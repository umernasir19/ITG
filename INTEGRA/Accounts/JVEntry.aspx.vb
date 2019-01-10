Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class JVEntry
    Inherits System.Web.UI.Page
    Dim objtblJVMst As New tblJVMst
    Dim objtblJvDtl As New tblJvDtl
    Dim objgeneralCode As New GeneralCode
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim tblJVMstID As Long
    Dim dtAC As DataTable
    Dim AccountCode As String
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tblJVMstID = Request.QueryString("ltblJVMstID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            SetInitialRow()
            If tblJVMstID > 0 Then
                EditMode()
                btnSave.Text = "Update"
                btnSave.Visible = True
            Else
                '    ' BindBookAccountFirstTime()
                txtVoucherdate.Text = Date.Now
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
            End If
        End If
        PageHeader("JOURNAL VOUCHER ENTRY FORM")
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtVoucherdate.Text
            'Dim txtVoucherdate As Date
            'If chkshowCalander.Checked = True Then
            '    Voucherdate = txtVoucherdate.Text
            'Else
            '    Voucherdate = txtVoucherdate2.Text
            'End If
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            Dim DayP As String = Voucherdate.Day
            If DayP.Length = 1 Then
                DayP = "0" & Voucherdate.Day
            Else
                DayP = Voucherdate.Day
            End If

            year = year.Substring(2, 2)
            Dim Month As String = Voucherdate.Month
            Dim CodeMonth As String
            If Month = 1 Then
                CodeMonth = "01"
            ElseIf Month = 2 Then
                CodeMonth = "02"
            ElseIf Month = 3 Then
                CodeMonth = "03"
            ElseIf Month = 4 Then
                CodeMonth = "04"
            ElseIf Month = 5 Then
                CodeMonth = "05"
            ElseIf Month = 6 Then
                CodeMonth = "06"
            ElseIf Month = 7 Then
                CodeMonth = "07"
            ElseIf Month = 8 Then
                CodeMonth = "08"
            ElseIf Month = 9 Then
                CodeMonth = "09"
            Else
                CodeMonth = Month
            End If

            Dim LastVoucherNo As String = objtblJVMst.GetLastVoucherNo(Month, yearP, DayP)
            Dim PreviousMonth As Integer
            Dim Previousday As Integer
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                Dim LastCodee As Integer
                PreviousMonth = LastVoucherNo.Substring(5, 2)
                Previousday = LastVoucherNo.Substring(7, 2)
                If LastVoucherNo.Length = 14 Then
                    LastCodee = LastVoucherNo.Substring(10, 4)
                ElseIf LastVoucherNo.Length = 16 Then
                    LastCodee = LastVoucherNo.Substring(10, 6)
                ElseIf LastVoucherNo.Length = 17 Then
                    LastCodee = LastVoucherNo.Substring(10, 7)
                ElseIf LastVoucherNo.Length = 18 Then
                    LastCodee = LastVoucherNo.Substring(10, 8)
                End If

                If PreviousMonth = Month And Previousday = DayP Then
                    If LastCodee < 10 Then
                        If LastCodee = 9 Then
                            LastCode = "00" & Val(LastCodee + 1)
                        Else
                            LastCode = "000" & Val(LastCodee + 1)
                        End If

                    ElseIf LastCodee < 100 Or LastCodee = 10 Then
                        If LastCodee = 99 Then
                            LastCode = "0" & Val(LastCodee + 1)
                        Else
                            LastCode = "00" & Val(LastCodee + 1)
                        End If

                    ElseIf LastCodee < 1000 Or LastCodee = 100 Then
                        If LastCodee = 999 Then
                            LastCode = Val(LastCodee + 1)
                        Else
                            LastCode = "0" & Val(LastCodee + 1)
                        End If
                    Else
                        LastCode = Val(LastCodee + 1)
                    End If
                Else
                    LastCode = "0001"
                End If
            End If
            VoucherNo = "JV" & "-" & year & "" & CodeMonth & "" & "" & DayP & "-" & LastCode
            txtVoucherNo.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub SetInitialRow()
        Dim dt As New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("tblJvDtlID", GetType(String)))
        dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
        dt.Columns.Add(New DataColumn("AccountCode", GetType(String)))
        dt.Columns.Add(New DataColumn("AccountName", GetType(String)))
        dt.Columns.Add(New DataColumn("VoucherType", GetType(String)))
        dt.Columns.Add(New DataColumn("Debit", GetType(String)))
        dt.Columns.Add(New DataColumn("Credit", GetType(String)))
        dt.Columns.Add(New DataColumn("TypeID", GetType(String)))
        dr = dt.NewRow()
        dr("tblJvDtlID") = 0
        dr("RowNumber") = 1
        dr("AccountCode") = String.Empty
        dr("AccountName") = String.Empty
        dr("VoucherType") = String.Empty
        dr("Debit") = String.Empty
        dr("Credit") = String.Empty
        dr("TypeID") = String.Empty
        dt.Rows.Add(dr)
        Session("CurrentTable") = dt
        dgJVDetail.DataSource = dt
        dgJVDetail.DataBind()
        BindcmbCRDR()

        '---For shipmentdate
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(i).FindControl("lblTypeID"), Label)
            Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtAccountCode"), TextBox)
            Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(i).FindControl("lblRowNo"), Label)
            Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtAccountName"), TextBox)
            Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtDebit"), TextBox)
            Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtCredit"), TextBox)
            Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(i).FindControl("cmbType"), DropDownList)
            lblRowNo.Text = dt.Rows(i)("RowNumber")
            txtAccountName.Text = dt.Rows(i)("AccountName")
            txtAccountCode.Text = dt.Rows(i)("AccountCode")
            cmbType.SelectedValue = dt.Rows(i)("VoucherType")
            txtDebit.Text = dt.Rows(i)("Debit")
            txtCredit.Text = dt.Rows(i)("Credit")
            lblTypeID.Text = dt.Rows(i)("TypeID")
            cmbType.SelectedValue = 1
            txtDebit.Enabled = True
            txtCredit.Enabled = False
        Next
    End Sub
    Sub BindcmbCRDR()
        Try
            Dim x As Integer = 0
            For x = 0 To dgJVDetail.Items.Count - 1
                Dim cmbType As DropDownList = CType(dgJVDetail.Items(x).FindControl("cmbType"), DropDownList)
                Dim Dt As DataTable
                Dt = objtblJVMst.GetDRCR
                If cmbType IsNot Nothing Then
                    cmbType.DataSource = Dt
                    cmbType.DataTextField = "DBCR"
                    cmbType.DataValueField = "JVTypeID" '   
                    cmbType.DataBind()
                    cmbType.DataSource = Dt
                    cmbType.Items.Insert(0, New ListItem("Select", "0"))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

            Dim x As Integer = dgJVDetail.Items.Count - 1
            Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblTypeID"), Label)
            Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountCode"), TextBox)
            Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblRowNo"), Label)
            Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountName"), TextBox)
            Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtDebit"), TextBox)
            Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtCredit"), TextBox)
            Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(x).FindControl("cmbType"), DropDownList)
            If cmbType.SelectedValue = 1 Then
                If txtDebit.Text = "" Or txtDebit.Text = "000.00" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                ElseIf txtAccountName.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    AddNewRowToGrid()

                    Dim cmbTypee As DropDownList = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("cmbType"), DropDownList)
                    cmbTypee.SelectedValue = 2
                    '--assign values
                    Dim txtCreditee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                    Dim totalCredit As Decimal = 0
                    Dim TotalDebit As Decimal = 0
                    TotalDebit = Convert.ToDecimal(txttotalDebit.Text)
                    totalCredit = Convert.ToDecimal(txttotalCredit.Text)
                    If totalCredit > TotalDebit Then
                        txtCreditee.Text = 0
                    ElseIf totalCredit = TotalDebit Then
                        txtCreditee.Text = 0
                    ElseIf totalCredit < TotalDebit Then
                        txtCreditee.Text = TotalDebit - totalCredit
                    End If
                    CalculateTotal()
                End If
            Else
                If txtCredit.Text = "" Or txtCredit.Text = "000.00" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                ElseIf txtAccountName.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    AddNewRowToGrid()

                    Dim cmbTypee As DropDownList = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("cmbType"), DropDownList)
                    cmbTypee.SelectedValue = 1

                    '--assign values
                    Dim txtDebitee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                    Dim totalCredit As Decimal = 0
                    Dim TotalDebit As Decimal = 0
                    TotalDebit = Convert.ToDecimal(txttotalDebit.Text)
                    totalCredit = Convert.ToDecimal(txttotalCredit.Text)
                    If totalCredit < TotalDebit Then
                        txtDebitee.Text = 0
                    ElseIf totalCredit = TotalDebit Then
                        txtDebitee.Text = 0
                    ElseIf totalCredit > TotalDebit Then
                        txtDebitee.Text = totalCredit - TotalDebit
                    End If
                    CalculateTotal()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0

        If Session("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    'extract the TextBox values
                    Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(rowIndex).FindControl("lblTypeID"), Label)
                    Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(rowIndex).FindControl("lblRowNo"), Label)
                    Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtAccountName"), TextBox)
                    Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtAccountCode"), TextBox)
                    Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtDebit"), TextBox)
                    Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtCredit"), TextBox)
                    Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(rowIndex).FindControl("cmbType"), DropDownList)
                    Dim tblJvDtlID As String = dgJVDetail.Items(rowIndex).Cells(0).Text
                    drCurrentRow = dtCurrentTable.NewRow()
                    If tblJVMstID > 0 Then
                        drCurrentRow("tblJvDtlID") = 0
                    Else
                        drCurrentRow("tblJvDtlID") = tblJvDtlID
                    End If
                    drCurrentRow("RowNumber") = i + 1
                    drCurrentRow("AccountCode") = String.Empty
                    drCurrentRow("AccountName") = String.Empty
                    drCurrentRow("VoucherType") = String.Empty

                    If cmbType.SelectedValue = 1 Then
                        drCurrentRow("TypeID") = 2
                        drCurrentRow("Credit") = 0
                    Else
                        drCurrentRow("TypeID") = 1
                        drCurrentRow("Debit") = 0
                    End If

                    'dtCurrentTable.Rows(i - 1)("RowNumber") = lblRowNo.Text
                    dtCurrentTable.Rows(i - 1)("AccountCode") = txtAccountCode.Text
                    dtCurrentTable.Rows(i - 1)("AccountName") = txtAccountName.Text
                    dtCurrentTable.Rows(i - 1)("VoucherType") = cmbType.SelectedItem.Text
                    dtCurrentTable.Rows(i - 1)("Debit") = txtDebit.Text
                    dtCurrentTable.Rows(i - 1)("Credit") = txtCredit.Text
                    dtCurrentTable.Rows(i - 1)("TypeID") = cmbType.SelectedValue
                    rowIndex += 1
                Next
                dtCurrentTable.Rows.Add(drCurrentRow)
                Session("CurrentTable") = dtCurrentTable

                dgJVDetail.DataSource = dtCurrentTable
                dgJVDetail.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
    End Sub
    Private Sub SetPreviousData()
        BindcmbCRDR()
        Dim rowIndex As Integer = 0
        If Session("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(rowIndex).FindControl("lblRowNo"), Label)
                    Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtAccountName"), TextBox)
                    Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtAccountCode"), TextBox)
                    Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtDebit"), TextBox)
                    Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(rowIndex).FindControl("txtCredit"), TextBox)
                    Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(rowIndex).FindControl("cmbType"), DropDownList)
                    Dim tblJvDtlID As String = dgJVDetail.Items(rowIndex).Cells(0).Text

                    lblRowNo.Text = dt.Rows(i)("RowNumber").ToString()
                    txtAccountCode.Text = dt.Rows(i)("AccountCode").ToString()
                    txtAccountName.Text = dt.Rows(i)("AccountName").ToString()
                    If dt.Rows(i)("TypeID") = 1 Then
                        txtDebit.Text = Convert.ToDecimal(dt.Rows(i)("Debit")).ToString("#,000.00")
                    End If
                    If dt.Rows(i)("TypeID") = 2 Then
                        txtCredit.Text = Convert.ToDecimal(dt.Rows(i)("Credit")).ToString("#,000.00")
                    End If
                    cmbType.SelectedItem.Text = dt.Rows(i)("VoucherType").ToString()
                    cmbType.SelectedValue = dt.Rows(i)("TypeID").ToString()
                    rowIndex += 1
                Next
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim txtAccountNameE As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtAccountName"), TextBox)

            If dgJVDetail.Items.Count > 0 Then
                Dim dtvoucherno As New DataTable
                dtvoucherno = objtblJVMst.CheckVoucherNo(txtVoucherNo.Text)
                If tblJVMstID > 0 Then
                    ' Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                    'Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                    If Convert.ToDecimal(txttotalDebit.Text) = Convert.ToDecimal(txttotalCredit.Text) Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        If txtAccountNameE.Text = "" Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                        Else
                            SaveAllData()
                            Response.Redirect("JVView.aspx")
                        End If
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Debit and Credit Not Equal.")
                    End If
                Else
                    If dtvoucherno.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher No.  " & txtVoucherNo.Text & " Already Exist.")
                    Else
                        Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                        Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                        If Convert.ToDecimal(txttotalDebit.Text) = Convert.ToDecimal(txttotalCredit.Text) Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                            If txtDebit.Text <> "" Then
                                If Convert.ToDecimal(txtDebit.Text) = 0 Then
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can not allow Debit/Credit zero")
                                Else
                                    If txtAccountNameE.Text = "" Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                                    Else
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                                        SaveAllData()
                                        Response.Redirect("JVView.aspx")
                                    End If
                                End If
                            ElseIf txtCredit.Text <> "" Then
                                If Convert.ToDecimal(txtCredit.Text) = 0 Then
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can not allow Debit/Credit zero")
                                Else
                                    If txtAccountNameE.Text = "" Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                                    Else
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                                        SaveAllData()
                                        Response.Redirect("JVView.aspx")
                                    End If
                                End If
                            End If

                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Debit and Credit Not Equal.")
                        End If
                    End If
                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Atleast One detail Required.")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveAllData()
        Try

            If txtVoucherNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher No. Not Empty.")

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                With objtblJVMst
                    If tblJVMstID > 0 Then
                        .tblJVMstID = tblJVMstID
                    Else
                        .tblJVMstID = 0
                    End If
                    .CompanyId = "0001"
                    .VoucherNo = txtVoucherNo.Text

                    'If chkshowCalander.Checked = True Then
                    '    .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                    'Else
                    '    .VoucherDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
                    'End If
                    .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                    .Description = txtDescriptionDetail.Text
                    .Cancel = "N/A"
                    .EntryDate = Date.Now
                    .UserId = objtblJVMst.GetUserName(CLng(Session("Userid")))
                    .InvoiceNo = "N/A"
                    .InvoiceDate = Date.Now
                    .UID = CLng(Session("Userid"))
                    .TotalAmount = Convert.ToDecimal(txttotalDebit.Text) + Convert.ToDecimal(txttotalCredit.Text)
                    .VNo = txtVno.Text
                    If chkshowCalander.Checked = True Then
                        .ChkDate = True
                    Else
                        .ChkDate = False
                    End If
                    .CargoId = 0
                    .SavetblJVMst()
                End With

                Dim x As Integer
                For x = 0 To dgJVDetail.Items.Count - 1
                    Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblTypeID"), Label)
                    Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblRowNo"), Label)
                    Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountName"), TextBox)
                    Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountCode"), TextBox)
                    Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtDebit"), TextBox)
                    Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtCredit"), TextBox)
                    Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(x).FindControl("cmbType"), DropDownList)

                    With objtblJvDtl
                        .tblJvDtlID = dgJVDetail.Items(x).Cells(0).Text
                        If tblJVMstID > 0 Then
                            .tblJVMstID = tblJVMstID
                        Else
                            .tblJVMstID = objtblJVMst.GetID()
                        End If
                        .CompanyId = "0001"
                        .VoucherNo = txtVoucherNo.Text
                        .AccountCode = txtAccountCode.Text
                        .DescriptionEntry = txtDescriptionDetail.Text
                        .VoucherType = cmbType.SelectedItem.Text
                        If cmbType.SelectedItem.Text = "Debit" Then
                            .Debit = Convert.ToDecimal(txtDebit.Text)
                            .Credit = 0
                        Else
                            .Debit = 0
                            .Credit = Convert.ToDecimal(txtCredit.Text)
                        End If
                        .Cancel = "N/A"
                        .ChqClear = 0
                        .ChqClearDate = Date.Today
                        .BankStDate = Date.Today
                        .NotCharge = 0
                        .StaxInvNo = "N/A"
                        .STaxInvDate = Date.Today
                        .TypeCode = "N/A"
                        .ExcludingStAmt = 0
                        .StaxPer = 0
                        .STaxAmt = 0
                        .NetAmount = 0
                        .Transfer = 0
                        .NotCharge = 0
                        .CostCCode = dgJVDetail.Items(x).Cells(2).Text '"N/A" '----Save Row number
                        .SubCostCCode = "N/A"
                        .Clear_Date = Date.Today
                        Dim TopSNo As Integer = objtblJVMst.GetTopSNO()
                        .Sno = Val(TopSNo + 1)
                        .SavetblJvDtl()
                    End With
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If tblJVMstID > 0 Then
                Dim x As Integer
                For x = 0 To dgJVDetail.Items.Count - 1
                    Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblTypeID"), Label)
                    Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(x).FindControl("lblRowNo"), Label)
                    Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountName"), TextBox)
                    Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtAccountCode"), TextBox)
                    Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtDebit"), TextBox)
                    Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(x).FindControl("txtCredit"), TextBox)
                    Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(x).FindControl("cmbType"), DropDownList)
                    If cmbType.SelectedIndex = 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Type.")
                    ElseIf txtAccountName.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                        'txtAccountName.Text = ""
                        txtAccountCode.Text = ""
                        txtAccountName.Text = ""
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
                        dtAC = objtblJVMst.GetUniqueAccountName(txtAccountName.Text)
                        If dtAC.Rows.Count > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                            txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                            txtAccountName.Text = dtAC.Rows(0)("AccountName")
                            If cmbType.SelectedValue = 1 Then '--DEBIT
                                txtDebit.Enabled = True
                                txtCredit.Enabled = False
                                txtDebit.Focus()
                            Else
                                txtDebit.Enabled = False
                                txtCredit.Enabled = True
                                txtCredit.Focus()

                            End If
                        End If

                    End If
                    CalculateTotal()
                Next
            Else
                Dim x As Integer
                Dim txtAccountCode As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtAccountCode"), TextBox)
                Dim lblRowNo As Label = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("lblRowNo"), Label)
                Dim txtAccountName As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtAccountName"), TextBox)
                Dim txtDebit As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                Dim txtCredit As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                Dim cmbType As DropDownList = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("cmbType"), DropDownList)
                If cmbType.SelectedIndex = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Type.")
                ElseIf txtAccountName.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                    'txtAccountName.Text = ""
                    txtAccountCode.Text = ""
                    txtAccountName.Text = ""
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
                    dtAC = objtblJVMst.GetUniqueAccountName(txtAccountName.Text)
                    If dtAC.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                        txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                        txtAccountName.Text = dtAC.Rows(0)("AccountName")
                        If cmbType.SelectedValue = 1 Then '--DEBIT
                            txtDebit.Enabled = True
                            txtCredit.Enabled = False
                            txtDebit.Focus()
                        Else
                            txtDebit.Enabled = False
                            txtCredit.Enabled = True
                            txtCredit.Focus()

                        End If
                    End If

                End If
                CalculateTotal()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtAccountCode As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtAccountCode"), TextBox)
            Dim lblRowNo As Label = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("lblRowNo"), Label)
            Dim txtAccountName As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtAccountName"), TextBox)
            Dim txtDebit As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
            Dim txtCredit As TextBox = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
            Dim cmbType As DropDownList = CType(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("cmbType"), DropDownList)

            If cmbType.SelectedValue = 1 Then '--DEBIT
                txtDebit.Enabled = True
                txtCredit.Enabled = False

                '--assign values
                Dim txtDebitee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                Dim txtCreditee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                Dim totalCredit As Decimal = 0
                Dim TotalDebit As Decimal = 0
                txtCredit.Text = ""
                TotalDebit = Convert.ToDecimal(txttotalDebit.Text)
                totalCredit = Convert.ToDecimal(txttotalCredit.Text)
                If totalCredit < TotalDebit Then
                    txtDebitee.Text = 0
                ElseIf totalCredit = TotalDebit Then
                    txtDebitee.Text = 0
                ElseIf totalCredit > TotalDebit Then
                    txtDebitee.Text = totalCredit - TotalDebit
                End If

            Else
                txtDebit.Enabled = False
                txtCredit.Enabled = True

                '--assign values
                Dim txtDebitee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtDebit"), TextBox)
                Dim txtCreditee As TextBox = DirectCast(dgJVDetail.Items(dgJVDetail.Items.Count - 1).FindControl("txtCredit"), TextBox)
                txtDebitee.Text = ""
                Dim totalCredit As Decimal = 0
                Dim TotalDebit As Decimal = 0
                TotalDebit = Convert.ToDecimal(txttotalDebit.Text)
                totalCredit = Convert.ToDecimal(txttotalCredit.Text)
                If totalCredit > TotalDebit Then
                    txtCreditee.Text = 0
                ElseIf totalCredit = TotalDebit Then
                    txtCreditee.Text = 0
                ElseIf totalCredit < TotalDebit Then
                    txtCreditee.Text = TotalDebit - totalCredit
                End If

            End If
            '  txtAccountName.Focus()
            CalculateTotal()
        Catch ex As Exception

        End Try
    End Sub
    Sub CalculateTotal()
        Try
            txttotalDebit.Text = ""
            txttotalCredit.Text = ""
            Dim x As Integer
            For x = 0 To dgJVDetail.Items.Count - 1
                Dim txtAccountCode As TextBox = CType(dgJVDetail.Items(x).FindControl("txtAccountCode"), TextBox)
                Dim lblRowNo As Label = CType(dgJVDetail.Items(x).FindControl("lblRowNo"), Label)
                Dim txtAccountName As TextBox = CType(dgJVDetail.Items(x).FindControl("txtAccountName"), TextBox)
                Dim txtDebit As TextBox = CType(dgJVDetail.Items(x).FindControl("txtDebit"), TextBox)
                Dim txtCredit As TextBox = CType(dgJVDetail.Items(x).FindControl("txtCredit"), TextBox)
                Dim cmbType As DropDownList = CType(dgJVDetail.Items(x).FindControl("cmbType"), DropDownList)
                'Dim totalDebit As Decimal
                'Dim totalCredit As Decimal
                If txttotalDebit.Text = "" Then
                    txttotalDebit.Text = 0
                End If
                If txttotalCredit.Text = "" Then
                    txttotalCredit.Text = 0
                End If
                If txtDebit.Text <> "" Then
                    txttotalDebit.Text = (Convert.ToDecimal(txttotalDebit.Text) + Convert.ToDecimal(txtDebit.Text)).ToString("#,000.00")
                    txtDebit.Text = Convert.ToDecimal(txtDebit.Text).ToString("#,000.00")
                End If
                If txtCredit.Text <> "" Then
                    txtCredit.Text = Convert.ToDecimal(txtCredit.Text).ToString("#,000.00")
                    txttotalCredit.Text = (Convert.ToDecimal(txttotalCredit.Text) + Convert.ToDecimal(txtCredit.Text)).ToString("#,000.00")
                End If
            Next
            If Convert.ToDecimal(txttotalCredit.Text) = Convert.ToDecimal(txttotalDebit.Text) Then
                If Convert.ToDecimal(txttotalCredit.Text) = 0 And Convert.ToDecimal(txttotalDebit.Text) = 0 Then
                    txtDescriptionDetail.Enabled = False
                    btnSave.Visible = False
                    btnCancel.Visible = False
                Else
                    txtDescriptionDetail.Enabled = True
                    btnSave.Visible = True
                    btnCancel.Visible = True
                End If
            Else
                txtDescriptionDetail.Enabled = False
                btnSave.Visible = False
                btnCancel.Visible = False
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDebit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            CalculateTotal()
            btnAdd.Focus()
            If Convert.ToDecimal(txttotalCredit.Text) = Convert.ToDecimal(txttotalDebit.Text) Then
                txtDescriptionDetail.Enabled = True
                btnSave.Visible = True
                btnCancel.Visible = True
            Else
                txtDescriptionDetail.Enabled = False
                btnSave.Visible = False
                btnCancel.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtCredit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            CalculateTotal()
            btnAdd.Focus()
            If Convert.ToDecimal(txttotalCredit.Text) = Convert.ToDecimal(txttotalDebit.Text) Then
                txtDescriptionDetail.Enabled = True
                btnSave.Visible = True
                btnCancel.Visible = True
            Else
                txtDescriptionDetail.Enabled = False
                btnSave.Visible = False
                btnCancel.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JVView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub chkshowCalander_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkshowCalander.CheckedChanged
    '    Try
    '        If chkshowCalander.Checked = True Then
    '            txtVoucherdate2.Visible = False
    '            txtVoucherdate.Visible = True
    '            ImageButton1.Visible = True

    '        Else
    '            txtVoucherdate2.Visible = True
    '            txtVoucherdate.Visible = False
    '            ImageButton1.Visible = False
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objtblJVMst.GetJvDataOnEdit(tblJVMstID)
            If dt.Rows.Count > 0 Then
                txtVoucherNo.Text = dt.Rows(0)("VoucherNo")

                'If dt.Rows(0)("ChkDate") = "0" Then
                '    chkshowCalander.Checked = False
                '    txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
                'Else
                '    chkshowCalander.Checked = False
                '    txtVoucherdate2.Text = dt.Rows(0)("VoucherDate")
                'End If
                txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
                txtDescriptionDetail.Text = dt.Rows(0)("Description")
                txtVno.Text = dt.Rows(0)("VNo")

                dgJVDetail.DataSource = dt
                dgJVDetail.DataBind()
                BindcmbCRDR()
                'chkshowCalander.Checked = False

                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Dim lblTypeID As Label = DirectCast(dgJVDetail.Items(i).FindControl("lblTypeID"), Label)
                    Dim txtAccountCode As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtAccountCode"), TextBox)
                    Dim lblRowNo As Label = DirectCast(dgJVDetail.Items(i).FindControl("lblRowNo"), Label)
                    Dim txtAccountName As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtAccountName"), TextBox)
                    Dim txtDebit As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtDebit"), TextBox)
                    Dim txtCredit As TextBox = DirectCast(dgJVDetail.Items(i).FindControl("txtCredit"), TextBox)
                    Dim cmbType As DropDownList = DirectCast(dgJVDetail.Items(i).FindControl("cmbType"), DropDownList)
                    lblRowNo.Text = i + 1
                    'txtAccountName.Text = dt.Rows(i)("AccountName")
                    txtAccountCode.Text = dt.Rows(i)("AccountCode")
                    txtAccountName.Text = objtblJVMst.GetAccountNameByAccountNo(dt.Rows(i)("AccountCode"))

                    If dt.Rows(i)("VoucherType") = "Debit" Then
                        cmbType.SelectedValue = 1
                        txtDebit.Text = dt.Rows(i)("Debit")
                        txtCredit.Text = "0"
                        lblTypeID.Text = 1
                        txtCredit.Enabled = False
                        txtDebit.Enabled = True
                    Else
                        cmbType.SelectedValue = 2
                        txtDebit.Text = "0"
                        txtCredit.Text = dt.Rows(i)("Credit")
                        lblTypeID.Text = 2
                        txtCredit.Enabled = True
                        txtDebit.Enabled = False
                    End If
                Next
                CalculateTotal()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub txtVoucherdate2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate2.TextChanged
    '    Try
    '        VoucherNoGenerateOnLoad()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub txtVoucherdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate.TextChanged
    '    Try
    '        VoucherNoGenerateOnLoad()
    '    Catch ex As Exception

    '    End Try
    'End Sub

End Class



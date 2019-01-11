Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Imports Integra.classes

Public Class LedgerPrint
    Inherits System.Web.UI.Page
    Dim YearFirst, YearSecond As String
    Dim objtblBankMst As New tblBankMst
    Dim AccountCode As String
    Dim objDataTable As DataTable
    Dim OpeningBalance As Decimal
    Dim accountName, FiscalYear As String
    Dim startdate, enddate As Date
    Dim lblCd As String
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountCode = Request.QueryString("AccountCode")
        accountName = Request.QueryString("AccountName")
        FiscalYear = Request.QueryString("FiscalYear")
        Dim objDataView As DataView

        YearFirst = Session("BANKsDATE") '"07/01/" + FiscalYear.Substring(0, 4)
        YearSecond = Session("BANKeeDATE") '"06/30/20" + FiscalYear.Substring(5, 2)
        startdate = Session("BANKsDATE")
        enddate = Session("BANKeeDATE")
        lblFrom.Text = YearFirst
        lblTo.Text = YearSecond

        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
    End Sub

    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        lblTotalDebit.Text = ""
        lblTotalCredit.Text = ""

        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        dt = objDataView.ToTable()

        For i As Integer = 0 To dt.Rows.Count - 1
            'Dim lblVoucherNo As Label = DirectCast(dgView.Items(i).FindControl("lblVoucherNo"), Label)
            Dim lblVoucherdate As Label = DirectCast(dgView.Items(i).FindControl("lblVoucherdate"), Label)
            Dim lblChecqNo As Label = DirectCast(dgView.Items(i).FindControl("lblChecqNo"), Label)
            Dim lblCheqDate As Label = DirectCast(dgView.Items(i).FindControl("lblCheqDate"), Label)
            Dim lblDescription As Label = DirectCast(dgView.Items(i).FindControl("lblDescription"), Label)
            Dim lblbb As Label = DirectCast(dgView.Items(i).FindControl("lblbb"), Label)
            Dim Chkdate As String = dt.Rows(i)("ChequeDate")
            Dim Debit As Decimal = dt.Rows(i)("Debit")
            Dim Credit As Decimal = dt.Rows(i)("Credit")
            Dim lblCd As Label = DirectCast(dgView.Items(i).FindControl("lblCd"), Label)
            'lblVoucherNo.Text = dt.Rows(i)("VoucherNo")
            lblVoucherdate.Text = dt.Rows(i)("VoucherDate")
            lblChecqNo.Text = dt.Rows(i)("ChequeNo")
            If Chkdate = "" Or Chkdate = " " Then
                lblCheqDate.Text = ""
            Else
                Chkdate = Chkdate.Substring(0, 10)
                lblCheqDate.Text = Chkdate
            End If
            If Debit = 0 And Credit = 0 Then
                lblCd.Text = ""
            ElseIf Debit = 0 Then
                lblCd.Text = "CR"
            ElseIf Credit = 0 Then
                lblCd.Text = "DB"
            Else
                If Credit > Debit Then
                    lblCd.Text = "CR"
                ElseIf Debit > Credit Then
                    lblCd.Text = "DB"
                End If
            End If
            lblDescription.Text = dt.Rows(i)("DescriptionEntry")
            lblbb.Text = dt.Rows(i)("AccountName")
            lblTotalDebit.Text = Val(lblTotalDebit.Text) + dgView.Items(i).Cells(4).Text
            lblTotalCredit.Text = Val(lblTotalCredit.Text) + Val(dgView.Items(i).Cells(5).Text)

            If Val(dgView.Items(i).Cells(4).Text) > 0 Then
                dgView.Items(i).Cells(4).ForeColor = Drawing.Color.Black
            Else
                dgView.Items(i).Cells(4).ForeColor = Drawing.Color.White
            End If
            If Val(dgView.Items(i).Cells(5).Text) > 0 Then
                dgView.Items(i).Cells(5).ForeColor = Drawing.Color.Black
            Else
                dgView.Items(i).Cells(5).ForeColor = Drawing.Color.White
            End If
            If Val(dgView.Items(i).Cells(6).Text) > 0 Then
                dgView.Items(i).Cells(6).ForeColor = Drawing.Color.Black
            Else
                dgView.Items(i).Cells(6).ForeColor = Drawing.Color.White
            End If
            If Val(lblTotalDebit.Text) > 0 Then
                lblTotalDebit.ForeColor = Drawing.Color.Black
            Else
                lblTotalDebit.ForeColor = Drawing.Color.Gray
            End If
            If Val(lblTotalCredit.Text) > 0 Then
                lblTotalCredit.ForeColor = Drawing.Color.Black
            Else
                lblTotalCredit.ForeColor = Drawing.Color.Gray
            End If

        Next
        lbltotal.Text = Val(lblTotalDebit.Text) - Val(lblTotalCredit.Text)
        If Val(lbltotal.Text) > 0 Then
            lbltotal.ForeColor = Drawing.Color.Black
        Else
            lbltotal.ForeColor = Drawing.Color.Gray
        End If


        lblTotalDebit.Text = Convert.ToDecimal(lblTotalDebit.Text).ToString("#,##0.00")
        lblTotalCredit.Text = Convert.ToDecimal(lblTotalCredit.Text).ToString("#,##0.00")
        lbltotal.Text = Convert.ToDecimal(lbltotal.Text).ToString("#,##0.00")

        Session("dt") = Nothing
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim OBJDATE As New GeneralCode
        Dim GroupAct As String = "0102004"
        Dim GroupAct2 As String = "0102005"
        Dim dtgroupAct As New DataTable
        dtgroupAct = objtblBankMst.GetGroupAct(AccountCode)
        Session("dt") = Nothing
        Dim Dr As DataRow
        'Dim sdatee, edate As String
        'sdatee = OBJDATE.GetDateFormat(startdate)
        'edate = OBJDATE.GetDateFormat(enddate)
        Dim x As Integer
        Dim objDataView As DataView
        objtblBankMst.TruncateTempLedgerTable()
        '  If GroupAct = dtgroupAct.Rows(0)("GroupAct") Or GroupAct2 = dtgroupAct.Rows(0)("GroupAct") Then
        If GroupAct = dtgroupAct.Rows(0)("GroupAct") Or GroupAct2 = dtgroupAct.Rows(0)("GroupAct") Then
            objtblBankMst.InsertBPVData(AccountCode)
            objtblBankMst.InsertCVData(AccountCode)
        Else
            objtblBankMst.InsertBPVDataWithOutBank(AccountCode)
            objtblBankMst.InsertCVDataWithOutBank(AccountCode)
        End If
        objtblBankMst.InsertJVData(AccountCode)
        objtblBankMst.InsertPVData(AccountCode)

        'OpeningBalance = objtblBankMst.GetOpeningBalance(AccountCode)

        OpeningBalance = 0

        ' objDataTable = objtblBankMst.GetLedgerForPrint(OpeningBalance)
        objDataTable = objtblBankMst.GetLedgerForPrintNewDateWise(OpeningBalance, startdate, enddate)

        Session("objDataTable") = objDataTable

        ''-=------------------
        If (Not CType(Session("dt"), DataTable) Is Nothing) Then
            dt = Session("dt")
        Else
            dt = New DataTable
            With dt
                .Columns.Add("TempID", GetType(Long))
                .Columns.Add("VoucherNo", GetType(String))
                .Columns.Add("VoucherDate", GetType(String))
                .Columns.Add("ChequeNo", GetType(String))
                .Columns.Add("Chequedate", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("DescriptionEntry", GetType(String))
                .Columns.Add("AccountName", GetType(String))
                .Columns.Add("Debit", GetType(String))
                .Columns.Add("Credit", GetType(String))
                .Columns.Add("Balance", GetType(String))
            End With
        End If

        If objDataTable.Rows.Count > 0 Then
            For x = 0 To objDataTable.Rows.Count - 1
                If x = 0 Then

                    Dim strArr() As String
                    strArr = YearSecond.Split("/")

                    Dim FirstPart As String = strArr(0) & "/" & strArr(1) & "/"
                    Dim Lastyear As String = strArr(2)
                    'Dim FirstPart As String = YearSecond.Substring(1, 5)
                    'Dim Lastyear As String = YearSecond.Substring(6, 4)
                    Lastyear = Lastyear - 1
                    Lastyear = FirstPart & Lastyear

                    Dr = dt.NewRow()

                    Dr("TempID") = 0
                    Dr("VoucherNo") = ""
                    Dr("VoucherDate") = Lastyear
                    Dr("ChequeNo") = ""
                    Dr("Chequedate") = ""
                    Dr("Description") = ""
                    Dr("DescriptionEntry") = "Balance B/F"
                    Dr("AccountName") = ""
                    If OpeningBalance > 0 Then
                        Dr("Debit") = OpeningBalance
                        Dr("Credit") = 0
                        Dr("Balance") = OpeningBalance
                    Else
                        Dr("Debit") = 0
                        Dr("Credit") = -1 * OpeningBalance
                        Dr("Balance") = OpeningBalance
                    End If

                    dt.Rows.Add(Dr)


                    Dr = dt.NewRow()
                    Dr("TempID") = objDataTable.Rows(x)("TempID")
                    Dr("VoucherNo") = objDataTable.Rows(x)("VoucherNo")
                    Dr("VoucherDate") = objDataTable.Rows(x)("VoucherDatee")
                    Dr("ChequeNo") = objDataTable.Rows(x)("ChequeNo")
                    Dr("Chequedate") = objDataTable.Rows(x)("Chequedate")
                    Dr("Description") = objDataTable.Rows(x)("Description")
                    Dr("DescriptionEntry") = objDataTable.Rows(x)("DescriptionEntry")
                    Dr("AccountName") = objDataTable.Rows(x)("AccountName")
                    Dr("Debit") = Convert.ToDecimal(objDataTable.Rows(x)("Debit")).ToString("#,##0.00") 'objDataTable.Rows(x)("Debit")
                    Dr("Credit") = Convert.ToDecimal(objDataTable.Rows(x)("Credit")).ToString("#,##0.00") 'objDataTable.Rows(x)("Credit")
                    Dr("Balance") = Convert.ToDecimal(objDataTable.Rows(x)("Balance")).ToString("#,##0.00") 'objDataTable.Rows(x)("Balance")
                    ' objDataTable.Rows.Add(Dr)
                Else
                    Dr = dt.NewRow()
                    Dr("TempID") = objDataTable.Rows(x)("TempID")
                    Dr("VoucherNo") = objDataTable.Rows(x)("VoucherNo")
                    Dr("VoucherDate") = objDataTable.Rows(x)("VoucherDatee")
                    Dr("ChequeNo") = objDataTable.Rows(x)("ChequeNo")
                    Dr("Chequedate") = objDataTable.Rows(x)("Chequedate")
                    Dr("Description") = objDataTable.Rows(x)("Description")
                    Dr("DescriptionEntry") = objDataTable.Rows(x)("DescriptionEntry")
                    Dr("AccountName") = objDataTable.Rows(x)("AccountName")
                    'Dr("Debit") = objDataTable.Rows(x)("Debit")
                    'Dr("Credit") = objDataTable.Rows(x)("Credit")
                    'Dr("Balance") = objDataTable.Rows(x)("Balance")
                    Dr("Debit") = Convert.ToDecimal(objDataTable.Rows(x)("Debit")).ToString("#,##0.00") 'objDataTable.Rows(x)("Debit")
                    Dr("Credit") = Convert.ToDecimal(objDataTable.Rows(x)("Credit")).ToString("#,##0.00") 'objDataTable.Rows(x)("Credit")
                    Dr("Balance") = Convert.ToDecimal(objDataTable.Rows(x)("Balance")).ToString("#,##0.00") 'objDataTable.Rows(x)("Balance")
                End If
                dt.Rows.Add(Dr)

            Next
        Else
            'Dim FirstPart As String = YearSecond.Substring(1, 5)
            'Dim FirstPart As String = YearSecond.Substring(0, 5)
            'Dim Lastyear As String = YearSecond.Substring(6, 4)
            ' Dim Lastyear As String = YearSecond.Substring(5, 4)

            Dim strArr() As String
            strArr = YearSecond.Split("/")

            Dim FirstPart As String = strArr(0) & "/" & strArr(1) & "/"
            Dim Lastyear As String = strArr(2)

            Lastyear = Lastyear - 1
            Lastyear = FirstPart & Lastyear
            Dr = dt.NewRow()
            Dr("TempID") = 0
            Dr("VoucherNo") = ""
            Dr("VoucherDate") = Lastyear
            Dr("ChequeNo") = ""
            Dr("Chequedate") = ""
            Dr("Description") = ""
            Dr("DescriptionEntry") = "Balance B/F"
            Dr("AccountName") = ""
            If OpeningBalance > 0 Then
                Dr("Debit") = OpeningBalance
                Dr("Credit") = 0
                Dr("Balance") = OpeningBalance
            Else
                Dr("Debit") = 0
                Dr("Credit") = -1 * OpeningBalance
                Dr("Balance") = OpeningBalance

            End If
            'If Dr("Debit") = 0 Then
            '    lblCd.Text = "CR"
            'ElseIf Dr("Credit") = 0 Then
            '    lblCd.Text = "DR"
            'Else
            '    If Dr("Credit") > Dr("Debit") Then
            '        lblCd.Text = "CR"
            '    ElseIf Dr("Debit") > Dr("Credit") Then
            '        lblCd.Text = "DR"
            '    End If
            'End If
            dt.Rows.Add(Dr)

        End If
        Session("dt") = dt

        lblOpeningBalance.Text = OpeningBalance
        lblAccountName.Text = accountName
        ''--------------------------
        If objDataTable.Rows.Count > 0 Then
            lbltotal.Text = objDataTable.Rows(objDataTable.Rows.Count - 1)("Balance")
        Else
        End If

        objDataView = New DataView(dt)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub

End Class


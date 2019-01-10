Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class CashVoucherEntry
    Inherits System.Web.UI.Page
    Dim objtblCashMst As New tblCashMst
    Dim objtblCashDtl As New tblCashDtl
    Dim objInvoiceMst As New InvoiceMst
    Dim objInvoiceDtl As New InvoiceDtl

    Dim objgeneralCode As New GeneralCode
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim tblCashMstID As Long
    Dim dtAC As DataTable
    Dim AccountCode As String
    Dim objContactType As New ContactType
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tblCashMstID = Request.QueryString("ltblCashMstID")
        If Not Page.IsPostBack Then
            PNAfterAdjustClickLabelGridBind.Visible = False
            BindBookAccount()
            Session("dtDetail") = Nothing
            If tblCashMstID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else

                cmbVoucherType.SelectedValue = 2
                btnSave.Text = "Save"
                txtVoucherdate.Text = Date.Now
                VoucherNoGenerateOnLoad()
                pnlbookaccountMst.Visible = True
                pnlbookaccountMstSearch.Visible = False
                pnlAccountCodedtl.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = True
            End If
        End If
        If cmbVoucherType.SelectedValue = 1 Then
            lblBankH.Text = "Cash Receipt Voucher"
        Else
            lblBankH.Text = "Cash Payment Voucher"
        End If
        PageHeader("CASH VOUCHER ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindBookAccountFirstTime()
        Dim dt As DataTable
        dt = objtblCashMst.GetBookAccountFirstTime()
        If dt.Rows.Count > 0 Then
            cmbBookAccount.DataSource = dt
            cmbBookAccount.DataTextField = "BookAccount"
            cmbBookAccount.DataValueField = "AccountCode"
            cmbBookAccount.DataBind()
            cmbBookAccount.Items.Insert(0, New ListItem("Select", "0"))
            '   cmbBookAccount.SelectedValue = dt.Rows(0)("AccountCode")
        Else
        End If

    End Sub
    Sub BindBookAccount()
        Dim dt As DataTable
        dt = objtblCashMst.GetCashNAME()
        If dt.Rows.Count > 0 Then
            cmbBookAccount.DataSource = dt
            cmbBookAccount.DataTextField = "AccountName"
            cmbBookAccount.DataValueField = "AccountCode"
            cmbBookAccount.DataBind()
            cmbBookAccount.Items.Insert(0, New ListItem("Select", "0"))
        Else
        End If
    End Sub
    Sub BindAccountCode()
        Dim dt As DataTable
        dt = objtblCashMst.GetBookAccount()
        If dt.Rows.Count > 0 Then
            cmbAccountCode.DataSource = dt
            cmbAccountCode.DataTextField = "BookAccount"
            cmbAccountCode.DataValueField = "AccountCode"
            cmbAccountCode.DataBind()
            cmbAccountCode.Items.Insert(0, New ListItem("Select", "0"))
        Else

        End If

    End Sub
    Sub BindAccountCodeFirstTime()
        Dim dt As DataTable
        dt = objtblCashMst.GetBookAccountFirstTime()
        If dt.Rows.Count > 0 Then
            cmbAccountCode.DataSource = dt
            cmbAccountCode.DataTextField = "BookAccount"
            cmbAccountCode.DataValueField = "AccountCode"
            cmbAccountCode.DataBind()
            cmbAccountCode.Items.Insert(0, New ListItem("Select", "0"))

            cmbAccountCode.SelectedValue = dt.Rows(0)("AccountCode")
        Else

        End If

    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail

                .Columns.Add("tblCashDtlID", GetType(Long))
                .Columns.Add("ChequeNo", GetType(String))
                .Columns.Add("ChequeDate", GetType(String))
                .Columns.Add("AccountCode", GetType(String))
                .Columns.Add("AccountName", GetType(String))
                .Columns.Add("DescriptionEntry", GetType(String))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("CostCenterId", GetType(String))
                .Columns.Add("Cost", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        If lbldetail.Text = "" Then
            Dr("tblCashDtlID") = 0
        Else
            Dr("tblCashDtlID") = lbldetail.Text
        End If
        'Dr("ChequeNo") = txtchequeNo.Text
        Dr("ChequeNo") = "N/A"
        'Dr("ChequeDate") = objgeneralCode.GetDate(txtchequedate.Text)
        Dr("ChequeDate") = " "

        ' If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
        Dr("AccountCode") = txtAccountCode.Text
        Dr("AccountName") = txtAccountName.Text
        Dr("CostCenterId") = lblCostCenterId.Text
        Dr("Cost") = txtCostCenter.Text
        ' Else
        'Dr("AccountCode") = cmbAccountCode.SelectedValue
        ' Dr("AccountName") = objtblCashMst.GetAccountName(cmbAccountCode.SelectedValue)
        'End If

        Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
        Dr("Type") = cmbType.SelectedItem.Text
        Dr("Amount") = txtamount.Text
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try

            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgView.Visible = True
                dgView.RecordCount = objDatatble.Rows.Count
                dgView.DataSource = objDatatble
                dgView.DataBind()

            Else
                dgView.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtDescriptionDetail.Text = ""
        lbldetail.Text = ""
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            saveData()
            Response.Redirect("CashVoucherView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub saveData()

        If txtVoucherNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("VoucherNo Not Empty.")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            With objtblCashMst
                If tblCashMstID > 0 Then
                    .tblCashMstID = tblCashMstID
                Else
                    .tblCashMstID = 0
                End If
                .CompanyId = "0001"
                .VoucherNo = txtVoucherNo.Text
                ' .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                'If chkshowCalander.Checked = True Then
                '    .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                'Else
                '    .VoucherDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
                'End If

                .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                    .BookAccount = cmbBookAccount.SelectedValue
                Else
                    .BookAccount = cmbBookAccount.SelectedValue
                End If
                .Description = txtdescription.Text
                If cmbVoucherType.SelectedItem.Text = "Cash Receipt" Then
                    .VoucherType = "R"
                Else
                    .VoucherType = "P"
                End If
                .Cancel = "N/A"
                .EntryDate = Date.Now
                .UserId = objtblCashMst.GetUserName(CLng(Session("Userid")))
                .VoucherNoOld = "N/A"
                .VoucherNoNew = "N/A"
                .UID = CLng(Session("Userid"))

                Dim AA As Decimal = 0
                Dim Total As Decimal = 0
                Dim A As Integer = 0
                For A = 0 To dgView.Items.Count - 1
                    AA = dgView.Items(A).Cells(7).Text
                    Total = Total + AA
                Next
                .TotalAmount = Total
                .InvoiceType = "N/A"
                .VNo = txtVno.Text
                If chkshowCalander.Checked = True Then
                    .ChkDate = True
                Else
                    .ChkDate = False
                End If
                .SavetblCashMst()
            End With

            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                With objtblCashDtl
                    .tblCashDtlID = dgView.Items(x).Cells(0).Text
                    If tblCashMstID > 0 Then
                        .tblCashMstID = tblCashMstID
                    Else
                        .tblCashMstID = objtblCashMst.GetID()
                    End If
                    .CompanyId = "0001"
                    .VoucherNo = txtVoucherNo.Text
                    .AccountCode = dgView.Items(x).Cells(3).Text
                    .DescriptionEntry = dgView.Items(x).Cells(5).Text
                    .ChequeNo = dgView.Items(x).Cells(1).Text
                    .ChequeDate = dgView.Items(x).Cells(2).Text
                    .Type = dgView.Items(x).Cells(6).Text
                    Dim A As Decimal = 0
                    A = dgView.Items(x).Cells(7).Text
                    .Amount = A
                    .Cancel = "N/A"
                    .ChqClear = 0
                    .ChqClearDate = "01/01/2020"
                    .BankStDate = "01/01/2020"
                    .NotCharge = 0
                    .VoucherNoOld = "N/A"
                    .CostCCode = "N/A"
                    .SubCostCCode = "N/A"
                    .Bank_Name = "N/A"
                    .Bank_Branch = "N/A"
                    .Is_Cancel = False
                    .Is_Clear = False
                    .Clear_Date = "01/01/2020"
                    Dim TopSNo As Integer = objtblCashMst.GetTopSNO()
                    .Sno = Val(TopSNo + 1)
                    .DOC_RefNo = 0
                    .CostCenterId = dgView.Items(x).Cells(9).Text
                    .SavetblCashDtl()
                End With
            Next
        End If



    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objtblCashMst.Edit(tblCashMstID)
            'Dim A As Boolean
            'A = dt.Rows(0)("ChkDate")
            'If A = True Then
            '    chkshowCalander.Checked = True
            '    txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
            '    txtVoucherdate2.Visible = False
            '    txtVoucherdate.Visible = True
            '    ImageButton1.Visible = True
            'Else
            '    chkshowCalander.Checked = False
            '    txtVoucherdate2.Text = dt.Rows(0)("VoucherDate")
            '    txtVoucherdate2.Visible = True
            '    txtVoucherdate.Visible = False
            '    ImageButton1.Visible = False
            'End If
            txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
            txtVoucherNo.Text = dt.Rows(0)("VoucherNo")
            txtdescription.Text = dt.Rows(0)("Description")
            txtVno.Text = dt.Rows(0)("VNo")
            Dim VoucherType As String = dt.Rows(0)("VoucherType")
            If VoucherType = "R" Then
                pnlbookaccountMst.Visible = True
                pnlAccountCodedtlSearchAuto.Visible = True
                '-----Auto Accoun code
                Dim BookAccount As String = dt.Rows(0)("BookAccount")
                Dim BookAccountName As String = objtblCashMst.GetBookAccountNameMaster(BookAccount)
                cmbVoucherType.SelectedItem.Text = "Cash Receipt"
                cmbVoucherType.SelectedValue = 1
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                cmbType.SelectedItem.Text = "C"
                cmbType.Enabled = False
            Else
                pnlbookaccountMst.Visible = True
                pnlAccountCodedtlSearchAuto.Visible = True
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                cmbVoucherType.SelectedItem.Text = "Cash Payment"
                cmbVoucherType.SelectedValue = 2
                cmbType.SelectedItem.Text = "D"
                cmbType.Enabled = False
            End If
            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("tblCashDtlID", GetType(Long))
                    .Columns.Add("ChequeNo", GetType(String))
                    .Columns.Add("ChequeDate", GetType(String))
                    .Columns.Add("AccountCode", GetType(String))
                    .Columns.Add("AccountName", GetType(String))
                    .Columns.Add("DescriptionEntry", GetType(String))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("CostCenterId", GetType(String))
                    .Columns.Add("Cost", GetType(String))
                End With
            End If

            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("tblCashDtlID") = dt.Rows(x)("tblCashDtlID")
                Dr("ChequeNo") = dt.Rows(x)("ChequeNo")
                Dr("ChequeDate") = dt.Rows(x)("ChequeDate")
                Dr("AccountCode") = dt.Rows(x)("AccountCode")
                Dr("AccountName") = dt.Rows(x)("AccountName")
                Dr("DescriptionEntry") = dt.Rows(x)("DescriptionEntry")
                Dr("Type") = dt.Rows(x)("Type")
                Dr("Amount") = dt.Rows(x)("Amount")
                Dr("CostCenterId") = dt.Rows(x)("CostCenterId")
                Dr("Cost") = dt.Rows(x)("Cost")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CashVoucherView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            'If txtchequeNo.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Empty.")
            'If txtchequedate.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque Date Empty.")
            If txtDescriptionDetail.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Description Empty.")
            ElseIf txtamount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Amount Empty.")
            Else
                If cmbVoucherType.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select account code .")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    ClearControls()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbVoucherType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVoucherType.SelectedIndexChanged
        Try
            If cmbVoucherType.SelectedItem.Text = "Cash Receipt" Then
                lbldrcrM.Text = "(Dr)"
                lbldrcrD.Text = "(Cr)"
            ElseIf cmbVoucherType.SelectedItem.Text = "Cash Payment" Then
                lbldrcrM.Text = "(Cr)"
                lbldrcrD.Text = "(Dr)"
            Else
                lbldrcrM.Text = ""
                lbldrcrD.Text = ""
            End If


            VoucherNoGenerateOnLoad()

            '        Dim VoucherNo As String
            '        Dim VoucherType As String
            '        Dim Voucherdate As Date = txtVoucherdate.Text
            '        Dim year As String = Voucherdate.Year
            '        Dim yearP As String = Voucherdate.Year
            '        year = year.Substring(2, 2)
            '        Dim Month As String = Voucherdate.Month
            '        Dim CodeMonth As String
            '        If Month = 1 Then
            '            CodeMonth = "01"
            '        ElseIf Month = 2 Then
            '            CodeMonth = "02"
            '        ElseIf Month = 3 Then
            '            CodeMonth = "03"
            '        ElseIf Month = 4 Then
            '            CodeMonth = "04"
            '        ElseIf Month = 5 Then
            '            CodeMonth = "05"
            '        ElseIf Month = 6 Then
            '            CodeMonth = "06"
            '        ElseIf Month = 7 Then
            '            CodeMonth = "07"
            '        ElseIf Month = 8 Then
            '            CodeMonth = "08"
            '        ElseIf Month = 9 Then
            '            CodeMonth = "09"
            '        Else
            '            CodeMonth = Month
            '        End If
            '        If cmbVoucherType.SelectedItem.Text = "Cash Receipt" Then
            '            VoucherType = "R"
            '        Else
            '            VoucherType = "P"
            '        End If
            '        Dim LastVoucherNo As String = objtblCashMst.GetLastVoucherNo(Month, yearP)
            '        Dim PreviousMonth As Integer
            '        Dim LastCode As String
            '        If LastVoucherNo = "" Then
            '            LastCode = "00001"
            '        Else
            '            PreviousMonth = LastVoucherNo.Substring(7, 2)
            '            LastCode = LastVoucherNo.Substring(10, 5)
            '            If PreviousMonth = Month Then
            '                If LastCode < 10 Then
            '                    LastCode = "0000" & Val(LastCode + 1)
            '                ElseIf LastCode < 100 Or LastCode >= 10 Then
            '                    LastCode = "000" & Val(LastCode + 1)
            '                ElseIf LastCode < 1000 Or LastCode >= 100 Then
            '                    LastCode = "00" & Val(LastCode + 1)
            '                Else
            '                End If
            '            Else
            '                LastCode = "00001"
            '            End If
            '        End If
            '        VoucherNo = "CV" & "-" & VoucherType & "-" & year & "" & CodeMonth & "-" & LastCode
            '        txtVoucherNo.Text = VoucherNo

            '        'If cmbVoucherType.SelectedValue = 0 Then
            '        BindBookAccountFirstTime()
            '        'ElseIf cmbVoucherType.SelectedValue = 1 Then
            '        '    BindBookAccount()
            '        '    BindAccountCodeFirstTime()
            '        'ElseIf cmbVoucherType.SelectedValue = 2 Then
            '        '    BindBookAccountFirstTime()
            '        '    BindAccountCode()
            '        '    cmbVoucherType.SelectedValue = 2
            '        'End If


            '        If cmbVoucherType.SelectedValue = 0 Then
            '            cmbType.Enabled = True
            '        ElseIf cmbVoucherType.SelectedValue = 1 Then
            '            cmbType.SelectedValue = 1
            '            cmbType.Enabled = False
            '        ElseIf cmbVoucherType.SelectedValue = 2 Then
            '            cmbType.SelectedValue = 0
            '            cmbType.Enabled = False
            '        End If



            '        'pnlbookaccountMst.Visible = False
            '        'pnlbookaccountMstSearch.Visible = True

            '        'pnlAccountCodedtl.Visible = True
            '        'pnlAccountCodedtlSearchAuto.Visible = False

            '        pnlbookaccountMst.Visible = True
            '        pnlbookaccountMstSearch.Visible = False
            '        'AdjustDataUpdate.Visible = False

            '        pnlAccountCodedtl.Visible = False
            '        pnlAccountCodedtlSearchAuto.Visible = True


            '    Catch ex As Exception

            '    End Try
            'End Sub
            'Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
            '    Try
            '        Select Case e.CommandName
            '            Case "Edit"
            '                'Case "Remove"
            '                '    Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
            '                '    objtblCashMst.DeleteBrandDatabase(tblBankMstID)
            '                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
            '                '    Dim objDataView As DataView
            '                '    objDataView = LoadData()
            '                '    Session("objDataView") = objDataView
            '                '  BindGrid()

            '                dtDetail = CType(Session("dtDetail"), DataTable)
            '                If (Not dtDetail Is Nothing) Then
            '                    If (dtDetail.Rows.Count > 0) Then
            '                        Dim ltblCashDtlID As Integer = dgView.Items(e.Item.ItemIndex).Cells(0).Text
            '                        SetDetailValuesByDataTable(e.Item.ItemIndex)
            '                        dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
            '                        BindGrid()
            '                    End If
            '                End If
            '        End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try


            lbldetail.Text = dtDetail.Rows(dtrowNo)("tblCashDtlID")
            ' txtchequeNo.Text = dtDetail.Rows(dtrowNo)("ChequeNo")
            ' txtchequedate.Text = dtDetail.Rows(dtrowNo)("ChequeDate")
            '   cmbAccountCode.SelectedValue = dtDetail.Rows(dtrowNo)("AccountCode")
            txtDescriptionDetail.Text = dtDetail.Rows(dtrowNo)("DescriptionEntry")
            cmbType.SelectedItem.Text = dtDetail.Rows(dtrowNo)("Type")
            txtamount.Text = dtDetail.Rows(dtrowNo)("Amount")
            lblCostCenterId.Text = dtDetail.Rows(dtrowNo)("CostCenterId")
            txtCostCenter.Text = dtDetail.Rows(dtrowNo)("Cost")
            'If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
            'ccountCodedtl.Visible = True
            'pnlAccountCodedtlSearchAuto.Visible = False
            'cmbAccountCode.SelectedValue = dtDetail.Rows(dtrowNo)("AccountCode")
            ' Else
            pnlAccountCodedtl.Visible = False
            pnlAccountCodedtlSearchAuto.Visible = True
            Dim BookAccount As String = dtDetail.Rows(dtrowNo)("AccountCode")
            Dim BookAccountName As String = objtblCashMst.GetBookAccountNameMaster(BookAccount)
            txtAccountCode.Text = BookAccount
            txtAccountName.Text = BookAccountName

            dtAC = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
            txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
            If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                txtAccountLevel.BackColor = Drawing.Color.LightGreen
            Else
                txtAccountLevel.BackColor = Drawing.Color.Red
            End If
            'End If

        Catch ex As Exception
        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            If cmbVoucherType.SelectedItem.Text = "Cash Receipt" Then
                lbldrcrM.Text = "(Dr)"
                lbldrcrD.Text = "(Cr)"
            ElseIf cmbVoucherType.SelectedItem.Text = "Cash Payment" Then
                lbldrcrM.Text = "(Cr)"
                lbldrcrD.Text = "(Dr)"
            Else
                lbldrcrM.Text = ""
                lbldrcrD.Text = ""
            End If
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now 'txtVoucherdate.Text

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

            Dim LastVoucherNo As String = objtblCashMst.GetLastVoucherNo(Month, yearP)
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
            VoucherNo = "CV" & "-" & year & "" & CodeMonth & "" & "" & DayP & "-" & LastCode
            txtVoucherNo.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub
    'Dim VoucherNo As String
    'Dim VoucherType As String
    'Dim Voucherdate As Date = txtVoucherdate.Text
    ''Dim Voucherdate As Date
    ''If chkshowCalander.Checked = True Then
    ''    Voucherdate = txtVoucherdate.Text
    ''Else
    ''    Voucherdate = txtVoucherdate2.Text
    ''End If
    'Dim year As String = Voucherdate.Year
    'Dim yearP As String = Voucherdate.Year
    'year = year.Substring(2, 2)
    'Dim Month As String = Voucherdate.Month
    'Dim CodeMonth As String
    'If Month = 1 Then
    '    CodeMonth = "01"
    'ElseIf Month = 2 Then
    '    CodeMonth = "02"
    'ElseIf Month = 3 Then
    '    CodeMonth = "03"
    'ElseIf Month = 4 Then
    '    CodeMonth = "04"
    'ElseIf Month = 5 Then
    '    CodeMonth = "05"
    'ElseIf Month = 6 Then
    '    CodeMonth = "06"
    'ElseIf Month = 7 Then
    '    CodeMonth = "07"
    'ElseIf Month = 8 Then
    '    CodeMonth = "08"
    'ElseIf Month = 9 Then
    '    CodeMonth = "09"
    'Else
    '    CodeMonth = Month
    'End If
    'If cmbVoucherType.SelectedItem.Text = "Cash Receipt" Then
    '    VoucherType = "R"
    'Else
    '    VoucherType = "P"
    'End If
    'Dim LastVoucherNo As String = objtblCashMst.GetLastVoucherNo(Month, yearP)
    'Dim PreviousMonth As Integer
    'Dim LastCode As String

    'If LastVoucherNo = "" Then
    '    LastCode = "00001"
    'Else
    '    PreviousMonth = LastVoucherNo.Substring(7, 2)
    '    LastCode = LastVoucherNo.Substring(10, 5)
    '    If PreviousMonth = Month Then
    '        If LastCode < 10 Then
    '            If LastCode = 9 Then
    '                LastCode = "000" & Val(LastCode + 1)
    '            Else
    '                LastCode = "0000" & Val(LastCode + 1)
    '            End If
    '            ' LastCode = "0000" & Val(LastCode + 1)
    '        ElseIf LastCode < 100 Or LastCode >= 10 Then
    '            If LastCode = 99 Then
    '                LastCode = "00" & Val(LastCode + 1)
    '            Else
    '                LastCode = "000" & Val(LastCode + 1)
    '            End If
    '            'LastCode = "000" & Val(LastCode + 1)
    '        ElseIf LastCode < 1000 Or LastCode >= 100 Then
    '            If LastCode = 999 Then
    '                LastCode = "0" & Val(LastCode + 1)
    '            Else
    '                LastCode = "00" & Val(LastCode + 1)
    '            End If
    '            'LastCode = "00" & Val(LastCode + 1)
    '        ElseIf LastCode < 10000 Or LastCode = 1000 Then
    '            If LastCode = 9999 Then
    '                LastCode = Val(LastCode + 1)
    '            Else
    '                LastCode = Val(LastCode + 1)
    '            End If
    '        Else
    '            LastCode = Val(LastCode + 1)
    '        End If
    '    Else
    '        LastCode = "00001"
    '    End If
    'End If
    'VoucherNo = "CV" & "-" & VoucherType & "-" & year & "" & CodeMonth & "-" & LastCode
    'txtVoucherNo.Text = VoucherNo

    'If cmbVoucherType.SelectedValue = 0 Then
    '    cmbType.Enabled = True
    'ElseIf cmbVoucherType.SelectedValue = 1 Then
    '    cmbType.SelectedValue = 1
    '    cmbType.Enabled = False
    'ElseIf cmbVoucherType.SelectedValue = 2 Then
    '    cmbType.SelectedValue = 0
    '    cmbType.Enabled = False
    'End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub txtBookAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookAccountName.TextChanged
        Try
            If txtBookAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtBookAccountName.Text <> "" Then
                dtAC = objtblCashMst.GetUniqueAccountName(txtBookAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If
                txtBookAccountCode.Text = dtAC.Rows(0)("AccountCode")
                txtBookAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                    txtBookAccountLevel.BackColor = Drawing.Color.LightGreen
                Else
                    txtBookAccountLevel.BackColor = Drawing.Color.Red
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtCostCenter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenter.TextChanged
        Try
            Dim dtAC As DataTable
            If txtCostCenter.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Cost Center")
            ElseIf txtAccountName.Text <> "" Then
                dtAC = objtblCashMst.GetUniqueCostCenter(txtCostCenter.Text)
                'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    lblCostCenterId.Text = dtAC.Rows(0)("CostCenterId")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cost Center Not Exist")
                    lblCostCenterId.Text = 0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtdescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescription.TextChanged
        Try
            txtDescriptionDetail.Text = txtdescription.Text
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub txtVoucherdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate.TextChanged
    '    Try
    '        VoucherNoGenerateOnLoad()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub lnkDeliveryType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDeliveryType.Click
    '    Dim ID As Integer = 0
    '    Response.Write("<script> window.open('SelectionPopup.aspx?ID=" & ID & "', 'newwindow', 'left=450, top=300, height=220, width=450, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
    'End Sub
    ''Danish work
    'Protected Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheck.Click

    '    PnlBankVoucher.Visible = False
    '    'PnlInvoiceGridAdjust.Visible = True
    '    PNAfterAdjustClickLabelGridBind.Visible = False
    '    bindInvoiceFirstTime()


    'End Sub
    'Sub bindInvoiceFirstTime()

    '    Try
    '        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
    '        Dim dt As New DataTable
    '        dt = objInvoiceMst.GettblInvoiceMstDataForPopUp(txtAccountName.Text)
    '        If dt.Rows.Count > 0 Then
    '            'dgInvoiceFirst.DataSource = dt
    '            'dgInvoiceFirst.DataBind()

    '        Else
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Record Not Found ")
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        'bindInvoiceFirstTime()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        'bindInvoiceFirstTime()
    End Sub
    'Protected Sub dgInvoiceFirst_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgInvoiceFirst.ItemCommand
    '    Try
    '        Select Case e.CommandName
    '            Case "Adjust"

    '                Dim ltblInvoiceMstID As String = dgInvoiceFirst.Items(e.Item.ItemIndex).Cells(0).Text
    '                'Dim ltblInvoiceDtlID As Long = dgInvoiceFirst.Items(e.Item.ItemIndex).Cells(1).Text
    '                Dim dt As New DataTable
    '                Dim SupplierName As String
    '                dt = objInvoiceMst.getInvoiceMstForLabelShow(ltblInvoiceMstID, SupplierName)

    '                lblSupplierInv.Text = dt.Rows(0)("SupplierName")
    '                lblInvoiceNoInv.Text = dt.Rows(0)("InvoiceNo")
    '                lblPayable.Text = dt.Rows(0)("PayableAmount")
    '                lblInvoiceDateInv.Text = dt.Rows(0)("InvoiceDatee")

    '                dgAfterAdjustClickLabelGridBind.DataSource = dt
    '                dgAfterAdjustClickLabelGridBind.DataBind()
    '                PNAfterAdjustClickLabelGridBind.Visible = True

    '                Session("AdjustBalanace") = dt


    '        End Select
    '    Catch ex As Exception
    '    End Try
    'End Sub
    '

    'Protected Sub dgAfterAdjustClickLabelGridBind_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAfterAdjustClickLabelGridBind.ItemCommand
    '    Try
    '        Select Case e.CommandName
    '            Case "Adjust"

    '                Dim ltblInvoiceMstID As Long = dgInvoiceFirst.Items(e.Item.ItemIndex).Cells(0).Text
    '                'Dim ltblInvoiceDtlID As Long = dgInvoiceFirst.Items(e.Item.ItemIndex).Cells(1).Text
    '                Dim dt As New DataTable
    '                Dim SupplierName As String
    '                dt = objInvoiceMst.getInvoiceMstForLabelShow(ltblInvoiceMstID, SupplierName)


    '                dgAfterAdjustClickLabelGridBindForUpdate.DataSource = dt
    '                dgAfterAdjustClickLabelGridBindForUpdate.DataBind()
    '                dgAfterAdjustClickLabelGridBindForUpdate.Visible = True
    '                AdjustDataUpdate.Visible = False



    '        End Select
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Protected Sub btnAdjust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
    '    Try

    'Dim dt As New DataTable
    'dt = objInvoiceMst.getInvoiceMstForAdjustButton(lblSupplierInv.Text)
    'dgAfterAdjustClickLabelGridBindForUpdate.DataSource = dt
    'dgAfterAdjustClickLabelGridBindForUpdate.DataBind()

    'Dim lOpeningBalance, lAdjustAmount, lBalanceAmount As Integer
    'Dim strPaymentType As String

    ' Dim x As Integer
    'For x = 0 To dgAfterAdjustClickLabelGridBindForUpdate.Items.Count - 1

    ' lOpeningBalance = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(3).Text()
    'lAdjustAmount = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(4).Text()
    'lBalanceAmount = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(5).Text()
    'strPaymentType = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(8).Text()
    'lAdjustAmount = Math.Round(Val(lOpeningBalance) - Val(lAdjustAmount), 2)
    'dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(5).Text() = lAdjustAmount

    ' Dim txtPaymentType As TextBox
    'txtPaymentType = DirectCast(dgAfterAdjustClickLabelGridBindForUpdate.Items(x).FindControl("txtBalanaceAmountDTL"), TextBox)
    'If strPaymentType = "N/A" Then
    'txtPaymentType.Text = "--"

    'Else
    ' txtPaymentType.Text = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(8).Text()
    'End If
    'Dim dtadjustBalance, dtAmount As DataTable
    '        dtadjustBalance = (Session("AdjustBalanace"))
    '        dtAmount = Session("dtDetail")
    '        LblVoucherDate.Text = txtVoucherdate.Text
    '        lblBalance.Text = dtadjustBalance.Rows(dtadjustBalance.Rows.Count - 1)("BalanceAmountDTL")
    '        LblAMOUNT.Text = dtAmount.Rows(0)("Amount")
    '        lblAdjustedAmount.Text = Val(lblBalance.Text) - Val(LblAMOUNT.Text)
    '        lblRefVoucher.Text = txtVoucherNo.Text
    '        LblInvoiceMstId.Text = dtadjustBalance.Rows(dtadjustBalance.Rows.Count - 1)("InvoiceMstID")
    '        AdjustDataUpdate.Visible = True

    '        btnUpadateInv.Visible = True
    '        BtnCanelInv.Visible = True


    ''Next
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub btnUpadateInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpadateInv.Click
    '    Try
    '        saveData()
    '        With objInvoiceDtl
    '            'Dim x As Integer
    '            'For x = 0 To dgAfterAdjustClickLabelGridBindForUpdate.Items.Count - 1
    '            ' lInvoiceDtlId As Integer = dgAfterAdjustClickLabelGridBindForUpdate.Items(x).Cells(1).Text
    '            'If lInvoiceDtlId > 0 Then
    '            .InvoiceDtlID = 0
    '            ' Else
    '            ' .InvoiceDtlID = lInvoiceDtlId
    '            'End If
    '            .InvoiceMstID = LblInvoiceMstId.Text
    '            .CreationDate = LblVoucherDate.Text
    '            .OpeningAmount = lblBalance.Text
    '            .AjustedAmount = LblAMOUNT.Text
    '            .BalanceAmountDTL = lblAdjustedAmount.Text
    '            .PaymentVocuherRefNo = lblRefVoucher.Text
    '            ' Dim txtPaymentType As TextBox
    '            'txtPaymentType = DirectCast(dgAfterAdjustClickLabelGridBindForUpdate.Items(x).FindControl("txtBalanaceAmountDTL"), TextBox)
    '            .PaymentType = txtPaymentType.Text
    '            .SaveInvoiceDtl()

    '            'Next

    '            Response.Redirect("BankVoucherView.aspx")
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub RBBtn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBBtn.SelectedIndexChanged
    '    Try
    '        If RBBtn.SelectedValue = 0 Then
    '            bindInvoiceMaster()
    '            PnlInvoiceGridAdjust.Visible = True
    '            AdjustDataUpdate.Visible = False
    '        Else
    '            PnlInvoiceGridAdjust.Visible = False
    '            dgAfterAdjustClickLabelGridBindForUpdate.Visible = False
    '            PNAfterAdjustClickLabelGridBind.Visible = False
    '            AdjustDataUpdate.Visible = False
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub bindInvoiceMaster()

    '    Try
    '        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
    '        Dim dt As New DataTable
    '        Dim SupplierName As String
    '        dt = objInvoiceMst.GettblInvoiceMst(txtAccountName.Text, SupplierName)
    '        If dt.Rows.Count > 0 Then
    '            dgInvoiceFirst.DataSource = dt
    '            dgInvoiceFirst.DataBind()

    '        Else
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Record Not Found ")
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Sub
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

    'Protected Sub txtVoucherdate2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate2.TextChanged
    '    Try
    '        VoucherNoGenerateOnLoad()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Try
            If txtAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtAccountName.Text <> "" Then
                dtAC = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If

                txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                    txtAccountLevel.BackColor = Drawing.Color.LightGreen
                Else
                    txtAccountLevel.BackColor = Drawing.Color.Red
                End If



                '----------------For Ledger Balance
                '----------------For Ledger Balance

                Dim DebitPvv As Decimal = 0
                Dim CreditPvv As Decimal = 0
                Dim DebitJVv As Decimal = 0
                Dim CreditJVv As Decimal = 0

                Dim CreditCVv As Decimal = 0
                Dim DebitCVv As Decimal = 0
                Dim CreditConVv As Decimal = 0
                Dim DebitConVv As Decimal = 0

                Dim TotalLedgerBalancee As Decimal = 0
                Dim dtbankamountt As DataTable
                Dim dtJVamountt As DataTable
                Dim dtCVamountt As DataTable
                Dim dtContamount As DataTable

                dtbankamountt = objContactType.GetBPVDataForLedger(txtAccountCode.Text)
                dtJVamountt = objContactType.GetJVDataForLedger(txtAccountCode.Text)
                dtCVamountt = objContactType.GetCVDataForLedger(txtAccountCode.Text)
                dtContamount = objContactType.GetContraDataForLedger(txtAccountCode.Text)

                If dtbankamountt.Rows.Count > 0 Then
                    DebitPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                    CreditPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
                End If
                If dtJVamountt.Rows.Count > 0 Then
                    DebitJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Debit)", String.Empty))
                    CreditJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Credit)", String.Empty))
                End If

                If dtCVamountt.Rows.Count > 0 Then
                    DebitCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                    CreditCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
                End If
                If dtContamount.Rows.Count > 0 Then
                    DebitConVv = Convert.ToInt32(dtContamount.Compute("SUM(Debit)", String.Empty))
                    CreditConVv = Convert.ToInt32(dtContamount.Compute("SUM(Credit)", String.Empty))
                End If

                TotalLedgerBalancee = Val(DebitPvv + DebitJVv + DebitCVv + DebitConVv) - Val(CreditPvv + CreditJVv + CreditCVv + CreditConVv)
                txtLedgerBalance.Text = Convert.ToDecimal(TotalLedgerBalancee).ToString("#,##0.00")
            End If

            If txtLedgerBalance.Text >= 0 Then
                lblLedgerBalanceCRDR.Text = "Dr"
            Else
                lblLedgerBalanceCRDR.Text = "Cr"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBookAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBookAccount.SelectedIndexChanged
        Try
            Dim DebitPv As Decimal = 0
            Dim CreditPv As Decimal = 0
            Dim DebitJV As Decimal = 0
            Dim CreditJV As Decimal = 0

            Dim DebitCV As Decimal = 0
            Dim CreditCV As Decimal = 0
            Dim DebitCONV As Decimal = 0
            Dim CreditCONV As Decimal = 0

            Dim TotalBankBalance As Decimal = 0
            Dim dtbankamount As DataTable
            Dim dtJVamount As DataTable
            Dim dtCVamount As DataTable
            Dim dtCONTamount As DataTable

            dtbankamount = objContactType.GetBPVData(cmbBookAccount.SelectedValue)
            dtJVamount = objContactType.GetJVData(cmbBookAccount.SelectedValue)
            dtCVamount = objContactType.GetCVData(cmbBookAccount.SelectedValue)
            dtCONTamount = objContactType.GetCCONTRData(cmbBookAccount.SelectedValue)

            If dtbankamount.Rows.Count > 0 Then
                DebitPv = Convert.ToInt32(dtbankamount.Compute("SUM(Debit)", String.Empty))
                CreditPv = Convert.ToInt32(dtbankamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtJVamount.Rows.Count > 0 Then
                DebitJV = Convert.ToInt32(dtJVamount.Compute("SUM(Debit)", String.Empty))
                CreditJV = Convert.ToInt32(dtJVamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtCVamount.Rows.Count > 0 Then
                DebitCV = Convert.ToInt32(dtCVamount.Compute("SUM(Debit)", String.Empty))
                CreditCV = Convert.ToInt32(dtCVamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtCONTamount.Rows.Count > 0 Then
                DebitCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Debit)", String.Empty))
                CreditCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Credit)", String.Empty))
            End If

            '----Detail AccountCode Data
            Dim dtbankamountt As DataTable
            Dim dtCVamountt As DataTable
            Dim dtContramount As DataTable

            Dim DebitPvvd As Decimal = 0
            Dim CreditPvvd As Decimal = 0
            Dim CreditCVvd As Decimal = 0
            Dim DebitCVvd As Decimal = 0
            Dim CreditConVvd As Decimal = 0
            Dim DebitConVvd As Decimal = 0

            dtbankamountt = objContactType.GetBPVDataForLedger(txtAccountCode.Text)
            dtCVamountt = objContactType.GetCVDataForLedger(txtAccountCode.Text)
            dtContramount = objContactType.GetContraDataForLedger(txtAccountCode.Text)
            If dtbankamountt.Rows.Count > 0 Then
                DebitPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                CreditPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
            End If

            If dtCVamountt.Rows.Count > 0 Then
                DebitCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                CreditCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
            End If
            If dtContramount.Rows.Count > 0 Then
                DebitConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Debit)", String.Empty))
                CreditConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Credit)", String.Empty))
            End If





            TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV + DebitPvvd + DebitCVvd + DebitConVvd) - Val(CreditPv + CreditJV + CreditCV + CreditCONV + CreditPvvd + CreditCVvd + CreditConVvd)
            '  TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV) - Val(CreditPv + CreditJV + CreditCV + CreditCONV)
            txtBankbalance.Text = Convert.ToDecimal(TotalBankBalance).ToString("#,##0.00")


            If txtBankbalance.Text >= 0 Then
                lblCurrBalanceCRDR.Text = "Dr"
            Else
                lblCurrBalanceCRDR.Text = "Cr"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim tblCashDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindGrid()
                            Try
                                If txtAccountName.Text = "" Then
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
                                ElseIf txtAccountName.Text <> "" Then
                                    Dim strAcc As String = txtAccountName.Text & "-" & txtAccountCode.Text
                                    dtAC = objtblCashMst.GetUniqueAccountName(strAcc)
                                    'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                                    If dtAC.Rows.Count > 0 Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                                    Else
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                                    End If

                                    txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                                    txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                                    If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                                        txtAccountLevel.BackColor = Drawing.Color.LightGreen
                                    Else
                                        txtAccountLevel.BackColor = Drawing.Color.Red
                                    End If

                                    Dim DebitPvv As Decimal = 0
                                    Dim CreditPvv As Decimal = 0
                                    Dim DebitJVv As Decimal = 0
                                    Dim CreditJVv As Decimal = 0

                                    Dim CreditCVv As Decimal = 0
                                    Dim DebitCVv As Decimal = 0
                                    Dim CreditConVv As Decimal = 0
                                    Dim DebitConVv As Decimal = 0

                                    Dim TotalLedgerBalancee As Decimal = 0
                                    Dim dtbankamountt As DataTable
                                    Dim dtJVamountt As DataTable
                                    Dim dtCVamountt As DataTable
                                    Dim dtContamount As DataTable

                                    dtbankamountt = objContactType.GetBPVDataForLedger(txtAccountCode.Text)
                                    dtJVamountt = objContactType.GetJVDataForLedger(txtAccountCode.Text)
                                    dtCVamountt = objContactType.GetCVDataForLedger(txtAccountCode.Text)
                                    dtContamount = objContactType.GetContraDataForLedger(txtAccountCode.Text)

                                    If dtbankamountt.Rows.Count > 0 Then
                                        DebitPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
                                    End If
                                    If dtJVamountt.Rows.Count > 0 Then
                                        DebitJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Credit)", String.Empty))
                                    End If

                                    If dtCVamountt.Rows.Count > 0 Then
                                        DebitCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
                                    End If
                                    If dtContamount.Rows.Count > 0 Then
                                        DebitConVv = Convert.ToInt32(dtContamount.Compute("SUM(Debit)", String.Empty))
                                        CreditConVv = Convert.ToInt32(dtContamount.Compute("SUM(Credit)", String.Empty))
                                    End If

                                    TotalLedgerBalancee = Val(DebitPvv + DebitJVv + DebitCVv + DebitConVv) - Val(CreditPvv + CreditJVv + CreditCVv + CreditConVv)
                                    txtLedgerBalance.Text = Convert.ToDecimal(TotalLedgerBalancee).ToString("#,##0.00")
                                End If

                                If txtLedgerBalance.Text >= 0 Then
                                    lblLedgerBalanceCRDR.Text = "Dr"
                                Else
                                    lblLedgerBalanceCRDR.Text = "Cr"
                                End If
                            Catch ex As Exception

                            End Try
                            btnAdd.Visible = True
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class

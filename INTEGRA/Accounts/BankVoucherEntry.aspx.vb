Imports System.Data
Imports System.Data.DataTable
Imports Integra.classes

Public Class BankVoucherEntry
    Inherits System.Web.UI.Page




    Dim objtblBankMst As New tblBankMst
    Dim objtblBankDtl As New tblBankDtl
    Dim objInvoiceMst As New InvoiceMst
    Dim objPOInvoiceAdjDetail As New POInvoiceAdjDetail

    Dim objgeneralCode As New GeneralCode
    Dim dtDetail, dtAdjustDetail As DataTable
    Dim Dr As DataRow
    Dim tblBankMstID As Long
    Dim dtAC As DataTable
    Dim AccountCode, Voucher As String
    Dim objSupplierLedger As New SupplierLedger
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       



        tblBankMstID = Request.QueryString("ltblBankMstID")
        Voucher = Request.QueryString("Voucher")
        If Not Page.IsPostBack Then
            If Voucher = "BankVoucher" Then
                lblBankH.Text = "Bank Voucher"
        Else
                lblBankH.Text = "Cash Voucher"
            End If
        End If
        If Not Page.IsPostBack Then
            ImageButton1.Focus()
            BindVoucherType()
            BindBookAccount()
            BindCurrency()
            BindPaymentType()
            BindPresented()
            ' BindAccountCode()
            Session("dtDetail") = Nothing
            Session("dtAdjustDetail") = Nothing
            If tblBankMstID > 0 Then
                EditMode()
                btnUpadateInv.Text = "Update"
                btnAdd.Visible = True
                btnUpadateInv.Visible = True
            Else
                BindPaymentTerms()
                BindBookAccountFirstTime()
                cmbVoucherType.SelectedValue = 2
                txtVoucherdate.Text = Date.Now
                txtchequedate.Text = Date.Now
                btnUpadateInv.Text = "Save"
                VoucherNoGenerateOnLoad()
                pnlbookaccountMst.Visible = True
                pnlbookaccountMstSearch.Visible = False

                pnlAccountCodedtl.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = True
            End If
        End If
        PageHeader("BANK VOUCHER ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindVoucherType()
        cmbVoucherType.Items.Insert(0, New ListItem("Select", "0"))
        cmbVoucherType.Items.Insert(1, New ListItem("Receipt Voucher", "1"))
        cmbVoucherType.Items.Insert(2, New ListItem("Payment Voucher", "2"))
        ' cmbVoucherType.Items.Insert(3, New ListItem("Contra Voucher", "3"))
        cmbVoucherType.SelectedValue = 2
    End Sub
    Sub BindBookAccountFirstTime()
        Dim dt As DataTable
        If Voucher = "BankVoucher" Then
            If cmbVoucherType.SelectedValue = 1 Or cmbVoucherType.SelectedValue = 2 Then
                dt = objtblBankMst.GetBookAccountFirstTimeForNaeemBank()
            Else
                dt = objtblBankMst.GetBookAccountFirstTimeForNaeemBankForContraVoucher()
            End If

        Else
            dt = objtblBankMst.GetBookAccountFirstTimeForNaeemCash()
        End If
        If dt.Rows.Count > 0 Then
            cmbBookAccount.DataSource = dt
            cmbBookAccount.DataTextField = "BookAccount"
            cmbBookAccount.DataValueField = "AccountCode"
            cmbBookAccount.DataBind()
            cmbBookAccount.Items.Insert(0, New ListItem("Select", "0"))

            cmbBookAccount.SelectedValue = dt.Rows(0)("AccountCode")
        Else

        End If

    End Sub
    Sub BindCurrency()
        Dim dt As DataTable
        dt = objtblBankMst.GetCurrency()
        cmbCurrency.DataSource = dt
        cmbCurrency.DataTextField = "CurrencyName"
        cmbCurrency.DataValueField = "CurrencyID"
        cmbCurrency.DataBind()
        cmbCurrency.SelectedValue = 6
    End Sub
    Sub BindPaymentTerms()
        Dim dt As DataTable
        dt = objtblBankMst.GetPaymentTerm()
        cmbPaymentTerms.DataSource = dt
        cmbPaymentTerms.DataTextField = "PaymentTerms"
        cmbPaymentTerms.DataValueField = "ID"
        cmbPaymentTerms.DataBind()
        cmbPaymentTerms.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindBookAccount()
        Dim dt As DataTable
        ' dt = objtblBankMst.GetBookAccount()
        'If Voucher = "BankVoucher" Then
        If cmbVoucherType.SelectedValue = 1 Or cmbVoucherType.SelectedValue = 2 Then
            dt = objtblBankMst.GetBookAccountFirstTimeForNaeemBank()
        Else
            dt = objtblBankMst.GetBookAccountFirstTimeForNaeemBankForContraVoucher()
        End If
        'Else
        'dt = objtblBankMst.GetBookAccountFirstTimeForNaeemCash()
        'End If

        cmbBookAccount.DataSource = dt
        cmbBookAccount.DataTextField = "BookAccount"
        cmbBookAccount.DataValueField = "AccountCode"
        cmbBookAccount.DataBind()
        cmbBookAccount.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindAccountCode()
        Dim dt As DataTable
        dt = objtblBankMst.GetBookAccount()
        cmbAccountCode.DataSource = dt
        cmbAccountCode.DataTextField = "BookAccount"
        cmbAccountCode.DataValueField = "AccountCode"
        cmbAccountCode.DataBind()
        cmbAccountCode.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindAccountCodeFirstTime()
        Dim dt As DataTable
        If Voucher = "BankVoucher" Then
            dt = objtblBankMst.GetBookAccountFirstTimeForNaeemBank()
        Else
            dt = objtblBankMst.GetBookAccountFirstTimeForNaeemCash()
        End If
        cmbAccountCode.DataSource = dt
        cmbAccountCode.DataTextField = "BookAccount"
        cmbAccountCode.DataValueField = "AccountCode"
        cmbAccountCode.DataBind()
        cmbAccountCode.Items.Insert(0, New ListItem("Select", "0"))

        cmbAccountCode.SelectedValue = dt.Rows(0)("AccountCode")
    End Sub

    Sub BindPaymentType()
        Dim dt As DataTable
        dt = objtblBankMst.GetPayType()
        cmbpaytype.DataSource = dt
        cmbpaytype.DataTextField = "TypeName"
        cmbpaytype.DataValueField = "TypeID"
        cmbpaytype.DataBind()
        cmbpaytype.Items.Insert(0, New ListItem("Select", "0"))

        cmbpaytype.SelectedValue = dt.Rows(0)("TypeID")
    End Sub


    Sub BindPresented()
        Dim dt As DataTable
        dt = objtblBankMst.GetPresentedType()
        cmbpresented.DataSource = dt
        cmbpresented.DataTextField = "PresentationName"
        cmbpresented.DataValueField = "PresentationID"
        cmbpresented.DataBind()
        cmbpresented.Items.Insert(0, New ListItem("Select", "0"))

        cmbpresented.SelectedValue = dt.Rows(0)("PresentationID")
    End Sub




    '-----New Develpment start 
    '1---For bank bind
    Protected Sub txtBookAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookAccountName.TextChanged
        Try
            If txtBookAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtBookAccountName.Text <> "" Then

                'AccountCode = objtblBankMst.GetUniqueAccountName(txtBookAccountName.Text)
                'If AccountCode <> "" Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                'Else
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("AccountName. Not Exist")
                'End If
                dtAC = objtblBankMst.GetUniqueAccountName(txtBookAccountName.Text)
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
    '2---ForInvoice Grid Bind bind
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Try
            If txtAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Party Name.")
                btnAdd.Visible = False
            ElseIf txtAccountName.Text <> "" Then
                dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                'AccountCode = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    btnAdd.Visible = False
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If
                If cmbBookAccount.SelectedValue = dtAC.Rows(0)("AccountCode") Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Already Selected")
                    txtAccountName.Text = ""
                    txtAccountCode.Text = ""
                    txtAccountLevel.Text = ""
                    txtAccountLevel.BackColor = Drawing.Color.White
                Else
                    btnAdd.Visible = True
                    txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                    txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                    If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                        txtAccountLevel.BackColor = Drawing.Color.LightGreen
                    Else
                        txtAccountLevel.BackColor = Drawing.Color.Red
                    End If
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbPaymentTerms_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpresented.SelectedIndexChanged, cmbPaymentTerms.SelectedIndexChanged
        Try
            If cmbPaymentTerms.SelectedValue = 3 Then
                lblNetAmount.Visible = False
                txtPaymentAmount.Visible = False
                lblRefNo.Visible = False
                txtRefNo.Visible = False

                If txtAccountName.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Party Name.")
                ElseIf txtAccountName.Text <> "" Then
                    dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                    'AccountCode = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                    If dtAC.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                    End If
                End If
                BindInvoiceGrid()
                dgInvoice.Visible = True
            Else
                lblNetAmount.Visible = True
                txtPaymentAmount.Visible = True
                lblRefNo.Visible = True
                txtRefNo.Visible = True
                dgInvoice.Visible = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub BindInvoiceGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = objtblBankMst.GetInvoiceNaeem(txtAccountName.Text)
            If objDatatble.Rows.Count > 0 Then
                dgInvoice.Visible = True
                dgInvoice.RecordCount = objDatatble.Rows.Count
                dgInvoice.DataSource = objDatatble
                dgInvoice.DataBind()
                LblSupplierId.Text = objDatatble.Rows(0)("AccountPayablePartyId")
            Else
                dgInvoice.Visible = False
            End If
            Dim x As Integer = 0
            Dim Amount As Decimal = 0
            Dim lblCheckdstatus As Label
            Dim txtSTaxPercentage, txtSTaxAmount, txtGSTaxPercentage, txtGSTaxAmount, txtWHTaxPercentage, txtWHTaxAmount, txtAmount As TextBox
            For x = 0 To dgInvoice.Items.Count - 1
                lblCheckdstatus = DirectCast(dgInvoice.Items(x).FindControl("lblCheckdstatus"), Label)
                txtSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxPercentage"), TextBox)
                txtSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxAmount"), TextBox)
                txtGSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxPercentage"), TextBox)
                txtGSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxAmount"), TextBox)
                txtWHTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxPercentage"), TextBox)
                txtWHTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxAmount"), TextBox)
                txtAmount = DirectCast(dgInvoice.Items(x).FindControl("txtAmount"), TextBox)


                '--New changing by Sameen ALAWWAL
                Dim STAmt As Decimal = 0
                Amount = objDatatble.Rows(x)("InvoiceNetAmount")
                txtSTaxAmount.Text = 0 'Math.Round(Val(Amount) * Val(txtSTaxPercentage.Text) / 100, 2)
                txtGSTaxAmount.Text = 0 'Math.Round(Val(txtSTaxAmount.Text) * Val(txtGSTaxPercentage.Text) / 100, 2)
                STAmt = Val(txtSTaxAmount.Text) + Val(Amount)
                txtWHTaxAmount.Text = 0 'Math.Round(Val(STAmt) * Val(txtWHTaxPercentage.Text) / 100, 2)
                Dim AlreadyPayment As Decimal = 0
                Dim Netamount As Decimal = 0
                Netamount = dgInvoice.Items(x).Cells(3).Text
                AlreadyPayment = dgInvoice.Items(x).Cells(4).Text
                txtAmount.Text = Netamount - AlreadyPayment 'Math.Round(Val(STAmt) - Val(txtWHTaxAmount.Text) - Val(txtGSTaxAmount.Text), 2)
            Next
        Catch ex As Exception

        End Try

    End Sub
    '3--- For Description auto come in detai desc
    Protected Sub txtdescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescription.TextChanged
        Try
            txtDescriptionDetail.Text = txtdescription.Text
        Catch ex As Exception

        End Try
    End Sub

    '4----For Add Click
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            lblBankH.Visible = False
            lblbnk.Text = cmbVoucherType.SelectedItem.Text

            If tblBankMstID > 0 Then
                If cmbPaymentTerms.SelectedValue = 3 Then
                    Dim x As Integer
                    Dim ChkStatus As CheckBox
                    Dim a As Integer = 0
                    For x = 0 To dgInvoice.Items.Count - 1
                        ChkStatus = DirectCast(dgInvoice.Items(x).FindControl("ChkStatus"), CheckBox)
                        If ChkStatus.Checked = True Then
                            a = a + 1
                        Else
                            a = a
                        End If
                    Next
                    If a > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        SaveSession()
                        BindGrid()
                        btnUpadateInv.Visible = True
                        ClearControls()
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Check")
                    End If
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    btnUpadateInv.Visible = True
                    ClearControls()
                End If
            Else
                Dim dtchkNo As DataTable
                dtchkNo = objtblBankMst.CheckCheckNo(txtchequeNo.Text)
                '----Remove validation Checkno Duplication on 13 JUL 2016 
                'If dtchkNo.Rows.Count > 0 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Already Exist.")
                'Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                If txtchequeNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Empty.")
                ElseIf txtchequedate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque Date Empty.")
                ElseIf txtDescriptionDetail.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Description Empty.")
                ElseIf cmbPaymentTerms.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select Voucher Type.")
                ElseIf cmbVoucherType.SelectedItem.Text = "Select Type" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select Voucher Type.")
                ElseIf txtxchangeRate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Exchange Rate Empty.")
                Else
                    If cmbPaymentTerms.SelectedValue = 3 Then
                        Dim x As Integer
                        Dim ChkStatus As CheckBox
                        Dim a As Integer = 0
                        For x = 0 To dgInvoice.Items.Count - 1
                            ChkStatus = DirectCast(dgInvoice.Items(x).FindControl("ChkStatus"), CheckBox)
                            If ChkStatus.Checked = True Then
                                a = a + 1
                            Else
                                a = a
                            End If
                        Next
                        If a > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            SaveSession()
                            BindGrid()
                            btnUpadateInv.Visible = True
                            ClearControls()
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Check")
                        End If
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        SaveSession()
                        BindGrid()
                        btnUpadateInv.Visible = True
                        ClearControls()
                    End If
                End If
                '  End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("tblBankDtlID", GetType(Long))
                .Columns.Add("ChequeNo", GetType(String))
                .Columns.Add("ChequeDate", GetType(String))
                .Columns.Add("AccountCode", GetType(String))
                .Columns.Add("AccountName", GetType(String))
                .Columns.Add("DescriptionEntry", GetType(String))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("InitialAmount", GetType(String))
                .Columns.Add("WHTaxAmount", GetType(String))
                .Columns.Add("GSTaxAmount", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("WHTaxAmountCr", GetType(String))
                .Columns.Add("GSTaxAmountCr", GetType(String))
                .Columns.Add("WHTaxAmountDB", GetType(String))
                .Columns.Add("GSTaxAmountDB", GetType(String))
                .Columns.Add("WHTaxPercentage", GetType(String))
                .Columns.Add("GSTaxPercentage", GetType(String))
                .Columns.Add("PaymentTermID", GetType(String))
                .Columns.Add("RefNo", GetType(String))
                .Columns.Add("CurrencyID", GetType(String))
                .Columns.Add("CurrencyName", GetType(String))
                .Columns.Add("ExchangeRate", GetType(String))
               
            End With
        End If
        Dr = dtDetail.NewRow()

        If lbldetail.Text = "" Then
            Dr("tblBankDtlID") = 0
        Else
            Dr("tblBankDtlID") = lbldetail.Text
        End If
        Dr("ChequeNo") = txtchequeNo.Text
        Dr("ChequeDate") = objgeneralCode.GetDate(txtchequedate.Text)

        ' If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
        Dr("AccountCode") = txtAccountCode.Text
        Dr("AccountName") = txtAccountName.Text
        ' Else
        'Dr("AccountCode") = cmbAccountCode.SelectedValue
        ' Dr("AccountName") = objtblBankMst.GetAccountName(cmbAccountCode.SelectedValue)
        'End If

        Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
        Dr("Type") = cmbType.SelectedItem.Text
        Dr("PaymentTermID") = cmbPaymentTerms.SelectedValue

        Dim x As Integer = 0
        Dim initialAmount As Decimal = 0
        Dim WHTaxAmount As Decimal = 0
        Dim GSTaxAmount As Decimal = 0
        Dim WHTaxPercentage As Decimal = 0
        Dim GSTaxPercentage As Decimal = 0
        Dim WHTaxAmountCr As Decimal = 0
        Dim GSTaxAmountCr As Decimal = 0
        Dim WHTaxAmountDB As Decimal = 0
        Dim GSTaxAmountDB As Decimal = 0
        Dim NetAmount As Decimal = 0
        Dim ChkStatus As CheckBox
        Dim lblCheckdstatus As Label
        Dim txtSTaxPercentage, txtSTaxAmount, txtGSTaxPercentage, txtGSTaxAmount, txtWHTaxPercentage, txtWHTaxAmount, txtAmount As TextBox
        For x = 0 To dgInvoice.Items.Count - 1
            lblCheckdstatus = DirectCast(dgInvoice.Items(x).FindControl("lblCheckdstatus"), Label)
            txtSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxPercentage"), TextBox)
            txtSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxAmount"), TextBox)
            txtGSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxPercentage"), TextBox)
            txtGSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxAmount"), TextBox)
            txtWHTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxPercentage"), TextBox)
            txtWHTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxAmount"), TextBox)
            txtAmount = DirectCast(dgInvoice.Items(x).FindControl("txtAmount"), TextBox)
            ChkStatus = DirectCast(dgInvoice.Items(x).FindControl("ChkStatus"), CheckBox)

            If ChkStatus.Checked = True And lblCheckdstatus.Text = 0 Then
                initialAmount = initialAmount + Val(dgInvoice.Items(x).Cells(3).Text)
                WHTaxAmount = WHTaxAmount + Val(txtWHTaxAmount.Text)
                GSTaxAmount = GSTaxAmount + Val(txtGSTaxAmount.Text)
                WHTaxAmountCr = WHTaxAmountCr + Val(txtWHTaxAmount.Text)
                GSTaxAmountCr = GSTaxAmountCr + Val(txtGSTaxAmount.Text)
                WHTaxAmountDB = WHTaxAmountDB + Val(txtWHTaxAmount.Text)
                GSTaxAmountDB = GSTaxAmountDB + Val(txtGSTaxAmount.Text)
                WHTaxPercentage = WHTaxPercentage + Val(txtWHTaxPercentage.Text)
                GSTaxPercentage = GSTaxPercentage + Val(txtGSTaxPercentage.Text)
                NetAmount = NetAmount + Val(txtAmount.Text)
                lblCheckdstatus.Text = 1
                ChkStatus.Enabled = False
            Else

            End If
        Next

        Dr("WHTaxAmount") = WHTaxAmount
        Dr("GSTaxAmount") = GSTaxAmount
        Dr("WHTaxPercentage") = WHTaxPercentage
        Dr("GSTaxPercentage") = GSTaxPercentage
        Dr("WHTaxAmountCr") = -WHTaxAmount
        Dr("GSTaxAmountCr") = -GSTaxAmount
        Dr("WHTaxAmountDB") = WHTaxAmount
        Dr("GSTaxAmountDB") = GSTaxAmount
        If cmbPaymentTerms.SelectedValue = 3 Then
            Dr("InitialAmount") = initialAmount * Val(txtxchangeRate.Text)
            Dr("Amount") = NetAmount * Val(txtxchangeRate.Text)
            Dr("RefNo") = "N/A"
        Else
            Dr("InitialAmount") = Val(txtPaymentAmount.Text) * Val(txtxchangeRate.Text)
            Dr("Amount") = Val(txtPaymentAmount.Text) * Val(txtxchangeRate.Text)
            Dr("RefNo") = txtRefNo.Text
        End If
        Dr("CurrencyID") = cmbCurrency.SelectedValue
        Dr("CurrencyName") = cmbCurrency.SelectedItem.Text
        Dr("ExchangeRate") = txtxchangeRate.Text
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try
            lbltotalAmount.Text = ""
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgView.Visible = True
                dgView.RecordCount = objDatatble.Rows.Count
                dgView.DataSource = objDatatble
                dgView.DataBind()
                lblTotalHding.Visible = True
                lbltotalAmount.Visible = True
            Else
                dgView.Visible = False
                lblTotalHding.Visible = False
                lbltotalAmount.Visible = False
            End If
            Dim TotalWHTaxAmt As Decimal = 0
            Dim TotalSTaxAmt As Decimal = 0
            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                lbltotalAmount.Text = Val(lbltotalAmount.Text) + Val(dgView.Items(x).Cells(10).Text)
                TotalWHTaxAmt = TotalWHTaxAmt + Val(dgView.Items(x).Cells(8).Text)
                TotalSTaxAmt = TotalSTaxAmt + Val(dgView.Items(x).Cells(9).Text)
                Dim datechk As Date = dgView.Items(x).Cells(2).Text
                dgView.Items(x).Cells(2).Text = datechk
            Next
            txtTotalWHTaxAmount.Text = Math.Round(TotalWHTaxAmt, 2)
            txtTotalSTaxAmount.Text = Math.Round(TotalSTaxAmt, 2)

        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        'txtDescriptionDetail.Text = ""
        'txtchequeNo.Text = ""
        'txtamount.Text = ""
        lbldetail.Text = ""
    End Sub
    '---------Save
    Protected Sub btnUpadateInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpadateInv.Click
        Try

            'If txtPaymentType.Text = "" Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Payment Type Empty.")
            If dgView.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One Detail required")
            Else
                If cmbPaymentTerms.SelectedValue = 3 Then
                    Dim X As Integer = 0
                    Dim txtAmount As TextBox
                    Dim AlreadyPayment As Decimal = 0
                    Dim TotalInvoiceAmount As Decimal = 0
                    Dim POInvoiceMstID As Long
                    Dim ChkStatus As CheckBox
                    For X = 0 To dgInvoice.Items.Count - 1
                        ChkStatus = DirectCast(dgInvoice.Items(X).FindControl("ChkStatus"), CheckBox)
                        POInvoiceMstID = dgInvoice.Items(X).Cells(0).Text
                        AlreadyPayment = dgInvoice.Items(X).Cells(4).Text
                        TotalInvoiceAmount = dgInvoice.Items(X).Cells(3).Text
                        txtAmount = DirectCast(dgInvoice.Items(X).FindControl("txtAmount"), TextBox)
                        AlreadyPayment = AlreadyPayment + Val(txtAmount.Text)
                        If ChkStatus.Checked = True Then
                            If AlreadyPayment = TotalInvoiceAmount Then
                                objtblBankMst.UpdateInvoicePaymentComplete(POInvoiceMstID, AlreadyPayment)
                            Else
                                objtblBankMst.UpdateInvoicePayment(POInvoiceMstID, AlreadyPayment)
                            End If
                        Else
                            '---no checked
                        End If
                    Next
                    If tblBankMstID > 0 Then
                        saveData()
                        Response.Redirect("~/Accounts/BankVoucherView.aspx")
                    Else
                        Dim dtchkVoucherNoDuplication As DataTable
                        dtchkVoucherNoDuplication = objtblBankMst.ChkVoucherNoDuplication(txtVoucherNo.Text)
                        If dtchkVoucherNoDuplication.Rows.Count > 0 Then
                            VoucherNoGenerateOnLoad()
                        End If
                        saveData()
                        Response.Redirect("~/Accounts/BankVoucherView.aspx")
                    End If


                Else
                    If tblBankMstID > 0 Then
                        saveData()
                        Response.Redirect("~/Accounts/BankVoucherView.aspx")
                    Else
                        Dim dtchkVoucherNoDuplication As DataTable
                        dtchkVoucherNoDuplication = objtblBankMst.ChkVoucherNoDuplication(txtVoucherNo.Text)
                        If dtchkVoucherNoDuplication.Rows.Count > 0 Then
                            VoucherNoGenerateOnLoad()
                        End If
                        saveData()
                        Response.Redirect("BankVoucherView.aspx")
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub saveData()


        If txtVoucherNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("VoucherNo Not Empty.")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            With objtblBankMst
                If tblBankMstID > 0 Then
                    .tblBankMstID = tblBankMstID
                Else
                    .tblBankMstID = 0
                End If
                .CompanyId = "0001"

                .VoucherNo = txtVoucherNo.Text
                .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                    .BookAccount = cmbBookAccount.SelectedValue
                Else
                    .BookAccount = cmbBookAccount.SelectedValue 'txtBookAccountCode.Text
                End If
                .Description = txtdescription.Text
                If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                    .VoucherType = "R"
                Else
                    .VoucherType = "P"
                End If
                .Cancel = "N/A"
                .EntryDate = Date.Now
                .UserId = objtblBankMst.GetUserName(CLng(Session("Userid")))
                .VoucherNoOld = "N/A"
                .VoucherNoNew = "N/A"
                .UID = CLng(Session("Userid"))
                .TotalAmount = lbltotalAmount.Text
                'If RBBtn.SelectedItem.Text = "General Expense" Then
                .InvoiceType = 0 'RBBtn.SelectedItem.Text
                ''Else
                ' .InvoiceType = RBBtn.SelectedItem.Text
                ' End If
                .VNo = txtVno.Text
                .VoucherTypeID = cmbVoucherType.SelectedValue
                .CashTypeID = cmbpaytype.SelectedValue
                .PresentedID = cmbpresented.SelectedValue
                .LockBit = False
                .SavetblBankMst()
            End With

            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                With objtblBankDtl
                    .tblBankDtlID = dgView.Items(x).Cells(0).Text
                    If tblBankMstID > 0 Then
                        .tblBankMstID = tblBankMstID

                    Else
                        .tblBankMstID = objtblBankMst.GetID()
                    End If
                    .CompanyId = "0001"
                    .VoucherNo = txtVoucherNo.Text
                    .AccountCode = dgView.Items(x).Cells(3).Text
                    .DescriptionEntry = dgView.Items(x).Cells(5).Text
                    .ChequeNo = dgView.Items(x).Cells(1).Text
                    .ChequeDate = dgView.Items(x).Cells(2).Text
                    '  .Type = dgView.Items(x).Cells(6).Text
                    If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                        .Type = "D"
                    Else
                        .Type = "C"
                    End If


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
                    Dim TopSNo As Integer = objtblBankMst.GetTopSNO()
                    .Sno = Val(TopSNo + 1)
                    .WHTaxPercentage = dgView.Items(x).Cells(15).Text 'txtWHTaxPercentage.Text
                    .WHTaxAmountCr = dgView.Items(x).Cells(11).Text
                    .GSTaxPercentage = dgView.Items(x).Cells(16).Text 'txtGSTaxPercentage.Text
                    .GSTaxAmountCr = dgView.Items(x).Cells(12).Text
                    .Amount = dgView.Items(x).Cells(10).Text
                    .WHTaxAmountDB = dgView.Items(x).Cells(13).Text
                    .GSTaxAmountDB = dgView.Items(x).Cells(14).Text

                    .DOC_RefNo = dgView.Items(x).Cells(17).Text '----Use as Ref no in Detail
                    .PaymentTermID = dgView.Items(x).Cells(18).Text
                    .InitialAmount = dgView.Items(x).Cells(7).Text
                    .CurrencyID = dgView.Items(x).Cells(20).Text
                    .CurrencyName = dgView.Items(x).Cells(21).Text
                    .ExchangeRate = dgView.Items(x).Cells(19).Text
                    .SavetblBankDtl()
                End With
            Next

        End If
    End Sub

    '-----------Voucher no Creation
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim dtchllocked As DataTable
            Dim VoucherNo As String
            Dim VoucherType As String
            Dim Voucherdate As Date = txtVoucherdate.Text
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
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
            If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                VoucherType = "R"
            ElseIf cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                VoucherType = "P"
            Else
                VoucherType = "C"
            End If
            dtchllocked = objtblBankMst.CHKLocked(Month, yearP)
            If dtchllocked.Rows.Count > 0 Then
                txtVoucherdate.Text = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Selection Date of Month and year Locked ....")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")


                Dim LastVoucherNo As String = objtblBankMst.GetLastVoucherNoNew(Month, yearP, VoucherType)
                Dim PreviousMonth As Integer
                Dim LastCode As String
                If LastVoucherNo = "" Then
                    LastCode = "00001"
                Else
                    ' PreviousMonth = LastVoucherNo.Substring(7, 2)
                    LastCode = LastVoucherNo 'LastVoucherNo.Substring(10, 5)
                    'If PreviousMonth = Month Then
                    If LastCode <> "" Then
                        If LastCode < 10 Then
                            If LastCode = 9 Then
                                LastCode = "000" & Val(LastCode + 1)
                            Else
                                LastCode = "0000" & Val(LastCode + 1)
                            End If
                            ' LastCode = "0000" & Val(LastCode + 1)
                        ElseIf LastCode < 100 Or LastCode = 10 Then
                            If LastCode = 99 Then
                                LastCode = "00" & Val(LastCode + 1)
                            Else
                                LastCode = "000" & Val(LastCode + 1)
                            End If
                            'LastCode = "000" & Val(LastCode + 1)
                        ElseIf LastCode < 1000 Or LastCode = 100 Then
                            If LastCode = 999 Then
                                LastCode = "0" & Val(LastCode + 1)
                            Else
                                LastCode = "00" & Val(LastCode + 1)
                            End If
                            'LastCode = "00" & Val(LastCode + 1)
                        ElseIf LastCode < 10000 Or LastCode = 1000 Then
                            If LastCode = 9999 Then
                                LastCode = Val(LastCode + 1)
                            Else
                                LastCode = Val(LastCode + 1)
                            End If
                        Else
                            LastCode = Val(LastCode + 1)
                        End If
                    Else
                        LastCode = "00001"
                    End If
                End If
                VoucherNo = "BB" & "-" & VoucherType & "-" & year & "" & CodeMonth & "-" & LastCode
                txtVoucherNo.Text = VoucherNo

                If cmbVoucherType.SelectedValue = 0 Then
                    cmbType.Enabled = True
                ElseIf cmbVoucherType.SelectedValue = 1 Then
                    cmbType.SelectedValue = 1
                    cmbType.Enabled = False
                ElseIf cmbVoucherType.SelectedValue = 2 Then
                    cmbType.SelectedValue = 0
                    cmbType.Enabled = False
                ElseIf cmbVoucherType.SelectedValue = 3 Then
                    cmbType.SelectedValue = 0
                    cmbType.Enabled = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtVoucherdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate.TextChanged
        Try
            VoucherNoGenerateOnLoad()




        Catch ex As Exception

        End Try
    End Sub
    '-----New Develpment End


    'Save General voucher and Adjust

    '



    Sub EditMode()
        Try
            Dim dt As DataTable = objtblBankMst.Edit(tblBankMstID)
            txtVoucherNo.Text = dt.Rows(0)("VoucherNo")
            txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
            txtVno.Text = dt.Rows(0)("VNo")
            '  cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")

            'If cmbVoucherType.SelectedValue = 2 Then
            '    pnlbookaccountMst.Visible = False
            '    pnlbookaccountMstSearch.Visible = True

            '    cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
            'Else
            '    pnlAccountCodedtl.Visible = True
            '    pnlAccountCodedtlSearchAuto.Visible = False

            '    Dim BookAccount As String = dt.Rows(0)("BookAccount")
            '    Dim BookAccountName As String = objtblBankMst.GetBookAccountNameMaster(BookAccount)
            '    cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
            'End If
            BindPaymentTerms()
            txtdescription.Text = dt.Rows(0)("Description")
            Dim VoucherType As String = dt.Rows(0)("VoucherType")
            If VoucherType = "R" Then
                pnlbookaccountMst.Visible = True
                pnlAccountCodedtlSearchAuto.Visible = True
                ' pnlbookaccountMst.Visible = False
                'pnlAccountCodedtl.Visible = True
                'pnlAccountCodedtlSearchAuto.Visible = False
                ' pnlbookaccountMstSearch.Visible = True
                Dim BookAccount As String = dt.Rows(0)("BookAccount")
                Dim BookAccountName As String = objtblBankMst.GetBookAccountNameMaster(BookAccount)

                ' txtBookAccountCode.Text = BookAccount
                'txtBookAccountName.Text = BookAccountName

                ' txtBookAccountLevel.Text = dt.Rows(0)("AccountLevel").ToString() + " Account"
                ' If dt.Rows(0)("AccountLevel") = "Detail" Then
                'txtBookAccountLevel.BackColor = Drawing.Color.LightGreen
                'Else
                '   txtBookAccountLevel.BackColor = Drawing.Color.Red
                ' End If
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                ' cmbVoucherType.SelectedItem.Text = "Receipt Voucher"
                cmbVoucherType.SelectedValue = 1
                ' cmbType.SelectedItem.Text = "C"
                cmbType.SelectedValue = 1
                cmbType.Enabled = False
            Else
                pnlbookaccountMst.Visible = True
                ' pnlAccountCodedtl.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = True
                'pnlbookaccountMstSearch.Visible = False
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                'cmbVoucherType.SelectedItem.Text = "Payment Voucher"
                cmbVoucherType.SelectedValue = 2
                ' cmbType.SelectedItem.Text = "D"
                cmbType.SelectedValue = 0
                cmbType.Enabled = False

            End If
            lbltotalAmount.Text = dt.Rows(0)("TotalAmount")


            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("tblBankDtlID", GetType(Long))
                    .Columns.Add("ChequeNo", GetType(String))
                    .Columns.Add("ChequeDate", GetType(String))
                    .Columns.Add("AccountCode", GetType(String))
                    .Columns.Add("AccountName", GetType(String))
                    .Columns.Add("DescriptionEntry", GetType(String))
                    .Columns.Add("Type", GetType(String))

                    .Columns.Add("InitialAmount", GetType(String))
                    .Columns.Add("WHTaxAmount", GetType(String))
                    .Columns.Add("GSTaxAmount", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("WHTaxAmountCr", GetType(String))
                    .Columns.Add("GSTaxAmountCr", GetType(String))
                    .Columns.Add("WHTaxAmountDB", GetType(String))
                    .Columns.Add("GSTaxAmountDB", GetType(String))
                    .Columns.Add("WHTaxPercentage", GetType(String))
                    .Columns.Add("GSTaxPercentage", GetType(String))

                    '----New
                    .Columns.Add("PaymentTermID", GetType(String))
                    .Columns.Add("RefNo", GetType(String))
                    .Columns.Add("CurrencyID", GetType(String))
                    .Columns.Add("CurrencyName", GetType(String))
                    .Columns.Add("ExchangeRate", GetType(String))

                End With
            End If

            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("tblBankDtlID") = dt.Rows(x)("tblBankDtlID")
                Dr("ChequeNo") = dt.Rows(x)("ChequeNo")
                Dr("ChequeDate") = dt.Rows(x)("ChequeDate")
                Dr("AccountCode") = dt.Rows(x)("AccountCode")
                Dr("AccountName") = dt.Rows(x)("AccountName")
                Dr("DescriptionEntry") = dt.Rows(x)("DescriptionEntry")
                Dr("Type") = dt.Rows(x)("Type")
                Dr("InitialAmount") = dt.Rows(x)("InitialAmount")

                Dr("WHTaxAmount") = dt.Rows(x)("WHTaxAmountCr")
                Dr("GSTaxAmount") = dt.Rows(x)("GSTaxAmountCr")

                Dr("Amount") = dt.Rows(x)("Amount")
                Dr("WHTaxAmountCr") = dt.Rows(x)("WHTaxAmountCr")
                Dr("GSTaxAmountCr") = dt.Rows(x)("GSTaxAmountCr")
                Dr("WHTaxAmountDB") = dt.Rows(x)("WHTaxAmountDB")
                Dr("GSTaxAmountDB") = dt.Rows(x)("GSTaxAmountDB")
                Dr("WHTaxPercentage") = dt.Rows(x)("WHTaxPercentage")
                Dr("GSTaxPercentage") = dt.Rows(x)("GSTaxPercentage")

                '----New
                Dr("PaymentTermID") = dt.Rows(x)("PaymentTermID")
                Dr("RefNo") = dt.Rows(x)("DOC_RefNo")
                Dr("CurrencyID") = dt.Rows(x)("CurrencyID")
                Dr("CurrencyName") = dt.Rows(x)("CurrencyName")
                Dr("ExchangeRate") = dt.Rows(x)("ExchangeRate")


                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbVoucherType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVoucherType.SelectedIndexChanged
        Try
            lblBankH.Text = cmbVoucherType.SelectedItem.Text
            Session("VoucherType") = cmbVoucherType.SelectedItem.Text
            VoucherNoGenerateOnLoad()
            If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                cmbType.SelectedValue = 1
            ElseIf cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                cmbType.SelectedValue = 0
            Else
                cmbType.SelectedValue = 0
            End If
            'Dim VoucherNo As String
            'Dim VoucherType As String
            'Dim Voucherdate As Date = txtVoucherdate.Text
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
            'If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
            '    VoucherType = "R"
            'ElseIf cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
            '    VoucherType = "P"
            'Else
            '    VoucherType = "C"
            'End If
            'Dim LastVoucherNo As String = objtblBankMst.GetLastVoucherNo(Month, yearP)
            'Dim PreviousMonth As Integer
            'Dim LastCode As String
            'If LastVoucherNo = "" Then
            '    LastCode = "00001"
            'Else
            '    PreviousMonth = LastVoucherNo.Substring(7, 2)
            '    LastCode = LastVoucherNo.Substring(10, 5)
            '    If PreviousMonth = Month Then
            '        If LastCode < 10 Then
            '            LastCode = "0000" & Val(LastCode + 1)
            '        ElseIf LastCode < 100 Or LastCode >= 10 Then
            '            LastCode = "000" & Val(LastCode + 1)
            '        ElseIf LastCode < 1000 Or LastCode >= 100 Then
            '            LastCode = "00" & Val(LastCode + 1)
            '        Else
            '        End If
            '    Else
            '        LastCode = "00001"
            '    End If
            'End If
            'VoucherNo = "BB" & "-" & VoucherType & "-" & year & "" & CodeMonth & "-" & LastCode
            'txtVoucherNo.Text = VoucherNo

            '' 'If cmbVoucherType.SelectedValue = 0 Then
            'If cmbVoucherType.SelectedValue = 3 Then
            '    BindBookAccountFirstTime()
            'End If

            ' ''ElseIf cmbVoucherType.SelectedValue = 1 Then
            ' ''    BindBookAccount()
            ' ''    BindAccountCodeFirstTime()
            ' ''ElseIf cmbVoucherType.SelectedValue = 2 Then
            ' ''    BindBookAccountFirstTime()
            ' ''    BindAccountCode()
            ' ''    cmbVoucherType.SelectedValue = 2
            ' ''End If


            'If cmbVoucherType.SelectedValue = 0 Then
            '    cmbType.Enabled = True
            'ElseIf cmbVoucherType.SelectedValue = 1 Then
            '    cmbType.SelectedValue = 1
            '    cmbType.Enabled = False
            'ElseIf cmbVoucherType.SelectedValue = 2 Then
            '    cmbType.SelectedValue = 0
            '    cmbType.Enabled = False
            'ElseIf cmbVoucherType.SelectedValue = 3 Then
            '    cmbType.SelectedValue = 0
            '    cmbType.Enabled = False
            'End If



            ' ''pnlbookaccountMst.Visible = False
            ' ''pnlbookaccountMstSearch.Visible = True

            ' ''pnlAccountCodedtl.Visible = True
            ' ''pnlAccountCodedtlSearchAuto.Visible = False

            pnlbookaccountMst.Visible = True
            pnlbookaccountMstSearch.Visible = False
            pnlAccountCodedtl.Visible = False
            pnlAccountCodedtlSearchAuto.Visible = True


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        dtDetail = CType(Session("dtDetail"), DataTable)
                        If (Not dtDetail Is Nothing) Then
                            If (dtDetail.Rows.Count > 0) Then
                                Dim ltblBankDtlID As Integer = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                                If ltblBankDtlID > 0 Then
                                    SetDetailValuesByDataTable(e.Item.ItemIndex)
                                    dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                                    BindGrid()
                                Else
                                    dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                                    BindGrid()
                                End If
                                btnUpadateInv.Visible = False
                                btnAdd.Visible = True
                            End If
                        End If
                    End If
                Case "Remove"
                    'Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    'objtblBankMst.DeleteBrandDatabase(tblBankMstID)
                    'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                    'Dim objDataView As DataView
                    'objDataView = LoadData()
                    'Session("objDataView") = objDataView
                    'BindGrid()


            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try

            If dtDetail.Rows(dtrowNo)("PaymentTermID") = 3 Then '---Use against ref
            Else
                BindCurrency()
                BindPaymentTerms()
                lbldetail.Text = dtDetail.Rows(dtrowNo)("tblBankDtlID")
                txtchequeNo.Text = dtDetail.Rows(dtrowNo)("ChequeNo")
                txtchequedate.Text = dtDetail.Rows(dtrowNo)("ChequeDate")
                txtDescriptionDetail.Text = dtDetail.Rows(dtrowNo)("DescriptionEntry")
                '   cmbType.SelectedItem.Text = dtDetail.Rows(dtrowNo)("Type")


                ' txtIntialAmount.Text = dtDetail.Rows(dtrowNo)("InitialAmount")

                ' txtWHTaxAmount.Text = dtDetail.Rows(dtrowNo)("WHTaxAmount")
                ' txtGSTaxAmount.Text = dtDetail.Rows(dtrowNo)("GSTaxAmount")

                'txtamount.Text = dtDetail.Rows(dtrowNo)("Amount")

                If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                    cmbType.SelectedValue = 1
                    'pnlAccountCodedtl.Visible = True
                    'pnlAccountCodedtlSearchAuto.Visible = False
                    'cmbAccountCode.SelectedValue = dtDetail.Rows(dtrowNo)("AccountCode")
                    pnlAccountCodedtl.Visible = False
                    pnlAccountCodedtlSearchAuto.Visible = True
                    Dim BookAccount As String = dtDetail.Rows(dtrowNo)("AccountCode")
                    Dim BookAccountName As String = objtblBankMst.GetBookAccountNameMaster(BookAccount)
                    txtAccountCode.Text = BookAccount
                    txtAccountName.Text = BookAccountName

                    dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                    txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                    If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                        txtAccountLevel.BackColor = Drawing.Color.LightGreen
                    Else
                        txtAccountLevel.BackColor = Drawing.Color.Red
                    End If
                Else
                    cmbType.SelectedValue = 0
                    pnlAccountCodedtl.Visible = False
                    pnlAccountCodedtlSearchAuto.Visible = True
                    Dim BookAccount As String = dtDetail.Rows(dtrowNo)("AccountCode")
                    Dim BookAccountName As String = objtblBankMst.GetBookAccountNameMaster(BookAccount)
                    txtAccountCode.Text = BookAccount
                    txtAccountName.Text = BookAccountName

                    dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                    txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                    If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                        txtAccountLevel.BackColor = Drawing.Color.LightGreen
                    Else
                        txtAccountLevel.BackColor = Drawing.Color.Red
                    End If
                End If
                '----------------New
                cmbPaymentTerms.SelectedValue = dtDetail.Rows(dtrowNo)("PaymentTermID")
                lblNetAmount.Visible = True
                txtPaymentAmount.Visible = True
                lblRefNo.Visible = True
                txtRefNo.Visible = True
                txtPaymentAmount.Text = dtDetail.Rows(dtrowNo)("Amount")
                txtRefNo.Text = dtDetail.Rows(dtrowNo)("RefNo")

                cmbCurrency.SelectedValue = dtDetail.Rows(dtrowNo)("CurrencyID")
                txtxchangeRate.Text = dtDetail.Rows(dtrowNo)("ExchangeRate")

                'If cmbPaymentTerms.SelectedValue = 3 Then
                '    Dr("InitialAmount") = initialAmount * Val(txtxchangeRate.Text)
                '    Dr("Amount") = NetAmount * Val(txtxchangeRate.Text)
                '    Dr("RefNo") = "N/A"
                'Else
                '    Dr("InitialAmount") = Val(txtPaymentAmount.Text) * Val(txtxchangeRate.Text)
                '    Dr("Amount") = Val(txtPaymentAmount.Text) * Val(txtxchangeRate.Text)
                '    Dr("RefNo") = txtRefNo.Text
                'End If
                'Dr("CurrencyID") = cmbCurrency.SelectedValue
                'Dr("CurrencyName") = cmbCurrency.SelectedItem.Text
                'Dr("ExchangeRate") = txtxchangeRate.Text


            End If
        Catch ex As Exception
        End Try
    End Sub

    '----Not use recently Taxes
    Protected Sub txtGSTaxPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer = 0
            Dim Amount As Decimal = 0
            Dim txtSTaxPercentage, txtSTaxAmount, txtGSTaxPercentage, txtGSTaxAmount, txtWHTaxPercentage, txtWHTaxAmount, txtAmount As TextBox
            For x = 0 To dgInvoice.Items.Count - 1
                txtSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxPercentage"), TextBox)
                txtSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxAmount"), TextBox)
                txtGSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxPercentage"), TextBox)
                txtGSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxAmount"), TextBox)
                txtWHTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxPercentage"), TextBox)
                txtWHTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxAmount"), TextBox)
                txtAmount = DirectCast(dgInvoice.Items(x).FindControl("txtAmount"), TextBox)



                'txtWHTaxAmount.Text = Val(Amount) * Val(txtWHTaxPercentage.Text) / 100
                'txtGSTaxAmount.Text = Val(Amount) * Val(txtGSTaxPercentage.Text) / 100
                'txtAmount.Text = Val(Amount) - (Val(txtWHTaxAmount.Text) + Val(txtGSTaxAmount.Text))


                Dim STAmt As Decimal = 0
                Amount = Val(dgInvoice.Items(x).Cells(4).Text)
                txtSTaxAmount.Text = Math.Round(Val(Amount) * Val(txtSTaxPercentage.Text) / 100, 2)
                txtGSTaxAmount.Text = Math.Round(Val(txtSTaxAmount.Text) * Val(txtGSTaxPercentage.Text) / 100, 2)
                STAmt = Val(txtSTaxAmount.Text) + Val(Amount)
                txtWHTaxAmount.Text = Math.Round(Val(STAmt) * Val(txtWHTaxPercentage.Text) / 100, 2)
                txtAmount.Text = Math.Round(Val(STAmt) - Val(txtWHTaxAmount.Text) - Val(txtGSTaxAmount.Text), 2)


            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtWHTaxPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer = 0
            Dim Amount As Decimal = 0
            Dim txtSTaxPercentage, txtSTaxAmount, txtGSTaxPercentage, txtGSTaxAmount, txtWHTaxPercentage, txtWHTaxAmount, txtAmount As TextBox
            For x = 0 To dgInvoice.Items.Count - 1
                txtSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxPercentage"), TextBox)
                txtSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxAmount"), TextBox)
                txtGSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxPercentage"), TextBox)
                txtGSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxAmount"), TextBox)
                txtWHTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxPercentage"), TextBox)
                txtWHTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxAmount"), TextBox)
                txtAmount = DirectCast(dgInvoice.Items(x).FindControl("txtAmount"), TextBox)

                'Amount = Val(dgInvoice.Items(x).Cells(4).Text)
                'txtWHTaxAmount.Text = Val(Amount) * Val(txtWHTaxPercentage.Text) / 100
                'txtGSTaxAmount.Text = Val(Amount) * Val(txtGSTaxPercentage.Text) / 100
                'txtAmount.Text = Val(Amount) - (Val(txtWHTaxAmount.Text) + Val(txtGSTaxAmount.Text))

                Dim STAmt As Decimal = 0
                Amount = Val(dgInvoice.Items(x).Cells(4).Text)
                txtSTaxAmount.Text = Math.Round(Val(Amount) * Val(txtSTaxPercentage.Text) / 100, 2)
                txtGSTaxAmount.Text = Math.Round(Val(txtSTaxAmount.Text) * Val(txtGSTaxPercentage.Text) / 100, 2)
                STAmt = Val(txtSTaxAmount.Text) + Val(Amount)
                txtWHTaxAmount.Text = Math.Round(Val(STAmt) * Val(txtWHTaxPercentage.Text) / 100, 2)
                txtAmount.Text = Math.Round(Val(STAmt) - Val(txtWHTaxAmount.Text) - Val(txtGSTaxAmount.Text), 2)


            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtSTaxPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Amount As Decimal = 0

        Dim x As Integer = 0
        Dim txtSTaxPercentage, txtSTaxAmount, txtGSTaxPercentage, txtAmount, txtGSTaxAmount, txtWHTaxAmount As TextBox

        For x = 0 To dgInvoice.Items.Count - 1
            Amount = Val(dgInvoice.Items(x).Cells(4).Text)
            txtSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxPercentage"), TextBox)
            txtSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtSTaxAmount"), TextBox)
            txtAmount = DirectCast(dgInvoice.Items(x).FindControl("txtAmount"), TextBox)
            txtGSTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxAmount"), TextBox)
            txtWHTaxAmount = DirectCast(dgInvoice.Items(x).FindControl("txtWHTaxAmount"), TextBox)
            txtGSTaxPercentage = DirectCast(dgInvoice.Items(x).FindControl("txtGSTaxPercentage"), TextBox)
            If Val(txtSTaxPercentage.Text) = 0 Then

                txtSTaxAmount.Text = 0
                txtGSTaxAmount.Text = 0
                txtGSTaxPercentage.Text = 0
                txtAmount.Text = (Amount + Val(txtSTaxAmount.Text)) - (Val(txtGSTaxAmount.Text) + Val(txtWHTaxAmount.Text))
            Else

                txtSTaxAmount.Text = Val(Amount) * Val(txtSTaxPercentage.Text) / 100
                txtGSTaxAmount.Text = Val(txtSTaxAmount.Text) * Val(txtGSTaxAmount.Text) / 100


                txtAmount.Text = (Amount + Val(txtSTaxAmount.Text)) - (Val(txtGSTaxAmount.Text) + Val(txtWHTaxAmount.Text))

            End If




        Next
    End Sub
    '--End--Not use recently Taxes


    Protected Sub BtnCanelInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCanelInv.Click
        Try
            Response.Redirect("BankVoucherView.aspx")
            'Server.Transfer("BankVoucherView.aspx")

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub txtchequeNo_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dtchkNoDuplication As DataTable
            dtchkNoDuplication = objtblBankMst.ChkNoDuplication(txtchequeNo.Text)
            If dtchkNoDuplication.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Check No Already Exist...")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class



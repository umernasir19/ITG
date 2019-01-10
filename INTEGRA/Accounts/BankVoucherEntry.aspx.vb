Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class BankVoucherEntry
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objtblBankMst As New tblBankMst
    Dim objtblBankDtl As New tblBankDtl
    Dim objInvoiceMst As New InvoiceMst
    Dim ObjtblBankDtlDetail As New tblBankDtlDetail
    Dim objPOInvoiceAdjDetail As New POInvoiceAdjDetail
    Dim objgeneralCode As New GeneralCode
    Dim dtDetail, dtAdjustDetail As DataTable
    Dim Dr As DataRow
    Dim tblBankMstID As Long
    Dim dtAC As DataTable
    Dim AccountCode, Voucher As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tblBankMstID = Request.QueryString("ltblBankMstID")
        Voucher = Request.QueryString("Voucher")
        If Not Page.IsPostBack Then
            BindVoucherType()
            BindBookAccount()
            Session("dtDetail") = Nothing
            Session("dtAdjustDetail") = Nothing
            Session("dtDetailInv") = Nothing
            If tblBankMstID > 0 Then
                EditMode()
                btnUpadateInv.Text = "Update"
            Else
                txtVoucherdate2.Text = Date.Now
                txtVoucherdate.Text = Date.Now
                VoucherNoGenerateOnLoad()
                BindPaymentTerms()
                cmbVoucherType.SelectedValue = 2
                txtchequedate.Text = Date.Now
                btnUpadateInv.Text = "Save"
                VoucherNoGenerateOnLoad()
                pnlbookaccountMst.Visible = True
                pnlbookaccountMstSearch.Visible = False
                pnlAccountCodedtl.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = True
            End If
        End If
        If cmbVoucherType.SelectedValue = 1 Then
            lblBankH.Text = "Bank Receipt Voucher"
        Else
            lblBankH.Text = "Bank Payment Voucher"
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
        Else
        End If
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
        dt = objtblBankMst.GetBankName()
        cmbBookAccount.DataSource = dt
        cmbBookAccount.DataTextField = "AccountName"
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
    Protected Sub txtBookAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookAccountName.TextChanged
        Try
            If txtBookAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtBookAccountName.Text <> "" Then
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
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Try
            If txtAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Party Name.")
            ElseIf txtAccountName.Text <> "" Then
                dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If
                If cmbBookAccount.SelectedValue = dtAC.Rows(0)("AccountCode") Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Already Selected")
                    txtAccountName.Text = ""
                    txtAccountCode.Text = ""
                    txtAccountLevel.Text = ""
                    txtAccountLevel.BackColor = Drawing.Color.White
                Else
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
                    dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
                    dtJVamountt = objtblBankMst.GetJVDataForLedger(txtAccountCode.Text)
                    dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
                    dtContamount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)
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
            End If
            If txtLedgerBalance.Text >= 0 Then
                lblLedgerBalanceCRDR.Text = "Dr"
            Else
                lblLedgerBalanceCRDR.Text = "Cr"
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
                dtAC = objtblBankMst.GetUniqueCostCenter(txtCostCenter.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    lblCostCenterId.Text = dtAC.Rows(0)("CostCenterId")
                Else
                    lblCostCenterId.Text = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cost Center Not Exist")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPaymentTerms_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
                    If dtAC.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                    End If
                End If
                BindInvoiceGrid()
                dgInvoice.Visible = True
                txtRefNo.Text = cmbPaymentTerms.SelectedItem.Text
                pnlllfalse.Visible = True
                udppnlllfalse.Update()
            Else
                pnlllfalse.Visible = False
                udppnlllfalse.Update()
                Dim dt As DataTable
                dgInvoice.DataSource = dt
                dgInvoice.DataBind()

                Dim A As Decimal = 0
                Dim B As Decimal = 0
                If txtTotalPayment.Text = "" Then
                    txtTotalPayment.Text = 0
                Else
                    txtTotalPayment.Text = txtTotalPayment.Text
                End If
                A = txtTotalPayment.Text
                If lbltotalAmount.Text = "" Then
                    lbltotalAmount.Text = 0
                Else
                    lbltotalAmount.Text = lbltotalAmount.Text
                End If
                B = lbltotalAmount.Text
                txtPaymentAmount.Text = Val(A) - Val(B)
                txtPaymentAmount.Text = Convert.ToDecimal(txtPaymentAmount.Text).ToString("#,##0.00")
                lblNetAmount.Visible = True
                txtPaymentAmount.Visible = True
                lblRefNo.Visible = True
                txtRefNo.Visible = True
                dgInvoice.Visible = False
                txtRefNo.Text = cmbPaymentTerms.SelectedItem.Text
            End If
            Session("Supplier") = txtAccountName.Text
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
                Dim STAmt As Decimal = 0
                Amount = objDatatble.Rows(x)("InvoiceNetAmount")
                txtSTaxAmount.Text = 0
                txtGSTaxAmount.Text = 0
                STAmt = Val(txtSTaxAmount.Text) + Val(Amount)
                txtWHTaxAmount.Text = 0
                Dim AlreadyPayment As Decimal = 0
                Dim Netamount As Decimal = 0
                Netamount = dgInvoice.Items(x).Cells(3).Text
                AlreadyPayment = dgInvoice.Items(x).Cells(4).Text
                txtAmount.Text = Netamount - AlreadyPayment
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub BindInvoiceGridONAutoSearch()
        Try
            Dim objDatatble As DataTable
            objDatatble = objtblBankMst.GetInvoiceNaeemWithDCAutoSearch(txtAccountName.Text, txtShowMeINV.Text)
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
                Dim STAmt As Decimal = 0
                Amount = objDatatble.Rows(x)("InvoiceNetAmount")
                txtSTaxAmount.Text = 0
                txtGSTaxAmount.Text = 0
                STAmt = Val(txtSTaxAmount.Text) + Val(Amount)
                txtWHTaxAmount.Text = 0
                Dim AlreadyPayment As Decimal = 0
                Dim Netamount As Decimal = 0
                Netamount = dgInvoice.Items(x).Cells(3).Text
                AlreadyPayment = dgInvoice.Items(x).Cells(4).Text
                txtAmount.Text = Netamount - AlreadyPayment
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtdescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescription.TextChanged
        Try
            txtDescriptionDetail.Text = txtdescription.Text
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Session("dtDetail") = Nothing
            Dim dtchkNo As DataTable
            dtchkNo = objtblBankMst.CheckCheckNo(txtchequeNo.Text)
            If tblBankMstID > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                lblerorMsgg.Text = ""
                If txtchequeNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Empty.")
                    lblerorMsgg.Text = "Cheque No Empty"
                ElseIf txtchequedate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque Date Empty.")
                    lblerorMsgg.Text = "Cheque Date Empty."
                ElseIf txtDescriptionDetail.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Description Empty.")
                    lblerorMsgg.Text = "Description Empty."
                ElseIf cmbPaymentTerms.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select PaymentTerms.")
                    lblerorMsgg.Text = "select PaymentTerms"
                ElseIf cmbVoucherType.SelectedItem.Text = "Select Type" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select Voucher Type.")
                    lblerorMsgg.Text = "select Voucher Type."
                Else
                    Dim dtchkinvoiceduplicateadd As New DataTable
                    dtchkinvoiceduplicateadd = Session("dtDetailInv")
                    Dim results As DataRow()
                    If dgpaymentDetailInvoicewise.Items.Count > 0 Then
                        Dim z As Integer = 0
                        Dim Invno As String
                        Dim ChkStatus As CheckBox
                        For z = 0 To dgInvoice.Items.Count - 1
                            ChkStatus = DirectCast(dgInvoice.Items(z).FindControl("ChkStatus"), CheckBox)
                            If ChkStatus.Checked = True Then
                                Invno = dgInvoice.Items(z).Cells(1).Text
                                results = dtchkinvoiceduplicateadd.Select("SaleTaxInvoiceNo='" & Invno & "'")
                                If results.Length = 1 Then
                                    Exit For
                                End If
                            End If
                        Next
                        If cmbPaymentTerms.SelectedValue = 3 Then
                            If results.Length <> 1 Then
                                SaveSessionDetailInvoicewise()
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                            Else
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Al ready add Invoice")
                            End If
                        Else
                            SaveSessionDetailInvoicewise()
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        End If
                    Else
                        SaveSessionDetailInvoicewise()
                    End If
                    If dgpaymentDetailInvoicewise.Items.Count > 0 Then
                        SaveSessionMainGrd()
                    Else
                    End If
                End If
            Else
                If dtchkNo.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Already Exist.")
                    lblerorMsgg.Text = "Cheque No Already Exist."
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    lblerorMsgg.Text = ""
                    If txtchequeNo.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque No Empty.")
                        lblerorMsgg.Text = "Cheque No Empty"
                    ElseIf txtchequedate.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cheque Date Empty.")
                        lblerorMsgg.Text = "Cheque Date Empty."
                    ElseIf txtDescriptionDetail.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Description Empty.")
                        lblerorMsgg.Text = "Description Empty."
                    ElseIf cmbPaymentTerms.SelectedItem.Text = "Select" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select PaymentTerms.")
                        lblerorMsgg.Text = "select PaymentTerms"
                    ElseIf cmbVoucherType.SelectedItem.Text = "Select Type" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("select Voucher Type.")
                        lblerorMsgg.Text = "select Voucher Type."
                    Else
                        Dim dtchkinvoiceduplicateadd As New DataTable
                        dtchkinvoiceduplicateadd = Session("dtDetailInv")
                        Dim results As DataRow()
                        If dgpaymentDetailInvoicewise.Items.Count > 0 Then
                            Dim z As Integer = 0
                            Dim Invno As String
                            Dim ChkStatus As CheckBox
                            For z = 0 To dgInvoice.Items.Count - 1
                                ChkStatus = DirectCast(dgInvoice.Items(z).FindControl("ChkStatus"), CheckBox)
                                If ChkStatus.Checked = True Then
                                    Invno = dgInvoice.Items(z).Cells(1).Text
                                    results = dtchkinvoiceduplicateadd.Select("SaleTaxInvoiceNo='" & Invno & "'")
                                    If results.Length = 1 Then
                                        Exit For
                                    End If
                                End If
                            Next
                            If cmbPaymentTerms.SelectedValue = 3 Then
                                If results.Length <> 1 Then
                                    SaveSessionDetailInvoicewise()
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                                Else
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Al ready add Invoice")
                                End If
                            Else
                                SaveSessionDetailInvoicewise()
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                            End If
                        Else
                            SaveSessionDetailInvoicewise()
                        End If
                        If dgpaymentDetailInvoicewise.Items.Count > 0 Then
                            SaveSessionMainGrd()
                        Else
                        End If
                    End If
                End If
            End If
            Dim TOL As Decimal = 0
            Dim LastTol As Decimal = 0
            LastTol = lbltotalAmount.Text
            TOL = txtTotalPayment.Text
            If Val(TOL) = Val(LastTol) Then
                btnUpadateInv.Visible = True
            Else
                btnUpadateInv.Visible = False
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
                .Columns.Add("SaleTaxInvoiceNo", GetType(String))
                '.Columns.Add("CostCenterId", GetType(String))
                '.Columns.Add("Cost", GetType(String))
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
        Dr("AccountCode") = txtAccountCode.Text
        Dr("AccountName") = txtAccountName.Text
        Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
        Dr("Type") = cmbType.SelectedItem.Text
        Dr("PaymentTermID") = cmbPaymentTerms.SelectedValue
        'Dr("CostCenterId") = lblCostCenterId.Text
        'Dr("Cost") = txtCostCenter.Text
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
            Dr("InitialAmount") = initialAmount
            Dr("Amount") = NetAmount
            Dr("RefNo") = txtRefNo.Text
        Else
            Dr("InitialAmount") = txtPaymentAmount.Text
            Dr("Amount") = txtPaymentAmount.Text
            Dr("RefNo") = txtRefNo.Text
        End If
        Dr("SaleTaxInvoiceNo") = 0
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
        txtDescriptionDetail.Text = ""
    End Sub
    Protected Sub btnUpadateInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpadateInv.Click
        Try
            If dgView.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One Detail required")
            Else
                Dim X As Integer = 0
                Dim txtAmount As TextBox
                Dim AlreadyPayment As Decimal = 0
                Dim TotalInvoiceAmount As Decimal = 0
                Dim POInvoiceMstID As Long
                Dim ChkStatus As CheckBox
                For X = 0 To dgpaymentDetailInvoicewise.Items.Count - 1
                    Dim cel21 As Decimal = 0
                    Dim cel22 As Decimal = 0
                    Dim cel10 As Decimal = 0
                    cel21 = (dgpaymentDetailInvoicewise.Items(X).Cells(21).Text)
                    cel22 = (dgpaymentDetailInvoicewise.Items(X).Cells(22).Text)
                    cel10 = (dgpaymentDetailInvoicewise.Items(X).Cells(10).Text)
                    ChkStatus = DirectCast(dgpaymentDetailInvoicewise.Items(X).FindControl("lblCheckdstatusForInvoiceInfo"), CheckBox)
                    POInvoiceMstID = dgpaymentDetailInvoicewise.Items(X).Cells(20).Text
                    AlreadyPayment = cel21
                    TotalInvoiceAmount = cel22
                    AlreadyPayment = AlreadyPayment + Val(cel10)
                    If ChkStatus.Checked = True Then
                        If POInvoiceMstID <> 0 Then
                            If AlreadyPayment = TotalInvoiceAmount Then
                                objtblBankMst.UpdateInvoicePaymentComplete(POInvoiceMstID, AlreadyPayment)
                            Else
                                objtblBankMst.UpdateInvoicePayment(POInvoiceMstID, AlreadyPayment)
                            End If
                        Else
                        End If
                    Else

                    End If
                Next
                If txtVoucherNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("VoucherNo Not Empty.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    saveData()
                    Response.Redirect("BankVoucherView.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub PDF()
        Try
            If tblBankMstID > 0 Then
                tblBankMstID = tblBankMstID
            Else
                tblBankMstID = objtblBankMst.GetID()
            End If
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim FileName As String
            If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                Report.Load(Server.MapPath("..\Reports/VoucherReceipt.rpt"))
                FileName = "Voucher"
            Else
                Report.Load(Server.MapPath("..\Reports/VoucherPayment.rpt"))

                FileName = "Voucher"
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, tblBankMstID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()
            udpbtnUpadateInv.Update()
            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
                Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                Response.End()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub saveData()
        With objtblBankMst
            If tblBankMstID > 0 Then
                .tblBankMstID = tblBankMstID
            Else
                .tblBankMstID = 0
            End If
            .CompanyId = "0001"
            .VoucherNo = txtVoucherNo.Text
            If chkshowCalander.Checked = True Then
                .VoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                If tblBankMstID > 0 Then
                    .OriginalVoucherDate = objgeneralCode.GetDate(txtOriginaldate.Text)
                Else
                    .OriginalVoucherDate = objgeneralCode.GetDate(txtVoucherdate.Text)
                End If
            Else
                .VoucherDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
                If tblBankMstID > 0 Then
                    .OriginalVoucherDate = objgeneralCode.GetDate(txtOriginaldate.Text)
                Else
                    .OriginalVoucherDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
                End If
            End If
            If cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                .BookAccount = cmbBookAccount.SelectedValue
            Else
                .BookAccount = cmbBookAccount.SelectedValue
            End If
            If txtdescription.Text = "" Then
                .Description = "N/A"
            Else
                .Description = txtdescription.Text
            End If
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
            Dim TotalPaidAmount As Decimal = 0
            TotalPaidAmount = lbltotalAmount.Text
            .TotalAmount = TotalPaidAmount
            .InvoiceType = 0
            .VNo = txtVno.Text
            .VoucherTypeID = cmbVoucherType.SelectedValue
            If chkshowCalander.Checked = True Then
                .ChkDate = True
            Else
                .ChkDate = False
            End If
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
                'If AccountCode = dgView.Items(x).Cells(3).Text = "" Then
                '    .AccountCode = 0
                'Else
                '    AccountCode = dgView.Items(x).Cells(3).Text
                'End If
                If AccountCode = "" Then
                    .AccountCode = 0
                Else
                    AccountCode = AccountCode
                End If
                .DescriptionEntry = dgView.Items(x).Cells(5).Text
                .ChequeNo = dgView.Items(x).Cells(1).Text
                .ChequeDate = dgView.Items(x).Cells(2).Text
                .Type = dgView.Items(x).Cells(6).Text
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
                .WHTaxPercentage = dgView.Items(x).Cells(15).Text
                .WHTaxAmountCr = dgView.Items(x).Cells(11).Text
                .GSTaxPercentage = dgView.Items(x).Cells(16).Text
                .GSTaxAmountCr = dgView.Items(x).Cells(12).Text
                Dim PaidAmount As Decimal = 0
                PaidAmount = (dgView.Items(x).Cells(10).Text)
                .Amount = PaidAmount
                .WHTaxAmountDB = dgView.Items(x).Cells(13).Text
                .GSTaxAmountDB = dgView.Items(x).Cells(14).Text
                .DOC_RefNo = dgView.Items(x).Cells(17).Text
                .PaymentTermID = dgView.Items(x).Cells(18).Text
                Dim INVAmount As Decimal = 0
                INVAmount = (dgView.Items(x).Cells(7).Text)
                .InitialAmount = INVAmount
                '.CostCenterId = dgView.Items(x).Cells(20).Text
                .SavetblBankDtl()
            End With
        Next
        Dim a As Integer
        For a = 0 To dgpaymentDetailInvoicewise.Items.Count - 1
            With ObjtblBankDtlDetail
                .tblBankDtlDetailID = dgpaymentDetailInvoicewise.Items(a).Cells(0).Text
                If tblBankMstID > 0 Then
                    .tblBankMstID = tblBankMstID
                Else
                    .tblBankMstID = objtblBankMst.GetID()
                End If
                .CompanyId = "0001"
                .VoucherNo = txtVoucherNo.Text
                .AccountCode = dgpaymentDetailInvoicewise.Items(a).Cells(3).Text
                .DescriptionEntry = dgpaymentDetailInvoicewise.Items(a).Cells(5).Text
                .ChequeNo = dgpaymentDetailInvoicewise.Items(a).Cells(1).Text
                .ChequeDate = dgpaymentDetailInvoicewise.Items(a).Cells(2).Text
                .Type = dgpaymentDetailInvoicewise.Items(a).Cells(6).Text
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
                .WHTaxPercentage = dgpaymentDetailInvoicewise.Items(a).Cells(15).Text
                .WHTaxAmountCr = dgpaymentDetailInvoicewise.Items(a).Cells(11).Text
                .GSTaxPercentage = dgpaymentDetailInvoicewise.Items(a).Cells(16).Text
                .GSTaxAmountCr = dgpaymentDetailInvoicewise.Items(a).Cells(12).Text
                Dim Cell10 As Decimal = 0
                Cell10 = (dgpaymentDetailInvoicewise.Items(a).Cells(10).Text)
                .Amount = Cell10
                .WHTaxAmountDB = dgpaymentDetailInvoicewise.Items(a).Cells(13).Text
                .GSTaxAmountDB = dgpaymentDetailInvoicewise.Items(a).Cells(14).Text
                .DOC_RefNo = dgpaymentDetailInvoicewise.Items(a).Cells(17).Text
                .PaymentTermID = dgpaymentDetailInvoicewise.Items(a).Cells(18).Text
                Dim Cell7 As Decimal = 0
                Cell7 = (dgpaymentDetailInvoicewise.Items(a).Cells(7).Text)
                .InitialAmount = Cell7
                .InvNo = dgpaymentDetailInvoicewise.Items(a).Cells(19).Text
                '.CostCenterId = dgpaymentDetailInvoicewise.Items(a).Cells(24).Text
                .SavetblBankDtlDetail()
            End With
        Next
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                lbldrcrM.Text = "(Dr)"
                lbldrcrD.Text = "(Cr)"
            ElseIf cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                lbldrcrM.Text = "(Cr)"
                lbldrcrD.Text = "(Dr)"
            Else
                lbldrcrM.Text = ""
                lbldrcrD.Text = ""
            End If
            Dim VoucherNo As String
            Dim VoucherType As String
            Dim Voucherdate As Date
            If chkshowCalander.Checked = True Then
                Voucherdate = txtVoucherdate.Text
            Else
                Voucherdate = txtVoucherdate2.Text
            End If
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
            Dim LastVoucherNo As String = objtblBankMst.GetLastVoucherNo(Month, yearP)
            Dim PreviousMonth As Integer
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "00001"
            Else
                PreviousMonth = LastVoucherNo.Substring(7, 2)
                LastCode = LastVoucherNo.Substring(10, 5)
                If PreviousMonth = Month Then
                    If LastCode < 10 Then
                        If LastCode = 9 Then
                            LastCode = "000" & Val(LastCode + 1)
                        Else
                            LastCode = "0000" & Val(LastCode + 1)
                        End If
                    ElseIf LastCode < 100 Or LastCode >= 10 Then
                        If LastCode = 99 Then
                            LastCode = "00" & Val(LastCode + 1)
                        Else
                            LastCode = "000" & Val(LastCode + 1)
                        End If
                    ElseIf LastCode < 1000 Or LastCode >= 100 Then
                        If LastCode = 999 Then
                            LastCode = "0" & Val(LastCode + 1)
                        Else
                            LastCode = "00" & Val(LastCode + 1)
                        End If
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
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtVoucherdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate.TextChanged
        Try
            VoucherNoGenerateOnLoad()
        Catch ex As Exception
        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objtblBankMst.Edit(tblBankMstID)
            Dim A As Boolean
            A = dt.Rows(0)("ChkDate")
            If A = True Then
                chkshowCalander.Checked = False
                txtVoucherdate.Text = dt.Rows(0)("VoucherDate")
                txtVoucherdate2.Visible = False
                txtVoucherdate.Visible = True
                ImageButton1.Visible = True
            Else
                chkshowCalander.Checked = False
                txtVoucherdate2.Text = dt.Rows(0)("VoucherDate")
                txtVoucherdate2.Visible = True
                txtVoucherdate.Visible = False
                ImageButton1.Visible = False
            End If
            txtOriginaldate.Text = dt.Rows(0)("VoucherDate")
            txtVoucherNo.Text = dt.Rows(0)("VoucherNo")
            txtVno.Text = dt.Rows(0)("VNo")
            BindPaymentTerms()
            txtdescription.Text = dt.Rows(0)("Description")
            Dim VoucherType As String = dt.Rows(0)("VoucherType")
            If VoucherType = "R" Then
                pnlbookaccountMst.Visible = False
                pnlAccountCodedtl.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = False
                pnlbookaccountMstSearch.Visible = False
                Dim BookAccount As String = dt.Rows(0)("BookAccount")
                Dim BookAccountName As String = objtblBankMst.GetBookAccountNameMaster(BookAccount)
                cmbVoucherType.SelectedItem.Text = "Receipt Voucher"
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                cmbType.SelectedItem.Text = "C"
                cmbType.Enabled = False
            Else
                pnlbookaccountMst.Visible = False
                pnlAccountCodedtlSearchAuto.Visible = False
                cmbBookAccount.SelectedValue = dt.Rows(0)("BookAccount")
                cmbVoucherType.SelectedItem.Text = "Payment Voucher"
                cmbType.SelectedItem.Text = "D"
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
                    .Columns.Add("PaymentTermID", GetType(String))
                    .Columns.Add("RefNo", GetType(String))
                    .Columns.Add("SaleTaxInvoiceNo", GetType(String))
                    '.Columns.Add("CostCenterId", GetType(String))
                    '.Columns.Add("Cost", GetType(String))
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
                Dr("PaymentTermID") = dt.Rows(x)("PaymentTermID")
                Dr("RefNo") = dt.Rows(x)("DOC_RefNo")
                Dr("SaleTaxInvoiceNo") = dt.Rows(x)("DOC_RefNo")
                'Dr("CostCenterId") = dt.Rows(x)("CostCenterId")
                'Dr("Cost") = dt.Rows(x)("Cost")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbVoucherType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVoucherType.SelectedIndexChanged
        Try
            If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                lbldrcrM.Text = "(Dr)"
                lbldrcrD.Text = "(Cr)"
            ElseIf cmbVoucherType.SelectedItem.Text = "Payment Voucher" Then
                lbldrcrM.Text = "(Cr)"
                lbldrcrD.Text = "(Dr)"
            Else
                lbldrcrM.Text = ""
                lbldrcrD.Text = ""
            End If
            VoucherNoGenerateOnLoad()
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
                                Try
                                    If txtAccountName.Text = "" Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Party Name.")
                                    ElseIf txtAccountName.Text <> "" Then
                                        dtAC = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                                        If dtAC.Rows.Count > 0 Then
                                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                                        Else
                                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                                        End If
                                        If cmbBookAccount.SelectedValue = dtAC.Rows(0)("AccountCode") Then
                                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Already Selected")
                                            txtAccountName.Text = ""
                                            txtAccountCode.Text = ""
                                            txtAccountLevel.Text = ""
                                            txtAccountLevel.BackColor = Drawing.Color.White
                                        Else
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
                                            dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
                                            dtJVamountt = objtblBankMst.GetJVDataForLedger(txtAccountCode.Text)
                                            dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
                                            dtContamount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)
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
                                    End If
                                    If txtLedgerBalance.Text >= 0 Then
                                        lblLedgerBalanceCRDR.Text = "Dr"
                                    Else
                                        lblLedgerBalanceCRDR.Text = "Cr"
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            If dtDetail.Rows(dtrowNo)("PaymentTermID") = 3 Then
            Else
                BindPaymentTerms()
                lbldetail.Text = dtDetail.Rows(dtrowNo)("tblBankDtlID")
                txtchequeNo.Text = dtDetail.Rows(dtrowNo)("ChequeNo")
                txtchequedate.Text = dtDetail.Rows(dtrowNo)("ChequeDate")
                txtDescriptionDetail.Text = dtDetail.Rows(dtrowNo)("DescriptionEntry")
                cmbType.SelectedItem.Text = dtDetail.Rows(dtrowNo)("Type")
                lblCostCenterId.Text = dtDetail.Rows(dtrowNo)("CostCenterId")
                txtCostCenter.Text = dtDetail.Rows(dtrowNo)("Cost")
                UpdatePanel1.Update()
                If cmbVoucherType.SelectedItem.Text = "Receipt Voucher" Then
                    pnlAccountCodedtl.Visible = True
                    pnlAccountCodedtlSearchAuto.Visible = False
                    cmbAccountCode.SelectedValue = dtDetail.Rows(dtrowNo)("AccountCode")
                Else
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
                cmbPaymentTerms.SelectedValue = dtDetail.Rows(dtrowNo)("PaymentTermID")
                lblNetAmount.Visible = True
                txtPaymentAmount.Visible = True
                lblRefNo.Visible = True
                txtRefNo.Visible = True
                txtPaymentAmount.Text = dtDetail.Rows(dtrowNo)("Amount")
                txtRefNo.Text = dtDetail.Rows(dtrowNo)("RefNo")
            End If
        Catch ex As Exception
        End Try
    End Sub
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
    Protected Sub BtnCanelInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCanelInv.Click
        Try
            Response.Redirect("BankVoucherView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtTotalPayment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalPayment.TextChanged
        Try
            Dim a As Decimal
            a = txtTotalPayment.Text
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtShowMeINV_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMeINV.TextChanged
        Try
            If txtShowMeINV.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                BindInvoiceGrid()
            ElseIf txtShowMeINV.Text <> "" Then
                BindInvoiceGridONAutoSearch()
            End If
            Session("Supplier") = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionDetailInvoicewise()
        Dim dtDetaildtDetailInv As New DataTable
        If (Not CType(Session("dtDetailInv"), DataTable) Is Nothing) Then
            dtDetaildtDetailInv = Session("dtDetailInv")
        Else
            dtDetaildtDetailInv = New DataTable
            With dtDetaildtDetailInv
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
                .Columns.Add("SaleTaxInvoiceNo", GetType(String))
                .Columns.Add("POInvoiceMstID", GetType(String))
                .Columns.Add("AlreadyPayment", GetType(String))
                .Columns.Add("TotalInvoiceAmount", GetType(String))
                '.Columns.Add("CostCenterId", GetType(String))
                '.Columns.Add("Cost", GetType(String))
            End With
        End If
        Dim aaa As Decimal = 0
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
        If cmbPaymentTerms.SelectedValue <> 3 Then
            Dr = dtDetaildtDetailInv.NewRow()

            If lbldetail.Text = "" Then
                Dr("tblBankDtlID") = 0
            Else
                Dr("tblBankDtlID") = lbldetail.Text
            End If
            Dr("ChequeNo") = txtchequeNo.Text
            Dr("ChequeDate") = objgeneralCode.GetDate(txtchequedate.Text)
            Dr("AccountCode") = txtAccountCode.Text
            Dr("AccountName") = txtAccountName.Text
            Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
            Dr("Type") = cmbType.SelectedItem.Text
            Dr("PaymentTermID") = cmbPaymentTerms.SelectedValue
            Dr("WHTaxAmount") = WHTaxAmount
            Dr("GSTaxAmount") = GSTaxAmount
            Dr("WHTaxPercentage") = WHTaxPercentage
            Dr("GSTaxPercentage") = GSTaxPercentage
            Dr("WHTaxAmountCr") = -WHTaxAmount
            Dr("GSTaxAmountCr") = -GSTaxAmount
            Dr("WHTaxAmountDB") = WHTaxAmount
            Dr("GSTaxAmountDB") = GSTaxAmount
            aaa = txtPaymentAmount.Text
            Dr("InitialAmount") = Convert.ToDecimal(aaa).ToString("#,##0.00")
            Dr("Amount") = Convert.ToDecimal(aaa).ToString("#,##0.00")
            Dr("RefNo") = txtRefNo.Text
            Dr("SaleTaxInvoiceNo") = txtRefNo.Text
            Dr("POInvoiceMstID") = 0
            Dr("AlreadyPayment") = 0
            Dr("TotalInvoiceAmount") = 0
            'Dr("CostCenterId") = lblCostCenterId.Text
            'Dr("Cost") = txtCostCenter.Text
            dtDetaildtDetailInv.Rows.Add(Dr)
        Else
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
                If ChkStatus.Checked = True Then
                    Dr = dtDetaildtDetailInv.NewRow()
                    If lbldetail.Text = "" Then
                        Dr("tblBankDtlID") = 0
                    Else
                        Dr("tblBankDtlID") = lbldetail.Text
                    End If
                    Dr("ChequeNo") = txtchequeNo.Text
                    Dr("ChequeDate") = objgeneralCode.GetDate(txtchequedate.Text)
                    Dr("AccountCode") = txtAccountCode.Text
                    Dr("AccountName") = txtAccountName.Text
                    Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
                    Dr("Type") = cmbType.SelectedItem.Text
                    Dr("PaymentTermID") = cmbPaymentTerms.SelectedValue
                    initialAmount = Val(dgInvoice.Items(x).Cells(3).Text)
                    WHTaxAmount = Val(txtWHTaxAmount.Text)
                    GSTaxAmount = Val(txtGSTaxAmount.Text)
                    WHTaxAmountCr = Val(txtWHTaxAmount.Text)
                    GSTaxAmountCr = Val(txtGSTaxAmount.Text)
                    WHTaxAmountDB = Val(txtWHTaxAmount.Text)
                    GSTaxAmountDB = Val(txtGSTaxAmount.Text)
                    WHTaxPercentage = Val(txtWHTaxPercentage.Text)
                    GSTaxPercentage = Val(txtGSTaxPercentage.Text)
                    NetAmount = Val(txtAmount.Text)
                    lblCheckdstatus.Text = 1
                    Dr("WHTaxAmount") = WHTaxAmount
                    Dr("GSTaxAmount") = GSTaxAmount
                    Dr("WHTaxPercentage") = WHTaxPercentage
                    Dr("GSTaxPercentage") = GSTaxPercentage
                    Dr("WHTaxAmountCr") = -WHTaxAmount
                    Dr("GSTaxAmountCr") = -GSTaxAmount
                    Dr("WHTaxAmountDB") = WHTaxAmount
                    Dr("GSTaxAmountDB") = GSTaxAmount
                    Dr("InitialAmount") = Convert.ToDecimal(initialAmount).ToString("#,##0.00")
                    Dr("Amount") = Convert.ToDecimal(NetAmount).ToString("#,##0.00")
                    Dr("RefNo") = txtRefNo.Text
                    Dr("SaleTaxInvoiceNo") = dgInvoice.Items(x).Cells(1).Text
                    Dr("POInvoiceMstID") = dgInvoice.Items(x).Cells(0).Text
                    Dr("AlreadyPayment") = dgInvoice.Items(x).Cells(4).Text
                    Dr("TotalInvoiceAmount") = dgInvoice.Items(x).Cells(3).Text
                    'Dr("CostCenterId") = lblCostCenterId.Text
                    'Dr("Cost") = txtCostCenter.Text
                    dtDetaildtDetailInv.Rows.Add(Dr)
                Else
                End If
            Next
        End If
        Session("dtDetailInv") = dtDetaildtDetailInv
        BindGridDetailInfo()
    End Sub
    Private Sub BindGridDetailInfo()
        Try
            lbltotalAmount.Text = ""
            Dim objDatatble2 As DataTable
            objDatatble2 = Session("dtDetailInv")
            If objDatatble2.Rows.Count > 0 Then
                dgpaymentDetailInvoicewise.Visible = True
                dgpaymentDetailInvoicewise.RecordCount = objDatatble2.Rows.Count
                dgpaymentDetailInvoicewise.DataSource = objDatatble2
                dgpaymentDetailInvoicewise.DataBind()
                lblTotalHding.Visible = True
                lbltotalAmount.Visible = True
            Else
                dgpaymentDetailInvoicewise.Visible = False
                lblTotalHding.Visible = False
                lbltotalAmount.Visible = False
            End If
            Dim TotalWHTaxAmt As Decimal = 0
            Dim TotalSTaxAmt As Decimal = 0
            Dim x As Integer
            Dim CheckdstatusForInvoiceInfo As New CheckBox
            Dim ChkStatus As New CheckBox
            For x = 0 To dgpaymentDetailInvoicewise.Items.Count - 1
                Dim cel8 As Decimal = 0
                Dim cel9 As Decimal = 0
                Dim cel10 As Decimal = 0
                cel8 = (dgpaymentDetailInvoicewise.Items(x).Cells(8).Text)
                cel9 = (dgpaymentDetailInvoicewise.Items(x).Cells(9).Text)
                cel10 = (dgpaymentDetailInvoicewise.Items(x).Cells(10).Text)
                CheckdstatusForInvoiceInfo = DirectCast(dgpaymentDetailInvoicewise.Items(x).FindControl("lblCheckdstatusForInvoiceInfo"), CheckBox)
                lbltotalAmount.Text = Val(lbltotalAmount.Text) + Val(cel10)
                TotalWHTaxAmt = TotalWHTaxAmt + Val(cel8)
                TotalSTaxAmt = TotalSTaxAmt + Val(cel9)
                Dim datechk As Date = dgpaymentDetailInvoicewise.Items(x).Cells(2).Text
                dgpaymentDetailInvoicewise.Items(x).Cells(2).Text = datechk
                CheckdstatusForInvoiceInfo.Checked = True
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionMainGrd()
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
                .Columns.Add("SaleTaxInvoiceNo", GetType(String))
                '.Columns.Add("CostCenterId", GetType(String))
                '.Columns.Add("Cost", GetType(String))
            End With
        End If

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
        Dim CheckdstatusForInvoiceInfo As CheckBox
        For x = 0 To dgpaymentDetailInvoicewise.Items.Count - 1
            Dr = dtDetail.NewRow()
            If lbldetail.Text = "" Then
                Dr("tblBankDtlID") = 0
            Else
                Dr("tblBankDtlID") = lbldetail.Text
            End If
            Dr("ChequeNo") = txtchequeNo.Text
            Dr("ChequeDate") = objgeneralCode.GetDate(txtchequedate.Text)
            Dr("AccountCode") = txtAccountCode.Text
            Dr("AccountName") = txtAccountName.Text
            Dr("DescriptionEntry") = txtDescriptionDetail.Text.ToUpper
            Dr("Type") = cmbType.SelectedItem.Text
            Dr("PaymentTermID") = cmbPaymentTerms.SelectedValue
            'Dr("CostCenterId") = lblCostCenterId.Text
            'Dr("Cost") = txtCostCenter.Text
            CheckdstatusForInvoiceInfo = DirectCast(dgpaymentDetailInvoicewise.Items(x).FindControl("lblCheckdstatusForInvoiceInfo"), CheckBox)
            If CheckdstatusForInvoiceInfo.Checked = True Then
                Dim cel7 As Decimal = 0
                Dim cel8 As Decimal = 0
                Dim cel9 As Decimal = 0
                Dim cel10 As Decimal = 0
                Dim cel11 As Decimal = 0
                Dim cel12 As Decimal = 0
                Dim cel13 As Decimal = 0
                Dim cel14 As Decimal = 0
                Dim cel15 As Decimal = 0
                Dim cel16 As Decimal = 0
                cel7 = (dgpaymentDetailInvoicewise.Items(x).Cells(7).Text)
                cel8 = (dgpaymentDetailInvoicewise.Items(x).Cells(8).Text)
                cel9 = (dgpaymentDetailInvoicewise.Items(x).Cells(9).Text)
                cel10 = (dgpaymentDetailInvoicewise.Items(x).Cells(10).Text)
                cel11 = (dgpaymentDetailInvoicewise.Items(x).Cells(11).Text)
                cel12 = (dgpaymentDetailInvoicewise.Items(x).Cells(12).Text)
                cel13 = (dgpaymentDetailInvoicewise.Items(x).Cells(13).Text)
                cel14 = (dgpaymentDetailInvoicewise.Items(x).Cells(14).Text)
                cel15 = (dgpaymentDetailInvoicewise.Items(x).Cells(15).Text)
                cel16 = (dgpaymentDetailInvoicewise.Items(x).Cells(16).Text)
                initialAmount = initialAmount + Val(cel7)
                WHTaxAmount = WHTaxAmount + Val(cel8)
                GSTaxAmount = GSTaxAmount + Val(cel9)
                WHTaxAmountCr = WHTaxAmountCr + Val(cel11)
                GSTaxAmountCr = GSTaxAmountCr + Val(cel12)
                WHTaxAmountDB = WHTaxAmountDB + Val(cel13)
                GSTaxAmountDB = GSTaxAmountDB + Val(cel14)
                WHTaxPercentage = WHTaxPercentage + Val(cel15)
                GSTaxPercentage = GSTaxPercentage + Val(cel16)
                NetAmount = NetAmount + Val(cel10)

                Dr("WHTaxAmount") = WHTaxAmount
                Dr("GSTaxAmount") = GSTaxAmount
                Dr("WHTaxPercentage") = WHTaxPercentage
                Dr("GSTaxPercentage") = GSTaxPercentage
                Dr("WHTaxAmountCr") = -WHTaxAmount
                Dr("GSTaxAmountCr") = -GSTaxAmount
                Dr("WHTaxAmountDB") = WHTaxAmount
                Dr("GSTaxAmountDB") = GSTaxAmount
                Dr("InitialAmount") = Convert.ToDecimal(initialAmount).ToString("#,##0.00")
                Dr("Amount") = Convert.ToDecimal(NetAmount).ToString("#,##0.00")
                Dr("RefNo") = txtRefNo.Text
                Dr("SaleTaxInvoiceNo") = 0
                dtDetail.Rows.Add(Dr)
                Session("dtDetail") = dtDetail
            Else
            End If
        Next

        BindGridMainGrd()
    End Sub
    Private Sub BindGridMainGrd()
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
            Dim Cell10 As Decimal = 0
            For x = 0 To dgView.Items.Count - 1
                Cell10 = (dgView.Items(x).Cells(10).Text)
                lbltotalAmount.Text = Val(lbltotalAmount.Text) + Val(Cell10)
                TotalWHTaxAmt = TotalWHTaxAmt + Val(dgView.Items(x).Cells(8).Text)
                TotalSTaxAmt = TotalSTaxAmt + Val(dgView.Items(x).Cells(9).Text)
                Dim datechk As Date = dgView.Items(x).Cells(2).Text
                dgView.Items(x).Cells(2).Text = datechk
            Next
            txtTotalWHTaxAmount.Text = Math.Round(TotalWHTaxAmt, 2)
            txtTotalSTaxAmount.Text = Math.Round(TotalSTaxAmt, 2)
            lbltotalAmount.Text = Convert.ToDecimal(lbltotalAmount.Text).ToString("#,##0.00")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub LinkToShowPageOFAllInvoiceDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ScriptManager.RegisterClientScriptBlock(Me.upGetArticle, Me.upGetArticle.GetType(), "New ClientScript", "window.open('DetailPopup.aspx', 'newwindow','left=70, top=120, height=500, width=800,  status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbBookAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
            dtbankamount = objtblBankMst.GetBPVData(cmbBookAccount.SelectedValue)
            dtJVamount = objtblBankMst.GetJVData(cmbBookAccount.SelectedValue)
            dtCVamount = objtblBankMst.GetCVData(cmbBookAccount.SelectedValue)
            dtCONTamount = objtblBankMst.GetCCONTRData(cmbBookAccount.SelectedValue)
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
            Dim dtbankamountt As DataTable
            Dim dtCVamountt As DataTable
            Dim dtContramount As DataTable
            Dim DebitPvvd As Decimal = 0
            Dim CreditPvvd As Decimal = 0
            Dim CreditCVvd As Decimal = 0
            Dim DebitCVvd As Decimal = 0
            Dim CreditConVvd As Decimal = 0
            Dim DebitConVvd As Decimal = 0
            dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
            dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
            dtContramount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)
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
            txtBankbalance.Text = Convert.ToDecimal(TotalBankBalance).ToString("#,##0.00")
            If txtBankbalance.Text >= 0 Then
                lblCurrBalanceCRDR.Text = "Dr"
            Else
                lblCurrBalanceCRDR.Text = "Cr"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub chkshowCalander_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkshowCalander.CheckedChanged
        Try
            If chkshowCalander.Checked = True Then
                txtVoucherdate2.Visible = False
                txtVoucherdate.Visible = True
                ImageButton1.Visible = True
            Else
                txtVoucherdate2.Visible = True
                txtVoucherdate.Visible = False
                ImageButton1.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtVoucherdate2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate2.TextChanged
        Try
            VoucherNoGenerateOnLoad()
        Catch ex As Exception
        End Try
    End Sub
End Class



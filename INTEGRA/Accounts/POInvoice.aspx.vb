Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Drawing.Color
Public Class POInvoice
    Inherits System.Web.UI.Page

    Dim objPOInvoiceMaster As New POInvoiceMaster
    Dim objPOInvoiceDetail As New POInvoiceDetail
    Dim x As Integer
    Dim objgeneralCode As New GeneralCode
    Dim dtDetail, dtExpenses, dtview As DataTable
    Dim Dr As DataRow
    Dim POInvoiceMasterID, AccountPayablePartyID As Long
    Dim dtAC, dtPoDetail As DataTable
    Dim AccountCode As String
    Dim objPOInvoiceAdjDetail As New POInvoiceAdjDetail
    Dim objSupplierLedger As New SupplierLedger
    Dim objPOInvoiceMst As New POInvoiceMst
    Dim objPOInvoiceDtl As New POInvoiceDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POInvoiceMasterID = Request.QueryString("lPOInvoiceMasterID")
        AccountPayablePartyID = Request.QueryString("AccountPayablePartyID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            RBBtn.SelectedValue = 0
            pnlWithGST.Visible = True
            BindParty()
            If POInvoiceMasterID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                txtCreationDate.Text = Date.Today
                txtVoucherdate2.Text = Date.Today
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
                TransactionNoGenerateOnLoad()
            End If
        End If
        PageHeader("PURCHASE VOUCHER ENTRY FORM")
    End Sub
    'Protected Sub TXTPONo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPONo.TextChanged
    '    Try
    '        Dim dt As DataTable
    '        dt = objPOInvoiceDtl.GetPOID(TXTPONo.Text)
    '        lblPONo.Text = dt.Rows(0)("POID")


    '        pnlJunaidinfo.Visible = True
    '        Dim dtduplicateadd As New DataTable
    '        dtduplicateadd = Session("dtDetail")
    '        Dim results As DataRow()
    '        If dtduplicateadd Is Nothing Then
    '            lblPartyid.Text = cmbPartyname.SelectedValue
    '            SaveSessionInvoicePONOWise()
    '            BindGrid()
    '            cmbProductType.Enabled = False
    '            cmbproduct.Enabled = False
    '            btnSave.Visible = True
    '            btnCancel.Visible = True
    '            txtWeight.Enabled = False
    '            txtrate.Enabled = False
    '            txtdiscPercentage.Enabled = False
    '            txtSalesTaxPercentage.Enabled = False
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
    '        Else
    '            results = dtduplicateadd.Select("PONo='" & TXTPONo.Text & "'")
    '            If results.Length <> 1 Then
    '                lblPartyid.Text = cmbPartyname.SelectedValue
    '                SaveSessionInvoicePONOWise()
    '                BindGrid()
    '                cmbProductType.Enabled = False
    '                cmbproduct.Enabled = False
    '                btnSave.Visible = True
    '                btnCancel.Visible = True
    '                txtWeight.Enabled = False
    '                txtrate.Enabled = False
    '                txtdiscPercentage.Enabled = False
    '                txtSalesTaxPercentage.Enabled = False
    '                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
    '            Else
    '                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already Add DC.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Sub SaveSessionInvoicePONOWise()
    '    If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
    '        dtDetail = Session("dtDetail")
    '    Else
    '        dtDetail = New DataTable
    '        With dtDetail
    '            .Columns.Add("POInvoiceDetailID", GetType(Long))
    '            .Columns.Add("ItemId", GetType(String))
    '            .Columns.Add("ItemCode", GetType(String))
    '            .Columns.Add("ItemName", GetType(String))
    '            .Columns.Add("TotalQty", GetType(String))
    '            .Columns.Add("Weight", GetType(String))
    '            .Columns.Add("Rate", GetType(String))
    '            .Columns.Add("GrossAmount", GetType(String))
    '            .Columns.Add("DiscPercent", GetType(String))
    '            .Columns.Add("DiscAmount", GetType(String))
    '            .Columns.Add("ValExcloudSalesTax", GetType(String))
    '            .Columns.Add("SalesTaxPercentage", GetType(String))
    '            .Columns.Add("SalesTaxAmount", GetType(String))
    '            .Columns.Add("NetAmount", GetType(String))
    '            .Columns.Add("PODetailID", GetType(Long))
    '            .Columns.Add("PreInvoiceQty", GetType(String))
    '            .Columns.Add("PONO", GetType(String))
    '            .Columns.Add("Balance", GetType(String))
    '            .Columns.Add("DCDate", GetType(String))
    '            .Columns.Add("INVFrom", GetType(String))
    '        End With
    '    End If
    '    If lblPartyFrom.Text = "PORECEIVE" Then
    '        dtPoDetail = objPOInvoiceAdjDetail.GetPodetailNewNew(lblPONo.Text, cmbPartyname.SelectedValue)
    '    End If
    '    Dim a As Integer
    '    For a = 0 To dtPoDetail.Rows.Count - 1
    '        Dr = dtDetail.NewRow()
    '        Dr("PreInvoiceQty") = Math.Round(Val(dtPoDetail.Rows(a)("PreInvoiceQty").ToString), 0)
    '        Dr("POInvoiceDetailID") = dtPoDetail.Rows(a)("POInvoiceDetailID").ToString
    '        Dr("ItemId") = dtPoDetail.Rows(a)("IMSItemId").ToString
    '        Dr("ItemCode") = dtPoDetail.Rows(a)("ItemCodee").ToString
    '        Dr("ItemName") = dtPoDetail.Rows(a)("ItemName").ToString
    '        Dr("TotalQty") = Math.Round(Val(dtPoDetail.Rows(a)("TotalQty").ToString), 0)
    '        Dr("Weight") = dtPoDetail.Rows(a)("Weight").ToString
    '        Dr("Rate") = dtPoDetail.Rows(a)("Rate").ToString
    '        Dr("GrossAmount") = dtPoDetail.Rows(a)("GrossAmount").ToString
    '        Dr("DiscPercent") = dtPoDetail.Rows(a)("DiscPercent").ToString
    '        Dr("DiscAmount") = dtPoDetail.Rows(a)("DiscAmount").ToString
    '        Dr("ValExcloudSalesTax") = dtPoDetail.Rows(a)("ValExcloudSalesTax").ToString
    '        If txtSalesTaxP.Text = "" Then
    '            Dr("SalesTaxPercentage") = 0
    '        Else
    '            Dr("SalesTaxPercentage") = txtSalesTaxP.Text
    '        End If
    '        If txtSalesTaxP.Text = "" Then
    '            Dr("SalesTaxAmount") = 0
    '        Else
    '            Dr("SalesTaxAmount") = Math.Round(Val(dtPoDetail.Rows(a)("NetAmount").ToString) * Val(txtSalesTaxP.Text) / 100, 0)
    '        End If
    '        Dr("NetAmount") = Math.Round(Val(dtPoDetail.Rows(a)("NetAmount").ToString), 0)
    '        Dr("PODetailID") = dtPoDetail.Rows(a)("PODetailID").ToString
    '        Dr("PONO") = dtPoDetail.Rows(a)("PONO").ToString
    '        Dr("Balance") = Math.Round(Val(dtPoDetail.Rows(a)("RecvQuantity").ToString) - Val(dtPoDetail.Rows(a)("PreInvoiceQty").ToString), 0)
    '        Dr("DCDate") = dtPoDetail.Rows(a)("DCDate").ToString
    '        Dr("INVFrom") = lblPartyFrom.Text
    '        dtDetail.Rows.Add(Dr)
    '    Next
    '    Session("dtDetail") = dtDetail
    'End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub TransactionNoGenerateOnLoad()
        Try
            Dim TransactionNo As String = 0
            Dim LastTransactionNo As String = objPOInvoiceMaster.GetLastTransactionNo()

            If LastTransactionNo = "" Then
                LastTransactionNo = "0000001"
            Else
                If LastTransactionNo < 10 Then
                    LastTransactionNo = "000000" & Val(LastTransactionNo + 1)
                ElseIf LastTransactionNo < 100 Or LastTransactionNo >= 10 Then
                    LastTransactionNo = "00000" & Val(LastTransactionNo + 1)
                ElseIf LastTransactionNo < 1000 Or LastTransactionNo >= 100 Then
                    LastTransactionNo = "0000" & Val(LastTransactionNo + 1)
                ElseIf LastTransactionNo < 10000 Or LastTransactionNo >= 1000 Then
                    LastTransactionNo = "000" & Val(LastTransactionNo + 1)
                ElseIf LastTransactionNo < 100000 Or LastTransactionNo >= 10000 Then
                    LastTransactionNo = "00" & Val(LastTransactionNo + 1)
                ElseIf LastTransactionNo < 1000000 Or LastTransactionNo >= 100000 Then
                    LastTransactionNo = "0" & Val(LastTransactionNo + 1)
                Else
                    LastTransactionNo = Val(LastTransactionNo + 1)
                End If
            End If
            txtTransactionNo.Text = LastTransactionNo
        Catch ex As Exception
        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date
            If chkshowCalander.Checked = True Then
                Voucherdate = txtCreationDate.Text
            Else
                Voucherdate = txtVoucherdate2.Text
            End If
            Dim month As String = Voucherdate.Month
            Dim year As String = Voucherdate.Year
            Dim year1 As String = Voucherdate.Year
            Dim year2 As String = Voucherdate.Year
            Dim yearp As String = Voucherdate.Year
            Dim YearCode As String
            year1 = year.Substring(2, 2)
            If month > 6 Then
                year2 = year1 + 1
                YearCode = year1 & year2
            Else
                year2 = year1 - 1
                YearCode = year2 & year1
            End If
            Dim LastVoucherNo As String = objPOInvoiceMaster.GetLastVoucherNo(yearp)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0000001"
            Else
                LastCode = LastVoucherNo.Substring(8, 7)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00000" & Val(LastCode + 1)
                    Else
                        LastCode = "000000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0000" & Val(LastCode + 1)
                    Else
                        LastCode = "00000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "000" & Val(LastCode + 1)
                    Else
                        LastCode = "0000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100000 Or LastCode = 10000 Then
                    If LastCode = 99999 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000000 Or LastCode = 100000 Then
                    If LastCode = 999999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "PV" & "/" & YearCode & "/" & LastCode
            txtVoucherNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductName(ByVal ItemCode As String)
        Dim dt As DataTable
        dt = objPOInvoiceMaster.GetProductName(ItemCode)
        cmbproduct.DataSource = dt
        cmbproduct.DataTextField = "ItemName"
        cmbproduct.DataValueField = "ItemID"
        cmbproduct.DataBind()
        cmbproduct.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindParty()
        Try
            objPOInvoiceAdjDetail.TruncateTempINVPartiesTable()
            objPOInvoiceAdjDetail.InsertPORecvParty() '---Insert PORECV
            Dim dt As DataTable
            dt = objPOInvoiceAdjDetail.BindSupplierForInvoiceFromPOReceiveNew()
            cmbPartyname.DataSource = dt
            cmbPartyname.DataTextField = "SupplierName"
            cmbPartyname.DataValueField = "SupplierID"
            cmbPartyname.DataBind()
            cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPartyname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPartyname.SelectedIndexChanged
        Try
            Dim dtPartyFrom As DataTable
            dtPartyFrom = objPOInvoiceAdjDetail.GetPartyFrom(cmbPartyname.SelectedValue)
            If dtPartyFrom.Rows.Count > 0 Then
                lblPartyFrom.Text = dtPartyFrom.Rows(0)("Type").ToString
            Else
            End If
            BindDCNO()
            lblPartyid.Text = cmbPartyname.SelectedValue
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDCNO()
        Dim dt As DataTable
        If lblPartyFrom.Text = "PORECEIVE" Then
            dt = objPOInvoiceAdjDetail.BindDCNOForInvoiceFromPOReceive(cmbPartyname.SelectedValue)
        End If
        cmbDCNO.DataSource = dt
        cmbDCNO.DataTextField = "PartyDCNo"
        cmbDCNO.DataValueField = "PORecvMasterID"
        cmbDCNO.DataBind()
        cmbDCNO.Items.Insert(0, New ListItem("Select DCNO", "0"))
    End Sub
    Protected Sub cmbDCNO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            pnlJunaidinfo.Visible = True
            Dim dtduplicateadd As New DataTable
            dtduplicateadd = Session("dtDetail")
            Dim results As DataRow()
            If dtduplicateadd Is Nothing Then
                lblPartyid.Text = cmbPartyname.SelectedValue
                SaveSessionInvoice()
                BindGrid()
                cmbProductType.Enabled = False
                cmbproduct.Enabled = False
                btnSave.Visible = True
                btnCancel.Visible = True
                txtWeight.Enabled = False
                txtrate.Enabled = False
                txtdiscPercentage.Enabled = False
                txtSalesTaxPercentage.Enabled = False
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            Else
                results = dtduplicateadd.Select("PartyDCNo='" & cmbDCNO.SelectedItem.Text & "'")
                If results.Length <> 1 Then
                    lblPartyid.Text = cmbPartyname.SelectedValue
                    SaveSessionInvoice()
                    BindGrid()
                    cmbProductType.Enabled = False
                    cmbproduct.Enabled = False
                    btnSave.Visible = True
                    btnCancel.Visible = True
                    txtWeight.Enabled = False
                    txtrate.Enabled = False
                    txtdiscPercentage.Enabled = False
                    txtSalesTaxPercentage.Enabled = False
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already Add DC.")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionInvoice()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("POInvoiceDetailID", GetType(Long))
                .Columns.Add("ItemId", GetType(String))
                .Columns.Add("PartyDCNo", GetType(String))
                .Columns.Add("ItemCode", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("TotalQty", GetType(String))
                .Columns.Add("Weight", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("GrossAmount", GetType(String))
                .Columns.Add("DiscPercent", GetType(String))
                .Columns.Add("DiscAmount", GetType(String))
                .Columns.Add("ValExcloudSalesTax", GetType(String))
                .Columns.Add("SalesTaxPercentage", GetType(String))
                .Columns.Add("SalesTaxAmount", GetType(String))
                .Columns.Add("NetAmount", GetType(String))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("PORecvDetailTwoID", GetType(Long))
                .Columns.Add("PORecvMasterID", GetType(Long))
                .Columns.Add("PreInvoiceQty", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Balance", GetType(String))
                .Columns.Add("DCDate", GetType(String))
                .Columns.Add("INVFrom", GetType(String))
            End With
        End If

        If lblPartyFrom.Text = "PORECEIVE" Then
            dtPoDetail = objPOInvoiceAdjDetail.GetPodetailNew(cmbDCNO.SelectedValue, cmbPartyname.SelectedValue)
            ' ElseIf lblPartyFrom.Text = "YARNRECEIVE" Then
            ' dtPoDetail = objPOInvoiceAdjDetail.GetYarnRecvdetailNew(cmbDCNO.SelectedValue, cmbPartyname.SelectedValue)
            'Else
            '---get next
        End If


        Dim a As Integer
        For a = 0 To dtPoDetail.Rows.Count - 1
            Dr = dtDetail.NewRow()
            Dr("PreInvoiceQty") = Math.Round(Val(dtPoDetail.Rows(a)("PreInvoiceQty").ToString), 0)
            Dr("POInvoiceDetailID") = dtPoDetail.Rows(a)("POInvoiceDetailID").ToString
            Dr("PORecvMasterID") = dtPoDetail.Rows(a)("PORecvMasterID").ToString
            Dr("PartyDCNo") = dtPoDetail.Rows(a)("PartyDCNo").ToString
            Dr("PORecvDetailTwoID") = dtPoDetail.Rows(a)("PORecvDetailID").ToString
            Dr("ItemId") = dtPoDetail.Rows(a)("IMSItemId").ToString
            Dr("ItemCode") = dtPoDetail.Rows(a)("ItemCodee").ToString
            Dr("ItemName") = dtPoDetail.Rows(a)("ItemName").ToString
            Dr("TotalQty") = Math.Round(Val(dtPoDetail.Rows(a)("TotalQty").ToString), 0)
            Dr("Weight") = dtPoDetail.Rows(a)("Weight").ToString
            Dr("Rate") = dtPoDetail.Rows(a)("Rate").ToString
            Dr("GrossAmount") = dtPoDetail.Rows(a)("GrossAmount").ToString
            Dr("DiscPercent") = dtPoDetail.Rows(a)("DiscPercent").ToString
            Dr("DiscAmount") = dtPoDetail.Rows(a)("DiscAmount").ToString
            Dr("ValExcloudSalesTax") = dtPoDetail.Rows(a)("ValExcloudSalesTax").ToString
            If txtSalesTaxP.Text = "" Then
                Dr("SalesTaxPercentage") = 0
            Else
                Dr("SalesTaxPercentage") = txtSalesTaxP.Text  'dtPoDetail.Rows(a)("SalesTaxPercentage").ToString
            End If
            If txtSalesTaxP.Text = "" Then
                Dr("SalesTaxAmount") = 0
            Else
                Dr("SalesTaxAmount") = Math.Round(Val(dtPoDetail.Rows(a)("NetAmount").ToString) * Val(txtSalesTaxP.Text) / 100, 0)
            End If

            Dr("NetAmount") = Math.Round(Val(dtPoDetail.Rows(a)("NetAmount").ToString), 0)
            Dr("PODetailID") = dtPoDetail.Rows(a)("PODetailID").ToString
            Dr("PONO") = dtPoDetail.Rows(a)("PONO").ToString
            Dr("Balance") = Math.Round(Val(dtPoDetail.Rows(a)("RecvQuantity").ToString) - Val(dtPoDetail.Rows(a)("PreInvoiceQty").ToString), 0)
            Dr("DCDate") = dtPoDetail.Rows(a)("DCDate").ToString
            Dr("INVFrom") = lblPartyFrom.Text
            dtDetail.Rows.Add(Dr)
        Next
        Session("dtDetail") = dtDetail
    End Sub
    Sub BindProductType()
        Dim dt As DataTable
        dt = objPOInvoiceMaster.GetProductTypeFirstLevel()
        cmbProductType.DataSource = dt
        cmbProductType.DataTextField = "ItemName"
        cmbProductType.DataValueField = "ItemCode"
        cmbProductType.DataBind()
        cmbProductType.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbproduct.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Product Select.")
            ElseIf txtQuantity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Qty Empty.")
            ElseIf txtWeight.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Weight Empty.")
            ElseIf txtrate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Rate Empty.")
            ElseIf txtdiscPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("disc % Empty.")
            ElseIf txtSalesTaxPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("S.T. % Empty.")
            Else
                If cmbDCNO.SelectedValue > 0 Then
                    If Val(txtQuantity.Text) > lblQuantity.Text Then ' DGpodataView.Items(x).Cells(7).Text Then   '
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity must be less than Or Equal to " + lblQuantity.Text)
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        SaveSession()
                        BindGrid()
                        ClearControls()
                        btnSave.Visible = True
                        btnCancel.Visible = True
                        lblQuantity.Text = ""
                        lblPOdetailid.Text = ""
                        lblPORecvDetailTwoID.Text = ""
                        lblALreadyInvoiceQty.Text = ""
                        If POInvoiceMasterID > 0 Then
                            Dim a As Integer
                            For a = 0 To dgProductdetail.Items.Count - 1
                                Dim ChkStatus As CheckBox = CType(dgProductdetail.Items(a).FindControl("ChkStatus"), CheckBox)
                                ChkStatus.Checked = True
                            Next
                        End If

                    End If

                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    ClearControls()
                    btnSave.Visible = True
                    btnCancel.Visible = True
                    lblQuantity.Text = ""
                    lblPOdetailid.Text = ""
                    lblPORecvDetailTwoID.Text = ""
                    lblALreadyInvoiceQty.Text = ""
                    'If POInvoiceMasterID > 0 Then
                    Dim a As Integer
                    For a = 0 To dgProductdetail.Items.Count - 1
                        Dim ChkStatus As CheckBox = CType(dgProductdetail.Items(a).FindControl("ChkStatus"), CheckBox)
                        ChkStatus.Checked = True
                    Next
                    ' If
                End If

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
                .Columns.Add("POInvoiceDetailID", GetType(Long))
                .Columns.Add("ItemId", GetType(String))
                .Columns.Add("PartyDCNo", GetType(String))
                .Columns.Add("ItemCode", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("TotalQty", GetType(String))
                .Columns.Add("Weight", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("GrossAmount", GetType(String))
                .Columns.Add("DiscPercent", GetType(String))
                .Columns.Add("DiscAmount", GetType(String))
                .Columns.Add("ValExcloudSalesTax", GetType(String))
                .Columns.Add("SalesTaxPercentage", GetType(String))
                .Columns.Add("SalesTaxAmount", GetType(String))
                .Columns.Add("NetAmount", GetType(String))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("PORecvDetailTwoID", GetType(Long))
                .Columns.Add("PORecvMasterID", GetType(Long))
                .Columns.Add("PreInvoiceQty", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("PreInvoiceQty") = lblALreadyInvoiceQty.Text
        If lblPOInvoicedetailID.Text = "" Then
            Dr("POInvoiceDetailID") = 0
        Else
            Dr("POInvoiceDetailID") = lblPOInvoicedetailID.Text
        End If
        Dr("PORecvMasterID") = cmbDCNO.SelectedValue
        Dr("PartyDCNo") = cmbDCNO.SelectedItem.Text
        Dr("PORecvDetailTwoID") = lblPORecvDetailTwoID.Text
        Dr("ItemId") = cmbproduct.SelectedValue
        Dim ItemCode As String = objPOInvoiceMaster.GetItemCode(cmbproduct.SelectedValue)
        Dr("ItemCode") = ItemCode
        Dr("ItemName") = cmbproduct.SelectedItem.Text
        Dr("TotalQty") = txtQuantity.Text
        Dr("Weight") = txtWeight.Text
        Dr("Rate") = txtrate.Text
        Dr("GrossAmount") = txtGrossAmount.Text
        If txtdiscPercentage.Text = "" Then
            Dr("DiscPercent") = 0
        Else
            Dr("DiscPercent") = txtdiscPercentage.Text
        End If

        Dr("DiscAmount") = txtDiscAmount.Text
        Dr("ValExcloudSalesTax") = txtValueExcloudeST.Text
        If txtSalesTaxPercentage.Text = "" Then
            Dr("SalesTaxPercentage") = 0
        Else
            Dr("SalesTaxPercentage") = txtSalesTaxPercentage.Text
        End If
        Dr("SalesTaxAmount") = txtSalesTaxAmount.Text

        Dr("NetAmount") = Val(txtNetAmount.Text) + 0
        If lblPOdetailid.Text = "" Then
            Dr("PODetailID") = 0
        Else
            Dr("PODetailID") = lblPOdetailid.Text
        End If
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Protected Sub dgProductdetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductdetail.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim POInvoiceDetailID As Integer = dgProductdetail.Items(e.Item.ItemIndex).Cells(0).Text
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            objPOInvoiceMaster.DeleteDetail(POInvoiceDetailID)
                            BindGrid()
                        End If
                    End If

                Case "Edit"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim POInvoiceDetailID As Integer = dgProductdetail.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindGrid()
                            btnAdd.Visible = True
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            cmbDCNO.SelectedValue = dtDetail.Rows(dtrowNo)("PORecvMasterID")
            BindProductType()
            lblALreadyInvoiceQty.Text = dtDetail.Rows(dtrowNo)("PreInvoiceQty")
            lblPORecvDetailTwoID.Text = dtDetail.Rows(dtrowNo)("PORecvDetailTwoID")
            lblPOInvoicedetailID.Text = dtDetail.Rows(dtrowNo)("POInvoiceDetailID")
            lblPOdetailid.Text = dtDetail.Rows(dtrowNo)("PODetailID")
            lblQuantity.Text = dtDetail.Rows(dtrowNo)("TotalQTY")
            Dim ItemCode As String = objPOInvoiceMaster.GetItemCode(dtDetail.Rows(dtrowNo)("ItemId"))
            Dim ItemName As String = objPOInvoiceMaster.GetItemName(ItemCode.Substring(0, 2))
            cmbProductType.SelectedItem.Text = ItemName

            BindProductName(ItemCode.Substring(0, 2))

            cmbproduct.SelectedValue = dtDetail.Rows(dtrowNo)("ItemId")

            txtQuantity.Text = dtDetail.Rows(dtrowNo)("TotalQTY")
            txtWeight.Text = dtDetail.Rows(dtrowNo)("Weight")
            txtrate.Text = dtDetail.Rows(dtrowNo)("Rate")
            txtGrossAmount.Text = dtDetail.Rows(dtrowNo)("GrossAmount")
            txtdiscPercentage.Text = dtDetail.Rows(dtrowNo)("DiscPercent")
            txtDiscAmount.Text = dtDetail.Rows(dtrowNo)("DiscAmount")
            txtValueExcloudeST.Text = dtDetail.Rows(dtrowNo)("ValExcloudSalesTax")
            txtSalesTaxPercentage.Text = dtDetail.Rows(dtrowNo)("SalesTaxPercentage")
            txtSalesTaxAmount.Text = dtDetail.Rows(dtrowNo)("SalesTaxAmount")
            txtNetAmount.Text = dtDetail.Rows(dtrowNo)("NetAmount")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgProductdetail.Visible = True
                dgProductdetail.RecordCount = objDatatble.Rows.Count
                dgProductdetail.DataSource = objDatatble
                dgProductdetail.DataBind()
            Else
                dgProductdetail.Visible = False
            End If
            Dim TotalAmount As Decimal = 0
            Dim Stamount As Decimal = 0
            Dim NetAmt As Decimal = 0

            Dim a As Integer
            For a = 0 To dgProductdetail.Items.Count - 1
                Stamount = Stamount + dgProductdetail.Items(a).Cells(15).Text
                NetAmt = NetAmt + dgProductdetail.Items(a).Cells(16).Text
            Next
            TotalAmount = Val(NetAmt + Stamount)
            txtTotalAmount.Text = NetAmt
            txtTotalSalesTaxAmount.Text = Stamount
            txtTotal.Text = TotalAmount


            '-----New JN GRid
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgJunaidinfo.Visible = True
                dgJunaidinfo.RecordCount = objDatatble.Rows.Count
                dgJunaidinfo.DataSource = objDatatble
                dgJunaidinfo.DataBind()
            Else
                dgJunaidinfo.Visible = False
            End If
            Dim TotalAmountJN As Decimal = 0
            Dim StamountJN As Decimal = 0
            Dim NetAmtJN As Decimal = 0

            Dim aJN As Integer
            For aJN = 0 To dgJunaidinfo.Items.Count - 1
                Dim txtQunatityJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtQunatityJND"), Label)
                Dim txtRateJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtRateJND"), Label)
                Dim txtNetAmountJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtNetAmountJND"), Label)

                If txtSalesTaxP.Text = "" Then
                    txtSalesTaxP.Text = 0
                Else
                    txtSalesTaxP.Text = txtSalesTaxP.Text
                End If
                StamountJN = Math.Round(StamountJN + (Val(txtNetAmountJND.Text) * Val(txtSalesTaxP.Text) / 100), 0)
                NetAmtJN = NetAmtJN + Val(txtNetAmountJND.Text)
            Next
            TotalAmountJN = Val(NetAmtJN + StamountJN)
            txtTotalAmountJND.Text = NetAmtJN
            txtTotalSalesTaxAmountJND.Text = StamountJN
            txtTotalJND.Text = TotalAmountJN


        Catch ex As Exception
        End Try
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Check As Decimal = 0
        Try
            Dim dtchkinvoiceduplication As New DataTable
            dtchkinvoiceduplication = objPOInvoiceAdjDetail.ChkInvoiceDuplication(txtsalesTaxInv.Text)
            If dtchkinvoiceduplication.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Inv No Duplicate..")
            Else
                Dim credits As Decimal = 0
                If txtsalesTaxInv.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Sales TaxInv Empty.")
                    'ElseIf txtBillDate.Text = "" Then
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Bill Date. Empty.")
                    'ElseIf txtrefNo.Text = "" Then
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Ref No Empty.")
                ElseIf cmbPartyname.SelectedIndex = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Supplier Select.")
                ElseIf dgProductdetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                ElseIf txtAccountLedger.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("AccountLedger Required.")
                Else

                    SaveMaster()
                    SaveDetail()
                    '---Save Adjust Invoice Data detail
                    SaveAdjustInvoiceDetailData()
                    Response.Redirect("POInvoiceView.aspx")
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub
    Sub SaveMaster()
        Try
            With objPOInvoiceMst
                If POInvoiceMasterID > 0 Then
                    .POInvoiceMstID = POInvoiceMasterID
                Else
                    .POInvoiceMstID = 0
                End If
                .TransactionNo = txtTransactionNo.Text
                If txtDescription.Text = "" Then
                    .Description = "N/A"
                Else
                    .Description = txtDescription.Text
                End If

                .VoucherNo = txtVoucherNo.Text
                '  .CreationDate = txtCreationDate.Text
                If chkshowCalander.Checked = True Then
                    .CreationDate = objgeneralCode.GetDate(txtCreationDate.Text)
                Else
                    .CreationDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
                End If

                .GSTType = RBBtn.SelectedItem.Text
                If txtsalesTaxInv.Text = "" Then
                    .SaleTaxInvoiceNo = "N/A"
                Else
                    .SaleTaxInvoiceNo = txtsalesTaxInv.Text
                End If

                .BillDate = Date.Today
                If txtSupplierRefNo.Text = "" Then
                    .SupplierRefNo = "N/A"
                Else
                    .SupplierRefNo = txtSupplierRefNo.Text
                End If
                .CompanySTNo = "N/A" 'txtCompanySTNo.Text
                .OtherRefNo = "N/A" 'txtrefNo.Text
                .BuyerSTNo = "N/A" 'txtBuyerSTNo.Text
                .CompanyCSTNo = "N/A" ' txtCompanyCSTNo.Text
                .SaleTaxType = 0
                .CompanyPAN = "N/A" 'txtCompanyPAN.Text
                Dim TopSNo As Integer = objPOInvoiceMaster.GetTopSNO()
                .SNO = Val(TopSNo + 1)
                .AccountPayablePartyID = cmbPartyname.SelectedValue
                '---Use purpose for Payment Time
                Dim c As Integer
                'Dim TotalInvoiceAmount As Decimal = 0
                'For c = 0 To dgProductdetail.Items.Count - 1
                '    TotalInvoiceAmount = TotalInvoiceAmount + dgProductdetail.Items(c).Cells(15).Text
                'Next
                '.InvoiceNetAmount = TotalInvoiceAmount
                .InvoiceNetAmount = txtTotal.Text
                .PaymentAmount = 0
                .PaymentBit = 0
                .LedgerAccountName = txtAccountLedger.Text
                .LedgerAccountCode = lblAccountLedgerCode.Text
                .INVFrom = lblPartyFrom.Text
                If chkshowCalander.Checked = True Then
                    .ChkDate = True
                Else
                    .ChkDate = False
                End If
                .SavePOInvoiceMst()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveDetail()
        Try
            For x = 0 To dgProductdetail.Items.Count - 1
                Dim txtQunatity As TextBox = CType(dgProductdetail.Items(x).FindControl("txtQunatity"), TextBox)
                Dim lPORecvDetailTwoID As Long = dgProductdetail.Items(x).Cells(21).Text
                Dim TotalQty As Decimal = 0
                Dim Quantity As Decimal = 0
                Dim updateqty As Decimal = 0
                Dim PREVOUSQTY As Decimal = 0
                Dim dtPOQTY, dtpreviouQty As DataTable
                With objPOInvoiceDtl
                    .POInvoiceDtlId = dgProductdetail.Items(x).Cells(0).Text
                    If POInvoiceMasterID > 0 Then
                        .POInvoiceMstID = POInvoiceMasterID
                    Else
                        .POInvoiceMstID = objPOInvoiceMst.GetID
                    End If
                    .ItemId = dgProductdetail.Items(x).Cells(1).Text
                    .Qunatity = Val(txtQunatity.Text)
                    .Weight = dgProductdetail.Items(x).Cells(8).Text
                    .Rate = dgProductdetail.Items(x).Cells(9).Text
                    .GrossAmount = dgProductdetail.Items(x).Cells(10).Text
                    .DiscPercent = dgProductdetail.Items(x).Cells(11).Text
                    .DiscAmount = dgProductdetail.Items(x).Cells(12).Text
                    .ValExcloudSalesTax = dgProductdetail.Items(x).Cells(13).Text
                    .SalesTaxPercentage = dgProductdetail.Items(x).Cells(14).Text
                    .SalesTaxAmount = dgProductdetail.Items(x).Cells(15).Text
                    .NetAmount = dgProductdetail.Items(x).Cells(16).Text
                    If lblPartyFrom.Text = "PORECEIVE" Then
                        '----POPortion IDs
                        .PODetailId = dgProductdetail.Items(x).Cells(20).Text
                        .PORecvDetailTwoID = dgProductdetail.Items(x).Cells(21).Text
                        .PORecvMasterID = dgProductdetail.Items(x).Cells(22).Text
                        '----YarnPortion IDs
                        .TblYarnPurchaseContractDetailID = 0
                        .YarnRecvDetailID = 0
                        .YarnRecvmasterID = 0
                    ElseIf lblPartyFrom.Text = "YARNRECEIVE" Then
                        '----POPortion IDs
                        .PODetailId = 0
                        .PORecvDetailTwoID = 0
                        .PORecvMasterID = 0
                        '----YarnPortion IDs
                        .TblYarnPurchaseContractDetailID = dgProductdetail.Items(x).Cells(20).Text
                        .YarnRecvDetailID = dgProductdetail.Items(x).Cells(21).Text
                        .YarnRecvmasterID = dgProductdetail.Items(x).Cells(22).Text
                    Else
                    End If

                    .INVFrom = lblPartyFrom.Text


                    .SavePOInvoiceDtl()
                End With
                If lPORecvDetailTwoID > 0 Then
                    If POInvoiceMasterID > 0 Then
                        If lblPartyFrom.Text = "PORECEIVE" Then
                            dtPOQTY = objPOInvoiceDtl.GetYarnRecvQUANTITY(lPORecvDetailTwoID)
                            dtpreviouQty = objPOInvoiceDtl.GetYarnPreviousQUANTITY(lPORecvDetailTwoID)
                        ElseIf lblPartyFrom.Text = "YARNRECEIVE" Then
                            dtPOQTY = objPOInvoiceDtl.GetPORecvQUANTITY(lPORecvDetailTwoID)
                            dtpreviouQty = objPOInvoiceDtl.GetPOPreviousQUANTITY(lPORecvDetailTwoID)
                        Else
                            '---get next
                        End If
                        Quantity = dtPOQTY.Rows(0)("InvoiceQTY")
                        PREVOUSQTY = dtpreviouQty.Rows(0)("PREVOIUSSUM")
                        updateqty = Quantity - PREVOUSQTY 'dgProductdetail.Items(x).Cells(6).Text '- dtPOQTY.Rows(0)("InvoiceQTY")
                        'If updateqty > 0 Then
                        TotalQty = Quantity - updateqty
                        'Else
                        'TotalQty = Quantity
                        'End If
                        TotalQty = Quantity - updateqty
                        objPOInvoiceDtl.UPDATEInVOICEqTYNew(lPORecvDetailTwoID, TotalQty, lblPartyFrom.Text)
                    Else
                        Dim POREceiveQty As Decimal = 0
                        If lblPartyFrom.Text = "PORECEIVE" Then
                            dtPOQTY = objPOInvoiceDtl.GetPOQUANTITY(lPORecvDetailTwoID)
                        ElseIf lblPartyFrom.Text = "YARNRECEIVE" Then
                            dtPOQTY = objPOInvoiceDtl.GetYarnQUANTITY(lPORecvDetailTwoID)
                        Else
                            '---get next
                        End If
                        Quantity = dtPOQTY.Rows(0)("InvoiceQTY")
                        POREceiveQty = dtPOQTY.Rows(0)("RecvQuantity")
                        TotalQty = Quantity + Val(txtQunatity.Text)
                        objPOInvoiceDtl.UPDATEInVOICEqTYNew(lPORecvDetailTwoID, TotalQty, lblPartyFrom.Text)
                        '---For update Status
                        ' If POREceiveQty = Val(dgProductdetail.Items(x).Cells(5).Text) Then
                        If POREceiveQty = TotalQty Then
                            objPOInvoiceDtl.UPDATEInVOICEStatusNew(lPORecvDetailTwoID, lblPartyFrom.Text)
                        Else

                        End If
                    End If

                End If
            Next
            If POInvoiceMasterID > 0 Then
                objPOInvoiceDetail.DeleteFrmLedger(lblPartyid.Text, POInvoiceMasterID)
            End If
            With objSupplierLedger
                .SupplierLedgerID = 0
                .IMSSupplierId = lblPartyid.Text
                .InvoiceDate = txtCreationDate.Text
                .AmountDebits = 0
                .AmountCredits = 0 'Convert.ToDecimal(LblNetAmount.Text)
                .Description = "Invoice # " & txtVoucherNo.Text
                If POInvoiceMasterID > 0 Then
                    .POInvoiceMstId = POInvoiceMasterID
                Else
                    .POInvoiceMstId = objPOInvoiceMaster.GetID
                End If
                .SaveSupplierLedger()

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveAdjustInvoiceDetailData()
        Try
            Dim NetAmount As Decimal = 0
            If POInvoiceMasterID > 0 Then
                For x = 0 To dgProductdetail.Items.Count - 1
                    NetAmount = NetAmount + dgProductdetail.Items(x).Cells(15).Text
                Next
                objPOInvoiceAdjDetail.UpdateOpeningAmount(POInvoiceMasterID, NetAmount)
            Else
                With objPOInvoiceAdjDetail
                    .POInvoiceAdjDetailID = 0
                    .POInvoiceMasterID = objPOInvoiceMst.GetID
                    .SupplierID = lblPartyid.Text
                    .tblBankMstID = 0
                    .CreationDate = Today.Date

                    For x = 0 To dgProductdetail.Items.Count - 1
                        NetAmount = NetAmount + dgProductdetail.Items(x).Cells(15).Text
                    Next
                    .OpeningAmount = NetAmount
                    .BalanceAmountDTL = NetAmount
                    .AdjustedAmount = 0
                    .PaymentType = "N/A"
                    .PaymentVocuherRefNo = "N/A"
                    .SavePOInvoiceAdjDetail()
                End With
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub ClearControls()
        cmbproduct.SelectedValue = 0
        cmbProductType.SelectedValue = 0
        txtQuantity.Text = ""
        txtWeight.Text = ""
        txtrate.Text = ""
        txtGrossAmount.Text = ""
        txtdiscPercentage.Text = ""
        txtDiscAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtValueExcloudeST.Text = ""
        txtSalesTaxPercentage.Text = ""
        txtSalesTaxAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtNetAmount.Text = ""
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("POInvoiceView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        Try

            If POInvoiceMasterID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                '---new
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) + (Val(txtDiscAmount.Text))
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtdiscPercentage.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtdiscPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdiscPercentage.TextChanged
        Try
            If POInvoiceMasterID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxPercentage.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtSalesTaxPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesTaxPercentage.TextChanged
        Try
            If POInvoiceMasterID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Try
            If POInvoiceMasterID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtWeight.Focus()
            Else
                If txtWeight.Text = "" Or txtrate.Text = "" Or txtdiscPercentage.Text = "" Or txtDiscAmount.Text = "" Or txtSalesTaxPercentage.Text = "" Or txtSalesTaxAmount.Text = "" Then
                    txtrate.Text = 0
                    txtdiscPercentage.Text = 0
                    txtDiscAmount.Text = 0
                    txtSalesTaxPercentage.Text = 0
                    txtSalesTaxAmount.Text = 0
                    txtWeight.Text = 0
                Else
                    txtrate.Text = txtrate.Text
                    txtdiscPercentage.Text = txtdiscPercentage.Text
                    txtDiscAmount.Text = txtDiscAmount.Text
                    txtSalesTaxPercentage.Text = txtSalesTaxPercentage.Text
                    txtSalesTaxAmount.Text = txtSalesTaxAmount.Text
                End If

                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtWeight.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub chkshowCalander_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkshowCalander.CheckedChanged
        Try
            If chkshowCalander.Checked = True Then
                txtVoucherdate2.Visible = False
                txtCreationDate.Visible = True
                ImageButton1.Visible = True

            Else
                txtVoucherdate2.Visible = True
                txtCreationDate.Visible = False
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

    '---New End  
    Sub EditMode()
        Try
            Dim dt As DataTable = objPOInvoiceMaster.EditNew(POInvoiceMasterID, AccountPayablePartyID)
            Dim dtexpenses As DataTable = objPOInvoiceMaster.EditExpense(POInvoiceMasterID)

            Dim A As Boolean
            A = dt.Rows(0)("ChkDate")

            If A = True Then
                chkshowCalander.Checked = True
                txtCreationDate.Text = dt.Rows(0)("CreationDate")
                txtVoucherdate2.Visible = False
                txtCreationDate.Visible = True
                ImageButton1.Visible = True
            Else
                chkshowCalander.Checked = False
                txtVoucherdate2.Text = dt.Rows(0)("CreationDate")
                txtVoucherdate2.Visible = True
                txtCreationDate.Visible = False
                ImageButton1.Visible = False
            End If
            'txtCreationDate.Text = dt.Rows(0)("CreationDate")

            txtTransactionNo.Text = dt.Rows(0)("TransactionNo")
            txtVoucherNo.Text = dt.Rows(0)("VoucherNo")

            Dim GST As Boolean = dt.Rows(0)("GSTType")
            If GST = False Then
                RBBtn.SelectedValue = 0
            Else
                RBBtn.SelectedValue = 1
            End If
            txtsalesTaxInv.Text = dt.Rows(0)("SaleTaxInvoiceNo")
            'cmbPO.SelectedValue = dt.Rows(0)("POID")
            BindParty()
            'cmbPO.Enabled = False

            txtBillDate.Text = dt.Rows(0)("BillDate")
            txtrefNo.Text = dt.Rows(0)("refNo")
            'txtPurchaseAC.Text = dt.Rows(0)("PurchaseAccount")
            'txtCreditDays.Text = dt.Rows(0)("CreditDays")
            cmbPartyname.SelectedValue = dt.Rows(0)("SupplierDatabaseId")
            cmbPartyname.SelectedItem.Text = dt.Rows(0)("AccountPayable")
            lblPartyid.Text = dt.Rows(0)("SupplierDatabaseID")
            'txtterms.Text = dt.Rows(0)("terms")
            'cmbSalesTaxType.SelectedItem.Text = dt.Rows(0)("SaleTaxType")
            'txtComments.Text = dt.Rows(0)("Comments")

            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("POInvoiceDetailID", GetType(Long))
                    .Columns.Add("DeptDatabasename", GetType(String))
                    .Columns.Add("ItemId", GetType(String))
                    .Columns.Add("ItemCode", GetType(String))
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("Quality", GetType(String))
                    .Columns.Add("TotalQTy", GetType(String))
                    .Columns.Add("Weight", GetType(String))
                    .Columns.Add("Rate", GetType(String))
                    .Columns.Add("GrossAmount", GetType(String))
                    .Columns.Add("DiscPercent", GetType(String))
                    .Columns.Add("DiscAmount", GetType(String))
                    .Columns.Add("ValExcloudSalesTax", GetType(String))
                    .Columns.Add("SalesTaxPercentage", GetType(String))
                    .Columns.Add("SalesTaxAmount", GetType(String))
                    .Columns.Add("NetAmount", GetType(String))
                    .Columns.Add("PODetailID", GetType(Long))
                    .Columns.Add("AdditionalChargesAccountCode", GetType(String))
                    .Columns.Add("AdditionalChargesAccountName", GetType(String))
                    .Columns.Add("AdditionalCharges", GetType(String))
                End With
            End If

            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("POInvoiceDetailID") = dt.Rows(x)("POInvoiceDetailID")
                Dr("DeptDatabasename") = dt.Rows(x)("DeptDatabasename")
                Dr("ItemId") = dt.Rows(x)("ItemId")
                Dr("ItemCode") = dt.Rows(x)("ItemCode")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("Quality") = dt.Rows(x)("Quality")
                Dr("TotalQTy") = dt.Rows(x)("Qunatity")
                Dr("Weight") = dt.Rows(x)("Weight")
                Dr("Rate") = dt.Rows(x)("Rate")
                Dr("GrossAmount") = dt.Rows(x)("GrossAmount")
                Dr("DiscPercent") = dt.Rows(x)("DiscPercent")
                Dr("DiscAmount") = dt.Rows(x)("DiscAmount")
                Dr("ValExcloudSalesTax") = dt.Rows(x)("ValExcloudSalesTax")
                Dr("SalesTaxPercentage") = dt.Rows(x)("SalesTaxPercentage")
                Dr("SalesTaxAmount") = dt.Rows(x)("SalesTaxAmount")
                Dr("NetAmount") = dt.Rows(x)("NetAmount")
                Dr("PODetailID") = dt.Rows(x)("PODetailID")
                Dr("AdditionalChargesAccountCode") = dt.Rows(x)("AdditionalChargesAccountCode")
                Dr("AdditionalChargesAccountName") = dt.Rows(x)("AdditionalChargesAccountName")
                Dr("AdditionalCharges") = dt.Rows(x)("AdditionalCharges")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
            Dim b As Integer
            For b = 0 To dgProductdetail.Items.Count - 1
                Dim ChkStatus As CheckBox = CType(dgProductdetail.Items(b).FindControl("ChkStatus"), CheckBox)
                ChkStatus.Checked = True
            Next

            btnSave.Visible = True
            btnCancel.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtCreationDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCreationDate.TextChanged
        Try
            VoucherNoGenerateOnLoad()
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub txtaccountPayable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaccountPayable.TextChanged
    '    Try
    '        If txtaccountPayable.Text = "" Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid SupplierName.")
    '        ElseIf txtaccountPayable.Text <> "" Then
    '            dtAC = objSupplier.GetSupplierIDForInvoice(txtaccountPayable.Text)
    '            If dtAC.Rows.Count > 0 Then
    '                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
    '            Else
    '                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("SupplierName Name Not Exist")
    '            End If
    '            lblPartyid.Text = dtAC.Rows(0)("SupplierdatabaseID")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub RBBtn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBBtn.SelectedIndexChanged
        Try
            If RBBtn.SelectedValue = 0 Then
                pnlWithGST.Visible = True
                lblHdngStax.Text = "Sales Tax Inv:"
                If txtSalesTaxP.Text = "" Then
                    txtSalesTaxP.Text = 0
                Else
                    txtSalesTaxP.Text = txtSalesTaxP.Text
                End If
                lblSalesTaxAmountJND.Visible = True
                txtTotalSalesTaxAmountJND.Visible = True
            Else
                lblSalesTaxAmountJND.Visible = False
                txtTotalSalesTaxAmountJND.Visible = False
                pnlWithGST.Visible = False
                lblHdngStax.Text = "Inv:"
                txtSalesTaxP.Text = 0
            End If
            CalculationStxTotalAmt()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtQunatity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim TotalAmount As Decimal = 0
            Dim Stamount As Decimal = 0
            Dim NetAmt As Decimal = 0

            For x = 0 To dgProductdetail.Items.Count - 1

                Dim txtQunatity As TextBox = CType(dgProductdetail.Items(x).FindControl("txtQunatity"), TextBox)
                'dgProductdetail.Items(x).Cells(15).Text = Val(dgProductdetail.Items(x).Cells(8).Text) * Val(txtQunatity.Text)
                'dgProductdetail.Items(x).Cells(9).Text = dgProductdetail.Items(x).Cells(15).Text
                'dgProductdetail.Items(x).Cells(11).Text = dgProductdetail.Items(x).Cells(15).Text
                'dgProductdetail.Items(x).Cells(14).Text = Val(dgProductdetail.Items(x).Cells(15).Text) * Val(txtSalesTaxP.Text) / 100
                'Stamount = Stamount + dgProductdetail.Items(x).Cells(14).Text
                'NetAmt = NetAmt + dgProductdetail.Items(x).Cells(15).Text

                dgProductdetail.Items(x).Cells(10).Text = Val(dgProductdetail.Items(x).Cells(9).Text) * Val(txtQunatity.Text)
                dgProductdetail.Items(x).Cells(13).Text = dgProductdetail.Items(x).Cells(10).Text
                dgProductdetail.Items(x).Cells(14).Text = Val(txtSalesTaxP.Text)
                dgProductdetail.Items(x).Cells(15).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text) * Val(txtSalesTaxP.Text) / 100, 0)
                dgProductdetail.Items(x).Cells(16).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text), 0) 'Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text) + Val(dgProductdetail.Items(x).Cells(15).Text), 0)
                Stamount = Stamount + Val(dgProductdetail.Items(x).Cells(15).Text)
                NetAmt = NetAmt + Val(dgProductdetail.Items(x).Cells(16).Text)

                dgProductdetail.Items(x).Cells(24).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(24).Text) - Val(txtQunatity.Text), 0)

                Dim txtQunatityJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtQunatityJND"), Label)
                Dim txtRateJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtRateJND"), Label)
                Dim txtNetAmountJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtNetAmountJND"), Label)
                txtQunatityJND.Text = txtQunatity.Text
                txtNetAmountJND.Text = Math.Round(Val(txtQunatityJND.Text) * Val(txtRateJND.Text), 0)
            Next
            TotalAmount = Val(NetAmt + Stamount)
            txtTotalAmount.Text = NetAmt
            txtTotalSalesTaxAmount.Text = Stamount
            txtTotal.Text = TotalAmount



            '-----------------------
            '-----New JN GRid

            Dim TotalAmountJN As Decimal = 0
            Dim StamountJN As Decimal = 0
            Dim NetAmtJN As Decimal = 0

            Dim aJN As Integer
            For aJN = 0 To dgJunaidinfo.Items.Count - 1
                Dim txtQunatityJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtQunatityJND"), Label)
                Dim txtRateJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtRateJND"), Label)
                Dim txtNetAmountJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtNetAmountJND"), Label)
                If txtSalesTaxP.Text = "" Then
                    txtSalesTaxP.Text = 0
                Else
                    txtSalesTaxP.Text = txtSalesTaxP.Text
                End If
                StamountJN = Math.Round(StamountJN + (Val(txtNetAmountJND.Text) * Val(txtSalesTaxP.Text) / 100), 0)
                NetAmtJN = NetAmtJN + Val(txtNetAmountJND.Text)
            Next
            TotalAmountJN = Val(NetAmtJN + StamountJN)
            txtTotalAmountJND.Text = NetAmtJN
            txtTotalSalesTaxAmountJND.Text = StamountJN
            txtTotalJND.Text = TotalAmountJN


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtsalesTaxInv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtsalesTaxInv.Text <> "" Then
                txtSupplierRefNo.Text = txtsalesTaxInv.Text
            Else
                txtSupplierRefNo.Text = txtsalesTaxInv.Text
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub CalculationStxTotalAmt()
        Try
            Dim TotalAmount As Decimal = 0
            Dim Stamount As Decimal = 0
            Dim NetAmt As Decimal = 0

            For x = 0 To dgProductdetail.Items.Count - 1

                Dim txtQunatity As TextBox = CType(dgProductdetail.Items(x).FindControl("txtQunatity"), TextBox)
                dgProductdetail.Items(x).Cells(10).Text = Val(dgProductdetail.Items(x).Cells(9).Text) * Val(txtQunatity.Text)
                dgProductdetail.Items(x).Cells(13).Text = dgProductdetail.Items(x).Cells(10).Text
                dgProductdetail.Items(x).Cells(14).Text = Val(txtSalesTaxP.Text)
                dgProductdetail.Items(x).Cells(15).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text) * Val(txtSalesTaxP.Text) / 100, 0)
                dgProductdetail.Items(x).Cells(16).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text), 0) ' Math.Round(Val(dgProductdetail.Items(x).Cells(10).Text) + Val(dgProductdetail.Items(x).Cells(15).Text), 0)
                Stamount = Stamount + Val(dgProductdetail.Items(x).Cells(15).Text)
                NetAmt = NetAmt + dgProductdetail.Items(x).Cells(16).Text

                'dgProductdetail.Items(x).Cells(24).Text = Math.Round(Val(dgProductdetail.Items(x).Cells(24).Text) - Val(txtQunatity.Text), 0)

                Dim txtQunatityJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtQunatityJND"), Label)
                Dim txtRateJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtRateJND"), Label)
                Dim txtNetAmountJND As Label = CType(dgJunaidinfo.Items(x).FindControl("txtNetAmountJND"), Label)
                txtQunatityJND.Text = txtQunatity.Text
                txtNetAmountJND.Text = Math.Round(Val(txtQunatityJND.Text) * Val(txtRateJND.Text), 0)
            Next
            TotalAmount = Val(NetAmt + Stamount)
            txtTotalAmount.Text = NetAmt
            txtTotalSalesTaxAmount.Text = Stamount
            txtTotal.Text = TotalAmount



            '-----------------------
            '-----New JN GRid

            Dim TotalAmountJN As Decimal = 0
            Dim StamountJN As Decimal = 0
            Dim NetAmtJN As Decimal = 0

            Dim aJN As Integer
            For aJN = 0 To dgJunaidinfo.Items.Count - 1
                Dim txtQunatityJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtQunatityJND"), Label)
                Dim txtRateJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtRateJND"), Label)
                Dim txtNetAmountJND As Label = CType(dgJunaidinfo.Items(aJN).FindControl("txtNetAmountJND"), Label)
                If txtSalesTaxP.Text = "" Then
                    txtSalesTaxP.Text = 0
                Else
                    txtSalesTaxP.Text = txtSalesTaxP.Text
                End If
                StamountJN = Math.Round(StamountJN + (Val(txtNetAmountJND.Text) * Val(txtSalesTaxP.Text) / 100), 0)
                NetAmtJN = NetAmtJN + Val(txtNetAmountJND.Text)
            Next
            TotalAmountJN = Val(NetAmtJN + StamountJN)
            txtTotalAmountJND.Text = NetAmtJN
            txtTotalSalesTaxAmountJND.Text = StamountJN
            txtTotalJND.Text = TotalAmountJN
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtSalesTaxP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesTaxP.TextChanged
        Try
            CalculationStxTotalAmt()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtAccountLedger_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountLedger.TextChanged
        Try
            If txtAccountLedger.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtAccountLedger.Text <> "" Then
                Dim dtacntldgr As DataTable
                dtacntldgr = objPOInvoiceMaster.GetAccountLedger(txtAccountLedger.Text)
                If dtacntldgr.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    txtAccountLedger.Text = dtacntldgr.Rows(0)("AccountName").ToString
                    lblAccountLedgerCode.Text = dtacntldgr.Rows(0)("AccountCode").ToString
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Ledger. Not Exist")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class





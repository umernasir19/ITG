Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class ProcessOrderEntry
    Inherits System.Web.UI.Page
    Dim objProcessOrderMst As New ProcessOrderMst
    Dim objProcessOrderDtl As New ProcessOrderDtl
    Dim objIssueType As New IssueType
    Dim objSupplier As New SupplierDataBase
    Dim objgeneralCode As New GeneralCode
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim ProcessOrderMstID, JoborderID As Long
    Dim dtAC As DataTable
    Dim AccountCode As String
    Dim userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProcessOrderMstID = Request.QueryString("ProcessOrderMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindPOType()
            BindProductType()
            BindProductName(cmbProductType.SelectedValue)
            BindStore()
            BindJobOrder()
            bindItemUnit()
            bindCurrency()
            BindIssueType()
            Session("dtDetail") = Nothing
            Session("PoTypeId") = Nothing
            If cmbPOType.SelectedValue = 1 Then
                cmbJobNo.Enabled = False
            Else
                cmbJobNo.Enabled = True
            End If
            If ProcessOrderMstID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                txtCreationDate.Text = Date.Now
                VoucherNoGenerateOnLoad()
                btnSave.Text = "Save"
                txtSample.Text = "N/A"
                txtcomment.Text = "N/A"
                txtInspection.Text = "N/A"
                txtPartyRef.Text = "N/A"
                txtPacking.Text = "N/A"
                cmbFrom.SelectedValue = 54
                txtdiscPercentage.Text = 0
                txtSalesTaxPercentage.Text = 0
                If userid = 245 Then
                    cmbItemunit.SelectedValue = 7
                Else
                End If
            End If
        End If
        PageHeader("PROCESS ORDER ENTRY")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindPOType()
        Dim dtContractType As DataTable
        dtContractType = objProcessOrderMst.BindContractType()
        cmbPOType.DataSource = dtContractType
        cmbPOType.DataTextField = "ContractType"
        cmbPOType.DataValueField = "ContractTypeID"
        cmbPOType.DataBind()
    End Sub
    Sub BindProductType()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetAllFabric()
        cmbProductType.DataSource = dt
        cmbProductType.DataTextField = "ItemClassName"
        cmbProductType.DataValueField = "IMSItemClassID"
        cmbProductType.DataBind()
    End Sub
    Sub BindProcessItemType()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetProcessItem(lblIssueCode.Text)
        cmbProcessType.DataSource = dt
        cmbProcessType.DataTextField = "ItemClassName"
        cmbProcessType.DataValueField = "IMSItemClassID"
        cmbProcessType.DataBind()
    End Sub
    Sub BindProcessItemName()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetProcessItemName(lblIssueCode.Text)
        cmbProcessItemName.DataSource = dt
        cmbProcessItemName.DataTextField = "ItemName"
        cmbProcessItemName.DataValueField = "IMSItemID"
        cmbProcessItemName.DataBind()
    End Sub
    Sub BindProductName(ByVal ItemCode As String)
        Dim dt As DataTable
        dt = objProcessOrderMst.GetItemFabric(cmbProductType.SelectedValue)
        cmbproduct.DataSource = dt
        cmbproduct.DataTextField = "ItemName"
        cmbproduct.DataValueField = "IMSItemID"
        cmbproduct.DataBind()
        cmbproduct.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindStore()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetCmbFrom()
        cmbFrom.DataSource = dt
        cmbFrom.DataTextField = "DeptDatabaseName"
        cmbFrom.DataValueField = "DeptDatabaseId"
        cmbFrom.DataBind()
    End Sub
    Sub BindJobOrder()
        Try
            Dim dtJobNo As DataTable
            dtJobNo = objProcessOrderMst.BindJobOrderNo()
            cmbJobNo.DataSource = dtJobNo
            cmbJobNo.DataTextField = "SRNO"
            cmbJobNo.DataValueField = "Joborderid"
            cmbJobNo.DataBind()
            cmbJobNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub bindItemUnit()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetUOMItem()
        cmbItemunit.DataSource = dt
        cmbItemunit.DataTextField = "Symbol"
        cmbItemunit.DataValueField = "ItemUnitID"
        cmbItemunit.DataBind()
    End Sub
    Sub bindCurrency()
        Dim Dt As DataTable
        Dt = objProcessOrderMst.GetCurrency()
        cmbCurrencys.DataSource = Dt
        cmbCurrencys.DataTextField = "CurrencyName"
        cmbCurrencys.DataValueField = "CurrencyID"
        cmbCurrencys.DataBind()
        cmbCurrencys.DataSource = Dt
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objProcessOrderMst.FabricEditForDigitalNew(ProcessOrderMstID)
            txtPurchaseOrderNo.Text = dt.Rows(0)("PONo")
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            cmbPOType.SelectedValue = dt.Rows(0)("POTypeID")
            txtPartyRef.Text = dt.Rows(0)("PartyRef")
            txtcomment.Text = dt.Rows(0)("Comments")
            TXTInditexPONo.Text = dt.Rows(0)("InditexPONo")
            txtConsumerAge.Text = dt.Rows(0)("ConsumerAge")
            TXTSalesContractNo.Text = dt.Rows(0)("SalesContractNo")
            TXTCodeEntry.Text = dt.Rows(0)("CodeEntry")
            txtRemarks.Text = dt.Rows(0)("MasterRemarks")
            If cmbJobNo.SelectedValue > 0 Then
                BindProductTypeByJobOrdervise()
                cmbProductType.SelectedValue = dt.Rows(0)("ProductTypeId")
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
            Else
                BindProductType()
                cmbProductType.SelectedValue = dt.Rows(0)("ProductTypeId")
                BindProductName(cmbProductType.SelectedValue)
            End If
            txtSample.Text = dt.Rows(0)("Sample")
            txtPacking.Text = dt.Rows(0)("Packing")
            txtInspection.Text = dt.Rows(0)("Inspection")
            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("ProcessOrderDtlID", GetType(Long))
                    .Columns.Add("DeptDatabaseId", GetType(String))
                    .Columns.Add("DeptDatabaseName", GetType(String))
                    .Columns.Add("ItemId", GetType(String))
                    .Columns.Add("ProductType", GetType(String))
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("Quality", GetType(String))
                    .Columns.Add("Quantity", GetType(String))
                    .Columns.Add("Weight", GetType(String))
                    .Columns.Add("Rate", GetType(String))
                    .Columns.Add("GrossAmount", GetType(String))
                    .Columns.Add("DiscPercent", GetType(String))
                    .Columns.Add("DiscAmount", GetType(String))
                    .Columns.Add("ValExcloudSalesTax", GetType(String))
                    .Columns.Add("SalesTaxPercentage", GetType(String))
                    .Columns.Add("SalesTaxAmount", GetType(String))
                    .Columns.Add("NetAmount", GetType(String))
                    .Columns.Add("InvoiceQty", GetType(String))
                    .Columns.Add("UOM", GetType(String))
                    .Columns.Add("Size", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("PartyAccount", GetType(String))
                    .Columns.Add("AccountPayablePartyID", GetType(String))
                    .Columns.Add("ProductTypeId", GetType(String))
                    .Columns.Add("UOMID", GetType(String))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("CurrencyId", GetType(String))
                    .Columns.Add("Currency", GetType(String))
                    .Columns.Add("ExchangeRate", GetType(String))
                    .Columns.Add("Remarks", GetType(String))
                    .Columns.Add("IssueTypeID", GetType(String))
                    .Columns.Add("IssueType", GetType(String))
                    .Columns.Add("ProcessItemCodeID", GetType(String))
                    .Columns.Add("ProcessItemCode", GetType(String))
                    .Columns.Add("ProcessItemTypeID", GetType(String))
                    .Columns.Add("ProcessItemType", GetType(String))
                    .Columns.Add("ProcessItemNameID", GetType(String))
                    .Columns.Add("ProcessItemName", GetType(String))
                    .Columns.Add("ProcessQuality", GetType(String))
                    .Columns.Add("ProcessShade", GetType(String))
                    .Columns.Add("ProcessQuantity", GetType(String))
                    .Columns.Add("ProcessSalesTax", GetType(String))
                    .Columns.Add("SRNoID", GetType(String))
                    .Columns.Add("SRNo", GetType(String))
                    .Columns.Add("FreshQty", GetType(String))
                    .Columns.Add("BQualityQty", GetType(String))
                    .Columns.Add("DeliveryDate", GetType(String))
                    .Columns.Add("PORate", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("ProcessOrderDtlID") = dt.Rows(x)("ProcessOrderDtlID")
                Dr("DeptDatabaseId") = dt.Rows(x)("DeptDatabaseId")
                Dr("DeptDatabaseName") = dt.Rows(x)("DeptDatabaseName")
                Dr("ItemId") = dt.Rows(x)("ItemId")
                Dr("ProductType") = dt.Rows(x)("ItemClassname")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("Quality") = dt.Rows(x)("Quality")
                Dr("Quantity") = dt.Rows(x)("Quantity")
                Dr("Weight") = dt.Rows(x)("Weight")
                Dr("Rate") = dt.Rows(x)("Rate")
                Dr("GrossAmount") = dt.Rows(x)("GrossAmount")
                Dr("DiscPercent") = dt.Rows(x)("DiscPercent")
                Dr("DiscAmount") = dt.Rows(x)("DiscAmount")
                Dr("ValExcloudSalesTax") = dt.Rows(x)("ValExcloudSalesTax")
                Dr("SalesTaxPercentage") = dt.Rows(x)("SalesTaxPercentage")
                Dr("SalesTaxAmount") = dt.Rows(x)("SalesTaxAmount")
                Dr("NetAmount") = dt.Rows(x)("NetAmount")
                Dr("InvoiceQty") = dt.Rows(x)("InvoiceQty")
                Dr("UOM") = dt.Rows(x)("Symbol")
                Dr("Size") = dt.Rows(x)("Size")
                Dr("Color") = dt.Rows(x)("Color")
                Dr("PartyAccount") = dt.Rows(x)("PartyAccount")
                Dr("AccountPayablePartyID") = dt.Rows(x)("AccountPayablePartyID")
                Dr("ProductTypeId") = dt.Rows(x)("ProductTypeId")
                Dr("UOMID") = dt.Rows(x)("UOMID")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("IssueTypeID") = dt.Rows(x)("IssueTypeID")
                Dr("IssueType") = dt.Rows(x)("IssueType")
                Dr("CurrencyId") = dt.Rows(x)("CurrencyId")
                Dr("Currency") = dt.Rows(x)("Currency")
                Dr("ExchangeRate") = dt.Rows(x)("ExchangeRate")
                Dr("ProcessItemCodeID") = dt.Rows(x)("ProcessItemCodeID")
                Dr("ProcessItemCode") = dt.Rows(x)("ProcessItemCodee")
                Dr("ProcessItemTypeID") = dt.Rows(x)("ProcessItemTypeID")
                Dr("ProcessItemType") = dt.Rows(x)("ItemClassName")
                Dr("ProcessItemNameID") = dt.Rows(x)("ProcessItemNameID")
                Dr("ProcessItemName") = dt.Rows(x)("ProcessItemName")
                Dr("ProcessQuality") = dt.Rows(x)("ProcessQuality")
                Dr("ProcessShade") = dt.Rows(x)("ProcessShade")
                Dr("ProcessQuantity") = dt.Rows(x)("ProcessQuantity")
                Dr("ProcessSalesTax") = dt.Rows(x)("ProcessSalesTax")
                Dr("FreshQty") = dt.Rows(x)("FreshQty")
                Dr("BQualityQty") = dt.Rows(x)("BQualityQty")
                Dr("SRNoID") = dt.Rows(x)("SRNoID")
                Dr("SRNo") = dt.Rows(x)("SRNo")
                Dr("DeliveryDate") = dt.Rows(x)("DeliveryDatee")
                Dr("PORate") = dt.Rows(x)("PORate")
                Dr("Remarks") = dt.Rows(x)("DetailRemarks").Replace("&nbsp;", "")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
            btnSave.Visible = True
            btnCancel.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductTypeByJobOrdervise()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetFabricItemTypejOBWISENewCost(cmbJobNo.SelectedValue)
        cmbProductType.DataSource = dt
        cmbProductType.DataTextField = "ItemClassName"
        cmbProductType.DataValueField = "IMSItemClassID"
        cmbProductType.DataBind()
    End Sub
    Sub BindProductNameByJobordervise(ByVal ItemCode As String)
        Try
            Dim dt As DataTable
            dt = objProcessOrderMst.GetItemNameFabricCostNew(cmbJobNo.SelectedValue, cmbProductType.SelectedValue)
            cmbproduct.DataSource = dt
            cmbproduct.DataTextField = "ItemName"
            cmbproduct.DataValueField = "IMSItemID"
            cmbproduct.DataBind()
            cmbproduct.Items.Insert(0, New ListItem("Select", "0"))
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
                btnSave.Visible = True
                btnCancel.Visible = True
            Else
                btnSave.Visible = False
                btnCancel.Visible = True
                dgProductdetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindItemUnitbujoborderwise(ByVal ItemID As Long)
        Try
            Dim dt As DataTable
            dt = objProcessOrderMst.GetQtyandUnitByJobwiseFabricNewCostNEWWWWW(ItemID, cmbJobNo.SelectedValue)
            If dt.Rows.Count > 0 Then
                lblCheck.Text = dt.Rows(0)("Joborderid")
            Else
                lblCheck.Text = 0
            End If
            Dim dtCheck As DataTable = objProcessOrderMst.CheckForPOFabricWise(lblCheck.Text, ItemID)
            Dim dtItem As DataTable = objProcessOrderMst.CheckQuality(ItemID)
            If dtCheck.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("P.O. Already Have Created For This Item")
                txtrate.Text = ""
                txtQuantity.Text = ""
                txtGrossAmount.Text = ""
                txtDiscAmount.Text = ""
                txtValueExcloudeST.Text = ""
                txtSalesTaxAmount.Text = ""
                txtNetAmount.Text = ""
                txtQuality.Text = ""
                txtColor.Text = ""
                txtSize.Text = ""
                txtStyle.Text = ""
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If dt.Rows.Count > 0 Then
                    txtrate.Text = dt.Rows(0)("Unitrate").ToString
                    txtQuantity.Text = dt.Rows(0)("QTY").ToString
                    txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                    txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                    txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                    txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                    txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                    If dtItem.Rows.Count > 0 Then
                        txtQuality.Text = dtItem.Rows(0)("Quality")
                    Else
                        txtQuality.Text = "N/A"
                    End If
                    txtExRate.Text = dt.Rows(0)("ExchangeRate").ToString
                    txtColor.Text = " "
                    txtSize.Text = " "
                    txtStyle.Text = dt.Rows(0)("Style").ToString
                    cmbCurrencys.SelectedValue = dt.Rows(0)("CurrencyId")
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim LastVoucherNo As String = objProcessOrderMst.GetLastVoucherNoForProcessOrder(yearP)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0000001"
            Else
                LastCode = LastVoucherNo.Substring(6, 7)
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
            VoucherNo = "PR" & "/" & year & "" & "/" & LastCode
            txtPurchaseOrderNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("ProcessOrderDtlID", GetType(Long))
                .Columns.Add("DeptDatabaseName", GetType(String))
                .Columns.Add("DeptDatabaseId", GetType(String))
                .Columns.Add("ItemId", GetType(String))
                .Columns.Add("ProductType", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("Quality", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Weight", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("GrossAmount", GetType(String))
                .Columns.Add("DiscPercent", GetType(String))
                .Columns.Add("DiscAmount", GetType(String))
                .Columns.Add("ValExcloudSalesTax", GetType(String))
                .Columns.Add("SalesTaxPercentage", GetType(String))
                .Columns.Add("SalesTaxAmount", GetType(String))
                .Columns.Add("NetAmount", GetType(String))
                .Columns.Add("InvoiceQTY", GetType(String))
                .Columns.Add("UOM", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("PartyAccount", GetType(String))
                .Columns.Add("AccountPayablePartyID", GetType(String))
                .Columns.Add("ProductTypeId", GetType(String))
                .Columns.Add("UOMID", GetType(String))
                .Columns.Add("IssueTypeID", GetType(String))
                .Columns.Add("IssueType", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("CurrencyId", GetType(String))
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("ExchangeRate", GetType(String))
                .Columns.Add("ProcessItemCodeID", GetType(String))
                .Columns.Add("ProcessItemCode", GetType(String))
                .Columns.Add("ProcessItemTypeID", GetType(String))
                .Columns.Add("ProcessItemType", GetType(String))
                .Columns.Add("ProcessItemNameID", GetType(String))
                .Columns.Add("ProcessItemName", GetType(String))
                .Columns.Add("ProcessQuality", GetType(String))
                .Columns.Add("ProcessShade", GetType(String))
                .Columns.Add("ProcessQuantity", GetType(String))
                .Columns.Add("ProcessSalesTax", GetType(String))
                .Columns.Add("SRNoID", GetType(String))
                .Columns.Add("SRNo", GetType(String))
                .Columns.Add("FreshQty", GetType(String))
                .Columns.Add("BQualityQty", GetType(String))
                .Columns.Add("DeliveryDate", GetType(String))
                .Columns.Add("PORate", GetType(String))
                .Columns.Add("Remarks", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        If lblPOdetailid.Text = "" Then
            Dr("ProcessOrderDtlID") = 0
        Else
            Dr("ProcessOrderDtlID") = lblPOdetailid.Text
        End If
        If txtRemarksDetail.Text = "" Then
            Dr("Remarks") = ""
        Else
            Dr("Remarks") = txtRemarksDetail.Text.ToUpper
        End If
        Dr("DeptDatabaseName") = cmbFrom.SelectedItem.Text
        Dr("DeptDatabaseId") = cmbFrom.SelectedValue
        Dr("ItemId") = cmbproduct.SelectedValue
        Dr("ProductType") = cmbProductType.SelectedItem.Text
        Dr("ProductTypeId") = cmbProductType.SelectedValue
        Dr("ItemName") = cmbproduct.SelectedItem.Text
        If txtQuality.Text = "" Then
            Dr("Quality") = "N/A"
        Else
            Dr("Quality") = txtQuality.Text
        End If
        Dr("Quantity") = txtQuantity.Text
        If txtWeight.Text = "" Then
            Dr("Weight") = 0
        Else
            Dr("Weight") = txtWeight.Text
        End If
        If txtrate.Text = "" Then
            Dr("Rate") = 0
        Else
            Dr("Rate") = txtrate.Text
        End If
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
        Dr("NetAmount") = txtNetAmount.Text
        If lblInvoiceQTY.Text = "" Then
            Dr("InvoiceQTY") = 0
        Else
            Dr("InvoiceQTY") = lblInvoiceQTY.Text
        End If
        Dr("UOM") = cmbItemunit.SelectedItem.Text
        Dr("UOMID") = cmbItemunit.SelectedValue
        If txtSize.Text = "" Then
            Dr("Size") = "N/A"
        Else
            Dr("Size") = txtSize.Text
        End If
        If txtColor.Text = "" Then
            Dr("Color") = "N/A"
        Else
            Dr("Color") = txtColor.Text
        End If
        Dr("PartyAccount") = txtPartyAccount.Text
        Dr("AccountPayablePartyID") = lblPartyid.Text
        If txtStyle.Text = "" Then
            Dr("Style") = "N/A"
        Else
            Dr("Style") = txtStyle.Text
        End If
        Dr("CurrencyId") = cmbCurrencys.SelectedValue
        Dr("Currency") = cmbCurrencys.SelectedItem.Text
        If txtExRate.Text = "" Then
            Dr("ExchangeRate") = "0"
        Else
            Dr("ExchangeRate") = txtExRate.Text
        End If
        Dr("IssueType") = cmbIssueType.SelectedItem.Text
        Dr("IssueTypeID") = cmbIssueType.SelectedValue
        Dr("ProcessItemCodeID") = lblIssueCode.Text
        Dr("ProcessItemCode") = txtIssueCode.Text
        Dr("ProcessItemTypeID") = cmbProcessType.SelectedValue
        Dr("ProcessItemType") = cmbProcessType.SelectedItem.Text
        Dr("ProcessItemNameID") = cmbProcessItemName.SelectedValue
        Dr("ProcessItemName") = cmbProcessItemName.SelectedItem.Text
        Dr("ProcessQuality") = txtProcessQuality.Text
        Dr("ProcessShade") = txtItemShade.Text
        Dr("ProcessQuantity") = txtQuantity.Text
        Dr("ProcessSalesTax") = txtSalesTaxPercentage.Text
        If cmbJobNo.SelectedValue = "0" Then
            Dr("SRNoID") = 0
        Else
            Dr("SRNoID") = cmbJobNo.SelectedValue
        End If
        If cmbJobNo.SelectedValue = "0" Then
            Dr("SRNo") = ""
        Else
            Dr("SRNo") = cmbJobNo.SelectedItem.Text
        End If
        If txtFreshQty.Text = "" Then
            Dr("FreshQty") = 0
        Else
            Dr("FreshQty") = txtFreshQty.Text
        End If
        If txtBQualityQty.Text = "" Then
            Dr("BQualityQty") = 0
        Else
            Dr("BQualityQty") = txtBQualityQty.Text
        End If
        Dr("DeliveryDate") = txtDeleiveryDate.Text
        If txtPORate.Text = "" Then
            Dr("PORate") = 0
        Else
            Dr("PORate") = txtPORate.Text
        End If
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Sub ClearControls()
        TXTCodeEntry.Text = ""
        txtQuality.Text = ""
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
        txtExRate.Text = ""
        txtFreshQty.Text = ""
        txtBQualityQty.Text = ""
        txtDeleiveryDate.Text = ""
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ProcessOrderView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbproduct.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Product Select.")
            ElseIf txtQuality.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quality Empty.")
            ElseIf txtQuantity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Qty Empty.")
            ElseIf txtrate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Rate Empty.")
            ElseIf txtdiscPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("disc % Empty.")
            ElseIf txtSalesTaxPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("S.T. % Empty.")
            ElseIf txtPartyAccount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Party Account. % Empty.")
            ElseIf txtDeleiveryDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Delivery Date.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
                ClearControls()
                btnSave.Visible = True
                btnCancel.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbProductType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProductType.SelectedIndexChanged
        Try
            If cmbProductType.SelectedItem.Text = "EMBROIDERY" Then
                lblname.Text = "Bill No."
            Else
                lblname.Text = "Quality:"
            End If
            If cmbJobNo.SelectedValue > 0 Then
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
            Else
                BindProductName(cmbProductType.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        Try
            If ProcessOrderMstID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) + (Val(txtDiscAmount.Text))
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtdiscPercentage.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtdiscPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdiscPercentage.TextChanged
        Try
            If ProcessOrderMstID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
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
            If ProcessOrderMstID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If ProcessOrderMstID > 0 Then
                If txtPurchaseOrderNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Purchase Order No Not Empty.")
            
                ElseIf dgProductdetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                Else
                    SaveMaster()
                    SaveDetail()
                    Response.Redirect("ProcessOrderView.aspx")
                End If
            Else
                Dim PONO As String = objProcessOrderMst.CheckPONOExist(txtPurchaseOrderNo.Text)
                If PONO = "" Then
                    If txtPurchaseOrderNo.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Purchase Order No Not Empty.")
                    ElseIf txtPartyAccount.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PartyAccount Not Empty.")
                 
                    ElseIf dgProductdetail.Items.Count = 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                    ElseIf cmbIssueType.SelectedValue = 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Issue Type")
                    Else
                        SaveMaster()
                        SaveDetail()
                        Response.Redirect("ProcessOrderView.aspx")
                    End If
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PONO: (" & txtPurchaseOrderNo.Text & "). Already Exist.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveMaster()
        Try
            With objProcessOrderMst
                If ProcessOrderMstID > 0 Then
                    .ProcessOrderMstID = ProcessOrderMstID
                Else
                    .ProcessOrderMstID = 0
                End If
                .PONo = txtPurchaseOrderNo.Text
                .CreationDate = txtCreationDate.Text
                .POTypeID = cmbPOType.SelectedValue
                If txtPartyRef.Text = "" Then
                    .PartyRef = "N/A"
                Else
                    .PartyRef = txtPartyRef.Text
                End If
                If txtcomment.Text = "" Then
                    .Comments = "N/A"
                Else
                    .Comments = txtcomment.Text
                End If
                .Sample = txtSample.Text
                .Packing = txtPacking.Text
                .Inspection = txtInspection.Text
                .CEOApproval = 1
                .FabricPOrder = 1
                If txtPayMode.Text = "" Then
                    .PayMode = "N/A"
                Else
                    .PayMode = txtPayMode.Text
                End If
                If txtQtyJOWise.Text = "" Then
                    .TotalQty = 0
                Else
                    .TotalQty = txtQtyJOWise.Text
                End If
                If userid = 241 Then
                    .FabricStatus = 1
                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    .FabricStatus = 1
                Else
                    .FabricStatus = 0
                End If
                If TXTInditexPONo.Text = "" Then
                    .InditexPONo = ""
                Else
                    .InditexPONo = TXTInditexPONo.Text.ToUpper
                End If
                If txtConsumerAge.Text = "" Then
                    .ConsumerAge = ""
                Else
                    .ConsumerAge = txtConsumerAge.Text.ToUpper
                End If
                .SalesContractNo = TXTSalesContractNo.Text.ToUpper
                .CodeEntry = TXTCodeEntry.Text.ToUpper
                .Remarks = txtRemarks.Text.ToUpper
                .SaveProcessOrderMst()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveDetail()
        Try
            Dim x As Integer
            For x = 0 To dgProductdetail.Items.Count - 1
                With objProcessOrderDtl
                    .ProcessOrderDtlID = dgProductdetail.Items(x).Cells(0).Text
                    If ProcessOrderMstID > 0 Then
                        .ProcessOrderMstID = ProcessOrderMstID
                    Else
                        .ProcessOrderMstID = objProcessOrderMst.GetID
                    End If
                    .DeptDatabaseId = dgProductdetail.Items(x).Cells(25).Text
                    .ItemId = dgProductdetail.Items(x).Cells(1).Text
                    .Quality = dgProductdetail.Items(x).Cells(6).Text
                    .Quantity = dgProductdetail.Items(x).Cells(7).Text
                    .Weight = dgProductdetail.Items(x).Cells(9).Text
                    .Rate = dgProductdetail.Items(x).Cells(10).Text
                    .GrossAmount = dgProductdetail.Items(x).Cells(11).Text
                    .DiscPercent = dgProductdetail.Items(x).Cells(12).Text
                    .DiscAmount = dgProductdetail.Items(x).Cells(13).Text
                    .ValExcloudSalesTax = dgProductdetail.Items(x).Cells(14).Text
                    .SalesTaxPercentage = dgProductdetail.Items(x).Cells(15).Text
                    .SalesTaxAmount = dgProductdetail.Items(x).Cells(16).Text
                    .NetAmount = dgProductdetail.Items(x).Cells(17).Text
                    .Size = dgProductdetail.Items(x).Cells(18).Text
                    .Color = dgProductdetail.Items(x).Cells(19).Text
                    .InvoiceQTY = dgProductdetail.Items(x).Cells(24).Text
                    .AccountPayablePartyID = dgProductdetail.Items(x).Cells(26).Text
                    .PartyAccount = dgProductdetail.Items(x).Cells(2).Text
                    .ProductTypeId = dgProductdetail.Items(x).Cells(27).Text
                    .UOMID = dgProductdetail.Items(x).Cells(28).Text
                    .Style = dgProductdetail.Items(x).Cells(20).Text
                    .ProductType = dgProductdetail.Items(x).Cells(4).Text
                    .CurrencyId = dgProductdetail.Items(x).Cells(21).Text
                    .Currency = dgProductdetail.Items(x).Cells(22).Text
                    .ExchangeRate = dgProductdetail.Items(x).Cells(23).Text
                    .IssueTypeID = dgProductdetail.Items(x).Cells(29).Text
                    .ProcessItemCodeID = dgProductdetail.Items(x).Cells(31).Text
                    .ProcessItemTypeID = dgProductdetail.Items(x).Cells(33).Text
                    .ProcessItemNameID = dgProductdetail.Items(x).Cells(35).Text
                    .ProcessQuality = dgProductdetail.Items(x).Cells(37).Text
                    .ProcessShade = dgProductdetail.Items(x).Cells(38).Text
                    .ProcessQuantity = dgProductdetail.Items(x).Cells(39).Text
                    .ProcessSalesTax = dgProductdetail.Items(x).Cells(40).Text
                    .SRNoID = dgProductdetail.Items(x).Cells(42).Text
                    .FreshQty = dgProductdetail.Items(x).Cells(43).Text
                    .BQualityQty = dgProductdetail.Items(x).Cells(44).Text
                    .DeliveryDate = dgProductdetail.Items(x).Cells(45).Text
                    .PORate = dgProductdetail.Items(x).Cells(46).Text
                    .Remarks = dgProductdetail.Items(x).Cells(47).Text.Replace("&nbsp;", "")
                    .SaveProcessOrderDtl()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPartyAccount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartyAccount.TextChanged
        Try
            If txtPartyAccount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid SupplierName.")
            ElseIf txtPartyAccount.Text <> "" Then
                dtAC = objSupplier.gETsUPPLIERpo(txtPartyAccount.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    lblPartyid.Text = dtAC.Rows(0)("SupplierdatabaseID")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("SupplierName Name Not Exist")
                    lblPartyid.Text = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Try
            If ProcessOrderMstID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = (txtDiscAmount.Text) + Val(txtGrossAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtWeight.Focus()
            Else
                If txtWeight.Text = "" Then
                    txtWeight.Text = 0
                ElseIf txtrate.Text = "" Then
                    txtrate.Text = 0
                ElseIf txtdiscPercentage.Text = "" Then
                    txtdiscPercentage.Text = 0
                ElseIf txtDiscAmount.Text = "" Then
                    txtDiscAmount.Text = 0
                ElseIf txtSalesTaxPercentage.Text = "" Then
                    txtSalesTaxPercentage.Text = 0
                ElseIf txtSalesTaxAmount.Text = "" Then
                    txtSalesTaxAmount.Text = 0
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
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtWeight.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbproduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.SelectedIndexChanged
        Try
            If cmbJobNo.SelectedValue > 0 Then
                BindItemUnitbujoborderwise(cmbproduct.SelectedValue)
                Dim Dte As DataTable = objProcessOrderMst.GetItemFabricNewForProcessGetRate(cmbproduct.SelectedValue)
                If Dte.Rows.Count > 0 Then
                    txtPORate.Text = Dte.Rows(0)("Rate")
                End If
            Else
                Dim dt As DataTable = objProcessOrderMst.GetFabricConAndCompositionFromItemDatabase(cmbproduct.SelectedValue)
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = dt.Rows(0)("ItemQuality")
                txtColor.Text = dt.Rows(0)("Shade")
                txtSize.Text = "N/A"
                Dim Dte As DataTable = objProcessOrderMst.GetItemFabricNewForProcessGetRate(cmbproduct.SelectedValue)
                If Dte.Rows.Count > 0 Then
                    txtPORate.Text = Dte.Rows(0)("Rate")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTableold(ByVal dtrowNo As Long)
        Try
            BindProductType()
            BindStore()
            lblPOdetailid.Text = dtDetail.Rows(dtrowNo)("ProcessOrderDtlID")
            cmbFrom.SelectedValue = dtDetail.Rows(dtrowNo)("DeptDatabaseId")
            cmbFrom.SelectedItem.Text = dtDetail.Rows(dtrowNo)("DeptDatabaseName")
            cmbProductType.SelectedValue = dtDetail.Rows(dtrowNo)("ProductTypeId")
            cmbproduct.SelectedValue = dtDetail.Rows(dtrowNo)("ItemId")
            cmbItemunit.SelectedValue = dtDetail.Rows(dtrowNo)("UOMID")
            txtQuality.Text = dtDetail.Rows(dtrowNo)("Quality")
            txtQuantity.Text = dtDetail.Rows(dtrowNo)("Quantity")
            txtWeight.Text = dtDetail.Rows(dtrowNo)("Weight")
            txtrate.Text = dtDetail.Rows(dtrowNo)("Rate")
            txtGrossAmount.Text = dtDetail.Rows(dtrowNo)("GrossAmount")
            txtdiscPercentage.Text = dtDetail.Rows(dtrowNo)("DiscPercent")
            txtDiscAmount.Text = dtDetail.Rows(dtrowNo)("DiscAmount")
            txtValueExcloudeST.Text = dtDetail.Rows(dtrowNo)("ValExcloudSalesTax")
            txtSalesTaxPercentage.Text = dtDetail.Rows(dtrowNo)("SalesTaxPercentage")
            txtSalesTaxAmount.Text = dtDetail.Rows(dtrowNo)("SalesTaxAmount")
            txtNetAmount.Text = dtDetail.Rows(dtrowNo)("NetAmount")
            txtPartyAccount.Text = dtDetail.Rows(dtrowNo)("PartyAccount")
            lblPartyid.Text = dtDetail.Rows(dtrowNo)("AccountPayablePartyID")
            txtColor.Text = dtDetail.Rows(dtrowNo)("Color")
            txtQuality.Text = dtDetail.Rows(dtrowNo)("Quality")
            txtSize.Text = dtDetail.Rows(dtrowNo)("Size")
            txtStyle.Text = dtDetail.Rows(dtrowNo)("Style")
            txtFreshQty.Text = dtDetail.Rows(dtrowNo)("FreshQty")
            txtBQualityQty.Text = dtDetail.Rows(dtrowNo)("BQualityQty")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPOType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPOType.SelectedIndexChanged
        Try
            If cmbPOType.SelectedValue = 1 Then
                cmbJobNo.Enabled = False
                cmbJobNo.SelectedValue = 0
            Else
                cmbJobNo.Enabled = True
            End If
            If cmbJobNo.SelectedValue > 0 Then
                BindProductTypeByJobOrdervise()
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
                Dim dt As DataTable = objProcessOrderMst.GetItemTypejOBWISENewCostNEWW(cmbJobNo.SelectedValue)
                Dim dtItem As DataTable = objProcessOrderMst.GetItemNameSearch(cmbJobNo.SelectedValue)
                If dt.Rows.Count > 0 Then
                    Dim JOQTY As String = dt.Rows(0)("Quantity")
                    txtQtyJOWise.Text = JOQTY
                Else
                End If
            Else
                ClearControls()
                BindProductType()
                BindProductName(cmbProductType.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbJobNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Try
            If cmbJobNo.SelectedValue > 0 Then
                BindProductTypeByJobOrdervise()
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
                Dim dt As DataTable = objProcessOrderMst.GetItemTypejOBWISENewCostNEWW(cmbJobNo.SelectedValue)
                Dim dtItem As DataTable = objProcessOrderMst.GetItemNameSearch(cmbJobNo.SelectedValue)
                If dt.Rows.Count > 0 Then
                    Dim JOQTY As String = dt.Rows(0)("Quantity")
                    txtQtyJOWise.Text = JOQTY
                Else
                End If
            Else
                ClearControls()
                BindProductType()
                BindProductName(cmbProductType.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dt As DataTable
            dt = objProcessOrderMst.GetItemFabricNew(TXTCodeEntry.Text)
            cmbproduct.DataSource = dt
            cmbproduct.DataTextField = "ItemName"
            cmbproduct.DataValueField = "IMSItemID"
            cmbproduct.DataBind()
            cmbproduct.SelectedValue = dt.Rows(0)("ImsItemID")
            If cmbJobNo.SelectedValue > 0 Then
                BindItemUnitbujoborderwise(cmbproduct.SelectedValue)
                Dim dttt As DataTable
                dttt = objProcessOrderMst.GetItemFabricNewForProcess(TXTCodeEntry.Text)
                Dim ItemId As Long = dttt.Rows(0)("IMSItemID")
                Dim Dte As DataTable = objProcessOrderMst.GetItemFabricNewForProcessGetRate(ItemId)
                If Dte.Rows.Count > 0 Then
                    txtPORate.Text = Dte.Rows(0)("Rate")
                End If
            Else
                Dim dtt As DataTable = objProcessOrderMst.GetFabricConAndCompositionFromItemDatabase(cmbproduct.SelectedValue)
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = dt.Rows(0)("ItemQuality") '"N/A"
                txtColor.Text = dt.Rows(0)("Shade") '"N/A"
                txtSize.Text = "N/A"
                Dim dttt As DataTable
                dttt = objProcessOrderMst.GetItemFabricNewForProcess(TXTCodeEntry.Text)
                Dim ItemId As Long = dttt.Rows(0)("IMSItemID")
                Dim Dte As DataTable = objProcessOrderMst.GetItemFabricNewForProcessGetRate(ItemId)
                If Dte.Rows.Count > 0 Then
                    txtPORate.Text = Dte.Rows(0)("Rate")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindIssueType()
        Try
            Dim dtIssueType As DataTable
            dtIssueType = objIssueType.BindIssueType()
            cmbIssueType.DataSource = dtIssueType
            cmbIssueType.DataTextField = "IssueType"
            cmbIssueType.DataValueField = "IssueTypeID"
            cmbIssueType.DataBind()
            cmbIssueType.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnAddIssueType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddIssueType.Click
        Try
            PnlIssueTypetxt.Visible = True
            PnlIssueTypeCmb.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSaveIssueType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveIssueType.Click
        Try
            If txtIssueType.Text = "" Then
                With objIssueType
                    .IssueTypeID = 0
                    .IssueType = txtIssueType.Text
                End With
            Else
                With objIssueType
                    .IssueTypeID = 0
                    .IssueType = txtIssueType.Text
                    .SaveIssueType()
                End With
                txtIssueType.Text = ""
            End If
        Catch ex As Exception
        End Try
        PnlIssueTypetxt.Visible = False
        PnlIssueTypeCmb.Visible = True
        BindIssueType()
    End Sub
    Protected Sub txtIssueCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtIssueCode.TextChanged
        Try
            Dim dt As DataTable = objProcessOrderMst.BindIssue(txtIssueCode.Text)
            If dt.Rows.Count > 0 Then
                lblIssueCode.Text = dt.Rows(0)("IMSItemID")
                BindProcessItemType()
                BindProcessItemName()
                Dim dtq As DataTable = objProcessOrderMst.GetProcessItemQuality(lblIssueCode.Text)
                txtProcessQuality.Text = dt.Rows(0)("ItemQuality")
                txtItemShade.Text = dt.Rows(0)("Shade")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbProcessType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProcessType.SelectedIndexChanged
    End Sub
    Protected Sub dgProductdetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductdetail.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim PoDetailId As Integer = dgProductdetail.Items(e.Item.ItemIndex).Cells(0).Text
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
            BindProductType()
            BindStore()
            BindStore()
            BindJobOrder()
            bindItemUnit()
            bindCurrency()
            BindIssueType()
            lblPOdetailid.Text = dtDetail.Rows(dtrowNo)("ProcessOrderDtlID")
            cmbFrom.SelectedValue = dtDetail.Rows(dtrowNo)("DeptDatabaseId")
            lblIssueCode.Text = dtDetail.Rows(dtrowNo)("ProcessItemCodeID")
            txtIssueCode.Text = dtDetail.Rows(dtrowNo)("ProcessItemCode")
            Dim dt As DataTable
            dt = objProcessOrderMst.GetItemFabricNew(TXTCodeEntry.Text)
            cmbproduct.DataSource = dt
            cmbproduct.DataTextField = "ItemName"
            cmbproduct.DataValueField = "IMSItemID"
            cmbproduct.DataBind()
            cmbProductType.SelectedValue = dtDetail.Rows(dtrowNo)("ProductTypeId")
            cmbproduct.SelectedValue = dtDetail.Rows(dtrowNo)("ItemID")
            Dim Dte As DataTable = objProcessOrderMst.GetItemFabricNewForProcessGetRate(cmbproduct.SelectedValue)
            If Dte.Rows.Count > 0 Then
                txtPORate.Text = Dte.Rows(0)("Rate")
            End If
            cmbItemunit.SelectedValue = dtDetail.Rows(dtrowNo)("UOMID")
            txtQuality.Text = dtDetail.Rows(dtrowNo)("Quality")
            txtQuantity.Text = dtDetail.Rows(dtrowNo)("Quantity")
            txtWeight.Text = dtDetail.Rows(dtrowNo)("Weight")
            txtrate.Text = dtDetail.Rows(dtrowNo)("Rate")
            txtGrossAmount.Text = dtDetail.Rows(dtrowNo)("GrossAmount")
            txtdiscPercentage.Text = dtDetail.Rows(dtrowNo)("DiscPercent")
            txtDiscAmount.Text = dtDetail.Rows(dtrowNo)("DiscAmount")
            txtValueExcloudeST.Text = dtDetail.Rows(dtrowNo)("ValExcloudSalesTax")
            txtSalesTaxPercentage.Text = dtDetail.Rows(dtrowNo)("SalesTaxPercentage")
            txtSalesTaxAmount.Text = dtDetail.Rows(dtrowNo)("SalesTaxAmount")
            txtNetAmount.Text = dtDetail.Rows(dtrowNo)("NetAmount")
            lblInvoiceQTY.Text = dtDetail.Rows(dtrowNo)("InvoiceQTY")
            txtPartyAccount.Text = dtDetail.Rows(dtrowNo)("PartyAccount")
            lblPartyid.Text = dtDetail.Rows(dtrowNo)("AccountPayablePartyID")
            txtColor.Text = dtDetail.Rows(dtrowNo)("Color")
            txtSize.Text = dtDetail.Rows(dtrowNo)("Size")
            txtStyle.Text = dtDetail.Rows(dtrowNo)("Style")
            cmbCurrencys.SelectedValue = dtDetail.Rows(dtrowNo)("CurrencyId")
            txtExRate.Text = dtDetail.Rows(dtrowNo)("ExchangeRate")
            cmbIssueType.SelectedValue = dtDetail.Rows(dtrowNo)("IssueTypeID")
            txtFreshQty.Text = dtDetail.Rows(dtrowNo)("FreshQty")
            BindProcessItemTypeForEditCase()
            cmbProcessType.SelectedValue = dtDetail.Rows(dtrowNo)("ProcessItemTypeID")
            BindProcessItemName()
            cmbProcessItemName.SelectedValue = dtDetail.Rows(dtrowNo)("ProcessItemNameID")
            txtProcessQuality.Text = dtDetail.Rows(dtrowNo)("ProcessQuality")
            txtItemShade.Text = dtDetail.Rows(dtrowNo)("ProcessShade")
            txtQuantity.Text = dtDetail.Rows(dtrowNo)("ProcessQuantity")
            txtSalesTaxPercentage.Text = dtDetail.Rows(dtrowNo)("ProcessSalesTax")
            cmbJobNo.SelectedValue = dtDetail.Rows(dtrowNo)("SRNoID")
            txtFreshQty.Text = dtDetail.Rows(dtrowNo)("FreshQty")
            txtBQualityQty.Text = dtDetail.Rows(dtrowNo)("BQualityQty")
            txtDeleiveryDate.Text = dtDetail.Rows(dtrowNo)("DeliveryDate")
            cmbJobNo.Enabled = True
            txtRemarksDetail.Text = dtDetail.Rows(dtrowNo)("Remarks")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProcessItemTypeForEditCase()
        Dim dt As DataTable
        dt = objProcessOrderMst.GetProcessItemForEditCasse()
        cmbProcessType.DataSource = dt
        cmbProcessType.DataTextField = "ItemClassName"
        cmbProcessType.DataValueField = "IMSItemClassID"
        cmbProcessType.DataBind()
    End Sub
End Class
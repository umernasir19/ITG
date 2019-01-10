Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class FabricPurchaseOrderEntry
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim objPODetail As New PODetail
    Dim objSupplier As New SupplierDataBase
    Dim objgeneralCode As New GeneralCode
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim POID, JoborderID As Long
    Dim dtAC As DataTable
    Dim AccountCode As String
    Dim userid As Long
    Dim objPORecvMaster As New PORecvMaster
    Dim objSizeRange As New SizeRange
    Dim ObjDPIMst As New DPIMst
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim objSeason As New SeasonDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lPOID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindPOType()
            BindProductType()
            BindProductName(cmbProductType.SelectedValue)
            BindStore()
            BindSeasonname()
            bindItemUnit()
            bindCurrency()
            Session("dtDetail") = Nothing
            Session("PoTypeId") = Nothing
            If cmbPOType.SelectedValue = 1 Then
                cmbseason.Enabled = False
                cmbJobNo.Enabled = False
            Else
                cmbseason.Enabled = True
                cmbJobNo.Enabled = True
            End If
            txtdiscPercentage.Text = 0
            txtSalesTaxPercentage.Text = 0
            txtExRate.Text = 1
            If POID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                VoucherNoGenerateOnLoad()
                txtCreationDate.Text = Date.Now
                btnSave.Text = "Save"
                txtSample.Text = "N/A"
                txtcomment.Text = "N/A"
                txtInspection.Text = "N/A"
                txtPartyRef.Text = "N/A"
                txtPacking.Text = "N/A"
                cmbFrom.SelectedValue = 54
                If userid = 245 Then
                    cmbItemunit.SelectedValue = 7
                Else
                End If
            End If
        End If
        PageHeader("PURCHASE ORDER ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub bindCurrency()
        Dim Dt As DataTable
        Dt = objPOMaster.GetCurrency()
        cmbCurrencys.DataSource = Dt
        cmbCurrencys.DataTextField = "CurrencyName"
        cmbCurrencys.DataValueField = "CurrencyID"
        cmbCurrencys.DataBind()
        cmbCurrencys.DataSource = Dt
    End Sub
    Sub BindPOType()
        Dim dtContractType As DataTable
        dtContractType = objPOMaster.BindContractType()
        cmbPOType.DataSource = dtContractType
        cmbPOType.DataTextField = "ContractType"
        cmbPOType.DataValueField = "ContractTypeID"
        cmbPOType.DataBind()
    End Sub
    Sub BindStore()
        Dim dt As DataTable
        dt = objPOMaster.GetCmbFrom()
        cmbFrom.DataSource = dt
        cmbFrom.DataTextField = "DeptDatabaseName"
        cmbFrom.DataValueField = "DeptDatabaseId"
        cmbFrom.DataBind()
    End Sub
    Sub BindProductTypeByJobOrdervise()
        Dim dt As DataTable
        dt = objPOMaster.GetFabricItemTypejOBWISENewCost(cmbJobNo.SelectedValue)
        cmbProductType.DataSource = dt
        cmbProductType.DataTextField = "ItemClassName"
        cmbProductType.DataValueField = "IMSItemClassID"
        cmbProductType.DataBind()
    End Sub
    Sub BindProductType()
        Dim dt As DataTable
        dt = objPOMaster.GetAllFabric()
        cmbProductType.DataSource = dt
        cmbProductType.DataTextField = "ItemClassName"
        cmbProductType.DataValueField = "IMSItemClassID"
        cmbProductType.DataBind()
    End Sub
    Sub BindProductNameByJobordervise(ByVal ItemCode As String)
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemNameFabricCostNew(cmbJobNo.SelectedValue, cmbProductType.SelectedValue)
            cmbproduct.DataSource = dt
            cmbproduct.DataTextField = "ItemName"
            cmbproduct.DataValueField = "IMSItemID"
            cmbproduct.DataBind()
            cmbproduct.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductName(ByVal ItemCode As String)
        Dim dt As DataTable
        dt = objPOMaster.GetItemFabric(cmbProductType.SelectedValue)
        cmbproduct.DataSource = dt
        cmbproduct.DataTextField = "ItemName"
        cmbproduct.DataValueField = "IMSItemID"
        cmbproduct.DataBind()
        cmbproduct.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub bindItemUnit()
        Dim dt As DataTable
        dt = objPOMaster.GetUOMItem()
        cmbItemunit.DataSource = dt
        cmbItemunit.DataTextField = "Symbol"
        cmbItemunit.DataValueField = "ItemUnitID"
        cmbItemunit.DataBind()
    End Sub
    Sub BindItemUnitbujoborderwise(ByVal ItemID As Long)
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetQtyandUnitByJobwiseFabricNewCostNEWWWWW(ItemID, cmbJobNo.SelectedValue)
            lblCheck.Text = dt.Rows(0)("Joborderid")
            Dim dtCheck As DataTable = objPOMaster.CheckForPOFabricWise(lblCheck.Text, ItemID)
            Dim dtItem As DataTable = objPOMaster.CheckQuality(ItemID)
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
            Dim LastVoucherNo As String = objPOMaster.GetLastVoucherNo(yearP)
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
            VoucherNo = "PO" & "/" & year & "" & "/" & LastCode
            txtPurchaseOrderNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objPOMaster.FabricEditForDigital(POID)
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
            txtPayMode.Text = dt.Rows(0)("PayMode")
            Try
                'If cmbJobNo.SelectedValue > 0 Then
                '    BindProductTypeByJobOrdervise()
                '    cmbProductType.SelectedValue = dt.Rows(0)("ProductTypeId")
                '    BindProductNameByJobordervise(cmbProductType.SelectedValue)
                'Else
                BindProductType()
                cmbProductType.SelectedValue = dt.Rows(0)("ProductTypeId")
                BindProductName(cmbProductType.SelectedValue)
                'End If
            Catch ex As Exception

            End Try
            txtSample.Text = dt.Rows(0)("Sample")
            txtPacking.Text = dt.Rows(0)("Packing")
            txtInspection.Text = dt.Rows(0)("Inspection")
            lblAuditorStatus.Text = dt.Rows(0)("AuditorStatus")
            lblAuditorID.Text = dt.Rows(0)("AuditorID")
            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("PoDetailId", GetType(Long))
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
                    .Columns.Add("JoborderID", GetType(Long))
                    .Columns.Add("SrNo", GetType(String))
                    .Columns.Add("FreshQty", GetType(String))
                    .Columns.Add("BQualityQty", GetType(String))
                    .Columns.Add("Remarks", GetType(String))
                    .Columns.Add("DeliveryDate", GetType(String))
                    .Columns.Add("ClearanceCharges", GetType(String))
                    .Columns.Add("SeasonDatabaseID", GetType(Long))
                    .Columns.Add("Season", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("PoDetailId") = dt.Rows(x)("PoDetailId")
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
                Dr("CurrencyId") = dt.Rows(x)("CurrencyId")
                Dr("Currency") = dt.Rows(x)("Currency")
                Dr("ExchangeRate") = dt.Rows(x)("ExchangeRate")
                Dr("JoborderID") = dt.Rows(x)("JoborderID")
                Dr("SrNo") = dt.Rows(x)("SrNo")
                Dr("FreshQty") = dt.Rows(x)("FreshQty")
                Dr("BQualityQty") = dt.Rows(x)("BQualityQty")
                Dr("Remarks") = dt.Rows(x)("DetailRemarks").Replace("&nbsp;", "")
                Dr("DeliveryDate") = dt.Rows(x)("DeliveryDatee")
                Dr("ClearanceCharges") = dt.Rows(x)("ClearanceCharges")
                Dr("SeasonDatabaseID") = dt.Rows(x)("SeasonDatabaseID")
                Dim dtSea As DataTable
                dtSea = objSeason.GetSeasonDataBaseForEdit(dt.Rows(x)("SeasonDatabaseID"))
                If dtSea.Rows.Count > 0 Then
                    Dr("Season") = dtSea.Rows(0)("SeasonName")
                Else
                    Dr("Season") = ""
                End If 
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
            btnSave.Visible = True
            btnCancel.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("PoDetailId", GetType(Long))
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
                .Columns.Add("Style", GetType(String))
                .Columns.Add("CurrencyId", GetType(String))
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("ExchangeRate", GetType(String))
                .Columns.Add("JoborderID", GetType(Long))
                .Columns.Add("SrNo", GetType(String))
                .Columns.Add("FreshQty", GetType(String))
                .Columns.Add("BQualityQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("DeliveryDate", GetType(String))
                .Columns.Add("ClearanceCharges", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(Long))
                .Columns.Add("Season", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        If lblPOdetailid.Text = "" Then
            Dr("PoDetailId") = 0
        Else
            Dr("PoDetailId") = lblPOdetailid.Text
        End If
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
            Dr("ExchangeRate") = "1"
        Else
            Dr("ExchangeRate") = txtExRate.Text
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
        If cmbseason.SelectedItem.Text = "Select" Then
            Dr("JoborderID") = 0
        Else
            Dr("JoborderID") = cmbJobNo.SelectedValue
        End If
        If txtRemarksDetail.Text = "" Then
            Dr("Remarks") = ""
        Else
            Dr("Remarks") = txtRemarksDetail.Text.ToUpper
        End If
        Dr("DeliveryDate") = txtDeleiveryDate.Text
        If txtClearanceCharges.Text = "" Then
            Dr("ClearanceCharges") = 0
        Else
            Dr("ClearanceCharges") = txtClearanceCharges.Text
        End If
         
        If cmbseason.SelectedItem.Text = "Select" Then
            Dr("SeasonDatabaseID") = 0
        Else
            Dr("SeasonDatabaseID") = cmbseason.SelectedValue
        End If
        If cmbseason.SelectedItem.Text = "Select" Then
            Dr("Season") = ""
        Else
            Dr("Season") = cmbseason.SelectedItem.Text
        End If

        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
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
    Sub ClearControls()
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
        txtExRate.Text = 1
        txtFreshQty.Text = ""
        txtBQualityQty.Text = ""
        txtClearanceCharges.Text = 0
        cmbproduct.SelectedValue = 0
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("FPurchaseOrderView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbproduct.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Product Select.")
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
            If POID > 0 Then
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
            If POID > 0 Then
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
            If POID > 0 Then
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
            If POID > 0 Then
                If txtPurchaseOrderNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Purchase Order No Not Empty.")
                ElseIf dgProductdetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                Else
                    SaveMaster()
                    SaveDetail()
                    Response.Redirect("FPurchaseOrderView.aspx")
                End If
            Else
                If txtPartyAccount.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PartyAccount Not Empty.")
                ElseIf dgProductdetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                Else
                    SaveMaster()
                    SaveDetail()
                    Response.Redirect("FPurchaseOrderView.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveMaster()
        Try
            With objPOMaster
                If POID > 0 Then
                    .POID = POID
                Else
                    .POID = 0
                End If
                If POID > 0 Then
                Else
                    Dim dt As DataTable = objPOMaster.GetLastVoucherNoAlreadtExist(txtPurchaseOrderNo.Text)
                    If dt.Rows.Count > 0 Then
                        VoucherNoGenerateOnLoad()
                    End If
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
                If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    .FabricStatus = 1
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        .FabricStatus = 1
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                        .FabricStatus = 0
                    End If
                End If
                .GStoreStatus = 0
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
                If lblAuditorStatus.Text = "" Then
                    .AuditorStatus = 0
                Else
                    .AuditorStatus = lblAuditorStatus.Text
                End If
                If lblAuditorID.Text = "" Then
                    .AuditorID = 0
                Else
                    .AuditorID = lblAuditorID.Text
                End If
                .ClosedStatus = 0
                .SavePOMaster()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveDetail()
        Try
            Dim x As Integer
            For x = 0 To dgProductdetail.Items.Count - 1
                With objPODetail
                    .PoDetailId = dgProductdetail.Items(x).Cells(0).Text
                    If POID > 0 Then
                        .POID = POID
                    Else
                        .POID = objPOMaster.GetID
                    End If
                    .ItemId = dgProductdetail.Items(x).Cells(1).Text
                    .PartyAccount = dgProductdetail.Items(x).Cells(2).Text
                    .ProductType = dgProductdetail.Items(x).Cells(3).Text
                    .Quality = dgProductdetail.Items(x).Cells(5).Text
                    .Quantity = dgProductdetail.Items(x).Cells(6).Text
                    .Weight = dgProductdetail.Items(x).Cells(8).Text
                    .Rate = dgProductdetail.Items(x).Cells(9).Text
                    .GrossAmount = dgProductdetail.Items(x).Cells(10).Text
                    .DiscPercent = dgProductdetail.Items(x).Cells(11).Text
                    .DiscAmount = dgProductdetail.Items(x).Cells(12).Text
                    .ValExcloudSalesTax = dgProductdetail.Items(x).Cells(13).Text
                    .SalesTaxPercentage = dgProductdetail.Items(x).Cells(14).Text
                    .SalesTaxAmount = dgProductdetail.Items(x).Cells(15).Text
                    .NetAmount = dgProductdetail.Items(x).Cells(16).Text
                    .Size = dgProductdetail.Items(x).Cells(17).Text
                    .Color = dgProductdetail.Items(x).Cells(18).Text
                    .Style = dgProductdetail.Items(x).Cells(19).Text
                    .CurrencyId = dgProductdetail.Items(x).Cells(20).Text
                    .Currency = dgProductdetail.Items(x).Cells(21).Text
                    .ExchangeRate = dgProductdetail.Items(x).Cells(22).Text
                    .InvoiceQTY = dgProductdetail.Items(x).Cells(23).Text
                    .AccountPayablePartyID = dgProductdetail.Items(x).Cells(24).Text
                    .ProductTypeId = dgProductdetail.Items(x).Cells(25).Text
                    .UOMID = dgProductdetail.Items(x).Cells(26).Text
                    .JoborderID = dgProductdetail.Items(x).Cells(27).Text
                    .FreshQty = dgProductdetail.Items(x).Cells(29).Text
                    .BQualityQty = dgProductdetail.Items(x).Cells(30).Text
                    .Remarks = dgProductdetail.Items(x).Cells(31).Text.Replace("&nbsp;", "")
                    .DeliveryDate = dgProductdetail.Items(x).Cells(32).Text
                    .ClearanceCharges = dgProductdetail.Items(x).Cells(33).Text
                    .SeasonDatabaseID = dgProductdetail.Items(x).Cells(34).Text
                    .SavePODetail()
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
            If POID > 0 Then
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
            Else
                Dim dt As DataTable = objPOMaster.GetFabricConAndCompositionFromItemDatabase(cmbproduct.SelectedValue)
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = dt.Rows(0)("ItemQuality")
                txtColor.Text = dt.Rows(0)("Shade")
                txtSize.Text = "N/A"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgProductdetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductdetail.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim PoDetailId As Integer = dgProductdetail.Items(e.Item.ItemIndex).Cells(0).Text
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            objPOMaster.DeleteDetail(PoDetailId)
                            BindGrid()
                        End If
                    End If
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
            cmbProductType.SelectedValue = dtDetail.Rows(dtrowNo)("ProductTypeId")
            BindStore()
            BindSeasonname()
            If dtDetail.Rows(dtrowNo)("SeasonDatabaseID") > 0 Then
                cmbseason.SelectedValue = dtDetail.Rows(dtrowNo)("SeasonDatabaseID")
                BindSrNo()
            End If
            Try
                If cmbJobNo.SelectedValue > 0 Then
                    BindProductTypeByJobOrdervise()
                    cmbProductType.SelectedValue = dtDetail.Rows(0)("ProductTypeId")
                    BindProductNameByJobordervise(cmbProductType.SelectedValue)
                Else
                    BindProductType()
                    cmbProductType.SelectedValue = dtDetail.Rows(0)("ProductTypeId")
                    BindProductName(cmbProductType.SelectedValue)
                End If
            Catch ex As Exception

            End Try
            lblPOdetailid.Text = dtDetail.Rows(dtrowNo)("PODetailID")
            BindProductName(cmbProductType.SelectedValue)
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
            txtRemarksDetail.Text = dtDetail.Rows(dtrowNo)("Remarks")
            txtDeleiveryDate.Text = dtDetail.Rows(dtrowNo)("DeliveryDate")
            'cmbJobNo.Enabled = True
            txtClearanceCharges.Text = dtDetail.Rows(dtrowNo)("ClearanceCharges")
            
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPOType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPOType.SelectedIndexChanged
        Try
            If cmbPOType.SelectedValue = 1 Then
                cmbJobNo.Enabled = False
                cmbJobNo.SelectedValue = 0
                cmbseason.Enabled = False
            Else
                cmbJobNo.Enabled = True
                cmbseason.Enabled = True
            End If
            If cmbJobNo.SelectedValue > 0 Then
                BindProductTypeByJobOrdervise()
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
                Dim dt As DataTable = objPOMaster.GetItemTypejOBWISENewCostNEWW(cmbJobNo.SelectedValue)
                Dim dtItem As DataTable = objPOMaster.GetItemNameSearch(cmbJobNo.SelectedValue)
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
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Try
            If cmbJobNo.SelectedValue > 0 Then
                BindProductTypeByJobOrdervise()
                BindProductNameByJobordervise(cmbProductType.SelectedValue)
                Dim dt As DataTable = objPOMaster.GetItemTypejOBWISENewCostNEWW(cmbJobNo.SelectedValue)
                Dim dtItem As DataTable = objPOMaster.GetItemNameSearch(cmbJobNo.SelectedValue)
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
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            cmbproduct.DataSource = dt
            cmbproduct.DataTextField = "ItemName"
            cmbproduct.DataValueField = "IMSItemID"
            cmbproduct.DataBind()
            cmbproduct.SelectedValue = dt.Rows(0)("ImsItemID")

            If cmbJobNo.SelectedValue > 0 Then
                BindItemUnitbujoborderwise(cmbproduct.SelectedValue)
            Else
                Dim dtt As DataTable = objPOMaster.GetFabricConAndCompositionFromItemDatabase(cmbproduct.SelectedValue)
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = dt.Rows(0)("ItemQuality") '"N/A"
                txtColor.Text = dt.Rows(0)("Shade") '"N/A"
                txtSize.Text = "N/A"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtClearanceCharges_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClearanceCharges.TextChanged
        Try
            Dim Amout As Decimal = 0
            txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
            Amout = (Val(txtGrossAmount.Text) * Val(txtClearanceCharges.Text) / 100) + Val(txtNetAmount.Text)
            txtNetAmount.Text = Amout
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("SeasonDatabaseID") = cmbseason.SelectedValue
            BindSrNo()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeasonname()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjDPIMst.GetSeasonNameForOrderStatusRpt()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "seasonname"
            cmbSeason.DataValueField = "seasondatabaseId"
            cmbSeason.DataBind()
            cmbseason.Items.Insert(0, New ListItem("Select", "0"))
            'Dim dt As DataTable
            ' dt = ObjIMSItemCategory.GETSRNoAutoSearchForGetSeasonId()
            cmbseason.SelectedIndex = 0 ' dt.Rows(0)("SeasondatabaseID")
            BindSrNo()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            If cmbseason.SelectedIndex = 0 Then
                cmbJobNo.DataSource = Nothing
                cmbJobNo.DataBind()
            Else
                dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbseason.SelectedValue)
                cmbJobNo.DataSource = dtInvoiceNo
                cmbJobNo.DataTextField = "SrNO"
                cmbJobNo.DataValueField = "JobOrderID"
                cmbJobNo.DataBind()
                cmbJobNo.Items.Insert(0, New ListItem("Select", "0"))
            End If
            
        Catch ex As Exception
        End Try
    End Sub
End Class


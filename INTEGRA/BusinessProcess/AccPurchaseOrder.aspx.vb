Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class AccPurchaseOrder
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
    Dim ObjDPIMst As New DPIMst
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim objPORecvMaster As New PORecvMaster
    Dim objSizeRange As New SizeRange
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lPOID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindPOType()
            BindProductType()
            BindStore()
            BindSeasonname()
            bindItemUnit()
            bindCurrency()
            Session("dtDetail") = Nothing
            If cmbPOType.SelectedValue = 1 Then
                cmbseason.Enabled = False
                cmbSrNo.Enabled = False
            Else
                cmbseason.Enabled = True
                cmbSrNo.Enabled = True
            End If
            txtdiscPercentage.Text = 0
            txtSalesTaxPercentage.Text = 0
            txtExRate.Text = 1
            If POID > 0 Then
                EditMode()
                btnSave.Text = "Update"
                If cmbPOType.SelectedValue = 1 Then
                    cmbseason.Enabled = False
                    cmbSrNo.Enabled = False
                Else
                    cmbseason.Enabled = True
                    cmbSrNo.Enabled = True
                End If
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
                Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheckk.Rows(0)("Department") = "Merchandising" Then
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
    Sub BindSeasonname()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjDPIMst.GetSeasonNameForOrderStatusRpt()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "seasonname"
            cmbSeason.DataValueField = "seasondatabaseId"
            cmbSeason.DataBind()
            cmbseason.Items.Insert(0, New ListItem("Select", "0"))
            Dim dt As DataTable
            dt = ObjIMSItemCategory.GETSRNoAutoSearchForGetSeasonId()
            cmbseason.SelectedValue = dt.Rows(0)("SeasondatabaseID")
            BindSrNo()
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
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbseason.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "PONO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub bindCurrency()
        Dim Dt As DataTable
        Dt = objPOMaster.GetCurrency()
        cmbCurrencys.DataSource = Dt
        cmbCurrencys.DataTextField = "CurrencyName"
        cmbCurrencys.DataValueField = "CurrencyID" '    
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
        cmbFrom.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindProductType()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dt As DataTable
            dt = objPOMaster.GetAllAccDP()
            cmbProductType.DataSource = dt
            cmbProductType.DataTextField = "ItemCategoryName"
            cmbProductType.DataValueField = "IMSItemCategoryID"
            cmbProductType.DataBind()
            cmbProductType.Items.Insert(0, New ListItem("Select", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dt As DataTable
            dt = objPOMaster.GetAllAccDPGStore()
            cmbProductType.DataSource = dt
            cmbProductType.DataTextField = "ItemCategoryName"
            cmbProductType.DataValueField = "IMSItemCategoryID"
            cmbProductType.DataBind()
            cmbProductType.Items.Insert(0, New ListItem("Select", "0"))
        End If
    End Sub
    Sub bindItemUnit()
        Dim dt As DataTable
        dt = objPOMaster.GetUOMItem()
        cmbItemunit.DataSource = dt
        cmbItemunit.DataTextField = "Symbol"
        cmbItemunit.DataValueField = "ItemUnitID"
        cmbItemunit.DataBind()
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim LastVoucherNo As String = objPOMaster.GetLastVoucherNoForTest()
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
    Sub VoucherNoGenerateOnLoadOnAlreadyExist()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtCreationDate.Text
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim LastVoucherNo As String = objPOMaster.GetLastVoucherNoForTest()
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
            Dim dt As DataTable = objPOMaster.FabricEditForDigitalAccessories(POID)
            txtPurchaseOrderNo.Text = dt.Rows(0)("PONo")
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            cmbPOType.SelectedValue = dt.Rows(0)("POTypeID")
            txtPartyRef.Text = dt.Rows(0)("PartyRef")
            txtcomment.Text = dt.Rows(0)("Comments")
            TXTInditexPONo.Text = dt.Rows(0)("InditexPONo")
            txtConsumerAge.Text = dt.Rows(0)("ConsumerAge")
            txtRemarks.Text = dt.Rows(0)("MasterRemarks")
                BindProductType()
            txtSample.Text = dt.Rows(0)("Sample")
            txtPacking.Text = dt.Rows(0)("Packing")
            txtInspection.Text = dt.Rows(0)("Inspection")
            TXTSalesContractNo.Text = dt.Rows(0)("SalesContractNo")
            lblAuditorStatus.Text = dt.Rows(0)("AuditorStatus")
            lblAuditorID.Text = dt.Rows(0)("AuditorID")
            txtPayMode.Text = dt.Rows(0)("PayMode")
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
                    .Columns.Add("DeliveryDate", GetType(String))
                    .Columns.Add("Remarks", GetType(String))
                    .Columns.Add("SeasonDatabaseID", GetType(Long))
                    .Columns.Add("Season", GetType(String))
                    .Columns.Add("ClearanceCharges", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("PoDetailId") = dt.Rows(x)("PoDetailId")
                Dr("ItemId") = dt.Rows(x)("ItemId")
                Dr("ProductType") = dt.Rows(x)("ItemCategoryName")
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
                Dr("SrNo") = dt.Rows(x)("PONOo")
                Dr("DeliveryDate") = dt.Rows(x)("DeliveryDatee")
                Dr("Remarks") = dt.Rows(x)("DetailRemarks").Replace("&nbsp;", "")
                Dr("SeasonDatabaseID") = dt.Rows(x)("SeasonDatabaseID")
                Dr("Season") = dt.Rows(x)("SeasonName")
                Dr("ClearanceCharges") = dt.Rows(x)("ClearanceCharges")
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
                .Columns.Add("DeliveryDate", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(Long))
                .Columns.Add("Season", GetType(String))
                .Columns.Add("ClearanceCharges", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        If lblPOdetailid.Text = "" Then
            Dr("PoDetailId") = 0
        Else
            Dr("PoDetailId") = lblPOdetailid.Text
        End If
        Dr("ItemId") = lblItemId.Text
        Dr("ProductType") = cmbProductType.SelectedItem.Text
        Dr("ProductTypeId") = cmbProductType.SelectedValue
        Dr("ItemName") = txtProduct.Text.ToUpper
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
        If cmbSrNo.SelectedIndex = 0 Then
            Dr("JoborderID") = 0
        Else
            Dr("JoborderID") = cmbSrNo.SelectedValue
        End If
        If cmbSrNo.SelectedIndex = 0 Then
            Dr("SrNo") = ""
        Else
            Dr("SrNo") = cmbSrNo.SelectedItem.Text
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
        Dr("DeliveryDate") = txtDeleiveryDate.Text
        If txtRemarksDetail.Text = "" Then
            Dr("Remarks") = ""
        Else
            Dr("Remarks") = txtRemarksDetail.Text.ToUpper
        End If
        If txtClearanceCharges.Text = "" Then
            Dr("ClearanceCharges") = 0
        Else
            Dr("ClearanceCharges") = txtClearanceCharges.Text
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
    Sub ClearControlsNew()
        BindProductType()
        txtQuality.Text = ""
        txtQuantity.Text = ""
        txtWeight.Text = ""
        txtrate.Text = ""
        txtGrossAmount.Text = ""
        txtdiscPercentage.Text = 0
        txtDiscAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtValueExcloudeST.Text = ""
        txtSalesTaxPercentage.Text = 0
        txtSalesTaxAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtNetAmount.Text = ""
        txtExRate.Text = 1
        lblPOdetailid.Text = ""
        TXTCodeEntry.Text = ""
        txtColor.Text = ""
        txtRemarksDetail.Text = ""
        txtProduct.Text = ""
        lblItemId.Text = ""
        txtDeleiveryDate.Text = ""
        txtPartyAccount.Text = ""
        txtStyle.Text = ""
    End Sub
    Sub ClearControls()
        txtQuality.Text = ""
        txtQuantity.Text = ""
        txtWeight.Text = ""
        txtrate.Text = ""
        txtGrossAmount.Text = ""
        txtdiscPercentage.Text = 0
        txtDiscAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtValueExcloudeST.Text = ""
        txtSalesTaxPercentage.Text = 0
        txtSalesTaxAmount.Text = ""
        txtValueExcloudeST.Text = ""
        txtNetAmount.Text = ""
        txtExRate.Text = 1
        lblPOdetailid.Text = ""
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("APurchaseOrderView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProduct.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Product Fill.")
            ElseIf txtPartyAccount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Party Account. % Empty.")
            ElseIf txtDeleiveryDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Delivery Date Fill.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
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
            bindItemUnit()
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNewGetDataNewww(cmbProductType.SelectedValue)
            If dt.Rows.Count > 0 Then
                lblItemId.Text = dt.Rows(0)("IMSItemID")
                txtProduct.Text = dt.Rows(0)("ItemName")
                TXTCodeEntry.Text = dt.Rows(0)("ItemCodee")
                txtQuality.Text = dt.Rows(0)("ItemQuality")
                txtColor.Text = dt.Rows(0)("Shade")
                txtSize.Text = "N/A"
                txtQuantity.ReadOnly = False
                cmbItemunit.SelectedValue = dt.Rows(0)("ItemUnitId")
                txtrate.Text = dt.Rows(0)("UnitRate")
            Else
                lblItemId.Text = 0
                txtProduct.Text = ""
                TXTCodeEntry.Text = ""
                txtQuality.Text = ""
                txtColor.Text = ""
                txtSize.Text = ""
                txtQuantity.ReadOnly = False
                txtrate.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        Try
            If POID > 0 Then
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtGrossAmount.Text = Val(txtrate.Text) * Val(txtQuantity.Text)
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
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
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
            Else
                txtDiscAmount.Text = (Val(txtdiscPercentage.Text) * Val(txtGrossAmount.Text)) / 100
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
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
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
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
                    Response.Redirect("APurchaseOrderView.aspx")
                End If
            Else
                If dgProductdetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least One detail Required.")
                Else
                    SaveMaster()
                    SaveDetail()
                    Response.Redirect("APurchaseOrderView.aspx")
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
                If POID > 0 Then
                Else
                    .CreationDate = txtCreationDate.Text
                End If
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
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    .FabricStatus = 1
                    .FabricPOrder = 1
                    .GStoreStatus = 0
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    .FabricStatus = 0
                    .FabricPOrder = 0
                    .GStoreStatus = 0
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    .GStoreStatus = 1
                    .FabricStatus = 0
                    .FabricPOrder = 0
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
                .CodeEntry = TXTCodeEntry.Text
                .SalesContractNo = TXTSalesContractNo.Text
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
                    .ProductType = dgProductdetail.Items(x).Cells(4).Text
                    .JoborderID = dgProductdetail.Items(x).Cells(27).Text
                    .FreshQty = 0
                    .BQualityQty = 0
                    .DeliveryDate = dgProductdetail.Items(x).Cells(29).Text
                    .Remarks = dgProductdetail.Items(x).Cells(30).Text.Replace("&nbsp;", "")
                    .SeasonDatabaseID = dgProductdetail.Items(x).Cells(31).Text
                    .ClearanceCharges = dgProductdetail.Items(x).Cells(33).Text
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
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
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
                txtValueExcloudeST.Text = Val(txtGrossAmount.Text) - Val(txtDiscAmount.Text)
                txtSalesTaxAmount.Text = (Val(txtSalesTaxPercentage.Text) * Val(txtValueExcloudeST.Text)) / 100
                txtNetAmount.Text = Val(txtSalesTaxAmount.Text) + Val(txtValueExcloudeST.Text)
                txtWeight.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPOType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPOType.SelectedIndexChanged
        Try
            If cmbPOType.SelectedValue = 1 Then
                cmbseason.Enabled = False
                cmbSrNo.Enabled = False
            Else
                cmbseason.Enabled = True
                cmbSrNo.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            Dim dt As DataTable = objPOMaster.GetItemTypejOBWISENewCostNEWW(cmbSrNo.SelectedValue)
            If dt.Rows.Count > 0 Then
                Dim JOQTY As String = dt.Rows(0)("Quantity")
                txtQtyJOWise.Text = JOQTY
            Else
            End If
            Session("CheckAcessItemBit") = 1
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dttt As DataTable = objPOMaster.GetItemFabricNewNew(TXTCodeEntry.Text)
            cmbProductType.DataSource = dttt
            cmbProductType.DataTextField = "ItemCategoryName"
            cmbProductType.DataValueField = "IMSItemCategoryID"
            cmbProductType.DataBind()
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            If dt.Rows.Count > 0 Then
                lblItemId.Text = dt.Rows(0)("IMSItemID")
                txtProduct.Text = dt.Rows(0)("ItemName")
                bindItemUnit()
                txtQuality.Text = dt.Rows(0)("ItemQuality")
                txtColor.Text = dt.Rows(0)("Shade")
                txtSize.Text = "N/A"
                txtQuantity.ReadOnly = False
                cmbItemunit.SelectedValue = dt.Rows(0)("ItemUnitId")
                txtrate.Text = dt.Rows(0)("UnitRate")
            Else
                lblItemId.Text = 0
                txtProduct.Text = ""
                bindItemUnit()
                txtQuality.Text = ""
                txtColor.Text = ""
                txtSize.Text = ""
                txtQuantity.ReadOnly = False
                txtrate.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtProduct_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtProduct.TextChanged
        Try
            Dim dttt As DataTable = objPOMaster.GetItemFabricNewNewCategory(txtProduct.Text)
            cmbProductType.DataSource = dttt
            cmbProductType.DataTextField = "ItemCategoryName"
            cmbProductType.DataValueField = "IMSItemCategoryID"
            cmbProductType.DataBind()

            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNewGetData(txtProduct.Text)
            If dt.Rows.Count > 0 Then
                lblItemId.Text = dt.Rows(0)("IMSItemID")
                txtProduct.Text = dt.Rows(0)("ItemName")
                TXTCodeEntry.Text = dt.Rows(0)("ItemCodee")
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = dt.Rows(0)("ItemQuality")
                txtColor.Text = dt.Rows(0)("Shade")
                txtSize.Text = "N/A"
                cmbItemunit.SelectedValue = dt.Rows(0)("ItemUnitId")
                txtrate.Text = dt.Rows(0)("UnitRate")
            Else
                lblItemId.Text = 0
                txtProduct.Text = ""
                TXTCodeEntry.Text = ""
                bindItemUnit()
                txtQuantity.ReadOnly = False
                txtQuality.Text = ""
                txtColor.Text = ""
                txtSize.Text = ""
                txtrate.Text = 0
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
            BindStore()
            BindSeasonname()
            bindItemUnit()
            bindCurrency()
            lblPOdetailid.Text = dtDetail.Rows(dtrowNo)("PODetailID")
            cmbProductType.SelectedValue = dtDetail.Rows(dtrowNo)("ProductTypeId")
            lblItemId.Text = dtDetail.Rows(dtrowNo)("ItemId")
            Dim dttt As DataTable = objPOMaster.GetItemFabricNewNewNewForNeww(lblItemId.Text)
            TXTCodeEntry.Text = dttt.Rows(0)("ItemCodee")
            txtProduct.Text = dttt.Rows(0)("ItemName")
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
            txtRemarksDetail.Text = dtDetail.Rows(dtrowNo)("Remarks")
            txtDeleiveryDate.Text = dtDetail.Rows(dtrowNo)("DeliveryDate")
            lblInvoiceQTY.Text = dtDetail.Rows(dtrowNo)("InvoiceQTY")
            cmbCurrencys.SelectedValue = dtDetail.Rows(dtrowNo)("CurrencyId")
            txtExRate.Text = dtDetail.Rows(dtrowNo)("ExchangeRate")
            If dtDetail.Rows(dtrowNo)("SeasonDatabaseID") > 0 Then 
                cmbseason.SelectedValue = dtDetail.Rows(dtrowNo)("SeasonDatabaseID")
                BindSrNo()
                cmbSrNo.SelectedValue = dtDetail.Rows(dtrowNo)("JobOrderID")
            Else
                cmbseason.SelectedItem.Text = "Select"
            End If 
            txtClearanceCharges.Text = dtDetail.Rows(dtrowNo)("ClearanceCharges")
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
End Class


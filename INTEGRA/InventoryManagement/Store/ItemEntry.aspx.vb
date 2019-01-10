Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ItemEntry
    Inherits System.Web.UI.Page
    Dim ObjIMSItemClass As New IMSItemClass
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim IMSItemID As Long
    Dim ObjIMSCurrency As New IMSCurrency2
    Dim ObjItemUnitStore As New ItemUnitStore
    Dim ObjIMSItem As New IMSItem
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim Userid As Long
    Dim ObjIMSItemMaster As New IMSItemMaster
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMSItemID = Request.QueryString("IMSItemID")
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                BindcmbItemClassNameForFabric()
                BindcmbMeasuringUnit()
                cmbMeasuringUnit.SelectedValue = 7
                trdal.Visible = True
                pnldd.Visible = True
                lblQ.Visible = True
                lblComp.Visible = True
                lblW.Visible = True
                lblF.Visible = True
                txtQualityForChange.Visible = True
                txtCompForChange.Visible = True
                txtWashForChange.Visible = True
                txtFinishForChange.Visible = True
                LabelShade.Visible = True
                txtShade.Visible = True
                LabelColor.Visible = True
                txtColor.Visible = True
                lblQ.Text = "Quality"
                TrDalRefNo.Visible = True
                Label13.Visible = True
                txtWidthForItem.Visible = True
                Label14.Visible = True
                txtGSMBeforeWashForItem.Visible = True
                Label15.Visible = True
                txtGSMAfterWashForItem.Visible = True
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    BindcmbItemClassNameForFabric()
                    BindcmbMeasuringUnit()
                    cmbMeasuringUnit.SelectedValue = 7
                    trdal.Visible = True
                    pnldd.Visible = True
                    lblQ.Visible = True
                    lblComp.Visible = True
                    lblW.Visible = True
                    lblF.Visible = True
                    txtQualityForChange.Visible = True
                    txtCompForChange.Visible = True
                    txtWashForChange.Visible = True
                    txtFinishForChange.Visible = True
                    LabelShade.Visible = True
                    txtShade.Visible = True
                    LabelColor.Visible = True
                    txtColor.Visible = True
                    lblQ.Text = "Quality"
                    TrDalRefNo.Visible = True
                    Label13.Visible = True
                    txtWidthForItem.Visible = True
                    Label14.Visible = True
                    txtGSMBeforeWashForItem.Visible = True
                    Label15.Visible = True
                    txtGSMAfterWashForItem.Visible = True
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    BindcmbItemClassNameForAccessories()
                    BindcmbMeasuringUnit()
                    cmbMeasuringUnit.SelectedValue = 3
                    cmbItemStatus.SelectedValue = 4
                    trdal.Visible = False
                    lblQ.Visible = True
                    txtQualityForChange.Visible = True
                    lblQ.Text = "Item Quality"
                    LabelShade.Visible = True
                    txtShade.Visible = True
                    TrDalRefNo.Visible = False
                    Label13.Visible = False
                    txtWidthForItem.Visible = False
                    Label14.Visible = False
                    txtGSMBeforeWashForItem.Visible = False
                    Label15.Visible = False
                    txtGSMAfterWashForItem.Visible = False
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    BindcmbItemClassNameForGSTORE()
                    BindcmbMeasuringUnit()
                    cmbMeasuringUnit.SelectedValue = 3
                    cmbItemStatus.SelectedValue = 4
                    trdal.Visible = False
                    lblQ.Visible = True
                    txtQualityForChange.Visible = True
                    lblQ.Text = "Item Quality"
                    LabelShade.Visible = True
                    txtShade.Visible = True
                    TrDalRefNo.Visible = False
                    Label13.Visible = False
                    txtWidthForItem.Visible = False
                    Label14.Visible = False
                    txtGSMBeforeWashForItem.Visible = False
                    Label15.Visible = False
                    txtGSMAfterWashForItem.Visible = False
                End If
            End If
            BindcmbCurrency()
            If IMSItemID > 0 Then
                SetValuesEditMod()
                If Userid = 241 Then
                    FabricPanelDataonEdit()
                End If
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub FabricPanelDataonEdit()
        Dim dtFBData As DataTable = ObjIMSItem.GetFBData(txtDalNoO.Text)
        If dtFBData.Rows.Count > 0 Then
            txtSupplierRef.Text = dtFBData.Rows(0)("SupplierArtNo")
            txtSupplierName.Text = dtFBData.Rows(0)("SupplierName")
            txtQuality.Text = dtFBData.Rows(0)("SupplierName")
            txtComposition.Text = dtFBData.Rows(0)("CompositionName")
            txtQuality.Text = dtFBData.Rows(0)("FabricQuality")
            txtColour.Text = dtFBData.Rows(0)("Color")
            txtWidth.Text = dtFBData.Rows(0)("FabricWidth")
            txtDye.Text = dtFBData.Rows(0)("DyeWash")
            txtFinish.Text = dtFBData.Rows(0)("FinishGSM")
            lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
            txtGSMBefWash.Text = dtFBData.Rows(0)("BefWashGSM")
            txtGSMAfterWash.Text = dtFBData.Rows(0)("AfterWashGsm")
            txtShrink.Text = dtFBData.Rows(0)("Shrinkage")
            txtMillShrink.Text = dtFBData.Rows(0)("MillShrinkage")
        Else
            lblFabricMstId.Text = 0
        End If
    End Sub
    Sub BindcmbItemClassName()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAll
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForChemical()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForChemical
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForFabric()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForFabric
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForGSTORE()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForGStore
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForAccessories()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForAccessories
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForDead()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForDead
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemClassNameForGeneral()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAllForGeneral
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
        Dim dtt As DataTable
        dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
        cmbItemCategory.DataSource = dtt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
        If dtt.Rows.Count > 0 Then
            txtItemPrefix.Text = txtItemPrefix.Text + dtt.Rows(0)("ItemCategoryCode")
        End If
        If dtt.Rows.Count > 0 Then
            Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
            If dtCode.Rows.Count > 0 Then
                txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                If ItemCode >= 0 And ItemCode <= 9 Then
                    txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                    txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                    txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                Else
                    txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Else
            txtItemCodePart.Text = 1
            txtItemCode.Text = txtItemPrefix.Text + "0001"
        End If
    End Sub
    Sub BindcmbItemCategory()
        Dim dt As DataTable
        dt = ObjIMSItemCategory.GetIMSItemCategoryAll
        cmbItemCategory.DataSource = dt
        cmbItemCategory.DataTextField = "ItemCategoryName"
        cmbItemCategory.DataValueField = "IMSItemCategoryID"
        cmbItemCategory.DataBind()
    End Sub
    Sub BindcmbMeasuringUnit()
        Dim dt As DataTable
        dt = ObjItemUnitStore.GetItemUnits
        cmbMeasuringUnit.DataSource = dt
        cmbMeasuringUnit.DataTextField = "Name"
        cmbMeasuringUnit.DataValueField = "ItemUnitId"
        cmbMeasuringUnit.DataBind()
    End Sub
    Sub BindcmbCurrency()
        Dim dt As DataTable
        dt = ObjIMSCurrency.GetIMSCurrencyAll
        cmbCurrency.DataSource = dt
        cmbCurrency.DataTextField = "CurrencyName"
        cmbCurrency.DataValueField = "IMSCurrencyID"
        cmbCurrency.DataBind()
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjIMSItem.GetIMSItemEdit(IMSItemID)
            cmbItemClassName.SelectedValue = dt.Rows(0)("IMSItemClassID")
            Dim dtt As DataTable
            dtt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
            cmbItemCategory.DataSource = dtt
            cmbItemCategory.DataTextField = "ItemCategoryName"
            cmbItemCategory.DataValueField = "IMSItemCategoryID"
            cmbItemCategory.DataBind()
            cmbItemCategory.SelectedValue = dt.Rows(0)("IMSItemCategoryID")
            txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
            txtItemPrefix.Text = txtItemPrefix.Text + dt.Rows(0)("ItemCategoryCode")
            txtItemCode.Text = dt.Rows(0)("ItemCodee")
            txtItemName.Text = dt.Rows(0)("ItemName")
            cmbMeasuringUnit.SelectedValue = dt.Rows(0)("ItemUnitId")
            txtUnitRate.Text = dt.Rows(0)("UnitRate")
            txtOpeningQuantity.Text = dt.Rows(0)("OpeningQuantity")
            txtOpeningValue.Text = dt.Rows(0)("OpeningValue")
            cmbCurrency.SelectedValue = dt.Rows(0)("IMSCurrencyID")
            txtReorderQuantity.Text = dt.Rows(0)("ReorderQuantity")
            txtMaxIssueQuantity.Text = dt.Rows(0)("MaxIssueQuantity")
            txtItemCodePart.Text = dt.Rows(0)("ItemCodePart")
            lblFabricMstId.Text = dt.Rows(0)("FabricDBMstId")
            txtDalNoO.Text = dt.Rows(0)("DalNoo")
            cmbItemStatus.SelectedItem.Text = dt.Rows(0)("ItemStatus")
            txtQualityForChange.Text = dt.Rows(0)("ItemQuality")
            txtCompForChange.Text = dt.Rows(0)("ItemComposition")
            txtWashForChange.Text = dt.Rows(0)("ItemWashDye")
            txtFinishForChange.Text = dt.Rows(0)("ItemFinish")
            txtShade.Text = dt.Rows(0)("Shade")
            txtColor.Text = dt.Rows(0)("Color")
            txtDalRefNo.Text = dt.Rows(0)("DalRefNo")
            txtWidthForItem.Text = dt.Rows(0)("Width")
            txtGSMBeforeWashForItem.Text = dt.Rows(0)("GSMBeforeWash")
            txtGSMAfterWashForItem.Text = dt.Rows(0)("GSMAfterWash")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If IMSItemID > 0 Then
                save()
                Response.Redirect("ItemView.aspx")
            Else
                Dim dtchkalreadyexist As New DataTable
                dtchkalreadyexist = ObjIMSItem.ChkExist(txtItemName.Text)
                If dtchkalreadyexist.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Item Name: " & txtItemName.Text & ". Already Exist.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    If txtItemName.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Item Name empty.")
                    ElseIf cmbItemCategory.SelectedValue = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Item Category empty.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        save()
                        Response.Redirect("ItemView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try
            Dim dtFBData As DataTable = ObjIMSItem.GetFBData(txtDalNoO.Text)
            If dtFBData.Rows.Count > 0 Then
                txtSupplierRef.Text = dtFBData.Rows(0)("SupplierArtNo")
                txtSupplierName.Text = dtFBData.Rows(0)("SupplierName")
                txtQuality.Text = dtFBData.Rows(0)("SupplierName")
                txtComposition.Text = dtFBData.Rows(0)("CompositionName")
                txtQuality.Text = dtFBData.Rows(0)("FabricQuality")
                txtColour.Text = dtFBData.Rows(0)("Color")
                txtWidth.Text = dtFBData.Rows(0)("FabricWidth")
                txtDye.Text = dtFBData.Rows(0)("DyeWash")
                txtFinish.Text = dtFBData.Rows(0)("FinishGSM")
                lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                txtQualityForChange.Text = dtFBData.Rows(0)("FabricQuality")
                txtCompForChange.Text = dtFBData.Rows(0)("CompositionName")
                txtWashForChange.Text = dtFBData.Rows(0)("DyeWash")
                txtFinishForChange.Text = dtFBData.Rows(0)("FinishGSM")
            Else
                lblFabricMstId.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub save()
        With ObjIMSItem
            If IMSItemID > 0 Then
                .IMSItemID = IMSItemID
            Else
                .IMSItemID = 0
            End If
            .CreationDate = Date.Now
            .IMSItemClassID = cmbItemClassName.SelectedValue
            .IMSItemCategoryID = cmbItemCategory.SelectedValue
            .ItemName = txtItemName.Text.ToUpper()
            .ItemCodee = txtItemCode.Text
            .ItemUnitId = cmbMeasuringUnit.SelectedValue
            .UnitRate = Val(txtUnitRate.Text)
            .OpeningQuantity = Val(txtOpeningQuantity.Text)
            .OpeningValue = Val(txtOpeningValue.Text)
            .ReorderQuantity = Val(txtReorderQuantity.Text)
            .MaxIssueQuantity = Val(txtMaxIssueQuantity.Text)
            .IMSCurrencyID = cmbCurrency.SelectedValue
            .ItemCodePart = Val(txtItemCodePart.Text)
            .FabricDBMstId = lblFabricMstId.Text
            .ItemStatus = cmbItemStatus.SelectedItem.Text
            If txtQualityForChange.Text = "" Then
                .ItemQuality = ""
            Else
                .ItemQuality = txtQualityForChange.Text.ToUpper
            End If
            If txtCompForChange.Text = "" Then
                .ItemComposition = ""
            Else
                .ItemComposition = txtCompForChange.Text
            End If
            If txtFinishForChange.Text = "" Then
                .ItemFinish = ""
            Else
                .ItemFinish = txtFinishForChange.Text
            End If
            If txtWashForChange.Text = "" Then
                .ItemWashDye = ""
            Else
                .ItemWashDye = txtWashForChange.Text
            End If
            If txtShade.Text = "" Then
                .Shade = ""
            Else
                .Shade = txtShade.Text.ToUpper
            End If
            If txtColor.Text = "" Then
                .Color = ""
            Else
                .Color = txtColor.Text.ToUpper
            End If
            .DalRefNo = txtDalRefNo.Text.ToUpper
            .Width = txtWidthForItem.Text.ToUpper
            .GSMBeforeWash = txtGSMBeforeWashForItem.Text.ToUpper
            .GSMAfterWash = txtGSMAfterWashForItem.Text.ToUpper
            .SaveIMSItem()
        End With
        With ObjIMSStoreLedger
            If IMSItemID > 0 Then
                .StoreLedgerID = ObjIMSStoreLedger.GetStoreLedgerID(IMSItemID)
                .IMSItemID = IMSItemID
            Else
                .StoreLedgerID = 0
                .IMSItemID = ObjIMSItem.GetID()
            End If
            .CreationDate = Date.Now()
            .TransactionDate = Date.Now.Date()
            .TransactionType = "Open"
            .OpenQty = Val(txtOpeningQuantity.Text)
            .OpenAmount = Val(txtOpeningValue.Text)
            .ReceiveQty = 0
            .ReceiveAmount = 0
            .IssueQty = 0
            .IssueAmount = 0
            .CloseQty = Val(txtOpeningQuantity.Text)
            .CloseAmount = Val(txtOpeningValue.Text)
            .SaveIMSStoreLedger()
        End With
    End Sub
    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            Response.Redirect("ItemView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbItemClassName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemClassName.SelectedIndexChanged
        Try
            txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
            Dim dt As DataTable
            dt = ObjIMSItemCategory.GetIMSItemCategoryAllD(cmbItemClassName.SelectedValue)
            cmbItemCategory.DataSource = dt
            cmbItemCategory.DataTextField = "ItemCategoryName"
            cmbItemCategory.DataValueField = "IMSItemCategoryID"
            cmbItemCategory.DataBind()
            If dt.Rows.Count > 0 Then
                txtItemPrefix.Text = txtItemPrefix.Text + dt.Rows(0)("ItemCategoryCode")
                Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
                If dtCode.Rows.Count > 0 Then
                    txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                    Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                    If ItemCode >= 0 And ItemCode <= 9 Then
                        txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                    ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                        txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                    ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                        txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                    Else
                        txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                    End If
                Else
                    txtItemCodePart.Text = 1
                    txtItemCode.Text = txtItemPrefix.Text + "0001"
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbItemCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemCategory.SelectedIndexChanged
        Try
            txtItemPrefix.Text = ObjIMSItemClass.GetItemClassItemCode(cmbItemClassName.SelectedValue)
            Dim dt As DataTable
            dt = ObjIMSItemCategory.GetIMSItemCategoryD(cmbItemCategory.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtItemPrefix.Text = txtItemPrefix.Text + dt.Rows(0)("ItemCategoryCode")
                Dim dtCode As DataTable = ObjIMSItem.GetIMSCode(cmbItemClassName.SelectedValue, cmbItemCategory.SelectedValue)
                If dtCode.Rows.Count > 0 Then
                    txtItemCodePart.Text = dtCode.Rows(0)("ItemCodePart") + 1
                    Dim ItemCode As Decimal = dtCode.Rows(0)("ItemCodePart") + 1
                    If ItemCode >= 0 And ItemCode <= 9 Then
                        txtItemCode.Text = txtItemPrefix.Text + "000" + (ItemCode).ToString()
                    ElseIf ItemCode >= 9 And ItemCode <= 99 Then
                        txtItemCode.Text = txtItemPrefix.Text + "00" + (ItemCode).ToString()
                    ElseIf ItemCode >= 99 And ItemCode <= 999 Then
                        txtItemCode.Text = txtItemPrefix.Text + "0" + (ItemCode).ToString()
                    Else
                        txtItemCode.Text = txtItemPrefix.Text + (ItemCode).ToString()
                    End If
                Else
                    txtItemCodePart.Text = 1
                    txtItemCode.Text = txtItemPrefix.Text + "0001"
                End If
            Else
                txtItemCodePart.Text = 1
                txtItemCode.Text = txtItemPrefix.Text + "0001"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtOpeningQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpeningQuantity.TextChanged
        Try
            txtOpeningValue.Text = Math.Round(Val(txtUnitRate.Text) * Val(txtOpeningQuantity.Text), 2)
            uptxtOpeningValue.Update()
        Catch ex As Exception
        End Try
    End Sub
End Class

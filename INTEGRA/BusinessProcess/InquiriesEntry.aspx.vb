Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Imports System.Data.DataTable
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class InquiriesEntry
    Inherits System.Web.UI.Page
    Dim objInquiriesEntryClass As New InquiriesEntryClass
    Dim dtStyleProductInformation, dtQuotationInformation, dtConformedStyle As DataTable
    Dim objInquiryStyleProductionInformation As New InquiryStyleProductionInformation
    Dim objtblStyleQuotationInformation As New tblStyleQuotationInformation
    Dim ObjTblInquiryConfirmed As New TblInquiryConfirmed
    Dim Dr As DataRow
    Dim InquiryStyleID As Long
    Dim Type As String
    Dim objInqStyleAccessories As New InqStyleAccessories
    Dim dtAccessories, dtAccessoriesCon As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InquiryStyleID = Request.QueryString("InquiryStyleID")
        Type = Request.QueryString("Type")
        If Not Page.IsPostBack Then
            Session("ImageByteP") = Nothing
            Session("FileNameP") = Nothing
            Session("dtStyleProductInformation") = Nothing
            Session("dtQuotationInformation") = Nothing
            Session("dtAccessories") = Nothing
            Session("dtAccessoriesCon") = Nothing
            BindAccessories()
            BindCustomer()
            BindSeason()
            BindProductPortfolio()
            BindProductConsumer()
            BindSupplier()
            BindCompositionQuoted()
            If InquiryStyleID > 0 Then
                EditMode()
                'If Type = "Costing" Then

                FillDataConCompWt()
                Dim dtcheck As DataTable = objtblStyleQuotationInformation.check(InquiryStyleID)
                If dtcheck.Rows.Count > 0 Then
                    EditCost()
                    bindConfromSupplier()
                    BindConformedPanel()
                    pnconfrom.Visible = True
                    btnShowcomparativecosting.Visible = False
                    btnHidecomparativecosting.Visible = False
                    PnCosting.Visible = True
                Else
                    pnconfrom.Visible = True
                    btnShowcomparativecosting.Visible = True
                    btnHidecomparativecosting.Visible = False
                    PnCosting.Visible = False
                    BindAllSupplier()
                    BindConformedPanel()
                    pnconfrom.Visible = True
                End If

                PnInquiry.Enabled = True
                'PnCosting.Visible = True
                btnSave.Visible = True
                btnSave.Text = "Update Inquiry"
                btnCancel.Visible = True
                lnkFIlePicture.Visible = True
                btnAddMoreProduct.Visible = True
                btnAddProduct.Visible = False
                btnAutoComplete.Visible = False
                'Else
                '    pnconfrom.Visible = False
                '    PnCosting.Visible = False
                '    btnSave.Text = "Update"
                '    lnkFIlePicture.Visible = True
                '    btnAddProduct.Visible = False
                '    btnAutoComplete.Visible = False
                'End If


            Else
                btnShowcomparativecosting.Visible = False
                btnHidecomparativecosting.Visible = False
                btnSave.Text = "Save"
                txtTodaydate.SelectedDate = Date.Now
                pnconfrom.Visible = False
                PnCosting.Visible = False
            End If
        End If
    End Sub
    Sub FillDataConCompWt()

        Dim txtFCons As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtFCons"), TextBox)
        Dim cmbFComp As DropDownList = DirectCast(dgProductinfo.Items(0).FindControl("cmbFComp"), DropDownList)
        Dim txtFWt As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtFWt"), TextBox)

        Dim txtBuyerMOQ1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtBuyerMOQ1"), TextBox)
        Dim cmbBuyerPriceUnit1 As DropDownList = DirectCast(dgProductinfo.Items(0).FindControl("cmbBuyerPriceUnit1"), DropDownList)
        Dim txtBuyerTargetPrice1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtBuyerTargetPrice1"), TextBox)

        txtFCons1.Text = txtFCons.Text
        txtFCons2.Text = txtFCons.Text
        txtFCons3.Text = txtFCons.Text
        txtFCons4.Text = txtFCons.Text
        txtFCons5.Text = txtFCons.Text


        cmbFComp1.SelectedValue = cmbFComp.SelectedValue
        cmbFComp2.SelectedValue = cmbFComp.SelectedValue
        cmbFComp3.SelectedValue = cmbFComp.SelectedValue
        cmbFComp4.SelectedValue = cmbFComp.SelectedValue
        cmbFComp5.SelectedValue = cmbFComp.SelectedValue


        txtFwt1.Text = txtFWt.Text
        txtFWt2.Text = txtFWt.Text
        txtFWt3.Text = txtFWt.Text
        txtFWt4.Text = txtFWt.Text
        txtFWt5.Text = txtFWt.Text

        txtSupplierMOQ1.Text = txtBuyerMOQ1.Text
        txtSupplierMOQ2.Text = txtBuyerMOQ1.Text
        txtSupplierMOQ3.Text = txtBuyerMOQ1.Text
        txtSupplierMOQ4.Text = txtBuyerMOQ1.Text
        txtSupplierMOQ5.Text = txtBuyerMOQ1.Text
        txtQuotedPrice1.Text = txtBuyerTargetPrice1.Text
        txtQuotedPrice2.Text = txtBuyerTargetPrice1.Text
        txtQuotedPrice3.Text = txtBuyerTargetPrice1.Text
        txtQuotedPrice4.Text = txtBuyerTargetPrice1.Text
        txtQuotedPrice5.Text = txtBuyerTargetPrice1.Text
        txtBuyerMOQ.Text = txtBuyerMOQ1.Text
        txtBuyerTargetPrice.Text = txtBuyerTargetPrice1.Text
        cmbUnitQuotedPrice1.SelectedValue = cmbBuyerPriceUnit1.SelectedValue
        cmbUnitQuotedPrice2.SelectedValue = cmbBuyerPriceUnit1.SelectedValue
        cmbUnitQuotedPrice3.SelectedValue = cmbBuyerPriceUnit1.SelectedValue
        cmbUnitQuotedPrice4.SelectedValue = cmbBuyerPriceUnit1.SelectedValue
        cmbUnitQuotedPrice5.SelectedValue = cmbBuyerPriceUnit1.SelectedValue

    End Sub
    Sub BindAccessories()
        Try
            Dim dt As DataTable
            dt = objInqStyleAccessories.GetStyleAccessoriesList
            cmbAccessories.DataSource = dt
            cmbAccessories.DataTextField = "AccessoriesName"
            cmbAccessories.DataValueField = "AccessoriesID"
            cmbAccessories.DataBind()

            cmbAccessoriesCon.DataSource = dt
            cmbAccessoriesCon.DataTextField = "AccessoriesName"
            cmbAccessoriesCon.DataValueField = "AccessoriesID"
            cmbAccessoriesCon.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindAllSupplier()
        Dim dtSupplier As DataTable = objInquiriesEntryClass.getDataforBindCombo
        With cmbSupplierConfrmd
            .DataSource = dtSupplier
            .DataTextField = "VenderName"
            .DataValueField = "VenderLibraryID"
            .DataBind()
            .Items.Insert(0, New ListItem("Select", "0"))
        End With
    End Sub
    Sub bindConfromSupplier()
        Dim dtSupplier As DataTable = objInquiriesEntryClass.getConfroemSupllier(InquiryStyleID)

        Dim max As Decimal = 0
        Dim current As Decimal = 0
        For y As Integer = 0 To dtSupplier.Rows.Count - 1
            current = dtSupplier.Rows(y)("TotalCount")
            If current > max Then
                max = current
            End If
        Next
        Dim dtSP As New DataTable '= DirectCast(Session("dtStyleProductInformation"), DataTable)

        With dtSP
            .Columns.Add("VenderLibraryID", GetType(String))
            .Columns.Add("VenderName", GetType(String))
        End With

        Dim VenderLibraryID As String
        Dim VenderName As String
        Dim count As Decimal
        For x = 0 To dtSupplier.Rows.Count - 1
            VenderLibraryID = dtSupplier.Rows(x)("VenderLibraryID")
            VenderName = dtSupplier.Rows(x)("VenderName")
            count = dtSupplier.Rows(x)("TotalCount")
            If count = max Then
                With dtSP
                    Dr = dtSP.NewRow()
                    Dr("VenderLibraryID") = VenderLibraryID
                    Dr("VenderName") = VenderName
                    dtSP.Rows.Add(Dr)
                End With
            End If
        Next
        With cmbSupplierConfrmd
            .DataSource = dtSP
            .DataTextField = "VenderName"
            .DataValueField = "VenderLibraryID"
            .DataBind()
            .Items.Insert(0, New ListItem("Select", "0"))
        End With
    End Sub
    Sub BindConformedPanel()
        ' bindConfromSupplier()
        Dim dtPrduct As DataTable = objInquiriesEntryClass.GetProductForConfromed(InquiryStyleID)
        If dtPrduct.Rows.Count > 0 Then
            Dim asd As Integer = dtPrduct.Rows(0)("SUPPLIERID")
            txtStylingDetail.Text = dtPrduct.Rows(0)("StylingDetail")
            cmbSupplierConfrmd.SelectedValue = asd
            If dtPrduct.Rows(0)("TackPack") = "1900-01-01 00:00:00.000" Then
            Else
                txtCADArtworkRecvDate.SelectedDate = dtPrduct.Rows(0)("CadArtDate")
                txtTackPackDate.SelectedDate = dtPrduct.Rows(0)("TackPack")
            End If
            dgConfrmOrder.DataSource = dtPrduct
            dgConfrmOrder.DataBind()
            dgConfrmOrder.Visible = True
            BindFabricType2()
            BindFWtUnit2()
            BindComposition2()
            BindFabFinish2()
            dtConformedStyle = New DataTable
            With dtConformedStyle
                .Columns.Add("InquiryConformedID", GetType(String))
                .Columns.Add("InquirySproductID", GetType(String))
                .Columns.Add("RowNo", GetType(String))
                .Columns.Add("ProductPortfolioID", GetType(String))
                .Columns.Add("ProductCategoriesID", GetType(String))
                .Columns.Add("ProductConsumerID", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("FabicType", GetType(String))
                .Columns.Add("FabicCons", GetType(String))
                .Columns.Add("CompositionID", GetType(String))
                .Columns.Add("FabicWt", GetType(Decimal))
                .Columns.Add("FabicWtUnitID", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Rremarks", GetType(String))
                .Columns.Add("FabicTypeID", GetType(String))
                .Columns.Add("FabFinishID", GetType(String))
                .Columns.Add("FabFinish", GetType(String))
                .Columns.Add("ProductConsumerGroup", GetType(String))
                .Columns.Add("Price", GetType(String))
            End With
            For x = 0 To dtPrduct.Rows.Count - 1
                Dim txtFType2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtFType2"), TextBox)
                Dim txtFCons2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtFCons2"), TextBox)
                Dim cmbFComp2 As DropDownList = DirectCast(dgConfrmOrder.Items(x).FindControl("cmbFComp2"), DropDownList)
                Dim txtFWt2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtFWt2"), TextBox)
                Dim cmbFWtUnit2 As DropDownList = DirectCast(dgConfrmOrder.Items(x).FindControl("cmbFWtUnit2"), DropDownList)
                Dim txtColor2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtColor2"), TextBox)
                Dim txtQty2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtQty2"), TextBox)
                Dim txtRemarks2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtRemarks2"), TextBox)
                Dim cmbFabricType2 As DropDownList = DirectCast(dgConfrmOrder.Items(x).FindControl("cmbFabricType2"), DropDownList)
                Dim cmbFabFinish2 As DropDownList = DirectCast(dgConfrmOrder.Items(x).FindControl("cmbFabFinish2"), DropDownList)
                Dim txtItem2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtItem2"), TextBox)
                Dim txtPrice As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtPrice"), TextBox)
                Dim ChkUpdate As CheckBox = DirectCast(dgConfrmOrder.Items(x).FindControl("ChkUpdate"), CheckBox)

                Dr = dtConformedStyle.NewRow()
                Dr("InquiryConformedID") = dtPrduct.Rows(x)("InquiryConformedID")
                Dr("InquirySproductID") = dtPrduct.Rows(x)("InquirySproductID")
                Dr("RowNo") = dtPrduct.Rows(x)("RowNo")
                Dr("ProductPortfolioID") = dtPrduct.Rows(x)("ProductPortfolioID")
                Dr("ProductCategoriesID") = dtPrduct.Rows(x)("ProductCategoriesID")
                Dr("ProductConsumerID") = dtPrduct.Rows(x)("ProductConsumerID")
                Dr("Item") = dtPrduct.Rows(x)("Item")
                Dr("FabicType") = dtPrduct.Rows(x)("FabricType")
                Dr("FabicCons") = dtPrduct.Rows(x)("FConstruction")
                Dr("CompositionID") = dtPrduct.Rows(x)("Compid")
                Dr("FabicWt") = dtPrduct.Rows(x)("FWT")
                Dr("FabicWtUnitID") = dtPrduct.Rows(x)("FabicWtUnitID")
                Dr("Color") = dtPrduct.Rows(x)("Color")
                Dr("Qty") = dtPrduct.Rows(x)("Qty")
                Dr("Rremarks") = dtPrduct.Rows(x)("Rremarks")
                Dr("FabicTypeID") = dtPrduct.Rows(x)("FabricTypeID")
                Dr("FabFinishID") = dtPrduct.Rows(x)("FabFinishID")
                Dr("FabFinish") = dtPrduct.Rows(x)("FabFinish")
                Dr("ProductConsumerGroup") = dtPrduct.Rows(x)("ProductConsumerName")
                Dr("Price") = dtPrduct.Rows(x)("Price")
                dtConformedStyle.Rows.Add(Dr)
                txtFCons2.Text = dtPrduct.Rows(x)("FConstruction")
                cmbFComp2.SelectedValue = dtPrduct.Rows(x)("Compid")
                txtFWt2.Text = dtPrduct.Rows(x)("FWT")
                cmbFWtUnit2.SelectedValue = dtPrduct.Rows(x)("FabicWtUnitID")
                txtColor2.Text = dtPrduct.Rows(x)("Color")
                txtRemarks2.Text = dtPrduct.Rows(x)("Rremarks")
                cmbFabricType2.SelectedValue = dtPrduct.Rows(x)("FabricTypeID")
                cmbFabFinish2.SelectedValue = dtPrduct.Rows(x)("FabFinishID")
                txtQty2.Text = dtPrduct.Rows(x)("Qty")
                txtPrice.Text = dtPrduct.Rows(x)("Price")
                If dtPrduct.Rows(x)("InquiryConformedID") > 0 Then
                    ChkUpdate.Checked = True
                    ChkUpdate.Enabled = False
                Else
                    ChkUpdate.Checked = False
                    ChkUpdate.Enabled = True
                End If
            Next
            Dim dtAssc As DataTable = objInqStyleAccessories.GetAccessCon(InquiryStyleID)
            If dtAssc.Rows.Count > 0 Then
                dtAccessoriesCon = New DataTable
                With dtAccessoriesCon
                    .Columns.Add("InqSAID", GetType(Long))
                    .Columns.Add("AccessoriesID", GetType(Long))
                    .Columns.Add("AccessoriesName", GetType(String))
                    .Columns.Add("AccessoriesDescription", GetType(String))
                    .Columns.Add("Source", GetType(String))
                    .Columns.Add("ConAcc", GetType(String))
                    .Columns.Add("OnlyConAcc", GetType(String))
                End With

                For x = 0 To dtAssc.Rows.Count - 1
                    Dr = dtAccessoriesCon.NewRow()
                    Dr("InqSAID") = dtAssc.Rows(x)("InqSAID")
                    Dr("AccessoriesID") = dtAssc.Rows(x)("AccessoriesID")
                    Dr("AccessoriesName") = dtAssc.Rows(x)("AccessoriesName")
                    Dr("AccessoriesDescription") = dtAssc.Rows(x)("AccessoriesDescription")
                    Dr("Source") = dtAssc.Rows(x)("Source")
                    Dr("ConAcc") = dtAssc.Rows(x)("ConAcc")
                    Dr("OnlyConAcc") = dtAssc.Rows(x)("OnlyConAcc")
                    dtAccessoriesCon.Rows.Add(Dr)
                Next
                Session("dtAccessoriesCon") = dtAccessoriesCon
                BindGridAccesCon()
                For x = 0 To DgAcssCon.Items.Count - 1
                    Dim ChkAccUpdate As CheckBox = DirectCast(DgAcssCon.Items(x).FindControl("ChkAccUpdate"), CheckBox)
                    If dtAccessoriesCon.Rows.Count > 0 Then
                        If dtAccessoriesCon.Rows(x)("ConAcc") = True Then
                            ChkAccUpdate.Checked = True
                        End If
                    End If
                Next
                upDgAcssCon.Update()
            End If
        End If
    End Sub
    Sub EditCost()
        Dim dtCostEdt As DataTable = objtblStyleQuotationInformation.Costedit(InquiryStyleID)
        If (Not CType(Session("dtQuotationInformation"), DataTable) Is Nothing) Then
            dtQuotationInformation = Session("dtQuotationInformation")
        Else
            dtQuotationInformation = New DataTable
            With dtQuotationInformation
                .Columns.Add("InquiryQuotationID", GetType(Long))
                .Columns.Add("InquirySproductID", GetType(Long))
                .Columns.Add("RowNo", GetType(String))
                .Columns.Add("BuyerTargetPrice", GetType(String))
                .Columns.Add("BuyerPriceUnit", GetType(String))
                .Columns.Add("BuyerMOQ", GetType(String))
                .Columns.Add("SupplierID1", GetType(String))
                .Columns.Add("Supplier1", GetType(String))
                .Columns.Add("FCons1", GetType(String))
                .Columns.Add("CompositionID1", GetType(String))
                .Columns.Add("FComp1", GetType(String))
                .Columns.Add("FWT1", GetType(String))
                .Columns.Add("QuotedPrice1", GetType(String))
                .Columns.Add("QuotedPriceUnit1", GetType(String))
                .Columns.Add("SupplierID2", GetType(String))
                .Columns.Add("Supplier2", GetType(String))
                .Columns.Add("FCons2", GetType(String))
                .Columns.Add("CompositionID2", GetType(String))
                .Columns.Add("FComp2", GetType(String))
                .Columns.Add("FWT2", GetType(String))

                .Columns.Add("QuotedPrice2", GetType(String))
                .Columns.Add("QuotedPriceUnit2", GetType(String))
                .Columns.Add("SupplierID3", GetType(String))
                .Columns.Add("Supplier3", GetType(String))
                .Columns.Add("FCons3", GetType(String))
                .Columns.Add("CompositionID3", GetType(String))
                .Columns.Add("FComp3", GetType(String))
                .Columns.Add("FWT3", GetType(String))

                .Columns.Add("QuotedPrice3", GetType(String))
                .Columns.Add("QuotedPriceUnit3", GetType(String))
                .Columns.Add("SupplierID4", GetType(String))
                .Columns.Add("Supplier4", GetType(String))
                .Columns.Add("FCons4", GetType(String))
                .Columns.Add("CompositionID4", GetType(String))
                .Columns.Add("FComp4", GetType(String))
                .Columns.Add("FWT4", GetType(String))

                .Columns.Add("QuotedPrice4", GetType(String))
                .Columns.Add("QuotedPriceUnit4", GetType(String))
                .Columns.Add("SupplierID5", GetType(String))
                .Columns.Add("Supplier5", GetType(String))
                .Columns.Add("FCons5", GetType(String))
                .Columns.Add("CompositionID5", GetType(String))
                .Columns.Add("FComp5", GetType(String))
                .Columns.Add("FWT5", GetType(String))

                .Columns.Add("QuotedPrice5", GetType(String))
                .Columns.Add("QuotedPriceUnit5", GetType(String))
                .Columns.Add("QuotedRemarks", GetType(String))
                .Columns.Add("SupplierMOQ1", GetType(String))
                .Columns.Add("SupplierMOQ2", GetType(String))
                .Columns.Add("SupplierMOQ3", GetType(String))
                .Columns.Add("SupplierMOQ4", GetType(String))
                .Columns.Add("SupplierMOQ5", GetType(String))
            End With
        End If
        For x As Integer = 0 To dtCostEdt.Rows.Count - 1


            Dr = dtQuotationInformation.NewRow()
            Dr("InquiryQuotationID") = dtCostEdt.Rows(x)("InquiryQuotationID")
            Dr("InquirySproductID") = dtCostEdt.Rows(x)("InquirySproductID")
            Dr("RowNo") = dtCostEdt.Rows(x)("RowNo")
            Dr("BuyerTargetPrice") = dtCostEdt.Rows(x)("BuyerTargetPrice")
            Dr("BuyerMOQ") = dtCostEdt.Rows(x)("BuyerMOQ")
            Dr("BuyerPriceUnit") = dtCostEdt.Rows(x)("BuyerPriceUnit")
            Dr("SupplierID1") = dtCostEdt.Rows(x)("SupplierID1")
            Dr("Supplier1") = dtCostEdt.Rows(x)("Supplier1")
            Dr("FCons1") = dtCostEdt.Rows(x)("FCons1")
            Dr("CompositionID1") = dtCostEdt.Rows(x)("CompositionID1")
            Dr("FComp1") = dtCostEdt.Rows(x)("FComp1")
            Dr("FWT1") = dtCostEdt.Rows(x)("FWT1")

            Dr("QuotedPrice1") = dtCostEdt.Rows(x)("QuotedPrice1")
            Dr("QuotedPriceUnit1") = dtCostEdt.Rows(x)("QuotedPriceUnit1")
            Dr("SupplierID2") = dtCostEdt.Rows(x)("SupplierID2")
            Dr("Supplier2") = dtCostEdt.Rows(x)("Supplier2")
            Dr("FCons2") = dtCostEdt.Rows(x)("FCons2")
            Dr("CompositionID2") = dtCostEdt.Rows(x)("CompositionID2")
            Dr("FComp2") = dtCostEdt.Rows(x)("FComp2")
            Dr("FWT2") = dtCostEdt.Rows(x)("FWT2")

            Dr("QuotedPrice2") = dtCostEdt.Rows(x)("QuotedPrice2")
            Dr("QuotedPriceUnit2") = dtCostEdt.Rows(x)("QuotedPriceUnit2")
            Dr("SupplierID3") = dtCostEdt.Rows(x)("SupplierID3")
            Dr("Supplier3") = dtCostEdt.Rows(x)("Supplier3")
            Dr("FCons3") = dtCostEdt.Rows(x)("FCons3")
            Dr("CompositionID3") = dtCostEdt.Rows(x)("CompositionID3")
            Dr("FComp3") = dtCostEdt.Rows(x)("FComp3")
            Dr("FWT3") = dtCostEdt.Rows(x)("FWT3")

            Dr("QuotedPrice3") = dtCostEdt.Rows(x)("QuotedPrice3")
            Dr("QuotedPriceUnit3") = dtCostEdt.Rows(x)("QuotedPriceUnit3")
            Dr("SupplierID4") = dtCostEdt.Rows(x)("SupplierID4")
            Dr("Supplier4") = dtCostEdt.Rows(x)("Supplier4")
            Dr("FCons4") = dtCostEdt.Rows(x)("FCons4")
            Dr("CompositionID4") = dtCostEdt.Rows(x)("CompositionID4")
            Dr("FComp4") = dtCostEdt.Rows(x)("FComp4")
            Dr("FWT4") = dtCostEdt.Rows(x)("FWT4")
            Dr("QuotedPrice4") = dtCostEdt.Rows(x)("QuotedPrice4")
            Dr("QuotedPriceUnit4") = dtCostEdt.Rows(x)("QuotedPriceUnit4")
            Dr("SupplierID5") = dtCostEdt.Rows(x)("SupplierID5")
            Dr("Supplier5") = dtCostEdt.Rows(x)("Supplier5")
            Dr("FCons5") = dtCostEdt.Rows(x)("FCons5")
            Dr("CompositionID5") = dtCostEdt.Rows(x)("CompositionID5")
            Dr("FComp5") = dtCostEdt.Rows(x)("FComp5")
            Dr("FWT5") = dtCostEdt.Rows(x)("FWT5")
            Dr("QuotedPrice5") = dtCostEdt.Rows(x)("QuotedPrice5")
            Dr("QuotedPriceUnit5") = dtCostEdt.Rows(x)("QuotedPriceUnit5")
            Dr("QuotedRemarks") = dtCostEdt.Rows(x)("QuotedRemarks")
            Dr("SupplierMOQ1") = dtCostEdt.Rows(x)("SupplierMOQ1")
            Dr("SupplierMOQ2") = dtCostEdt.Rows(x)("SupplierMOQ2")
            Dr("SupplierMOQ3") = dtCostEdt.Rows(x)("SupplierMOQ3")
            Dr("SupplierMOQ4") = dtCostEdt.Rows(x)("SupplierMOQ4")
            Dr("SupplierMOQ5") = dtCostEdt.Rows(x)("SupplierMOQ5")
            dtQuotationInformation.Rows.Add(Dr)
        Next
        Session("dtQuotationInformation") = dtQuotationInformation
        BindGridQuotation()
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objInquiriesEntryClass.getDataforBindCombo
            With CbmSupplier1
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            With cmbSupplier2
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            With cmbSupplier3
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            With cmbSupplier4
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            With cmbSupplier5
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dtMaster As DataTable = objInquiriesEntryClass.GetMaster(InquiryStyleID)
            If dtMaster.Rows.Count > 0 Then
                txtTodaydate.SelectedDate = dtMaster.Rows(0)("creationdate")
                txtStyleNo.Text = dtMaster.Rows(0)("StyleNo")
                ' txtCoreLine.Text = dtMaster.Rows(0)("CoreLine")
                cmbSpecialLine.SelectedValue = dtMaster.Rows(0)("CoreLine")
                txtStyleDescription.Text = dtMaster.Rows(0)("StyleDescription")
                cmbCustomer.SelectedValue = dtMaster.Rows(0)("CustomerID")
                'Load buing no first
                cmbBuyingDept.DataSource = objInquiriesEntryClass.GetBuyingNo(cmbCustomer.SelectedValue)
                cmbBuyingDept.DataValueField = "departmentno"
                cmbBuyingDept.DataTextField = "departmentno"
                cmbBuyingDept.DataBind()
                cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))
                cmbBuyingDept.SelectedValue = dtMaster.Rows(0)("BuyingDept")
                '---Bind Byuer Name
                cmbBuyerName.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
                cmbBuyerName.DataTextField = "BuyerName"
                cmbBuyerName.DataValueField = "BuyerName"
                cmbBuyerName.DataBind()
                cmbBuyerName.Items.Insert(0, New ListItem("Select", "0"))
                cmbBuyerName.SelectedValue = dtMaster.Rows(0)("BuyerName")
                '---Bind Brand 
                cmbBrand.DataSource = objInquiriesEntryClass.GetBrandInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
                cmbBrand.DataTextField = "BrandName"
                cmbBrand.DataValueField = "BrandName"
                cmbBrand.DataBind()
                cmbBrand.Items.Insert(0, New ListItem("Select", "0"))
                cmbBrand.SelectedValue = dtMaster.Rows(0)("BrandName")
                cmbSeason.SelectedValue = dtMaster.Rows(0)("SeasonID")
                cmbStyleSource.SelectedItem.Text = dtMaster.Rows(0)("StyleSource")
                txtRecvDate.SelectedDate = dtMaster.Rows(0)("RecvDate")
                'txtExFactoryDate.Text = dtMaster.Rows(0)("ExFactoryDate")
                cmbEnquireType.SelectedItem.Text = dtMaster.Rows(0)("EnquiryType")
                cmbPOStatus.SelectedItem.Text = dtMaster.Rows(0)("POStatus")
                If cmbPOStatus.SelectedItem.Text = "Cancelled" Then
                    ReasonofCancel.Visible = True
                    UpReasonofCancel.Update()
                Else
                    ReasonofCancel.Visible = False
                    UpReasonofCancel.Update()
                End If
                'POStatus = dtMaster.Rows(0)("POStatus")
                If dtMaster.Rows(0)("FileName") = "" Then
                    pictureNotAvialable()
                Else
                    Session("FileNameP") = dtMaster.Rows(0)("FileName")
                    Session("ImageByteP") = dtMaster.Rows(0)("Picture")
                End If
                cmbEnquiryPurpose.SelectedItem.Text = dtMaster.Rows(0)("EnquiryPurpose")
                txtEnquiryConfirmDate.Text = dtMaster.Rows(0)("EnquiryConfirmDate")
                'ConfirmDate = dtMaster.Rows(0)("EnquiryConfirmDate")
                txtDesignName.Text = dtMaster.Rows(0)("DesignName")
                cmbHighDifficultyLevel.SelectedItem.Text = dtMaster.Rows(0)("DiffcultyLevel")
                txtReasonofCancel.Text = dtMaster.Rows(0)("ReasonofCancel")
            End If

            Dim dtPrduct As DataTable = objInquiriesEntryClass.GetProductNew(InquiryStyleID)

            If dtPrduct.Rows.Count > 0 Then
                dgProductinfo.DataSource = dtPrduct
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
                Dim dtProductCategories As DataTable
                dtProductCategories = objInquiriesEntryClass.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
                cmbProductCategory.DataSource = dtProductCategories
                cmbProductCategory.DataTextField = "ProductCategories"
                cmbProductCategory.DataValueField = "ProductCategoriesID"
                cmbProductCategory.DataBind()
                cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
                BindFabricType()
                BindFWtUnit()
                BindGarmentWtUnit()
                BindComposition()
                BindFabFinish()
                BindLinigType()


                dtStyleProductInformation = New DataTable
                With dtStyleProductInformation
                    .Columns.Add("InquirySproductID", GetType(String))
                    .Columns.Add("RowNo", GetType(String))
                    .Columns.Add("ProductPortfolioID", GetType(String))
                    .Columns.Add("ProductCategoriesID", GetType(String))
                    .Columns.Add("ProductConsumerID", GetType(String))
                    .Columns.Add("Pack", GetType(String))
                    .Columns.Add("Item", GetType(String))
                    .Columns.Add("HSCode", GetType(String))
                    .Columns.Add("FabicType", GetType(String))
                    .Columns.Add("FabicCons", GetType(String))
                    .Columns.Add("CompositionID", GetType(String))
                    .Columns.Add("FabicWt", GetType(Decimal))
                    .Columns.Add("FabicWtUnitID", GetType(String))
                    .Columns.Add("GarmentWt", GetType(Decimal))
                    .Columns.Add("GarmentWtUnitID", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("Rremarks", GetType(String))
                    .Columns.Add("FabicTypeID", GetType(String))
                    .Columns.Add("FabFinishID", GetType(String))
                    .Columns.Add("FabFinish", GetType(String))
                    .Columns.Add("ProductConsumerGroup", GetType(String))
                    .Columns.Add("Lining", GetType(String))
                    .Columns.Add("LiningType", GetType(String))
                    .Columns.Add("LiningTypeID", GetType(String))
                    .Columns.Add("LiningCons", GetType(String))
                    .Columns.Add("LiningCompID", GetType(String))
                    .Columns.Add("LiningComposition", GetType(String))
                    .Columns.Add("LiningWeight", GetType(String))
                    .Columns.Add("BuyerTargetPrice", GetType(String))
                    .Columns.Add("BuyerPriceUnit", GetType(String))
                    .Columns.Add("BuyerMOQ", GetType(String))
                End With

                For x = 0 To dtPrduct.Rows.Count - 1
                    'Dim txtRow As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRow"), TextBox)
                    'Dim txtPack As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtPack"), TextBox)
                    'Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)

                    Dim txtHSCode As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtHSCode"), TextBox)
                    Dim txtFType As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFType"), TextBox)
                    Dim txtFCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFCons"), TextBox)
                    Dim cmbFComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFComp"), DropDownList)
                    Dim txtFWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFWt"), TextBox)
                    Dim cmbFWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
                    Dim txtGarmentWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtGarmentWt"), TextBox)
                    Dim cmbGarmentWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbGarmentWtUnit"), DropDownList)
                    Dim txtColor As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtColor"), TextBox)
                    Dim txtBuyerTargetPrice1 As TextBox = CType(dgProductinfo.Items(x).FindControl("txtBuyerTargetPrice1"), TextBox)
                    Dim txtBuyerMOQ1 As TextBox = CType(dgProductinfo.Items(x).FindControl("txtBuyerMOQ1"), TextBox)
                    Dim cmbBuyerPriceUnit1 As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbBuyerPriceUnit1"), DropDownList)
                    Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbFabricType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabricType"), DropDownList)
                    Dim cmbFabFinish As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)
                    Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)

                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)

                    Dr = dtStyleProductInformation.NewRow()
                    Dr("InquirySproductID") = dtPrduct.Rows(x)("InquirySproductID")
                    Dr("RowNo") = dtPrduct.Rows(x)("RowNo")
                    Dr("ProductPortfolioID") = dtPrduct.Rows(x)("ProductPortfolioID")
                    Dr("ProductCategoriesID") = dtPrduct.Rows(x)("ProductCategoriesID")
                    Dr("ProductConsumerID") = dtPrduct.Rows(x)("ProductConsumerID")
                    Dr("Pack") = dtPrduct.Rows(x)("Pack")
                    Dr("Item") = dtPrduct.Rows(x)("Item")
                    Dr("HSCode") = dtPrduct.Rows(x)("HSCode")
                    Dr("FabicType") = dtPrduct.Rows(x)("FabricType")
                    Dr("FabicCons") = dtPrduct.Rows(x)("FabicCons")
                    Dr("CompositionID") = dtPrduct.Rows(x)("CompositionID")
                    Dr("FabicWt") = dtPrduct.Rows(x)("FabicWt")
                    Dr("FabicWtUnitID") = dtPrduct.Rows(x)("FabicWtUnitID")
                    Dr("GarmentWt") = dtPrduct.Rows(x)("GarmentWt")
                    Dr("GarmentWtUnitID") = dtPrduct.Rows(x)("GarmentWtUnitID")
                    Dr("Color") = dtPrduct.Rows(x)("Color")
                    Dr("Rremarks") = dtPrduct.Rows(x)("Rremarks")
                    Dr("FabicTypeID") = dtPrduct.Rows(x)("FabricTypeID")
                    Dr("FabFinishID") = dtPrduct.Rows(x)("FabFinishID")
                    Dr("FabFinish") = dtPrduct.Rows(x)("FabFinish")
                    Dr("ProductConsumerGroup") = dtPrduct.Rows(x)("ProductConsumerName")
                    Dr("Lining") = dtPrduct.Rows(x)("Lining")
                    Dr("LiningTypeID") = dtPrduct.Rows(x)("LiningTypeID")
                    Dr("LiningType") = dtPrduct.Rows(x)("LiningType")
                    Dr("LiningCons") = dtPrduct.Rows(x)("LiningCons")
                    Dr("LiningCompID") = dtPrduct.Rows(x)("LiningCompID")
                    Dr("LiningComposition") = dtPrduct.Rows(x)("LiningComposition")
                    Dr("LiningWeight") = dtPrduct.Rows(x)("LiningWt")
                    Dr("BuyerTargetPrice") = dtPrduct.Rows(x)("BuyerTargetPrice")
                    Dr("BuyerPriceUnit") = dtPrduct.Rows(x)("BuyerPriceUnit")
                    Dr("BuyerMOQ") = dtPrduct.Rows(x)("BuyerMOQ")
                    dtStyleProductInformation.Rows.Add(Dr)

                    txtBuyerTargetPrice1.Text = dtPrduct.Rows(x)("BuyerTargetPrice")
                    txtBuyerMOQ1.Text = dtPrduct.Rows(x)("BuyerMOQ")
                    cmbBuyerPriceUnit1.SelectedValue = dtPrduct.Rows(x)("BuyerPriceUnit")

                    txtHSCode.Text = dtPrduct.Rows(x)("HSCode")
                    txtFCons.Text = dtPrduct.Rows(x)("FabicCons")
                    cmbFComp.SelectedValue = dtPrduct.Rows(x)("CompositionID")
                    txtFWt.Text = dtPrduct.Rows(x)("FabicWt")
                    cmbFWtUnit.SelectedValue = dtPrduct.Rows(x)("FabicWtUnitID")
                    txtGarmentWt.Text = dtPrduct.Rows(x)("GarmentWt")
                    cmbGarmentWtUnit.SelectedValue = dtPrduct.Rows(x)("GarmentWtUnitID")
                    txtColor.Text = dtPrduct.Rows(x)("Color")
                    txtRemarks.Text = dtPrduct.Rows(x)("Rremarks")
                    cmbFabricType.SelectedValue = dtPrduct.Rows(x)("FabricTypeID")
                    cmbFabFinish.SelectedValue = dtPrduct.Rows(x)("FabFinishID")
                    cmbLiningType.SelectedValue = dtPrduct.Rows(x)("LiningTypeID")
                    txtLiningCons.Text = dtPrduct.Rows(x)("LiningCons")
                    cmbLinigComp.SelectedValue = dtPrduct.Rows(x)("LiningCompID")
                    txtLiningWt.Text = dtPrduct.Rows(x)("LiningWt")
                    If cmbProductPortfolio.SelectedValue = 1 Then
                        txtItem.ReadOnly = True
                    Else
                        txtItem.ReadOnly = False
                    End If
                    Dim Lining As String = dgProductinfo.Items(x).Cells(25).Text
                    If Lining = "Y" Then
                        cmbLiningType.Visible = True
                        txtLiningCons.Visible = True
                        cmbLinigComp.Visible = True
                        txtLiningWt.Visible = True
                        UpUpbtnAutoComplete.Update()
                    Else
                        cmbLiningType.Visible = False
                        txtLiningCons.Visible = False
                        cmbLinigComp.Visible = False
                        txtLiningWt.Visible = False
                        UpUpbtnAutoComplete.Update()
                    End If

                Next
                cmbRow.DataSource = dtPrduct
                cmbRow.DataTextField = "RowNo"
                cmbRow.DataValueField = "InquirySproductID"
                cmbRow.DataBind()
                '---new use nizam for Binding DD
                BindProductPortfolio()
                BindProductCategories()
                BindProductConsumer()
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
                cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
                cmbProductConsumerGrp.SelectedValue = dtPrduct.Rows(0)("ProductConsumerID")
                cmbPack.SelectedItem.Text = dtPrduct.Rows(0)("Pack")
                '-----end
                Session("dtStyleProductInformation") = dtStyleProductInformation
                If cmbProductPortfolio.SelectedValue = 1 Then
                    lblpack.Visible = False
                    cmbPack.Visible = False
                    UpdatePanel6.Update()
                    Uplblpack.Update()
                    btnAddMoreProduct.Visible = True
                    UpcmbProductPortfolio.Update()
                    cmbProductPortfolio.Enabled = False
                    Upadd.Update()
                    UpcmbProductPortfolio.Update()
                Else
                    lblpack.Visible = True
                    cmbPack.Visible = True
                    btnAddMoreProduct.Visible = True
                    UpdatePanel6.Update()
                    Uplblpack.Update()
                    UpcmbProductPortfolio.Update()
                    cmbProductPortfolio.Enabled = False
                    Upadd.Update()
                    UpcmbProductPortfolio.Update()
                End If
                Dim dtAssc As DataTable = objInqStyleAccessories.GetAccess(InquiryStyleID)
                If dtAssc.Rows.Count > 0 Then
                    dtAccessories = New DataTable
                    With dtAccessories
                        .Columns.Add("InqSAID", GetType(Long))
                        .Columns.Add("AccessoriesID", GetType(Long))
                        .Columns.Add("AccessoriesName", GetType(String))
                        .Columns.Add("AccessoriesDescription", GetType(String))
                        .Columns.Add("Source", GetType(String))
                        .Columns.Add("ConAcc", GetType(String))
                    End With

                    For x = 0 To dtAssc.Rows.Count - 1
                        Dr = dtAccessories.NewRow()
                        Dr("InqSAID") = dtAssc.Rows(x)("InqSAID")
                        Dr("AccessoriesID") = dtAssc.Rows(x)("AccessoriesID")
                        Dr("AccessoriesName") = dtAssc.Rows(x)("AccessoriesName")
                        Dr("AccessoriesDescription") = dtAssc.Rows(x)("AccessoriesDescription")
                        Dr("Source") = dtAssc.Rows(x)("Source")
                        Dr("ConAcc") = dtAssc.Rows(x)("ConAcc")
                        dtAccessories.Rows.Add(Dr)
                    Next
                    Session("dtAccessories") = dtAccessories
                    BindGridAcces()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindCustomer()
        cmbCustomer.DataSource = objInquiriesEntryClass.GetFilterComboValues
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        '---Bind Buyeing Dept
        cmbBuyingDept.DataSource = objInquiriesEntryClass.GetBuyingNo(cmbCustomer.SelectedValue)
        cmbBuyingDept.DataValueField = "departmentno"
        cmbBuyingDept.DataTextField = "departmentno"
        cmbBuyingDept.DataBind()

        '---Bind Byuer Name
        cmbBuyerName.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
        cmbBuyerName.DataTextField = "BuyerName"
        cmbBuyerName.DataValueField = "BuyerName"
        cmbBuyerName.DataBind()
        UpdatecmbBuyerName.Update()
        '---Bind Brand 
        cmbBrand.DataSource = objInquiriesEntryClass.GetBrandInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
        cmbBrand.DataTextField = "BrandName"
        cmbBrand.DataValueField = "BrandName"
        cmbBrand.DataBind()
        UpcmbBrand.Update()

    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            '---Bind Buying Dept
            cmbBuyingDept.DataSource = objInquiriesEntryClass.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()

            '---Bind Byuer Name
            cmbBuyerName.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()
            '---Bind Brand 
            cmbBrand.DataSource = objInquiriesEntryClass.GetBrandInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try

            '---Bind Byuer Name
            cmbBuyerName.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            '---Bind Brand 
            cmbBrand.DataSource = objInquiriesEntryClass.GetBrandInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            UpcmbBrand.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyerName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyerName.SelectedIndexChanged
        Try
            ''---Bind Brand 
            '---Bind Brand 
            cmbBrand.DataSource = objInquiriesEntryClass.GetBrandInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            UpcmbBrand.Update()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductPortfolio()
        Try

            Dim dtProductPortfolio As DataTable
            dtProductPortfolio = objInquiriesEntryClass.GetAllProductPortfolio
            cmbProductPortfolio.DataSource = dtProductPortfolio
            cmbProductPortfolio.DataTextField = "ProductPortfolio"
            cmbProductPortfolio.DataValueField = "ProductPortfolioID"
            cmbProductPortfolio.DataBind()

            Dim dtProductCategories As DataTable
            dtProductCategories = objInquiriesEntryClass.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategory.DataSource = dtProductCategories
            cmbProductCategory.DataTextField = "ProductCategories"
            cmbProductCategory.DataValueField = "ProductCategoriesID"
            cmbProductCategory.DataBind()
            If cmbProductPortfolio.SelectedValue = 1 Then
                lblpack.Visible = False
                cmbPack.Visible = False
                UpdatePanel6.Update()
                Uplblpack.Update()
            Else
                lblpack.Visible = True
                cmbPack.Visible = True
                UpdatePanel6.Update()
                Uplblpack.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbProductPortfolio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductPortfolio.SelectedIndexChanged
        Try
            If cmbProductPortfolio.SelectedValue = 0 Then
                cmbProductCategory.Items.Clear()
                cmbProductPortfolio.BackColor = Drawing.Color.Red
            Else
                Dim dtProductCategories As DataTable
                dtProductCategories = objInquiriesEntryClass.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
                cmbProductCategory.DataSource = dtProductCategories
                cmbProductCategory.DataTextField = "ProductCategories"
                cmbProductCategory.DataValueField = "ProductCategoriesID"
                cmbProductCategory.DataBind()

                UpcmbProductCategory.Update()
            End If

            If cmbProductPortfolio.SelectedValue = 1 Then
                lblpack.Visible = False
                cmbPack.Visible = False
                UpdatePanel6.Update()
                Uplblpack.Update()
            Else
                lblpack.Visible = True
                cmbPack.Visible = True
                UpdatePanel6.Update()
                Uplblpack.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductConsumer()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetProductConsumer
            cmbProductConsumerGrp.DataSource = dt
            cmbProductConsumerGrp.DataTextField = "ProductConsumerName"
            cmbProductConsumerGrp.DataValueField = "ProductConsumerID"
            cmbProductConsumerGrp.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductCategories()
        Try
            Dim dtProductCategories As DataTable
            dtProductCategories = objInquiriesEntryClass.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategory.DataSource = dtProductCategories
            cmbProductCategory.DataTextField = "ProductCategories"
            cmbProductCategory.DataValueField = "ProductCategoriesID"
            cmbProductCategory.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddProduct.Click
        Try
            SaveSessionProduct()
            BindGridProduct()
            BindFWtUnit()
            BindGarmentWtUnit()
            BindComposition()
            BindFabricType()
            BindLinigType()
            BindFabFinish()
            If cmbProductPortfolio.SelectedValue = 1 Then
                btnAddProduct.Visible = False
                cmbProductPortfolio.Enabled = False
                btnAddMoreProduct.Visible = True
                Upadd.Update()
                UpcmbProductPortfolio.Update()
            Else
                If InquiryStyleID > 0 Then
                    btnAddProduct.Visible = False
                    btnAddMoreProduct.Visible = True
                Else
                    btnAddProduct.Visible = False
                End If
                UpcmbProductPortfolio.Update()
                cmbProductPortfolio.Enabled = False
                Upadd.Update()
                UpcmbProductPortfolio.Update()
            End If
            Dim x As Integer
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)
                Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
                Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)

                If cmbProductPortfolio.SelectedValue = 1 Then
                    txtItem.ReadOnly = True
                Else
                    txtItem.ReadOnly = False
                End If
                Dim Lining As String = dgProductinfo.Items(x).Cells(25).Text
                If Lining = "Y" Then
                    cmbLiningType.Visible = True
                    txtLiningCons.Visible = True
                    cmbLinigComp.Visible = True
                    txtLiningWt.Visible = True
                    UpUpbtnAutoComplete.Update()
                Else
                    cmbLiningType.Visible = False
                    txtLiningCons.Visible = False
                    cmbLinigComp.Visible = False
                    txtLiningWt.Visible = False
                    UpUpbtnAutoComplete.Update()
                End If
            Next
            btnAutoComplete.Visible = True
            UpbtnAutoComplete.Update()
            UpUpbtnAutoComplete.Update()

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionProduct()
        If (Not CType(Session("dtStyleProductInformation"), DataTable) Is Nothing) Then
            dtStyleProductInformation = Session("dtStyleProductInformation")
        Else
            dtStyleProductInformation = New DataTable
            With dtStyleProductInformation
                .Columns.Add("InquirySproductID", GetType(Long))
                .Columns.Add("RowNo", GetType(String))
                .Columns.Add("ProductPortfolioID", GetType(Long))
                .Columns.Add("ProductCategoriesID", GetType(Long))
                .Columns.Add("ProductConsumerID", GetType(Long))
                .Columns.Add("Pack", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("HSCode", GetType(String))
                .Columns.Add("FabicType", GetType(String))
                .Columns.Add("FabicTypeID", GetType(String))
                .Columns.Add("FabicCons", GetType(String))
                .Columns.Add("CompositionID", GetType(Long))
                .Columns.Add("FabicWt", GetType(String))
                .Columns.Add("FabicWtUnitID", GetType(Long))
                .Columns.Add("GarmentWt", GetType(String))
                .Columns.Add("GarmentWtUnitID", GetType(Long))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Rremarks", GetType(String))
                .Columns.Add("FabFinishID", GetType(String))
                .Columns.Add("FabFinish", GetType(String))
                .Columns.Add("ProductConsumerGroup", GetType(String))
                .Columns.Add("Lining", GetType(String))
                .Columns.Add("LiningType", GetType(String))
                .Columns.Add("LiningTypeID", GetType(String))
                .Columns.Add("LiningCons", GetType(String))
                .Columns.Add("LiningCompID", GetType(String))
                .Columns.Add("LiningComposition", GetType(String))
                .Columns.Add("LiningWeight", GetType(String))
                .Columns.Add("BuyerTargetPrice", GetType(String))
                .Columns.Add("BuyerPriceUnit", GetType(String))
                .Columns.Add("BuyerMOQ", GetType(String))
            End With
        End If
        Dim x = 0

        If cmbPack.SelectedValue = 0 Then
            x = 1
            '  BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 1 Then
            x = 2
            ' BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 2 Then
            x = 3
            ' BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 3 Then
            x = 4
            ' BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 4 Then
            x = 5
            ' BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 5 Then
            x = 6
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 6 Then
            x = 7
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 7 Then
            x = 8
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 8 Then
            x = 9
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 9 Then
            x = 10
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 10 Then
            x = 11
            'BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 11 Then
            x = 12
            ' BindcmbBaseItem(x)
        End If


        Dim rowcount As Decimal
        For x = 1 To x
            Dr = dtStyleProductInformation.NewRow()
            rowcount = Val(dtStyleProductInformation.Rows.Count) + 1
            Dr("InquirySproductID") = 0
            If cmbProductPortfolio.SelectedValue = 1 Then
                Dr("RowNo") = "Item" + " " + rowcount.ToString()
            Else
                Dr("RowNo") = "Row" + " " + x.ToString()
            End If

            Dr("ProductPortfolioID") = cmbProductPortfolio.SelectedValue
            Dr("ProductCategoriesID") = cmbProductCategory.SelectedValue
            Dr("ProductConsumerID") = cmbProductConsumerGrp.SelectedValue
            Dr("Pack") = cmbPack.SelectedItem.Text
            If cmbProductPortfolio.SelectedValue = 1 Then
                Dr("Item") = cmbProductCategory.SelectedItem.Text
            Else
                Dr("Item") = "Item" + " " + x.ToString()
            End If

            Dr("HSCode") = ""
            Dr("FabicType") = ""
            Dr("FabicTypeID") = ""
            Dr("FabicCons") = ""
            Dr("CompositionID") = 0
            Dr("FabicWt") = 0
            Dr("FabicWtUnitID") = 0
            Dr("GarmentWt") = 0
            Dr("GarmentWtUnitID") = 0
            Dr("Color") = ""
            Dr("Rremarks") = ""
            Dr("FabFinishID") = ""
            Dr("FabFinish") = ""
            Dr("ProductConsumerGroup") = cmbProductConsumerGrp.SelectedItem.Text
            Dr("Lining") = cmbLining.SelectedItem.Text
            Dr("LiningTypeID") = 0
            Dr("LiningType") = ""
            Dr("LiningCons") = ""
            Dr("LiningCompID") = 0
            Dr("LiningComposition") = ""
            Dr("LiningWeight") = 0
            Dr("BuyerTargetPrice") = 0
            Dr("BuyerPriceUnit") = ""
            Dr("BuyerMOQ") = 0
            dtStyleProductInformation.Rows.Add(Dr)

        Next

        Session("dtStyleProductInformation") = dtStyleProductInformation
        If cmbProductPortfolio.SelectedValue = 1 Then
            'BindcmbBaseItemForHomeTextile()
            'lblitem.Text = "Item"
            'Uplblitem.Update()
        Else
            'lblitem.Text = "Base Item"
            'Uplblitem.Update()
        End If

    End Sub

    Protected Sub btnAddMoreProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMoreProduct.Click
        Try
            AddNewRowToGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0
        Dim rowcount As Decimal
        If Session("dtStyleProductInformation") IsNot Nothing Then
            Dim dtStyleProductInformation As DataTable = DirectCast(Session("dtStyleProductInformation"), DataTable)
            Dim dr As DataRow = Nothing
            If dtStyleProductInformation.Rows.Count > 0 Then
                For i As Integer = 1 To dtStyleProductInformation.Rows.Count
                    'extract the TextBox values

                    Dim txtPack As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtPack"), TextBox)
                    Dim txtRow As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtRow"), TextBox)
                    Dim txtItem As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtItem"), TextBox)
                    Dim cmbFabricType As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbFabricType"), DropDownList)
                    Dim txtHSCode As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtHSCode"), TextBox)
                    Dim cmbFabFinish As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbFabFinish"), DropDownList)
                    Dim txtFCons As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtFCons"), TextBox)
                    Dim cmbFComp As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbFComp"), DropDownList)
                    Dim txtFWt As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtFWt"), TextBox)
                    Dim cmbFWtUnit As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbFWtUnit"), DropDownList)
                    Dim txtGarmentWt As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtGarmentWt"), TextBox)
                    Dim cmbGarmentWtUnit As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbGarmentWtUnit"), DropDownList)
                    Dim txtColor As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtColor"), TextBox)
                    Dim txtBuyerTargetPrice1 As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtBuyerTargetPrice1"), TextBox)
                    Dim txtBuyerMOQ1 As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtBuyerMOQ1"), TextBox)
                    Dim cmbBuyerPriceUnit1 As DropDownList = CType(dgProductinfo.Items(rowIndex).FindControl("cmbBuyerPriceUnit1"), DropDownList)
                    Dim txtRemarks As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtRemarks"), TextBox)
                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(rowIndex).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(rowIndex).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(rowIndex).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(rowIndex).FindControl("txtLiningWt"), TextBox)
                    Dim Lining As String = dgProductinfo.Items(rowIndex).Cells(25).Text

                    Dim SproductID As String = dgProductinfo.Items(rowIndex).Cells(0).Text
                    Dim ProductPortfolioID As String = dgProductinfo.Items(rowIndex).Cells(1).Text
                    Dim ProductCategoriesID As String = dgProductinfo.Items(rowIndex).Cells(2).Text
                    Dim ProductConsumerID As String = dgProductinfo.Items(rowIndex).Cells(3).Text
                    rowcount = Val(dtStyleProductInformation.Rows.Count) + 1
                    dr = dtStyleProductInformation.NewRow()
                    dr("InquirySproductID") = SproductID
                    dr("ProductPortfolioID") = cmbProductPortfolio.SelectedValue 'ProductPortfolioID
                    dr("ProductCategoriesID") = cmbProductCategory.SelectedValue 'ProductCategoriesID
                    dr("ProductConsumerID") = cmbProductConsumerGrp.SelectedValue 'ProductConsumerID
                    ' dr("RowNo") = "Item" + " " + rowcount.ToString()
                    If cmbProductPortfolio.SelectedValue = 1 Then
                        dr("RowNo") = "Item" + " " + rowcount.ToString()
                    Else
                        dr("RowNo") = "Row" + " " + rowcount.ToString()
                    End If
                    dr("Pack") = cmbPack.SelectedItem.Text
                    '   dr("Item") = cmbProductCategory.SelectedItem.Text
                    If cmbProductPortfolio.SelectedValue = 1 Then
                        dr("Item") = cmbProductCategory.SelectedItem.Text
                    Else
                        dr("Item") = "Item" + " " + rowcount.ToString()
                    End If
                    dr("HSCode") = ""
                    dr("FabicType") = ""
                    dr("FabicTypeID") = ""
                    dr("FabicCons") = ""
                    dr("CompositionID") = 0
                    dr("FabicWt") = 0
                    dr("FabicWtUnitID") = 0
                    dr("GarmentWt") = 0
                    dr("GarmentWtUnitID") = 0
                    dr("Color") = ""
                    dr("Rremarks") = ""
                    dr("FabFinishID") = ""
                    dr("FabFinish") = ""
                    dr("ProductConsumerGroup") = cmbProductConsumerGrp.SelectedItem.Text
                    dr("Lining") = cmbLining.SelectedItem.Text
                    dr("LiningTypeID") = 0
                    dr("LiningType") = ""
                    dr("LiningCons") = ""
                    dr("LiningCompID") = 0
                    dr("LiningComposition") = ""
                    dr("LiningWeight") = 0
                    dr("BuyerTargetPrice") = 0
                    dr("BuyerPriceUnit") = ""
                    dr("BuyerMOQ") = 0
                    ' dr("OpeningBal") = txtBalanceQty.Text
                    dtStyleProductInformation.Rows(i - 1)("RowNo") = txtRow.Text
                    dtStyleProductInformation.Rows(i - 1)("Pack") = txtPack.Text
                    dtStyleProductInformation.Rows(i - 1)("Item") = txtItem.Text
                    dtStyleProductInformation.Rows(i - 1)("HSCode") = txtHSCode.Text
                    dtStyleProductInformation.Rows(i - 1)("FabicType") = cmbFabricType.SelectedItem.Text
                    dtStyleProductInformation.Rows(i - 1)("FabicTypeID") = cmbFabricType.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("FabicCons") = txtFCons.Text
                    dtStyleProductInformation.Rows(i - 1)("CompositionID") = cmbFComp.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("FabicWt") = txtFWt.Text
                    dtStyleProductInformation.Rows(i - 1)("FabicWtUnitID") = cmbFWtUnit.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("GarmentWt") = txtGarmentWt.Text
                    dtStyleProductInformation.Rows(i - 1)("GarmentWtUnitID") = cmbGarmentWtUnit.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("Color") = txtColor.Text
                    dtStyleProductInformation.Rows(i - 1)("Rremarks") = txtRemarks.Text
                    dtStyleProductInformation.Rows(i - 1)("FabFinishID") = cmbFabFinish.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("FabFinish") = cmbFabFinish.SelectedItem.Text
                    dtStyleProductInformation.Rows(i - 1)("LiningTypeID") = cmbLiningType.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("LiningType") = cmbLiningType.SelectedItem.Text
                    dtStyleProductInformation.Rows(i - 1)("LiningCons") = txtLiningCons.Text
                    dtStyleProductInformation.Rows(i - 1)("LiningCompID") = cmbLinigComp.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("LiningComposition") = cmbLinigComp.SelectedItem.Text
                    dtStyleProductInformation.Rows(i - 1)("LiningWeight") = txtLiningWt.Text
                    dtStyleProductInformation.Rows(i - 1)("BuyerTargetPrice") = txtBuyerTargetPrice1.Text
                    dtStyleProductInformation.Rows(i - 1)("BuyerPriceUnit") = cmbBuyerPriceUnit1.SelectedValue
                    dtStyleProductInformation.Rows(i - 1)("BuyerMOQ") = txtBuyerMOQ1.Text
                    rowIndex += 1
                Next

                dtStyleProductInformation.Rows.Add(dr)
                dtStyleProductInformation.Rows(rowIndex)("InquirySproductID") = 0
                Session("dtStyleProductInformation") = dtStyleProductInformation

                dgProductinfo.DataSource = dtStyleProductInformation
                dgProductinfo.DataBind()
                UpUpbtnAutoComplete.Update()
                dgProductinfo.Visible = True

            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
        If cmbProductPortfolio.SelectedValue = 1 Then
            'BindcmbBaseItemForHomeTextile()
            'lblitem.Text = "Item"
            'Uplblitem.Update()
        Else
            'BindcmbBaseItemadd()
            'lblitem.Text = "Base Item"
            'Uplblitem.Update()
        End If
        ' BindcmbBaseItemForHomeTextile()
        UpUpbtnAutoComplete.Update()
    End Sub
    Private Sub SetPreviousData()
        BindFWtUnit()
        BindGarmentWtUnit()
        BindComposition()
        BindFabricType()
        BindFabFinish()
        BindLinigType()
        Dim rowIndex As Integer = 0
        If Session("dtStyleProductInformation") IsNot Nothing Then
            Dim dtStyleProductInformation As DataTable = DirectCast(Session("dtStyleProductInformation"), DataTable)
            If dtStyleProductInformation.Rows.Count > 0 Then
                For i As Integer = 0 To dtStyleProductInformation.Rows.Count - 1
                    Dim txtPack As TextBox = CType(dgProductinfo.Items(i).FindControl("txtPack"), TextBox)
                    Dim txtRow As TextBox = CType(dgProductinfo.Items(i).FindControl("txtRow"), TextBox)
                    Dim txtItem As TextBox = CType(dgProductinfo.Items(i).FindControl("txtItem"), TextBox)
                    Dim cmbFabricType As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbFabricType"), DropDownList)
                    Dim txtHSCode As TextBox = CType(dgProductinfo.Items(i).FindControl("txtHSCode"), TextBox)
                    Dim cmbFabFinish As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbFabFinish"), DropDownList)
                    Dim txtFCons As TextBox = CType(dgProductinfo.Items(i).FindControl("txtFCons"), TextBox)
                    Dim cmbFComp As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbFComp"), DropDownList)
                    Dim txtFWt As TextBox = CType(dgProductinfo.Items(i).FindControl("txtFWt"), TextBox)
                    Dim cmbFWtUnit As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbFWtUnit"), DropDownList)
                    Dim txtGarmentWt As TextBox = CType(dgProductinfo.Items(i).FindControl("txtGarmentWt"), TextBox)
                    Dim cmbGarmentWtUnit As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbGarmentWtUnit"), DropDownList)
                    Dim txtColor As TextBox = CType(dgProductinfo.Items(i).FindControl("txtColor"), TextBox)
                    Dim txtBuyerTargetPrice1 As TextBox = CType(dgProductinfo.Items(i).FindControl("txtBuyerTargetPrice1"), TextBox)
                    Dim txtBuyerMOQ1 As TextBox = CType(dgProductinfo.Items(i).FindControl("txtBuyerMOQ1"), TextBox)
                    Dim cmbBuyerPriceUnit1 As DropDownList = CType(dgProductinfo.Items(i).FindControl("cmbBuyerPriceUnit1"), DropDownList)
                    Dim txtRemarks As TextBox = CType(dgProductinfo.Items(i).FindControl("txtRemarks"), TextBox)

                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(i).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(i).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(i).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(i).FindControl("txtLiningWt"), TextBox)

                    txtPack.Text = dtStyleProductInformation.Rows(i)("Pack").ToString
                    txtRow.Text = dtStyleProductInformation.Rows(i)("RowNo")
                    txtItem.Text = dtStyleProductInformation.Rows(i)("Item")
                    Dim Lining As String = dgProductinfo.Items(i).Cells(25).Text
                    If Lining = "Y" Then
                        cmbLiningType.Visible = True
                        txtLiningCons.Visible = True
                        cmbLinigComp.Visible = True
                        txtLiningWt.Visible = True
                        UpUpbtnAutoComplete.Update()
                    Else
                        cmbLiningType.Visible = False
                        txtLiningCons.Visible = False
                        cmbLinigComp.Visible = False
                        txtLiningWt.Visible = False
                        UpUpbtnAutoComplete.Update()
                    End If
                    If cmbProductPortfolio.SelectedValue = 1 Then

                        txtItem.ReadOnly = True
                    Else

                        txtItem.ReadOnly = False
                    End If

                    txtHSCode.Text = dtStyleProductInformation.Rows(i)("HSCode")
                    'cmbFabricType.SelectedItem.Text = dtStyleProductInformation.Rows(i)("FabicType")
                    cmbFabricType.SelectedValue = dtStyleProductInformation.Rows(i)("FabicTypeID")
                    txtFCons.Text = dtStyleProductInformation.Rows(i)("FabicCons")
                    cmbFComp.SelectedValue = dtStyleProductInformation.Rows(i)("CompositionID")
                    txtFWt.Text = dtStyleProductInformation.Rows(i)("FabicWt")
                    cmbFWtUnit.SelectedValue = dtStyleProductInformation.Rows(i)("FabicWtUnitID")
                    txtGarmentWt.Text = dtStyleProductInformation.Rows(i)("GarmentWt")
                    cmbGarmentWtUnit.SelectedValue = dtStyleProductInformation.Rows(i)("GarmentWtUnitID")
                    txtColor.Text = dtStyleProductInformation.Rows(i)("Color")
                    txtBuyerTargetPrice1.Text = dtStyleProductInformation.Rows(i)("BuyerTargetPrice")
                    txtBuyerMOQ1.Text = dtStyleProductInformation.Rows(i)("BuyerMOQ")
                    cmbBuyerPriceUnit1.SelectedValue = dtStyleProductInformation.Rows(i)("BuyerPriceUnit")

                    txtRemarks.Text = dtStyleProductInformation.Rows(i)("Rremarks")
                    cmbFabFinish.SelectedValue = dtStyleProductInformation.Rows(i)("FabFinishID")
                    cmbLiningType.SelectedValue = dtStyleProductInformation.Rows(i)("LiningTypeID")
                    ''cmbLiningType.SelectedItem.Text = dtStyleProductInformation.Rows(i)("LiningType")
                    txtLiningCons.Text = dtStyleProductInformation.Rows(i)("LiningCons")
                    cmbLinigComp.SelectedValue = dtStyleProductInformation.Rows(i)("LiningCompID")
                    'cmbLinigComp.SelectedItem.Text = dtStyleProductInformation.Rows(i)("LiningComposition")
                    txtLiningWt.Text = dtStyleProductInformation.Rows(i)("LiningWeight")
                    ' cmbFabFinish.SelectedItem.Text = dtStyleProductInformation.Rows(i)("FabFinish")
                    rowIndex += 1
                Next

            End If
        End If
    End Sub
    Private Function BindGridProduct() As Boolean
        If (Not dtStyleProductInformation Is Nothing) Then
            If (dtStyleProductInformation.Rows.Count > 0) Then

                dgProductinfo.DataSource = dtStyleProductInformation
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                UpUpbtnAutoComplete.Update()
                Return (True)
            Else
                dgProductinfo.Visible = False
                UpUpbtnAutoComplete.Update()
                Return (False)
            End If

        End If
        Return (False)


    End Function
    Private Sub BindFWtUnit()
        Dim dt As DataTable = objInquiriesEntryClass.GetUnits
        Dim x As Integer
        For x = 0 To dgProductinfo.Items.Count - 1
            Dim cmbFWtUnit As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
            cmbFWtUnit.DataSource = dt
            cmbFWtUnit.DataTextField = "UnitName"
            cmbFWtUnit.DataValueField = "UnitID"
            cmbFWtUnit.DataBind()
        Next
    End Sub
    Private Sub BindFWtUnit2()
        Dim dt As DataTable = objInquiriesEntryClass.GetUnits
        Dim x As Integer
        For x = 0 To dgConfrmOrder.Items.Count - 1
            Dim cmbFWtUnit2 As DropDownList = CType(dgConfrmOrder.Items(x).FindControl("cmbFWtUnit2"), DropDownList)
            cmbFWtUnit2.DataSource = dt
            cmbFWtUnit2.DataTextField = "UnitName"
            cmbFWtUnit2.DataValueField = "UnitID"
            cmbFWtUnit2.DataBind()
        Next
    End Sub
    Private Sub BindGarmentWtUnit()
        Dim dt As DataTable = objInquiriesEntryClass.GetUnits
        Dim x As Integer
        For x = 0 To dgProductinfo.Items.Count - 1
            Dim cmbGarmentWtUnit As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbGarmentWtUnit"), DropDownList)
            cmbGarmentWtUnit.DataSource = dt
            cmbGarmentWtUnit.DataTextField = "UnitName"
            cmbGarmentWtUnit.DataValueField = "UnitID"
            cmbGarmentWtUnit.DataBind()
        Next
    End Sub
    Sub BindComposition()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetComposition
            Dim x As Integer
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim cmbFComp As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbFComp"), DropDownList)
                Dim cmbLinigComp As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                cmbFComp.DataSource = dt
                cmbFComp.DataTextField = "CompositionName"
                cmbFComp.DataValueField = "CompositionID"
                cmbFComp.DataBind()

                cmbLinigComp.DataSource = dt
                cmbLinigComp.DataTextField = "CompositionName"
                cmbLinigComp.DataValueField = "CompositionID"
                cmbLinigComp.DataBind()
            Next
            cmbFComp1.DataSource = dt
            cmbFComp1.DataTextField = "CompositionName"
            cmbFComp1.DataValueField = "CompositionID"
            cmbFComp1.DataBind()

            cmbFComp2.DataSource = dt
            cmbFComp2.DataTextField = "CompositionName"
            cmbFComp2.DataValueField = "CompositionID"
            cmbFComp2.DataBind()

            cmbFComp3.DataSource = dt
            cmbFComp3.DataTextField = "CompositionName"
            cmbFComp3.DataValueField = "CompositionID"
            cmbFComp3.DataBind()

            cmbFComp4.DataSource = dt
            cmbFComp4.DataTextField = "CompositionName"
            cmbFComp4.DataValueField = "CompositionID"
            cmbFComp4.DataBind()

            cmbFComp5.DataSource = dt
            cmbFComp5.DataTextField = "CompositionName"
            cmbFComp5.DataValueField = "CompositionID"
            cmbFComp5.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindCompositionQuoted()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetComposition
            cmbFComp1.DataSource = dt
            cmbFComp1.DataTextField = "CompositionName"
            cmbFComp1.DataValueField = "CompositionID"
            cmbFComp1.DataBind()

            cmbFComp2.DataSource = dt
            cmbFComp2.DataTextField = "CompositionName"
            cmbFComp2.DataValueField = "CompositionID"
            cmbFComp2.DataBind()

            cmbFComp3.DataSource = dt
            cmbFComp3.DataTextField = "CompositionName"
            cmbFComp3.DataValueField = "CompositionID"
            cmbFComp3.DataBind()

            cmbFComp4.DataSource = dt
            cmbFComp4.DataTextField = "CompositionName"
            cmbFComp4.DataValueField = "CompositionID"
            cmbFComp4.DataBind()

            cmbFComp5.DataSource = dt
            cmbFComp5.DataTextField = "CompositionName"
            cmbFComp5.DataValueField = "CompositionID"
            cmbFComp5.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindComposition2()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetComposition
            Dim x As Integer
            For x = 0 To dgConfrmOrder.Items.Count - 1
                Dim cmbFComp2 As DropDownList = CType(dgConfrmOrder.Items(x).FindControl("cmbFComp2"), DropDownList)
                cmbFComp2.DataSource = dt
                cmbFComp2.DataTextField = "CompositionName"
                cmbFComp2.DataValueField = "CompositionID"
                cmbFComp2.DataBind()

            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub BindFabFinish()
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objInquiriesEntryClass.GetAllProductType
            Dim x As Integer
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim cmbFabFinish As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)
                cmbFabFinish.DataSource = dtProductGroup
                cmbFabFinish.DataTextField = "ProductType"
                cmbFabFinish.DataValueField = "TypeID"
                cmbFabFinish.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub BindFabFinish2()
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objInquiriesEntryClass.GetAllProductType
            Dim x As Integer
            For x = 0 To dgConfrmOrder.Items.Count - 1
                Dim cmbFabFinish2 As DropDownList = CType(dgConfrmOrder.Items(x).FindControl("cmbFabFinish2"), DropDownList)
                cmbFabFinish2.DataSource = dtProductGroup
                cmbFabFinish2.DataTextField = "ProductType"
                cmbFabFinish2.DataValueField = "TypeID"
                cmbFabFinish2.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub BindFabricType()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetFabricType
            Dim x As Integer
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim cmbFabricType As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbFabricType"), DropDownList)
                cmbFabricType.DataSource = dt
                cmbFabricType.DataTextField = "FabricType"
                cmbFabricType.DataValueField = "FabricTypeID"
                cmbFabricType.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub BindFabricType2()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetFabricType
            Dim x As Integer
            For x = 0 To dgConfrmOrder.Items.Count - 1
                Dim cmbFabricType2 As DropDownList = CType(dgConfrmOrder.Items(x).FindControl("cmbFabricType2"), DropDownList)
                cmbFabricType2.DataSource = dt
                cmbFabricType2.DataTextField = "FabricType"
                cmbFabricType2.DataValueField = "FabricTypeID"
                cmbFabricType2.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub BindLinigType()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetLiningType
            Dim x As Integer
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim cmbLiningType As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                cmbLiningType.DataSource = dt
                cmbLiningType.DataTextField = "LiningType"
                cmbLiningType.DataValueField = "LiningTypeID"
                cmbLiningType.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAutoComplete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAutoComplete.Click
        Try
            'Dim txtRow1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtRow"), TextBox)
            ' Dim txtPack1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtPack"), TextBox)
            Dim txtItem1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtItem"), TextBox)
            Dim txtHSCode1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtHSCode"), TextBox)
            Dim txtFType1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtFType"), TextBox)
            Dim txtFCons1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtFCons"), TextBox)
            Dim cmbFComp1 As DropDownList = DirectCast(dgProductinfo.Items(0).FindControl("cmbFComp"), DropDownList)
            Dim txtFWt1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtFWt"), TextBox)
            Dim cmbFWtUnit1 As DropDownList = DirectCast(dgProductinfo.Items(0).FindControl("cmbFWtUnit"), DropDownList)
            Dim txtGarmentWt1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtGarmentWt"), TextBox)
            Dim cmbGarmentWtUnit1 As DropDownList = DirectCast(dgProductinfo.Items(0).FindControl("cmbGarmentWtUnit"), DropDownList)
            Dim txtColor1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtColor"), TextBox)
            Dim txtRemarks1 As TextBox = DirectCast(dgProductinfo.Items(0).FindControl("txtRemarks"), TextBox)

            For x = 0 To dgProductinfo.Items.Count - 1
                Dim txtRow As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRow"), TextBox)
                Dim txtPack As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtPack"), TextBox)
                Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)
                Dim txtHSCode As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtHSCode"), TextBox)
                Dim txtFType As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFType"), TextBox)
                Dim txtFCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFCons"), TextBox)
                Dim cmbFComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFComp"), DropDownList)
                Dim txtFWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFWt"), TextBox)
                Dim cmbFWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
                Dim txtGarmentWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtGarmentWt"), TextBox)
                Dim cmbGarmentWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbGarmentWtUnit"), DropDownList)
                Dim txtColor As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtColor"), TextBox)
                Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)

                'txtRow.Text = txtRow1.Text
                ' txtPack.Text = txtPack1.Text
                txtItem.Text = txtItem1.Text
                txtHSCode.Text = txtHSCode1.Text
                txtFType.Text = txtFType1.Text
                txtFCons.Text = txtFCons1.Text
                cmbFComp.SelectedValue = cmbFComp1.SelectedValue
                txtFWt.Text = txtFWt1.Text
                cmbFWtUnit.SelectedValue = cmbFWtUnit1.SelectedValue
                txtGarmentWt.Text = txtGarmentWt1.Text
                cmbGarmentWtUnit.SelectedValue = cmbGarmentWtUnit1.SelectedValue
                txtColor.Text = txtColor1.Text
                txtRemarks.Text = txtRemarks1.Text
            Next
            UpUpbtnAutoComplete.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgProductinfo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductinfo.ItemCommand
        Select Case e.CommandName
            Case Is = "RemoveProduct"
                dtStyleProductInformation = CType(Session("dtStyleProductInformation"), DataTable)
                If (Not dtStyleProductInformation Is Nothing) Then
                    If (dtStyleProductInformation.Rows.Count > 0) Then
                        If cmbProductPortfolio.SelectedValue = 1 Then
                            Dim SproductID As Long = dgProductinfo.Items(e.Item.ItemIndex).Cells(0).Text
                            Dim StyleID As Long = dgProductinfo.Items(e.Item.ItemIndex).Cells(1).Text
                            dtStyleProductInformation.Rows.RemoveAt(e.Item.ItemIndex)
                            objInquiryStyleProductionInformation.DeleteDetail(SproductID)
                            Session("dtStyleProductInformation") = dtStyleProductInformation
                            If dtStyleProductInformation.Rows.Count > 0 Then
                                dgProductinfo.DataSource = dtStyleProductInformation
                                dgProductinfo.DataBind()
                                UpUpbtnAutoComplete.Update()
                                dgProductinfo.Visible = True
                                btnAddProduct.Visible = False
                                btnAddMoreProduct.Visible = True
                                btnAutoComplete.Visible = True
                                Upadd.Update()
                            Else
                                btnAddProduct.Visible = True
                                btnAddMoreProduct.Visible = False
                                btnAutoComplete.Visible = True
                                dgProductinfo.Visible = False
                                Upadd.Update()
                            End If
                            '  BindcmbBaseItemForHomeTextile()
                            SetPreviousData()

                            ' dtStyle.Rows.Clear()
                            'objStyleDetail.DeleteDetailall(StyleID)
                            'dgColor.DataSource = Nothing
                            'dgColor.DataBind()
                            'If cmbProductPortfolio.SelectedValue = 1 Then
                            '    dgColor.Columns(2).HeaderText = "Item"
                            'Else
                            '    dgColor.Columns(2).HeaderText = "BaseRow"
                            'End If
                            'UpdatePanel9.Update()
                        Else
                            dtStyleProductInformation.Rows.Clear()

                            dgProductinfo.DataSource = Nothing
                            dgProductinfo.DataBind()

                            'dtStyle.Rows.Clear()
                            'dgColor.DataSource = Nothing
                            'dgColor.DataBind()
                            'If cmbProductPortfolio.SelectedValue = 1 Then
                            '    dgColor.Columns(2).HeaderText = "Item"
                            'Else
                            '    dgColor.Columns(2).HeaderText = "BaseRow"
                            'End If
                            'UpdatePanel9.Update()

                            'cmbBaseItem.DataSource = Nothing
                            'cmbBaseItem.DataBind()
                            btnAddProduct.Visible = True
                            btnAddMoreProduct.Visible = False
                            btnAutoComplete.Visible = True
                            Upadd.Update()
                        End If


                    Else

                    End If
                End If

        End Select
    End Sub
    Protected Sub btnUploadNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUploadNew.Click
        Try


            Session("FileNameP") = Nothing
            Session("ImageByteP") = Nothing
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload2.FileName)
            If FileUpload2.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                pictureNotAvialable()
                lnkFIlePicture.Visible = True
            ElseIf fileExt = ".jpg" Or fileExt = ".pdf" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileNameTP As String = ""
                Dim fs As System.IO.Stream = FileUpload2.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytesTP As Byte() = br.ReadBytes(CType(fs.Length, Integer))

                FileNameTP = FileUpload2.FileName
                Session("FileNameP") = FileNameTP
                Session("ImageByteP") = bytesTP
                lnkFIlePicture.Visible = True
                ' btnUploadNew.Visible = False

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only jpg or Pdf file allow to upload")
            End If
            'If IEnquiriesSystemID > 0 Then
            '    Dim dt As DataTable = objEnquiresesEntryaddclass.getEdit(IEnquiriesSystemID)
            '    If dt.Rows.Count > 0 Then
            '        txtRecvDate.Text = dt.Rows(0)("RecvDate")
            '    End If

            'Else
            '    txtRecvDate.Text = ""
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Sub pictureNotAvialable()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        ' Session("FileName") = "NoImage.JPEG"
        ' Session("ImageByte") = GetFileContent(path2)
        Session("ImageByteP") = GetFileContent(path)
        Session("FileNameP") = "no-image.jpg"
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Protected Sub lnkFIlePicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFIlePicture.Click
        Try
            '  ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('SRQTechPackUploadShow.aspx?FileName=" & Session("FileNameTP") & "&Byte=" & Session("ImageByteTP") & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
            'Response.Write("<script> window.open('SRQTechPackUploadShow.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

            ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('EnquiryPicturePopUp.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try

            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No empty.")
            Else
                savedata()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub savedata()
        'If txtStyleNo.Text = "" Then
        '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No empty.")
        'Else
        If dgProductinfo.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Product Info. required.")

        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            With objInquiriesEntryClass
                If InquiryStyleID > 0 Then
                    .InquiryStyleID = InquiryStyleID

                Else
                    .InquiryStyleID = 0
                End If
                .CreationDate = txtTodaydate.SelectedDate.Value.ToString("yyyy-MM-dd")
                .StyleNo = txtStyleNo.Text
                .CoreLine = cmbSpecialLine.SelectedItem.Text 'txtCoreLine.Text
                .BuyerName = cmbBuyerName.SelectedItem.Text
                .StyleDescription = txtStyleDescription.Text
                .UserID = CLng(Session("UserID"))
                .CustomerID = cmbCustomer.SelectedValue
                .BuyingDept = cmbBuyingDept.SelectedValue
                .SeasonID = cmbSeason.SelectedValue
                .StyleSource = cmbStyleSource.SelectedItem.Text
                .BrandName = cmbBrand.SelectedValue
                .RecvDate = txtRecvDate.SelectedDate
                '.ExFactoryDate = txtExFactoryDate.Text
                .ExFactoryDate = "N/A"
                .EnquiryType = cmbEnquireType.SelectedItem.Text
                '.POStatus = cmbPOStatus.SelectedItem.Text
                If InquiryStyleID > 0 Then
                    .POStatus = cmbPOStatus.SelectedItem.Text
                Else
                    .POStatus = "Pending"
                End If

                If Session("FileNameP") = "" Then
                    pictureNotAvialable()
                    .FileName = Session("FileNameP")
                    .Picture = Session("ImageByteP")
                Else
                    .FileName = Session("FileNameP")
                    .Picture = Session("ImageByteP")
                End If
                .EnquiryPurpose = cmbEnquiryPurpose.SelectedItem.Text
                '.EnquiryConfirmDate = txtEnquiryConfirmDate.Text
                If InquiryStyleID > 0 Then
                    .EnquiryConfirmDate = txtEnquiryConfirmDate.Text
                Else
                    .EnquiryConfirmDate = ""
                End If

                .DesignName = txtDesignName.Text
                .DiffcultyLevel = cmbHighDifficultyLevel.SelectedItem.Text
                .ReasonofCancel = txtReasonofCancel.Text
                .SaveEnquiryStyle()
            End With


            'For Colro info
            Dim x As Integer = 0
            For x = 0 To dgProductinfo.Items.Count - 1
                Dim txtRow As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRow"), TextBox)
                Dim txtPack As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtPack"), TextBox)
                Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)
                Dim txtHSCode As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtHSCode"), TextBox)
                Dim cmbFabricType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabricType"), DropDownList)
                Dim txtFCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFCons"), TextBox)
                Dim cmbFComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFComp"), DropDownList)
                Dim txtFWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFWt"), TextBox)
                Dim cmbFWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
                Dim txtGarmentWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtGarmentWt"), TextBox)
                Dim cmbGarmentWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbGarmentWtUnit"), DropDownList)
                Dim txtColor As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtColor"), TextBox)
                Dim txtBuyerTargetPrice1 As TextBox = CType(dgProductinfo.Items(x).FindControl("txtBuyerTargetPrice1"), TextBox)
                Dim txtBuyerMOQ1 As TextBox = CType(dgProductinfo.Items(x).FindControl("txtBuyerMOQ1"), TextBox)
                Dim cmbBuyerPriceUnit1 As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbBuyerPriceUnit1"), DropDownList)
                Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)
                Dim cmbFabFinish As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)

                Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
                Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)
                With objInquiryStyleProductionInformation
                    .InquirySproductID = dgProductinfo.Items(x).Cells(0).Text
                    If InquiryStyleID > 0 Then

                        .InquiryStyleID = InquiryStyleID

                    Else
                        .InquiryStyleID = objInquiriesEntryClass.GetId()
                    End If
                    .RowNo = txtRow.Text
                    .ProductPortfolioID = dgProductinfo.Items(x).Cells(1).Text
                    .ProductCategoriesID = dgProductinfo.Items(x).Cells(2).Text
                    .ProductConsumerID = dgProductinfo.Items(x).Cells(3).Text
                    .Pack = txtPack.Text
                    .Item = txtItem.Text
                    .HSCode = txtHSCode.Text
                    .FabricTypeID = cmbFabricType.SelectedValue
                    .FabicCons = txtFCons.Text
                    .CompositionID = cmbFComp.SelectedValue   '  id
                    .FabicWt = Val(txtFWt.Text)
                    .FabicWtUnitID = cmbFWtUnit.SelectedValue
                    .GarmentWt = Val(txtGarmentWt.Text)
                    .GarmentWtUnitID = cmbGarmentWtUnit.SelectedValue
                    .Color = txtColor.Text
                    .Rremarks = txtRemarks.Text
                    .FabFinishID = cmbFabFinish.SelectedValue
                    .Lining = dgProductinfo.Items(x).Cells(25).Text
                    .LiningTypeID = cmbLiningType.SelectedValue
                    .LiningCons = txtLiningCons.Text
                    .LiningCompId = cmbLinigComp.SelectedValue
                    If txtLiningWt.Text = "" Then
                        .LiningWt = 0
                    Else
                        .LiningWt = txtLiningWt.Text
                    End If
                    If txtBuyerTargetPrice1.Text = "" Then
                        .BuyerTargetPrice = 0
                    Else
                        .BuyerTargetPrice = txtBuyerTargetPrice1.Text
                    End If
                    .BuyerPriceUnit = cmbBuyerPriceUnit1.SelectedValue
                    If txtBuyerMOQ1.Text = "" Then
                        .BuyerMOQ = 0
                    Else
                        .BuyerMOQ = txtBuyerMOQ1.Text
                    End If
                    .SaveStyleProductInformation()
                End With
            Next
            For x = 0 To dgAccessories.Items.Count - 1
                With objInqStyleAccessories
                    .InqSAID = dgAccessories.Items(x).Cells(0).Text
                    If InquiryStyleID > 0 Then
                        .InquiryStyleID = InquiryStyleID
                    Else
                        .InquiryStyleID = objInquiriesEntryClass.GetId()
                    End If
                    .AccessoriesID = dgAccessories.Items(x).Cells(1).Text
                    .AccessoriesDescription = dgAccessories.Items(x).Cells(3).Text
                    .Source = dgAccessories.Items(x).Cells(4).Text
                    .ConAcc = dgAccessories.Items(x).Cells(5).Text
                    .OnlyConAcc = 0
                    .SaveStyleAccessories()
                End With
            Next

            Session("ImageByteP") = Nothing
            Session("FileNameP") = Nothing
            Session("dtStyleProductInformation") = Nothing
            Session("dtAccessories") = Nothing

            Response.Redirect("InquiryStyleView.aspx")
        End If
    End Sub



    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("InquiryStyleView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddQuotation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddQuotation.Click
        Try
            SaveSessionQuotation()
            BindGridQuotation()
            ClearControls()
        Catch ex As Exception

        End Try
    End Sub
    Sub ClearControls()
        txtBuyerTargetPrice.Text = ""
        txtBuyerMOQ.Text = ""
        CbmSupplier1.SelectedValue = 0
        txtQuotedPrice1.Text = ""
        cmbSupplier2.SelectedValue = 0
        txtQuotedPrice2.Text = ""
        cmbSupplier3.SelectedValue = 0
        txtQuotedPrice3.Text = ""
        cmbSupplier4.SelectedValue = 0
        txtQuotedPrice4.Text = ""
        cmbSupplier5.SelectedValue = 0
        txtQuotedPrice5.Text = ""
        txtSupplierMOQ5.Text = ""
        txtSupplierMOQ4.Text = ""
        txtSupplierMOQ3.Text = ""
        txtSupplierMOQ2.Text = ""
        txtSupplierMOQ1.Text = ""

    End Sub
    Sub SaveSessionQuotation()
        If (Not CType(Session("dtQuotationInformation"), DataTable) Is Nothing) Then
            dtQuotationInformation = Session("dtQuotationInformation")
        Else
            dtQuotationInformation = New DataTable
            With dtQuotationInformation
                .Columns.Add("InquiryQuotationID", GetType(Long))
                .Columns.Add("InquirySproductID", GetType(Long))
                .Columns.Add("RowNo", GetType(String))
                .Columns.Add("BuyerTargetPrice", GetType(String))
                .Columns.Add("BuyerPriceUnit", GetType(String))
                .Columns.Add("BuyerMOQ", GetType(String))
                .Columns.Add("SupplierID1", GetType(String))
                .Columns.Add("Supplier1", GetType(String))
                .Columns.Add("FCons1", GetType(String))
                .Columns.Add("CompositionID1", GetType(String))
                .Columns.Add("FComp1", GetType(String))
                .Columns.Add("FWT1", GetType(String))
                .Columns.Add("QuotedPrice1", GetType(String))
                .Columns.Add("QuotedPriceUnit1", GetType(String))
                .Columns.Add("SupplierID2", GetType(String))
                .Columns.Add("Supplier2", GetType(String))
                .Columns.Add("FCons2", GetType(String))
                .Columns.Add("CompositionID2", GetType(String))
                .Columns.Add("FComp2", GetType(String))
                .Columns.Add("FWT2", GetType(String))

                .Columns.Add("QuotedPrice2", GetType(String))
                .Columns.Add("QuotedPriceUnit2", GetType(String))
                .Columns.Add("SupplierID3", GetType(String))
                .Columns.Add("Supplier3", GetType(String))
                .Columns.Add("FCons3", GetType(String))
                .Columns.Add("CompositionID3", GetType(String))
                .Columns.Add("FComp3", GetType(String))
                .Columns.Add("FWT3", GetType(String))

                .Columns.Add("QuotedPrice3", GetType(String))
                .Columns.Add("QuotedPriceUnit3", GetType(String))
                .Columns.Add("SupplierID4", GetType(String))
                .Columns.Add("Supplier4", GetType(String))
                .Columns.Add("FCons4", GetType(String))
                .Columns.Add("CompositionID4", GetType(String))
                .Columns.Add("FComp4", GetType(String))
                .Columns.Add("FWT4", GetType(String))

                .Columns.Add("QuotedPrice4", GetType(String))
                .Columns.Add("QuotedPriceUnit4", GetType(String))
                .Columns.Add("SupplierID5", GetType(String))
                .Columns.Add("Supplier5", GetType(String))
                .Columns.Add("FCons5", GetType(String))
                .Columns.Add("CompositionID5", GetType(String))
                .Columns.Add("FComp5", GetType(String))
                .Columns.Add("FWT5", GetType(String))

                .Columns.Add("QuotedPrice5", GetType(String))
                .Columns.Add("QuotedPriceUnit5", GetType(String))
                .Columns.Add("QuotedRemarks", GetType(String))
                .Columns.Add("SupplierMOQ1", GetType(String))
                .Columns.Add("SupplierMOQ2", GetType(String))
                .Columns.Add("SupplierMOQ3", GetType(String))
                .Columns.Add("SupplierMOQ4", GetType(String))
                .Columns.Add("SupplierMOQ5", GetType(String))
            End With
        End If
        Dr = dtQuotationInformation.NewRow()
        If lblInquiryQuotationID.Text > 0 Then
            Dr("InquiryQuotationID") = lblInquiryQuotationID.Text
        Else
            Dr("InquiryQuotationID") = 0
        End If

        Dr("InquirySproductID") = cmbRow.SelectedValue
        Dr("RowNo") = cmbRow.SelectedItem.Text
        If txtBuyerTargetPrice.Text = "" Then
            Dr("BuyerTargetPrice") = 0
        Else
            Dr("BuyerTargetPrice") = txtBuyerTargetPrice.Text
        End If

        If txtBuyerMOQ.Text = "" Then
            Dr("BuyerMOQ") = 0
        Else
            Dr("BuyerMOQ") = txtBuyerMOQ.Text
        End If
        Dr("BuyerPriceUnit") = cmbBuyerPriceUnit.SelectedItem.Text

        Dr("SupplierID1") = CbmSupplier1.SelectedValue
        If CbmSupplier1.SelectedValue = 0 Then
            Dr("Supplier1") = ""
        Else
            Dr("Supplier1") = CbmSupplier1.SelectedItem.Text
        End If

        If CbmSupplier1.SelectedValue <> 0 Then
            If txtFCons1.Text = "" Then
                Dr("FCons1") = ""
            Else
                Dr("FCons1") = txtFCons1.Text
            End If
            If CbmSupplier1.SelectedValue = 0 Then
                Dr("CompositionID1") = 0
                Dr("FComp1") = ""
            Else
                Dr("CompositionID1") = cmbFComp1.SelectedValue
                Dr("FComp1") = cmbFComp1.SelectedItem.Text
            End If
            If txtFwt1.Text = "" Then
                Dr("FWT1") = 0
            Else
                Dr("FWT1") = txtFwt1.Text
            End If
            If txtQuotedPrice1.Text = "" Then
                Dr("QuotedPrice1") = 0
            Else
                Dr("QuotedPrice1") = txtQuotedPrice1.Text
            End If
            Dr("QuotedPriceUnit1") = cmbUnitQuotedPrice1.SelectedItem.Text
        Else
            Dr("FCons1") = ""
            Dr("CompositionID1") = 0
            Dr("FComp1") = ""
            Dr("FWT1") = 0
            Dr("QuotedPrice1") = 0
            Dr("QuotedPriceUnit1") = cmbUnitQuotedPrice1.SelectedItem.Text
        End If
        Dr("SupplierID2") = cmbSupplier2.SelectedValue
        If cmbSupplier2.SelectedValue <> 0 Then
            If cmbSupplier2.SelectedValue = 0 Then
                Dr("Supplier2") = ""
            Else
                Dr("Supplier2") = cmbSupplier2.SelectedItem.Text
            End If
            If txtFCons2.Text = "" Then
                Dr("FCons2") = ""
            Else
                Dr("FCons2") = txtFCons2.Text
            End If
            If cmbSupplier2.SelectedValue = 0 Then
                Dr("CompositionID2") = 0
                Dr("FComp2") = ""
            Else
                Dr("CompositionID2") = cmbFComp2.SelectedValue
                Dr("FComp2") = cmbFComp2.SelectedItem.Text
            End If
            If txtFWt2.Text = "" Then
                Dr("FWT2") = 0
            Else
                Dr("FWT2") = txtFWt2.Text
            End If
            If txtQuotedPrice2.Text = "" Then
                Dr("QuotedPrice2") = 0
            Else
                Dr("QuotedPrice2") = txtQuotedPrice2.Text
            End If
            Dr("QuotedPriceUnit2") = cmbUnitQuotedPrice2.SelectedItem.Text
        Else
            Dr("FCons2") = ""
            Dr("CompositionID2") = 0
            Dr("FComp2") = ""
            Dr("FWT2") = 0
            Dr("QuotedPrice2") = 0
            Dr("QuotedPriceUnit2") = cmbUnitQuotedPrice2.SelectedItem.Text
        End If
        Dr("SupplierID3") = cmbSupplier3.SelectedValue
        If cmbSupplier3.SelectedValue <> 0 Then

            If cmbSupplier3.SelectedValue = 0 Then
                Dr("Supplier3") = ""
            Else
                Dr("Supplier3") = cmbSupplier3.SelectedItem.Text
            End If
            If txtFCons3.Text = "" Then
                Dr("FCons3") = ""
            Else
                Dr("FCons3") = txtFCons3.Text
            End If
            If cmbSupplier3.SelectedValue = 0 Then
                Dr("CompositionID3") = 0
                Dr("FComp3") = ""
            Else
                Dr("CompositionID3") = cmbFComp3.SelectedValue
                Dr("FComp3") = cmbFComp3.SelectedItem.Text
            End If
            If txtFWt3.Text = "" Then
                Dr("FWT3") = 0
            Else
                Dr("FWT3") = txtFWt3.Text
            End If
            If txtQuotedPrice3.Text = "" Then
                Dr("QuotedPrice3") = 0
            Else
                Dr("QuotedPrice3") = txtQuotedPrice3.Text
            End If
            Dr("QuotedPriceUnit3") = cmbUnitQuotedPrice3.SelectedItem.Text
        Else
            Dr("FCons3") = ""
            Dr("CompositionID3") = 0
            Dr("FComp3") = ""
            Dr("FWT3") = 0
            Dr("QuotedPrice3") = 0
            Dr("QuotedPriceUnit3") = cmbUnitQuotedPrice3.SelectedItem.Text
        End If
        Dr("SupplierID4") = cmbSupplier4.SelectedValue
        If cmbSupplier4.SelectedValue <> 0 Then
            If cmbSupplier4.SelectedValue = 0 Then
                Dr("Supplier4") = ""
            Else
                Dr("Supplier4") = cmbSupplier4.SelectedItem.Text
            End If

            If txtFCons4.Text = "" Then
                Dr("FCons4") = ""
            Else
                Dr("FCons4") = txtFCons4.Text
            End If
            If cmbSupplier4.SelectedValue = 0 Then
                Dr("CompositionID4") = 0
                Dr("FComp4") = ""
            Else
                Dr("CompositionID4") = cmbFComp4.SelectedValue
                Dr("FComp4") = cmbFComp4.SelectedItem.Text
            End If

            If txtFWt4.Text = "" Then
                Dr("FWT4") = 0
            Else
                Dr("FWT4") = txtFWt4.Text
            End If

            If txtQuotedPrice4.Text = "" Then
                Dr("QuotedPrice4") = 0
            Else
                Dr("QuotedPrice4") = txtQuotedPrice4.Text
            End If
            Dr("QuotedPriceUnit4") = cmbUnitQuotedPrice4.SelectedItem.Text
        Else
            Dr("FCons4") = ""
            Dr("CompositionID4") = 0
            Dr("FComp4") = ""
            Dr("FWT4") = 0
            Dr("QuotedPrice4") = 0
            Dr("QuotedPriceUnit4") = cmbUnitQuotedPrice4.SelectedItem.Text
        End If
        Dr("SupplierID5") = cmbSupplier5.SelectedValue
        If cmbSupplier5.SelectedValue <> 0 Then
            If cmbSupplier5.SelectedValue = 0 Then
                Dr("Supplier5") = ""
            Else
                Dr("Supplier5") = cmbSupplier5.SelectedItem.Text
            End If
            If txtFCons5.Text = "" Then
                Dr("FCons5") = ""
            Else
                Dr("FCons5") = txtFCons5.Text
            End If
            If cmbSupplier5.SelectedValue = 0 Then
                Dr("CompositionID5") = 0
                Dr("FComp5") = ""
            Else
                Dr("CompositionID5") = cmbFComp5.SelectedValue
                Dr("FComp5") = cmbFComp5.SelectedItem.Text
            End If

            If txtFWt5.Text = "" Then
                Dr("FWT5") = 0
            Else
                Dr("FWT5") = txtFWt5.Text
            End If
            If txtQuotedPrice5.Text = "" Then
                Dr("QuotedPrice5") = 0
            Else
                Dr("QuotedPrice5") = txtQuotedPrice5.Text
            End If
            Dr("QuotedPriceUnit5") = cmbUnitQuotedPrice5.SelectedItem.Text
        Else
            Dr("FCons5") = ""
            Dr("CompositionID5") = 0
            Dr("FComp5") = ""
            Dr("FWT5") = 0
            Dr("QuotedPrice5") = 0
            Dr("QuotedPriceUnit5") = cmbUnitQuotedPrice5.SelectedItem.Text
        End If
        Dr("QuotedRemarks") = txtQuotedRemarks.Text
        If txtSupplierMOQ1.Text = "" Then
            Dr("SupplierMOQ1") = 0
        Else
            Dr("SupplierMOQ1") = txtSupplierMOQ1.Text
        End If

        If txtSupplierMOQ2.Text = "" Then
            Dr("SupplierMOQ2") = 0
        Else
            Dr("SupplierMOQ2") = txtSupplierMOQ2.Text
        End If
        If txtSupplierMOQ3.Text = "" Then
            Dr("SupplierMOQ3") = 0
        Else
            Dr("SupplierMOQ3") = txtSupplierMOQ3.Text
        End If
        If txtSupplierMOQ4.Text = "" Then
            Dr("SupplierMOQ4") = 0
        Else
            Dr("SupplierMOQ4") = txtSupplierMOQ4.Text
        End If
        If txtSupplierMOQ5.Text = "" Then
            Dr("SupplierMOQ5") = 0
        Else
            Dr("SupplierMOQ5") = txtSupplierMOQ5.Text
        End If

        dtQuotationInformation.Rows.Add(Dr)
        Session("dtQuotationInformation") = dtQuotationInformation
    End Sub
    Private Function BindGridQuotation() As Boolean
        If (Not dtQuotationInformation Is Nothing) Then
            If (dtQuotationInformation.Rows.Count > 0) Then

                dgQuotation.DataSource = dtQuotationInformation
                dgQuotation.DataBind()
                dgQuotation.Visible = True
                UpdgQuotation.Update()
                Return (True)
            Else
                dgQuotation.Visible = False
                UpdgQuotation.Update()
                Return (False)
            End If

        End If
        Return (False)


    End Function
    Protected Sub dgQuotation_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgQuotation.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    'dtDetail = CType(Session("dtDetail"), DataTable)
                    'If (Not dtDetail Is Nothing) Then
                    '    If (dtDetail.Rows.Count > 0) Then
                    '        Dim POInvoiceDetailID As Integer = dgProductdetail.Items(e.Item.ItemIndex).Cells(0).Text
                    '        dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                    '        objPOInvoiceMaster.DeleteDetail(POInvoiceDetailID)
                    '        BindGrid()
                    '    End If
                    'End If

                Case "Edit"
                    dtQuotationInformation = CType(Session("dtQuotationInformation"), DataTable)
                    If (Not dtQuotationInformation Is Nothing) Then
                        If (dtQuotationInformation.Rows.Count > 0) Then
                            Dim POInvoiceDetailID As Integer = dgQuotation.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtQuotationInformation.Rows.RemoveAt(e.Item.ItemIndex)
                            Session("dtQuotationInformation") = dtQuotationInformation
                            BindGridQuotation()
                            'btnAdd.Visible = True
                            'If dtDetail.Rows.Count = 0 Then
                            '    PanelExp.Visible = False
                            '    LblCredits.Visible = False
                            '    LblNetAmount.Visible = False
                            'Else
                            '    PanelExp.Visible = True
                            '    LblCredits.Visible = True
                            '    LblNetAmount.Visible = True
                            'End If
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            lblInquiryQuotationID.Text = dtQuotationInformation.Rows(dtrowNo)("InquiryQuotationID")
            cmbRow.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("InquirySproductID")
            '    cmbRow.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("RowNo")
            txtBuyerTargetPrice.Text = dtQuotationInformation.Rows(dtrowNo)("BuyerTargetPrice")
            txtBuyerMOQ.Text = dtQuotationInformation.Rows(dtrowNo)("BuyerMOQ")
            cmbBuyerPriceUnit.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("BuyerPriceUnit")
            CbmSupplier1.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("SupplierID1")
            txtFCons1.Text = dtQuotationInformation.Rows(dtrowNo)("FCons1")
            cmbFComp1.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("CompositionID1")
            ' cmbFComp1.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("FComp1")
            txtFwt1.Text = dtQuotationInformation.Rows(dtrowNo)("FWT1")
            txtQuotedPrice1.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPrice1")
            cmbUnitQuotedPrice1.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPriceUnit1")
            cmbSupplier2.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("SupplierID2")
            txtFCons2.Text = dtQuotationInformation.Rows(dtrowNo)("FCons2")
            txtFWt2.Text = dtQuotationInformation.Rows(dtrowNo)("FWT2")
            cmbFComp2.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("CompositionID2")
            txtQuotedPrice2.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPrice2")
            cmbUnitQuotedPrice2.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPriceUnit2")
            cmbSupplier3.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("SupplierID3")
            cmbFComp3.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("CompositionID3")
            txtFCons3.Text = dtQuotationInformation.Rows(dtrowNo)("FCons3")
            txtFWt3.Text = dtQuotationInformation.Rows(dtrowNo)("FWT3")
            txtQuotedPrice3.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPrice3")
            cmbUnitQuotedPrice3.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPriceUnit3")
            cmbSupplier4.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("SupplierID4")
            cmbFComp4.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("CompositionID4")
            txtFCons4.Text = dtQuotationInformation.Rows(dtrowNo)("FCons4")
            txtFWt4.Text = dtQuotationInformation.Rows(dtrowNo)("FWT4")
            txtQuotedPrice4.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPrice4")
            cmbUnitQuotedPrice4.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPriceUnit4")
            cmbSupplier5.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("SupplierID5")
            txtFCons5.Text = dtQuotationInformation.Rows(dtrowNo)("FCons5")
            cmbFComp5.SelectedValue = dtQuotationInformation.Rows(dtrowNo)("CompositionID5")
            txtFWt5.Text = dtQuotationInformation.Rows(dtrowNo)("FWT5")
            txtQuotedPrice5.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPrice5")
            cmbUnitQuotedPrice5.SelectedItem.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedPriceUnit5")
            txtQuotedRemarks.Text = dtQuotationInformation.Rows(dtrowNo)("QuotedRemarks")
            txtSupplierMOQ1.Text = dtQuotationInformation.Rows(dtrowNo)("SupplierMOQ1")
            txtSupplierMOQ2.Text = dtQuotationInformation.Rows(dtrowNo)("SupplierMOQ2")
            txtSupplierMOQ3.Text = dtQuotationInformation.Rows(dtrowNo)("SupplierMOQ3")
            txtSupplierMOQ4.Text = dtQuotationInformation.Rows(dtrowNo)("SupplierMOQ4")
            txtSupplierMOQ5.Text = dtQuotationInformation.Rows(dtrowNo)("SupplierMOQ5")

            UpBuyerTargetPrice.Update()
            UptxtBuyerMOQ.Update()
            UpCbmSupplier1.Update()
            UpFCons1.Update()
            UpdatePanel5.Update()

            UpFWT1.Update()
            UpSupplierMOQ1.Update()
            UpdatePanel4.Update()

            UpSupplier2.Update()
            UpFCons.Update()
            UpFComp2.Update()
            UpFWt.Update()
            UptxtSupplierMOQ2.Update()
            UpQuotedPrice2.Update()
            UpSupplier3.Update()
            UpFCons3.Update()
            UpFComp3.Update()

            UpFWt3.Update()
            UptxtSupplierMOQ3.Update()
            UpQuotedPrice3.Update()
            UpUpSupplier4.Update()
            UpFCons4.Update()
            UpFComp4.Update()
            UpFWt4.Update()
            UptxtSupplierMOQ4.Update()
            UpQuotedPrice4.Update()
            UpSupplier5.Update()
            UpFCons5.Update()
            UpFComp5.Update()
            UpFWt5.Update()
            UptxtSupplierMOQ5.Update()
            UpQuotedPrice5.Update()
            UptxtSupplierReamrks.Update()
            UpdatePanel2.Update()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSAVEQuotation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSAVEQuotation.Click
        Try
            If dgProductinfo.Items.Count = 0 Then

            Else
                SAVEQuotation()
                Response.Redirect("InquiryStyleView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SAVEQuotation()
        Dim x As Integer = 0
        For x = 0 To dgQuotation.Items.Count - 1
            With objtblStyleQuotationInformation
                .InquiryQuotationID = dgQuotation.Items(x).Cells(0).Text
                .InquiryStyleID = InquiryStyleID
                .InquirySproductID = dgQuotation.Items(x).Cells(1).Text
                .RowNo = dgQuotation.Items(x).Cells(2).Text
                .BuyerTargetPrice = dgQuotation.Items(x).Cells(3).Text
                .BuyerPriceUnit = dgQuotation.Items(x).Cells(4).Text
                .BuyerMOQ = dgQuotation.Items(x).Cells(5).Text
                .SupplierID1 = dgQuotation.Items(x).Cells(6).Text
                .QuotedPrice1 = dgQuotation.Items(x).Cells(13).Text
                .QuotedPriceUnit1 = dgQuotation.Items(x).Cells(14).Text
                .SupplierID2 = dgQuotation.Items(x).Cells(15).Text
                .QuotedPrice2 = dgQuotation.Items(x).Cells(22).Text
                .QuotedPriceUnit2 = dgQuotation.Items(x).Cells(23).Text
                .SupplierID3 = dgQuotation.Items(x).Cells(24).Text
                .QuotedPrice3 = dgQuotation.Items(x).Cells(31).Text
                .QuotedPriceUnit3 = dgQuotation.Items(x).Cells(32).Text
                .SupplierID4 = dgQuotation.Items(x).Cells(33).Text
                .QuotedPrice4 = dgQuotation.Items(x).Cells(40).Text
                .QuotedPriceUnit4 = dgQuotation.Items(x).Cells(41).Text
                .SupplierID5 = dgQuotation.Items(x).Cells(42).Text
                .QuotedPrice5 = dgQuotation.Items(x).Cells(49).Text
                .QuotedPriceUnit5 = dgQuotation.Items(x).Cells(50).Text
                .FCons1 = dgQuotation.Items(x).Cells(8).Text
                .CompositionID1 = dgQuotation.Items(x).Cells(9).Text
                .FWT1 = dgQuotation.Items(x).Cells(11).Text
                .FCons2 = dgQuotation.Items(x).Cells(17).Text
                .CompositionID2 = dgQuotation.Items(x).Cells(18).Text
                .FWT2 = dgQuotation.Items(x).Cells(20).Text
                .FCons3 = dgQuotation.Items(x).Cells(26).Text
                .CompositionID3 = dgQuotation.Items(x).Cells(27).Text
                .FWT3 = dgQuotation.Items(x).Cells(29).Text
                .FCons4 = dgQuotation.Items(x).Cells(35).Text
                .CompositionID4 = dgQuotation.Items(x).Cells(36).Text
                .FWT4 = dgQuotation.Items(x).Cells(38).Text
                .FCons5 = dgQuotation.Items(x).Cells(44).Text
                .CompositionID5 = dgQuotation.Items(x).Cells(45).Text
                .FWT5 = dgQuotation.Items(x).Cells(47).Text
                .QuotedRemarks = dgQuotation.Items(x).Cells(51).Text
                .SupplierMOQ1 = dgQuotation.Items(x).Cells(12).Text
                .SupplierMOQ2 = dgQuotation.Items(x).Cells(21).Text
                .SupplierMOQ3 = dgQuotation.Items(x).Cells(30).Text
                .SupplierMOQ4 = dgQuotation.Items(x).Cells(39).Text
                .SupplierMOQ5 = dgQuotation.Items(x).Cells(48).Text
                .SaveInquiryQuotation()
            End With
        Next
    End Sub
    Protected Sub btnCancelQuotation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelQuotation.Click
        Try
            Response.Redirect("InquiryStyleView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnConfirmedSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmedSave.Click
        Try
            If txtCADArtworkRecvDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill CAD/Artwork Recv Date ")
            ElseIf txtTackPackDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Tack Pack Date")
            Else
                Dim x As Integer = 0

                Dim check As Integer = 0
                For x = 0 To dgConfrmOrder.Items.Count - 1
                    Dim ChkUpdate As CheckBox = DirectCast(dgConfrmOrder.Items(x).FindControl("ChkUpdate"), CheckBox)
                    If ChkUpdate.Checked = True Then
                        check = 1
                    End If
                Next
                If check > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    UpdateInquries()
                    SaveConfirmed()
                    Response.Redirect("InquiryStyleView.aspx")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At Least one check before save")
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub UpdateInquries()
        Try
            objInquiriesEntryClass.UpdatePOStatusAndConfirmDateNew(InquiryStyleID, txtEnquiryConfirmDate.Text, cmbPOStatus.SelectedItem.Text, txtReasonofCancel.Text)
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveConfirmed()
        Dim x As Integer = 0
        For x = 0 To dgConfrmOrder.Items.Count - 1
            Dim txtColor2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtColor2"), TextBox)
            Dim txtQty2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtQty2"), TextBox)
            Dim txtRemarks2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtRemarks2"), TextBox)
            Dim txtPrice As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtPrice"), TextBox)
            Dim ChkUpdate As CheckBox = DirectCast(dgConfrmOrder.Items(x).FindControl("ChkUpdate"), CheckBox)
            Dim txtFCons2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtFCons2"), TextBox)
            Dim cmbFComp2 As DropDownList = DirectCast(dgConfrmOrder.Items(x).FindControl("cmbFComp2"), DropDownList)
            Dim txtFWt2 As TextBox = DirectCast(dgConfrmOrder.Items(x).FindControl("txtFWt2"), TextBox)
            If ChkUpdate.Checked = True Then
                With ObjTblInquiryConfirmed
                    .InquiryConformedID = dgConfrmOrder.Items(x).Cells(0).Text
                    .InquiryStyleID = InquiryStyleID
                    .InquirySproductID = dgConfrmOrder.Items(x).Cells(1).Text
                    .SupplierId = cmbSupplierConfrmd.SelectedValue
                    .Color = txtColor2.Text
                    If txtQty2.Text = "" Then
                        .Qty = 0
                    Else
                        .Qty = txtQty2.Text
                    End If
                    If txtPrice.Text = "" Then
                        .Price = 0
                    Else
                        .Price = txtPrice.Text
                    End If

                    .ConfirmRemarks = txtRemarks2.Text
                    .CadArtDate = txtCADArtworkRecvDate.SelectedDate
                    .TackPack = txtTackPackDate.SelectedDate
                    .ConFConstruction = txtFCons2.Text
                    .ConCompostionId = cmbFComp2.SelectedValue
                    If txtFWt2.Text = "" Then
                        .ConFwt = 0
                    Else
                        .ConFwt = txtFWt2.Text
                    End If
                    .StylingDetail = txtStylingDetail.Text
                    .SaveInquiryConformed()
                End With
            End If
        Next
        For x = 0 To DgAcssCon.Items.Count - 1
            Dim ChkAccUpdate As CheckBox = DirectCast(DgAcssCon.Items(x).FindControl("ChkAccUpdate"), CheckBox)
            With objInqStyleAccessories
                .InqSAID = DgAcssCon.Items(x).Cells(0).Text
                If InquiryStyleID > 0 Then
                    .InquiryStyleID = InquiryStyleID
                Else
                    .InquiryStyleID = objInquiriesEntryClass.GetId()
                End If
                .AccessoriesID = DgAcssCon.Items(x).Cells(1).Text
                .AccessoriesDescription = DgAcssCon.Items(x).Cells(3).Text
                .Source = DgAcssCon.Items(x).Cells(4).Text
                If ChkAccUpdate.Checked = True Then
                    .ConAcc = 1
                Else
                    .ConAcc = 0
                End If

                .OnlyConAcc = DgAcssCon.Items(x).Cells(6).Text
                .SaveStyleAccessories()

            End With
        Next


    End Sub
    Protected Sub btnConfirmedCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmedCancel.Click
        Try
            Response.Redirect("InquiryStyleView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnShowcomparativecosting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowcomparativecosting.Click
        Try
            btnShowcomparativecosting.Visible = False
            btnHidecomparativecosting.Visible = True
            PnCosting.Visible = True
            pnconfrom.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnHidecomparativecosting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHidecomparativecosting.Click
        Try
            pnconfrom.Visible = True
            btnShowcomparativecosting.Visible = True
            btnHidecomparativecosting.Visible = False
            PnCosting.Visible = False
            BindAllSupplier()
            BindConformedPanel()
            pnconfrom.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbRow_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRow.SelectedIndexChanged
        Try
            Dim dtpd As DataTable = objInquiriesEntryClass.GetProductNew22(cmbRow.SelectedValue)
            If dtpd.Rows.Count > 0 Then
                txtFCons1.Text = dtpd.Rows(0)("FabicCons")
                txtFCons2.Text = dtpd.Rows(0)("FabicCons")
                txtFCons3.Text = dtpd.Rows(0)("FabicCons")
                txtFCons4.Text = dtpd.Rows(0)("FabicCons")
                txtFCons5.Text = dtpd.Rows(0)("FabicCons")


                cmbFComp1.SelectedValue = dtpd.Rows(0)("CompositionID")
                cmbFComp2.SelectedValue = dtpd.Rows(0)("CompositionID")
                cmbFComp3.SelectedValue = dtpd.Rows(0)("CompositionID")
                cmbFComp4.SelectedValue = dtpd.Rows(0)("CompositionID")
                cmbFComp5.SelectedValue = dtpd.Rows(0)("CompositionID")


                txtFwt1.Text = dtpd.Rows(0)("FabicWt")
                txtFWt2.Text = dtpd.Rows(0)("FabicWt")
                txtFWt3.Text = dtpd.Rows(0)("FabicWt")
                txtFWt4.Text = dtpd.Rows(0)("FabicWt")
                txtFWt5.Text = dtpd.Rows(0)("FabicWt")
                txtSupplierMOQ1.Text = dtpd.Rows(0)("BuyerMOQ")
                txtSupplierMOQ2.Text = dtpd.Rows(0)("BuyerMOQ")
                txtSupplierMOQ3.Text = dtpd.Rows(0)("BuyerMOQ")
                txtSupplierMOQ4.Text = dtpd.Rows(0)("BuyerMOQ")
                txtSupplierMOQ5.Text = dtpd.Rows(0)("BuyerMOQ")
                txtQuotedPrice1.Text = dtpd.Rows(0)("BuyerTargetPrice")
                txtQuotedPrice2.Text = dtpd.Rows(0)("BuyerTargetPrice")
                txtQuotedPrice3.Text = dtpd.Rows(0)("BuyerTargetPrice")
                txtQuotedPrice4.Text = dtpd.Rows(0)("BuyerTargetPrice")
                txtQuotedPrice5.Text = dtpd.Rows(0)("BuyerTargetPrice")
                txtBuyerMOQ.Text = dtpd.Rows(0)("BuyerMOQ")
                txtBuyerTargetPrice.Text = dtpd.Rows(0)("BuyerTargetPrice")
                cmbUnitQuotedPrice1.SelectedValue = dtpd.Rows(0)("BuyerPriceUnit")
                cmbUnitQuotedPrice2.SelectedValue = dtpd.Rows(0)("BuyerPriceUnit")
                cmbUnitQuotedPrice3.SelectedValue = dtpd.Rows(0)("BuyerPriceUnit")
                cmbUnitQuotedPrice4.SelectedValue = dtpd.Rows(0)("BuyerPriceUnit")
                cmbUnitQuotedPrice5.SelectedValue = dtpd.Rows(0)("BuyerPriceUnit")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddAccessories_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddAccessories.Click
        Try
            SaveSessionAcces()
            BindGridAcces()
            Updgacss.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionAcces()
        If (Not CType(Session("dtAccessories"), DataTable) Is Nothing) Then
            dtAccessories = Session("dtAccessories")
        Else
            dtAccessories = New DataTable
            With dtAccessories
                .Columns.Add("InqSAID", GetType(Long))
                .Columns.Add("AccessoriesID", GetType(Long))
                .Columns.Add("AccessoriesName", GetType(String))
                .Columns.Add("AccessoriesDescription", GetType(String))
                .Columns.Add("Source", GetType(String))
                .Columns.Add("ConAcc", GetType(String))
            End With
        End If
        Dr = dtAccessories.NewRow()
        Dr("InqSAID") = 0
        Dr("AccessoriesID") = cmbAccessories.SelectedValue
        Dr("AccessoriesName") = cmbAccessories.SelectedItem.Text
        Dr("AccessoriesDescription") = txtAccessoriesDescription.Text
        Dr("Source") = cmbSource.SelectedItem.Text
        Dr("ConAcc") = 0
        dtAccessories.Rows.Add(Dr)
        Session("dtAccessories") = dtAccessories
    End Sub
    Private Function BindGridAcces() As Boolean
        If (Not dtAccessories Is Nothing) Then
            If (dtAccessories.Rows.Count > 0) Then

                dgAccessories.DataSource = dtAccessories
                dgAccessories.DataBind()
                dgAccessories.Visible = True
                Return (True)
            Else
                dgAccessories.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
    Protected Sub btnConfrimAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfrimAdd.Click
        Try
            SaveSessionAccesCon()
            BindGridAccesCon()
            For x = 0 To DgAcssCon.Items.Count - 1
                Dim ChkAccUpdate As CheckBox = DirectCast(DgAcssCon.Items(x).FindControl("ChkAccUpdate"), CheckBox)
                If dtAccessoriesCon.Rows.Count > 0 Then
                    If dtAccessoriesCon.Rows(x)("ConAcc") = True Then
                        ChkAccUpdate.Checked = True
                    End If
                End If
            Next
            upDgAcssCon.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionAccesCon()
        If (Not CType(Session("dtAccessoriesCon"), DataTable) Is Nothing) Then
            dtAccessoriesCon = Session("dtAccessoriesCon")
        Else
            dtAccessoriesCon = New DataTable
            With dtAccessoriesCon
                .Columns.Add("InqSAID", GetType(Long))
                .Columns.Add("AccessoriesID", GetType(Long))
                .Columns.Add("AccessoriesName", GetType(String))
                .Columns.Add("AccessoriesDescription", GetType(String))
                .Columns.Add("Source", GetType(String))
                .Columns.Add("ConAcc", GetType(String))
                .Columns.Add("OnlyConAcc", GetType(String))
            End With
        End If
        Dr = dtAccessoriesCon.NewRow()
        Dr("InqSAID") = 0
        Dr("AccessoriesID") = cmbAccessoriesCon.SelectedValue
        Dr("AccessoriesName") = cmbAccessoriesCon.SelectedItem.Text
        Dr("AccessoriesDescription") = txtAccessoriesDescriptionCon.Text
        Dr("Source") = CmbSourceConfirm.SelectedItem.Text
        Dr("ConAcc") = 1
        Dr("OnlyConAcc") = 1
        dtAccessoriesCon.Rows.Add(Dr)
        Session("dtAccessoriesCon") = dtAccessoriesCon
    End Sub
    Private Function BindGridAccesCon() As Boolean
        If (Not dtAccessoriesCon Is Nothing) Then
            If (dtAccessoriesCon.Rows.Count > 0) Then

                DgAcssCon.DataSource = dtAccessoriesCon
                DgAcssCon.DataBind()
                DgAcssCon.Visible = True
                Return (True)
            Else
                DgAcssCon.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
    Protected Sub cmbPOStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPOStatus.SelectedIndexChanged
        Try
            If cmbPOStatus.SelectedItem.Text = "Cancelled" Then
                ReasonofCancel.Visible = True
                UpReasonofCancel.Update()
            Else
                ReasonofCancel.Visible = False
                UpReasonofCancel.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgAccessories_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAccessories.ItemCommand
        Select Case e.CommandName
            Case Is = "RemoveProduct"
                dtAccessories = CType(Session("dtAccessories"), DataTable)
                If (Not dtAccessories Is Nothing) Then
                    If (dtAccessories.Rows.Count > 0) Then
                        Dim InqSAID As Long = dgAccessories.Items(e.Item.ItemIndex).Cells(0).Text
                        dtAccessories.Rows.RemoveAt(e.Item.ItemIndex)
                        objInqStyleAccessories.DeleteDetailFromStyleAccessDetail(InqSAID)
                        Session("dtAccessories") = dtAccessories
                        dgAccessories.DataSource = dtAccessories
                        dgAccessories.DataBind()
                        Updgacss.Update()
                    Else

                    End If
                End If

        End Select
    End Sub
    Protected Sub DgAcssCon_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgAcssCon.ItemCommand
        Select Case e.CommandName
            Case Is = "RemoveProduct"
                dtAccessoriesCon = CType(Session("dtAccessoriesCon"), DataTable)
                If (Not dtAccessoriesCon Is Nothing) Then
                    If (dtAccessoriesCon.Rows.Count > 0) Then
                        Dim InqSAID As Long = DgAcssCon.Items(e.Item.ItemIndex).Cells(0).Text
                        dtAccessoriesCon.Rows.RemoveAt(e.Item.ItemIndex)
                        objInqStyleAccessories.DeleteDetailFromStyleAccessDetail(InqSAID)
                        Session("dtAccessoriesCon") = dtAccessoriesCon
                        DgAcssCon.DataSource = dtAccessoriesCon
                        DgAcssCon.DataBind()
                        For x = 0 To DgAcssCon.Items.Count - 1
                            Dim ChkAccUpdate As CheckBox = DirectCast(DgAcssCon.Items(x).FindControl("ChkAccUpdate"), CheckBox)
                            If dtAccessoriesCon.Rows.Count > 0 Then
                                If dtAccessoriesCon.Rows(x)("ConAcc") = True Then
                                    ChkAccUpdate.Checked = True
                                End If
                            End If
                        Next
                        upDgAcssCon.Update()
                    Else

                    End If
                End If

        End Select
    End Sub
End Class
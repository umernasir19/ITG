Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class JobOrderDatabaseEntry
    Inherits System.Web.UI.Page
    Dim objSeasonDatabase As New SeasonDatabase
    Dim objUser As New User
    Dim GeneralCode As New GeneralCode
    Dim UserId As Long
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim objJobOrderCertificateRequired As New JobOrderCertificateRequired
    Dim objJobOrderTestRequired As New JobOrderTestRequired
    Dim objPortDestinations As New PortDestinationsEntry
    Dim objBrandDatabase As New BrandDatabase
    Dim objShipmentMode As New ShipmentMode
    Dim lJoborderid As Long
    Dim dt As New DataTable
    Dim objGeneralCode As New GeneralCode
    Dim objStyle As New Style2
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjPaymentTerm As New PaymentTerm
    Dim ObjPortOrigin As New PortOrigin
    Dim ObjPortLoad As New PortLoad
    Dim ObjStyleDatabaseClass As New StyleDatabaseClass
    Dim objStyleDesc As New StyleDesriptionClass
    Dim Type As String
    Protected mintTimeout As Integer
    Protected mstrLoginURL As String
    Dim objDeliveryTermClass As New DeliveryTermClass
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim intRedirectTime As Integer = 2
        'mintTimeout = (Session.Timeout - intRedirectTime) * 150000
        mstrLoginURL = ResolveUrl("~/Login.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJoborderid = Request.QueryString("Joborderid")
        Type = Request.QueryString("Type")
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BinBuyer()
            BinBrand()
            BinSeason()
            BinPaymentTerm()
            BinShipmentMode()
            BinCurrency()
            LnkItemDatabase.Visible = False
            STLNOGenerateOnLoad()
            BinPortOrigin()
            BinPortLoad()
            checkPOrt()
            BinDeliveryTerm()
            Session("ImageByteFrontImage") = Nothing
            Session("FileNameFrontImage") = Nothing
            Session("ImageByteBackImage") = Nothing
            Session("FileNameBackImage") = Nothing
            If lJoborderid > 0 Then
                If Type = "Copy" Then
                    PanelAll.Enabled = False
                    txtSrNo.ReadOnly = False
                    GetForEditCopy()
                    btnAddMore.Visible = True
                    vtnSameStyle.Visible = True
                    btnAddDetail.Visible = False
                    btnSave.Text = "Save"
                    btnSave.Enabled = False
                    lnkprint.Visible = False
                    Inkprint2.Visible = False
                    GetSrno()
                Else
                    PanelAll.Enabled = True
                    txtSrNo.ReadOnly = True
                    GetForEdit()
                    btnAddMore.Visible = True
                    vtnSameStyle.Visible = True
                    btnAddDetail.Visible = False
                    btnSave.Text = "Update"
                    lnkprint.Visible = False
                    Inkprint2.Visible = False
                End If
            Else
                btnAddMore.Visible = False
                vtnSameStyle.Visible = False
                btnAddDetail.Visible = True
                btnSave.Text = "Save"
                STLNOGenerateOnLoad()
                GetSrno()
            End If
        End If
        PageHeader("JOB ORDER ENTRY FORM")
    End Sub
    Protected Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Calculate2()
    End Sub
    Protected Sub txtUnitPrice_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Calculate()
    End Sub
   Sub GetForEditCopy()
        Try
            Dim dtForEdit As New DataTable
            dtForEdit = objJobOrderdatabase.GetForEdit(lJoborderid)
            txtJobOrderNo.Text = dtForEdit.Rows(0)("JoborderNo")
            txtCustomerOrder.Text = dtForEdit.Rows(0)("CustomerOrder")
            cmbSeason.SelectedValue = dtForEdit.Rows(0)("SeasonDatabaseID")
            txtShipmentDate.Text = dtForEdit.Rows(0)("StyleShipmentDatee")
            cmbCurrency.SelectedValue = dtForEdit.Rows(0)("CurrencyID")
            cmbShipMode.SelectedValue = dtForEdit.Rows(0)("ShipmentModeID")
            txtShippingInstruction.Text = dtForEdit.Rows(0)("ShippingInstruction")
            cmbCustomer.SelectedValue = dtForEdit.Rows(0)("CustomerDatabaseID")
            cmbBrand.SelectedValue = dtForEdit.Rows(0)("BrandDatabaseID")
            txtOrderRecvDate.Text = dtForEdit.Rows(0)("OrderRecvDatee")
            cmbPayMode.SelectedValue = dtForEdit.Rows(0)("PaymentTermId")
            cmbSupplier.SelectedItem.Text = dtForEdit.Rows(0)("Supplier")
            txtSrNo.Text = dtForEdit.Rows(0)("SRNOPOne")
            txtSrNoTwo.Text = dtForEdit.Rows(0)("SRNOPTwo")
            cmbPortOrigin.SelectedItem.Text = dtForEdit.Rows(0)("PortOrigin")
            cmbPortLoad.SelectedItem.Text = dtForEdit.Rows(0)("PortLoad")
            cmbOrigin.SelectedValue = dtForEdit.Rows(0)("OriginId")
            txtShipmentDatee.Text = dtForEdit.Rows(0)("StyleShipmentDate")
            cmbDeliveryTerm.SelectedValue = dtForEdit.Rows(0)("DeliveryTermId")
            lblRecvDate.Text = dtForEdit.Rows(0)("OrderRecvDate")
            lblShipmentDate.Text = dtForEdit.Rows(0)("StyleShipmentDate")
            txtPONo.Text = dtForEdit.Rows(0)("PONo")
            txtPORefNo.Text = dtForEdit.Rows(0)("PORefNo")
            checkPOrt()
            Dim x As Integer
            Dim lTotalQuantity, lTotalvalue As Long
            Dim finalTotalQuantity As Long = 0
            Dim finalTotalvalue As Long = 0
            For x = 0 To dtForEdit.Rows.Count - 1
                lTotalQuantity = dtForEdit.Rows(x)("Quantity")
                finalTotalQuantity = Val(finalTotalQuantity) + Val(lTotalQuantity)
                lTotalvalue = dtForEdit.Rows(x)("Value")
                finalTotalvalue = Val(finalTotalvalue) + Val(lTotalvalue)
            Next
            Dim dtCertificatePopup As New DataTable
            dtCertificatePopup = objJobOrderdatabase.GetJobOrderCertificateRequiredPopup(lJoborderid)
            Session("dtCertificate") = dtCertificatePopup
            If Not Session("dtCertificate") Is Nothing Then
                rpCertificate.DataSource = dtCertificatePopup
                rpCertificate.DataBind()
            End If
            Dim dtTestRequiredPopup As New DataTable
            dtTestRequiredPopup = objJobOrderdatabase.GetJobOrderTestRequiredPopup(lJoborderid)
            Session("dtTestRequired") = dtTestRequiredPopup
            If Not Session("dtTestRequired") Is Nothing Then
                rptTestRequired.DataSource = dtTestRequiredPopup
                rptTestRequired.DataBind()
            End If
            TxtTotalQty.Text = finalTotalQuantity
            txtTotalAmount.Text = finalTotalvalue
            Session("CurrentTable") = dtForEdit
            Dim dtt As New DataTable()
            Dim dr As DataRow = Nothing
            dtt.Columns.Add(New DataColumn("JoborderDetailid", GetType(String)))
            dtt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column1", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column2", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column3", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column4", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column5", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column6", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column7", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column8", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column9", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column10", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column11", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column12", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column13", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column14", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column15", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column16", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column17", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column18", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column19", GetType(String)))
            For x = 0 To dtForEdit.Rows.Count - 1
                dr = dtt.NewRow()
                dr("JoborderDetailid") = dtForEdit.Rows(x)("JoborderDetailid")
                dr("RowNumber") = 1
                dr("Column1") = dtForEdit.Rows(x)("Style")
                dr("Column2") = dtForEdit.Rows(x)("ItemDatabaseID")
                dr("Column3") = dtForEdit.Rows(x)("Content")
                dr("Column4") = dtForEdit.Rows(x)("GSM")
                dr("Column5") = dtForEdit.Rows(x)("BuyerColor")
                dr("Column6") = dtForEdit.Rows(x)("Quantity")
                dr("Column7") = dtForEdit.Rows(x)("UNITID")
                dr("Column8") = dtForEdit.Rows(x)("UnitPrice")
                dr("Column9") = dtForEdit.Rows(x)("value")
                dr("Column10") = dtForEdit.Rows(x)("StyleShipmentDate")
                dr("Column11") = dtForEdit.Rows(x)("AfterWashGsm")
                dr("Column12") = dtForEdit.Rows(x)("DPRNDID")
                dr("Column13") = dtForEdit.Rows(x)("ItemDesc")
                dr("Column14") = dtForEdit.Rows(x)("ContentforBuyer")
                dr("Column15") = dtForEdit.Rows(x)("ColorCode")
                dr("Column16") = dtForEdit.Rows(x)("ItemCode")
                dr("Column17") = dtForEdit.Rows(x)("IMSItemID")
                dr("Column18") = dtForEdit.Rows(x)("Model")
                dr("Column19") = dtForEdit.Rows(x)("ParentCd")
                dtt.Rows.Add(dr)
            Next
            Session("CurrentTable") = dtt
            dgJobOrderDetail.DataSource = dtForEdit
            dgJobOrderDetail.DataBind()
            BindcmbItem()
            BindcmbUOM()
            BindStyleDescription()
            Dim drCurrentRow As DataRow = Nothing
            If dtForEdit.Rows.Count > 0 Then
                For i As Integer = 0 To dtForEdit.Rows.Count - 1
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = CType(dgJobOrderDetail.Items(i).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(i).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtColorCode"), TextBox)
                    Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtItemCode"), TextBox)
                    Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblItemID"), Label)
                    Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtModelRefNo"), TextBox)
                    Dim cmbItemDesc As DropDownList = CType(dgJobOrderDetail.Items(i).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtParentCd"), TextBox)
                    JoborderDetailid = dtForEdit.Rows(i)("JoborderDetailid")
                    txtStyle.Text = dtForEdit.Rows(i)("Style")
                    lblDPRNDid.Text = dtForEdit.Rows(i)("DPRNDID")
                    Dim DTItemName As DataTable = objJobOrderdatabase.GetDPItem(lblDPRNDid.Text)
                    If DTItemName.Rows.Count > 0 Then
                        cmbItem.DataSource = DTItemName
                        cmbItem.DataTextField = "DPItemName"
                        cmbItem.DataValueField = "DPItemDatabaseid" '   
                        cmbItem.DataBind()
                    Else
                    End If
                    cmbItem.SelectedValue = dtForEdit.Rows(i)("ItemDatabaseID")
                    cmbUOM.SelectedValue = dtForEdit.Rows(i)("UNITID")
                    txtContent.Text = dtForEdit.Rows(i)("Content")
                    txtGSM.Text = dtForEdit.Rows(i)("GSM")
                    txtBuyerColorName.Text = dtForEdit.Rows(i)("BuyerColor")
                    txtUnitPrice.Text = dtForEdit.Rows(i)("UnitPrice")
                    txtQuantity.Text = dtForEdit.Rows(i)("Quantity")
                    txtStyleShipmentDate.Text = dtForEdit.Rows(i)("StyleShipmentDate")
                    txtAmount.Text = dtForEdit.Rows(i)("value")
                    txtGSMAfter.Text = dtForEdit.Rows(i)("AfterWashGsm")
                    cmbItemDesc.SelectedItem.Text = dtForEdit.Rows(i)("ItemDesc")
                    txtContentforBuyer.Text = dtForEdit.Rows(i)("ContentforBuyer")
                    txtColorCode.Text = dtForEdit.Rows(i)("ColorCode")
                    txtItemCode.Text = dtForEdit.Rows(i)("ItemCode")
                    lblItemID.Text = dtForEdit.Rows(i)("IMSItemID")
                    txtModelRefNo.Text = dtForEdit.Rows(i)("Model")
                    txtParentCd.Text = dtForEdit.Rows(i)("ParentCd")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub GetForEdit()
        Try
            Dim dtForEdit As New DataTable
            dtForEdit = objJobOrderdatabase.GetForEdit(lJoborderid)
            txtJobOrderNo.Text = dtForEdit.Rows(0)("JoborderNo")
            txtCustomerOrder.Text = dtForEdit.Rows(0)("CustomerOrder")
            cmbSeason.SelectedValue = dtForEdit.Rows(0)("SeasonDatabaseID")
            txtShipmentDate.Text = dtForEdit.Rows(0)("StyleShipmentDatee")
            cmbCurrency.SelectedValue = dtForEdit.Rows(0)("CurrencyID")
            cmbShipMode.SelectedValue = dtForEdit.Rows(0)("ShipmentModeID")
            txtShippingInstruction.Text = dtForEdit.Rows(0)("ShippingInstruction")
            cmbCustomer.SelectedValue = dtForEdit.Rows(0)("CustomerDatabaseID")
            cmbBrand.SelectedValue = dtForEdit.Rows(0)("BrandDatabaseID")
            txtOrderRecvDate.Text = dtForEdit.Rows(0)("OrderRecvDatee")
            cmbPayMode.SelectedValue = dtForEdit.Rows(0)("PaymentTermId")
            cmbSupplier.SelectedItem.Text = dtForEdit.Rows(0)("Supplier")
            txtSrNo.Text = dtForEdit.Rows(0)("SRNOPOne")
            txtSrNoTwo.Text = dtForEdit.Rows(0)("SRNOPTwo")
            cmbPortOrigin.SelectedItem.Text = dtForEdit.Rows(0)("PortOrigin")
            cmbPortLoad.SelectedItem.Text = dtForEdit.Rows(0)("PortLoad")
            cmbOrigin.SelectedValue = dtForEdit.Rows(0)("OriginId")
            txtShipmentDatee.Text = dtForEdit.Rows(0)("StyleShipmentDate")
            cmbDeliveryTerm.SelectedValue = dtForEdit.Rows(0)("DeliveryTermId")
            lblShipmentStatus.Text = dtForEdit.Rows(0)("ShipmentStatus")
            lblUserId.Text = dtForEdit.Rows(0)("UserId")
            txtPONo.Text = dtForEdit.Rows(0)("PONo")
            txtPORefNo.Text = dtForEdit.Rows(0)("PORefNo")
            checkPOrt()
            lblRecvDate.Text = dtForEdit.Rows(0)("OrderRecvDate")
            lblShipmentDate.Text = dtForEdit.Rows(0)("StyleShipmentDate")
            Dim x As Integer
            Dim lTotalQuantity, lTotalvalue As Long
            Dim finalTotalQuantity As Long = 0
            Dim finalTotalvalue As Long = 0
            For x = 0 To dtForEdit.Rows.Count - 1
                lTotalQuantity = dtForEdit.Rows(x)("Quantity")
                finalTotalQuantity = Val(finalTotalQuantity) + Val(lTotalQuantity)

                lTotalvalue = dtForEdit.Rows(x)("Value")
                finalTotalvalue = Val(finalTotalvalue) + Val(lTotalvalue)
            Next
            Dim dtCertificatePopup As New DataTable
            dtCertificatePopup = objJobOrderdatabase.GetJobOrderCertificateRequiredPopup(lJoborderid)
            Session("dtCertificate") = dtCertificatePopup
            If Not Session("dtCertificate") Is Nothing Then
                rpCertificate.DataSource = dtCertificatePopup
                rpCertificate.DataBind()
            End If
            Dim dtTestRequiredPopup As New DataTable
            dtTestRequiredPopup = objJobOrderdatabase.GetJobOrderTestRequiredPopup(lJoborderid)
            Session("dtTestRequired") = dtTestRequiredPopup
            If Not Session("dtTestRequired") Is Nothing Then
                rptTestRequired.DataSource = dtTestRequiredPopup
                rptTestRequired.DataBind()
            End If
            TxtTotalQty.Text = finalTotalQuantity
            txtTotalAmount.Text = finalTotalvalue
            Session("CurrentTable") = dtForEdit
            Dim dtt As New DataTable()
            Dim dr As DataRow = Nothing
            dtt.Columns.Add(New DataColumn("JoborderDetailid", GetType(String)))
            dtt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column1", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column2", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column3", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column4", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column5", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column6", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column7", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column8", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column9", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column10", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column11", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column12", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column13", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column14", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column15", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column16", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column17", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column18", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column19", GetType(String)))
            For x = 0 To dtForEdit.Rows.Count - 1
                dr = dtt.NewRow()
                dr("JoborderDetailid") = dtForEdit.Rows(x)("JoborderDetailid")
                dr("RowNumber") = 1
                dr("Column1") = dtForEdit.Rows(x)("Style")
                dr("Column2") = dtForEdit.Rows(x)("ItemDatabaseID")
                dr("Column3") = dtForEdit.Rows(x)("Content")
                dr("Column4") = dtForEdit.Rows(x)("GSM")
                dr("Column5") = dtForEdit.Rows(x)("BuyerColor")
                dr("Column6") = dtForEdit.Rows(x)("Quantity")
                dr("Column7") = dtForEdit.Rows(x)("UNITID")
                dr("Column8") = dtForEdit.Rows(x)("UnitPrice")
                dr("Column9") = dtForEdit.Rows(x)("value")
                dr("Column10") = dtForEdit.Rows(x)("StyleShipmentDate")
                dr("Column11") = dtForEdit.Rows(x)("AfterWashGsm")
                dr("Column12") = dtForEdit.Rows(x)("DPRNDID")
                dr("Column13") = dtForEdit.Rows(x)("ItemDesc")
                dr("Column14") = dtForEdit.Rows(x)("ContentforBuyer")
                dr("Column15") = dtForEdit.Rows(x)("ColorCode")
                dr("Column16") = dtForEdit.Rows(x)("ItemCode")
                dr("Column17") = dtForEdit.Rows(x)("IMSItemID")
                dr("Column18") = dtForEdit.Rows(x)("Model")
                dr("Column19") = dtForEdit.Rows(x)("ParentCd")
                dtt.Rows.Add(dr)
            Next
            Session("CurrentTable") = dtt
            dgJobOrderDetail.DataSource = dtForEdit
            dgJobOrderDetail.DataBind()
            BindcmbItem()
            BindcmbUOM()
            BindStyleDescription()
            Dim drCurrentRow As DataRow = Nothing
            If dtForEdit.Rows.Count > 0 Then
                For i As Integer = 0 To dtForEdit.Rows.Count - 1
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = CType(dgJobOrderDetail.Items(i).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(i).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtColorCode"), TextBox)
                    Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtItemCode"), TextBox)
                    Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblItemID"), Label)
                    Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtModelRefNo"), TextBox)
                    Dim cmbItemDesc As DropDownList = CType(dgJobOrderDetail.Items(i).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtParentCd"), TextBox)
                    JoborderDetailid = dtForEdit.Rows(i)("JoborderDetailid")
                    txtStyle.Text = dtForEdit.Rows(i)("Style")
                    lblDPRNDid.Text = dtForEdit.Rows(i)("DPRNDID")
                    Dim DTItemName As DataTable = objJobOrderdatabase.GetDPItem(lblDPRNDid.Text)
                    If DTItemName.Rows.Count > 0 Then
                        cmbItem.DataSource = DTItemName
                        cmbItem.DataTextField = "DPItemName"
                        cmbItem.DataValueField = "DPItemDatabaseid" '   
                        cmbItem.DataBind()
                    Else
                    End If
                    cmbItem.SelectedValue = dtForEdit.Rows(i)("ItemDatabaseID")
                    cmbUOM.SelectedValue = dtForEdit.Rows(i)("UNITID")
                    txtContent.Text = dtForEdit.Rows(i)("Content")
                    txtGSM.Text = dtForEdit.Rows(i)("GSM")
                    txtBuyerColorName.Text = dtForEdit.Rows(i)("BuyerColor")
                    txtUnitPrice.Text = dtForEdit.Rows(i)("UnitPrice")
                    txtQuantity.Text = dtForEdit.Rows(i)("Quantity")
                    txtStyleShipmentDate.Text = dtForEdit.Rows(i)("StyleShipmentDate")
                    txtAmount.Text = dtForEdit.Rows(i)("value")
                    txtGSMAfter.Text = dtForEdit.Rows(i)("AfterWashGsm")
                    cmbItemDesc.SelectedItem.Text = dtForEdit.Rows(i)("ItemDesc")
                    txtContentforBuyer.Text = dtForEdit.Rows(i)("ContentforBuyer")
                    txtColorCode.Text = dtForEdit.Rows(i)("ColorCode")
                    txtItemCode.Text = dtForEdit.Rows(i)("ItemCode")
                    lblItemID.Text = dtForEdit.Rows(i)("IMSItemID")
                    txtModelRefNo.Text = dtForEdit.Rows(i)("Model")
                    txtParentCd.Text = dtForEdit.Rows(i)("ParentCd")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
       GetSrno
    End Sub
    Sub BinDeliveryTerm()
        Dim dt As DataTable
        dt = objSizeRange.GetDeliveryTerm()
        cmbDeliveryTerm.DataSource = dt
        cmbDeliveryTerm.DataTextField = "DeliveryTerm"
        cmbDeliveryTerm.DataValueField = "DeliveryTermID"
        cmbDeliveryTerm.DataBind()
        cmbDeliveryTerm.Items.Insert(0, "Select")
    End Sub
    Sub GetSrno()
        Try
            Dim dt As DataTable = objJobOrderdatabase.GetSRNONew2(cmbSeason.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtSrNo.Text = dt.Rows(0)("SRNOPOne")
                txtSrNoTwo.Text = dt.Rows(0)("SRNOPTwo")
                lbloldSR.Text = dt.Rows(0)("SRNO")
            Else
                txtSrNo.Text = 0
                txtSrNoTwo.Text = ""
                lbloldSR.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub STLNOGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim currentSRQEntrydate As Date = Date.Today
            Dim year As String = currentSRQEntrydate.Year
            year = year.Substring(2, 2)
            Dim LastCode As String

            Dim lastNo As Integer = objJobOrderdatabase.GetMaxLastNo()
            If lastNo = 0 Then
                LastCode = "00001"
            Else
                If lastNo < 10 Then
                    If lastNo = 9 Then
                        LastCode = "000" & Val(lastNo + 1)
                    Else
                        LastCode = "0000" & Val(lastNo + 1)
                    End If

                ElseIf lastNo < 100 Or lastNo = 10 Then
                    If lastNo = 99 Then
                        LastCode = "00" & Val(lastNo + 1)
                    Else
                        LastCode = "000" & Val(lastNo + 1)
                    End If
                ElseIf lastNo < 1000 Or lastNo = 100 Then
                    If lastNo = 999 Then
                        LastCode = "0" & Val(lastNo + 1)
                    Else
                        LastCode = "00" & Val(lastNo + 1)
                    End If
                Else
                    LastCode = Val(lastNo + 1)
                End If
            End If
            VoucherNo = "DAL-JO-" & LastCode
            txtJobOrderNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub AutoJobNo()
        Try
            Dim jobNo As Decimal = Convert.ToDecimal(objJobOrderdatabase.AutoJobNo())
            If jobNo >= 0 And jobNo <= 9 Then
                txtJobOrderNo.Text = "000" + (jobNo + 1).ToString()
            ElseIf jobNo >= 10 And jobNo <= 99 Then
                txtJobOrderNo.Text = "00" + (jobNo + 1).ToString()
            ElseIf jobNo >= 100 And jobNo <= 999 Then
                txtJobOrderNo.Text = "0" + (jobNo + 1).ToString()
            Else
                txtJobOrderNo.Text = (jobNo + 1).ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BinBuyer()
        Dim dt As DataTable
        dt = objSizeRange.GetBuyer()
        cmbCustomer.DataSource = dt
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
    End Sub
    Sub BinBrand()
        Dim dtB As DataTable
        dtB = objSizeRange.GetBrand()
        cmbBrand.DataSource = dtB
        cmbBrand.DataTextField = "Brand"
        cmbBrand.DataValueField = "BrandDatabaseID"
        cmbBrand.DataBind()
    End Sub
    Sub BinSeason()
        Dim dt As DataTable
        dt = objSizeRange.GetSeasons()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
    End Sub
    Sub BinPaymentTerm()
        Dim dt As DataTable
        dt = ObjPaymentTerm.GetPaymentTerm()
        cmbPayMode.DataSource = dt
        cmbPayMode.DataTextField = "PaymentTerm"
        cmbPayMode.DataValueField = "PaymentTermID"
        cmbPayMode.DataBind()
    End Sub
    Sub BinShipmentMode()
        Dim dt As DataTable
        dt = objSizeRange.GetShipmentMode()
        cmbShipMode.DataSource = dt
        cmbShipMode.DataTextField = "ShipmentMode"
        cmbShipMode.DataValueField = "ShipmentModeID"
        cmbShipMode.DataBind()
    End Sub
    Sub BinPortOrigin()
        Dim dt As DataTable
        dt = objSizeRange.GetPortOrigin()
        cmbPortOrigin.DataSource = dt
        cmbPortOrigin.DataTextField = "PortOrigin"
        cmbPortOrigin.DataValueField = "PortOriginID"
        cmbPortOrigin.DataBind()
    End Sub
    Sub BinPortLoad()
        Dim dt As DataTable
        dt = objSizeRange.GetPortLoad()
        cmbPortLoad.DataSource = dt
        cmbPortLoad.DataTextField = "PortLoad"
        cmbPortLoad.DataValueField = "PortLoadID"
        cmbPortLoad.DataBind()
    End Sub
    Sub BinCurrency()
        Dim dt As DataTable
        dt = objJobOrderdatabase.GetCurrency()
        cmbCurrency.DataSource = dt
        cmbCurrency.DataTextField = "CurrencyName"
        cmbCurrency.DataValueField = "CurrencyID"
        cmbCurrency.DataBind()
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            LnkItemDatabase.Visible = False
            btnShow.Visible = False
            If txtShipmentDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("shipment date null.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                vtnSameStyle.Visible = True
                btnAddMore.Visible = True
                btnAddDetail.Visible = False
                SetInitialRow()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetInitialRow()
        Dim dt As New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("JoborderDetailid", GetType(String)))
        dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
        dt.Columns.Add(New DataColumn("Column1", GetType(String)))
        dt.Columns.Add(New DataColumn("Column2", GetType(String)))
        dt.Columns.Add(New DataColumn("Column3", GetType(String)))
        dt.Columns.Add(New DataColumn("Column4", GetType(String)))
        dt.Columns.Add(New DataColumn("Column5", GetType(String)))
        dt.Columns.Add(New DataColumn("Column6", GetType(String)))
        dt.Columns.Add(New DataColumn("Column7", GetType(String)))
        dt.Columns.Add(New DataColumn("Column8", GetType(String)))
        dt.Columns.Add(New DataColumn("Column9", GetType(String)))
        dt.Columns.Add(New DataColumn("Column10", GetType(String)))
        dt.Columns.Add(New DataColumn("Column11", GetType(String)))
        dt.Columns.Add(New DataColumn("Column12", GetType(String)))
        dt.Columns.Add(New DataColumn("Column13", GetType(String)))
        dt.Columns.Add(New DataColumn("Column14", GetType(String)))
        dt.Columns.Add(New DataColumn("Column15", GetType(String)))
        dt.Columns.Add(New DataColumn("Column16", GetType(String)))
        dt.Columns.Add(New DataColumn("Column17", GetType(String)))
        dt.Columns.Add(New DataColumn("Column18", GetType(String)))
        dt.Columns.Add(New DataColumn("Column19", GetType(String)))
        dr = dt.NewRow()
        dr("JoborderDetailid") = 0
        dr("RowNumber") = 1
        dr("Column1") = String.Empty
        dr("Column2") = String.Empty
        dr("Column3") = String.Empty
        dr("Column4") = String.Empty
        dr("Column5") = String.Empty
        dr("Column6") = String.Empty
        dr("Column7") = 6
        dr("Column8") = String.Empty
        dr("Column9") = String.Empty
        dr("Column10") = txtShipmentDate.Text
        dr("Column11") = String.Empty
        dr("Column12") = String.Empty
        dr("Column13") = String.Empty
        dr("Column14") = String.Empty
        dr("Column15") = String.Empty
        dr("Column16") = String.Empty
        dr("Column17") = String.Empty
        dr("Column18") = String.Empty
        dr("Column19") = String.Empty
        dt.Rows.Add(dr)
        Session("CurrentTable") = dt
        dgJobOrderDetail.DataSource = dt
        dgJobOrderDetail.DataBind()
        BindcmbUOM()
        BindcmbItem()
        BindStyleDescription()
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyleShipmentDate"), TextBox)
            Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbUOM"), DropDownList)
            txtStyleShipmentDate.Text = dt.Rows(i)("Column10")
            cmbUOM.SelectedValue = dt.Rows(i)("Column7")
        Next
    End Sub
    Sub BindStyleDescription()
        Dim x As Integer = 0
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim cmbItemDesc As DropDownList = CType(dgJobOrderDetail.Items(x).FindControl("cmbItemDesc"), DropDownList)
            Dim Dt As DataTable
            Dt = objJobOrderdatabase.GetAllStyleDescription
            If cmbItemDesc IsNot Nothing Then
                cmbItemDesc.DataSource = Dt
                cmbItemDesc.DataTextField = "StyleDescription"
                cmbItemDesc.DataValueField = "StyleDescriptionId" '   
                cmbItemDesc.DataBind()
                cmbItemDesc.Items.Insert(0, "Select")
            End If
        Next
    End Sub
    Sub BindcmbUOM()
        Dim x As Integer = 0
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim cmbUOM As DropDownList = CType(dgJobOrderDetail.Items(x).FindControl("cmbUOM"), DropDownList)
            Dim Dt As DataTable
            Dt = objJobOrderdatabase.GetAllUOMss
            If cmbUOM IsNot Nothing Then
                cmbUOM.DataSource = Dt
                cmbUOM.DataTextField = "Symbol"
                cmbUOM.DataValueField = "UOMID" '   
                cmbUOM.DataBind()
                cmbUOM.DataSource = Dt
            End If
        Next
    End Sub
    Sub BindcmbItem()
        Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
        Dim x As Integer = 0
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim cmbItem As DropDownList = CType(dgJobOrderDetail.Items(x).FindControl("cmbItem"), DropDownList)
            Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(x).FindControl("lblDPRNDid"), Label)
            Dim DPRDNID As String = dtCurrentTable.Rows(x)("Column12").ToString()
            Dim DTItemName As DataTable = objJobOrderdatabase.GetDPItem(DPRDNID)
            If DTItemName.Rows.Count > 0 Then
                cmbItem.DataSource = DTItemName
                cmbItem.DataTextField = "DPItemName"
                cmbItem.DataValueField = "DPItemDatabaseid" '   
                cmbItem.DataBind()
            Else
            End If
        Next
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddMore.Click
        Try
            Dim x As Integer = dgJobOrderDetail.Items.Count - 1
            Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbUOM"), DropDownList)
            Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItem"), DropDownList)
            Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyle"), TextBox)
            Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContent"), TextBox)
            Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtGSM"), TextBox)
            Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtBuyerColorName"), TextBox)
            Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtUnitPrice"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtAmount"), TextBox)
            Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyleShipmentDate"), TextBox)
            Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContentforBuyer"), TextBox)
            Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtColorCode"), TextBox)
            Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtItemCode"), TextBox)
            Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtModelRefNo"), TextBox)
            Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItemDesc"), DropDownList)
            Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtParentCd"), TextBox)
            If cmbUOM.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf cmbUOM.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtBuyerColorName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtUnitPrice.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtStyleShipmentDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
                'ElseIf txtModelRefNo.Text = "" Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf cmbItemDesc.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtParentCd.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                AddNewRowToGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0
        If Session("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(rowIndex).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtColorCode"), TextBox)
                    Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtItemCode"), TextBox)
                    Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblItemID"), Label)
                    Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtModelRefNo"), TextBox)
                    Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtParentCd"), TextBox)
                    drCurrentRow = dtCurrentTable.NewRow()
                    If lJoborderid > 0 Then
                        drCurrentRow("JoborderDetailid") = 0
                    Else
                        drCurrentRow("JoborderDetailid") = JoborderDetailid
                    End If
                    drCurrentRow("RowNumber") = i + 1
                    dtCurrentTable.Rows(i - 1)("Column1") = txtStyle.Text
                    dtCurrentTable.Rows(i - 1)("Column2") = cmbItem.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Column3") = txtContent.Text
                    dtCurrentTable.Rows(i - 1)("Column4") = txtGSM.Text
                    dtCurrentTable.Rows(i - 1)("Column5") = txtBuyerColorName.Text
                    dtCurrentTable.Rows(i - 1)("Column6") = txtQuantity.Text
                    dtCurrentTable.Rows(i - 1)("Column7") = cmbUOM.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Column8") = txtUnitPrice.Text
                    dtCurrentTable.Rows(i - 1)("Column9") = txtAmount.Text
                    dtCurrentTable.Rows(i - 1)("Column10") = txtStyleShipmentDate.Text
                    dtCurrentTable.Rows(i - 1)("Column11") = txtGSMAfter.Text
                    dtCurrentTable.Rows(i - 1)("Column12") = lblDPRNDid.Text
                    dtCurrentTable.Rows(i - 1)("Column13") = cmbItemDesc.SelectedItem.Text
                    dtCurrentTable.Rows(i - 1)("Column14") = txtContentforBuyer.Text
                    dtCurrentTable.Rows(i - 1)("Column15") = txtColorCode.Text
                    dtCurrentTable.Rows(i - 1)("Column16") = txtItemCode.Text
                    dtCurrentTable.Rows(i - 1)("Column17") = lblItemID.Text
                    dtCurrentTable.Rows(i - 1)("Column18") = "N/A" 'txtModelRefNo.Text
                    dtCurrentTable.Rows(i - 1)("Column19") = txtParentCd.Text
                    rowIndex += 1
                Next
                dtCurrentTable.Rows.Add(drCurrentRow)
                dtCurrentTable.Rows(rowIndex)("Column1") = String.Empty
                dtCurrentTable.Rows(rowIndex)("Column12") = 0
                dtCurrentTable.Rows(rowIndex)("Column16") = String.Empty
                dtCurrentTable.Rows(rowIndex)("Column17") = 0
                dtCurrentTable.Rows(rowIndex)("Column18") = "N/A"
                Session("CurrentTable") = dtCurrentTable
                dgJobOrderDetail.DataSource = dtCurrentTable
                dgJobOrderDetail.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If
        SetPreviousData()
    End Sub
    Private Sub SetPreviousData()
        BindcmbUOM()
        BindcmbItem()
        BindStyleDescription()
        Dim rowIndex As Integer = 0
        If Session("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(rowIndex).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtColorCode"), TextBox)
                    Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtItemCode"), TextBox)
                    Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblItemID"), Label)
                    Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtModelRefNo"), TextBox)
                    Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtParentCd"), TextBox)
                    txtStyle.Text = dt.Rows(i)("Column1").ToString()
                    cmbItem.SelectedValue = dt.Rows(i)("Column2").ToString()
                    txtContent.Text = dt.Rows(i)("Column3").ToString()
                    txtGSM.Text = dt.Rows(i)("Column4").ToString()
                    txtBuyerColorName.Text = dt.Rows(i)("Column5").ToString()
                    txtQuantity.Text = dt.Rows(i)("Column6").ToString()
                    cmbUOM.SelectedValue = dt.Rows(i)("Column7").ToString()
                    txtUnitPrice.Text = dt.Rows(i)("Column8").ToString()
                    txtAmount.Text = dt.Rows(i)("Column9").ToString()
                    txtStyleShipmentDate.Text = dt.Rows(i)("Column10").ToString()
                    If txtStyleShipmentDate.Text = "" Then
                        txtStyleShipmentDate.Text = txtShipmentDate.Text
                    End If
                    txtGSMAfter.Text = dt.Rows(i)("Column11").ToString()
                    lblDPRNDid.Text = dt.Rows(i)("Column12").ToString()
                    cmbItemDesc.SelectedItem.Text = dt.Rows(i)("Column13").ToString()
                    txtContentforBuyer.Text = dt.Rows(i)("Column14").ToString()
                    txtColorCode.Text = dt.Rows(i)("Column15").ToString()
                    txtItemCode.Text = dt.Rows(i)("Column16").ToString()
                    lblItemID.Text = dt.Rows(i)("Column17").ToString()
                    txtModelRefNo.Text = dt.Rows(i)("Column18").ToString()
                    txtParentCd.Text = dt.Rows(i)("Column19").ToString()
                    rowIndex += 1
                Next
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If lJoborderid > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Save()
                Session("CurrentTable") = Nothing
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Save()
                Session("CurrentTable") = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Save()
        If lJoborderid > 0 Then
            SaveJoborseMaster()
            SaveJoborseDetail()
           Session("CurrentTable") = Nothing
            Response.Redirect("JobOrderDatabaseView.aspx")
        Else
            If txtJobOrderNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Job Order No.")
            ElseIf txtCustomerOrder.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Customer Order")
            ElseIf txtOrderRecvDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter OrderRecv Date")
            ElseIf txtShipmentDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Shipment Date")
            ElseIf cmbDeliveryTerm.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Delivery Term")
            ElseIf txtPONo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter PO No.")
            ElseIf txtPORefNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter PO Ref No.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                If dgJobOrderDetail.Items.Count > 0 Then
                    SaveJoborseMaster()
                    SaveJoborseDetail()
                    Session("CurrentTable") = Nothing
                    Response.Redirect("JobOrderDatabaseView.aspx")
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Detail Required")
                End If
            End If
        End If
    End Sub
    Sub GenrateTNAChart(ByVal lPOID As Long)
        Dim Dtprocess As DataTable
        Dim dtuser As DataTable
        Dim ObjTNAChart As New TNAChart
        Dim ObjTNAChartHistory As New TNAChartHistory
        Dim PLacementDate As Date
        Dim TimeSpame, x, i As Integer
        Dim userid As Long
        Dim dtproductinfo As DataTable
        Dtprocess = ObjStyleDatabaseClass.GetScheduleNewwithWoven()
            Dim DtPO As New DataTable
        DtPO = ObjStyleDatabaseClass.GetforAll()
            For i = 0 To DtPO.Rows.Count - 1
            PLacementDate = DtPO.Rows(i)("OrderRecvDate")
                TimeSpame = DtPO.Rows(i)("TimeSpame")
                For x = 0 To Dtprocess.Rows.Count - 1
                    With ObjTNAChart
                        .IdealDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                        .ActualDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                        .DateEstemated = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                    .POID = DtPO.Rows(i)("JobOrderId")
                        .QtyCompleted = 0
                        .Remarks = " "
                        .Status = "Created"
                        .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                        .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                        .Selected = True
                        .SelectedStatus = "SELECTED"
                        .Parameter = 0
                        .ParameterUnit = ""
                        .TotalCapacity = 0
                        .CapacityUnit = ""
                        .Required = 0
                    .RequiredUnit = ""
                    .ProductionStatus = ""
                   .ProcessActive = 1
                        .SaveTNAChart()
                    End With
                    With ObjTNAChartHistory
                        .CreationDate = Date.Now
                        .TNAChartID = ObjTNAChart.GetId
                        .IdealDate = ObjTNAChart.IdealDate
                        .DateEstemated = ObjTNAChart.DateEstemated
                        .ActualDate = ObjTNAChart.ActualDate
                        .QtyCompleted = 0
                        .Remarks = " "
                        .Status = "Created"
                        .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                        .Parameter = 0
                        .ParameterUnit = ""
                        .TotalCapacity = 0
                        .CapacityUnit = ""
                        .Required = 0
                        .RequiredUnit = ""
                    .Color = ""
                    .ProductionStatus = ""
                        .SaveTNAChartHistory()
                    End With
                Next
            Next
    End Sub
    Private Sub SaveJoborseMaster()
        Calculate()
        With objJobOrderdatabase
       If lJoborderid > 0 Then
                If Type = "Copy" Then
                    .Joborderid = 0
                Else
                    .Joborderid = lJoborderid
                End If
            Else
                .Joborderid = 0
            End If
            .PONo = txtPONo.Text
            .PORefNo = txtPORefNo.Text
            .CustomerDatabaseID = cmbCustomer.SelectedValue
            .BrandDatabaseID = cmbBrand.SelectedValue
            .SeasonDatabaseID = cmbSeason.SelectedValue
            .CurrencyID = cmbCurrency.SelectedValue
            .ShipmentModeID = cmbShipMode.SelectedValue
            .PaymentTermId = cmbPayMode.SelectedValue
            .JoborderNo = txtJobOrderNo.Text
            .CustomerOrder = txtCustomerOrder.Text
            If Type = "Copy" Or lJoborderid > 0 Then
                .OrderRecvDate = lblRecvDate.Text
            Else
                .OrderRecvDate = txtOrderRecvDate.Text
            End If
            If lJoborderid > 0 Then
                .ShipmentDate = lblShipmentDate.Text
            Else
                .ShipmentDate = txtShipmentDate.Text
            End If
            .ShippingInstruction = txtShippingInstruction.Text.ToUpper()
            .CreationDate = Date.Now
            .Timespame = GetTimeSpame(objGeneralCode.GetDate(txtShipmentDate.Text), objGeneralCode.GetDate(txtOrderRecvDate.Text))
            If UserId = 0 Then
                ResolveUrl("~/Login.aspx")
            Else
                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    If Type = "Copy" Then
                        .UserID = UserId
                    ElseIf lJoborderid > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = 270
                    End If
                Else
                    If Type = "Copy" Then
                        .UserID = UserId
                    ElseIf lJoborderid > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = UserId
                    End If
                End If
            End If
            .Supplier = cmbSupplier.SelectedItem.Text
            .SRNO = txtSrNo.Text.ToUpper & txtSrNoTwo.Text
            .SRNOPOne = txtSrNo.Text
            .SRNOPTwo = txtSrNoTwo.Text
            If cmbPortOrigin.SelectedValue = 0 Then
                .PortOrigin = "N/A"
            Else
                .PortOrigin = cmbPortOrigin.SelectedItem.Text
            End If
            If cmbPortLoad.SelectedValue = 0 Then
                .PortLoad = "N/A"
            Else
                .PortLoad = cmbPortLoad.SelectedItem.Text
            End If
            .OriginId = cmbOrigin.SelectedValue
            .DeliveryTermId = cmbDeliveryTerm.SelectedValue
            If lblShipmentStatus.Text = "" Then
                .ShipmentStatus = 0
            Else
                .ShipmentStatus = lblShipmentStatus.Text
            End If
            .SaveJobOrder()
        End With
        Dim CurrentID As Long
        If lJoborderid = 0 Or Type = "Copy" Then
            CurrentID = objJobOrderdatabase.GetID
            GenrateTNAChart(CurrentID)
        Else
            Dim dtcheckTNA As DataTable = ObjStyleDatabaseClass.CheckTNA(lJoborderid)
            If dtcheckTNA.Rows.Count > 0 Then
                Dim Dt As New DataTable
                Dt = ObjStyleDatabaseClass.GetPurchaseOrderByPON(lJoborderid)
                If txtShipmentDatee.Text = Dt.Rows(0)("ShipmentDate") Then
                Else
                    GenrateTNAChartChangShipmentDate(lJoborderid)
                End If
            Else
                CurrentID = lJoborderid
                GenrateTNAChart(CurrentID)
            End If
        End If
    End Sub
    Sub GenrateTNAChartChangShipmentDate(ByVal lPOID As Long)
        Dim Dtprocess As DataTable
        Dim dtuser As DataTable
        Dim ObjTNAChart As New TNAChart
        Dim ObjTNAChartHistory As New TNAChartHistory
        Dim PLacementDate As Date
        Dim TimeSpame, x, i As Integer
        Dim dtproductinfo As DataTable
        Dtprocess = ObjStyleDatabaseClass.GetScheduleNewwithWoven()        
            Dim DtPO As New DataTable
            Dim DtOldTNA As New DataTable
        DtPO = ObjTNAChart.GetPOForChangeShipmetDate(lPOID)
            DtOldTNA = ObjTNAChart.GetProcessByTNAChartId(lPOID)
        PLacementDate = DtPO.Rows(i)("OrderRecvDate")
            TimeSpame = DtPO.Rows(i)("TimeSpame")
            For x = 0 To DtOldTNA.Rows.Count - 1
                With ObjTNAChart
                    Dim ProcessIDOld As String = DtOldTNA.Rows(x)("ProcessID")
                    Dim POID As String = DtOldTNA.Rows(x)("POID")
                    Dim TNAID As Long = DtOldTNA.Rows(x)("TNAChartID")
                Dim DateIdeal As Date = GeneralCode.GetDate((AddDate(TimeSpame, DtOldTNA.Rows(x)("SchedularTime"), PLacementDate)).ToString("dd-MM-yyyy"))
                    Dim DateEstmated As Date = GeneralCode.GetDate((AddDate(TimeSpame, DtOldTNA.Rows(x)("SchedularTime"), PLacementDate)).ToString("dd-MM-yyyy"))
                    Dim Year As String = DateIdeal.Year()
                    Dim Day As String = DateIdeal.Day()
                    Dim Month As String = DateIdeal.Month()
                    Dim FInalDateIdeal As String = Month + "/" + Day + "/" + Year
                    .UpdateChartFotChangeShipmentDate(TNAID, ProcessIDOld, POID, FInalDateIdeal)
                End With
            Next
    End Sub
    Private Sub SaveJoborseDetail()
        Try
            Dim x As Integer
            For x = 0 To dgJobOrderDetail.Items.Count - 1
                Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyle"), TextBox)
                Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItem"), DropDownList)
                Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContent"), TextBox)
                Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtGSM"), TextBox)
                Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtBuyerColorName"), TextBox)
                Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtQuantity"), TextBox)
                Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbUOM"), DropDownList)
                Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtUnitPrice"), TextBox)
                Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtAmount"), TextBox)
                Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyleShipmentDate"), TextBox)
                Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtGSMAfter"), TextBox)
                Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(x).FindControl("lblDPRNDid"), Label)
                Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContentforBuyer"), TextBox)
                Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtColorCode"), TextBox)
                Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtItemCode"), TextBox)
                Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(x).FindControl("lblItemID"), Label)
                Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtModelRefNo"), TextBox)
                Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItemDesc"), DropDownList)
                Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtParentCd"), TextBox)
                With objJobOrderdatabaseDetail
                    If lJoborderid > 0 Then
                        If Type = "Copy" Then
                            .JoborderDetailid = 0
                        Else
                            .JoborderDetailid = dgJobOrderDetail.Items(x).Cells(0).Text
                        End If
                        If Type = "Copy" Then
                            .Joborderid = objJobOrderdatabase.GetID
                        Else
                            .Joborderid = lJoborderid
                        End If
                        .StyleID = 0
                    Else
                        If Type = "Copy" Then
                            .JoborderDetailid = 0
                        Else
                            .JoborderDetailid = dgJobOrderDetail.Items(x).Cells(0).Text
                        End If
                        .Joborderid = objJobOrderdatabase.GetID
                        .StyleID = 0
                    End If
                    .UOMID = cmbUOM.SelectedValue
                    .Style = txtStyle.Text.ToUpper()
                    .BuyerColor = txtBuyerColorName.Text.ToUpper()
                    .Quantity = Val(txtQuantity.Text)
                    .UnitPrice = Val(txtUnitPrice.Text)
                    .Value = Val(txtAmount.Text)
                    .StyleShipmentDate = txtStyleShipmentDate.Text
                    .Timespame = GetTimeSpame(objGeneralCode.GetDate(txtStyleShipmentDate.Text), objGeneralCode.GetDate(txtOrderRecvDate.Text))
                    .ItemDesc = cmbItemDesc.SelectedItem.Text
                    .ColorCode = txtColorCode.Text
                    .Model = "N/A" 'txtModelRefNo.Text.ToUpper
                    .ItemDatabaseID = 0
                    If txtGSM.Text = "" Then
                        .GSM = ""
                    Else
                        .GSM = txtGSM.Text.ToUpper()
                    End If
                    If txtGSMAfter.Text = "" Then
                        .AfterWashGsm = ""
                    Else
                        .AfterWashGsm = txtGSMAfter.Text
                    End If
                    If lblDPRNDid.Text = "" Then
                        .DPRNDID = 0
                    Else
                        .DPRNDID = lblDPRNDid.Text
                    End If
                    If txtContentforBuyer.Text = "" Then
                        .ContentforBuyer = ""
                    Else
                        .ContentforBuyer = txtContentforBuyer.Text
                    End If
                    If txtContent.Text = "" Then
                        .Content = ""
                    Else
                        .Content = txtContent.Text.ToUpper()
                    End If
                    If lblItemID.Text = "" Then
                        .IMSItemID = 0
                    Else
                        .IMSItemID = lblItemID.Text
                    End If
                    If txtItemCode.Text = "" Then
                        .ItemCode = ""
                    Else
                        .ItemCode = txtItemCode.Text
                    End If
                    .QtyPerNew = 0
                    .TotalQtyNew = 0
                    .ParentCd = txtParentCd.Text.ToUpper
                    .SaveJobOrderDetail()
                End With
            Next
            With objJobOrderCertificateRequired
                Dim checkCertificate As Long
                For x = 0 To rpCertificate.Items.Count - 1
                    Dim dtCheckJobOrderCertificateIdExist As New DataTable
                    dtCheckJobOrderCertificateIdExist = objJobOrderdatabase.CheckJobOrderCertificateIdExist(lJoborderid)
                    If dtCheckJobOrderCertificateIdExist.Rows.Count > 0 Then
                        checkCertificate = dtCheckJobOrderCertificateIdExist.Rows(0)("JobOrderCertificateRequiredID")
                    Else
                    End If
                    If lJoborderid > 0 Then
                        .JobOrderCertificateRequiredID = checkCertificate
                    Else
                        .JobOrderCertificateRequiredID = 0
                    End If
                    .CertificateID = CType(rpCertificate.Items(x).FindControl("lblCertificateID"), Label).Text
                    If Type = "Copy" Then
                        .JobOrderID = objJobOrderdatabase.GetID
                    Else
                        .JobOrderID = lJoborderid
                    End If
                    .SupplierCertificateID = CType(rpCertificate.Items(x).FindControl("lblSupplierCertificateID"), Label).Text
                    .SaveCertificate()
                Next
            End With
            With objJobOrderTestRequired
                Dim checkTestRequired As Long
                For x = 0 To rptTestRequired.Items.Count - 1
                    Dim dtCheckRequiredIdExist As New DataTable
                    dtCheckRequiredIdExist = objJobOrderdatabase.CheckTestRequiredIDExist(lJoborderid)
                    If dtCheckRequiredIdExist.Rows.Count > 0 Then
                        checkTestRequired = dtCheckRequiredIdExist.Rows(0)("JobOrderTestRequiredID")
                    Else
                    End If
                    If lJoborderid > 0 Then
                        .JobOrderTestRequiredID = checkTestRequired
                    Else
                        .JobOrderTestRequiredID = 0
                    End If
                    If Type = "Copy" Then
                        .JobOrderID = objJobOrderdatabase.GetID
                    Else
                        .JobOrderID = lJoborderid
                    End If
                    .TestingdatabaseID = CType(rptTestRequired.Items(x).FindControl("lblTestingDatabaseID"), Label).Text
                    .SaveTestRequired()
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub
    Function AddDate(ByVal TotalDays As Double, ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        Days = (TotalDays / 100) * Days
        dt = DateAddin.AddDays(Days)
        Return dt
    End Function
    Function GetTimeSpame(ByVal DateFrom As Date, ByVal DateTo As Date)
        Dim tsTimeSpan As TimeSpan
        Dim iNumberOfDays As Integer
        tsTimeSpan = DateFrom.Subtract(DateTo)
        iNumberOfDays = tsTimeSpan.Days
        Return iNumberOfDays
    End Function
    Protected Sub certificate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles certificate.Click
        Response.Write("<script> window.open('SelectionCertificate.aspx', 'newwindow', 'left=450, top=300, height=220, width=450, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
    End Sub
    Protected Sub btnGetCertificate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetCertificate.Click
        SetrpCertificate()
    End Sub
    Sub SetrpCertificate()
        Dim Dt As DataTable
        Dt = Session("dtCertificate")
        If Not Session("dtCertificate") Is Nothing Then
            rpCertificate.DataSource = Dt
            rpCertificate.DataBind()
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SetrpTestRequired()
    End Sub
    Sub SetrpTestRequired()
        Dim Dt As DataTable
        Dt = Session("dtTestRequired")
        If Not Session("dtTestRequired") Is Nothing Then
            rptTestRequired.DataSource = Dt
            rptTestRequired.DataBind()
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Write("<script> window.open('SelectionTestRequired.aspx', 'newwindow', 'left=450, top=300, height=220, width=450, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
    End Sub
    Protected Sub dgJobOrderDetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgJobOrderDetail.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim dtChkStyleAssortment As DataTable
                Dim dtCurrentTable As DataTable = CType(Session("CurrentTable"), DataTable)
                dtChkStyleAssortment = objJobOrderdatabaseDetail.CheckStyleAssortment(lJoborderid)
                If dtChkStyleAssortment.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("CAN NOT DELETE B/C IT USE IN STYLE ASSORTMENT.")
                Else
                    If (Not dtCurrentTable Is Nothing) Then
                        If (dtCurrentTable.Rows.Count > 0) Then
                            Dim lJoborderDetailid As Integer = dgJobOrderDetail.Items(e.Item.ItemIndex).Cells(0).Text
                            dtCurrentTable.Rows.RemoveAt(e.Item.ItemIndex)
                            objJobOrderdatabaseDetail.DeleteDetailFromJobOrderdatabaseDetail(lJoborderDetailid)
                            Dim dtForEdit As New DataTable
                            dtForEdit = objJobOrderdatabase.GetForEdit(lJoborderid)
                            Session("dtCurrentTable") = dtForEdit
                            OnremoveAgainBind()
                            If dtCurrentTable.Rows.Count = 0 Then
                                dgJobOrderDetail.Controls.Clear()
                                dgJobOrderDetail.Visible = False
                            End If
                        Else
                            dgJobOrderDetail.Visible = False
                        End If
                    End If
                End If
            Case Is = "Calculate"
                Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtQuantity"), TextBox)
                Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtUnitPrice"), TextBox)
                If txtQuantity.Text = "" And txtUnitPrice.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Allow To Calculate, First Fill Last Row Correctly")
                ElseIf txtQuantity.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Allow To Calculate, First Fill Last Row Correctly")
                ElseIf txtUnitPrice.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Allow To Calculate, First Fill Last Row Correctly")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Calculate()
                End If
            Case Is = "AddStyle"
                Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtStyle"), TextBox)
                Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtModelRefNo"), TextBox)
                Dim imgSyleAdd As ImageButton = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("imgSyleAdd"), ImageButton)
                Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtItemCode"), TextBox)
                If txtStyle.Text = "" Then
                    lblErrorMsg.Text = "Please Fill Style."
                Else
                    lblErrorMsg.Text = ""
                    With ObjStyleDatabaseClass
                        .DPStyleDatabaseId = 0
                        .StyleCode = txtStyle.Text.ToUpper
                        .StyleName = "Buyer Style"
                        .CreationDate = Date.Now
                        .StyleDate = Date.Now
                        .UserId = UserId
                        .CompanyName = "Digital Apparel (Pvt) Ltd."
                        .Description = ""
                        .EstimatedTimeReq = 0
                        pictureNotAvialableFront()
                        .FileNameFront = Session("FileNameFrontImage")
                        .ImageFront = Session("ImageByteFrontImage")
                        pictureNotAvialableBack()
                        .FileNameBack = Session("FileNameBackImage")
                        .ImageBack = Session("ImageByteBackImage")
                        .Isactive = 1
                        .CustomerID = cmbCustomer.SelectedValue
                        .BuyerReferenceNo = ""
                        .Save()
                        imgSyleAdd.Visible = False
                        txtItemCode.Focus()
                    End With
                End If
            Case Is = "Move"
                Dim JoborderDetailid As Integer = dgJobOrderDetail.Items(e.Item.ItemIndex).Cells(0).Text
                Response.Write("<script> window.open('ItemDBAddPopUp.aspx?POID=" & JoborderDetailid & "', 'newwindow', 'left=100, top=180, height=300, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            Case Is = "AddITMDesc"
                Try
                    Dim txtSaveItemDesc As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtSaveItemDesc"), TextBox)
                    Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("cmbItemDesc"), DropDownList)
                    Dim lnkBtnAddItemDesc As ImageButton = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("lnkBtnAddItemDesc"), ImageButton)
                    Dim lnkBtnSaveItemDesc As ImageButton = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("lnkBtnSaveItemDesc"), ImageButton)

                    cmbItemDesc.Visible = False
                    txtSaveItemDesc.Visible = True
                    lnkBtnAddItemDesc.Visible = False
                    lnkBtnSaveItemDesc.Visible = True
                Catch ex As Exception
                End Try
            Case Is = "SaveITMDesc"
                Dim txtSaveItemDesc As TextBox = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("txtSaveItemDesc"), TextBox)
                Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("cmbItemDesc"), DropDownList)
                Dim lnkBtnAddItemDesc As ImageButton = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("lnkBtnAddItemDesc"), ImageButton)
                Dim lnkBtnSaveItemDesc As ImageButton = DirectCast(dgJobOrderDetail.Items(e.Item.ItemIndex).FindControl("lnkBtnSaveItemDesc"), ImageButton)

                Try
                    If txtSaveItemDesc.Text = "" Then
                        With objStyleDesc
                            .StyleDescriptionID = 0
                            .StyleDescription = txtSaveItemDesc.Text
                            .StyleCategoryId = 4
                        End With
                    Else
                        With objStyleDesc
                            .StyleDescriptionID = 0
                            .StyleDescription = txtSaveItemDesc.Text
                            .StyleCategoryId = 4
                            .Save()
                        End With
                    End If
                Catch ex As Exception
                End Try
                cmbItemDesc.Visible = True
                txtSaveItemDesc.Visible = False
                lnkBtnAddItemDesc.Visible = True
                lnkBtnSaveItemDesc.Visible = False
                BindStyleDescription()
        End Select
    End Sub
    Protected Sub UpdateStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim JoborderDetailid As Integer
        Dim x As Integer
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim ChkMove As CheckBox = CType(dgJobOrderDetail.Items(x).FindControl("ChkMove"), CheckBox)
            If ChkMove.Checked = True Then
                JoborderDetailid = dgJobOrderDetail.Items(x).Cells(0).Text
                Response.Write("<script> window.open('JoborderDetailMovePopup.aspx?JoborderDetailid=" & JoborderDetailid & "', 'newwindow', 'left=100, top=180, height=200, width=300, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                ChkMove.Checked = False
            End If
        Next
    End Sub
    Sub pictureNotAvialableFront()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteFrontImage") = GetFileContent(path)
        Session("FileNameFrontImage") = "no-image.jpg"
    End Sub
    Sub pictureNotAvialableBack()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteBackImage") = GetFileContent(path)
        Session("FileNameBackImage") = "no-image.jpg"
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub OnremoveAgainBind()
        Try
            Dim x As Integer
            Dim dtdeleteAgaineBind As New DataTable
            dtdeleteAgaineBind = Session("dtCurrentTable")
            Dim dtt As New DataTable()
            Dim dr As DataRow = Nothing
            dtt.Columns.Add(New DataColumn("JoborderDetailid", GetType(String)))
            dtt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column1", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column2", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column3", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column4", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column5", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column6", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column7", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column8", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column9", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column10", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column11", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column12", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column13", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column14", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column15", GetType(String)))
            dtt.Columns.Add(New DataColumn("Column19", GetType(String)))
            For x = 0 To dtdeleteAgaineBind.Rows.Count - 1
                dr = dtt.NewRow()
                dr("JoborderDetailid") = dtdeleteAgaineBind.Rows(x)("JoborderDetailid")
                dr("RowNumber") = 1
                dr("Column1") = String.Empty
                dr("Column2") = String.Empty
                dr("Column3") = String.Empty
                dr("Column4") = String.Empty
                dr("Column5") = String.Empty
                dr("Column6") = String.Empty
                dr("Column7") = String.Empty
                dr("Column8") = String.Empty
                dr("Column9") = String.Empty
                dr("Column10") = String.Empty
                dr("Column11") = String.Empty
                dr("Column12") = String.Empty
                dr("Column13") = String.Empty
                dr("Column14") = String.Empty
                dr("Column15") = String.Empty
                dr("Column19") = String.Empty
                dtt.Rows.Add(dr)
            Next
            Session("CurrentTable") = dtt
            dgJobOrderDetail.DataSource = dtdeleteAgaineBind
            dgJobOrderDetail.DataBind()
            BindcmbItem()
            BindcmbUOM()
            BindStyleDescription()
            Dim drCurrentRow As DataRow = Nothing
            If dtdeleteAgaineBind.Rows.Count > 0 Then
                For i As Integer = 0 To dtdeleteAgaineBind.Rows.Count - 1
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = CType(dgJobOrderDetail.Items(i).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(i).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtColorCode"), TextBox)
                    Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtParentCd"), TextBox)
                    JoborderDetailid = dtdeleteAgaineBind.Rows(i)("JoborderDetailid")
                    txtStyle.Text = dtdeleteAgaineBind.Rows(i)("Style")
                    cmbItem.SelectedValue = dtdeleteAgaineBind.Rows(i)("ItemDatabaseID")
                    cmbUOM.SelectedValue = dtdeleteAgaineBind.Rows(i)("UNITID")
                    txtContent.Text = dtdeleteAgaineBind.Rows(i)("Content")
                    txtGSM.Text = dtdeleteAgaineBind.Rows(i)("GSM")
                    txtBuyerColorName.Text = dtdeleteAgaineBind.Rows(i)("BuyerColor")
                    txtUnitPrice.Text = dtdeleteAgaineBind.Rows(i)("UnitPrice")
                    txtQuantity.Text = dtdeleteAgaineBind.Rows(i)("Quantity")
                    txtStyleShipmentDate.Text = dtdeleteAgaineBind.Rows(i)("StyleShipmentDate")
                    txtAmount.Text = dtdeleteAgaineBind.Rows(i)("value")
                    txtGSMAfter.Text = dtdeleteAgaineBind.Rows(i)("AfterWashGsm")
                    lblDPRNDid.Text = dtdeleteAgaineBind.Rows(i)("DPRNDID")
                    cmbItemDesc.SelectedItem.Text = dtdeleteAgaineBind.Rows(i)("ItemDesc")
                    txtContentforBuyer.Text = dtdeleteAgaineBind.Rows(i)("ContentforBuyer")
                    txtColorCode.Text = dtdeleteAgaineBind.Rows(i)("ColorCode")
                    txtParentCd.Text = dtdeleteAgaineBind.Rows(i)("ParentCd")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Calculate()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtUnitPrice"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtAmount"), TextBox)
            If txtQuantity.Text = "" Then
                txtQuantity.Text = 0
            End If
            If txtAmount.Text = "" Then
                txtAmount.Text = 0
            End If
            If txtUnitPrice.Text = "" Then
                txtUnitPrice.Text = 0
            End If
            TotalQty = TotalQty + Val(txtQuantity.Text)
            txtAmount.Text = (txtQuantity.Text) * txtUnitPrice.Text
            TotalAmt = TotalAmt + Val(txtAmount.Text)
            txtTotalAmount.Text = TotalAmt
            TxtTotalQty.Text = TotalQty
        Next
    End Sub
    Sub Calculate2()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        For x = 0 To dgJobOrderDetail.Items.Count - 1
            Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtUnitPrice"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtAmount"), TextBox)
            If txtQuantity.Text = "" Then
                txtQuantity.Text = 0
            End If
            If txtAmount.Text = "" Then
                txtAmount.Text = 0
            End If
            If txtUnitPrice.Text = "" Then
                txtUnitPrice.Text = 0
            End If
            TotalQty = TotalQty + Val(txtQuantity.Text)
            txtAmount.Text = (txtQuantity.Text) * txtUnitPrice.Text
            TotalAmt = TotalAmt + Val(txtAmount.Text)
            txtTotalAmount.Text = TotalAmt
            TxtTotalQty.Text = TotalQty
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub vtnSameStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles vtnSameStyle.Click
        Try
            Dim x As Integer = dgJobOrderDetail.Items.Count - 1
            Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbUOM"), DropDownList)
            Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItem"), DropDownList)
            Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyle"), TextBox)
            Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContent"), TextBox)
            Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtGSM"), TextBox)
            Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtBuyerColorName"), TextBox)
            Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtUnitPrice"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtAmount"), TextBox)
            Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtStyleShipmentDate"), TextBox)
            Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtContentforBuyer"), TextBox)
            Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtColorCode"), TextBox)
            Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtItemCode"), TextBox)
            Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtModelRefNo"), TextBox)
            Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(x).FindControl("cmbItemDesc"), DropDownList)
            Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(x).FindControl("txtParentCd"), TextBox)
            If cmbUOM.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf cmbUOM.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf cmbItemDesc.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtBuyerColorName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtUnitPrice.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtStyleShipmentDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtModelRefNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            ElseIf txtParentCd.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First fill last row correctly")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                AddNewRowToGridSameStyle()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddNewRowToGridSameStyle()
        Dim rowIndex As Integer = 0
        Dim txtStyle As TextBox
        Dim cmbItem As DropDownList
        Dim txtContent As TextBox
        Dim txtGSM As TextBox
        Dim cmbUOM As DropDownList
        Dim txtUnitPrice As TextBox
        Dim txtGSMAfter As TextBox
        Dim lblDPRNDid As Label
        Dim txtContentforBuyer As TextBox
        Dim txtColorCode As TextBox
        Dim txtItemCode As TextBox
        Dim lblItemID As Label
        Dim txtModelRefNo As TextBox
        Dim cmbItemDesc As DropDownList
        Dim txtParentCd As TextBox
        If Session("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    txtStyle = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyle"), TextBox)
                    cmbItem = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItem"), DropDownList)
                    txtContent = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContent"), TextBox)
                    txtGSM = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    cmbUOM = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbUOM"), DropDownList)
                    txtUnitPrice = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(rowIndex).Cells(0).Text
                    txtGSMAfter = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSMAfter"), TextBox)
                    lblDPRNDid = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblDPRNDid"), Label)
                    txtContentforBuyer = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContentforBuyer"), TextBox)
                    txtColorCode = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtColorCode"), TextBox)
                    txtItemCode = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtItemCode"), TextBox)
                    lblItemID = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblItemID"), Label)
                    txtModelRefNo = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtModelRefNo"), TextBox)
                    cmbItemDesc = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItemDesc"), DropDownList)
                    txtParentCd = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtParentCd"), TextBox)
                    drCurrentRow = dtCurrentTable.NewRow()
                    If lJoborderid > 0 Then
                        drCurrentRow("JoborderDetailid") = 0
                    Else
                        drCurrentRow("JoborderDetailid") = JoborderDetailid
                    End If
                    drCurrentRow("RowNumber") = i + 1
                    dtCurrentTable.Rows(i - 1)("Column1") = txtStyle.Text
                    dtCurrentTable.Rows(i - 1)("Column2") = cmbItem.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Column3") = txtContent.Text
                    dtCurrentTable.Rows(i - 1)("Column4") = txtGSM.Text
                    dtCurrentTable.Rows(i - 1)("Column5") = txtBuyerColorName.Text
                    dtCurrentTable.Rows(i - 1)("Column6") = txtQuantity.Text
                    dtCurrentTable.Rows(i - 1)("Column7") = cmbUOM.SelectedValue
                    dtCurrentTable.Rows(i - 1)("Column8") = txtUnitPrice.Text
                    dtCurrentTable.Rows(i - 1)("Column9") = txtAmount.Text
                    dtCurrentTable.Rows(i - 1)("Column10") = txtStyleShipmentDate.Text
                    dtCurrentTable.Rows(i - 1)("Column11") = txtGSMAfter.Text
                    dtCurrentTable.Rows(i - 1)("Column12") = lblDPRNDid.Text
                    dtCurrentTable.Rows(i - 1)("Column13") = cmbItemDesc.SelectedItem.Text
                    dtCurrentTable.Rows(i - 1)("Column14") = txtContentforBuyer.Text
                    dtCurrentTable.Rows(i - 1)("Column15") = txtColorCode.Text
                    dtCurrentTable.Rows(i - 1)("Column16") = txtItemCode.Text
                    dtCurrentTable.Rows(i - 1)("Column17") = lblItemID.Text
                    dtCurrentTable.Rows(i - 1)("Column18") = txtModelRefNo.Text
                    dtCurrentTable.Rows(i - 1)("Column19") = txtParentCd.Text
                    rowIndex += 1
                Next
                dtCurrentTable.Rows.Add(drCurrentRow)
                dtCurrentTable.Rows(rowIndex)("Column1") = txtStyle.Text
                dtCurrentTable.Rows(rowIndex)("Column2") = cmbItem.SelectedValue
                dtCurrentTable.Rows(rowIndex)("Column3") = txtContent.Text
                dtCurrentTable.Rows(rowIndex)("Column4") = txtGSM.Text
                dtCurrentTable.Rows(rowIndex)("Column7") = cmbUOM.SelectedValue
                dtCurrentTable.Rows(rowIndex)("Column8") = txtUnitPrice.Text
                dtCurrentTable.Rows(rowIndex)("Column11") = txtGSMAfter.Text
                dtCurrentTable.Rows(rowIndex)("Column12") = lblDPRNDid.Text
                dtCurrentTable.Rows(rowIndex)("Column13") = cmbItemDesc.SelectedItem.Text
                dtCurrentTable.Rows(rowIndex)("Column14") = txtContentforBuyer.Text
                dtCurrentTable.Rows(rowIndex)("Column15") = ""
                dtCurrentTable.Rows(rowIndex)("Column16") = txtItemCode.Text
                dtCurrentTable.Rows(rowIndex)("Column17") = lblItemID.Text
                dtCurrentTable.Rows(rowIndex)("Column18") = txtModelRefNo.Text
                dtCurrentTable.Rows(rowIndex)("Column19") = txtParentCd.Text
                Session("CurrentTable") = dtCurrentTable
                dgJobOrderDetail.DataSource = dtCurrentTable
                dgJobOrderDetail.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If
        SetPreviousDataSameStyle()
    End Sub
    Private Sub SetPreviousDataSameStyle()
        BindcmbUOM()
        BindcmbItem()
        BindStyleDescription()
        Dim rowIndex As Integer = 0
        If Session("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyle"), TextBox)
                    Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItem"), DropDownList)
                    Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContent"), TextBox)
                    Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSM"), TextBox)
                    Dim txtBuyerColorName As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtBuyerColorName"), TextBox)
                    Dim txtQuantity As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    Dim cmbUOM As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbUOM"), DropDownList)
                    Dim txtUnitPrice As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtUnitPrice"), TextBox)
                    Dim txtAmount As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtAmount"), TextBox)
                    Dim txtStyleShipmentDate As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtStyleShipmentDate"), TextBox)
                    Dim JoborderDetailid As String = dgJobOrderDetail.Items(rowIndex).Cells(0).Text
                    Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtGSMAfter"), TextBox)
                    Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblDPRNDid"), Label)
                    Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtContentforBuyer"), TextBox)
                    Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtColorCode"), TextBox)
                    Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtItemCode"), TextBox)
                    Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("lblItemID"), Label)
                    Dim txtModelRefNo As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtModelRefNo"), TextBox)
                    Dim cmbItemDesc As DropDownList = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("cmbItemDesc"), DropDownList)
                    Dim txtParentCd As TextBox = DirectCast(dgJobOrderDetail.Items(rowIndex).FindControl("txtParentCd"), TextBox)
                    txtStyle.Text = dt.Rows(i)("Column1").ToString()
                    cmbItem.SelectedValue = dt.Rows(i)("Column2").ToString()
                    txtContent.Text = dt.Rows(i)("Column3").ToString()
                    txtGSM.Text = dt.Rows(i)("Column4").ToString()
                    txtBuyerColorName.Text = dt.Rows(i)("Column5").ToString()
                    txtQuantity.Text = dt.Rows(i)("Column6").ToString()
                    cmbUOM.SelectedValue = dt.Rows(i)("Column7").ToString()
                    txtUnitPrice.Text = dt.Rows(i)("Column8").ToString()
                    txtAmount.Text = dt.Rows(i)("Column9").ToString()
                    txtStyleShipmentDate.Text = dt.Rows(i)("Column10").ToString()
                    If txtStyleShipmentDate.Text = "" Then
                        txtStyleShipmentDate.Text = txtShipmentDate.Text
                    End If
                    txtGSMAfter.Text = dt.Rows(i)("Column11").ToString()
                    lblDPRNDid.Text = dt.Rows(i)("Column12").ToString()
                    cmbItemDesc.SelectedItem.Text = dt.Rows(i)("Column13").ToString()
                    txtContentforBuyer.Text = dt.Rows(i)("Column14").ToString()
                    txtColorCode.Text = dt.Rows(i)("Column15").ToString()
                    txtItemCode.Text = dt.Rows(i)("Column16").ToString()
                    lblItemID.Text = dt.Rows(i)("Column17").ToString()
                    txtModelRefNo.Text = dt.Rows(i)("Column18").ToString()
                    txtParentCd.Text = dt.Rows(i)("Column19").ToString()
                    rowIndex += 1
                Next
            End If
        End If
    End Sub
    Protected Sub lnkprint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkprint.Click
        printjoborderreport()
    End Sub
    Sub printjoborderreport()
        Try
            Dim JobOrderId As Long = lJoborderid
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Report.Load(Server.MapPath("~/Reports/JobOrder.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, JobOrderId)
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Job Order"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()
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
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub printAssortmentreport()
        Try
            Dim rJobOrderId As Long = lJoborderid
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Report.Load(Server.MapPath("~/Reports/rptAssortment.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, rJobOrderId)
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Assortment Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()
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
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Inkprint2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Inkprint2.Click
        printAssortmentreport()
    End Sub
    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAdd.Click
        Try
            Panel2.Visible = True
            PnlSeasonCmb.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSaveSeason_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveSeason.Click
        Try
            Dim toDayDate As Date = Date.Today
            Dim Year As String = toDayDate.Year
            If txtSeason.Text = "" Then
                With objSeasonDatabase
                    .SeasonDatabaseID = 0
                    .CreationDate = Date.Today
                    .UmuserID = UserId
                    .Year = Year
                    .SeasonName = txtSeason.Text.ToUpper()
                End With
            Else
                With objSeasonDatabase
                    .SeasonDatabaseID = 0
                    .CreationDate = Date.Today
                    .UmuserID = UserId
                    .Year = Year
                    .SeasonName = txtSeason.Text.ToUpper()
                    .saveSeasonDatabase()
                End With
            End If
        Catch ex As Exception
        End Try
        PnlSeasonCmb.Visible = True
        Panel2.Visible = False
        BinSeason()
    End Sub
    Protected Sub BtnAddBrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddBrand.Click
        Try
            PnlBrand2.Visible = True
            PnlBrand1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnBrandSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBrandSave.Click
        Try
            If txtBrandSave.Text = "" Then
                With objBrandDatabase
                    .BrandDatabaseID = 0
                    .CreationDate = Date.Today
                    .UmuserID = UserId
                    .Brand = txtBrandSave.Text
                End With
            Else
                With objBrandDatabase
                    .BrandDatabaseID = 0
                    .CreationDate = Date.Today
                    .UmuserID = UserId
                    .Brand = txtBrandSave.Text
                    .saveBrandDatabase()
                End With
            End If
        Catch ex As Exception
        End Try
        PnlBrand1.Visible = True
        PnlBrand2.Visible = False
        BinBrand()
    End Sub
    Protected Sub BtnAddShipMode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddShipMode.Click
        Try
            PnlShipmentMode2.Visible = True
            PnlShipmentMode1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSaveShipmentMode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveShipmentMode.Click
        Try
            If txtSaveShipmentMode.Text = "" Then
                With objShipmentMode
                    .ShipmentModeID = 0
                    .ShipmentMode = txtSaveShipmentMode.Text
                End With
            Else
                With objShipmentMode
                    .ShipmentModeID = 0
                    .ShipmentMode = txtSaveShipmentMode.Text
                    .SaveShipmentMode()
                End With
            End If
        Catch ex As Exception
        End Try
        PnlShipmentMode1.Visible = True
        PnlShipmentMode2.Visible = False
        BinShipmentMode()
    End Sub
    Protected Sub BtnAddPort_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddPort.Click
        Try
            PnlPortDestination2.Visible = True
            PnlPortDestination1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsavePort_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnsavePort.Click
        Try
            If txtPortOrigin.Text <> "" Then
                With ObjPortOrigin
                    .PortOriginID = 0
                    .PortOrigin = txtPortOrigin.Text
                    .SavePortOrigin()
                End With
            End If
        Catch ex As Exception

        End Try
        PnlPortDestination1.Visible = True
        PnlPortDestination2.Visible = False
        BinPortOrigin()
    End Sub
    Protected Sub BtnAddPortLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddPortLoad.Click
        Try
            pnlPortLoad2.Visible = True
            pnlPortLoad1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsavePortLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSavePortLoad.Click
        Try
            If txtPortLoad.Text <> "" Then
                With ObjPortLoad
                    .PortLoadID = 0
                    .PortLoad = txtPortLoad.Text
                    .SavePortLoad()
                End With
            End If
        Catch ex As Exception
        End Try
        pnlPortLoad1.Visible = True
        pnlPortLoad2.Visible = False
        BinPortLoad()
    End Sub
    Protected Sub ImageButtonAddPaympde_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonAddPaympde.Click
        Try
            Panel3Add.Visible = False
            Panel4Save.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ImageButtonSavePayMode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSavePayMode.Click
        Try
            Dim toDayDate As Date = Date.Today
            Dim Year As String = toDayDate.Year
            If txtPayMode.Text <> "" Then
                With ObjPaymentTerm
                    .PaymentTermID = 0
                    .PaymentTerm = txtPayMode.Text.ToUpper()
                    .SavePaymentTerm()
                End With
                Panel4Save.Visible = False
                Panel3Add.Visible = True
                BinPaymentTerm()
            Else
                Panel4Save.Visible = False
                Panel3Add.Visible = True
                BinPaymentTerm()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub LnkItemDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkItemDatabase.Click
        Try
            Response.Write("<script> window.open('ItemDBAddPopUp.aspx', 'newwindow', 'left=100, top=180, height=300, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        BindcmbItem()
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
        Catch ex As Exception
        End Try
    End Sub
    Sub checkPOrt()
        If cmbOrigin.SelectedValue = 1 Then
            BtnAddPort.Visible = True
        Else
            BtnAddPort.Visible = True
        End If
    End Sub
    Protected Sub cmbOrigin_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrigin.SelectedIndexChanged
        Try
            PnlPortDestination2.Visible = False
            PnlPortDestination1.Visible = True
            checkPOrt()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
        For i As Integer = 0 To dgJobOrderDetail.Items.Count - 1
            Dim txtStyle As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtStyle"), TextBox)
            Dim txtContent As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContent"), TextBox)
            Dim txtGSM As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSM"), TextBox)
            Dim txtGSMAfter As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtGSMAfter"), TextBox)
            Dim lblDPRNDid As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblDPRNDid"), Label)
            Dim cmbItem As DropDownList = DirectCast(dgJobOrderDetail.Items(i).FindControl("cmbItem"), DropDownList)
            Dim txtContentforBuyer As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtContentforBuyer"), TextBox)
            Dim txtColorCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtColorCode"), TextBox)
            Dim txtItemCode As TextBox = DirectCast(dgJobOrderDetail.Items(i).FindControl("txtItemCode"), TextBox)
            Dim lblItemID As Label = DirectCast(dgJobOrderDetail.Items(i).FindControl("lblItemID"), Label)
            Dim PreItemCode As String = dtCurrentTable.Rows(i)("Column16")
            Dim dtItem As DataTable = objJobOrderdatabase.GetItemDataCodeNew(txtItemCode.Text)
            Dim dtItem2 As DataTable = objJobOrderdatabase.GetItemDataCodeForDalRefNo(txtItemCode.Text)
            If dtItem.Rows.Count > 0 Then
                If PreItemCode = txtItemCode.Text Then
                Else
                    lblItemID.Text = dtItem.Rows(0)("imsitemid")
                    txtContent.Text = dtItem.Rows(0)("FabricQualityy")
                    txtContentforBuyer.Text = dtItem.Rows(0)("FabricQualityy")
                    txtGSM.Text = dtItem.Rows(0)("GSMBeforeWash")
                    txtGSMAfter.Text = dtItem.Rows(0)("GSMAfterWash")
                End If
            ElseIf dtItem2.Rows.Count > 0 Then
                If PreItemCode = txtItemCode.Text Then
                Else
                    lblItemID.Text = dtItem2.Rows(0)("imsitemid")
                    txtContent.Text = dtItem2.Rows(0)("FabricQualityy")
                    txtContentforBuyer.Text = dtItem2.Rows(0)("FabricQualityy")
                    If dtItem2.Rows(0)("GSMBeforeWash") = "" Then
                        txtGSM.Text = ""
                    Else
                        txtGSM.Text = dtItem2.Rows(0)("GSMBeforeWash")
                    End If
                    If dtItem2.Rows(0)("GSMAfterWash") = "" Then
                        txtGSMAfter.Text = ""
                    Else
                        txtGSMAfter.Text = dtItem2.Rows(0)("GSMAfterWash")
                    End If
                End If
            End If
        Next
    End Sub
    Protected Sub txtSrNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSrNo.TextChanged
        Try
            If txtSrNo.Text & txtSrNoTwo.Text = lbloldSR.Text Then
                PanelAll.Enabled = True
            Else
                If Type = "Copy" Then
                    btnSave.Enabled = True
                End If
                PanelAll.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddDeliveryTerm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddDeliveryTerm.Click
        Try
            pnlDeliveryTerm2.Visible = True
            pnlDeliveryTerm1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSaveDeliveryTerm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveDeliveryTerm.Click
        Try
            If txtDeliveryTerm.Text <> "" Then
                With objDeliveryTermClass
                    .DeliveryTermId = 0
                    .DeliveryTerm = txtDeliveryTerm.Text
                    .Save()
                End With
            End If
        Catch ex As Exception
        End Try
        pnlDeliveryTerm1.Visible = True
        pnlDeliveryTerm2.Visible = False
        BinDeliveryTerm()
    End Sub


    'Protected Sub BtnAddItemDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddItemDesc.Click
    '    Try
    '        PnlShipmentMode2.Visible = True
    '        PnlShipmentMode1.Visible = False
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Protected Sub BtnSaveItemDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveItemDesc.Click
    '    Try
    '        If txtSaveShipmentMode.Text = "" Then
    '            With objShipmentMode
    '                .ShipmentModeID = 0
    '                .ShipmentMode = txtSaveShipmentMode.Text
    '            End With
    '        Else
    '            With objShipmentMode
    '                .ShipmentModeID = 0
    '                .ShipmentMode = txtSaveShipmentMode.Text
    '                .SaveShipmentMode()
    '            End With
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    PnlShipmentMode1.Visible = True
    '    PnlShipmentMode2.Visible = False
    '    BinShipmentMode()
    'End Sub

    Protected Sub dgJobOrderDetail_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgJobOrderDetail.SelectedIndexChanged
        Try
    
        Catch ex As Exception

        End Try
    End Sub
End Class

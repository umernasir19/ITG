Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class EnquiresSystemAdd
    Inherits System.Web.UI.Page
    Dim objVendor As New Vender
    Dim objCustomer As New Customer
    Dim objEnquiresesEntryaddclass As New EnquiriesSystemAddclass
    Dim objEnquiriesSystemDetailAdd As New EnquiriesSystemDetailAdd
    Dim ObjEnquiriesSystemCPRDetail As New EnquiriesSystemCPRDetail
    Dim ObjEnquiriesSystemCPRBuyerDetail As New EnquiriesSystemCPRBuyerDetail
    Dim OBJEnquiresImageDetail As New EnquiresImageDetail
    Dim OBJEnqCustomerACP As New EnqCustomerACP
    Dim OBJEnqSupplierACP As New EnqSupplierACP
    Dim dtAstyleDetailENQ, dtCPReq, dtCPReqBuyer As DataTable
    Dim IEnquiriesSystemID, LEnqSupplierACPID, LEnqCustomerACPID As Long
    Dim Dr As DataRow
    Dim GeneralCode As New GeneralCode
    Dim Type As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IEnquiriesSystemID = Request.QueryString("EnquiriesSystemID")
        Type = Request.QueryString("Type")
        If Not Page.IsPostBack Then

            OBJEnquiresImageDetail.DeleteStyleUploadDetailTable()
            Session("objDataCRPView1") = Nothing
            Session("dtAstyleDetailENQ") = Nothing
            Session("dtCPReq") = Nothing
            Session("dtCPReqBuyer") = Nothing
            Session("dtAstyleDetailENQ") = Nothing
            Session("ImageByteP") = Nothing
            Session("FileNameP") = Nothing
          
            BindProductCat()
            BindSeason()
            BindCustomer()
            BindSupplier()
            BindCPReq()
            BindCPReqBuyer()
            BindProductConsumer()

            If Type = "Copy" Then
                EditCopyMod()
                btnSave.Text = "Save"
                lnkFIlePicture.Visible = True
            Else
                If IEnquiriesSystemID > 0 Then
                    EditModes()
                    btnSave.Text = "Update"
                    lnkFIlePicture.Visible = True
                Else
                    btnSave.Text = "Save"
                    txtTodaydate.Text = Date.Now
                End If

            End If
        End If
    End Sub
    Sub BindProductConsumer()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.GetProductConsumer
            cmbProductConsumerGrp.DataSource = dt
            cmbProductConsumerGrp.DataTextField = "ProductConsumerName"
            cmbProductConsumerGrp.DataValueField = "ProductConsumerID"
            cmbProductConsumerGrp.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub EditCopyMod()
        Dim dt As DataTable = objEnquiresesEntryaddclass.getEdit(IEnquiriesSystemID)
        If dt.Rows.Count > 0 Then
            txtStyleNo.Text = dt.Rows(0)("StyleNo")
            txtRecvDate.Text = dt.Rows(0)("RecvDate")
            txtTodaydate.Text = dt.Rows(0)("creationdatee")
            '  txtBrand.Text = dt.Rows(0)("Brand")
            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiresesEntryaddclass.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.SelectedValue = dt.Rows(0)("BuyingDept")
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()

            cmbBuyer.SelectedValue = dt.Rows(0)("Buyer")
            cmbBrand.SelectedValue = dt.Rows(0)("Brand")
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            txtExFactoryDate.Text = dt.Rows(0)("ExFactoryDate")
            cmbSeason.SelectedValue = dt.Rows(0)("Seasonid")
            txtSpecialInstruction.Text = dt.Rows(0)("SpecialInstruction")
            txtStyleDesc.Text = dt.Rows(0)("StyleDesc")
            ' txtStylingSource.Text = dt.Rows(0)("StylingSource")
            cmbStyleSource.SelectedItem.Text = dt.Rows(0)("StylingSource")
            cmbEnquireType.SelectedItem.Text = dt.Rows(0)("EnquiryType")
            cmbProductCategory.SelectedValue = dt.Rows(0)("ProductCategoriesID")
            ' txtBuyer.Text = dt.Rows(0)("Buyer")
            cmbPOStatus.SelectedItem.Text = dt.Rows(0)("POStatus")
            cmbProductConsumerGrp.SelectedValue = dt.Rows(0)("ProductConsumerID")
            cmbEnquiryPurpose.SelectedItem.Text = dt.Rows(0)("EnquiryPurpose")
            txtEnquiryConfirmDate.Text = dt.Rows(0)("EnquiryConfirmDate")
            If dt.Rows(0)("FileName") = "" Then
                pictureNotAvialable()
            Else
                Session("FileNameP") = dt.Rows(0)("FileName")
                Session("ImageByteP") = dt.Rows(0)("Picture")
            End If


        End If
        dtAstyleDetailENQ = objEnquiresesEntryaddclass.getEditDetail(IEnquiriesSystemID)

        If dtAstyleDetailENQ.Rows.Count > 0 Then
            'Session("dtAstyleDetailENQ") = dtAstyleDetailENQ
            ' BindGrid()
        End If

        'dtCPReq = objEnquiresesEntryaddclass.getEditCRP(IEnquiriesSystemID)
        dtCPReq = OBJEnqSupplierACP.getEditCRPSupplier(IEnquiriesSystemID)
        If dtCPReq.Rows.Count > 0 Then
            'Session("dtCPReq") = dtCPReq
            'BindGridcpreq()
            'Dim x As Integer
            'For x = 0 To dgCPReq.Items.Count - 1
            '    Dim txtDispatcDate As TextBox = CType(dgCPReq.Items(x).FindControl("txtDispatcDate"), TextBox)
            '    txtDispatcDate.Text = dtCPReq.Rows(x)("DispatchDate")
            'Next

            lblLEnqSupplierACPID.Text = dtCPReq.Rows(0)("EnqSupplierACPID")
            'If dtCPReq.Rows(0)("FabricDate") = "" Then
            'Else
            txtFabricDate.Text = dtCPReq.Rows(0)("FabricDate")
            'End If
            'If dtCPReq.Rows(0)("PriceDate") = "" Then
            'Else
            txtPriceDate.Text = dtCPReq.Rows(0)("PriceDate")
            'End If
            If dtCPReq.Rows(0)("ProtoSampleDate") = "" Then
            Else
                txtProtoSamplDate.Text = dtCPReq.Rows(0)("ProtoSampleDatee")
            End If
            If dtCPReq.Rows(0)("LabDipDate") = "" Then
            Else
                txtLabDipDate.Text = dtCPReq.Rows(0)("LabDipDatee")
            End If
            If dtCPReq.Rows(0)("PhotoSampleDate") = "" Then
            Else
                txtPhotoSampleDate.Text = dtCPReq.Rows(0)("PhotoSampleDatee")
            End If
            If dtCPReq.Rows(0)("SellerSampleDate") = "" Then
            Else
                txtSellerDate.Text = dtCPReq.Rows(0)("SellerSampleDatee")
            End If
            txtRemarksSupplier.Text = dtCPReq.Rows(0)("EnqSRemarks")
        End If
        'dtCPReqBuyer = objEnquiresesEntryaddclass.getEditCRPBUYER(IEnquiriesSystemID)
        dtCPReqBuyer = OBJEnqCustomerACP.getEditCRPBUYER(IEnquiriesSystemID)
        If dtCPReqBuyer.Rows.Count > 0 Then
            'Session("dtCPReqBuyer") = dtCPReqBuyer
            'BindGridcpreqBuyer()
            lblLEnqCustomerACPID.Text = dtCPReqBuyer.Rows(0)("EnqCustomerACPID")
            If dtCPReqBuyer.Rows(0)("TechPackDate") = "" Then
            Else
                txtTechPackDate.Text = dtCPReqBuyer.Rows(0)("TechPackDatee")
            End If
            If dtCPReqBuyer.Rows(0)("OriginalSampleDate") = "" Then
            Else
                txtOriginalSampleDate.Text = dtCPReqBuyer.Rows(0)("OriginalSampleDatee")
            End If
            'If dtCPReqBuyer.Rows(0)("MOQDate") = "" Then
            'Else
            txtMOQDate.Text = dtCPReqBuyer.Rows(0)("MOQDate")
            'End If
            If dtCPReqBuyer.Rows(0)("CadArtworkDate") = "" Then
            Else
                txtCadArtworkDate.Text = dtCPReqBuyer.Rows(0)("CadArtworkDatee")
            End If
            If dtCPReqBuyer.Rows(0)("PODate") = "" Then
            Else
                txtPurchaseOrderDate.Text = dtCPReqBuyer.Rows(0)("PODatee")
            End If
            txtRemarksBuyer.Text = dtCPReqBuyer.Rows(0)("EnqCRemarks")
        End If
        Dim objDataTable As DataTable = OBJEnquiresImageDetail.GetFileInfoNew(IEnquiriesSystemID)
        If objDataTable.Rows.Count > 0 Then
            '    Dim objDataView = New DataView(objDataTable)
            '     Session("objDataCRPView1") = objDataView
            '   BindGridFileInfo()
        End If

    End Sub
    Sub EditModes()
        Dim dt As DataTable = objEnquiresesEntryaddclass.getEdit(IEnquiriesSystemID)
        If dt.Rows.Count > 0 Then
            txtStyleNo.Text = dt.Rows(0)("StyleNo")
            txtRecvDate.Text = dt.Rows(0)("RecvDate")
            txtTodaydate.Text = dt.Rows(0)("creationdatee")
            '  txtBrand.Text = dt.Rows(0)("Brand")
            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiresesEntryaddclass.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.SelectedValue = dt.Rows(0)("BuyingDept")
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
           
            cmbBuyer.SelectedValue = dt.Rows(0)("Buyer")
            cmbBrand.SelectedValue = dt.Rows(0)("Brand")

            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            txtExFactoryDate.Text = dt.Rows(0)("ExFactoryDate")
            cmbSeason.SelectedValue = dt.Rows(0)("Seasonid")
            txtSpecialInstruction.Text = dt.Rows(0)("SpecialInstruction")
            txtStyleDesc.Text = dt.Rows(0)("StyleDesc")
            ' txtStylingSource.Text = dt.Rows(0)("StylingSource")
            cmbStyleSource.SelectedItem.Text = dt.Rows(0)("StylingSource")
            cmbEnquireType.SelectedItem.Text = dt.Rows(0)("EnquiryType")
            cmbProductCategory.SelectedValue = dt.Rows(0)("ProductCategoriesID")
            ' txtBuyer.Text = dt.Rows(0)("Buyer")
            cmbPOStatus.SelectedItem.Text = dt.Rows(0)("POStatus")
            cmbProductConsumerGrp.SelectedValue = dt.Rows(0)("ProductConsumerID")
            cmbEnquiryPurpose.SelectedItem.Text = dt.Rows(0)("EnquiryPurpose")
            txtEnquiryConfirmDate.Text = dt.Rows(0)("EnquiryConfirmDate")
            If dt.Rows(0)("FileName") = "" Then
                pictureNotAvialable()
            Else
                Session("FileNameP") = dt.Rows(0)("FileName")
                Session("ImageByteP") = dt.Rows(0)("Picture")
            End If

        
        End If
        dtAstyleDetailENQ = objEnquiresesEntryaddclass.getEditDetail(IEnquiriesSystemID)

        If dtAstyleDetailENQ.Rows.Count > 0 Then
            Session("dtAstyleDetailENQ") = dtAstyleDetailENQ
            BindGrid()
        End If

        'dtCPReq = objEnquiresesEntryaddclass.getEditCRP(IEnquiriesSystemID)
        dtCPReq = OBJEnqSupplierACP.getEditCRPSupplier(IEnquiriesSystemID)
        If dtCPReq.Rows.Count > 0 Then
            'Session("dtCPReq") = dtCPReq
            'BindGridcpreq()
            'Dim x As Integer
            'For x = 0 To dgCPReq.Items.Count - 1
            '    Dim txtDispatcDate As TextBox = CType(dgCPReq.Items(x).FindControl("txtDispatcDate"), TextBox)
            '    txtDispatcDate.Text = dtCPReq.Rows(x)("DispatchDate")
            'Next

            lblLEnqSupplierACPID.Text = dtCPReq.Rows(0)("EnqSupplierACPID")
            'If dtCPReq.Rows(0)("FabricDate") = "" Then
            'Else
            txtFabricDate.Text = dtCPReq.Rows(0)("FabricDate")
            'End If
            'If dtCPReq.Rows(0)("PriceDate") = "" Then
            'Else
            txtPriceDate.Text = dtCPReq.Rows(0)("PriceDate")
            'End If
            If dtCPReq.Rows(0)("ProtoSampleDate") = "" Then
            Else
                txtProtoSamplDate.Text = dtCPReq.Rows(0)("ProtoSampleDatee")
            End If
            If dtCPReq.Rows(0)("LabDipDate") = "" Then
            Else
                txtLabDipDate.Text = dtCPReq.Rows(0)("LabDipDatee")
            End If
            If dtCPReq.Rows(0)("PhotoSampleDate") = "" Then
            Else
                txtPhotoSampleDate.Text = dtCPReq.Rows(0)("PhotoSampleDatee")
            End If
            If dtCPReq.Rows(0)("SellerSampleDate") = "" Then
            Else
                txtSellerDate.Text = dtCPReq.Rows(0)("SellerSampleDatee")
            End If
            txtRemarksSupplier.Text = dtCPReq.Rows(0)("EnqSRemarks")
        End If
        'dtCPReqBuyer = objEnquiresesEntryaddclass.getEditCRPBUYER(IEnquiriesSystemID)
        dtCPReqBuyer = OBJEnqCustomerACP.getEditCRPBUYER(IEnquiriesSystemID)
        If dtCPReqBuyer.Rows.Count > 0 Then
            'Session("dtCPReqBuyer") = dtCPReqBuyer
            'BindGridcpreqBuyer()
            lblLEnqCustomerACPID.Text = dtCPReqBuyer.Rows(0)("EnqCustomerACPID")
            If dtCPReqBuyer.Rows(0)("TechPackDate") = "" Then
            Else
                txtTechPackDate.Text = dtCPReqBuyer.Rows(0)("TechPackDatee")
            End If
            If dtCPReqBuyer.Rows(0)("OriginalSampleDate") = "" Then
            Else
                txtOriginalSampleDate.Text = dtCPReqBuyer.Rows(0)("OriginalSampleDatee")
            End If
            'If dtCPReqBuyer.Rows(0)("MOQDate") = "" Then
            'Else
            txtMOQDate.Text = dtCPReqBuyer.Rows(0)("MOQDate")
            'End If
            If dtCPReqBuyer.Rows(0)("CadArtworkDate") = "" Then
            Else
                txtCadArtworkDate.Text = dtCPReqBuyer.Rows(0)("CadArtworkDatee")
            End If
            If dtCPReqBuyer.Rows(0)("PODate") = "" Then
            Else
                txtPurchaseOrderDate.Text = dtCPReqBuyer.Rows(0)("PODatee")
            End If
            txtRemarksBuyer.Text = dtCPReqBuyer.Rows(0)("EnqCRemarks")
        End If
        Dim objDataTable As DataTable = OBJEnquiresImageDetail.GetFileInfoNew(IEnquiriesSystemID)
        If objDataTable.Rows.Count > 0 Then
            Dim objDataView = New DataView(objDataTable)
            Session("objDataCRPView1") = objDataView
            BindGridFileInfo()
        End If

    End Sub
    Sub BindProductCat()
        Dim dtProductCategories As DataTable
        dtProductCategories = objEnquiresesEntryaddclass.GetAllProductCategories()
        cmbProductCategory.DataSource = dtProductCategories
        cmbProductCategory.DataTextField = "ProductCategories"
        cmbProductCategory.DataValueField = "ProductCategoriesID"
        cmbProductCategory.DataBind()
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCPReq()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.Getcpreq
            cmbRequirement.DataSource = dt
            cmbRequirement.DataTextField = "CPRequirmen"
            cmbRequirement.DataValueField = "CPRequirmentID"
            cmbRequirement.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCPReqBuyer()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.GetcpreqBuyer
            cmbrequirmentBuyer.DataSource = dt
            cmbrequirmentBuyer.DataTextField = "CPRequirementB"
            cmbrequirmentBuyer.DataValueField = "CPRequirmentBID"
            cmbrequirmentBuyer.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiresesEntryaddclass.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            '---Bind Byuer Name
            'cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNo(cmbCustomer.SelectedValue)
            'cmbBuyer.DataTextField = "BuyerName"
            'cmbBuyer.DataValueField = "BuyerName"
            'cmbBuyer.DataBind()
            'UpdatecmbBuyerName.Update()
            ''---Bind Brand 
            'cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBrandInfoNo(cmbCustomer.SelectedValue)
            'cmbBrand.DataTextField = "BrandName"
            'cmbBrand.DataValueField = "BrandName"
            'cmbBrand.DataBind()
            'UpcmbBrand.Update()

            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
    '    Try


    '        '---Bind Byuer Name
    '        cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNo(cmbCustomer.SelectedValue)
    '        cmbBuyer.DataTextField = "BuyerName"
    '        cmbBuyer.DataValueField = "BuyerName"
    '        cmbBuyer.DataBind()
    '        UpdatecmbBuyerName.Update()
    '        '---Bind Brand 
    '        cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBrandInfoNo(cmbCustomer.SelectedValue)
    '        cmbBrand.DataTextField = "BrandName"
    '        cmbBrand.DataValueField = "BrandName"
    '        cmbBrand.DataBind()
    '        UpcmbBrand.Update()
    '        '---Bind BuyingDept
    '        cmbBuyingDept.DataSource = objEnquiresesEntryaddclass.GetBuyingDeptenq(cmbCustomer.SelectedValue)
    '        cmbBuyingDept.DataTextField = "BuyingDept"
    '        cmbBuyingDept.DataValueField = "BuyingDept"
    '        cmbBuyingDept.DataBind()
    '        UpcmbBuyingDept.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.getDataforBindCombo
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            ' If txtMOQ.Text = "" Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("MOQ empty.")
            'ElseIf txtColorways.Text = "" Then
            ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Colorways empty.")
            ' ElseIf txtPrice.Text = "" Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Price empty.")
            '  Else
            ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            FillGridByStyleDetail()
            txtColorways.Text = ""
            txtMOQ.Text = ""
            txtPrice.Text = ""
            txtFabricRemarks.Text = ""
            txtFabric.Text = ""
            txtBuyerTargetPrice.Text = ""
            txtFabricDetail.Text = "" 'as construction
            txtcompostion.Text = ""
            txtweight.Text = ""


            ' End If




        Catch ex As Exception
        End Try

    End Sub
    Sub FillGridByStyleDetail()
        Try
            If (Not CType(Session("dtAstyleDetailENQ"), DataTable) Is Nothing) Then
                dtAstyleDetailENQ = Session("dtAstyleDetailENQ")
            Else
                dtAstyleDetailENQ = New DataTable
                With dtAstyleDetailENQ
                    .Columns.Add("EnquiriesSystemDetailID", GetType(Long))
                    .Columns.Add("Colorways", GetType(String))
                    .Columns.Add("MOQ", GetType(String))
                    .Columns.Add("BuyerTargetPrice", GetType(String))
                    .Columns.Add("BuyerTargetPriceUnit", GetType(String))
                    .Columns.Add("Price", GetType(String))
                    .Columns.Add("PriceUnit", GetType(String))
                    .Columns.Add("Fabric", GetType(String))
                    .Columns.Add("FabricRemarks", GetType(String))
                    .Columns.Add("Construction", GetType(String))
                    .Columns.Add("Compostion", GetType(String))
                    .Columns.Add("Weight", GetType(String))
                End With
            End If

            Dr = dtAstyleDetailENQ.NewRow()
            Dr("EnquiriesSystemDetailID") = 0
            If txtColorways.Text = "" Then
                Dr("Colorways") = " "
            Else
                Dr("Colorways") = txtColorways.Text
            End If
            If txtMOQ.Text = "" Then
                Dr("MOQ") = " "
            Else
                Dr("MOQ") = txtMOQ.Text
            End If
            If txtBuyerTargetPrice.Text = "" Then
                Dr("BuyerTargetPrice") = " "
            Else
                Dr("BuyerTargetPrice") = txtBuyerTargetPrice.Text
            End If

            Dr("BuyerTargetPriceUnit") = cmbBuyerPriceUnit.SelectedItem.Text


            If txtPrice.Text = "" Then
                Dr("Price") = " "
            Else
                Dr("Price") = txtPrice.Text
            End If

            Dr("PriceUnit") = cmbCurrency.SelectedItem.Text
            If txtFabric.Text = "" Then
                Dr("Fabric") = " "
            Else
                Dr("Fabric") = txtFabric.Text
            End If
            If txtFabricRemarks.Text = "" Then
                Dr("FabricRemarks") = " "
            Else
                Dr("FabricRemarks") = txtFabricRemarks.Text
            End If

            If txtFabricDetail.Text = "" Then
                Dr("Construction") = " "
            Else
                Dr("Construction") = txtFabricDetail.Text
            End If
            If txtcompostion.Text = "" Then
                Dr("Compostion") = " "
            Else
                Dr("Compostion") = txtcompostion.Text
            End If
            If txtweight.Text = "" Then
                Dr("Weight") = " "
            Else
                Dr("Weight") = txtweight.Text
            End If

            dtAstyleDetailENQ.Rows.Add(Dr)
            Session("dtAstyleDetailENQ") = dtAstyleDetailENQ
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtAstyleDetailENQ Is Nothing) Then
            If (dtAstyleDetailENQ.Rows.Count > 0) Then
                dgEnqDetail.DataSource = dtAstyleDetailENQ
                dgEnqDetail.DataBind()
                dgEnqDetail.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function

    Protected Sub dgEnqDetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgEnqDetail.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    dtAstyleDetailENQ = CType(Session("dtAstyleDetailENQ"), DataTable)
                    If (Not dtAstyleDetailENQ Is Nothing) Then
                        If (dtAstyleDetailENQ.Rows.Count > 0) Then
                            Dim lEnquiriesSystemDetailID As Integer = dtAstyleDetailENQ.Rows(e.Item.ItemIndex)("EnquiriesSystemDetailID")
                            dtAstyleDetailENQ.Rows.RemoveAt(e.Item.ItemIndex)
                            objEnquiresesEntryaddclass.DeleteDetailById(lEnquiriesSystemDetailID)
                            BindGrid()
                            If dtAstyleDetailENQ.Rows.Count = 0 Then
                                dgEnqDetail.DataSource = dtAstyleDetailENQ
                                dgEnqDetail.DataBind()
                                dgEnqDetail.Visible = False
                            End If
                        Else
                            dgEnqDetail.Visible = False
                        End If
                    End If
            End Select

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncr_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncr.Click
        Try
            If txtCrDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                FillGridByDCRtail()
                txtCrDate.Text = ""
                txtRemarksSupplier.Text = ""

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnByerCRPAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnByerCRPAdd.Click
        Try
            If txtCrBDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                FillGridByDCRByerDtail()
                txtCrBDate.Text = ""
                txtRemarksBuyer.Text = ""

            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub FillGridByDCRByerDtail()
        Try
            If (Not CType(Session("dtCPReqBuyer"), DataTable) Is Nothing) Then
                dtCPReqBuyer = Session("dtCPReqBuyer")
            Else
                dtCPReqBuyer = New DataTable
                With dtCPReqBuyer
                    .Columns.Add("EnquiriesSystemCPRBuyerID", GetType(Long))
                    .Columns.Add("CPRequirmentBID", GetType(Long))
                    .Columns.Add("CPRequirementB", GetType(String))
                    .Columns.Add("CPRBDate", GetType(String))
                    .Columns.Add("RemarksB", GetType(String))
                End With
            End If

            Dr = dtCPReqBuyer.NewRow()
            Dr("EnquiriesSystemCPRBuyerID") = 0
            Dr("CPRequirementB") = cmbrequirmentBuyer.SelectedItem.Text
            Dr("CPRequirmentBID") = cmbrequirmentBuyer.SelectedValue
            Dr("CPRBDate") = txtCrBDate.Text
            If txtRemarksBuyer.Text = "" Then
                Dr("RemarksB") = " "
            Else
                Dr("RemarksB") = txtRemarksBuyer.Text
            End If


            dtCPReqBuyer.Rows.Add(Dr)
            Session("dtCPReqBuyer") = dtCPReqBuyer
            BindGridcpreqBuyer()
        Catch ex As Exception

        End Try
    End Sub
    Sub FillGridByDCRtail()
        Try
            If (Not CType(Session("dtCPReq"), DataTable) Is Nothing) Then
                dtCPReq = Session("dtCPReq")
            Else
                dtCPReq = New DataTable
                With dtCPReq
                    .Columns.Add("EnquiriesSystemCPRID", GetType(Long))
                    .Columns.Add("CPRequirement", GetType(String))
                    .Columns.Add("CPRequirmentID", GetType(Long))
                    .Columns.Add("CPRDate", GetType(String))
                    .Columns.Add("DispatchDate", GetType(String))
                    .Columns.Add("Remarks", GetType(String))


                End With
            End If

            Dr = dtCPReq.NewRow()
            Dr("EnquiriesSystemCPRID") = 0
            Dr("CPRequirement") = cmbRequirement.SelectedItem.Text
            Dr("CPRequirmentID") = cmbRequirement.SelectedValue
            Dr("CPRDate") = txtCrDate.Text
            Dr("DispatchDate") = String.Empty
            If txtRemarksSupplier.Text = "" Then
                Dr("Remarks") = " "
            Else
                Dr("Remarks") = txtRemarksSupplier.Text
            End If


            dtCPReq.Rows.Add(Dr)

            Session("dtCPReq") = dtCPReq
            BindGridcpreq()
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGridcpreqBuyer() As Boolean
        If (Not dtCPReqBuyer Is Nothing) Then
            If (dtCPReqBuyer.Rows.Count > 0) Then
                dgCPReqBuyer.DataSource = dtCPReqBuyer
                dgCPReqBuyer.DataBind()
                dgCPReqBuyer.Visible = True

                Return (True)
            End If
        End If

        Return (False)
    End Function
    Private Function BindGridcpreq() As Boolean
        If (Not dtCPReq Is Nothing) Then
            If (dtCPReq.Rows.Count > 0) Then
                dgCPReq.DataSource = dtCPReq
                dgCPReq.DataBind()
                dgCPReq.Visible = True

                Return (True)
            End If
        End If

        Return (False)
    End Function
    Protected Sub dgCPReqBuyer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCPReqBuyer.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    dtCPReqBuyer = CType(Session("dtCPReqBuyer"), DataTable)
                    If (Not dgCPReqBuyer Is Nothing) Then
                        If (dtCPReqBuyer.Rows.Count > 0) Then
                            Dim lEnquiriesSystemCPRBuyerID As Integer = dtCPReqBuyer.Rows(e.Item.ItemIndex)("EnquiriesSystemCPRBuyerID")
                            dtCPReqBuyer.Rows.RemoveAt(e.Item.ItemIndex)
                            objEnquiresesEntryaddclass.DeleteDetailcprbUYERById(lEnquiriesSystemCPRBuyerID)
                            BindGridcpreqBuyer()
                            If dtCPReqBuyer.Rows.Count = 0 Then
                                dgCPReqBuyer.DataSource = dtCPReqBuyer
                                dgCPReqBuyer.DataBind()
                                dgCPReqBuyer.Visible = False

                            End If
                        Else
                            dgCPReqBuyer.Visible = False
                        End If
                    End If
            End Select

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgCPReq_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCPReq.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    dtCPReq = CType(Session("dtCPReq"), DataTable)
                    If (Not dtCPReq Is Nothing) Then
                        If (dtCPReq.Rows.Count > 0) Then
                            Dim lEnquiriesSystemCPRID As Integer = dtCPReq.Rows(e.Item.ItemIndex)("EnquiriesSystemCPRID")
                            dtCPReq.Rows.RemoveAt(e.Item.ItemIndex)
                            objEnquiresesEntryaddclass.DeleteDetailcprById(lEnquiriesSystemCPRID)
                            BindGridcpreq()
                            If dtCPReq.Rows.Count = 0 Then
                                dgCPReq.DataSource = dtCPReq
                                dgCPReq.DataBind()
                                dgCPReq.Visible = False
                            End If
                        Else
                            dgCPReq.Visible = False
                        End If
                    End If
            End Select

        Catch ex As Exception
        End Try
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub SaveUploaddata()
        Try
            'Dim EnquiriesSystemID As Long = 0
            With OBJEnquiresImageDetail
                .EnquiresImageDetailID = 0

                If IEnquiriesSystemID > 0 Then
                    .EnquiriesSystemID = IEnquiriesSystemID

                Else
                    .EnquiriesSystemID = 0 'objStyleMaster.GetID()
                    'objStyleMaster.GetID()
                End If
                If FileUpload1.FileName = "" Then
                    Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
                    ' Session("FileName") = "NoImage.JPEG"
                    ' Session("ImageByte") = GetFileContent(path2)
                    .UploadPicture = GetFileContent(path)
                    .FileName = "no-image.jpg"
                Else
                    .FileName = FileUpload1.FileName
                    .UploadPicture = SaveUploadPicture()
                End If
                .FileDescription = txtFileDescription.Text
                .FileNameWr = txtFileName.Text
                .SaveEnquiresImageUploads()
            End With

            'Show in grid
            Dim objDataView1 As DataView
            objDataView1 = LoadData1(IEnquiriesSystemID)
            Session("objDataCRPView1") = objDataView1
            BindGridFileInfo()


            Dim dtt = objDataView1.ToTable
            Dim x As Integer = 0
            For x = 0 To dgFileInfo.Items.Count - 1
                Dim Image1 As Image = DirectCast(dgFileInfo.Items(x).FindControl("Image1"), Image)
                Dim Picstype As String = dgFileInfo.Items(x).Cells(3).Text
                Dim bytes As Byte() = DirectCast(dtt.Rows(x)("UploadPicture"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                If Picstype = "Picture" Then
                    Image1.ImageUrl = "data:image/png;base64," & base64String
                    Image1.Visible = True
                    Image1.Visible = True
                Else
                    Image1.Visible = False
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridFileInfo()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataCRPView1")
        If objDataView.Count > 0 Then
            strSortExpression = dgFileInfo.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgFileInfo.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgFileInfo.Visible = True
            dgFileInfo.RecordCount = objDataView.Count
            dgFileInfo.DataSource = objDataView
            dgFileInfo.DataBind()
        Else
            dgFileInfo.Visible = False
        End If
    End Sub
    Function SaveUploadPicture() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload1.HasFile AndAlso Not FileUpload1.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = FileUpload1.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Function LoadData1(ByVal IEnquiriesSystemID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = OBJEnquiresImageDetail.GetFileInfoNew(IEnquiriesSystemID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
        If FileUpload1.FileName = "" Then
            SaveUploaddata()
            'lblErrorMsg.Text = "No File"
        ElseIf fileExt = ".jpg" Then
            lblErrorMsg.Text = ""
            SaveUploaddata()
        ElseIf fileExt = ".pdf" Then
            lblErrorMsg.Text = ""
            SaveUploaddata()
            '--Noted  if we upload Xl etc then we show excel on upload popup
            '  ElseIf fileExt = ".xls" OrElse fileExt = ".xlsx" Then
            '  SaveUploaddata()
        Else
            lblErrorMsg.Text = "Only jpg or Pdf file allow to upload"
        End If
    End Sub
    Protected Sub dgFileInfo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFileInfo.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "DownloadFile"
                    Dim lEnquiresImageDetailID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim EnquiriesSystemID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text
                    ScriptManager.RegisterClientScriptBlock(Me.UpdgFileInfo, Me.UpdgFileInfo.GetType(), "New ClientScript", "window.open('EnquiriesDatabaseUploadShow.aspx?EnquiresImageDetailID=" & lEnquiresImageDetailID & "&EnquiriesSystemID=" & EnquiriesSystemID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                Case Is = "Remove"
                    Dim lEnquiresImageDetailID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim EnquiriesSystemID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text

                    OBJEnquiresImageDetail.DeleteStyleUploadTableonAddPage(lEnquiresImageDetailID, EnquiriesSystemID)

                    'Show in grid
                    Dim objDataView1 As DataView
                    objDataView1 = LoadData1(IEnquiriesSystemID)
                    Session("objDataCRPView1") = objDataView1
                    BindGridFileInfo()

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
          


                If txtStyleNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No. Empty")
                ElseIf txtRecvDate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Recv. Date Empty")
                    ' ElseIf txtExFactoryDate.Text = "" Then
                    '  DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Ex Factory Date Empty")
                ElseIf dgEnqDetail.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("ADD Article Description")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    savemaster()
                    saveArticledes()
                    saveCriticalpathSUPPLIER()
                    saveCriticalpathBUYER()
                    Dim a As Long
                    If IEnquiriesSystemID > 0 Then
                        If Type = "Copy" Then
                            a = objEnquiresesEntryaddclass.GetId
                        Else
                            a = IEnquiriesSystemID
                        End If

                    Else
                        a = objEnquiresesEntryaddclass.GetId
                    End If
                    OBJEnquiresImageDetail.UpdateStyleUploadTable(a)
                    Response.Redirect("EnquiriesSystemViewNew.aspx")
                End If


        Catch ex As Exception

        End Try
    End Sub
    Sub savemaster()
        With objEnquiresesEntryaddclass
            If IEnquiriesSystemID > 0 Then
                If Type = "Copy" Then
                    .EnquiriesSystemID = 0
                    .CreationDate = Date.Today
                Else
                    .EnquiriesSystemID = IEnquiriesSystemID
                    .CreationDate = GeneralCode.GetDateCr(txtTodaydate.Text)
                End If
                '.EnquiriesSystemID = IEnquiriesSystemID
                '.CreationDate = GeneralCode.GetDateCr(txtTodaydate.Text)
            Else
                .EnquiriesSystemID = 0
                .CreationDate = Date.Today
            End If


            .StyleNo = txtStyleNo.Text
            .RecvDate = GeneralCode.GetDate(txtRecvDate.Text)
            .Brand = cmbBrand.SelectedItem.Text 'txtBrand.Text
            .CustomerID = cmbCustomer.SelectedValue
            .SupplierID = cmbSupplier.SelectedValue
            .ExFactoryDate = txtExFactoryDate.Text 'GeneralCode.GetDate(txtExFactoryDate.Text)
            .Seasonid = cmbSeason.SelectedValue
            .SpecialInstruction = txtSpecialInstruction.Text
            .StyleDesc = txtStyleDesc.Text
            .StylingSource = cmbStyleSource.SelectedItem.Text
            .EnquiryType = cmbEnquireType.SelectedItem.Text
            .ProductCategoriesID = cmbProductCategory.SelectedValue
            .Buyer = cmbBuyer.SelectedItem.Text 'txtBuyer.Text
            .POStatus = cmbPOStatus.SelectedItem.Text
            If Session("FileNameP") = "" Then
                pictureNotAvialable()
                .FileName = Session("FileNameP")
                .Picture = Session("ImageByteP")
            Else
                .FileName = Session("FileNameP")
                .Picture = Session("ImageByteP")
            End If
            .UserID = CLng(Session("UserID"))
            .ProductConsumerID = cmbProductConsumerGrp.SelectedValue
            .EnquiryPurpose = cmbEnquiryPurpose.SelectedItem.Text
            .EnquiryConfirmDate = txtEnquiryConfirmDate.Text
            .BuyingDept = cmbBuyingDept.SelectedItem.Text
            .SaveEnquiriesSystem()
        End With
    End Sub
    Sub saveArticledes()
        Dim x As Integer
        For x = 0 To dgEnqDetail.Items.Count - 1
            With objEnquiriesSystemDetailAdd
                .EnquiriesSystemDetailID = dgEnqDetail.Items(x).Cells(0).Text
                If IEnquiriesSystemID > 0 Then
                    If Type = "Copy" Then
                        .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
                    Else
                        .EnquiriesSystemID = IEnquiriesSystemID
                    End If

                Else
                    .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
                End If
                .Colorways = dgEnqDetail.Items(x).Cells(1).Text
                .MOQ = dgEnqDetail.Items(x).Cells(2).Text
                .BuyerTargetPrice = dgEnqDetail.Items(x).Cells(3).Text
                .BuyerTargetPriceUnit = dgEnqDetail.Items(x).Cells(4).Text
                .Price = dgEnqDetail.Items(x).Cells(5).Text
                .PriceUnit = dgEnqDetail.Items(x).Cells(6).Text
                .Fabric = dgEnqDetail.Items(x).Cells(7).Text
                .FabricRemarks = dgEnqDetail.Items(x).Cells(11).Text
                .Construction = dgEnqDetail.Items(x).Cells(8).Text
                .Compostion = dgEnqDetail.Items(x).Cells(9).Text
                .Weight = dgEnqDetail.Items(x).Cells(10).Text
                .SaveEnquiriesSystemDetail()

            End With
        Next
    End Sub
    Sub saveCriticalpathSUPPLIER()
        'Dim x As Integer
        'For x = 0 To dgCPReq.Items.Count - 1
        '    Dim txtDispatcDate As TextBox = CType(dgCPReq.Items(x).FindControl("txtDispatcDate"), TextBox)
        '    With ObjEnquiriesSystemCPRDetail
        '        .EnquiriesSystemCPRID = dgCPReq.Items(x).Cells(0).Text
        '        If IEnquiriesSystemID > 0 Then
        '            .EnquiriesSystemID = IEnquiriesSystemID
        '        Else
        '            .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
        '        End If
        '        .CPRequirmentID = dgCPReq.Items(x).Cells(1).Text
        '        .CPRequirement = dgCPReq.Items(x).Cells(2).Text
        '        .CPRDate = GeneralCode.GetDate(dgCPReq.Items(x).Cells(3).Text)
        '        .Remarks = dgCPReq.Items(x).Cells(4).Text
        '        .DispatchDate = txtDispatcDate.Text
        '        .SaveEnquiriesCRPSystem()
        '    End With
        'Next
        With OBJEnqSupplierACP
            If Val(lblLEnqSupplierACPID.Text) > 0 Then
                If Type = "Copy" Then
                    .EnqSupplierACPID = 0
                Else
                    .EnqSupplierACPID = Val(lblLEnqSupplierACPID.Text)
                End If

            Else
                .EnqSupplierACPID = 0
            End If
            If IEnquiriesSystemID > 0 Then
                If Type = "Copy" Then
                    .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
                Else
                    .EnquiriesSystemID = IEnquiriesSystemID
                End If

            Else
                .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
            End If
            If txtFabricDate.Text = "" Then
                .FabricDate = ""
            Else
                .FabricDate = txtFabricDate.Text
            End If
            If txtPriceDate.Text = "" Then
                .PriceDate = ""
            Else
                .PriceDate = txtPriceDate.Text
            End If
            If txtProtoSamplDate.Text = "" Then
                .ProtoSampleDate = ""
            Else
                .ProtoSampleDate = GeneralCode.GetDateNews(txtProtoSamplDate.Text)
            End If
            If txtLabDipDate.Text = "" Then
                .LabDipDate = ""
            Else
                .LabDipDate = GeneralCode.GetDateNews(txtLabDipDate.Text)
            End If
            If txtPhotoSampleDate.Text = "" Then
                .PhotoSampleDate = ""
            Else
                .PhotoSampleDate = GeneralCode.GetDateNews(txtPhotoSampleDate.Text)
            End If
            If txtSellerDate.Text = "" Then
                .SellerSampleDate = ""
            Else
                .SellerSampleDate = GeneralCode.GetDateNews(txtSellerDate.Text)
            End If
            .EnqSRemarks = txtRemarksSupplier.Text
            .saveEnqSupplierACP()
        End With

    End Sub
    Sub saveCriticalpathBUYER()
        'Dim x As Integer
        'For x = 0 To dgCPReqBuyer.Items.Count - 1
        '    With ObjEnquiriesSystemCPRBuyerDetail
        '        .EnquiriesSystemCPRBuyerID = dgCPReqBuyer.Items(x).Cells(0).Text
        '        If IEnquiriesSystemID > 0 Then
        '            .EnquiriesSystemID = IEnquiriesSystemID
        '        Else
        '            .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
        '        End If
        '        .CPRequirmentBID = dgCPReqBuyer.Items(x).Cells(1).Text
        '        .CPRequirementB = dgCPReqBuyer.Items(x).Cells(2).Text
        '        .CPRBDate = GeneralCode.GetDate(dgCPReqBuyer.Items(x).Cells(3).Text)
        '        .RemarksB = dgCPReqBuyer.Items(x).Cells(4).Text
        '        .SaveEnquiriesCRPSystem()
        '    End With
        'Next
        With OBJEnqCustomerACP
            If Val(lblLEnqCustomerACPID.Text) > 0 Then
                If Type = "Copy" Then
                    .EnqCustomerACPID = 0
                Else
                    .EnqCustomerACPID = Val(lblLEnqCustomerACPID.Text)
                End If

            Else
                .EnqCustomerACPID = 0
            End If
            If IEnquiriesSystemID > 0 Then
                If Type = "Copy" Then
                    .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
                Else
                    .EnquiriesSystemID = IEnquiriesSystemID
                End If

            Else
                .EnquiriesSystemID = objEnquiresesEntryaddclass.GetId()
            End If
            If txtTechPackDate.Text = "" Then
                .TechPackDate = ""
            Else
                .TechPackDate = GeneralCode.GetDateNews(txtTechPackDate.Text)
            End If

            If txtOriginalSampleDate.Text = "" Then
                .OriginalSampleDate = ""
            Else
                .OriginalSampleDate = GeneralCode.GetDateNews(txtOriginalSampleDate.Text)
            End If
            If txtMOQDate.Text = "" Then
                .MOQDate = ""
            Else
                .MOQDate = txtMOQDate.Text
            End If
            If txtCadArtworkDate.Text = "" Then
                .CadArtworkDate = ""
            Else
                .CadArtworkDate = GeneralCode.GetDateNews(txtCadArtworkDate.Text)
            End If
            If txtPurchaseOrderDate.Text = "" Then
                .PODate = ""
            Else
                .PODate = GeneralCode.GetDateNews(txtPurchaseOrderDate.Text)
            End If
            .EnqCRemarks = txtRemarksBuyer.Text

            .SaveEnqCustomerACP()
        End With
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("EnquiriesSystemViewNew.aspx")
        Catch ex As Exception

        End Try
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
            If IEnquiriesSystemID > 0 Then
                Dim dt As DataTable = objEnquiresesEntryaddclass.getEdit(IEnquiriesSystemID)
                If dt.Rows.Count > 0 Then
                    txtRecvDate.Text = dt.Rows(0)("RecvDate")
                End If

            Else
                txtRecvDate.Text = ""
            End If

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
    Protected Sub lnkFIlePicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFIlePicture.Click
        Try
            '  ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('SRQTechPackUploadShow.aspx?FileName=" & Session("FileNameTP") & "&Byte=" & Session("ImageByteTP") & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
            'Response.Write("<script> window.open('SRQTechPackUploadShow.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

            ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('EnquiryPicturePopUp.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objEnquiresesEntryaddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
          

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
        
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyer.SelectedIndexChanged
        Try
            ''---Bind Brand 
            cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBrandReportNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
          
        Catch ex As Exception

        End Try
    End Sub
End Class
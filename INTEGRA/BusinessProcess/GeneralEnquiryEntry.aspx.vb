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
Public Class GeneralEnquiryEntry
    Inherits System.Web.UI.Page
    Dim IEnquiriesSystemID As Long
    Public MarchandID As Long
    Dim dtArticle As New DataTable
    Dim Dr As DataRow
    Dim objGeneralInquiryMst As New GeneralInquiryMst
    Dim objGeneralInquiryDtl As New GeneralInquiryDtl
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objStyleMaster As New StyleMaster
    Dim dtStyleProductInformation As DataTable
    Dim dtDetail As DataTable
    Dim lGeneralInquiryMstID As Long
    Dim objFabricType As New FabricType
    Dim objLiningType As New LiningType

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lGeneralInquiryMstID = Request.QueryString("GeneralInquiryMstID")
        If Not Page.IsPostBack Then
            txtCreDate.SelectedDate = Date.Now
            Session("dtDetail") = Nothing
            Session("dtStyleProductInformation") = Nothing
            BindCustomer()
            BindSeason()
            If lGeneralInquiryMstID > 0 Then
                EditModes()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            'BindSupplier()
        End If
    End Sub
    Sub EditModes()
        Dim dt As DataTable = objGeneralInquiryMst.getEdit(lGeneralInquiryMstID)
        If dt.Rows.Count > 0 Then
            txtCreDate.SelectedDate = dt.Rows(0)("CreationDate")
            txtStyleNo.Text = dt.Rows(0)("StyleNo")
            txtStyleNo.ReadOnly = True
            txtStyleNo.Enabled = False
            txtInqRecvDate.SelectedDate = dt.Rows(0)("InqRecvDate")
            lblStyleId.Text = dt.Rows(0)("StyleId")
            GetStyleMode()
            ' cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            cmbEnqType.SelectedValue = dt.Rows(0)("InquiryType")
            cmbSeason.SelectedValue = dt.Rows(0)("SeasonID")
            cmbPO.SelectedValue = dt.Rows(0)("PONO")
            txtRemarks.Text = dt.Rows(0)("Remarks")
            ' cmbbrand.SelectedItem.Text = dt.Rows(0)("Brand")
            ' cmbBuyer.SelectedItem.Text = dt.Rows(0)("Buyer")
            'cmbBuyingDept.SelectedItem.Text = dt.Rows(0)("BuyingDept")
            txtInqConfDate.Text = dt.Rows(0)("InqConfDate")
            cmbEnquiryPurpose.SelectedItem.Text = dt.Rows(0)("InquiryPurpose")
            cmbConfrimStatus.SelectedValue = dt.Rows(0)("InquiryStatus")
            txtInqConfDate.Text = dt.Rows(0)("ConfromationDate")

            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("GeneralInquiryDtlID", GetType(Long))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("QTy", GetType(Decimal))
            End With
            Dim x As Integer

            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("GeneralInquiryDtlID") = dt.Rows(x)("GeneralInquiryDtlID")
                Dr("Item") = dt.Rows(x)("Item")
                Dr("Color") = dt.Rows(x)("Color")
                Dr("QTy") = dt.Rows(x)("QTy")

                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
        End If

    End Sub
    'Sub BindCustomer()
    '    Try
    '        Dim dtCustomer As DataTable
    '        dtCustomer = objGeneralInquiryMst.GetBindCombo
    '        cmbCustomer.DataSource = dtCustomer
    '        cmbCustomer.DataTextField = "CustomerName"
    '        cmbCustomer.DataValueField = "CustomerID"
    '        cmbCustomer.DataBind()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    ''Sub BindSupplier()
    ''    Try
    ''        Dim dtSupplier As DataTable = objGeneralInquiryMst.getDataforBindCombo
    ''        With cmbSupplier
    ''            .DataSource = dtSupplier
    ''            .DataTextField = "VenderName"
    ''            .DataValueField = "VenderLibraryID"
    ''            .DataBind()
    ''        End With
    ''    Catch ex As Exception
    ''    End Try
    ''End Sub
    Sub BindSeason1()
        Try
            Dim dt As DataTable
            dt = objGeneralInquiryMst.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindBrand()
        Try
            Dim dtBrand As DataTable = objGeneralInquiryMst.GetBrandInfoNo(cmbCustomer.SelectedValue)
            With cmbbrand
                .DataSource = dtBrand
                .DataTextField = "BrandName"
                .DataValueField = "BrandName"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objGeneralInquiryMst.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = objGeneralInquiryMst.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            'UpcmbBuyingDept.Update()
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
            cmbBuyer.DataSource = objGeneralInquiryMst.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            'UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbbrand.DataSource = objGeneralInquiryMst.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbbrand.DataTextField = "BrandName"
            cmbbrand.DataValueField = "BrandName"
            cmbbrand.DataBind()
            '  cmbbrand.Items.Insert(0, New ListItem("Select", "0"))
            ' UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objGeneralInquiryMst.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()

            cmbRepeatSeason.DataSource = dt
            cmbRepeatSeason.DataTextField = "season"
            cmbRepeatSeason.DataValueField = "SeasonID"
            cmbRepeatSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub cmbBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyer.SelectedIndexChanged

    'End Sub

    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objGeneralInquiryMst.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            ' UpcmbBuyingDept.Update()
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objGeneralInquiryMst.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            'UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbbrand.DataSource = objGeneralInquiryMst.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbbrand.DataTextField = "BrandName"
            cmbbrand.DataValueField = "BrandName"
            cmbbrand.DataBind()
            'cmbbrand.Items.Insert(0, New ListItem("All", "0"))
            'UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objGeneralInquiryMst.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
            'UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbbrand.DataSource = objGeneralInquiryMst.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbbrand.DataTextField = "BrandName"
            cmbbrand.DataValueField = "BrandName"
            cmbbrand.DataBind()
            'CmbBrand.Items.Insert(0, New ListItem("All", "0"))
            ' UpcmbBrand.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyer.SelectedIndexChanged
        Try
            ''---Bind Brand 
            cmbbrand.DataSource = objGeneralInquiryMst.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            cmbbrand.DataTextField = "BrandName"
            cmbbrand.DataValueField = "BrandName"
            cmbbrand.DataBind()
            ' CmbBrand.Items.Insert(0, New ListItem("All", "0"))
            'UpcmbBrand.Update()

        Catch ex As Exception

        End Try
    End Sub
    Sub FillGridByStyleDetail()
        Try
            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("GeneralInquiryDtlID", GetType(Long))
                    .Columns.Add("Item", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("QTy", GetType(Decimal))

                End With
            End If

            Dr = dtDetail.NewRow()
            Dr("GeneralInquiryDtlID") = 0
            If txtItem.Text = "" Then
                Dr("Item") = " "
            Else
                Dr("Item") = txtItem.Text
            End If
            If txtColor.Text = "" Then
                Dr("Color") = " "
            Else
                Dr("Color") = txtColor.Text
            End If
            If txtQty.Text = "" Then
                Dr("QTy") = " "
            Else
                Dr("QTy") = txtQty.Text
            End If



            dtDetail.Rows.Add(Dr)
            Session("dtDetail") = dtDetail
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtDetail Is Nothing) Then
            If (dtDetail.Rows.Count > 0) Then
                dgView.DataSource = dtDetail
                dgView.DataBind()
                dgView.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim GeneralInquiryDtlID As Integer = dtDetail.Rows(e.Item.ItemIndex)("GeneralInquiryDtlID")
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            objGeneralInquiryDtl.DeleteDetail(GeneralInquiryDtlID)
                            dtDetail = Session("dtDetail")
                            BindGrid()

                        Else
                            dgView.Visible = False
                        End If
                    End If
            End Select

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            FillGridByStyleDetail()
            txtItem.Text = ""
            txtColor.Text = ""
            txtQty.Text = ""

        Catch ex As Exception

        End Try
    End Sub
    Sub savemaster()
        With objGeneralInquiryMst
            If lGeneralInquiryMstID > 0 Then
                .GeneralInquiryMstID = lGeneralInquiryMstID
            Else
                .GeneralInquiryMstID = 0
            End If
            .StyleNo = txtStyleNo.Text
            .CreationDate = txtCreDate.SelectedDate
            .InqRecvDate = txtInqRecvDate.SelectedDate
            .InqConfDate = ""
            .InquiryType = cmbEnqType.SelectedItem.Text
            .SeasonID = cmbSeason.SelectedValue
            .PONO = cmbPO.SelectedItem.Text
            .StyleNo = txtStyleNo.Text
            .StyleId = Val(lblStyleId.Text)
            .Remarks = txtRemarks.Text
            .UserID = CLng(Session("UserID"))
            .InquiryPurpose = cmbEnquiryPurpose.SelectedItem.Text
            .InquiryStatus = cmbConfrimStatus.SelectedItem.Text
            .ConfromationDate = txtInqConfDate.Text
            .SaveEnquiriesSystem()
        End With
    End Sub
    Sub savedetail()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            With objGeneralInquiryDtl
                .GeneralInquiryDtlID = dgView.Items(x).Cells(0).Text
                If lGeneralInquiryMstID > 0 Then
                    .GeneralInquiryMstID = lGeneralInquiryMstID
                Else
                    .GeneralInquiryMstID = objGeneralInquiryMst.GetId()
                End If
                .Item = dgView.Items(x).Cells(1).Text
                .Color = dgView.Items(x).Cells(2).Text
                .Qty = dgView.Items(x).Cells(3).Text
                .SaveInquiriesDtl()
            End With
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtCreDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Creation empty.")
            ElseIf txtInqRecvDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Inq.Recv.Date empty.")
            ElseIf txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("StyleNo empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                savemaster()
                savedetail()
                Response.Redirect("InquiryStyleView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("InquiryStyleView.aspx")
    End Sub

    Protected Sub txtStyleNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStyleNo.TextChanged
        Try
            Dim dtStyleCheck As DataTable = objGeneralInquiryMst.GetStyleID(txtStyleNo.Text)
            If dtStyleCheck.Rows.Count > 0 Then
                lblStyleId.Text = dtStyleCheck.Rows(0)("StyleID")
                GetStyleMode()
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindFWtUnit()
        Dim dt As DataTable = objPurchaseMaster.GetUnits
        Dim x As Integer
        For x = 0 To dgProductinfo.Items.Count - 1
            Dim cmbFWtUnit As DropDownList = CType(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
            cmbFWtUnit.DataSource = dt
            cmbFWtUnit.DataTextField = "UnitName"
            cmbFWtUnit.DataValueField = "UnitID"
            cmbFWtUnit.DataBind()
        Next
    End Sub
    Private Sub BindGarmentWtUnit()
        Dim dt As DataTable = objPurchaseMaster.GetUnits
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
            dt = objPurchaseMaster.GetComposition
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

        Catch ex As Exception

        End Try
    End Sub
    Sub BindFabFinish()
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objPurchaseMaster.GetAllProductType
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
    Sub BindFabricType()
        Try
            Dim dt As DataTable
            dt = objFabricType.GetFabricType
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
    Sub BindLinigType()
        Try
            Dim dt As DataTable
            dt = objLiningType.GetLiningType
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
    Sub GetStyleMode()
        Try
            Session("dtStyleProductInformation") = Nothing
            Dim dtMaster As DataTable = objStyleMaster.GetMaster(lblStyleId.Text)
            If dtMaster.Rows.Count > 0 Then
                ' txtCoreLine.Text = dtMaster.Rows(0)("CoreLine")
                cmbSpecialLine.SelectedValue = dtMaster.Rows(0)("CoreLine")
                'UpCoreLine.Update()
                txtStyleDescription.Text = dtMaster.Rows(0)("StyleDescription")
                '  UptxtStyleDescription.Update()

                cmbCustomer.SelectedValue = dtMaster.Rows(0)("CustomerID")
                ' UpcmbCustomer.Update()
                'Load buing no first
                cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
                cmbBuyingDept.DataValueField = "departmentno"
                cmbBuyingDept.DataTextField = "departmentno"
                cmbBuyingDept.DataBind()


                '---Bind Byuer Name
                cmbBuyer.DataSource = objStyleMaster.GetBuyerInfoNo(cmbCustomer.SelectedValue)
                cmbBuyer.DataTextField = "BuyerName"
                cmbBuyer.DataValueField = "BuyerName"
                cmbBuyer.DataBind()
                '---Bind Brand 
                cmbbrand.DataSource = objStyleMaster.GetBrandInfoNo(cmbCustomer.SelectedValue)
                cmbbrand.DataTextField = "BrandName"
                cmbbrand.DataValueField = "BrandName"
                cmbbrand.DataBind()

                cmbBuyer.SelectedValue = dtMaster.Rows(0)("BuyerName")
                ' UpdatecmbBuyerName.Update()
                cmbBuyingDept.SelectedValue = dtMaster.Rows(0)("BuyingDept")
                ' UpcmbBuyingDept.Update()
                cmbSeason.SelectedValue = dtMaster.Rows(0)("SeasonID")
                ' UpcmbSeason.Update()
                cmbbrand.SelectedValue = dtMaster.Rows(0)("BrandName")
                'UpcmbBrand.Update()
                cmbStyleSource.SelectedItem.Text = dtMaster.Rows(0)("StyleSource")
                'upcmbStyleSource.Update()
            End If

            Dim dtPrduct As DataTable = objStyleMaster.GetProductNew(Val(lblStyleId.Text))
            BindProductPortfolio()
            If dtPrduct.Rows.Count > 0 Then
                dgProductinfo.Visible = True
                dgProductinfo.DataSource = dtPrduct
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
                ' UpcmbProductPortfolio.Update()
                Dim dtProductCategories As DataTable
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
                cmbProductCategory.DataSource = dtProductCategories
                cmbProductCategory.DataTextField = "ProductCategories"
                cmbProductCategory.DataValueField = "ProductCategoriesID"
                cmbProductCategory.DataBind()
                cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
                '  UpcmbProductCategory.Update()
                BindFabricType()
                BindFWtUnit()
                BindGarmentWtUnit()
                BindComposition()
                BindFabFinish()
                BindLinigType()


                dtStyleProductInformation = New DataTable
                With dtStyleProductInformation
                    .Columns.Add("SproductID", GetType(String))
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
                    Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbFabricType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabricType"), DropDownList)
                    Dim cmbFabFinish As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)
                    Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)

                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)

                    Dr = dtStyleProductInformation.NewRow()
                    Dr("SproductID") = dtPrduct.Rows(x)("SproductID")
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
                    dtStyleProductInformation.Rows.Add(Dr)


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
                    Dim Lining As String = dgProductinfo.Items(x).Cells(22).Text
                    If Lining = "Y" Then
                        cmbLiningType.Visible = True
                        txtLiningCons.Visible = True
                        cmbLinigComp.Visible = True
                        txtLiningWt.Visible = True
                        'UpUpbtnAutoComplete.Update()
                    Else
                        cmbLiningType.Visible = False
                        txtLiningCons.Visible = False
                        cmbLinigComp.Visible = False
                        txtLiningWt.Visible = False
                        ' UpUpbtnAutoComplete.Update()
                    End If

                Next

                '---new use nizam for Binding DD

                BindProductConsumer()

                cmbProductConsumerGrp.SelectedValue = dtPrduct.Rows(0)("ProductConsumerID")
                ' UpcmbProductConsumerGrp.Update()
                cmbPack.SelectedItem.Text = dtPrduct.Rows(0)("Pack")
                'UpcmbPack.Update()
                '-----end
                Session("dtStyleProductInformation") = dtStyleProductInformation
                If cmbProductPortfolio.SelectedValue = 1 Then
                    lblpack.Visible = False
                    cmbPack.Visible = False
                    'UpcmbPack.Update()
                    ' Uplblpack.Update()
                    btnAddMoreProduct.Visible = False
                Else
                    lblpack.Visible = True
                    cmbPack.Visible = True
                    btnAddMoreProduct.Visible = False
                    ' UpcmbPack.Update()
                    'Uplblpack.Update()

                End If
                ' UpUpbtnAutoComplete.Update()

            Else
                dgProductinfo.Visible = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductCategories()
        Try
            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategory.DataSource = dtProductCategories
            cmbProductCategory.DataTextField = "ProductCategories"
            cmbProductCategory.DataValueField = "ProductCategoriesID"
            cmbProductCategory.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductPortfolio()
        Try

            Dim dtProductPortfolio As DataTable
            dtProductPortfolio = objPurchaseMaster.GetAllProductPortfolio
            cmbProductPortfolio.DataSource = dtProductPortfolio
            cmbProductPortfolio.DataTextField = "ProductPortfolio"
            cmbProductPortfolio.DataValueField = "ProductPortfolioID"
            cmbProductPortfolio.DataBind()

            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategory.DataSource = dtProductCategories
            cmbProductCategory.DataTextField = "ProductCategories"
            cmbProductCategory.DataValueField = "ProductCategoriesID"
            cmbProductCategory.DataBind()
            If cmbProductPortfolio.SelectedValue = 1 Then
                lblpack.Visible = False
                cmbPack.Visible = False
                UpcmbPack.Update()
                'Uplblpack.Update()
            Else
                lblpack.Visible = True
                cmbPack.Visible = True
                UpcmbPack.Update()
                ' Uplblpack.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductConsumer()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetProductConsumer
            cmbProductConsumerGrp.DataSource = dt
            cmbProductConsumerGrp.DataTextField = "ProductConsumerName"
            cmbProductConsumerGrp.DataValueField = "ProductConsumerID"
            cmbProductConsumerGrp.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
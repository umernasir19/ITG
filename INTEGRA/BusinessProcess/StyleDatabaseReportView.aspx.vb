Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class StyleDatabaseReportView
    Inherits System.Web.UI.Page

    Dim objStyleMaster As New StyleMaster
    Dim objStyleDetail As New StyleDetail
    Dim objStyleAccessories As New StyleAccessories
    Dim objStyleUploads As New StyleUploads
    Dim objStyleUploadsTemp As New StyleUploadsTemp
    Dim objCustomer As New CustomerDatabase
    Dim StyleID As Long
    Dim LastStyleID As Long
    Dim dtStyle As New DataTable
    Dim dtArticleDetail As DataTable
    Dim Dr As DataRow
    Dim DrAcces As DataRow
    Dim objPurchaseMaster As New PurchaseOrder
    Dim dtStyleProductInformation As DataTable
    Dim dtAccessories As New DataTable
    Dim objStyleProductInformation As New StyleProductInformation
    Dim dtFile As New DataTable
    Dim objFabricType As New FabricType
    Dim objbuyer As New Buyer
    Dim dtt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("lStyleID")
        If Not Page.IsPostBack Then
            Enabled()
            ''---TDelete Detailtable if Master Id=0
            objStyleUploads.DeleteStyleUploadDetailTable()

            txtCreatedBy.Text = Session("UserName")
            txtCreatedOn.Text = Date.Now.ToString("dd/MM/yyyy")

            objStyleUploadsTemp.Deletetble()

            Session("dtStyle") = Nothing
            Session("dtAccessories") = Nothing
            Session("dtStyleProductInformation") = Nothing
            Session("dtFile") = Nothing



            BindCustomer()
            BindSeason()
            BindEmbell()
            BindProductPortfolio()
            BindProductConsumer()
            'BindSizeRange()
            BindAccessories()
            BindTypeOfDyes()
            BindTypeOfPrint()
            BindTypeOfWashing()
            BindCartonSizeUnitID()
            BindPolyBagSizeUnitID()
            BindPackedPcUnitID()
            BindPolyBagStickerSizeUnitID()
            BindQtyPackUnit()

            BindQtyCartonUnit()
            BindGrossWeightCartonUnit()

            If StyleID > 0 Then
                EditMode()
                btnAddProduct.Visible = False
                btnAutoComplete.Visible = False
            Else
                btnAddProduct.Visible = True
                btnAutoComplete.Visible = False
            End If
        End If
    End Sub
    Sub Enabled()
        dgProductinfo.Enabled = False
        txtStyleNo.ReadOnly = True
        txtCoreLine.ReadOnly = True
        cmbCustomer.Enabled = False
        txtStyleDescription.ReadOnly = True
        cmbSeason.Enabled = False
        cmbStyleSource.Enabled = False
        cmbBuyingDept.Enabled = False
        cmbBuyerName.Enabled = False
        cmbBrand.Enabled = False
        cmbProductPortfolio.Enabled = False
        'cmbProductCategory.Enabled = False
        'cmbProductConsumerGrp.Enabled = False
        cmbPack.Enabled = False
        dgColor.Enabled = False
        dgAcces.Enabled = False
        cmbEmbell.Enabled = False
        cmbTypeOfDyes.Enabled = False
        cmbTypeOfPrint.Enabled = False
        cmbTypeOfWashing.Enabled = False
        cmbCartonSizeUnitID.Enabled = False
        cmbQtyCartonUnit.Enabled = False
        cmbQtyPackUnit.Enabled = False
        cmbPolyBagSizeUnitID.Enabled = False
        cmbPackedPcUnitID.Enabled = False
        cmbGrossWeightCartonUnit.Enabled = False
        cmbPolyBagStickerSizeUnitID.Enabled = False
        dgFileInfo.Enabled = False

    End Sub

    Private Sub BindCustomer()
        cmbCustomer.DataSource = objStyleMaster.GetFilterComboValues
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        '---Bind Buyeing Dept
        cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
        cmbBuyingDept.DataValueField = "departmentno"
        cmbBuyingDept.DataTextField = "departmentno"
        cmbBuyingDept.DataBind()

        '---Bind Byuer Name
        cmbBuyerName.DataSource = objStyleMaster.GetBuyerInfoNo(cmbCustomer.SelectedValue)
        cmbBuyerName.DataTextField = "BuyerName"
        cmbBuyerName.DataValueField = "BuyerName"
        cmbBuyerName.DataBind()
        UpdatecmbBuyerName.Update()
        '---Bind Brand 
        cmbBrand.DataSource = objStyleMaster.GetBrandInfoNo(cmbCustomer.SelectedValue)
        cmbBrand.DataTextField = "BrandName"
        cmbBrand.DataValueField = "BrandName"
        cmbBrand.DataBind()
        UpcmbBrand.Update()

    End Sub

    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindEmbell()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetEmbell
            cmbEmbell.DataSource = dt
            cmbEmbell.DataTextField = "EmbellName"
            cmbEmbell.DataValueField = "EmbellID"
            cmbEmbell.DataBind()
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
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
                cmbProductCategory.DataSource = dtProductCategories
                cmbProductCategory.DataTextField = "ProductCategories"
                cmbProductCategory.DataValueField = "ProductCategoriesID"
                cmbProductCategory.DataBind()

                UpcmbProductCategory.Update()
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
    'Sub BindSizeRange()
    '    Try
    '        Dim dt As DataTable
    '        dt = objPurchaseMaster.GetSizeRange
    '        cmbSizeRange.DataSource = dt
    '        cmbSizeRange.DataValueField = "sizerange"
    '        cmbSizeRange.DataBind()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub BindAccessories()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetStyleAccessoriesList
          
        Catch ex As Exception

        End Try
    End Sub
    Sub BindTypeOfDyes()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetTypeOfDyes
            cmbTypeOfDyes.DataSource = dt
            cmbTypeOfDyes.DataTextField = "TypeOfDyesName"
            cmbTypeOfDyes.DataValueField = "TypeOfDyesID"
            cmbTypeOfDyes.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindTypeOfPrint()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetTypeOfPrint
            cmbTypeOfPrint.DataSource = dt
            cmbTypeOfPrint.DataTextField = "TypeOfPrintName"
            cmbTypeOfPrint.DataValueField = "TypeOfPrintID"
            cmbTypeOfPrint.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindTypeOfWashing()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetTypeOfWashing
            cmbTypeOfWashing.DataSource = dt
            cmbTypeOfWashing.DataTextField = "TypeOfWashingName"
            cmbTypeOfWashing.DataValueField = "TypeOfWashingID"
            cmbTypeOfWashing.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCartonSizeUnitID()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbCartonSizeUnitID.DataSource = dt
            cmbCartonSizeUnitID.DataTextField = "UnitName"
            cmbCartonSizeUnitID.DataValueField = "UnitID"
            cmbCartonSizeUnitID.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindPolyBagSizeUnitID()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbPolyBagSizeUnitID.DataSource = dt
            cmbPolyBagSizeUnitID.DataTextField = "UnitName"
            cmbPolyBagSizeUnitID.DataValueField = "UnitID"
            cmbPolyBagSizeUnitID.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindPackedPcUnitID()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbPackedPcUnitID.DataSource = dt
            cmbPackedPcUnitID.DataTextField = "UnitName"
            cmbPackedPcUnitID.DataValueField = "UnitID"
            cmbPackedPcUnitID.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindPolyBagStickerSizeUnitID()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbPolyBagStickerSizeUnitID.DataSource = dt
            cmbPolyBagStickerSizeUnitID.DataTextField = "UnitName"
            cmbPolyBagStickerSizeUnitID.DataValueField = "UnitID"
            cmbPolyBagStickerSizeUnitID.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindQtyPackUnit()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbQtyPackUnit.DataSource = dt
            cmbQtyPackUnit.DataTextField = "UnitName"
            cmbQtyPackUnit.DataValueField = "UnitID"
            cmbQtyPackUnit.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindQtyCartonUnit()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbQtyCartonUnit.DataSource = dt
            cmbQtyCartonUnit.DataTextField = "UnitName"
            cmbQtyCartonUnit.DataValueField = "UnitID"
            cmbQtyCartonUnit.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindGrossWeightCartonUnit()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetUnits
            cmbGrossWeightCartonUnit.DataSource = dt
            cmbGrossWeightCartonUnit.DataTextField = "UnitName"
            cmbGrossWeightCartonUnit.DataValueField = "UnitID"
            cmbGrossWeightCartonUnit.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtStyleNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStyleNo.TextChanged
        Try
            txtCoreLine.Text = txtStyleNo.Text
            UpCoreLine.Update()
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
            BindFabFinish()

            btnAddProduct.Visible = False
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
                .Columns.Add("SproductID", GetType(Long))
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
                .Columns.Add("FabicWt", GetType(Decimal))
                .Columns.Add("FabicWtUnitID", GetType(Long))
                .Columns.Add("GarmentWt", GetType(Decimal))
                .Columns.Add("GarmentWtUnitID", GetType(Long))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Rremarks", GetType(String))
                .Columns.Add("FabFinishID", GetType(String))
                .Columns.Add("FabFinish", GetType(String))
            End With
        End If

        Dim x = 0
        'If cmbPack.SelectedValue = 0 Then
        '    x = 1
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 1 Then
        '    x = 2
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 2 Then
        '    x = 3
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 3 Then
        '    x = 4
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 4 Then
        '    x = 5
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 5 Then
        '    x = 6
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 6 Then
        '    x = 7
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 7 Then
        '    x = 8
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 8 Then
        '    x = 9
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 9 Then
        '    x = 10
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 10 Then
        '    x = 11
        '    BindcmbBaseItem(x)
        'ElseIf cmbPack.SelectedValue = 11 Then
        '    x = 12
        '    BindcmbBaseItem(x)
        'End If

        For x = 1 To x
            Dr = dtStyleProductInformation.NewRow()
            Dr("SproductID") = 0
            Dr("RowNo") = "Row" + " " + x.ToString()
            Dr("ProductPortfolioID") = cmbProductPortfolio.SelectedValue
            Dr("ProductCategoriesID") = cmbProductCategory.SelectedValue
            Dr("ProductConsumerID") = cmbProductConsumerGrp.SelectedValue
            Dr("Pack") = cmbPack.SelectedItem.Text
            Dr("Item") = "Item" + " " + x.ToString()
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
            dtStyleProductInformation.Rows.Add(Dr)

        Next

        Session("dtStyleProductInformation") = dtStyleProductInformation
    End Sub
    Private Function BindGridProduct() As Boolean
        If (Not dtStyleProductInformation Is Nothing) Then
            If (dtStyleProductInformation.Rows.Count > 0) Then

                dgProductinfo.DataSource = dtStyleProductInformation
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                Return (True)
            Else
                dgProductinfo.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
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
                cmbFComp.DataSource = dt
                cmbFComp.DataTextField = "CompositionName"
                cmbFComp.DataValueField = "CompositionID"
                cmbFComp.DataBind()
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
    
    
    
    Private Function BindGridColor() As Boolean
        If (Not dtStyle Is Nothing) Then
            If (dtStyle.Rows.Count > 0) Then

                dgColor.DataSource = dtStyle
                dgColor.DataBind()
                dgColor.Visible = True
                Return (True)
            Else
                dgColor.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
    
    
    Private Function BindGridAcces() As Boolean
        If (Not dtAccessories Is Nothing) Then
            If (dtAccessories.Rows.Count > 0) Then

                dgAcces.DataSource = dtAccessories
                dgAcces.DataBind()
                dgAcces.Visible = True
                Return (True)
            Else
                dgAcces.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
    Protected Sub btnUpload1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload1.Click
        Try
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If FileUpload1.FileName = "" Then
                lblErrorMsg.Text = "No File"
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
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveUploaddata()
        Try
            Dim astyleid As Long = 0
            With objStyleUploads
                .TableID = 0
                .CreationDate = Date.Now
                If StyleID > 0 Then
                    .StyleID = StyleID
                    astyleid = StyleID
                Else
                    .StyleID = 0 'objStyleMaster.GetID()
                    astyleid = 0 'objStyleMaster.GetID()
                End If
                .FileName = FileUpload1.FileName
                .FileType = cmbFileType.SelectedItem.Text
                .UploadPicture = SaveUploadPicture()
                .SaveStyleUploads()
            End With

            'Show in grid
            Dim objDataView1 As DataView
            objDataView1 = LoadData1(astyleid)
            Session("objDataView1") = objDataView1
            BindGridFileInfo()


            dtt = objDataView1.ToTable
            Dim x As Integer = 0
            For x = 0 To dgFileInfo.Items.Count - 1
                Dim Image1 As Image = DirectCast(dgFileInfo.Items(x).FindControl("Image1"), Image)
                Dim Picstype As String = dgFileInfo.Items(x).Cells(3).Text
                Dim bytes As Byte() = DirectCast(dtt.Rows(x)("UploadPicture"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                If Picstype = "Picture" Then
                    imgExtra.ImageUrl = "data:image/png;base64," & base64String
                    imgExtra.Visible = True
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
        objDataView = Session("objDataView1")
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
    Function LoadData1(ByVal StyleID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleUploadsTemp.GetFileInfoNew(StyleID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No empty.")
            ElseIf dgProductinfo.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Product Info. required.")
            ElseIf dgColor.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Color Info. required.")
            ElseIf dgFileInfo.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Attachment required.")
            Else
                With objStyleMaster
                    If StyleID > 0 Then
                        .StyleID = StyleID
                    Else
                        .StyleID = 0
                    End If
                    .CreationDate = Date.Now()
                    .StyleNo = txtStyleNo.Text
                    .CoreLine = txtCoreLine.Text
                    .BuyerName = cmbBuyerName.SelectedItem.Text
                    .StyleDescription = txtStyleDescription.Text
                    .UserID = CLng(Session("UserID"))
                    .CustomerID = cmbCustomer.SelectedValue
                    .BuyingDept = cmbBuyingDept.SelectedValue
                    .SeasonID = cmbSeason.SelectedValue
                    .StyleSource = cmbStyleSource.SelectedItem.Text
                    .EmbellID = cmbEmbell.SelectedValue
                    .DimensionalStablityL = txtAcceptableDimensionalL.Text
                    .DimensionalStablityW = txtAcceptableDimensionalW.Text
                    .RubbingFastnessWet = Val(txtRubbingFastnessWet.Text)
                    .RubbingFastnessDry = Val(txtRubbingFastnessDry.Text)
                    .TypeOfDyesID = cmbTypeOfDyes.SelectedValue
                    .TypeOfPrintID = cmbTypeOfPrint.SelectedValue
                    .TypeOfWashingID = cmbTypeOfWashing.SelectedValue
                    .CartonType = txtCartonType.Text
                    .CartonSizeL = Val(txtCartonSizeL.Text)
                    .CartonSizeW = Val(txtCartonSizeW.Text)
                    .CartonSizeH = Val(txtCartonSizeH.Text)
                    .CartonSizeUnitID = cmbCartonSizeUnitID.SelectedValue
                    .QtyCarton = Val(txtQtyCarton.Text)
                    .QtyCartonUnitID = cmbQtyCartonUnit.SelectedValue
                    .QtyPack = Val(txtQtyPack.Text)
                    .QtyPackUnitID = cmbQtyPackUnit.SelectedValue
                    .PolyBagSizeL = Val(txtPolyBagSizeL.Text)
                    .PolyBagSizeW = Val(txtPolyBagSizeW.Text)
                    .PolyBagSizeFlap = Val(txtPolyBagSizeFlap.Text)
                    .PolyBagSizeUnitID = cmbPolyBagSizeUnitID.SelectedValue
                    .InlayCardSize = txtInlayCardSize.Text
                    .PackedPcL = Val(txtPackedPcSzL.Text)
                    .PackedPcW = Val(txtPackedPcSzW.Text)
                    .PackedPcUnitID = cmbPackedPcUnitID.SelectedValue
                    .GrossWeightCarton = Val(txtGrossWeightofCarton.Text)
                    .GrossWeightCartonUnitID = cmbGrossWeightCartonUnit.SelectedValue
                    .PolyBagStickerSizeL = Val(txtPolyBagStickerSizeL.Text)
                    .PolyBagStickerSizeW = Val(txtPolyBagStickerSizeW.Text)
                    .PolyBagStickerSizeH = Val(txtPolyBagStickerSizeH.Text)
                    .PolyBagStickerSizeUnitID = cmbPolyBagStickerSizeUnitID.SelectedValue
                    .BrandName = cmbBrand.SelectedValue
                    .InsetComplaintType = txtInsetComplainttype.Text
                    .SaveStyleMaster()
                End With

                'For Product Info
                Dim x As Integer
                For x = 0 To dgColor.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgColor.MasterTableView.Items(x), GridDataItem)

                    With objStyleDetail
                        .StyleDetailID = item("StyleDetailID").Text
                        If StyleID > 0 Then
                            .StyleID = StyleID
                        Else
                            .StyleID = objStyleMaster.GetID()
                        End If
                        .ColorRefNo = item("ColorRefNo").Text
                        .Colorway = item("Colorway").Text
                        .SizeRange = item("SizeRange").Text
                        .Sizes = item("Sizes").Text
                        .Price = item("Price").Text
                        .PriceUnit = item("PriceUnit").Text
                        .BaseRow = item("BaseRow").Text
                        .SaveStyleDetail()
                    End With
                Next

                'For Colro info
                x = 0
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
                    Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbFabFinish As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)

                    With objStyleProductInformation
                        .SproductID = dgProductinfo.Items(x).Cells(0).Text
                        If StyleID > 0 Then
                            .StyleID = StyleID
                        Else
                            .StyleID = objStyleMaster.GetID()
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
                        .SaveStyleProductInformation()
                    End With
                Next

                'For Assc.
                For x = 0 To dgAcces.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgAcces.MasterTableView.Items(x), GridDataItem)
                    With objStyleAccessories
                        .SAID = item("SAID").Text
                        If StyleID > 0 Then
                            .StyleID = StyleID
                        Else
                            .StyleID = objStyleMaster.GetID()
                        End If

                        .AccessoriesID = item("AccessoriesID").Text
                        .AccessoriesDescription = item("AccessoriesDescription").Text
                        .Source = item("Source").Text
                        .SaveStyleAccessories()
                    End With
                Next

                'For File Upload
                'Dim dtFile As DataTable = objStyleUploadsTemp.All()
                'If dtFile.Rows.Count > 0 Then
                '    Dim z As Integer
                '    For z = 0 To dtFile.Rows.Count - 1
                '        With objStyleUploads
                '            .TableID = 0
                '            .CreationDate = Date.Now
                '            If StyleID > 0 Then
                '                .StyleID = StyleID
                '            Else
                '                .StyleID = objStyleMaster.GetID()
                '            End If
                '            .FileName = dtFile.Rows(z)("FileName")
                '            .FileType = dtFile.Rows(z)("FileType")
                '            .UploadPicture = dtFile.Rows(z)("UploadPicture")
                '            .SaveStyleUploads()
                '        End With
                '    Next
                'End If

                '----Changes nizam
                Dim a As Long
                If StyleID > 0 Then
                    a = StyleID
                Else
                    a = objStyleMaster.GetID
                End If
                objStyleUploads.UpdateStyleUploadTable(a)

                Session("dtStyle") = Nothing
                Session("dtAccessories") = Nothing
                Session("dtStyleProductInformation") = Nothing
                Session("dtFile") = Nothing
                objStyleUploadsTemp.Deletetble()
                Response.Redirect("StyleView.aspx")
            End If

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
    
    Sub EditMode()
        Try
            Dim dtMaster As DataTable = objStyleMaster.GetMaster(StyleID)
            If dtMaster.Rows.Count > 0 Then
                txtStyleNo.Text = dtMaster.Rows(0)("StyleNo")
                txtCoreLine.Text = dtMaster.Rows(0)("CoreLine")
                txtStyleDescription.Text = dtMaster.Rows(0)("StyleDescription")
                cmbCustomer.SelectedValue = dtMaster.Rows(0)("CustomerID")
                'Load buing no first
                cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
                cmbBuyingDept.DataValueField = "departmentno"
                cmbBuyingDept.DataTextField = "departmentno"
                cmbBuyingDept.DataBind()

                '---Bind Byuer Name
                cmbBuyerName.DataSource = objStyleMaster.GetBuyerInfoNo(cmbCustomer.SelectedValue)
                cmbBuyerName.DataTextField = "BuyerName"
                cmbBuyerName.DataValueField = "BuyerName"
                cmbBuyerName.DataBind()
                '---Bind Brand 
                cmbBrand.DataSource = objStyleMaster.GetBrandInfoNo(cmbCustomer.SelectedValue)
                cmbBrand.DataTextField = "BrandName"
                cmbBrand.DataValueField = "BrandName"
                cmbBrand.DataBind()

                cmbBuyerName.SelectedValue = dtMaster.Rows(0)("BuyerName")
                cmbBuyingDept.SelectedValue = dtMaster.Rows(0)("BuyingDept")
                cmbSeason.SelectedValue = dtMaster.Rows(0)("SeasonID")
                cmbBrand.SelectedValue = dtMaster.Rows(0)("BrandName")

                cmbStyleSource.SelectedItem.Text = dtMaster.Rows(0)("StyleSource")
                cmbEmbell.SelectedValue = dtMaster.Rows(0)("EmbellID")
                txtAcceptableDimensionalL.Text = dtMaster.Rows(0)("DimensionalStablityL")
                txtAcceptableDimensionalW.Text = dtMaster.Rows(0)("DimensionalStablityW")
                txtRubbingFastnessWet.Text = dtMaster.Rows(0)("RubbingFastnessWet")
                txtRubbingFastnessDry.Text = dtMaster.Rows(0)("RubbingFastnessDry")
                cmbTypeOfDyes.SelectedValue = dtMaster.Rows(0)("TypeOfDyesID")
                cmbTypeOfPrint.SelectedValue = dtMaster.Rows(0)("TypeOfPrintID")
                cmbTypeOfWashing.SelectedValue = dtMaster.Rows(0)("TypeOfWashingID")
                txtCartonType.Text = dtMaster.Rows(0)("CartonType")
                txtCartonSizeL.Text = dtMaster.Rows(0)("CartonSizeL")
                txtCartonSizeW.Text = dtMaster.Rows(0)("CartonSizeW")
                txtCartonSizeH.Text = dtMaster.Rows(0)("CartonSizeH")
                cmbCartonSizeUnitID.SelectedValue = dtMaster.Rows(0)("CartonSizeUnitID")
                txtQtyCarton.Text = dtMaster.Rows(0)("QtyCarton")
                txtQtyPack.Text = dtMaster.Rows(0)("QtyPack")
                cmbQtyPackUnit.SelectedValue = dtMaster.Rows(0)("QtyPackUnitID")
                txtPolyBagSizeL.Text = dtMaster.Rows(0)("PolyBagSizeL")
                txtPolyBagSizeW.Text = dtMaster.Rows(0)("PolyBagSizeW")
                txtPolyBagSizeFlap.Text = dtMaster.Rows(0)("PolyBagSizeFlap")
                cmbPolyBagSizeUnitID.SelectedValue = dtMaster.Rows(0)("PolyBagSizeUnitID")
                txtInlayCardSize.Text = dtMaster.Rows(0)("InlayCardSize")
                txtPackedPcSzL.Text = dtMaster.Rows(0)("PackedPcL")
                txtPackedPcSzW.Text = dtMaster.Rows(0)("PackedPcW")
                cmbPackedPcUnitID.SelectedValue = dtMaster.Rows(0)("PackedPcUnitID")
                txtGrossWeightofCarton.Text = dtMaster.Rows(0)("GrossWeightCarton")
                txtPolyBagStickerSizeL.Text = dtMaster.Rows(0)("PolyBagStickerSizeL")
                txtPolyBagStickerSizeW.Text = dtMaster.Rows(0)("PolyBagStickerSizeW")
                txtPolyBagStickerSizeH.Text = dtMaster.Rows(0)("PolyBagStickerSizeH")
                cmbPolyBagStickerSizeUnitID.SelectedValue = dtMaster.Rows(0)("PolyBagStickerSizeUnitID")

                cmbQtyCartonUnit.SelectedValue = dtMaster.Rows(0)("QtyCartonUnitID")
                cmbGrossWeightCartonUnit.SelectedValue = dtMaster.Rows(0)("GrossWeightCartonUnitID")
                txtInsetComplainttype.Text = dtMaster.Rows(0)("InsetComplaintType")
            End If

            Dim dtPrduct As DataTable = objStyleMaster.GetProductNew(StyleID)

            If dtPrduct.Rows.Count > 0 Then
                dgProductinfo.DataSource = dtPrduct
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
                If cmbProductPortfolio.SelectedValue = 1 Then
                    RwPack.Visible = False
                Else
                    RwPack.Visible = True
                End If

                Dim dtProductCategories As DataTable
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
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


                dtStyleProductInformation = New DataTable
                With dtStyleProductInformation
                    .Columns.Add("SproductID", GetType(Long))
                    .Columns.Add("RowNo", GetType(String))
                    .Columns.Add("ProductPortfolioID", GetType(Long))
                    .Columns.Add("ProductCategoriesID", GetType(Long))
                    .Columns.Add("ProductConsumerID", GetType(Long))
                    .Columns.Add("Pack", GetType(String))
                    .Columns.Add("Item", GetType(String))
                    .Columns.Add("HSCode", GetType(String))
                    .Columns.Add("FabricType", GetType(String))
                    .Columns.Add("FabicCons", GetType(String))
                    .Columns.Add("CompositionID", GetType(Long))
                    .Columns.Add("FabicWt", GetType(Decimal))
                    .Columns.Add("FabicWtUnitID", GetType(Long))
                    .Columns.Add("GarmentWt", GetType(Decimal))
                    .Columns.Add("GarmentWtUnitID", GetType(Long))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("Rremarks", GetType(String))
                    .Columns.Add("FabricTypeID", GetType(Long))
                    .Columns.Add("FabFinishID", GetType(String))
                    .Columns.Add("FabFinish", GetType(String))
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

                    Dr = dtStyleProductInformation.NewRow()
                    Dr("SproductID") = dtPrduct.Rows(x)("SproductID")
                    Dr("RowNo") = dtPrduct.Rows(x)("RowNo")
                    Dr("ProductPortfolioID") = dtPrduct.Rows(x)("ProductPortfolioID")
                    Dr("ProductCategoriesID") = dtPrduct.Rows(x)("ProductCategoriesID")
                    Dr("ProductConsumerID") = dtPrduct.Rows(x)("ProductConsumerID")
                    Dr("Pack") = dtPrduct.Rows(x)("Pack")
                    Dr("Item") = dtPrduct.Rows(x)("Item")
                    Dr("HSCode") = dtPrduct.Rows(x)("HSCode")
                    Dr("FabricType") = dtPrduct.Rows(x)("FabricType")
                    Dr("FabicCons") = dtPrduct.Rows(x)("FabicCons")
                    Dr("CompositionID") = dtPrduct.Rows(x)("CompositionID")
                    Dr("FabicWt") = dtPrduct.Rows(x)("FabicWt")
                    Dr("FabicWtUnitID") = dtPrduct.Rows(x)("FabicWtUnitID")
                    Dr("GarmentWt") = dtPrduct.Rows(x)("GarmentWt")
                    Dr("GarmentWtUnitID") = dtPrduct.Rows(x)("GarmentWtUnitID")
                    Dr("Color") = dtPrduct.Rows(x)("Color")
                    Dr("Rremarks") = dtPrduct.Rows(x)("Rremarks")
                    Dr("FabricTypeID") = dtPrduct.Rows(x)("FabricTypeID")
                    Dr("FabFinishID") = dtPrduct.Rows(x)("FabFinishID")
                    Dr("FabFinish") = dtPrduct.Rows(x)("FabFinish")
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

                Next
                '---new use nizam for Binding DD
                BindProductPortfolio()
                BindProductCategories()
                BindProductConsumer()
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
                cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
                cmbProductConsumerGrp.SelectedValue = dtPrduct.Rows(0)("ProductConsumerID")
                cmbPack.SelectedItem.Text = dtPrduct.Rows(0)("Pack")
                '-----end
                Dim dtBaseItem As New DataTable
                With dtBaseItem
                    .Columns.Add("BaseItem", GetType(String))
                End With

                For xx = 0 To dtPrduct.Rows.Count - 1
                    With dtBaseItem
                        Dr = dtBaseItem.NewRow()
                        Dr("BaseItem") = dtPrduct.Rows(xx)("RowNo")
                        dtBaseItem.Rows.Add(Dr)
                    End With
                Next

                'cmbBaseItem.DataSource = dtBaseItem
                'cmbBaseItem.DataTextField = "BaseItem"
                'cmbBaseItem.DataValueField = "BaseItem"
                'cmbBaseItem.DataBind()
                'Dim count As Integer = 0
                'count = dtBaseItem.Rows.Count
                'cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
                'UpcmbBaseItem.Update()

                Session("dtStyleProductInformation") = dtStyleProductInformation

                Dim dtColor As DataTable = objStyleMaster.GetColor(StyleID)
                If dtColor.Rows.Count > 0 Then

                    dtStyle = New DataTable
                    With dtStyle
                        .Columns.Add("StyleID", GetType(Long))
                        .Columns.Add("StyleDetailID", GetType(Long))
                        .Columns.Add("ColorRefNo", GetType(String))
                        .Columns.Add("Colorway", GetType(String))
                        .Columns.Add("SizeRange", GetType(String))
                        .Columns.Add("Sizes", GetType(String))
                        .Columns.Add("Price", GetType(String))
                        .Columns.Add("PriceUnit", GetType(String))
                        .Columns.Add("BaseRow", GetType(String))
                    End With

                    For x = 0 To dtColor.Rows.Count - 1
                        Dr = dtStyle.NewRow()
                        Dr("StyleID") = dtColor.Rows(x)("StyleID")
                        Dr("StyleDetailID") = dtColor.Rows(x)("StyleDetailID")
                        Dr("ColorRefNo") = dtColor.Rows(x)("ColorRefNo")
                        Dr("Colorway") = dtColor.Rows(x)("Colorway")
                        Dr("SizeRange") = dtColor.Rows(x)("SizeRange")
                        Dr("Sizes") = dtColor.Rows(x)("Sizes")
                        Dr("Price") = dtColor.Rows(x)("Price")
                        Dr("PriceUnit") = dtColor.Rows(x)("PriceUnit")
                        Dr("BaseRow") = dtColor.Rows(x)("BaseRow")
                        dtStyle.Rows.Add(Dr)
                    Next
                    Session("dtStyle") = dtStyle
                    BindGridColor()

                End If

                btnHide.Visible = True

                Dim dtAssc As DataTable = objStyleMaster.GetAccess(StyleID)
                If dtAssc.Rows.Count > 0 Then

                    dtAccessories = New DataTable
                    With dtAccessories
                        .Columns.Add("SAID", GetType(Long))
                        .Columns.Add("StyleID", GetType(Long))
                        .Columns.Add("AccessoriesID", GetType(Long))
                        .Columns.Add("AccessoriesName", GetType(String))
                        .Columns.Add("AccessoriesDescription", GetType(String))
                        .Columns.Add("Source", GetType(String))
                    End With

                    For x = 0 To dtAssc.Rows.Count - 1
                        Dr = dtAccessories.NewRow()
                        Dr("StyleID") = dtAssc.Rows(x)("StyleID")
                        Dr("SAID") = dtAssc.Rows(x)("SAID")
                        Dr("AccessoriesID") = dtAssc.Rows(x)("AccessoriesID")
                        Dr("AccessoriesName") = dtAssc.Rows(x)("AccessoriesName")
                        Dr("AccessoriesDescription") = dtAssc.Rows(x)("AccessoriesDescription")
                        Dr("Source") = dtAssc.Rows(x)("Source")
                        dtAccessories.Rows.Add(Dr)
                    Next
                    Session("dtAccessories") = dtAccessories
                    BindGridAcces()
                End If
            End If

            'Show file in grid

            Dim dtRealFile As DataTable = objStyleUploads.GetFileInfo(StyleID)
           
         


            Session("dtFile") = dtRealFile
            Dim objDataView As DataView
            objDataView = New DataView(dtRealFile)
            If objDataView.Count > 0 Then
                dgFileInfo.Visible = True
                dgFileInfo.RecordCount = objDataView.Count
                dgFileInfo.DataSource = objDataView
                dgFileInfo.DataBind()
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
                dgFileInfo.Visible = False
            End If


            dtt = objDataView.ToTable
            Dim y As Integer = 0
            For y = 0 To dgFileInfo.Items.Count - 1
                Dim Image1 As Image = DirectCast(dgFileInfo.Items(y).FindControl("Image1"), Image)
                Dim Picstype As String = dgFileInfo.Items(y).Cells(3).Text
                Dim bytes As Byte() = DirectCast(dtt.Rows(y)("UploadPicture"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                If Picstype = "Picture" Then
                    imgExtra.ImageUrl = "data:image/png;base64," & base64String
                    imgExtra.Visible = True
                    Image1.Visible = True
                Else
                    Image1.Visible = False
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Function LoadData12(ByVal StyleID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleUploads.GetFileInfo(StyleID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            '---Bind Buying Dept
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()

            '---Bind Byuer Name
            cmbBuyerName.DataSource = objStyleMaster.GetBuyerInfoNo(cmbCustomer.SelectedValue)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()
            '---Bind Brand 
            cmbBrand.DataSource = objStyleMaster.GetBrandInfoNo(cmbCustomer.SelectedValue)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("StyleView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgFileInfo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFileInfo.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "DownloadFile"
                    Dim TableID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim StyleID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text
                    ScriptManager.RegisterClientScriptBlock(Me.UpdgFileInfo, Me.UpdgFileInfo.GetType(), "New ClientScript", "window.open('StyleDatabaseUploadShow.aspx?TableID=" & TableID & "&StyleID=" & StyleID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                Case Is = "Remove"
                    Dim TableID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim StyleID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text

                    objStyleUploads.DeleteStyleUploadTableonAddPage(TableID, StyleID)

                    'Show in grid
                    Dim objDataView1 As DataView
                    objDataView1 = LoadData1(StyleID)
                    Session("objDataView1") = objDataView1
                    BindGridFileInfo()

                    '----when a image delete then show next Picture
                    Dim Pt As New DataTable
                    Pt = objDataView1.ToTable
                    Dim y As Integer = 0
                    For y = 0 To dgFileInfo.Items.Count - 1
                        Dim Image1 As Image = DirectCast(dgFileInfo.Items(y).FindControl("Image1"), Image)
                        Dim Picstype As String = dgFileInfo.Items(y).Cells(3).Text
                        Dim bytes As Byte() = DirectCast(Pt.Rows(y)("UploadPicture"), Byte())
                        Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                        Image1.ImageUrl = "data:image/png;base64," & base64String
                        If Picstype = "Picture" Then
                            imgExtra.ImageUrl = "data:image/png;base64," & base64String
                            imgExtra.Visible = True
                            Image1.Visible = True
                        Else
                            Image1.Visible = False
                        End If
                    Next
            End Select
        Catch ex As Exception

        End Try
    End Sub
     
    Protected Sub dgAcces_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgAcces.DeleteCommand
        dtAccessories = CType(Session("dtAccessories"), DataTable)
        If (Not dtAccessories Is Nothing) Then
            If (dtAccessories.Rows.Count > 0) Then
                Dim SAID As Integer = dtAccessories.Rows(e.Item.ItemIndex)("SAID")
                Dim StyleID As Integer = dtAccessories.Rows(e.Item.ItemIndex)("StyleID")
                dtAccessories.Rows.RemoveAt(e.Item.ItemIndex)
                objStyleAccessories.DeleteDetailFromStyleAccessDetail(SAID, StyleID)
                Session("dtAccessories") = dtAccessories
                BindGridAcces()
                If dtAccessories.Rows.Count = 0 Then
                    dgAcces.Controls.Clear()
                    dgAcces.Visible = False

                End If
            Else
                dgAcces.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        Try
            PnlColor.Visible = True
            btnShow.Visible = False
            btnHide.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnHide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHide.Click
        Try
            PnlColor.Visible = False
            btnShow.Visible = True
            btnHide.Visible = False
        Catch ex As Exception

        End Try
    End Sub


End Class
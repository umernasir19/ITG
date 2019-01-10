Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class StyleDatabaseEntry1
    Inherits System.Web.UI.Page
    Dim objStyleMaster As New StyleMaster2
    Dim objStyleDetail As New StyleDetail
    Dim objStyleAccessories As New StyleAccessories
    Dim objStyleUploads As New StyleUploads
    Dim objCustomer As New CustomerDatabase
    Dim StyleID As Long
    Dim LastStyleID As Long
    Dim dtStyle As New DataTable
    Dim dtArticleDetail As DataTable
    Dim Dr As DataRow
    Dim dtAccesDetail As DataTable
    Dim DrAcces As DataRow
    Dim objPurchaseMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("lStyleID")
        If Not Page.IsPostBack Then
            Session("dtStyle") = Nothing
            Session("dtAccesDetail") = Nothing
            BindCustomer()

            BindProductPortfolio()
            BindProductGroup()
            BindProcessType()

            BindSizeRange()
            BindSeason()
            BindComposition()
            BindProductConsumer()

            If StyleID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"

                txtCartonType.Text = "7 Ply"
                txtCartonSizeL.Text = "80"
                txtCartonSizeW.Text = "30"
                txtCartonSizeH.Text = "40"
                txtCartonSizeUnit.Text = "cm"
                txtPolyBagSizeUnit.Text = "cm"

                If cmbProductPortfolio.SelectedValue = 1 Then
                    txtAcceptableDimensionalL.Text = "5%"
                    txtAcceptableDimensionalW.Text = "5%"
                ElseIf cmbProductPortfolio.SelectedValue = 2 Then
                    txtAcceptableDimensionalL.Text = "5%"
                    txtAcceptableDimensionalW.Text = "5%"
                ElseIf cmbProductPortfolio.SelectedValue = 3 Then
                    txtAcceptableDimensionalL.Text = "4%"
                    txtAcceptableDimensionalW.Text = "3%"
                ElseIf cmbProductPortfolio.SelectedValue = 4 Then
                    txtAcceptableDimensionalL.Text = "5%"
                    txtAcceptableDimensionalW.Text = "5%"
                ElseIf cmbProductPortfolio.SelectedValue = 5 Then
                    txtAcceptableDimensionalL.Text = "NR"
                    txtAcceptableDimensionalW.Text = "NR"
                End If

            End If

            ' Show(File)
            Dim objDataView1 As DataView
            objDataView1 = LoadData1(StyleID)
            Session("objDataView1") = objDataView1
            BindGridFileInfo()
        End If
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
    Sub BindComposition()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetComposition
            cmbComposition.DataSource = dt
            cmbComposition.DataTextField = "CompositionName"
            cmbComposition.DataValueField = "CompositionID"
            cmbComposition.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductConsumer()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetProductConsumer
            cmbProductConsumer.DataSource = dt
            cmbProductConsumer.DataTextField = "ProductConsumerName"
            cmbProductConsumer.DataValueField = "ProductConsumerID"
            cmbProductConsumer.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSizeRange()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetSizeRange
            cmbSizeRange.DataSource = dt
            cmbSizeRange.DataValueField = "sizerange"
            cmbSizeRange.DataBind()
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

            txtFabric.Text = cmbProductPortfolio.SelectedItem.Text

            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategroy.DataSource = dtProductCategories
            cmbProductCategroy.DataTextField = "ProductCategories"
            cmbProductCategroy.DataValueField = "ProductCategoriesID"
            cmbProductCategroy.DataBind()

            txtFabricType.Text = cmbProductCategroy.SelectedItem.Text
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductGroup()
        Try

            Dim dtProductGroup As DataTable
            dtProductGroup = objPurchaseMaster.GetAllProductType
            cmbProductGroup.DataSource = dtProductGroup
            cmbProductGroup.DataTextField = "ProductType"
            cmbProductGroup.DataValueField = "TypeID"
            cmbProductGroup.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindProcessType()
        Dim itemsList As New ArrayList()
        itemsList.Add("Yarn Dyed")
        itemsList.Add("Solid Dyed")
        itemsList.Add("Printed")
        itemsList.Add("Dyed Over Print")
        itemsList.Add("Flat Bed")
        itemsList.Add("Others")
        cmbProcessType.DataSource = itemsList
        cmbProcessType.DataBind()
    End Sub
    Private Sub BindCustomer()
        cmbBuyer.DataSource = objStyleMaster.GetFilterComboValues
        cmbBuyer.DataValueField = "CustomerID"
        cmbBuyer.DataTextField = "CustomerName"
        cmbBuyer.DataBind()

        cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbBuyer.SelectedValue)
        cmbBuyingDept.DataValueField = "departmentno"
        cmbBuyingDept.DataTextField = "departmentno"
        cmbBuyingDept.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            ' Dim dtExist As DataTable = objStyleMaster.CheckStyle11(txtStyleNo.Text)

            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No empty.")
            ElseIf dgArticle.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one article required.")
            Else
                With objStyleMaster
                    If StyleID > 0 Then
                        .StyleID = StyleID
                    Else
                        .StyleID = 0
                    End If

                    .StyleNo = txtStyleNo.Text
                    .StyleName = txtStyleName.Text
                    .Buyer = cmbBuyer.SelectedValue
                    .CreationDate = Date.Now()
                    .IsActive = True
                    .MarchandID = CLng(Session("UserID"))
                    .MaterialComposition = ""
                    .ProductGroup = cmbProductGroup.SelectedItem.Text

                    .Sketch = "Pending"

                    .ProductPortfolio = cmbProductPortfolio.SelectedItem.Text
                    .ProductCategories = cmbProductCategroy.SelectedItem.Text
                    .Blend = txtBlend.Text
                    .GSM = txtGSM.Text
                    .ProcessType = cmbProcessType.SelectedItem.Text
                    .Composition = cmbComposition.SelectedItem.Text

                    .OriginalSample = cmbOriginalSample.SelectedItem.Text ' txtOriginalSample.Text
                    .Fabric = txtFabric.Text
                    .FabricType = txtFabricType.Text
                    .FabricConstruction = txtFabricConstruction.Text
                    .FabricWeight = txtFabricWeight.Text
                    .GarmentWeight = txtGarmentWeight.Text
                    .PcWeight = txtPcWeight.Text
                    .CartonType = txtCartonType.Text
                    .CartonSizeL = txtCartonSizeL.Text
                    .CartonSizeW = txtCartonSizeW.Text
                    .CartonSizeH = txtCartonSizeH.Text
                    .CartonSizeUnit = txtCartonSizeUnit.Text
                    .QtyCarton = txtQtyCarton.Text
                    .QtyPack = txtQtyPack.Text
                    .QtyPackUnit = cmbQtyPack.SelectedItem.Text

                    .PolyBagSizeL = txtPolyBagSizeL.Text
                    .PolyBagSizeW = txtPolyBagSizeW.Text
                    .PolyBagSizeFlap = txtPolyBagSizeFlap.Text
                    .PolyBagSizeUnit = txtPolyBagSizeUnit.Text
                    .InlayCardSize = txtInlayCardSize.Text
                    .PackedPcL = txtPackedPcSzL.Text
                    .PackedPcW = txtPackedPcSzW.Text
                    .PackedPcH = txtPackedPcSzH.Text
                    .GrossWeightCarton = txtGrossWeightofCarton.Text
                    .PolyBagStickerSizeL = txtPolyBagStickerSizeL.Text
                    .PolyBagStickerSizeW = txtPolyBagStickerSizeW.Text
                    .AcceptableDimensionalL = txtAcceptableDimensionalL.Text
                    .AcceptableDimensionalW = txtAcceptableDimensionalW.Text
                    .RubbingFastnessWet = txtRubbingFastnessWet.Text
                    .RubbingFastnessDry = txtRubbingFastnessDry.Text
                    .TypeofDryes = txtTypeofDyes.Text
                    .TypeofPrint = txtTypeofPrint.Text
                    .TypeofWashing = txtTypeofWashing.Text
                    .FabricFinish = txtFabricFinish.Text
                    .Season = cmbSeason.SelectedItem.Text ' txtSeason.Text
                    .BuyingDept = cmbBuyingDept.SelectedValue
                    .WeightUnit = txtWeightUnit.Text
                    .NameOfBrand = txtNameOfBrand.Text
                    .FabricWeightUnit = txtFabricWeightUnit.Text
                    .GarmentWeightUnit = txtGarmentWeightUnit.Text
                    .PcWeightUnit = txtPcWeightUnit.Text
                    .ProductConsumerName = cmbProductConsumer.SelectedItem.Text
                    .SaveStyleMaster()
                End With

                Dim x As Integer
                Dim StyleDetailID As Integer = 0
                For x = 0 To dgArticle.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgArticle.MasterTableView.Items(x), GridDataItem)

                    With objStyleDetail
                        .StyleDetailID = item("StyleDetailID").Text
                        If StyleID > 0 Then
                            .StyleID = StyleID
                        Else
                            .StyleID = objStyleMaster.GetID()
                        End If

                        .CreationDate = Date.Now()
                        .Article = item("Article").Text
                        .ArticleDescription = item("ArticleDescription").Text
                        .Colorway = item("Colorway").Text
                        .SizeRange = item("SizeRange").Text
                        .Price = item("Price").Text
                        .Remarks = ""
                        .PriceUnit = item("PriceUnit").Text
                        .FabricConst = item("FabricConst").Text
                        .SaveStyleDetail()
                    End With
                Next

                'With objStyleUploads
                '    .TableID = 0
                '    If StyleID > 0 Then
                '        .StyleID = StyleID
                '    Else
                '        .StyleID = objStyleMaster.GetID()
                '    End If
                '    .UploadPicture = SaveUploadPicture()
                '    .UplaodSizeChart = SaveUplaodSizeChart()
                '    .UplaodCareLabePicture = SaveUplaodCareLabePicture()
                '    .SaveStyleUploads()
                'End With

                For x = 0 To dgAcces.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgAcces.MasterTableView.Items(x), GridDataItem)
                    With objStyleAccessories
                        .SAID = item("SAID").Text
                        If StyleID > 0 Then
                            .StyleID = StyleID
                        Else
                            .StyleID = objStyleMaster.GetID()
                        End If

                        .Accessories = item("Accessories").Text
                        .AccesType = item("AccesType").Text
                        .Source = item("Source").Text
                        .SaveStyleAccessories()
                    End With
                Next
                Session("dtStyle") = Nothing
                Session("dtAccesDetail") = Nothing
                Response.Redirect("StyleView.aspx")
            End If
        Catch ex As Exception

        End Try
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
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try
            'chking
            Dim FinalStatus As Decimal = 0
            If dgArticle.Items.Count > 0 Then
                For x = 0 To dgArticle.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgArticle.MasterTableView.Items(x), GridDataItem)
                    If item("Article").Text = txtArticle.Text And item("ArticleDescription").Text = txtArticleDescription.Text And item("Colorway").Text = txtColorway.Text And item("SizeRange").Text = txtSizeRange.Text And item("Price").Text = txtPrice.Text Then
                        FinalStatus = 1
                        Exit For
                    Else
                        FinalStatus = 0
                    End If
                Next
                If FinalStatus = 1 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Article already exist in grid.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtStyle"), DataTable) Is Nothing) Then
            dtStyle = Session("dtStyle")
        Else
            dtStyle = New DataTable
            With dtStyle
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("StyleDetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("ArticleDescription", GetType(String))
                .Columns.Add("Colorway", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Price", GetType(String))
                .Columns.Add("PriceUnit", GetType(String))
                .Columns.Add("FabricConst", GetType(String))
            End With
        End If

        Dim x As Integer
        Dim dtSize As DataTable = objPurchaseMaster.GetSizeRange11(cmbSizeRange.SelectedItem.Text)
        For x = 0 To dtSize.Rows.Count - 1
            Dr = dtStyle.NewRow()
            Dr("StyleID") = 0
            Dr("StyleDetailID") = 0
            Dr("Article") = txtArticle.Text
            Dr("ArticleDescription") = txtArticleDescription.Text
            Dr("Colorway") = txtColorway.Text
            Dr("SizeRange") = dtSize.Rows(x)("Sizes")
            Dr("Price") = txtPrice.Text
            Dr("PriceUnit") = cmbPriceUnit.SelectedItem.Text
            Dr("FabricConst") = txtFabricConst.Text
            dtStyle.Rows.Add(Dr)
        Next
        Session("dtStyle") = dtStyle
    End Sub
    'Sub SaveSession()
    '    If (Not CType(Session("dtStyle"), DataTable) Is Nothing) Then
    '        dtStyle = Session("dtStyle")
    '    Else
    '        dtStyle = New DataTable
    '        With dtStyle
    '            .Columns.Add("StyleID", GetType(Long))
    '            .Columns.Add("StyleDetailID", GetType(Long))
    '            .Columns.Add("Article", GetType(String))
    '            .Columns.Add("ArticleDescription", GetType(String))
    '            .Columns.Add("Colorway", GetType(String))
    '            .Columns.Add("SizeRange", GetType(String))
    '            .Columns.Add("Price", GetType(String))
    '            .Columns.Add("PriceUnit", GetType(String))
    '        End With
    '    End If
    '    Dr = dtStyle.NewRow()
    '    Dr("StyleID") = 0
    '    Dr("StyleDetailID") = 0
    '    Dr("Article") = txtArticle.Text
    '    Dr("ArticleDescription") = txtArticleDescription.Text
    '    Dr("Colorway") = txtColorway.Text
    '    Dr("SizeRange") = txtSizeRange.Text
    '    Dr("Price") = txtPrice.Text
    '    Dr("PriceUnit") = cmbPriceUnit.SelectedItem.Text
    '    dtStyle.Rows.Add(Dr)
    '    Session("dtStyle") = dtStyle
    'End Sub
    Private Function BindGrid() As Boolean
        If (Not dtStyle Is Nothing) Then
            If (dtStyle.Rows.Count > 0) Then

                dgArticle.DataSource = dtStyle
                dgArticle.DataBind()
                dgArticle.Visible = True
                Return (True)
            Else
                dgArticle.Visible = False
                Return (False)
            End If

        End If
        Return (False)
    End Function
    Protected Sub dgArticle_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Try
            dtStyle = CType(Session("dtStyle"), DataTable)
            If (Not dtStyle Is Nothing) Then
                If (dtStyle.Rows.Count > 0) Then
                    Dim StyleDetailID As Integer = dtStyle.Rows(e.Item.ItemIndex)("StyleDetailID")
                    dtStyle.Rows.RemoveAt(e.Item.ItemIndex)
                    objStyleDetail.DeleteDetail(StyleDetailID)
                    BindGrid()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgAcces_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub
    Sub SetValuesEditMod()
        Dim Dt As DataTable
        Dim DtStyleMaster As DataTable
        Dim x As Integer
        Try
            Dt = objStyleMaster.GetStyleByStyelID(StyleID)
            DtStyleMaster = objStyleMaster.GetStyleMasterByStyelID(StyleID)
            txtStyleNo.Text = DtStyleMaster.Rows(0)("StyleNo")

            If String.IsNullOrEmpty(DtStyleMaster.Rows(0)("StyleName").ToString()) = False Then
                txtStyleName.Text = DtStyleMaster.Rows(0)("StyleName")
            Else
                txtStyleName.Text = ""
            End If
            cmbBuyer.SelectedValue = DtStyleMaster.Rows(0)("customerID")

            If String.IsNullOrEmpty(Dt.Rows(0)("ProductPortfolio").ToString()) = False Then
                'Now first get the ProductGroup ID
                Dim dtProductGroupID As New DataTable
                dtProductGroupID = objPurchaseMaster.GetProductPortfolioID(Dt.Rows(0)("ProductPortfolio"))
                If dtProductGroupID.Rows.Count > 0 Then
                    Dim ProductGroupID As Long = dtProductGroupID.Rows(0)("ProductPortfolioID")
                    cmbProductPortfolio.SelectedValue = ProductGroupID
                Else
                    cmbProductPortfolio.SelectedValue = 0
                End If
            Else
                cmbProductPortfolio.SelectedValue = 0
            End If

            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategroy.DataSource = dtProductCategories
            cmbProductCategroy.DataTextField = "ProductCategories"
            cmbProductCategroy.DataValueField = "ProductCategoriesID"
            cmbProductCategroy.DataBind()

            'Now first get the Product Categories ID
            Dim dtProductCategoriesID As New DataTable
            dtProductCategoriesID = objPurchaseMaster.GetProductCategoriesID(Dt.Rows(0)("ProductCategories"), cmbProductPortfolio.SelectedValue)
            If dtProductCategoriesID.Rows.Count > 0 Then
                Dim ProductCategoriesID As Long = dtProductCategoriesID.Rows(0)("ProductCategoriesID")
                cmbProductCategroy.SelectedValue = ProductCategoriesID
                updProductCategroy.Update()
            End If


            If String.IsNullOrEmpty(Dt.Rows(0)("ProductGroup").ToString()) = False Then
                'Now first get the ProductType ID
                Dim dtProductTypeID As New DataTable
                dtProductTypeID = objPurchaseMaster.GetProductTypeID(Dt.Rows(0)("ProductGroup"))
                If dtProductTypeID.Rows.Count > 0 Then
                    Dim ProductTypeID As Long = dtProductTypeID.Rows(0)("TypeID")
                    cmbProductGroup.SelectedValue = ProductTypeID
                Else
                    cmbProductGroup.SelectedValue = 0
                End If
            Else
                cmbProductGroup.SelectedValue = 0
            End If

            txtBlend.Text = DtStyleMaster.Rows(0)("Blend")
            txtGSM.Text = DtStyleMaster.Rows(0)("GSM")
            cmbProcessType.SelectedItem.Text = DtStyleMaster.Rows(0)("ProcessType")
            ''For Composirion
            'If Dt.Rows(0)("Composition").ToString() = "CMIA" Then
            '    cmbComposition.SelectedIndex = 0
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Oragnic" Then
            '    cmbComposition.SelectedIndex = 1
            'ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Cotton" Then
            '    cmbComposition.SelectedIndex = 2
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Cotton Polyester" Then
            '    cmbComposition.SelectedIndex = 3
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Polystic Cotton" Then
            '    cmbComposition.SelectedIndex = 4
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Tensil" Then
            '    cmbComposition.SelectedIndex = 5
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Bambu" Then
            '    cmbComposition.SelectedIndex = 6
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Micro Fibric" Then
            '    cmbComposition.SelectedIndex = 7
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Cotton" Then
            '    cmbComposition.SelectedIndex = 8
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Polyester" Then
            '    cmbComposition.SelectedIndex = 9
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Elastine" Then
            '    cmbComposition.SelectedIndex = 10
            'ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Polyester" Then
            '    cmbComposition.SelectedIndex = 11
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Cow/Buffalo" Then
            '    cmbComposition.SelectedIndex = 12
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Sheep" Then
            '    cmbComposition.SelectedIndex = 13
            'ElseIf Dt.Rows(0)("Composition").ToString() = "Others" Then
            '    cmbComposition.SelectedIndex = 14
            'Else
            '    cmbComposition.SelectedIndex = 0
            'End If

            Dim dtC As DataTable
            dtC = objPurchaseMaster.GetComposition1(Dt.Rows(0)("Composition"))
            cmbComposition.SelectedValue = dtC.Rows(0)("CompositionID")

            If Dt.Rows(0)("OriginalSample") = "Technical sheet" Then
                cmbOriginalSample.SelectedValue = 0
            ElseIf Dt.Rows(0)("OriginalSample") = "Buyer sample" Then
                cmbOriginalSample.SelectedValue = 1
            End If

            'txtOriginalSample.Text = Dt.Rows(0)("OriginalSample")

            txtFabric.Text = Dt.Rows(0)("Fabric")
            txtFabricType.Text = Dt.Rows(0)("FabricType")
            txtFabricConstruction.Text = Dt.Rows(0)("FabricConstruction")
            txtFabricWeight.Text = Dt.Rows(0)("FabricWeight")
            txtGarmentWeight.Text = Dt.Rows(0)("GarmentWeight")
            txtPcWeight.Text = Dt.Rows(0)("PcWeight")
            txtCartonType.Text = Dt.Rows(0)("CartonType")
            txtCartonSizeL.Text = Dt.Rows(0)("CartonSizeL")
            txtCartonSizeW.Text = Dt.Rows(0)("CartonSizeW")
            txtCartonSizeH.Text = Dt.Rows(0)("CartonSizeH")

            If Dt.Rows(0)("QtyPackUnit") = "pcs" Then
                cmbQtyPack.SelectedValue = 0
            ElseIf Dt.Rows(0)("QtyPackUnit") = "pks" Then
                cmbQtyPack.SelectedValue = 1
            ElseIf Dt.Rows(0)("QtyPackUnit") = "sets" Then
                cmbQtyPack.SelectedValue = 2
            End If

            'txtCartonSizeUnit.Text = Dt.Rows(0)("CartonSizeUnit")
            txtQtyCarton.Text = Dt.Rows(0)("QtyCarton")
            txtQtyPack.Text = Dt.Rows(0)("QtyPack")
            txtPolyBagSizeL.Text = Dt.Rows(0)("PolyBagSizeL")
            txtPolyBagSizeW.Text = Dt.Rows(0)("PolyBagSizeW")
            txtPolyBagSizeFlap.Text = Dt.Rows(0)("PolyBagSizeFlap")

            txtPolyBagSizeUnit.Text = Dt.Rows(0)("PolyBagSizeUnit")
            txtInlayCardSize.Text = Dt.Rows(0)("InlayCardSize")
            txtPackedPcSzL.Text = Dt.Rows(0)("PackedPcL")
            txtPackedPcSzW.Text = Dt.Rows(0)("PackedPcW")
            txtPackedPcSzH.Text = Dt.Rows(0)("PackedPcH")
            txtGrossWeightofCarton.Text = Dt.Rows(0)("GrossWeightCarton")
            txtPolyBagStickerSizeL.Text = Dt.Rows(0)("PolyBagStickerSizeL")
            txtPolyBagStickerSizeW.Text = Dt.Rows(0)("PolyBagStickerSizeW")
            txtAcceptableDimensionalL.Text = Dt.Rows(0)("AcceptableDimensionalL")
            txtAcceptableDimensionalW.Text = Dt.Rows(0)("RubbingFastnessWet")
            txtRubbingFastnessWet.Text = Dt.Rows(0)("RubbingFastnessWet")
            txtRubbingFastnessDry.Text = Dt.Rows(0)("RubbingFastnessDry")
            txtTypeofDyes.Text = Dt.Rows(0)("TypeofDryes")
            txtTypeofPrint.Text = Dt.Rows(0)("TypeofPrint")
            txtTypeofWashing.Text = Dt.Rows(0)("TypeofWashing")
            txtFabricFinish.Text = Dt.Rows(0)("FabricFinish")

            ' txtSeason.Text = Dt.Rows(0)("Season")

            Dim dtS As DataTable
            dtS = objPurchaseMaster.GetSeason1(Dt.Rows(0)("Season"))

            cmbSeason.SelectedValue = dtS.Rows(0)("SeasonID")

            cmbBuyingDept.SelectedValue = Dt.Rows(0)("BuyingDept")

            txtWeightUnit.Text = Dt.Rows(0)("WeightUnit")
            txtNameOfBrand.Text = Dt.Rows(0)("NameOfBrand")

            txtFabricWeightUnit.Text = Dt.Rows(0)("FabricWeightUnit")
            txtGarmentWeightUnit.Text = Dt.Rows(0)("GarmentWeightUnit")
            txtPcWeightUnit.Text = Dt.Rows(0)("PcWeightUnit")

            Dim dtP As DataTable
            dtP = objPurchaseMaster.GetProductConsumer1(Dt.Rows(0)("ProductConsumerName"))
            cmbProductConsumer.SelectedValue = dtP.Rows(0)("ProductConsumerID")


            '-------------------- Detail Values
            dtStyle = Nothing
            Session("dtStyle") = Nothing
            dtStyle = New DataTable
            With dtStyle
                .Columns.Add("StyleDetailID", GetType(Long))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("ArticleDescription", GetType(String))
                .Columns.Add("Colorway", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Price", GetType(Decimal))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("PriceUnit", GetType(String))
                .Columns.Add("FabricConst", GetType(String))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtStyle.NewRow()
                Dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
                Dr("StyleID") = Dt.Rows(x)("StyleID")
                Dr("Article") = Dt.Rows(x)("Article")
                Dr("StyleNo") = Dt.Rows(x)("StyleNo")
                Dr("ArticleDescription") = Dt.Rows(x)("ArticleDescription")
                Dr("Colorway") = Dt.Rows(x)("Colorway")
                Dr("SizeRange") = Dt.Rows(x)("SizeRange")
                Dr("Price") = Dt.Rows(x)("Price")
                Dr("Remarks") = Dt.Rows(x)("Remarks")
                Dr("PriceUnit") = Dt.Rows(x)("PriceUnit")
                Dr("FabricConst") = Dt.Rows(x)("FabricConst")
                dtStyle.Rows.Add(Dr)
            Next
            Session("dtStyle") = dtStyle
            BindGrid()

            Dim dtt As DataTable = objStyleMaster.GetStyleAcces(StyleID)

            dtAccesDetail = Nothing
            Session("dtAccesDetail") = Nothing
            dtAccesDetail = New DataTable
            dtAccesDetail = New DataTable
            With dtAccesDetail
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("SAID", GetType(Long))
                .Columns.Add("Accessories", GetType(String))
                .Columns.Add("AccesType", GetType(String))
                .Columns.Add("Source", GetType(String))
            End With
            For x = 0 To dtt.Rows.Count - 1
                Dr = dtAccesDetail.NewRow()
                Dr("StyleID") = dtt.Rows(x)("StyleID")
                Dr("SAID") = dtt.Rows(x)("SAID")
                Dr("Accessories") = dtt.Rows(x)("Accessories")
                Dr("AccesType") = dtt.Rows(x)("AccesType")
                Dr("Source") = dtt.Rows(x)("Source")
                dtAccesDetail.Rows.Add(Dr)
            Next
            Session("dtAccesDetail") = dtAccesDetail
            BindGridAcces()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbProductPortfolio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductPortfolio.SelectedIndexChanged
        Try
            If cmbProductPortfolio.SelectedValue = 0 Then
                cmbProductCategroy.Items.Clear()
                cmbProductPortfolio.BackColor = Drawing.Color.Red
            Else
                Dim dtProductCategories As DataTable
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
                cmbProductCategroy.DataSource = dtProductCategories
                cmbProductCategroy.DataTextField = "ProductCategories"
                cmbProductCategroy.DataValueField = "ProductCategoriesID"
                cmbProductCategroy.DataBind()

                txtFabric.Text = cmbProductPortfolio.SelectedItem.Text
                txtFabricType.Text = cmbProductCategroy.SelectedItem.Text

                UpdatePanel1.Update()
                UpdatePanel2.Update()
            End If
            updProductCategroy.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            SaveSessionAcces()
            BindGridAcces()
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionAcces()
        If (Not CType(Session("dtAccesDetail"), DataTable) Is Nothing) Then
            dtAccesDetail = Session("dtAccesDetail")
        Else
            dtAccesDetail = New DataTable
            With dtAccesDetail
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("SAID", GetType(Long))
                .Columns.Add("Accessories", GetType(String))
                .Columns.Add("AccesType", GetType(String))
                .Columns.Add("Source", GetType(String))
            End With
        End If
        Dr = dtAccesDetail.NewRow()
        Dr("StyleID") = 0
        Dr("SAID") = 0
        Dr("Accessories") = txtAcces.Text
        Dr("AccesType") = txtAccesType.Text
        Dr("Source") = cmbSource.SelectedItem.Text

        dtAccesDetail.Rows.Add(Dr)
        Session("dtAccesDetail") = dtAccesDetail
    End Sub
    Private Function BindGridAcces() As Boolean
        If (Not dtAccesDetail Is Nothing) Then
            If (dtAccesDetail.Rows.Count > 0) Then

                dgAcces.DataSource = dtAccesDetail
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
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Session("dtStyle") = Nothing
            Session("dtAccesDetail") = Nothing
            Response.Redirect("StyleView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbProductCategroy_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductCategroy.SelectedIndexChanged
        Try
            txtFabricType.Text = cmbProductCategroy.SelectedItem.Text
            UpdatePanel1.Update()
            UpdatePanel2.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUpload1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload1.Click
        Try
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If FileUpload1.FileName = "" Then
                lblErrorMsg.Text = "No File"
            ElseIf fileExt <> ".jpg" Then
                lblErrorMsg.Text = "Only jpg file allow to upload"
            Else
                lblErrorMsg.Text = ""
                Dim astyleid As Long = 0
                With objStyleUploads
                    .TableID = 0
                    .CreationDate = Date.Now
                    If StyleID > 0 Then
                        .StyleID = StyleID
                        astyleid = StyleID
                    Else
                        .StyleID = objStyleMaster.GetID()
                        astyleid = objStyleMaster.GetID()
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
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadData1(ByVal StyleID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleUploads.GetFileInfo(StyleID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
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
    Protected Sub dgFileInfo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFileInfo.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "DownloadFile"
                    Dim StyleID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim ID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text

                    ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('StyleUploadShow.aspx?ID=" & ID & "&StyleID=" & StyleID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

                    '  Response.Redirect("StyleUploadShow.aspx?ID=" & ID & "&StyleID=" & StyleID & "")
                Case Is = "Remove"
                    Dim StyleID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim ID As Integer = dgFileInfo.Items(e.Item.ItemIndex).Cells(0).Text

                    Dim objQDInspectionUpload As New QDInspectionUpload
                    objQDInspectionUpload.DeleteFile(ID, StyleID)

                    'Show in grid
                    Dim objDataView1 As DataView
                    objDataView1 = LoadData1(StyleID)
                    Session("objDataView1") = objDataView1
                    BindGridFileInfo()

            End Select
        Catch ex As Exception

        End Try
    End Sub

End Class
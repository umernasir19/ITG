Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class StyleDatabaseEntry
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
    Dim objLiningType As New LiningType
    Dim objbuyer As New Buyer
    Dim dtt As DataTable
    Dim Type As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("lStyleID")
        Type = Request.QueryString("Type")
        If Not Page.IsPostBack Then
            ''---TDelete Detailtable if Master Id=0
            objStyleUploads.DeleteStyleUploadDetailTable()

            txtCreatedBy.Text = Session("UserName")
            txtCreatedOn.Text = Date.Now.ToString("dd/MM/yyyy")

            objStyleUploadsTemp.Deletetble()

            Session("dtStyle") = Nothing
            Session("dtAccessories") = Nothing
            Session("dtStyleProductInformation") = Nothing
            Session("dtFile") = Nothing

            BindStyle()
            If rbnSelect.SelectedValue = 0 Then
                txtStyleNo.Visible = False
                cmbStyleNoo.Visible = True
            Else
                txtStyleNo.Visible = True
                cmbStyleNoo.Visible = False
            End If
            BindDegree1()
            BindBleaching()
            BindDryCleaning()
            BindTumbleDry()
            BindIroning()
            BindCustomer()
            BindSeason()
            BindProductPortfolio()
            BindProductConsumer()
            BindEmbell()
            BindSizeRange()
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
                If Type = "Copy" Then
                    CopyMode()
                    btnAddProduct.Visible = True
                    btnAutoComplete.Visible = False
                Else
                    EditMode()
                    btnAddProduct.Visible = False
                    btnAutoComplete.Visible = False
                    rbnSelect.Enabled = False
                    UpdatePanel8.Update()
                End If
            Else
                btnAddProduct.Visible = True
                btnAutoComplete.Visible = False
            End If
        End If
    End Sub
    Sub BindDegree1()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetDegree1
            cmbdegree1.DataSource = dt
            cmbdegree1.DataTextField = "DegreeofColourname"
            cmbdegree1.DataValueField = "DegreeofColourID"
            cmbdegree1.DataBind()
            cmbdegree1.SelectedValue = 1

            cmbdegree2.DataSource = dt
            cmbdegree2.DataTextField = "DegreeofColourname"
            cmbdegree2.DataValueField = "DegreeofColourID"
            cmbdegree2.DataBind()
            cmbdegree2.SelectedValue = 2

            cmbdegree3.DataSource = dt
            cmbdegree3.DataTextField = "DegreeofColourname"
            cmbdegree3.DataValueField = "DegreeofColourID"
            cmbdegree3.DataBind()
            cmbdegree3.SelectedValue = 3
            'Dim imageURL As String = ""
            'Dim i As Integer = 0
            'Do While (i < cmbdegree1.Items.Count)
            '    Select Case (cmbdegree1.Items(i).Text)
            '        Case "degree1.jpg"
            '            imageURL = "~/Images/degree1.jpg"
            '        Case "degree2.jpg"
            '            imageURL = "~/Images/degree2.jpg"
            '        Case "degree3.jpg"
            '            imageURL = "~/Images/degree3.png"
            '    End Select

            '    Dim item As ListItem = cmbdegree1.Items(i)
            '    item.Attributes("style") = ("background: url(" _
            '                + (imageURL + ");background-repeat:no-repeat;"))
            '    i = (i + 1)
            'Loop


        Catch ex As Exception

        End Try
    End Sub
    Sub BindBleaching()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetBLEACHING
            cmbBleachingSymbol.DataSource = dt
            cmbBleachingSymbol.DataTextField = "BleachingSymbolname"
            cmbBleachingSymbol.DataValueField = "BleachingSymbolID"
            cmbBleachingSymbol.DataBind()



        Catch ex As Exception

        End Try
    End Sub
    Sub BindIroning()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetIroning
            cmbIroningSymbol.DataSource = dt
            cmbIroningSymbol.DataTextField = "IroningSymbolname"
            cmbIroningSymbol.DataValueField = "IroningSymbolID"
            cmbIroningSymbol.DataBind()



        Catch ex As Exception

        End Try
    End Sub

    Sub BindDryCleaning()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetDryCleaning
            cmbDryCleaning.DataSource = dt
            cmbDryCleaning.DataTextField = "DryCleaningSymbolname"
            cmbDryCleaning.DataValueField = "DryCleaningSymbolID"
            cmbDryCleaning.DataBind()



        Catch ex As Exception

        End Try
    End Sub
    Sub BindTumbleDry()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetTumlbeDry
            cmbTumbleDry.DataSource = dt
            cmbTumbleDry.DataTextField = "TumbleDryname"
            cmbTumbleDry.DataValueField = "TumbleDryID"
            cmbTumbleDry.DataBind()



        Catch ex As Exception

        End Try
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
    Sub BindStyle()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetStyle
            cmbStyleNoo.DataSource = dt
            cmbStyleNoo.DataTextField = "StyleNo"
            cmbStyleNoo.DataValueField = "InquiryStyleID"
            cmbStyleNoo.DataBind()
            cmbStyleNoo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
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
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
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
    Sub BindAccessories()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetStyleAccessoriesList
            cmbAccessories.DataSource = dt
            cmbAccessories.DataTextField = "AccessoriesName"
            cmbAccessories.DataValueField = "AccessoriesID"
            cmbAccessories.DataBind()
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
            If StyleID = 0 Then
                Dim dt As DataTable
                dt = objPurchaseMaster.CheckStyle(txtStyleNo.Text)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No Already Exist.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                End If
            Else
                If Type = "Copy" Then
                    Dim dt As DataTable
                    dt = objPurchaseMaster.CheckStyle(txtStyleNo.Text)
                    If dt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    End If
                End If
            End If
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
            BindLinigType()
            BindFabFinish()
            If cmbProductPortfolio.SelectedValue = 1 Then
                btnAddProduct.Visible = False
                cmbProductPortfolio.Enabled = False
                btnAddMoreProduct.Visible = True
                Upadd.Update()
                UpcmbProductPortfolio.Update()
            Else
                If StyleID > 0 Then
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
                Dim Lining As String = dgProductinfo.Items(x).Cells(22).Text
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
            End With
        End If
        Dim x = 0

        If cmbPack.SelectedValue = 0 Then
            x = 1
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 1 Then
            x = 2
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 2 Then
            x = 3
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 3 Then
            x = 4
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 4 Then
            x = 5
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 5 Then
            x = 6
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 6 Then
            x = 7
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 7 Then
            x = 8
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 8 Then
            x = 9
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 9 Then
            x = 10
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 10 Then
            x = 11
            BindcmbBaseItem(x)
        ElseIf cmbPack.SelectedValue = 11 Then
            x = 12
            BindcmbBaseItem(x)
        End If


        Dim rowcount As Decimal
        For x = 1 To x
            Dr = dtStyleProductInformation.NewRow()
            rowcount = Val(dtStyleProductInformation.Rows.Count) + 1
            Dr("SproductID") = 0
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
            dtStyleProductInformation.Rows.Add(Dr)

        Next

        Session("dtStyleProductInformation") = dtStyleProductInformation
        If cmbProductPortfolio.SelectedValue = 1 Then
            BindcmbBaseItemForHomeTextile()
            lblitem.Text = "Item"
            Uplblitem.Update()
        Else
            lblitem.Text = "Base Item"
            Uplblitem.Update()
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
                    Dim txtRemarks As TextBox = CType(dgProductinfo.Items(rowIndex).FindControl("txtRemarks"), TextBox)
                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(rowIndex).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(rowIndex).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(rowIndex).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(rowIndex).FindControl("txtLiningWt"), TextBox)
                    Dim Lining As String = dgProductinfo.Items(rowIndex).Cells(22).Text

                    Dim SproductID As String = dgProductinfo.Items(rowIndex).Cells(0).Text
                    Dim ProductPortfolioID As String = dgProductinfo.Items(rowIndex).Cells(1).Text
                    Dim ProductCategoriesID As String = dgProductinfo.Items(rowIndex).Cells(2).Text
                    Dim ProductConsumerID As String = dgProductinfo.Items(rowIndex).Cells(3).Text
                    rowcount = Val(dtStyleProductInformation.Rows.Count) + 1
                    dr = dtStyleProductInformation.NewRow()
                    dr("SproductID") = SproductID
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
                    rowIndex += 1
                Next

                dtStyleProductInformation.Rows.Add(dr)
                dtStyleProductInformation.Rows(rowIndex)("SproductID") = 0
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
            BindcmbBaseItemForHomeTextile()
            lblitem.Text = "Item"
            Uplblitem.Update()
        Else
            BindcmbBaseItemadd()
            lblitem.Text = "Base Item"
            Uplblitem.Update()
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
                    Dim txtRemarks As TextBox = CType(dgProductinfo.Items(i).FindControl("txtRemarks"), TextBox)

                    Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(i).FindControl("cmbLiningType"), DropDownList)
                    Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(i).FindControl("txtLiningCons"), TextBox)
                    Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(i).FindControl("cmbLinigComp"), DropDownList)
                    Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(i).FindControl("txtLiningWt"), TextBox)

                    txtPack.Text = dtStyleProductInformation.Rows(i)("Pack").ToString
                    txtRow.Text = dtStyleProductInformation.Rows(i)("RowNo")
                    txtItem.Text = dtStyleProductInformation.Rows(i)("Item")
                    Dim Lining As String = dgProductinfo.Items(i).Cells(22).Text
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
    Sub BindcmbBaseItem(ByVal xx As Long)
        Try
            Dim dtBaseItem As New DataTable
            'If (Not CType(Session("dtBaseItem"), DataTable) Is Nothing) Then
            '    dtBaseItem = Session("dtBaseItem")
            'Else
            With dtBaseItem
                .Columns.Add("BaseItem", GetType(String))
            End With
            ' End If

            For xx = 0 To xx - 1
                With dtBaseItem
                    Dr = dtBaseItem.NewRow()
                    Dr("BaseItem") = "Row " + (xx + 1).ToString()
                    dtBaseItem.Rows.Add(Dr)
                End With
            Next

            cmbBaseItem.DataSource = dtBaseItem
            cmbBaseItem.DataTextField = "BaseItem"
            cmbBaseItem.DataValueField = "BaseItem"
            cmbBaseItem.DataBind()
            Dim count As Integer = 0
            count = dtBaseItem.Rows.Count

            cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
            UpcmbBaseItem.Update()
            Session("dtBaseItem") = dtBaseItem
        Catch ex As Exception

        End Try
    End Sub
    Sub BindcmbBaseItemadd()
        Try
            Dim x As Integer
            Dim dtStyleProductInformation As DataTable = DirectCast(Session("dtStyleProductInformation"), DataTable)
            Dim dtBaseItem As New DataTable '= DirectCast(Session("dtStyleProductInformation"), DataTable)

            With dtBaseItem
                .Columns.Add("BaseItem", GetType(String))
            End With

            Dim item As String
            Dim newitem As String
            For x = 0 To dtStyleProductInformation.Rows.Count - 1
                item = dtStyleProductInformation.Rows(x)("RowNo")
                With dtBaseItem
                    Dr = dtBaseItem.NewRow()
                    Dr("BaseItem") = item
                    dtBaseItem.Rows.Add(Dr)
                End With
            Next

            cmbBaseItem.DataSource = dtBaseItem
            cmbBaseItem.DataTextField = "BaseItem"
            cmbBaseItem.DataValueField = "BaseItem"
            cmbBaseItem.DataBind()
            Dim count As Integer = 0
            count = dtBaseItem.Rows.Count
            cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
            UpcmbBaseItem.Update()
            Session("dtBaseItem") = dtBaseItem
        Catch ex As Exception

        End Try
    End Sub
    Sub BindcmbBaseItemForHomeTextile()
        Try
            Dim x As Integer
            Dim dtStyleProductInformation As DataTable = DirectCast(Session("dtStyleProductInformation"), DataTable)
            Dim dtBaseItem As New DataTable '= DirectCast(Session("dtStyleProductInformation"), DataTable)
            With dtBaseItem
                .Columns.Add("BaseItem", GetType(String))
            End With
            Dim item As String
            Dim newitem As String
            For x = 0 To dtStyleProductInformation.Rows.Count - 1
                item = dtStyleProductInformation.Rows(x)("Item")
                With dtBaseItem
                    If dtBaseItem.Rows.Count > 0 Then
                        Dim check As Integer = 0
                        For chk = 0 To dtBaseItem.Rows.Count - 1
                            If item = dtBaseItem.Rows(chk)("BaseItem") Then
                                check = 1
                            End If
                        Next
                        If check = 0 Then
                            Dr = dtBaseItem.NewRow()
                            Dr("BaseItem") = item
                            dtBaseItem.Rows.Add(Dr)
                        End If
                    Else
                        Dr = dtBaseItem.NewRow()
                        Dr("BaseItem") = item
                        dtBaseItem.Rows.Add(Dr)
                    End If
                End With
            Next

            cmbBaseItem.DataSource = dtBaseItem
            cmbBaseItem.DataTextField = "BaseItem"
            cmbBaseItem.DataValueField = "BaseItem"
            cmbBaseItem.DataBind()
            Dim count As Integer = 0
            count = dtBaseItem.Rows.Count

            cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
            UpcmbBaseItem.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddColor.Click
        Try
            'chking
            Dim FinalStatus As Decimal = 0
            If dgColor.Items.Count > 0 Then
                For x = 0 To dgColor.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgColor.MasterTableView.Items(x), GridDataItem)
                    If item("ColorRefNo").Text = txtColorRefNo.Text And item("Colorway").Text = txtColorway.Text And item("Colorway").Text = txtColorway.Text And item("SizeRange").Text = cmbSizeRange.SelectedItem.Text And item("Price").Text = txtPrice.Text Then
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
                    SaveSessionColor()
                    BindGridColor()
                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSessionColor()
                BindGridColor()
            End If
            'If cmbProductPortfolio.SelectedValue = 1 Then
            '    'dgColor.Columns("BaseRow").HeaderText = "Item"
            '    dgColor.MasterTableView.Columns(2).HeaderText = "Header Text"
            '    UpdatePanel9.Update()
            'Else
            '    'dgColor.Columns("BaseRow").HeaderText = "BaseRow"
            '    dgColor.MasterTableView.Columns(2).HeaderText = "BaseRow"
            '    UpdatePanel9.Update()
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionColor()
        If (Not CType(Session("dtStyle"), DataTable) Is Nothing) Then
            dtStyle = Session("dtStyle")
        Else
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
        End If

        Dim x As Integer
        Dim dtSize As DataTable = objPurchaseMaster.GetSizeRange11(cmbSizeRange.SelectedItem.Text)
        For x = 0 To dtSize.Rows.Count - 1
            Dr = dtStyle.NewRow()
            Dr("StyleID") = 0
            Dr("StyleDetailID") = 0
            Dr("ColorRefNo") = txtColorRefNo.Text
            Dr("Colorway") = txtColorway.Text
            Dr("SizeRange") = cmbSizeRange.SelectedItem.Text
            Dr("Sizes") = dtSize.Rows(x)("Sizes")
            Dr("Price") = Val(txtPrice.Text)
            Dr("PriceUnit") = cmbCurrency.SelectedItem.Text
            Dr("BaseRow") = cmbBaseItem.SelectedItem.Text
            dtStyle.Rows.Add(Dr)
        Next
        Session("dtStyle") = dtStyle
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
                .Columns.Add("SAID", GetType(Long))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("AccessoriesID", GetType(Long))
                .Columns.Add("AccessoriesName", GetType(String))
                .Columns.Add("AccessoriesDescription", GetType(String))
                .Columns.Add("Source", GetType(String))
            End With
        End If
        Dr = dtAccessories.NewRow()
        Dr("StyleID") = 0
        Dr("SAID") = 0
        Dr("AccessoriesID") = cmbAccessories.SelectedValue
        Dr("AccessoriesName") = cmbAccessories.SelectedItem.Text
        Dr("AccessoriesDescription") = txtAccessoriesDescription.Text
        Dr("Source") = cmbSource.SelectedItem.Text

        dtAccessories.Rows.Add(Dr)
        Session("dtAccessories") = dtAccessories
    End Sub
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
                    If Type = "Copy" Then
                        .StyleID = 0 'objStyleMaster.GetID()
                        astyleid = 0 'objStyleMaster.GetID()
                    Else
                        .StyleID = StyleID
                        astyleid = StyleID
                    End If
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
            If rbnSelect.SelectedValue = 1 Then
                If txtStyleNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No empty.")
                Else
                    savedata()
                End If
            Else
                If cmbStyleNoo.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style No ")
                Else
                    savedata()
                End If
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
        ElseIf dgColor.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Color Info. required.")
        ElseIf dgFileInfo.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Attachment required.")
        Else
            With objStyleMaster
                If StyleID > 0 Then
                    If Type = "Copy" Then
                        .StyleID = 0
                    Else
                        .StyleID = StyleID
                    End If
                Else
                    .StyleID = 0
                End If
                .CreationDate = Date.Now()

                If StyleID > 0 Then
                    If Type = "Copy" Then
                        If rbnSelect.SelectedValue = 0 Then
                            .StyleNo = cmbStyleNoo.SelectedItem.Text
                        Else
                            .StyleNo = txtStyleNo.Text
                        End If
                    Else
                        .StyleNo = txtStyleNo.Text
                    End If
                Else
                    If rbnSelect.SelectedValue = 0 Then
                        .StyleNo = cmbStyleNoo.SelectedItem.Text
                    Else
                        .StyleNo = txtStyleNo.Text
                    End If

                End If

                .CoreLine = cmbSpecialLine.SelectedItem.Text 'txtCoreLine.Text
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
                .RubbingFastnessWet = txtRubbingFastnessWet.Text
                .RubbingFastnessDry = txtRubbingFastnessDry.Text
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
                .Degree1ofColourID = cmbdegree1.SelectedValue
                .Degree2ofColourID = cmbdegree2.SelectedValue
                .Degree3ofColourID = cmbdegree3.SelectedValue
                .BleachingSymbolID = cmbBleachingSymbol.SelectedValue
                .IroningSymbolID = cmbIroningSymbol.SelectedValue
                .DryCleaningSymbolID = cmbDryCleaning.SelectedValue
                .TumbleDryID = cmbTumbleDry.SelectedValue
                .BuyerTechComments = txtBuyerTechComment.Text
                .SaveStyleMaster()
            End With

            'For Product Info
            Dim x As Integer
            For x = 0 To dgColor.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgColor.MasterTableView.Items(x), GridDataItem)

                With objStyleDetail
                    .StyleDetailID = item("StyleDetailID").Text
                    If StyleID > 0 Then
                        If Type = "Copy" Then
                            .StyleID = objStyleMaster.GetID()
                        Else
                            .StyleID = StyleID
                        End If

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

                Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
                Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
                Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
                Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)
                With objStyleProductInformation
                    .SproductID = dgProductinfo.Items(x).Cells(0).Text
                    If StyleID > 0 Then
                        If Type = "Copy" Then
                            .StyleID = objStyleMaster.GetID()
                        Else
                            .StyleID = StyleID
                        End If
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
                    .Lining = dgProductinfo.Items(x).Cells(22).Text
                    .LiningTypeID = cmbLiningType.SelectedValue
                    .LiningCons = txtLiningCons.Text
                    .LiningCompId = cmbLinigComp.SelectedValue
                    If txtLiningWt.Text = "" Then
                        .LiningWt = 0
                    Else
                        .LiningWt = txtLiningWt.Text
                    End If

                    .SaveStyleProductInformation()
                End With
            Next

            'For Assc.
            For x = 0 To dgAcces.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgAcces.MasterTableView.Items(x), GridDataItem)
                With objStyleAccessories
                    .SAID = item("SAID").Text
                    If StyleID > 0 Then
                        If Type = "Copy" Then
                            .StyleID = objStyleMaster.GetID()
                        Else
                            .StyleID = StyleID
                        End If

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
                If Type = "Copy" Then
                    a = objStyleMaster.GetID
                Else
                    a = StyleID
                End If
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
                            objStyleProductInformation.DeleteDetail(SproductID)
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
                            BindcmbBaseItemForHomeTextile()
                            SetPreviousData()

                            dtStyle.Rows.Clear()
                            'objStyleDetail.DeleteDetailall(StyleID)
                            dgColor.DataSource = Nothing
                            dgColor.DataBind()
                            If cmbProductPortfolio.SelectedValue = 1 Then
                                dgColor.Columns(2).HeaderText = "Item"
                            Else
                                dgColor.Columns(2).HeaderText = "BaseRow"
                            End If
                            UpdatePanel9.Update()
                        Else
                            dtStyleProductInformation.Rows.Clear()

                            dgProductinfo.DataSource = Nothing
                            dgProductinfo.DataBind()

                            dtStyle.Rows.Clear()
                            dgColor.DataSource = Nothing
                            dgColor.DataBind()
                            If cmbProductPortfolio.SelectedValue = 1 Then
                                dgColor.Columns(2).HeaderText = "Item"
                            Else
                                dgColor.Columns(2).HeaderText = "BaseRow"
                            End If
                            UpdatePanel9.Update()

                            cmbBaseItem.DataSource = Nothing
                            cmbBaseItem.DataBind()
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
    Sub EditMode()
        Try
            Dim dtMaster As DataTable = objStyleMaster.GetMaster(StyleID)
            If dtMaster.Rows.Count > 0 Then
                txtStyleNo.Text = dtMaster.Rows(0)("StyleNo")
                ' txtCoreLine.Text = dtMaster.Rows(0)("CoreLine")
                cmbSpecialLine.SelectedValue = dtMaster.Rows(0)("CoreLine")
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
                cmbdegree1.SelectedValue = dtMaster.Rows(0)("Degree1ofColourID")
                cmbdegree2.SelectedValue = dtMaster.Rows(0)("Degree2ofColourID")
                cmbdegree3.SelectedValue = dtMaster.Rows(0)("Degree3ofColourID")
                cmbBleachingSymbol.SelectedValue = dtMaster.Rows(0)("BleachingSymbolID")
                cmbIroningSymbol.SelectedValue = dtMaster.Rows(0)("IroningSymbolID")
                cmbDryCleaning.SelectedValue = dtMaster.Rows(0)("DryCleaningSymbolID")
                cmbTumbleDry.SelectedValue = dtMaster.Rows(0)("TumbleDryID")
                txtBuyerTechComment.Text = dtMaster.Rows(0)("BuyerTechComments")
            End If

            Dim dtPrduct As DataTable = objStyleMaster.GetProductNew(StyleID)

            If dtPrduct.Rows.Count > 0 Then
                dgProductinfo.DataSource = dtPrduct
                dgProductinfo.DataBind()
                dgProductinfo.Visible = True
                cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
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
                        UpUpbtnAutoComplete.Update()
                    Else
                        cmbLiningType.Visible = False
                        txtLiningCons.Visible = False
                        cmbLinigComp.Visible = False
                        txtLiningWt.Visible = False
                        UpUpbtnAutoComplete.Update()
                    End If

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
                Session("dtStyleProductInformation") = dtStyleProductInformation
                If cmbProductPortfolio.SelectedValue = 1 Then
                    lblpack.Visible = False
                    cmbPack.Visible = False
                    UpdatePanel6.Update()
                    Uplblpack.Update()
                    BindcmbBaseItemForHomeTextile()
                    lblitem.Text = "Item"
                    Uplblitem.Update()
                    btnAddMoreProduct.Visible = True
                Else
                    lblpack.Visible = True
                    cmbPack.Visible = True
                    btnAddMoreProduct.Visible = True
                    UpdatePanel6.Update()
                    Uplblpack.Update()
                    lblitem.Text = "Base Item"
                    Uplblitem.Update()

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
                    cmbBaseItem.DataSource = dtBaseItem
                    cmbBaseItem.DataTextField = "BaseItem"
                    cmbBaseItem.DataValueField = "BaseItem"
                    cmbBaseItem.DataBind()
                    Dim count As Integer = 0
                    count = dtBaseItem.Rows.Count
                    cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
                    UpcmbBaseItem.Update()
                    Session("dtBaseItem") = dtBaseItem
                End If

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
            ' If dtRealFile.Rows.Count > 0 Then
            'If (Not CType(Session("dtFile"), DataTable) Is Nothing) Then
            '    dtFile = Session("dtFile")
            'Else
            '    dtFile = New DataTable
            '    With dtFile
            '        .Columns.Add("TableID", GetType(Long))
            '        .Columns.Add("StyleID", GetType(Long))
            '        .Columns.Add("CreationDate", GetType(String))
            '        .Columns.Add("FileType", GetType(String))
            '        .Columns.Add("FileName", GetType(String))
            '    End With
            'End If
            'For x = 0 To dtRealFile.Rows.Count - 1
            '    Dr = dtFile.NewRow()
            '    Dr("TableID") = dtRealFile.Rows(x)("TableID")
            '    Dr("StyleID") = dtRealFile.Rows(x)("StyleID")
            '    Dr("CreationDate") = dtRealFile.Rows(x)("CreationDate")
            '    Dr("FileType") = dtRealFile.Rows(x)("FileType")
            '    Dr("FileName") = dtRealFile.Rows(x)("FileName")
            '    dtFile.Rows.Add(Dr)
            'Next
            'Session("dtFile") = dtFile

            'dgFileInfo.Visible = True
            'dgFileInfo.DataSource = dtFile
            'dgFileInfo.DataBind()


            'Dim objDataView1 As DataView
            'objDataView1 = LoadData12(StyleID)
            'Session("objDataView1") = objDataView1
            'BindGridFileInfo()


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
            ' End If

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
    Sub CopyMode()
        Try
            Dim dtMaster As DataTable = objStyleMaster.GetMaster(StyleID)
            If dtMaster.Rows.Count > 0 Then
                txtStyleNo.Text = dtMaster.Rows(0)("StyleNo")
                ' txtCoreLine.Text = dtMaster.Rows(0)("CoreLine")
                cmbSpecialLine.SelectedValue = dtMaster.Rows(0)("CoreLine")
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
                cmbdegree1.SelectedValue = dtMaster.Rows(0)("Degree1ofColourID")
                cmbdegree2.SelectedValue = dtMaster.Rows(0)("Degree2ofColourID")
                cmbdegree3.SelectedValue = dtMaster.Rows(0)("Degree3ofColourID")
                cmbBleachingSymbol.SelectedValue = dtMaster.Rows(0)("BleachingSymbolID")
                cmbIroningSymbol.SelectedValue = dtMaster.Rows(0)("IroningSymbolID")
                cmbDryCleaning.SelectedValue = dtMaster.Rows(0)("DryCleaningSymbolID")
                cmbTumbleDry.SelectedValue = dtMaster.Rows(0)("TumbleDryID")
                txtBuyerTechComment.Text = dtMaster.Rows(0)("BuyerTechComments")
            End If

            'Dim dtPrduct As DataTable = objStyleMaster.GetProductNew(StyleID)

            'If dtPrduct.Rows.Count > 0 Then
            '    dgProductinfo.DataSource = dtPrduct
            '    dgProductinfo.DataBind()
            '    dgProductinfo.Visible = True
            '    cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
            '    Dim dtProductCategories As DataTable
            '    dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            '    cmbProductCategory.DataSource = dtProductCategories
            '    cmbProductCategory.DataTextField = "ProductCategories"
            '    cmbProductCategory.DataValueField = "ProductCategoriesID"
            '    cmbProductCategory.DataBind()
            '    cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
            '    BindFabricType()
            '    BindFWtUnit()
            '    BindGarmentWtUnit()
            '    BindComposition()
            '    BindFabFinish()
            '    BindLinigType()


            '    dtStyleProductInformation = New DataTable
            '    With dtStyleProductInformation
            '        .Columns.Add("SproductID", GetType(String))
            '        .Columns.Add("RowNo", GetType(String))
            '        .Columns.Add("ProductPortfolioID", GetType(String))
            '        .Columns.Add("ProductCategoriesID", GetType(String))
            '        .Columns.Add("ProductConsumerID", GetType(String))
            '        .Columns.Add("Pack", GetType(String))
            '        .Columns.Add("Item", GetType(String))
            '        .Columns.Add("HSCode", GetType(String))
            '        .Columns.Add("FabicType", GetType(String))
            '        .Columns.Add("FabicCons", GetType(String))
            '        .Columns.Add("CompositionID", GetType(String))
            '        .Columns.Add("FabicWt", GetType(Decimal))
            '        .Columns.Add("FabicWtUnitID", GetType(String))
            '        .Columns.Add("GarmentWt", GetType(Decimal))
            '        .Columns.Add("GarmentWtUnitID", GetType(String))
            '        .Columns.Add("Color", GetType(String))
            '        .Columns.Add("Rremarks", GetType(String))
            '        .Columns.Add("FabicTypeID", GetType(String))
            '        .Columns.Add("FabFinishID", GetType(String))
            '        .Columns.Add("FabFinish", GetType(String))
            '        .Columns.Add("ProductConsumerGroup", GetType(String))
            '        .Columns.Add("Lining", GetType(String))
            '        .Columns.Add("LiningType", GetType(String))
            '        .Columns.Add("LiningTypeID", GetType(String))
            '        .Columns.Add("LiningCons", GetType(String))
            '        .Columns.Add("LiningCompID", GetType(String))
            '        .Columns.Add("LiningComposition", GetType(String))
            '        .Columns.Add("LiningWeight", GetType(String))
            '    End With

            '    For x = 0 To dtPrduct.Rows.Count - 1
            '        'Dim txtRow As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRow"), TextBox)
            '        'Dim txtPack As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtPack"), TextBox)
            '        'Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)

            '        Dim txtHSCode As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtHSCode"), TextBox)
            '        Dim txtFType As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFType"), TextBox)
            '        Dim txtFCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFCons"), TextBox)
            '        Dim cmbFComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFComp"), DropDownList)
            '        Dim txtFWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtFWt"), TextBox)
            '        Dim cmbFWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFWtUnit"), DropDownList)
            '        Dim txtGarmentWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtGarmentWt"), TextBox)
            '        Dim cmbGarmentWtUnit As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbGarmentWtUnit"), DropDownList)
            '        Dim txtColor As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtColor"), TextBox)
            '        Dim txtRemarks As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtRemarks"), TextBox)
            '        Dim cmbFabricType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabricType"), DropDownList)
            '        Dim cmbFabFinish As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbFabFinish"), DropDownList)
            '        Dim txtItem As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtItem"), TextBox)

            '        Dim cmbLiningType As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLiningType"), DropDownList)
            '        Dim txtLiningCons As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningCons"), TextBox)
            '        Dim cmbLinigComp As DropDownList = DirectCast(dgProductinfo.Items(x).FindControl("cmbLinigComp"), DropDownList)
            '        Dim txtLiningWt As TextBox = DirectCast(dgProductinfo.Items(x).FindControl("txtLiningWt"), TextBox)

            '        Dr = dtStyleProductInformation.NewRow()
            '        Dr("SproductID") = dtPrduct.Rows(x)("SproductID")
            '        Dr("RowNo") = dtPrduct.Rows(x)("RowNo")
            '        Dr("ProductPortfolioID") = dtPrduct.Rows(x)("ProductPortfolioID")
            '        Dr("ProductCategoriesID") = dtPrduct.Rows(x)("ProductCategoriesID")
            '        Dr("ProductConsumerID") = dtPrduct.Rows(x)("ProductConsumerID")
            '        Dr("Pack") = dtPrduct.Rows(x)("Pack")
            '        Dr("Item") = dtPrduct.Rows(x)("Item")
            '        Dr("HSCode") = dtPrduct.Rows(x)("HSCode")
            '        Dr("FabicType") = dtPrduct.Rows(x)("FabricType")
            '        Dr("FabicCons") = dtPrduct.Rows(x)("FabicCons")
            '        Dr("CompositionID") = dtPrduct.Rows(x)("CompositionID")
            '        Dr("FabicWt") = dtPrduct.Rows(x)("FabicWt")
            '        Dr("FabicWtUnitID") = dtPrduct.Rows(x)("FabicWtUnitID")
            '        Dr("GarmentWt") = dtPrduct.Rows(x)("GarmentWt")
            '        Dr("GarmentWtUnitID") = dtPrduct.Rows(x)("GarmentWtUnitID")
            '        Dr("Color") = dtPrduct.Rows(x)("Color")
            '        Dr("Rremarks") = dtPrduct.Rows(x)("Rremarks")
            '        Dr("FabicTypeID") = dtPrduct.Rows(x)("FabricTypeID")
            '        Dr("FabFinishID") = dtPrduct.Rows(x)("FabFinishID")
            '        Dr("FabFinish") = dtPrduct.Rows(x)("FabFinish")
            '        Dr("ProductConsumerGroup") = dtPrduct.Rows(x)("ProductConsumerName")
            '        Dr("Lining") = dtPrduct.Rows(x)("Lining")
            '        Dr("LiningTypeID") = dtPrduct.Rows(x)("LiningTypeID")
            '        Dr("LiningType") = dtPrduct.Rows(x)("LiningType")
            '        Dr("LiningCons") = dtPrduct.Rows(x)("LiningCons")
            '        Dr("LiningCompID") = dtPrduct.Rows(x)("LiningCompID")
            '        Dr("LiningComposition") = dtPrduct.Rows(x)("LiningComposition")
            '        Dr("LiningWeight") = dtPrduct.Rows(x)("LiningWt")
            '        dtStyleProductInformation.Rows.Add(Dr)


            '        txtHSCode.Text = dtPrduct.Rows(x)("HSCode")
            '        txtFCons.Text = dtPrduct.Rows(x)("FabicCons")
            '        cmbFComp.SelectedValue = dtPrduct.Rows(x)("CompositionID")
            '        txtFWt.Text = dtPrduct.Rows(x)("FabicWt")
            '        cmbFWtUnit.SelectedValue = dtPrduct.Rows(x)("FabicWtUnitID")
            '        txtGarmentWt.Text = dtPrduct.Rows(x)("GarmentWt")
            '        cmbGarmentWtUnit.SelectedValue = dtPrduct.Rows(x)("GarmentWtUnitID")
            '        txtColor.Text = dtPrduct.Rows(x)("Color")
            '        txtRemarks.Text = dtPrduct.Rows(x)("Rremarks")
            '        cmbFabricType.SelectedValue = dtPrduct.Rows(x)("FabricTypeID")
            '        cmbFabFinish.SelectedValue = dtPrduct.Rows(x)("FabFinishID")
            '        cmbLiningType.SelectedValue = dtPrduct.Rows(x)("LiningTypeID")
            '        txtLiningCons.Text = dtPrduct.Rows(x)("LiningCons")
            '        cmbLinigComp.SelectedValue = dtPrduct.Rows(x)("LiningCompID")
            '        txtLiningWt.Text = dtPrduct.Rows(x)("LiningWt")
            '        If cmbProductPortfolio.SelectedValue = 1 Then

            '            txtItem.ReadOnly = True
            '        Else

            '            txtItem.ReadOnly = False
            '        End If
            '        Dim Lining As String = dgProductinfo.Items(x).Cells(22).Text
            '        If Lining = "Y" Then
            '            cmbLiningType.Visible = True
            '            txtLiningCons.Visible = True
            '            cmbLinigComp.Visible = True
            '            txtLiningWt.Visible = True
            '            UpUpbtnAutoComplete.Update()
            '        Else
            '            cmbLiningType.Visible = False
            '            txtLiningCons.Visible = False
            '            cmbLinigComp.Visible = False
            '            txtLiningWt.Visible = False
            '            UpUpbtnAutoComplete.Update()
            '        End If

            '    Next

            '    '---new use nizam for Binding DD
            '    BindProductPortfolio()
            '    BindProductCategories()
            '    BindProductConsumer()
            '    cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
            '    cmbProductCategory.SelectedValue = dtPrduct.Rows(0)("ProductCategoriesID")
            '    cmbProductConsumerGrp.SelectedValue = dtPrduct.Rows(0)("ProductConsumerID")
            '    cmbPack.SelectedItem.Text = dtPrduct.Rows(0)("Pack")
            '    '-----end
            '    Session("dtStyleProductInformation") = dtStyleProductInformation
            '    If cmbProductPortfolio.SelectedValue = 1 Then
            '        lblpack.Visible = False
            '        cmbPack.Visible = False
            '        UpdatePanel6.Update()
            '        Uplblpack.Update()
            '        BindcmbBaseItemForHomeTextile()
            '        lblitem.Text = "Item"
            '        Uplblitem.Update()
            '        btnAddMoreProduct.Visible = True
            '    Else
            '        lblpack.Visible = True
            '        cmbPack.Visible = True
            '        UpdatePanel6.Update()
            '        Uplblpack.Update()
            '        lblitem.Text = "Base Item"
            '        Uplblitem.Update()

            '        Dim dtBaseItem As New DataTable
            '        With dtBaseItem
            '            .Columns.Add("BaseItem", GetType(String))
            '        End With

            '        For xx = 0 To dtPrduct.Rows.Count - 1
            '            With dtBaseItem
            '                Dr = dtBaseItem.NewRow()
            '                Dr("BaseItem") = dtPrduct.Rows(xx)("RowNo")
            '                dtBaseItem.Rows.Add(Dr)
            '            End With
            '        Next
            '        cmbBaseItem.DataSource = dtBaseItem
            '        cmbBaseItem.DataTextField = "BaseItem"
            '        cmbBaseItem.DataValueField = "BaseItem"
            '        cmbBaseItem.DataBind()
            '        Dim count As Integer = 0
            '        count = dtBaseItem.Rows.Count
            '        cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
            '        UpcmbBaseItem.Update()
            '    End If

            '    Dim dtColor As DataTable = objStyleMaster.GetColor(StyleID)
            '    If dtColor.Rows.Count > 0 Then

            '        dtStyle = New DataTable
            '        With dtStyle
            '            .Columns.Add("StyleID", GetType(Long))
            '            .Columns.Add("StyleDetailID", GetType(Long))
            '            .Columns.Add("ColorRefNo", GetType(String))
            '            .Columns.Add("Colorway", GetType(String))
            '            .Columns.Add("SizeRange", GetType(String))
            '            .Columns.Add("Sizes", GetType(String))
            '            .Columns.Add("Price", GetType(String))
            '            .Columns.Add("PriceUnit", GetType(String))
            '            .Columns.Add("BaseRow", GetType(String))
            '        End With

            '        For x = 0 To dtColor.Rows.Count - 1
            '            Dr = dtStyle.NewRow()
            '            Dr("StyleID") = dtColor.Rows(x)("StyleID")
            '            Dr("StyleDetailID") = dtColor.Rows(x)("StyleDetailID")
            '            Dr("ColorRefNo") = dtColor.Rows(x)("ColorRefNo")
            '            Dr("Colorway") = dtColor.Rows(x)("Colorway")
            '            Dr("SizeRange") = dtColor.Rows(x)("SizeRange")
            '            Dr("Sizes") = dtColor.Rows(x)("Sizes")
            '            Dr("Price") = dtColor.Rows(x)("Price")
            '            Dr("PriceUnit") = dtColor.Rows(x)("PriceUnit")
            '            Dr("BaseRow") = dtColor.Rows(x)("BaseRow")
            '            dtStyle.Rows.Add(Dr)
            '        Next
            '        Session("dtStyle") = dtStyle
            '        BindGridColor()


            '    End If

            '    btnHide.Visible = True

            '    Dim dtAssc As DataTable = objStyleMaster.GetAccess(StyleID)
            '    If dtAssc.Rows.Count > 0 Then

            '        dtAccessories = New DataTable
            '        With dtAccessories
            '            .Columns.Add("SAID", GetType(Long))
            '            .Columns.Add("StyleID", GetType(Long))
            '            .Columns.Add("AccessoriesID", GetType(Long))
            '            .Columns.Add("AccessoriesName", GetType(String))
            '            .Columns.Add("AccessoriesDescription", GetType(String))
            '            .Columns.Add("Source", GetType(String))
            '        End With

            '        For x = 0 To dtAssc.Rows.Count - 1
            '            Dr = dtAccessories.NewRow()
            '            Dr("StyleID") = dtAssc.Rows(x)("StyleID")
            '            Dr("SAID") = dtAssc.Rows(x)("SAID")
            '            Dr("AccessoriesID") = dtAssc.Rows(x)("AccessoriesID")
            '            Dr("AccessoriesName") = dtAssc.Rows(x)("AccessoriesName")
            '            Dr("AccessoriesDescription") = dtAssc.Rows(x)("AccessoriesDescription")
            '            Dr("Source") = dtAssc.Rows(x)("Source")
            '            dtAccessories.Rows.Add(Dr)
            '        Next
            '        Session("dtAccessories") = dtAccessories
            '        BindGridAcces()
            '    End If
            'End If

            'Show file in grid

            Dim dtRealFile As DataTable = objStyleUploads.GetFileInfo(StyleID)
            ' If dtRealFile.Rows.Count > 0 Then
            'If (Not CType(Session("dtFile"), DataTable) Is Nothing) Then
            '    dtFile = Session("dtFile")
            'Else
            '    dtFile = New DataTable
            '    With dtFile
            '        .Columns.Add("TableID", GetType(Long))
            '        .Columns.Add("StyleID", GetType(Long))
            '        .Columns.Add("CreationDate", GetType(String))
            '        .Columns.Add("FileType", GetType(String))
            '        .Columns.Add("FileName", GetType(String))
            '    End With
            'End If
            'For x = 0 To dtRealFile.Rows.Count - 1
            '    Dr = dtFile.NewRow()
            '    Dr("TableID") = dtRealFile.Rows(x)("TableID")
            '    Dr("StyleID") = dtRealFile.Rows(x)("StyleID")
            '    Dr("CreationDate") = dtRealFile.Rows(x)("CreationDate")
            '    Dr("FileType") = dtRealFile.Rows(x)("FileType")
            '    Dr("FileName") = dtRealFile.Rows(x)("FileName")
            '    dtFile.Rows.Add(Dr)
            'Next
            'Session("dtFile") = dtFile

            'dgFileInfo.Visible = True
            'dgFileInfo.DataSource = dtFile
            'dgFileInfo.DataBind()


            'Dim objDataView1 As DataView
            'objDataView1 = LoadData12(StyleID)
            'Session("objDataView1") = objDataView1
            'BindGridFileInfo()


            'Session("dtFile") = dtRealFile
            'Dim objDataView As DataView
            'objDataView = New DataView(dtRealFile)
            'If objDataView.Count > 0 Then
            '    dgFileInfo.Visible = True
            '    dgFileInfo.RecordCount = objDataView.Count
            '    dgFileInfo.DataSource = objDataView
            '    dgFileInfo.DataBind()
            '    btnSave.Enabled = True
            'Else
            '    btnSave.Enabled = False
            '    dgFileInfo.Visible = False
            'End If
            '' End If

            'dtt = objDataView.ToTable
            'Dim y As Integer = 0
            'For y = 0 To dgFileInfo.Items.Count - 1
            '    Dim Image1 As Image = DirectCast(dgFileInfo.Items(y).FindControl("Image1"), Image)
            '    Dim Picstype As String = dgFileInfo.Items(y).Cells(3).Text
            '    Dim bytes As Byte() = DirectCast(dtt.Rows(y)("UploadPicture"), Byte())
            '    Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
            '    Image1.ImageUrl = "data:image/png;base64," & base64String
            '    If Picstype = "Picture" Then
            '        imgExtra.ImageUrl = "data:image/png;base64," & base64String
            '        imgExtra.Visible = True
            '        Image1.Visible = True
            '    Else
            '        Image1.Visible = False
            '    End If
            'Next

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
    'Protected Sub dgAcces_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgAcces.ItemCommand
    '    Select Case e.CommandName
    '        Case "Delete"
    '            dtAccessories = CType(Session("dtAccessories"), DataTable)
    '            If (Not dtAccessories Is Nothing) Then
    '                If (dtAccessories.Rows.Count > 0) Then
    '                    Dim SAID As Long = dgAcces.Items(e.Item.ItemIndex).Cells(0).Text
    '                    Dim StyleID As Long = dgAcces.Items(e.Item.ItemIndex).Cells(1).Text
    '                    dtAccessories.Rows.RemoveAt(e.Item.ItemIndex)
    '                    objStyleAccessories.DeleteDetailFromStyleAccessDetail(SAID, StyleID)
    '                    Session("dtAccessories") = dtAccessories
    '                    BindGridAcces()
    '                    If dtAccessories.Rows.Count = 0 Then
    '                        dgAcces.Controls.Clear()
    '                        dgAcces.Visible = False

    '                    End If

    '                Else
    '                    dgAcces.Visible = False
    '                End If
    '            End If
    '    End Select
    'End Sub
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

    Protected Sub cmbStyleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStyleNoo.SelectedIndexChanged
        Try
            txtCoreLine.Text = cmbStyleNoo.SelectedItem.Text
            UpCoreLine.Update()
            Dim dt As DataTable = objPurchaseMaster.getInquirystyledata(cmbStyleNoo.SelectedValue)
            If dt.Rows.Count > 0 Then
                cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
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
                '---Bind BuyingDept 
                cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
                cmbBuyingDept.DataValueField = "departmentno"
                cmbBuyingDept.DataTextField = "departmentno"
                cmbBuyingDept.DataBind()

                cmbBuyerName.SelectedValue = dt.Rows(0)("BuyerName")
                UpdatecmbBuyerName.Update()
                cmbSeason.SelectedValue = dt.Rows(0)("SeasonID")
                UpcmbSeason.Update()
                UpcmbBrand.Update()
                cmbBrand.SelectedValue = dt.Rows(0)("BrandName")
                cmbBuyingDept.SelectedValue = dt.Rows(0)("BuyingDept")
                UpcmbBuyingDept.Update()
                cmbStyleSource.SelectedItem.Text = dt.Rows(0)("StyleSource")
                UpdatePanel3.Update()
                txtStyleDescription.Text = dt.Rows(0)("StyleDescription")
                UptxtStyleDescription.Update()
                UptxtStyleDescription.Update()
                GetInquiryDetail()
                UpUpbtnAutoComplete.Update()
                'cmbProductConsumerGrp.SelectedValue = dt.Rows(0)("ProductConsumerID")
                'UpdatePanel12.Update()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub GetInquiryDetail()
        Dim dtPrduct As DataTable = objStyleMaster.GetInquiryProduct(cmbStyleNoo.SelectedValue)

        If dtPrduct.Rows.Count > 0 Then
            dgProductinfo.DataSource = dtPrduct
            dgProductinfo.DataBind()
            dgProductinfo.Visible = True
            cmbProductPortfolio.SelectedValue = dtPrduct.Rows(0)("ProductPortfolioID")
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
                Dr("SproductID") = 0 'dtPrduct.Rows(x)("SproductID")
                Dr("RowNo") = dtPrduct.Rows(x)("RowNo")
                Dr("ProductPortfolioID") = dtPrduct.Rows(x)("ProductPortfolioID")
                Dr("ProductCategoriesID") = dtPrduct.Rows(x)("ProductCategoriesID")
                Dr("ProductConsumerID") = dtPrduct.Rows(x)("ProductConsumerID")
                Dr("Pack") = dtPrduct.Rows(x)("Pack")
                Dr("Item") = dtPrduct.Rows(x)("Item")
                Dr("HSCode") = dtPrduct.Rows(x)("HSCode")
                Dr("FabicType") = dtPrduct.Rows(x)("FabricType")
                Dr("FabicCons") = dtPrduct.Rows(x)("FConstruction")
                Dr("CompositionID") = dtPrduct.Rows(x)("Compid")
                Dr("FabicWt") = dtPrduct.Rows(x)("FWT")
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
                txtFCons.Text = dtPrduct.Rows(x)("FConstruction")
                cmbFComp.SelectedValue = dtPrduct.Rows(x)("Compid")
                txtFWt.Text = dtPrduct.Rows(x)("FWT")
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
                    UpUpbtnAutoComplete.Update()
                Else
                    cmbLiningType.Visible = False
                    txtLiningCons.Visible = False
                    cmbLinigComp.Visible = False
                    txtLiningWt.Visible = False
                    UpUpbtnAutoComplete.Update()
                End If

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
            Session("dtStyleProductInformation") = dtStyleProductInformation
            If cmbProductPortfolio.SelectedValue = 1 Then
                lblpack.Visible = False
                cmbPack.Visible = False
                UpdatePanel6.Update()
                Uplblpack.Update()
                BindcmbBaseItemForHomeTextile()
                lblitem.Text = "Item"
                Uplblitem.Update()
                btnAddMoreProduct.Visible = True
            Else
                lblpack.Visible = True
                cmbPack.Visible = True
                btnAddMoreProduct.Visible = True
                UpdatePanel6.Update()
                Uplblpack.Update()
                lblitem.Text = "Base Item"
                Uplblitem.Update()

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
                cmbBaseItem.DataSource = dtBaseItem
                cmbBaseItem.DataTextField = "BaseItem"
                cmbBaseItem.DataValueField = "BaseItem"
                cmbBaseItem.DataBind()
                Dim count As Integer = 0
                count = dtBaseItem.Rows.Count
                cmbBaseItem.Items.Insert((count), New ListItem("All", (count)))
                UpcmbBaseItem.Update()
                Session("dtBaseItem") = dtBaseItem
            End If
        End If
    End Sub
    Protected Sub rbnSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbnSelect.SelectedIndexChanged
        Try
            If rbnSelect.SelectedValue = 0 Then
                txtStyleNo.Visible = False
                cmbStyleNoo.Visible = True
                UpStyleNo.Update()
            Else
                txtStyleNo.Visible = True
                cmbStyleNoo.Visible = False
                UpStyleNo.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class

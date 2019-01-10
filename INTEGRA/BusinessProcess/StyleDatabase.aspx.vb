Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class StyleDatabase
    Inherits System.Web.UI.Page
    Dim objStyleMaster As New StyleMaster2
    Dim objStyleDetail As New StyleDetail
    Dim objCustomer As New CustomerDatabase
    Dim StyleID As Long
    Dim LastStyleID As Long
    Dim dtStyle As New DataTable
    Dim dtArticleDetail As DataTable
    Dim Dr As DataRow
    Dim objPurchaseMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("lStyleID")
        If Not Page.IsPostBack Then
            BindCustomer()

            BindProductPortfolio()
            BindProductGroup()
            BindProcessType()

            If StyleID > 0 Then
                SetValuesEditMod()
                Dim selectedIndex As Integer = RadPanelBar1.SelectedItem.Index
                RadPanelBar1.Items(selectedIndex + 1).Enabled = True
                Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
                Dim btnSave As RadButton = DirectCast(StyleInformationItem.FindControl("btnSave"), RadButton)
                btnSave.Text = "Update"
            Else
                Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
                Dim btnSave As RadButton = DirectCast(StyleInformationItem.FindControl("btnSave"), RadButton)
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BindProductPortfolio()
        Try
            Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
            Dim cmbProductPortfolio As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductPortfolio"), DropDownList)
            Dim cmbProductCategroy As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductCategroy"), DropDownList)
            Dim cmbProductGroup As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductGroup"), DropDownList)
 
            Dim dtProductPortfolio As DataTable
            dtProductPortfolio = objPurchaseMaster.GetAllProductPortfolio
            cmbProductPortfolio.DataSource = dtProductPortfolio
            cmbProductPortfolio.DataTextField = "ProductPortfolio"
            cmbProductPortfolio.DataValueField = "ProductPortfolioID"
            cmbProductPortfolio.DataBind()

            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductPortfolio.SelectedValue)
            cmbProductCategroy.DataSource = dtProductCategories
            cmbProductCategroy.DataTextField = "ProductCategories"
            cmbProductCategroy.DataValueField = "ProductCategoriesID"
            cmbProductCategroy.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductGroup()
        Try
            Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
            Dim cmbProductPortfolio As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductPortfolio"), DropDownList)
            Dim cmbProductCategroy As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductCategroy"), DropDownList)
            Dim cmbProductGroup As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductGroup"), DropDownList)

            Dim UpdatePanel5 As UpdatePanel = DirectCast(StyleInformationItem.FindControl("UpdatePanel5"), UpdatePanel)

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
        Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
        Dim cmbProcessType As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProcessType"), DropDownList)
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
    Protected Sub cmbProductPortfolio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
            Dim cmbProductPortfolio As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductPortfolio"), DropDownList)
            Dim cmbProductCategroy As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductCategroy"), DropDownList)
            Dim cmbProductGroup As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductGroup"), DropDownList)

            Dim updProductCategroy As UpdatePanel = DirectCast(StyleInformationItem.FindControl("updProductCategroy"), UpdatePanel)

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

            End If
            updProductCategroy.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
        Dim btnSave As RadButton = DirectCast(StyleInformationItem.FindControl("btnSave"), RadButton)
        Dim btnCancel As RadButton = DirectCast(StyleInformationItem.FindControl("btnCancelStyle"), RadButton)
        Try
            If btnSave.Text = "Update" Then
                SaveMaster()
                Session("dtStyle") = Nothing
            Else
                StyleID = 0
                SaveMaster()
                Session("dtStyle") = Nothing
                Session("StyleID") = objStyleMaster.GetID()
                GoToNextItem()
                btnSave.Visible = False
                btnCancel.Visible = False
            End If

            ''For Style Sampling
            'Dim IIStyleID As Long
            'If StyleID > 0 Then
            '    IIStyleID = StyleID
            'Else
            '    IIStyleID = objStyleMaster.GetID
            'End If
            'Dim ObjSampleTNAChart As New SampleTNAChart
            'Dim dtcheck As DataTable = ObjSampleTNAChart.CheckExisting(IIStyleID)
            'If dtcheck.Rows.Count > 0 Then
            '    'Already Chart Exist
            'Else
            '    GenrateSamplingTNAChart(IIStyleID)
            'End If
            ''End of Sampling

        Catch ex As Exception
        End Try
    End Sub
    Sub GenrateSamplingTNAChart(ByVal IIStyleID As Long)
        Dim Dtprocess As DataTable
        Dim ObjSampleTNAChart As New SampleTNAChart
        Dim ObjSampleTNAChartHistory As New SampleTNAChartHistory
        Dim x As Integer
        Dim ObjUMUser As New User
        Dtprocess = ObjSampleTNAChart.GetScheduleNew()
        For x = 0 To Dtprocess.Rows.Count - 1
            With ObjSampleTNAChart
                .IdealDate = AddDate(Dtprocess.Rows(x)("SchedularTime"), Date.Now)
                .ActualDate = AddDate(Dtprocess.Rows(x)("SchedularTime"), Date.Now)
                .DateEstemated = AddDate(Dtprocess.Rows(x)("SchedularTime"), Date.Now)
                .StyleID = IIStyleID
                .Remarks = " "
                .Status = "Created"
                .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                .Selected = True
                .SelectedStatus = "UNSELECT"
                .CreationDate = Date.Now
                .Submission = "--"
                .SaveSampleTNAChart()
            End With
            '---------- Save into Chat History
            With ObjSampleTNAChartHistory
                .CreationDate = Date.Now
                .SampleTNAChartID = ObjSampleTNAChart.GetID
                .IdealDate = ObjSampleTNAChart.IdealDate
                .DateEstemated = ObjSampleTNAChart.DateEstemated
                .ActualDate = ObjSampleTNAChart.ActualDate
                .Remarks = " "
                .Status = "Created"
                .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                .Submission = "--"
                .SaveSampleTNAChartHistory()
            End With
        Next
    End Sub
    Function AddDate(ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        dt = DateAddin.AddDays(Days)
        Return dt
    End Function
    Sub SaveMaster()
        Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)

        Dim txtstyleNo As RadTextBox = DirectCast(StyleInformationItem.FindControl("txtstyleNo"), RadTextBox)
        Dim txtstyleName As RadTextBox = DirectCast(StyleInformationItem.FindControl("txtstyleName"), RadTextBox)
        Dim cmbBuyer As RadComboBox = DirectCast(StyleInformationItem.FindControl("cmbBuyer"), RadComboBox)

        Dim cmbProductPortfolio As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductPortfolio"), DropDownList)
        Dim cmbProductCategroy As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductCategroy"), DropDownList)
        Dim cmbProductGroup As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductGroup"), DropDownList)
        Dim txtBlend As TextBox = DirectCast(StyleInformationItem.FindControl("txtBlend"), TextBox)
        Dim txtGSM As TextBox = DirectCast(StyleInformationItem.FindControl("txtGSM"), TextBox)
        Dim cmbProcessType As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProcessType"), DropDownList)
        Dim cmbComposition As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbComposition"), DropDownList)

        With objStyleMaster
            If StyleID > 0 Then
                .StyleID = StyleID
                
            Else
                .StyleID = 0
            End If

            .StyleNo = txtstyleNo.Text
            .StyleName = txtstyleName.Text
            .Buyer = cmbBuyer.SelectedValue
            .CreationDate = Date.Now()
            .IsActive = True
            .MarchandID = CLng(Session("UserID"))
            .MaterialComposition = ""
            .ProductGroup = cmbProductGroup.SelectedItem.Text
            .Season = ""
            .Sketch = "Pending"

            .ProductPortfolio = cmbProductPortfolio.SelectedItem.Text
            .ProductCategories = cmbProductCategroy.SelectedItem.Text
            .Blend = txtBlend.Text
            .GSM = txtGSM.Text
            .ProcessType = cmbProcessType.SelectedItem.Text
            .Composition = cmbComposition.SelectedItem.Text

            .SaveStyleMaster()
        End With
    End Sub
    Private Sub GoToNextItem()
        Dim selectedIndex As Integer = RadPanelBar1.SelectedItem.Index
        RadPanelBar1.Items(selectedIndex + 1).Selected = True
        RadPanelBar1.Items(selectedIndex + 1).Expanded = True
        RadPanelBar1.Items(selectedIndex + 1).Enabled = True
        RadPanelBar1.Items(selectedIndex).Expanded = False
    End Sub
    Private Sub BindArticleGrid()
        Try
            Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
            Dim dgArticle As RadGrid = DirectCast(ArticleformationItem.FindControl("dgArticle"), RadGrid)
            Dim objDatatble As DataTable
            objDatatble = Session("dtArticleDetail")
            If objDatatble.Rows.Count > 0 Then
                dgArticle.Visible = True
                dgArticle.VirtualItemCount = objDatatble.Rows.Count
                dgArticle.DataSource = objDatatble
                dgArticle.DataBind()

            Else
                dgArticle.Visible = False
            End If
            'Session.Clear()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub RadAjaxPanel1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles RadAjaxPanel1.Load

    End Sub
    Private Sub BindCustomer()
        Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)
        Dim cmbBuyer As RadComboBox = DirectCast(StyleInformationItem.FindControl("cmbBuyer"), RadComboBox)

        cmbBuyer.DataSource = objStyleMaster.GetFilterComboValues
        cmbBuyer.DataValueField = "CustomerID"
        cmbBuyer.DataTextField = "CustomerName"
        cmbBuyer.DataBind()
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

            End With
        End If
        Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
        Dim txtArticle As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticle"), RadTextBox)
        Dim txtArticleDescription As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticleDescription"), RadTextBox)
        Dim txtColorway As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtColorway"), RadTextBox)
        Dim txtSizeRange As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtSizeRange"), RadTextBox)
        Dim txtPrice As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtPrice"), RadTextBox)
        Dr = dtStyle.NewRow()
        Dr("StyleID") = 0
        Dr("StyleDetailID") = 0
        Dr("Article") = txtArticle.Text
        Dr("ArticleDescription") = txtArticleDescription.Text
        Dr("Colorway") = txtColorway.Text
        Dr("SizeRange") = txtSizeRange.Text
        Dr("Price") = txtPrice.Text

        dtStyle.Rows.Add(Dr)
        Session("dtStyle") = dtStyle
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'chking
            Dim FinalStatus As Decimal = 0
            Dim x As Integer
            Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
            Dim dgArticle As RadGrid = DirectCast(ArticleformationItem.FindControl("dgArticle"), RadGrid)
            Dim txtArticle As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticle"), RadTextBox)
            Dim txtArticleDescription As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticleDescription"), RadTextBox)
            Dim txtColorway As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtColorway"), RadTextBox)
            Dim txtSizeRange As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtSizeRange"), RadTextBox)
            Dim txtPrice As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtPrice"), RadTextBox)
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
        
            ' BindArticleGrid()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSaveArticle_Click(ByVal sender As Object, ByVal e As EventArgs)
        SaveDetail()
        ClearArticleFields()
        HttpContext.Current.Response.Redirect("~/BusinessProcess/StyleView.aspx")
    End Sub
    Sub SaveDetail()
        Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
        Dim dgArticle As RadGrid = DirectCast(ArticleformationItem.FindControl("dgArticle"), RadGrid)
        Dim x As Integer
        Dim StyleDetailID As Integer = 0
        For x = 0 To dgArticle.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgArticle.MasterTableView.Items(x), GridDataItem)

            With objStyleDetail
                .StyleDetailID = item("StyleDetailID").Text
                If StyleID > 0 Then
                    .StyleID = StyleID
                Else
                    .StyleID = CLng(Session("StyleID"))
                End If

                .CreationDate = Date.Now()
                .Article = item("Article").Text
                .ArticleDescription = item("ArticleDescription").Text
                .Colorway = item("Colorway").Text
                .SizeRange = item("SizeRange").Text
                .Price = item("Price").Text
                .Remarks = ""
                .SaveStyleDetail()
            End With
        Next
    End Sub
    Protected Sub btnCancelStyle_Click(ByVal sender As Object, ByVal e As EventArgs)
        HttpContext.Current.Response.Redirect("~/BusinessProcess/StyleView.aspx")
    End Sub
    Protected Sub btnCancelArticle_Click(ByVal sender As Object, ByVal e As EventArgs)
        HttpContext.Current.Response.Redirect("~/BusinessProcess/StyleView.aspx")
    End Sub
    Sub ClearArticleFields()
        Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
        Dim txtArticle As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticle"), RadTextBox)
        Dim txtArticleDescription As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtArticleDescription"), RadTextBox)
        Dim txtColorway As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtColorway"), RadTextBox)
        Dim txtSizeRange As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtSizeRange"), RadTextBox)
        Dim txtPrice As RadTextBox = DirectCast(ArticleformationItem.FindControl("txtPrice"), RadTextBox)
        txtArticle.Text = ""
        txtArticleDescription.Text = ""
        txtColorway.Text = ""
        txtPrice.Text = ""
        txtSizeRange.Text = ""
    End Sub
    Sub SetValuesEditMod()
        Dim Dt As DataTable
        Dim DtStyleMaster As DataTable
        Dim x As Integer
        Dim StyleInformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("StyleInformation"), RadPanelItem)

        Dim txtstyleNo As RadTextBox = DirectCast(StyleInformationItem.FindControl("txtstyleNo"), RadTextBox)
        Dim txtstyleName As RadTextBox = DirectCast(StyleInformationItem.FindControl("txtstyleName"), RadTextBox)
        Dim cmbBuyer As RadComboBox = DirectCast(StyleInformationItem.FindControl("cmbBuyer"), RadComboBox)
        Dim cmbProductPortfolio As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductPortfolio"), DropDownList)
        Dim cmbProductCategroy As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductCategroy"), DropDownList)
        Dim cmbProductGroup As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProductGroup"), DropDownList)
        Dim txtBlend As TextBox = DirectCast(StyleInformationItem.FindControl("txtBlend"), TextBox)
        Dim txtGSM As TextBox = DirectCast(StyleInformationItem.FindControl("txtGSM"), TextBox)
        Dim cmbProcessType As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbProcessType"), DropDownList)
        Dim cmbComposition As DropDownList = DirectCast(StyleInformationItem.FindControl("cmbComposition"), DropDownList)
        Dim updProductCategroy As UpdatePanel = DirectCast(StyleInformationItem.FindControl("updProductCategroy"), UpdatePanel)
        Try
            Dt = objStyleMaster.GetStyleByStyelID(StyleID)
            DtStyleMaster = objStyleMaster.GetStyleMasterByStyelID(StyleID)
            txtstyleNo.Text = DtStyleMaster.Rows(0)("StyleNo")

            If String.IsNullOrEmpty(DtStyleMaster.Rows(0)("StyleName").ToString()) = False Then
                txtstyleName.Text = DtStyleMaster.Rows(0)("StyleName")
            Else
                txtstyleName.Text = ""
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
            If Dt.Rows(0)("Composition").ToString() = "CMIA" Then
                cmbComposition.SelectedIndex = 0
            ElseIf Dt.Rows(0)("Composition").ToString() = "Oragnic" Then
                cmbComposition.SelectedIndex = 1
            ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Cotton" Then
                cmbComposition.SelectedIndex = 2
            ElseIf Dt.Rows(0)("Composition").ToString() = "Cotton Polyester" Then
                cmbComposition.SelectedIndex = 3
            ElseIf Dt.Rows(0)("Composition").ToString() = "Polystic Cotton" Then
                cmbComposition.SelectedIndex = 4
            ElseIf Dt.Rows(0)("Composition").ToString() = "Tensil" Then
                cmbComposition.SelectedIndex = 5
            ElseIf Dt.Rows(0)("Composition").ToString() = "Bambu" Then
                cmbComposition.SelectedIndex = 6
            ElseIf Dt.Rows(0)("Composition").ToString() = "Micro Fibric" Then
                cmbComposition.SelectedIndex = 7
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Cotton" Then
                cmbComposition.SelectedIndex = 8
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Polyester" Then
                cmbComposition.SelectedIndex = 9
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Elastine" Then
                cmbComposition.SelectedIndex = 10
            ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Polyester" Then
                cmbComposition.SelectedIndex = 11
            ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Cow/Buffalo" Then
                cmbComposition.SelectedIndex = 12
            ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Sheep" Then
                cmbComposition.SelectedIndex = 13
            ElseIf Dt.Rows(0)("Composition").ToString() = "Others" Then
                cmbComposition.SelectedIndex = 14
            Else
                cmbComposition.SelectedIndex = 0
            End If

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
                dtStyle.Rows.Add(Dr)
            Next
            Session("dtStyle") = dtStyle
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    Private Function BindGrid() As Boolean
        Dim ArticleformationItem As RadPanelItem = DirectCast(RadPanelBar1.FindItemByValue("ArticleInformation"), RadPanelItem)
        Dim dgArticle As RadGrid = DirectCast(ArticleformationItem.FindControl("dgArticle"), RadGrid)
        If (Not dtStyle Is Nothing) Then
            If (dtStyle.Rows.Count > 0) Then

                dgArticle.DataSource = dtStyle
                'dgArticle.RecordCount = dtStyle.Rows.Count
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
End Class
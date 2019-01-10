Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ProductCategoriesEntry
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objProductCategories As New ProductCategories
    Dim lProductCategoriesID As Long
    Dim Dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lProductCategoriesID = Request.QueryString("lProductCategoriesID")
        If Not Page.IsPostBack Then
            BindProductGroup()
            If lProductCategoriesID > 0 Then
                btnSave.Text = "Update"
                SetValuesEditMod()
            Else
                btnSave.Text = "Save"
            End If


            PageHeader("Product Categories Entry Form")

        End If
    End Sub
    Sub SetValuesEditMod()
        Try
            Dt = objProductCategories.GetEditProductCategoriesEntry(lProductCategoriesID)
            txtProductCategories.Text = Dt.Rows(0)("ProductCategories")
            cmbProductGroup.SelectedValue = Dt.Rows(0)("ProductPortfolioID")


        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindProductGroup()
        Dim dtProductPortfolio As DataTable
        dtProductPortfolio = objPurchaseMaster.GetAllProductPortfolio
        cmbProductGroup.DataSource = dtProductPortfolio
        cmbProductGroup.DataTextField = "ProductPortfolio"
        cmbProductGroup.DataValueField = "ProductPortfolioID"
        cmbProductGroup.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtProductCategories.Text = "" Then
                lblMsg.Text = "Empty Not Allow"
            Else
                Dim dtCheck As DataTable
                dtCheck = objProductCategories.GetExistProductCategories(txtProductCategories.Text, cmbProductGroup.SelectedValue)
                If lProductCategoriesID > 0 Then
                    With objProductCategories
                        If lProductCategoriesID > 0 Then

                            .ProductCategoriesID = lProductCategoriesID
                        Else
                            .ProductCategoriesID = 0
                        End If

                        .ProductPortfolioID = cmbProductGroup.SelectedValue
                        .ProductCategories = txtProductCategories.Text
                        .IsActive = True
                        .SaveProductCategories()
                    End With
                    Response.Redirect("ProductCategoriesView.aspx")
                    lblMsg.Text = ""
                Else
                    If dtCheck.Rows.Count > 0 Then
                        lblMsg.Text = "Already Exist"
                    Else
                        With objProductCategories
                            If lProductCategoriesID > 0 Then
                                .ProductCategoriesID = lProductCategoriesID
                            Else
                                .ProductCategoriesID = 0
                            End If

                            .ProductPortfolioID = cmbProductGroup.SelectedValue
                            .ProductCategories = txtProductCategories.Text
                            .IsActive = True
                            .SaveProductCategories()
                        End With
                        Response.Redirect("ProductCategoriesView.aspx")
                        lblMsg.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ProductCategoriesView.aspx")
    End Sub
End Class
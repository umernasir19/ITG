Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class CostingCenter
    Inherits System.Web.UI.Page
    Dim ObjCostCenter As New CostCenter
    Dim CostCenterID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CostCenterID = Request.QueryString("CostCenterID")
        If Not Page.IsPostBack Then
            BindCategory()
            If CostCenterID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable
            dt = ObjCostCenter.Edit(CostCenterID)
            txtCost.Text = dt.Rows(0)("Cost")
            cmbCategory.SelectedItem.Text = dt.Rows(0)("Category")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCategory()
        Dim dt As DataTable
        dt = ObjCostCenter.GetCategory()
        cmbCategory.DataSource = dt
        cmbCategory.DataTextField = "Category"
        cmbCategory.DataValueField = "Categoryid"
        cmbCategory.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtCost.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cost Center Empty.")
            ElseIf cmbCategory.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Category.")
            Else

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                With ObjCostCenter
                    If CostCenterID > 0 Then
                        .CostCenterID = CostCenterID
                    Else
                        .CostCenterID = 0
                    End If
                    .CategoryID = cmbCategory.SelectedValue

                    .Cost = txtCost.Text
                    .SaveCost()
                    Response.Redirect("CostCenterView.aspx")
                End With

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("CostCenterView.aspx")
    End Sub
End Class

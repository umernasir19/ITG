Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls.WebParts
Public Class ProductionLineStatusView
    Inherits System.Web.UI.Page
    Dim objProductionLineStatus As New ProductionLineStatus
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objProductionStatusView") = objDataView
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objProductionStatusView")
            dgProductionStatus.DataSource = objDataView
            dgProductionStatus.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objProductionLineStatus.GetProductionStatusView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub btnProductionEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProductionEntry.Click
        HttpContext.Current.Response.Redirect("~/BusinessProcess/ProductionLineStatusEntry.aspx")
    End Sub
End Class
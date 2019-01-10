Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ProductionStatus
    Inherits System.Web.UI.Page
    Dim objTNAChart As New TNAChart
    Dim IPOID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IPOID = Request.QueryString("IPOID")
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgProductionStatus.DataSource = objDataView
        dgProductionStatus.DataBind()

    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objTNAChart.GetProductionStatus(IPOID)
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgProductionStatus_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgProductionStatus.NeedDataSource
        dgProductionStatus.DataSource = objTNAChart.GetProductionStatus(IPOID)
    End Sub
    Protected Sub dgProductionStatus_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgProductionStatus.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgProductionStatus_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgProductionStatus.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgProductionStatus_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgProductionStatus.SortCommand
        BindGrid()
    End Sub
  
End Class
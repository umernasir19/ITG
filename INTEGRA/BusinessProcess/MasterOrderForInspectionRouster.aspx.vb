Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO

Public Class MasterOrderForInspectionRouster
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
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
        dgMasterOrderForInspectionRouster.DataSource = objDataView
        dgMasterOrderForInspectionRouster.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOpenOrderForManagementForInspectionLoad()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgMasterOrderForInspectionRouster_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForInspectionRouster.NeedDataSource
        dgMasterOrderForInspectionRouster.DataSource = objPo.GetMasterOpenOrderForManagementForInspectionLoad()
    End Sub
    Protected Sub dgMasterOrderForInspectionRouster_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForInspectionRouster.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForInspectionRouster_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForInspectionRouster.PageIndexChanged
        BindGrid()
    End Sub

End Class
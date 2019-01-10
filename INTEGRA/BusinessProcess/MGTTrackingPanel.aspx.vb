Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class MGTTrackingPanel
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objPOtracking As New POTracking
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()

        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOtracking.GetTrackingInfoAll()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView")
        dgMGTTrackingPanel.Visible = True
        dgMGTTrackingPanel.DataSource = objDataView
        dgMGTTrackingPanel.DataBind()
       
    End Sub
    Protected Sub dgMGTTrackingPanel_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMGTTrackingPanel.NeedDataSource
        dgMGTTrackingPanel.DataSource = objPOtracking.GetTrackingInfoAll()
    End Sub
    Protected Sub dgMGTTrackingPanel_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMGTTrackingPanel.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgMGTTrackingPanel_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMGTTrackingPanel.PageIndexChanged
        BindGrid()
    End Sub

End Class
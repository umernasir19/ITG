Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CuttingStatusView
    Inherits System.Web.UI.Page
    Dim objCuttingStatuss As New CuttingStatuss
    Dim objCuttingStatussDetail As New CuttingStatussDetail
    Dim IPOID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IPOID = Request.QueryString("IPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgCuttingStatusView.DataSource = objDataView
            dgCuttingStatusView.DataBind()

          
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCuttingStatuss.GetData(IPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgCuttingStatusView_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgCuttingStatusView.NeedDataSource
        dgCuttingStatusView.DataSource = objCuttingStatuss.GetData(IPOID)
    End Sub
    Protected Sub dgCuttingStatusView_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgCuttingStatusView.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgCuttingStatusView_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgCuttingStatusView.SortCommand
        BindGrid()
    End Sub
 
End Class
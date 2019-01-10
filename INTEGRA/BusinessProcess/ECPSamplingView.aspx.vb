Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ECPSamplingView
    Inherits System.Web.UI.Page
    Dim objECPSampling As New ECPSampling
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            dgECPSampling.DataSource = objDataView
            dgECPSampling.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objECPSampling.GetAllData()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Response.Redirect("ECPSamplingEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgECPSampling_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgECPSampling.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lECPSamplingID As String = item("ECPSamplingID").Text
                    Response.Redirect("ECPSamplingEntry.aspx?lECPSamplingID=" & lECPSamplingID & "")
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgECPSampling_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgECPSampling.NeedDataSource

        dgECPSampling.DataSource = objECPSampling.GetAllData()
    End Sub
    Protected Sub dgECPSampling_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgECPSampling.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgECPSampling_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgECPSampling.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgECPSampling_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgECPSampling.SortCommand
        BindGrid()
    End Sub

End Class
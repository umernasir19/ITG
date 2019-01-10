﻿Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class MasterOrderForLogistic
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
        dgMasterOrderForLogistic.DataSource = objDataView
        dgMasterOrderForLogistic.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForLogistic()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgMasterOrderForLogistic_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForLogistic.NeedDataSource
        dgMasterOrderForLogistic.DataSource = objPo.GetMasterOrderForLogistic
    End Sub
    Protected Sub dgMasterOrderForLogistic_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMasterOrderForLogistic.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgMasterOrderForLogistic_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForLogistic.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForLogistic_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForLogistic.SortCommand
        BindGrid()
    End Sub

End Class
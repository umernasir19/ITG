﻿Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class POCloseStatusPanel
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView1") = objDataview
                BindGrid()
            Catch ex As Exception
            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView1")
        dgMasterOrderForMerchandiser.DataSource = objDataView
        dgMasterOrderForMerchandiser.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetPOCloseStatusPanelOrders(CLng(Session("Userid")))
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub dgMasterOrderForMerchandiser_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForMerchandiser.NeedDataSource
        dgMasterOrderForMerchandiser.DataSource = objPo.GetPOCloseStatusPanelOrders(CLng(Session("Userid")))
    End Sub
    Protected Sub dgMasterOrderForMerchandiser_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForMerchandiser.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForMerchandiser_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForMerchandiser.PageIndexChanged
        BindGrid()
    End Sub


End Class
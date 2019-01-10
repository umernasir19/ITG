﻿Imports System.Data
Imports System.Xml
Imports Integra.EuroCentra
Public Class ProductPortfolioView
    Inherits System.Web.UI.Page
    Dim objVenderVerticalIntegration As New VenderVerticalIntegration
    Dim objdataview As DataView
    Dim objdatatable As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Try
                objdataview = LoadData()
                Session("objDataView") = objdataview
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Product Portfolio.")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.Visible = True
                strSortExpression = dgPurchaseOrder.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgPurchaseOrder.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgPurchaseOrder.RecordCount = objDataView.Count
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objVenderVerticalIntegration.GetProductGroup()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("ProductPortfolioEntry.aspx")
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim VVIID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                objVenderVerticalIntegration.deletepodtl(VVIID)
                objdataview = LoadData()
                Session("objDataView") = objdataview
                BindGrid()



        End Select
    End Sub




End Class
﻿Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ProductGroupView
    Inherits System.Web.UI.Page
    Dim objProductType As New ProductType
    Dim objDataView As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            PageHeader("Product Group View")
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("ProductGroupEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try

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
        objDataTable = objProductType.GetAllProductType()
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
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPurchaseOrder.ItemDataBound
        'BindGrid()
    End Sub

    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName


            Case "Edit"

                Dim TypeID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text

                Response.Redirect("ProductGroupEntry.aspx?TypeID=" & TypeID & "")
            Case "Remove"
                Dim TypeID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                objProductType.deletepodtl(TypeID)
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()


        End Select
    End Sub
End Class
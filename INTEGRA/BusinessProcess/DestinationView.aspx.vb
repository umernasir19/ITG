Imports System.Data
Imports System.Xml
Imports Integra.EuroCentra
Public Class DestinationView
    Inherits System.Web.UI.Page
    Dim objDestination As New Destination
    Dim dgPurchaseOrder As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView

        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Destination")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objDestination.GetAll()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            '  Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                '  dgPurchaseOrder.Visible = True
                'strSortExpression = dgPurchaseOrder.SortExpression
                'If strSortExpression <> "" Then
                '    objDataView.Sort = strSortExpression
                '    If Not dgPurchaseOrder.IsSortedAscending Then
                '        objDataView.Sort += " DESC"
                '    End If
                'End If
                dgDestination.RecordCount = objDataView.Count
                dgDestination.DataSource = objDataView
                dgDestination.DataBind()
                dgDestination.Visible = True

            Else
                dgDestination.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("DestinationEntryNew.aspx")
    End Sub
    'Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
    '    Select Case e.CommandName
    '        Case Is = "Remove"

    '    End Select
    'End Sub
End Class
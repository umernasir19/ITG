Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class ComplainDatabaseView
    Inherits System.Web.UI.Page
    Dim objComplainDatabase As New ComplainDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            PageHeader("Complain Database")
        End If
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
                dgView.Visible = True
                strSortExpression = dgView.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgView.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgView.RecordCount = objDataView.Count
                dgView.DataSource = objDataView
                dgView.DataBind()

            Else
                dgView.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objComplainDatabase.GetComplainDatabase()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("ComplainDatabaseEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Select Case e.CommandName
            Case Is = "Edit"
                Dim ComplainDatabaseID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                Response.Redirect("ComplainDatabaseEntry.aspx?ComplainDatabaseID=" & ComplainDatabaseID & "")
        End Select
    End Sub
End Class
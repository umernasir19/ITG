Imports Integra
Imports System.Data

Public Class RewashIssueView
    Inherits System.Web.UI.Page
    Dim ObjRewashIssue As New RewashIssue
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objDataView As DataView
            If Not Page.IsPostBack Then
                Try
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Catch objUDException As UDException
                End Try
            End If
            PageHeader("Rewash Issue")
        Catch ex As Exception

        End Try
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
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgRewashIssue.Visible = True
                dgRewashIssue.RecordCount = objDataView.Count
                dgRewashIssue.DataSource = objDataView
                dgRewashIssue.DataBind()
            Else
                dgRewashIssue.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjRewashIssue.GetRewashIssueAllData()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ' BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("RewashIssueEntry.aspx")
    End Sub
    Protected Sub dgRewashIssue_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRewashIssue.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim RewashIssueID As Long = dgRewashIssue.Items(e.Item.ItemIndex).Cells(0).Text

                ObjRewashIssue.DeleteRewashIssue(RewashIssueID)

                Dim objDataView As DataView

                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
        End Select
    End Sub

End Class
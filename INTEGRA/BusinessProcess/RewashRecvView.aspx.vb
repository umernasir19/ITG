Imports Integra
Imports System.Data

Public Class RewashRecvView
    Inherits System.Web.UI.Page
    Dim ObjRewash As New RewashRecv
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
            PageHeader("Rewash Recv")
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
                dgRewashRecv.Visible = True
                dgRewashRecv.RecordCount = objDataView.Count
                dgRewashRecv.DataSource = objDataView
                dgRewashRecv.DataBind()
            Else
                dgRewashRecv.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjRewash.GetRewashRecvAllData()
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
        Response.Redirect("RewashRecvEntry.aspx")
    End Sub
    Protected Sub dgRewashRecv_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRewashRecv.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim RewashRecvID As Long = dgRewashRecv.Items(e.Item.ItemIndex).Cells(0).Text

                ObjRewash.DeleteRewashRecv(RewashRecvID)

                Dim objDataView As DataView

                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
        End Select
    End Sub

End Class
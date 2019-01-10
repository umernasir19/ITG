Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class AccountInfoView
    Inherits System.Web.UI.Page
    Dim objDataView As DataView
    Dim objChartOfAccount As New AcntChartOfAccount
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Accounts Info View")
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
            dgView.RecordCount = objDataView.Count
            dgView.DataSource = objDataView
            dgView.DataBind()

            If objDataView.Count > 0 Then
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

            End If

        Catch ex As Exception

        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objChartOfAccount.GetDataforView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub LnkbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkbBack.Click
        Try
            Response.Redirect("AccountInfo.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class


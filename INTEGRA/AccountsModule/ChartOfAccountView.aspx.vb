Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ChartOfAccountView
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New ChartOfAccount
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
            dgChartOfAccountView.DataSource = objDataView
            dgChartOfAccountView.DataBind()
  
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objChartOfAccount.GetAllData()
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
    Protected Sub btnAddChartOfAccount_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddChartOfAccount.Click
        Try
            Response.Redirect("ChartOfAccountEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
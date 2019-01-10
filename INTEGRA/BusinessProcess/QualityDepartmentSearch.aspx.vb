Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class QualityDepartmentSearch
    Inherits System.Web.UI.Page
    Dim obGeneralCode As New GeneralCode
    Dim objQDInspection As New QDInspection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Quality Department Search Panel")
            BindQD()

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindQD()
        Dim objUser As New User
        Dim dtQD As New DataTable
        dtQD = objUser.GetBindQDCombo
        cmbQD.DataSource = dtQD
        cmbQD.DataTextField = "Username"
        cmbQD.DataValueField = "Userid"
        cmbQD.DataBind()
        cmbQD.Items.Insert(0, New ListItem("All QD", "0"))
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objQDInspection.GetQDSearch(cmbQD.SelectedValue, txtDateFrom.Text, txtDateTo.Text)
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
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class
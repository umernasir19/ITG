Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class QualityDepartmentForManagement
    Inherits System.Web.UI.Page
    Dim objQDInspection As New QDInspection
    Dim POID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objQDInspection.GetQDHistoryForManagement(POID)

        If objDataTable.Rows.Count > 0 Then
            lblmsg.Text = ""
            lblPONo.Text = "PO. No : " + objDataTable.Rows(0)("PONo")
            lblCustomer.Text = "Customer: " + objDataTable.Rows(0)("customerName")
            lblVendor.Text = "Vendor: " + objDataTable.Rows(0)("VenderName")
        Else
            'No History
            lblmsg.Text = "No History Found"
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            strSortExpression = dgQDInspectionHistory.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgQDInspectionHistory.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgQDInspectionHistory.Visible = True
            dgQDInspectionHistory.RecordCount = objDataView.Count
            dgQDInspectionHistory.DataSource = objDataView
            dgQDInspectionHistory.DataBind()
        Else
            dgQDInspectionHistory.Visible = False
        End If
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub


End Class
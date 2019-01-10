Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class CPChartHistoryView
    Inherits System.Web.UI.Page
    Dim CPProcessID As Long
    Dim lPOID As Long
    Dim objPurchaseOrder As New PurchaseOrder
    Dim objCPChart As New CPChart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CPProcessID = Request.QueryString("CPProcessID")
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then

            objDataView = LoadData()
            Session("objDataView2") = objDataView
            BindGrid()
            POInfo()
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCPChart.GetProcessHistory(lPOID, CPProcessID)
        objDataView = New DataView(objDataTable)
        If objDataTable.Rows.Count > 0 Then
            lblProcess.Text = objDataTable.Rows(0)("ProcessName")
        End If
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView2")
        If objDataView.Count > 0 Then
            strSortExpression = dgPurchaseOrder.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgPurchaseOrder.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgPurchaseOrder.Visible = True
            dgPurchaseOrder.RecordCount = objDataView.Count
            dgPurchaseOrder.DataSource = objDataView
            dgPurchaseOrder.DataBind()
        Else
            dgPurchaseOrder.Visible = False
        End If
    End Sub
    Sub POInfo()
        Try
            Dim dt As DataTable = objPurchaseOrder.GetPOInfo(lPOID)
            lblStyle.Text = dt.Rows(0)("StyleNo")
            lblCustomer.Text = dt.Rows(0)("CustomerName")
            lblShipemntDate.Text = dt.Rows(0)("ShipmentDatee")
            lblPONO.Text = dt.Rows(0)("PONO")

        Catch ex As Exception

        End Try
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
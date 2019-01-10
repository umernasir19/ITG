Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class QRCodeMGT
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim lPOID As Long
    Dim objPOtracking As New POTracking
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()
            LoadEditDate()
        End If
    End Sub
    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOtracking.GetTrackingInfo(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView")
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
    Sub LoadEditDate()
        Dim Dt, dtArticle As DataTable
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMasterView(lPOID)
            lblPONO.Text = Dt.Rows(0)("PONO")
            lblShipment.Text = Dt.Rows(0)("ShipmentDatee")
            lblCustomer.Text = Dt.Rows(0)("CustomerName")
            lblSupplier.Text = Dt.Rows(0)("VenderName")
            dtArticle = objPurchaseMaster.QRCodeForMGT(lPOID)
            lblNoOfArticle.Text = dtArticle.Rows(0)("TotalArticle")
            lblPoQuantity.Text = objPurchaseMaster.QRCodeTotalQty(lPOID)
        Catch ex As Exception
        End Try
    End Sub

 
End Class
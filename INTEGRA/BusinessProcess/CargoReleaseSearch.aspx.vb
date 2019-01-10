Imports System.Data
Imports Integra.EuroCentra
Public Class CargoReleaseSearch
    Inherits System.Web.UI.Page
    Dim objPOO As New PurchaseOrder
    Dim objCargo As New Cargo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Shipment Search")
            BindBuyerWise()
            BindSupplierWise()
            cmbBuyerWise.Visible = False
            lblCustomer.Visible = False
            cmbSupplier.Visible = False
            lblSupplier.Visible = False
            lblMsg.Visible = False
            btnSearch.Visible = False
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindBuyerWise()
        Dim dtBuyer As DataTable
        dtBuyer = objPOO.GetAllCustomer()
        cmbBuyerWise.DataSource = dtBuyer
        cmbBuyerWise.DataTextField = "CustomerName"
        cmbBuyerWise.DataValueField = "CustomerID"
        cmbBuyerWise.DataBind()
        'cmbBuyerWise.Items.Insert(0, New ListItem("All Customer", "0"))
    End Sub
    Sub BindSupplierWise()
        Dim dtBuyer As DataTable
        dtBuyer = objPOO.GetAllSupplier()
        cmbSupplier.DataSource = dtBuyer
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataBind()
        'cmbSupplier.Items.Insert(0, New ListItem("All Supplier", "0"))
    End Sub
    Protected Sub cmbReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedIndexChanged
        If cmbReportType.SelectedItem.Text = "Select.." Then
            cmbSupplier.Visible = False
            lblSupplier.Visible = False
            cmbBuyerWise.Visible = False
            lblCustomer.Visible = False
            'lblMsg.Visible = False
            btnSearch.Visible = False
        ElseIf cmbReportType.SelectedItem.Text = "Customer Vise" Then
            cmbSupplier.Visible = False
            lblSupplier.Visible = False
            cmbBuyerWise.Visible = True
            lblCustomer.Visible = True
            'lblMsg.Visible = False
            btnSearch.Visible = True
        ElseIf cmbReportType.SelectedItem.Text = "Supplier Vise" Then
            cmbSupplier.Visible = True
            lblSupplier.Visible = True
            cmbBuyerWise.Visible = False
            lblCustomer.Visible = False
            ' lblMsg.Visible = False
            btnSearch.Visible = True
        ElseIf cmbReportType.SelectedItem.Text = "PO Number Vise" Then
            Response.Redirect("CargoReleaseSearchByPONumber.aspx")

        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim objDataView As DataView
        Try
            objDataView = LoadDataSearch()
            Session("objDataView") = objDataView
            BindGrid()
        Catch objUDException As UDException
        End Try
    End Sub
    'PageChanged (NOT private otherwise unaccessible from the page)
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
    Function LoadDataSearch() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim ReportTypeParamter As Integer
        If cmbReportType.SelectedItem.Text = "Customer Vise" Then
            ReportTypeParamter = 0
        ElseIf cmbReportType.SelectedItem.Text = "Supplier Vise" Then
            ReportTypeParamter = 1
        End If
        objDataTable = objCargo.GetCargoSearch(ReportTypeParamter, cmbBuyerWise.SelectedValue, cmbSupplier.SelectedValue)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgCagro.Visible = True
                lblMsg.Visible = False
                strSortExpression = dgCagro.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgCagro.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgCagro.RecordCount = objDataView.Count
                dgCagro.DataSource = objDataView
                dgCagro.DataBind()
            Else
                dgCagro.Visible = False
                lblMsg.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
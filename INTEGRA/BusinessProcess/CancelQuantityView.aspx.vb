Imports System.Data
Imports Integra.EuroCentra
Partial Class CancelQuantityView
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim cmbStatus, cmbVendor, cmbBuyer, cmbShipmentMonth, cmbBookedMonth As DropDownList
    Dim Status, Vendor, Buyer, ShipmentMonth, BookedMonth, TotalPO As String
    Dim lblTotalPO As Label
    Dim dr As DataRow
    Dim objvender As New Vender
    Dim objCustomer As New Customer
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Response.Expires = 0
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData("ALL")
                Session("objDataView") = objDataView
                BindGrid()
                BindSeachGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Cancel Quantity Control Panel")
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
                'Check Shipment Made or not
                'Dim dtCheck As New DataTable
                'Dim x As Integer
                'Dim lnkCancelQTY As HyperLink
                'For x = 0 To dgPurchaseOrder.RecordCount - 1
                '    lnkCancelQTY = CType(dgPurchaseOrder.Items(x).FindControl("lnkCancelQTY"), HyperLink)
                '    dtCheck = objPurchaseOrder.CheckPOShipment(Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(0).Text))
                '    If dtCheck.Rows.Count > 1 Then
                '        lnkCancelQTY.Visible = True
                '    Else
                '        lnkCancelQTY.Visible = False
                '    End If
                'Next
                'end
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal Vender) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objPurchaseOrder.GetPurchaseOrderForCancel(Vender, CLng(Session("UserId")), CLng(Session("RoleId")), Session("Team"))
        objDataTable = objPurchaseOrder.GetPurchaseOrderForCancelNew(Vender, CLng(Session("UserId")))
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
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub
    Sub getRecord(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objDataView As DataView
        cmbVendor = CType(DgSeach.Items(0).FindControl("cmbVendor"), DropDownList)
        If cmbVendor.SelectedValue = "0" Then
            Vendor = "ALL"
        Else
            Vendor = cmbVendor.SelectedValue
        End If
        objDataView = LoadData(Vendor)
        Session("objDataView") = objDataView
        BindGrid()
    End Sub
    Sub BindSeachGrid()
        Dim dt As New DataTable
        With dt
            .Columns.Add("Vender", GetType(String))
        End With
        dr = dt.NewRow()
        dr("Vender") = ""
        dt.Rows.Add(dr)

        DgSeach.DataSource = dt
        DgSeach.DataBind()
        BindVender()
    End Sub
    Private Sub BindVender()
        Dim dtVender As DataTable = objvender.getVenderForPOCancel
        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgPurchaseOrder.Items
            With objDataGridItem
                If (Not DgSeach.Items(0).FindControl("cmbVendor") Is Nothing) Then
                    Dim tempDropDown As DropDownList = CType(DgSeach.Items(0).FindControl("cmbVendor"), DropDownList)
                    With tempDropDown
                        .DataSource = dtVender
                        .DataValueField = "VenderLibraryID"
                        .DataTextField = "VenderName"
                        .DataBind()
                        .Items.Insert(0, "ALL")
                    End With
                End If
            End With
        Next
    End Sub

End Class

Imports System.Data
Imports Integra.EuroCentra
Public Class CargoReleaseSearchByPONumber
    Inherits System.Web.UI.Page
    Dim objCargo As New Cargo
    Dim objPurchaseOrder As New PurchaseOrder
    Dim dtOrderNo As New DataTable
    Dim DtCargo As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Shipment Search By PO Number")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            dtOrderNo = objPurchaseOrder.GetPurchaseOrder2(CLng(Session("UserId")), CLng(Session("RoleId")), txtPONO.Text)
            Dim objPOView As DataView
            If dtOrderNo.Rows.Count = 0 Or dtOrderNo Is Nothing Then
                lblMsg.Visible = True
                lblMsg.Text = "Record Not Found !"
                dgPurchaseOrder.Visible = False

            Else
                objPOView = New DataView(dtOrderNo)
                Session("objDataViewPONO") = objPOView
                BindGridPONO()
            End If
            'Session("objDataViewPONO") = Nothing
            ' objPOView = Nothing
            dtOrderNo = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridPONO()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewPONO")
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
                lblMsg.Visible = False
            Else
                dgPurchaseOrder.Visible = False
                lblMsg.Visible = True
            End If
        Catch ex As Exception
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

    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Try
            Select Case e.CommandName
                Case "CheckShipment"
                    Dim lPOID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim objDataView As DataView
                    Try
                        objDataView = LoadDataSearch(lPOID)
                        Session("objDataView") = objDataView
                        BindGrid()
                    Catch objUDException As UDException
                    End Try
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Function LoadDataSearch(ByVal IPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCargo.GetCargoSearchByPONO(IPOID)
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
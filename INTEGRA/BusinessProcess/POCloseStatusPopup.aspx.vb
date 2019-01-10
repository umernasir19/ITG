Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class POCloseStatusPopup
    Inherits System.Web.UI.Page
    Dim objPurchaseOrderDetail As New PurchaseOrderDetail
    Dim IPOID As Long
    Dim ObjPOCancel As New POCancel
    Dim ObjPOCancelDetail As New POCancelDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        IPOID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            Try
                If IPOID > 0 Then
                    objDataView = LoadData(IPOID)
                    Session("objDataView") = objDataView
                    BindGrid()
                End If

            Catch objUDException As UDException
            End Try
        End If
    End Sub
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

                lblPONO.Text = objDataView.Item(0)("PONO")
                lblShipment.Text = objDataView.Item(0)("ShipmentDate")
                lblCustomer.Text = objDataView.Item(0)("CustomerName")
                lblSupplier.Text = objDataView.Item(0)("VenderName")
            Else
                dgPurchaseOrder.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal IPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPurchaseOrderDetail.GetPODetailForClose(IPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPurchaseOrder.ItemDataBound
        'BindGrid()

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            'Save Master
            With ObjPOCancel
                .POCancelID = 0
                .Userid = CLng(Session("Userid"))
                .CreationDate = Date.Now
                .SavePOCancel()
            End With

            'Save Detail
            Dim x As Integer
            Dim txtDifference As TextBox
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                txtDifference = CType(dgPurchaseOrder.Items(x).FindControl("txtDifference"), TextBox)
                With ObjPOCancelDetail
                    .POCancelDetailID = 0
                    .POCancelID = ObjPOCancel.GetId()
                    .POID = IPOID
                    .PODetailID = dgPurchaseOrder.Items(x).Cells(1).Text
                    If Val(txtDifference.Text) < 0 Then
                        .CancelQty = 0
                    Else
                        .CancelQty = Val(txtDifference.Text)
                    End If
                    .SavePOCancelDetail()
                End With
            Next
            'Update POStatus to Close
            objPurchaseOrderDetail.UpdatePOStatus(IPOID)
            lblMsg.Text = "PO. Close & Save Successfully."
        Catch ex As Exception

        End Try
    End Sub

End Class
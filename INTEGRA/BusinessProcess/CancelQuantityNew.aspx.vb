Imports System.Data
Imports Integra.EuroCentra
Partial Class CancelQuantityNew
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objPOCancelQuantity As New POCancelQuantity
    Dim lPOID As Long
    Dim objDataView As DataView
    Dim objDataView1 As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lPOID = Request.QueryString("lPOID")
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()
            PageHeader("Cancel Quantity Entry Panel")
        End If

    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal IPOIDs) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objPurchaseMaster.GetPoDataForCancelQTYNew(IPOIDs)
        objDataTable = objPurchaseMaster.GetPoDataForCancelQTYNeww(IPOIDs)
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

            Dim dtPOInfo As New DataTable
            dtPOInfo = objPurchaseMaster.GetPoDataForInfoNew(lPOID)
            If dtPOInfo.Rows.Count > 0 Then
                dgPOArticle.Visible = True
                dgPOArticle.DataSource = dtPOInfo
                dgPOArticle.DataBind()
            End If
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
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim x As Integer
        Dim txtCancelQty As TextBox
        Dim chkCancel As CheckBox
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim Diffrence As Decimal = dgPurchaseOrder.Items(x).Cells(12).Text
            chkCancel = DirectCast(dgPurchaseOrder.Items(x).FindControl("chkCancel"), CheckBox)
            txtCancelQty = CType(dgPurchaseOrder.Items(x).FindControl("txtCancelQuantity"), TextBox)
            If txtCancelQty.Text = "" Then
            Else
                If chkCancel.Checked = True Then
                    With objPOCancelQuantity
                        .CancelID = 0
                        .CreationDate = Date.Now
                        .POID = Convert.ToUInt32(dgPurchaseOrder.Items(x).Cells(0).Text)
                        .PODetailID = Convert.ToUInt32(dgPurchaseOrder.Items(x).Cells(1).Text)
                        .Quantity = txtCancelQty.Text
                        .IsActive = True
                        .MarchandID = CLng(Session("Userid"))
                        .SavePOCancelQuantity()
                        'Refresh Grid
                        Dim objDataView As DataView
                        objDataView = LoadData(Convert.ToUInt32(dgPurchaseOrder.Items(0).Cells(0).Text))
                        Session("objDataView") = objDataView
                    End With
                End If
            End If
        Next
        BindGrid()
    End Sub
    Protected Sub txtCancelQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer
        Dim txtCancelQty As TextBox
        Dim chkCancel As CheckBox
        For i = 0 To dgPurchaseOrder.Items.Count - 1
            Dim Diffrence As Decimal = dgPurchaseOrder.Items(i).Cells(12).Text
            txtCancelQty = CType(dgPurchaseOrder.Items(i).FindControl("txtCancelQuantity"), TextBox)
            Dim CancelQuantity As Double
            If txtCancelQty.Text = "" Then
                CancelQuantity = 0
            Else
                CancelQuantity = txtCancelQty.Text
            End If

            If CancelQuantity <= Diffrence And CancelQuantity <> 0 Then

                chkCancel = DirectCast(dgPurchaseOrder.Items(i).FindControl("chkCancel"), CheckBox)
                chkCancel.Enabled = True
                chkCancel.Checked = True
                chkCancel.ToolTip = " "
            Else
                chkCancel = DirectCast(dgPurchaseOrder.Items(i).FindControl("chkCancel"), CheckBox)
                chkCancel.Enabled = False
                chkCancel.Checked = False
                chkCancel.ToolTip = "Cancel Quantity never be greater then Diffrence Quantity"
            End If
        Next
    End Sub

End Class

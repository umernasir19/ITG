Imports System.Data
Imports Integra.EuroCentra

Public Class LogisticStatusFinalizationPanel
    Inherits System.Web.UI.Page
    Dim ObjCargoDetail As New CargoDetail
    Dim objLogisticStatus As New LogisticStatus
    Dim lPODetailID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        lPODetailID = Request.QueryString("lPODetailID")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()

            Catch objUDException As UDException
            End Try
        End If
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
                Dim x As Integer
                Dim cmbLogisticStaus As DropDownList
                For x = 0 To dgPurchaseOrder.RecordCount - 1
                    cmbLogisticStaus = CType(dgPurchaseOrder.Items(x).FindControl("cmbLogisticStaus"), DropDownList)
                    With cmbLogisticStaus
                        .Items.Clear()
                        .Items.Insert(0, "Select...")
                        .Items.Insert(1, "Shortfall-Open")
                        .Items.Insert(2, "Closed With Excess")
                        .Items.Insert(3, "Closed With Shortfall")
                        .Items.Insert(4, "Closed")
                    End With
                Next
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjCargoDetail.GetAllDataforLogisticStatusNew(lPODetailID)
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
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            Dim chkLogisticStaus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkLogisticStaus = CType(dgPurchaseOrder.Items(x).FindControl("chkLogisticStaus"), CheckBox)
                If chkLogisticStaus.Checked = True Then
                    Dim cmbLogisticStaus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbLogisticStaus"), DropDownList)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text

                    If Not cmbLogisticStaus.SelectedIndex = 0 Then
                        With objLogisticStatus
                            .LogisticStatusID = 0
                            .LogisticStatus = cmbLogisticStaus.SelectedItem.Text
                            .POID = IPOID
                            .PODetailID = IPODetailID
                            .CreationDate = Date.Now
                            .UserID = CLng(Session("Userid"))
                            .SaveLogisticStatus()
                        End With
                        chkLogisticStaus.Checked = True
                        lblMSG.Text = "Record Saved."
                        lblMSG.Visible = True
                    Else
                        lblMSG.Text = "Record Not Saved."
                        lblMSG.Visible = True
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
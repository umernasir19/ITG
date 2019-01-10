Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class QRCodeQD
    Inherits System.Web.UI.Page
    Dim objQDInspection As New QDInspection
    Dim lPOID As Long
    Dim objPOtracking As New POTracking
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objQDInspection.GetAllDataNewPopup(lPOID)
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

            lblPONO.Text = objDataView.Item(0)("PONO")
            lblShipment.Text = objDataView.Item(0)("shipmentdatee")
            lblCustomer.Text = objDataView.Item(0)("CustomerName")
            lblSupplier.Text = objDataView.Item(0)("VenderName")

            lblEknumber.Text = objDataView.Item(0)("eknumber")
            lblSeason.Text = objDataView.Item(0)("Season")
            lblCustomer.Text = objDataView.Item(0)("CustomerName")

            BindQD()
            BindStatus()
            BindInspStatus()

            'Now IF QD Inspection Exist then show last one in this page
            Dim x As Integer = 0
            Dim txtInsQty As TextBox
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                txtInsQty = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                Dim dtLastQDinsp As DataTable
                dtLastQDinsp = objQDInspection.GetQDInspLast(IPOID, IPODetailID)
                If dtLastQDinsp.Rows.Count > 0 Then
                    txtInsQty.Text = dtLastQDinsp.Rows(0)("InspectedQty")
                    cmbQDName.SelectedValue = dtLastQDinsp.Rows(0)("QDUserid")
                    txtInspDate.SelectedDate = dtLastQDinsp.Rows(0)("InspectionDate")
                    cmbStatus.SelectedValue = dtLastQDinsp.Rows(0)("InspectionStatus")
                    cmbInspStatus.SelectedValue = dtLastQDinsp.Rows(0)("InspStatus")
                End If
            Next
            'End
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
    Sub BindQD()
        Dim objUser As New User
        Dim dtQD As New DataTable
        dtQD = objUser.GetBindQDCombo
        With cmbQDName
            cmbQDName.DataSource = dtQD
            cmbQDName.DataTextField = "Username"
            cmbQDName.DataValueField = "Userid"
            cmbQDName.DataBind()
        End With
    End Sub
    Private Sub BindStatus()
        Try
            With cmbStatus
                .Items.Clear()
                .Items.Insert(0, "Inline")
                .Items.Insert(1, "Final")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindInspStatus()
        Try
            With cmbInspStatus
                .Items.Clear()
                .Items.Insert(0, "---")
                .Items.Insert(1, "Pass")
                .Items.Insert(2, "Hold")
                .Items.Insert(3, "Fail")
            End With
                 
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            SavePOTracking()
            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim txtInsQty As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text

                    Dim InspDate As String = txtInspDate.SelectedDate.ToString()
                    If InspDate <> "" Then
                        With objQDInspection
                            .QDInspectionID = 0
                            .CreationDate = Date.Now
                            .POID = IPOID
                            .PODetailID = IPODetailID
                            .InspectedQty = txtInsQty.Text
                            .QDUserid = cmbQDName.SelectedValue
                            .InspectionDate = txtInspDate.SelectedDate
                            .InspectionStatus = cmbStatus.SelectedItem.Text
                            .Remarks = ""
                            .InspStatus = cmbInspStatus.SelectedItem.Text
                            .SaveQDInspection()
                        End With
                        'After Sabe  chk false
                        chkStatus.Checked = False
                        lblMsg.Text = "Saved Successfully"
                    Else
                        chkStatus.Checked = False
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOTracking()
        Try
            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim InspDate As String = txtInspDate.SelectedDate.ToString()

                    If InspDate <> "" Then
                        If cmbStatus.SelectedItem.Text = "Final" And cmbInspStatus.SelectedItem.Text = "Pass" Then
                            With objPOtracking
                                .PoTrackingID = 0
                                .CreationDate = Date.Now
                                .POID = IPOID
                                .TrackingObject = "Final Inspection Passed"
                                .SavePOTracking()
                            End With
                            Exit For
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class SplitShipment
    Inherits System.Web.UI.Page
    Dim lPOID As Long
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objSplitShipmentDetail As New SplitShipmentDetail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("IPOID") = Nothing
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()
            btnSavee.Visible = False

        End If
    End Sub
    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMasterView(lPOID)
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

            lblPOShipmentMode.Text = objDataView.Item(0)("ShipmentModeName")
            BindMode()
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
    Sub BindMode()
        Dim objPORelatedField As New PORelatedFields
        Dim dtMode As New DataTable
        dtMode = objPORelatedField.GetShipmentMode
        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgPurchaseOrder.Items
            With objDataGridItem
                If (Not .FindControl("cmbMode") Is Nothing) Then
                    Dim tempDropDown As DropDownList = CType(.FindControl("cmbMode"), DropDownList)
                    tempDropDown.DataSource = dtMode
                    tempDropDown.DataTextField = "Name"
                    tempDropDown.DataValueField = "ID"
                    tempDropDown.DataBind()
                End If
            End With
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSavee.Click
        Try

            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim txtMove As RadNumericTextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtMove"), RadNumericTextBox)
                    Dim cmbMode As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbMode"), DropDownList)
                    Dim txtSpiltShipDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtSpiltShipDate"), RadDatePicker)
                    Dim txtReason As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtReason"), TextBox)

                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                    Dim IStyleID As Integer = dgPurchaseOrder.Items(x).Cells(2).Text
                    Dim IStyleDetailID As Integer = dgPurchaseOrder.Items(x).Cells(3).Text
                    Dim ShipDate As String = txtSpiltShipDate.SelectedDate.ToString()
                    Dim BookedQty As Decimal = dgPurchaseOrder.Items(x).Cells(10).Text

                    If ShipDate = "" Then
                        lblMsg.Text = "Split Shipment Date Empty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf txtMove.Text = "" Then
                        lblMsg.Text = "Spilt Qty Can't Empty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf txtMove.Text = "0" Then
                        lblMsg.Text = "Spilt Qty Can't Zero"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf Convert.ToInt32(txtMove.Text) > BookedQty Then
                        lblMsg.Text = "Spilt Qty can't Greater Than Booked Qty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    Else
                        lblMsg.Text = ""
                        With objSplitShipmentDetail
                            .SplitID = 0
                            .PODetailID = IPODetailID
                            .POID = IPOID
                            .Quantity = txtMove.Text
                            .Rate = dgPurchaseOrder.Items(x).Cells(8).Text
                            .StyleID = IStyleID
                            .StyleDetailID = IStyleDetailID
                            .SplitShipmentDate = txtSpiltShipDate.SelectedDate
                            .SplitMode = cmbMode.SelectedItem.Text
                            .Reason = txtReason.Text
                            .CreationDate = Date.Now

                            'check Article Split Pervious
                            Dim dtSplitNo As DataTable
                            dtSplitNo = objSplitShipmentDetail.CheckSplitNo(IPODetailID)
                            If dtSplitNo.Rows.Count > 0 Then
                                Dim ISplitNo As Long = Convert.ToInt32(dtSplitNo.Rows(0)("SplitNo")) + 1
                                .SplitNo = ISplitNo
                            Else
                                .SplitNo = 1
                            End If
                            .SaveSplitShipmentDetail()
                        End With
                        lblMsg.Text = "Saved Successfully"
                    End If
                End If
            Next
            SavePOTracking()
            ' SendEmail()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCheckData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheckData.Click
        Try
            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim txtMove As RadNumericTextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtMove"), RadNumericTextBox)
                    Dim txtSpiltShipDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtSpiltShipDate"), RadDatePicker)

                    Dim BookedQty As Decimal = dgPurchaseOrder.Items(x).Cells(10).Text
                    Dim ShipDate As String = txtSpiltShipDate.SelectedDate.ToString()

                    If ShipDate = "" Then
                        lblMsg.Text = "Split Shipment Date Empty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf txtMove.Text = "" Then
                        lblMsg.Text = "Spilt Qty Can't Empty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf txtMove.Text = "0" Then
                        lblMsg.Text = "Spilt Qty Can't Zero"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    ElseIf Convert.ToInt32(txtMove.Text) > BookedQty Then
                        lblMsg.Text = "Spilt Qty Can't Greater Than Booked Qty"
                        chkStatus.Checked = False
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightGray
                    Else
                        lblMsg.Text = ""
                        btnSavee.Visible = True
                        chkStatus.Checked = True
                        dgPurchaseOrder.Items(x).Cells(9).Text = BookedQty - Convert.ToInt32(txtMove.Text)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOTracking()
        Try
            Dim objPOtracking As New POTracking
            With objPOtracking
                .PoTrackingID = 0
                .CreationDate = Date.Now
                .POID = lPOID
                .TrackingObject = "PO Splitted"
                .SavePOTracking()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEmail()
        Try

            Dim x As Integer
            Dim SplitQty As Long
            Dim OrderQty As Decimal
            Dim ShipDatee As String
            Dim Mode As String
            Dim count As Integer = 0
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                OrderQty = OrderQty + dgPurchaseOrder.Items(x).Cells(10).Text
                If chkStatus.Checked = True Then
                    Dim txtMove As RadNumericTextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtMove"), RadNumericTextBox)
                    Dim cmbMode As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbMode"), DropDownList)
                    Dim txtSpiltShipDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtSpiltShipDate"), RadDatePicker)
                    Dim ShipDate As String = txtSpiltShipDate.SelectedDate.ToString()
                    Dim BookedQty As Decimal = dgPurchaseOrder.Items(x).Cells(10).Text
                    If ShipDate = "" Then
                    ElseIf txtMove.Text = "" Then
                    ElseIf txtMove.Text = "0" Then
                    ElseIf Convert.ToInt32(txtMove.Text) > BookedQty Then
                    Else
                        SplitQty = SplitQty + Convert.ToInt32(txtMove.Text)
                        If count = 0 Then
                            ShipDatee = txtSpiltShipDate.SelectedDate.Value.ToString("dd/MM/yyyy")

                            Mode = cmbMode.SelectedItem.Text
                            count = 1
                        End If
                    End If
                End If
            Next

            x = 0
            'Email
            Dim objUser As New User
            Dim dtEmail As DataTable
            dtEmail = objUser.GetEmailAddress(77)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable

            dtCC = objUser.EmailAddressCCForRevisedShipment()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
            Next
            Dim dtPOInfo As DataTable
            dtPOInfo = objUser.EmailAddressCCForRevisedShipmentMerchant(lPOID)
            mail.CC.Add(dtPOInfo.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = "Split Shipment Notification: PO No. " & dtPOInfo.Rows(0)("PONO") & ", " & dtPOInfo.Rows(0)("Customername") & ""
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Merchandiser has been splitted shipment of following order:"
            Body = Body + " " & _
                         "<br/>" & _
                         "PO. No:" & dtPOInfo.Rows(0)("PONO") & "" & _
                         "<br/>" & _
                          "Customer: " & dtPOInfo.Rows(0)("Customername") & "" & _
                         "<br/>" & _
                          "Supplier: " & dtPOInfo.Rows(0)("Vendername") & "" & _
                         "<br/>" & _
                         "Shipment date: " & lblShipment.Text & "" & _
                         "<br/>" & _
                          "--------------------------------------------------" & _
                          "<br/>" & _
                          "<b> Delivery 1: Shipment Date: " & lblShipment.Text & ", Qty: " & OrderQty - SplitQty & " , Shipment Mode: " & lblPOShipmentMode.Text & " </b>" & _
                         "<br/>" & _
                          "<b>Delivery 2: Shipment Date: " & ShipDatee & ", Qty: " & SplitQty & " , Shipment Mode: " & Mode & " </b>" & _
                          "<br/>" & _
                            "<br/>" & _
                          "Thanks" & _
                           "<br/>" & _
                          "Euro Centra B2B." & _
                           "<br/>" & _
                             "<br/>" & _
                           "Powered By: Integra ERP "
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 25
            smtp.Host = "mail.eurocentrab2b.com"
            smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
            smtp.EnableSsl = False
            smtp.Send(mail)

        Catch ex As Exception

        End Try
    End Sub
End Class
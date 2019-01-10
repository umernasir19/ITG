Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Public Class QualityDepartmentPopupEdit
    Inherits System.Web.UI.Page
    Dim objQDInspection As New QDInspection
    Dim lPOID As Long
    Dim lPODetailID As Long
    Dim QDInspectionID As Long
    Dim objPOtracking As New POTracking
    Dim objQDInspectionError As New QDInspectionError
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("IPOID") = Nothing
        lPOID = Request.QueryString("lPOID")
        lPODetailID = Request.QueryString("lPODetailID")
        QDInspectionID = Request.QueryString("QDInspectionID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()

            'abi ye page under const. hai 
        End If
    End Sub
    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objQDInspection.GetAllDataNewPopupEdit(lPOID, lPODetailID, QDInspectionID)
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
            BindErrorCode()

            'Now IF QD Inspection Exist then show last one in this page
            Dim x As Integer = 0
            Dim txtInsQty As TextBox
            Dim cmbQDName As DropDownList
            Dim txtInspDate As RadDatePicker
            Dim cmbStatus As DropDownList
            Dim cmbInspStatus As DropDownList
            Dim txtRemarks As TextBox
            Dim cmbErrorCode As RadComboBox

            For x = 0 To dgPurchaseOrder.Items.Count - 1
                txtInsQty = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                cmbQDName = CType(dgPurchaseOrder.Items(x).FindControl("cmbQDName"), DropDownList)
                txtInspDate = CType(dgPurchaseOrder.Items(x).FindControl("txtInspDate"), RadDatePicker)
                cmbStatus = CType(dgPurchaseOrder.Items(x).FindControl("cmbStatus"), DropDownList)
                cmbInspStatus = CType(dgPurchaseOrder.Items(x).FindControl("cmbInspStatus"), DropDownList)
                txtRemarks = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                cmbErrorCode = CType(dgPurchaseOrder.Items(x).FindControl("cmbErrorCode"), RadComboBox)

                Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(2).Text
                Dim QDInspectionID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                Dim dtLastQDinsp As DataTable
                dtLastQDinsp = objQDInspection.GetQDInspLastEdit(IPOID, IPODetailID, QDInspectionID)
                If dtLastQDinsp.Rows.Count > 0 Then
                    txtInsQty.Text = dtLastQDinsp.Rows(0)("InspectedQty")
                    cmbQDName.SelectedValue = dtLastQDinsp.Rows(0)("QDUserid")
                    txtInspDate.SelectedDate = dtLastQDinsp.Rows(0)("InspectionDate")
                    cmbStatus.SelectedValue = dtLastQDinsp.Rows(0)("InspectionStatus")
                    cmbInspStatus.SelectedValue = dtLastQDinsp.Rows(0)("InspStatus")
                    txtRemarks.Text = dtLastQDinsp.Rows(0)("Remarks")
                End If

                Dim dtQDError As DataTable = objQDInspection.GetErrorEdit(IPOID, IPODetailID, QDInspectionID)
                If dtQDError.Rows.Count > 0 Then
                    Dim z As Integer
                    For z = 0 To dtQDError.Rows.Count - 1
                        cmbErrorCode.Items.FindItemByValue(dtQDError.Rows(z)("ErrorID")).Checked = True
                    Next
                Else
                    'no selected item
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
        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgPurchaseOrder.Items
            With objDataGridItem
                If (Not .FindControl("cmbQDName") Is Nothing) Then
                    Dim tempDropDown As DropDownList = CType(.FindControl("cmbQDName"), DropDownList)
                    tempDropDown.DataSource = dtQD
                    tempDropDown.DataTextField = "Username"
                    tempDropDown.DataValueField = "Userid"
                    tempDropDown.DataBind()
                    tempDropDown.Items.Insert(0, "Select QD")
                End If
            End With
        Next
    End Sub
    Private Sub BindStatus()
        Try
            Dim objDataGridItem As DataGridItem
            For Each objDataGridItem In dgPurchaseOrder.Items
                With objDataGridItem
                    If (Not .FindControl("cmbStatus") Is Nothing) Then
                        Dim tempDropDown As DropDownList = CType(.FindControl("cmbStatus"), DropDownList)
                        With tempDropDown
                            .Items.Clear()
                            .Items.Insert(0, "Ist Inline")
                            .Items.Insert(1, "2nd Inline")
                            .Items.Insert(2, "Final")
                        End With
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindInspStatus()
        Try
            Dim objDataGridItem As DataGridItem
            For Each objDataGridItem In dgPurchaseOrder.Items
                With objDataGridItem
                    If (Not .FindControl("cmbInspStatus") Is Nothing) Then
                        Dim tempDropDown As DropDownList = CType(.FindControl("cmbInspStatus"), DropDownList)
                        With tempDropDown
                            .Items.Clear()
                            .Items.Insert(0, "---")
                            .Items.Insert(1, "Pass")
                            .Items.Insert(2, "Hold")
                            .Items.Insert(3, "Fail")
                        End With
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            SavePOTracking()
            'SendEmail()
            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim txtInsQty As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                    Dim cmbQDName As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbQDName"), DropDownList)
                    Dim txtInspDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtInspDate"), RadDatePicker)
                    Dim cmbStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbStatus"), DropDownList)
                    Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbInspStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbInspStatus"), DropDownList)
                    Dim cmbErrorCode As RadComboBox = CType(dgPurchaseOrder.Items(x).FindControl("cmbErrorCode"), RadComboBox)

                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(2).Text
                    Dim QDInspectionID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim InspDate As String = txtInspDate.SelectedDate.ToString()

                    If InspDate <> "" Then
                        'Get Tolerence of this order
                        Dim OrderTolerence As Decimal = objQDInspection.GetTolerence(IPOID)
                        Dim NewOrderQty As Long = Math.Round((Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(7).Text) * OrderTolerence) / 100)
                        ' If (Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(7).Text) + txtInsQty.Text) <= (Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(6).Text) + NewOrderQty) Then
                        With objQDInspection
                            .QDInspectionID = QDInspectionID
                            .CreationDate = Date.Now
                            .POID = IPOID
                            .PODetailID = IPODetailID
                            .InspectedQty = txtInsQty.Text
                            .QDUserid = cmbQDName.SelectedValue
                            .InspectionDate = txtInspDate.SelectedDate
                            .InspectionStatus = cmbStatus.SelectedItem.Text
                            .Remarks = txtRemarks.Text
                            .InspStatus = cmbInspStatus.SelectedItem.Text
                            .SaveQDInspection()
                        End With

                        'After Sabe  chk false
                        chkStatus.Checked = False
                        lblMsg.Text = "Edit Successfully"
                        'Else
                        '    lblMsg.Text = "Maximum Qty with tolerence is " + ((Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(6).Text) + NewOrderQty) - (Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(7).Text))).ToString()
                        '    Exit For
                        'End If
                    Else
                        chkStatus.Checked = False
                    End If
                End If
            Next
            Dim objDataView As DataView
            objDataView = LoadData(lPOID)
            Session("objDataView") = objDataView
            BindGrid()
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
                    Dim txtInsQty As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                    Dim cmbQDName As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbQDName"), DropDownList)
                    Dim txtInspDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtInspDate"), RadDatePicker)
                    Dim cmbStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbStatus"), DropDownList)
                    Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbInspStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbInspStatus"), DropDownList)

                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
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
    Sub SendEmail()
        Try
            'Email
            Dim x As Integer
            Dim chkStatus As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkStatus = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    Dim txtInsQty As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtInsQty"), TextBox)
                    Dim cmbQDName As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbQDName"), DropDownList)
                    Dim txtInspDate As RadDatePicker = CType(dgPurchaseOrder.Items(x).FindControl("txtInspDate"), RadDatePicker)
                    Dim cmbStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbStatus"), DropDownList)
                    Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim cmbInspStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbInspStatus"), DropDownList)

                    Dim Style As String = dgPurchaseOrder.Items(x).Cells(2).Text
                    Dim Article As String = dgPurchaseOrder.Items(x).Cells(3).Text
                    Dim Size As String = dgPurchaseOrder.Items(x).Cells(4).Text
                    Dim Color As String = dgPurchaseOrder.Items(x).Cells(5).Text
                    Dim InspDate As String = txtInspDate.SelectedDate.ToString()

                    If InspDate <> "" Then
                        If cmbStatus.SelectedItem.Text = "Final" And cmbInspStatus.SelectedItem.Text = "Pass" Then
                            Dim objUser As New User
                            Dim dtEmail As DataTable
                            dtEmail = objUser.GetEmailAddress(77) 'when Supplier id make then replace
                            Dim mail As MailMessage = New MailMessage()
                            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                            Dim dtCC As DataTable
                            Dim xx As Integer
                            dtCC = objUser.EmailAddressCCForInspection()
                            For xx = 0 To dtCC.Rows.Count - 1
                                mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))
                            Next
                            ' Dim dtPOInfo As DataTable
                            'dtPOInfo = objQDInspection.GetAllDataNewPopup(lPOID)
                            mail.Bcc.Add("zahidsajjad@hotmail.com")
                            mail.From = New MailAddress("noreply@eurocentrab2b.com")
                            mail.Subject = "Inspection Notification: PO No. " & lblPONO.Text & ", " & lblCustomer.Text & ""
                            Dim Body As String = " " & _
                                         "<br/>" & _
                                         "Greetings:" & _
                                           "<br/>" & _
                                           "<br/>" & _
                                         "Inspecion done of following order:"
                            Body = Body + " " & _
                                         "<br/>" & _
                                         "PO. No:" & lblPONO.Text & "" & _
                                         "<br/>" & _
                                          "Customer: " & lblCustomer.Text & "" & _
                                         "<br/>" & _
                                          "Supplier: " & lblSupplier.Text & "" & _
                                         "<br/>" & _
                                         "Shipment date: " & lblShipment.Text & "" & _
                                         "<br/>" & _
                                          "<br/>" & _
                                          "<b> Article Inspection with Final + Pass. </b>" & _
                                          "<br/>" & _
                                          "Style : " & Style & "" & _
                                          "<br/>" & _
                                          "Article : " & Article & "" & _
                                         "<br/>" & _
                                         "Size : " & Size & "" & _
                                          "<br/>" & _
                                          "Color : " & Color & "" & _
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
                        ElseIf cmbStatus.SelectedItem.Text = "Final" And cmbInspStatus.SelectedItem.Text = "Fail" Then
                            Dim objUser As New User
                            Dim dtEmail As DataTable
                            dtEmail = objUser.GetEmailAddress(77) 'when Supplier id make then replace
                            Dim mail As MailMessage = New MailMessage()
                            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                            Dim dtCC As DataTable
                            Dim xx As Integer
                            dtCC = objUser.EmailAddressCCForInspection()
                            For xx = 0 To dtCC.Rows.Count - 1
                                mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))
                            Next
                            ' Dim dtPOInfo As DataTable
                            'dtPOInfo = objQDInspection.GetAllDataNewPopup(lPOID)
                            mail.Bcc.Add("zahidsajjad@hotmail.com")
                            mail.From = New MailAddress("noreply@eurocentrab2b.com")
                            mail.Subject = "Inspection Notification: PO No. " & lblPONO.Text & ", " & lblCustomer.Text & ""
                            Dim Body As String = " " & _
                                         "<br/>" & _
                                         "Greetings:" & _
                                           "<br/>" & _
                                           "<br/>" & _
                                         "Inspecion done of following order:"
                            Body = Body + " " & _
                                         "<br/>" & _
                                         "PO. No:" & lblPONO.Text & "" & _
                                         "<br/>" & _
                                          "Customer: " & lblCustomer.Text & "" & _
                                         "<br/>" & _
                                          "Supplier: " & lblSupplier.Text & "" & _
                                         "<br/>" & _
                                         "Shipment date: " & lblShipment.Text & "" & _
                                         "<br/>" & _
                                          "<br/>" & _
                                          "<b> Article Inspection with Final + Fail. </b>" & _
                                          "<br/>" & _
                                          "Style : " & Style & "" & _
                                          "<br/>" & _
                                          "Article : " & Article & "" & _
                                         "<br/>" & _
                                         "Size : " & Size & "" & _
                                          "<br/>" & _
                                          "Color : " & Color & "" & _
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

                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbQDName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        Dim cmbQDName1 As DropDownList = DirectCast(sender, DropDownList)
        Dim row As DataGridItem = DirectCast(cmbQDName1.NamingContainer, DataGridItem)
        Dim index As Integer = row.ItemIndex
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim cmbQDName As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbQDName"), DropDownList)
            If index = 0 Then
                cmbQDName.SelectedValue = cmbQDName1.SelectedValue
            End If
        Next
    End Sub
    Protected Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        Dim cmbStatus1 As DropDownList = DirectCast(sender, DropDownList)
        Dim row As DataGridItem = DirectCast(cmbStatus1.NamingContainer, DataGridItem)
        Dim index As Integer = row.ItemIndex
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim cmbStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbStatus"), DropDownList)
            If index = 0 Then
                cmbStatus.SelectedValue = cmbStatus1.SelectedValue
            End If
        Next
    End Sub
    Protected Sub cmbInspStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        Dim cmbInspStatus1 As DropDownList = DirectCast(sender, DropDownList)
        Dim row As DataGridItem = DirectCast(cmbInspStatus1.NamingContainer, DataGridItem)
        Dim index As Integer = row.ItemIndex
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim cmbInspStatus As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbInspStatus"), DropDownList)
            If index = 0 Then
                cmbInspStatus.SelectedValue = cmbInspStatus1.SelectedValue
            End If
        Next
    End Sub
    Sub BindErrorCode()
        Dim objErrorCodes As New ErrorCode
        Dim dt As New DataTable
        dt = objErrorCodes.GetErrorCodesforView
        Dim objDataGridItem As DataGridItem
        For Each objDataGridItem In dgPurchaseOrder.Items
            With objDataGridItem
                If (Not .FindControl("cmbErrorCode") Is Nothing) Then
                    Dim tempDropDown As RadComboBox = CType(.FindControl("cmbErrorCode"), RadComboBox)
                    tempDropDown.DataSource = dt
                    tempDropDown.DataTextField = "ErrorNo"
                    tempDropDown.DataValueField = "ID"
                    tempDropDown.DataBind()
                End If
            End With
        Next
    End Sub
  
End Class
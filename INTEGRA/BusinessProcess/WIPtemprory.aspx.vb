Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class WIPtemprory
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim IPOID As Long
    Dim objWIPProcess As New WIPProcess
    Dim objWIPChart As New WIPChart
    Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
    Dim GeneralCode As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("IPOID") = Nothing
        Dim objDataView As DataView
        IPOID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            Try
                If IPOID > 0 Then
                    objDataView = LoadData(IPOID)
                    Session("objDataView") = objDataView
                    BindGrid()
                    ShowRevesedShipDates()
                End If

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

                lblPONO.Text = objDataView.Item(0)("PONO")
                lblShipment.Text = objDataView.Item(0)("ShipmentDate")
                lblCustomer.Text = objDataView.Item(0)("CustomerName")
                lblSupplier.Text = objDataView.Item(0)("VenderName")
                'txtRevisedShipment.SelectedDate = objDataView.Item(0)("RevisedShipmentDate")


                Dim x As Integer
                Dim PoRefNO As Integer
                Dim cmbWIPProcess As DropDownList
                Dim dtWIP As New DataTable
                dtWIP = objWIPProcess.GetWIPProcessForNewStyle()
                Dim dtWIPP As New DataTable
                dtWIPP = objWIPProcess.GetWIPProcessForRepeatStyle()
                Dim dtCurrentWIPprocess As New DataTable

                For x = 0 To dgPurchaseOrder.RecordCount - 1
                    PoRefNO = Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(2).Text)
                    cmbWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    If PoRefNO = 0 Then
                        With cmbWIPProcess
                            .DataSource = dtWIP
                            .DataTextField = "ProcessName"
                            .DataValueField = "WIPProcessID"
                            .DataBind()
                            .Items.Insert(0, New ListItem("Select...", "0"))
                        End With
                        'Now show Current WIP Process in Dropdown
                        dtCurrentWIPprocess = objWIPChart.GetCurrentWIPProcess(dgPurchaseOrder.Items(x).Cells(0).Text, dgPurchaseOrder.Items(x).Cells(1).Text)
                        If dtCurrentWIPprocess.Rows.Count > 0 Then
                            cmbWIPProcess.SelectedValue = dtCurrentWIPprocess.Rows(0)("WIPProcessID")
                        Else
                            cmbWIPProcess.SelectedValue = 0
                        End If
                    Else
                        With cmbWIPProcess
                            .DataSource = dtWIPP
                            .DataTextField = "ProcessName"
                            .DataValueField = "WIPProcessID"
                            .DataBind()
                            .Items.Insert(0, New ListItem("Select...", "0"))
                        End With
                        'Now show Current WIP Process in Dropdown
                        dtCurrentWIPprocess = objWIPChart.GetCurrentWIPProcess(dgPurchaseOrder.Items(x).Cells(0).Text, dgPurchaseOrder.Items(x).Cells(1).Text)
                        If dtCurrentWIPprocess.Rows.Count > 0 Then
                            cmbWIPProcess.SelectedValue = dtCurrentWIPprocess.Rows(0)("WIPProcessID")
                        Else
                            cmbWIPProcess.SelectedValue = 0
                        End If
                    End If
                Next
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
        objDataTable = objPurchaseOrder.TemproryFUN(IPOID)
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
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SavePOTracking()
        Dim ApplyinAll As String = ""
        Dim WIPComments As String = ""
        Dim WPOID As Long = 0
        Dim WPODetailID As Long = 0
        Try
            Dim DtSession As DataTable
            DtSession = Session("dtWIPSelection")

            If Not DtSession Is Nothing Then
                ApplyinAll = DtSession.Rows(0)("ApplyinAllSelection")
                WIPComments = DtSession.Rows(0)("Remarks")
                If ApplyinAll = "YES" Then
                    'No Need to find Selected line apply in all
                Else
                    'In this case find POID and PODetailid where we apply this
                    WPOID = DtSession.Rows(0)("POID")
                    WPODetailID = DtSession.Rows(0)("PODetailID")
                End If
            End If

            Dim x As Integer
            Dim chkWIPProcess As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
                If chkWIPProcess.Checked = True Then
                    Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text

                    If Not cmbWIPProcess.SelectedValue = 0 Then
                        With objWIPChart
                            .WIPChartId = 0
                            .WIPProcessID = cmbWIPProcess.SelectedValue
                            'NOW chk Apply in all
                            If ApplyinAll = "YES" Then
                                .POID = IPOID
                                .POdetailID = IPODetailID
                                .Remarks = WIPComments
                            ElseIf ApplyinAll = "NO" Then
                                If IPOID = WPOID And IPODetailID = WPODetailID Then
                                    'IF match with session IDs then save other NOT
                                    .POID = WPOID
                                    .POdetailID = WPODetailID
                                    .Remarks = WIPComments
                                Else
                                End If
                            Else
                                .POID = IPOID
                                .POdetailID = IPODetailID
                                .Remarks = ""
                            End If
                            .Status = "Created"
                            .CreationDate = Date.Now
                            .Userid = CLng(Session("Userid"))
                            .SaveWIPChart()
                            'After Save Make False Checkbox 
                            chkWIPProcess.Checked = False


                        End With
                        lblMSG.Visible = True
                        lblMsg.Text = "Your WIP Save Successfully"

                    Else
                        'Make False Checkbox 
                        chkWIPProcess.Checked = False
                        'Not save
                    End If
                Else
                    'lblMSG.Text = "Record NOT Saved"
                    ' lblMSG.Visible = True
                End If
            Next
        Catch ex As Exception

        End Try
        ApplyinAll = ""
        WIPComments = ""
        WPOID = 0
        WPODetailID = 0
        Session("dtWIPSelection") = Nothing

    End Sub
    Sub SavePOTracking()
        Try
            Dim x As Integer
            Dim chkWIPProcess As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
                If chkWIPProcess.Checked = True Then
                    Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                    If Not cmbWIPProcess.SelectedValue = 0 Then
                        Dim objPOtracking As New POTracking
                        With objPOtracking
                            .PoTrackingID = 0
                            .CreationDate = Date.Now
                            .POID = IPOID
                            .TrackingObject = "WIP Status: " + cmbWIPProcess.SelectedItem.Text
                            .SavePOTracking()
                        End With
                        Exit For
                    End If

                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Try
            Select Case e.CommandName
                Case "WIPRemarks"
                    Dim lPOID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim lPODetailID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text
                    'ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), "New ClientScript", "window.open('WIPRemarksPanel.aspx?lPOID=" & lPOID & "&lPODetailID=" & lPODetailID & "', 'newwindow', 'left=50, top=25, height=650, width=750, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

                    ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), "New ClientScript", "window.open('WIPRemarksPanel.aspx?lPOID=" & lPOID & "&lPODetailID=" & lPODetailID & "', 'PopUpWindowName', 'left=50, top=25, height=650, width=750, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

                    'Dim st As StringBuilder = New StringBuilder()
                    'st.Append("<script language='javascript'>")
                    'st.Append("var w = window.open('WIPRemarksPanel.aspx?lPOID=" & lPOID & "&lPODetailID=" & lPODetailID & "','PopUpWindowName','left=50, top=25, height=650, width=750, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                    'st.Append("w.focus()")
                    'st.Append("</script>")
                    'Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Protected Sub cmbWIPProcess_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        Dim ddlcmbWIPProcess As DropDownList = DirectCast(sender, DropDownList)
        Dim row As DataGridItem = DirectCast(ddlcmbWIPProcess.NamingContainer, DataGridItem)
        'Dim ddlAddLabTestShortName As DropDownList = DirectCast(row.FindControl("cmbWIPProcess"), DropDownList)
        Dim index As Integer = row.ItemIndex

        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
            Dim chkWIPProcess As CheckBox = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
            If index = 0 Then
                Dim cmbWIPProcesss As DropDownList = CType(dgPurchaseOrder.Items(index).FindControl("cmbWIPProcess"), DropDownList)
                If cmbWIPProcesss.SelectedValue = 0 Then
                    cmbWIPProcess.SelectedValue = 0
                    chkWIPProcess.Checked = False
                Else
                    cmbWIPProcess.SelectedValue = cmbWIPProcesss.SelectedValue
                    chkWIPProcess.Checked = True
                End If
            Else
                'it mean indivl drop down clik, so no action,But Just check if Selct then chkbox false
                If cmbWIPProcess.SelectedValue = 0 Then
                    chkWIPProcess.Checked = False
                Else
                    chkWIPProcess.Checked = True
                End If
            End If
        Next
    End Sub
    Protected Sub btnUpdateRevisedShipmentDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateRevisedShipmentDatee.Click
        Try
            SavePOReviseShipment()
        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOReviseShipment()
        Try
            Dim Dtt As New DataTable
            '  Dim RevisedShipment As String = txtRevisedShipmentt.SelectedDate.Value.Year.ToString() + "-" + txtRevisedShipment.SelectedDate.Value.Month.ToString() + "-" + txtRevisedShipment.SelectedDate.Value.Day.ToString()
            Dtt = objPurchaseReviseShip.GetPOForEcistingShipmetDate(IPOID, txtRevisedShipmentt.Text)
            If Dtt.Rows.Count > 0 Then
                lblMMsg.Text = "   Not Save."
            Else
                With objPurchaseReviseShip
                    .POReviseShipmentID = 0
                    .POID = IPOID
                    .CreationDate = Date.Now()
                    .ShipmentDate = GeneralCode.GetDate(txtRevisedShipmentt.Text)
                    .SavePurchaseOrderReviseShipment()
                End With
                lblMMsg.Text = "   Saved."

                Dim objDataView As DataView
                objDataView = LoadData(IPOID)
                Session("objDataView") = objDataView
                BindGrid()

                ShowRevesedShipDates()
                SendEmail()
                SavePOTrackingg()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ShowRevesedShipDates()
        Try
            Dim dtRevesedShipDates As New DataTable
            Dim x As Integer
            Dim Counter As Integer = 1
            Dim Message As String = ""
            dtRevesedShipDates = objPurchaseReviseShip.CheckExisting(IPOID)
            If dtRevesedShipDates.Rows.Count = 1 Then
                lblRevsedShipmentDate.Visible = True
                For x = 0 To dtRevesedShipDates.Rows.Count - 1
                    txtRevisedShipmentt.Text = dtRevesedShipDates.Rows(x)("ShipmentDatee")
                Next
            ElseIf dtRevesedShipDates.Rows.Count > 1 Then
                lblRevsedShipmentDate.Visible = True
                lblRevsedShipmentDate.Text = "Shipment Date Revised."
                For x = 0 To dtRevesedShipDates.Rows.Count - 1
                    Message = Message + "Shipment Date :" + Counter.ToString() + " = " + dtRevesedShipDates.Rows(x)("ShipmentDatee") + vbCrLf
                    Counter = Counter + 1
                Next
                lblRevsedShipmentDate.ToolTip = Message
                txtRevisedShipmentt.Text = dtRevesedShipDates.Rows(dtRevesedShipDates.Rows.Count - 1)("ShipmentDatee")
            Else
                lblRevsedShipmentDate.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmail()
        Try
            'Email
            Dim objUser As New User
            Dim dtEmail As DataTable
            dtEmail = objUser.GetEmailAddress(77)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            Dim x As Integer
            dtCC = objUser.EmailAddressCCForRevisedShipmentt()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
            Next
            Dim dtPOInfo As DataTable
            dtPOInfo = objUser.EmailAddressCCForRevisedShipmentMerchant(IPOID)
            mail.CC.Add(dtPOInfo.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = "Shipment Date Revised Notification: PO No. " & dtPOInfo.Rows(0)("PONO") & ", " & dtPOInfo.Rows(0)("Customername") & ""
            Dim dtRevisdDate As DataTable = objPurchaseReviseShip.CheckRevisedShipDate(IPOID)
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Merchandiser has revised shipment of following order:"
            Body = Body + " " & _
                         "<br/>" & _
                         "PO. No:" & dtPOInfo.Rows(0)("PONO") & "" & _
                         "<br/>" & _
                          "Customer: " & dtPOInfo.Rows(0)("Customername") & "" & _
                         "<br/>" & _
                          "Supplier: " & dtPOInfo.Rows(0)("Vendername") & "" & _
                         "<br/>" & _
                         "Original shipment date: " & dtPOInfo.Rows(0)("ShipmentDatee") & "" & _
                         "<br/>" & _
                          "Lead time margin: " & dtPOInfo.Rows(0)("timespame") & "Days" & _
                         "<br/>" & _
                          "<br/>" & _
                          "<b> Revised: " & dtRevisdDate.Rows(0)("ShipmentDate")  & "</b>" & _
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
    Sub SavePOTrackingg()
        Try
            Dim objPOtracking As New POTracking
            With objPOtracking
                .PoTrackingID = 0
                .CreationDate = Date.Now
                .POID = IPOID
                .TrackingObject = "Revised Shipment Date"
                .SavePOTracking()
            End With
        Catch ex As Exception
        End Try
    End Sub

End Class
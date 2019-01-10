Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml

Public Class EmailTrigger
    Inherits System.Web.UI.Page
    Dim dtEmail As New DataTable
    Dim dtEmail2 As New DataTable
    Dim objUser As New User
    Dim dtEmailDuplicate As New DataTable
    Dim dtEmailDuplicate1 As New DataTable
    Dim objEmailReminder As New EmailReminder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub btnFabricCuttingYarnMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFabricCuttingYarnMail.Click
        'First Tio Check The mail is send or not in current Date
        Dim ObjUmUserLinkLog As New UmUserLinkLog
        Dim DtEmailInfo As New DataTable
        DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
        If DtEmailInfo.Rows.Count = 0 Then
            SendEmailYarnProcurement()
            SendEmailFabricInHouse()
            SendEmailCutting()
            'Now Save Mail Send Info Into Log Table
            With ObjUmUserLinkLog
                .Logid = 0
                .Userid = CLng(Session("Userid"))
                .MailSenddate = Date.Now
                .EmailStatus = "Email Send"
                .SaveEmailSendInfo()
            End With
        End If
    End Sub
    Sub SendEmailFabricInHouse()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            dt = objPurchaseOrder.GetAllDataForMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 45) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMail(dt.Rows(x)("PODetailID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            'Dim dtCC As DataTable = objUser.GetEmailAddress(94)
            'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Fabric In House Delayed "
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Articles have <b> Fabric In House delayed </b>." & _
                        "<br/>"
            '"<br/>" & _
            '  "<table><tr> <td style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;'>PO #</td><td>Article #</td><td>Buyer</td><td>Supplier</td><td>Quantity</td><td>Booked Value</td><td>Placement Date</td><td>Shipment Date</td></tr>  "
            'For x = 0 To dtEmail.Rows.Count - 1
            '    Body = Body + "<tr> <td>" + dtEmail.Rows(x)("PONO") + " </td><td>" + dtEmail.Rows(x)("Article") + "</td><td>" + dtEmail.Rows(x)("CustomerName") + "</td><td>" + dtEmail.Rows(x)("VenderName") + "</td><td>" + dtEmail.Rows(x)("ArticleQTY").ToString() + "</td><td>" + (dtEmail.Rows(x)("ArticleValue")).ToString() + "</td><td>" + dtEmail.Rows(x)("PlacementDatee") + "</td><td>" + dtEmail.Rows(x)("ShipmentDatee") + "</td></tr>"
            '    '"*. " + dtorder.Rows(x)("UserName") + "... " + dtorder.Rows(x)("TotalPOs").ToString() + " Orders."
            'Next
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>" & _
                             "<br/>"
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
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        'base.VerifyRenderingInServerForm(control);
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
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid1()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder1.Visible = True
                strSortExpression = dgPurchaseOrder1.SortExpression
                dgPurchaseOrder1.DataSource = objDataView
                dgPurchaseOrder1.DataBind()
            Else
                dgPurchaseOrder1.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid2()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder2.Visible = True
                strSortExpression = dgPurchaseOrder2.SortExpression
                dgPurchaseOrder2.DataSource = objDataView
                dgPurchaseOrder2.DataBind()
            Else
                dgPurchaseOrder2.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objPurchaseOrder As New PurchaseOrder
        Dim objDataView As DataView
        objDataView = New DataView(dtEmail)
        Return objDataView
    End Function
    Function LoadData2() As ICollection
        Dim objPurchaseOrder As New PurchaseOrder
        Dim objDataView As DataView
        objDataView = New DataView(dtEmailDuplicate)
        Return objDataView
    End Function
    Function LoadData22() As ICollection
        Dim objPurchaseOrder As New PurchaseOrder
        Dim objDataView As DataView
        objDataView = New DataView(dtEmailDuplicate1)
        Return objDataView
    End Function
    Sub SendEmailCutting()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            dt = objPurchaseOrder.GetAllDataForMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 70) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMailCutting(dt.Rows(x)("PODetailID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            'Dim dtCC As DataTable = objUser.GetEmailAddress(94)
            'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Cutting Delayed "
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Articles have <b> cutting delayed </b>." & _
                        "<br/>"
            '"<br/>" & _
            '  "<table><tr> <td style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;'>PO #</td><td>Article #</td><td>Buyer</td><td>Supplier</td><td>Quantity</td><td>Booked Value</td><td>Placement Date</td><td>Shipment Date</td></tr>  "
            'For x = 0 To dtEmail.Rows.Count - 1
            '    Body = Body + "<tr> <td>" + dtEmail.Rows(x)("PONO") + " </td><td>" + dtEmail.Rows(x)("Article") + "</td><td>" + dtEmail.Rows(x)("CustomerName") + "</td><td>" + dtEmail.Rows(x)("VenderName") + "</td><td>" + dtEmail.Rows(x)("ArticleQTY").ToString() + "</td><td>" + (dtEmail.Rows(x)("ArticleValue")).ToString() + "</td><td>" + dtEmail.Rows(x)("PlacementDatee") + "</td><td>" + dtEmail.Rows(x)("ShipmentDatee") + "</td></tr>"
            '    '"*. " + dtorder.Rows(x)("UserName") + "... " + dtorder.Rows(x)("TotalPOs").ToString() + " Orders."
            'Next
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>" & _
                             "<br/>"
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
    Sub SendEmailYarnProcurement()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            dt = objPurchaseOrder.GetAllDataForMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 10) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMailYarnProcurement(dt.Rows(x)("PODetailID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)

            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            'Dim dtCC As DataTable = objUser.GetEmailAddress(94)
            'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Yarn Procurement Delayed "
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Articles have <b> Yarn Procurement delayed </b>." & _
                        "<br/>"
            '"<br/>" & _
            '  "<table><tr> <td style='border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;'>PO #</td><td>Article #</td><td>Buyer</td><td>Supplier</td><td>Quantity</td><td>Booked Value</td><td>Placement Date</td><td>Shipment Date</td></tr>  "
            'For x = 0 To dtEmail.Rows.Count - 1
            '    Body = Body + "<tr> <td>" + dtEmail.Rows(x)("PONO") + " </td><td>" + dtEmail.Rows(x)("Article") + "</td><td>" + dtEmail.Rows(x)("CustomerName") + "</td><td>" + dtEmail.Rows(x)("VenderName") + "</td><td>" + dtEmail.Rows(x)("ArticleQTY").ToString() + "</td><td>" + (dtEmail.Rows(x)("ArticleValue")).ToString() + "</td><td>" + dtEmail.Rows(x)("PlacementDatee") + "</td><td>" + dtEmail.Rows(x)("ShipmentDatee") + "</td></tr>"
            '    '"*. " + dtorder.Rows(x)("UserName") + "... " + dtorder.Rows(x)("TotalPOs").ToString() + " Orders."
            'Next
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>" & _
                             "<br/>"
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
    Protected Sub btnFabricCuttingYarnMasterMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFabricCuttingYarnMasterMail.Click
        Try
            'First Tio Check The mail is send or not in current Date
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            ObjUmUserLinkLog.DeleteEmailSendInfo()
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()

            If DtEmailInfo.Rows.Count = 0 Then
                SendMasterEmailYarnProcurement()
                SendMasterEmailFabricInHouse()
                SendEmailCuttingMasterMail()
                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            Else
                'If Mail send Once then next time login not send mail
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendMasterEmailFabricInHouse()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable

            dt = objPurchaseOrder.GetAllDataForMasterMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 45) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid1()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder1.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            dtEmail = objUser.GetEmailAddress(63)
            mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Fabric In House  Delayed (Summary)"
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Purchase Order have <b> fabric in house delayed </b>." & _
                        "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                          "<br/>" & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>"

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
    Sub SendEmailCuttingMasterMail()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            dt = objPurchaseOrder.GetAllDataForMasterMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 70) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid1()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder1.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            dtEmail = objUser.GetEmailAddress(63)
            mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Cutting Delayed (Summary)"
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Purchase Order have <b> cutting delayed </b>." & _
                        "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>" & _
                             "<br/>"
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
    Sub SendMasterEmailYarnProcurement()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            dt = objPurchaseOrder.GetAllDataForMasterMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("TimeSpame")
                POLeadTime = (POLeadTime * 10) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            'Bind Grid
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid1()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgPurchaseOrder1.RenderControl(hw)
            'Email
            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            dtEmail = objUser.GetEmailAddress(63)
            mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " System Notification: Yarn Procurement Delayed (Summary) "
            'Dim x As Integer
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear Supply Chain, </b>" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Following Purchase Order have <b> Yarn Procurement delayed </b>." & _
                        "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                         "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                         "<br/>" & _
                         "Thanks," & _
                           "<br/>" & _
                            "<br/>" & _
                         "Euro Centra B2B." & _
                           "<br/>" & _
                        "Powered By: Integra ERP" & _
                           "<br/>" & _
                             "<br/>"

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
    Protected Sub btnWeekShipmentt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWeekShipmentt.Click
        Try
            'First Tio Check The mail is send or not in current Date
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            ObjUmUserLinkLog.DeleteEmailSendInfo()
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                'Make Email for Week Shipment Alert ... Always 2 week Fowerder, 
                Dim WeekN0 As Integer = Format(DatePart(DateInterval.WeekOfYear, Now)) + 2
                Dim StartDate As Date = GetWeekStartDate(Date.Now.Year(), WeekN0)
                Dim EndDate As Date = StartDate.AddDays(7)

                Dim objPurchaseOrder As New PurchaseOrder
                Dim objWIPChart As New WIPChart
                dtEmail = objPurchaseOrder.GetAllDataForWeekShipmentMail(StartDate, EndDate)
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid1()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgPurchaseOrder1.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                dtEmail = objUser.GetEmailAddress(24)
                mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                Dim x As Integer
                dtCC = objUser.GetEmailAddressCCWeekShipment()
                For x = 0 To dtCC.Rows.Count - 1
                    mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
                Next
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Shipment planning alert for week No." & WeekN0 & ""
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Mr. Grephen Almas, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following purchase order have <b> shipments in week " & WeekN0 & ".</b>." & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>" & _
                                 "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            Else
                'If Mail send Once then next time login not send mail
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetWeekStartDate(ByVal year As Integer, ByVal week As Integer) As DateTime
        Dim jan1 As New DateTime(year, 1, 1)
        Dim day As Integer = CInt(jan1.DayOfWeek) - 1
        Dim delta As Integer = (If(day < 4, -day, 7 - day)) + 7 * (week - 1)

        Return jan1.AddDays(delta)
    End Function
    Protected Sub btnSocail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSocail.Click
        Try
            'First Tio Check The mail is send or not in current Date
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            '  ObjUmUserLinkLog.DeleteEmailSendInfo()
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendSocailComplianceSC()
                ' SendSocailComplianceSupplier()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendSocailComplianceSC()
        Try
            'Make Email forSocial Compliance  ... Always 90 days, 
            Dim objVenderCertificate As New VenderCertificate
            Dim objWIPChart As New WIPChart
            Dim Dr As DataRow
            With dtEmailDuplicate
                .Columns.Add("Supplier", GetType(String))
                .Columns.Add("Certificate", GetType(String))
                .Columns.Add("Validity", GetType(String))
                .Columns.Add("Status", GetType(String))
            End With
            dtEmail = objVenderCertificate.getCertificateData()
            'Bind Grid
            'For 90 days
            Dim xx As Integer
            Dim Tdays As TimeSpan
            For xx = 0 To dtEmail.Rows.Count - 1
                Dim CertificateExpire As Date = dtEmail.Rows(xx)("CertificateExpire")
                If dtEmail.Rows(xx)("CertificateExpire") < Date.Now Then
                    Dr = dtEmailDuplicate.NewRow()
                    Dr("Supplier") = dtEmail.Rows(xx)("vendername")
                    Dr("Certificate") = dtEmail.Rows(xx)("Certificate")
                    Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                    Dr("Status") = "Expired"
                    dtEmailDuplicate.Rows.Add(Dr)
                ElseIf dtEmail.Rows(xx)("CertificateExpire") < Date.Now.AddDays(30) Then
                    Dr = dtEmailDuplicate.NewRow()
                    Dr("Supplier") = dtEmail.Rows(xx)("vendername")
                    Dr("Certificate") = dtEmail.Rows(xx)("Certificate")
                    Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                    Tdays = CertificateExpire.Subtract(Date.Now)
                    Dr("Status") = Tdays.Days.ToString() + " days left to expire"
                    dtEmailDuplicate.Rows.Add(Dr)
                Else
                    ' dtEmail.Rows.RemoveAt(xx)
                End If
            Next
            If dtEmailDuplicate.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = LoadData2()
                Session("objDataView") = objDataView
                BindGrid2()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgPurchaseOrder2.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                dtEmail = objUser.GetEmailAddress(73)
                mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(87)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                dtCC = objUser.GetEmailAddress(28)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Social Compliance Notification"
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following supplier(s) social compliance need to review." & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>" & _
                                 "<br/>"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)
            Else
                'If Mail send Once then next time login not send mail
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendSocailComplianceSupplier()
        Try
            Dim objVenderCertificate As New VenderCertificate
            Dim dtSupplier As DataTable = objVenderCertificate.getCertificateDistinctSupplier()
            Dim i As Integer
            With dtEmailDuplicate1
                .Columns.Add("Supplier", GetType(String))
                .Columns.Add("Certificate", GetType(String))
                .Columns.Add("Validity", GetType(String))
                .Columns.Add("Status", GetType(String))
            End With
            For i = 0 To dtSupplier.Rows.Count - 1
                'Make Email forSocial Compliance  ... Always 90 days, 
                dtEmailDuplicate1.Clear()
                Dim objWIPChart As New WIPChart
                Dim Dr As DataRow
                dtEmail = objVenderCertificate.getCertificateSupplierData(dtSupplier.Rows(i)("Venderlibraryid"))
                'Bind Grid
                'For 90 days
                Dim xx As Integer
                Dim Tdays As TimeSpan
                For xx = 0 To dtEmail.Rows.Count - 1
                    Dim CertificateExpire As Date = dtEmail.Rows(xx)("CertificateExpire")
                    If dtEmail.Rows(xx)("CertificateExpire") < Date.Now Then
                        Dr = dtEmailDuplicate1.NewRow()
                        Dr("Supplier") = dtEmail.Rows(xx)("vendername")
                        Dr("Certificate") = dtEmail.Rows(xx)("Certificate")
                        Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                        Dr("Status") = "Expired"
                        dtEmailDuplicate1.Rows.Add(Dr)
                    ElseIf dtEmail.Rows(xx)("CertificateExpire") < Date.Now.AddDays(90) Then
                        Dr = dtEmailDuplicate1.NewRow()
                        Dr("Supplier") = dtEmail.Rows(xx)("vendername")
                        Dr("Certificate") = dtEmail.Rows(xx)("Certificate")
                        Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                        Tdays = CertificateExpire.Subtract(Date.Now)
                        Dr("Status") = Tdays.Days.ToString() + " days left to expire"
                        dtEmailDuplicate1.Rows.Add(Dr)
                    End If
                Next
                If dtEmailDuplicate1.Rows.Count > 0 Then
                    Dim objDataView As DataView
                    objDataView = LoadData22()
                    Session("objDataView") = objDataView
                    BindGrid2()
                    dgPurchaseOrder2.Columns(1).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgPurchaseOrder2.RenderControl(hw)
                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(i)("Venderlibraryid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = dtSupplier.Rows(i)("Vendername").ToString() + " -Social Compliance Notification"
                    'Dim x As Integer
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(i)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following social compliance need to review." & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                 "Thanks," & _
                                   "<br/>" & _
                                    "<br/>" & _
                                 "Euro Centra B2B." & _
                                   "<br/>" & _
                                "Powered By: Integra ERP" & _
                                   "<br/>" & _
                                     "<br/>"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Port = 25
                    smtp.Host = "mail.eurocentrab2b.com"
                    smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                    smtp.EnableSsl = False
                    smtp.Send(mail)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSupplier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSupplier.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendEmailYarnProcurementSupplier()
                SendEmailFabricInHouseSupplier()
                SendEmailCuttingSupplier()

                'SendMerchantEmailYarnProcurement()
                'SendMerchantEmailFabricInHouse()
                'SendMerchantEmailCutting()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailFabricInHouseSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dtSupplier As DataTable
            Dim dt As DataTable
            Dim dtBuyer As DataTable
            Dim iBuyer As Integer
            dtSupplier = objPurchaseOrder.GetAllSupplierForMail()
            Dim i As Integer
            For i = 0 To dtSupplier.Rows.Count - 1
                dtBuyer = objPurchaseOrder.GetBuyer(dtSupplier.Rows(i)("VenderLibraryID"))
                For iBuyer = 0 To dtBuyer.Rows.Count - 1
                    dt = objPurchaseOrder.GetAllDataForMasterSupplierMaill(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                    dtEmail = dt.Clone()
                    Dim x As Integer

                    For x = 0 To dt.Rows.Count - 1
                        Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                        POLeadTime = (POLeadTime * 45) / 100
                        Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                        ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                        If ProcessTargetDate < Date.Now.Date Then
                            'Now check in WIP this Aricle History
                            Dim dtWIPStatus As DataTable
                            dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                            If dtWIPStatus.Rows.Count > 0 Then
                            Else
                                Dim drRow As DataRow = dt.Rows(x)
                                dtEmail.NewRow()
                                Dim dr As DataRow = drRow
                                dtEmail.ImportRow(drRow)
                            End If
                        End If
                    Next

                    If dtEmail.Rows.Count > 0 Then
                        Dim dtCheckingEmailExist As DataTable
                        dtCheckingEmailExist = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                        If dtCheckingEmailExist.Rows.Count > 0 Then
                            '  For Email save reminder count
                            Dim a As Integer
                            Dim Str As String = "("
                            For a = 0 To dtEmail.Rows.Count - 1
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dtEmail.Rows(a)("POID"), dtEmail.Rows(a)("Supplierid"), dtEmail.Rows(a)("Customerid"), "Fabric In House")
                                If dtSupplierInfo.Rows.Count > 0 Then
                                    With objEmailReminder
                                        .EmailReminderID = dtSupplierInfo.Rows(0)("EmailReminderID")
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = dtSupplierInfo.Rows(0)("ReminderCount") + 1
                                        .Process = "Fabric In House"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                Else
                                    With objEmailReminder
                                        .EmailReminderID = 0
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = 1
                                        .Process = "Fabric In House"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                End If

                            Next

                            Str = Str + ")"
                            Str = Replace(Str, ",)", ")")
                            objEmailReminder.DeleteNotinList(Str, dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"), "Fabric In House")

                            For Each dr As DataRow In dtEmail.Rows
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dr.Item("POID"), dr.Item("Supplierid"), dr.Item("Customerid"), "Fabric In House")
                                dr.Item("ReminderCount") = dtSupplierInfo.Rows(0)("ReminderCount")
                            Next

                            'Bind Grid
                            Dim objDataView As DataView
                            objDataView = LoadData()
                            Session("objDataView") = objDataView
                            BindGridSupplier()
                            Dim sb As New StringBuilder()
                            Dim sw As New StringWriter(sb)
                            Dim hw As New HtmlTextWriter(sw)
                            dgPurchaseOrderSupplier.RenderControl(hw)
                            'Email
                            Dim dtEmailTo As DataTable
                            Dim mail As MailMessage = New MailMessage()
                            dtEmailTo = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            Dim dtUser As DataTable = objUser.GetUser(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            If dtEmailTo.Rows.Count > 0 Then
                                Dim ii As Integer
                                For ii = 0 To dtEmailTo.Rows.Count - 1
                                    mail.To.Add(dtEmailTo.Rows(ii)("EmailAddress"))
                                Next

                                Dim dtCC As DataTable
                                Dim xx As Integer
                                dtCC = objUser.GetEmailAddress(77)
                                mail.Bcc.Add(dtCC.Rows(xx)("EmailAddress"))

                                mail.Bcc.Add("zahidsajjad@hotmail.com")
                                mail.From = New MailAddress("zainab@eurocentrab2b.com")
                                mail.Subject = dtEmailTo.Rows(0)("CustomerName") + " / " + dtEmailTo.Rows(0)("VenderName") + " / " + dtUser.Rows(0)("UserName") + " / " + dtEmailTo.Rows(0)("ContactPerson") + " :Fabric In House Delayed"

                                'Dim x As Integer
                                Dim Body As String = " " & _
                                              "<br/>" & _
                                              "<b> Dear " & dtEmailTo.Rows(0)("VenderName") & ",</b>" & _
                                                "<br/>" & _
                                                "<br/>" & _
                                              "Following customer order(s) have <b> Yarn Procurement delayed </b>." & _
                                             "<br/>"
                                Body = Body + sb.ToString()
                                Body = Body + " </table> <br/>" & _
                                             "<br/>" & _
                                             "In case of any query, you are advised to contact the key account manager and merchandiser in Euro Centra." & _
                                              "<br/>" & _
                                             "<br/>" & _
                                             "Thanks," & _
                                       "<br/>" & _
                                        "<br/>" & _
                                     "Best Regards/Freundliche gruesse" & _
                                      "<br/>" & _
                                     "<b>Zainab Ihsan</b>" & _
                                      "<br/>" & _
                                     "Deputy Manager" & _
                                      "<br/>" & _
                                     "Supply Chain and Business Development Group" & _
                                       "<br/>" & _
                                        "<br/>" & _
                                    "Powered By: Integra ERP" & _
                                            "<br/>" & _
                                    "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                       "<br/>"
                                mail.Body = Body
                                mail.IsBodyHtml = True
                                Dim smtp As SmtpClient = New SmtpClient()
                                smtp.Port = 25
                                smtp.Host = "mail.eurocentrab2b.com"
                                smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                                smtp.EnableSsl = False
                                smtp.Send(mail)
                                Threading.Thread.Sleep(5000)
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailYarnProcurementSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dtSupplier As DataTable
            Dim dtBuyer As DataTable

            Dim dt As DataTable
            dtSupplier = objPurchaseOrder.GetAllSupplierForMail()

            Dim i As Integer = 0
            For i = 0 To dtSupplier.Rows.Count - 1
                dtBuyer = objPurchaseOrder.GetBuyer(dtSupplier.Rows(i)("VenderLibraryID"))
                Dim iBuyer As Integer = 0
                For iBuyer = 0 To dtBuyer.Rows.Count - 1
                    dt = objPurchaseOrder.GetAllDataForMasterSupplierMaill(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                    dtEmail = dt.Clone()

                    Dim x As Integer = 0
                    For x = 0 To dt.Rows.Count - 1
                        'Get Timespame from Revised Shipmnt date
                        Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                        POLeadTime = (POLeadTime * 10) / 100
                        Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                        ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                        If ProcessTargetDate < Date.Now.Date Then
                            'Now check in WIP this Aricle History
                            Dim dtWIPStatus As DataTable
                            dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                            If dtWIPStatus.Rows.Count > 0 Then
                            Else
                                Dim drRow As DataRow = dt.Rows(x)
                                dtEmail.NewRow()
                                Dim dr As DataRow = drRow
                                dtEmail.ImportRow(drRow)
                            End If
                        End If
                    Next

                    If dtEmail.Rows.Count > 0 Then
                        Dim dtCheckingEmailExist As DataTable
                        dtCheckingEmailExist = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                        If dtCheckingEmailExist.Rows.Count > 0 Then
                            '  For Email save reminder count
                            Dim a As Integer
                            Dim Str As String = "("
                            For a = 0 To dtEmail.Rows.Count - 1
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dtEmail.Rows(a)("POID"), dtEmail.Rows(a)("Supplierid"), dtEmail.Rows(a)("Customerid"), "Yarn Procurement")
                                If dtSupplierInfo.Rows.Count > 0 Then
                                    With objEmailReminder
                                        .EmailReminderID = dtSupplierInfo.Rows(0)("EmailReminderID")
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = dtSupplierInfo.Rows(0)("ReminderCount") + 1
                                        .Process = "Yarn Procurement"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                Else
                                    With objEmailReminder
                                        .EmailReminderID = 0
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = 1
                                        .Process = "Yarn Procurement"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                End If

                            Next

                            Str = Str + ")"
                            Str = Replace(Str, ",)", ")")
                            objEmailReminder.DeleteNotinList(Str, dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"), "Yarn Procurement")

                            For Each dr As DataRow In dtEmail.Rows
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dr.Item("POID"), dr.Item("Supplierid"), dr.Item("Customerid"), "Yarn Procurement")
                                dr.Item("ReminderCount") = dtSupplierInfo.Rows(0)("ReminderCount")
                            Next


                            'Bind Grid
                            Dim objDataView As DataView
                            objDataView = LoadData()
                            Session("objDataView") = objDataView
                            BindGridSupplier()
                            Dim sb As New StringBuilder()
                            Dim sw As New StringWriter(sb)
                            Dim hw As New HtmlTextWriter(sw)
                            dgPurchaseOrderSupplier.RenderControl(hw)
                            'Email
                            Dim dtEmailTo As DataTable
                            Dim mail As MailMessage = New MailMessage()
                            dtEmailTo = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            Dim dtUser As DataTable = objUser.GetUser(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            Dim ii As Integer
                            If dtEmailTo.Rows.Count > 0 Then

                                For ii = 0 To dtEmailTo.Rows.Count - 1
                                    mail.To.Add(dtEmailTo.Rows(ii)("EmailAddress"))
                                Next

                                Dim dtCC As DataTable
                                Dim xx As Integer
                                dtCC = objUser.GetEmailAddress(77)
                                mail.Bcc.Add(dtCC.Rows(xx)("EmailAddress"))

                                mail.Bcc.Add("zahidsajjad@hotmail.com")
                                mail.From = New MailAddress("zainab@eurocentrab2b.com")
                                mail.Subject = dtEmailTo.Rows(0)("CustomerName") + " / " + dtEmailTo.Rows(0)("VenderName") + " / " + dtUser.Rows(0)("UserName") + " / " + dtEmailTo.Rows(0)("ContactPerson") + " :Yarn Procurement Delayed"
                                'Dim x As Integer
                                Dim Body As String = " " & _
                                             "<br/>" & _
                                             "<b> Dear " & dtEmailTo.Rows(0)("VenderName") & ",</b>" & _
                                               "<br/>" & _
                                               "<br/>" & _
                                             "Following customer order(s) have <b> Yarn Procurement delayed </b>." & _
                                            "<br/>"
                                Body = Body + sb.ToString()
                                Body = Body + " </table> <br/>" & _
                                             "<br/>" & _
                                             "In case of any query, you are advised to contact the key account manager and merchandiser in Euro Centra." & _
                                              "<br/>" & _
                                             "<br/>" & _
                                            "Thanks," & _
                                       "<br/>" & _
                                        "<br/>" & _
                                     "Best Regards/Freundliche gruesse" & _
                                      "<br/>" & _
                                     "<b>Zainab Ihsan</b>" & _
                                      "<br/>" & _
                                        "Deputy Manager" & _
                                      "<br/>" & _
                                     "Supply Chain and Business Development Group" & _
                                       "<br/>" & _
                                        "<br/>" & _
                                    "Powered By: Integra ERP" & _
                                            "<br/>" & _
                                    "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                       "<br/>"

                                mail.Body = Body
                                mail.IsBodyHtml = True
                                Dim smtp As SmtpClient = New SmtpClient()
                                smtp.Port = 25
                                smtp.Host = "mail.eurocentrab2b.com"
                                smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                                smtp.EnableSsl = False
                                smtp.Send(mail)
                                Threading.Thread.Sleep(5000)
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailCuttingSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dtSupplier As DataTable
            Dim dt As DataTable
            Dim dtBuyer As DataTable
            Dim iBuyer As Integer
            dtSupplier = objPurchaseOrder.GetAllSupplierForMail()
            Dim i As Integer
            For i = 0 To dtSupplier.Rows.Count - 1
                dtBuyer = objPurchaseOrder.GetBuyer(dtSupplier.Rows(i)("VenderLibraryID"))
                For iBuyer = 0 To dtBuyer.Rows.Count - 1
                    dt = objPurchaseOrder.GetAllDataForMasterSupplierMaill(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                    dtEmail = dt.Clone()
                    Dim x As Integer

                    For x = 0 To dt.Rows.Count - 1
                        Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                        POLeadTime = (POLeadTime * 70) / 100
                        Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                        ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                        If ProcessTargetDate < Date.Now.Date Then
                            'Now check in WIP this Aricle History
                            Dim dtWIPStatus As DataTable
                            dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                            If dtWIPStatus.Rows.Count > 0 Then
                            Else
                                Dim drRow As DataRow = dt.Rows(x)
                                dtEmail.NewRow()
                                Dim dr As DataRow = drRow
                                dtEmail.ImportRow(drRow)
                            End If
                        End If
                    Next

                    If dtEmail.Rows.Count > 0 Then
                        '  For Email save reminder count
                        Dim dtCheckingEmailExist As DataTable
                        dtCheckingEmailExist = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                        If dtCheckingEmailExist.Rows.Count > 0 Then
                            Dim a As Integer
                            Dim Str As String = "("
                            For a = 0 To dtEmail.Rows.Count - 1
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dtEmail.Rows(a)("POID"), dtEmail.Rows(a)("Supplierid"), dtEmail.Rows(a)("Customerid"), "Cutting")
                                If dtSupplierInfo.Rows.Count > 0 Then
                                    With objEmailReminder
                                        .EmailReminderID = dtSupplierInfo.Rows(0)("EmailReminderID")
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = dtSupplierInfo.Rows(0)("ReminderCount") + 1
                                        .Process = "Cutting"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                Else
                                    With objEmailReminder
                                        .EmailReminderID = 0
                                        .POID = dtEmail.Rows(a)("POID")
                                        .Supplierid = dtEmail.Rows(a)("Supplierid")
                                        .Customerid = dtEmail.Rows(a)("Customerid")
                                        .CreationDate = Date.Now
                                        .ReminderCount = 1
                                        .Process = "Cutting"
                                        .SaveEmailReminder()
                                        Str = Str + dtEmail.Rows(a)("POID").ToString() + ","
                                    End With
                                End If
                            Next
                            Str = Str + ")"
                            Str = Replace(Str, ",)", ")")
                            objEmailReminder.DeleteNotinList(Str, dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"), "Cutting")

                            For Each dr As DataRow In dtEmail.Rows
                                Dim dtSupplierInfo As New DataTable
                                dtSupplierInfo = objEmailReminder.GetSupplierMailInfo(dr.Item("POID"), dr.Item("Supplierid"), dr.Item("Customerid"), "Cutting")
                                dr.Item("ReminderCount") = dtSupplierInfo.Rows(0)("ReminderCount")
                            Next

                            'Bind Grid
                            Dim objDataView As DataView
                            objDataView = LoadData()
                            Session("objDataView") = objDataView
                            BindGridSupplier()
                            Dim sb As New StringBuilder()
                            Dim sw As New StringWriter(sb)
                            Dim hw As New HtmlTextWriter(sw)
                            dgPurchaseOrderSupplier.RenderControl(hw)
                            'Email
                            Dim dtEmailTo As DataTable
                            Dim mail As MailMessage = New MailMessage()
                            dtEmailTo = objUser.GetSupplierCustomerEmail(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            Dim dtUser As DataTable = objUser.GetUser(dtSupplier.Rows(i)("VenderLibraryID"), dtBuyer.Rows(iBuyer)("Customerid"))
                            Dim ii As Integer
                            If dtEmailTo.Rows.Count > 0 Then
                                For ii = 0 To dtEmailTo.Rows.Count - 1
                                    mail.To.Add(dtEmailTo.Rows(ii)("EmailAddress"))
                                Next

                                Dim dtCC As DataTable
                                Dim xx As Integer
                                dtCC = objUser.GetEmailAddress(77)
                                mail.Bcc.Add(dtCC.Rows(xx)("EmailAddress"))

                                mail.Bcc.Add("zahidsajjad@hotmail.com")
                                mail.From = New MailAddress("zainab@eurocentrab2b.com")
                                mail.Subject = dtEmailTo.Rows(0)("CustomerName") + " / " + dtEmailTo.Rows(0)("VenderName") + " / " + dtUser.Rows(0)("UserName") + " / " + dtEmailTo.Rows(0)("ContactPerson") + " :Cutting Delayed"

                                'Dim x As Integer
                                Dim Body As String = " " & _
                                           "<br/>" & _
                                           "<b> Dear " & dtEmailTo.Rows(0)("VenderName") & ",</b>" & _
                                             "<br/>" & _
                                             "<br/>" & _
                                           "Following customer order(s) have <b> Cutting delayed </b>." & _
                                          "<br/>"
                                Body = Body + sb.ToString()
                                Body = Body + " </table> <br/>" & _
                                             "<br/>" & _
                                             "In case of any query, you are advised to contact the key account manager and merchandiser in Euro Centra." & _
                                              "<br/>" & _
                                             "<br/>" & _
                                            "Thanks," & _
                                       "<br/>" & _
                                        "<br/>" & _
                                     "Best Regards/Freundliche gruesse" & _
                                      "<br/>" & _
                                     "<b>Zainab Ihsan</b>" & _
                                      "<br/>" & _
                                      "Deputy Manager" & _
                                      "<br/>" & _
                                     "Supply Chain and Business Development Group" & _
                                       "<br/>" & _
                                        "<br/>" & _
                                    "Powered By: Integra ERP" & _
                                            "<br/>" & _
                                    "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                       "<br/>"

                                mail.Body = Body
                                mail.IsBodyHtml = True
                                Dim smtp As SmtpClient = New SmtpClient()
                                smtp.Port = 25
                                smtp.Host = "mail.eurocentrab2b.com"
                                smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                                smtp.EnableSsl = False
                                smtp.Send(mail)
                                Threading.Thread.Sleep(5000)
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridSupplier()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrderSupplier.Visible = True
                strSortExpression = dgPurchaseOrderSupplier.SortExpression
                dgPurchaseOrderSupplier.DataSource = objDataView
                dgPurchaseOrderSupplier.DataBind()
            Else
                dgPurchaseOrderSupplier.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendMerchantEmailFabricInHouse()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dtMerchant = objPurchaseOrder.GetAllMerchandiserForMail()
            For xM = 0 To dtMerchant.Rows.Count - 1
                dt = objPurchaseOrder.GetAllDataForMasterMerchantMail(dtMerchant.Rows(xM)("userid"))

                dtEmail = dt.Clone()
                Dim x As Integer
                For x = 0 To dt.Rows.Count - 1
                    Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                    POLeadTime = (POLeadTime * 45) / 100
                    Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this Aricle History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If
                Next

                If dtEmail.Rows.Count > 0 Then
                    'Bind Grid
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    objDataView.Sort = "VenderName ASC"
                    Session("objDataView") = objDataView
                    BindGridMerchant()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgMerchant.RenderControl(hw)
                    'Email
                    Dim mail As MailMessage = New MailMessage()

                    dtEmail = objUser.GetEmailAddress(dtMerchant.Rows(xM)("userid"))
                    If dtEmail.Rows.Count > 0 Then
                        mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                        Dim dtCC As DataTable
                        dtCC = objUser.GetEmailAddress(77)
                        mail.Bcc.Add(dtCC.Rows(0)("EmailAddress"))
                        'dtCC = objUser.GetEmailAddress(94)
                        'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("zainab@eurocentrab2b.com")
                        mail.Subject = "TTD for " + dtEmail.Rows(0)("UserName") + ":Fabric In House Delayed"
                        'Dim x As Integer
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                     "<b> Dear " + dtEmail.Rows(0)("UserName") + ", </b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Following Purchase Order have <b> fabric in house delayed </b>." & _
                                    "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                     "<br/>" & _
                                     "PLEASE UPDATE WIP. " & _
                                      "<br/>" & _
                                     "<br/>" & _
                                    "Thanks," & _
                                           "<br/>" & _
                                            "<br/>" & _
                                         "Best Regards/Freundliche gruesse" & _
                                          "<br/>" & _
                                         "<b>Zainab Ihsan</b>" & _
                                          "<br/>" & _
                                          "Deputy Manager" & _
                                          "<br/>" & _
                                         "Supply Chain and Business Development Group" & _
                                           "<br/>" & _
                                            "<br/>" & _
                                        "Powered By: Integra ERP" & _
                                                "<br/>" & _
                                        "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                           "<br/>"

                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Port = 25
                        smtp.Host = "mail.eurocentrab2b.com"
                        smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                        smtp.EnableSsl = False
                        smtp.Send(mail)
                        Threading.Thread.Sleep(6000)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SendMerchantEmailYarnProcurement()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dtMerchant = objPurchaseOrder.GetAllMerchandiserForMail()
            For xM = 0 To dtMerchant.Rows.Count - 1
                dt = objPurchaseOrder.GetAllDataForMasterMerchantMail(dtMerchant.Rows(xM)("userid"))

                dtEmail = dt.Clone()
                Dim x As Integer
                For x = 0 To dt.Rows.Count - 1
                    Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                    POLeadTime = (POLeadTime * 10) / 100
                    Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this Aricle History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If
                Next

                If dtEmail.Rows.Count > 0 Then
                    'Bind Grid
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    objDataView.Sort = "VenderName ASC"
                    Session("objDataView") = objDataView
                    BindGridMerchant()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgMerchant.RenderControl(hw)
                    'Email
                    Dim mail As MailMessage = New MailMessage()

                    dtEmail = objUser.GetEmailAddress(dtMerchant.Rows(xM)("userid"))
                    If dtEmail.Rows.Count > 0 Then
                        mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                        Dim dtCC As DataTable
                        dtCC = objUser.GetEmailAddress(77)
                        mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                        'dtCC = objUser.GetEmailAddress(94)
                        'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("zainab@eurocentrab2b.com")
                        mail.Subject = "TTD for " + dtEmail.Rows(0)("UserName") + ":Yarn Procurement Delayed"
                        'Dim x As Integer
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                     "<b> Dear " + dtEmail.Rows(0)("UserName") + ", </b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Following Purchase Order have <b> Yarn Procurement delayed </b>." & _
                                    "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                     "<br/>" & _
                                     "PLEASE UPDATE WIP. " & _
                                      "<br/>" & _
                                     "<br/>" & _
                                    "Thanks," & _
                                           "<br/>" & _
                                            "<br/>" & _
                                         "Best Regards/Freundliche gruesse" & _
                                          "<br/>" & _
                                         "<b>Zainab Ihsan</b>" & _
                                          "<br/>" & _
                                         "Deputy Manager" & _
                                          "<br/>" & _
                                         "Supply Chain and Business Development Group" & _
                                           "<br/>" & _
                                            "<br/>" & _
                                        "Powered By: Integra ERP" & _
                                                "<br/>" & _
                                        "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                           "<br/>"

                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Port = 25
                        smtp.Host = "mail.eurocentrab2b.com"
                        smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                        smtp.EnableSsl = False
                        smtp.Send(mail)
                        Threading.Thread.Sleep(6000)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SendMerchantEmailCutting()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dtMerchant = objPurchaseOrder.GetAllMerchandiserForMail()
            For xM = 0 To dtMerchant.Rows.Count - 1
                dt = objPurchaseOrder.GetAllDataForMasterMerchantMail(dtMerchant.Rows(xM)("userid"))

                dtEmail = dt.Clone()
                Dim x As Integer
                For x = 0 To dt.Rows.Count - 1
                    Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                    POLeadTime = (POLeadTime * 70) / 100
                    Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this Aricle History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If
                Next
                If dtEmail.Rows.Count > 0 Then
                    'Bind Grid
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    objDataView.Sort = "VenderName ASC"
                    Session("objDataView") = objDataView
                    BindGridMerchant()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgMerchant.RenderControl(hw)
                    'Email
                    Dim mail As MailMessage = New MailMessage()

                    dtEmail = objUser.GetEmailAddress(dtMerchant.Rows(xM)("userid"))
                    If dtEmail.Rows.Count > 0 Then
                        mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                        Dim dtCC As DataTable
                        dtCC = objUser.GetEmailAddress(77)
                        mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                        'dtCC = objUser.GetEmailAddress(94)
                        'mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("zainab@eurocentrab2b.com")
                        mail.Subject = "TTD for " + dtEmail.Rows(0)("UserName") + ":Cutting Delayed"
                        'Dim x As Integer
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                     "<b> Dear " + dtEmail.Rows(0)("UserName") + ", </b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Following Purchase Order have <b> Cutting delayed </b>." & _
                                    "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                     "<br/>" & _
                                     "PLEASE UPDATE WIP. " & _
                                      "<br/>" & _
                                     "<br/>" & _
                                    "Thanks," & _
                                           "<br/>" & _
                                            "<br/>" & _
                                         "Best Regards/Freundliche gruesse" & _
                                          "<br/>" & _
                                         "<b>Zainab Ihsan</b>" & _
                                          "<br/>" & _
                                          "Deputy Manager" & _
                                          "<br/>" & _
                                         "Supply Chain and Business Development Group" & _
                                           "<br/>" & _
                                            "<br/>" & _
                                        "Powered By: Integra ERP" & _
                                                "<br/>" & _
                                        "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                           "<br/>"

                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Port = 25
                        smtp.Host = "mail.eurocentrab2b.com"
                        smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                        smtp.EnableSsl = False
                        smtp.Send(mail)
                        Threading.Thread.Sleep(6000)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridMerchant()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgMerchant.Visible = True
                strSortExpression = dgMerchant.SortExpression
                dgMerchant.DataSource = objDataView
                dgMerchant.DataBind()
            Else
                dgMerchant.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    'New
    Sub SupplierMail()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim POLeadTime As Long
            Dim dtSupplier As DataTable
            Dim dtDept As DataTable
            dtSupplier = objPurchaseOrder.GetAllSupplierForMail()
            Dim i As Integer

            For i = 0 To dtSupplier.Rows.Count - 1
                dt = objPurchaseOrder.GetAllDataForMasterSupplierMail(dtSupplier.Rows(i)("VenderLibraryID"))
                dtEmail = dt.Clone()
                Dim x As Integer
                dtEmail = dt.Clone()

                For x = 0 To dt.Rows.Count - 1
                    ' Yarn
                    POLeadTime = dt.Rows(x)("TimeSpame")
                    POLeadTime = (POLeadTime * 10) / 100
                    Dim ProcessTargetDateYarn As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDateYarn = ProcessTargetDateYarn.AddDays(POLeadTime)
                    If ProcessTargetDateYarn < Date.Now.Date Then
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            drRow.Item("Process") = "Yarn Procurement"
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If

                    POLeadTime = dt.Rows(x)("TimeSpame")
                    ' FabricInHouse
                    POLeadTime = (POLeadTime * 45) / 100
                    Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)
                    If ProcessTargetDate < Date.Now.Date Then
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            drRow.Item("Process") = "Fabric In House"
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If
                    ' Cutting
                    POLeadTime = dt.Rows(x)("TimeSpame")
                    POLeadTime = (POLeadTime * 70) / 100
                    Dim ProcessTargetDateCutting As Date = dt.Rows(x)("PlacementDate")
                    ProcessTargetDateCutting = ProcessTargetDateCutting.AddDays(POLeadTime)
                    If ProcessTargetDateCutting < Date.Now.Date Then
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = dt.Rows(x)
                            dtEmail.NewRow()
                            drRow.Item("Process") = "Cutting"
                            Dim dr As DataRow = drRow
                            dtEmail.ImportRow(drRow)
                        End If
                    End If
                Next
                'Dim UserNames = From row In dtEmail.AsEnumerable()
                '            Select row.Field(Of String)("UserName") Distinct

                Dim ss As DataTable = dtEmail.DefaultView.ToTable(True, New String() {"UserName"})
                If ss.Rows.Count > 0 Then
                    dtEmail2 = dtEmail.Clone
                    Dim aa As Integer
                    For aa = 0 To ss.Rows.Count - 1
                        dtEmail2.Rows.Clear()
                        Dim dr2 As DataRow() = dtEmail.Select("UserName = '" & ss.Rows(aa)("UserName") & "'")
                        For Each row As DataRow In dr2
                            dtEmail2.ImportRow(row)
                        Next

                        'Bind Grid
                        Dim objDataView As DataView
                        objDataView = LoadDataEmail2()
                        objDataView.Sort = "Process DESC"
                        Session("objDataView") = objDataView
                        BindGridSupplierNew()
                        Dim sb As New StringBuilder()
                        Dim sw As New StringWriter(sb)
                        Dim hw As New HtmlTextWriter(sw)
                        dgSupplierMailNew.RenderControl(hw)

                        'Email
                        Dim mail As MailMessage = New MailMessage()
                        Dim dtEmails As DataTable = objUser.GetSupplierEmail(dtSupplier.Rows(i)("VenderLibraryID"))
                        If dtEmails.Rows.Count > 0 Then
                            Dim ii As Integer
                            For ii = 0 To dtEmails.Rows.Count - 1
                                mail.To.Add(dtEmails.Rows(ii)("EmailAddress"))
                            Next

                            Dim dtCC As DataTable
                            Dim xx As Integer
                            dtCC = objUser.GetEmailAddress(77)
                            mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))
                            dtCC = objUser.GetEmailAddressMerchant(ss.Rows(aa)("UserName"))
                            mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))

                            ' mail.Bcc.Add("zahidsajjad@hotmail.com")
                            mail.From = New MailAddress("zainab@eurocentrab2b.com")
                            mail.Subject = " TTD Notification For " & dtEmails.Rows(0)("VenderName") & " ECP Merchant:" & dtCC.Rows(0)("UserName") & ""
                            'Dim x As Integer
                            Dim Body As String = " " & _
                                         "<br/>" & _
                                         "<b> Dear " & dtEmails.Rows(0)("VenderName") & ",</b>" & _
                                           "<br/>" & _
                                           "<br/>" & _
                                         "Please update following task." & _
                                        "<br/>"
                            Body = Body + sb.ToString()
                            Body = Body + " </table> <br/>" & _
                                         "<br/>" & _
                                         " You are advise to contact key account manager and/or merchandiser in Euro Centra Pakistan. " & _
                                          "<br/>" & _
                                         "<br/>" & _
                                         "Thanks," & _
                                           "<br/>" & _
                                            "<br/>" & _
                                         "Best Regards/Freundliche gruesse" & _
                                          "<br/>" & _
                                         "<b>Zainab Ihsan</b>" & _
                                          "<br/>" & _
                                         "Assistant Manager Supply Chain" & _
                                          "<br/>" & _
                                         "Supply Chain and Business Development Group" & _
                                           "<br/>" & _
                                            "<br/>" & _
                                        "Powered By: Integra ERP" & _
                                                "<br/>" & _
                                        "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                           "<br/>"

                            mail.Body = Body
                            mail.IsBodyHtml = True
                            Dim smtp As SmtpClient = New SmtpClient()
                            smtp.Port = 25
                            smtp.Host = "mail.eurocentrab2b.com"
                            smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                            smtp.EnableSsl = False
                            smtp.Send(mail)
                        End If
                    Next

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SupplierzMail()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim POLeadTime As Long
            Dim dtMerchant As DataTable
            Dim dtDistinctSupplier As DataTable
            Dim dtDistinctCustomerFromSuplier As DataTable
            dtMerchant = objPurchaseOrder.GetAllMerchandiserForMail()
            Dim i As Integer
            Dim x As Integer
            Dim y As Integer
            Dim yx As Integer
            Dim TotalFabricPos As Integer = 0
            Dim TotalYarnPos As Integer = 0
            Dim TotalCuttingPos As Integer = 0
            Dim Dr As DataRow
            For i = 0 To dtMerchant.Rows.Count - 1
                dtDistinctSupplier = objPurchaseOrder.GetAllMerchantSupplierForMail(dtMerchant.Rows(i)("Userid"))
                '-------------Code Here
                For y = 0 To dtDistinctSupplier.Rows.Count - 1
                    dtEmailDuplicate = New DataTable
                    With dtEmailDuplicate
                        .Columns.Add("User", GetType(String))
                        .Columns.Add("Supplier", GetType(String))
                        .Columns.Add("Customer", GetType(String))
                        .Columns.Add("Orders", GetType(String))
                        .Columns.Add("Status", GetType(String))
                    End With
                    dtDistinctCustomerFromSuplier = objPurchaseOrder.GetAllMerchantSuppliersForMail(dtMerchant.Rows(i)("Userid"), dtDistinctSupplier.Rows(y)("VenderLibraryID"))
                    For yx = 0 To dtDistinctCustomerFromSuplier.Rows.Count - 1
                        dt = objPurchaseOrder.GetAllDataForMasterSupplierMailCustomer(dtDistinctCustomerFromSuplier.Rows(yx)("Customerid"), dtMerchant.Rows(i)("Userid"), dtDistinctSupplier.Rows(y)("VenderLibraryID"))
                        For x = 0 To dt.Rows.Count - 1
                            ' Yarn
                            POLeadTime = dt.Rows(x)("TimeSpame")
                            POLeadTime = (POLeadTime * 10) / 100
                            Dim ProcessTargetDateYarn As Date = dt.Rows(x)("PlacementDate")
                            ProcessTargetDateYarn = ProcessTargetDateYarn.AddDays(POLeadTime)
                            If ProcessTargetDateYarn < Date.Now.Date Then
                                Dim dtWIPStatus As DataTable
                                dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                                If dtWIPStatus.Rows.Count > 0 Then
                                Else
                                    TotalYarnPos = TotalYarnPos + 1
                                End If
                            End If
                            POLeadTime = dt.Rows(x)("TimeSpame")
                            ' FabricInHouse
                            POLeadTime = (POLeadTime * 45) / 100
                            Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
                            ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)
                            If ProcessTargetDate < Date.Now.Date Then
                                Dim dtWIPStatus As DataTable
                                dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                                If dtWIPStatus.Rows.Count > 0 Then
                                Else
                                    TotalFabricPos = TotalFabricPos + 1
                                End If
                            End If
                            ' Cutting
                            POLeadTime = dt.Rows(x)("TimeSpame")
                            POLeadTime = (POLeadTime * 70) / 100
                            Dim ProcessTargetDateCutting As Date = dt.Rows(x)("PlacementDate")
                            ProcessTargetDateCutting = ProcessTargetDateCutting.AddDays(POLeadTime)
                            If ProcessTargetDateCutting < Date.Now.Date Then
                                Dim dtWIPStatus As DataTable
                                dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                                If dtWIPStatus.Rows.Count > 0 Then
                                Else
                                    TotalCuttingPos = TotalCuttingPos + 1
                                End If
                            End If
                        Next
                        If TotalYarnPos <> 0 Then
                            Dr = dtEmailDuplicate.NewRow()
                            Dr("User") = dtMerchant.Rows(i)("Username")
                            Dr("Supplier") = dtDistinctSupplier.Rows(y)("vendername")
                            Dr("Customer") = dtDistinctCustomerFromSuplier.Rows(yx)("CustomerName")
                            Dr("Orders") = TotalYarnPos
                            Dr("Status") = "POs delayed for Yarn procurement"
                            dtEmailDuplicate.Rows.Add(Dr)
                        End If
                        If TotalFabricPos <> 0 Then
                            Dr = dtEmailDuplicate.NewRow()
                            Dr("User") = dtMerchant.Rows(i)("Username")
                            Dr("Supplier") = dtDistinctSupplier.Rows(y)("vendername")
                            Dr("Customer") = dtDistinctCustomerFromSuplier.Rows(yx)("CustomerName")
                            Dr("Orders") = TotalFabricPos
                            Dr("Status") = "POs delayed for fabric procurement"
                            dtEmailDuplicate.Rows.Add(Dr)
                        End If
                        If TotalCuttingPos <> 0 Then
                            Dr = dtEmailDuplicate.NewRow()
                            Dr("User") = dtMerchant.Rows(i)("Username")
                            Dr("Supplier") = dtDistinctSupplier.Rows(y)("vendername")
                            Dr("Customer") = dtDistinctCustomerFromSuplier.Rows(yx)("CustomerName")
                            Dr("Orders") = TotalCuttingPos
                            Dr("Status") = "POs delayed for cutting"
                            dtEmailDuplicate.Rows.Add(Dr)
                        End If
                        TotalCuttingPos = 0
                        TotalFabricPos = 0
                        TotalYarnPos = 0
                    Next
                    Dim sss As String = "ffff"
                    dtEmail = dtEmailDuplicate.Clone()

                    If dtEmailDuplicate.Rows.Count > 0 Then
                        'Bind Grid
                        Dim objDataView As DataView
                        objDataView = LoadData2()
                        'objDataView.Sort = "Process DESC"
                        Session("objDataView") = objDataView
                        BindGridSupplierzz()
                        Dim sb As New StringBuilder()
                        Dim sw As New StringWriter(sb)
                        Dim hw As New HtmlTextWriter(sw)
                        dgSupplierzz.RenderControl(hw)

                        'Email
                        Dim mail As MailMessage = New MailMessage()
                        Dim dtEmails As DataTable = objUser.GetSupplierEmail(dtDistinctSupplier.Rows(y)("VenderLibraryID"))
                        Dim ii As Integer
                        For ii = 0 To dtEmails.Rows.Count - 1
                            mail.To.Add(dtEmails.Rows(ii)("EmailAddress"))
                        Next

                        Dim dtCC As DataTable
                        Dim xx As Integer
                        dtCC = objUser.GetEmailAddress(77)
                        mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))
                        dtCC = objUser.GetEmailAddress(dtMerchant.Rows(i)("Userid"))
                        mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))

                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("zainab@eurocentrab2b.com")
                        mail.Subject = "TTD - Please update order status "
                        'Dim x As Integer
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                     "<b> Dear " & dtEmails.Rows(0)("vendername") & ",</b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Please update following task." & _
                                    "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                     "<br/>" & _
                                     " You are advise to contact key account manager and/or merchandiser in Euro Centra Pakistan. " & _
                                      "<br/>" & _
                                     "<br/>" & _
                                     "Thanks," & _
                                       "<br/>" & _
                                        "<br/>" & _
                                     "Best Regards/Freundliche gruesse" & _
                                      "<br/>" & _
                                     "<b>Zainab Ihsan</b>" & _
                                      "<br/>" & _
                                     "Assistant Manager Supply Chain" & _
                                      "<br/>" & _
                                     "Supply Chain and Business Development Group" & _
                                       "<br/>" & _
                                        "<br/>" & _
                                    "Powered By: Integra ERP" & _
                                            "<br/>" & _
                                    "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                       "<br/>"

                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Port = 25
                        smtp.Host = "mail.eurocentrab2b.com"
                        smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
                        smtp.EnableSsl = False
                        smtp.Send(mail)
                    End If

                Next
            Next


        Catch ex As Exception

        End Try
    End Sub
    Function LoadDataEmail2() As ICollection
        Dim objPurchaseOrder As New PurchaseOrder
        Dim objDataView As DataView
        objDataView = New DataView(dtEmail2)
        Return objDataView
    End Function
    Private Sub BindGridSupplierNew()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgSupplierMailNew.Visible = True
                strSortExpression = dgSupplierMailNew.SortExpression
                dgSupplierMailNew.DataSource = objDataView
                dgSupplierMailNew.DataBind()
            Else
                dgSupplierMailNew.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridSupplierzz()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgSupplierzz.Visible = True
                strSortExpression = dgSupplierzz.SortExpression
                dgSupplierzz.DataSource = objDataView
                dgSupplierzz.DataBind()

                Dim x As Integer
                Dim lblCustomer As Label
                Dim customer As String = ""

                For x = 0 To dgSupplierzz.Rows.Count - 1
                    lblCustomer = CType(dgSupplierzz.Rows(x).FindControl("lblCustomer"), Label)
                    If x = 0 Then
                        customer = lblCustomer.Text
                    ElseIf customer = lblCustomer.Text Then
                        lblCustomer.Text = ""
                    Else
                        lblCustomer.Text = lblCustomer.Text
                    End If

                Next

            Else
                dgSupplierzz.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnRedAlert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRedAlert.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendEmailYarnProcurementRedAlert()
                SendEmailFabricInHouseRedAlert()
                SendEmailCuttingRedAlert()
                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailYarnProcurementRedAlert()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            dtEmail = objPurchaseOrder.GetAllDataForRedAlertMail("Yarn Procurement")
            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGriddgRedAlert()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgRedAlert.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                dtEmail = objUser.GetEmailAddress(77)
                mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                dtEmail = objUser.GetEmailAddress(63)
                mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
                'dtEmail = objUser.GetEmailAddress(94)
                'mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = " Red Alert: Yarn Procurement > 3 Reminders"
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Kaschif, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "System advise you to take immediate action against following order(s) having greater than three(03) reminders in <b>  yarn procurement. </b> " & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                              "<br/>" & _
                             "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailFabricInHouseRedAlert()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            dtEmail = objPurchaseOrder.GetAllDataForRedAlertMail("Fabric In House")
            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGriddgRedAlert()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgRedAlert.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                dtEmail = objUser.GetEmailAddress(77)
                mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                dtEmail = objUser.GetEmailAddress(63)
                mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
                'dtEmail = objUser.GetEmailAddress(94)
                'mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = " Red Alert: Fabric In House > 3 Reminders"
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Kaschif, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "System advise you to take immediate action against following order(s) having greater than three(03) reminders in <b>  fabric in house. </b> " & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                              "<br/>" & _
                             "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailCuttingRedAlert()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            dtEmail = objPurchaseOrder.GetAllDataForRedAlertMail("Cutting")
            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGriddgRedAlert()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgRedAlert.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                dtEmail = objUser.GetEmailAddress(77)
                mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                dtEmail = objUser.GetEmailAddress(63)
                mail.CC.Add(dtEmail.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = " Red Alert: Cutting > 3 Reminders"
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Kaschif, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "System advise you to take immediate action against following order(s) having greater than three(03) reminders in <b>  cutting. </b> " & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "YOUR STAFF NOT UPDATING WIP. PLEASE INTIMATE ABOVE STAFF TO UPDATE WIP. " & _
                              "<br/>" & _
                             "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGriddgRedAlert()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgRedAlert.Visible = True
                strSortExpression = dgRedAlert.SortExpression
                dgRedAlert.DataSource = objDataView
                dgRedAlert.DataBind()
            Else
                dgRedAlert.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Sub SupplierMailBackup()
    '    Try
    '        Dim objPurchaseOrder As New PurchaseOrder
    '        Dim objWIPChart As New WIPChart
    '        Dim dt As DataTable
    '        Dim POLeadTime As Long
    '        Dim dtSupplier As DataTable
    '        dtSupplier = objPurchaseOrder.GetAllSupplierForMail()
    '        Dim i As Integer
    '        For i = 0 To dtSupplier.Rows.Count - 1
    '            dt = objPurchaseOrder.GetAllDataForMasterSupplierMail(dtSupplier.Rows(i)("VenderLibraryID"))
    '            dtEmail = dt.Clone()
    '            Dim x As Integer
    '            dtEmail = dt.Clone()
    '            For x = 0 To dt.Rows.Count - 1
    '                ' Yarn
    '                POLeadTime = dt.Rows(x)("TimeSpame")
    '                POLeadTime = (POLeadTime * 10) / 100
    '                Dim ProcessTargetDateYarn As Date = dt.Rows(x)("PlacementDate")
    '                ProcessTargetDateYarn = ProcessTargetDateYarn.AddDays(POLeadTime)
    '                If ProcessTargetDateYarn < Date.Now.Date Then
    '                    Dim dtWIPStatus As DataTable
    '                    dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
    '                    If dtWIPStatus.Rows.Count > 0 Then
    '                    Else
    '                        Dim drRow As DataRow = dt.Rows(x)
    '                        dtEmail.NewRow()
    '                        drRow.Item("Process") = "Yarn Procurement"
    '                        Dim dr As DataRow = drRow
    '                        dtEmail.ImportRow(drRow)
    '                    End If
    '                End If

    '                POLeadTime = dt.Rows(x)("TimeSpame")
    '                ' FabricInHouse
    '                POLeadTime = (POLeadTime * 45) / 100
    '                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDate")
    '                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)
    '                If ProcessTargetDate < Date.Now.Date Then
    '                    Dim dtWIPStatus As DataTable
    '                    dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
    '                    If dtWIPStatus.Rows.Count > 0 Then
    '                    Else
    '                        Dim drRow As DataRow = dt.Rows(x)
    '                        dtEmail.NewRow()
    '                        drRow.Item("Process") = "Fabric In House"
    '                        Dim dr As DataRow = drRow
    '                        dtEmail.ImportRow(drRow)
    '                    End If
    '                End If
    '                ' Cutting
    '                POLeadTime = dt.Rows(x)("TimeSpame")
    '                POLeadTime = (POLeadTime * 70) / 100
    '                Dim ProcessTargetDateCutting As Date = dt.Rows(x)("PlacementDate")
    '                ProcessTargetDateCutting = ProcessTargetDateCutting.AddDays(POLeadTime)
    '                If ProcessTargetDateCutting < Date.Now.Date Then
    '                    Dim dtWIPStatus As DataTable
    '                    dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
    '                    If dtWIPStatus.Rows.Count > 0 Then
    '                    Else
    '                        Dim drRow As DataRow = dt.Rows(x)
    '                        dtEmail.NewRow()
    '                        drRow.Item("Process") = "Cutting"
    '                        Dim dr As DataRow = drRow
    '                        dtEmail.ImportRow(drRow)
    '                    End If
    '                End If
    '            Next
    '            'Dim UserNames = From row In dtEmail.AsEnumerable()
    '            '            Select row.Field(Of String)("UserName") Distinct

    '            Dim ss As DataTable = dtEmail.DefaultView.ToTable(True, New String() {"UserName"})
    '            If ss.Rows.Count > 0 Then
    '                dtEmail2 = dtEmail.Clone
    '                Dim aa As Integer
    '                For aa = 0 To ss.Rows.Count - 1
    '                    dtEmail2.Rows.Clear()
    '                    Dim dr2 As DataRow() = dtEmail.Select("UserName = '" & ss.Rows(aa)("UserName") & "'")
    '                    For Each row As DataRow In dr2
    '                        dtEmail2.ImportRow(row)
    '                    Next

    '                    'Bind Grid
    '                    Dim objDataView As DataView
    '                    objDataView = LoadDataEmail2()
    '                    objDataView.Sort = "Process DESC"
    '                    Session("objDataView") = objDataView
    '                    BindGridSupplierNew()
    '                    Dim sb As New StringBuilder()
    '                    Dim sw As New StringWriter(sb)
    '                    Dim hw As New HtmlTextWriter(sw)
    '                    dgSupplierMailNew.RenderControl(hw)

    '                    'Email
    '                    Dim mail As MailMessage = New MailMessage()
    '                    Dim dtEmails As DataTable = objUser.GetSupplierEmail(dtSupplier.Rows(i)("VenderLibraryID"))
    '                    If dtEmails.Rows.Count > 0 Then
    '                        Dim ii As Integer
    '                        For ii = 0 To dtEmails.Rows.Count - 1
    '                            mail.To.Add(dtEmails.Rows(ii)("EmailAddress"))
    '                        Next

    '                        Dim dtCC As DataTable
    '                        Dim xx As Integer
    '                        dtCC = objUser.GetEmailAddress(77)
    '                        mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))
    '                        dtCC = objUser.GetEmailAddressMerchant(ss.Rows(aa)("UserName"))
    '                        mail.CC.Add(dtCC.Rows(xx)("EmailAddress"))

    '                        ' mail.Bcc.Add("zahidsajjad@hotmail.com")
    '                        mail.From = New MailAddress("zainab@eurocentrab2b.com")
    '                        mail.Subject = " TTD Notification For " & dtEmails.Rows(0)("VenderName") & " ECP Merchant:" & dtCC.Rows(0)("UserName") & ""
    '                        'Dim x As Integer
    '                        Dim Body As String = " " & _
    '                                     "<br/>" & _
    '                                     "<b> Dear " & dtEmails.Rows(0)("VenderName") & ",</b>" & _
    '                                       "<br/>" & _
    '                                       "<br/>" & _
    '                                     "Please update following task." & _
    '                                    "<br/>"
    '                        Body = Body + sb.ToString()
    '                        Body = Body + " </table> <br/>" & _
    '                                     "<br/>" & _
    '                                     " You are advise to contact key account manager and/or merchandiser in Euro Centra Pakistan. " & _
    '                                      "<br/>" & _
    '                                     "<br/>" & _
    '                                     "Thanks," & _
    '                                       "<br/>" & _
    '                                        "<br/>" & _
    '                                     "Best Regards/Freundliche gruesse" & _
    '                                      "<br/>" & _
    '                                     "<b>Zainab Ihsan</b>" & _
    '                                      "<br/>" & _
    '                                     "Assistant Manager Supply Chain" & _
    '                                      "<br/>" & _
    '                                     "Supply Chain and Business Development Group" & _
    '                                       "<br/>" & _
    '                                        "<br/>" & _
    '                                    "Powered By: Integra ERP" & _
    '                                            "<br/>" & _
    '                                    "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
    '                                       "<br/>"

    '                        mail.Body = Body
    '                        mail.IsBodyHtml = True
    '                        Dim smtp As SmtpClient = New SmtpClient()
    '                        smtp.Port = 25
    '                        smtp.Host = "mail.eurocentrab2b.com"
    '                        smtp.Credentials = New System.Net.NetworkCredential("zainab@eurocentrab2b.com", "zainab1013")
    '                        smtp.EnableSsl = False
    '                        smtp.Send(mail)
    '                    End If
    '                Next

    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub btnShrmlaYarn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShrmlaYarn.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendShrmlaEmailYarnProcurement()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendShrmlaEmailYarnProcurement()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dt = objPurchaseOrder.GetMasterOrderForCustomerMail()

            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                POLeadTime = (POLeadTime * 10) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDatee")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                objDataView.Sort = "VenderName ASC"
                Session("objDataView") = objDataView
                BindGridShrmla()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgShrmla.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTO As DataTable
                dtTO = objUser.GetEmailAddress(85)
                mail.To.Add(dtTO.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(77)
                mail.Bcc.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("sharmilam@eurocentrab2b.com")
                mail.Subject = "Order(s) critically delayed at Yarn Procurement."
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b>Dear Waqas, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                            "My " & dtEmail.Compute("Count(PONO)", "").ToString() & " orders having qty. " & Format(dtEmail.Compute("Sum(POQuantity)", ""), "##,###") & " seem to be delayed at cutting. Please expedite," & _
                             "<br/>" & _
                             "Following are the details:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "I do believe you will take corrective measure to avoid such happenings forward." & _
                              "<br/>" & _
                             "<br/>" & _
                            "Thanks," & _
                                   "<br/>" & _
                                    "<br/>" & _
                                 "Best Regards" & _
                                  "<br/>" & _
                                 "<b>Sharmila Makker</b>" & _
                                  "<br/>" & _
                                 "Sr. V.P. Sourcing & Production" & _
                                  "<br/>" & _
                                 "Marc Ecko Enterprises" & _
                                   "<br/>" & _
                                 "501 west 10th ave , 7th floor" & _
                                   "<br/>" & _
                                 "New York 10018" & _
                                   "<br/>" & _
                                 "New York" & _
                                   "<br/>" & _
                                    "<br/>" & _
                                "Powered By: Integra ERP" & _
                                        "<br/>" & _
                                "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                   "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("sharmilam@eurocentrab2b.com", "zainab1013")
                smtp.EnableSsl = False
                smtp.Send(mail)
                Threading.Thread.Sleep(5000)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridShrmla()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgShrmla.Visible = True
                strSortExpression = dgShrmla.SortExpression
                dgShrmla.DataSource = objDataView
                dgShrmla.DataBind()
            Else
                dgShrmla.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnShrmlaCutting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShrmlaCutting.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendShrmlaEmailCutting()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendShrmlaEmailCutting()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dt = objPurchaseOrder.GetMasterOrderForCustomerMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                POLeadTime = (POLeadTime * 70) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDatee")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                objDataView.Sort = "VenderName ASC"
                Session("objDataView") = objDataView
                BindGridShrmla()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgShrmla.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(85)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(77)
                mail.Bcc.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("sharmilam@eurocentrab2b.com")
                mail.Subject = "Order(s) critically delayed at Cutting."
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Waqas, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "My " & dtEmail.Compute("Count(PONO)", "").ToString() & " orders having qty. " & Format(dtEmail.Compute("Sum(POQuantity)", ""), "##,###") & " seem to be delayed at cutting. Please expedite," & _
                             "<br/>" & _
                             "Following are the details:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "I do believe you will take corrective measure to avoid such happenings forward." & _
                              "<br/>" & _
                             "<br/>" & _
                            "Thanks," & _
                                   "<br/>" & _
                                    "<br/>" & _
                                 "Best Regards" & _
                                  "<br/>" & _
                                 "<b>Sharmila Makker</b>" & _
                                  "<br/>" & _
                                 "Sr. V.P. Sourcing & Production" & _
                                  "<br/>" & _
                                 "Marc Ecko Enterprises" & _
                                   "<br/>" & _
                                 "501 west 10th ave , 7th floor" & _
                                   "<br/>" & _
                                 "New York 10018" & _
                                   "<br/>" & _
                                 "New York" & _
                                   "<br/>" & _
                                    "<br/>" & _
                                "Powered By: Integra ERP" & _
                                        "<br/>" & _
                                "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                   "<br/>"

                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("sharmilam@eurocentrab2b.com", "zainab1013")
                smtp.EnableSsl = False
                smtp.Send(mail)
                Threading.Thread.Sleep(5000)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShrmlaFabric_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShrmlaFabric.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendShrmlaEmailFabric()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendShrmlaEmailFabric()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer

            dt = objPurchaseOrder.GetMasterOrderForCustomerMail()
            dtEmail = dt.Clone()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim POLeadTime As Long = dt.Rows(x)("NewTimeSpame")
                POLeadTime = (POLeadTime * 45) / 100
                Dim ProcessTargetDate As Date = dt.Rows(x)("PlacementDatee")
                ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                If ProcessTargetDate < Date.Now.Date Then
                    'Now check in WIP this Aricle History
                    Dim dtWIPStatus As DataTable
                    dtWIPStatus = objWIPChart.GetPOForMasterMail(dt.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                    Else
                        Dim drRow As DataRow = dt.Rows(x)
                        dtEmail.NewRow()
                        Dim dr As DataRow = drRow
                        dtEmail.ImportRow(drRow)
                    End If
                End If
            Next

            If dtEmail.Rows.Count > 0 Then
                'Bind Grid
                Dim objDataView As DataView
                objDataView = LoadData()
                objDataView.Sort = "VenderName ASC"
                Session("objDataView") = objDataView
                BindGridShrmla()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgShrmla.RenderControl(hw)
                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(85)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(77)
                mail.Bcc.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("sharmilam@eurocentrab2b.com")
                mail.Subject = "Order(s) critically delayed at Fabric Procurement."
                'Dim x As Integer
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Waqas, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                           "My " & dtEmail.Compute("Count(PONO)", "").ToString() & " orders having qty. " & Format(dtEmail.Compute("Sum(POQuantity)", ""), "##,###") & " seem to be delayed at cutting. Please expedite," & _
                             "<br/>" & _
                             "Following are the details:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                             "<br/>" & _
                             "I do believe you will take corrective measure to avoid such happenings forward." & _
                              "<br/>" & _
                             "<br/>" & _
                            "Thanks," & _
                                   "<br/>" & _
                                    "<br/>" & _
                                 "Best Regards" & _
                                  "<br/>" & _
                                 "<b>Sharmila Makker</b>" & _
                                  "<br/>" & _
                                 "Sr. V.P. Sourcing & Production" & _
                                  "<br/>" & _
                                 "Marc Ecko Enterprises" & _
                                   "<br/>" & _
                                 "501 west 10th ave , 7th floor" & _
                                   "<br/>" & _
                                 "New York 10018" & _
                                   "<br/>" & _
                                 "New York" & _
                                   "<br/>" & _
                                    "<br/>" & _
                                "Powered By: Integra ERP" & _
                                        "<br/>" & _
                                "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                   "<br/>"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("sharmilam@eurocentrab2b.com", "zainab1013")
                smtp.EnableSsl = False
                smtp.Send(mail)
                Threading.Thread.Sleep(5000)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnTT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTT.Click
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objWIPChart As New WIPChart
            Dim dt As DataTable
            Dim dtMerchant As DataTable
            Dim xM As Integer
            Dim y As Long = 0
            For y = 0 To 6
                dtMerchant = objPurchaseOrder.GetAllMerchandiserForMail()
                For xM = 0 To dtMerchant.Rows.Count - 1
                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    dtEmail = objUser.GetEmailAddress(dtMerchant.Rows(xM)("userid"))
                    If dtEmail.Rows.Count > 0 Then
                        mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
                        Dim dtCC As DataTable
                        dtCC = objUser.GetEmailAddress(77)
                        mail.Bcc.Add(dtCC.Rows(0)("EmailAddress"))
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("shinezakir@eurocentrab2b.com")
                        mail.Subject = y.ToString() + " TTD for " + dtEmail.Rows(0)("UserName") + ":Test"
                        'Dim x As Integer
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                     "<b> Dear " + dtEmail.Rows(0)("UserName") + ", </b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Following Purchase Order have <b> fabric in house delayed </b>." & _
                                    "<br/>"
                        Body = Body + " </table> <br/>" & _
                                     "<br/>" & _
                                     "PLEASE UPDATE WIP. " & _
                                      "<br/>" & _
                                     "<br/>" & _
                                    "Thanks," & _
                                           "<br/>" & _
                                            "<br/>" & _
                                         "Best Regards/Freundliche gruesse" & _
                                          "<br/>" & _
                                         "<b>Zainab Ihsan</b>" & _
                                          "<br/>" & _
                                          "Deputy Manager" & _
                                          "<br/>" & _
                                         "Supply Chain and Business Development Group" & _
                                           "<br/>" & _
                                            "<br/>" & _
                                        "Powered By: Integra ERP" & _
                                                "<br/>" & _
                                        "Developed By:<a href=""http://www.itg.net.pk/contact.html"">Interactive Technologies Gateway</a>" & _
                                           "<br/>"
                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Port = 25
                        smtp.Host = "mail.eurocentrab2b.com"
                        smtp.Credentials = New System.Net.NetworkCredential("shinezakir@eurocentrab2b.com", "pakistan")
                        smtp.EnableSsl = False
                        smtp.Send(mail)
                        Threading.Thread.Sleep(5000)
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAutoWIP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAutoWIP.Click
        Try
            Dim objWIPChart As New WIPChart
            Dim dtMarchant As DataTable = objWIPChart.DistinctMarchant()
            Dim xx As Integer
            For xx = 0 To dtMarchant.Rows.Count - 1
                Dim dtWIP As DataTable = objWIPChart.AutoFillWIP(dtMarchant.Rows(xx)("marchandid"))
                Dim x As Integer
                For x = 0 To dtWIP.Rows.Count - 1
                    If dtWIP.Rows(x)("WIPProcessID") = 12 Then
                        'No entry in DB
                    Else
                        With objWIPChart
                            .WIPChartId = 0
                            .WIPProcessID = 12
                            .POID = dtWIP.Rows(x)("POID")
                            .POdetailID = dtWIP.Rows(x)("PODetailID")
                            .Remarks = "Good Released done by system, on account of merchant due to PO status = Shipped"
                            .Status = "Created"
                            .CreationDate = Date.Now
                            .Userid = dtWIP.Rows(x)("marchandid")
                            .SaveWIPChart()
                        End With
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUpdateTNA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateTNA.Click
        Try

            Dim objPurchaseOrder As New PurchaseOrder
            Dim DtPO As New DataTable
            Dim Dtprocess As DataTable
            Dim ObjTNAChart As New TNAChart
            Dim ObjTNAChartHistory As New TNAChartHistory
            Dim MADDate As Date
            Dim TimeSpame, x, i As Integer
            Dim PLacementDate As Date
            DtPO = objPurchaseOrder.GetAllPO

            For i = 0 To DtPO.Rows.Count - 1
                MADDate = DtPO.Rows(i)("ShipmentDate")
                PLacementDate = DtPO.Rows(i)("PLacementDate")
                TimeSpame = DtPO.Rows(i)("TimeSpame")
                If DtPO.Rows(i)("CustomerID") = 46 Then
                    Dtprocess = objPurchaseOrder.GetScheduleCELIO("ECP 01")
                    For x = 0 To Dtprocess.Rows.Count - 1
                        With ObjTNAChart
                            .IdealDate = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                            .ActualDate = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                            .DateEstemated = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                            .POID = DtPO.Rows(i)("POID")
                            .QtyCompleted = 0
                            .Remarks = " "
                            .Status = "Created"
                            .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                            .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                            .Selected = True
                            .SelectedStatus = "SELECTED"
                            .Parameter = 0
                            .ParameterUnit = ""
                            .TotalCapacity = 0
                            .CapacityUnit = ""
                            .Required = 0
                            .RequiredUnit = ""
                            .SaveTNAChart()
                        End With
                        '---------- Save into Chat History
                        With ObjTNAChartHistory
                            .CreationDate = Date.Now
                            .TNAChartID = ObjTNAChart.GetId
                            .IdealDate = ObjTNAChart.IdealDate
                            .DateEstemated = ObjTNAChart.DateEstemated
                            .ActualDate = ObjTNAChart.ActualDate
                            .QtyCompleted = 0
                            .Remarks = " "
                            .Status = "Created"
                            .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                            .Parameter = 0
                            .ParameterUnit = ""
                            .TotalCapacity = 0
                            .CapacityUnit = ""
                            .Required = 0
                            .RequiredUnit = ""
                            .SaveTNAChartHistory()
                        End With
                    Next
                Else
                    Dtprocess = objPurchaseOrder.GetScheduleNew("ECP 01")
                    For x = 0 To Dtprocess.Rows.Count - 1
                        With ObjTNAChart
                            .IdealDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                            .ActualDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                            .DateEstemated = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                            .POID = DtPO.Rows(i)("POID")
                            .QtyCompleted = 0
                            .Remarks = " "
                            .Status = "Created"
                            .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                            .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                            .Selected = True
                            .SelectedStatus = "SELECTED"
                            .Parameter = 0
                            .ParameterUnit = ""
                            .TotalCapacity = 0
                            .CapacityUnit = ""
                            .Required = 0
                            .RequiredUnit = ""
                            .SaveTNAChart()
                        End With
                        '---------- Save into Chat History
                        With ObjTNAChartHistory
                            .CreationDate = Date.Now
                            .TNAChartID = ObjTNAChart.GetId
                            .IdealDate = ObjTNAChart.IdealDate
                            .DateEstemated = ObjTNAChart.DateEstemated
                            .ActualDate = ObjTNAChart.ActualDate
                            .QtyCompleted = 0
                            .Remarks = " "
                            .Status = "Created"
                            .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                            .Parameter = 0
                            .ParameterUnit = ""
                            .TotalCapacity = 0
                            .CapacityUnit = ""
                            .Required = 0
                            .RequiredUnit = ""
                            .SaveTNAChartHistory()
                        End With
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Function AddDateCELIO(ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        dt = DateAddin.AddDays(-Days)
        Return dt
    End Function
    Function AddDate(ByVal TotalDays As Double, ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        Days = (TotalDays / 100) * Days
        dt = DateAddin.AddDays(Days)
        Return dt
    End Function
    Protected Sub btnBMMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBMMail.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendMerchantEmailYarnProcurement()
                SendMerchantEmailFabricInHouse()
                SendMerchantEmailCutting()

                'Now Save Mail Send Info Into Log Table
                With ObjUmUserLinkLog
                    .Logid = 0
                    .Userid = CLng(Session("Userid"))
                    .MailSenddate = Date.Now
                    .EmailStatus = "Email Send"
                    .SaveEmailSendInfo()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUpdateRevisedShipment11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateRevisedShipment11.Click
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
            Dim dt As DataTable = objPurchaseOrder.GetNedRevisdShip()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim dtRevs As DataTable = objPurchaseOrder.GetNedRevisdShipFromTest(dt.Rows(x)("POID"))
                If dtRevs.Rows.Count > 0 Then
                    With objPurchaseReviseShip
                        .POReviseShipmentID = 0
                        .POID = dtRevs.Rows(0)("POID")
                        .CreationDate = Date.Now()
                        .ShipmentDate = dtRevs.Rows(0)("ShipmentDate")
                        .SavePurchaseOrderReviseShipment()
                    End With
                Else
                    With objPurchaseReviseShip
                        .POReviseShipmentID = 0
                        .POID = dt.Rows(x)("POID")
                        .CreationDate = Date.Now()
                        .ShipmentDate = dt.Rows(x)("ShipmentDate")
                        .SavePurchaseOrderReviseShipment()
                    End With
                End If
               
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCP.Click
        Try
            Dim objCPChart As New CPChart
            Dim objCPChartHistory As New CPChartHistory
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dt As DataTable = objPurchaseOrder.GetMasterOrderForCelioNewOrderCCP()
            Dim x As Integer
            Dim a As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim dtt As DataTable = objCPChart.GetProcessFirstTime()
                For a = 0 To dtt.Rows.Count - 1
                    With objCPChart
                        .CPChartID = 0
                        .POID = dt.Rows(x)("POID")
                        .CreationDate = Date.Now()
                        .CPProcessID = dtt.Rows(a)("CPProcessID")
                        .Quantity = 0
                        .TargetSubmission = ""
                        .IstSubmission = ""
                        .DHLorFEDEX = ""
                        .FeedBackReceived = ""
                        .RevisedTarget = ""
                        .RevisedSubmission = ""
                        .DHLorFEDEX1 = ""
                        .FeedBackReceived1 = ""
                        .Remarks = ""
                        .SaveCPChart()
                    End With

                    With objCPChartHistory
                        .CPChartHistoryID = 0
                        .CreationDate = Date.Now()
                        .CPChartID = objCPChart.GetId()
                        .CPProcessID = dtt.Rows(a)("CPProcessID")
                        .Quantity = 0
                        .TargetSubmission = ""
                        .IstSubmission = ""
                        .DHLorFEDEX = ""
                        .FeedBackReceived = ""
                        .RevisedTarget = ""
                        .RevisedSubmission = ""
                        .DHLorFEDEX1 = ""
                        .FeedBackReceived1 = ""
                        .Remarks = ""
                        .SaveCPChartHistory()
                    End With
                Next
            Next


        Catch ex As Exception

        End Try
    End Sub
End Class
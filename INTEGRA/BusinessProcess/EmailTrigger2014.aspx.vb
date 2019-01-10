Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class EmailTrigger2014
    Inherits System.Web.UI.Page
    Dim objUser As New User
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub btnFabricCuttingYarnMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFabricCuttingYarnMail.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendOpenOrderSCM()
                SendOpenOrderMarchant()
                SendOpenOrderSupplier()
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
    Sub SendOpenOrderSCM()
        Try
            Dim objPurchaseOrderDetail As New PurchaseOrderDetail
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPurchaseOrderDetail.GetOpenOrdersSCM()
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                dgOpenOrder.Columns(5).Visible = False
                dgOpenOrder.Columns(10).Visible = False
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgOpenOrder.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = " Today open orders in system (SCM) "
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear SCM, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following orders placed today (" & Date.Now().ToString("dd/MM/yyyy") & ")." & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                              "<u> Notified parties: </u>" & _
                                   "<br/>" & _
                                 " Brand Managers" & _
                                   "<br/>" & _
                                 " Suppliers" & _
                                   "<br/>" & _
                                 " SCM" & _
                                 "<br/>" & _
                                   "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>" & _
                                "Developed By: " & _
                                 "<br/>" & _
                                 "<a href=""http://itg.net.pk/"">Interactive Technologies Gateway </a>" & _
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
        Catch ex As Exception
        End Try
    End Sub
    Sub SendOpenOrderMarchant()
        Try
            Dim objPurchaseOrderDetail As New PurchaseOrderDetail
            Dim dtMarchant As DataTable = objPurchaseOrderDetail.GetOpenOrdersDistinctMarchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrderDetail.GetOpenOrdersMarchant(dtMarchant.Rows(x)("Marchandid"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGrid()
                    dgOpenOrder.Columns(5).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgOpenOrder.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("Marchandid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Today open orders in system (BM) "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("Username") & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following orders placed today (" & Date.Now().ToString("dd/MM/yyyy") & ")." & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                 "<u> Notified parties: </u>" & _
                                   "<br/>" & _
                                 " Brand Managers" & _
                                   "<br/>" & _
                                 " Suppliers" & _
                                   "<br/>" & _
                                 " SCM" & _
                                 "<br/>" & _
                                   "<br/>" & _
                                 "Thanks," & _
                                   "<br/>" & _
                                    "<br/>" & _
                                 "Euro Centra B2B." & _
                                   "<br/>" & _
                                "Powered By: Integra ERP" & _
                                  "<br/>" & _
                                "Developed By: " & _
                                 "<br/>" & _
                                 "<a href=""http://itg.net.pk/"">Interactive Technologies Gateway </a>" & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendOpenOrderSupplier()
        Try
            Dim objPurchaseOrderDetail As New PurchaseOrderDetail
            Dim dtSupplier As DataTable = objPurchaseOrderDetail.GetOpenOrdersDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrderDetail.GetOpenOrdersSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGrid()
                    dgOpenOrder.Columns(5).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgOpenOrder.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Today open orders in system (Supplier) "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("Vendername") & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following orders <b> place in system today</b>." & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                 "<u> Notified parties: </u>" & _
                                   "<br/>" & _
                                 " Brand Managers" & _
                                   "<br/>" & _
                                 " Suppliers" & _
                                   "<br/>" & _
                                 " SCM" & _
                                 "<br/>" & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgOpenOrder.Visible = True
                strSortExpression = dgOpenOrder.SortExpression
                dgOpenOrder.DataSource = objDataView
                dgOpenOrder.DataBind()
            Else
                dgOpenOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        'base.VerifyRenderingInServerForm(control);
    End Sub
    Protected Sub btnNeworRepeatOrder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNeworRepeatOrder.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendNewOrRepeatOrderMarchant()
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
    Sub SendNewOrRepeatOrderMarchant()
        Try
            Dim objLeadTimeApproval As New LeadTimeApproved
            Dim dtMarchant As DataTable = objLeadTimeApproval.GetLeadTimeApprovalDistinctMarchant1()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable, objDataTable1 As DataTable
                    objDataTable = objLeadTimeApproval.GetLeadTimeApprovalForNewOrder(dtMarchant.Rows(x)("Marchandid"))
                    objDataTable1 = objLeadTimeApproval.GetLeadTimeApprovalForRepeatOrder(dtMarchant.Rows(x)("Marchandid"))
 
                    If objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count > 0 Then
                        objDataTable.Merge(objDataTable1)
                        objDataView = New DataView(objDataTable)
                    ElseIf objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count = 0 Then
                        objDataView = New DataView(objDataTable)
                    ElseIf objDataTable.Rows.Count = 0 And objDataTable1.Rows.Count > 0 Then
                        objDataView = New DataView(objDataTable1)
                    Else
                        objDataView = New DataView(objDataTable)
                    End If

                    Session("objDataView") = objDataView
                    BindGrid()
                    dgOpenOrder.Columns(5).Visible = True
                    dgOpenOrder.Columns(10).Visible = False

                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgOpenOrder.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("Marchandid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Lead Time Approval "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtMarchant.Rows(x)("Username").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following orders need <b> Lead Time Approval </b>." & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                "<br/>" & _
                                 "Please click on following link to approve above orders lead time." & _
                                "<br/>" & _
                                 "<a href=""http://184.173.211.234/ECPB2B/BusinessProcess/LeadTimeApprovalSheetPopup.aspx?Merchandid=" & dtMarchant.Rows(x)("Marchandid") & """>Lead time approval sheet.</a>" & _
                                  "<br/>" & _
                                  "<br/>" & _
                                       "<u> Note </u>" & _
                                         "<br/>" & _
      "Which orders we include in this email?" & _
        "<br/>" & _
      "If order status = initial, quantity < 5000 and lead time < 70 days" & _
        "<br/>" & _
      "If order status = repeat, quantity < 5000 and lead time < 30 days" & _
        "<br/>" & _
      "Why we consider this is necessary?" & _
        "<br/>" & _
      "In mail order business it is difficult to remember each orders lead time. If system highlight squeezed lead time," & _
        "<br/>" & _
     "it is suppose to be easy for you to deal with suppliers to ensure on-time deliveries. " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnInspection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInspection.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                SendPassInspectionSCM()
                ' SendFailInspectionSCM()
                SendPassInspectionMerchant()
                'SendFailInspectionMerchant()
                ' SendPassInspectionSupplier()
                ' SendFailInspectionSupplier()

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
    Sub SendPassInspectionSCM()
        Try
            Dim objQDInspection As New QDInspection
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objQDInspection.GetPassInspectionSCM()
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGridInspection()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgInspectionAlert.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(22)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "MGT - Daily inspection status those PASSED"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear SCM, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following inspection passed by QD team today:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
        Catch ex As Exception
        End Try
    End Sub
    Sub SendFailInspectionSCM()
        Try
            Dim objQDInspection As New QDInspection
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objQDInspection.GetFailInspectionSCM()
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGridInspection()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgInspectionAlert.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "MGT- Daily inspection status those FAILED"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear SCM, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following inspection failed by QD team today:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
        Catch ex As Exception
        End Try
    End Sub
    Sub SendPassInspectionMerchant()
        Try
            Dim objQDInspection As New QDInspection
            Dim dtMarchant As DataTable = objQDInspection.GetPassInspectionBMDistinctMerchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objQDInspection.GetPassInspectionMarchant(dtMarchant.Rows(x)("Marchandid"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGridInspection()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionAlert.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("Marchandid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "BM- Daily inspection status those PASSED"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following inspection passed by QD team today:" & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                 "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendFailInspectionMerchant()
        Try
            Dim objQDInspection As New QDInspection
            Dim dtMarchant As DataTable = objQDInspection.GetFailInspectionBMDistinctMerchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objQDInspection.GetFailInspectionMarchant(dtMarchant.Rows(x)("Marchandid"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGridInspection()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionAlert.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("Marchandid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "BM- Daily inspection status those FAILED "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following inspection failed by QD team today:" & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendPassInspectionSupplier()
        Try
            Dim objQDInspection As New QDInspection
            Dim dtSupplier As DataTable = objQDInspection.GetPassInspectionDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objQDInspection.GetPassInspectionSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGridInspection()
                    dgInspectionAlert.Columns(3).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionAlert.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Supplier-Daily inspection status those PASSED "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(x)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following inspection passed by QD team today:" & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                               "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendFailInspectionSupplier()
        Try
            Dim objQDInspection As New QDInspection
            Dim dtSupplier As DataTable = objQDInspection.GetFailInspectionDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objQDInspection.GetFailInspectionSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGridInspection()
                    dgInspectionAlert.Columns(3).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionAlert.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Supplier-Daily inspection status those FAILED "
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(x)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following inspection failed by QD team today:" & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                               "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridInspection()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgInspectionAlert.Visible = True
                strSortExpression = dgInspectionAlert.SortExpression
                dgInspectionAlert.DataSource = objDataView
                dgInspectionAlert.DataBind()
            Else
                dgInspectionAlert.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnNoCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNoCertificate.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                NoSupplierCertificate()

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
    Sub NoSupplierCertificate()
        Try
            Dim objVenderCertificate As New VenderCertificate
            Dim dtObjTable As DataTable = objVenderCertificate.NoCertificate()
            If dtObjTable.Rows.Count > 0 Then
                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(73)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Social Compliance Required"
                Dim x As Integer
                Dim strVenderName As String = ""
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following supplier(s) social compliance required in system." & _
                            "<br/>"
                For x = 0 To dtObjTable.Rows.Count - 1
                    strVenderName = strVenderName + "<br/>" + dtObjTable.Rows(x)("Vendername")
                Next
                Body = Body + strVenderName
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
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnVAF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVAF.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                NoVAFFoundInCurrentYear()

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
    Sub NoVAFFoundInCurrentYear()
        Try
            Dim objVender As New Vender
            Dim dtObjTable As DataTable = objVender.GetVenderForNoVAF()
            If dtObjTable.Rows.Count > 0 Then
                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(73)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(28)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "VAF Required"
                Dim x As Integer
                Dim strVenderName As String = ""
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following supplier(s) VAF required for the year " & Date.Now.Year.ToString() & " in system." & _
                            "<br/>"
                For x = 0 To dtObjTable.Rows.Count - 1
                    strVenderName = strVenderName + "<br/>" + dtObjTable.Rows(x)("Vendername")
                Next
                Body = Body + strVenderName
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
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnInspectionRoster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInspectionRoster.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendInspectionRosterForNextWeekSCM()
                SendInspectionRosterForNextWeekMarchant()
                SendInspectionRosterForNextWeekSupplier()

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
    Sub SendInspectionRosterForNextWeekSCM()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtObjTable As DataTable = objPurchaseOrder.SendInspectionRosterForNextWeek()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewInspRoster") = objDataView
                BindGridInspectionRoster()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgInspectionRoster.RenderControl(hw)


                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Inspection Roster for week: " + dtObjTable.Rows(0)("ProcessWeekNo").ToString()
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Orders have inspection plan in upcoming week." & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub SendInspectionRosterForNextWeekMarchant()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtMarchant As DataTable = objPurchaseOrder.SendInspectionRosterForNextWeekDistinctMarchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrder.SendInspectionRosterForNextWeekMarchant(dtMarchant.Rows(x)("Marchandid"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewInspRoster") = objDataView
                    BindGridInspectionRoster()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionRoster.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("Marchandid"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " BM- Inspection Roster for week: " + objDataTable.Rows(0)("ProcessWeekNo").ToString()
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following Orders have inspection plan in upcoming week." & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendInspectionRosterForNextWeekSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtSupplier As DataTable = objPurchaseOrder.SendInspectionRosterForNextWeekDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrder.SendInspectionRosterForNextWeekSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataView") = objDataView
                    BindGridInspectionRoster()
                    dgInspectionAlert.Columns(3).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgInspectionRoster.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = " Supplier-Inspection Roster for week: " + objDataTable.Rows(0)("ProcessWeekNo").ToString()
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(x)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                  "Following Orders have inspection plan in upcoming week." & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridInspectionRoster()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewInspRoster")
            If objDataView.Count > 0 Then
                dgInspectionRoster.Visible = True
                strSortExpression = dgInspectionRoster.SortExpression
                dgInspectionRoster.DataSource = objDataView
                dgInspectionRoster.DataBind()
            Else
                dgInspectionRoster.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnWeeklySamplingPass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWeeklySamplingPass.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                WeeklySamplingPassSCM()
                WeeklySamplingPassSCMMarchant()

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
    Sub WeeklySamplingPassSCM()
        Try
            Dim objECPSampling As New ECPSampling
            Dim dtObjTable As DataTable = objECPSampling.GetDataForSCMMail()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewWeeklySamplingPass") = objDataView
                BindGridWeeklySamplingPass()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgWeeklySamplingPass.RenderControl(hw)


                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(87)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "MGT - Weekly sample status those passed by PD team ‏"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following samples passed by PD team this week:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub WeeklySamplingPassSCMMarchant()
        Try
            Dim objECPSampling As New ECPSampling
            Dim dtMarchant As DataTable = objECPSampling.GetDataForMailDistinctMerchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objECPSampling.GetDataForMailMarchant(dtMarchant.Rows(x)("UserID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewWeeklySamplingPass") = objDataView
                    BindGridWeeklySamplingPass()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgWeeklySamplingPass.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("UserID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "BM- Weekly sample status those passed by PD team"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following samples passed by PD team this week:" & _
                            "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridWeeklySamplingPass()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewWeeklySamplingPass")
            If objDataView.Count > 0 Then
                dgWeeklySamplingPass.Visible = True
                strSortExpression = dgWeeklySamplingPass.SortExpression
                dgWeeklySamplingPass.DataSource = objDataView
                dgWeeklySamplingPass.DataBind()
            Else
                dgWeeklySamplingPass.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnWeeklySamplingFail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWeeklySamplingFail.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then

                WeeklySamplingFailSCM()
                WeeklySamplingFailSCMMarchant()

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
    Sub WeeklySamplingFailSCM()
        Try
            Dim objECPSampling As New ECPSampling
            Dim dtObjTable As DataTable = objECPSampling.GetDataForSCMMailFail()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewWeeklySamplingFail") = objDataView
                BindGridWeeklySamplingFail()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgWeeklySamplingPass.RenderControl(hw)


                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(87)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "MGT - Weekly sample status those failed by PD team"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following samples failed by PD team this week:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                           "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub WeeklySamplingFailSCMMarchant()
        Try
            Dim objECPSampling As New ECPSampling
            Dim dtMarchant As DataTable = objECPSampling.GetDataForMailDistinctMerchantFail()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objECPSampling.GetDataForMailMarchantFail(dtMarchant.Rows(x)("UserID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewWeeklySamplingFail") = objDataView
                    BindGridWeeklySamplingFail()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgWeeklySamplingPass.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("UserID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "BM- Weekly sample status those failed by PD team"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following samples failed by PD team this week:" & _
                            "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Product Development Manager" & _
                              "<br/>" & _
                       "Brand Managers" & _
                         "<br/>" & _
                          "SCM " & _
                            "<br/>" & _
                           "MGT " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridWeeklySamplingFail()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewWeeklySamplingFail")
            If objDataView.Count > 0 Then
                dgWeeklySamplingPass.Visible = True
                strSortExpression = dgWeeklySamplingPass.SortExpression
                dgWeeklySamplingPass.DataSource = objDataView
                dgWeeklySamplingPass.DataBind()
            Else
                dgWeeklySamplingPass.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCuttingApproval_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCuttingApproval.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendTodayCuttingApprovalSummaryMailSCM()
                SendTodayCuttingApprovalSummaryMailMarchant()
                ' SendTodayCuttingApprovalSummaryMailSupplier()
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
    Sub SendTodayCuttingApprovalSummaryMailSCM()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtObjTable As DataTable = objPurchaseOrder.GetDataForCuttingApprovalMail()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewCuttingApproved") = objDataView
                BindGridCuttingApproved()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgCuttingApproved.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                Dim dtCC As DataTable
                dtCC = objUser.GetEmailAddress(22)
                mail.CC.Add(dtCC.Rows(0)("EmailAddress"))

                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert- Cutting Approval by ECP "
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "This is a formal notification that granted by PDM to proceed for bulk cutting in following orders:" & _
                            "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                              "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Supplier" & _
                              "<br/>" & _
                       "Product Development Manager" & _
                         "<br/>" & _
                          "Brand Managers " & _
                            "<br/>" & _
                           "SCM  " & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub SendTodayCuttingApprovalSummaryMailMarchant()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtMarchant As DataTable = objPurchaseOrder.GetDataForCuttingApprovalMailDistinctMerchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrder.GetDataForCuttingApprovalMailMerchant(dtMarchant.Rows(x)("MarchandID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewCuttingApproved") = objDataView
                    BindGridWeeklySamplingFail()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgCuttingApproved.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("MarchandID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "Alert- Today Cutting Approved"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                   "This is a formal notification that granted by PDM to proceed for bulk cutting in following orders:" & _
                            "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Supplier" & _
                              "<br/>" & _
                       "Product Development Manager" & _
                         "<br/>" & _
                          "Brand Managers " & _
                            "<br/>" & _
                           "SCM  " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendTodayCuttingApprovalSummaryMailSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtSupplier As DataTable = objPurchaseOrder.GetDataForCuttingApprovalMailDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrder.GetDataForCuttingApprovalMailSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewCuttingApproved") = objDataView
                    BindGridInspectionRoster()
                    dgInspectionAlert.Columns(3).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgCuttingApproved.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "Alert- Today Cutting Approved"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(x)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                   "This is a formal notification that granted by PDM to proceed for bulk cutting in following orders:" & _
                                "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                               "<br/>" & _
                           "<u> Notified parties: </u> " & _
                             "<br/>" & _
                            "Supplier" & _
                              "<br/>" & _
                       "Product Development Manager" & _
                         "<br/>" & _
                          "Brand Managers " & _
                            "<br/>" & _
                           "SCM  " & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridCuttingApproved()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewCuttingApproved")
            If objDataView.Count > 0 Then
                dgCuttingApproved.Visible = True
                strSortExpression = dgCuttingApproved.SortExpression
                dgCuttingApproved.DataSource = objDataView
                dgCuttingApproved.DataBind()
            Else
                dgCuttingApproved.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btninlineinspection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btninlineinspection.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendTodayInlineInspectionDue()
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
    Sub SendTodayInlineInspectionDue()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objQDInspection As New QDInspection

            Dim dtObjTable As DataTable = objPurchaseOrder.GetDataForInlineIspectionMail()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewCuttingApproved") = objDataView
                BindGridCuttingApproved()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgCuttingApproved.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)  'irfanameer ko mail jane chaye, as ka mail address table dalna hai wd id
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))
               
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert- First Inline Inspection Due"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Orders need first inline inspection." & _
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
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn2inlineinspection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn2inlineinspection.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendToday2ndInlineInspectionDue()
                SendToday2ndInlineInspectionDueSupplier()
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
    Sub SendToday2ndInlineInspectionDue()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objQDInspection As New QDInspection

            Dim dtObjTable As DataTable = objPurchaseOrder.GetDataFor2ndInlineIspectionMail()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewCuttingApproved") = objDataView
                BindGridCuttingApproved()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgCuttingApproved.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)  'irfanameer ko mail jane chaye, as ka mail address table dalna hai wd id
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))

                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert- 2nd Inline Inspection Due"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Orders need 2nd inline inspection." & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub SendToday2ndInlineInspectionDueSupplier()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtSupplier As DataTable = objPurchaseOrder.GetDataFor2ndInlineIspectionMailDistinctSupplier()
            If dtSupplier.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtSupplier.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = objPurchaseOrder.GetDataFor2ndInlineIspectionMailSupplier(dtSupplier.Rows(x)("SupplierID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewCuttingApproved") = objDataView
                    BindGridCuttingApproved()
                    dgInspectionAlert.Columns(3).Visible = False
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgCuttingApproved.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.GetSupplierEmail(dtSupplier.Rows(x)("SupplierID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "Alert- 2nd Inline Inspection Due"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtSupplier.Rows(x)("Vendername").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "Following Orders need 2nd inline inspection." & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnFinalInspectionPlanning_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalInspectionPlanning.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendFinalInspectionPlanning()
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
    Sub SendFinalInspectionPlanning()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objQDInspection As New QDInspection

            Dim dtObjTable As DataTable = objPurchaseOrder.SendFinalInspectionPlanning()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewCuttingApproved") = objDataView
                BindGridCuttingApproved()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgCuttingApproved.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)  'irfanameer ko mail jane chaye, as ka mail address table dalna hai wd id
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))

                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert- Final Inspection Planning Sheet"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Orders need Final Inspection Planning." & _
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
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnokaytoship_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnokaytoship.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendOktoShip()
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
    Sub SendOktoShip()
        Try
            Dim ObjShippedApproval As New ShippedApproval
            Dim dtMarchant As DataTable = ObjShippedApproval.GetDataForShippedApprovalDistinct()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = ObjShippedApproval.GetDataForShippedApproval(dtMarchant.Rows(x)("MarchandID"))
                    objDataView = New DataView(objDataTable)

                    Session("objDataViewCuttingApproved") = objDataView
                    BindGridCuttingApproved()
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgCuttingApproved.RenderControl(hw)

                    'Email
                    Dim mail As MailMessage = New MailMessage()
                    Dim dtTo As DataTable
                    dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("MarchandID"))
                    mail.To.Add(dtTo.Rows(0)("EmailAddress"))
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    mail.From = New MailAddress("noreply@eurocentrab2b.com")
                    mail.Subject = "Alert- Ok to Ship"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                   "<br/>" & _
                                   "<br/>" & _
                                   "Following Orders need OK to Ship approval." & _
                            "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                  "Please click on following link to approve above orders ok to ship." & _
                                "<br/>" & _
                                 "<a href=""http://184.173.211.234/ECPB2B/BusinessProcess/ShippedApproval.aspx?MarchandID=" & dtMarchant.Rows(x)("Marchandid") & """>Ok to ship approval sheet.</a>" & _
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
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCloseOrders_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCloseOrders.Click
        Try
            Dim ObjUmUserLinkLog As New UmUserLinkLog
            Dim DtEmailInfo As New DataTable
            DtEmailInfo = ObjUmUserLinkLog.GetEmailSendInfo()
            If DtEmailInfo.Rows.Count = 0 Then
                SendCloseOrdersSCM()
                SendCloseOrdersBM()
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
    Sub SendCloseOrdersSCM()
        Try
            Dim objPurchaseOrder As New PurchaseOrder

            Dim dtObjTable As DataTable = objPurchaseOrder.SendCloseOrders()
            If dtObjTable.Rows.Count > 0 Then
                Dim objDataView As DataView
                objDataView = New DataView(dtObjTable)
                Session("objDataViewCuttingApproved") = objDataView
                BindGridCuttingApproved()
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgCuttingApproved.RenderControl(hw)

                'Email
                Dim mail As MailMessage = New MailMessage()
                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))

                mail.Bcc.Add("zahidsajjad@hotmail.com")
                mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert- Today Close Orders"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Orders Closed today." & _
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
        Catch ex As Exception

        End Try
    End Sub
    Sub SendCloseOrdersBM()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dtMarchant As DataTable = objPurchaseOrder.SendCloseOrdersDistinctMerchant()
            If dtMarchant.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtMarchant.Rows.Count - 1
                    Dim dtObjTable As DataTable = objPurchaseOrder.SendCloseOrdersForMarchant(dtMarchant.Rows(x)("Marchandid"))
                    If dtObjTable.Rows.Count > 0 Then
                        Dim objDataView As DataView
                        objDataView = New DataView(dtObjTable)
                        Session("objDataViewCuttingApproved") = objDataView
                        BindGridCuttingApproved()
                        Dim sb As New StringBuilder()
                        Dim sw As New StringWriter(sb)
                        Dim hw As New HtmlTextWriter(sw)
                        dgCuttingApproved.RenderControl(hw)

                        'Email
                        Dim mail As MailMessage = New MailMessage()
                        Dim dtTo As DataTable
                        dtTo = objUser.MarchantMailAddress(dtMarchant.Rows(x)("MarchandID"))
                        mail.To.Add(dtTo.Rows(0)("EmailAddress"))

                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        mail.From = New MailAddress("noreply@eurocentrab2b.com")
                        mail.Subject = "Alert- Today Close Orders"
                        Dim Body As String = " " & _
                                     "<br/>" & _
                                    "<b> Dear " & dtTo.Rows(0)("UserName").ToString() & ", </b>" & _
                                       "<br/>" & _
                                       "<br/>" & _
                                     "Following Orders Closed today." & _
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
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
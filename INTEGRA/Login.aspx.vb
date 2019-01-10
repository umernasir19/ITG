Imports Integra.EuroCentra
Imports System.Data
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Partial Class Login
    Inherits System.Web.UI.Page
    Dim UserLogined As New UserLogined
    Dim dtemail As New DataTable
    Dim ObjUmUserLinkLog As New UmUserLinkLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        Dim objUser As New User
        Dim objUserLog As New UserLog
        Dim objDataTable As DataTable
        Dim objDataRow As DataRow
        Dim Uid As Long
        lblErrorMsg.Text = ""
        If IsPostBack Then
            Try
                If objUser.Validate(txtUserCodee.Text, txtPasswordd.Text) Then
                    objUserLog = New UserLog
                    objDataTable = objUser.GetUsers(1, , txtUserCodee.Text, )
                    objDataRow = objDataTable.Rows(0)
                    Session("UserId") = objDataRow("UserId")
                    Dim objUserId As Integer
                    Dim objRoleId As Integer
                    Dim objDataTable1 As DataTable
                    Dim objDataRow1 As DataRow
                    objUserId = Session("UserId")
                    objDataTable1 = objUser.GetRoles(objUserId)
                    objDataRow1 = objDataTable1.Rows(0)
                    Session("RoleId") = objDataRow1("RoleId")
                    objRoleId = Session("RoleId")
                    Session("BranchCode") = objDataTable.Rows(0)("BranchCode")
                    Session("UserCode") = Trim(CType(objDataRow("UserCode"), String))
                    Session("UserName") = Trim(CType(objDataRow("UserName"), String))
                    Session("SupplierId") = objDataTable.Rows(0)("EmployeeId")
                    Uid = objUserId
                    If objDataTable.Rows(0)("counterid") = "1" Then
                        lblErrorMsg.Text = ""
                        With UserLogined
                            .loginedDate = Date.Now.ToShortDateString
                            .LoginTime = Now.ToShortTimeString
                            .UserID = objUserId
                            .SaveUser()
                        End With
                        Dim dtMar As DataTable = UserLogined.getMarchandNew()
                        Dim x As Integer = 0
                        For x = 0 To dtMar.Rows.Count - 1
                            Dim Userid As Long = dtMar.Rows(x)("Userid")
                            'SendEMailsFor3ndRem(Userid)
                            ' SendEMailsFor2ndRem(Userid)
                            'SendKKintsEMailsForAll(Userid)
                            With ObjUmUserLinkLog
                                .Logid = 0
                                .Userid = CLng(Userid)
                                .MailSenddate = Date.Now
                                .EmailStatus = "Email Send"
                                .SaveEmailSendInfo()
                            End With
                        Next
                    Else
                        lblErrorMsg.Text = "You are not allowed to login."
                    End If
                End If
            Catch ec As Exception
                If ec.GetType().FullName = "USRMERP.UDException" Then
                    lblErrorMsg.Text = CType(ec, UDException).Description
                Else
                    lblErrorMsg.Text = ec.Message
                End If
            End Try
            If lblErrorMsg.Text = "" Then
                If lblErrorMsg.Text = "" Then
                    If Session("RoleId") = 40 Then
                        HttpContext.Current.Response.Redirect("~/BusinessProcess/JobOrderDatabaseView.aspx")
                    ElseIf Session("RoleId") = 41 Then
                        Dim firstYear As String = Date.Now.Year.ToString()
                        Dim secondYear As String = (Convert.ToInt32(Date.Now.Year) + 1).ToString()
                        Session("Session") = Date.Now.Year.ToString() & "-" & secondYear.Substring(2, 2).ToString()
                        Session("YearFirst") = "07/01/" & firstYear
                        Session("YearSecond") = "06/30/" & secondYear
                        HttpContext.Current.Response.Redirect("~/MainPage.aspx")
                    Else
                        HttpContext.Current.Response.Redirect("~/MainPage.aspx")
                    End If
                End If
            End If
        End If
    End Sub
    Sub SendKKintsEMailsForAll(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim DtEmailInfo As DataTable
            DtEmailInfo = objEmailSendPO.GetEmailSendInfoData(Userid)
            If Not DtEmailInfo.Rows.Count = 0 Then
            Else
                Dim dtorder, dtEmailAddress As DataTable
                Dim ObjPurchaseorder As New PurchaseOrder
                Dim Estdate As Date = Date.Now.AddDays(1)
                Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objEmailSendPO.GetEmailAlterNew(Userid, Estdatee)
                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count > 0 Then
                        'Fabric
                        SendKKintsEMailsForAllFabricZubair(Userid)
                        SendKKintsEMailsForAllFabricIbrahim(Userid)
                        SendKKintsEMailsForAllFabricSaman(Userid)
                        SendKKintsEMailsForAllFabricghayas(Userid)
                        '-------------------------------------------
                        'acc
                        SendKKintsEMailsForAllaCCHaider(Userid)
                        SendKKintsEMailsForAllaCCAdnan(Userid)
                        SendKKintsEMailsForAllaCCShakeel(Userid)
                        '-------------------------------------------
                        'swing
                        SendKKintsEMailsForAllSamanSwing(Userid)
                        '---------------------------------

                        SendKKintsEMailsForAllAliRazaSwing(Userid)
                        '-----------------------------------------
                        dgknitsemail.DataSource = dt
                        dgknitsemail.DataBind()
                        dgknitsemail.Visible = True
                    End If
                    Dim x As Long
                    For x = 0 To dgknitsemail.Items.Count - 1
                        With objEmailReminder
                            .ReminderID = 0
                            .POID = dgknitsemail.Items(x).Cells(0).Text
                            .ProcessID = dgknitsemail.Items(x).Cells(8).Text
                            .NoofReminder = 1
                            .Status = dgknitsemail.Items(x).Cells(9).Text
                            .ProcessActive = 1
                            .SaveEmailReminder()
                        End With
                    Next
                    dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                    dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                    dgknitsemail.HeaderStyle.Font.Name = "verdana"
                    dgknitsemail.ForeColor = Drawing.Color.Black
                    dgknitsemail.Font.Name = "verdana"
                    dgknitsemail.Font.Size = 8
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgknitsemail.RenderControl(hw)
                    Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                    dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                    If dtEmailAddress.Rows.Count > 0 Then
                        Dim mail As MailMessage = New MailMessage()
                        mail.To.Add("digapp@digitalapparels.com")
                        mail.Bcc.Add("Salahuddin@itg.net.pk")
                        mail.Bcc.Add("yasiransari2288@gmail.com")
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        If dteamilcc.Rows.Count > 0 Then
                            For y = 0 To dteamilcc.Rows.Count - 1
                                mail.CC.Add(dteamilcc.Rows(y)("EmailAddress"))
                            Next
                        End If
                        Dim objEmailSendPOO As New EmailSendPO
                        Dim dty As DataTable = objEmailSendPOO.GetnAMEUser(Userid)
                        Dim UserName As String = dty.Rows(0)("UserName")
                        mail.From = New MailAddress("erpnoreplyy@gmail.com")
                        mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                        Dim Body As String = " " & _
                            "<br/>" & _
                            "<b> Dear Merchandiser, </b>" & _
                              "<br/>" & _
                              "<br/>" & _
                            "System noticed that following processes will done by tomorrow.</b>" & _
                          "<br/>" & _
                            "Please update the system if process is done.</b>" & _
"<br/>" & _
                           "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                    "<br/>" & _
                                         "<br/>" & _
                                            "<br/>" & _
                                     "Thanks" & _
                                       "<br/>" & _
                                    "Digital Apparel ERP System " & _
                                     "<br/>" & _
                                      "<br/>" & _
                                     "************* This is System generated email and does not required reply *******************"
                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Host = "smtp.gmail.com"
                        smtp.Port = 587
                        smtp.UseDefaultCredentials = True
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                        smtp.EnableSsl = True
                        smtp.Timeout = 50000
                        smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                        smtp.Send(mail)
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRem(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim DtEmailInfo As DataTable
            DtEmailInfo = objEmailSendPO.GetEmailSendInfoData(Userid)
            If Not DtEmailInfo.Rows.Count = 0 Then
            Else
                Dim dtorder, dtEmailAddress As DataTable
                Dim ObjPurchaseorder As New PurchaseOrder
                Dim Estdate As Date = Date.Now
                Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNew(Userid, Estdatee)
                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count > 0 Then
                        'fabric
                        SendEMailsFor2ndRemFabricZubair(Userid)
                        SendEMailsFor2ndRemFabricIbrahim(Userid)
                        SendEMailsFor2ndRemFabricSaman(Userid)
                        SendEMailsFor2ndRemFabricghayas(Userid)
                        '------------------------------------------
                        'acc
                        SendEMailsFor2ndRemaCCHaider(Userid)
                        SendEMailsFor2ndRemaCCAdnan(Userid)
                        SendEMailsFor2ndRemaCCShakeel(Userid)
                        '--------------------------------------------
                        'swing
                        SendEMailsFor2ndRemSamanSwing(Userid)
                        '------------------------------------------
                        SendEMailsFor2ndRemAlirAZASwing(Userid)
                        '----------------------------------------
                        dgemailAdmin.DataSource = dt
                        dgemailAdmin.DataBind()
                        dgemailAdmin.Visible = True
                    End If
                    Dim x As Long
                    For x = 0 To dgemailAdmin.Items.Count - 1
                        objEmailSendPO.UpdatAlertsNO(dt.Rows(x)("POID"), dt.Rows(x)("TNAProcessID"), 2)
                    Next
                    dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                    dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                    dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                    dgemailAdmin.ForeColor = Drawing.Color.Black
                    dgemailAdmin.Font.Name = "verdana"
                    dgemailAdmin.Font.Size = 8
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgemailAdmin.RenderControl(hw)
                    Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                    dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                    If dtEmailAddress.Rows.Count > 0 Then
                        Dim mail As MailMessage = New MailMessage()
                        mail.To.Add("digapp@digitalapparels.com")
                        mail.Bcc.Add("Salahuddin@itg.net.pk")
                        mail.Bcc.Add("yasiransari2288@gmail.com")
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        If dteamilcc.Rows.Count > 0 Then
                            For y = 0 To dteamilcc.Rows.Count - 1
                                mail.CC.Add(dteamilcc.Rows(y)("EmailAddress"))
                            Next
                        End If
                        Dim objEmailSendPOO As New EmailSendPO
                        Dim dty As DataTable = objEmailSendPOO.GetnAMEUser(Userid)
                        Dim UserName As String = dty.Rows(0)("UserName")
                        mail.From = New MailAddress("erpnoreplyy@gmail.com")
                        mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                        Dim Body As String = " " & _
                            "<br/>" & _
                            "<b> Dear Merchandiser, </b>" & _
                              "<br/>" & _
                              "<br/>" & _
                            "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                          "<br/>" & _
                            "Please update the system if process is done.</b>" & _
"<br/>" & _
                           "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                    "<br/>" & _
                                         "<br/>" & _
                                            "<br/>" & _
                                     "Thanks" & _
                                       "<br/>" & _
                                    "Digital Apparel ERP System" & _
                                     "<br/>" & _
                                      "<br/>" & _
                                     "************* This is System generated email and does not required reply *******************"
                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Host = "smtp.gmail.com"
                        smtp.Port = 587
                        smtp.UseDefaultCredentials = True
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                        smtp.EnableSsl = True
                        smtp.Timeout = 50000
                        smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                        smtp.Send(mail)
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRem(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim DtEmailInfo As DataTable
            DtEmailInfo = objEmailSendPO.GetEmailSendInfoData(Userid)
            If Not DtEmailInfo.Rows.Count = 0 Then
            Else
                Dim dtorder, dtEmailAddress As DataTable
                Dim ObjPurchaseorder As New PurchaseOrder
                Dim Estdate As Date = Date.Now.AddDays(-1)
                Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNew(Userid, Estdatee)
                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count > 0 Then
                        'FABRIC
                        SendEMailsFor3ndRemFabricZubair(Userid)
                        SendEMailsFor3ndRemFabricIbrahim(Userid)
                        SendEMailsFor3ndRemFabricSaman(Userid)
                        SendEMailsFor3ndRemFabricGhayas(Userid)
                        '------------------------------------------
                        'ACC
                        SendEMailsFor3ndRemACCHaider(Userid)
                        SendEMailsFor3ndRemACCAdnan(Userid)
                        SendEMailsFor3ndRemACCShakeel(Userid)
                        '----------------------------------------
                        'swing
                        SendEMailsFor3ndRemSamanSwing(Userid)
                        '-------------------------------------------
                        SendEMailsFor3ndRemSamanSwingAliRaza(Userid)
                        '--------------------------------------------
                        dgemail3rem.DataSource = dt
                        dgemail3rem.DataBind()
                        dgemail3rem.Visible = True
                    End If
                    Dim x As Long
                    For x = 0 To dgemail3rem.Items.Count - 1
                        objEmailSendPO.UpdatAlertsNO(dt.Rows(x)("POID"), dt.Rows(x)("TNAProcessID"), 3)
                    Next
                    dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                    dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                    dgemail3rem.HeaderStyle.Font.Name = "verdana"
                    dgemail3rem.ForeColor = Drawing.Color.Black
                    dgemail3rem.Font.Name = "verdana"
                    dgemail3rem.Font.Size = 8
                    Dim sb As New StringBuilder()
                    Dim sw As New StringWriter(sb)
                    Dim hw As New HtmlTextWriter(sw)
                    dgemail3rem.RenderControl(hw)
                    Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                    dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                    Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                    If dtEmailAddress.Rows.Count > 0 Then
                        Dim mail As MailMessage = New MailMessage()
                        mail.To.Add("digapp@digitalapparels.com")
                        mail.Bcc.Add("Salahuddin@itg.net.pk")
                        mail.Bcc.Add("yasiransari2288@gmail.com")
                        mail.Bcc.Add("zahidsajjad@hotmail.com")
                        If dteamilcc.Rows.Count > 0 Then
                            For y = 0 To dteamilcc.Rows.Count - 1
                                mail.CC.Add(dteamilcc.Rows(y)("EmailAddress"))
                            Next
                        End If
                        If dtRem2cc.Rows.Count > 0 Then
                            For y = 0 To dtRem2cc.Rows.Count - 1
                                mail.CC.Add(dtRem2cc.Rows(y)("EmailAddress"))
                            Next
                        End If
                        Dim objEmailSendPOO As New EmailSendPO
                        Dim dty As DataTable = objEmailSendPOO.GetnAMEUser(Userid)
                        Dim UserName As String = dty.Rows(0)("UserName")
                        mail.From = New MailAddress("erpnoreplyy@gmail.com")
                        mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                        Dim Body As String = " " & _
                            "<br/>" & _
                            "<b> Dear Merchandiser, </b>" & _
                              "<br/>" & _
                              "<br/>" & _
                            "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                          "<br/>" & _
                            "Please update the system if process is done.</b>" & _
"<br/>" & _
                           "<br/>"
                        Body = Body + sb.ToString()
                        Body = Body + " </table> <br/>" & _
                                    "<br/>" & _
                                         "<br/>" & _
                                            "<br/>" & _
                                     "Thanks" & _
                                       "<br/>" & _
                                    "Digital Apparel ERP System" & _
                                     "<br/>" & _
                                      "<br/>" & _
                                     "************* This is System generated email and does not required reply *******************"
                        mail.Body = Body
                        mail.IsBodyHtml = True
                        Dim smtp As SmtpClient = New SmtpClient()
                        smtp.Host = "smtp.gmail.com"
                        smtp.Port = 587
                        smtp.UseDefaultCredentials = True
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                        smtp.EnableSsl = True
                        smtp.Timeout = 50000
                        smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                        smtp.Send(mail)
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllFabricZubair(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForFabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Zubair"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System " & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllFabricIbrahim(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForFabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Ibrahim"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System " & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllFabricSaman(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForFabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Saman"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System " & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllFabricghayas(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForFabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Ghayas"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System " & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllaCCHaider(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForAccess(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Haider"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System " & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllaCCAdnan(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForAccess(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Adnan"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System " & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllaCCShakeel(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForAccess(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Shakeel"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System " & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllSamanSwing(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForSwing(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Saman"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System " & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendKKintsEMailsForAllAliRazaSwing(ByVal Userid As Long)
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.GetEmailAlterNewForSwingAliRaza(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgknitsemail.DataSource = dt
                    dgknitsemail.DataBind()
                    dgknitsemail.Visible = True
                End If
                dgknitsemail.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgknitsemail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgknitsemail.HeaderStyle.Font.Name = "verdana"
                dgknitsemail.ForeColor = Drawing.Color.Black
                dgknitsemail.Font.Name = "verdana"
                dgknitsemail.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgknitsemail.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Ali Raza"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "System noticed that following processes will done by tomorrow.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System " & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemFabricZubair(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim UserName As String = "Zubair"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemFabricIbrahim(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw) 
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Ibrahim"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemFabricSaman(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim objEmailSendPOO As New EmailSendPO
                    Dim UserName As String = "Saman"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemFabricghayas(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim objEmailSendPOO As New EmailSendPO
                    Dim UserName As String = "Ghayas"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                                 "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemaCCHaider(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim objEmailSendPOO As New EmailSendPO
                Dim UserName As String = "Haider"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemaCCAdnan(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim objEmailSendPOO As New EmailSendPO
                Dim UserName As String = "Adnan"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemaCCShakeel(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim objEmailSendPOO As New EmailSendPO
                Dim UserName As String = "Shakeel"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemSamanSwing(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForSwing(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim objEmailSendPOO As New EmailSendPO
                Dim UserName As String = "Saman"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor2ndRemAlirAZASwing(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid2ndRemNewForSwingaLIrAZA(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemailAdmin.DataSource = dt
                    dgemailAdmin.DataBind()
                    dgemailAdmin.Visible = True
                End If
                dgemailAdmin.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemailAdmin.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemailAdmin.HeaderStyle.Font.Name = "verdana"
                dgemailAdmin.ForeColor = Drawing.Color.Black
                dgemailAdmin.Font.Name = "verdana"
                dgemailAdmin.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemailAdmin.RenderControl(hw)
                Dim mail As MailMessage = New MailMessage()
                mail.To.Add("digapp@digitalapparels.com")
                mail.Bcc.Add("Salahuddin@itg.net.pk")
                mail.Bcc.Add("yasiransari2288@gmail.com")
                mail.Bcc.Add("zahidsajjad@hotmail.com")
                Dim objEmailSendPOO As New EmailSendPO
                Dim UserName As String = "Ali Raza"
                mail.From = New MailAddress("erpnoreplyy@gmail.com")
                mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                Dim Body As String = " " & _
                    "<br/>" & _
                    "<b> Dear User, </b>" & _
                      "<br/>" & _
                      "<br/>" & _
                    "This is 2nd reminder and should take as priority that following processes have not been executed yet.</b>" & _
                  "<br/>" & _
                    "Please update the system if process is done.</b>" & _
"<br/>" & _
                   "<br/>"
                Body = Body + sb.ToString()
                Body = Body + " </table> <br/>" & _
                            "<br/>" & _
                                 "<br/>" & _
                                    "<br/>" & _
                             "Thanks" & _
                               "<br/>" & _
                            "Digital Apparel ERP System" & _
                             "<br/>" & _
                              "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.UseDefaultCredentials = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.EnableSsl = True
                smtp.Timeout = 50000
                smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                smtp.Send(mail)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemFabricZubair(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Zubair"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemFabricIbrahim(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Ibrahim"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemFabricSaman(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Saman"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemFabricGhayas(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForfabric(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Saman"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemACCHaider(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Haider"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemACCAdnan(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Adnan"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemACCShakeel(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForaCCESS(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Shakeel"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemSamanSwing(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForSwing(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Saman"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEMailsFor3ndRemSamanSwingAliRaza(ByVal Userid As Long)
        Try
            Dim ObjEmailRemainder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim dtorder, dtEmailAddress As DataTable
            Dim ObjPurchaseorder As New PurchaseOrder
            Dim Estdate As Date = Date.Now.AddDays(-1)
            Dim Estdatee As String = Estdate.ToString("dd/MM/yyyy")
            Dim dt As DataTable = objEmailSendPO.EmailGrid3rdRemNewForSwingAliRaza(Userid, Estdatee)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 0 Then
                    dgemail3rem.DataSource = dt
                    dgemail3rem.DataBind()
                    dgemail3rem.Visible = True
                End If
                dgemail3rem.HeaderStyle.BackColor = Drawing.Color.LightBlue
                dgemail3rem.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
                dgemail3rem.HeaderStyle.Font.Name = "verdana"
                dgemail3rem.ForeColor = Drawing.Color.Black
                dgemail3rem.Font.Name = "verdana"
                dgemail3rem.Font.Size = 8
                Dim sb As New StringBuilder()
                Dim sw As New StringWriter(sb)
                Dim hw As New HtmlTextWriter(sw)
                dgemail3rem.RenderControl(hw)
                Dim dteamilcc As DataTable = objEmailSendPO.GetEmailCC()
                dtEmailAddress = objEmailSendPO.GetEmailAddressnEW(Userid)
                Dim dtRem2cc As DataTable = objEmailSendPO.GetEmailCCReminder3("Reminder3")
                If dtEmailAddress.Rows.Count > 0 Then
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("digapp@digitalapparels.com")
                    mail.Bcc.Add("Salahuddin@itg.net.pk")
                    mail.Bcc.Add("yasiransari2288@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    Dim UserName As String = "Ali Raza"
                    mail.From = New MailAddress("erpnoreplyy@gmail.com")
                    mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
                    Dim Body As String = " " & _
                        "<br/>" & _
                        "<b> Dear User, </b>" & _
                          "<br/>" & _
                          "<br/>" & _
                        "This is final notice and 3rd reminder to inform you that the  following processes have not been executed. This may lead to order delays. </b>" & _
                      "<br/>" & _
                        "Please update the system if process is done.</b>" & _
"<br/>" & _
                       "<br/>"
                    Body = Body + sb.ToString()
                    Body = Body + " </table> <br/>" & _
                                "<br/>" & _
                                     "<br/>" & _
                                        "<br/>" & _
                                 "Thanks" & _
                                   "<br/>" & _
                                "Digital Apparel ERP System" & _
                                 "<br/>" & _
                                  "<br/>" & _
                             "************* This is System generated email and does not required reply *******************"
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = True
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                    smtp.EnableSsl = True
                    smtp.Timeout = 50000
                    smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
                    smtp.Send(mail)
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkFortgetPassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkFortgetPassword.Click
        Response.Write("<script> window.open('ForgetPassword.aspx?', 'newwindow', 'left=250, top=250, height=300, width=590, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0'); </script>")
    End Sub   
    Sub TestEmail()
        Try
            Dim objEmailReminder As New EmailReminder
            Dim objEmailSendPO As New EmailSendPO
            Dim objUser As New User
            Dim DtEmailInfo As DataTable
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgknitsemail.RenderControl(hw)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add("digapp@digitalapparels.com")
            mail.Bcc.Add("yasiransari2288@gmail.com")
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            Dim objEmailSendPOO As New EmailSendPO
            Dim dt As DataTable = objEmailSendPOO.GetnAMEUser(260)
            Dim UserName As String = dt.Rows(0)("UserName")
            mail.From = New MailAddress("erpnoreplyy@gmail.com")
            mail.Subject = UserName + " - " + "ERP SYSTEM NOTIFICATION "
            Dim Body As String = " " & _
                "<br/>" & _
                "<b> Dear Merchandiser, </b>" & _
                  "<br/>" & _
                  "<br/>" & _
                "System noticed that following processes will done by tomorrow.</b>" & _
              "<br/>" & _
                "Please update the system if process is done.</b>" & _
"<br/>" & _
               "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                        "<br/>" & _
                             "<br/>" & _
                                "<br/>" & _
                         "Thanks" & _
                           "<br/>" & _
                        "Digital Apparel ERP System " & _
                         "<br/>" & _
                          "<br/>" & _
                         "************* This is System generated email and does not required reply *******************"
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 587
            smtp.Host = "smtp.gmail.com"
            smtp.Timeout = 500000
            smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")
            smtp.EnableSsl = True
            smtp.Send(mail)
        Catch ex As Exception
        End Try
    End Sub
End Class
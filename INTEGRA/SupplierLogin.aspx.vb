Imports Integra.EuroCentra
Imports System.Data
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Public Class SupplierLogin
    Inherits System.Web.UI.Page
    Dim UserLogined As New UserLogined
    Dim dtemail As New DataTable
    Dim ObjUser As New User
    Dim ObjVender As New Vender
    Dim objDataTable As New DataTable
    Dim objtree As New Tree
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        Try
            Dim objUser As New User
            Dim objUserLog As New UserLog
            Dim objDataRow As DataRow
            Dim Uid As Long
            lblErrorMsg.Text = ""
            If IsPostBack Then
                Try
                    If objUser.Validate(txtUserCode.Text, txtPassword.Text) Then
                        objUserLog = New UserLog
                        objDataTable = objUser.GetUsers(1, , txtUserCode.Text, )
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
                        Session("SupplierId") = objDataTable.Rows(0)("EmployeeId")
                        Session("ECPDivistion") = objDataTable.Rows(0)("ECPDivistion")
                        Session("UserCode") = Trim(CType(objDataRow("UserCode"), String))
                        Uid = objUserId

                        If objDataTable.Rows(0)("EmployeeId") = "0" Then
                            lblErrorMsg.Text = "You are not allowed to login."
                        Else
                            lblErrorMsg.Text = ""
                            With UserLogined
                                .loginedDate = Date.Now.ToShortDateString
                                .LoginTime = Now.ToShortTimeString
                                .UserID = objUserId
                                .SaveUser()
                            End With
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
                    Dim dt As DataTable = objtree.GetMembersTree(CLng(Session("Userid")))

                    Dim aa As String = ObjVender.EncryptData(objDataTable.Rows(0)("EmployeeId"))
                    Dim aas As String = ObjVender.DecryptString(aa)
                    Dim x As Long
                    For x = 0 To dt.Rows.Count - 1
                        ' objtree.UpdateRMForm(dt.Rows(x)("FormId"), (dt.Rows(x)("Link")) + "?SupplierID=" & ObjVender.EncryptData(objDataTable.Rows(0)("EmployeeId")) & "")

                        'objtree.UpdateRMForm(dt.Rows(x)("FormId"), "BusinessProcess/VafView.aspx" + "?SupplierID=" & ObjVender.EncryptData(objDataTable.Rows(0)("EmployeeId")) & "")

                    Next
                    HttpContext.Current.Response.Redirect("~/BusinessProcess/VafView.aspx?SupplierID=" & ObjVender.EncryptData(objDataTable.Rows(0)("EmployeeId")) & "")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnregister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregister.Click
        Try
            If txtFirstName.Text = "" Then
                lblmsg.Text = "First Name empty"
            ElseIf txtCompanyName.Text = "" Then
                lblmsg.Text = "Company Name empty"
            ElseIf txtPhoneNo.Text = "" Then
                lblmsg.Text = "Phone No empty"
            ElseIf txtEmail.Text = "" Then
                lblmsg.Text = "Email empty"
            Else
                'checking
                Dim dt As DataTable = ObjVender.ChkSupplier(txtExisting.Text)
                If dt.Rows.Count > 0 Then
                    'Existing
                Else
                    'new
                    txtExisting.Text = ""
                End If

                If txtExisting.Text = "" Then
                    lblmsg.Text = ""
                    With ObjVender
                        .SupplierStatus = ""
                        .VenderName = txtCompanyName.Text
                        .VenderCode = ""
                        .Address1 = ""
                        .Address2 = ""
                        .ZipCode = ""
                        .PhoneNumber = txtPhoneNo.Text
                        .City = 942
                        .CountryID = 171
                        .ShortName = txtCompanyName.Text
                        .FaxNo = ""
                        .IsActive = False
                        .Website = ""
                        .LongitudeandLatitude = ""
                        Dim CurrentVenderID As Long = Convert.ToInt32(ObjVender.GetCurrentId) + 1
                        .imgOriginalLogo = "SupplierImages/" & CurrentVenderID & "/Logo/no-image.jpg"
                        .imgWaterMark = "SupplierImages/" & CurrentVenderID & "/WaterMarked/no-image.jpg"
                        .VAF = "SupplierImages/" & CurrentVenderID & "/VAF/no-image.jpg"
                        .VAFuploadDate = ""
                        .SaveVender()
                    End With
                End If
                With ObjUser
                    .UserId = 0
                    .UserCode = LCase(txtCompanyName.Text).ToString() + ".vaf"
                    If txtExisting.Text = "" Then
                        .EmployeeId = ObjVender.GetCurrentId()
                    Else
                        .EmployeeId = txtExisting.Text
                    End If

                    .Password = "itg1013"
                    .LocationId = "1"
                    .IsActive = True
                    .BranchCode = "1"
                    .CounterID = "0"
                    .UserName = txtFirstName.Text + " " + txtLastName.Text
                    .ECPDivistion = "Supplier"
                    .Designation = "CEO"
                    .Question = "What is Your Security Code?"
                    .Answer = "ECP1100"
                    .InspCode = ""
                    .image = ""
                    .SaveUser()

                End With
                If txtExisting.Text = "" Then
                    ObjUser.UpdateEmailAddress(ObjUser.GetCurrentUserId(), ObjVender.GetCurrentId(), txtEmail.Text)
                Else
                    ObjUser.UpdateEmailAddress(ObjUser.GetCurrentUserId(), txtExisting.Text, txtEmail.Text)
                End If


                'Role ID =25 is VAF Role
                ObjUser.UpdateRMUserRoles(ObjUser.GetCurrentUserId())

                'Mail
                If txtExisting.Text = "" Then
                    Dim dtEmail As DataTable
                    dtEmail = ObjUser.GetVafEmail(ObjUser.GetCurrentUserId())
                    Dim mail As MailMessage = New MailMessage()
                    mail.To.Add("atteqa@gmail.com")
                    mail.Bcc.Add("zahidsajjad@hotmail.com")
                    'mail.To.Add("Muhammad.salman90@live.com")

                    'mail.Bcc.Add("nizam149@gmail.com")
                    mail.From = New MailAddress("noreply.integra@itg.net.pk")
                    mail.Subject = "Supplier registered: " + txtCompanyName.Text + ", waiting for login credentials"
                    Dim Body As String = " " & _
                                 "<br/>" & _
                                 "Dear Madam," & _
                                   "<br/>" & _
                                   "<br/>" & _
                                 "A new supplier registered in <b> GIA </b> with following Information."
                    Body = Body + " " & _
                                 "<br/>" & _
                                 "<br/>" & _
                                 "<b>Supplier: " & dtEmail.Rows(0)("VenderName") & "" & _
                                 "<br/>" & _
                                  "Person Name: " & dtEmail.Rows(0)("Username") & "" & _
                                 "<br/>" & _
                                  "Phone No.: " & dtEmail.Rows(0)("PhoneNumber") & "" & _
                                 "<br/>" & _
                                 "Email: " & dtEmail.Rows(0)("EmailAddress") & "  </b>" & _
                                 "<br/>" & _
                                 "<br/>" & _
                                 "Kindly allot him/her user id and password and forward them." & _
                                  "<br/>" & _
                                 "<br/>" & _
                                  "Thanks" & _
                                   "<br/>" & _
                                  "GIA" & _
                                   "<br/>" & _
                                     "<br/>" & _
                                   "Powered By: Integra ERP "
                    mail.Body = Body
                    mail.IsBodyHtml = True
                    Dim smtp As SmtpClient = New SmtpClient()
                    smtp.Port = 25
                    smtp.Host = "mail.itg.net.pk"
                    smtp.Credentials = New System.Net.NetworkCredential("noreply.integra@itg.net.pk", "noreply")
                    smtp.EnableSsl = False
                    smtp.Send(mail)

                    'End Mail
                End If

                lblmsg.Text = "Account Registered, We will revert back to you."
                txtCompanyName.Text = ""
                txtEmail.Text = ""
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtPhoneNo.Text = ""
                txtExisting.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub


End Class
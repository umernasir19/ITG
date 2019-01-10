Imports Integra.EuroCentra
Imports System.Data
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Partial Class ForgetPassword
    Inherits System.Web.UI.Page
    Dim objUser As New User
    Dim objUserProfile As New UserProfile
    Dim dt As New System.Data.DataTable
    Dim UserCode As String
    Dim UserIDCurrent As Long
    Dim ECPDivistion, Designation, Question, Answer, UserName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Panel2.Visible = True
        Panel2.Visible = False
        btncheck.Visible = False
    End Sub
    Protected Sub btncheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheck.Click
        If btncheck.Text = "Check" Then
            'UserCode = txtUserName.Text
            'GetSecurityQByUserCode()
        ElseIf btncheck.Text = "Next" Then
            UserCode = txtUserName.Text
            CheckSecurityQandAnswer()
        ElseIf btncheck.Text = "Change Password" Then
            If txtPassword.Text = "" Or txtRepassword.Text = "" Then
            ElseIf txtPassword.Text <> "" Or txtRepassword.Text <> "" Then
                If txtPassword.Text = txtPassword.Text Then
                    With objUser
                        UserCode = ttxtUserCode.Text
                        GetAllFileds()
                        .ECPDivistion = ECPDivistion
                        .Designation = Designation
                        .Question = Question
                        .Answer = Answer
                        .UserName = UserName
                        .EmployeeId = "0"
                        .IsActive = "1"
                        .UserCode = ttxtUserCode.Text
                        .Password = txtPassword.Text
                        .UserId = Convert.ToInt64(lblUserIDHide.Text)
                        .SaveUser(Convert.ToInt64(lblUserIDHide.Text))
                        lblUserIDHide.Text = "Password Change"
                        lblMsgShow.Visible = True
                    End With
                Else
                    lblUserIDHide.Text = "Password Didn't  Match"
                End If
                lblUserIDHide.Text = "Password Required"
            End If
        End If
    End Sub
    Sub GetSecurityQByUserCode()
        'txtUserName.Enabled = False
        Dim dtUser As DataTable
        dtUser = objUser.GetSecurityQbyUserCode(UserCode)
        If dtUser.Rows.Count = 0 Then
            lbSecurityQ.Text = "No Security Question in Database"
            txtUserName.Enabled = True
        Else
            lbSecurityQ.Text = dtUser.Rows(0)("Question")
            btncheck.Visible = True
            btncheck.Text = "Next"
            btnShow.Visible = False
            txtUserName.Enabled = False
        End If
    End Sub
    Sub CheckSecurityQandAnswer()
        Dim dtUser As DataTable
        dtUser = objUser.GetUserByCheckAnswer(UserCode, txtAnswer.Text)
        'lblUserIDHide.Text = dtUser.Rows(0)("userid")
        If dtUser.Rows.Count = 0 Then
            Label1.Text = "Please Enter Correct Answer"
            btncheck.Visible = True
        Else
            lblUserIDHide.Text = dtUser.Rows(0)("userid")
            Label1.Text = "Ok"
            ttxtUserCode.Text = txtUserName.Text
            ttxtUserCode.Enabled = False
            Panel2.Visible = True
            Panel1.Visible = False
            btncheck.Text = "Change Password"
            btncheck.Visible = True
        End If
    End Sub
    Sub GetAllFileds()
        Dim dtUser As DataTable
        dtUser = objUser.GetAllFields(UserCode)
        ECPDivistion = dtUser.Rows(0)("ECPDivistion")
        Designation = dtUser.Rows(0)("Designation")
        Question = dtUser.Rows(0)("Question")
        Answer = dtUser.Rows(0)("Answer")
        UserName = dtUser.Rows(0)("UserName")
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            If btncheck.Text = "Check" Then
                UserCode = txtUserName.Text
                GetSecurityQByUserCode()
            ElseIf btncheck.Text = "Next" Then
                UserCode = txtUserName.Text
                CheckSecurityQandAnswer()
            ElseIf btncheck.Text = "Change Password" Then
                If txtPassword.Text = "" Or txtRepassword.Text = "" Then
                ElseIf txtPassword.Text <> "" Or txtRepassword.Text <> "" Then
                    If txtPassword.Text = txtPassword.Text Then
                        With objUser
                            UserCode = ttxtUserCode.Text
                            GetAllFileds()
                            .ECPDivistion = ECPDivistion
                            .Designation = Designation
                            .Question = Question
                            .Answer = Answer
                            .UserName = UserName
                            .EmployeeId = "0"
                            .IsActive = "1"
                            .UserCode = ttxtUserCode.Text
                            .Password = txtPassword.Text
                            .UserId = Convert.ToInt64(lblUserIDHide.Text)
                            .SaveUser(Convert.ToInt64(lblUserIDHide.Text))
                            lblUserIDHide.Text = "Password Change"
                        End With
                    Else
                        lblUserIDHide.Text = "Password Didn't  Match"
                    End If
                    lblUserIDHide.Text = "Password Required"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
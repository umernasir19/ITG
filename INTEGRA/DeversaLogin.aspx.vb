Imports Integra.EuroCentra
Imports System.Data
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Public Class DeversaLogin
    Inherits System.Web.UI.Page
    Dim UserLogined As New UserLogined
    Dim dtemail As New DataTable
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
                    Session("SupplierId") = objDataTable.Rows(0)("EmployeeId")
                    Uid = objUserId
                    If objDataTable.Rows(0)("InspCode") = "1" Then
                        lblErrorMsg.Text = ""
                        With UserLogined
                            .loginedDate = Date.Now.ToShortDateString
                            .LoginTime = Now.ToShortTimeString
                            .UserID = objUserId
                            .SaveUser()
                        End With
                    Else
                        lblErrorMsg.Text = "You are not allowed to login."

                    End If
                    'Else
                    '    lblErrorMsg.Text = "<font color='Red'><b>You are already logged in from another location </b></font> "
                End If

            Catch ec As Exception
                If ec.GetType().FullName = "USRMERP.UDException" Then
                    lblErrorMsg.Text = CType(ec, UDException).Description
                Else
                    lblErrorMsg.Text = ec.Message
                End If

            End Try
            If lblErrorMsg.Text = "" Then
                ' Response.Redirect("CustomerProfileView.aspx")
                If lblErrorMsg.Text = "" Then
                    HttpContext.Current.Response.Redirect("~/D_StyleLibraryMainView.aspx")
                End If

            End If
        End If
    End Sub
    Protected Sub lnkFortgetPassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkFortgetPassword.Click
        Response.Write("<script> window.open('ForgetPassword.aspx?', 'newwindow', 'left=250, top=250, height=300, width=590, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0'); </script>")
    End Sub

End Class
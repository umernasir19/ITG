Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class UserAdd
    Inherits System.Web.UI.Page
    Dim ObjUser As New User
    Dim ObjUserProfile As New UserProfile
    Dim nUserId As Short
    Dim strUserName As String
    Dim objRole As New Role
    Dim objUserRoles As New UserRoles
    Dim objFormRoles As New FormRoles
    Dim objFormRolesNew As New FormRolesNew
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        nUserId = CInt(Request.QueryString("nUserId"))
        If Not Page.IsPostBack Then
            Try
                If nUserId > 0 Then
                    SetValues()
                Else
                End If
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("User Add Page")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub SetValues()
        Dim dt As New DataTable
        dt = ObjUser.getPicture(nUserId)
        txtUMUserCodee.Text = dt.Rows(0)("UserCode")
        txtUMPasswordd.Attributes("value") = dt.Rows(0)("Password").ToString()
        chkIsActive.Checked = dt.Rows(0)("IsActive")
        txtUserName.Text = dt.Rows(0)("UserName")
        txtDivision.Text = dt.Rows(0)("ECPDivistion")
        txtDesignation.Text = dt.Rows(0)("Designation")
        txtQuestion.Text = dt.Rows(0)("Question")
        txtAnswer.Text = dt.Rows(0)("Answer")
        cmbDepartment.SelectedItem.Text = dt.Rows(0)("Department")
    End Sub
    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Try
            If cmbDepartment.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Department.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjUser
                    If nUserId > 0 Then
                        .UserId = nUserId
                    Else
                        .UserId = 0
                        .ViewNotification = False
                        .SaveNotification = False
                        .CancelNotification = False
                    End If
                    .UserCode = txtUMUserCodee.Text
                    .EmployeeId = 0
                    .Password = txtUMPasswordd.Text
                    .IsActive = chkIsActive.Checked
                    .UserName = txtUserName.Text
                    .ECPDivistion = txtUserName.Text
                    .Designation = txtDesignation.Text
                    .Question = txtQuestion.Text
                    .Answer = txtAnswer.Text
                    .CounterID = 1
                    .BranchCode = 1
                    .InspCode = 1
                    .Department = cmbDepartment.SelectedItem.Text
                    .SaveUser()
                End With
                If nUserId > 0 Then
                Else
                    With objRole
                        .RoleId = 0
                        .Name = txtUserName.Text
                        .Description = txtUserName.Text
                        .IsActive = True
                        .RoleTypeId = 7
                        .HierarchySequence = 70
                        .SaveRole()
                    End With
                    With objUserRoles
                        .UserRoleId = 0
                        .IsActive = True
                        .UserId = ObjUser.GetId()
                        .RoleId = objRole.GetID()
                        .SaveUserRole()
                    End With
                End If
                Response.Redirect("UserView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect("UserView.aspx")
    End Sub
End Class

Imports System.Data
Imports Integra.EuroCentra
Imports SmartControls.Controls
Public Class UserRightsView
    Inherits System.Web.UI.Page
    Dim UserId As Long
    Dim ObjUser As New User
    Dim objRole As New Role
    Dim objUserRoles As New UserRoles
    Dim objFormRoles As New FormRoles
    Dim objFormRolesNew As New FormRolesNew
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = CInt(Request.QueryString("nUserId"))
        Response.Expires = 0
        If Not Page.IsPostBack Then
            Try
                Dim dtName As DataTable = ObjUser.GetName(UserId)
                If dtName.Rows.Count > 0 Then
                    lblUserName.Text = dtName.Rows(0)("UserName")
                End If
                BindAllowedMenuGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("User Rights View")
    End Sub
    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Response.Redirect("UserView.aspx")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub UpdateStatusAdd(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer
        For x = 0 To dgUserAllow.Items.Count - 1
            Dim ChkAdd As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkAdd"), CheckBox)
            Dim ID As Integer = dgUserAllow.Items(x).Cells(3).Text
            Dim AddStatus As String = dgUserAllow.Items(x).Cells(4).Text
            If ChkAdd.Checked = True Then
                objFormRolesNew.UpdateAddStatus(ID)
            ElseIf ChkAdd.Checked = False Then
                objFormRolesNew.DisUpdateAddStatus(ID)
            End If
        Next
        BindAllowedMenuGrid()
    End Sub
    Protected Sub UpdateStatusView(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer
        For x = 0 To dgUserAllow.Items.Count - 1
            Dim ChkView As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkView"), CheckBox)
            Dim ID As Integer = dgUserAllow.Items(x).Cells(3).Text
            Dim AddStatus As String = dgUserAllow.Items(x).Cells(5).Text
            If ChkView.Checked = True Then
                objFormRolesNew.UpdateViewStatus(ID)
            ElseIf ChkView.Checked = False Then
                objFormRolesNew.DisUpdateViewStatus(ID)
            End If
        Next
        BindAllowedMenuGrid()
    End Sub
    Protected Sub UpdateStatusDelete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer
        For x = 0 To dgUserAllow.Items.Count - 1
            Dim ChkDelete As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkDelete"), CheckBox)
            Dim ID As Integer = dgUserAllow.Items(x).Cells(3).Text
            Dim AddStatus As String = dgUserAllow.Items(x).Cells(6).Text
            If ChkDelete.Checked = True Then
                objFormRolesNew.UpdateDeleteStatus(ID)
            ElseIf ChkDelete.Checked = False Then
                objFormRolesNew.DisUpdateDeleteStatus(ID)
            End If
        Next
        BindAllowedMenuGrid()
    End Sub
    Protected Sub dgUserAllow_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgUserAllow.ItemCommand
        Try
            Select Case e.CommandName
                Case "Delete"
                    Dim FormRoleID As Long = dgUserAllow.Items(e.Item.ItemIndex).Cells(3).Text
                    ObjUser.DeleteMenuNew(FormRoleID)
                    BindAllowedMenuGrid()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub BindAllowedMenuGrid()
        Dim dt As DataTable = ObjUser.getAllOWEDDataNew(UserId)
        dgUserAllow.DataSource = dt
        dgUserAllow.DataBind()
        Dim x As Integer
        For x = 0 To dgUserAllow.Items.Count - 1
            Dim ChkAdd As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkAdd"), CheckBox)
            Dim ChkView As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkView"), CheckBox)
            Dim ChkDelete As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkDelete"), CheckBox)
            Dim AddStatus As String = dgUserAllow.Items(x).Cells(4).Text
            Dim ViewStatus As String = dgUserAllow.Items(x).Cells(5).Text
            Dim DeleteStatus As String = dgUserAllow.Items(x).Cells(6).Text
            If AddStatus = 1 Then
                ChkAdd.Checked = True
            Else
                ChkAdd.Checked = False
            End If
            If ViewStatus = 1 Then
                ChkView.Checked = True
            Else
                ChkView.Checked = False
            End If
            If DeleteStatus = 1 Then
                ChkDelete.Checked = True
            Else
                ChkDelete.Checked = False
            End If
        Next
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports SmartControls.Controls
Public Class UserPermissionView
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
                BindAllMenuGrid()
                BindAllowedMenuGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("User Permission View")
    End Sub
    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Response.Redirect("UserView.aspx")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub UpdateStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer
        For x = 0 To dgAllMenu.Items.Count - 1
            Dim ChkDownLoad As CheckBox = CType(dgAllMenu.Items(x).FindControl("ChkDownLoad"), CheckBox)
            Dim FormRoleId As Integer = dgAllMenu.Items(x).Cells(0).Text
            Dim RoleId As Integer = dgAllMenu.Items(x).Cells(1).Text
            If ChkDownLoad.Checked = True Then
                Dim dtName As DataTable = ObjUser.GetName(UserId)
                Dim dt As DataTable = ObjUser.GetData(FormRoleId)
                Dim dtRoleID As DataTable = ObjUser.GetRoleID(UserId)
                Dim dtte As DataTable = ObjUser.CheckAlreadyExist(dtRoleID.Rows(0)("RoleId"), dt.Rows(0)("FormRoleId"))
                If dtte.Rows.Count > 0 Then
                Else
                    With objFormRolesNew
                        If dt.Rows(0)("ParentFormRoleId") = 0 Then
                            .ID = 0
                            .FormRoleId = dt.Rows(0)("FormRoleId")
                            .TextToDisplay = dt.Rows(0)("TextToDisplay")
                            .Sequence = dt.Rows(0)("Sequence")
                            .IsActive = dt.Rows(0)("IsActive")
                            .ParentFormRoleId = 0
                            .FormId = dt.Rows(0)("FormId")
                            .RoleId = dtRoleID.Rows(0)("RoleId")
                            .AddStatus = 1
                            .ViewStatus = 1
                            .DeleteStatus = 1
                            .Save()
                        Else
                            Dim dttTC As DataTable = ObjUser.GetheaderMenuNewwwNewfORdATA(FormRoleId)
                            Dim ID As Long = dttTC.Rows(0)("ParentFormRoleId")
                            Dim dttTCC As DataTable = ObjUser.GetheaderMenuNewwwNewfORdATAnEW(ID)
                            Dim dttcNew As DataTable = ObjUser.GetheaderMenuNewwwNew(dttTCC.Rows(0)("TextToDisplay"), dtRoleID.Rows(0)("RoleId"))
                            Dim dttc As DataTable = ObjUser.GetheaderMenuNewww(dt.Rows(0)("ParentFormRoleId"), dtRoleID.Rows(0)("RoleId"))
                            If dttcNew.Rows.Count > 0 Then
                                .ID = 0
                                .FormRoleId = dt.Rows(0)("FormRoleId")
                                .TextToDisplay = dt.Rows(0)("TextToDisplay")
                                .Sequence = dt.Rows(0)("Sequence")
                                .IsActive = dt.Rows(0)("IsActive")
                                .ParentFormRoleId = dttcNew.Rows(0)("FormRoleId")
                                .FormId = dt.Rows(0)("FormId")
                                .RoleId = dtRoleID.Rows(0)("RoleId")
                                .AddStatus = 1
                                .ViewStatus = 1
                                .DeleteStatus = 1
                                .Save()
                            ElseIf dttc.Rows.Count > 0 Then
                                .ID = 0
                                .FormRoleId = dt.Rows(0)("FormRoleId")
                                .TextToDisplay = dt.Rows(0)("TextToDisplay")
                                .Sequence = dt.Rows(0)("Sequence")
                                .IsActive = dt.Rows(0)("IsActive")
                                .ParentFormRoleId = dttc.Rows(0)("FormRoleId")
                                .FormId = dt.Rows(0)("FormId")
                                .RoleId = dtRoleID.Rows(0)("RoleId")
                                .AddStatus = 1
                                .ViewStatus = 1
                                .DeleteStatus = 1
                                .Save()
                            Else
                                Dim dtt As DataTable = ObjUser.GetheaderMenu(dt.Rows(0)("ParentFormRoleId"))
                                .ID = 0
                                .FormRoleId = dtt.Rows(0)("FormRoleId")
                                .TextToDisplay = dtt.Rows(0)("TextToDisplay")
                                .Sequence = dtt.Rows(0)("Sequence")
                                .IsActive = dtt.Rows(0)("IsActive")
                                .ParentFormRoleId = 0
                                .FormId = dtt.Rows(0)("FormId")
                                .RoleId = dtRoleID.Rows(0)("RoleId")
                                .AddStatus = 1
                                .ViewStatus = 1
                                .DeleteStatus = 1
                                .Save()
                                .ID = 0
                                .FormRoleId = dt.Rows(0)("FormRoleId")
                                .TextToDisplay = dt.Rows(0)("TextToDisplay")
                                .Sequence = dt.Rows(0)("Sequence")
                                .IsActive = dt.Rows(0)("IsActive")
                                .ParentFormRoleId = dt.Rows(0)("ParentFormRoleId")
                                .FormId = dt.Rows(0)("FormId")
                                .RoleId = dtRoleID.Rows(0)("RoleId")
                                .AddStatus = 1
                                .ViewStatus = 1
                                .DeleteStatus = 1
                                .Save()
                            End If
                        End If
                    End With
                End If       
            Else
            End If
        Next
        BindAllowedMenuGrid()
        BindAllMenuGrid()
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
        Dim dt As DataTable = ObjUser.getAllOWEDData(UserId)
        dgUserAllow.DataSource = dt
        dgUserAllow.DataBind()
        Dim x As Integer
        For x = 0 To dgUserAllow.Items.Count - 1
            Dim ChkDownLoad As CheckBox = CType(dgUserAllow.Items(x).FindControl("ChkDownLoad"), CheckBox)
            Dim FormRoleId As Integer = dgUserAllow.Items(x).Cells(0).Text
            Dim RoleId As Integer = dgUserAllow.Items(x).Cells(1).Text
        Next
    End Sub
    Sub BindAllMenuGrid()
        Dim dt As DataTable = ObjUser.getAllDataAll()
        dgAllMenu.DataSource = dt
        dgAllMenu.DataBind()
        Dim x As Integer
        For x = 0 To dgAllMenu.Items.Count - 1
            Dim ChkDownLoad As CheckBox = CType(dgAllMenu.Items(x).FindControl("ChkDownLoad"), CheckBox)
            Dim FormRoleId As Integer = dgAllMenu.Items(x).Cells(0).Text
            Dim RoleId As Integer = dgAllMenu.Items(x).Cells(1).Text
        Next
    End Sub
End Class
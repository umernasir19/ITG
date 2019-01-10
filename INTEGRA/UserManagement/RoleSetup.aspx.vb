Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class RoleSetup
    Inherits System.Web.UI.Page
    Dim ObjTblRND As New TblDPRND
    Dim dtRoleSetup As DataTable
    Dim Dr As DataRow
    Dim ObjRole As New Role
    Dim lRoleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lRoleID = Request.QueryString("RoleID")
        If Not Page.IsPostBack Then
            Session("dtRoleSetup") = Nothing
            BindDepartment()
            If lRoleID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If

        End If
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = ObjTblRND.GetEditDataForRoleSetup(lRoleID)
        If dt.Rows.Count > 0 Then
            txtDesignation.Text = dt.Rows(0)("Name")
            cmbDepartment.SelectedValue = dt.Rows(0)("UMDepartmentID")
        End If
    End Sub
    Sub BindDepartment()
        Dim dtDepartment As DataTable
        dtDepartment = ObjTblRND.GetDepartment
        cmbDepartment.DataSource = dtDepartment
        cmbDepartment.DataTextField = "UMDepartment"
        cmbDepartment.DataValueField = "UMDepartmentid"
        cmbDepartment.DataBind()
        cmbDepartment.Items.Insert(0, New RadComboBoxItem("Select"))
    End Sub
    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
    '    Try
    '        If txtDesignation.Text = "" Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Designation")
    '        ElseIf cmbDepartment.SelectedValue = 0 Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Department")
    '        Else
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
    '            SaveSession()
    '            clear()
    '            btnSave.Visible = True
    '        End If

    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Sub SaveSession()
    '    If (Not CType(Session("dtRoleSetup"), DataTable) Is Nothing) Then
    '        dtRoleSetup = Session("dtRoleSetup")
    '    Else
    '        dtRoleSetup = New DataTable
    '        With dtRoleSetup
    '            .Columns.Add("RoleID", GetType(Long))
    '            .Columns.Add("UMDepartmentID", GetType(Long))
    '            .Columns.Add("Department", GetType(String))
    '            .Columns.Add("Designation", GetType(String))
    '           End With
    '    End If
    '    Dr = dtRoleSetup.NewRow()
    '    Dr("RoleID") = 0
    '    Dr("UMDepartmentID") = cmbDepartment.SelectedValue
    '    Dr("Department") = cmbDepartment.SelectedItem.Text
    '    Dr("Designation") = txtDesignation.Text.ToUpper
    '    dtRoleSetup.Rows.Add(Dr)
    '    Session("dtRoleSetup") = dtRoleSetup
    '    BinddtRoleSetupGrid()

    'End Sub
    'Sub BinddtRoleSetupGrid()
    '    dgView.DataSource = dtRoleSetup
    '    dgView.DataBind()
    'End Sub
    'Sub clear()
    '    cmbDepartment.SelectedValue = 0
    '    txtDesignation.Text = ""
    'End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
                If cmbDepartment.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Department")
                ElseIf txtDesignation.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Designation")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Save()
                    Response.Redirect("RoleSetupView.aspx")
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Try

                Response.Redirect("RoleSetupView.aspx")

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        Try
            With ObjRole
                If lRoleID > 0 Then
                    .RoleId = lRoleID
                Else
                    .RoleId = 0
                End If
                .Name = txtDesignation.Text.ToUpper
                .Description = txtDesignation.Text.ToUpper
                .IsActive = True
                .RoleTypeId = 7
                .HierarchySequence = 70
                '.UMDepartmentID = cmbDepartment.SelectedValue
                .SaveRole()
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class
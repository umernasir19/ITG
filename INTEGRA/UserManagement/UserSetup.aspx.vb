Imports System.Data
Imports Integra.eurocentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class UserSetup
    Inherits System.Web.UI.Page
    Dim ObjTblRND As New TblDPRND
    Dim dtRoleSetup As DataTable
    Dim Dr As DataRow
    Dim ObjRole As New Role
    Dim lUserID As Long
    Dim objUser As New User
    Dim objUserRoles As New UserRoles
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lUserID = Request.QueryString("UserID")
        If Not Page.IsPostBack Then
            Session("dtRoleSetup") = Nothing
            BindDesignation()
            If lUserID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If

        End If
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = ObjTblRND.GetEditDataForUserSetup(lUserID)
        If dt.Rows.Count > 0 Then
            txtUserId.Text = dt.Rows(0)("UserCode")
            txtPassword.Text = dt.Rows(0)("Password")
            cmbDesignation.SelectedValue = dt.Rows(0)("RoleId")
            txtDepartment.Text = dt.Rows(0)("UMDepartment")
            lblRMUserId.Text = dt.Rows(0)("UserRoleId")

        End If
    End Sub
    Protected Sub cmbDesignation_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbDesignation.SelectedIndexChanged
        Try

            Dim dt As DataTable = ObjTblRND.GetDesignationNew(cmbDesignation.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtDepartment.Text = dt.Rows(0)("UMDepartment")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindDesignation()
        Dim dtDepartment As DataTable
        dtDepartment = ObjTblRND.GetDesignation
        cmbDesignation.DataSource = dtDepartment
        cmbDesignation.DataTextField = "Name"
        cmbDesignation.DataValueField = "RoleId"
        cmbDesignation.DataBind()
        cmbDesignation.Items.Insert(0, New RadComboBoxItem("Select"))
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
                If cmbDesignation.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Designation")
                ElseIf txtUserId.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill User Id")
                ElseIf txtPassword.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Password")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Save()
                    Response.Redirect("UserSetupView.aspx")
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Try
                Response.Redirect("UserSetupView.aspx")

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        Try
            'save UM USer
            With objUser
                If lUserID > 0 Then
                    .UserId = lUserID
                Else
                    .UserId = 0
                End If

                .UserCode = txtUserId.Text
                .EmployeeId = 1
                .Password = txtPassword.Text
                .IsActive = True
                .UserName = txtUserId.Text
                .ECPDivistion = txtUserId.Text
                .Designation = txtUserId.Text
                .Question = ""
                .Answer = ""
                .InspCode = 0
                .LocationId = 1
                .BranchCode = 1
                .CounterID = 1
                .image = ""
                .SaveUser()
            End With

            'save RM USer ROLE
            With objUserRoles
                If lblRMUserId.Text > 0 Then
                    .UserRoleId = lblRMUserId.Text
                Else
                    .UserRoleId = 0
                End If

                .IsActive = True
                If lUserID > 0 Then
                    .UserId = lUserID
                Else
                    .UserId = objUser.GetId
                End If
                .RoleId = cmbDesignation.SelectedValue
                .SaveUserRole()
            End With
           

        Catch ex As Exception

        End Try
    End Sub
End Class
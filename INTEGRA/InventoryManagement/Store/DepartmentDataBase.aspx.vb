Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class DepartmentDataBase
    Inherits System.Web.UI.Page
    Dim objDeptDtabase As New DepartmetDataBase
    Dim lDeptDatabaseId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        lDeptDatabaseId = Request.QueryString("lDeptDatabaseId")
        If Not Page.IsPostBack Then

            If lDeptDatabaseId > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            PageHeader(" ")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub SetValuesEditMod()
        Dim dtDepartmentDatabase As DataTable = objDeptDtabase.GetDepartmentById(lDeptDatabaseId)
        txtDeptDatabaseName.Text = dtDepartmentDatabase.Rows(0)("DeptDatabaseName")
        txtDeptAbbrivation.Text = dtDepartmentDatabase.Rows(0)("DeptAbbrivation")
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtDeptDatabaseName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Department Name Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim dtCheck As DataTable
                If lDeptDatabaseId > 0 Then
                    dtCheck = objDeptDtabase.CheckExistingEdit(lDeptDatabaseId, txtDeptDatabaseName.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Department Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With objDeptDtabase
                            If lDeptDatabaseId > 0 Then
                                .DeptDatabaseId = lDeptDatabaseId
                            Else
                                .DeptDatabaseId = 0
                            End If
                            .DeptDatabaseName = txtDeptDatabaseName.Text.ToUpper
                            .DeptAbbrivation = txtDeptAbbrivation.Text.ToUpper
                            .DeptSectionName = "--"
                            .IsActive = True
                            .SaveDeptDataBase()
                        End With
                        Response.Redirect("../Store/DepartmentDataBaseView.aspx")
                    End If
                Else
                    dtCheck = objDeptDtabase.CheckExisting(txtDeptDatabaseName.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Department Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                        With objDeptDtabase
                            If lDeptDatabaseId > 0 Then
                                .DeptDatabaseId = lDeptDatabaseId
                            Else
                                .DeptDatabaseId = 0
                            End If
                            .DeptDatabaseName = txtDeptDatabaseName.Text
                            .DeptAbbrivation = txtDeptAbbrivation.Text
                            .DeptSectionName = "--"
                            .IsActive = True
                            .SaveDeptDataBase()
                        End With
                        Response.Redirect("../Store/DepartmentDataBaseView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("../Store/DepartmentDataBaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class AccountSubGroupEntry
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Dim objAccountSubGroup As New AccountSubGroup

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindAccountGroup()
        End If
    End Sub
    Sub BindAccountGroup()
        Try
            Dim dtAccountGroupcode As DataTable = objAccountGroup.GetAccountGroupCodeForCombo
            With cmbAccountSubGroup
                .DataSource = dtAccountGroupcode
                .DataValueField = "AccountGroupID"
                .DataTextField = "AccountGroup"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtAccountSubGroup.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Sub Group Empty")
            Else
                Dim dtExist As DataTable = objAccountSubGroup.CheckExisting(cmbAccountSubGroup.SelectedValue, txtAccountSubGroup.Text)
                If dtExist.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Sub Group Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objAccountSubGroup
                        .AccountSubGroupID = 0
                        .AccountSubGroup = txtAccountSubGroup.Text
                        .AccountGroupID = cmbAccountSubGroup.SelectedValue
                        ' Dim CurrentID As Long = objAccountSubGroup.MaxId
                        Dim dtAccountGroupcode As DataTable = objAccountSubGroup.GetAccountSubGroupCode(cmbAccountSubGroup.SelectedValue)
                        Dim AccountSubGroupCode As String
                        If dtAccountGroupcode.Rows.Count > 0 Then
                            AccountSubGroupCode = dtAccountGroupcode.Rows(0)("AccountSubGroupCode")
                        Else
                        End If
                        If AccountSubGroupCode = 0 Then
                            .AccountSubGroupCode = "01"
                        Else
                            If Val(AccountSubGroupCode + 1) <= "09" Then
                                .AccountSubGroupCode = "0" & Val(AccountSubGroupCode + 1)
                            Else
                                .AccountSubGroupCode = Val(AccountSubGroupCode + 1)
                            End If
                        End If
                        .SaveAccountSubGroup()
                        Response.Redirect("AccountSubGroupView.aspx")
                    End With
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("AccountSubGroupView.aspx")
    End Sub
End Class
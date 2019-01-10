Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ChartOfAccountEntry
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New ChartOfAccount
    Dim objAccountGroup As New AccountGroup
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            BindAccountGroup()
        End If
    End Sub
    Sub BindAccountGroup()
        Try
            Dim dtAccountGroup As DataTable
            dtAccountGroup = objChartOfAccount.GetAccountGroup
            cmbAccountGroup.DataSource = dtAccountGroup
            cmbAccountGroup.DataTextField = "AccountGroup"
            cmbAccountGroup.DataValueField = "AccountGroupID"
            cmbAccountGroup.DataBind()

            'For first Time
            Dim dtAccountSubGroup As DataTable
            dtAccountSubGroup = objChartOfAccount.GetAccountSubGroup(cmbAccountGroup.SelectedValue)
            cmbAccountSubGroup.DataSource = dtAccountSubGroup
            cmbAccountSubGroup.DataTextField = "AccountSubGroup"
            cmbAccountSubGroup.DataValueField = "AccountSubGroupID"
            cmbAccountSubGroup.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            'Check Existing
            Dim dtExist As New DataTable
            dtExist = objChartOfAccount.GetExisting(cmbAccountGroup.SelectedValue, cmbAccountSubGroup.SelectedValue, txtAccountType.Text)

            If dtExist.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already Exist")
            ElseIf txtAccountType.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Account Type")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objChartOfAccount
                    .ChartofAccountID = 0
                    .AccountGroupID = cmbAccountGroup.SelectedValue
                    .AccountSubGroupID = cmbAccountSubGroup.SelectedValue

                    Dim AccountGroupCode As String = objAccountGroup.GetAccountGroupCode(cmbAccountGroup.SelectedValue)
                    Dim AccountSubGroupCode As String = objAccountGroup.GetAccountSubGroupCode(cmbAccountSubGroup.SelectedValue)
                    '------------------------------
                    Dim dtChartOfAccountcode As DataTable = objChartOfAccount.GetChartOfAccountCode(cmbAccountGroup.SelectedValue, cmbAccountSubGroup.SelectedValue)
                    Dim ChartOfAccountCode As String
                    Dim FinalChartAccountCode As String
                    If dtChartOfAccountcode.Rows.Count > 0 Then
                        ChartOfAccountCode = dtChartOfAccountcode.Rows(0)("ChartOfAccountCode")
                    Else
                        ChartOfAccountCode = 0
                    End If

                    If ChartOfAccountCode = 0 Then
                        FinalChartAccountCode = "001"
                    Else
                        If Val(ChartOfAccountCode + 1) <= "009" Then
                            FinalChartAccountCode = "00" & Val(ChartOfAccountCode + 1)
                        ElseIf Val(ChartOfAccountCode + 1) <= "099" Then
                            FinalChartAccountCode = "0" & Val(ChartOfAccountCode + 1)
                        Else
                            FinalChartAccountCode = Val(ChartOfAccountCode + 1)
                        End If
                    End If
                    .ChartOfAccountCode = FinalChartAccountCode
                    '----------------------------------
                    Dim dtAccountcode As DataTable = objChartOfAccount.GetAccountCode(cmbAccountGroup.SelectedValue, cmbAccountSubGroup.SelectedValue)
                    Dim AccountCode As String

                    If dtAccountcode.Rows.Count > 0 Then
                        AccountCode = dtAccountcode.Rows(0)("AccountCode")
                    Else
                        AccountCode = 0
                    End If
                    If AccountCode = 0 Then
                        .AccountCode = AccountGroupCode & AccountSubGroupCode & "001"
                    Else
                        .AccountCode = AccountGroupCode & AccountSubGroupCode & FinalChartAccountCode
                    End If
                    .AccountType = txtAccountType.Text
                    .CreationDate = Date.Now
                    .SaveChartOfAccount()
                End With
                Response.Redirect("ChartOfAccountView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("ChartOfAccountView.aspx")
    End Sub
    Protected Sub cmbAccountGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAccountGroup.SelectedIndexChanged
        Try
            Dim dtAccountSubGroup As DataTable
            dtAccountSubGroup = objChartOfAccount.GetAccountSubGroup(cmbAccountGroup.SelectedValue)
            cmbAccountSubGroup.DataSource = dtAccountSubGroup
            cmbAccountSubGroup.DataTextField = "AccountSubGroup"
            cmbAccountSubGroup.DataValueField = "AccountSubGroupID"
            cmbAccountSubGroup.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
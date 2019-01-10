Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class BudgetAccountSetting
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Dim objAccountSubGroup As New AccountSubGroup
    Dim ObjBudgetSettiing As New BudgetSetting
    Dim objChartofaccount As ChartOfAccount
    Dim objBudgetAccountSubGroupSetting As New BudgetAccountSubGroupSetting

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            BindAccountGroup()
            BindAccountSubGroup()
        End If
    End Sub

    Sub BindAccountGroup()
        Try
            Dim dtAccountGroupcode As DataTable = objAccountGroup.GetAccountGroupCodeForCombo
            With cmbAccountGroup
                .DataSource = dtAccountGroupcode
                .DataValueField = "AccountGroupID"
                .DataTextField = "AccountGroup"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub BindAccountSubGroup()
        Try
            Dim dtAccountGroupcode As DataTable = objAccountGroup.GetAccountSubGroupCodeForCombo(cmbAccountGroup.SelectedValue)
            With cmbAccountSubGroup
                .DataSource = dtAccountGroupcode
                .DataValueField = "AccountSubGroupID"
                .DataTextField = "AccountSubGroup"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbAccountGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAccountGroup.SelectedIndexChanged
        Try
            BindAccountSubGroup()
        Catch ex As Exception

        End Try

    End Sub
    Function LoadDataA(ByVal AccountSubGroupID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objAccountGroup.GetdataForBudgetSetting(AccountSubGroupID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            btnSave.Visible = True
            dgBudgetAccountSetting.Visible = True
            dgBudgetAccountSetting.DataSource = objDataView
            dgBudgetAccountSetting.DataBind()
        Else
            btnSave.Visible = False
            dgBudgetAccountSetting.Visible = False
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            For x = 0 To dgBudgetAccountSetting.Items.Count - 1
                Dim txtChartOAccountAllocation As RadTextBox = DirectCast(dgBudgetAccountSetting.Items(x).FindControl("txtChartOAccountAllocation"), RadTextBox)
                Dim item As GridDataItem = DirectCast(dgBudgetAccountSetting.MasterTableView.Items(x), GridDataItem)
                With ObjBudgetSettiing
                    .BudgetSettingId = 0
                    .AccountGroupID = item("AccountGroupID").Text
                    .AccountSubGroupID = item("AccountSubGroupID").Text
                    .ChartofAccountID = item("ChartofAccountID").Text
                    .PercentageAllocationChartOfAccount = txtChartOAccountAllocation.Text
                    .SaveBudgetSetting()
                End With
            Next
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Successfully.")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtChartOAccountAllocation_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer
        Dim BudgetAccountSubGroupAlocationEntry As Decimal = 0
        Dim AccountGroupAllocationEnterd As Double = objBudgetAccountSubGroupSetting.GetSumAllocationForSubgroup(cmbAccountSubGroup.SelectedValue)

        For i = 0 To dgBudgetAccountSetting.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgBudgetAccountSetting.MasterTableView.Items(i), GridDataItem)
            Dim txtChartOAccountAllocation As RadTextBox = DirectCast(dgBudgetAccountSetting.Items(i).FindControl("txtChartOAccountAllocation"), RadTextBox)
            If Val(txtChartOAccountAllocation.Text) > 0 Then
                BudgetAccountSubGroupAlocationEntry = BudgetAccountSubGroupAlocationEntry + Convert.ToDecimal(txtChartOAccountAllocation.Text)
            End If
        Next

        If BudgetAccountSubGroupAlocationEntry > AccountGroupAllocationEnterd Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("% Allocation Not Greater then    " & AccountGroupAllocationEnterd & "  Please Enter Correct Allocation.")
            btnSave.Enabled = False
            btnSave.Visible = False
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            btnSave.Enabled = True
            btnSave.Visible = True
        End If
    End Sub
    Protected Sub cmbAccountSubGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAccountSubGroup.SelectedIndexChanged
        Dim objDataView As DataView
        Try
            objDataView = LoadDataA(cmbAccountSubGroup.SelectedValue)
            Session("objDataView") = objDataView
            BindGrid()
            Dim AccountGroupAllocationShow As Double = objBudgetAccountSubGroupSetting.GetSumAllocationForSubgroup(cmbAccountSubGroup.SelectedValue)
            lblChartOfAccountAllocation.Text = cmbAccountSubGroup.SelectedItem.Text & "= " & AccountGroupAllocationShow & "  %"
        Catch objUDException As UDException
        End Try
    End Sub
End Class
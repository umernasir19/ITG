Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class BudgetAccountSubGroup
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Dim objAccountSubGroup As New AccountSubGroup
    Dim ObjBudgetAccountSubGroupSettiing As New BudgetAccountSubGroupSetting
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindAccountGroup()

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
    Protected Sub cmbAccountGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAccountGroup.SelectedIndexChanged

        Try
            Dim objDataView As DataView
            objDataView = LoadDataA(cmbAccountGroup.SelectedValue)
            Session("objDataView") = objDataView
            BindGrid()
            Dim AccountGrpAllocationShow As Decimal = ObjBudgetAccountSubGroupSettiing.GetSumAllocation(cmbAccountGroup.SelectedValue)
            lblSubGroupAllocation.Text = cmbAccountGroup.SelectedItem.Text & "= " & AccountGrpAllocationShow & "  %"
        Catch objUDException As UDException
        End Try
    End Sub
    Function LoadDataA(ByVal ID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objAccountGroup.GetdataForBudgetAccountSubGroupSetting(ID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            btnSave.Visible = True
            dgBudgetAccountSubGroup.Visible = True
            dgBudgetAccountSubGroup.DataSource = objDataView
            dgBudgetAccountSubGroup.DataBind()

        Else
            btnSave.Visible = False
            dgBudgetAccountSubGroup.Visible = False
        End If

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            For x = 0 To dgBudgetAccountSubGroup.Items.Count - 1
                Dim txtAccountSubGroupAllocation As RadTextBox = DirectCast(dgBudgetAccountSubGroup.Items(x).FindControl("txtAccountSubGroupAllocation"), RadTextBox)
                Dim item As GridDataItem = DirectCast(dgBudgetAccountSubGroup.MasterTableView.Items(x), GridDataItem)
                With ObjBudgetAccountSubGroupSettiing
                    .BudgetAccountSubGroupSettingID = 0
                    .AccountGroupID = item("AccountGroupID").Text
                    .AccountSubGroupID = item("AccountSubGroupID").Text
                    .PercentageAllocationAccountSubGroup = txtAccountSubGroupAllocation.Text
                    .SaveBudgetAccountSubGroupSetting()
                End With
            Next
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Successfully.")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtAccountSubGroupAllocation_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer
        Dim BudgetAccountSubGroupAlocationEntry As Double = 0
        Dim AccountGroupAllocationEnterd As Decimal = ObjBudgetAccountSubGroupSettiing.GetSumAllocation(cmbAccountGroup.SelectedValue)
        For i = 0 To dgBudgetAccountSubGroup.Items.Count - 1
            Dim txtAccountSubGroupAllocation As RadTextBox = DirectCast(dgBudgetAccountSubGroup.Items(i).FindControl("txtAccountSubGroupAllocation"), RadTextBox)
            If Val(txtAccountSubGroupAllocation.Text) > 0 Then
                BudgetAccountSubGroupAlocationEntry = BudgetAccountSubGroupAlocationEntry + Val(txtAccountSubGroupAllocation.Text)
            Else
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
End Class
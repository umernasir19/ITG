Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class BudgetCreate
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Dim objAccountSubGroup As New AccountSubGroup
    Dim ObjBudgetCreateMaster As New BudgetCreateMaster
    Dim ObjBudgetCreateDetail As New BudgetCreateDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub
    Function LoadDataA() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objAccountGroup.GetdataForCreateBudget()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgBudgetPlain.Visible = True
            dgBudgetPlain.DataSource = objDataView
            dgBudgetPlain.DataBind()
        Else
            dgBudgetPlain.Visible = False
        End If
        Dim x As Integer
        For x = 0 To dgBudgetPlain.Items.Count - 1
            Dim lblCCHAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblCCHAmount"), Label)
            Dim lblSCHAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblSCHAmount"), Label)
            Dim lblCHBAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblCHBAmount"), Label)

            Dim item As GridDataItem = DirectCast(dgBudgetPlain.MasterTableView.Items(x), GridDataItem)

            Dim CCHAllocation As Double = item("PercentageAllocationAccountGroup").Text
            Dim SCHAllocation As Double = item("PercentageAllocationAccountSubGroup").Text
            Dim CHBAllocation As Double = item("PercentageAllocationChartOfAccount").Text

            Dim CCHAmount As Double = txtRemittance.Text * CCHAllocation / 100
            Dim SCHAmount As Double = txtRemittance.Text * SCHAllocation / 100
            Dim CHBAmount As Double = txtRemittance.Text * CHBAllocation / 100

            lblCCHAmount.Text = CCHAmount
            lblSCHAmount.Text = SCHAmount
            lblCHBAmount.Text = CHBAmount
        Next

    End Sub

    Protected Sub btnCreateRemittance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateRemittance.Click
        Dim objDataView As DataView
        Try
            objDataView = LoadDataA()
            Session("objDataView") = objDataView
            BindGrid()
            btnSave.Visible = True
        Catch objUDException As UDException
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveBudgetMaster()
            SaveBudgetDetail()
            Response.Redirect("BudgetView.aspx")
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Budget Save Successfully.")
            btnSave.Enabled = False

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveBudgetMaster()
        Try
            With ObjBudgetCreateMaster
                .BudgetCreateMasterId = 0
                .CreationDate = Date.Now
                .BudgetCreationDate = cmbMonth.SelectedValue + "/" + "1" + "/" + cmbYear.SelectedItem.Text
                .Remittance = txtRemittance.Text
                .Month = cmbMonth.SelectedItem.Text
                .Year = cmbYear.SelectedItem.Text
                .SaveBudgetCreateMaster()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveBudgetDetail()
        Dim x As Integer
        Try
            For x = 0 To dgBudgetPlain.Items.Count - 1

                Dim lblCCHAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblCCHAmount"), Label)
                Dim lblSCHAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblSCHAmount"), Label)
                Dim lblCHBAmount As Label = DirectCast(dgBudgetPlain.Items(x).FindControl("lblCHBAmount"), Label)

                Dim item As GridDataItem = DirectCast(dgBudgetPlain.MasterTableView.Items(x), GridDataItem)

                Dim CCHAmount As Double = item("PercentageAllocationAccountGroup").Text
                Dim SCHAmount As Double = item("PercentageAllocationAccountSubGroup").Text
                Dim CHBAmount As Double = item("PercentageAllocationChartOfAccount").Text

                CCHAmount = lblCCHAmount.Text
                SCHAmount = lblSCHAmount.Text
                CHBAmount = lblCHBAmount.Text

                With ObjBudgetCreateDetail
                    .BudgetCreateDetailId = 0
                    .BudgetCreateMasterId = ObjBudgetCreateMaster.GetId
                    .BudgetSettingId = item("BudgetSettingId").Text
                    .AccountGroupID = item("AccountGroupID").Text
                    .AccountSubGroupID = item("AccountSubGroupID").Text
                    .ChartofAccountID = item("ChartofAccountID").Text
                    .AccountGroup = item("AccountGroup").Text
                    .PercentageAllocationAccountGroup = item("PercentageAllocationAccountGroup").Text
                    .AmountCCH = CCHAmount
                    .AccountSubGroup = item("AccountSubGroup").Text
                    .PercentageAllocationAccountSubGroup = item("PercentageAllocationAccountSubGroup").Text
                    .AmountSCH = SCHAmount
                    .AccountType = item("AccountType").Text
                    .PercentageAllocationChartOfAccount = item("PercentageAllocationChartOfAccount").Text
                    .AmountCHB = CHBAmount
                    .SaveBudgetCreateDetail()
                End With
            Next

           
        Catch ex As Exception

        End Try
    End Sub
End Class
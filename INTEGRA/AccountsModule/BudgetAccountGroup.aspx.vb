Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class BudgetAccountGroup
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Dim ObjBudgetAccountGroupSetting As New BudgetAccountGroupSetting
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgBudgetAccountGroupSetting.DataSource = objDataView
        dgBudgetAccountGroupSetting.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            'objDataTable = objAccountGroup.GetdataForBudgetAccountGroupSetting()
            objDataTable = ObjBudgetAccountGroupSetting.GetdataForBudgetAccountGroupSetting()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            For x = 0 To dgBudgetAccountGroupSetting.Items.Count - 1
                Dim txtAccountGroupAllocation As RadTextBox = DirectCast(dgBudgetAccountGroupSetting.Items(x).FindControl("txtAccountGroupAllocation"), RadTextBox)
                Dim item As GridDataItem = DirectCast(dgBudgetAccountGroupSetting.MasterTableView.Items(x), GridDataItem)
                If txtAccountGroupAllocation.Text = "" Then
                    'not save
                Else
                    With ObjBudgetAccountGroupSetting
                        .BudgetAccountGroupSettingID = item("BudgetAccountGroupSettingID").Text
                        .AccountGroupID = item("AccountGroupID").Text
                        .PercentageAllocationAccountGroup = txtAccountGroupAllocation.Text
                        .SaveBudgetAccountGroupSetting()
                    End With
                End If
            Next
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Successfully.")
            Response.Redirect("BudgetAccountGroupView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
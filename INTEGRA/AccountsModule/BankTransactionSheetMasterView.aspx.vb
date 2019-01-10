Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class BankTransactionSheetMasterView
    Inherits System.Web.UI.Page
    Dim objBankTransaction As New BankTransaction
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("objDataViewBank") = Nothing
            BindCurrentMonthData()
            BindViewBy()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataViewBank")
            dgBankTransactionSheet.DataSource = objDataView
            dgBankTransactionSheet.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Sub BindViewBy()
        Try
            Dim dtMonthYear As DataTable
            dtMonthYear = objBankTransaction.GetMonthYear()
            cmbMonthYear.DataSource = dtMonthYear
            cmbMonthYear.DataTextField = "MonthYear"
            cmbMonthYear.DataValueField = "Monthh"
            cmbMonthYear.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbMonthYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbMonthYear.SelectedIndexChanged
        Try
            If cmbMonthYear.SelectedValue = 0 Then
            Else
                Dim objDataView As DataView
                Dim objDataTable As DataTable
                'First Separte Year and month
                Dim strYear() As String
                strYear = cmbMonthYear.SelectedItem.Text.Split(",")
                objDataTable = objBankTransaction.GetMasterData(cmbMonthYear.SelectedValue, strYear(1))
                objDataView = New DataView(objDataTable)
                Session("objDataViewBank") = objDataView
                BindGrid()
                updgBankTransactionSheet.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddCashTransactionN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddBankTransactionN.Click
        Try
            Response.Redirect("BankTransactionSheet.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrentMonthData()
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objBankTransaction.GetMasterData(Date.Now.Month, Date.Now.Year)
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataViewBank") = objDataView
                BindGrid()
                updgBankTransactionSheet.Update()

                BindViewBy()
                upcmbMonthYear.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgBankTransactionSheet_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgBankTransactionSheet.NeedDataSource
        BindGrid()
    End Sub
    Protected Sub dgBankTransactionSheet_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgBankTransactionSheet.SelectedIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgBankTransactionSheet_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgBankTransactionSheet.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgBankTransactionSheet_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgBankTransactionSheet.ItemCommand
        Select Case e.CommandName
            Case Is = "EDIT"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lBankTransactionID As String = item("BankTransactionID").Text
                Response.Redirect("BankTransactionSheet.aspx?lBankTransactionID=" & lBankTransactionID & "")
        End Select
    End Sub
    Protected Sub rblView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblView.SelectedIndexChanged
        Try
            If rblView.SelectedItem.Text = "Ledger" Then
                Response.Redirect("BankTransactionSheetMasterView.aspx")
            Else
                Response.Redirect("BankTransactionSheetView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
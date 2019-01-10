Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class BankTransactionSheetView
    Inherits System.Web.UI.Page
    Dim objBankTransaction As New BankTransaction
    Dim BitStatus As Long
    Dim BitMonth As Long
    Dim BitYear As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BitStatus = Request.QueryString("BitStatus")
        BitMonth = Request.QueryString("BitMonth")
        BitYear = Request.QueryString("BitYear")
        If Not Page.IsPostBack Then
            Session("objDataViewBank") = Nothing
            If BitStatus = 0 Then
                'Load Current month data
                BindCurrentMonthData()
            Else
                'Load that month data which trnction save right now
                BindCurrentSaveMonthData()
            End If
            ' BindViewBy()
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
                objDataTable = objBankTransaction.GetData(cmbMonthYear.SelectedValue, strYear(1))
                objDataView = New DataView(objDataTable)
                Session("objDataViewBank") = objDataView
                BindGrid()
                updgBankTransactionSheet.Update()

                LoadSummaryStatus()
                lblBalanceCF.Visible = True
                txtBalanceCF.Visible = True
                lblBank.Visible = True
                txtBank.Visible = True
                lblotalExpense.Visible = True
                txtotalExpense.Visible = True
                lblBankBalance.Visible = True
                txtBankBalance.Visible = True


                uptxtBalanceCF.Update()
                uptxtBank.Update()
                uptxtotalExpense.Update()
                uptxttxtBankBalance.Update()
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
            objDataTable = objBankTransaction.GetData(Date.Now.Month, Date.Now.Year)
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataViewBank") = objDataView
                BindGrid()
                updgBankTransactionSheet.Update()

                BindViewBy()
                upcmbMonthYear.Update()

                LoadSummaryStatusCurrentMonth()

                lblBalanceCF.Visible = True
                txtBalanceCF.Visible = True
                lblBank.Visible = True
                txtBank.Visible = True
                lblotalExpense.Visible = True
                txtotalExpense.Visible = True
                lblBankBalance.Visible = True
                txtBankBalance.Visible = True

                uptxtBalanceCF.Update()
                uptxtBank.Update()
                uptxtotalExpense.Update()
                uptxttxtBankBalance.Update()
            Else
                BindViewBy()

                lblBalanceCF.Visible = False
                txtBalanceCF.Visible = False
                lblBank.Visible = False
                txtBank.Visible = False
                lblotalExpense.Visible = False
                txtotalExpense.Visible = False
                lblBankBalance.Visible = False
                txtBankBalance.Visible = False
                uptxtBalanceCF.Update()
                uptxtBank.Update()
                uptxtotalExpense.Update()
                uptxttxtBankBalance.Update()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrentSaveMonthData()
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objBankTransaction.GetData(BitMonth, BitYear)
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataViewBank") = objDataView
                BindGrid()
                updgBankTransactionSheet.Update()

                BindViewBy()
                upcmbMonthYear.Update()

                LoadSummaryStatusCurrentMonth()
                uptxtBalanceCF.Update()
                uptxtBank.Update()
                uptxtotalExpense.Update()
                uptxttxtBankBalance.Update()
            Else
                BindViewBy()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadSummaryStatus()
        Try
            'First Separte Year and month
            Dim strYear() As String
            strYear = cmbMonthYear.SelectedItem.Text.Split(",")
            txtBalanceCF.Text = objBankTransaction.GetBalanceCF(cmbMonthYear.SelectedValue, strYear(1))
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtBank.Text = objBankTransaction.Getbank(cmbMonthYear.SelectedValue, strYear(1))
            If txtBank.Text = "" Then
                txtBank.Text = 0
            End If
            txtotalExpense.Text = objBankTransaction.GetTotalExpense(cmbMonthYear.SelectedValue, strYear(1))
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtBankBalance.Text = objBankTransaction.GetTotalAmount(cmbMonthYear.SelectedValue, strYear(1))

            uptxtBalanceCF.Update()
            uptxtBank.Update()
            uptxtotalExpense.Update()
            uptxttxtBankBalance.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadSummaryStatusCurrentMonth()
        Try
            txtBalanceCF.Text = objBankTransaction.GetBalanceCF(Date.Now.Month, Date.Now.Year)
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtBank.Text = objBankTransaction.Getbank(Date.Now.Month, Date.Now.Year)
            If txtBank.Text = "" Then
                txtBank.Text = 0
            End If
            txtotalExpense.Text = objBankTransaction.GetTotalExpense(Date.Now.Month, Date.Now.Year)
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtBankBalance.Text = objBankTransaction.GetTotalAmount(Date.Now.Month, Date.Now.Year)

            uptxtBalanceCF.Update()
            uptxtBank.Update()
            uptxtotalExpense.Update()
            uptxttxtBankBalance.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadSummaryStatusCurrentSaveMonthData()
        Try
            txtBalanceCF.Text = objBankTransaction.GetBalanceCF(BitMonth, BitYear)
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtBank.Text = objBankTransaction.Getbank(BitMonth, BitYear)
            If txtBank.Text = "" Then
                txtBank.Text = 0
            End If
            txtotalExpense.Text = objBankTransaction.GetTotalExpense(BitMonth, BitYear)
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtBankBalance.Text = objBankTransaction.GetTotalAmount(BitMonth, BitYear)

            uptxtBalanceCF.Update()
            uptxtBank.Update()
            uptxtotalExpense.Update()
            uptxttxtBankBalance.Update()
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

End Class


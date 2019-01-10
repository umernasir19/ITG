Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class LedgerReport
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim dtAC As DataTable
    Dim obGeneralCode As New GeneralCode
    Dim YearFirst, YearSecond As String
    Dim objSupplierLedger As New SupplierLedger
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'YearFirst = Session("YearFirst")
        'YearSecond = Session("YearSecond")
        If Not Page.IsPostBack Then
            Try
                txtStartDate.SelectedDate = "01/07/2017"
                txtEndDate.SelectedDate = Date.Now
                ' CurrentMonthDate()
                BindAccountcode()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Ledger Report")
    End Sub

    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindAccountcode()
        Dim dtAccountCode As DataTable
        dtAccountCode = ObjtblBankMst.GetUniqueAccountNameForPrintOB()
        CmbAccountCode.DataSource = dtAccountCode
        CmbAccountCode.DataValueField = "AccountCode"
        CmbAccountCode.DataTextField = "AccountName"
        CmbAccountCode.DataBind()
        ' CmbAccountCode.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
    Sub CurrentMonthDate()
        Dim month As String = Date.Today.Month
        Dim codemonth As String
        If month = 1 Then
            codemonth = "01"
        ElseIf month = 2 Then
            codemonth = "02"
        ElseIf month = 3 Then
            codemonth = "03"
        ElseIf month = 4 Then
            codemonth = "04"
        ElseIf month = 5 Then
            codemonth = "05"
        ElseIf month = 6 Then
            codemonth = "06"
        ElseIf month = 7 Then
            codemonth = "07"
        ElseIf month = 8 Then
            codemonth = "08"
        ElseIf month = 9 Then
            codemonth = "09"
        Else
            codemonth = month
        End If
        Dim Year As String = Date.Today.Year
        'txtStartDate.Text = "01/" & codemonth & "/" & Year
        'If codemonth = "02" Then
        '    txtEndDate.Text = "28/" & codemonth & "/" & Year
        'Else
        '    txtEndDate.Text = "30/" & codemonth & "/" & Year
        'End If
    End Sub
  Protected Sub lnkprint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkprint.Click
        Try
            'Session("BANKsDATE") = txtStartDate.SelectedDate
            'Session("BANKeeDATE") = txtEndDate.SelectedDate
            Session("BANKsDATE") = txtStartDate.SelectedDate
            Session("BANKeeDATE") = txtEndDate.SelectedDate

            'Session("YearFirst") = "07/01/2017"
            'Session("YearSecond") = "06/30/2018"

            Response.Redirect("LedgerPrint.aspx?AccountCode=" & lblAccountCode.Text & " &AccountName=" & txtAccountName.Text & " &FiscalYear=" & Session("Session") & "")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Try
            Dim dta As DataTable = objSupplierLedger.GetUniqueAccountCode(txtAccountName.Text)
            lblAccountCode.Text = dta.Rows(0)("AccountCode")
        Catch ex As Exception

        End Try
    End Sub
End Class


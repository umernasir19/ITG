Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CashTransactionSheetView
    Inherits System.Web.UI.Page
    Dim objCashTransaction As New CashTransaction
    Dim BitStatus As Long
    Dim BitMonth As Long
    Dim BitYear As Long
    Dim EditCashID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BitStatus = Request.QueryString("BitStatus")
        BitMonth = Request.QueryString("BitMonth")
        BitYear = Request.QueryString("BitYear")
        If Not Page.IsPostBack Then
            Session("objDataView") = Nothing
            If BitStatus = 0 Then
                'Load Current month data
                BindCurrentMonthData()
            Else
                'Load that month data which trnction save right now
                BindCurrentSaveMonthData()
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgCashTransactionSheet.DataSource = objDataView
            dgCashTransactionSheet.DataBind()

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
            dtMonthYear = objCashTransaction.GetMonthYear()
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
                objDataTable = objCashTransaction.GetData(cmbMonthYear.SelectedValue, strYear(1))
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                updgCashTransactionSheet.Update()

                LoadSummaryStatus()

                lblBalanceCF.Visible = True
                txtBalanceCF.Visible = True
                lblPettyCashh.Visible = True
                txtPettyCash.Visible = True
                lblp.Visible = True
                txtotalExpense.Visible = True
                lblClosingBalance.Visible = True
                txtClosingBalance.Visible = True


                uptxtBalanceCF.Update()
                uptxtPettyCash.Update()
                uptxtotalExpense.Update()
                uptxtClosingBalance.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddCashTransactionN_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddCashTransactionN.Click
        Try
            Response.Redirect("CashTransactionSheet.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrentMonthData()
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objCashTransaction.GetData(Date.Now.Month, Date.Now.Year)
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                updgCashTransactionSheet.Update()

                BindViewBy()
                LoadSummaryStatusCurrentMonth()

                lblBalanceCF.Visible = True
                txtBalanceCF.Visible = True
                lblPettyCashh.Visible = True
                txtPettyCash.Visible = True
                lblp.Visible = True
                txtotalExpense.Visible = True
                lblClosingBalance.Visible = True
                txtClosingBalance.Visible = True

                uptxtBalanceCF.Update()
                uptxtPettyCash.Update()
                uptxtotalExpense.Update()
                uptxtClosingBalance.Update()
            Else
                BindViewBy()

                lblBalanceCF.Visible = False
                txtBalanceCF.Visible = False
                lblPettyCashh.Visible = False
                txtPettyCash.Visible = False
                lblp.Visible = False
                txtotalExpense.Visible = False
                lblClosingBalance.Visible = False
                txtClosingBalance.Visible = False
                uptxtBalanceCF.Update()
                uptxtPettyCash.Update()
                uptxtotalExpense.Update()
                uptxtClosingBalance.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrentSaveMonthData()
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objCashTransaction.GetData(BitMonth, BitYear)
            If objDataTable.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                updgCashTransactionSheet.Update()

                BindViewBy()
                LoadSummaryStatusCurrentMonth()
                uptxtBalanceCF.Update()
                uptxtPettyCash.Update()
                uptxtotalExpense.Update()
                uptxtClosingBalance.Update()
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
            txtBalanceCF.Text = objCashTransaction.GetBalanceCF(cmbMonthYear.SelectedValue, strYear(1))
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtPettyCash.Text = objCashTransaction.GetPettyCash(cmbMonthYear.SelectedValue, strYear(1))
            If txtPettyCash.Text = "" Then
                txtPettyCash.Text = 0
            End If
            txtotalExpense.Text = objCashTransaction.GetTotalExpense(cmbMonthYear.SelectedValue, strYear(1))
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtClosingBalance.Text = objCashTransaction.GetTotalAmount(cmbMonthYear.SelectedValue, strYear(1))

            uptxtBalanceCF.Update()
            uptxtPettyCash.Update()
            uptxtotalExpense.Update()
            uptxtClosingBalance.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadSummaryStatusCurrentMonth()
        Try
            txtBalanceCF.Text = objCashTransaction.GetBalanceCF(Date.Now.Month, Date.Now.Year)
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtPettyCash.Text = objCashTransaction.GetPettyCash(Date.Now.Month, Date.Now.Year)
            If txtPettyCash.Text = "" Then
                txtPettyCash.Text = 0
            End If
            txtotalExpense.Text = objCashTransaction.GetTotalExpense(Date.Now.Month, Date.Now.Year)
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtClosingBalance.Text = objCashTransaction.GetTotalAmount(Date.Now.Month, Date.Now.Year)

            uptxtBalanceCF.Update()
            uptxtPettyCash.Update()
            uptxtotalExpense.Update()
            uptxtClosingBalance.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadSummaryStatusCurrentSaveMonthData()
        Try
            txtBalanceCF.Text = objCashTransaction.GetBalanceCF(BitMonth, BitYear)
            If txtBalanceCF.Text = "" Then
                txtBalanceCF.Text = 0
            End If
            txtPettyCash.Text = objCashTransaction.GetPettyCash(BitMonth, BitYear)
            If txtPettyCash.Text = "" Then
                txtPettyCash.Text = 0
            End If
            txtotalExpense.Text = objCashTransaction.GetTotalExpense(BitMonth, BitYear)
            If txtotalExpense.Text = "" Then
                txtotalExpense.Text = 0
            End If
            txtClosingBalance.Text = objCashTransaction.GetTotalAmount(BitMonth, BitYear)

            uptxtBalanceCF.Update()
            uptxtPettyCash.Update()
            uptxtotalExpense.Update()
            uptxtClosingBalance.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgCashTransactionSheet_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgCashTransactionSheet.SelectedIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgCashTransactionSheet_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgCashTransactionSheet.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgCashTransactionSheet_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgCashTransactionSheet.NeedDataSource
        BindGrid()
    End Sub
    'Protected Sub dgCashTransactionSheet_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgCashTransactionSheet.ItemCommand
    '    Select Case e.CommandName
    '        Case Is = "PrintReport"
    '            Dim Report As New ReportDocument
    '            Dim Options As New ExportOptions
    '            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '            Dim lCashTransactionID As String = item("CashTransactionID").Text
    '            Dim lTranscationType As String = item("TranscationType").Text


    '            Report.Load(Server.MapPath("..\Reports/CashTransaction.rpt"))
    '            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
    '            di.Create()

    '            Dim FileName As String = "CashTransaction-" + lTranscationType
    '            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
    '            Report.SetParameterValue(0, lCashTransactionID)
    '            Dim FileOption As New DiskFileDestinationOptions
    '            FileOption.DiskFileName = sTempFileName
    '            Options = Report.ExportOptions
    '            Options.ExportDestinationType = ExportDestinationType.DiskFile
    '            Options.ExportFormatType = ExportFormatType.PortableDocFormat
    '            Options.DestinationOptions = FileOption
    '            Options.ExportDestinationOptions = FileOption
    '            Report.SetDatabaseLogon("sa", "pwd")
    '            Report.Export()

    '            Dim strFileSize As String = ""
    '            Dim ExistFIleName As String = "CashTransaction-" + lTranscationType + ".pdf"
    '            Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

    '            Dim fi As IO.FileInfo
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
    '            For Each fi In aryFi
    '                Response.ClearHeaders()
    '                Response.ClearContent()
    '                Response.ContentType = "application/octet-stream"
    '                Response.Charset = "UTF-8"
    '                Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
    '                Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
    '                Response.End()
    '            Next

    '    End Select
    'End Sub
    Sub DownloadPDF()
        Try
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
           
            Report.Load(Server.MapPath("..\Reports/CashTransaction.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Cash Transaction-"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, EditCashID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            Dim strFileSize As String = ""
            Dim ExistFIleName As String = "Cash Transaction-" + ".pdf"
            Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

            Dim fi As IO.FileInfo
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            For Each fi In aryFi
                Response.ClearHeaders()
                Response.ClearContent()
                Response.ContentType = "application/octet-stream"
                Response.Charset = "UTF-8"
                Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                Response.End()
            Next

        Catch ex As Exception

        End Try
    End Sub
 
End Class
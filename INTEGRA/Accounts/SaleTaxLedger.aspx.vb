Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class SaleTaxLedger
    Inherits System.Web.UI.Page
    Dim objSupplierledger As New SupplierLedger
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtStartDate.SelectedDate = "01/07/2017"
            txtEndDate.SelectedDate = Date.Now
            ' CurrentMonthDate()
        End If
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

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try


            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            GetDateForLedgerReport()
            'Dim StatDate As Date = txtStartDate.SelectedDate
            'Dim EndDate As Date = txtEndDate.SelectedDate
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FileName As String = "SALES TAX LEDGER"
            'PartiesLedger()
            Report.Load(Server.MapPath("~/Reports/SalesTaxLedgerForNM.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, txtStartDate.SelectedDate)
            Report.SetParameterValue(1, txtEndDate.SelectedDate)

            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub GetDateForLedgerReport()
        Try
            '-----Create New Temp Table Some field add TempLedgerSupplierINVBPV
            Dim OBJDATE As New GeneralCode
            Dim sdatee, edate As String
            sdatee = OBJDATE.GetDateFormat(txtStartDate.SelectedDate)
            edate = OBJDATE.GetDateFormat(txtEndDate.SelectedDate)
            objSupplierledger.TruncateTempLedgerTableNewForSalesTax()

            '''''''----This is a SalesTax Report which we use in all Stax in invoice
            ' objSupplierledger.InsertJVDataWithOutNew(txtAccountCode.Text)
            'objSupplierledger.InsertbvDataWithOutNew(txtAccountCode.Text)

            objSupplierledger.InsertSalesTaxLedgerDataWithOUtDateNew(sdatee, edate)
            objSupplierledger.TruncateTempLedgerFinalTableNewForSalesTax()
            objSupplierledger.InsertSalesTaxLedgerFinalDataWithOutDateNew()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            GetDateForLedgerReport()
        Catch ex As Exception

        End Try
    End Sub
End Class



Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class DownloadExcelSheet
    Inherits System.Web.UI.Page
    Dim ObjBankTransaction As New BankTransaction
    Dim ObjCashTransaction As New CashTransaction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Accounts Status Download")
            If cmbType.SelectedItem.Text = "Bank Transaction" Then
                BindMonthBank()
                BindYearBank()
            Else
                BindMonthCash()
                BindYearCash()
            End If
         
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindMonthBank()
        Dim dtMonth As DataTable
        dtMonth = ObjBankTransaction.GetMonthNames
        cmbMonth.DataSource = dtMonth
        cmbMonth.DataTextField = "MonthName"
        cmbMonth.DataValueField = "MonthNo"
        cmbMonth.DataBind()
    End Sub
    Sub BindYearBank()
        Dim dtYear As DataTable
        dtYear = ObjBankTransaction.GetYearNames
        cmbYear.DataSource = dtYear
        cmbYear.DataTextField = "YearName"
        cmbYear.DataValueField = "YearNo"
        cmbYear.DataBind()
    End Sub
    Sub BindMonthCash()
        Dim dtMonth As DataTable
        dtMonth = ObjCashTransaction.GetMonthNames
        cmbMonth.DataSource = dtMonth
        cmbMonth.DataTextField = "MonthName"
        cmbMonth.DataValueField = "MonthNo"
        cmbMonth.DataBind()
    End Sub
    Sub BindYearCash()
        Dim dtYear As DataTable
        dtYear = ObjCashTransaction.GetYearNames
        cmbYear.DataSource = dtYear
        cmbYear.DataTextField = "YearName"
        cmbYear.DataValueField = "YearNo"
        cmbYear.DataBind()
    End Sub
    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownload.Click
        Try
            If cmbType.SelectedItem.Text = "Bank Transaction" Then
                Dim FileName As String = "BankSheet"
                ObjBankTransaction.getExcelSheet(cmbMonth.SelectedValue, cmbYear.SelectedValue)
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/BankSheetGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                ' Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                'Now File Name is Customer, Month,Year, Cussenry

                Dim FileNamePart2 As String = "Pak-" + cmbYear.SelectedValue + "-" + cmbMonth.SelectedValue + "-HSBC-PRS-(A/C Code 13110108)-For HK-" + cmbMonth.SelectedItem.Text + " Download " + Day + "-" + month + "-" + year
                ' Pak-2013-01-HSBC-PRS-(A/C Code 13110108)-For HK-Jan Download 28-06-2013

                Response.AppendHeader("Content-Disposition", "attachment; filename=""" + FileNamePart2 + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf cmbType.SelectedItem.Text = "Bank Ledger" Then
                Dim FileName As String = "BankSheet"
                ObjBankTransaction.getExcelSheetBankLedger(cmbMonth.SelectedValue, cmbYear.SelectedValue)
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/BankSheetGeneratedLedger/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                ' Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                'Now File Name is Customer, Month,Year, Cussenry

                Dim FileNamePart2 As String = "Bank Ledger-" + cmbYear.SelectedValue + "-" + cmbMonth.SelectedValue + "-HSBC-PRS-(A/C Code 13110108)-For HK-" + cmbMonth.SelectedItem.Text + " Download " + Day + "-" + month + "-" + year
                ' Pak-2013-01-HSBC-PRS-(A/C Code 13110108)-For HK-Jan Download 28-06-2013

                Response.AppendHeader("Content-Disposition", "attachment; filename=""" + FileNamePart2 + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf cmbType.SelectedItem.Text = "Cash Book" Then
                DownloadCashBook()
            ElseIf cmbType.SelectedItem.Text = "Cost Center Analysis" Then
                DownloadCostCenter()
            ElseIf cmbType.SelectedItem.Text = "Budget Forecast" Then
                DownloadBudgetForecast()
            Else
                Dim FileName As String = "CashSheet"
                ObjCashTransaction.getExcelSheet(cmbMonth.SelectedValue, cmbYear.SelectedValue)
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/CashSheetGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                ' Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                'Now File Name is Customer, Month,Year, Cussenry
                Dim FileNamePart2 As String = "Pak-" + cmbYear.SelectedValue + "-" + cmbMonth.SelectedValue + "-Cash-in-Hand-PRS (A/C Code 13160806)-For HK-" + cmbMonth.SelectedItem.Text + " Download " + Day + "-" + month + "-" + year
                ' Pak-2013-01-Cash-in-Hand-PRS (AC Code 13160806) For HK-Jan Download 28-06-2013

                Response.AppendHeader("Content-Disposition", "attachment; filename=""" + FileNamePart2 + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            End If
           
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbType.SelectedIndexChanged
        Try
            If cmbType.SelectedItem.Text = "Bank Transaction" Then
                BindMonthBank()
                BindYearBank()
            ElseIf cmbType.SelectedItem.Text = "Bank Ledger" Then
                BindMonthBank()
                BindYearBank()
            ElseIf cmbType.SelectedItem.Text = "Cash Book" Then
                BindMonthBank()
                BindYearBank()
            ElseIf cmbType.SelectedItem.Text = "Cost Center Analysis" Then
                BindMonthBank()
                BindYearBank()
            ElseIf cmbType.SelectedItem.Text = "Budget Forecast" Then
                BindMonthBank()
                BindYearBank()
            Else
                BindMonthCash()
                BindYearCash()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub DownloadCashBook()
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Report.Load(Server.MapPath("..\Reports/CashBook.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Cash Book"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, cmbMonth.SelectedValue)
            Report.SetParameterValue(1, cmbYear.SelectedValue)
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
    Sub DownloadCostCenter()
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Report.Load(Server.MapPath("..\Reports/CostCenterAnalysis.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Cost Center Analysis"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, cmbMonth.SelectedValue)
            Report.SetParameterValue(1, cmbYear.SelectedValue)
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
    Sub DownloadBudgetForecast()
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Report.Load(Server.MapPath("..\Reports/BudgetForecastStatementMonthly.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Budget Forecast Statement"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, cmbMonth.SelectedValue)
            Report.SetParameterValue(1, cmbYear.SelectedValue)
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
End Class
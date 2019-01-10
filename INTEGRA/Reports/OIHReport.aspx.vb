Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class OIHReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("OIH Report")
            Dim FirstDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateFrom.SelectedDate = FirstDay
            Dim lastDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateTo.SelectedDate = lastDay.AddMonths(1).AddDays(-1)
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            Dim ObjBookedExchangeRate As New BookedExchangeRate
            Dim dtBookedExchangeRate As DataTable
            Dim BookedExchange As String = "("
            dtBookedExchangeRate = ObjBookedExchangeRate.ExistingOfBookedRateForReports(txtDateFrom.SelectedDate, txtDateTo.SelectedDate)
            If dtBookedExchangeRate.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtBookedExchangeRate.Rows.Count - 1
                    BookedExchange = BookedExchange + dtBookedExchangeRate.Rows(x)("BookedExchangeRate").ToString() + ","
                Next
                BookedExchange = BookedExchange + ")"
                BookedExchange = Replace(BookedExchange, ",)", ")")
            Else
                BookedExchange = "---"
            End If
            If cmbreporttype.SelectedItem.Text = "Customer Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/OIHCustomerVise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "OIH-Customer Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)

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

            ElseIf cmbreporttype.SelectedItem.Text = "Supplier Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/OIHSupplierVise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "OIH-Supplier Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)

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
            ElseIf cmbreporttype.SelectedItem.Text = "Merchandiser Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/OIHMerchandiserVise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "OIH-Merchandiser Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)

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
            ElseIf cmbreporttype.SelectedItem.Text = "TDG Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/OIHECPVise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "OIH-TDG Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)

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
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
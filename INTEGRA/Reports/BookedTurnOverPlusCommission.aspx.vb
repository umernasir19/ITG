Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class BookedTurnOverPlusCommission
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Booked Turn Over & Commission")
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
            dtBookedExchangeRate = ObjBookedExchangeRate.ExistingOfBookedRateForReports(txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy"), txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy"))
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

                Report.Load(Server.MapPath("..\Reports/BookedTurnOverCustomerWise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Booked Turnover Customer Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)
                Report.SetParameterValue(3, fromDate)
                Report.SetParameterValue(4, ToDate)

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

                Report.Load(Server.MapPath("..\Reports/BookedTurnOverSupplierWise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Booked Turnover Supplier Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)
                Report.SetParameterValue(3, fromDate)
                Report.SetParameterValue(4, ToDate)

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

                Report.Load(Server.MapPath("..\Reports/BookedTurnOverMarchandWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Booked Turnover Merchandiser Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)
                Report.SetParameterValue(3, fromDate)
                Report.SetParameterValue(4, ToDate)

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
            ElseIf cmbreporttype.SelectedItem.Text = "Dept. Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/BookedTurnOverECPWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                ' Dim FileName As String = "Booked Turnover TDG Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim FileName As String = "Booked Turnover Dept Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)
                Report.SetParameterValue(3, fromDate)
                Report.SetParameterValue(4, ToDate)

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
            ElseIf cmbreporttype.SelectedItem.Text = "Department Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/BookedTurnOverDepartmentWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Booked Turnover Department Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, BookedExchange)
                Report.SetParameterValue(3, fromDate)
                Report.SetParameterValue(4, ToDate)

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
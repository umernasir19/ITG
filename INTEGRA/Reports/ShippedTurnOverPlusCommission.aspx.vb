Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class ShippedTurnOverPlusCommission
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Shipped Turn Over & Commission")
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
            Dim ObjShipExchangeRate As New ShipExchangeRate
            Dim dtShipExchangeRate As DataTable
            Dim ShipExchange As String = "("
            dtShipExchangeRate = ObjShipExchangeRate.ExistingOfShipRateForReport(txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy"), txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy"))
            If dtShipExchangeRate.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To dtShipExchangeRate.Rows.Count - 1
                    ShipExchange = ShipExchange + dtShipExchangeRate.Rows(x)("ShipExchangeRate").ToString() + ","
                Next
                ShipExchange = ShipExchange + ")"
                ShipExchange = Replace(ShipExchange, ",)", ")")
            Else
                ShipExchange = "---"
            End If
            If cmbreporttype.SelectedItem.Text = "Customer Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/ShippedTurnOverCustomerWise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Shipped Turnover Customer Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, ShipExchange)
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

                Report.Load(Server.MapPath("..\Reports/ShippedTurnOverSupplierWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Shipped Turnover Supplier Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, ShipExchange)
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

                Report.Load(Server.MapPath("..\Reports/ShippedTurnOverMarchandWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Shipped Turnover Merchandiser Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, ShipExchange)
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

                Report.Load(Server.MapPath("..\Reports/ShippedTurnOverECPDivisionWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                ' Dim FileName As String = "Shipped Turnover TDG Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim FileName As String = "Shipped Turnover Dept Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, ShipExchange)
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

                Report.Load(Server.MapPath("..\Reports/ShippedTurnOverEKNumberWiseAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Shipped Turnover Department Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, ShipExchange)
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
            ElseIf cmbreporttype.SelectedItem.Text = "ECP Vise" Then
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/TradingGroupTurnOverCustomerWise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Shipped Turnover Trading Group Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")

                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Report.SetParameterValue(2, fromDate)
                Report.SetParameterValue(3, ToDate)

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
    Protected Sub btnReportBuyerSuplier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReportBuyerSuplier.Click
        Try
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Report.Load(Server.MapPath("..\Reports/ShippedTurnOverCustomerSupplierWise.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Shipped Turnover Customer Supplier Vise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Report.SetParameterValue(0, fromDate)
            Report.SetParameterValue(1, ToDate)
            Report.SetParameterValue(2, fromDate)
            Report.SetParameterValue(3, ToDate)

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
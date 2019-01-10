Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class LogisticDepartmentShippedStatus
    Inherits System.Web.UI.Page
    Dim objCargo As New Cargo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Logistic Department Shipped Status Download")
            BindMonth()
            BindYear()
            BindCustomer()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindMonth()
        Dim dtMonth As DataTable
        dtMonth = objCargo.GetCargoMonthNames
        cmbMonth.DataSource = dtMonth
        cmbMonth.DataTextField = "MonthName"
        cmbMonth.DataValueField = "MonthNo"
        cmbMonth.DataBind()
    End Sub
    Sub BindYear()
        Dim dtYear As DataTable
        dtYear = objCargo.GetCargoYearNames
        cmbYear.DataSource = dtYear
        cmbYear.DataTextField = "YearName"
        cmbYear.DataValueField = "YearNo"
        cmbYear.DataBind()
    End Sub
    Sub BindCustomer()
        Dim dtCustomer As DataTable
        dtCustomer = objCargo.GetCargoCustomers
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
    End Sub
    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownload.Click
        Try
            'First If Record Exist then downlaod Xl other wise not
            Dim DtCheck As DataTable
            DtCheck = objCargo.GetCargoExisting(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
            If DtCheck.Rows.Count > 0 Then
                If cmbCustomer.SelectedValue = 8 Then
                    lblMsg.Text = ""
                    Dim FileName As String = "ShippedStatus"
                    objCargo.getExcelSheetOfShippedStatusSCHWAB(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/LogisticDepartmentGeneratedXLSCHWAB/"
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
                    Dim FileNamePart2 As String = cmbCustomer.SelectedItem.Text + "_" + cmbMonth.SelectedItem.Text + "_" + cmbYear.SelectedItem.Text + "_" + cmbCurrency.SelectedItem.Text

                    Response.AppendHeader("Content-Disposition", "attachment; filename="" Shipped Status " + FileNamePart2 + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                Else
                    lblMsg.Text = ""
                    Dim FileName As String = "ShippedStatus"
                    objCargo.getExcelSheetOfShippedStatus(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/LogisticDepartmentGeneratedXL/"
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
                    Dim FileNamePart2 As String = cmbCustomer.SelectedItem.Text + "_" + cmbMonth.SelectedItem.Text + "_" + cmbYear.SelectedItem.Text + "_" + cmbCurrency.SelectedItem.Text

                    Response.AppendHeader("Content-Disposition", "attachment; filename="" Shipped Status " + FileNamePart2 + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                End If
            Else
                'Show msg no Record Found
                lblMsg.Text = "No Record Found."
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPDF.Click
        Try
            'First If Record Exist then Generate Report other wise not
            Dim DtCheck As DataTable
            DtCheck = objCargo.GetCargoExisting(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
            If DtCheck.Rows.Count > 0 Then
                If cmbCustomer.SelectedValue = 8 Then
                    lblMsg.Text = ""
                    'Export PDf
                    'Delete All PDF files from Folder
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Report.Load(Server.MapPath("..\Reports/StatusofOrderShippedByCustomerSCHWAB.rpt"))
                    Report.SetDatabaseLogon("sa", "pwd")
                    Report.Refresh()
                    Dim FileName As String = "Shipped Status-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text.ToString() + "-" + cmbCurrency.SelectedItem.Text + ""
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, cmbCustomer.SelectedValue)
                    Report.SetParameterValue(1, cmbMonth.SelectedValue)
                    Report.SetParameterValue(2, cmbYear.SelectedItem.Text)
                    Report.SetParameterValue(3, cmbCurrency.SelectedItem.Text)
                    Dim FileOption As New DiskFileDestinationOptions
                    FileOption.DiskFileName = sTempFileName
                    Options = Report.ExportOptions
                    Options.ExportDestinationType = ExportDestinationType.DiskFile
                    Options.ExportFormatType = ExportFormatType.PortableDocFormat
                    Options.DestinationOptions = FileOption
                    Options.ExportDestinationOptions = FileOption
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

                Else
                    lblMsg.Text = ""
                    'Export PDf
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    If (Directory.Exists(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))) Then
                        Report.Load(Server.MapPath("..\Reports/StatusofOrderShippedByCustomer.rpt"))
                        Dim FileName As String = "Shipped Status-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text + "-" + cmbCurrency.SelectedItem.Text + ""
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & FileName & ".pdf"
                        Report.SetDatabaseLogon("sa", "pwd")
                        Report.Refresh()
                        Report.SetParameterValue(0, cmbCustomer.SelectedValue)
                        Report.SetParameterValue(1, cmbMonth.SelectedValue)
                        Report.SetParameterValue(2, cmbYear.SelectedItem.Text)
                        Report.SetParameterValue(3, cmbCurrency.SelectedItem.Text)
                        Dim FileOption As New DiskFileDestinationOptions
                        FileOption.DiskFileName = sTempFileName
                        Options = Report.ExportOptions
                        Options.ExportDestinationType = ExportDestinationType.DiskFile
                        Options.ExportFormatType = ExportFormatType.PortableDocFormat
                        Options.DestinationOptions = FileOption
                        Options.ExportDestinationOptions = FileOption
                        Report.Export()

                        Dim strFileSize As String = ""
                        Dim di As New IO.DirectoryInfo(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))
                        Dim ExistFIleName As String = "Shipped Status-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text + "-" + cmbCurrency.SelectedItem.Text + ".pdf"
                        Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)
                        If aryFi.Length > 0 Then
                            Dim fi As IO.FileInfo
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            For Each fi In aryFi
                                Response.ClearHeaders()
                                Response.ClearContent()
                                Response.ContentType = "application/octet-stream"
                                Response.Charset = "UTF-8"
                                Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                                Response.WriteFile((Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & fi.Name & "")))
                                Response.End()
                            Next
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                        End If
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))
                        di.Create()
                        Report.Load(Server.MapPath("..\Reports/StatusofOrderShippedByCustomer.rpt"))
                        Dim FileName As String = "Shipped Status-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text.ToString() + "-" + cmbCurrency.SelectedItem.Text + ""
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & FileName & ".pdf"
                        Report.SetDatabaseLogon("sa", "pwd")
                        Report.Refresh()
                        Report.SetParameterValue(0, cmbCustomer.SelectedValue)
                        Report.SetParameterValue(1, cmbMonth.SelectedValue)
                        Report.SetParameterValue(2, cmbYear.SelectedItem.Text)
                        Report.SetParameterValue(3, cmbCurrency.SelectedItem.Text)
                        Dim FileOption As New DiskFileDestinationOptions
                        FileOption.DiskFileName = sTempFileName
                        Options = Report.ExportOptions
                        Options.ExportDestinationType = ExportDestinationType.DiskFile
                        Options.ExportFormatType = ExportFormatType.PortableDocFormat
                        Options.DestinationOptions = FileOption
                        Options.ExportDestinationOptions = FileOption
                        Report.Export()

                        Dim strFileSize As String = ""
                        Dim dii As New IO.DirectoryInfo(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))
                        Dim ExistFIleName As String = "Shipped Status-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text + "-" + cmbCurrency.SelectedItem.Text + ".pdf"
                        Dim aryFi As IO.FileInfo() = dii.GetFiles(ExistFIleName)
                        If aryFi.Length > 0 Then
                            Dim fi As IO.FileInfo
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            For Each fi In aryFi
                                Response.ClearHeaders()
                                Response.ClearContent()
                                Response.ContentType = "application/octet-stream"
                                Response.Charset = "UTF-8"
                                Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                                Response.WriteFile((Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & fi.Name & "")))
                                Response.End()
                            Next
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                        End If
                    End If
                End If
            Else
                'Show msg no Record Found
                lblMsg.Text = "No Record Found."
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
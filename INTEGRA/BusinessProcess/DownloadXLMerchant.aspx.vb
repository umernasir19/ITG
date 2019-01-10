Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.SqlClient

Public Class DownloadXLMerchant
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If CLng(Session("Userid")) = 72 Then
                PageHeader("Quality Department Order Status Download")
                btnsupplychn.Text = "Download Order Status"
            Else
                PageHeader("Merchant Order Status Download")
                btnsupplychn.Text = "Download Order Merchant Status"
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnsupplychn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsupplychn.Click
        Try
            If cmbYYear.SelectedItem.Text = "2014 & above PO. Vise" Then
                Dim objPurchaseOrder As New PurchaseOrder
                Dim FileName As String = "OrderStatusPOVise"
                objPurchaseOrder.getMasterExcel(CLng(Session("Userid")))
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/MasterOrderStatusGenerated/"
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
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status_PO Vise_" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            Else
                If CLng(Session("UserId")) = 5 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/5/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 7 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/7/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()

                ElseIf CLng(Session("UserId")) = 15 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/15/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 19 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/19/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 38 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/38/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 39 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/39/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 40 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/40/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 41 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/41/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 59 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/59/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 67 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/67/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 68 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/68/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 69 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/69/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 70 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/70/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 71 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/71/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 72 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/72/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 86 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/86/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 92 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/92/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf CLng(Session("UserId")) = 84 Then
                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/84/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                Else

                    Dim FileName As String = "MySupplyChain"
                    ' objPurchaseOrder.getexcelsheetNew()
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/Complete/"
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
                    ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status " + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
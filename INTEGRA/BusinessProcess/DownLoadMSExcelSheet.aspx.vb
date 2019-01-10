Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.SqlClient

Public Class DownLoadMSExcelSheet
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("DownLoad MS-Excel Sheet")

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnsupplychn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsupplychn.Click
        Try
            Dim spName As String = ""
            If cmbYYear.SelectedItem.Text = "2015 Item Vise" Then
                Dim FileName As String = "MySupplyChain"
                'spName = "sp_AdminSupplyChainExcelSheetLatestNewShipmentDate2015"
                'objPurchaseOrder.getExcelSheetClick(spName)
                objPurchaseOrder.getexcelsheetNew()
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/Complete2015/"
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
            ElseIf cmbYYear.SelectedItem.Text = "2015 PO. Vise" Then
                Dim FileName As String = "OrderStatusPOVise"
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/MasterOrderGenerated2015/"
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status PO Vise " + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()

            ElseIf cmbYYear.SelectedItem.Text = "2014 Item Vise" Then
                Dim FileName As String = "MySupplyChain"
                ' objPurchaseOrder.getexcelsheetNew()
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/Complete2014andOver/"
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
            ElseIf cmbYYear.SelectedItem.Text = "2014 PO. Vise" Then
                Dim FileName As String = "OrderStatusPOVise"
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/MasterOrderGenerated2014/"
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status PO Vise " + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf cmbYYear.SelectedItem.Text = "2013 Item Vise" Then
                Dim FileName As String = "MySupplyChain"
                ' objPurchaseOrder.getexcelsheetNew()
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/Complete2013andOver/"
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
            ElseIf cmbYYear.SelectedItem.Text = "2013 PO. Vise" Then
                Dim FileName As String = "OrderStatusPOVise"
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/MasterOrderGenerated/"
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status PO Vise " + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
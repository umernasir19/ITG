Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class ECPSamplingExcelSheet
    Inherits System.Web.UI.Page
    Dim objECPSampling As New ECPSampling
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("PDM Status Download")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnDownloadExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim FileName As String = "PDMSheet"
            objECPSampling.getExcelSheet()
            Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/PDMGenerated/"
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

            Response.AppendHeader("Content-Disposition", "attachment; filename="" PDM Status " + datee + ".xls")
            Response.TransmitFile(MyPath + "/" + FileName + ".xls")
            Response.End()
        Catch ex As Exception

        End Try
    End Sub
End Class
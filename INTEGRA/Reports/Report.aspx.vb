Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Report
    Inherits System.Web.UI.Page
    Dim rd As New ReportDocument
    Dim POID, ReportName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lcargorId")
        ReportName = Request.QueryString("ReportName")
        Report()
    End Sub
    Sub Report()
        Try
            Select Case ReportName
                Case "POPDF"
                    rd.Load(Server.MapPath("QRMGT.rpt"))
                    rd.SetDatabaseLogon("sa", "pwd")
                    rd.Refresh()
                    rd.SetParameterValue(0, POID)
                    CRViewer.ReportSource = rd
                    Dim FileName As String = POID ' objVender.getVenderNameByID(venderid)
                    Dim MyPath As String = Request.PhysicalApplicationPath + "/EmailPDFs/"
                    ' Dim sDate_time As String
                    Dim sDestination_path As String
                    Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                    Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                    Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                    myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                    File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                    Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                    ' sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                    sDestination_path = MyPath + FileName + ".pdf"
                    File_destination.DiskFileName = sDestination_path
                    Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                    If thefile.Exists Then
                        System.IO.File.Delete(sDestination_path)
                    End If
                    myExportOptions = rd.ExportOptions
                    myExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    myExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    myExportOptions.DestinationOptions = File_destination
                    myExportOptions.FormatOptions = Format_options
                    rd.Export()
                    Response.ContentType = "PDF"
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".pdf")
                    Response.TransmitFile(MyPath + "/" + FileName + ".pdf")
                    Response.End()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class RecordOfOrders
    Inherits System.Web.UI.Page
    Dim objLateOrdersSummary As New LateOrdersSummary
    Dim obGeneralCode As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Record of Orders")

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnSreach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSreach.Click
        Try

            Dim toDate As String
            Dim FromDate As String
            toDate = Date.Now.ToString("MM/dd/yyyy")    ''"12/31/2013"
            FromDate = "1/1/2013"

            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete

            objLateOrdersSummary.TruncateTable()
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            If cmbReportType.SelectedItem.Text = "General" Then
                Report.Load(Server.MapPath("..\Reports/RecordOfOrders.rpt"))
            Else
                Report.Load(Server.MapPath("..\Reports/RecordOfOrdersCustomer.rpt"))
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            ' Dim FileName As String = "Late_Orders_Summary_" + txtDateFrom.Text + "_" + txtDateTo.Text
            Dim FileName As String = "Record of Orders"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, FromDate)
            Report.SetParameterValue(1, toDate)
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
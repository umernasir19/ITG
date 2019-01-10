Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload

Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class SupplierCertificate
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim lCargoID As Long
    Dim objByCargo As New BIInstMst
    Dim objSuppCertificate As New SuppCertificate
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCargoID = Request.QueryString("CargoID")
        If Not Page.IsPostBack Then
            txtRemarks.Text = "WE CERTIFYING THAT GOODS SHIPPED DOESN’T CONTAIN FORBIDDEN SUBSTANCE BY THE GENERAL LEGISLATION REACH, CPSIA,GB, SERIE EN-71 AND GENERAL DIRECTIVE OF SECURITY PRODUCTS."

            Dim dt As DataTable = objSuppCertificate.GetDataCargo(lCargoID)
            If dt.Rows.Count > 0 Then
                txtInvoice.Text = dt.Rows(0)("InvoiceNo")
                txtInvoiceDate.SelectedDate = dt.Rows(0)("InvoiceDate")
                txtLCNo.Text = dt.Rows(0)("LCNO")
                txtLCDate.SelectedDate = dt.Rows(0)("DateOfIssue")
            End If

        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            save()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/SupplierCertificate.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "SupplierCertificate"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
          
            Report.SetParameterValue(0, lCargoID)

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
    Sub save()
        Try
            With objSuppCertificate
                .SuppCertificateID = 0
                .InvoiceNo = txtInvoice.Text.ToUpper
                .InvDate = txtInvoiceDate.SelectedDate
                .LCNO = txtLCNo.Text.ToUpper
                .LCDate = txtLCDate.SelectedDate
                .Remarks = txtRemarks.Text.ToUpper
                .CargoID = lCargoID
                .Save()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class
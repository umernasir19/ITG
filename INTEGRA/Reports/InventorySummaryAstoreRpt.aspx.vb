Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail

Public Class InventorySummaryAstoreRpt
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindItem()
        End If
    End Sub
    Sub BindItem()
        Try
            Dim dtcmbSrno As DataTable
            dtcmbSrno = ObjDPIMst.GetIMSItem()
            cmbItem.DataSource = dtcmbSrno
            cmbItem.DataTextField = "ItemName"
            cmbItem.DataValueField = "IMSItemID"
            cmbItem.DataBind()
            cmbItem.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try

            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Dim ItemID As String = cmbItem.SelectedValue


            Report.Load(Server.MapPath("..\Reports/InventorySummary2Astore.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "InventorySummary2"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"




            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, ItemID)
                Report.SetParameterValue(1, txtDateFrom.SelectedDate)
                Report.SetParameterValue(2, txtDateTo.SelectedDate)
                Report.SetParameterValue(3, CheckDate)
            Else
                CheckDate = 0
                Report.SetParameterValue(0, ItemID)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, Date.Now)
                Report.SetParameterValue(3, CheckDate)
            End If



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
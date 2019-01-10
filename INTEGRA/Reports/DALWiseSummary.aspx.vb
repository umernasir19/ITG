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
Public Class DALWiseSummary
    Inherits System.Web.UI.Page

    Dim objDPPoRecevMst As New DPPoRecevMst

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindStyle()
        End If

    End Sub

    Sub BindDALNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetDalNOforSummary()
            cmbDal.DataSource = dtDalNo
            cmbDal.DataTextField = "DalNo"
            cmbDal.DataValueField = "FabricDbMstID"
            cmbDal.DataBind()
            cmbDal.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetStyleforSummary(cmbDal.SelectedValue)
            cmbStyle.DataSource = dtStyle
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataValueField = "DPRNDID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbDal_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbDal.SelectedIndexChanged
        Try
            BindStyle()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click

        Dim Report As New ReportDocument
        Dim Options As New ExportOptions

        Report.Load(Server.MapPath("..\Reports/DALWiseSummary.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "DALWiseSummary"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        Report.SetParameterValue(0, cmbDal.SelectedValue)
        Report.SetParameterValue(1, cmbStyle.SelectedValue)

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

    End Sub
End Class
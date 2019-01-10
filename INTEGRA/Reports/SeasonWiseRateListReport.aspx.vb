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
Public Class SeasonWiseRateListReport
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSeasonname()
            BindStyle()
            BindBuyer()
            BindSRNo()
        End If
    End Sub
    Sub BindSeasonname()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjDPIMst.GetSeasonNameForOrderStatusRpt()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "seasonname"
            cmbSeason.DataValueField = "seasondatabaseId"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindBuyer()
        Try
            Dim dtcmbBuyer As DataTable
            dtcmbBuyer = ObjDPIMst.GetBuyer()
            cmbBuyer.DataSource = dtcmbBuyer
            cmbBuyer.DataTextField = "CustomerName"
            cmbBuyer.DataValueField = "CustomerDatabaseID"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSRNo()
        Try
            Dim dt As DataTable
            dt = ObjDPIMst.GetSRNo()
            cmbSrNo.DataSource = dt
            cmbSrNo.DataTextField = "SRNo"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dt As DataTable
            dt = ObjDPIMst.GetStyle()
            cmbStyle.DataSource = dt
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim SeasonDatabaseID As String = cmbSeason.SelectedValue
            Dim CustomerDatabaseID As String = cmbBuyer.SelectedValue
            Dim SRNo As String = cmbSrNo.SelectedItem.Text
            Dim Style As String = cmbStyle.SelectedItem.Text
            Report.Load(Server.MapPath("..\Reports/SeasonWiseRateList.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Season_Wise_Rate_List_Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, SeasonDatabaseID)
                Report.SetParameterValue(1, txtDateFrom.SelectedDate)
                Report.SetParameterValue(2, txtDateTo.SelectedDate)
                Report.SetParameterValue(3, CheckDate)
                Report.SetParameterValue(4, CustomerDatabaseID)
                Report.SetParameterValue(5, SRNo)
                Report.SetParameterValue(6, Style)
            Else
                CheckDate = 0
                Report.SetParameterValue(0, SeasonDatabaseID)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, Date.Now)
                Report.SetParameterValue(3, CheckDate)
                Report.SetParameterValue(4, CustomerDatabaseID)
                Report.SetParameterValue(5, SRNo)
                Report.SetParameterValue(6, Style)
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
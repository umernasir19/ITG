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
Public Class ProcessStoreIssueReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim ObjGeneralCode As GeneralCode
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim userid As Long
    Dim ObjIssue As New IssueMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindManualChallanNo()
            BindSeason()
            BindSrNo()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
            BindLocation()
        End If
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssueForStoreReportForGoogRecvNoteForProcessIssue()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReportForProcessIsssue()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForStoreReportForGoodRecvNoteForProcessIsssueReport(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtt
            cmbSrNo.DataValueField = "JobOrderId"
            cmbSrNo.DataTextField = "SrNo"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            lblID.Text = dt.Rows(0)("IMSItemID")
        Catch ex As Exception

        End Try

    End Sub
    Sub BindManualChallanNo()
        Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabricForAllForProcess()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
        cmbManualChallanNo.DataValueField = "processIssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindLocation()
        Try
            Dim dt As DataTable
            dt = objPORecvMaster.BindLocation()
            cmbDepartment.DataSource = dt
            cmbDepartment.DataTextField = "Location"
            cmbDepartment.DataValueField = "LocationId"
            cmbDepartment.DataBind()
            cmbDepartment.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifoForProcess.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Store_Issue_Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                Report.SetParameterValue(1, txtDateTo.SelectedDate)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                Report.SetParameterValue(6, cmbDepartment.SelectedValue)
            Else
                CheckDate = 0
                Report.SetParameterValue(0, Date.Now)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                Report.SetParameterValue(6, cmbDepartment.SelectedValue)
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
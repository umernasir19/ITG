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
Public Class OrderStatus
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSeasonname()
            BindBuyer()
        End If
    End Sub
    Sub BindBuyer()
        Try
            Dim dtcmbSrno As DataTable
            dtcmbSrno = ObjDPIMst.GetCustomerNameForOrderStatusRpt()
            cmbBuyer.DataSource = dtcmbSrno
            cmbBuyer.DataTextField = "Customername"
            cmbBuyer.DataValueField = "CustomerId"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeasonname()
        Try
            Dim dtcmbSrno As DataTable
            dtcmbSrno = ObjDPIMst.GetSeasonNameForOrderStatusRpt()
            cmbSrno.DataSource = dtcmbSrno
            cmbSrno.DataTextField = "seasonname"
            cmbSrno.DataValueField = "seasondatabaseId"
            cmbSrno.DataBind()
            cmbSrno.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If cmbSrno.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Season Name")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim SeasonDatabaseID As String = cmbSrno.SelectedValue
                Dim CustomerDatabaseID As String = cmbBuyer.SelectedValue
                Report.Load(Server.MapPath("..\Reports/OrderStatusReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Order_Status_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, SeasonDatabaseID)
                    Report.SetParameterValue(1, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(2, txtDateTo.SelectedDate)
                    Report.SetParameterValue(3, CheckDate)
                    Report.SetParameterValue(4, CustomerDatabaseID)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, SeasonDatabaseID)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, Date.Now)
                    Report.SetParameterValue(3, CheckDate)
                    Report.SetParameterValue(4, CustomerDatabaseID)
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
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
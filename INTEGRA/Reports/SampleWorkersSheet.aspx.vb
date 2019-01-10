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
Public Class SampleWorkersSheet
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Dim objDPPOMst As New DPPOMst
    Dim objDPPODtl As New DPPODtl
    Dim dtAccess As DataTable
    Dim Dr As DataRow
    Dim ObjtempSampleProgramSheet As New tempSampleProgramSheet
    Dim startDate, enddate As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindWorkerName()
            BindBuyer()
            BindStyle()
        End If
    End Sub
    Sub BindWorkerName()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetWorkerNAME()
            cmbWorkerName.DataSource = dtStyle
            cmbWorkerName.DataTextField = "WorkerName"
            'cmbStyle.DataValueField = "DPRNDID"
            cmbWorkerName.DataBind()
            cmbWorkerName.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindBuyer()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetBuyerForSampleWorkersReport()
            cmbBuyer.DataSource = dtStyle
            cmbBuyer.DataTextField = "Buyer"
            'cmbStyle.DataValueField = "DPRNDID"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetStyleForSampleWorkersReport()
            cmbStyle.DataSource = dtStyle
            cmbStyle.DataTextField = "Style"
            'cmbStyle.DataValueField = "DPRNDID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
   Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try

            If cmbWorkerName.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Worker Name")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim WorkerName As String = cmbWorkerName.SelectedItem.Text
                Dim buyername As String = cmbBuyer.SelectedItem.Text
                Dim Style As String = cmbStyle.SelectedItem.Text

                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/SampleWorkerWiseReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "SampleWorkersSheet"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1

                    Report.SetParameterValue(0, WorkerName)
                    Report.SetParameterValue(1, Style)
                    Report.SetParameterValue(2, buyername)
                    Report.SetParameterValue(3, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(4, txtDateTo.SelectedDate)
                    Report.SetParameterValue(5, CheckDate)
                Else
                    CheckDate = 0

                    Report.SetParameterValue(0, WorkerName)
                    Report.SetParameterValue(1, Style)
                    Report.SetParameterValue(2, buyername)
                    Report.SetParameterValue(3, Date.Now)
                    Report.SetParameterValue(4, Date.Now)
                    Report.SetParameterValue(5, CheckDate)


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
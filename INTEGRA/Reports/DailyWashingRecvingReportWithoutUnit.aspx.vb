Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.Net
Imports System.Net.Mail
Public Class DailyWashingRecvingReportWithoutUnit
    Inherits System.Web.UI.Page
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objSizeRange As New SizeRange
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                ' BindSeason()
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Sub BindSeason()
    '    Try
    '        Dim dtcmbSeason As DataTable
    '        dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase()
    '        cmbSeason.DataSource = dtcmbSeason
    '        cmbSeason.DataTextField = "SeasonName"
    '        cmbSeason.DataValueField = "SeasonDatabaseID"
    '        cmbSeason.DataBind()
    '        cmbSeason.Items.Insert(0, "Select")

    '        cmbColor.DataSource = Nothing
    '        cmbColor.Items.Clear()
    '        cmbColor.DataBind()
    '        cmbColor.Items.Insert(0, "ALL")

    '        cmbColor.DataSource = Nothing
    '        cmbColor.Items.Clear()
    '        cmbColor.DataBind()
    '        cmbColor.Items.Insert(0, "ALL")
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Sub BindSrNo()
    '    Try
    '        Dim dtInvoiceNo As DataTable
    '        'dtInvoiceNo = objSizeRange.GetSrnOForCutting(cmbSeason.SelectedValue)
    '        dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
    '        cmbSrNo.DataSource = dtInvoiceNo
    '        cmbSrNo.DataTextField = "SrNO"
    '        cmbSrNo.DataValueField = "JobOrderID"
    '        cmbSrNo.DataBind()
    '        cmbSrNo.Items.Insert(0, "ALL")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub BindColor()
    '    Try
    '        Dim dtInvoiceNo As DataTable
    '        dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
    '        cmbColor.DataSource = dtInvoiceNo
    '        cmbColor.DataTextField = "BuyerColor"
    '        cmbColor.DataValueField = "JobOrderDetailID"
    '        cmbColor.DataBind()
    '        cmbColor.Items.Insert(0, "ALL")
    '    Catch ex As Exception
    '        cmbColor.DataSource = Nothing
    '        cmbColor.Items.Clear()
    '        cmbColor.DataBind()
    '        cmbColor.Items.Insert(0, "ALL")
    '    End Try
    'End Sub

    'Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
    '    Try
    '        BindSrNo()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSrNo.SelectedIndexChanged
    '    Try
    '        BindColor()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If cmbMonth.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Month")
            ElseIf cmbYear.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Year")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                '  Report.Load(Server.MapPath("..\Reports/OfflineSheetDaily.rpt"))
                Report.Load(Server.MapPath("..\Reports/DailyWashingReceivingWithoutUnitWiseReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Daily_Washing_Receiving_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue("@ttYear", cmbYear.SelectedValue)
                Report.SetParameterValue("@ttMonth", cmbMonth.SelectedValue)

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
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
Public Class SupplierSamplingPerformance
    Inherits System.Web.UI.Page
    Dim objInquiriesEntryClass As New InquiriesEntryClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
            BindSeason()
            BindSupplier()

        End If
    End Sub
    Sub BindSupplier()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetSupplierForPerformanceReport(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbseason.SelectedValue)
            cmbsupplier.DataSource = dt
            cmbsupplier.DataTextField = "vendername"
            cmbsupplier.DataValueField = "Supplierid"
            cmbsupplier.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objInquiriesEntryClass.GetSeasonForPerformanceReport(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
            cmbseason.DataSource = dt
            cmbseason.DataTextField = "season"
            cmbseason.DataValueField = "SeasonID"
            cmbseason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindCustomer()
        cmbCustomer.DataSource = objInquiriesEntryClass.GetFilterComboValues
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()
        '---Bind Buyeing Dept
        cmbDept.DataSource = objInquiriesEntryClass.GetBuyingNo(cmbCustomer.SelectedValue)
        cmbDept.DataValueField = "departmentno"
        cmbDept.DataTextField = "departmentno"
        cmbDept.DataBind()
        BindSeason()
        BindSupplier()
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            '---Bind Buying Dept
            cmbDept.DataSource = objInquiriesEntryClass.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbDept.DataValueField = "departmentno"
            cmbDept.DataTextField = "departmentno"
            cmbDept.DataBind()
            BindSeason()
            BindSupplier()
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            downloadReport()
        Catch ex As Exception

        End Try
    End Sub
    Sub downloadReport()
        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next

        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/SupplierSamplingPerformance.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "SupplierSamplingPerformance"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

        Report.SetParameterValue(0, cmbCustomer.SelectedValue)

        Report.SetParameterValue(1, cmbDept.SelectedItem.Text)
        Report.SetParameterValue(2, cmbseason.SelectedValue)
        Report.SetParameterValue(3, cmbsupplier.SelectedValue)
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
        ' End If
    End Sub

    Protected Sub cmbseason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbseason.SelectedIndexChanged
        Try
            BindSupplier()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDept.SelectedIndexChanged
        Try
            BindSeason()
            BindSupplier()
        Catch ex As Exception

        End Try
    End Sub
End Class
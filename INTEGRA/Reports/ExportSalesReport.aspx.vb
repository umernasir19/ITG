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
Public Class ExportSalesReport
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSno()
            BindCustomer()
            BindInvoice()
        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbBuyer As DataTable
            dtcmbBuyer = ObjDPIMst.GetCustomerExport()
            cmbBuyer.DataSource = dtcmbBuyer
            cmbBuyer.DataTextField = "CustomerName"
            cmbBuyer.DataValueField = "CustomerID"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindInvoice()
        Try
            Dim dtcmbInvoice As DataTable
            dtcmbInvoice = ObjDPIMst.GetInvoiceExport()
            cmbInvoiceno.DataSource = dtcmbInvoice
            cmbInvoiceno.DataTextField = "InvoiceNo"
            ' cmbInvoice.DataValueField = "CustomerID"
            cmbInvoiceno.DataBind()
            cmbInvoiceno.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSno()
        Try
            Dim dtcmbSno As DataTable
            dtcmbSno = ObjDPIMst.GetSno()
            cmbSno.DataSource = dtcmbSno
            cmbSno.DataTextField = "SRNO"
            ' cmbInvoice.DataValueField = "CustomerID"
            cmbSno.DataBind()
            cmbSno.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            'If cmbMonth.SelectedValue = 0 And cmbYear.SelectedValue = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Month/Year")
            ' Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim Month As String = cmbMonth.SelectedItem.Text
            Dim year As String = cmbYear.SelectedItem.Text
            Dim CustomerID As String = cmbBuyer.SelectedValue
            Dim Invoice As String = cmbInvoiceno.SelectedItem.Text
            Dim SrNo As String = cmbSno.SelectedItem.Text
            Report.Load(Server.MapPath("..\Reports/ExportSales.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "ExportSalesReport"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, Month)
            Report.SetParameterValue(1, year)
            Report.SetParameterValue(2, CustomerID)
            Report.SetParameterValue(3, Invoice)
            Report.SetParameterValue(4, SrNo)

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
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class
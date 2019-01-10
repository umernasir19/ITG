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
Public Class MonthlyShipmentReport
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindOrder()
            BindCustomer()
            BindInvoice()

        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbBuyer As DataTable
            dtcmbBuyer = ObjDPIMst.GetCustomer()
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
            dtcmbInvoice = ObjDPIMst.GetInvoice()
            cmbInvoice.DataSource = dtcmbInvoice
            cmbInvoice.DataTextField = "InvoiceNo"
            ' cmbInvoice.DataValueField = "CustomerID"
            cmbInvoice.DataBind()
            cmbInvoice.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindOrder()
        Try
            Dim dtcmbOrder As DataTable
            dtcmbOrder = ObjDPIMst.GetOrder()
            cmbOrder.DataSource = dtcmbOrder
            cmbOrder.DataTextField = "CustomerOrder"
            ' cmbInvoice.DataValueField = "CustomerID"
            cmbOrder.DataBind()
            cmbOrder.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            'If cmbMonth.SelectedValue = 0 And cmbYear.SelectedValue = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Month/Year")
            'Else
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
            Dim Invoice As String = cmbInvoice.SelectedItem.Text
            Dim order As String = cmbOrder.SelectedItem.Text
            Report.Load(Server.MapPath("..\Reports/MonthlyShipment.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "MonthlyShipmentReport"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, Month)
            Report.SetParameterValue(1, year)
            Report.SetParameterValue(2, CustomerID)
            Report.SetParameterValue(3, Invoice)
            Report.SetParameterValue(4, order)

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
        Catch ex As Exception

        End Try
    End Sub

End Class
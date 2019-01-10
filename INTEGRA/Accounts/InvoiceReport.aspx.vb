Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra

Public Class InvoiceReport
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjInvoiceMst As New POInvoiceMaster
    Dim objSupplierDatabase As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                BindSupplier()

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Invoice Report")
    End Sub

    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindSupplier()
        Dim dt As DataTable
        dt = ObjInvoiceMst.GetSupplierForInvoiceeReport()
        cmbSupplier.DataSource = dt
        cmbSupplier.DataTextField = "SupplierName"
        cmbSupplier.DataValueField = "AccountCode"
        cmbSupplier.DataBind()
        cmbSupplier.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindInvoice()
        Dim dt As DataTable
        dt = ObjInvoiceMst.GetVoucher(cmbSupplier.SelectedValue)
        cmbVoucherNo.DataSource = dt
        cmbVoucherNo.DataTextField = "VoucherNo"
        cmbVoucherNo.DataValueField = "tblBankMstId"
        cmbVoucherNo.DataBind()
        cmbVoucherNo.Items.Insert(0, New ListItem("Select", "0"))

    End Sub

    Protected Sub btnQuantityReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuantityReport.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim tblBankMstiD As String = cmbVoucherNo.SelectedValue
            'Dim AccountCode, AccountName, InvoiceNo As String

            'AccountCode = cmbSupplier.SelectedValue.Trim()
            'AccountName = cmbSupplier.SelectedItem.Text
            'InvoiceNo = cmbInvoiceNo.SelectedItem.Text
            Report.Load(Server.MapPath("..\Reports/rptINVOICENEW2.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, tblBankMstiD)
            Report.SetParameterValue(1, tblBankMstiD)




            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Invoice"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

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
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindInvoice()
        Catch ex As Exception

        End Try
    End Sub

End Class

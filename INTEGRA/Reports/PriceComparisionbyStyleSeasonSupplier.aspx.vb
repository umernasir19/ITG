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

Public Class PriceComparisionbyStyleSeasonSupplier
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = ObjCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()


            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = ObjCustomer.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            ' cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))

            cmbBuyer.DataSource = ObjCustomer.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = ObjCustomer.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            'cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))



            cmbBuyer.DataSource = ObjCustomer.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbBuyingDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            cmbBuyer.DataSource = ObjCustomer.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Try
            Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
            Dim CustomerID As Long = cmbCustomer.SelectedValue
            Dim Buyer As String = cmbBuyer.SelectedItem.Text
            Dim CustomerName As String = cmbCustomer.SelectedItem.Text
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/PriceComparisionBySeasonSupplier.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Price Comparison Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, CustomerID)
            Report.SetParameterValue(1, Buyer)
            Report.SetParameterValue(2, BuyingDept)
            Report.SetParameterValue(3, CustomerName)

            'Report.SetParameterValue(5, txtEndDatee.SelectedDate)
            'Report.SetParameterValue(6, cmbReportType.SelectedItem.Text)
            'Report.SetParameterValue(7, Heading)
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
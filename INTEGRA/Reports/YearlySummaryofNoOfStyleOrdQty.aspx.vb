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
Public Class YearlySummaryofNoOfStyleOrdQty
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = objPurchaseMaster.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = objPurchaseMaster.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbbuyingDept.DataSource = dt
        cmbbuyingDept.DataTextField = "BuyingDept"
        cmbbuyingDept.DataBind()
        cmbbuyingDept.Items.Insert(0, New ListItem("All", "0"))

    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindDept(cmbCustomer.SelectedValue)

    End Sub
    Sub BindDept(ByVal CustomerID As Long)
        Dim dt As DataTable
        dt = objPurchaseMaster.GetDeptCustomerWise(CustomerID)
        cmbbuyingDept.DataSource = dt
        cmbbuyingDept.DataTextField = "BuyingDept"
        cmbbuyingDept.DataBind()
        cmbbuyingDept.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try

            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            ' Report.Load(Server.MapPath("..\Reports/EnquirySystemALL.rpt"))
            'If cmbType.SelectedValue = 0 Then
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
            'Else
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
            'End If

            Report.Load(Server.MapPath("..\Reports/YearlySummaryNoofStyleorderqty.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "YearlySummary"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, cmbbuyingDept.SelectedItem.Text)
            Report.SetParameterValue(1, cmbCustomer.SelectedValue)
            Report.SetParameterValue(2, cmbCustomer.SelectedItem.Text)


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
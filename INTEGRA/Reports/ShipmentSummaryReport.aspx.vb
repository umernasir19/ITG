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
Public Class ShipmentSummaryReport
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
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
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))

            'txtStartDate.Text = ""
            'txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Try
            ' If txtStartDatee.ValidationDate <> "" And txtEndDatee.ValidationDate <> "" Then
            'Dim startdate As Date = txtStartDate.Text
            ' Dim EndDate As Date = txtEndDate.Text
            'Dim season As String = cmbSeason.SelectedItem.Text
            'Dim supplier As String
            Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
            Dim CustomerID As Long = cmbCustomer.SelectedValue
            Dim Month As String = cmbMonth.SelectedValue
            Dim year As String = cmbYear.SelectedItem.Text
            'Dim Heading As String
            'Dim monthdate As Date = txtStartDatee.SelectedDate
            'If cmbReportType.SelectedItem.Text = "Monthly" Then
            '    If monthdate.Month = 1 Then
            '        Heading = "Jan"
            '    ElseIf monthdate.Month = 2 Then
            '        Heading = "Feb"
            '    ElseIf monthdate.Month = 3 Then
            '        Heading = "Mar"
            '    ElseIf monthdate.Month = 4 Then
            '        Heading = "April"
            '    ElseIf monthdate.Month = 5 Then
            '        Heading = "May"
            '    ElseIf monthdate.Month = 6 Then
            '        Heading = "June"
            '    ElseIf monthdate.Month = 7 Then
            '        Heading = "July"
            '    ElseIf monthdate.Month = 8 Then
            '        Heading = "Aug"
            '    ElseIf monthdate.Month = 9 Then
            '        Heading = "Sep"
            '    ElseIf monthdate.Month = 10 Then
            '        Heading = "Oct"
            '    ElseIf monthdate.Month = 11 Then
            '        Heading = "Nov"
            '    ElseIf monthdate.Month = 12 Then
            '        Heading = "Dec"
            '    End If
            'ElseIf cmbReportType.SelectedItem.Text = "Yearly" Then
            '    Heading = monthdate.Year
            'Else
            '    Heading = cmbSeason.SelectedItem.Text
            'End If

            'If cmbSupplier.SelectedValue = 0 Then
            '    supplier = 0
            'Else
            '    supplier = cmbSupplier.SelectedValue
            'End If


            'customer = cmbCustomer.SelectedValue


            If cmbBuyingDept.SelectedItem.Text = "All" Then
                BuyingDept = "All"
            Else
                BuyingDept = cmbBuyingDept.SelectedItem.Text
            End If

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

            Report.Load(Server.MapPath("..\Reports/SHIPMENTSUMMERYREPORT.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Shipment Summary Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, CustomerID)
            Report.SetParameterValue(1, BuyingDept)
            Report.SetParameterValue(2, Month)
            Report.SetParameterValue(3, year)
            'Report.SetParameterValue(4, txtStartDatee.SelectedDate)

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
            'Else
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class
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
Public Class InquiryRecvConfirmReport
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
            cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))

            'txtStartDate.Text = ""
            'txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewReport.Click
        Try
          
            If cmbBuyingDept.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
            Else
                Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
                Dim CustomerID As Long = cmbCustomer.SelectedValue
                Dim Month As String = cmbMonth.SelectedValue
                Dim year As String = cmbYear.SelectedItem.Text
                BuyingDept = cmbBuyingDept.SelectedItem.Text

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/InquiriesRecvConfromed.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "InquiryRecv&ConfirmReport"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue(0, Month)
                Report.SetParameterValue(1, year)
                Report.SetParameterValue(2, CustomerID)
                Report.SetParameterValue(3, BuyingDept)
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

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
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
Public Class SupplierCriticalPathTracking
    Inherits System.Web.UI.Page
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSupplier()
            BindCustomer()
            BindSeason()
        End If
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystemAddclass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Dim dt As New DataTable
        dt = objEnquiriesSystemAddclass.GetCustomer
        cmbCustomer.DataSource = dt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()
        cmbCustomer.Items.Insert(0, New ListItem("ALL", "0"))

        ''---Bind BuyingDept
        cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
        cmbBuyingDept.DataTextField = "BuyingDept"
        cmbBuyingDept.DataValueField = "BuyingDept"
        cmbBuyingDept.DataBind()


        ''---Bind Brand 

        CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReport(cmbCustomer.SelectedValue)
        CmbBrand.DataTextField = "BrandName"
        CmbBrand.DataValueField = "BrandName"
        CmbBrand.DataBind()
        CmbBrand.Items.Insert(0, New ListItem("All", "0"))

        ''----Bind Buyer
        cmbBuyer.DataSource = objEnquiriesSystemAddclass.GetBuyerReport(cmbCustomer.SelectedValue)
        cmbBuyer.DataTextField = "Buyer_Name"
        cmbBuyer.DataValueField = "Buyer_Name"
        cmbBuyer.DataBind()
        cmbBuyer.Items.Insert(0, New ListItem("All", "0"))

    End Sub
    Sub BindSupplier()
        Dim dt As New DataTable
        dt = objEnquiriesSystemAddclass.GetSupplier
        cmbSupplier.DataSource = dt
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataBind()
        cmbSupplier.Items.Insert(0, New ListItem("Select", "0"))
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnView.Click

        If txtStartDate.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
        ElseIf txtEndDate.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Dim SupplierID As Integer = cmbSupplier.SelectedValue
            Dim CustomerID As Integer = cmbCustomer.SelectedValue
            Dim SeasonID As Integer = cmbSeason.SelectedValue
            Dim Brand As String = CmbBrand.SelectedItem.Text
            Dim Buyer As String = cmbBuyer.SelectedItem.Text
            Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            'Report.Load(Server.MapPath("..\Reports/SupplierActionENQNew.rpt"))
            Report.Load(Server.MapPath("..\Reports/SampleFollowup.rpt"))
            'If cmbType.SelectedValue = 0 Then
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
            'Else
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
            'End If

            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Supplier Critical Path"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, txtStartDate.Text)
            Report.SetParameterValue(1, txtEndDate.Text)
            Report.SetParameterValue(2, txtMeetingDate.Text)
            Report.SetParameterValue(3, BuyingDept)
            Report.SetParameterValue(4, CustomerID)
            Report.SetParameterValue(5, Buyer)
            Report.SetParameterValue(6, SeasonID)
            Report.SetParameterValue(7, SupplierID)
            Report.SetParameterValue(8, Brand)


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


    End Sub

    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            ' cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))

            ''---Bind Brand 
            CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReport(cmbCustomer.SelectedValue)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))

            cmbBuyer.DataSource = objEnquiriesSystemAddclass.GetBuyerReport(cmbCustomer.SelectedValue)
            cmbBuyer.DataTextField = "Buyer_Name"
            cmbBuyer.DataValueField = "Buyer_Name"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New ListItem("All", "0"))

            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

End Class
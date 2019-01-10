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
Public Class EnquiriesReportView
    Inherits System.Web.UI.Page
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Dim objCustomer As New Customer
    Dim EnquiriesSystemID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            BindProductCat()
            'brand()
            BindSeason()
            BindCustomer()
            BindSupplier()
            BindStyle()

        End If
    End Sub
    Sub BindStyle()
        Dim dt As New DataTable
        dt = objEnquiriesSystemAddclass.GetStyleDiscat(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbSeason.SelectedValue, cmbEnquirypurpose.SelectedItem.Text, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, CmbBrand.SelectedItem.Text)
        cmbStyle.DataSource = dt
        cmbStyle.DataValueField = "StyleNo"
        cmbStyle.DataTextField = "StyleNo"
        cmbStyle.DataBind()
        cmbStyle.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindProductCat()
        Dim dtProductCategories As DataTable
        dtProductCategories = objEnquiriesSystemAddclass.GetAllProductCategoriesReport()
        cmbProductCategory.DataSource = dtProductCategories
        cmbProductCategory.DataTextField = "ProductCategories"
        cmbProductCategory.DataValueField = "ProductCategoriesID"
        cmbProductCategory.DataBind()
        cmbProductCategory.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub brand()

        CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandInfoNo(cmbCustomer.SelectedValue)
        CmbBrand.DataTextField = "BrandName"
        CmbBrand.DataValueField = "BrandName"
        CmbBrand.DataBind()
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
    Sub BindSupplier()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystemAddclass.GetSupplier
            cmbSupplier.DataSource = dt
            cmbSupplier.DataTextField = "VenderName"
            cmbSupplier.DataValueField = "VenderLibraryID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, New ListItem("All", "0"))

            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()

            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiriesSystemAddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()


            ''---Bind Brand 
            CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReportNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))

           

            'UpdatecmbBuyerName.Update()
            ''---Bind Brand 
            'cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBrandInfoNo(cmbCustomer.SelectedValue)
            'cmbBrand.DataTextField = "BrandName"
            'cmbBrand.DataValueField = "BrandName"
            'cmbBrand.DataBind()
            'UpcmbBrand.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnView.Click
        Try


            If txtStartDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
            ElseIf txtEndDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
            ElseIf txtMeetingDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Meeting Date Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                ' Dim EnquiriesSystemID As Integer = cmbStyle.SelectedValue
                Dim styleNo As String = cmbStyle.SelectedItem.Text
                Dim customerid As Long = cmbCustomer.SelectedValue
                Dim seasonid As Long = cmbSeason.SelectedValue
                Dim SupplierId As Long = cmbSupplier.SelectedValue
                Dim Brand As String
                Dim Buyer As String = cmbBuyer.SelectedItem.Text
                Dim eqnPurpose As String = cmbEnquirypurpose.SelectedItem.Text

                'If CmbBrand.SelectedItem.Text = "All" Then
                '    Brand = CmbBrand.SelectedValue
                'Else
                Brand = CmbBrand.SelectedItem.Text
                'End If

                Dim ProductCatID As Long = cmbProductCategory.SelectedValue
                Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text

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
                If cmbReportType.SelectedItem.Text = "With Image" And cmbReportTypeP.SelectedItem.Text = "With Price" And cmbReportTypeR.SelectedItem.Text = "With Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R1NEW.rpt"))


                ElseIf cmbReportType.SelectedItem.Text = "With Image" And cmbReportTypeP.SelectedItem.Text = "With Price" And cmbReportTypeR.SelectedItem.Text = "Without Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R2NEW.rpt"))

                ElseIf cmbReportType.SelectedItem.Text = "With Image" And cmbReportTypeP.SelectedItem.Text = "Without Price" And cmbReportTypeR.SelectedItem.Text = "With Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R3NEW.rpt"))


                ElseIf cmbReportType.SelectedItem.Text = "With Image" And cmbReportTypeP.SelectedItem.Text = "Without Price" And cmbReportTypeR.SelectedItem.Text = "Without Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R4NEW.rpt"))

                ElseIf cmbReportType.SelectedItem.Text = "Without Image" And cmbReportTypeP.SelectedItem.Text = "With Price" And cmbReportTypeR.SelectedItem.Text = "With Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R5NEW.rpt"))

                ElseIf cmbReportType.SelectedItem.Text = "Without Image" And cmbReportTypeP.SelectedItem.Text = "With Price" And cmbReportTypeR.SelectedItem.Text = "Without Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R6NEW.rpt"))

                ElseIf cmbReportType.SelectedItem.Text = "Without Image" And cmbReportTypeP.SelectedItem.Text = "Without Price" And cmbReportTypeR.SelectedItem.Text = "With Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R7NEW.rpt"))

                ElseIf cmbReportType.SelectedItem.Text = "Without Image" And cmbReportTypeP.SelectedItem.Text = "Without Price" And cmbReportTypeR.SelectedItem.Text = "Without Remarks" Then
                    Report.Load(Server.MapPath("..\Reports/R8NEW.rpt"))

                End If

                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Final Meeting Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue(0, txtStartDate.Text)
                Report.SetParameterValue(1, txtEndDate.Text)
                Report.SetParameterValue(2, customerid)
                Report.SetParameterValue(3, seasonid)
                Report.SetParameterValue(4, Brand)
                Report.SetParameterValue(5, ProductCatID)
                Report.SetParameterValue(6, BuyingDept)
                Report.SetParameterValue(7, txtMeetingDate.Text)
                Report.SetParameterValue(8, styleNo)
                Report.SetParameterValue(9, SupplierId)
                Report.SetParameterValue(10, Buyer)
                Report.SetParameterValue(11, eqnPurpose)


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

    Protected Sub cmbReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        Try
            'If cmbReportType.SelectedValue = 0 Or cmbReportType.SelectedValue = 1 Then
            '    RowType.Visible = True
            '    If cmbReportType.SelectedValue = 0 Then
            '        lblReportType.Text = "Brand"
            '        CmbBrand.Visible = True
            '        cmbProductCategory.Visible = False
            '    ElseIf cmbReportType.SelectedValue = 1 Then
            '        lblReportType.Text = "Product Category"
            '        CmbBrand.Visible = False
            '        cmbProductCategory.Visible = True
            '    End If
            'Else
            '    RowType.Visible = False
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()

            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiriesSystemAddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()


            ''---Bind Brand 
            CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReportNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))

            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
            BindStyle()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbEnquirypurpose_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEnquirypurpose.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            ''---Bind Byuer Name
            cmbBuyer.DataSource = objEnquiriesSystemAddclass.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()


            ''---Bind Brand 
            CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReportNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))

            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyer.SelectedIndexChanged
        Try
            ''---Bind Brand 
            CmbBrand.DataSource = objEnquiriesSystemAddclass.GetBrandReportNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text)
            CmbBrand.DataTextField = "BrandName"
            CmbBrand.DataValueField = "BrandName"
            CmbBrand.DataBind()
            CmbBrand.Items.Insert(0, New ListItem("All", "0"))

            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CmbBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBrand.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtMeetingDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub
End Class
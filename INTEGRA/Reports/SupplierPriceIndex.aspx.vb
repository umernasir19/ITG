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
Public Class SupplierPriceIndex
    Inherits System.Web.UI.Page
    Dim objEnquiresesEntryaddclass As New EnquiriesSystemAddclass
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            BindSupplier()
            BindSeason()
            BindStyle()
        End If
    End Sub
    Sub BindStyle()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.GetStyleNo(cmbSupplier.SelectedValue, cmbSeason.SelectedValue)
            cmbStyle.DataSource = dt
            cmbStyle.DataTextField = "StyleNo"
            ' cmbStyle.DataValueField = "CPRequirmentID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dt As DataTable
            dt = objEnquiresesEntryaddclass.GetSupplierName()
            cmbSupplier.DataSource = dt
            cmbSupplier.DataTextField = "VenderName"
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystemAddclass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStyle.SelectedIndexChanged
        BindSupplier()
    End Sub

  
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            If txtStartDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
            ElseIf txtEndDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim StyleNo As String = cmbStyle.SelectedItem.Text
                Dim supplierId As String = cmbSupplier.SelectedValue
                Dim SeasonID As String = cmbSeason.SelectedValue

                'If cmbSupplier.SelectedValue = 0 Then
                '    supplier = 0
                'Else
                '    supplier = cmbSupplier.SelectedValue
                'End If


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

                Report.Load(Server.MapPath("..\Reports/SupplierPriceIndexnew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Comparative Costing Sheet"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, StyleNo)
                Report.SetParameterValue(1, txtEndDate.Text)
                Report.SetParameterValue(2, txtStartDate.Text)
                Report.SetParameterValue(3, supplierId)
                Report.SetParameterValue(4, SeasonID)
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            If txtStartDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
            ElseIf txtEndDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim StyleNo As String = cmbStyle.SelectedItem.Text
                Dim supplierId As String = cmbSupplier.SelectedValue
                Dim SeasonID As String = cmbSeason.SelectedValue
                'If cmbSupplier.SelectedValue = 0 Then
                '    supplier = 0
                'Else
                '    supplier = cmbSupplier.SelectedValue
                'End If


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

                Report.Load(Server.MapPath("..\Reports/SupplierPriceIndexConfirmPR.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Comparative Costing Sheet"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, StyleNo)
                Report.SetParameterValue(1, txtEndDate.Text)
                Report.SetParameterValue(2, txtStartDate.Text)
                Report.SetParameterValue(3, supplierId)
                Report.SetParameterValue(4, SeasonID)
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

    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindStyle()
            txtStartDate.Text = ""
            txtEndDate.Text = ""
        Catch ex As Exception

        End Try
    End Sub
End Class
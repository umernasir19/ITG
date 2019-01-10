Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class MilestoneSummary
    Inherits System.Web.UI.Page
    Dim obGeneralCode As New GeneralCode
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Milestone Summary Report")
            BindBuyingDept()
            bindProductPOrtfolio()
            lblHeadingSupplier.Visible = False
            cmbSupplier.Visible = False
            lblMerchandiser.Visible = True
            cmbMarchandiser.Visible = True
            lblReport.Visible = False
            cmbReport.Visible = False
            BindMarchandiser()
            BindSupplier()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindBuyingDept()
       Dim objStyleMaster As New StyleMaster
        cmbBuyingDetp.DataSource = objStyleMaster.GetBuyingNoforMilestone()
        cmbBuyingDetp.DataValueField = "EkNumber"
        cmbBuyingDetp.DataTextField = "EkNumber"
        cmbBuyingDetp.DataBind()
        'cmbSupplier.Items.Insert(0, New ListItem("All Supplier", "0"))
    End Sub
    Sub BindSupplier()
        Dim ObjVender As New Vender
        Dim dtVender As DataTable
        'dtVender = ObjVender.getVenderForPONNew(cmbProductPortfolio.SelectedValue)
        dtVender = ObjVender.getVenderForPONNew2(cmbProductPortfolio.SelectedValue, cmbBuyingDetp.SelectedItem.Text)
        cmbSupplier.DataSource = dtVender
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataBind()
        'cmbSupplier.Items.Insert(0, New ListItem("All Supplier", "0"))
    End Sub
    Sub bindProductPOrtfolio()
        Dim ObjUser As New User
        'Chking ProductPortfolio
        Dim dt As DataTable = ObjUser.GetProductPortfolioNew()
        cmbProductPortfolio.DataSource = dt
        cmbProductPortfolio.DataValueField = "ProductPortfolioID"
        cmbProductPortfolio.DataTextField = "ProductPortfolio"
        cmbProductPortfolio.DataBind()
    End Sub
    Sub BindMarchandiser()
        Dim ObjUser As New User
        Dim dtUser As DataTable
        ' dtUser = ObjUser.getuserForPONew(cmbProductPortfolio.SelectedValue)
        dtUser = ObjUser.getuserForPONew2(cmbProductPortfolio.SelectedValue, cmbBuyingDetp.SelectedItem.Text)
        cmbMarchandiser.DataSource = dtUser
        cmbMarchandiser.DataTextField = "username"
        cmbMarchandiser.DataValueField = "userid"
        cmbMarchandiser.DataBind()

        

    End Sub
    
    Protected Sub cmbReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedIndexChanged
        If cmbReportType.Text = "Supplier Wise" Then
            lblHeadingSupplier.Visible = True
            cmbSupplier.Visible = True
            lblMerchandiser.Visible = False
            cmbMarchandiser.Visible = False
            lblReport.Visible = False
            cmbReport.Visible = False
        ElseIf cmbReportType.Text = "Merchandiser Wise" Then
            lblHeadingSupplier.Visible = False
            cmbSupplier.Visible = False
            lblMerchandiser.Visible = True
            cmbMarchandiser.Visible = True
            lblReport.Visible = False
            cmbReport.Visible = False

        End If
    End Sub
    Protected Sub cmbMarchandiser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMarchandiser.SelectedIndexChanged
        Try
            'Dim ObjUser As New User
            ''Chking ProductPortfolio
            'Dim dt As DataTable = ObjUser.GetProductPortfolioID(cmbMarchandiser.SelectedValue)
            'cmbProductPortfolio.DataSource = dt
            'cmbProductPortfolio.DataValueField = "ProductPortfolioID"
            'cmbProductPortfolio.DataTextField = "ProductPortfolio"
            'cmbProductPortfolio.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            'Dim toDate As String
            'Dim FromDate As String
            'toDate = obGeneralCode.GetDateFormat(txtDateTo.Text)
            'FromDate = obGeneralCode.GetDateFormat(txtDateFrom.Text)
            'MilestoneP3Activity
            Dim obMilestoneP3Activity As New MilestoneP3Activity
            With obMilestoneP3Activity
                .ID = 0
                .CreationDate = Date.Now
                .LoginUserName = obMilestoneP3Activity.GetUserName(CLng(Session("Userid")))
                .ReportType = "Milestone Summary"
                .FromDate = txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd")
                .ToDate = txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd")
                If cmbReportType.Text = "Supplier Wise" Then
                    .ReportSelection = "Supplier Wise-" + cmbSupplier.SelectedItem.Text
                ElseIf cmbReportType.Text = "Merchandiser Wise" Then
                    If cmbReport.SelectedItem.Text = "General" Then
                        .ReportSelection = "Merchandiser Wise" + "-General-" + cmbMarchandiser.SelectedItem.Text
                    ElseIf cmbReport.SelectedItem.Text = "With Follow-up Remarks" Then
                        .ReportSelection = "Merchandiser Wise" + "-With Follow-up Remarks-" + cmbMarchandiser.SelectedItem.Text
                    ElseIf cmbReport.SelectedItem.Text = "With Last/Current Follow-up" Then
                        .ReportSelection = "Merchandiser Wise" + "-With Last/Current Follow-up-" + cmbMarchandiser.SelectedItem.Text
                    End If
                End If
                .SaveMilestoneP3Activity()
            End With
            'end

            If cmbReportType.Text = "Supplier Wise" Then
                'Delete All PDF files from Folder
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                If cmbProductPortfolio.SelectedItem.Text = "Knitwear Apparels" Then
                    Report.Load(Server.MapPath("..\Reports/Milestone_KnitwearSupplierWise.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(2, cmbProductPortfolio.SelectedItem.Text)
                    Report.SetParameterValue(3, cmbSupplier.SelectedValue)
                    Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                ElseIf cmbProductPortfolio.SelectedItem.Text = "Woven Apparels" Then
                    Report.Load(Server.MapPath("..\Reports/Milestone_WovenSupplierwise.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(2, cmbProductPortfolio.SelectedItem.Text)
                    Report.SetParameterValue(3, cmbSupplier.SelectedValue)
                    Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                ElseIf cmbProductPortfolio.SelectedItem.Text = "Home Textiles & Leathers" Then
                    Report.Load(Server.MapPath("..\Reports/Milestone_HometextileSuplierWise.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    Report.SetParameterValue(2, cmbProductPortfolio.SelectedItem.Text)
                    Report.SetParameterValue(3, cmbSupplier.SelectedValue)
                    Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                    'ElseIf cmbProductPortfolio.SelectedItem.Text = "Apparel" Then
                    '    Report.Load(Server.MapPath("..\Reports/OrderMilestonSummaryNewWithQtyFinal.rpt"))
                    '    Report.Refresh()
                    '    Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    '    Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    '    Report.SetParameterValue(2, cmbSupplier.SelectedValue)
                End If


                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year
                Dim FileName As String = "Milestone Summary_" + cmbSupplier.SelectedItem.Text + " " + datee
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
            ElseIf cmbReportType.Text = "Merchandiser Wise" Then
                'Delete All PDF files from Folder
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete

                If cmbReport.SelectedItem.Text = "General" Then
                    If cmbProductPortfolio.SelectedItem.Text = "Knitwear Apparels" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_Knitwear.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, cmbProductPortfolio.SelectedItem.Text)
                        Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Woven Apparels" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_Woven.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, cmbProductPortfolio.SelectedItem.Text)
                        Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Home Textiles & Leathers" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_Hometextile.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, cmbProductPortfolio.SelectedItem.Text)
                        Report.SetParameterValue(4, cmbBuyingDetp.SelectedItem.Text)
                        'ElseIf cmbProductPortfolio.SelectedItem.Text = "Apparel" Then
                        '    Report.Load(Server.MapPath("..\Reports/OrderMilestonSummaryMerchandiserWithQTYFinal.rpt"))
                        '    Report.Refresh()
                        '    Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        '    Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        '    Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                    End If

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year
                    Dim FileName As String = "Milestone Summary_" + cmbMarchandiser.SelectedItem.Text + " " + datee
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
                ElseIf cmbReport.SelectedItem.Text = "With Follow-up Remarks" Then

                    If cmbProductPortfolio.SelectedItem.Text = "Knitwear Apparels" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_HardLine.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 1)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Leather Goods" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_LeatherGoods.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 2)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Home Textile" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_HomeTextile.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 5)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Apparel" Then
                        Report.Load(Server.MapPath("..\Reports/OrderMilestonSummaryMerchandiserWithQTYandFollowupFinal.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                    End If

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + "-" + Hour + "-" + Minute + "-" + AMorPMResult
                    Dim FileName As String = "Milestone Summary With Follow-up_" + cmbMarchandiser.SelectedItem.Text + " " + datee
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
                ElseIf cmbReport.SelectedItem.Text = "With Last/Current Follow-up" Then

                    If cmbProductPortfolio.SelectedItem.Text = "Hard-line" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_HardLine.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 1)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Leather Goods" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_LeatherGoods.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 2)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Home Textile" Then
                        Report.Load(Server.MapPath("..\Reports/Milestone_HomeTextile.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                        Report.SetParameterValue(3, 5)
                    ElseIf cmbProductPortfolio.SelectedItem.Text = "Apparel" Then
                        Report.Load(Server.MapPath("..\Reports/OrderMilestonSummaryMerchandiserWithQTYandFollowupForMailFinal.rpt"))
                        Report.Refresh()
                        Report.SetParameterValue(0, txtDateFromm.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(1, txtDateToo.SelectedDate.Value.ToString("yyyy-MM-dd"))
                        Report.SetParameterValue(2, cmbMarchandiser.SelectedValue)
                    End If

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim Day As String = Date.Now().Day()
                    Dim month As String = Date.Now().Month
                    Dim year As String = Date.Now().Year
                    Dim Hour As String = Date.Now().Hour
                    Dim Minute As String = Date.Now().Minute
                    Dim AMorPMResult As String = Now.ToString("tt ")
                    Dim datee As String = Day + "-" + month + "-" + year + "-" + Hour + "-" + Minute + "-" + AMorPMResult
                    Dim FileName As String = "Milestone Summary With Last-Current Follow-up_" + cmbMarchandiser.SelectedItem.Text + " " + datee
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
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbProductPortfolio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductPortfolio.SelectedIndexChanged
        Try
            If cmbReportType.Text = "Merchandiser Wise" Then
                BindMarchandiser()
                lblHeadingSupplier.Visible = False
                cmbSupplier.Visible = False
                lblMerchandiser.Visible = True
                cmbMarchandiser.Visible = True
                lblReport.Visible = False
                cmbReport.Visible = False
            Else
                BindSupplier()
                lblHeadingSupplier.Visible = True
                cmbSupplier.Visible = True
                lblMerchandiser.Visible = False
                cmbMarchandiser.Visible = False
                lblReport.Visible = False
                cmbReport.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbBuyingDetp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDetp.SelectedIndexChanged
        Try
            BindMarchandiser()
            BindSupplier()
        Catch ex As Exception

        End Try
    End Sub
End Class

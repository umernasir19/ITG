Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class StyleInspectionReport
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindPONo()
        End If
    End Sub
    Sub BindPONo()

        Dim dt As DataTable
        dt = objPurchaseMaster.GetPo
        cmbPONo.DataSource = dt
        cmbPONo.DataTextField = "PONo"
        cmbPONo.DataValueField = "POID"
        cmbPONo.DataBind()
        cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub

    Sub BindColor()

        Dim dt As DataTable
        dt = objPurchaseMaster.GetColor(lblStyleID.Text)
        cmbColor.DataSource = dt
        cmbColor.DataTextField = "Colorway"
        'cmbColor.DataValueField = "StyleID"
        cmbColor.DataBind()
        cmbColor.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub btnSreach_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSreach.Click
        Try
            If cmbPONo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select PO.No")
            ElseIf cmbColor.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select Color")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                ' Report.Load(Server.MapPath("..\Reports/EnquirySystemALL.rpt"))
                'If cmbType.SelectedValue = 0 Then
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
                'Else
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
                'End If

                Report.Load(Server.MapPath("..\Reports/InspectionReportFinal.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "InspectionForm"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, cmbPONo.SelectedValue)
                Report.SetParameterValue(1, cmbColor.SelectedItem.Text)

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

    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPONo.SelectedIndexChanged
        Try

            Dim dt As DataTable
            If cmbPONo.SelectedValue > 0 Then
                dt = objPurchaseMaster.getStyleID(cmbPONo.SelectedValue)
                If dt.Rows.Count > 0 Then
                    lblStyleID.Text = dt.Rows(0)("StyleID")
                    BindColor()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFabric_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFabric.Click
        Try
            If cmbPONo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select PO.No")
            ElseIf cmbColor.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select Color")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                ' Report.Load(Server.MapPath("..\Reports/EnquirySystemALL.rpt"))
                'If cmbType.SelectedValue = 0 Then
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
                'Else
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
                'End If

                Report.Load(Server.MapPath("..\Reports/FabricCheckListFinal.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "FabricAndPackingCheckList"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, lblStyleID.Text)
                Report.SetParameterValue(1, cmbPONo.SelectedValue)
                Report.SetParameterValue(2, lblStyleID.Text)
                Report.SetParameterValue(3, lblStyleID.Text)
                ' Report.SetParameterValue(4, cmbPONo.SelectedValue)
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

    Protected Sub btnPacking_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPacking.Click
        Try
            If cmbPONo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select PO.No")
                'ElseIf cmbColor.SelectedItem.Text = "Select" Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select Color")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                ' Report.Load(Server.MapPath("..\Reports/EnquirySystemALL.rpt"))
                'If cmbType.SelectedValue = 0 Then
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
                'Else
                '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
                'End If

                Report.Load(Server.MapPath("..\Reports/PackingCheckList.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PackingCheckList"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, lblStyleID.Text)
                Report.SetParameterValue(1, cmbPONo.SelectedValue)

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

    Protected Sub btnFabricIns_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFabricIns.Click
        Try
            If cmbPONo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select PO.No")
            ElseIf cmbColor.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select Color")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions


                Report.Load(Server.MapPath("..\Reports/FabricInspectionTest.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "FabricInspection"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue(0, cmbColor.SelectedItem.Text)
                Report.SetParameterValue(1, cmbPONo.SelectedValue)

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

    Protected Sub txtPONO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPONO.TextChanged
        Try
            Dim dtpo As DataTable = objPurchaseMaster.GetPOIDOnPoNo(txtPONO.Text)
            If dtpo.Rows.Count > 0 Then
                lblpoid.Text = dtpo.Rows(0)("POID")
                cmbPONo.SelectedValue = dtpo.Rows(0)("POID")
                Dim dt As DataTable
                If cmbPONo.SelectedValue > 0 Then
                    dt = objPurchaseMaster.getStyleID(cmbPONo.SelectedValue)
                    If dt.Rows.Count > 0 Then
                        lblStyleID.Text = dt.Rows(0)("StyleID")
                        BindColor()
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
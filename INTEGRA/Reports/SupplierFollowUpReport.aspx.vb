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
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class SupplierFollowUpReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim UserId As Long
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objSizeRange As New SizeRange
    Dim objTemSRNO As New TemPOSupplierFollowup
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BindSupplier()
            BindSeason()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
        End If
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSrNoo.DataSource = dtInvoiceNo
            cmbSrNoo.DataTextField = "SrNO"
            cmbSrNoo.DataValueField = "JobOrderID"
            cmbSrNoo.DataBind()
            cmbSrNoo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNoo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSrNoo.SelectedIndexChanged
        Try
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReport()
            cmbSupplierr.DataSource = dtP
            cmbSupplierr.DataTextField = "PartyAccount"
            cmbSupplierr.DataBind()
            cmbSupplierr.Items.Insert(0, New RadComboBoxItem("All", 0))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAcc()
            cmbSupplierr.DataSource = dtP
            cmbSupplierr.DataTextField = "PartyAccount"
            cmbSupplierr.DataBind()
            cmbSupplierr.Items.Insert(0, New RadComboBoxItem("All", 0))
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccGSTORE()
            cmbSupplierr.DataSource = dtP
            cmbSupplierr.DataTextField = "PartyAccount"
            cmbSupplierr.DataBind()
            cmbSupplierr.Items.Insert(0, New RadComboBoxItem("All", 0))
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccForAuditor()
            cmbSupplierr.DataSource = dtP
            cmbSupplierr.DataTextField = "PartyAccount"
            cmbSupplierr.DataBind()
            cmbSupplierr.Items.Insert(0, New RadComboBoxItem("All", 0))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccForAuditor()
            cmbSupplierr.DataSource = dtP
            cmbSupplierr.DataTextField = "PartyAccount"
            cmbSupplierr.DataBind()
            cmbSupplierr.Items.Insert(0, New RadComboBoxItem("All", 0))
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            objSizeRange.temSRNOTbaleTruncateForPOSupplierFollowup()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                If CMBType.SelectedItem.Text = "Select" Then
                    Report.Load(Server.MapPath("..\Reports/SupplierFollowUpReport.rpt"))
                ElseIf CMBType.SelectedItem.Text = "Late" Then
                    Report.Load(Server.MapPath("..\Reports/SupplierFollowUpReport_Late.rpt"))
                ElseIf CMBType.SelectedItem.Text = "On Time" Then
                    Report.Load(Server.MapPath("..\Reports/SupplierFollowUpReport_OnTime.rpt"))
                ElseIf CMBType.SelectedItem.Text = "Early" Then
                    Report.Load(Server.MapPath("..\Reports/SupplierFollowUpReport_Early.rpt"))
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Else
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Supplier_Followup_Excel"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If cmbSeason.SelectedItem.Text = "Select" Then
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                    Report.SetParameterValue(3, 0)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                    Report.SetParameterValue(3, 0)
                End If
            Else
                If cmbSrNoo.Text = "All" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                        Report.SetParameterValue(3, 0)
                    Else
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                        Report.SetParameterValue(3, 0)
                    End If
                Else
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                .Save()
                            End With
                        Next
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                        Report.SetParameterValue(3, 1)
                    Else
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                .Save()
                            End With
                        Next
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(4, cmbSupplierr.SelectedItem.Text)
                        Report.SetParameterValue(3, 1)
                    End If
                End If
            End If
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
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcel.Click
        Try
            objSizeRange.temSRNOTbaleTruncateForPOSupplierFollowup()
            Dim FileName As String = ""
            If CMBType.SelectedItem.Text = "Select" Then
                objSizeRange.temSRNOTbaleTruncateForPO()
                Dim FileNamee As String = "Supplier_Followup_Excel"
                Dim spName As String = ""
                spName = "SP_SupplierFollowupStatusAstoreExcel"
                Dim SRNO As String
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            spName = ""
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    End If
                End If
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplyChainGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                FileName = "Supplier_Followup_Excel"
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                datee = ""
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Supplier_Followup_Excel.xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf CMBType.SelectedItem.Text = "Late" Then
                objSizeRange.temSRNOTbaleTruncateForPO()
                Dim FileNamee As String = "Supplier_Followup_Excel"
                Dim spName As String = ""
                spName = "SP_SupplierFollowupStatusAstoreExcel_Late"
                Dim SRNO As String
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            spName = ""
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    End If
                End If
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplyChainGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                FileName = "Supplier_Followup_Excel"
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                datee = ""
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Supplier_Followup_Excel.xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf CMBType.SelectedItem.Text = "On Time" Then
                objSizeRange.temSRNOTbaleTruncateForPO()
                Dim FileNamee As String = "Supplier_Followup_Excel"
                Dim spName As String = ""
                spName = "SP_SupplierFollowupStatusAstoreExcel_OnTime"
                Dim SRNO As String
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            spName = ""
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    End If
                End If
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplyChainGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                FileName = "Supplier_Followup_Excel"
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                datee = ""
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Supplier_Followup_Excel.xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf CMBType.SelectedItem.Text = "Early" Then
                objSizeRange.temSRNOTbaleTruncateForPO()
                Dim FileNamee As String = "Supplier_Followup_Excel"
                Dim spName As String = ""
                spName = "SP_SupplierFollowupStatusAstoreExcel_Early"
                Dim SRNO As String
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Joborderid = cmbSrNoo.CheckedItems(xx).Value
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            spName = ""
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbSupplierr.SelectedItem.Text, SRNO)
                        End If
                    End If
                End If
                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplyChainGenerated/"
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                FileName = "Supplier_Followup_Excel"
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                datee = ""
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Supplier_Followup_Excel.xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function getExcelSheetClick2(ByVal spName As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CheckDate As String, ByVal PartyAccount As String, ByVal SRNO As String)
        Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
        Dim objSqlConnection As New SqlConnection
        Dim sqlCmd As New SqlCommand
        objSqlConnection = New SqlConnection(strConnection)
        sqlCmd = New SqlCommand(spName, objSqlConnection)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.Add("@StartDate", StartDate)
        sqlCmd.Parameters.Add("@EndDate", EndDate)
        sqlCmd.Parameters.Add("@CheckDate", CheckDate)
        sqlCmd.Parameters.Add("@PartyAccount", PartyAccount)
        sqlCmd.Parameters.Add("@SRNO", SRNO)
        objSqlConnection.Open()
        sqlCmd.CommandTimeout = 600
        sqlCmd.ExecuteNonQuery()
        objSqlConnection.Close()
    End Function
End Class
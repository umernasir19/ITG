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
Public Class PurchaseOrderStatus
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim UserId As Long
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objSizeRange As New SizeRange
    Dim objTemSRNO As New TemPO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BindPO()
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
    Sub BindPO()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindPOForReport()
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "PONO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportNewForAcc()
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "PONO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportNewForGStore()
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "PONO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportNewForAccFoRAuditor()
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "PONO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("All", "0"))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportNewForAccFoRAuditor()
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "PONO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("All", "0"))
        End If
    End Sub
    Sub BindSupplier()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReport()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataTextField = "PartyAccount"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAcc()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataTextField = "PartyAccount"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccGSTORE()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataTextField = "PartyAccount"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccForAuditor()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataTextField = "PartyAccount"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForReportForAccForAuditor()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataTextField = "PartyAccount"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        End If
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            lblID.Text = dt.Rows(0)("IMSItemID")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            objSizeRange.temSRNOTbaleTruncateForPO()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatus.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusForACC.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusForGStore.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusAuditor.rpt"))
            Else
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusAuditor.rpt"))
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Purchase_Order_Status"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If cmbSeason.SelectedItem.Text = "Select" Then
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, cmbPONo.SelectedValue)
                    Report.SetParameterValue(4, lblID.Text)
                    Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                    Report.SetParameterValue(6, 0)
                    Report.SetParameterValue(7, 0)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, cmbPONo.SelectedValue)
                    Report.SetParameterValue(4, lblID.Text)
                    Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                    Report.SetParameterValue(6, 0)
                    Report.SetParameterValue(7, 0)
                End If
            Else
                If cmbSrNoo.Text = "All" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 0)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    Else
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 0)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    End If
                Else
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Save()
                            End With
                        Next
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 1)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    Else
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Save()
                            End With
                        Next
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 1)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
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
    Protected Sub btnSummaryReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSummaryReport.Click
        Try
            objSizeRange.temSRNOTbaleTruncateForPO()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusSummary.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusSummaryForACC.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusSummaryForGStore.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusSummaryAuditor.rpt"))
            Else
                Report.Load(Server.MapPath("..\Reports/PurchaseOrderStatusSummaryAuditor.rpt"))
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Purchase_Order_Status"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If cmbSeason.SelectedItem.Text = "Select" Then
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, cmbPONo.SelectedValue)
                    Report.SetParameterValue(4, lblID.Text)
                    Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                    Report.SetParameterValue(6, 0)
                    Report.SetParameterValue(7, 0)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, cmbPONo.SelectedValue)
                    Report.SetParameterValue(4, lblID.Text)
                    Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                    Report.SetParameterValue(6, 0)
                    Report.SetParameterValue(7, 0)
                End If
            Else
                If cmbSrNoo.Text = "All" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 0)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    Else
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 0)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    End If
                Else
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Save()
                            End With
                        Next
                        CheckDate = 1
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 1)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
                    Else
                        Dim xx As Integer
                        For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                            With objTemSRNO
                                .ID = 0
                                .No = cmbSrNoo.CheckedItems(xx).Text
                                .Save()
                            End With
                        Next
                        CheckDate = 0
                        Report.SetParameterValue(0, Date.Now)
                        Report.SetParameterValue(1, Date.Now)
                        Report.SetParameterValue(2, CheckDate)
                        Report.SetParameterValue(3, cmbPONo.SelectedValue)
                        Report.SetParameterValue(4, lblID.Text)
                        Report.SetParameterValue(5, cmbSupplier.SelectedItem.Text)
                        Report.SetParameterValue(6, 1)
                        Report.SetParameterValue(7, cmbSeason.SelectedValue)
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
            objSizeRange.temSRNOTbaleTruncateForPO()
            Dim FileName As String = "Purchase_Order_Status"
            Dim SRNO As String
            Dim SeasonDatabaseId As Long
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
            Else
                CheckDate = 0
            End If
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim spName As String = ""
                spName = "SP_PurchaseOrderStatusNewEXCEL"
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Order_Status-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Dim spName As String = ""
                spName = "SP_PurchaseOrderStatusNewACCEXCEL"
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Order_Status-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Dim spName As String = ""
                spName = "SP_PurchaseOrderStatusNewAuditorEXCEL"
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Order_Status-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            Else
                Dim spName As String = ""
                spName = "SP_PurchaseOrderStatusNewAuditorEXCEL"
                If cmbSeason.SelectedItem.Text = "Select" Then
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        CheckDate = 1
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    Else
                        CheckDate = 0
                        SRNO = 0
                        SeasonDatabaseId = 0
                        getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                    End If
                Else
                    If cmbSrNoo.Text = "All" Then
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            CheckDate = 1
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            CheckDate = 0
                            SRNO = 0
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        End If
                    Else
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 1
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
                        Else
                            Dim xx As Integer
                            For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                                With objTemSRNO
                                    .ID = 0
                                    .No = cmbSrNoo.CheckedItems(xx).Text
                                    .Save()
                                End With
                            Next
                            CheckDate = 0
                            SRNO = 1
                            SeasonDatabaseId = cmbSeason.SelectedValue
                            getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, cmbPONo.SelectedValue, lblID.Text, cmbSupplier.SelectedItem.Text, SRNO, SeasonDatabaseId)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Order_Status-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function getExcelSheetClick2(ByVal spName As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CheckDate As String, ByVal POID As Long, ByVal IMSItemID As Long, ByVal PartyAccount As String, ByVal SRNO As String, ByVal SeasonDatabaseId As Long)
        Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
        Dim objSqlConnection As New SqlConnection
        Dim sqlCmd As New SqlCommand
        objSqlConnection = New SqlConnection(strConnection)
        sqlCmd = New SqlCommand(spName, objSqlConnection)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.Add("@StartDate", StartDate)
        sqlCmd.Parameters.Add("@EndDate", EndDate)
        sqlCmd.Parameters.Add("@CheckDate", CheckDate)
        sqlCmd.Parameters.Add("@POID", POID)
        sqlCmd.Parameters.Add("@ItemId", IMSItemID)
        sqlCmd.Parameters.Add("@PartyAccount", PartyAccount)
        sqlCmd.Parameters.Add("@SRNo", SRNO)
        sqlCmd.Parameters.Add("@SeasonDatabaseId", SeasonDatabaseId)
        objSqlConnection.Open()
        sqlCmd.CommandTimeout = 600
        sqlCmd.ExecuteNonQuery()
        objSqlConnection.Close()
    End Function
End Class
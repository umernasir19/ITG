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
Public Class GoodRecvNote
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim ObjGeneralCode As GeneralCode
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim userid As Long
    Dim ObjIssue As New IssueMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindInvoiceNo()
            BindSupplier()
            BindSeason()
            BindSrNo()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
        End If
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssueForStoreReportForGoogRecvNote()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReport()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForStoreReportForGoodRecvNote(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtt
            cmbSrNo.DataValueField = "JobOrderId"
            cmbSrNo.DataTextField = "SrNo"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            lblID.Text = dt.Rows(0)("IMSItemID")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindInvoiceNo()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportForfabric()
            cmbInvoiceNo.DataSource = dtP
            cmbInvoiceNo.DataTextField = "GatePassNo"
            cmbInvoiceNo.DataValueField = "PORecvMasterID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportForAcc()
            cmbInvoiceNo.DataSource = dtP
            cmbInvoiceNo.DataTextField = "GatePassNo"
            cmbInvoiceNo.DataValueField = "PORecvMasterID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportForAuditor()
            cmbInvoiceNo.DataSource = dtP
            cmbInvoiceNo.DataTextField = "GatePassNo"
            cmbInvoiceNo.DataValueField = "PORecvMasterID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportForAccGStore()
            cmbInvoiceNo.DataSource = dtP
            cmbInvoiceNo.DataTextField = "GatePassNo"
            cmbInvoiceNo.DataValueField = "PORecvMasterID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New ListItem("All", "0"))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindInvoiceNoForReportForAuditor()
            cmbInvoiceNo.DataSource = dtP
            cmbInvoiceNo.DataTextField = "GatePassNo"
            cmbInvoiceNo.DataValueField = "PORecvMasterID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New ListItem("All", "0"))
        End If
    End Sub
    Sub BindSupplier()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForGoodRecvNoteReport()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataTextField = "SUPPLIERnAME"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForGoodRecvNoteReportForAcc()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataTextField = "SUPPLIERnAME"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForGoodRecvNoteReportForAccGStore()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataTextField = "SUPPLIERnAME"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))

        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForGoodRecvNoteReportForAuditor()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataTextField = "SUPPLIERnAME"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindSupplierForGoodRecvNoteReportForAuditor()
            cmbSupplier.DataSource = dtP
            cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataTextField = "SUPPLIERnAME"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("All", "0"))
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Report.Load(Server.MapPath("..\Reports/GoodRecvNoteRpt.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Report.Load(Server.MapPath("..\Reports/GoodRecvNoteRptForAcc.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Report.Load(Server.MapPath("..\Reports/GoodRecvNoteRptForGStore.rpt"))
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Report.Load(Server.MapPath("..\Reports/GoodRecvNoteRptForAuditor.rpt"))
            Else
                Report.Load(Server.MapPath("..\Reports/GoodRecvNoteRptForAuditor.rpt"))
            End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Good_Receiving_Note"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                Report.SetParameterValue(1, txtDateTo.SelectedDate)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbSupplier.SelectedValue)
                Report.SetParameterValue(5, cmbInvoiceNo.SelectedValue)
                Report.SetParameterValue(6, cmbSrNo.SelectedValue)
            Else
                CheckDate = 0
                Report.SetParameterValue(0, Date.Now)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbSupplier.SelectedValue)
                Report.SetParameterValue(5, cmbInvoiceNo.SelectedValue)
                Report.SetParameterValue(6, cmbSrNo.SelectedValue)
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
            Dim FileName As String = "GRN_Excel"

            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
            Else
                CheckDate = 0
            End If
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim spName As String = ""
                spName = "sp_GRNFstoreEXCEL"
                getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, lblID.Text, cmbSupplier.SelectedValue, cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Good_Receiving_Note-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
                 
                 
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Dim spName As String = ""
                Dim FileNamee As String = "Good_Receiving_Note"
                spName = "sp_GRNAstoreEXCEL"
                getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, lblID.Text, cmbSupplier.SelectedValue, cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Good_Receiving_Note-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()


            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Dim spName As String = ""
                Dim FileNamee As String = "Good_Receiving_Note"
                spName = "sp_GRNAUDstoreEXCEL"
                getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, lblID.Text, cmbSupplier.SelectedValue, cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Good_Receiving_Note-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            Else
                Dim spName As String = ""
                Dim FileNamee As String = "Good_Receiving_Note"
                spName = "sp_GRNAUDstoreEXCEL"
                getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, lblID.Text, cmbSupplier.SelectedValue, cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Good_Receiving_Note-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function getExcelSheetClick2(ByVal spName As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CheckDate As String, ByVal IMSItemID As Long, ByVal SupplierID As Long, ByVal PORecvMasterID As Long, ByVal JobOrderId As Long)
        Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
        Dim objSqlConnection As New SqlConnection
        Dim sqlCmd As New SqlCommand
        objSqlConnection = New SqlConnection(strConnection)
        sqlCmd = New SqlCommand(spName, objSqlConnection)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.Add("@StartDate", StartDate)
        sqlCmd.Parameters.Add("@EndDate", EndDate)
        sqlCmd.Parameters.Add("@CheckDate", CheckDate)
        sqlCmd.Parameters.Add("@ItemId", IMSItemID)
        sqlCmd.Parameters.Add("@SupplierId", SupplierID)
        sqlCmd.Parameters.Add("@PORecvMasterID", PORecvMasterID)
        sqlCmd.Parameters.Add("@JobOrderId", JobOrderId)
        objSqlConnection.Open()
        sqlCmd.CommandTimeout = 600
        sqlCmd.ExecuteNonQuery()
        objSqlConnection.Close()
    End Function
End Class
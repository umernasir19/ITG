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
Public Class PurchaseRegister
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim ObjGeneralCode As GeneralCode
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim objPOMaster As New POMaster
    Dim dtSession As DataTable
    Dim Dr As DataRow
    Dim UserId As Long
    Dim objTempPurchaseRegisterClass As New TempPurchaseRegisterClass
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim ObjIssue As New IssueMst
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BindGrnno()
            BindSeason()
            BindSrNo()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
            PageHeader("Purchase Register Report")
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
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindGrnno()
        Try
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dtJobNo As DataTable
                dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchase()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
                cmbGRNNo.DataValueField = "PORecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Dim dtJobNo As DataTable
                dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchaseForAcc()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
                cmbGRNNo.DataValueField = "PORecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))

            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Dim dtJobNo As DataTable
                dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchaseForGStore()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
                cmbGRNNo.DataValueField = "PORecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))

            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                Dim dtJobNo As DataTable
                dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchaseForAuditor()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
                cmbGRNNo.DataValueField = "PORecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))
            Else
                Dim dtJobNo As DataTable
                dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchaseForAuditor()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
                cmbGRNNo.DataValueField = "PORecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))
            End If
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
    Sub SaveSession()
        Session("dtSession") = Nothing
        objTempStockInventory.TruncateTempTablePurchaseRegister()
        Dim Date22 As Date = txtDateFrom.SelectedDate
        Dim date33 As Date = txtDateTo.SelectedDate
        Dim Est As String = Date22.ToString("MM/dd/yyyy")
        Dim Endd As String = date33.ToString("MM/dd/yyyy")
        Dim dt As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportNew(Est, Endd)
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportForAccNew(Est, Endd)
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportForAccNewGStore(Est, Endd)
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportForAuditorNew(Est, Endd)
        Else
            dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportForAuditorNew(Est, Endd)
        End If
        If (Not CType(Session("dtSession"), DataTable) Is Nothing) Then
            dtSession = Session("dtSession")
        Else
            dtSession = New DataTable
            With dtSession
                .Columns.Add("ID", GetType(String))
                .Columns.Add("GRNNo", GetType(String))
                .Columns.Add("PORecvDate", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("SupplierName", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("LastPurchaseDate", GetType(String))
                .Columns.Add("LastPurchaseRate", GetType(String))
                .Columns.Add("SecondLastPurchaseDate", GetType(String))
                .Columns.Add("SecondLastPurchaseRate", GetType(String))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("PORecvMasterID", GetType(String))
                .Columns.Add("JobOrderId", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dt.Rows.Count - 1
            Dr = dtSession.NewRow()
            Dr("ID") = 0
            Dr("ItemID") = dt.Rows(x)("ItemID")
            Dr("PORecvMasterID") = dt.Rows(x)("PORecvMasterID")
            Dr("GRNNo") = dt.Rows(x)("GatePassNo")
            Dr("PORecvDate") = dt.Rows(x)("PORecvDate")
            Dr("ItemCodee") = dt.Rows(x)("ItemCodee")
            Dr("ItemName") = dt.Rows(x)("ItemName")
            Dr("SupplierName") = dt.Rows(x)("SupplierName")
            Dr("Qty") = dt.Rows(x)("RecvQty")
            Dr("Rate") = dt.Rows(x)("RecvRate") * dt.Rows(x)("ExchangeRate")
            Dr("JobOrderId") = dt.Rows(x)("JobOrderId")
            Dim date1 As Date = dt.Rows(x)("PoRecvDate")
            Dim Estdatee As String = date1.ToString("dd/MM/yyyy")
            Dim LastPurchase As DataTable = objDPPoRecevMst.GetLastPurchase(dt.Rows(x)("ItemId"), Estdatee)
            If LastPurchase.Rows.Count > 1 Then
                Dr("LastPurchaseRate") = LastPurchase.Rows(0)("LastPurchaseRate")
                Dr("LastPurchaseDate") = LastPurchase.Rows(0)("LastPurchaseDate")
                Dr("SecondLastPurchaseRate") = LastPurchase.Rows(1)("LastPurchaseRate")
                Dr("SecondLastPurchaseDate") = LastPurchase.Rows(1)("LastPurchaseDate")
            ElseIf LastPurchase.Rows.Count = 0 Then
                Dr("LastPurchaseRate") = 0
                Dr("LastPurchaseDate") = ""
                Dr("SecondLastPurchaseRate") = 0
                Dr("SecondLastPurchaseDate") = ""
            Else
                Dim date2 As Date = dt.Rows(x)("PoRecvDate")
                Dim Estdateee As String = date2.ToString("dd/MM/yyyy")
                Dim SecondLastPurchase As DataTable = objDPPoRecevMst.GetLastPurchase(dt.Rows(x)("ItemId"), Estdateee)
                Dr("LastPurchaseRate") = SecondLastPurchase.Rows(0)("LastPurchaseRate")
                Dr("LastPurchaseDate") = SecondLastPurchase.Rows(0)("LastPurchaseDate")
                Dr("SecondLastPurchaseRate") = 0
                Dr("SecondLastPurchaseDate") = ""
            End If
            dtSession.Rows.Add(Dr)
        Next
        Session("dtSession") = dtSession
        With objTempPurchaseRegisterClass
            Dim z As Integer
            For z = 0 To dtSession.Rows.Count - 1
                .ID = 0
                .GRNNo = dtSession.Rows(z)("GRNNo")
                .PORecvDate = dtSession.Rows(z)("PORecvDate")
                .ItemCodee = dtSession.Rows(z)("ItemCodee")
                .ItemName = dtSession.Rows(z)("ItemName")
                .SupplierName = dtSession.Rows(z)("SupplierName")
                .Qty = dtSession.Rows(z)("Qty")
                .Rate = dtSession.Rows(z)("Rate")
                .LastPurchaseDate = dtSession.Rows(z)("LastPurchaseDate")
                .LastPurchaseRate = dtSession.Rows(z)("LastPurchaseRate")
                .SecondLastPurchaseDate = dtSession.Rows(z)("SecondLastPurchaseDate")
                .SecondLastPurchaseRate = dtSession.Rows(z)("SecondLastPurchaseRate")
                .ItemID = dtSession.Rows(z)("ItemID")
                .PORecvMasterID = dtSession.Rows(z)("PORecvMasterID")
                .JoborderId = dtSession.Rows(z)("JobOrderId")
                .Save()
            Next
        End With
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                SaveSession()
                Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForPurchase.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PurchaseRegister"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                CheckDate = 1
                Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                Report.SetParameterValue(1, txtDateTo.SelectedDate)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(5, cmbSrNo.SelectedValue)
                Report.SetParameterValue(6, txtDateFrom.SelectedDate)
                Report.SetParameterValue(7, txtDateTo.SelectedDate)
                Report.SetParameterValue(8, CheckDate)
                Report.SetParameterValue(9, lblID.Text)
                Report.SetParameterValue(10, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(11, cmbSrNo.SelectedValue)
                Report.SetParameterValue(12, txtDateFrom.SelectedDate)
                Report.SetParameterValue(13, txtDateTo.SelectedDate)
                Report.SetParameterValue(14, CheckDate)
                Report.SetParameterValue(15, lblID.Text)
                Report.SetParameterValue(16, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(17, cmbSrNo.SelectedValue)
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
            Else
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Report.Load(Server.MapPath("..\Reports/PurchaseRegister.rpt"))
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForAcc.rpt"))
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForAuditor.rpt"))
                Else
                    Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForAuditor.rpt"))
                End If
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "PurchaseRegister"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                CheckDate = 0
                Report.SetParameterValue(0, Date.Now)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(5, cmbSrNo.SelectedValue)
                Report.SetParameterValue(6, Date.Now)
                Report.SetParameterValue(7, Date.Now)
                Report.SetParameterValue(8, CheckDate)
                Report.SetParameterValue(9, lblID.Text)
                Report.SetParameterValue(10, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(11, cmbSrNo.SelectedValue)
                Report.SetParameterValue(12, Date.Now)
                Report.SetParameterValue(13, Date.Now)
                Report.SetParameterValue(14, CheckDate)
                Report.SetParameterValue(15, lblID.Text)
                Report.SetParameterValue(16, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(17, cmbSrNo.SelectedValue)
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
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcel.Click
        Try
            Dim FileName As String = ""
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                SaveSession()
                Dim FileNamee As String = "Purchase_Register"
                Dim spName As String = ""
                spName = "SP_EXCELPurchaseRegisterWithDate"
                getExcelSheetClick2(spName, txtDateFrom.SelectedDate, txtDateTo.SelectedDate, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                FileName = "Purchase_Register_Excel_With_Date"
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            Else
                CheckDate = 0
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim FileNamee As String = "Purchase_Register"
                    Dim spName As String = ""
                    spName = "sp_PurchaseRegisterFstoreEXCEL"
                    getExcelSheetClick2(spName, Date.Now, Date.Now, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                    FileName = "Purchase_Register_Excel"
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
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim spName As String = ""
                    Dim FileNamee As String = "Purchase_Register"
                    spName = "sp_PurchaseRegisterAstoreEXCEL"
                    getExcelSheetClick2(spName, Date.Now, Date.Now, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                    FileName = "Purchase_Register_Excel"
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
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim spName As String = ""
                    Dim FileNamee As String = "Purchase_Register"
                    spName = "sp_PurchaseRegisterGstoreEXCEL"
                    getExcelSheetClick2(spName, Date.Now, Date.Now, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                    FileName = "Purchase_Register_Excel"
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
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim spName As String = ""
                    Dim FileNamee As String = "Purchase_Register"
                    spName = "sp_PurchaseRegisterAuditorstoreEXCEL"
                    getExcelSheetClick2(spName, Date.Now, Date.Now, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                    FileName = "Purchase_Register_Excel"
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
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                Else
                    Dim spName As String = ""
                    Dim FileNamee As String = "Purchase_Register"
                    spName = "sp_PurchaseRegisterAuditorstoreEXCEL"
                    getExcelSheetClick2(spName, Date.Now, Date.Now, CheckDate, lblID.Text, cmbGRNNo.SelectedValue, cmbSrNo.SelectedValue)
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
                    FileName = "Purchase_Register_Excel"
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
                    Response.AppendHeader("Content-Disposition", "attachment; filename=""Purchase_Register-" + datee + ".xls")
                    Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                    Response.End()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function getExcelSheetClick2(ByVal spName As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CheckDate As String, ByVal IMSItemID As Long, ByVal PORecvMasterID As Long, ByVal JobOrderId As Long)
        Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
        Dim objSqlConnection As New SqlConnection
        Dim sqlCmd As New SqlCommand
        objSqlConnection = New SqlConnection(strConnection)
        sqlCmd = New SqlCommand(spName, objSqlConnection)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.Add("@StartDate", StartDate)
        sqlCmd.Parameters.Add("@EndDate", EndDate)
        sqlCmd.Parameters.Add("@CheckDate", CheckDate)
        sqlCmd.Parameters.Add("@IMSITemID", IMSItemID)
        sqlCmd.Parameters.Add("@PORecvMasterID", PORecvMasterID)
        sqlCmd.Parameters.Add("@JobOrderId", JobOrderId)
        objSqlConnection.Open()
        sqlCmd.CommandTimeout = 600
        sqlCmd.ExecuteNonQuery()
        objSqlConnection.Close()
    End Function
End Class

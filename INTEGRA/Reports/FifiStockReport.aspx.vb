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
Public Class FifiStockReport
    Inherits System.Web.UI.Page
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim Dr As DataRow
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim dtAC As DataTable
    Dim obGeneralCode As New GeneralCode
    Dim YearFirst, YearSecond As String
    Dim AccountCode As String
    Dim openDate As String
    Dim OpeningBalance As Decimal
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindLocation()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
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
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try 
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            If (dt.Rows(0)("itemCodee").ToString().Substring(0, 2).Equals("PF")) Then
                DownLoadReportForprocess()
            Else
                DownLoadReport()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub DownLoadReportForprocess()
        Dim dt As DataTable
        dt = objPOMaster.GetItemFabricNewNewNew(TXTCodeEntry.Text)
        If dt.Rows.Count > 0 Then
            If cmbGodown.SelectedItem.Text = "All" Then
                AccountCode = lblID.Text
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForProcessNewwwPROCESS(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewToProcesses(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, 0)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForProcessPorcesssss(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForProcessForProcess(lblID.Text)
                Else
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForprocess(lblID.Text, cmbGodown.SelectedValue)
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForProcess(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
        Else
            If cmbGodown.SelectedItem.Text = "All" Then
                AccountCode = lblID.Text
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForProcess(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewToProcesses(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForProcessNewToProcess(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, 0)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForProcess(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForProcessForProcess(lblID.Text)
                Else
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForprocess(lblID.Text, cmbGodown.SelectedValue)
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForProcess(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
    End Sub
    Sub BindLocation()
        Try
            Dim dt As DataTable
            dt = objPORecvMaster.BindLocation()
            cmbGodown.DataSource = dt
            cmbGodown.DataTextField = "Location"
            cmbGodown.DataValueField = "LocationId"
            cmbGodown.DataBind()
            cmbGodown.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub GetDataForStockLedgerNew()
        objTempStockInventory.TruncateTempInventoryNew()
        objTempStockInventory.InsertTempStockInventoryReceive(lblID.Text)
        objTempStockInventory.TruncateTempInventoryFinal()
        Dim dt As DataTable = objTempStockInventory.GETRecvData()
    End Sub
    Sub DownLoadReport()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
        If cmbGodown.SelectedItem.Text = "All" Then
            AccountCode = lblID.Text
            objTempStockInventory.TruncateTempInventoryNew()
            objTempStockInventory.InsertTempStockInventoryReceive(lblID.Text)
            objTempStockInventory.InsertTempStockInventoryIssueNewTo(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, cmbGodown.SelectedValue)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWise(lblID.Text)
                    objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                Else
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWise(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()

                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            If cmbGodown.SelectedItem.Text = "All" Then
                AccountCode = lblID.Text
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceive(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewTo(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigitalAStore.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, 0)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "main store 1" Then
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWise(lblID.Text)
                    objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                Else
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWise(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()

                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If

                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigitalAStore.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
    End Sub
    Sub DownLoadReportForFabric()
        Dim dt As DataTable
        dt = objPOMaster.GetItemFabricNewNewNew(TXTCodeEntry.Text)
        If dt.Rows.Count > 0 Then
            If cmbGodown.SelectedItem.Text = "All" Then
                AccountCode = lblID.Text
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForProcessForFabric(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryReceiveForProcessForFabricIssue(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, 0)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForProcess(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                Else
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForProcess(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim OpCre As Decimal = 0
                Dim OpDbt As Decimal = 0
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()

                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If

                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
        Else
            If cmbGodown.SelectedItem.Text = "All" Then
                AccountCode = lblID.Text
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceive(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewTo(lblID.Text)
                objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("MM/dd/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0 'dt2.Rows(x)("IssueQuantity") + dt4.Rows(x)("IssueQuantity")
                Dim OpDbt As Decimal = 0 'dt1.Rows(x)("RecvQuantity") + dt3.Rows(x)("RecvQuantity")
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("MM/dd/yyyy")
                Dim Enddatee As String = date3.ToString("MM/dd/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNew(OpeningBalance, Estdatee, Enddatee)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()
                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2(OpeningBalance)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, 0)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
                AccountCode = lblID.Text
                Dim lOCATIONid As Long = cmbGodown.SelectedValue
                objTempStockInventory.TruncateTempInventoryNew()
                objTempStockInventory.InsertTempStockInventoryReceiveForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWise(lblID.Text)
                    objTempStockInventory.InsertTempStockInventoryIssueNewToReturnNew(lblID.Text)
                Else
                    objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                End If
                objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWise(lblID.Text, cmbGodown.SelectedValue)
                objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWise(lblID.Text, cmbGodown.SelectedValue)
                Dim x As Integer
                Dim OBJDATE As New GeneralCode
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt1 As DataTable = objTempStockInventory.GetDataForOpening(lblID.Text, SDate)
                Dim dt2 As DataTable = objTempStockInventory.GetDataForOpeningTwo(lblID.Text, SDate)
                Dim dt3 As DataTable = objTempStockInventory.GetDataForOpeningThree(lblID.Text, SDate)
                Dim dt4 As DataTable = objTempStockInventory.GetDataForOpeningFour(lblID.Text, SDate)
                Dim OpCre As Decimal = 0 'dt2.Rows(x)("IssueQuantity") + dt4.Rows(x)("IssueQuantity")
                Dim OpDbt As Decimal = 0 'dt1.Rows(x)("RecvQuantity") + dt3.Rows(x)("RecvQuantity")
                If OpCre = 0 And OpDbt = 0 Then
                    OpeningBalance = OpCre
                ElseIf OpCre > 0 And OpDbt = 0 Then
                    OpeningBalance = -OpCre
                ElseIf OpDbt > 0 And OpCre = 0 Then
                    OpeningBalance = OpDbt
                ElseIf OpDbt > OpCre Then
                    OpeningBalance = OpDbt - OpCre
                ElseIf OpCre > OpDbt Then
                    OpeningBalance = OpDbt - OpCre
                End If
                Dim Date2 As Date = txtDateFrom.SelectedDate
                Dim date3 As Date = txtDateTo.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                objTempStockInventory.TruncateTempInventoryFinal()
                objTempStockInventory.InsertTempLedgerIntoTempFinal()
                Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocation(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                Dim Prevoiusbalance As Decimal = 0
                If objDataTablepre.Rows.Count > 0 Then
                    Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                End If
                Dim dtchk As DataTable
                dtchk = objTempStockInventory.CheckInsertdata()

                Dim dtonlyVoucher As DataTable
                If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                    dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocation(OpeningBalance, cmbGodown.SelectedValue)
                    Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                End If
                Dim DescEntry As String = ""
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim FileName As String
                Report.Load(Server.MapPath("~/Reports/LedgerReportForDigital.rpt"))
                FileName = "Item_Ledger"
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim StatDate As Date = txtDateFrom.SelectedDate
                Dim EndDate As Date = txtDateTo.SelectedDate
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, TXTCodeEntry.Text)
                Report.SetParameterValue(1, StatDate)
                Report.SetParameterValue(2, EndDate)
                Report.SetParameterValue(3, OpeningBalance)
                Report.SetParameterValue(4, openDate)
                Report.SetParameterValue(5, Prevoiusbalance)
                Report.SetParameterValue(6, lOCATIONid)
                Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
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
    End Sub
End Class
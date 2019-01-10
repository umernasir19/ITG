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
Public Class ItemInvetoryReportForFStore
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim dtAC As DataTable
    Dim obGeneralCode As New GeneralCode
    Dim YearFirst, YearSecond As String
    Dim AccountCode As String
    Dim openDate As String
    Dim OpeningBalance As Decimal
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BindLocation()
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
            cmbGodown.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            DownLoadReport()
        Catch ex As Exception
        End Try
    End Sub
    Sub DownLoadReport()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            If cmbGodown.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If lblID.Text = 0 Then
                    AccountCode = lblID.Text
                    Dim lOCATIONid As Long = cmbGodown.SelectedValue
                    objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
                    objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCase(cmbGodown.SelectedValue)
                    If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCase()
                    Else
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCase(cmbGodown.SelectedValue)
                    End If
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCase(cmbGodown.SelectedValue)
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCase(cmbGodown.SelectedValue)
                    Dim x As Integer
                    Dim OBJDATE As New GeneralCode
                    Dim Date1 As Date = "01/03/2015"
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
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDateTo.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    objTempStockInventory.TruncateTempItemInventoryFinal()
                    objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
                    Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                    Dim Prevoiusbalance As Decimal = 0
                    If objDataTablepre.Rows.Count > 0 Then
                        Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                    End If
                    Dim dtchk As DataTable
                    dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

                    Dim dtonlyVoucher As DataTable
                    If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                        dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
                        Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                    End If
                    Dim DescEntry As String = ""
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If ckhWithoutZeroQty.Checked = True Then
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCaseForZero.rpt"))
                    Else
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCase.rpt"))
                    End If
                    FileName = "Item_Inventory_Report"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StatDate As Date = "01/03/2015"
                    Dim EndDate As Date = txtDateTo.SelectedDate
                    Dim ReportName As String = "FABRIC INVENTORY"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, txtFabricCode.Text)
                    Report.SetParameterValue(1, OpeningBalance)
                    Report.SetParameterValue(2, StatDate)
                    Report.SetParameterValue(3, EndDate)
                    Report.SetParameterValue(4, openDate)
                    Report.SetParameterValue(5, Prevoiusbalance)
                    Report.SetParameterValue(6, lOCATIONid)
                    Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
                    Report.SetParameterValue(8, ReportName)
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
                    objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
                    objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
                    If cmbGodown.SelectedItem.Text = "DAL-2 MAIN F.STORE" Then
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForCategoryWise(lblID.Text)
                    Else
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
                    End If
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForCategorywise(lblID.Text, cmbGodown.SelectedValue)
                    Dim x As Integer
                    Dim OBJDATE As New GeneralCode
                    Dim Date1 As Date = "01/03/2015"
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
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDateTo.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    objTempStockInventory.TruncateTempItemInventoryFinal()
                    objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
                    Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                    Dim Prevoiusbalance As Decimal = 0
                    If objDataTablepre.Rows.Count > 0 Then
                        Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                    End If
                    Dim dtchk As DataTable
                    dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

                    Dim dtonlyVoucher As DataTable
                    If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                        dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
                        Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                    End If
                    Dim DescEntry As String = ""
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If ckhWithoutZeroQty.Checked = True Then
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCaseForZero.rpt"))
                    Else
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCase.rpt"))
                    End If
                    FileName = "Item_Inventory_Report"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StatDate As Date = "01/03/2015"
                    Dim EndDate As Date = txtDateTo.SelectedDate
                    Dim ReportName As String = "FABRIC INVENTORY"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, txtFabricCode.Text)
                    Report.SetParameterValue(1, OpeningBalance)
                    Report.SetParameterValue(2, StatDate)
                    Report.SetParameterValue(3, EndDate)
                    Report.SetParameterValue(4, openDate)
                    Report.SetParameterValue(5, Prevoiusbalance)
                    Report.SetParameterValue(6, lOCATIONid)
                    Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
                    Report.SetParameterValue(8, ReportName)
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
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            If cmbGodown.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If lblID.Text = 0 Then
                    AccountCode = lblID.Text
                    Dim lOCATIONid As Long = cmbGodown.SelectedValue
                    objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
                    objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseForAcc(cmbGodown.SelectedValue)
                    If cmbGodown.SelectedItem.Text = "main store 1" Then
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCaseForACC()
                    Else
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCaseForAcc(cmbGodown.SelectedValue)
                    End If
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCase(cmbGodown.SelectedValue)
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCase(cmbGodown.SelectedValue)
                    Dim x As Integer
                    Dim OBJDATE As New GeneralCode
                    Dim Date1 As Date = "01/03/2015"
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
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDateTo.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    objTempStockInventory.TruncateTempItemInventoryFinal()
                    objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
                    Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                    Dim Prevoiusbalance As Decimal = 0
                    If objDataTablepre.Rows.Count > 0 Then
                        Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                    End If
                    Dim dtchk As DataTable
                    dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

                    Dim dtonlyVoucher As DataTable
                    If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                        dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
                        Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                    End If
                    Dim DescEntry As String = ""
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If ckhWithoutZeroQty.Checked = True Then
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCaseForAstoreForZero.rpt"))
                    Else
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCaseForAstore.rpt"))
                    End If
                    FileName = "Item_Inventory_Report"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StatDate As Date = "01/03/2015"
                    Dim EndDate As Date = txtDateTo.SelectedDate
                    Dim ReportName As String = "ITEM INVENTORY"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, txtFabricCode.Text)
                    Report.SetParameterValue(1, OpeningBalance)
                    Report.SetParameterValue(2, StatDate)
                    Report.SetParameterValue(3, EndDate)
                    Report.SetParameterValue(4, openDate)
                    Report.SetParameterValue(5, Prevoiusbalance)
                    Report.SetParameterValue(6, lOCATIONid)
                    Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
                    Report.SetParameterValue(8, ReportName)
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
                    objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
                    objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAccForCATEGORYWISE(lblID.Text, cmbGodown.SelectedValue)
                    If cmbGodown.SelectedItem.Text = "main store 1" Then
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAccForCategorywise(lblID.Text)
                    Else
                        objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
                    End If
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
                    objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForCategorywise(lblID.Text, cmbGodown.SelectedValue)
                    Dim x As Integer
                    Dim OBJDATE As New GeneralCode
                    Dim Date1 As Date = "01/03/2018"
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
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDateTo.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    objTempStockInventory.TruncateTempItemInventoryFinal()
                    objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
                    Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
                    Dim Prevoiusbalance As Decimal = 0
                    If objDataTablepre.Rows.Count > 0 Then
                        Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
                    End If
                    Dim dtchk As DataTable
                    dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

                    Dim dtonlyVoucher As DataTable
                    If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                        dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
                        Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
                    End If
                    Dim DescEntry As String = ""
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If ckhWithoutZeroQty.Checked = True Then
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCaseForAstoreForZero.rpt"))
                    Else
                        Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCaseForAstore.rpt"))
                    End If
                    FileName = "Item_Inventory_Report"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StatDate As Date = "01/03/2015"
                    Dim EndDate As Date = txtDateTo.SelectedDate
                    Dim ReportName As String = "ITEM INVENTORY"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, txtFabricCode.Text)
                    Report.SetParameterValue(1, OpeningBalance)
                    Report.SetParameterValue(2, StatDate)
                    Report.SetParameterValue(3, EndDate)
                    Report.SetParameterValue(4, openDate)
                    Report.SetParameterValue(5, Prevoiusbalance)
                    Report.SetParameterValue(6, lOCATIONid)
                    Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
                    Report.SetParameterValue(8, ReportName)
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
        End If
    End Sub
    Protected Sub txtFabricCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFabricCode.TextChanged
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNewItemCategory(txtFabricCode.Text)
            lblID.Text = dt.Rows(0)("IMSItemCategoryID")
        Catch ex As Exception
        End Try
    End Sub
End Class
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
Public Class StoreIssueReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim ObjGeneralCode As GeneralCode
    Dim objPORecvMaster As New PORecvMaster
    Dim objPOMaster As New POMaster
    Dim userid As Long
    Dim ObjIssue As New IssueMst
    Dim objTempStockInventory As New TempStockInventoryFinal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindManualChallanNo()
            BindSeason()
            BindSrNo()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
            BindLocation()
        End If
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssueForStoreReport()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAnyForStoreIssueReport()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForStoreReport(cmbSeason.SelectedValue)
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
    Sub BindManualChallanNo()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabric()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
            cmbManualChallanNo.DataValueField = "IssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabricForAcc()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
            cmbManualChallanNo.DataValueField = "IssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabricForAccGStore()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
            cmbManualChallanNo.DataValueField = "IssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabricForAll()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
            cmbManualChallanNo.DataValueField = "IssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
        Else
            Dim dtP As DataTable = objPORecvMaster.BindManualChallanNoForReportForfabricForAll()
            cmbManualChallanNo.DataSource = dtP
            cmbManualChallanNo.DataTextField = "ManualChallanNo"
            cmbManualChallanNo.DataValueField = "IssueID"
            cmbManualChallanNo.DataBind()
            cmbManualChallanNo.Items.Insert(0, New ListItem("All", "0"))
        End If
    End Sub
    Sub BindLocation()
        Try
            Dim dt As DataTable
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dt = ObjIssue.BindDeptFabNew()
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    dt = ObjIssue.BindDeptFabNew()
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    dt = ObjIssue.BindDeptFabNew()
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    dt = ObjIssue.BindDeptFabNew()
                End If
            End If
            cmbDepartment.DataSource = dt
            cmbDepartment.DataValueField = "DeptDatabaseID"
            cmbDepartment.DataTextField = "DeptDatabaseName"
            cmbDepartment.DataBind()
            cmbDepartment.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
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
                Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifo.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Store_Issue_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
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
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                If lblID.Text = "" Then
                    GetData()
                    Report.Load(Server.MapPath("..\Reports/StoreissueAstoreReportNew.rpt"))
                    'Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifoForAcc.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Store_Issue_Report"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Else
                        CheckDate = 0
                        Report.SetParameterValue(0, "01/01/1900")
                        Report.SetParameterValue(1, "01/01/1900")
                    End If
                    'If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    '    CheckDate = 1
                    '    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    '    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    '    Report.SetParameterValue(2, CheckDate)
                    '    Report.SetParameterValue(3, lblID.Text)
                    '    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    '    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    '    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                    'Else
                    '    CheckDate = 0
                    '    Report.SetParameterValue(0, Date.Now)
                    '    Report.SetParameterValue(1, Date.Now)
                    '    Report.SetParameterValue(2, CheckDate)
                    '    Report.SetParameterValue(3, lblID.Text)
                    '    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    '    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    '    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                    'End If
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
                    Dim dt As DataTable = objPORecvMaster.CheckImsItemIdInGodownTransfer(lblID.Text)
                    If dt.Rows.Count > 0 Then
                        GetData()
                        Report.Load(Server.MapPath("..\Reports/StoreissueAstoreReportNew.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "Store_Issue_Report"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                            Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Else
                            CheckDate = 0
                            Report.SetParameterValue(0, "01/01/1900")
                            Report.SetParameterValue(1, "01/01/1900")
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
                    Else
                        GetData()
                        Report.Load(Server.MapPath("..\Reports/StoreissueAstoreReportNew.rpt"))
                        'Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifoForAcc.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "Store_Issue_Report"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                            Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                            Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        Else
                            CheckDate = 0
                            Report.SetParameterValue(0, "01/01/1900")
                            Report.SetParameterValue(1, "01/01/1900")
                        End If
                        'If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        '    CheckDate = 1
                        '    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                        '    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                        '    Report.SetParameterValue(2, CheckDate)
                        '    Report.SetParameterValue(3, lblID.Text)
                        '    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                        '    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                        '    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                        'Else
                        '    CheckDate = 0
                        '    Report.SetParameterValue(0, Date.Now)
                        '    Report.SetParameterValue(1, Date.Now)
                        '    Report.SetParameterValue(2, CheckDate)
                        '    Report.SetParameterValue(3, lblID.Text)
                        '    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                        '    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                        '    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                        'End If
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
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifoForGStore.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Store_Issue_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
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
            Else
                Report.Load(Server.MapPath("..\Reports/ItemInventoryIssueFifoForAll.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Store_Issue_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, lblID.Text)
                    Report.SetParameterValue(4, cmbSrNo.SelectedValue)
                    Report.SetParameterValue(5, cmbManualChallanNo.SelectedValue)
                    Report.SetParameterValue(6, cmbDepartment.SelectedValue)
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
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub GetData()
        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            CheckDate = 1
            Dim Date2 As Date = txtDateFrom.SelectedDate
            Dim date3 As Date = txtDateTo.SelectedDate
            Dim Estdateee As String = Date2.ToString("MM/dd/yyyy")
            Dim Enddateee As String = date3.ToString("MM/dd/yyyy")
            Dim ItemId As Long
            Dim JobOrderId As Long
            Dim IssueId As Long
            Dim LocationId As Long
            If lblID.Text = "" Then
                ItemId = 0
            Else
                ItemId = lblID.Text
            End If
            If cmbSeason.SelectedValue = 0 Then
            Else
                If cmbSrNo.SelectedValue = 0 Then
                    JobOrderId = 0
                Else
                    JobOrderId = cmbSrNo.SelectedValue
                End If
            End If
            If cmbManualChallanNo.SelectedValue = 0 Then
                IssueId = 0
            Else
                IssueId = cmbManualChallanNo.SelectedValue
            End If
            If cmbDepartment.SelectedValue = 0 Then
                LocationId = 0
            Else
                LocationId = cmbDepartment.SelectedValue
            End If
            objTempStockInventory.GetReportdataIssue(CheckDate, ItemId, JobOrderId, IssueId, LocationId, Estdateee, Enddateee)
            objTempStockInventory.GetReportdataIssueGodown(CheckDate, ItemId, Estdateee, Enddateee)
        Else
            CheckDate = 0
            Dim StartDate As String = "01/01/2000"
            Dim EndDate As String = "01/01/2090"
            Dim ItemId As Long
            Dim JobOrderId As Long
            Dim IssueId As Long
            Dim LocationId As Long
            If lblID.Text = "" Then
                ItemId = 0
            Else
                ItemId = lblID.Text
            End If
            If cmbSeason.SelectedValue = 0 Then
            Else
                If cmbSrNo.SelectedValue = 0 Then
                    JobOrderId = 0
                Else
                    JobOrderId = cmbSrNo.SelectedValue
                End If
            End If
            If cmbManualChallanNo.SelectedValue = 0 Then
                IssueId = 0
            Else
                IssueId = cmbManualChallanNo.SelectedValue
            End If
            If cmbDepartment.SelectedValue = 0 Then
                LocationId = 0
            Else
                LocationId = cmbDepartment.SelectedValue
            End If
            objTempStockInventory.GetReportdataIssue(CheckDate, ItemId, JobOrderId, IssueId, LocationId, StartDate, EndDate)
            objTempStockInventory.GetReportdataIssueGodown(CheckDate, ItemId, StartDate, EndDate)
        End If
    End Sub
End Class
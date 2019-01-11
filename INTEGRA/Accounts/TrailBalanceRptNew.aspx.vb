Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.classes

Public Class TrailBalanceRptNew
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim obGeneralCode As New GeneralCode
    Dim objDataTable As DataTable
    Dim ObjTemTrialBalance As New TemTrialBalance
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SetAllVouchersData()
        Dim OBJDATE As New GeneralCode
        ObjtblBankMst.TruncatingTemTrialBalanceTables()
        Dim StartDate As String = OBJDATE.GetDateFormat(txtStartDatee.SelectedDate)
        Dim EndDate As String = OBJDATE.GetDateFormat(txtEndDatee.SelectedDate)
        Dim sdatee, edate As String
        Dim Date2 As Date = txtStartDatee.SelectedDate
        Dim date3 As Date = txtEndDatee.SelectedDate
        sdatee = Date2.ToString("MM/dd/yyyy")
        edate = date3.ToString("MM/dd/yyyy")
        Dim dt As New DataTable
        Session("dt") = Nothing
        Dim Dr As DataRow
        Dim x As Integer
        Try
            If (Not CType(Session("dt"), DataTable) Is Nothing) Then
                dt = Session("dt")
            Else
                dt = New DataTable
                With dt
                    .Columns.Add("TempTrialID", GetType(Long))
                    .Columns.Add("Accountcode", GetType(String))
                    .Columns.Add("DebitBPV", GetType(String))
                    .Columns.Add("CreditBPV", GetType(String))
                    .Columns.Add("JVDebit", GetType(String))
                    .Columns.Add("JVCredit", GetType(String))
                    .Columns.Add("DebitCV", GetType(String))
                    .Columns.Add("CreditCV", GetType(String))
                    .Columns.Add("DebitPV", GetType(String))
                    .Columns.Add("CreditPV", GetType(String))
                    .Columns.Add("OB", GetType(String))
                    .Columns.Add("OBCr", GetType(String))
                End With
            End If
            objDataTable = ObjTemTrialBalance.GetAllAccountsNew()
            Dim DebitBPV As Decimal = 0
            Dim CreditBPV As Decimal = 0
            Dim DebitBPVMaster As Decimal = 0
            Dim CreditBPVMaster As Decimal = 0
            Dim JVDebit As Decimal = 0
            Dim JVCredit As Decimal = 0
            Dim DebitCV As Decimal = 0
            Dim CreditCV As Decimal = 0
            Dim DebitPV As Decimal = 0
            Dim CreditPV As Decimal = 0
            Dim OB As Decimal = 0
            Dim dtBPVDB As New DataTable
            Dim dtBPVCR As New DataTable
            Dim dtOBPVDB As New DataTable
            Dim dtOBPVCR As New DataTable
            Dim dtBPVDBMaster As New DataTable
            Dim dtBPVCRMaster As New DataTable
            Dim dtOBPVDBMaster As New DataTable
            Dim dtOBPVCRMaster As New DataTable
            Dim dtCVDB As New DataTable
            Dim dtCVCR As New DataTable
            Dim dtJVDB As New DataTable
            Dim dtJVCR As New DataTable
            Dim dtOJVDB As New DataTable
            Dim dtOJVCR As New DataTable
            Dim dtPVDB As New DataTable
            Dim dtPVCR As New DataTable
            Dim TotalBankDb As Decimal = 0
            Dim TotalBankCR As Decimal = 0
            Dim OpenDebitBPV As Decimal = 0
            Dim OpeningCreditBPV As Decimal = 0
            Dim OpeningCreditBPVMaster As Decimal = 0
            Dim OpeningDebitBPVMaster As Decimal = 0
            Dim OpeningJVDebit As Decimal = 0
            Dim OpeningJVCredit As Decimal = 0
            If objDataTable.Rows.Count > 0 Then
                For x = 0 To objDataTable.Rows.Count - 1
                    dtBPVDB = ObjTemTrialBalance.GetSumDebitBPVNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtBPVDB.Rows.Count > 0 Then
                        DebitBPV = Convert.ToInt64(dtBPVDB.Compute("SUM(DebitBPV)", String.Empty))
                    Else
                        DebitBPV = 0
                    End If
                    dtOBPVDB = ObjTemTrialBalance.GetOpeningSumDebitBPV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOBPVDB.Rows.Count > 0 Then
                        OpenDebitBPV = Convert.ToInt64(dtOBPVDB.Compute("SUM(DebitBPV)", String.Empty))
                    Else
                        OpenDebitBPV = 0
                    End If
                    dtBPVCR = ObjTemTrialBalance.GetSumCreditBPVNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtBPVCR.Rows.Count > 0 Then
                        CreditBPV = Convert.ToInt64(dtBPVCR.Compute("SUM(CreditBPV)", String.Empty))
                    Else
                        CreditBPV = 0
                    End If
                    dtOBPVCR = ObjTemTrialBalance.GetOpeningSumCreditBPV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOBPVCR.Rows.Count > 0 Then
                        OpeningCreditBPV = Convert.ToInt64(dtOBPVCR.Compute("SUM(CreditBPV)", String.Empty))
                    Else
                        OpeningCreditBPV = 0
                    End If
                    dtBPVDBMaster = ObjTemTrialBalance.GetSumCreditBPVMasterNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtBPVDBMaster.Rows.Count > 0 Then
                        CreditBPVMaster = Convert.ToInt64(dtBPVDBMaster.Compute("SUM(DebitBPV)", String.Empty))
                    Else
                        CreditBPVMaster = 0
                    End If
                    dtOBPVDBMaster = ObjTemTrialBalance.GetOpeningSumCreditBPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOBPVDBMaster.Rows.Count > 0 Then
                        OpeningCreditBPVMaster = Convert.ToInt64(dtOBPVDBMaster.Compute("SUM(DebitBPV)", String.Empty))
                    Else
                        OpeningCreditBPVMaster = 0
                    End If
                    dtBPVCRMaster = ObjTemTrialBalance.GetSumDebitBPVMasterNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtBPVCRMaster.Rows.Count > 0 Then
                        DebitBPVMaster = Convert.ToInt64(dtBPVCRMaster.Compute("SUM(CreditBPV)", String.Empty))
                    Else
                        DebitBPVMaster = 0
                    End If
                    dtOBPVCRMaster = ObjTemTrialBalance.GetOpeningSumDebitBPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOBPVCRMaster.Rows.Count > 0 Then
                        OpeningDebitBPVMaster = Convert.ToInt64(dtOBPVCRMaster.Compute("SUM(CreditBPV)", String.Empty))
                    Else
                        OpeningDebitBPVMaster = 0
                    End If
                    TotalBankDb = DebitBPV + DebitBPVMaster
                    TotalBankCR = CreditBPV + CreditBPVMaster
                    DebitCV = 0
                    CreditCV = 0
                    dtJVDB = ObjTemTrialBalance.GetSumDebitJV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtJVDB.Rows.Count > 0 Then
                        JVDebit = Convert.ToInt64(dtJVDB.Compute("SUM(DebitJV)", String.Empty))
                    Else
                        JVDebit = 0
                    End If
                    dtOJVDB = ObjTemTrialBalance.GetOpeningSumDebitJV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOJVDB.Rows.Count > 0 Then
                        OpeningJVDebit = Convert.ToInt64(dtOJVDB.Compute("SUM(DebitJV)", String.Empty))
                    Else
                        OpeningJVDebit = 0
                    End If
                    dtJVCR = ObjTemTrialBalance.GetSumCreditJV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    If dtJVCR.Rows.Count > 0 Then
                        JVCredit = Convert.ToInt64(dtJVCR.Compute("SUM(CreditJV)", String.Empty))
                    Else
                        JVCredit = 0
                    End If
                    dtOJVCR = ObjTemTrialBalance.GetOpeningSumCreditJV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    If dtOJVCR.Rows.Count > 0 Then
                        OpeningJVCredit = Convert.ToInt64(dtOJVCR.Compute("SUM(CreditJV)", String.Empty))
                    Else
                        OpeningJVCredit = 0
                    End If
                    DebitPV = 0
                    CreditPV = 0
                    Dim dtob As DataTable
                    dtob = ObjTemTrialBalance.GetOBNew(objDataTable.Rows(x)("Accountcode"))
                    Dim OpCre As Decimal = 0
                    Dim OpDbt As Decimal = 0
                    OpCre = 0 + OpeningCreditBPV + OpeningCreditBPVMaster + OpeningJVCredit
                    OpDbt = 0 + OpenDebitBPV + OpeningDebitBPVMaster + OpeningJVDebit
                    If OpCre = 0 And OpDbt = 0 Then
                        OB = OpDbt - OpCre
                    ElseIf OpCre > 0 And OpDbt = 0 Then
                        OB = OpDbt - OpCre
                    ElseIf OpDbt > 0 And OpCre = 0 Then
                        OB = OpDbt - OpCre
                    ElseIf OpDbt > OpCre Then
                        OB = OpDbt - OpCre
                    ElseIf OpCre > OpDbt Then
                        OB = OpDbt - OpCre
                    End If
                    Dr = dt.NewRow()
                    Dr("TempTrialID") = 0
                    Dr("Accountcode") = objDataTable.Rows(x)("Accountcode")
                    If TotalBankDb = 0 Then
                        Dr("DebitBPV") = 0
                    Else
                        Dr("DebitBPV") = TotalBankDb
                    End If
                    If TotalBankCR = 0 Then
                        Dr("CreditBPV") = 0
                    Else
                        Dr("CreditBPV") = TotalBankCR
                    End If
                    If JVDebit = 0 Then
                        Dr("JVDebit") = 0
                    Else
                        Dr("JVDebit") = JVDebit
                    End If
                    If JVCredit = 0 Then
                        Dr("JVCredit") = 0
                    Else
                        Dr("JVCredit") = JVCredit
                    End If
                    If DebitCV = 0 Then
                        Dr("DebitCV") = 0
                    Else
                        Dr("DebitCV") = DebitCV
                    End If
                    If CreditCV = 0 Then
                        Dr("CreditCV") = 0
                    Else
                        Dr("CreditCV") = CreditCV
                    End If
                    If DebitPV = 0 Then
                        Dr("DebitPV") = 0
                    Else
                        Dr("DebitPV") = DebitPV
                    End If
                    If CreditPV = 0 Then
                        Dr("CreditPV") = 0
                    Else
                        Dr("CreditPV") = CreditPV
                    End If
                    If OpDbt = 0 Then
                        Dr("OB") = 0
                    Else
                        Dr("OB") = OpDbt
                    End If
                    If OpCre = 0 Then
                        Dr("OBCr") = 0
                    Else
                        Dr("OBCr") = OpCre
                    End If
                    dt.Rows.Add(Dr)
                Next
            End If
            Session("dt") = dt
            For x = 0 To dt.Rows.Count - 1
                With ObjTemTrialBalance
                    .TempTrialID = 0
                    .Accountcode = dt.Rows(x)("Accountcode")
                    .DebitBPV = dt.Rows(x)("DebitBPV")
                    .CreditBPV = dt.Rows(x)("CreditBPV")
                    .JVDebit = dt.Rows(x)("JVDebit")
                    .JVCredit = dt.Rows(x)("JVCredit")
                    .DebitCV = dt.Rows(x)("DebitCV")
                    .CreditCV = dt.Rows(x)("CreditCV")
                    .DebitPV = dt.Rows(x)("DebitPV")
                    .CreditPV = dt.Rows(x)("CreditPV")
                    .OB = dt.Rows(x)("OB")
                    .OBCR = dt.Rows(x)("OBCr")
                    .SaveTemTrialBalance()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim dtbpv As DataTable
            dtbpv = ObjTemTrialBalance.GetBPVData()
            If dtbpv.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtbpv.Rows.Count - 1
                    ObjTemTrialBalance.UpdateTblBankMstGetBPVData(dtbpv.Rows(i)("tblBankMstID"), dtbpv.Rows(i)("Amountdtl"))
                Next
            End If
            SetAllVouchersData()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FINANCIALYEAR As String
            FINANCIALYEAR = "2018 - 19"
            Dim Date2 As Date = txtStartDatee.SelectedDate
            Dim date3 As Date = txtEndDatee.SelectedDate
            Dim sdatee, edate As String
            sdatee = Date2.ToString("MM/dd/yyyy")
            edate = date3.ToString("MM/dd/yyyy")
            'Dim StartDate As String = txtStartDatee.SelectedDate
            'Dim EndDate As String = txtEndDatee.SelectedDate
            Report.Load(Server.MapPath("~/Reports/TrialBalanceFORKAINew2.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, FINANCIALYEAR)
            Report.SetParameterValue(1, sdatee)
            Report.SetParameterValue(2, edate)
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Trial Balance Report"
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
        Catch ex As Exception
        End Try
    End Sub
End Class


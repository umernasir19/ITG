Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.classes

Public Class LedgerReportNew
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim dtAC As DataTable
    Dim obGeneralCode As New GeneralCode
    Dim YearFirst, YearSecond As String
    Dim AccountCode As String
    Dim openDate As String
    Dim OpeningBalance As Decimal
    Dim objSupplierledger As New SupplierLedger
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Ledger Report")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub lnkprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkprint.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            AccountCode = txtAccountCode.Text
            openDate = "01/01/1900"
            Dim GroupAct As String = "0102009001"
            Dim dtgroupAct As New DataTable
            dtgroupAct = ObjtblBankMst.GetGroupAct(AccountCode)
            Session("dt") = Nothing
            Dim x As Integer
            ObjtblBankMst.TruncateTempLedgerTable()
            If GroupAct = dtgroupAct.Rows(0)("GroupAct") Then
                ObjtblBankMst.InsertBPVDataNew(AccountCode)
                ObjtblBankMst.InsertBPVDataWithOutBankNew(AccountCode)
            Else
                ObjtblBankMst.InsertBPVDataWithOutBankNew(AccountCode)
            End If
            ObjtblBankMst.InsertJVDataNew(AccountCode)
            objSupplierledger.InsertCVDataTempLedgerINVBPVCVJV(txtAccountCode.Text)
            objSupplierledger.InsertCOntraVDataTempLedgerINVBPVCVJV(txtAccountCode.Text)
            objSupplierledger.InsertTempLedgerINVBPVCVJV(txtAccountCode.Text, txtPartyID.Text)
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
            Dim sdatee, edate As String
            Dim Date2 As Date = txtStartDatee.SelectedDate
            Dim date3 As Date = txtEndDatee.SelectedDate
            sdatee = Date2.ToString("MM/dd/yyyy")
            edate = date3.ToString("MM/dd/yyyy")
            ObjtblBankMst.TruncateTempLedgerFinal()
            ObjtblBankMst.InsertTempLedgerIntoTempFinal()
            Dim objDataTablepre As DataTable = ObjtblBankMst.GetLedgerForPrintNew(OpeningBalance, sdatee, edate)
            Dim Prevoiusbalance As Decimal = 0
            If objDataTablepre.Rows.Count > 0 Then
                Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
            End If
            Dim dtchk As DataTable
            dtchk = ObjtblBankMst.CheckInsertdataBackDate(sdatee)
            Dim dtonlyVoucher As DataTable
            If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
                dtonlyVoucher = ObjtblBankMst.GetLedgerForPrintNew2(OpeningBalance)
                Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
            End If
            Dim DescEntry As String = ""
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Dim FileName As String
            If objDataTablepre.Rows.Count > 0 Then
                Report.Load(Server.MapPath("..\Reports/LedgerReportForKAI.rpt"))
            Else
                If dtchk.Rows.Count = 0 Then
                    Report.Load(Server.MapPath("..\Reports/LedgerReportForKAIForOPOnly.rpt"))
                Else
                    Report.Load(Server.MapPath("..\Reports/LedgerReportForKAIOPBTVoucher.rpt"))
                End If
            End If
            FileName = "General Ledger"
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim Date22 As Date = txtStartDatee.SelectedDate
            Dim date33 As Date = txtEndDatee.SelectedDate
            Dim Est As String = Date22.ToString("MM/dd/yyyy")
            Dim Endd As String = date33.ToString("MM/dd/yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, txtCmbAccountCode.Text)
            Report.SetParameterValue(1, Est)
            Report.SetParameterValue(2, Endd)
            Report.SetParameterValue(3, OpeningBalance)
            Report.SetParameterValue(4, openDate)
            Report.SetParameterValue(5, Prevoiusbalance)
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
    Protected Sub lnlwebReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnlwebReport.Click
        Try
            Response.Redirect("LedgerPrintNew.aspx?AccountCode=" & lblAccountCode.Text & " &AccountName=" & txtCmbAccountCode.Text & " &StartDate=" & txtStartDatee.SelectedDate & "&EndDate=" & txtEndDatee.SelectedDate & "")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtCmbAccountCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCmbAccountCode.TextChanged
        Try
            Dim dt As DataTable = objSupplierledger.getPartyIDByAccountCodeForLedger(txtCmbAccountCode.Text)
            Dim dtAccountCode As DataTable = objSupplierledger.getAccountCodeForLedger(txtCmbAccountCode.Text)
            If dt.Rows.Count > 0 Then
                txtPartyID.Text = dt.Rows(0)("SupplierDatabaseID")
            Else
                txtPartyID.Text = 0
            End If
            If dtAccountCode.Rows.Count > 0 Then
                txtAccountCode.Text = dtAccountCode.Rows(0)("AccountCode")
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class


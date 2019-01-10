Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class LedgerReportForDigital
    Inherits System.Web.UI.Page
    Dim objSupplierledger As New SupplierLedger
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objG As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtStartDate.SelectedDate = "01/07/2018"
            txtEndDate.SelectedDate = Date.Now '"30/06/2019" 
        End If
    End Sub
    Sub CurrentMonthDate()
        Dim month As String = Date.Today.Month
        Dim codemonth As String
        If month = 1 Then
            codemonth = "01"
        ElseIf month = 2 Then
            codemonth = "02"
        ElseIf month = 3 Then
            codemonth = "03"
        ElseIf month = 4 Then
            codemonth = "04"
        ElseIf month = 5 Then
            codemonth = "05"
        ElseIf month = 6 Then
            codemonth = "06"
        ElseIf month = 7 Then
            codemonth = "07"
        ElseIf month = 8 Then
            codemonth = "08"
        ElseIf month = 9 Then
            codemonth = "09"
        Else
            codemonth = month
        End If
        Dim Year As String = Date.Today.Year
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If txtautoLedger.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Ledger.....")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            GetDateForLedgerReport()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FileName As String = "Ledger Report"
            Report.Load(Server.MapPath("~/Reports/LedgerReportForNM.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, txtStartDate.SelectedDate)
            Report.SetParameterValue(1, txtEndDate.SelectedDate)
            Report.SetParameterValue(2, txtautoLedger.Text)
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
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
           Dim path As String = (Server.MapPath("~/TempPDF") + "/" + FileName + ".pdf")
            Dim fs As FileStream = New FileStream(path, FileMode.Open)
            Dim fileSize As Long
            fileSize = fs.Length
            Dim Buffer() As Byte = New Byte((CType(fileSize, Integer)) - 1) {}
            fs.Read(Buffer, 0, CType(fs.Length, Integer))
            fs.Close()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", ("inline; filename=" + FileName))
            Response.BinaryWrite(Buffer)
            Response.Flush()
            Response.End()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub
    Sub GetDateForLedgerReport()
      Dim OBJDATE As New GeneralCode
        Dim sdatee, edate As String
        sdatee = OBJDATE.GetDateFormat(txtStartDate.SelectedDate)
        edate = OBJDATE.GetDateFormat(txtEndDate.SelectedDate)
        objSupplierledger.TruncateTempLedgerINVBPVCVJV()
        objSupplierledger.InsertJVDatainTempLedgerINVBPVCVJV(txtAccountCode.Text)
        objSupplierledger.InsertbvDataTempLedgerINVBPVCVJV(txtAccountCode.Text)
        objSupplierledger.InsertCVDataTempLedgerINVBPVCVJV(txtAccountCode.Text)
        objSupplierledger.InsertCOntraVDataTempLedgerINVBPVCVJV(txtAccountCode.Text)
        objSupplierledger.InsertTempLedgerINVBPVCVJV(txtAccountCode.Text, txtPartyID.Text)
        objSupplierledger.TruncateTempLedgerFinalINVBPVCVJV()
        objSupplierledger.InsertTempLedgerFinalINVBPVCVJV()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            GetDateForLedgerReport()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtautoLedger_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtautoLedger.TextChanged
        Try
            Dim dt As DataTable = objSupplierledger.getPartyIDByAccountCodeForLedger(txtautoLedger.Text)
            Dim dtAccountCode As DataTable = objSupplierledger.getAccountCodeForLedger(txtautoLedger.Text)
            If dt.Rows.Count > 0 Then
                txtPartyID.Text = dt.Rows(0)("SupplierDatabaseID")
            Else
                txtPartyID.Text = 0
            End If
            If dtAccountCode.Rows.Count > 0 Then
                txtAccountCode.Text = dtAccountCode.Rows(0)("AccountCode")
            Else
            End If
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        Catch ex As Exception
        End Try
    End Sub
End Class


Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Imports Integra.classes

Public Class TrialBalanceReport
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim obGeneralCode As New GeneralCode
    Dim objDataTable As DataTable
    Dim ObjTemTrialBalance As New TemTrialBalance
    Dim OBJDATE As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                txtstartdate.Text = "01/07/2018"
                txtEndDate.Text = "30/06/2019"
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
        ObjtblBankMst.TruncatingTemTrialBalanceTables()
        Dim StartDate As String = OBJDATE.GetDateFormat(txtstartdate.Text)
        Dim EndDate As String = OBJDATE.GetDateFormat(txtEndDate.Text)
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
                End With
            End If
            objDataTable = ObjTemTrialBalance.GetAllAccounts()
            Dim DebitBPV As Decimal = 0
            Dim CreditBPV As Decimal = 0
            Dim JVDebit As Decimal = 0
            Dim JVCredit As Decimal = 0
            Dim DebitCV As Decimal = 0
            Dim CreditCV As Decimal = 0
            Dim DebitPV As Decimal = 0
            Dim CreditPV As Decimal = 0
            Dim OB As Decimal = 0
            If objDataTable.Rows.Count > 0 Then
                For x = 0 To objDataTable.Rows.Count - 1
                    DebitBPV = ObjTemTrialBalance.GetSumDebitBPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    CreditBPV = ObjTemTrialBalance.GetSumCreditBPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    DebitCV = ObjTemTrialBalance.GetSumDebitCPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    CreditCV = ObjTemTrialBalance.GetSumCreditCPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    JVDebit = ObjTemTrialBalance.GetSumDebitJV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    JVCredit = ObjTemTrialBalance.GetSumCreditJV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    DebitPV = ObjTemTrialBalance.GetSumDebitPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    CreditPV = ObjTemTrialBalance.GetSumCreditPV(objDataTable.Rows(x)("Accountcode"), StartDate, EndDate)
                    Dim OpCre As Decimal = objDataTable.Rows(x)("Opening_Credit")
                    Dim OpDbt As Decimal = objDataTable.Rows(x)("Opening_Debit")
                    If OpCre = 0 And OpDbt = 0 Then
                        OB = OpCre
                    ElseIf OpCre > 0 And OpDbt = 0 Then
                        OB = OpCre
                    ElseIf OpDbt > 0 And OpCre = 0 Then
                        OB = OpDbt
                    ElseIf OpDbt > OpCre Then
                        OB = OpDbt - OpCre
                    ElseIf OpCre > OpDbt Then
                        OB = OpCre - OpDbt
                    End If
                    Dr = dt.NewRow()
                    Dr("TempTrialID") = 0
                    Dr("Accountcode") = objDataTable.Rows(x)("Accountcode")
                    If DebitBPV = 0 Then
                        Dr("DebitBPV") = 0
                    Else
                        Dr("DebitBPV") = DebitBPV
                    End If
                    If CreditBPV = 0 Then
                        Dr("CreditBPV") = 0
                    Else
                        Dr("CreditBPV") = CreditBPV
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

                    If OB = 0 Then
                        Dr("OB") = 0
                    Else
                        Dr("OB") = OB
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
                    .SaveTemTrialBalance()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            SetAllVouchersData()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FINANCIALYEAR As String
            FINANCIALYEAR = Session("Session").ToString()
            Dim StartDate As String = OBJDATE.GetDateFormat(txtstartdate.Text)
            Dim EndDate As String = OBJDATE.GetDateFormat(txtEndDate.Text)
            Report.Load(Server.MapPath("~/Reports/TrialBalanceJBTest222.rpt"))
            Report.Refresh()
            Report.SetParameterValue(0, FINANCIALYEAR)
            Report.SetParameterValue(1, StartDate)
            Report.SetParameterValue(2, EndDate)
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


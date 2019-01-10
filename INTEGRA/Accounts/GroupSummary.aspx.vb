Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class GroupSummary
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                ' CurrentMonthDate()
                BindAccountcode()
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
    Sub BindAccountcode()
        Dim dtGroup As New DataTable '= DirectCast(Session("dtStyleProductInformation"), DataTable)

        With dtGroup
            .Columns.Add("AccountCode", GetType(String))
            .Columns.Add("AccountName", GetType(String))
        End With
        Dim dtAccountCode As DataTable
        dtAccountCode = ObjtblBankMst.GetUniqueAccountNameForGroupSummary()
        If dtAccountCode.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To dtAccountCode.Rows.Count - 1
                Dim dtcheck As DataTable = ObjtblBankMst.CheckGroupDetail(dtAccountCode.Rows(x)("AccountCode"))
                If dtcheck.Rows.Count > 0 Then
                    With dtGroup
                        Dr = dtGroup.NewRow()
                        Dr("AccountCode") = dtAccountCode.Rows(x)("AccountCode")
                        Dr("AccountName") = dtAccountCode.Rows(x)("AccountName")
                        dtGroup.Rows.Add(Dr)
                    End With
                End If
            Next
        End If
        If dtGroup.Rows.Count > 0 Then
            CmbAccountCode.DataSource = dtGroup
            CmbAccountCode.DataValueField = "AccountCode"
            CmbAccountCode.DataTextField = "AccountName"
            CmbAccountCode.DataBind()
        End If
        ' CmbAccountCode.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
    'Sub CurrentMonthDate()
    '    Dim month As String = Date.Today.Month
    '    Dim codemonth As String
    '    If month = 1 Then
    '        codemonth = "01"
    '    ElseIf month = 2 Then
    '        codemonth = "02"
    '    ElseIf month = 3 Then
    '        codemonth = "03"
    '    ElseIf month = 4 Then
    '        codemonth = "04"
    '    ElseIf month = 5 Then
    '        codemonth = "05"
    '    ElseIf month = 6 Then
    '        codemonth = "06"
    '    ElseIf month = 7 Then
    '        codemonth = "07"
    '    ElseIf month = 8 Then
    '        codemonth = "08"
    '    ElseIf month = 9 Then
    '        codemonth = "09"
    '    Else
    '        codemonth = month
    '    End If
    '    Dim Year As String = Date.Today.Year
    '    txtStartDate.Text = "01/" & codemonth & "/" & Year
    '    If codemonth = "02" Then
    '        txtEndDate.Text = "28/" & codemonth & "/" & Year
    '    Else
    '        txtEndDate.Text = "30/" & codemonth & "/" & Year
    '    End If
    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            GetDateForLedgerReport()
        Catch ex As Exception

        End Try
    End Sub
    Sub GetDateForLedgerReport()

        'Dim OBJDATE As New GeneralCode
        'Dim sdatee, edate As String
        'sdatee = OBJDATE.GetDateFormat(txtStartDate.Text)
        'edate = OBJDATE.GetDateFormat(txtEndDate.Text)
        ObjtblBankMst.TruncateTempGroupSummaryTable()
        ObjtblBankMst.InsertAll(CmbAccountCode.SelectedValue)
        ObjtblBankMst.InsertJVDataGropuSummary(CmbAccountCode.SelectedValue)
        '  ObjtblBankMst.InsertJVDataGropuSummary(CmbAccountCode.SelectedValue)
        ObjtblBankMst.InsertbvDataGropuSummary(CmbAccountCode.SelectedValue)
        ObjtblBankMst.InsertCVDataGropuSummary(CmbAccountCode.SelectedValue)
        'objSupplierledger.InsertSupplierLedgerDataWithOUtDate(txtAccountCode.Text, cmbSupplier.SelectedValue)
        'objSupplierledger.TruncateTempLedgerFinalTable()
        'objSupplierledger.InsertSupplierLedgerFinalDataWithOutDate()

    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            GetDateForLedgerReport()
            'Dim Supplerid As Long = cmbSupplier.SelectedValue
            '  Dim StatDate As Date = txtStartDate.Text
            ' Dim EndDate As Date = txtEndDate.Text
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FileName As String = "Group Summary"
            'PartiesLedger()
            ' Report.Load(Server.MapPath("~/Reports/SupplierLedgerNew.rpt"))
            Report.Load(Server.MapPath("~/Reports/GroupSummary.rpt"))
            Report.Refresh()
            'Report.SetParameterValue(0, Supplerid)
            Report.SetParameterValue(0, CmbAccountCode.SelectedItem.Text)


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

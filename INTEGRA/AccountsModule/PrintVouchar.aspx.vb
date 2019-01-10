Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Collections
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PrintVouchar
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New ChartOfAccount
    Dim objCashTransaction As New CashTransaction
    Dim CashTransactionID As Long
    Dim BankTransactionID As Long
    Dim Type As String
    Dim TranscationType As String
    Dim IsTaxable As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CashTransactionID = Request.QueryString("Cashid")
        BankTransactionID = Request.QueryString("Bankid")
        Type = Request.QueryString("Type")
        TranscationType = Request.QueryString("TranscationType")
        IsTaxable = Request.QueryString("IsTaxable")

        If Not Page.IsPostBack Then
            If Type = "Cash" Then
                DownloadCashPDF()
            ElseIf Type = "TaxVocher" Then
                DownloadTaxPDF()
            Else
                DownloadBankPDF()
            End If

        End If
    End Sub
    Sub DownloadCashPDF()
        Try

            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim EditCashID As Long
            If CashTransactionID > 0 Then
                EditCashID = CashTransactionID
            Else
                EditCashID = objCashTransaction.GetId
            End If
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Report.Load(Server.MapPath("..\Reports/CashTransaction.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Cash Transaction-"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, EditCashID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            Dim strFileSize As String = ""
            Dim ExistFIleName As String = "Cash Transaction-" + ".pdf"
            Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

            Dim fi As IO.FileInfo

            For Each fi In aryFi
                Response.ClearHeaders()
                Response.ClearContent()
                Response.ContentType = "application/pdf"
                ' Response.Charset = "UTF-8"
                ' Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                Response.End()
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub DownloadBankPDF()
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim EditBankID As Long
            If BankTransactionID > 0 Then
                EditBankID = BankTransactionID
            End If
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim lTranscationType As String = TranscationType
            Dim lIsTaxable As String = IsTaxable

            If lTranscationType = "BPV" And lIsTaxable = "False" Then
                Report.Load(Server.MapPath("..\Reports/BankTransactionBPVIsTaxFalse.rpt"))
            ElseIf lTranscationType = "BPV" And lIsTaxable = "True" Then
                Report.Load(Server.MapPath("..\Reports/BankTransactionBPVIsTaxTrue.rpt"))
            ElseIf lTranscationType = "BRV" And lIsTaxable = "False" Then
                Report.Load(Server.MapPath("..\Reports/BankTransactionBRV.rpt"))
            End If

            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Bank Transaction-" + lTranscationType
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, EditBankID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            Dim strFileSize As String = ""
            Dim ExistFIleName As String = "Bank Transaction-" + lTranscationType + ".pdf"
            Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

            Dim fi As IO.FileInfo

            For Each fi In aryFi
                Response.ClearHeaders()
                Response.ClearContent()
                Response.ContentType = "application/pdf"
                ' Response.Charset = "UTF-8"
                '  Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                Response.End()
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub DownloadTaxPDF()
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim lTranscationType As String = TranscationType

            Report.Load(Server.MapPath("..\Reports/TaxVoucher.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "Tax Voucher-" + lTranscationType
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, BankTransactionID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            Dim strFileSize As String = ""
            Dim ExistFIleName As String = "Tax Voucher-" + lTranscationType + ".pdf"
            Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

            Dim fi As IO.FileInfo

            For Each fi In aryFi
                Response.ClearHeaders()
                Response.ClearContent()
                Response.ContentType = "application/pdf"
                ' Response.Charset = "UTF-8"
                '  Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                Response.End()
            Next

        Catch ex As Exception

        End Try
    End Sub
End Class
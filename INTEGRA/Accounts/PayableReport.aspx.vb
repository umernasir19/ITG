Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class PayableReport
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim dtAC As DataTable
    Dim obGeneralCode As New GeneralCode
    Dim YearFirst, YearSecond As String
    Dim ObjSupplier As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                BindSupplier()

            Catch objUDException As UDException
            End Try
        End If
    End Sub

    Sub BindSupplier()
        Dim dt As DataTable
        dt = ObjSupplier.GetSupplierForDalAccounts()
        cmbSupplier.DataSource = dt
        cmbSupplier.DataValueField = "SupplierDatabaseId"
        cmbSupplier.DataTextField = "SupplierName"
        cmbSupplier.DataBind()
        cmbSupplier.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            If cmbSupplier.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Supplier")
            ElseIf cmbYear.SelectedValue = 0 Then

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Year")
            ElseIf txtStartDate.SelectedDate.ToString = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Start Date")
            ElseIf txtEndDate.SelectedDate.ToString = "" Then

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select End Date")

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

                'Dim Supplerid As Long = cmbSupplier.SelectedValue
                ' Dim StatDate As Date = txtStartDate.SelectedDate
                'Dim EndDate As Date = txtEndDate.SelectedDate
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim FileName As String = "PartiesPayable"
                'PartiesLedger()
                ' Report.Load(Server.MapPath("~/Reports/SupplierLedgerNew.rpt"))
                Report.Load(Server.MapPath("~/Reports/PartiesPayable.rpt"))
                Report.Refresh()
                Report.SetParameterValue(0, cmbYear.SelectedItem.Text)
                Report.SetParameterValue(1, cmbSupplier.SelectedValue)
                Report.SetParameterValue(2, txtStartDate.SelectedDate)
                Report.SetParameterValue(3, txtEndDate.SelectedDate)

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
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class

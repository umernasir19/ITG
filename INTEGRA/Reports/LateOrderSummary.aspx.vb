Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class LateOrderSummary
    Inherits System.Web.UI.Page
    Dim objLateOrdersSummary As New LateOrdersSummary
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Late Orders Summary")
            Dim FirstDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateFrom.SelectedDate = FirstDay
            Dim lastDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateTo.SelectedDate = lastDay.AddMonths(1).AddDays(-1)
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete

            objLateOrdersSummary.TruncateTable()
            GetLateOrdersSummaryReport()
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/LateOrderSummary.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Late_Orders_Summary_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, txtDateFrom.SelectedDate)
            Report.SetParameterValue(1, txtDateTo.SelectedDate)
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
    Sub GetLateOrdersSummaryReport()
        Try
            Dim dtSupplier As New DataTable
            'Dim Fromdate As Date = txtDateFrom.SelectedDate
            'Dim ToDate As Date = txtDateTo.SelectedDate
            Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim x As Integer
            dtSupplier = objLateOrdersSummary.GetMgtSupplierData()
            For x = 0 To dtSupplier.Rows.Count - 1
                Dim BookedForPos As Decimal = 0
                Dim ShippedPosOnTime As Decimal = 0
                Dim DelayedByWeek1 As Decimal = 0
                Dim DelayedByWeek2 As Decimal = 0
                Dim DelayedByWeek3 As Decimal = 0
                Dim DelayedByWeek4 As Decimal = 0
                Dim DelayedByWeek4Plus As Decimal = 0
                Dim SupplierID As Long = dtSupplier.Rows(x)("venderlibraryid")
                Dim SupplierName As String = dtSupplier.Rows(x)("VenderName")
                Dim i As Integer
                Dim dtCustomer As New DataTable
                dtCustomer = objLateOrdersSummary.GetMgtCustomerDataNew(Fromdate, ToDate, SupplierID)
                If dtCustomer.Rows.Count = 0 Then
                Else
                    For i = 0 To dtCustomer.Rows.Count - 1
                        Dim CustomerID As Long = dtCustomer.Rows(i)("CustomerID")
                        Dim CustomerName As String = dtCustomer.Rows(i)("CustomerName")
                        Dim dtECPDivision As New DataTable
                        dtECPDivision = objLateOrdersSummary.GetECPDivisionNew(Fromdate, ToDate, SupplierID, CustomerID)
                        Dim j As Integer
                        If dtECPDivision.Rows.Count = 0 Then
                        Else
                            For j = 0 To dtECPDivision.Rows.Count - 1
                                Dim ECPDivision As String = dtECPDivision.Rows(j)("ECPDivistion")
                                Dim First As Decimal = 0
                                Dim Last As Decimal = 0

                                '----Shipped Pos OnTime
                                ShippedPosOnTime = objLateOrdersSummary.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, SupplierID, CustomerID, ECPDivision)
                                '----Booked For Pos
                                BookedForPos = objLateOrdersSummary.GetMGTBookedForPOsNew(Fromdate, ToDate, SupplierID, CustomerID, ECPDivision)
                                '----DelayedByWeek1
                                DelayedByWeek1 = objLateOrdersSummary.GetDelayedPosNew(Fromdate, ToDate, SupplierID, CustomerID, 1, ECPDivision)
                                '----DelayedByWeek2
                                DelayedByWeek2 = objLateOrdersSummary.GetDelayedPosNew(Fromdate, ToDate, SupplierID, CustomerID, 2, ECPDivision)
                                '----DelayedByWeek3
                                DelayedByWeek3 = objLateOrdersSummary.GetDelayedPosNew(Fromdate, ToDate, SupplierID, CustomerID, 3, ECPDivision)
                                '----DelayedByWeek4
                                DelayedByWeek4 = objLateOrdersSummary.GetDelayedPosNew(Fromdate, ToDate, SupplierID, CustomerID, 4, ECPDivision)
                                '----DelayedByWeek4Plus
                                DelayedByWeek4Plus = objLateOrdersSummary.GetDelayedByWeek4PlusNew(Fromdate, ToDate, SupplierID, CustomerID, ECPDivision)
                                With objLateOrdersSummary
                                    .LOSID = 0
                                    .CreationDate = Today.Date
                                    .SupplierID = SupplierID
                                    .SupplierName = SupplierName
                                    .CustomerID = CustomerID
                                    .CustomerName = CustomerName
                                    .ECPDivision = ECPDivision
                                    .ShippedPOsOnTime = ShippedPosOnTime
                                    .BookedForPOs = BookedForPos
                                    .DelayedByWeek1 = DelayedByWeek1
                                    .DelayedByWeek2 = DelayedByWeek2
                                    .DelayedByWeek3 = DelayedByWeek3
                                    .DelayedByWeek4 = DelayedByWeek4
                                    .DelayedByWeek4plus = DelayedByWeek4Plus
                                    .SaveLateOrdersSummary()
                                End With
                            Next
                        End If
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
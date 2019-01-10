Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class DetailedCustomerAnalysisReportN
    Inherits System.Web.UI.Page
    Dim objDetailedCustomerAnalysis As New DetailedCustomerAnalysisReport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Supplier Customer Report")
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
        objDetailedCustomerAnalysis.TruncateTable()
        GetDetailedCustomerAnalysisReport()
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/DetailedCustomerAnalysisReport.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Detailed_Customer_Analysis_Report_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
    End Sub
    Sub GetDetailedCustomerAnalysisReport()
        Dim dtCustomer As New DataTable
        Dim Fromdate As Date = txtDateFrom.SelectedDate
        Dim ToDate As Date = txtDateTo.SelectedDate
        Dim x As Integer
        dtCustomer = objDetailedCustomerAnalysis.GetCustomerData(Fromdate, ToDate)
        For x = 0 To dtCustomer.Rows.Count - 1
            Dim CustomerID As Long = dtCustomer.Rows(x)("CustomerID")
            Dim CustomerName As String = dtCustomer.Rows(x)("CustomerName")
            Dim dtSupplier As New DataTable
            dtSupplier = objDetailedCustomerAnalysis.GetSupplierData(Fromdate, ToDate, CustomerID)
            Dim GetBookedInQTY As Decimal = 0
            Dim GetBookedForQty As Decimal = 0
            Dim GetShippedQuantity As Decimal = 0
            Dim GetShippedQtyOnTime As Decimal = 0
            Dim GetBookedInPos As Decimal = 0
            Dim GetBookedForPos As Decimal = 0
            Dim GetTotalShippedPos As Decimal = 0
            Dim GetShippedPOsOnTime As Decimal = 0
            Dim dtBookedInTurnOver As New DataTable
            Dim BookedInTurnOver As Decimal = 0
            Dim dtBookedForTurnover As New DataTable
            Dim BookedForTurnOver As Decimal = 0
            Dim dtShippedturnover As New DataTable
            Dim ShippedTurnOver As Decimal = 0
            Dim BookedComm As Decimal = 0
            Dim ShippedComm As Decimal = 0
            Dim DeliveryPerformance As Decimal = 0
            Dim ProductionPerformance As Decimal = 0
            Dim QualityPerformance As Decimal = 0
            Dim i As Integer
            For i = 0 To dtSupplier.Rows.Count - 1
                Dim SupplierID As Long = dtSupplier.Rows(i)("venderlibraryid")
                Dim SupplierName As String = dtSupplier.Rows(i)("VenderName")
                If dtSupplier.Rows.Count = 0 Then

                Else
                    '---BookedInQty
                    GetBookedInQTY = objDetailedCustomerAnalysis.GetBookedInQTY(Fromdate, ToDate, CustomerID, SupplierID)
                    '----BookedForQty
                    GetBookedForQty = objDetailedCustomerAnalysis.GetBookedForQTY(Fromdate, ToDate, CustomerID, SupplierID)
                    '----Balance To Go Pos
                    '----Shipped Quantity
                    GetShippedQuantity = objDetailedCustomerAnalysis.GetShippedQTY(Fromdate, ToDate, CustomerID, SupplierID)
                    '---Shipped Qty On Time
                    GetShippedQtyOnTime = objDetailedCustomerAnalysis.GetShippedQTYOnTime(Fromdate, ToDate, CustomerID, SupplierID)
                    '---Booked In Pos
                    GetBookedInPos = objDetailedCustomerAnalysis.GetBookedInPOs(Fromdate, ToDate, CustomerID, SupplierID)
                    '---Booked For Pos
                    GetBookedForPos = objDetailedCustomerAnalysis.GetBookedForPOs(Fromdate, ToDate, CustomerID, SupplierID)
                    '---GetTotalShippedPos
                    GetTotalShippedPos = objDetailedCustomerAnalysis.GetTotalShippedPos(Fromdate, ToDate, CustomerID, SupplierID)
                    '---GetMGTShippedPOsOnTime
                    GetShippedPOsOnTime = objDetailedCustomerAnalysis.GetShippedPOsOnTime(Fromdate, ToDate, CustomerID, SupplierID)
                    '---BookeedInTurnOver
                    dtBookedInTurnOver = objDetailedCustomerAnalysis.BookeedInTurnOver(Fromdate, ToDate, CustomerID, SupplierID)
                    If dtBookedInTurnOver.Rows.Count = 0 Then
                        BookedInTurnOver = 0
                    Else
                        BookedInTurnOver = dtBookedInTurnOver.Compute("Sum(BookedTurnOver)", "")
                    End If
                    ''''Booked For Turnover
                    dtBookedForTurnover = objDetailedCustomerAnalysis.BookeedForTurnOver(Fromdate, ToDate, CustomerID, SupplierID)
                    If dtBookedForTurnover.Rows.Count = 0 Then
                        BookedForTurnOver = 0
                    Else
                        BookedForTurnOver = dtBookedForTurnover.Compute("Sum(BookedTurnOver)", "")
                    End If
                    '---Shipped Turnover
                    dtShippedturnover = objDetailedCustomerAnalysis.ShippeedTurnOver(Fromdate, ToDate, CustomerID, SupplierID)
                    If dtShippedturnover.Rows.Count = 0 Then
                        ShippedTurnOver = 0
                    Else
                        ShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                    End If
                    '--- Shipped Turnover On Time
                    Dim dtShippedTurnoverOnTime As New DataTable
                    Dim ShippedTurnOverOntime As Decimal = 0
                    dtShippedTurnoverOnTime = objDetailedCustomerAnalysis.ShippeedTurnOverOnTime(Fromdate, ToDate, CustomerID, SupplierID)
                    If dtShippedTurnoverOnTime.Rows.Count = 0 Then
                        ShippedTurnOverOntime = 0
                    Else
                        ShippedTurnOverOntime = dtShippedTurnoverOnTime.Compute("Sum(ShippedTurnOverOnTime)", "")
                    End If
                    '----Booked Comm
                    BookedComm = objDetailedCustomerAnalysis.GetBookedComm(Fromdate, ToDate, CustomerID, SupplierID)
                    '-----Shipped Comm
                    Dim TotalShippedComm As Decimal
                    ShippedComm = dtCustomer.Rows(x)("Commission")
                    TotalShippedComm = ShippedTurnOver * ShippedComm / 100
                    '----Delivery Performance
                    If GetBookedForPos = 0 Then
                        DeliveryPerformance = 0
                    Else
                        DeliveryPerformance = (GetShippedPOsOnTime * 100) / GetBookedForPos
                    End If
                    'PP
                    If GetBookedForQty = 0 Then
                        ProductionPerformance = 0
                    Else
                        ProductionPerformance = (GetShippedQuantity * 100) / GetBookedForQty
                    End If
                    '----Claim POs
                    Dim ClaimPos As Decimal = 0
                    ClaimPos = objDetailedCustomerAnalysis.GetClaimPos(Fromdate, ToDate, CustomerID, SupplierID)
                    '----QP
                    Dim QP As Decimal = 0
                    If GetTotalShippedPos = 0 Then
                        QP = 0
                    Else
                        QualityPerformance = ClaimPos * 100 / GetTotalShippedPos

                        QP = 100 - QualityPerformance
                    End If
                    With objDetailedCustomerAnalysis
                        .DCARID = 0
                        .CreationDate = Now.Date
                        .CustomerID = CustomerID
                        .CustomerName = CustomerName
                        .SupplierID = SupplierID
                        .SupplierName = SupplierName
                        .BookedInQuantity = GetBookedInQTY
                        .BookedForQuantity = GetBookedForQty
                        .ShippedQuantity = GetShippedQuantity
                        .ShippedQtyOnTime = GetShippedQtyOnTime
                        .BalanceToGoQty = GetBookedForQty - GetShippedQuantity
                        .BookedInPos = GetBookedInPos
                        .BookedForPos = GetBookedForPos
                        .TotalShippedPos = GetTotalShippedPos
                        .ShippedPosOnTime = GetShippedPOsOnTime
                        .BalanceToGoPos = GetBookedForPos - GetTotalShippedPos
                        .BookedInTurnOver = BookedInTurnOver
                        .BookedForTurnOver = BookedForTurnOver
                        .ShippedTurnOver = ShippedTurnOver
                        .ShippedTurnOverOnTime = ShippedTurnOverOntime
                        .BTGTurnover = BookedForTurnOver - ShippedTurnOver
                        .BookedCommission = BookedComm
                        .ShippedCommission = TotalShippedComm
                        .ProductionPerformance = ProductionPerformance
                        .DeliveryPerformance = DeliveryPerformance
                        .QualityPerformance = QP
                        .SaveDetailedCustomerAnalysisReport()
                    End With
                End If
            Next
        Next
    End Sub
End Class
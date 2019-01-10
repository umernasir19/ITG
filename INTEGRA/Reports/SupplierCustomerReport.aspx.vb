Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class SupplierCustomerReport
    Inherits System.Web.UI.Page
    Dim objSupplierCustomer As New MGTSupplierCustomerReports
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Supplier Customer Report")
            Dim FirstDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateFrom.SelectedDate = FirstDay
            Dim lastDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateTo.SelectedDate = lastDay.AddMonths(1).AddDays(-1)
            BindMarchand()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub

    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        objSupplierCustomer.TruncateTable()
        GetSupplierCustomerReport()
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/Supplier_Customer.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Supplier_Customer_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        Report.SetParameterValue(0, txtDateFrom.SelectedDate)
        Report.SetParameterValue(1, txtDateTo.SelectedDate)
        Report.SetParameterValue(2, cmbMarchand.SelectedValue)
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
    Sub GetSupplierCustomerReport()
        Dim dtMgtSupplier As New DataTable
        Dim dtBookQty As New DataTable
        Dim dtbookedturnover As New DataTable
        Dim dtShippedturnover As New DataTable
        Dim dtTimelyShipped As New DataTable
        Dim dtTotalPos As New DataTable
        'Dim Fromdate As Date = txtDateFrom.SelectedDate
        'Dim ToDate As Date = txtDateTo.SelectedDate
        Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
        Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
        Dim MarchandID As Long = cmbMarchand.SelectedValue
        Dim MarchandName As String = cmbMarchand.SelectedItem.Text
        Dim x As Integer
        dtMgtSupplier = objSupplierCustomer.GetMgtSupplierDataNew(Fromdate, ToDate, MarchandID)
        For x = 0 To dtMgtSupplier.Rows.Count - 1
            Dim BookedQty As Decimal = 0
            Dim ShippedQty As Decimal = 0
            Dim ShippedQtyOnTime As Decimal = 0
            Dim BookedForPos As Decimal = 0
            Dim TotalShippedPos As Decimal = 0
            Dim ShippedPosOnTime As Decimal = 0
            Dim BookedTurnOver As Decimal = 0
            Dim SumOfBookedTurnOver As Decimal = 0
            Dim ShippedTurnOver As Decimal = 0
            Dim SumOfShippedTurnOver As Decimal = 0
            Dim DeliverPerformance As Decimal = 0
            Dim ProductionPerformance As Decimal = 0
            Dim SupplierID As Long = dtMgtSupplier.Rows(x)("venderlibraryid")
            Dim SupplierName As String = dtMgtSupplier.Rows(x)("VenderName")
            Dim i As Integer
            Dim dtCustomer As New DataTable
            dtCustomer = objSupplierCustomer.GetMgtCustomerDataNew(Fromdate, ToDate, SupplierID, MarchandID)
            For i = 0 To dtCustomer.Rows.Count - 1
                If dtCustomer.Rows.Count = 0 Then

                Else
                    Dim CustomerID As Long = dtCustomer.Rows(i)("CustomerID")
                    Dim CustomerName As String = dtCustomer.Rows(i)("CustomerName")
                    '---BookedQty
                    BookedQty = objSupplierCustomer.GetMGTBookedQTYNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '---ShippeddQty
                    ShippedQty = objSupplierCustomer.GetMGTShippedQTYNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Shipped Qty On Time
                    ShippedQtyOnTime = objSupplierCustomer.GetMGTShippedQTYOnTimeNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Booked For Pos
                    BookedForPos = objSupplierCustomer.GetMGTBookedForPOsNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Total Shipped Pos
                    TotalShippedPos = objSupplierCustomer.GetMGTTotalShippedPosNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Shipped Pos OnTime
                    ShippedPosOnTime = objSupplierCustomer.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '-----Booked Turnover
                    dtbookedturnover = objSupplierCustomer.BookeedTurnOverNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    If dtbookedturnover.Rows.Count = 0 Then
                        SumOfBookedTurnOver = 0
                    Else
                        SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                    End If
                    '-----Shipped Turnover
                    dtShippedturnover = objSupplierCustomer.ShippeedTurnOverNew(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    If dtShippedturnover.Rows.Count = 0 Then
                        SumOfShippedTurnOver = 0
                    Else
                        SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                    End If
                    '----------------------------------------------
                    ''----Shipped Quantity On Time EKNumber Vise
                    'Dim ShippedQtyOnTimeIND As Decimal = 0
                    'Dim BookedForPosIND As Decimal = 0
                    'Dim ShippedPosOnTimeIND As Decimal = 0
                    'Dim BookedQtyIND As Decimal = 0
                    ''----Shipped Qty On Time For Individual
                    'ShippedQtyOnTimeIND = objSupplierCustomer.GetMGTShippedQTYOnTimeIND(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    ''----Booked For Pos For Individual
                    'BookedForPosIND = objSupplierCustomer.GetMGTBookedForPOsIND(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    ''----Shipped Pos OnTime For Individual
                    'ShippedPosOnTimeIND = objSupplierCustomer.GetMGTShippedPOsOnTimeIND(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    ''---BookedQty For Individual
                    'BookedQtyIND = objSupplierCustomer.GetMGTBookedQTYIND(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    ''----- Grnad Total of Production Performance
                    'If BookedQtyIND = 0 Then
                    '    ProductionPerformance = 0
                    'Else
                    '    ProductionPerformance = (ShippedQtyOnTimeIND * 100) / BookedQtyIND
                    '    If ProductionPerformance > 100 Then
                    '        ProductionPerformance = 100
                    '    Else
                    '        ProductionPerformance = ProductionPerformance
                    '    End If
                    'End If

                    If BookedQty = 0 Then
                        ProductionPerformance = 0
                    Else
                        ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                        If ProductionPerformance > 100 Then
                            ProductionPerformance = 100
                        Else
                            ProductionPerformance = ProductionPerformance
                        End If
                    End If

                    '---- Grand Total of Delivery Performance
                    'If BookedForPosIND = 0 Then
                    '    DeliverPerformance = 0
                    'Else
                    '    DeliverPerformance = (ShippedPosOnTimeIND * 100) / BookedForPosIND
                    'End If
                    If BookedForPos = 0 Then
                        DeliverPerformance = 0
                    Else
                        DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                    End If
                    '----For Save
                    With objSupplierCustomer
                        .SCID = 0
                        .CreationDate = Today.Date
                        .MarchandID = MarchandID
                        .MarchandName = MarchandName
                        .CustomerID = CustomerID
                        .CustomerName = CustomerName
                        .SupplierID = SupplierID
                        .SupplierName = SupplierName
                        .BookedQuantity = BookedQty
                        .ShippedQuantity = ShippedQty
                        .BookedTurnOver = SumOfBookedTurnOver
                        .ShippedTurnOver = SumOfShippedTurnOver
                        .DeliveryPerformance = DeliverPerformance
                        .ProductionPerformance = ProductionPerformance
                        .ShippedQuantityOnTime = ShippedQtyOnTime
                        .BookedForPOs = BookedForPos
                        .TotalShippedPOs = TotalShippedPos
                        .ShippedPOsOnTime = ShippedPosOnTime
                        .PeriodicType = cmbPeriodicType.SelectedItem.Text
                        .SaveSuplierCustomer()
                    End With
                End If
            Next
        Next
    End Sub
    Sub BindMarchand()
        Dim dtMarchand As New DataTable
        dtMarchand = objSupplierCustomer.GetMarchand
        cmbMarchand.DataSource = dtMarchand
        cmbMarchand.DefaultItem.Text = "Select Merchant"
        cmbMarchand.DataTextField = "UserName"
        cmbMarchand.DataValueField = "MarchandID"
        cmbMarchand.DataBind()
    End Sub
End Class
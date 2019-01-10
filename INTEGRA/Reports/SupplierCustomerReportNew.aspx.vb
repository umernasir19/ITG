Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class SupplierCustomerReportNew
    Inherits System.Web.UI.Page
    Dim objSupplierCustomer As New MGTSupplierCustomerReports2
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Supplier Customer Report")
            Dim FirstDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateFrom.SelectedDate = FirstDay
            Dim lastDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateTo.SelectedDate = lastDay.AddMonths(1).AddDays(-1)
            BindMarchand()

            BindCustomer()

            cmbMarchand.Visible = False
            lblh.Text = "Customer:"
            cmbCustomer.Visible = True
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        objSupplierCustomer.TruncateTable()
        If cmbReportType.SelectedValue = 0 Then
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
        ElseIf cmbReportType.SelectedValue = 1 Then
            GetSupplierCustomerReport1()
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/Supplier_Customer1.rpt"))
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
        dtMgtSupplier = objSupplierCustomer.GetMgtSupplierData(Fromdate, ToDate, MarchandID)
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
            dtCustomer = objSupplierCustomer.GetMgtCustomerData(Fromdate, ToDate, SupplierID, MarchandID)
            For i = 0 To dtCustomer.Rows.Count - 1
                If dtCustomer.Rows.Count = 0 Then

                Else
                    Dim CustomerID As Long = dtCustomer.Rows(i)("CustomerID")
                    Dim CustomerName As String = dtCustomer.Rows(i)("CustomerName")
                    '---BookedQty
                    BookedQty = objSupplierCustomer.GetMGTBookedQTY(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '---ShippeddQty
                    ShippedQty = objSupplierCustomer.GetMGTShippedQTY(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Shipped Qty On Time
                    ShippedQtyOnTime = objSupplierCustomer.GetMGTShippedQTYOnTime(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Booked For Pos
                    BookedForPos = objSupplierCustomer.GetMGTBookedForPOs(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Total Shipped Pos
                    TotalShippedPos = objSupplierCustomer.GetMGTTotalShippedPos(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '----Shipped Pos OnTime
                    ShippedPosOnTime = objSupplierCustomer.GetMGTShippedPOsOnTime(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    '-----Booked Turnover
                    dtbookedturnover = objSupplierCustomer.BookeedTurnOver(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
                    If dtbookedturnover.Rows.Count = 0 Then
                        SumOfBookedTurnOver = 0
                    Else
                        SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                    End If
                    '-----Shipped Turnover
                    dtShippedturnover = objSupplierCustomer.ShippeedTurnOver(Fromdate, ToDate, SupplierID, CustomerID, MarchandID)
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
    Sub GetSupplierCustomerReport1()
        Try
            Dim dtMgtSupplier, dtMgtCus As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            'Dim Fromdate As Date = txtDateFrom.SelectedDate
            'Dim ToDate As Date = txtDateTo.SelectedDate
            Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim CustomerID As String = cmbCustomer.SelectedValue
            'Dim MarchandName As String = cmbMarchand.SelectedItem.Text
            Dim x As Integer
            dtMgtCus = objSupplierCustomer.GetMgtCusNew(Fromdate, ToDate, CustomerID)
            For x = 0 To dtMgtCus.Rows.Count - 1
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

                Dim CustomerIDD As Long = dtMgtCus.Rows(x)("CustomerID")
                Dim CustomerName As String = dtMgtCus.Rows(x)("CustomerName")

                Dim i As Integer
                Dim dtSupMr As New DataTable
                dtSupMr = objSupplierCustomer.GetMgtSupMar(Fromdate, ToDate, CustomerIDD)
                For i = 0 To dtSupMr.Rows.Count - 1
                    If dtSupMr.Rows.Count = 0 Then

                    Else
                        Dim Marchandid As Long = dtSupMr.Rows(i)("Marchandid")
                        Dim SupplierID As Long = dtSupMr.Rows(i)("venderlibraryid")

                        Dim SupplierName As String = dtSupMr.Rows(i)("VenderName")
                        Dim MarchandName As String = dtSupMr.Rows(i)("username")

                        '---BookedQty
                        BookedQty = objSupplierCustomer.GetMGTBookedQTY11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '---ShippeddQty
                        ShippedQty = objSupplierCustomer.GetMGTShippedQTY11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '----Shipped Qty On Time
                        ShippedQtyOnTime = objSupplierCustomer.GetMGTShippedQTYOnTime11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '----Booked For Pos
                        BookedForPos = objSupplierCustomer.GetMGTBookedForPOs11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '----Total Shipped Pos
                        TotalShippedPos = objSupplierCustomer.GetMGTTotalShippedPos11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '----Shipped Pos OnTime
                        ShippedPosOnTime = objSupplierCustomer.GetMGTShippedPOsOnTime11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        '-----Booked Turnover
                        dtbookedturnover = objSupplierCustomer.BookeedTurnOver11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        If dtbookedturnover.Rows.Count = 0 Then
                            SumOfBookedTurnOver = 0
                        Else
                            SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                        End If
                        '-----Shipped Turnover
                        dtShippedturnover = objSupplierCustomer.ShippeedTurnOver11(Fromdate, ToDate, SupplierID, CustomerIDD, Marchandid)
                        If dtShippedturnover.Rows.Count = 0 Then
                            SumOfShippedTurnOver = 0
                        Else
                            SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                        End If
                        '----------------------------------------------

                        If BookedQty = 0 Then
                            ProductionPerformance = 0
                        Else
                            ProductionPerformance = (ShippedQty * 100) / BookedQty ' (ShippedQtyOnTime * 100) / BookedQty
                            If ProductionPerformance > 100 Then
                                ProductionPerformance = 100
                            Else
                                ProductionPerformance = ProductionPerformance
                            End If
                        End If

                        If BookedForPos = 0 Then
                            DeliverPerformance = 0
                        Else
                            DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                        End If
                        '----For Save
                        With objSupplierCustomer
                            .SCID = 0
                            .CreationDate = Today.Date
                            .MarchandID = Marchandid
                            .MarchandName = MarchandName
                            .CustomerID = CustomerIDD
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
        Catch ex As Exception

        End Try
    End Sub
    'Sub GetSupplierCustomerReport1()
    '    Dim dtMgtSupplier As New DataTable
    '    Dim dtBookQty As New DataTable
    '    Dim dtbookedturnover As New DataTable
    '    Dim dtShippedturnover As New DataTable
    '    Dim dtTimelyShipped As New DataTable
    '    Dim dtTotalPos As New DataTable
    '    Dim Fromdate As Date = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
    '    Dim ToDate As Date = txtDateTo.SelectedDate
    '    Dim CustomerID As Long = cmbCustomer.SelectedValue
    '    'Dim MarchandName As String = cmbMarchand.SelectedItem.Text
    '    Dim x As Integer
    '    dtMgtSupplier = objSupplierCustomer.GetMgtSupplierData1(Fromdate, ToDate, CustomerID)
    '    For x = 0 To dtMgtSupplier.Rows.Count - 1
    '        Dim BookedQty As Decimal = 0
    '        Dim ShippedQty As Decimal = 0
    '        Dim ShippedQtyOnTime As Decimal = 0
    '        Dim BookedForPos As Decimal = 0
    '        Dim TotalShippedPos As Decimal = 0
    '        Dim ShippedPosOnTime As Decimal = 0
    '        Dim BookedTurnOver As Decimal = 0
    '        Dim SumOfBookedTurnOver As Decimal = 0
    '        Dim ShippedTurnOver As Decimal = 0
    '        Dim SumOfShippedTurnOver As Decimal = 0
    '        Dim DeliverPerformance As Decimal = 0
    '        Dim ProductionPerformance As Decimal = 0
    '        Dim SupplierID As Long = dtMgtSupplier.Rows(x)("venderlibraryid")
    '        Dim SupplierName As String = dtMgtSupplier.Rows(x)("VenderName")
    '        Dim i As Integer
    '        Dim dtCustomer As New DataTable
    '        dtCustomer = objSupplierCustomer.GetMgtCustomerData1(Fromdate, ToDate, SupplierID, CustomerID)
    '        For i = 0 To dtCustomer.Rows.Count - 1
    '            If dtCustomer.Rows.Count = 0 Then

    '            Else
    '                'Dim CustomerID As Long = dtCustomer.Rows(i)("CustomerID")
    '                Dim CustomerName As String = dtCustomer.Rows(i)("CustomerName")
    '                '---BookedQty
    '                BookedQty = objSupplierCustomer.GetMGTBookedQTY1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '---ShippeddQty
    '                ShippedQty = objSupplierCustomer.GetMGTShippedQTY1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '----Shipped Qty On Time
    '                ShippedQtyOnTime = objSupplierCustomer.GetMGTShippedQTYOnTime1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '----Booked For Pos
    '                BookedForPos = objSupplierCustomer.GetMGTBookedForPOs1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '----Total Shipped Pos
    '                TotalShippedPos = objSupplierCustomer.GetMGTTotalShippedPos1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '----Shipped Pos OnTime
    '                ShippedPosOnTime = objSupplierCustomer.GetMGTShippedPOsOnTime1(Fromdate, ToDate, SupplierID, CustomerID)
    '                '-----Booked Turnover
    '                dtbookedturnover = objSupplierCustomer.BookeedTurnOver1(Fromdate, ToDate, SupplierID, CustomerID)
    '                If dtbookedturnover.Rows.Count = 0 Then
    '                    SumOfBookedTurnOver = 0
    '                Else
    '                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
    '                End If
    '                '-----Shipped Turnover
    '                dtShippedturnover = objSupplierCustomer.ShippeedTurnOver1(Fromdate, ToDate, SupplierID, CustomerID)
    '                If dtShippedturnover.Rows.Count = 0 Then
    '                    SumOfShippedTurnOver = 0
    '                Else
    '                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
    '                End If
    '                '----------------------------------------------

    '                If BookedQty = 0 Then
    '                    ProductionPerformance = 0
    '                Else
    '                    ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
    '                    If ProductionPerformance > 100 Then
    '                        ProductionPerformance = 100
    '                    Else
    '                        ProductionPerformance = ProductionPerformance
    '                    End If
    '                End If

    '                If BookedForPos = 0 Then
    '                    DeliverPerformance = 0
    '                Else
    '                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
    '                End If
    '                '----For Save
    '                With objSupplierCustomer
    '                    .SCID = 0
    '                    .CreationDate = Today.Date
    '                    .MarchandID = 0
    '                    .MarchandName = ""
    '                    .CustomerID = CustomerID
    '                    .CustomerName = CustomerName
    '                    .SupplierID = SupplierID
    '                    .SupplierName = SupplierName
    '                    .BookedQuantity = BookedQty
    '                    .ShippedQuantity = ShippedQty
    '                    .BookedTurnOver = SumOfBookedTurnOver
    '                    .ShippedTurnOver = SumOfShippedTurnOver
    '                    .DeliveryPerformance = DeliverPerformance
    '                    .ProductionPerformance = ProductionPerformance
    '                    .ShippedQuantityOnTime = ShippedQtyOnTime
    '                    .BookedForPOs = BookedForPos
    '                    .TotalShippedPOs = TotalShippedPos
    '                    .ShippedPOsOnTime = ShippedPosOnTime
    '                    .PeriodicType = cmbPeriodicType.SelectedItem.Text
    '                    .SaveSuplierCustomer()
    '                End With
    '            End If
    '        Next
    '    Next
    'End Sub
    Sub BindMarchand()
        Dim dtMarchand As New DataTable
        dtMarchand = objSupplierCustomer.GetMarchand111
        cmbMarchand.DataSource = dtMarchand
        cmbMarchand.DefaultItem.Text = "Select Merchant"
        cmbMarchand.DataTextField = "UserName"
        cmbMarchand.DataValueField = "MarchandID"
        cmbMarchand.DataBind()
    End Sub
    Protected Sub cmbReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbReportType.SelectedIndexChanged
        Try
            If cmbReportType.SelectedValue = 0 Then
                cmbMarchand.Visible = True
                lblh.Text = "Marchant:"
                cmbCustomer.Visible = False

            ElseIf cmbReportType.SelectedValue = 1 Then
                cmbMarchand.Visible = False
                lblh.Text = "Customer:"
                cmbCustomer.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Dim dtMarchand As New DataTable
        dtMarchand = objSupplierCustomer.GetCC
        cmbCustomer.DataSource = dtMarchand
        cmbCustomer.DefaultItem.Text = "All Customer"
        cmbCustomer.DataTextField = "customerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()

    End Sub
End Class
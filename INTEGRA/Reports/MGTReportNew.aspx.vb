Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class MGTReportNew
    Inherits System.Web.UI.Page
    Dim objpurchaseOrder As New PurchaseOrder
    Dim objMGTSupplier As New MGTSupplier
    Dim objMGTCustomer As New MGTCustomer
    Dim ObjClaimDetail As New POClaimDetail
    Dim objMGTMarchand As New MGTMarchand
    Dim objMGTECP As New MGTECP
    Dim objSQLManager As SQLManager
    Dim objBDepartmentAnalysis As New BuyingDepartmentAnalysis
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Turn Over & Commission")
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

            If cmbreporttype.SelectedItem.Text = "Customer Vise" Then
                objMGTCustomer.TruncateTable()
                GetCustomerWiseReport()
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/MGTCustomerViseNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MGT_Customervise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            ElseIf cmbreporttype.SelectedItem.Text = "Supplier Vise" Then
                objMGTSupplier.TruncateTable()
                GetSupplierWiseReport()
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/MGTSupplierViseNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MGT_Suppliervise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            ElseIf cmbreporttype.SelectedItem.Text = "Merchandiser Vise" Then
                objMGTMarchand.TruncateTable()
                GetMerchandiserWiseReport()

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/MGTMerchandiserViseNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MGT_Merchandiservise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            ElseIf cmbreporttype.SelectedItem.Text = "TDG Vise" Then
                objMGTECP.TruncateTable()
                GetTDGWiseReport()
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/MGTECPViseNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MGT_TDGvise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            ElseIf cmbreporttype.SelectedItem.Text = "Buying Department Analysis" Then
                objBDepartmentAnalysis.TruncateTable()
                GetBuyingDepartmentAnalysis()
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/BuyingDepartmentAnalysis.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Buying_Department_Analysis_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            ElseIf cmbreporttype.SelectedItem.Text = "Article Vise" Then
                objMGTCustomer.TruncateTable()
                GetArticleWiseReport()
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/MGTCustomerArticleVise.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MGT_Article_Customervise_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
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
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub GetCustomerWiseReport()
        Try
            Dim dtMgtCustomer As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            'Dim Fromdate As Date = txtDateFrom.SelectedDate
            'Dim ToDate As Date = txtDateTo.SelectedDate
            Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim x As Integer
            dtMgtCustomer = objpurchaseOrder.GetMgtCustomerData()
            For x = 0 To dtMgtCustomer.Rows.Count - 1
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
                Dim CustomerID As Long = dtMgtCustomer.Rows(x)("CustomerID")
                Dim CustomerName As String = dtMgtCustomer.Rows(x)("CustomerName")
                '---BookedQty
                ' BookedQty = objpurchaseOrder.GetMGTBookedQTY(Fromdate, ToDate, CustomerID)
                BookedQty = objpurchaseOrder.GetMGTBookedQTYNew(Fromdate, ToDate, CustomerID)

                '---ShippeddQty
                ShippedQty = objpurchaseOrder.GetMGTShippedQTYNew(Fromdate, ToDate, CustomerID)
                '----Shipped Qty On Time
                ShippedQtyOnTime = objpurchaseOrder.GetMGTShippedQTYOnTimeNew(Fromdate, ToDate, CustomerID)
                '----Booked For Pos
                BookedForPos = objpurchaseOrder.GetMGTBookedForPOsNew(Fromdate, ToDate, CustomerID)
                '----Total Shipped Pos
                TotalShippedPos = objpurchaseOrder.GetMGTTotalShippedPosNew(Fromdate, ToDate, CustomerID)
                '----Shipped Pos OnTime
                ShippedPosOnTime = objpurchaseOrder.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, CustomerID)
                '----Booked TurOver
                dtbookedturnover = objpurchaseOrder.GetMGTBookedTurOverNew(Fromdate, ToDate, CustomerID)
                Dim xBookedTurnOver As Integer = 0
                'For xBookedTurnOver = 0 To dtbookedturnover.Rows.Count - 1
                '    BookedTurnOver = dtbookedturnover.Rows(xBookedTurnOver)("BookedTurnOver")
                '    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                'Next
                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objpurchaseOrder.GetMGTShippedTurOverNew(Fromdate, ToDate, CustomerID)
                Dim xShippedturnOver As Integer = 0
                For xShippedturnOver = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShippedturnOver)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If

                '---BookedCommission

                Dim TotalBookedComm As Decimal = 0
                Dim dtcommission As New DataTable
                'Dim BookComm As Decimal = objMGTSupplier.GetBookedCommission(Fromdate, ToDate, SupplierID)
                Dim BookComm As Decimal = objMGTCustomer.GetMGTBookedCommNew2(Fromdate, ToDate, CustomerID)
                TotalBookedComm = BookComm

                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                Dim ShippedComm As Decimal = dtMgtCustomer.Rows(x)("Commission")
                TotalShippedComm = SumOfShippedTurnOver * ShippedComm / 100
                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objpurchaseOrder.GetMGTClaiPcsNew(Fromdate, ToDate, CustomerID)

                ''-----TotalPOs

                Dim DeliverPerformance As Decimal

                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP
                Dim ProductionPerformance As Decimal = 0
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    'ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                    ProductionPerformance = (ShippedQty * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                '----For Save
                With objMGTCustomer
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .CustomerId = CustomerID
                    .CustomerName = CustomerName
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    .NoOfClaimed = ClaimedPcs
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    If ProductionPerformance > 100 Then
                        .ProductionPerformance = 100
                    Else
                        .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    End If
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGT()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetSupplierWiseReport()
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
        Dim x As Integer
        dtMgtSupplier = objMGTSupplier.GetMgtSupplierData()
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
            Dim ProductionPerformance As Decimal = 0

            Dim SupplierID As Long = dtMgtSupplier.Rows(x)("venderlibraryid")
            Dim SupplierName As String = dtMgtSupplier.Rows(x)("VenderName")
            '---BookedQty
            BookedQty = objMGTSupplier.GetMGTBookedQTYNew(Fromdate, ToDate, SupplierID)
            '---ShippeddQty
            ShippedQty = objMGTSupplier.GetMGTShippedQTYNew(Fromdate, ToDate, SupplierID)
            '----Shipped Qty On Time
            ShippedQtyOnTime = objMGTSupplier.GetMGTShippedQTYOnTimeNew(Fromdate, ToDate, SupplierID)
            '----Booked For Pos
            BookedForPos = objMGTSupplier.GetMGTBookedForPOsNew(Fromdate, ToDate, SupplierID)
            '----Total Shipped Pos
            TotalShippedPos = objMGTSupplier.GetMGTTotalShippedPosNew(Fromdate, ToDate, SupplierID)
            '----Shipped Pos OnTime
            ShippedPosOnTime = objMGTSupplier.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, SupplierID)
            '----Booked TurOver
            dtbookedturnover = objMGTSupplier.GetMGTBookedTurOverNew(Fromdate, ToDate, SupplierID)
            'Dim aa As Decimal = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
            Dim xbooktrn As Integer = 0
            'For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
            '    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
            '    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
            'Next
            If dtbookedturnover.Rows.Count = 0 Then
                SumOfBookedTurnOver = 0
            Else
                SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
            End If

            '----Shipped TurOver
            dtShippedturnover = objMGTSupplier.GetMGTShippedTurOverNew(Fromdate, ToDate, SupplierID)
            Dim xShipptrn As Integer = 0
            'For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
            '    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
            '    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
            'Next
            If dtShippedturnover.Rows.Count = 0 Then
                SumOfShippedTurnOver = 0
            Else
                SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
            End If

            '---BookedCommission
            Dim TotalBookedComm As Decimal = 0
            Dim dtcommission As New DataTable
            'Dim BookComm As Decimal = objMGTSupplier.GetBookedCommission(Fromdate, ToDate, SupplierID)
            Dim BookComm As Decimal = 0

            dtcommission = objMGTSupplier.GetMGTBookedCommNew2(Fromdate, ToDate, SupplierID)
            'For BookComm = 0 To dtcommission.Rows.Count - 1
            '    TotalBookedComm = TotalBookedComm + dtcommission.Rows(BookComm)("BookedTurnOver")
            'Next
            If dtcommission.Rows.Count = 0 Then
                TotalBookedComm = 0
            Else
                TotalBookedComm = dtcommission.Compute("Sum(BookedTurnOver)", "")
            End If
            ' TotalBookedComm = BookComm
            '---ShippedCommission
            Dim TotalShippedComm As Decimal
            'Dim ShippedComm As Decimal = objMGTSupplier.GetBookedCommission(Fromdate, ToDate, SupplierID)
            Dim ShippedComm As Decimal = objMGTSupplier.GetMGTShippedCommNew2(Fromdate, ToDate, SupplierID)
            TotalShippedComm = ShippedComm

            '-----ClaimPcs
            Dim ClaimedPcs As Decimal
            '---check cover direct val or not then get in datatable
            ClaimedPcs = objMGTSupplier.GetMGTClaiPcsNew(Fromdate, ToDate, SupplierID)

            ''-----TotalPOs
            'Dim TotalPos As Integer
            ''---check cover direct val or not then get in datatable
            'TotalPos = objMGTSupplier.GetMGTTotalPos(Fromdate, ToDate, SupplierID)

            ''----Timely Shipped
            'Dim POIDIncargoCount As Integer = 0
            Dim DeliverPerformance As Decimal
            'Dim xPos As Integer
            'dtTotalPos = objMGTSupplier.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, SupplierID)
            'If cmbOF.SelectedItem.Text = "ETD" Then
            '    For xPos = 0 To dtTotalPos.Rows.Count - 1
            '        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
            '        dtTimelyShipped = objMGTSupplier.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
            '        If dtTimelyShipped.Rows.Count > 0 Then
            '            POIDIncargoCount = POIDIncargoCount + 1
            '        End If
            '    Next
            'Else
            '    Dim ToDateETA As Date = txtDateTo.SelectedDate.Value.AddDays(28)
            '    For xPos = 0 To dtTotalPos.Rows.Count - 1
            '        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
            '        dtTimelyShipped = objMGTSupplier.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDateETA, POIDCount)
            '        If dtTimelyShipped.Rows.Count > 0 Then
            '            POIDIncargoCount = POIDIncargoCount + 1
            '        End If
            '    Next
            'End If
            'PP
            If BookedQty = 0 Then
                ProductionPerformance = 0
            Else
                ' ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                ProductionPerformance = (ShippedQty * 100) / BookedQty
                If ProductionPerformance > 100 Then
                    ProductionPerformance = 100
                Else
                    ProductionPerformance = ProductionPerformance
                End If
            End If

            '----DeliveryCode

            If BookedForPos = 0 Then
                DeliverPerformance = 0
            Else
                DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
            End If

            '----BackLogCleared
            Dim BackLogCleared As Decimal = 0
            BackLogCleared = ShippedQty - ShippedQtyOnTime
            '----For Save
            With objMGTSupplier
                .MGTId = 0
                .CreationDate = Date.Now
                .SupplierID = SupplierID
                .SupplierName = SupplierName
                .BookedQuantity = BookedQty
                .ShippedQuantity = ShippedQty
                .BookedTurnOver = SumOfBookedTurnOver
                .ShippedTurnOver = SumOfShippedTurnOver
                .BookedCommission = TotalBookedComm
                .ShippedCommission = TotalShippedComm
                .NoOfClaimed = ClaimedPcs
                ' .TotalPos = TotalPos
                ' .TimelyShipped = POIDIncargoCount
                .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                .ShippedPOsOnTime = ShippedPosOnTime
                .BookedForPOs = BookedForPos
                .ShippedQuantityOnTime = ShippedQtyOnTime
                .TotalShippedPOs = TotalShippedPos
                .BackLogCleared = BackLogCleared
                .SaveMGTSupplier()
            End With
        Next

    End Sub
    Sub GetMerchandiserWiseReport()
        Try
            Dim dtMgtMarchand As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            'Dim Fromdate As Date = txtDateFrom.SelectedDate
            'Dim ToDate As Date = txtDateTo.SelectedDate
            Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim x As Integer
            dtMgtMarchand = objMGTMarchand.GetMgtMarchandData()
            For x = 0 To dtMgtMarchand.Rows.Count - 1
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
                Dim ProductionPerformance As Decimal = 0
                Dim MarchandID As Long = dtMgtMarchand.Rows(x)("UserID")
                Dim MarchandName As String = dtMgtMarchand.Rows(x)("UserName")
                '---BookedQty
                BookedQty = objMGTMarchand.GetMGTBookedQTYNew(Fromdate, ToDate, MarchandID)
                '---ShippeddQty
                ShippedQty = objMGTMarchand.GetMGTShippedQTYNew(Fromdate, ToDate, MarchandID)
                '----Shipped Qty On Time
                ShippedQtyOnTime = objMGTMarchand.GetMGTShippedQTYOnTimeNew(Fromdate, ToDate, MarchandID)
                '----Booked For Pos
                BookedForPos = objMGTMarchand.GetMGTBookedForPOsNew(Fromdate, ToDate, MarchandID)
                '----Total Shipped Pos
                TotalShippedPos = objMGTMarchand.GetMGTTotalShippedPosNew(Fromdate, ToDate, MarchandID)
                '----Shipped Pos OnTime
                ShippedPosOnTime = objMGTMarchand.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, MarchandID)

                '----Booked TurOver
                dtbookedturnover = objMGTMarchand.GetMGTBookedTurOverNew(Fromdate, ToDate, MarchandID)
                Dim xbooktrn As Integer
                'For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                '    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                '    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                'Next
                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objMGTMarchand.GetMGTShippedTurOverNew(Fromdate, ToDate, MarchandID)
                Dim xShipptrn As Integer
                'For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                '    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                '    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                'Next
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If
                '---BookedCommission
                Dim dtcommission As New DataTable
                Dim xcount As Integer = 0
                Dim TotalBookedComm As Decimal = 0
                dtcommission = objMGTMarchand.GetMGTBookedCommNew2(Fromdate, ToDate, MarchandID)
                Dim BookComm As Decimal = 0
                'For xcount = 0 To dtcommission.Rows.Count - 1
                '    BookComm = dtcommission.Rows(xcount)("BookedTurnOver")
                '    TotalBookedComm = TotalBookedComm + BookComm
                'Next

                If dtcommission.Rows.Count = 0 Then
                    TotalBookedComm = 0
                Else
                    TotalBookedComm = dtcommission.Compute("Sum(BookedTurnOver)", "")
                End If
                '---ShippedCommission
                Dim TotalShippedComm As Decimal = 0
                TotalShippedComm = objMGTMarchand.GetMGTShippedCommNew2(Fromdate, ToDate, MarchandID)
                Dim DeliverPerformance As Decimal
                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ' ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                    ProductionPerformance = (ShippedQty * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                With objMGTMarchand
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .MarchandID = MarchandID
                    .MarchandName = MarchandName
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    ' .NoOfClaimed = ClaimedPcs
                    '   .TotalPos = TotalPos
                    '  .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    If ProductionPerformance > 100 Then
                        .ProductionPerformance = 100
                    Else
                        .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    End If
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGTMarchand()
                End With

            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub GetTDGWiseReport()
        Try
            Dim dtMgtECP As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            'Dim Fromdate As Date = txtDateFrom.SelectedDate
            'Dim ToDate As Date = txtDateTo.SelectedDate
            Dim Fromdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim x As Integer
            dtMgtECP = objMGTECP.GetMgtECPData()
            For x = 0 To dtMgtECP.Rows.Count - 1
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
                Dim ProductionPerformance As Decimal = 0
                Dim ECPDivistion As String = dtMgtECP.Rows(x)("ECPDivistion")
                '---BookedQty
                BookedQty = objMGTECP.GetMGTBookedQTYNew(Fromdate, ToDate, ECPDivistion)
                '---ShippeddQty
                ShippedQty = objMGTECP.GetMGTShippedQTYNew(Fromdate, ToDate, ECPDivistion)
                '----Shipped Qty On Time
                ShippedQtyOnTime = objMGTECP.GetMGTShippedQTYOnTimeNew(Fromdate, ToDate, ECPDivistion)
                '----Booked For Pos
                BookedForPos = objMGTECP.GetMGTBookedForPOsNew(Fromdate, ToDate, ECPDivistion)
                '----Total Shipped Pos
                TotalShippedPos = objMGTECP.GetMGTTotalShippedPosNew(Fromdate, ToDate, ECPDivistion)
                '----Shipped Pos OnTime
                ShippedPosOnTime = objMGTECP.GetMGTShippedPOsOnTimeNew(Fromdate, ToDate, ECPDivistion)
                '----Booked TurOver
                dtbookedturnover = objMGTECP.GetMGTBookedTurOverNew(Fromdate, ToDate, ECPDivistion)
                Dim xbooktrn As Integer
                'For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                '    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                '    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                'Next

                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objMGTECP.GetMGTShippedTurOverNew(Fromdate, ToDate, ECPDivistion)
                Dim xShipptrn As Integer
                'For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                '    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                '    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                'Next
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If
                '---BookedCommission
                Dim TotalBookedComm As Decimal = 0
                Dim dtcommission As New DataTable
                Dim xcount As Integer = 0
                dtcommission = objMGTECP.GetMGTBookedCommNew2(Fromdate, ToDate, ECPDivistion)
                Dim BookComm As Decimal = 0
                'For xcount = 0 To dtcommission.Rows.Count - 1
                '    BookComm = dtcommission.Rows(xcount)("BookedTurnOver")
                '    TotalBookedComm = TotalBookedComm + BookComm
                'Next
                If dtcommission.Rows.Count = 0 Then
                    TotalBookedComm = 0
                Else
                    TotalBookedComm = dtcommission.Compute("Sum(BookedTurnOver)", "")
                End If
                '---ShippedCommission
                Dim TotalShippedComm As Decimal = 0
                Dim ShippedComm As Decimal = objMGTECP.GetMGTShippedCommNew2(Fromdate, ToDate, ECPDivistion)
                TotalShippedComm = ShippedComm
                '----DeliveryPerformance
                Dim DeliverPerformance As Decimal = 0
                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    'ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                    ProductionPerformance = (ShippedQty * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                Dim ProductGroup As String = objMGTECP.GetProductGroupNew(Fromdate, ToDate, ECPDivistion)
                Dim MarchandID As String = objMGTECP.GetProductGroupNew(Fromdate, ToDate, ECPDivistion)
                '----For Save
                With objMGTECP
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .ECPDivistion = ECPDivistion
                    .UserID = MarchandID
                    .ProductGroup = ProductGroup
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    If ProductionPerformance > 100 Then
                        .ProductionPerformance = 100
                    Else
                        .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    End If
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGTECP()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetBuyingDepartmentAnalysis()
        Try
            Dim dtCustomer As New DataTable
            Dim dtEKNumber As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedTurnOver As New DataTable
            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            dtCustomer = getCustomer()
            For i = 0 To dtCustomer.Rows.Count - 1
                Dim SumOfBookedTurnOver As String = 0
                Dim SumOfShippedTurnOver As String = 0
                Dim ShippedQtyOnTime As Decimal = 0
                Dim BookedForPos As Decimal = 0
                Dim ShippedPosOnTime As Decimal = 0
                Dim BookedQty As Decimal = 0
                Dim CustomerID As Long = dtCustomer.Rows(i)("CustomerID")
                dtEKNumber = objBDepartmentAnalysis.GetEKNumber(CustomerID)
                For x = 0 To dtEKNumber.Rows.Count - 1
                    Dim EKNumber As String = dtEKNumber.Rows(x)("EKnumber")
                    dtbookedturnover = objBDepartmentAnalysis.BookeedTurnOver(Fromdate, ToDate, CustomerID, EKNumber)
                    If dtbookedturnover.Rows.Count = 0 Then
                        SumOfBookedTurnOver = 0
                    Else
                        SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                    End If

                    dtShippedTurnOver = objBDepartmentAnalysis.ShippeedTurnOver(Fromdate, ToDate, CustomerID, EKNumber)
                    If dtShippedTurnOver.Rows.Count = 0 Then
                        SumOfShippedTurnOver = 0
                    Else
                        SumOfShippedTurnOver = dtShippedTurnOver.Compute("Sum(ShippedTurOver)", "")
                    End If

                    '----Shipped Quantity On Time
                    ShippedQtyOnTime = objBDepartmentAnalysis.GetMGTShippedQTYOnTime(Fromdate, ToDate, CustomerID, EKNumber)
                    '----Booked For Pos
                    BookedForPos = objBDepartmentAnalysis.GetMGTBookedForPOs(Fromdate, ToDate, CustomerID, EKNumber)
                    '----Shipped Pos OnTime
                    ShippedPosOnTime = objBDepartmentAnalysis.GetMGTShippedPOsOnTime(Fromdate, ToDate, CustomerID, EKNumber)
                    '---BookedQty
                    BookedQty = objBDepartmentAnalysis.GetMGTBookedQTY(Fromdate, ToDate, CustomerID, EKNumber)

                    '----------------------------------------------
                    '----Shipped Quantity On Time EKNumber Vise
                    'Dim ShippedQtyOnTimeEK As Decimal = 0
                    'Dim BookedForPosEK As Decimal = 0
                    'Dim ShippedPosOnTimeEK As Decimal = 0
                    'Dim BookedQtyEK As Decimal = 0
                    'ShippedQtyOnTimeEK = objBDepartmentAnalysis.GetMGTShippedQTYOnTimeEK(Fromdate, ToDate, CustomerID, EKNumber)
                    ''----Booked For Pos EKNumber Vise
                    'BookedForPosEK = objBDepartmentAnalysis.GetMGTBookedForPOsEK(Fromdate, ToDate, CustomerID, EKNumber)
                    ''----Shipped Pos OnTime EKNumber Vise
                    'ShippedPosOnTimeEK = objBDepartmentAnalysis.GetMGTShippedPOsOnTimeEK(Fromdate, ToDate, CustomerID, EKNumber)
                    ''---BookedQty EKNumber Vise
                    'BookedQtyEK = objBDepartmentAnalysis.GetMGTBookedQTYEK(Fromdate, ToDate, CustomerID, EKNumber)

                    Dim DeliverPerformance As Decimal = 0
                    If BookedForPos = 0 Then
                        DeliverPerformance = 0
                    Else
                        DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                    End If

                    'PP
                    Dim ProductionPerformance As Decimal = 0
                    If BookedQty = 0 Then
                        ProductionPerformance = 0
                    Else
                        ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                    End If
                    With objBDepartmentAnalysis
                        .BuyingDepartmentAnalysisID = 0
                        .CustomerID = dtCustomer.Rows(i)("CustomerID")
                        .CustomerName = dtCustomer.Rows(i)("CustomerName")
                        .EKNumber = dtEKNumber.Rows(x)("EKnumber")
                        .BookedTurnOver = SumOfBookedTurnOver
                        .ShippedTurnOver = SumOfShippedTurnOver
                        .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                        .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                        .ShippedQuantityOnTime = ShippedQtyOnTime
                        .BookedQuantity = BookedQty
                        .ShippedPOsOnTime = ShippedPosOnTime
                        .BookedForPOs = BookedForPos
                        .SaveBuyingDepartmentAnalysis()
                    End With
                Next

            Next

        Catch ex As Exception

        End Try
    End Sub
    Public Function getCustomer() As DataTable
        Dim dtCust As DataTable
        Try
            dtCust = objBDepartmentAnalysis.GetCustomer()

        Catch ex As Exception

        End Try
        Return dtCust
    End Function
    Sub ETAvsETD()
        Try
            Dim dtMgtMarchand As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            Dim x As Integer
            dtMgtMarchand = objMGTMarchand.GetMgtMarchandData()
            For x = 0 To dtMgtMarchand.Rows.Count - 1
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
                Dim ProductionPerformance As Decimal = 0
                Dim MarchandID As Long = dtMgtMarchand.Rows(x)("UserID")
                Dim MarchandName As String = dtMgtMarchand.Rows(x)("UserName")
                '---BookedQty
                BookedQty = objMGTMarchand.GetMGTBookedQTY(Fromdate, ToDate, MarchandID)
                '---ShippeddQty
                ShippedQty = objMGTMarchand.GetMGTShippedQTY(Fromdate, ToDate, MarchandID)
                '----Shipped Qty On Time


                ShippedQtyOnTime = objMGTMarchand.GetMGTShippedQTYOnTime(Fromdate, ToDate, MarchandID)
                '----Booked For Pos
                BookedForPos = objMGTMarchand.GetMGTBookedForPOs(Fromdate, ToDate, MarchandID)
                '----Total Shipped Pos
                TotalShippedPos = objMGTMarchand.GetMGTTotalShippedPos(Fromdate, ToDate, MarchandID)
                '----Shipped Pos OnTime
                ShippedPosOnTime = objMGTMarchand.GetMGTShippedPOsOnTimeETA(Fromdate, ToDate, MarchandID)

                '----Booked TurOver
                dtbookedturnover = objMGTMarchand.GetMGTBookedTurOver(Fromdate, ToDate, MarchandID)
                Dim xbooktrn As Integer
                'For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                '    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                '    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                'Next
                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objMGTMarchand.GetMGTShippedTurOver(Fromdate, ToDate, MarchandID)
                Dim xShipptrn As Integer
                'For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                '    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                '    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                'Next
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If
                '---BookedCommission
                Dim dtcommission As New DataTable
                Dim xcount As Integer = 0
                Dim TotalBookedComm As Decimal = 0
                dtcommission = objMGTMarchand.GetMGTBookedCommNew(Fromdate, ToDate, MarchandID)
                Dim BookComm As Decimal = 0
                'For xcount = 0 To dtcommission.Rows.Count - 1
                '    BookComm = dtcommission.Rows(xcount)("BookedTurnOver")
                '    TotalBookedComm = TotalBookedComm + BookComm
                'Next

                If dtcommission.Rows.Count = 0 Then
                    TotalBookedComm = 0
                Else
                    TotalBookedComm = dtcommission.Compute("Sum(BookedTurnOver)", "")
                End If
                '---ShippedCommission
                Dim TotalShippedComm As Decimal = 0
                TotalShippedComm = objMGTMarchand.GetMGTShippedCommNew(Fromdate, ToDate, MarchandID)
                Dim DeliverPerformance As Decimal = 0

                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP

                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                With objMGTMarchand
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .MarchandID = MarchandID
                    .MarchandName = MarchandName
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    ' .NoOfClaimed = ClaimedPcs
                    '   .TotalPos = TotalPos
                    '  .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGTMarchand()
                End With

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetArticleWiseReport()
        Try
            Dim dtMgtCustomer As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            Dim x As Integer
            dtMgtCustomer = objpurchaseOrder.GetMgtCustomerArticleData()
            For x = 0 To dtMgtCustomer.Rows.Count - 1
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
                Dim CustomerID As Long = dtMgtCustomer.Rows(x)("CustomerID")
                Dim CustomerName As String = dtMgtCustomer.Rows(x)("CustomerName")
                '---BookedQty
                BookedQty = objpurchaseOrder.GetMGTBookedQTY(Fromdate, ToDate, CustomerID)

                '---ShippeddQty
                ShippedQty = objpurchaseOrder.GetMGTShippedQTY(Fromdate, ToDate, CustomerID)
                '----Shipped Qty On Time
                ShippedQtyOnTime = objpurchaseOrder.GetMGTShippedQTYOnTime(Fromdate, ToDate, CustomerID)
                '----Booked For Pos
                Dim dtBokNo As DataTable = objpurchaseOrder.GetMGTBookedArticlePOs(Fromdate, ToDate, CustomerID)
                If dtBokNo.Rows.Count > 0 Then
                    BookedForPos = dtBokNo.Compute("SUM(TotalBookedPos)", "")
                Else
                    BookedForPos = 0
                End If

                '----Total Shipped Pos
                Dim dtShipNo As DataTable = objpurchaseOrder.GetMGTTotalShippedArticle(Fromdate, ToDate, CustomerID)
                If dtShipNo.Rows.Count > 0 Then
                    TotalShippedPos = dtShipNo.Compute("SUM(TotalShippedPOs)", "")
                Else
                    TotalShippedPos = 0
                End If
                '----Shipped Pos OnTime
                Dim dtOnShiped As DataTable = objpurchaseOrder.GetMGTShippedArticleOnTime(Fromdate, ToDate, CustomerID)
                If dtOnShiped.Rows.Count > 0 Then
                    ShippedPosOnTime = dtOnShiped.Compute("SUM(ShippedPOsOnTime)", "")
                Else
                    ShippedPosOnTime = 0
                End If
                '----Booked TurOver
                dtbookedturnover = objpurchaseOrder.GetMGTBookedTurOver(Fromdate, ToDate, CustomerID)
                Dim xBookedTurnOver As Integer = 0

                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objpurchaseOrder.GetMGTShippedTurOver(Fromdate, ToDate, CustomerID)
                Dim xShippedturnOver As Integer = 0
                For xShippedturnOver = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShippedturnOver)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If

                '---BookedCommission

                Dim TotalBookedComm As Decimal = 0
                Dim dtcommission As New DataTable

                Dim BookComm As Decimal = objMGTCustomer.GetMGTBookedCommNew(Fromdate, ToDate, CustomerID)
                TotalBookedComm = BookComm

                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                Dim ShippedComm As Decimal = dtMgtCustomer.Rows(x)("Commission")
                TotalShippedComm = SumOfShippedTurnOver * ShippedComm / 100
                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objpurchaseOrder.GetMGTClaiPcs(Fromdate, ToDate, CustomerID)

                ''-----TotalPOs

                Dim DeliverPerformance As Decimal

                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP
                Dim ProductionPerformance As Decimal = 0
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                '----For Save
                With objMGTCustomer
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .CustomerId = CustomerID
                    .CustomerName = CustomerName
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    .NoOfClaimed = ClaimedPcs
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    If Math.Round(ProductionPerformance, 2) > 100 Then
                        .ProductionPerformance = 100
                    Else
                        .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    End If
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGT()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
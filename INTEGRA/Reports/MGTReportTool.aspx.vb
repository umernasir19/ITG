Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class MGTReportTool
    Inherits System.Web.UI.Page
    Dim objpurchaseOrder As New PurchaseOrder
    Dim objMGTSupplier As New MGTSupplier
    Dim objMGTCustomer As New MGTCustomer
    Dim ObjClaimDetail As New POClaimDetail
    Dim objMGTMarchand As New MGTMarchand
    Dim objMGTECP As New MGTECP
    Dim objSQLManager As SQLManager
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
            If cmbreporttype.SelectedItem.Text = "Customer Vise" Then
                objMGTCustomer.TruncateTable()
                GetCustomerWiseReport()

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/rtpBusinessStatisticCustomerVise.rpt"))
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

                Report.Load(Server.MapPath("..\Reports/rptBusinessStatisticsSupplierVise.rpt"))
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

                Report.Load(Server.MapPath("..\Reports/rptBusinessStatisticsMerchandisers.rpt"))
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

                Report.Load(Server.MapPath("..\Reports/rptBusinessStatisticsECPVise.rpt"))
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
            End If
        Catch ex As Exception
        Finally
            objMGTCustomer.TruncateTable()
            objMGTSupplier.TruncateTable()
            objMGTMarchand.TruncateTable()
            objMGTECP.TruncateTable()
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

            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            Dim x As Integer

            dtMgtCustomer = objpurchaseOrder.GetMgtCustomerData()
            For x = 0 To dtMgtCustomer.Rows.Count - 1
                Dim BookedQty As Decimal = 0
                Dim ShippedQty As Decimal = 0
                Dim BookedTurnOver As Decimal = 0
                Dim SumOfBookedTurnOver As Decimal = 0
                Dim ShippedTurnOver As Decimal = 0
                Dim SumOfShippedTurnOver As Decimal = 0

                Dim CustomerId As Long = dtMgtCustomer.Rows(x)("Customerid")
                Dim CustomerName As String = dtMgtCustomer.Rows(x)("CustomerName")

                '---BookedQty
                BookedQty = objpurchaseOrder.GetMGTBookedQTY(Fromdate, ToDate, CustomerId)

                '---ShippeddQty
                ShippedQty = objpurchaseOrder.GetMGTShippedQTY(Fromdate, ToDate, CustomerId)
                '----Booked TurOver
                dtbookedturnover = objpurchaseOrder.GetMGTBookedTurOver(Fromdate, ToDate, CustomerId)

                Dim xbooktrn As Integer
                For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                Next
                '----Shipped TurOver
                dtShippedturnover = objpurchaseOrder.GetMGTShippedTurOver(Fromdate, ToDate, CustomerId)
                Dim xShipptrn As Integer
                For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next

                '---BookedCommission
                Dim TotalBookedComm As Decimal
                Dim BookComm As Decimal = dtMgtCustomer.Rows(x)("Commission")
                TotalBookedComm = SumOfBookedTurnOver * BookComm / 100
                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                Dim ShippedComm As Decimal = dtMgtCustomer.Rows(x)("Commission")

                TotalShippedComm = SumOfShippedTurnOver * ShippedComm / 100

                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objpurchaseOrder.GetMGTClaiPcs(Fromdate, ToDate, CustomerId)

                '-----TotalPOs
                Dim TotalPos As Integer
                '---check cover direct val or not then get in datatable
                TotalPos = objpurchaseOrder.GetMGTTotalPos(Fromdate, ToDate, CustomerId)

                '----Timely Shipped
                Dim DeliverPerformance As Decimal
                dtTotalPos = objpurchaseOrder.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, CustomerId)
                Dim POIDIncargoCount As Integer = 0
                Dim xPos As Integer
                If cmbOF.SelectedItem.Text = "ETD" Then
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objpurchaseOrder.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                Else
                    Dim ToDateETA As Date = txtDateTo.SelectedDate.Value.AddDays(28)
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objpurchaseOrder.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDateETA, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                End If

                '----DeliveryCode
                If TotalPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (POIDIncargoCount * 100) / TotalPos
                End If


                '----For Save
                With objMGTCustomer
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .CustomerId = CustomerId
                    .CustomerName = CustomerName
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    .NoOfClaimed = ClaimedPcs
                    .TotalPos = TotalPos
                    .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = DeliverPerformance
                    .SaveMGT()
                End With

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetSupplierWiseReport()
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

            dtMgtCustomer = objMGTSupplier.GetMgtCustomerData()
            For x = 0 To dtMgtCustomer.Rows.Count - 1
                Dim BookedQty As Decimal = 0
                Dim ShippedQty As Decimal = 0
                Dim BookedTurnOver As Decimal = 0
                Dim SumOfBookedTurnOver As Decimal = 0
                Dim ShippedTurnOver As Decimal = 0
                Dim SumOfShippedTurnOver As Decimal = 0
                Dim ProductionPerformance As Decimal = 0

                Dim SupplierID As Long = dtMgtCustomer.Rows(x)("venderlibraryid")
                Dim SupplierName As String = dtMgtCustomer.Rows(x)("VenderName")

                '---BookedQty
                BookedQty = objMGTSupplier.GetMGTBookedQTY(Fromdate, ToDate, SupplierID)

                '---ShippeddQty
                ShippedQty = objMGTSupplier.GetMGTShippedQTY(Fromdate, ToDate, SupplierID)
                '----Booked TurOver
                dtbookedturnover = objMGTSupplier.GetMGTBookedTurOver(Fromdate, ToDate, SupplierID)

                Dim xbooktrn As Integer
                For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                Next
                '----Shipped TurOver
                dtShippedturnover = objMGTSupplier.GetMGTShippedTurOver(Fromdate, ToDate, SupplierID)
                Dim xShipptrn As Integer
                For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next

                '---BookedCommission
                Dim TotalBookedComm As Decimal
                Dim dtcommission As New DataTable
                'Dim BookComm As Decimal = objMGTSupplier.GetBookedCommission(Fromdate, ToDate, SupplierID)
                Dim BookComm As Decimal = objMGTSupplier.GetMGTBookedCommNew(Fromdate, ToDate, SupplierID)
                TotalBookedComm = BookComm

                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                'Dim ShippedComm As Decimal = objMGTSupplier.GetBookedCommission(Fromdate, ToDate, SupplierID)
                Dim ShippedComm As Decimal = objMGTSupplier.GetMGTShippedCommNew(Fromdate, ToDate, SupplierID)
                TotalShippedComm = ShippedComm

                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objMGTSupplier.GetMGTClaiPcs(Fromdate, ToDate, SupplierID)

                '-----TotalPOs
                Dim TotalPos As Integer
                '---check cover direct val or not then get in datatable
                TotalPos = objMGTSupplier.GetMGTTotalPos(Fromdate, ToDate, SupplierID)

                '----Timely Shipped
                Dim POIDIncargoCount As Integer = 0
                Dim DeliverPerformance As Decimal
                Dim xPos As Integer
                dtTotalPos = objMGTSupplier.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, SupplierID)
                If cmbOF.SelectedItem.Text = "ETD" Then
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTSupplier.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                Else
                    Dim ToDateETA As Date = txtDateTo.SelectedDate.Value.AddDays(28)
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTSupplier.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDateETA, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                End If
                'PP
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ProductionPerformance = (ShippedQty * 100) / BookedQty
                End If

                '----DeliveryCode
                If TotalPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (POIDIncargoCount * 100) / TotalPos
                End If
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
                    .TotalPos = TotalPos
                    .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = DeliverPerformance
                    .ProductionPerformance = ProductionPerformance
                    .SaveMGTSupplier()
                End With

            Next



        Catch ex As Exception

        End Try
    End Sub
    Sub GetMerchandiserWiseReport()
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
                Dim BookedTurnOver As Decimal = 0
                Dim SumOfBookedTurnOver As Decimal = 0
                Dim ShippedTurnOver As Decimal = 0
                Dim SumOfShippedTurnOver As Decimal = 0

                Dim MarchandID As Long = dtMgtMarchand.Rows(x)("UserID")
                Dim MarchandName As String = dtMgtMarchand.Rows(x)("UserName")

                '---BookedQty
                BookedQty = objMGTMarchand.GetMGTBookedQTY(Fromdate, ToDate, MarchandID)

                '---ShippeddQty
                ShippedQty = objMGTMarchand.GetMGTShippedQTY(Fromdate, ToDate, MarchandID)
                '----Booked TurOver
                dtbookedturnover = objMGTMarchand.GetMGTBookedTurOver(Fromdate, ToDate, MarchandID)

                Dim xbooktrn As Integer
                For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                Next
                '----Shipped TurOver
                dtShippedturnover = objMGTMarchand.GetMGTShippedTurOver(Fromdate, ToDate, MarchandID)
                Dim xShipptrn As Integer
                For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next

                '---BookedCommission
                Dim TotalBookedComm As Decimal
                Dim POCommission As Decimal = objMGTMarchand.GetMGTBookedCommNew(Fromdate, ToDate, MarchandID)
                TotalBookedComm = POCommission
                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                TotalShippedComm = objMGTMarchand.GetMGTShippedCommNew(Fromdate, ToDate, MarchandID)

                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objMGTMarchand.GetMGTClaiPcs(Fromdate, ToDate, MarchandID)

                '-----TotalPOs
                Dim TotalPos As Integer
                '---check cover direct val or not then get in datatable
                TotalPos = objMGTMarchand.GetMGTTotalPos(Fromdate, ToDate, MarchandID)

                '----Timely Shipped
                Dim DeliverPerformance As Decimal

                Dim xPos As Integer

                dtTotalPos = objMGTMarchand.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, MarchandID)
                Dim POIDIncargoCount As Integer = 0
                If cmbOF.SelectedItem.Text = "ETD" Then
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTMarchand.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next

                Else
                    Dim ToDateETA As Date = txtDateTo.SelectedDate.Value.AddDays(28)
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTMarchand.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDateETA, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                End If


                '----DeliveryCode
                If TotalPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (POIDIncargoCount * 100) / TotalPos
                End If
                '----For Save
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
                    .NoOfClaimed = ClaimedPcs
                    .TotalPos = TotalPos
                    .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = DeliverPerformance
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

            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            Dim x As Integer

            dtMgtECP = objMGTECP.GetMgtECPData()
            For x = 0 To dtMgtECP.Rows.Count - 1
                Dim BookedQty As Decimal = 0
                Dim ShippedQty As Decimal = 0
                Dim BookedTurnOver As Decimal = 0
                Dim SumOfBookedTurnOver As Decimal = 0
                Dim ShippedTurnOver As Decimal = 0
                Dim SumOfShippedTurnOver As Decimal = 0
                Dim ProductionPerformance As Decimal = 0

                Dim ECPDivistion As String = dtMgtECP.Rows(x)("ECPDivistion")

                '---BookedQty
                BookedQty = objMGTECP.GetMGTBookedQTY(Fromdate, ToDate, ECPDivistion)

                '---ShippeddQty
                ShippedQty = objMGTECP.GetMGTShippedQTY(Fromdate, ToDate, ECPDivistion)
                '----Booked TurOver
                dtbookedturnover = objMGTECP.GetMGTBookedTurOver(Fromdate, ToDate, ECPDivistion)

                Dim xbooktrn As Integer
                For xbooktrn = 0 To dtbookedturnover.Rows.Count - 1
                    BookedTurnOver = dtbookedturnover.Rows(xbooktrn)("BookedTurnOver")
                    SumOfBookedTurnOver = SumOfBookedTurnOver + BookedTurnOver
                Next
                '----Shipped TurOver
                dtShippedturnover = objMGTECP.GetMGTShippedTurOver(Fromdate, ToDate, ECPDivistion)
                Dim xShipptrn As Integer
                For xShipptrn = 0 To dtShippedturnover.Rows.Count - 1
                    ShippedTurnOver = dtShippedturnover.Rows(xShipptrn)("ShippedTurOver")
                    SumOfShippedTurnOver = SumOfShippedTurnOver + ShippedTurnOver
                Next

                '---BookedCommission
                Dim TotalBookedComm As Decimal
                Dim dtcommission As New DataTable
                Dim xcount As Integer = 0
                dtcommission = objMGTECP.GetMGTBookedCommNew(Fromdate, ToDate, ECPDivistion)
                Dim BookComm As Decimal
                For BookComm = 0 To dtcommission.Rows.Count - 1
                    BookComm = dtcommission.Rows(BookComm)("BookedTurnOver")
                    TotalBookedComm = TotalBookedComm + BookComm
                Next

                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                Dim ShippedComm As Decimal = objMGTECP.GetMGTShippedCommNew(Fromdate, ToDate, ECPDivistion)
                TotalShippedComm = ShippedComm

                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objMGTECP.GetMGTClaiPcs(Fromdate, ToDate, ECPDivistion)

                '-----TotalPOs
                Dim TotalPos As Integer
                '---check cover direct val or not then get in datatable
                TotalPos = objMGTECP.GetMGTTotalPos(Fromdate, ToDate, ECPDivistion)

                '----Timely Shipped
                Dim DeliverPerformance As Decimal

                Dim xPos As Integer

                dtTotalPos = objMGTECP.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, ECPDivistion)
                Dim POIDIncargoCount As Integer = 0
                If cmbOF.SelectedItem.Text = "ETD" Then
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTECP.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                Else
                    Dim ToDateETA As Date = txtDateTo.SelectedDate.Value.AddDays(28)
                    For xPos = 0 To dtTotalPos.Rows.Count - 1
                        Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                        dtTimelyShipped = objMGTECP.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDateETA, POIDCount)
                        If dtTimelyShipped.Rows.Count > 0 Then
                            POIDIncargoCount = POIDIncargoCount + 1
                        End If
                    Next
                End If
                'PP
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ProductionPerformance = (ShippedQty * 100) / BookedQty
                End If
                '----DeliveryCode
                If TotalPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (POIDIncargoCount * 100) / TotalPos
                End If
                Dim ProductGroup As String = objMGTECP.GetProductGroup(Fromdate, ToDate, ECPDivistion)
                Dim MarchandID As String = objMGTECP.GetProductGroup(Fromdate, ToDate, ECPDivistion)

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
                    .NoOfClaimed = ClaimedPcs
                    .TotalPos = TotalPos
                    .TimelyShipped = POIDIncargoCount
                    .DeliveryPerformance = DeliverPerformance
                    .ProductionPerformance = ProductionPerformance
                    .SaveMGTECP()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class MGT
    Inherits System.Web.UI.Page
    Dim objpurchaseOrder As New PurchaseOrder
    Dim objMGTCustomer As New MGTCustomer
    Dim ObjClaimDetail As New POClaimDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
        Try
            Dim dtMgtCustomer As New DataTable
            Dim dtBookQty As New DataTable

            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable

            Dim Fromdate As Date = txtFromDate.SelectedDate
            Dim ToDate As Date = txtToDate.SelectedDate
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

                Dim xPos As Integer

                dtTotalPos = objpurchaseOrder.GetMGTTotalPosCheckTimelyShipped(Fromdate, ToDate, CustomerId)
                Dim POIDIncargoCount As Integer = 0
                For xPos = 0 To dtTotalPos.Rows.Count - 1
                    Dim POIDCount As Integer = dtTotalPos.Rows(xPos)("POID")
                    dtTimelyShipped = objpurchaseOrder.GetMGTTotalPOsTimelyShippedSecond(Fromdate, ToDate, POIDCount)
                    If dtTimelyShipped.Rows.Count > 0 Then
                        POIDIncargoCount = POIDIncargoCount + 1
                    End If
                Next
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
End Class
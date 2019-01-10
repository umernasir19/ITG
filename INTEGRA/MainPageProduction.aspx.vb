Imports System
Imports System.Data
Imports System.Configuration
Imports Integra.EuroCentra
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Telerik.Charting
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.DataTable
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports System.Text
Imports Telerik.Web.UI
Imports System.Globalization
Public Class MainPageProduction
    Inherits System.Web.UI.Page
    Dim objPO As New PurchaseOrder
    Dim UserID As Long
    Dim HRID As Long
    Dim objUser As New User
    Dim objLeaveRequest As New HRLeaveRequest
    Dim objLeaveRequestApproval As New HRLeaveRequestApproval
    Dim objMGTCustomer As New MGTCustomer
    Dim objpurchaseOrder As New PurchaseOrder
    Dim objShippedAnalysis As New ShippedAnalysis
    Dim DepttName As String
    Dim RoleId As Long
    Dim ID As Long
    Dim Type As String
    Dim ObjIssue As New IssueMst
    Dim ObjIssueDtl As New IssueDetail
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim PORecvMasterID As Long
    Dim ObjItem As New IMSItem
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjLocation As New Location
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Dim objSizeRange As New SizeRange
    Dim objTempCustomerInventoryPosition As New TempCustomerInventoryPosition
    Dim objTempSrnoInventoryPosition As New TempSrnoInventoryPosition
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objUserConfirmation As New UserConfirmation
    Dim objTempCustomerFilter As New TempCustomerFilter
    Dim objTempPurchasingSummary As New TempPurchasingSummary
    Dim objTempStockInventory As New TempStockInventoryFinal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ID = Request.QueryString("ID")
        Type = Request.QueryString("Type")
        If Not Page.IsPostBack Then
            UserID = CLng(Session("Userid"))
            RoleId = CLng(Session("RoleId"))
            lblUserId.Text = CLng(Session("Userid"))
            Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    Chart_Chart1()
                    'Chart_Chart2()
                    Chart_Chart3()
                    'Chart_Chart4()
                    'Chart_Chart6()
                    GetUserInfo(UserID)
                Else
                    GetUserInfo(UserID)
                End If
            End If
            If UserID = 238 Then
                Response.Redirect("~/BusinessProcess/DPRNDView.aspx")
            End If
            If UserID = 245 Or UserID = 256 Or UserID = 257 Or UserID = 258 Or UserID = 259 Or UserID = 260 Or UserID = 261 Or UserID = 262 Or UserID = 263 Or UserID = 268 Or UserID = 269 Then
                Response.Redirect("~/BusinessProcess/DPRNDView.aspx")
            End If
        End If
    End Sub
    Sub Chart_Chart6()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objUser As New User
            Dim dr As DataRow
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("SupplierDatabaseId", GetType(Long))
                .Columns.Add("SupplierName", GetType(String))
                .Columns.Add("PurchaseValue", GetType(String))
                .Columns.Add("AvgDelivery", GetType(String))
            End With
            Dim dt As DataTable = objMGTCustomer.GetSupplierNameOrAmount()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim CurrentDate As Date = Date.Now
                Dim PreviousMonth As Date = CurrentDate.AddMonths(-3)
                Dim Month As String = PreviousMonth.Month
                Dim Year As String = PreviousMonth.Year
                Dim Day As String = "01"
                Dim StartDate As String = Month & "/" & Day & "/" & Year
                Dim EndDatee As Date = Date.Now
                Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                Dim Average As Decimal = 0
                Dim NoOfRows As Decimal = 0
                Dim TotalAverage As Decimal = 0
                Dim dtAmount As DataTable = objMGTCustomer.GetAmountt(dt.Rows(x)("SupplierDatabaseId"), StartDate, EndDate)
                Dim dtPO As DataTable = objMGTCustomer.GetDataForDifference(dt.Rows(x)("SupplierDatabaseId"), StartDate, EndDate)
                If dtPO.Rows.Count > 0 Then
                    Average = Convert.ToInt32(dtPO.Compute("SUM(Diff)", String.Empty))
                    NoOfRows = dtPO.Rows.Count
                    TotalAverage = Math.Round(Average / NoOfRows, 0)
                    dr = dtQtyVise.NewRow()
                    dr("SupplierDatabaseId") = dt.Rows(x)("SupplierDatabaseId")
                    dr("SupplierName") = dt.Rows(x)("SupplierName")
                    dr("PurchaseValue") = dt.Rows(x)("Amount")
                    dr("AvgDelivery") = TotalAverage
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            'dgVieww2.DataSource = dtQtyVise
            'dgVieww2.DataBind()
            'Dim z As Integer
            'For z = 0 To dgVieww2.Items.Count - 1
            '    Dim img1 As ImageButton = CType(dgVieww2.Items.Item(z).FindControl("img1"), ImageButton)
            '    Dim lblAvgDelivery As Label = CType(dgVieww2.Items.Item(z).FindControl("lblAvgDelivery"), Label)
            '    Dim AvgDelivery As Decimal = dgVieww2.Items.Item(z).Cells(3).Text
            '    If AvgDelivery > 0 Or AvgDelivery = 0 Then
            '        lblAvgDelivery.Text = AvgDelivery
            '        img1.ImageUrl = "~/Images/greenimage.png"
            '    Else
            '        lblAvgDelivery.Text = AvgDelivery
            '        img1.ImageUrl = "~/Images/redimage.png"
            '    End If
            'Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GetDirectorInfo()
        Try
            lblName.Text = "Atif Bhawani"
            lblDesig.Text = "Director"
            lblDivision.Text = "Director"
        Catch ex As Exception
        End Try
    End Sub
    Sub GetUserInfo(ByVal UserID)
        Try
            Dim dt As DataTable
            dt = objUser.GetUSerInfoNew(UserID)
            lblName.Text = dt.Rows(0)("UserName")
            lblDesig.Text = dt.Rows(0)("Designation2")
            lblDivision.Text = dt.Rows(0)("ECPDivistion")
            If dt.Rows(0)("image").ToString() = Nothing Then
                Image1.ImageUrl = "~/img/photo.jpg"
            Else
                Image1.ImageUrl = dt.Rows(0)("image").ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart4()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objUser As New User
            Dim dr As DataRow
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("CustomerID", GetType(Long))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("POAmount", GetType(Decimal))
                .Columns.Add("ReceiveAmount", GetType(Decimal))
                .Columns.Add("IssueAmount", GetType(Decimal))
            End With
            Dim dt As DataTable = objMGTCustomer.GetDistinctCustomer()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim CurrentDate As Date = Date.Now
                Dim PreviousMonth As Date = CurrentDate.AddMonths(-3)
                Dim Month As String = PreviousMonth.Month
                Dim Year As String = PreviousMonth.Year
                Dim Day As String = "01"
                Dim StartDate As String = Month & "/" & Day & "/" & Year
                Dim EndDatee As Date = Date.Now
                Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                Dim POAmount As String
                Dim RecvAmount As String
                Dim IssueAmount As String
                Dim dtPO As DataTable = objMGTCustomer.GetPOQtyCateViseNeww(dt.Rows(x)("CustomerID"), StartDate, EndDate)
                If dtPO.Rows.Count > 0 Then
                    POAmount = Convert.ToInt32(dtPO.Compute("SUM(POAmount)", String.Empty))
                Else
                    POAmount = 0
                End If
                Dim dtRecv As DataTable = objMGTCustomer.GetPOQtyCateViseNewwRecv(dt.Rows(x)("CustomerID"), StartDate, EndDate)
                If dtRecv.Rows.Count > 0 Then
                    RecvAmount = Convert.ToInt32(dtRecv.Compute("SUM(POAmount)", String.Empty))
                Else
                    RecvAmount = 0
                End If
                Dim dtIssue As DataTable = objMGTCustomer.GetPOQtyCateViseNewwIssue(dt.Rows(x)("CustomerID"), StartDate, EndDate)
                If dtIssue.Rows.Count > 0 Then
                    IssueAmount = Convert.ToInt32(dtIssue.Compute("SUM(POAmount)", String.Empty))
                Else
                    IssueAmount = 0
                End If
                If POAmount > 0 Then
                    dr = dtQtyVise.NewRow()
                    dr("CustomerID") = dt.Rows(x)("CustomerID")
                    dr("CustomerName") = dt.Rows(x)("CustomerName")
                    Dim FinalAmountpo As Decimal = 0
                    Dim FinalAmountRecv As Decimal = 0
                    Dim FinalAmountIssue As Decimal = 0
                    FinalAmountpo = POAmount
                    FinalAmountRecv = RecvAmount
                    FinalAmountIssue = IssueAmount
                    dr("POAmount") = FinalAmountpo
                    dr("ReceiveAmount") = FinalAmountRecv
                    dr("IssueAmount") = FinalAmountIssue
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            'dgVieww.DataSource = dtQtyVise
            ' dgVieww.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart1()
        Try
            Dim CurrentDate As Date = Date.Now
            Dim Month As String = CurrentDate.Month
            Dim Year As String = CurrentDate.Year
            Dim Day As String = "01"
            Dim EndDay As String
            Dim StartDate As String = Month & "/" & Day & "/" & Year
            If Month = 1 Then
                EndDay = 31
            ElseIf Month = 2 Then
                EndDay = 28
            ElseIf Month = 3 Then
                EndDay = 31
            ElseIf Month = 4 Then
                EndDay = 30
            ElseIf Month = 5 Then
                EndDay = 31
            ElseIf Month = 6 Then
                EndDay = 30
            ElseIf Month = 7 Then
                EndDay = 31
            ElseIf Month = 8 Then
                EndDay = 31
            ElseIf Month = 9 Then
                EndDay = 30
            ElseIf Month = 10 Then
                EndDay = 31
            ElseIf Month = 11 Then
                EndDay = 30
            ElseIf Month = 12 Then
                EndDay = 31
            End If
            Dim EndDate As String = Month & "/" & EndDay & "/" & Year
            Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonId
            Dim SeasonId As Long = dtt.Rows(0)("SeasonDatabaseID")
            Dim dt As DataTable = objMGTCustomer.GetDataOrderStatus(StartDate, EndDate, SeasonId)
            dgView2.DataSource = dt
            dgView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart3()
        Try
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("Value1", GetType(String))
                .Columns.Add("Value2", GetType(String))
                .Columns.Add("Value3", GetType(String))
                .Columns.Add("Date", GetType(String))
            End With
            Dim dt As DataTable = objMGTCustomer.GetDataDate()
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim dt1 As DataTable = objMGTCustomer.GetDataDateDAL1(dt.Rows(x)("CRDate"))
                Dim dt2 As DataTable = objMGTCustomer.GetDataDateDAL2(dt.Rows(x)("CRDate"))
                Dim dt3 As DataTable = objMGTCustomer.GetDataDateDAL3(dt.Rows(x)("CRDate"))
                If dt1.Rows.Count > 0 Or dt2.Rows.Count > 0 Or dt3.Rows.Count > 0 Then
                    Dr = dtQtyVise.NewRow()
                    If dt1.Rows.Count > 0 Then
                        Dr("Value1") = dt1.Rows(0)("Offlinee")
                    End If
                    If dt2.Rows.Count > 0 Then
                        Dr("Value2") = dt2.Rows(0)("Offlinee")
                    End If
                    If dt3.Rows.Count > 0 Then
                        Dr("Value3") = dt3.Rows(0)("Offlinee")
                    End If
                    Dr("Date") = dt.Rows(x)("CRDate")
                    dtQtyVise.Rows.Add(Dr)
                End If
            Next
            Chart3.DataSource = dtQtyVise
            Chart3.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart7()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objUser As New User
            Dim dr As DataRow
            Dim dtCurrentYear, dtCurrentYearPOF, dtCurrentYearPPRECVF, dtCurrentYearPOISSUEF, dtCurrentYearPOA, dtCurrentYearPPRECVA, dtCurrentYearPOISSUEA As DataTable
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("Value1", GetType(String))
                .Columns.Add("Value2", GetType(String))
                .Columns.Add("Value3", GetType(String))
                .Columns.Add("Value4", GetType(String))
                .Columns.Add("Value5", GetType(String))
                .Columns.Add("Value6", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonIdNew
            Dim ID As Long = dtt.Rows(0)("SeasonDatabaseID")
            Dim dt As DataTable = objSizeRange.GetSRNOData(ID)
            Dim z As Integer
            For z = 0 To dt.Rows.Count - 1
                dtCurrentYear = Nothing
                dtCurrentYearPOF = Nothing
                dtCurrentYearPPRECVF = Nothing
                dtCurrentYearPOISSUEF = Nothing
                dtCurrentYearPOA = Nothing
                dtCurrentYearPPRECVA = Nothing
                dtCurrentYearPOISSUEA = Nothing
                Dim Year As String = Date.Now.Year
                dtCurrentYearPOF = objMGTCustomer.GetDataPORecvSrNoViseFstore(ID, dt.Rows(z)("JobOrderId"))
                dtCurrentYearPPRECVF = objMGTCustomer.GetDataPOMasterSrNoViseFstore(ID, dt.Rows(z)("JobOrderId"))
                dtCurrentYearPOISSUEF = objMGTCustomer.GetDataPOIssueSrNoViseFstore(ID, dt.Rows(z)("JobOrderId"))
                dtCurrentYearPOA = objMGTCustomer.GetDataPORecvSrNoViseAstore(ID, dt.Rows(z)("JobOrderId"))
                dtCurrentYearPPRECVA = objMGTCustomer.GetDataPOMasterSrNoViseastore(ID, dt.Rows(z)("JobOrderId"))
                dtCurrentYearPOISSUEA = objMGTCustomer.GetDataPOIssueSrNoViseAstore(ID, dt.Rows(z)("JobOrderId"))
                If dtCurrentYearPOF.Rows(0)("Amount") > 0 Then
                    dr = dtQtyVise.NewRow()
                    dr("Value1") = dtCurrentYearPOF.Rows(0)("Amount") / 1000
                    dr("Value2") = dtCurrentYearPPRECVF.Rows(0)("Amount") / 1000
                    dr("Value3") = dtCurrentYearPOISSUEF.Rows(0)("Amount") / 1000
                    dr("Value4") = dtCurrentYearPOA.Rows(0)("Amount") / 1000
                    dr("Value5") = dtCurrentYearPPRECVA.Rows(0)("Amount") / 1000
                    dr("Value6") = dtCurrentYearPOISSUEA.Rows(0)("Amount") / 1000
                    dr("Name") = dt.Rows(z)("Srno")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            Chart3.DataSource = dtQtyVise
            Chart3.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart2()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objUser As New User
            Dim dr As DataRow
            Dim dtCurrentYear As DataTable
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSeasonViseAllCaseNewStoreDashboard()
            Dim x As Integer
            For x = 0 To dtCustomer.Rows.Count - 1
                Dim dtRecevFstoreAll As DataTable = objSizeRange.GetDataForReceiveInChartAllCaseAllData()
                Dim dtissueFstoreAll As DataTable = objSizeRange.GetDataForIssueInChartAllCASEAllData()
                Dim dtRecevFstore As DataTable = objSizeRange.GetDataForReceiveInChartAllCase(dtCustomer.Rows(x)("CustomerId"))
                Dim dtissueFstore As DataTable = objSizeRange.GetDataForIssueInChartAllCASE(dtCustomer.Rows(x)("CustomerId"))
                If dtRecevFstore.Rows.Count > 0 Then
                    Dim AmountFstore As Decimal = 0
                    Dim AmountIssue As Decimal = 0
                    Dim FinalAmount As Decimal = 0
                    Dim FinalQty As Decimal = 0
                    AmountFstore = dtRecevFstore.Rows(0)("Amount") / dtRecevFstoreAll.Rows(0)("Amount")
                    AmountIssue = dtRecevFstore.Rows(0)("Amount") / dtissueFstoreAll.Rows(0)("Amount")
                    FinalAmount = AmountFstore - AmountIssue
                    dr = dtQtyVise.NewRow()
                    dr("Value") = FinalAmount
                    dr("Name") = dtCustomer.Rows(x)("CustomerName")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            Chart2.DataSource = dtQtyVise
            Chart2.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class

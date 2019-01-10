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
Public Class MainPageStore
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
            BindCustomer()
            BindSeason()
            BindCustomerPurchasingDetail()
            Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    Chart_Chart1()
                    Chart_Chart2()
                    Chart_Chart3()
                    Chart_Chart4()
                    Chart_Chart5()
                    Chart_Chart6()
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
    Sub Chart_Chart1()
        Try
            Dim objPurchaseOrder As New PurchaseOrder
            Dim objUser As New User
            Dim dr As DataRow
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("Value1", GetType(String))
                .Columns.Add("Value2", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim CurrentDate As Date = Date.Now
            Dim PreviousMonth As Date = CurrentDate.AddMonths(-6)
            Dim Month As String = PreviousMonth.Month
            Dim Year As String = PreviousMonth.Year
            Dim Day As String = "01"
            Dim StartDate As String = Month & "/" & Day & "/" & Year
            Dim EndDatee As Date = Date.Now
            Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
            Dim dt As DataTable = objMGTCustomer.GetDataForPOMonthWiseFstore(StartDate, EndDate)
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim Yearr As String = dt.Rows(x)("year")
                Dim Monthh As String = dt.Rows(x)("Month")
                Dim dttF As DataTable = objMGTCustomer.GetDataForPOMonthWiseFstoreForInnerLoop(Yearr, Monthh)
                Dim AmountF As Decimal = 0
                Dim AmountA As Decimal = 0
                If dttF.Rows.Count > 0 Then
                    AmountF = Convert.ToInt32(dttF.Compute("SUM(Amount)", String.Empty))
                End If
                Dim dttA As DataTable = objMGTCustomer.GetDataForPOMonthWiseAstoreForInnerLoop(Yearr, Monthh)
                If dttA.Rows.Count > 0 Then
                    AmountA = Convert.ToInt32(dttA.Compute("SUM(Amount)", String.Empty))
                End If
                dr = dtQtyVise.NewRow()
                dr("Value1") = AmountF / 1000
                dr("Value2") = AmountA / 1000
                dr("Name") = Monthh & "-" & Yearr
                dtQtyVise.Rows.Add(dr)
            Next
            Chart1.DataSource = dtQtyVise
            Chart1.DataBind()
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
                .Columns.Add("Value1", GetType(String))
                .Columns.Add("Value2", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim CurrentDate As Date = Date.Now
            Dim PreviousMonth As Date = CurrentDate.AddMonths(-1)
            Dim Month As String = PreviousMonth.Month
            Dim Year As String = PreviousMonth.Year
            Dim Day As String = "01"
            Dim StartDate As String = Month & "/" & Day & "/" & Year
            Dim EndDatee As Date = Date.Now
            Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSeasonViseAllCaseNewStoreDashboardNeww(StartDate, EndDate)
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
                    AmountFstore = dtRecevFstore.Rows(0)("Amount")
                    AmountIssue = dtissueFstore.Rows(0)("Amount")
                    FinalAmount = AmountFstore - AmountIssue
                    dr = dtQtyVise.NewRow()
                    dr("Name") = dtCustomer.Rows(x)("CustomerName")
                    If FinalAmount > 0 Then
                        dr("Value1") = FinalAmount
                        dtQtyVise.Rows.Add(dr)
                    Else
                        dr("Value2") = FinalAmount * (-1)
                        dtQtyVise.Rows.Add(dr)
                    End If
                End If
            Next
            Chart2.DataSource = dtQtyVise
            Chart2.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart3()
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
            dgView.DataSource = dtQtyVise
            dgView.DataBind()
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
            dgView2.DataSource = dtQtyVise
            dgView2.DataBind()
            Dim z As Integer
            For z = 0 To dgView2.Items.Count - 1
                Dim img1 As ImageButton = CType(dgView2.Items.Item(z).FindControl("img1"), ImageButton)
                Dim lblAvgDelivery As Label = CType(dgView2.Items.Item(z).FindControl("lblAvgDelivery"), Label)
                Dim AvgDelivery As Decimal = dgView2.Items.Item(z).Cells(3).Text
                If AvgDelivery > 0 Or AvgDelivery = 0 Then
                    lblAvgDelivery.Text = AvgDelivery
                    img1.ImageUrl = "~/Images/greenimage.png"
                Else
                    lblAvgDelivery.Text = AvgDelivery
                    img1.ImageUrl = "~/Images/redimage.png"
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart5()
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
                .Columns.Add("Name", GetType(String))
            End With
            Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonIdNeweeeeee()
            Dim ID As Long = dtt.Rows(0)("SeasonDatabaseID")
            Dim CurrentDate As Date = Date.Now
            Dim PreviousMonth As Date = CurrentDate.AddMonths(-2)
            Dim Month As String = PreviousMonth.Month
            Dim Year As String = PreviousMonth.Year
            Dim Day As String = "01"
            Dim StartDate As String = Month & "/" & Day & "/" & Year
            Dim EndDatee As Date = Date.Now
            Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
            Dim dt As DataTable = objSizeRange.GetSRNODataNew(ID, StartDate, EndDate)
            Dim z As Integer
            For z = 0 To dt.Rows.Count - 1
                dtCurrentYear = Nothing
                dtCurrentYearPOF = Nothing
                dtCurrentYearPPRECVF = Nothing
                dtCurrentYearPOISSUEF = Nothing
                dtCurrentYearPOA = Nothing
                dtCurrentYearPPRECVA = Nothing
                dtCurrentYearPOISSUEA = Nothing
                Dim Dta As DataTable = objMGTCustomer.GetFQty(ID, dt.Rows(z)("JobOrderId"))
                If Dta.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    dr("Value1") = Dta.Rows(0)("POQuantity") * Dta.Rows(0)("Rate")
                    dr("Value2") = Dta.Rows(0)("RecvQuantity") * Dta.Rows(0)("Rate")
                    dr("Value3") = Dta.Rows(0)("IssueQuantity") * Dta.Rows(0)("IssueRate")
                    dr("Name") = dt.Rows(z)("Srno")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            Chart5.DataSource = dtQtyVise
            Chart5.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart6()
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
                .Columns.Add("Name", GetType(String))
            End With
            Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonIdNeweeeeee()
            Dim ID As Long = dtt.Rows(0)("SeasonDatabaseID")
            Dim CurrentDate As Date = Date.Now
            Dim PreviousMonth As Date = CurrentDate.AddMonths(-2)
            Dim Month As String = PreviousMonth.Month
            Dim Year As String = PreviousMonth.Year
            Dim Day As String = "01"
            Dim StartDate As String = Month & "/" & Day & "/" & Year
            Dim EndDatee As Date = Date.Now
            Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
            Dim dt As DataTable = objSizeRange.GetSRNODataNewAstore(ID, StartDate, EndDate)
            Dim z As Integer
            For z = 0 To dt.Rows.Count - 1
                Dim Dta As DataTable = objMGTCustomer.GetAQty(ID, dt.Rows(z)("JobOrderId"))
                If Dta.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    dr("Value1") = Dta.Rows(0)("POQuantity") * Dta.Rows(0)("Rate")
                    dr("Value2") = Dta.Rows(0)("RecvQuantity") * Dta.Rows(0)("Rate")
                    dr("Value3") = Dta.Rows(0)("IssueQuantity") * Dta.Rows(0)("IssueRate")
                    dr("Name") = dt.Rows(z)("Srno")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            Chart6.DataSource = dtQtyVise
            Chart6.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo2()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNewGetOrderNo(cmbCustomerPurchasingDetail.SelectedValue)
            cmbSrNo2.DataSource = dtInvoiceNo
            cmbSrNo2.DataTextField = "SrNO"
            cmbSrNo2.DataValueField = "JobOrderID"
            cmbSrNo2.DataBind()
            cmbSrNo2.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
            Dim script As String = "function f(){$find(""" + rwCustomerInventory.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbCustomerPurchasingDetail_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomerPurchasingDetail.SelectedIndexChanged
        Try
            BindSrNo2()
            Dim script As String = "function f(){$find(""" + rwPurchasingDetail.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomerPurchasingDetail()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objMGTCustomer.GetDistinctCustomer()
            cmbCustomerPurchasingDetail.DataSource = dtcmbSeason
            cmbCustomerPurchasingDetail.DataTextField = "CustomerName"
            cmbCustomerPurchasingDetail.DataValueField = "CustomerID"
            cmbCustomerPurchasingDetail.DataBind()
            cmbCustomerPurchasingDetail.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dt As DataTable = objSizeRange.GetCustomerNameByFilterDataNew()
            cmbCustomer.DataSource = dt
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, New RadComboBoxItem("Select", 0))
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
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles ImageButton1.Click
        Try
            Dim script As String = "function f(){$find(""" + rwPurchasingDetail.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPurchasingDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPurchasingDetail.Click
        Dim script As String = "function f(){$find(""" + rwPurchasingDetail.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                Chart_Chart6()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
            End If
        End If
    End Sub
    Protected Sub btnPurchasingDetailView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPurchasingDetailView.Click
        If cmbCustomerPurchasingDetail.SelectedItem.Text = "Select" Then
            Label2.Text = "Please Select Customer"
        Else
            Label2.Text = ""
            objSizeRange.tempPurchasingSummaryTruncateSrno()
            If cmbSrNo2.CheckedItems.Count > 1 Then
                Dim xx As Integer
                For xx = 0 To cmbSrNo2.CheckedItems.Count - 1
                    With objTempPurchasingSummary
                        .ID = 0
                        .No = cmbSrNo2.CheckedItems(xx).Text
                        .JobOrdeId = cmbSrNo2.CheckedItems(xx).Value
                        .Save()
                    End With
                Next
                Dim objPurchaseOrder As New PurchaseOrder
                Dim objUser As New User
                Dim dr As DataRow
                Dim dtCurrentYear As DataTable
                Dim dtQtyVise As New DataTable
                dtQtyVise = Nothing
                dtQtyVise = New DataTable
                With dtQtyVise
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("POAmount", GetType(Decimal))
                    .Columns.Add("ReceiveAmount", GetType(Decimal))
                    .Columns.Add("IssueAmount", GetType(Decimal))
                End With
                Dim dt As DataTable
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    Dim StartDatee As Date = txtDateFrom.SelectedDate
                    Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                    Dim EndDatee As Date = txtDateTo.SelectedDate
                    Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                    dt = objMGTCustomer.GetItemIDaNDItemNAmerrrrrrrrrrrrrrrrrrDateWise(cmbCustomerPurchasingDetail.SelectedValue, StartDate, EndDate)
                Else
                    dt = objMGTCustomer.GetItemIDaNDItemNAmerrrrrrrrrrrrrrrrrr(cmbCustomerPurchasingDetail.SelectedValue)
                End If
                Dim z As Integer
                For z = 0 To dt.Rows.Count - 1
                    Dim POAmount As String
                    Dim RecvAmount As String
                    Dim IssueAmount As String
                    Dim dtPOo As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaaAnyCaseDateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaaAnyCase(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtPOo.Rows.Count > 0 Then
                        POAmount = Convert.ToDecimal(dtPOo.Compute("SUM(POAmount)", String.Empty))
                    Else
                        POAmount = ""
                    End If

                    Dim dtRecv As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444vAnuCaseDateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtRecv = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444vAnuCase(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtRecv.Rows.Count > 0 Then
                        RecvAmount = Convert.ToDecimal(dtRecv.Compute("SUM(POAmount)", String.Empty))
                    Else
                        RecvAmount = ""
                    End If
                    Dim dtIssue As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666AnyCaseDateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtIssue = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666AnyCase(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtIssue.Rows.Count > 0 Then
                        IssueAmount = Convert.ToDecimal(dtIssue.Compute("SUM(POAmount)", String.Empty))
                    Else
                        IssueAmount = ""
                    End If
                    If POAmount > 0 Then
                        dr = dtQtyVise.NewRow()
                        dr("ItemName") = dt.Rows(z)("ItemName")
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
                If dtQtyVise.Rows.Count > 0 Then
                    dgPartialGridView.DataSource = dtQtyVise
                    dgPartialGridView.DataBind()
                    Dim totalCount As Decimal = 0
                    Dim totalCount1 As Decimal = 0
                    Dim totalCount2 As Decimal = 0
                    Dim a As Integer
                    For a = 0 To dgPartialGridView.Items.Count - 1
                        totalCount = totalCount + dgPartialGridView.Items(a).Cells(1).Text
                        totalCount1 = totalCount1 + dgPartialGridView.Items(a).Cells(2).Text
                        totalCount2 = totalCount2 + dgPartialGridView.Items(a).Cells(3).Text
                    Next
                    lblPOAmount.Text = Math.Round(totalCount, 0)
                    lblRecvAmount.Text = Math.Round(totalCount1, 0)
                    lblIssueAmount.Text = Math.Round(totalCount2, 0)
                End If
            ElseIf cmbSrNo2.CheckedItems.Count = 1 Then
                Dim objPurchaseOrder As New PurchaseOrder
                Dim objUser As New User
                Dim dr As DataRow
                Dim dtCurrentYear As DataTable
                Dim dtQtyVise As New DataTable
                dtQtyVise = Nothing
                dtQtyVise = New DataTable
                With dtQtyVise
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("POAmount", GetType(Decimal))
                    .Columns.Add("ReceiveAmount", GetType(Decimal))
                    .Columns.Add("IssueAmount", GetType(Decimal))
                End With
                Dim dt As DataTable
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    Dim StartDatee As Date = txtDateFrom.SelectedDate
                    Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                    Dim EndDatee As Date = txtDateTo.SelectedDate
                    Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                    dt = objMGTCustomer.GetItemIDaNDItemNAmeDateVise(cmbCustomerPurchasingDetail.SelectedValue, StartDate, EndDate)
                Else
                    dt = objMGTCustomer.GetItemIDaNDItemNAme(cmbCustomerPurchasingDetail.SelectedValue)
                End If
                Dim z As Integer
                For z = 0 To dt.Rows.Count - 1
                    Dim POAmount As String
                    Dim RecvAmount As String
                    Dim IssueAmount As String
                    Dim dtPOo As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaaDateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaa(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtPOo.Rows.Count > 0 Then
                        POAmount = Convert.ToDecimal(dtPOo.Compute("SUM(POAmount)", String.Empty))
                    Else
                        POAmount = ""
                    End If
                    Dim dtRecv As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtRecv = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444vdateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtRecv = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444v(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtRecv.Rows.Count > 0 Then
                        RecvAmount = Convert.ToDecimal(dtRecv.Compute("SUM(POAmount)", String.Empty))
                    Else
                        RecvAmount = ""
                    End If
                    Dim dtIssue As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtIssue = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666DateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtIssue = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtIssue.Rows.Count > 0 Then
                        IssueAmount = Convert.ToDecimal(dtIssue.Compute("SUM(POAmount)", String.Empty))
                    Else
                        IssueAmount = ""
                    End If
                    If POAmount > 0 Then
                        dr = dtQtyVise.NewRow()
                        dr("ItemName") = dt.Rows(z)("ItemName")
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
                If dtQtyVise.Rows.Count > 0 Then
                    dgPartialGridView.DataSource = dtQtyVise
                    dgPartialGridView.DataBind()
                    Dim totalCount As Decimal = 0
                    Dim totalCount1 As Decimal = 0
                    Dim totalCount2 As Decimal = 0
                    Dim a As Integer
                    For a = 0 To dgPartialGridView.Items.Count - 1
                        totalCount = totalCount + dgPartialGridView.Items(a).Cells(1).Text
                        totalCount1 = totalCount1 + dgPartialGridView.Items(a).Cells(2).Text
                        totalCount2 = totalCount2 + dgPartialGridView.Items(a).Cells(3).Text
                    Next
                    lblPOAmount.Text = Math.Round(totalCount, 0)
                    lblRecvAmount.Text = Math.Round(totalCount1, 0)
                    lblIssueAmount.Text = Math.Round(totalCount2, 0)
                End If
            Else
                Dim objPurchaseOrder As New PurchaseOrder
                Dim objUser As New User
                Dim dr As DataRow
                Dim dtCurrentYear As DataTable
                Dim dtQtyVise As New DataTable
                dtQtyVise = Nothing
                dtQtyVise = New DataTable
                With dtQtyVise
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("POAmount", GetType(Decimal))
                    .Columns.Add("ReceiveAmount", GetType(Decimal))
                    .Columns.Add("IssueAmount", GetType(Decimal))
                End With
                Dim dt As DataTable
                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    Dim StartDatee As Date = txtDateFrom.SelectedDate
                    Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                    Dim EndDatee As Date = txtDateTo.SelectedDate
                    Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                    dt = objMGTCustomer.GetItemIDaNDItemNAmeDateVise(cmbCustomerPurchasingDetail.SelectedValue, StartDate, EndDate)
                Else
                    dt = objMGTCustomer.GetItemIDaNDItemNAme(cmbCustomerPurchasingDetail.SelectedValue)
                End If
                Dim z As Integer
                For z = 0 To dt.Rows.Count - 1
                    Dim POAmount As Decimal
                    Dim RecvAmount As Decimal
                    Dim IssueAmount As Decimal
                    Dim dtPOo As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaaDateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtPOo = objMGTCustomer.GetPOQtyCateViseNewwPOAmountDtaa(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtPOo.Rows.Count > 0 Then
                        POAmount = Convert.ToDecimal(dtPOo.Compute("SUM(POAmount)", String.Empty))
                    Else
                        POAmount = ""
                    End If
                    Dim dtRecv As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtRecv = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444vdateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtRecv = objMGTCustomer.GetPOQtyCateViseNewwRec4444444444444v(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtRecv.Rows.Count > 0 Then
                        RecvAmount = Convert.ToDecimal(dtRecv.Compute("SUM(POAmount)", String.Empty))
                    Else
                        RecvAmount = ""
                    End If
                    Dim dtIssue As DataTable
                    If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                        Dim StartDatee As Date = txtDateFrom.SelectedDate
                        Dim StartDate As String = StartDatee.ToString("MM/dd/yyyy")
                        Dim EndDatee As Date = txtDateTo.SelectedDate
                        Dim EndDate As String = EndDatee.ToString("MM/dd/yyyy")
                        dtIssue = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666DateWise(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"), StartDate, EndDate)
                    Else
                        dtIssue = objMGTCustomer.GetPOQtyCateViseNewwIssue6666666666666666(cmbCustomerPurchasingDetail.SelectedValue, dt.Rows(z)("IMSItemId"))
                    End If
                    If dtIssue.Rows.Count > 0 Then
                        IssueAmount = Convert.ToDecimal(dtIssue.Compute("SUM(POAmount)", String.Empty))
                    Else
                        IssueAmount = ""
                    End If
                    If POAmount > 0 Then
                        dr = dtQtyVise.NewRow()
                        dr("ItemName") = dt.Rows(z)("ItemName")
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
                If dtQtyVise.Rows.Count > 0 Then
                    dgPartialGridView.DataSource = dtQtyVise
                    dgPartialGridView.DataBind()
                    Dim totalCount As Decimal = 0
                    Dim totalCount1 As Decimal = 0
                    Dim totalCount2 As Decimal = 0
                    Dim a As Integer
                    For a = 0 To dgPartialGridView.Items.Count - 1
                        totalCount = totalCount + dgPartialGridView.Items(a).Cells(1).Text
                        totalCount1 = totalCount1 + dgPartialGridView.Items(a).Cells(2).Text
                        totalCount2 = totalCount2 + dgPartialGridView.Items(a).Cells(3).Text
                    Next
                    lblPOAmount.Text = Math.Round(totalCount, 2)
                    lblRecvAmount.Text = Math.Round(totalCount1, 2)
                    lblIssueAmount.Text = Math.Round(totalCount2, 2)
                End If
            End If
        End If
        Dim script As String = "function f(){$find(""" + rwPurchasingDetail.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub   
    Protected Sub btnPurchasingSummary_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnPurchasingSummary.Click
        Try
            Dim script As String = "function f(){$find(""" + rwPurchasingSummary.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancelPurchaseSummary_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelPurchaseSummary.Click
        Dim script As String = "function f(){$find(""" + rwPurchasingSummary.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        cmbMonth.SelectedValue = 0
        cmbYear.SelectedValue = 0
        cmbStoreType.SelectedValue = 0
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                Chart_Chart6()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
            End If
        End If
    End Sub
    Protected Sub btnViewChartPurchaseSummary_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewChartPurchaseSummary.Click
        Dim objPurchaseOrder As New PurchaseOrder
        Dim objUser As New User
        Dim dr As DataRow
        Dim dtQtyVise As New DataTable
        dtQtyVise = Nothing
        dtQtyVise = New DataTable
        With dtQtyVise
            .Columns.Add("SupplierName", GetType(String))
            .Columns.Add("Qauntity", GetType(String))
            .Columns.Add("Amount", GetType(String))
        End With
        Dim Year As String
        Dim Month As String
        If cmbYear.SelectedItem.Text = "All" Then
            Year = "All"
        Else
            Year = cmbYear.SelectedItem.Text
        End If
        If cmbMonth.SelectedItem.Text = "All" Then
            Month = "All"
        Else
            If cmbMonth.SelectedItem.Text = "JAN" Then
                Month = "01"
            End If
            If cmbMonth.SelectedItem.Text = "FEB" Then
                Month = "02"
            End If
            If cmbMonth.SelectedItem.Text = "MAR" Then
                Month = "03"
            End If
            If cmbMonth.SelectedItem.Text = "APR" Then
                Month = "04"
            End If
            If cmbMonth.SelectedItem.Text = "MAY" Then
                Month = "05"
            End If
            If cmbMonth.SelectedItem.Text = "JUN" Then
                Month = "06"
            End If
            If cmbMonth.SelectedItem.Text = "JUL" Then
                Month = "07"
            End If
            If cmbMonth.SelectedItem.Text = "AUG" Then
                Month = "08"
            End If
            If cmbMonth.SelectedItem.Text = "SEP" Then
                Month = "09"
            End If
            If cmbMonth.SelectedItem.Text = "OCT" Then
                Month = "10"
            End If
            If cmbMonth.SelectedItem.Text = "NOV" Then
                Month = "11"
            End If
            If cmbMonth.SelectedItem.Text = "DEC" Then
                Month = "12"
            End If
        End If
        Dim dttF As DataTable = objMGTCustomer.GetDataAllcase(cmbStoreType.SelectedItem.Text, Year, Month)
        Dim x As Integer
        For x = 0 To dttF.Rows.Count - 1
            dr = dtQtyVise.NewRow()
            dr("SupplierName") = dttF.Rows(x)("SupplierName")
            dr("Qauntity") = Math.Round(dttF.Rows(x)("Quantity"), 0)
            dr("Amount") = Math.Round(dttF.Rows(x)("Amount"), 0)
            dtQtyVise.Rows.Add(dr)
        Next
        dgPurchasingDetail.DataSource = dtQtyVise
        dgPurchasingDetail.DataBind()
        Dim totalCount As Decimal = 0
        Dim totalCount1 As Decimal = 0
        Dim a As Integer
        For a = 0 To dgPurchasingDetail.Items.Count - 1
            totalCount = totalCount + dgPurchasingDetail.Items(a).Cells(1).Text
            totalCount1 = totalCount1 + dgPurchasingDetail.Items(a).Cells(2).Text
        Next
        lblQty.Text = Math.Round(totalCount, 0)
        lblAmount.Text = Math.Round(totalCount1 / 1000, 0)
        Dim script As String = "function f(){$find(""" + rwPurchasingSummary.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Protected Sub BtnPartialCustomerChart_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles BtnPartialCustomerChart.Click
        Try
            Dim script As String = "function f(){$find(""" + rwCustomerInventory.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnViewChart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewChart.Click
        objSizeRange.tempInventoryPositionTruncate()
        objSizeRange.tempInventoryPositionTruncateSrno()
        If cmbCustomer.CheckedItems.Count <> 0 And cmbSrNo.CheckedItems.Count = 0 Then
            Dim xx As Integer
            For xx = 0 To cmbCustomer.CheckedItems.Count - 1
                With objTempCustomerInventoryPosition
                    .ID = 0
                    .No = cmbCustomer.CheckedItems(xx).Text
                    .Save()
                End With
            Next
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
            Dim Type As String
            If cmbType.SelectedItem.Text = "Select" Then
                Type = "All"
            ElseIf cmbType.SelectedItem.Text = "Fabric Store" Then
                Type = "Fabric Store"
            ElseIf cmbType.SelectedItem.Text = "Accessories Store" Then
                Type = "Accessories Store"
            End If
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSearchgetCustomername()
            Dim z As Integer
            For z = 0 To dtCustomer.Rows.Count - 1
                Dim Name As String = dtCustomer.Rows(z)("NO")
                Dim GetCustomerName As DataTable = objSizeRange.GetCustomerId(Name)
                Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPosition(Type, GetCustomerName.Rows(0)("CustomerId"))
                Dim dtt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPositionForIssue(Type, GetCustomerName.Rows(0)("CustomerId"))
                If dt.Rows.Count > 0 Then
                    Dim Amount As Decimal = 0
                    Dim AmountRecv As Decimal = 0
                    Dim Amountissue As Decimal = 0
                    AmountRecv = dt.Rows(0)("Amount")
                    Amountissue = dtt.Rows(0)("Amount")
                    Amount = AmountRecv - Amountissue
                    dr = dtQtyVise.NewRow()
                    dr("Value") = Amount / 1000
                    dr("Name") = dtCustomer.Rows(z)("No")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            If dtQtyVise.Rows.Count > 0 Then
                CustomerFilterChart.DataSource = dtQtyVise
                CustomerFilterChart.DataBind()
                CustomerFilterChart.Visible = True
            Else
                CustomerFilterChart.Visible = False
            End If




        ElseIf cmbCustomer.CheckedItems.Count <> 0 And cmbSrNo.CheckedItems.Count <> 0 Then
            Dim xx As Integer
            For xx = 0 To cmbCustomer.CheckedItems.Count - 1
                With objTempCustomerInventoryPosition
                    .ID = 0
                    .No = cmbCustomer.CheckedItems(xx).Text
                    .Save()
                End With
            Next

            Dim zz As Integer
            For zz = 0 To cmbSrNo.CheckedItems.Count - 1
                With objTempSrnoInventoryPosition
                    .ID = 0
                    .No = cmbSrNo.CheckedItems(zz).Text
                    .Save()
                End With
            Next

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
            Dim Type As String
            If cmbType.SelectedItem.Text = "Select" Then
                Type = "All"
            ElseIf cmbType.SelectedItem.Text = "Fabric Store" Then
                Type = "Fabric Store"
            ElseIf cmbType.SelectedItem.Text = "Accessories Store" Then
                Type = "Accessories Store"
            End If
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSearchgetCustomername()
            Dim z As Integer
            For z = 0 To dtCustomer.Rows.Count - 1
                Dim Name As String = dtCustomer.Rows(z)("NO")
                Dim GetCustomerName As DataTable = objSizeRange.GetCustomerId(Name)
                Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPositionOtherCase(Type, GetCustomerName.Rows(0)("CustomerId"))
                Dim dtt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPositionForIssueOtherCase(Type, GetCustomerName.Rows(0)("CustomerId"))
                If dt.Rows.Count > 0 Then
                    Dim Amount As Decimal = 0
                    Dim AmountRecv As Decimal = 0
                    Dim Amountissue As Decimal = 0
                    AmountRecv = dt.Rows(0)("Amount")
                    Amountissue = dtt.Rows(0)("Amount")
                    Amount = AmountRecv - Amountissue
                    dr = dtQtyVise.NewRow()
                    dr("Value") = Amount / 1000
                    dr("Name") = dtCustomer.Rows(z)("No")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            If dtQtyVise.Rows.Count > 0 Then
                CustomerFilterChart.DataSource = dtQtyVise
                CustomerFilterChart.DataBind()
                CustomerFilterChart.Visible = True
            Else
                CustomerFilterChart.Visible = False
            End If





        ElseIf cmbCustomer.CheckedItems.Count = 0 And cmbSrNo.CheckedItems.Count <> 0 Then
            Dim zz As Integer
            For zz = 0 To cmbSrNo.CheckedItems.Count - 1
                With objTempSrnoInventoryPosition
                    .ID = 0
                    .No = cmbSrNo.CheckedItems(zz).Text
                    .Save()
                End With
            Next
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
            Dim Type As String
            If cmbType.SelectedItem.Text = "Select" Then
                Type = "All"
            ElseIf cmbType.SelectedItem.Text = "Fabric Store" Then
                Type = "Fabric Store"
            ElseIf cmbType.SelectedItem.Text = "Accessories Store" Then
                Type = "Accessories Store"
            End If
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSearchgetSrnoVise()
            Dim z As Integer
            For z = 0 To dtCustomer.Rows.Count - 1
                Dim Name As String = dtCustomer.Rows(z)("NO")
                Dim GetCustomerName As DataTable = objSizeRange.GetJobOrderId(Name)
                Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPositionSrNoVise(Type, GetCustomerName.Rows(0)("JobOrderId"))
                Dim dtt As DataTable = objSizeRange.GetDataForCustomerFiltringInventoryPositionSrNoViseIssue(Type, GetCustomerName.Rows(0)("JobOrderId"))
                If dt.Rows.Count > 0 Then
                    Dim Amount As Decimal = 0
                    Dim AmountRecv As Decimal = 0
                    Dim Amountissue As Decimal = 0
                    AmountRecv = dt.Rows(0)("Amount")
                    Amountissue = dtt.Rows(0)("Amount")
                    Amount = AmountRecv - Amountissue
                    dr = dtQtyVise.NewRow()
                    dr("Value") = Amount / 1000
                    dr("Name") = GetCustomerName
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            If dtQtyVise.Rows.Count > 0 Then
                CustomerFilterChart.DataSource = dtQtyVise
                CustomerFilterChart.DataBind()
                CustomerFilterChart.Visible = True
            Else
                CustomerFilterChart.Visible = False
            End If
        ElseIf cmbCustomer.CheckedItems.Count = 0 And cmbSrNo.CheckedItems.Count = 0 Then


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
            Dim Type As String
            If cmbType.SelectedItem.Text = "Select" Then
                Type = "All"
            ElseIf cmbType.SelectedItem.Text = "Fabric Store" Then
                Type = "Fabric Store"
            ElseIf cmbType.SelectedItem.Text = "Accessories Store" Then
                Type = "Accessories Store"
            End If
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerIdsss()
            Dim x As Integer
            For x = 0 To dtCustomer.Rows.Count - 1
                Dim dtRecevFstore As DataTable = objSizeRange.GetDataForReceiveInChartAllCase(dtCustomer.Rows(x)("CustomerId"))
                Dim dtissueFstore As DataTable = objSizeRange.GetDataForIssueInChartAllCASE(dtCustomer.Rows(x)("CustomerId"))
                If dtRecevFstore.Rows.Count > 0 Then
                    Dim AmountFstore As Decimal = 0
                    Dim AmountAstore As Decimal = 0
                    Dim FinalQty As Decimal = 0
                    AmountFstore = dtRecevFstore.Rows(0)("Amount") - dtissueFstore.Rows(0)("Amount")
                    dr = dtQtyVise.NewRow()
                    dr("Value") = AmountFstore / 1000
                    dr("Name") = dtCustomer.Rows(x)("CustomerName")
                    dtQtyVise.Rows.Add(dr)
                End If
            Next
            If dtQtyVise.Rows.Count > 0 Then
                CustomerFilterChart.DataSource = dtQtyVise
                CustomerFilterChart.DataBind()
                CustomerFilterChart.Visible = True
            Else
                CustomerFilterChart.Visible = False
            End If
        End If
        Dim script As String = "function f(){$find(""" + rwCustomerInventory.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Dim script As String = "function f(){$find(""" + rwCustomerInventory.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        cmbSeason.SelectedIndex = -1
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                Chart_Chart6()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
            End If
        End If
    End Sub
    Sub DownLoadReport()
        objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
        objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCase(10)
        objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCase()
        objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCase(10)
        objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCase(10)
        Dim x As Integer
        Dim OBJDATE As New GeneralCode
        Dim Date1 As Date = "01/03/2015"
        Dim SDate As String = Date1.ToString("dd/MM/yyyy")
        Dim OpCre As Decimal = 0
        Dim OpDbt As Decimal = 0

        Dim Date2 As Date = "01/03/2015"
        Dim date3 As Date = Date.Now
        Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
        Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
        objTempStockInventory.TruncateTempItemInventoryFinal()
        objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()





        'ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
        '    If cmbGodown.SelectedItem.Text = "Select" Then
        '        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location.")
        '    Else
        '        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        '        If lblID.Text = 0 Then
        '            AccountCode = lblID.Text
        '            Dim lOCATIONid As Long = cmbGodown.SelectedValue
        '            objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
        '            objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseForAcc(cmbGodown.SelectedValue)
        '            If cmbGodown.SelectedItem.Text = "main store 1" Then
        '                objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCaseForACC()
        '            Else
        '                objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCaseForAcc(cmbGodown.SelectedValue)
        '            End If
        '            objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCase(cmbGodown.SelectedValue)
        '            objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCase(cmbGodown.SelectedValue)
        '            Dim x As Integer
        '            Dim OBJDATE As New GeneralCode
        '            Dim Date1 As Date = "01/03/2015"
        '            Dim SDate As String = Date1.ToString("dd/MM/yyyy")
        '            Dim OpCre As Decimal = 0
        '            Dim OpDbt As Decimal = 0
        '            If OpCre = 0 And OpDbt = 0 Then
        '                OpeningBalance = OpCre
        '            ElseIf OpCre > 0 And OpDbt = 0 Then
        '                OpeningBalance = -OpCre
        '            ElseIf OpDbt > 0 And OpCre = 0 Then
        '                OpeningBalance = OpDbt
        '            ElseIf OpDbt > OpCre Then
        '                OpeningBalance = OpDbt - OpCre
        '            ElseIf OpCre > OpDbt Then
        '                OpeningBalance = OpDbt - OpCre
        '            End If
        '            Dim Date2 As Date = "01/03/2015"
        '            Dim date3 As Date = txtDateTo.SelectedDate
        '            Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
        '            Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
        '            objTempStockInventory.TruncateTempItemInventoryFinal()
        '            objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
        '            Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
        '            Dim Prevoiusbalance As Decimal = 0
        '            If objDataTablepre.Rows.Count > 0 Then
        '                Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
        '            End If
        '            Dim dtchk As DataTable
        '            dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

        '            Dim dtonlyVoucher As DataTable
        '            If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
        '                dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
        '                Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
        '            End If
        '            Dim DescEntry As String = ""
        '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
        '            Dim Report As New ReportDocument
        '            Dim Options As New ExportOptions
        '            Dim FileName As String
        '            If ckhWithoutZeroQty.Checked = True Then
        '                Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCaseForAstoreForZero.rpt"))
        '            Else
        '                Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAllCaseForAstore.rpt"))
        '            End If
        '            FileName = "Item_Inventory_Report"
        '            Report.Refresh()
        '            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        '            di.Create()
        '            Dim StatDate As Date = "01/03/2015"
        '            Dim EndDate As Date = txtDateTo.SelectedDate
        '            Dim ReportName As String = "ITEM INVENTORY"
        '            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        '            Report.SetParameterValue(0, txtFabricCode.Text)
        '            Report.SetParameterValue(1, OpeningBalance)
        '            Report.SetParameterValue(2, StatDate)
        '            Report.SetParameterValue(3, EndDate)
        '            Report.SetParameterValue(4, openDate)
        '            Report.SetParameterValue(5, Prevoiusbalance)
        '            Report.SetParameterValue(6, lOCATIONid)
        '            Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
        '            Report.SetParameterValue(8, ReportName)
        '            Dim FileOption As New DiskFileDestinationOptions
        '            FileOption.DiskFileName = sTempFileName
        '            Options = Report.ExportOptions
        '            Options.ExportDestinationType = ExportDestinationType.DiskFile
        '            Options.ExportFormatType = ExportFormatType.PortableDocFormat
        '            Options.DestinationOptions = FileOption
        '            Options.ExportDestinationOptions = FileOption
        '            Report.SetDatabaseLogon("sa", "pwd")
        '            Report.Export()
        '            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
        '                Dim strFileSize As String = ""
        '                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
        '                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
        '                Dim fi As IO.FileInfo
        '                For Each fi In aryFi
        '                    Response.ClearHeaders()
        '                    Response.ClearContent()
        '                    Response.ContentType = "application/octet-stream"
        '                    Response.Charset = "UTF-8"
        '                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
        '                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
        '                    Response.End()
        '                Next
        '            End If
        '        Else
        '            AccountCode = lblID.Text
        '            Dim lOCATIONid As Long = cmbGodown.SelectedValue
        '            objTempStockInventory.TruncateTempInventoryNewForFinalInventory()
        '            objTempStockInventory.InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAccForCATEGORYWISE(lblID.Text, cmbGodown.SelectedValue)
        '            If cmbGodown.SelectedItem.Text = "main store 1" Then
        '                objTempStockInventory.InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAccForCategorywise(lblID.Text)
        '            Else
        '                objTempStockInventory.InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
        '            End If
        '            objTempStockInventory.InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForCategoryWise(lblID.Text, cmbGodown.SelectedValue)
        '            objTempStockInventory.InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForCategorywise(lblID.Text, cmbGodown.SelectedValue)
        '            Dim x As Integer
        '            Dim OBJDATE As New GeneralCode
        '            Dim Date1 As Date = "01/03/2018"
        '            Dim SDate As String = Date1.ToString("dd/MM/yyyy")
        '            Dim OpCre As Decimal = 0
        '            Dim OpDbt As Decimal = 0
        '            If OpCre = 0 And OpDbt = 0 Then
        '                OpeningBalance = OpCre
        '            ElseIf OpCre > 0 And OpDbt = 0 Then
        '                OpeningBalance = -OpCre
        '            ElseIf OpDbt > 0 And OpCre = 0 Then
        '                OpeningBalance = OpDbt
        '            ElseIf OpDbt > OpCre Then
        '                OpeningBalance = OpDbt - OpCre
        '            ElseIf OpCre > OpDbt Then
        '                OpeningBalance = OpDbt - OpCre
        '            End If
        '            Dim Date2 As Date = "01/03/2015"
        '            Dim date3 As Date = txtDateTo.SelectedDate
        '            Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
        '            Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
        '            objTempStockInventory.TruncateTempItemInventoryFinal()
        '            objTempStockInventory.InsertTempLedgerIntoTempFinalForItemInventory()
        '            Dim objDataTablepre As DataTable = objTempStockInventory.GetLedgerForPrintNewForLocationForNew(OpeningBalance, Estdatee, Enddatee, cmbGodown.SelectedValue)
        '            Dim Prevoiusbalance As Decimal = 0
        '            If objDataTablepre.Rows.Count > 0 Then
        '                Prevoiusbalance = objDataTablepre.Rows(0)("PreviousBalance")
        '            End If
        '            Dim dtchk As DataTable
        '            dtchk = objTempStockInventory.CheckInsertdataForItemInventory()

        '            Dim dtonlyVoucher As DataTable
        '            If objDataTablepre.Rows.Count = 0 And dtchk.Rows.Count <> 0 Then
        '                dtonlyVoucher = objTempStockInventory.GetLedgerForPrintNew2ForLocationForNew(OpeningBalance, cmbGodown.SelectedValue)
        '                Prevoiusbalance = dtonlyVoucher.Rows(dtonlyVoucher.Rows.Count - 1)("Balance")
        '            End If
        '            Dim DescEntry As String = ""
        '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
        '            Dim Report As New ReportDocument
        '            Dim Options As New ExportOptions
        '            Dim FileName As String
        '            If ckhWithoutZeroQty.Checked = True Then
        '                Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCaseForAstoreForZero.rpt"))
        '            Else
        '                Report.Load(Server.MapPath("~/Reports/ItemInventoryReportForAverageAnyCaseForAstore.rpt"))
        '            End If
        '            FileName = "Item_Inventory_Report"
        '            Report.Refresh()
        '            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        '            di.Create()
        '            Dim StatDate As Date = "01/03/2015"
        '            Dim EndDate As Date = txtDateTo.SelectedDate
        '            Dim ReportName As String = "ITEM INVENTORY"
        '            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        '            Report.SetParameterValue(0, txtFabricCode.Text)
        '            Report.SetParameterValue(1, OpeningBalance)
        '            Report.SetParameterValue(2, StatDate)
        '            Report.SetParameterValue(3, EndDate)
        '            Report.SetParameterValue(4, openDate)
        '            Report.SetParameterValue(5, Prevoiusbalance)
        '            Report.SetParameterValue(6, lOCATIONid)
        '            Report.SetParameterValue(7, cmbGodown.SelectedItem.Text)
        '            Report.SetParameterValue(8, ReportName)
        '            Dim FileOption As New DiskFileDestinationOptions
        '            FileOption.DiskFileName = sTempFileName
        '            Options = Report.ExportOptions
        '            Options.ExportDestinationType = ExportDestinationType.DiskFile
        '            Options.ExportFormatType = ExportFormatType.PortableDocFormat
        '            Options.DestinationOptions = FileOption
        '            Options.ExportDestinationOptions = FileOption
        '            Report.SetDatabaseLogon("sa", "pwd")
        '            Report.Export()
        '            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
        '                Dim strFileSize As String = ""
        '                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
        '                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
        '                Dim fi As IO.FileInfo
        '                For Each fi In aryFi
        '                    Response.ClearHeaders()
        '                    Response.ClearContent()
        '                    Response.ContentType = "application/octet-stream"
        '                    Response.Charset = "UTF-8"
        '                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
        '                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
        '                    Response.End()
        '                Next
        '            End If
        'End If
        'End If
        'End If
    End Sub
End Class

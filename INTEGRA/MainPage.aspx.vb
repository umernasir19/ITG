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
    Public Class MainPage
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
    Dim objUserConfirmation As New UserConfirmation
    Dim objTempCustomerFilter As New TempCustomerFilter
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objTempPurchasingSummary As New TempPurchasingSummary
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim objTempTurnover As New TempTurnover
    Dim objTempTotalSamples As New TempTotalSamples
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ID = Request.QueryString("ID")
            Type = Request.QueryString("Type")
            If Not Page.IsPostBack Then
            UserID = CLng(Session("Userid"))
            lblUserId.Text = CLng(Session("Userid"))
            RoleId = CLng(Session("RoleId"))
            BindCustomer()
            BindSeason()
            BindSupplier()
            Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    pnlChart.Visible = True
                    Chart_Chart1()
                    Chart_Chart2()
                    Chart_Chart3()
                    Chart_Chart4()
                    GetUserInfo(UserID)
                Else
                    GetUserInfo(UserID)
                    pnlChart.Visible = False
                End If
            End If
            Dim dtt As DataTable = objUser.GetUSerNotification(UserID)
            If dtt.Rows(0)("ViewNotification") = True And dtt.Rows(0)("SaveNotification") = False And dtt.Rows(0)("CancelNotification") = False Then
                Dim script As String = "function f(){$find(""" + rw1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                Dim dttt As DataTable = objUser.GetUSerMsg(UserID)
                lblUserName.Text = dtt.Rows(0)("UserName")
                rblmsg1.DataSource = dttt
                rblmsg1.DataTextField = "Msg"
                rblmsg1.DataValueField = "MsgId"
                rblmsg1.DataBind()
            End If
        End If
    End Sub
    Sub BindSrNoo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSRNOOo.DataSource = dtInvoiceNo
            cmbSRNOOo.DataTextField = "SrNO"
            cmbSRNOOo.DataValueField = "JobOrderID"
            cmbSRNOOo.DataBind()
            cmbSRNOOo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNooturnover()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmSeasonTotalTurnover.SelectedValue)
            cmSrNoTotalTurnover.DataSource = dtInvoiceNo
            cmSrNoTotalTurnover.DataTextField = "SrNO"
            cmSrNoTotalTurnover.DataValueField = "JobOrderID"
            cmSrNoTotalTurnover.DataBind()
            cmSrNoTotalTurnover.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNoo()
            Dim script As String = "function f(){$find(""" + rwTotalBooked.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmSeasonTotalTurnover_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmSeasonTotalTurnover.SelectedIndexChanged
        Try
            BindSrNooturnover()
            Dim script As String = "function f(){$find(""" + rwTotalTurnover.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
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
            cmbSeason.Items.Insert(0, "All")

            cmSeasonTotalTurnover.DataSource = dtcmbSeason
            cmSeasonTotalTurnover.DataTextField = "SeasonName"
            cmSeasonTotalTurnover.DataValueField = "SeasonDatabaseID"
            cmSeasonTotalTurnover.DataBind()
            cmSeasonTotalTurnover.Items.Insert(0, "All")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNewgetSRNO(cmbCustomer.SelectedValue)
            cmbSrNoo.DataSource = dtInvoiceNo
            cmbSrNoo.DataTextField = "SrNO"
            cmbSrNoo.DataValueField = "JobOrderID"
            cmbSrNoo.DataBind()
            cmbSrNoo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            BindSrNo()
            Dim script As String = "function f(){$find(""" + rwCustomer.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dt As DataTable = objSizeRange.GetCustomerNameByFilterData()
            cmbCustomer.DataSource = dt
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSupplierForSamples()
            cmbSupplierSamples.DataSource = dtInvoiceNo
            cmbSupplierSamples.DataTextField = "SupplierName"
            cmbSupplierSamples.DataValueField = "SupplierDatabaseId"
            cmbSupplierSamples.DataBind()
            cmbSupplierSamples.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub



    Protected Sub btnPI8Save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPI8Save.Click
        Try
            If rblmsg1.SelectedIndex = -1 Then
                lblErrorMsg.Text = "Please check any one option"
                Dim script As String = "function f(){$find(""" + rw1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            Else
                lblErrorMsg.Text = ""
                With objUserConfirmation
                    .ConfirmationID = 0
                    .UserID = lblUserId.Text
                    .MsgID = rblmsg1.SelectedValue
                    .CreationDate = Date.Now
                    .Save()
                End With
                Dim dt As DataTable = objUser.UpdateUserSaveStatus(lblUserId.Text)
                Dim script As String = "function f(){$find(""" + rw1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
                Dim dte As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
                If dte.Rows.Count > 0 Then
                    If dte.Rows(0)("Department") = "Higher Management" Then
                        pnlChart.Visible = True
                        Chart_Chart1()
                        Chart_Chart2()
                        Chart_Chart3()
                        Chart_Chart4()
                        GetUserInfo(UserID)
                    Else
                        GetUserInfo(UserID)
                        pnlChart.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPI8Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPI8Cancel.Click
        Try
            Dim dt As DataTable = objUser.UpdateUserCancelStatus(lblUserId.Text)
            Dim script As String = "function f(){$find(""" + rw1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
            Dim dte As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
            If dte.Rows.Count > 0 Then
                If dte.Rows(0)("Department") = "Higher Management" Then
                    pnlChart.Visible = True
                    Chart_Chart1()
                    Chart_Chart2()
                    Chart_Chart3()
                    Chart_Chart4()
                    GetUserInfo(UserID)
                Else
                    GetUserInfo(UserID)
                    pnlChart.Visible = False
                End If
            End If
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
    Sub Chart_Chart1()
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
            Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonIdNew
            Dim ID As Long = dtt.Rows(0)("SeasonDatabaseID")
            Dim dttAllQty As DataTable = objSizeRange.GetCustomerViseAllDataAllCase()
            Dim dtCustomer As DataTable = objSizeRange.GetDistinctCustomerFiltringSeasonViseAllCaseNew()
            Dim x As Integer
            For x = 0 To dtCustomer.Rows.Count - 1
                Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltring8888888888AllCase(dtCustomer.Rows(x)("CustomerId"))
                If dt.Rows.Count > 0 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim TotalQty As Decimal = 0
                    Dim Qty As Decimal = 0
                    Dim FinalQty As Decimal = 0
                    TotalQty = dttAllQty.Rows(0)("Quantity")
                    Qty = Convert.ToInt32(dt.Compute("SUM(Quantity)", String.Empty))
                    FinalQty = Qty / TotalQty
                    If FinalQty > 0 Then
                        dr = dtQtyVise.NewRow()
                        dr("Value") = FinalQty
                        dr("Name") = dtCustomer.Rows(x)("CustomerName")
                        dtQtyVise.Rows.Add(dr)
                    End If
                End If
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
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim x As Integer
            x = 0
            For x = 0 To 11
                If x = 0 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDJan(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jan"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 1 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDFeb(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Feb"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 2 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDMarch(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Mar"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 3 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDApril(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Apr"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 4 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDMay(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "May"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 5 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDJune(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jun"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 6 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDJuly(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jul"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 7 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDAug(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Aug"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 8 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDSep(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Sep"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 9 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDOct(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Oct"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 10 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDNov(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Nov"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 11 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataRNDDec(Year)
                    If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = dtCurrentYear.Rows(0)("Quantity")
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Dec"
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
            Dim dtCurrentYear As DataTable
            Dim dtQtyVise As New DataTable
            dtQtyVise = Nothing
            dtQtyVise = New DataTable
            With dtQtyVise
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim x As Integer
            x = 0
            For x = 0 To 11
                If x = 0 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnJan(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jan"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 1 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnFeb(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Feb"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 2 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnMarch(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Mar"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 3 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnApril(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Apr"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 4 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnMay(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "May"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 5 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnJune(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jun"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 6 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnJuly(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jul"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 7 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnAug(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Aug"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 8 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnSep(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Sep"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 9 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnOct(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Oct"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 10 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnNov(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows(0)("Quantity") > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Nov"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 11 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataVolumnDec(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Dec"
                        dtQtyVise.Rows.Add(dr)
                    End If
                End If
            Next
            Chart3.DataSource = dtQtyVise
            Chart3.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Chart_Chart4()
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
            Dim x As Integer
            x = 0
            For x = 0 To 11
                If x = 0 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverJan(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jan"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 1 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverFeb(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Feb"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 2 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverMarch(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Mar"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 3 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverApril(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Apr"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 4 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverMay(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "May"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 5 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverJune(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jun"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 6 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverJuly(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Jul"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 7 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverAug(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Aug"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 8 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverSep(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Sep"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 9 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverOct(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Oct"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 10 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverNov(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Nov"
                        dtQtyVise.Rows.Add(dr)
                    End If
                ElseIf x = 11 Then
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    Dim Year As String = Date.Now.Year
                    dtCurrentYear = objMGTCustomer.GetDataTurnoverDec(Year)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Dec"
                        dtQtyVise.Rows.Add(dr)
                    End If
                End If
            Next
            Chart4.DataSource = dtQtyVise
            Chart4.DataBind()
        Catch ex As Exception
        End Try
    End Sub



    'Total Booked Orders partial chart


    Protected Sub BtnPartialCustomerChart_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles BtnPartialCustomerChart.Click
        Try
            Dim script As String = "function f(){$find(""" + rwCustomer.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnViewChart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewChart.Click
        objSizeRange.TruncatetabletempPurchasingSummarySrno()
        If cmbCustomer.SelectedItem.Text = "Select" Then
            Label2.Text = "Please Select Customer"
        Else
            Label2.Text = ""
            If cmbSrNoo.CheckedItems.Count > 1 Then
                If cmbSrNoo.Text = "All" Then
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
                    Dim dtsrno As DataTable = objSizeRange.GetSrnOForCuttingNewgetSRNO(cmbCustomer.SelectedValue)
                    If dtsrno.Rows.Count > 0 Then
                        Dim x As Integer
                        For x = 0 To dtsrno.Rows.Count - 1
                            Dim dttAllQty As DataTable = objSizeRange.GetCustomerViseAllDataByFilterDataNewww(cmbCustomer.SelectedValue)
                            Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringForSelectCustomerOLDDDDD(cmbCustomer.SelectedValue, dtsrno.Rows(x)("JoborderId"))
                            If dt.Rows.Count > 0 Then
                                Dim dtShip As DataTable
                                Dim dtOIH As DataTable
                                Dim a, aa As String
                                dtCurrentYear = Nothing
                                Dim TotalQty As Decimal = 0
                                Dim Qty As Decimal = 0
                                Dim FinalQty As Decimal = 0
                                TotalQty = dttAllQty.Rows(0)("Quantity")
                                Qty = Convert.ToInt32(dt.Compute("SUM(Quantity)", String.Empty))
                                FinalQty = Qty / TotalQty
                                If FinalQty > 0 Then
                                    dr = dtQtyVise.NewRow()
                                    dr("Value") = FinalQty
                                    dr("Name") = dtsrno.Rows(x)("SRNO")
                                    dtQtyVise.Rows.Add(dr)
                                End If
                            End If
                        Next
                        CustomerFilterChart.DataSource = dtQtyVise
                        CustomerFilterChart.DataBind()
                        CustomerFilterChart.Visible = True
                    Else
                        CustomerFilterChart.Visible = False
                    End If
                Else
                    Dim xx As Integer
                    For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                        With objTempPurchasingSummary
                            .ID = 0
                            .No = cmbSrNoo.CheckedItems(xx).Text
                            .JobOrdeId = cmbSrNoo.CheckedItems(xx).Value
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
                    Dim dtsrno As DataTable = objSizeRange.GetSRNOOOOOO()
                    If dtsrno.Rows.Count > 0 Then
                        Dim x As Integer
                        For x = 0 To dtsrno.Rows.Count - 1
                            Dim dttAllQty As DataTable = objSizeRange.GetCustomerViseAllDataByFilterDataNewww(cmbCustomer.SelectedValue)
                            Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringForSelectCustomerOLDDDDD(cmbCustomer.SelectedValue, dtsrno.Rows(x)("JobOrdeId"))
                            Dim dttOrderNo As DataTable = objSizeRange.GetJobOrderNoo(dtsrno.Rows(x)("JobOrdeId"))
                            If dt.Rows.Count > 0 Then
                                Dim dtShip As DataTable
                                Dim dtOIH As DataTable
                                Dim a, aa As String
                                dtCurrentYear = Nothing
                                Dim TotalQty As Decimal = 0
                                Dim Qty As Decimal = 0
                                Dim FinalQty As Decimal = 0
                                TotalQty = dttAllQty.Rows(0)("Quantity")
                                Qty = Convert.ToInt32(dt.Compute("SUM(Quantity)", String.Empty))
                                FinalQty = Qty / TotalQty
                                If FinalQty > 0 Then
                                    dr = dtQtyVise.NewRow()
                                    dr("Value") = FinalQty
                                    dr("Name") = dttOrderNo.Rows(0)("SRNO")
                                    dtQtyVise.Rows.Add(dr)
                                End If
                            End If
                        Next
                        CustomerFilterChart.DataSource = dtQtyVise
                        CustomerFilterChart.DataBind()
                        CustomerFilterChart.Visible = True
                    Else
                        CustomerFilterChart.Visible = False
                    End If
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
                    .Columns.Add("Value", GetType(String))
                    .Columns.Add("Name", GetType(String))
                End With
                Dim dtsrno As DataTable = objSizeRange.GetSrnOForCuttingNewgetSRNO(cmbCustomer.SelectedValue)
                If dtsrno.Rows.Count > 0 Then
                    Dim x As Integer
                    For x = 0 To dtsrno.Rows.Count - 1
                        Dim dttAllQty As DataTable = objSizeRange.GetCustomerViseAllDataByFilterDataNewww(cmbCustomer.SelectedValue)
                        Dim dt As DataTable = objSizeRange.GetDataForCustomerFiltringForSelectCustomerOLDDDDD(cmbCustomer.SelectedValue, dtsrno.Rows(x)("JoborderId"))
                        If dt.Rows.Count > 0 Then
                            Dim dtShip As DataTable
                            Dim dtOIH As DataTable
                            Dim a, aa As String
                            dtCurrentYear = Nothing
                            Dim TotalQty As Decimal = 0
                            Dim Qty As Decimal = 0
                            Dim FinalQty As Decimal = 0
                            TotalQty = dttAllQty.Rows(0)("Quantity")
                            Qty = Convert.ToInt32(dt.Compute("SUM(Quantity)", String.Empty))
                            FinalQty = Qty / TotalQty
                            If FinalQty > 0 Then
                                dr = dtQtyVise.NewRow()
                                dr("Value") = FinalQty
                                dr("Name") = dtsrno.Rows(x)("SRNO")
                                dtQtyVise.Rows.Add(dr)
                            End If
                        End If
                    Next
                    CustomerFilterChart.DataSource = dtQtyVise
                    CustomerFilterChart.DataBind()
                    CustomerFilterChart.Visible = True
                Else
                    CustomerFilterChart.Visible = False
                End If
            End If
        End If
        Dim script As String = "function f(){$find(""" + rwCustomer.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Dim script As String = "function f(){$find(""" + rwCustomer.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                pnlChart.Visible = True
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
                pnlChart.Visible = False
            End If
        End If
    End Sub


    'Total Booked partial chart


    Protected Sub btnTotalBooked_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnTotalBooked.Click
        Try
            Dim script As String = "function f(){$find(""" + rwTotalBooked.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnTotalBookedCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTotalBookedCancel.Click
        Dim script As String = "function f(){$find(""" + rwTotalBooked.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                pnlChart.Visible = True
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
                pnlChart.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnTotalBookedd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTotalBookedd.Click
        objSizeRange.TruncatetabletempPurchasingSummarySrno()
        If cmbSeason.SelectedItem.Text = "All" Then
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
            Dim Month As String
            If cmbMonth.SelectedItem.Text = "JAN" Then
                Month = "01"
            ElseIf cmbMonth.SelectedItem.Text = "FEB" Then
                Month = "02"
            ElseIf cmbMonth.SelectedItem.Text = "MAR" Then
                Month = "03"
            ElseIf cmbMonth.SelectedItem.Text = "APR" Then
                Month = "04"
            ElseIf cmbMonth.SelectedItem.Text = "MAY" Then
                Month = "05"
            ElseIf cmbMonth.SelectedItem.Text = "JUN" Then
                Month = "06"
            ElseIf cmbMonth.SelectedItem.Text = "JUL" Then
                Month = "07"
            ElseIf cmbMonth.SelectedItem.Text = "AUG" Then
                Month = "08"
            ElseIf cmbMonth.SelectedItem.Text = "SEP" Then
                Month = "09"
            ElseIf cmbMonth.SelectedItem.Text = "OCT" Then
                Month = "10"
            ElseIf cmbMonth.SelectedItem.Text = "NOV" Then
                Month = "11"
            ElseIf cmbMonth.SelectedItem.Text = "DEC" Then
                Month = "12"
            Else
                Month = "All"
            End If
            Dim MonthName As String = Month
            Dim Yearr As String = cmbYear.SelectedItem.Text
            Dim x As Integer
            Dim dtShip As DataTable
            Dim dtOIH As DataTable
            Dim a, aa As String
            dtCurrentYear = Nothing
            dtCurrentYear = objMGTCustomer.GetReportdateForAcc(Yearr, MonthName)
            If dtCurrentYear.Rows.Count > 0 Then
                dr = dtQtyVise.NewRow()
                Dim Count As Decimal = 0
                Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                If dtCurrentYear.Rows.Count > 0 Then
                    dr("Value") = Count
                Else
                    dr("Value") = 0
                End If
                dr("Name") = "Total Booked - PCS"
                dtQtyVise.Rows.Add(dr)
            End If
            chartPartiall.DataSource = dtQtyVise
            chartPartiall.DataBind()
        Else
            If cmbSRNOOo.CheckedItems.Count > 1 Then
                If cmbSRNOOo.Text = "All" Then
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
                    Dim Month As String
                    If cmbMonth.SelectedItem.Text = "JAN" Then
                        Month = "01"
                    ElseIf cmbMonth.SelectedItem.Text = "FEB" Then
                        Month = "02"
                    ElseIf cmbMonth.SelectedItem.Text = "MAR" Then
                        Month = "03"
                    ElseIf cmbMonth.SelectedItem.Text = "APR" Then
                        Month = "04"
                    ElseIf cmbMonth.SelectedItem.Text = "MAY" Then
                        Month = "05"
                    ElseIf cmbMonth.SelectedItem.Text = "JUN" Then
                        Month = "06"
                    ElseIf cmbMonth.SelectedItem.Text = "JUL" Then
                        Month = "07"
                    ElseIf cmbMonth.SelectedItem.Text = "AUG" Then
                        Month = "08"
                    ElseIf cmbMonth.SelectedItem.Text = "SEP" Then
                        Month = "09"
                    ElseIf cmbMonth.SelectedItem.Text = "OCT" Then
                        Month = "10"
                    ElseIf cmbMonth.SelectedItem.Text = "NOV" Then
                        Month = "11"
                    ElseIf cmbMonth.SelectedItem.Text = "DEC" Then
                        Month = "12"
                    Else
                        Month = "All"
                    End If
                    Dim MonthName As String = Month
                    Dim Yearr As String = cmbYear.SelectedItem.Text
                    Dim x As Integer
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    dtCurrentYear = objMGTCustomer.GetReportdateForAcc(Yearr, MonthName)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Total Booked - PCS"
                        dtQtyVise.Rows.Add(dr)
                    End If
                    chartPartiall.DataSource = dtQtyVise
                    chartPartiall.DataBind()
                Else
                    Dim xx As Integer
                    For xx = 0 To cmbSRNOOo.CheckedItems.Count - 1
                        With objTempPurchasingSummary
                            .ID = 0
                            .No = cmbSRNOOo.CheckedItems(xx).Text
                            .JobOrdeId = cmbSRNOOo.CheckedItems(xx).Value
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
                    Dim Month As String
                    If cmbMonth.SelectedItem.Text = "JAN" Then
                        Month = "01"
                    ElseIf cmbMonth.SelectedItem.Text = "FEB" Then
                        Month = "02"
                    ElseIf cmbMonth.SelectedItem.Text = "MAR" Then
                        Month = "03"
                    ElseIf cmbMonth.SelectedItem.Text = "APR" Then
                        Month = "04"
                    ElseIf cmbMonth.SelectedItem.Text = "MAY" Then
                        Month = "05"
                    ElseIf cmbMonth.SelectedItem.Text = "JUN" Then
                        Month = "06"
                    ElseIf cmbMonth.SelectedItem.Text = "JUL" Then
                        Month = "07"
                    ElseIf cmbMonth.SelectedItem.Text = "AUG" Then
                        Month = "08"
                    ElseIf cmbMonth.SelectedItem.Text = "SEP" Then
                        Month = "09"
                    ElseIf cmbMonth.SelectedItem.Text = "OCT" Then
                        Month = "10"
                    ElseIf cmbMonth.SelectedItem.Text = "NOV" Then
                        Month = "11"
                    ElseIf cmbMonth.SelectedItem.Text = "DEC" Then
                        Month = "12"
                    Else
                        Month = "All"
                    End If
                    Dim MonthName As String = Month
                    Dim Yearr As String = cmbYear.SelectedItem.Text
                    Dim x As Integer
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    dtCurrentYear = objMGTCustomer.GetReportdateForAccOrderWIse(Yearr, MonthName)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Total Booked - PCS"
                        dtQtyVise.Rows.Add(dr)
                    End If
                    chartPartiall.DataSource = dtQtyVise
                    chartPartiall.DataBind()
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
                    .Columns.Add("Value", GetType(String))
                    .Columns.Add("Name", GetType(String))
                End With
                Dim Month As String
                If cmbMonth.SelectedItem.Text = "JAN" Then
                    Month = "01"
                ElseIf cmbMonth.SelectedItem.Text = "FEB" Then
                    Month = "02"
                ElseIf cmbMonth.SelectedItem.Text = "MAR" Then
                    Month = "03"
                ElseIf cmbMonth.SelectedItem.Text = "APR" Then
                    Month = "04"
                ElseIf cmbMonth.SelectedItem.Text = "MAY" Then
                    Month = "05"
                ElseIf cmbMonth.SelectedItem.Text = "JUN" Then
                    Month = "06"
                ElseIf cmbMonth.SelectedItem.Text = "JUL" Then
                    Month = "07"
                ElseIf cmbMonth.SelectedItem.Text = "AUG" Then
                    Month = "08"
                ElseIf cmbMonth.SelectedItem.Text = "SEP" Then
                    Month = "09"
                ElseIf cmbMonth.SelectedItem.Text = "OCT" Then
                    Month = "10"
                ElseIf cmbMonth.SelectedItem.Text = "NOV" Then
                    Month = "11"
                ElseIf cmbMonth.SelectedItem.Text = "DEC" Then
                    Month = "12"
                Else
                    Month = "All"
                End If
                Dim MonthName As String = Month
                Dim Yearr As String = cmbYear.SelectedItem.Text
                Dim x As Integer
                Dim dtShip As DataTable
                Dim dtOIH As DataTable
                Dim a, aa As String
                dtCurrentYear = Nothing
                dtCurrentYear = objMGTCustomer.GetReportdateForAcc(Yearr, MonthName)
                If dtCurrentYear.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    Dim Count As Decimal = 0
                    Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr("Value") = Count
                    Else
                        dr("Value") = 0
                    End If
                    dr("Name") = "Total Booked - PCS"
                    dtQtyVise.Rows.Add(dr)
                End If
                chartPartiall.DataSource = dtQtyVise
                chartPartiall.DataBind()
            End If
        End If
            Dim script As String = "function f(){$find(""" + rwTotalBooked.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub



    'Total Turnover partial chart

    Protected Sub BtnViewTotalTurnover_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles BtnViewTotalTurnover.Click
        Try
            Dim script As String = "function f(){$find(""" + rwTotalTurnover.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub CancelTotalTurnover_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelTotalTurnover.Click
        Dim script As String = "function f(){$find(""" + rwTotalTurnover.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                pnlChart.Visible = True
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
                pnlChart.Visible = False
            End If
        End If
    End Sub
    Protected Sub ViewTotalTurnover_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ViewTotalTurnover.Click
        objSizeRange.TruncatetabletempTurnover()
        If cmSeasonTotalTurnover.SelectedItem.Text = "All" Then
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
            Dim Month As String
            If cmbMonthTotalTurnover.SelectedItem.Text = "JAN" Then
                Month = "01"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "FEB" Then
                Month = "02"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAR" Then
                Month = "03"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "APR" Then
                Month = "04"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAY" Then
                Month = "05"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUN" Then
                Month = "06"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUL" Then
                Month = "07"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "AUG" Then
                Month = "08"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "SEP" Then
                Month = "09"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "OCT" Then
                Month = "10"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "NOV" Then
                Month = "11"
            ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "DEC" Then
                Month = "12"
            Else
                Month = "All"
            End If
            Dim MonthName As String = Month
            Dim Yearr As String = cmbYearTotalTurnover.SelectedItem.Text
            Dim x As Integer
            Dim dtShip As DataTable
            Dim dtOIH As DataTable
            Dim a, aa As String
            dtCurrentYear = Nothing
            dtCurrentYear = objMGTCustomer.GetTurnover(Yearr, MonthName)
            If dtCurrentYear.Rows.Count > 0 Then
                dr = dtQtyVise.NewRow()
                Dim Count As Decimal = 0
                Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                If dtCurrentYear.Rows.Count > 0 Then
                    dr("Value") = Count / 1000
                Else
                    dr("Value") = 0
                End If
                dr("Name") = "Total Turnover"
                dtQtyVise.Rows.Add(dr)
            End If
            ChartTotalTurnover.DataSource = dtQtyVise
            ChartTotalTurnover.DataBind()
        Else
            If cmSrNoTotalTurnover.CheckedItems.Count > 1 Then
                If cmSrNoTotalTurnover.Text = "All" Then
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
                    Dim Month As String
                    If cmbMonthTotalTurnover.SelectedItem.Text = "JAN" Then
                        Month = "01"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "FEB" Then
                        Month = "02"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAR" Then
                        Month = "03"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "APR" Then
                        Month = "04"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAY" Then
                        Month = "05"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUN" Then
                        Month = "06"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUL" Then
                        Month = "07"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "AUG" Then
                        Month = "08"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "SEP" Then
                        Month = "09"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "OCT" Then
                        Month = "10"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "NOV" Then
                        Month = "11"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "DEC" Then
                        Month = "12"
                    Else
                        Month = "All"
                    End If
                    Dim MonthName As String = Month
                    Dim Yearr As String = cmbYearTotalTurnover.SelectedItem.Text
                    Dim x As Integer
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    dtCurrentYear = objMGTCustomer.GetTurnover(Yearr, MonthName)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Total Turnover"
                        dtQtyVise.Rows.Add(dr)
                    End If
                    ChartTotalTurnover.DataSource = dtQtyVise
                    ChartTotalTurnover.DataBind()
                Else
                    Dim xx As Integer
                    For xx = 0 To cmSrNoTotalTurnover.CheckedItems.Count - 1
                        With objTempTurnover
                            .ID = 0
                            .No = cmSrNoTotalTurnover.CheckedItems(xx).Text
                            .JobOrdeId = cmSrNoTotalTurnover.CheckedItems(xx).Value
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
                    Dim Month As String
                    If cmbMonthTotalTurnover.SelectedItem.Text = "JAN" Then
                        Month = "01"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "FEB" Then
                        Month = "02"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAR" Then
                        Month = "03"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "APR" Then
                        Month = "04"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAY" Then
                        Month = "05"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUN" Then
                        Month = "06"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUL" Then
                        Month = "07"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "AUG" Then
                        Month = "08"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "SEP" Then
                        Month = "09"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "OCT" Then
                        Month = "10"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "NOV" Then
                        Month = "11"
                    ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "DEC" Then
                        Month = "12"
                    Else
                        Month = "All"
                    End If
                    Dim MonthName As String = Month
                    Dim Yearr As String = cmbYearTotalTurnover.SelectedItem.Text
                    Dim x As Integer
                    Dim dtShip As DataTable
                    Dim dtOIH As DataTable
                    Dim a, aa As String
                    dtCurrentYear = Nothing
                    dtCurrentYear = objMGTCustomer.GetTurnoverOrderVise(Yearr, MonthName)
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr = dtQtyVise.NewRow()
                        Dim Count As Decimal = 0
                        Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                        If dtCurrentYear.Rows.Count > 0 Then
                            dr("Value") = Count / 1000
                        Else
                            dr("Value") = 0
                        End If
                        dr("Name") = "Total Turnover"
                        dtQtyVise.Rows.Add(dr)
                    End If
                    ChartTotalTurnover.DataSource = dtQtyVise
                    ChartTotalTurnover.DataBind()
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
                    .Columns.Add("Value", GetType(String))
                    .Columns.Add("Name", GetType(String))
                End With
                Dim Month As String
                If cmbMonthTotalTurnover.SelectedItem.Text = "JAN" Then
                    Month = "01"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "FEB" Then
                    Month = "02"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAR" Then
                    Month = "03"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "APR" Then
                    Month = "04"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "MAY" Then
                    Month = "05"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUN" Then
                    Month = "06"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "JUL" Then
                    Month = "07"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "AUG" Then
                    Month = "08"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "SEP" Then
                    Month = "09"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "OCT" Then
                    Month = "10"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "NOV" Then
                    Month = "11"
                ElseIf cmbMonthTotalTurnover.SelectedItem.Text = "DEC" Then
                    Month = "12"
                Else
                    Month = "All"
                End If
                Dim MonthName As String = Month
                Dim Yearr As String = cmbYearTotalTurnover.SelectedItem.Text
                Dim x As Integer
                Dim dtShip As DataTable
                Dim dtOIH As DataTable
                Dim a, aa As String
                dtCurrentYear = Nothing
                dtCurrentYear = objMGTCustomer.GetTurnover(Yearr, MonthName)
                If dtCurrentYear.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    Dim Count As Decimal = 0
                    Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr("Value") = Count / 1000
                    Else
                        dr("Value") = 0
                    End If
                    dr("Name") = "Total Turnover"
                    dtQtyVise.Rows.Add(dr)
                End If
                ChartTotalTurnover.DataSource = dtQtyVise
                ChartTotalTurnover.DataBind()
            End If
        End If
        Dim script As String = "function f(){$find(""" + rwTotalTurnover.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub

    'Total Samples partial chart

    Protected Sub btnTotalSample_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnTotalSample.Click
        Try
            Dim script As String = "function f(){$find(""" + rwTotalNoofSamples.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancelbtnTotalNoofSamples_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelbtnTotalNoofSamples.Click
        Dim script As String = "function f(){$find(""" + rwTotalNoofSamples.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, False)
        Dim dt As DataTable = ObjSupplier.GetUserStatus(lblUserId.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                pnlChart.Visible = True
                Chart_Chart1()
                Chart_Chart2()
                Chart_Chart3()
                Chart_Chart4()
                GetUserInfo(UserID)
            Else
                GetUserInfo(UserID)
                pnlChart.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnTotalNoofSamples_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTotalNoofSamples.Click
        objSizeRange.TruncatetabletempTotalSamples()
        If cmbSupplierSamples.CheckedItems.Count > 0 Then
            If cmbSupplierSamples.Text = "All" Then
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
                Dim Month As String
                If cmbMonthTotalNoofSamples.SelectedItem.Text = "JAN" Then
                    Month = "01"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "FEB" Then
                    Month = "02"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAR" Then
                    Month = "03"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "APR" Then
                    Month = "04"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAY" Then
                    Month = "05"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUN" Then
                    Month = "06"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUL" Then
                    Month = "07"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "AUG" Then
                    Month = "08"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "SEP" Then
                    Month = "09"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "OCT" Then
                    Month = "10"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "NOV" Then
                    Month = "11"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "DEC" Then
                    Month = "12"
                Else
                    Month = "All"
                End If
                Dim MonthName As String = Month
                Dim Yearr As String = cmbYearTotalNoofSamples.SelectedItem.Text
                Dim x As Integer
                Dim dtShip As DataTable
                Dim dtOIH As DataTable
                Dim a, aa As String
                dtCurrentYear = Nothing
                dtCurrentYear = objMGTCustomer.GetTotalSamples(Yearr, MonthName)
                If dtCurrentYear.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    Dim Count As Decimal = 0
                    Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr("Value") = Count
                    Else
                        dr("Value") = 0
                    End If
                    dr("Name") = "Total No. of Samples"
                    dtQtyVise.Rows.Add(dr)
                End If
                ChartTotalNoofSamples.DataSource = dtQtyVise
                ChartTotalNoofSamples.DataBind()
            Else
                Dim xx As Integer
                For xx = 0 To cmbSupplierSamples.CheckedItems.Count - 1
                    With objTempTotalSamples
                        .ID = 0
                        .No = cmbSupplierSamples.CheckedItems(xx).Text
                        .SupplierId = cmbSupplierSamples.CheckedItems(xx).Value
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
                Dim Month As String
                If cmbMonthTotalNoofSamples.SelectedItem.Text = "JAN" Then
                    Month = "01"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "FEB" Then
                    Month = "02"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAR" Then
                    Month = "03"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "APR" Then
                    Month = "04"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAY" Then
                    Month = "05"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUN" Then
                    Month = "06"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUL" Then
                    Month = "07"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "AUG" Then
                    Month = "08"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "SEP" Then
                    Month = "09"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "OCT" Then
                    Month = "10"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "NOV" Then
                    Month = "11"
                ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "DEC" Then
                    Month = "12"
                Else
                    Month = "All"
                End If
                Dim MonthName As String = Month
                Dim Yearr As String = cmbYearTotalNoofSamples.SelectedItem.Text
                Dim x As Integer
                Dim dtShip As DataTable
                Dim dtOIH As DataTable
                Dim a, aa As String
                dtCurrentYear = Nothing
                dtCurrentYear = objMGTCustomer.GetTotalSamplesSupplierVise(Yearr, MonthName)
                If dtCurrentYear.Rows.Count > 0 Then
                    dr = dtQtyVise.NewRow()
                    Dim Count As Decimal = 0
                    Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                    If dtCurrentYear.Rows.Count > 0 Then
                        dr("Value") = Count
                    Else
                        dr("Value") = 0
                    End If
                    dr("Name") = "Total No. of Samples"
                    dtQtyVise.Rows.Add(dr)
                End If
                ChartTotalNoofSamples.DataSource = dtQtyVise
                ChartTotalNoofSamples.DataBind()
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
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Name", GetType(String))
            End With
            Dim Month As String
            If cmbMonthTotalNoofSamples.SelectedItem.Text = "JAN" Then
                Month = "01"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "FEB" Then
                Month = "02"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAR" Then
                Month = "03"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "APR" Then
                Month = "04"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "MAY" Then
                Month = "05"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUN" Then
                Month = "06"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "JUL" Then
                Month = "07"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "AUG" Then
                Month = "08"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "SEP" Then
                Month = "09"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "OCT" Then
                Month = "10"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "NOV" Then
                Month = "11"
            ElseIf cmbMonthTotalNoofSamples.SelectedItem.Text = "DEC" Then
                Month = "12"
            Else
                Month = "All"
            End If
            Dim MonthName As String = Month
            Dim Yearr As String = cmbYearTotalNoofSamples.SelectedItem.Text
            Dim x As Integer
            Dim dtShip As DataTable
            Dim dtOIH As DataTable
            Dim a, aa As String
            dtCurrentYear = Nothing
            dtCurrentYear = objMGTCustomer.GetTotalSamples(Yearr, MonthName)
            If dtCurrentYear.Rows.Count > 0 Then
                dr = dtQtyVise.NewRow()
                Dim Count As Decimal = 0
                Count = Convert.ToInt32(dtCurrentYear.Compute("SUM(Quantity)", String.Empty))
                If dtCurrentYear.Rows.Count > 0 Then
                    dr("Value") = Count
                Else
                    dr("Value") = 0
                End If
                dr("Name") = "Total No. of Samples"
                dtQtyVise.Rows.Add(dr)
            End If
            ChartTotalNoofSamples.DataSource = dtQtyVise
            ChartTotalNoofSamples.DataBind()
        End If
        Dim script As String = "function f(){$find(""" + rwTotalNoofSamples.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
End Class

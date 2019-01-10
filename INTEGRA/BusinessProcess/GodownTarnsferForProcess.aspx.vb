
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class GodownTarnsferForProcess
    Inherits System.Web.UI.Page
    Dim dtItemIssue As New DataTable
    Dim Dr As DataRow
    Dim ObjUser As New EuroCentra.User
    Dim lGodownIssueID As Long
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjIMSItem As New IMSItem
    Dim Userid As Long
    Dim InhandQty As Decimal
    Dim TansactionMethod As String
    Dim objGodownIssueMst As New GodownIssueMst
    Dim objGodownIssueDetail As New GodownIssueDetail
    Dim ObjIssue As New IssueMst
    Dim objGodownIssueMstForProcess As New GodownIssueMstForProcess
    Dim objGodownIssueDetailForProcess As New GodownIssueDetailForProcess
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lGodownIssueID = Request.QueryString("GodownIssueID")
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            BindLocation()
            BindSeason()
            BindSrNoAll()
            Session("dtSelection") = Nothing
            Session("dtItemIssue") = Nothing
            txtTodayis.Text = Date.Now.ToString("dd/MM/yyyy")
            Dim dtInfo As DataTable = ObjUser.GetUSerInfoNew(CLng(Session("Userid")))
            If lGodownIssueID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
            End If
        End If
        PageHeader("Godown Tarnsfer Entry Form")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub txtQtyIssue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyIssue.TextChanged
        Try
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssue()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindSrNoAll()
        Dim dtt As DataTable
        dtt = ObjIssue.GetSrNoForGodownNewAll()
        cmbSrNo.DataSource = dtt
        cmbSrNo.DataTextField = "SrNo"
        cmbSrNo.DataValueField = "JobOrderID"
        cmbSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable
        dtt = ObjIssue.GetSrNoForGodownNewNew(cmbSeason.SelectedValue)
        cmbSrNo.DataSource = dtt
        cmbSrNo.DataTextField = "SrNo"
        cmbSrNo.DataValueField = "JobOrderID"
        cmbSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub txtITEMCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITEMCODE.TextChanged
        Try
            Dim GetID As DataTable = ObjIssue.GetIMSItemNameForIssue(txtITEMCODE.Text)
            lblItemId.Text = GetID.Rows(0)("IMSItemID")
            txtITEMNAME.Text = GetID.Rows(0)("ItemName")
            If cmbLocationFrom.SelectedValue = 10 Then
                Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                Dim dtIssueSubtarct As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtarct.Rows(0)("RecvQty")
            Else
                Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(lblItemId.Text, cmbLocationFrom.SelectedValue)
                Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvNewwwForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable
            dtt = ObjIssue.GetSrNoForGodownNewNew(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtt
            cmbSrNo.DataTextField = "SrNo"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("Select", "0"))
            If cmbSeason.SelectedItem.Text = "Select" And cmbSrNo.SelectedItem.Text = "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtIssueSubtarct As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtarct.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text = "Select" And cmbSrNo.SelectedItem.Text <> "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtIssueSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseOnlySRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForSubtractForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text <> "Select" And cmbSrNo.SelectedItem.Text = "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtIssueSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForSubtractForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseSeasonForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text <> "Select" And cmbSrNo.SelectedItem.Text <> "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtIssueForSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueForSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseSeasonaNDSRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForProcess(lblItemId.Text, cmbLocationTo.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForSubtractForprocessNew(lblItemId.Text, cmbLocationTo.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            If cmbSeason.SelectedItem.Text = "Select" And cmbSrNo.SelectedItem.Text = "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtIssueSubtarct As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtarct.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(lblItemId.Text, cmbLocationFrom.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text = "Select" And cmbSrNo.SelectedItem.Text <> "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtIssueSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseOnlySRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForSubtractForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text <> "Select" And cmbSrNo.SelectedItem.Text = "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtIssueSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForSubtractForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseSeasonForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            ElseIf cmbSeason.SelectedItem.Text <> "Select" And cmbSrNo.SelectedItem.Text <> "Select" Then
                If cmbLocationFrom.SelectedValue = 10 Then
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtIssueForSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForSubtractForprocess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = dtIssue.Rows(0)("RecvQty") - dtIssueForSubtract.Rows(0)("RecvQty")
                Else
                    Dim dtIssue As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseSeasonaNDSRNOForProcess(lblItemId.Text, cmbLocationFrom.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecv As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForProcess(lblItemId.Text, cmbLocationTo.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    Dim dtRecvSubtract As DataTable = ObjIssue.GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForSubtractForprocessNew(lblItemId.Text, cmbLocationTo.SelectedValue, cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
                    txtQtyInHand.Text = (dtIssue.Rows(0)("IssueQty") + dtRecv.Rows(0)("RecvQty")) - dtRecvSubtract.Rows(0)("RecvQty")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub GetInhandQty()
        Dim dt As DataTable = ObjIssue.GetInhandQtyForGodownTransferForProcess(lblItemId.Text, cmbSrNo.SelectedValue, cmbSeason.SelectedValue, cmbLocationFrom.SelectedValue)
        If dt.Rows.Count > 0 Then
            txtQtyInHand.Text = dt.Rows(0)("IssueQty")
        Else
            txtQtyInHand.Text = 0
        End If
    End Sub
    Sub BindLocation()
        Dim dt As DataTable
        dt = objGodownIssueMst.BindLocation()
        cmbLocationFrom.DataSource = dt
        cmbLocationFrom.DataTextField = "Location"
        cmbLocationFrom.DataValueField = "LocationId"
        cmbLocationFrom.DataBind()
        cmbLocationFrom.Items.Insert(0, New ListItem("Select", "0"))

        cmbLocationTo.DataSource = dt
        cmbLocationTo.DataTextField = "Location"
        cmbLocationTo.DataValueField = "LocationId"
        cmbLocationTo.DataBind()
        cmbLocationTo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtTodayis.Text
            Dim month As String = Voucherdate.Month
            Dim year As String = Voucherdate.Year
            Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = objGodownIssueMst.GetIssueCodeNew(year)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(7, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            If Userid = 241 Then
                VoucherNo = "DAL" & "-" & "FG" & "-" & LastCode & "-" & yearv
                txtStoreIssueVoucherNo.Text = VoucherNo
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                VoucherNo = "DAL" & "-" & "FG" & "-" & LastCode & "-" & yearv
                txtStoreIssueVoucherNo.Text = VoucherNo
            ElseIf Userid = 242 Then
                VoucherNo = "DAL" & "-" & "AG" & "-" & LastCode & "-" & yearv
                txtStoreIssueVoucherNo.Text = VoucherNo
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            If txtQtyIssue.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Qty. empty")
            ElseIf Val(txtQtyIssue.Text) > Val(txtQtyInHand.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Qty exceed")
            ElseIf cmbLocationFrom.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location From")
            ElseIf cmbLocationTo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location To")
            ElseIf cmbLocationFrom.SelectedValue = cmbLocationTo.SelectedValue Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select different Location")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                FillGridByStyle()
                BindGridNew()
                Session("dtSelection") = Nothing
                ClearText()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub FillGridByStyle()
        Dim bShouldAdd As Boolean = True
        Dim isEmployeeExist As Boolean = False
        If (Not CType(Session("dtItemIssue"), DataTable) Is Nothing) Then
            dtItemIssue = Session("dtItemIssue")
        Else
            dtItemIssue = New DataTable
            With dtItemIssue
                .Columns.Add("GodownIssueDetailID", GetType(String))
                .Columns.Add("IMSItemID", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("QtyInHand", GetType(String))
                .Columns.Add("QtyIssue", GetType(String))
                .Columns.Add("TransactionMethodID", GetType(String))
                .Columns.Add("FromLocationID", GetType(String))
                .Columns.Add("FromLocation", GetType(String))
                .Columns.Add("ToLocationID", GetType(String))
                .Columns.Add("ToLocation", GetType(String))
                .Columns.Add("Rate", GetType(String))
            End With
        End If
        Dr = dtItemIssue.NewRow()
        If lblGodownIssueDetailID.Text = "" Then
            Dr("GodownIssueDetailID") = 0
        Else
            Dr("GodownIssueDetailID") = lblGodownIssueDetailID.Text
        End If
        Dr("IMSItemID") = lblItemId.Text
        Dr("ItemCodee") = txtITEMCODE.Text
        Dr("ItemName") = txtITEMNAME.Text
        Dr("QtyInHand") = Val(txtQtyInHand.Text)
        Dr("QtyIssue") = Val(txtQtyIssue.Text)
        Dr("TransactionMethodID") = 0
        Dr("FromLocationID") = cmbLocationFrom.SelectedValue
        Dr("FromLocation") = cmbLocationFrom.SelectedItem.Text
        Dr("ToLocationID") = cmbLocationTo.SelectedValue
        Dr("ToLocation") = cmbLocationTo.SelectedItem.Text
        If txtRate.Text = "" Then
            Dr("Rate") = 0
        Else
            Dr("Rate") = txtRate.Text
        End If
        dtItemIssue.Rows.Add(Dr)
        Session("dtItemIssue") = dtItemIssue
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtItemIssue Is Nothing) Then
            If (dtItemIssue.Rows.Count > 0) Then
                dgItemView.DataSource = dtItemIssue
                dgItemView.RecordCount = dtItemIssue.Rows.Count
                dgItemView.DataBind()
                dgItemView.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Sub BindGridNew()
        If (Not dtItemIssue Is Nothing) Then
            If (dtItemIssue.Rows.Count > 0) Then
                dgItemView.DataSource = dtItemIssue
                dgItemView.RecordCount = dtItemIssue.Rows.Count
                dgItemView.DataBind()
                dgItemView.Visible = True
            Else
                dgItemView.Visible = False
            End If
        End If
    End Sub
    Sub ClearText()
        Try
            txtITEMCODE.Text = ""
            txtITEMNAME.Text = ""
            txtQtyIssue.Text = ""
            txtTransactionMethodID.Text = ""
            IMSItemID.Text = ""
            txtQtyInHand.Text = ""
            txtRate.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date empty.")
            ElseIf dgItemView.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Item required in detail section.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objGodownIssueMstForProcess
                    If lGodownIssueID > 0 Then
                        .GodownIssueID = lGodownIssueID
                    Else
                        .GodownIssueID = 0
                    End If
                    .CreationDate = Date.Now
                    If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                        If lGodownIssueID > 0 Then
                            .CreatedbyID = lblUserId.Text
                        Else
                            .CreatedbyID = 270
                        End If
                    Else
                        If lGodownIssueID > 0 Then
                            .CreatedbyID = lblUserId.Text
                        Else
                            .CreatedbyID = CLng(Session("Userid"))
                        End If
                    End If
                    .EntryDate = txtDate.Text
                    .SIVNo = txtStoreIssueVoucherNo.Text
                    .CCNo = txtCCNo.Text
                    If lGodownIssueID > 0 Then
                        .TokenNo = lGodownIssueID
                    Else
                        .TokenNo = ObjIMSStoreIssue.GetID() + 1
                    End If
                    .CounterNo = txtCounterNo.Text
                    If cmbSeason.SelectedItem.Text = "Select" Then
                        .SeasonDatabaseID = 0
                    Else
                        .SeasonDatabaseID = cmbSeason.SelectedValue
                    End If
                    If cmbSrNo.SelectedItem.Text = "Select" Then
                        .JobOrderID = 0
                    Else
                        .JobOrderID = cmbSrNo.SelectedValue
                    End If
                    If txtChallanNo.Text = "" Then
                        .ChallanNo = ""
                    Else
                        .ChallanNo = txtChallanNo.Text
                    End If
                    If txtRemarks.Text = "" Then
                        .Remarks = ""
                    Else
                        .Remarks = txtRemarks.Text
                    End If
                    .SaveIMSGodownIssue()
                End With
                Dim x As Integer
                For x = 0 To dgItemView.Items.Count - 1
                    Dim txtRate As TextBox = CType(dgItemView.Items(x).FindControl("txtRate"), TextBox)
                    With objGodownIssueDetailForProcess
                        .GodownIssueDetailID = dgItemView.Items(x).Cells(0).Text
                        If lGodownIssueID > 0 Then
                            .GodownIssueID = lGodownIssueID
                        Else
                            .GodownIssueID = objGodownIssueMstForProcess.GetID()
                        End If
                        .IMSItemID = dgItemView.Items(x).Cells(1).Text
                        .QtyIssue = dgItemView.Items(x).Cells(9).Text
                        .QtyInHand = dgItemView.Items(x).Cells(8).Text
                        .TransactionMethodID = dgItemView.Items(x).Cells(10).Text
                        .FromLocationID = dgItemView.Items(x).Cells(3).Text
                        .ToLocationID = dgItemView.Items(x).Cells(5).Text
                        .Rate = txtRate.Text
                        .SaveIMSStoreIssueDetail()
                    End With
                Next
                Session("dtSelection") = Nothing
                Session("dtItemIssue") = Nothing
                Response.Redirect("GodownTransferViewForProcess.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = ObjIMSStoreIssue.GetEditDataForGodownIssueNewForProcess(lGodownIssueID)
            txtStoreIssueVoucherNo.Text = dt.Rows(0)("SIVNo")
            txtDate.Text = dt.Rows(0)("EntryDate")
            lblUserId.Text = dt.Rows(0)("CreatedbyID")
            txtCCNo.Text = dt.Rows(0)("CCNo")
            txtCounterNo.Text = dt.Rows(0)("CounterNo")
            If dt.Rows(0)("SeasonDatabaseId") <> 0 Then
                cmbSeason.SelectedValue = dt.Rows(0)("SeasondatabaseID")
            End If
            If dt.Rows(0)("JobOrderId") <> 0 Then
                cmbSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            End If
            txtChallanNo.Text = dt.Rows(0)("ChallanNo")
            txtRemarks.Text = dt.Rows(0)("Remarks")
            dtItemIssue = New DataTable
            With dtItemIssue
                .Columns.Add("GodownIssueDetailID", GetType(String))
                .Columns.Add("IMSItemID", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("QtyInHand", GetType(String))
                .Columns.Add("QtyIssue", GetType(String))
                .Columns.Add("TransactionMethodID", GetType(String))
                .Columns.Add("FromLocationID", GetType(String))
                .Columns.Add("FromLocation", GetType(String))
                .Columns.Add("ToLocationID", GetType(String))
                .Columns.Add("ToLocation", GetType(String))
                .Columns.Add("Rate", GetType(String))
            End With
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtItemIssue.NewRow()
                Dr("GodownIssueDetailID") = dt.Rows(x)("GodownIssueDetailID")
                Dr("IMSItemID") = dt.Rows(x)("IMSItemID")
                Dr("ItemCodee") = dt.Rows(x)("ItemCodee")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("QtyInHand") = dt.Rows(x)("QtyInHand")
                Dr("QtyIssue") = dt.Rows(x)("QtyIssue")
                Dr("TransactionMethodID") = 0
                Dr("FromLocationID") = dt.Rows(x)("FromLocationID")
                Dr("FromLocation") = dt.Rows(x)("FromLocation")
                Dr("ToLocationID") = dt.Rows(x)("ToLocationID")
                Dr("ToLocation") = dt.Rows(x)("ToLocation")
                Dr("Rate") = dt.Rows(x)("Rate")
                dtItemIssue.Rows.Add(Dr)
            Next
            Session("dtItemIssue") = dtItemIssue
            BindGrid()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Session("dtSelection") = Nothing
            Session("dtItemIssue") = Nothing
            Response.Redirect("GodownTransferViewForProcess.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class

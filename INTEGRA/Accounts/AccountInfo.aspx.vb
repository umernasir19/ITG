Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class AccountInfo
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New AcntChartOfAccount
    Dim ClickBitG, ClickBitL As String
    Dim ClickBit As String = ""
    Dim objDataView As DataView
    Dim x As Integer
    Dim objDtaBaseSupplier As New SupplierDataBase
    Dim objSupplierDetail As New SupplierDatabaseDetail
    Dim ObjCustomerDatabase As New CustomerDatabase
    Dim ObjCustomerDatabaseDetail As New CustomerDetail
    Dim ObjtblDeleteAccounts As New tblDeleteAccounts
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                BindAccountLevelcombo()
                Session("ClickBit") = Nothing
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Account Information")
    End Sub
    Protected Sub btnBackMainPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBackMainPage.Click
        Try
            Response.Redirect("~/MainPage.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        ClickBit = Session("ClickBit")
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView")
        'dgView.RecordCount = objDataView.Count
        'dgView.DataSource = objDataView
        'dgView.DataBind()
        If objDataView.Count > 0 Then
            strSortExpression = dgView.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgView.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgView.RecordCount = objDataView.Count
            dgView.DataSource = objDataView
            dgView.DataBind()
        Else

        End If

        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim txtAccountNamee As TextBox = DirectCast(dgView.Items(x).FindControl("txtAccountNamee"), TextBox)
            Dim txtOpening_Debit As TextBox = DirectCast(dgView.Items(x).FindControl("txtOpening_Debit"), TextBox)
            Dim txtOpening_Credit As TextBox = DirectCast(dgView.Items(x).FindControl("txtOpening_Credit"), TextBox)
            txtAccountNamee.Text = dgView.Items(x).Cells(1).Text
            txtOpening_Debit.Text = dgView.Items(x).Cells(2).Text
            txtOpening_Credit.Text = dgView.Items(x).Cells(3).Text
            If ClickBit = "Ledger" Then
                dgView.Columns(6).Visible = True
                dgView.Columns(7).Visible = True
            Else
                dgView.Columns(6).Visible = False
                dgView.Columns(7).Visible = False
            End If
        Next


    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal ClickBit As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable ', 
        objDataTable = objChartOfAccount.GetdataForAccountInfoPage(ClickBit)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub

    Protected Sub btnGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            ClickBitG = "Group"
            Session("ClickBit") = ClickBitG
            PanelLedgerCreate.Visible = False
            PanelViewCreateGroup.Visible = True
            PanelViewCreateLedger.Visible = False
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSupplier.Visible = False
            PanelSaveButton.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLedger.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            ClickBitL = "Ledger"
            Session("ClickBit") = ClickBitL
            PanelLedgerCreate.Visible = False
            PanelViewCreateGroup.Visible = False
            PanelViewCreateLedger.Visible = True
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSupplier.Visible = False
            PanelSaveButton.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Function LoadDataOnSearch(ByVal AccountName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        ClickBit = Session("ClickBit")
        objDataTable = objChartOfAccount.GetAccountNameForAccountInfoSearch(AccountName, ClickBit)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If txtShowMe.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Account Name..")
            ElseIf txtShowMe.Text <> "" Then
                Dim objDataView As DataView
                objDataView = LoadDataOnSearch(txtShowMe.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim dtfirst As DataTable = objChartOfAccount.GetAccountGroupSearch(txtShowMe.Text, ClickBit)
                    Dim GroupAccountcode As String
                    lblFirst.Text = dtfirst.Rows(0)("groupActname")
                    GroupAccountcode = dtfirst.Rows(0)("GroupAct")
                    Dim dtSecond As DataTable = objChartOfAccount.GetAccountGroupGroupSearch(GroupAccountcode)
                    lblSecond.Text = dtSecond.Rows(0)("groupActname")

                    If lblSecond.Text = lblFirst.Text Then
                        lblSecond.Text = ""
                    Else

                    End If
                    If lblFirst.Text = txtShowMe.Text Then
                        lblFirst.Text = ""
                    Else

                    End If
                    PnlSearch.Visible = True
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name. Not Exist")
                    PnlSearch.Visible = False
                End If
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Save"
                    Dim txtAccountNamee As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtAccountNamee"), TextBox)
                    Dim txtOpening_Debit As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtOpening_Debit"), TextBox)
                    Dim txtOpening_Credit As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtOpening_Credit"), TextBox)
                    Dim ChartOfAccountID = dgView.Items(e.Item.ItemIndex).Cells(4).Text
                    objChartOfAccount.UpdateAccount(ChartOfAccountID, txtAccountNamee.Text, txtOpening_Debit.Text, txtOpening_Credit.Text)
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Update successfully")
                    ClickBit = Session("ClickBit")
                    objDataView = LoadData(ClickBit)
                    Session("objDataView") = objDataView
                    BindGrid()
                    txtShowMe.Text = ""
                Case "Remove"
                    ClickBit = Session("ClickBit")
                    Dim AccountCode As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dtGroup, DttblJvDtl, DttblBankMst, DttblBankDtl, DtSupplierPODetail, DtSupplierPORecvMaster, DtSupplierPORecvDetailTwo, DtSupplierPOInvoiceMst, DtSupplierIns, DtSupplierInsMst, dtcustomer, DtSupplierYPC, DtSupplierYRYC, DtSupplierYRM, DtSupplierFR, DtSupplierYID, DtSupplierFRec, DtSupplierYReturn As New DataTable
                    If ClickBit = "Ledger" Then
                        'check from Joborder Customer
                        dtcustomer = objChartOfAccount.CheckcustomerinJobtable(AccountCode) '--JobOrderDatabase
                        DtSupplierYPC = objChartOfAccount.CheckSupplierFromYarnPurContract(AccountCode) '--YarnPurchaseContract
                        DtSupplierYRYC = objChartOfAccount.CheckSupplierFromYarnReturnYarnPurContract(AccountCode) '--YarnReturnForYarnPurchaseContract
                        DtSupplierYRM = objChartOfAccount.CheckSupplierFromYarnRecvMaster(AccountCode) '--YarnRecvMaster
                        DtSupplierYID = objChartOfAccount.CheckSupplierFromYarnIssueDtl(AccountCode) '--YarnIssueDtl
                        DtSupplierYReturn = objChartOfAccount.CheckSupplierFromYarnReturn(AccountCode) '--YarnReturn
                        DtSupplierFRec = objChartOfAccount.CheckSupplierFromFabricReceiving(AccountCode) '--FabricReceiving
                        DtSupplierFR = objChartOfAccount.CheckSupplierFromFabricReturn(AccountCode) '--FabricReturn
                        DtSupplierIns = objChartOfAccount.CheckSupplierFromInspection(AccountCode) '--Inspection
                        DtSupplierInsMst = objChartOfAccount.CheckSupplierFromInspectionMst(AccountCode) '--InspectionMst
                        DtSupplierPODetail = objChartOfAccount.CheckSupplierFromPODetail(AccountCode) '--PODetail
                        DtSupplierPORecvMaster = objChartOfAccount.CheckSupplierFromPORecvMaster(AccountCode) '--PORecvMaster
                        DtSupplierPORecvDetailTwo = objChartOfAccount.CheckSupplierFromPORecvDetailTwo(AccountCode) '--PORecvDetailTwo
                        DtSupplierPOInvoiceMst = objChartOfAccount.CheckSupplierFromPOInvoiceMst(AccountCode) '--POInvoiceMst

                        DttblBankMst = objChartOfAccount.CheckSupplierFromtblBankMst(AccountCode) '--tblBankMst
                        DttblBankDtl = objChartOfAccount.CheckSupplierFromtblBankDtl(AccountCode) '--tblBankDtl
                        DttblJvDtl = objChartOfAccount.CheckSupplierFromtblJvDtl(AccountCode) '--tblJvDtl


                        If dtcustomer.Rows.Count > 0 Or DtSupplierYPC.Rows.Count > 0 Or DtSupplierYRYC.Rows.Count > 0 Or DtSupplierYRM.Rows.Count > 0 Or DtSupplierYID.Rows.Count > 0 Or DtSupplierYReturn.Rows.Count > 0 Or DtSupplierFRec.Rows.Count > 0 Or DtSupplierFR.Rows.Count > 0 Or DtSupplierIns.Rows.Count > 0 Or DtSupplierInsMst.Rows.Count > 0 Or DtSupplierPODetail.Rows.Count > 0 Or DtSupplierPORecvMaster.Rows.Count > 0 Or DtSupplierPORecvDetailTwo.Rows.Count > 0 Or DtSupplierPOInvoiceMst.Rows.Count > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Allow To Deleted")
                        Else
                            '----Insert into Delete table data before deleted
                            objChartOfAccount.InsertIntoDeleteAccountsTabale(AccountCode)

                            objChartOfAccount.DeleteCustomerDatabase(AccountCode) '---DeleteCustomerMaster
                            objChartOfAccount.DeleteCustomerDatabase(AccountCode) '---DeleteCustomerDatabaseDetail
                            objChartOfAccount.DeleteSupplierDatabaseDatabase(AccountCode) '---DeleteSupplierDatabase
                            objChartOfAccount.DeleteSupplierDatabaseDatabaseDetail(AccountCode) '---DeleteSupplierDatabaseDetail
                            objChartOfAccount.DeleteCustomerChrtaccount(AccountCode) '---DeleteChartOfAccount
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                            Dim objDataView As DataView
                            'objDataView = LoadData(ClickBitL)
                            'Session("objDataView") = objDataView
                            'BindGrid()
                            objDataView = LoadData(ClickBit)
                            Session("objDataView") = objDataView
                            BindGrid()
                            txtShowMe.Text = ""
                        End If
                    Else
                        dtGroup = objChartOfAccount.Checktblaccounts(AccountCode) '--chkTblaccount detail exist or not
                        If dtGroup.Rows.Count > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Allow To Deleted")
                        Else
                            '----Insert into Delete table data before deleted
                            objChartOfAccount.InsertIntoDeleteAccountsTabale(AccountCode)

                            objChartOfAccount.DeleteGroupChrtaccount(AccountCode) '---DeleteChartOfAccount
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                            Dim objDataView As DataView
                            objDataView = LoadData(ClickBit)
                            Session("objDataView") = objDataView
                            BindGrid()
                            txtShowMe.Text = ""
                        End If
                    End If

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnLedgerView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLedgerView.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            txtShowMe.Text = ""
            ClickBitL = "Ledger"
            Session("ClickBit") = ClickBitL
            objDataView = LoadData(ClickBitL)
            Session("ClickBitG") = Nothing
            Session("objDataView") = objDataView
            BindGrid()
            PnlGropLedgerView.Visible = True
            dgView.Columns(5).Visible = True
            dgView.Columns(8).Visible = False
            dgView.Columns(9).Visible = False
            ' txtShowMe.Text = ""
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSearch.Visible = False
            PnlSupplier.Visible = False
            PanelSaveButton.Visible = False
            lblHeadingMain2.Text = "Ledger View"
            PanelViewCreateGroup.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGrouopView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrouopView.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            txtShowMe.Text = ""
            ClickBitG = "Group"
            Session("ClickBit") = ClickBitG
            objDataView = LoadData(ClickBitG)
            Session("ClickBitL") = Nothing

            objDataView = LoadData(ClickBitG)
            Session("objDataView") = objDataView
            BindGrid()
            PnlGropLedgerView.Visible = True
            dgView.Columns(5).Visible = True
            dgView.Columns(8).Visible = False
            dgView.Columns(9).Visible = False
            ' txtShowMe.Text = ""
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSearch.Visible = False
            PnlSupplier.Visible = False
            lblHeadingMain2.Text = "Group View"
            PanelViewCreateLedger.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnLedgerCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLedgerCreate.Click
        Try

            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            ClearControlTwo()
            PanelLedgerCreate.Visible = True
            PnlSearch.Visible = False

            PanelViewCreateLedger.Visible = False
            PanelViewCreateGroup.Visible = False

            PnlGropLedgerView.Visible = False

            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSupplier.Visible = False
            lblHeading.Text = "Create Ledger"
            PanelViewCreateGroup.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtAllGrouppAuto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllGrouppAuto.TextChanged
        Try
            ClickBit = Session("ClickBit")
            If txtAllGrouppAuto.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Account Name..")
            ElseIf txtAllGrouppAuto.Text <> "" Then
                Dim objDataView As DataView
                objDataView = LoadDataOnCreateLedger(txtAllGrouppAuto.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name. Not Exist")
                End If
                Session("objDataView") = objDataView
                Dim DtAccountInformarion As New DataTable
                Dim dtgroupact As New DataTable
                Dim groupAct As String
                If ClickBit = "Ledger" Then
                    dtgroupact = objChartOfAccount.GETGroupActOfSelectedGroup(txtAllGrouppAuto.Text, ClickBitL)
                    groupAct = dtgroupact.Rows(0)("GroupAct")
                    DtAccountInformarion = objChartOfAccount.GETToInformationOfSelectedGroup(groupAct, ClickBitL)
                    cmbAccountLevel.SelectedValue = 2
                    PnlOptionalOnSelection.Visible = True
                    PnlSupplier.Visible = True
                Else
                    dtgroupact = objChartOfAccount.GETGroupActOfSelectedGroup(txtAllGrouppAuto.Text, ClickBitL)
                    groupAct = dtgroupact.Rows(0)("GroupAct")
                    DtAccountInformarion = objChartOfAccount.GETToInformationOfSelectedGroup(groupAct, ClickBitL)
                    cmbAccountLevel.SelectedValue = 1
                    PnlOptionalOnSelection.Visible = False
                    PnlSupplier.Visible = False
                End If

                '---check already detail exist then code generate either New code generate
                If DtAccountInformarion.Rows.Count > 0 Then
                    Dim AccountNature As String
                    AccountNature = DtAccountInformarion.Rows(0)("AccountNature")
                    If AccountNature = "1" Then
                        txtAccountNature.Text = "ASSETS"
                    ElseIf AccountNature = "2" Then
                        txtAccountNature.Text = "LIABILITIES"
                    ElseIf AccountNature = "3" Then
                        txtAccountNature.Text = "CAPITAL"
                    ElseIf AccountNature = "4" Then
                        txtAccountNature.Text = "REVENUE"
                    Else
                        txtAccountNature.Text = "EXPENSES"
                    End If
                    Dim PAccountCode As String = 0
                    PAccountCode = DtAccountInformarion.Rows(0)("AccountCode")
                    txtAccountCode.Text = "0" & Val(PAccountCode + 1)
                    txtGroupAct.Text = DtAccountInformarion.Rows(0)("GroupAct")
                    txtAccountType.Text = DtAccountInformarion.Rows(0)("AccountType")
                    txtAccountLevelDigits.Text = DtAccountInformarion.Rows(0)("ActLevelDigit")

                    'ClearControlTwo()
                    PanelSaveButton.Visible = True
                    ' PnlOptionalOnSelection.Visible = True
                    ' PnlSupplier.Visible = True
                    Dim GAct As String = txtGroupAct.Text.Substring(0, 2)
                    If ClickBit = "Ledger" Then
                        If GAct = "04" Or GAct = "05" Then
                            PanelExtraForRevenewandExpence.Visible = True
                        Else
                            PanelExtraForRevenewandExpence.Visible = False
                        End If
                    Else
                        PanelExtraForRevenewandExpence.Visible = False
                    End If

                    ' cmbAccountLevel.SelectedValue = 2
                    txtAddress.Text = "N/A"
                    txtPhone.Text = "N/A"
                    txtFax.Text = "N/A"
                    txtEmailAddress.Text = "abc@ymail.com"
                    txtContactPerson.Text = "N/A"
                    txtCellNo.Text = "N/A"
                    'txtntnno.Text = "0000000-0"
                    'txtGstNo.Text = "00-00-0000-000-00"
                Else
                    Dim AccountNature As String
                    AccountNature = dtgroupact.Rows(0)("AccountNature")
                    If AccountNature = "1" Then
                        txtAccountNature.Text = "ASSETS"
                    ElseIf AccountNature = "2" Then
                        txtAccountNature.Text = "LIABILITIES"
                    ElseIf AccountNature = "3" Then
                        txtAccountNature.Text = "CAPITAL"
                    ElseIf AccountNature = "4" Then
                        txtAccountNature.Text = "REVENUE"
                    Else
                        txtAccountNature.Text = "EXPENSES"
                    End If
                    Dim PAccountCode As String = 0
                    PAccountCode = dtgroupact.Rows(0)("AccountCode")
                    Dim dtChckAccount As New DataTable
                    dtChckAccount = objChartOfAccount.GETCheckAccountcode(PAccountCode)
                    If dtChckAccount.Rows.Count > 0 Then
                        Dim Accountch As String = dtChckAccount.Rows(0)("AccountCode")
                        txtAccountCode.Text = "0" & Val(Accountch) + 1
                    Else
                        txtAccountCode.Text = "0" & Val(PAccountCode) & "001"
                    End If

                    txtGroupAct.Text = groupAct
                    txtAccountType.Text = dtgroupact.Rows(0)("AccountType")
                    Dim actLevelDigit As Decimal = 0
                    actLevelDigit = dtgroupact.Rows(0)("ActLevelDigit")
                    txtAccountLevelDigits.Text = actLevelDigit + 1

                    'ClearControlTwo()
                    PanelSaveButton.Visible = True
                    'PnlOptionalOnSelection.Visible = True
                    'PnlSupplier.Visible = True
                    Dim GAct As String = txtGroupAct.Text.Substring(0, 2)
                    If ClickBit = "Ledger" Then
                        If GAct = "04" Or GAct = "05" Then
                            PanelExtraForRevenewandExpence.Visible = True
                        Else
                            PanelExtraForRevenewandExpence.Visible = False
                        End If
                    Else
                        PanelExtraForRevenewandExpence.Visible = False
                    End If
                    ' cmbAccountLevel.SelectedValue = 2
                    txtAddress.Text = "N/A"
                    txtPhone.Text = "N/A"
                    txtFax.Text = "N/A"
                    txtEmailAddress.Text = "abc@ymail.com"
                    txtContactPerson.Text = "N/A"
                    txtCellNo.Text = "N/A"
                    'txtntnno.Text = "0000000-0"
                    'txtGstNo.Text = "00-00-0000-000-00"
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadDataOnCreateLedger(ByVal AccountName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objChartOfAccount.GETAUTOAllLedger(AccountName)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Sub BindAccountLevelcombo()
        Dim dt As New DataTable
        dt = objChartOfAccount.GetAccountLevel()
        With cmbAccountLevel
            .DataSource = dt
            .DataTextField = "AccountLevel"
            .DataValueField = "AccountLevelID"
            .DataBind()
            .Items.Insert(0, New ListItem("Select Account Level", "0"))
        End With
    End Sub
    Sub ClearControlTwo()
        txtAccountName.Text = ""
        txtAccountCode.Text = ""
        txtAccountLevelDigits.Text = ""
        txtAccountNature.Text = ""
        txtGroupAct.Text = ""
        rbtMaintainbalancebillbybill.SelectedItem.Text = "No"
        rbtInventoryvaluesareaffected.SelectedItem.Text = "No"
        rblCostCentresareapplicable.SelectedItem.Text = "No"
        rblAlowCostallocationStockItem.SelectedItem.Text = "No"
        rblActivateInterestCalculation.SelectedItem.Text = "No"
        txtntnno.Text = ""
        txtGstNo.Text = ""
        txtOpeningCR.Text = ""
        txtOpeningDB.Text = ""
        txtCurrencyofledger.Text = ""
        txtAccountType.Text = ""
        txtAllGrouppAuto.Text = ""
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim CheckPass As String
            ClickBit = Session("ClickBit")
            If ClickBit = "Ledger" Then
                CheckPass = "Detail"
            Else
                CheckPass = "Control"
            End If
            '----First Check NTNNo and GSTNo duplication 
            Dim dtChkNTN, dtChkGST, dtAccountName As New DataTable
            dtChkNTN = objChartOfAccount.CheckNTNNO(txtntnno.Text)
            dtChkGST = objChartOfAccount.CheckGSTNO(txtGstNo.Text)
            dtAccountName = objChartOfAccount.CheckAccountNameWithConNDetail(txtAccountName.Text, CheckPass)
            If ClickBit = "Ledger" Then

                If dtChkNTN.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("NTNNo Already Exist")
                ElseIf dtChkGST.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("GSTNo Already Exist")
                ElseIf dtAccountName.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    If cmbAccountLevel.SelectedIndex = 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Account Level")
                    ElseIf txtAccountName.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Empty")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        SaveValues()
                        '  lblTreeStatus.Text = "ManageView"
                        '---bind GroupLevelCurrentSave

                        ''------check Supplier or customer Save in Database
                        Dim dtchkCustomer, DtChkSupplierCurrentLibilities, DtChkSupplierTradeCreditor As New DataTable
                        dtchkCustomer = objChartOfAccount.CheckCustomer(objChartOfAccount.GetID())
                        DtChkSupplierCurrentLibilities = objChartOfAccount.CheckSupplierCurrentLibilities(objChartOfAccount.GetID())
                        DtChkSupplierTradeCreditor = objChartOfAccount.CheckSupplierTradeCreaditor(objChartOfAccount.GetID())

                        If dtchkCustomer.Rows.Count > 0 Then
                            'SaveCustomerDatabase()
                        Else
                        End If
                        If DtChkSupplierCurrentLibilities.Rows.Count > 0 Then
                            SaveSupplier()
                        Else
                        End If
                        If DtChkSupplierTradeCreditor.Rows.Count > 0 Then
                            SaveSupplier()
                        Else
                        End If
                        ClearControlSupplier()
                        ClearControl()

                        If ChkForSupplier.Checked = True Then
                            SaveSupplier()
                            ClearControlSupplier()
                        Else
                        End If
                        '----------After Save VisibilityFalse
                        PnlSupplier.Visible = False
                    End If
                End If
            Else
                If dtAccountName.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    If txtAccountName.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Empty")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        SaveValues()
                    
                        Dim dtchkCustomer, DtChkSupplierCurrentLibilities, DtChkSupplierTradeCreditor As New DataTable
                        dtchkCustomer = objChartOfAccount.CheckCustomer(objChartOfAccount.GetID())
                        DtChkSupplierCurrentLibilities = objChartOfAccount.CheckSupplierCurrentLibilities(objChartOfAccount.GetID())
                        DtChkSupplierTradeCreditor = objChartOfAccount.CheckSupplierTradeCreaditor(objChartOfAccount.GetID())

                        If dtchkCustomer.Rows.Count > 0 Then
                            'SaveCustomerDatabase()
                        Else
                        End If
                        If DtChkSupplierCurrentLibilities.Rows.Count > 0 Then
                            SaveSupplier()
                        Else
                        End If
                        If DtChkSupplierTradeCreditor.Rows.Count > 0 Then
                            SaveSupplier()
                        Else
                        End If
                        ClearControlSupplier()
                        ClearControl()

                        If ChkForSupplier.Checked = True Then
                            SaveSupplier()
                            ClearControlSupplier()
                        Else
                        End If
                        '----------After Save VisibilityFalse
                        PnlSupplier.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub SaveValues()
        With objChartOfAccount

            .ChartOfAccountID = 0
            .AccountCode = txtAccountCode.Text
            .GroupAct = txtGroupAct.Text
            .AccountName = txtAccountName.Text.ToUpper()
            .AccountType = txtAccountType.Text
            .AccountLevel = cmbAccountLevel.SelectedItem.Text  'cmbAccountLevel.SelectedValue
            If txtAccountNature.Text = "ASSETS" Then
                .AccountNature = 1
            ElseIf txtAccountNature.Text = "LIABILITIES" Then
                .AccountNature = 2
            ElseIf txtAccountNature.Text = "CAPITAL" Then
                .AccountNature = 3
            ElseIf txtAccountNature.Text = "REVENUE" Then
                .AccountNature = 4
            ElseIf txtAccountNature.Text = "EXPENSES" Then
                .AccountNature = 5

            End If

            .ActLevelDigit = txtAccountLevelDigits.Text
            .RelatedAccount = "N/A"
            .RelatedTaxAccount = "N/A"
            .PartyBookAccount = "N/A"
            If txtAddress.Text = "" Then
                .Address1 = "N/A"
            Else
                .Address1 = txtAddress.Text
            End If

            .Address2 = "N/A"

            If txtPhone.Text = "" Then
                .Phone = "N/A"
            Else
                .Phone = txtPhone.Text
            End If

            If txtFax.Text = "" Then
                .Fax = "N/A"
            Else
                .Fax = txtFax.Text
            End If

            If txtEmailAddress.Text = "" Then
                .Email = "N/A"
            Else
                .Email = txtEmailAddress.Text
            End If
            If txtContactPerson.Text = "" Then
                .ContactPerson = "N/A"
            Else
                .ContactPerson = txtContactPerson.Text
            End If
            If txtCellNo.Text = "" Then
                .MobileNo = "N/A"
            Else
                .MobileNo = txtCellNo.Text
            End If

            If txtGstNo.Text = "__-__-____-___-__" Then
                .GstNo = ""
            Else
                .GstNo = txtGstNo.Text
            End If
            If txtntnno.Text = "_______-_" Then
                .NtnNo = ""
            Else
                .NtnNo = txtntnno.Text
            End If



            .CreditDays = 0
            .CreditLimit = 0
            .January = 0
            .Febuary = 0
            .March = 0
            .April = 0
            .May = 0
            .June = 0
            .July = 0
            .August = 0
            .September = 0
            .October = 0
            .November = 0
            .December = 0
            .Remarks = 0
            .Cancel = 0
            .ClosingBalance = 0
            .TaxType = 0
            .LcValue = 0

            .CloseLC = 0
            .LCType = "N/A"
            .MaturityDate = "01/01/2014"
            .SectorCode = "N/A"
            If txtOpeningCR.Text = "" Then
                .Opening_Credit = 0
            Else
                .Opening_Credit = txtOpeningCR.Text
            End If
            If txtOpeningDB.Text = "" Then
                .Opening_Debit = 0
            Else
                .Opening_Debit = txtOpeningDB.Text
            End If
            .Old_Code = 0
            .Swift_Code = "N/A"
            .Account_Title = "N/A"
            .Account_No = "N/A"
            .Branch_Name = "N/A"
            .Bank_Name = "N/A"

            '--------New
            If txtCurrencyofledger.Text = "" Then
                .Currency = 0
            Else
                .Currency = txtCurrencyofledger.Text
            End If

            .Maintainbalancebillbybill = rbtMaintainbalancebillbybill.SelectedItem.Text
            .Inventoryvaluesareaffected = rbtInventoryvaluesareaffected.SelectedItem.Text
            .CostCentresareapplicable = rblCostCentresareapplicable.SelectedItem.Text
            .AlowCostallocationStockItem = rblAlowCostallocationStockItem.SelectedItem.Text
            .ActivateInterestCalculation = rblActivateInterestCalculation.SelectedItem.Text
            .IsCostAffected = RdbIsCostAffected.SelectedItem.Text

            .SaveChartOfAccount()
            PnlFalseInfo.Visible = False
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False

        End With
    End Sub
    Sub SaveSupplier()
        With objDtaBaseSupplier

            .SupplierDatabaseId = 0
            .SupplierName = txtAccountName.Text
            .SupplieAddress = txtAddress.Text
            .IsActive = 1
            If txtPhone.Text = "" Then
                .TelephoneNo = ""
            Else
                .TelephoneNo = txtPhone.Text
            End If
            If txtEmailAddress.Text = "" Then
                .Email = ""
            Else
                .Email = txtEmailAddress.Text
            End If

            .SupplierCategoryId = 1
            .SupplierCode = txtAccountCode.Text
            If txtFax.Text = "" Then
                .FaxNo = ""
            Else
                .FaxNo = txtFax.Text
            End If
            .SaveSupplierDatabase()
        End With

        With objSupplierDetail
            .SupplierDatabaseDetailId = 0
            .SupplierDatabaseId = objDtaBaseSupplier.GetID
            .ContactPerson = txtContactPerson.Text
            .CellNumber = txtCellNo.Text
            .SaveSupplierDatabaseDetail()
        End With
    End Sub
    'Sub SaveCustomerDatabase()
    '    Try
    '        With ObjCustomerDatabase
    '            .CustomerDatabaseID = 0
    '            .ProspectType = "Real"
    '            .PreparedBy = CLng(Session("userid"))
    '            .PreparedDate = Date.Now
    '            .CustomerName = txtAccountName.Text.ToUpper()
    '            .BuyingAgencyID = 1
    '            .Country = "Pakistan"
    '            .GeographyTerritory = "1 - EUROPE"
    '            .AddressLine1 = txtAddress.Text.ToUpper()
    '            .AddressPhone = txtPhone.Text.ToUpper()
    '            .AddressFax = txtFax.Text.ToUpper()
    '            .AddressLine2 = txtAddress.Text.ToUpper()
    '            .AddressLine3 = txtAddress.Text.ToUpper()
    '            .AddressWeb = "N/A"
    '            .AddressZip = "N/A"
    '            .IndustryTypeWholesale = False
    '            .IndustryTypeWholesaleRetail = False
    '            .IndustryTypeRetail = False
    '            .IndustryTypeImporter = False
    '            .RetailTypeDesigner = False
    '            .RetailTypeDepartmentStore = False
    '            .RetailTypeSpecialtyChain = False
    '            .RetailTypeSuperHyperMarket = False
    '            .RetailTypeDiscountStore = False
    '            .RetailTypePrintCatalogue = False
    '            .RetailTypeOnlineStore = False
    '            .RetailTypeTelevisionSales = False
    '            .RetailTypeWarehouse = False
    '            .BrandingPrivateLabel = False
    '            .BrandingPrivateOtherBrand = False
    '            .BrandingWholesaleBrand = False
    '            .AccountCode = txtAccountCode.Text
    '            .SaveCustomerDatabase()
    '        End With


    '        With ObjCustomerDatabaseDetail
    '            .CustomerDatabaseID = ObjCustomerDatabase.GetCustomerDatabaseID
    '            .CustomerDatabaseDetailID = 0
    '            .ContactType = "Business Contacts"
    '            .Positionn = "N/A"
    '            .Email = txtEmailAddress.Text
    '            .Name = txtContactPerson.Text
    '            .TelephoneOrFax = txtCellNo.Text
    '            .SaveCustomerDatabaseDetail()
    '        End With

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub ClearControlSupplier()
        txtAddress.Text = ""
        txtFax.Text = ""
        txtPhone.Text = ""
        txtEmailAddress.Text = ""
        txtContactPerson.Text = ""
        txtCellNo.Text = ""
    End Sub
    Sub ClearControl()
        txtAccountName.Text = ""
        txtAccountCode.Text = ""
        txtAccountLevelDigits.Text = ""
        txtAccountNature.Text = ""
        txtGroupAct.Text = ""
        rbtMaintainbalancebillbybill.SelectedItem.Text = "No"
        rbtInventoryvaluesareaffected.SelectedItem.Text = "No"
        rblCostCentresareapplicable.SelectedItem.Text = "No"
        rblAlowCostallocationStockItem.SelectedItem.Text = "No"
        rblActivateInterestCalculation.SelectedItem.Text = "No"
        txtntnno.Text = ""
        txtGstNo.Text = ""
        txtOpeningCR.Text = ""
        txtOpeningDB.Text = ""
        cmbAccountLevel.SelectedIndex = 0
        txtCurrencyofledger.Text = ""
    End Sub

    Protected Sub btnGrouopCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrouopCreate.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            ClearControlTwo()
            PanelLedgerCreate.Visible = True
            PnlSearch.Visible = False
            PanelViewCreateLedger.Visible = False
            PanelViewCreateGroup.Visible = False

            PnlGropLedgerView.Visible = False

            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSupplier.Visible = False
            lblHeading.Text = "Create Group"
            PanelViewCreateLedger.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LnkbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkbView.Click
        Try
            Response.Redirect("AccountInfoView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LnkbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkbPrint.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            Dim FileName As String

            Report.Load(Server.MapPath("..\Reports/AccountInfo.rpt"))
            FileName = "Accounts"
            'Report.Load(Server.MapPath("..\Reports/Voucher.rpt"))
            'FileName = "Bank Voucher"
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
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
                Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                Response.End()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnalterGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnalterGroup.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            txtShowMe.Text = ""
            ClickBitG = "Group"
            Session("ClickBit") = ClickBitG
            objDataView = LoadData(ClickBitG)
            Session("ClickBitL") = Nothing

            objDataView = LoadData(ClickBitG)
            Session("objDataView") = objDataView
            BindGrid()
            PnlGropLedgerView.Visible = True
            dgView.Columns(5).Visible = True
            dgView.Columns(8).Visible = True
            dgView.Columns(9).Visible = True
            ' txtShowMe.Text = ""
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSearch.Visible = False
            PnlSupplier.Visible = False
            lblHeadingMain2.Text = "Group View"
            PanelViewCreateLedger.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnalterLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnalterLedger.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            txtShowMe.Text = ""
            ClickBitL = "Ledger"
            Session("ClickBit") = ClickBitL
            objDataView = LoadData(ClickBitL)
            Session("ClickBitG") = Nothing
            Session("objDataView") = objDataView
            BindGrid()
            PnlGropLedgerView.Visible = True
            dgView.Columns(5).Visible = True
            dgView.Columns(8).Visible = True
            dgView.Columns(9).Visible = True
            ' txtShowMe.Text = ""
            PnlOptionalOnSelection.Visible = False
            PanelExtraForRevenewandExpence.Visible = False
            PnlSearch.Visible = False
            PnlSupplier.Visible = False
            PanelSaveButton.Visible = False
            lblHeadingMain2.Text = "Ledger View"
            PanelViewCreateGroup.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub lnkTreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTreeView.Click
        Try
            Response.Redirect("AccountsTree.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
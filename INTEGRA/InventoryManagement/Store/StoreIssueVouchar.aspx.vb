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
Public Class StoreIssueVouchar
    Inherits System.Web.UI.Page
    Dim dtItemIssue As New DataTable
    Dim Dr As DataRow
    Dim ObjUser As New EuroCentra.User
    Dim StoreIssueID As Long
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjIMSItem As New IMSItem
    Dim Userid As Long
    Dim InhandQty As Decimal
    Dim TansactionMethod As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StoreIssueID = Request.QueryString("StoreIssueID")
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            BindIssuedeptcode()
            Session("dtSelection") = Nothing
            Session("dtItemIssue") = Nothing
            txtTodayis.Text = Date.Now.ToString("dd/MM/yyyy")
            Dim dtInfo As DataTable = ObjUser.GetUSerInfoNew(CLng(Session("Userid")))
          
            If Userid = 240 Then

                BinItemFabricClassName()
                cmbIssueType.Enabled = True
            Else
                BinItemCodeWithoutFabric()
                lblCounter.Text = "Ref #"
            End If
            If StoreIssueID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
               
            End If
        End If
    End Sub

    Sub BinItemFabricClassName()
        Dim dt As DataTable
        dt = ObjIMSStoreIssue.GetItemFabricClassName()
        cmbIssueType.DataSource = dt
        cmbIssueType.DataTextField = "ItemClassName"
        cmbIssueType.DataValueField = "IMSItemClassID"
        cmbIssueType.DataBind()
        cmbIssueType.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BinItemCodeWithoutFabric()
        Dim dt As DataTable
        dt = ObjIMSStoreIssue.GetItemClassWithoutFabricNew()
        cmbIssueType.DataSource = dt
        cmbIssueType.DataTextField = "ItemClassName"
        cmbIssueType.DataValueField = "IMSItemClassID"
        cmbIssueType.DataBind()
        cmbIssueType.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindItemName()
        Dim dt As DataTable
        dt = ObjIMSStoreIssue.BindItemName(cmbIssueType.SelectedValue)
        cmbItemName.DataSource = dt
        cmbItemName.DataTextField = "ItemName"
        cmbItemName.DataValueField = "IMSItemID"
        cmbItemName.DataBind()
        cmbItemName.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtTodayis.Text
            Dim month As String = Voucherdate.Month
            Dim year As String = Voucherdate.Year
            Dim yearv As String = year.Substring(2, 2)


            Dim LastVoucherNo As String = ObjIMSStoreIssue.GetIssueCode(year)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(7, 2)
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


            If Userid = 17 Then

                VoucherNo = "STL" & "-" & "SI" & "-" & LastCode & "-" & yearv
                txtStoreIssueVoucherNo.Text = VoucherNo
            Else
                VoucherNo = "STL" & "-" & "FI" & "-" & LastCode & "-" & yearv
                txtStoreIssueVoucherNo.Text = VoucherNo
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindIssuedeptcode()
        Dim dt As DataTable
        Dim ObjDepartmentDataBase As New DepartmetDataBase
        dt = ObjDepartmentDataBase.GetDepartmentDataBase
        cmbIssueDeptCode.DataSource = dt
        cmbIssueDeptCode.DataTextField = "DeptAbbrivation"
        cmbIssueDeptCode.DataValueField = "DeptDatabaseId"
        cmbIssueDeptCode.DataBind()
        cmbIssueDeptCode.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub lnkItemPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkItemPopup.Click
        Try
            Session("dtSelection") = Nothing
            Response.Write("<script> window.open('ItemPopupForIssue.aspx', 'newwindow', 'left=100, top=180, height=500, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            Dim dtTemp As DataTable
            dtTemp = Session("dtSelection")
            If dtTemp.Rows.Count > 0 Then
                txtITEMCODE.Text = dtTemp.Rows(0)("ItemCodee")
                cmbItemName.SelectedItem.Text = dtTemp.Rows(0)("ItemName")
                txtID.Text = dtTemp.Rows(0)("StoreIssueDetailID")
                IMSItemID.Text = dtTemp.Rows(0)("IMSItemID")
                txtRATE.Text = dtTemp.Rows(0)("AVGRATE")
                txtQtyInHand.Text = dtTemp.Rows(0)("QtyInHand")
                txtTransactionMethodID.Text = dtTemp.Rows(0)("TransactionMethodID")
            Else
                txtITEMCODE.Text = ""
                cmbItemName.SelectedValue = 0
                txtID.Text = ""
                IMSItemID.Text = ""
                txtRATE.Text = ""
                txtQtyInHand.Text = ""
                txtTransactionMethodID.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtQtyIssue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyIssue.TextChanged
        Try
            txtAMOUNT.Text = Math.Round(Val(txtQtyIssue.Text) * Val(txtRATE.Text), 2)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            If cmbItemName.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Item Name")
            ElseIf cmbIssueDeptCode.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Dpt. Code empty")
            ElseIf txtQtyIssue.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Qty. empty")

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                FillGridByStyle()
                BindGrid()
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
                .Columns.Add("StoreIssueDetailID", GetType(Long))
                .Columns.Add("IMSItemID", GetType(String))
                .Columns.Add("DeptDatabaseId", GetType(Long))
                .Columns.Add("DeptAbbrivation", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("QtyInHand", GetType(Decimal))
                .Columns.Add("QtyIssue", GetType(Decimal))
                .Columns.Add("AVGRATE", GetType(Decimal))
                .Columns.Add("Amount", GetType(Decimal))
                .Columns.Add("TransactionMethodID", GetType(Long))
            End With
        End If

        Dr = dtItemIssue.NewRow()
        Dr("StoreIssueDetailID") = 0
        Dr("IMSItemID") = IMSItemID.Text
        Dr("DeptDatabaseId") = cmbIssueDeptCode.SelectedValue
        Dr("DeptAbbrivation") = cmbIssueDeptCode.SelectedItem.Text
        Dr("ItemCodee") = txtITEMCODE.Text
        Dr("ItemName") = cmbItemName.SelectedItem.Text
        Dr("QtyInHand") = Val(txtQtyInHand.Text)
        Dr("QtyIssue") = Val(txtQtyIssue.Text)
        Dr("AVGRATE") = Val(txtRATE.Text)
        Dr("Amount") = Val(txtAMOUNT.Text)
        Dr("TransactionMethodID") = txtTransactionMethodID.Text
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
    Sub ClearText()
        Try
            txtITEMCODE.Text = ""
            cmbItemName.SelectedValue = 0
            txtQtyIssue.Text = ""
            txtRATE.Text = ""
            txtTransactionMethodID.Text = ""
            txtAMOUNT.Text = ""
            IMSItemID.Text = ""
            txtQtyInHand.Text = ""
            cmbIssueDeptCode.SelectedValue = 0

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date empty.")
            ElseIf dgItemView.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Item required in detail section.")


            ElseIf txtCounterNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Counter No empty.")

            ElseIf txtCCNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("CC No empty.")


            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjIMSStoreIssue
                    .StoreIssueID = StoreIssueID
                    .CreationDate = Date.Now
                    .CreatedbyID = CLng(Session("Userid"))
                    .EntryDate = txtDate.Text
                    .SIVNo = txtStoreIssueVoucherNo.Text
                    ' .RequisitionNo = txtStoreRequisitionNo.Text
                    .IssueTypeID = cmbIssueType.SelectedValue 'txtIssueType.Text
                    .CCNo = txtCCNo.Text
                    If StoreIssueID > 0 Then
                        .TokenNo = StoreIssueID
                    Else
                        .TokenNo = ObjIMSStoreIssue.GetID() + 1
                    End If
                    .CounterNo = txtCounterNo.Text
                    .SaveIMSStoreIssue()
                End With

                Dim x As Integer
                For x = 0 To dgItemView.Items.Count - 1
                    With ObjIMSStoreIssueDetail
                        .StoreIssueDetailID = dgItemView.Items(x).Cells(0).Text
                        If StoreIssueID > 0 Then
                            .StoreIssueID = StoreIssueID
                        Else
                            .StoreIssueID = ObjIMSStoreIssue.GetID()
                        End If
                        .IMSItemID = dgItemView.Items(x).Cells(1).Text
                        .DeptDatabaseId = dgItemView.Items(x).Cells(9).Text
                        .QtyIssue = dgItemView.Items(x).Cells(7).Text
                        .QtyInHand = dgItemView.Items(x).Cells(4).Text
                        .AVGRATE = dgItemView.Items(x).Cells(6).Text
                        .Amount = dgItemView.Items(x).Cells(8).Text
                        .TransactionMethodID = dgItemView.Items(x).Cells(10).Text
                        .SaveIMSStoreIssueDetail()
                    End With

                    'Update on Ledger
                    If dgItemView.Items(x).Cells(0).Text = 0 Then
                        With ObjIMSStoreLedger
                            .StoreLedgerID = 0
                            .IMSItemID = dgItemView.Items(x).Cells(1).Text
                            .CreationDate = Date.Now()
                            .TransactionDate = Date.Now.Date()
                            .TransactionType = "SIV"
                            .OpenQty = 0
                            .OpenAmount = 0
                            .ReceiveQty = 0
                            .ReceiveAmount = 0
                            .IssueQty = dgItemView.Items(x).Cells(7).Text
                            .IssueAmount = dgItemView.Items(x).Cells(8).Text
                            .CloseQty = ObjIMSStoreLedger.GetCloseQty(dgItemView.Items(x).Cells(1).Text) - Convert.ToDecimal(dgItemView.Items(x).Cells(7).Text)
                            .CloseAmount = ObjIMSStoreLedger.GetCloseAmount(dgItemView.Items(x).Cells(1).Text) - Convert.ToDecimal(dgItemView.Items(x).Cells(8).Text)
                            .SaveIMSStoreLedger()
                        End With
                    End If
                Next
                Session("dtSelection") = Nothing
                Session("dtItemIssue") = Nothing
                Response.Redirect("StoreIssueVoucharView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = ObjIMSStoreIssue.GetEditData(StoreIssueID)
            txtStoreIssueVoucherNo.Text = dt.Rows(0)("SIVNo")
            txtDate.Text = dt.Rows(0)("EntryDate")
            'cmbItemName.SelectedItem.Text = dt.Rows(0)("RequisitionNo")
            ' BinItemCodeWithoutFabric()
            cmbIssueType.SelectedValue = dt.Rows(0)("IssueTypeID")
            txtCCNo.Text = dt.Rows(0)("CCNo")
            txtCounterNo.Text = dt.Rows(0)("CounterNo")
            dtItemIssue = New DataTable
            With dtItemIssue
                .Columns.Add("StoreIssueDetailID", GetType(Long))
                .Columns.Add("IMSItemID", GetType(String))
                .Columns.Add("DeptDatabaseId", GetType(Long))
                .Columns.Add("DeptAbbrivation", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("QtyInHand", GetType(Decimal))
                .Columns.Add("QtyIssue", GetType(Decimal))
                .Columns.Add("AVGRATE", GetType(Decimal))
                .Columns.Add("Amount", GetType(Decimal))
                .Columns.Add("TransactionMethodID", GetType(Long))
            End With
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtItemIssue.NewRow()
                Dr("StoreIssueDetailID") = dt.Rows(x)("StoreIssueDetailID")
                Dr("IMSItemID") = dt.Rows(x)("IMSItemID")
                Dr("DeptDatabaseId") = dt.Rows(x)("DeptDatabaseId")
                Dr("DeptAbbrivation") = dt.Rows(x)("DeptAbbrivation")
                Dr("ItemCodee") = dt.Rows(x)("ItemCodee")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("QtyInHand") = dt.Rows(x)("QtyInHand")
                Dr("QtyIssue") = dt.Rows(x)("QtyIssue")
                Dr("AVGRATE") = dt.Rows(x)("AVGRATE")
                Dr("Amount") = dt.Rows(x)("Amount")
                Dr("TransactionMethodID") = dt.Rows(x)("TransactionMethodID")
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
            Response.Redirect("StoreIssueVoucharView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtITEMCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITEMCODE.TextChanged
        Try
            Dim ObjIMSItem As New IMSItem
            Dim dtItemInfo As DataTable
            dtItemInfo = ObjIMSItem.GetIMSItemAllForIssueCode(txtITEMCODE.Text)
            If dtItemInfo.Rows.Count > 0 Then
                txtITEMCODE.Text = dtItemInfo.Rows(0)("ItemCodee")
                cmbItemName.SelectedItem.Text = dtItemInfo.Rows(0)("ItemName")
                txtID.Text = dtItemInfo.Rows(0)("StoreIssueDetailID")
                IMSItemID.Text = dtItemInfo.Rows(0)("IMSItemID")
                txtRATE.Text = dtItemInfo.Rows(0)("AVGRATE")
                txtQtyInHand.Text = dtItemInfo.Rows(0)("InHandQty")
                txtTransactionMethodID.Text = dtItemInfo.Rows(0)("TransactionMethodID")
            Else
                txtITEMCODE.Text = ""
                cmbItemName.SelectedValue = 0
                txtID.Text = ""
                IMSItemID.Text = ""
                txtRATE.Text = ""
                txtQtyInHand.Text = ""
                txtTransactionMethodID.Text = ""
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cmbIssueType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIssueType.SelectedIndexChanged
        BindItemName()
    End Sub

    Protected Sub cmbItemName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemName.SelectedIndexChanged
        GetItemData()
    End Sub
    Sub GetItemData()
        Dim dt As New DataTable
        ' dt = ObjIMSItem.GetIMSItem(cmbItemName.SelectedItem.Text)
        dt = ObjIMSItem.GetIMSItemNew(cmbItemName.SelectedValue)


        If IsNothing(dt) Then

            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, Inhand Qty is Zero(0).")
        Else

            InhandQty = dt.Rows(0)("InhandQty")
            TansactionMethod = dt.Rows(0)("TransactionMethod")
            If InhandQty = 0.0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, Inhand Qty is Zero(0).")

            ElseIf TansactionMethod = "--" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow, First define transaction method of item.")


            Else

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                txtITEMCODE.Text = dt.Rows(0)("ItemCodee")
                txtQtyInHand.Text = dt.Rows(0)("InhandQty")
                txtRATE.Text = dt.Rows(0)("AvgRate")
                txtTransactionMethodID.Text = dt.Rows(0)("TransactionMethodID")
                IMSItemID.Text = dt.Rows(0)("IMSItemID")
                txtQtyIssue.Focus()

            End If
        End If
    End Sub
End Class

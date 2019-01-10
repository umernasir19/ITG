Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POProcessIssueReturn
    Inherits System.Web.UI.Page

    Dim lProcessIssueID, lProcessIssueDtlID, luserid As Long
    Dim ObjFPOIssueReturn As New ProcessIssueReturn
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        luserid = Session("UserId")
        lProcessIssueID = Request.QueryString("ProcessIssueID")
        lProcessIssueDtlID = Request.QueryString("ProcessIssueDtlID")
        If Not Page.IsPostBack Then
            GetIssuedata()
        End If
    End Sub
    Sub GetIssuedata()
        Dim dt As DataTable = ObjFPOIssueReturn.GetProcessIssueReturn(lProcessIssueID, lProcessIssueDtlID)
        If dt.Rows.Count > 0 Then
            LBLPONO.Text = dt.Rows(0)("PONoo")
            LBLItemName.Text = dt.Rows(0)("ItemName")
            'LBLStyle.Text = dt.Rows(0)("Style")
            txtPOIssueQTY.Text = dt.Rows(0)("IssueQtyy")
            lblPoRecvid.Text = dt.Rows(0)("POProcessRecvMasterID")
            lblPoRecvDtlid.Text = dt.Rows(0)("POProcessRecvDetailID")
            lblPoId.Text = dt.Rows(0)("ProcessOrderMstid")
            lblImsItemId.Text = dt.Rows(0)("IMSItemID")
            lblDpt.Text = dt.Rows(0)("DeptDatabaseNamee")
            txtlocation.Text = dt.Rows(0)("Location")
            lblLocationid.Text = dt.Rows(0)("Locationid")
            lblManualChallanNo.Text = dt.Rows(0)("ManualChallanNo")
            lblItemCodee.Text = dt.Rows(0)("ItemCodee")
        End If
        Dim DTrtn As DataTable = ObjFPOIssueReturn.GetProcessIssueReturnedQty(lProcessIssueID, lProcessIssueDtlID)
        If DTrtn.Rows.Count > 0 Then
            txtIssueReturnedQTY.Text = DTrtn.Rows(0)("ReturnedQty")
        Else
            txtIssueReturnedQTY.Text = 0
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtReturnQTY.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Return Qty")

            ElseIf txtReturnDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Return Date")
            ElseIf Val(txtReturnQTY.Text) + Val(txtIssueReturnedQTY.Text) > Val(txtPOIssueQTY.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveData()
                Response.Redirect("POProcessIssueView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("POProcessIssueView.aspx")

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With ObjFPOIssueReturn
            .POProcessIssueReturnId = 0
            .ProcessOrderMstID = lblPoId.Text
            .POProcessRecvMasterID = lblPoRecvid.Text
            .POProcessRecvDetailID = lblPoRecvDtlid.Text
            .UserId = luserid
            .CreationDate = Date.Now
            .ReturnDate = txtReturnDate.Text
            .ReturnQty = txtReturnQTY.Text
            .ItemID = lblImsItemId.Text
            .ProcessIssueID = lProcessIssueID
            .ProcessIssueDtlID = lProcessIssueDtlID
            .Locationid = lblLocationid.Text
            .SaveReturn()
        End With
        With ObjIMSStoreLedger
            .StoreLedgerID = 0
            .IMSItemID = lblImsItemId.Text
            .CreationDate = Date.Now()
            .TransactionDate = Date.Now.Date()
            .TransactionType = "Process-IssueReturn"
            .OpenQty = 0
            .OpenAmount = 0
            .ReceiveQty = txtReturnQTY.Text
            .ReceiveAmount = 0
            .IssueQty = 0 'txtReturnQTY.Text
            .IssueAmount = 0
            Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(lblImsItemId.Text, lblLocationid.Text)
            If dtQty.Rows.Count > 0 Then
                .CloseQty = Val(dtQty.Rows(0)("CloseQty")) + Val(txtReturnQTY.Text)
            Else
                .CloseQty = Val(txtReturnQTY.Text)
            End If
            '.CloseQty = ObjIMSStoreLedger.GetCloseQty(lblImsItemId.Text) + Val(txtReturnQTY.Text)
            .CloseAmount = 0
            .SaveIMSStoreLedger()
        End With

        ObjFPOIssueReturn.GetUpdateReturnQtyForProcessIssue(Val(txtReturnQTY.Text) + Val(txtIssueReturnedQTY.Text), lProcessIssueID, lProcessIssueDtlID)

    End Sub
    Protected Sub txtReturnQTY_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtReturnQTY.TextChanged
        If Val(txtReturnQTY.Text) + Val(txtIssueReturnedQTY.Text) > Val(txtPOIssueQTY.Text) Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub

End Class
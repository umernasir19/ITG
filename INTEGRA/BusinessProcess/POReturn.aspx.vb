Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POReturn
    Inherits System.Web.UI.Page
    Dim lPOID, lPODetailID, lPORecvMasterID, lPORecvDetailID, luserid, lItemID As Long
    Dim ObjFPOReturn As New FPOReturn
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("POID")
        lPODetailID = Request.QueryString("PODetailID")
        lPORecvMasterID = Request.QueryString("PORecvMasterID")
        lPORecvDetailID = Request.QueryString("PORecvDetailID")
        luserid = Session("UserId")
        lItemID = Request.QueryString("ItemID")
        If Not Page.IsPostBack Then
            Try
                LBLPONO.Text = Session("PONO")
                LBLStyle.Text = Session("Style")
                LBLSupplierName.Text = Session("SupplierName")
                LBLItemName.Text = Session("ItemName")
                TXTPOqty.Text = Session("POQTY")
                txtPORecvQTY.Text = Session("RecvQuantity")
                GetReturnedQty()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtReturnQTY.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Return Qty")

            ElseIf txtReturnDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Return Date")
            ElseIf Val(txtReturnQTY.Text) + Val(txtReturnedQTY.Text) > Val(txtPORecvQTY.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveData()
                Response.Redirect("POReceiveView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
          
                Response.Redirect("POReceiveView.aspx")

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With ObjFPOReturn
            .FPOReturnId = 0
            .POID =lPOID
            .PODetailID = lPODetailID
            .PORecvMasterID = lPORecvMasterID
            .PORecvDetailID = lPORecvDetailID
            .UserId = luserid
            .CreationDate = Date.Now
            .ReturnDate = txtReturnDate.Text
            .ReturnQty = txtReturnQTY.Text
            .ItemID = lItemID
            .LocationID = lbllocationid.Text
            .Save()
        End With
        With ObjIMSStoreLedger
            .StoreLedgerID = 0
            .IMSItemID = lItemID
            .CreationDate = Date.Now()
            .TransactionDate = Date.Now.Date()
            .TransactionType = "PO-Return"
            .OpenQty = 0
            .OpenAmount = 0
            .ReceiveQty = 0
            .ReceiveAmount = 0
            .IssueQty = txtReturnQTY.Text
            .IssueAmount = 0
            Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(lItemID, lbllocationid.Text)
            If dtQty.Rows.Count > 0 Then
                .CloseQty = Val(dtQty.Rows(0)("CloseQty")) - Val(txtReturnQTY.Text)
            Else
                .CloseQty = -Val(txtReturnQTY.Text)
            End If
            ' .CloseQty = ObjIMSStoreLedger.GetCloseQty(lItemID) - Val(txtReturnQTY.Text)
            .CloseAmount = 0
            .LocationID = lbllocationid.Text
            .SaveIMSStoreLedger()
        End With

        ObjFPOReturn.GetUpdateReturnQty(Val(txtReturnQTY.Text) + Val(txtReturnedQTY.Text), lPODetailID, lPORecvMasterID, lPORecvDetailID)

    End Sub
    Sub GetReturnedQty()
        Dim dt, dtlocation As DataTable
        dt = ObjFPOReturn.GetReturnedQty(lPOID, lPODetailID, lPORecvMasterID, lPORecvDetailID, lItemID)
        If dt.Rows.Count > 0 Then
            txtReturnedQTY.Text = dt.Rows(0)("ReturnedQty")
        Else
            txtReturnedQTY.Text = 0
        End If
        dtlocation = ObjFPOReturn.GetLocation(lPORecvMasterID)
        If dtlocation.Rows.Count > 0 Then
            txtlocation.Text = dtlocation.Rows(0)("Location")
            lbllocationid.Text = dtlocation.Rows(0)("LocationId")
        End If
        txtReturnQTY.Focus()
    End Sub
    Protected Sub txtReturnQTY_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtReturnQTY.TextChanged
        If Val(txtReturnQTY.Text) + Val(txtReturnedQTY.Text) > Val(txtPORecvQTY.Text) Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub

End Class
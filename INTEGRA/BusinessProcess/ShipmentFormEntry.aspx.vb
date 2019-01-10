Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class ShipmentFormEntry
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtPacking As New DataTable
    Dim dtPurchaseOrder As New DataTable
    Dim lPOID, lShipmentID As Long
    Dim Dr As DataRow
    Dim ICargoID, userid As Long
    Dim Type As String
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim ObjTblRND As New TblDPRND
    Dim objDPSampleReceive As New DPSampleReceive
    Dim objPackingMst As New PackingMst
    Dim objPackingDtl As New PackingDtl
    Dim objShipmentFormClass As New ShipmentFormClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lShipmentID = Request.QueryString("ShipmentID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindInvoiceNo()
            BinShipmentMode()
            BinDeliveryTerm()
            If lShipmentID > 0 Then
                Edit()
                btnSave.Visible = True
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                txtAmountToBeRealized.Text = 0
                txtExchangeRate.Text = 0
                txtAmountInPKR.Text = 0
                txtPurchaseAmount.Text = 0
                txtPurchaseRate.Text = 0
                txtPurchaseAmountPKR.Text = 0
                txtBalRealizedAmount.Text = 0
                txtRealizedRate.Text = 0
                txtBalRealizedAmountPKR.Text = 0
                txtFBCharges.Text = 0
                txtNetRealizedAmount.Text = 0
                txtNetRealizedAmountPKR.Text = 0
            End If
        End If
    End Sub
    Sub Edit()
        Dim dtEdit As DataTable = objSizeRange.GetEditData(lShipmentID)
        cmbInvoiceNo.SelectedValue = dtEdit.Rows(0)("CargoID")
        txtBuyer.Text = dtEdit.Rows(0)("Buyer")
        txtCurrency.Text = dtEdit.Rows(0)("Currency")
        txtInvoiceAmount.Text = dtEdit.Rows(0)("InvoiceAmount")
        rdpInvoiceDate.SelectedDate = dtEdit.Rows(0)("InvoiceDate")
        txtExFactoryDate.Text = dtEdit.Rows(0)("ExFactoryDate")
        txtQtyPcs.Text = Math.Round(dtEdit.Rows(0)("Qty"), 0)
        txtLCNo.Text = dtEdit.Rows(0)("LCNO")
        rdpLCDate.SelectedDate = dtEdit.Rows(0)("LCDate")
        cmbShipMode.SelectedValue = dtEdit.Rows(0)("ShipmentModeID")
        cmbShipTerm.SelectedValue = dtEdit.Rows(0)("ShipmentTermID")
        txtBankCode.Text = dtEdit.Rows(0)("BankCode")
        txtFormENo.Text = dtEdit.Rows(0)("FromENo")
        rdpFormEDate.SelectedDate = dtEdit.Rows(0)("FromEDate")
        txtBLorAWB.Text = dtEdit.Rows(0)("BLORAWB")
        rdpBLorAWBDate.SelectedDate = dtEdit.Rows(0)("BLORAWBDate")
        txtContainerNo.Text = dtEdit.Rows(0)("ContainerNo")
        txtContainerSize.Text = dtEdit.Rows(0)("ContainerSize")
        rdpETADestination.SelectedDate = dtEdit.Rows(0)("ETADestination")
        txtClearingAgent.Text = dtEdit.Rows(0)("ClearingAgent")
        txtGD.Text = dtEdit.Rows(0)("GDNo")
        rdpGDDate.SelectedDate = dtEdit.Rows(0)("GDDate")
        TXTPaymentTerms.Text = dtEdit.Rows(0)("PaymentTerms")
        txtPaymentDays.Text = dtEdit.Rows(0)("PaymentDays")
        rdpDocsSubmitIntoBankOn.SelectedDate = dtEdit.Rows(0)("DocsSubmitIntoBankOn")
        txtBankToBankDHLNo.Text = dtEdit.Rows(0)("BankToBankDHLNo")
        rdpBankToBankDHLDate.SelectedDate = dtEdit.Rows(0)("BankToBankDHLDate")
        txtBuyerDHLNo.Text = dtEdit.Rows(0)("BuyerDHLNo")
        rdpBuyerDHLDate.SelectedDate = dtEdit.Rows(0)("BuyerDHLDate")
        txtExpectedPayRecDate.Text = dtEdit.Rows(0)("ExpectedPayRcvDate")
        rdpDiscrepacyMsgDate.SelectedDate = dtEdit.Rows(0)("DiscrepacyMsgDate")
        rdpTelexSendingDate.SelectedDate = dtEdit.Rows(0)("TelexSendingDate")
        rdpPayMaburityDate.SelectedDate = dtEdit.Rows(0)("PayMaburityDate")
        txtAmountToBeRealized.Text = dtEdit.Rows(0)("AmountToBeRealized")
        txtExchangeRate.Text = dtEdit.Rows(0)("ExchangeRate")
        txtAmountInPKR.Text = dtEdit.Rows(0)("AmountInPKR")
        txtPurchaseAmount.Text = dtEdit.Rows(0)("PurchaseAmount")
        txtPurchaseRate.Text = dtEdit.Rows(0)("PurchaseRate")
        txtPurchaseAmountPKR.Text = dtEdit.Rows(0)("PurchaseAmountPKR")
        rdpPurchaseDate.SelectedDate = dtEdit.Rows(0)("PurchaseDate")
        txtBalRealizedAmount.Text = dtEdit.Rows(0)("BalRealizedAmount")
        txtRealizedRate.Text = dtEdit.Rows(0)("RealizedRate")
        txtBalRealizedAmountPKR.Text = dtEdit.Rows(0)("BalRealizedAmountPKR")
        rdpRealizedDate.SelectedDate = dtEdit.Rows(0)("RealizedDate")
        txtFBCharges.Text = dtEdit.Rows(0)("FBCharges")
        txtNetRealizedAmount.Text = dtEdit.Rows(0)("NetRealizedAmount")
        txtNetRealizedAmountPKR.Text = dtEdit.Rows(0)("NetRealizedAmountPKR")
        txtRemarks.Text = dtEdit.Rows(0)("Remarks")
        Dim AGGT As Boolean = dtEdit.Rows(0)("Status")
        If AGGT = True Then
            cbPaymentReceived.Checked = True
        ElseIf AGGT = False Then
            cbPaymentReceived.Checked = False
        End If
    End Sub
    Protected Sub txtPaymentDays_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPaymentDays.TextChanged
        Try
            GetDuesDate()
        Catch ex As Exception

        End Try
    End Sub
    Sub GetDuesDate()
        Dim GetAddDays As String = txtPaymentDays.Text
        Dim CurrentDate As Date = txtExFactoryDate.Text
        txtExpectedPayRecDate.Text = CurrentDate.AddDays(GetAddDays)
    End Sub
    Sub BindInvoiceNo()
        Dim dt As DataTable
        dt = objSizeRange.GetInvoiceNo()
        cmbInvoiceNo.DataSource = dt
        cmbInvoiceNo.DataTextField = "InvoiceNo"
        cmbInvoiceNo.DataValueField = "CargoID"
        cmbInvoiceNo.DataBind()
        cmbInvoiceNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BinShipmentMode()
        Dim dt As DataTable
        dt = objSizeRange.GetShipmentMode()
        cmbShipMode.DataSource = dt
        cmbShipMode.DataTextField = "ShipmentMode"
        cmbShipMode.DataValueField = "ShipmentModeID"
        cmbShipMode.DataBind()
    End Sub
    Sub BinDeliveryTerm()
        Dim dt As DataTable
        dt = objSizeRange.GetDeliveryTerm()
        cmbShipTerm.DataSource = dt
        cmbShipTerm.DataTextField = "DeliveryTerm"
        cmbShipTerm.DataValueField = "DeliveryTermID"
        cmbShipTerm.DataBind()
        cmbShipTerm.Items.Insert(0, "Select")
    End Sub
    Protected Sub cmbInvoiceNO_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Dim dt As DataTable
        dt = objSizeRange.GetInvoiceData(cmbInvoiceNo.SelectedValue)
        txtBuyer.Text = dt.Rows(0)("CustomerName")
        txtCurrency.Text = dt.Rows(0)("CurrencyName")
        txtInvoiceAmount.Text = dt.Rows(0)("InvoiceValue")
        rdpInvoiceDate.SelectedDate = dt.Rows(0)("InvoiceDate")
        txtExFactoryDate.Text = dt.Rows(0)("ShipmentDate")
        txtQtyPcs.Text = Math.Round(dt.Rows(0)("Qty"), 0)
        txtLCNo.Text = dt.Rows(0)("LCNO")
        rdpLCDate.SelectedDate = dt.Rows(0)("DateOfIssue")
        cmbShipMode.SelectedValue = dt.Rows(0)("ShipModeID")
        cmbShipTerm.SelectedValue = dt.Rows(0)("DeliveryTermID")
        txtBankCode.Text = dt.Rows(0)("AccountCode")
        txtFormENo.Text = dt.Rows(0)("FrOmENo")
        rdpFormEDate.SelectedDate = dt.Rows(0)("FrOmEDate")
        txtBLorAWB.Text = dt.Rows(0)("Mode")
        txtContainerNo.Text = dt.Rows(0)("ContainerNo")
        txtContainerSize.Text = dt.Rows(0)("ContainerSize")
        rdpETADestination.SelectedDate = dt.Rows(0)("ETA")
        txtClearingAgent.Text = dt.Rows(0)("ClearNingAgent")
        TXTPaymentTerms.Text = dt.Rows(0)("LCTerms")
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If rdpBLorAWBDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill B/L OR AWB Date")
            ElseIf rdpGDDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill G.D Date")
            ElseIf rdpDocsSubmitIntoBankOn.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Docs. Submit Into Bank On")
            ElseIf rdpBankToBankDHLDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Bank To Bank DHL Date")
            ElseIf rdpBuyerDHLDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Buyer DHL Date")
            ElseIf txtPaymentDays.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Payment Days")
            ElseIf txtExpectedPayRecDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Expected Pay. Rcv. Date")
            ElseIf rdpDiscrepacyMsgDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Discrepacy Msg Date")
            ElseIf rdpTelexSendingDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Telex Sending Date")
            ElseIf rdpPayMaburityDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Pay Maburity Date")
            ElseIf rdpPurchaseDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Purchase Date")
            ElseIf rdpRealizedDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Realized Date")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Save()
                Response.Redirect("ShipmentFormView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ShipmentFormView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        With objShipmentFormClass
            If lShipmentID > 0 Then
                .ShipmentID = lShipmentID
            Else
                .ShipmentID = 0
            End If
            .CreationDate = Date.Now
            .UserID = userid
            .CargoID = cmbInvoiceNo.SelectedValue
            .Buyer = txtBuyer.Text
            .Currency = txtCurrency.Text
            .InvoiceAmount = txtInvoiceAmount.Text
            .InvoiceDate = rdpInvoiceDate.SelectedDate
            .ExFactoryDate = txtExFactoryDate.Text
            .Qty = txtQtyPcs.Text
            .LCNO = txtLCNo.Text
            .LCDate = rdpLCDate.SelectedDate
            .ShipmentModeID = cmbShipMode.SelectedValue
            .ShipmentTermID = cmbShipTerm.SelectedValue
            .BankCode = txtBankCode.Text.ToUpper
            .FromENo = txtFormENo.Text
            .FromEDate = rdpFormEDate.SelectedDate
            .BLORAWB = txtBLorAWB.Text.ToUpper
            .BLORAWBDate = rdpBLorAWBDate.SelectedDate
            .ContainerNo = txtContainerNo.Text
            .ContainerSize = txtContainerSize.Text
            .ETADestination = rdpETADestination.SelectedDate
            .ClearingAgent = txtClearingAgent.Text.ToUpper
            .GDNo = txtGD.Text.ToUpper
            .GDDate = rdpGDDate.SelectedDate
            .PaymentTerms = TXTPaymentTerms.Text.ToUpper
            .PaymentDays = txtPaymentDays.Text
            .DocsSubmitIntoBankOn = rdpDocsSubmitIntoBankOn.SelectedDate
            .BankToBankDHLNo = txtBankToBankDHLNo.Text
            .BankToBankDHLDate = rdpBankToBankDHLDate.SelectedDate
            .BuyerDHLNo = txtBuyerDHLNo.Text
            .BuyerDHLDate = rdpBuyerDHLDate.SelectedDate
            .ExpectedPayRcvDate = txtExpectedPayRecDate.Text
            .DiscrepacyMsgDate = rdpDiscrepacyMsgDate.SelectedDate
            .TelexSendingDate = rdpTelexSendingDate.SelectedDate
            .PayMaburityDate = rdpPayMaburityDate.SelectedDate
            .AmountToBeRealized = txtAmountToBeRealized.Text
            .ExchangeRate = txtExchangeRate.Text
            .AmountInPKR = txtAmountInPKR.Text
            .PurchaseAmount = txtPurchaseAmount.Text
            .PurchaseRate = txtPurchaseRate.Text
            .PurchaseAmountPKR = txtPurchaseAmountPKR.Text
            .PurchaseDate = rdpPurchaseDate.SelectedDate
            .BalRealizedAmount = txtBalRealizedAmount.Text
            .RealizedRate = txtRealizedRate.Text
            .BalRealizedAmountPKR = txtBalRealizedAmountPKR.Text
            .RealizedDate = rdpRealizedDate.SelectedDate
            .FBCharges = txtFBCharges.Text
            .NetRealizedAmount = txtNetRealizedAmount.Text
            .NetRealizedAmountPKR = txtNetRealizedAmountPKR.Text
            .Remarks = txtRemarks.Text
            If cbPaymentReceived.Checked = True Then
                .Status = 1
            Else
                .Status = 0
            End If
            .SaveCargo()
        End With
    End Sub

End Class
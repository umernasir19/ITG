Imports Integra.EuroCentra
Imports System.Data
Public Class CargoReleaseNew
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtArticle As New DataTable
    Dim dtPurchaseOrder As New DataTable
    Dim lPOID As Long
    Dim Dr As DataRow
    Dim ICargoID As Long
    Dim Type As String
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim ObjTblRND As New TblDPRND
    Dim objDPSampleReceive As New DPSampleReceive
    Dim objDestination As New Destination
    Dim objPOD As New POD
    Dim objCurrency As New Currency
    Dim POID As String
    Dim objUser As New User
    Dim objDPIMst As New DPIMst
    Dim DTAdd As DataTable
    Dim objDataView As DataView
    Dim ObjCommodityClass As New CommodityClass
    Dim OBJFreightTerm As New FreightTerm
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("POID")
        ICargoID = Request.QueryString("IcargoID")
        Type = Request.QueryString("Type")
        If Not Page.IsPostBack Then
            Session("dtArticle") = Nothing
            Session("dtSelection") = Nothing
            Session("DTAdd") = Nothing
            BindGrossweightunit()
            BindNetweightunit()
            BindPODPOA()
            BindPOD()
            BinShipmentMode()
            BinCurrency()
            BindFreightTerm()
            BindCustomer()
            PageHeader("Shipment Release")
            If lPOID > 0 Then
                lPOID = lPOID
            Else
                lPOID = 0
            End If   
                If ICargoID > 0 Then
                    SetValuesEditMod()
                    BindGridOnEdit()
                    btnSave.Text = "Update"
                Else
                    btnSave.Text = "Save"
                    InvoiceNoGenerateOnLoad()
                End If
        End If
        txtContainer.Visible = True
        cmbContainerSize.Visible = True
        cmbConsolidation.Visible = False
        txtMode.Visible = True
        TDContainerNo.Visible = True
        TDContainerSize.Visible = True
        TDConsolidation.Visible = False
        TDMAWB.Visible = True
        txtShippedExchangeRate.Text = 1
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCargo.GetPackingCustomer
            cmbCustomer.DataSource = dtcmbSeason
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerId"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindPackingNo()
    End Sub
    Protected Sub btnAddCurrency_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddCurrency.Click
        Try
            pnlCurrency2.Visible = True
            pnlCurrency1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Sub BindFreightTerm()
        Try
            Dim dtMarchandizer As DataTable = ObjCargo.GetFreightTerm
            cmbItemDesc.DataSource = dtMarchandizer
            cmbItemDesc.DataTextField = "FreightTerm"
            cmbItemDesc.DataValueField = "FreightTermID"
            cmbItemDesc.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSaveCurrency_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveCurrency.Click
        Try
            If txtAddCurrency.Text = "" Then
            Else
                With objCurrency
                    .CurrencyID = 0
                    .CurrencyName = txtAddCurrency.Text.ToUpper
                    .SaveCurrency()
                End With
            End If
            pnlCurrency1.Visible = True
            pnlCurrency2.Visible = False
            BinCurrency()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BTNADDCMBFinalDestination_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BTNADDCMBFinalDestination.Click
        Try
            pnlPOD2.Visible = True
            pnlPOD1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BTNSAVECMBFinalDestination_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BTNSAVECMBFinalDestination.Click
        Try
            If TXTADDFinalDestination.Text = "" Then
            Else
                With objPOD
                    .PODId = 0
                    .POD = TXTADDFinalDestination.Text.ToUpper
                    .Save()
                End With
            End If
            pnlPOD1.Visible = True
            pnlPOD2.Visible = False
            BindPOD()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnAddPOA_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddPOA.Click
        Try
            PnlPOA2.Visible = True
            PnlPOA1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSavePOA_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSavePOA.Click
        Try
            If txtPOA.Text = "" Then
            Else
                With objDestination
                    .DestinationID = 0
                    .DestinationName = txtPOA.Text.ToUpper
                    .SaveDestination()
                End With
            End If
            PnlPOA1.Visible = True
            PnlPOA2.Visible = False
            BindPODPOA()
        Catch ex As Exception
        End Try
    End Sub
    Sub InvoiceNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim year As String = Voucherdate.Year
            Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = objDPSampleReceive.GetLastInvoiceNo(year)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(4, 4)
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
            VoucherNo = "DAL" & "-" & LastCode
            txtInvoiceNo.Text = VoucherNo
            txtInvoiceNooo.Text = "/" & yearv
        Catch ex As Exception
        End Try
    End Sub
    Sub BinShipmentMode()
        Dim dt As DataTable
        dt = objSizeRange.GetShipmentMode()
        cmbShipMode.DataSource = dt
        cmbShipMode.DataTextField = "ShipmentMode"
        cmbShipMode.DataValueField = "ShipmentModeID"
        cmbShipMode.DataBind()
    End Sub
    Sub BinCurrency()
        Dim dt As DataTable
        dt = objJobOrderdatabase.GetCurrency()
        cmbCurrencyNew.DataSource = dt
        cmbCurrencyNew.DataTextField = "CurrencyName"
        cmbCurrencyNew.DataValueField = "CurrencyID"
        cmbCurrencyNew.DataBind()
    End Sub
    Sub HideFieldsAIRMode()
        If cmbMode.SelectedItem.Text = "AIR" Then
            txtContainer.Visible = False
            cmbContainerSize.Visible = False
            cmbConsolidation.Visible = False
            TDContainerNo.Visible = False
            TDContainerSize.Visible = False
            TDConsolidation.Visible = False
        ElseIf cmbMode.SelectedItem.Text = "SEA" Then
            txtMode.Visible = False
            TDMAWB.Visible = False
        Else
            txtContainer.Visible = True
            cmbContainerSize.Visible = True
            cmbConsolidation.Visible = True
            txtMode.Visible = True
            TDContainerNo.Visible = True
            TDContainerSize.Visible = True
            TDConsolidation.Visible = True
            TDMAWB.Visible = True
        End If
    End Sub
    Sub BindPODPOA()
        Try
            Dim dtMarchandizer As DataTable = ObjCargo.GetDestination
            cmbPODPOA.DataSource = dtMarchandizer
            cmbPODPOA.DataTextField = "DestinationName"
            cmbPODPOA.DataValueField = "DestinationID"
            cmbPODPOA.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindPOD()
        Try
            Dim dtMarchandizer As DataTable = ObjCargo.GetPOD
            CMBFinalDestination.DataSource = dtMarchandizer
            CMBFinalDestination.DataTextField = "POD"
            CMBFinalDestination.DataValueField = "PODID"
            CMBFinalDestination.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindGrossweightunit()
        Try
            Dim dtMarchandizer As DataTable = ObjCargo.Getweightunit
            cmbgrossWeightUnit.DataSource = dtMarchandizer
            cmbgrossWeightUnit.DataTextField = "UnitName"
            cmbgrossWeightUnit.DataValueField = "UnitId"
            cmbgrossWeightUnit.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindNetweightunit()
        Try
            Dim dtMarchandizer As DataTable = ObjCargo.Getweightunit
            CmbNetWeighUnit.DataSource = dtMarchandizer
            CmbNetWeighUnit.DataTextField = "UnitName"
            CmbNetWeighUnit.DataValueField = "UnitId"
            CmbNetWeighUnit.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub ClearControls()
        txtInvoiceNo.Text = ""
        txtMode.Text = ""
        txtBillNo.Text = ""
        txtRemarks.Text = ""
    End Sub
    Protected Sub TXTLCNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXTLCNo.TextChanged
        Try
            Dim DtCheckExistingDalNo As DataTable = ObjTblRND.CheckExistingLCNo(TXTLCNo.Text)
            If DtCheckExistingDalNo.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim dt As DataTable = ObjTblRND.CheckExistingLCNo(TXTLCNo.Text)
                If dt.Rows.Count > 0 Then
                    cmbBank.Text = dt.Rows(0)("NegotiateBank")
                    txtDrawnOn.Text = dt.Rows(0)("IssueBank")
                    If DtCheckExistingDalNo.Rows(0)("PISendDate") = "1900-01-01 00:00:00.000" Then
                        txtDateOfIssue.SelectedDate = Date.Now
                    Else
                        txtDateOfIssue.SelectedDate = dt.Rows(0)("PISendDate")
                    End If

                End If
                Dim dtt As DataTable = ObjTblRND.GetPaymentTerm(TXTLCNo.Text)
                If dtt.Rows.Count > 0 Then
                    TXTLCTerms.Text = dtt.Rows(0)("PaymentTerm")
                    cmbCurrencyNew.SelectedValue = dtt.Rows(0)("CurrencyId")
                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("LC No Not Exist")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session("dtArticle") = Nothing
        Session("dtSelection") = Nothing
        Response.Redirect("CargoReleaseView.aspx")
    End Sub
    Protected Sub cmbMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMode.SelectedIndexChanged
        HideFieldsAIRMode()
    End Sub
    Protected Sub txtInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtInvoiceNo.TextChanged
        Try
            If ICargoID = 0 Then
                Dim dt As DataTable
                dt = ObjCargo.checkInvoice(txtInvoiceNo.Text)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Invoice No Already Exist.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                End If
            Else
                If Type = "Copy" Then
                    Dim dt As DataTable
                    dt = ObjCargo.checkInvoice(txtInvoiceNo.Text)
                    If dt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Invoice No Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function TXTNetWeightKGS() As Object
        Throw New NotImplementedException
    End Function
    Function ChekIDExist(ByVal ID As Long) As Boolean
        Dim i As Integer
        Dim idChek As Long
        Dim dt As New DataTable
        dt = Session("dtSelection")
        If Not dt Is Nothing Then
            For i = 0 To dt.Rows.Count - 1
                idChek = dt.Rows(i)("sid")
                If ID = idChek Then
                    Return True
                End If
            Next
        End If
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgArticle.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub btnAddFreightTerm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddFreightTerm.Click
        Try
            PNLFreightTerm2.Visible = True
            PNLFreightTerm1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsaveFreightTerm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnsaveFreightTerm.Click
        Try
            If txtFreightTerm.Text = "" Then
            Else
                With OBJFreightTerm
                    .FreightTermID = 0
                    .FreightTerm = txtFreightTerm.Text.ToUpper
                    .Save()
                End With
            End If
            PNLFreightTerm1.Visible = True
            PNLFreightTerm2.Visible = False
            BindFreightTerm()
        Catch ex As Exception
        End Try
    End Sub
    Sub SetValues()
        Try
            Dim DtCargo As DataTable
            Dim startdatee As String
            If txtCargoDatee.SelectedDate.ToString = "" Then
                startdatee = "01/01/1900"
            Else
                startdatee = txtCargoDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            End If
            DtCargo = ObjCargo.GetCargoForShipRateNewforcargo(startdatee, startdatee, cmbCurrencyNew.SelectedItem.Text)
            Dim ExchangeRate As Decimal
            If DtCargo.Rows.Count > 0 Then
                ExchangeRate = DtCargo.Rows(0)("ShipExchangeRate")
            Else
                ExchangeRate = 0
            End If
            With ObjCargo
                .CreationDate = Date.Now()
                If txtInvoiceNoo.Text = "" Then
                    .InvoiceNo = txtInvoiceNo.Text & " " & txtInvoiceNooo.Text
                Else
                    .InvoiceNo = txtInvoiceNo.Text & txtInvoiceNoo.Text & txtInvoiceNooo.Text
                End If
                .InvoiceNoPOne = txtInvoiceNo.Text
                If txtInvoiceNoo.Text = "" Then
                    .InvoiceNoPTwo = ""
                Else
                    .InvoiceNoPTwo = txtInvoiceNoo.Text
                End If

                .InvoiceNoPThree = txtInvoiceNooo.Text
                If txtInvoiceDatee.SelectedDate.ToString = "" Then
                    .InvoiceDate = "01/01/1900"
                Else
                    .InvoiceDate = txtInvoiceDatee.SelectedDate
                End If

                .InvoiceValue = Val(txtInvoiceValue.Text)
                .Terms = cmbMode.SelectedItem.Text
                .ItemDescription = cmbItemDesc.SelectedItem.Text
                If txtMode.Text = "" Then
                    .Mode = ""
                Else
                    .Mode = txtMode.Text
                End If
                If txtCarrierName.Text = "" Then

                    .CarrierName = ""
                Else
                    .CarrierName = txtCarrierName.Text
                End If

                If txtVoyageFlight.Text = "" Then
                    .VoyageFlight = ""
                Else
                    .VoyageFlight = txtVoyageFlight.Text
                End If
                If txtBillNo.Text = "" Then
                    .BillNo = ""
                Else
                    .BillNo = txtBillNo.Text
                End If
                If txtHandOverDate.SelectedDate.ToString = "" Then
                    .HandOverDate = "01/01/1900"
                Else
                    .HandOverDate = txtHandOverDate.SelectedDate
                End If
                If txtCargoDatee.SelectedDate.ToString = "" Then
                    .ShipmentDate = "01/01/1900"

                Else
                    .ShipmentDate = txtCargoDatee.SelectedDate
                End If
                If txtContainer.Text = "" Then
                    .ContainerNo = ""
                Else
                    .ContainerNo = txtContainer.Text
                End If
                If txtRemarks.Text = "" Then
                    .Remarks = ""
                Else
                    .Remarks = txtRemarks.Text
                End If
                .IsActive = False
                If txtCargoDatee.SelectedDate.ToString = "" Then
                    .ETD = "01/01/1900"
                Else
                    .ETD = txtCargoDatee.SelectedDate
                End If
                If txtETDD.SelectedDate.ToString = "" Then
                    .ETA = "01/01/1900"
                Else
                    .ETA = txtETAA.SelectedDate
                End If
                If txtForwarder.Text = "" Then
                    .Forwarder = ""
                Else
                    .Forwarder = txtForwarder.Text
                End If

                If txtCBM.Text = "" Then
                    .CBM = 0
                Else
                    .CBM = txtCBM.Text
                End If
                .Consolidation = cmbConsolidation.SelectedItem.Text
                .ContainerSize = cmbContainerSize.SelectedItem.Text
                If txtShippingLine.Text = "" Then
                    .ShippingLine = ""
                Else
                    .ShippingLine = txtShippingLine.Text
                End If
                If txtShippedExchangeRate.Text = "" Then
                    .ShippedExchangeRate = ExchangeRate
                Else
                    .ShippedExchangeRate = ExchangeRate
                End If
                .UserID = CLng(Session("UserID"))
                If txtNetWeight.Text = "" Then
                    .NetWeight = 0
                Else
                    .NetWeight = Val(txtNetWeight.Text)
                End If
                If txtGrossWeight.Text = "" Then
                    .GrossWeight = 0
                Else
                    .GrossWeight = Val(txtGrossWeight.Text)
                End If
                .NetWeightUnit = CmbNetWeighUnit.SelectedItem.Text
                .GrossWeightUnit = cmbgrossWeightUnit.SelectedItem.Text
                .DestinationID = cmbPODPOA.SelectedValue
                If cmbBank.Text = "" Then
                    .AccountCode = ""
                Else
                    .AccountCode = cmbBank.Text
                End If
                If TXTFromENo.Text = "" Then
                    .FromENO = ""
                Else
                    .FromENO = TXTFromENo.Text.ToUpper
                End If
                If txtFromEDate.SelectedDate.ToString = "" Then
                    .FromEDate = "01/01/1900"
                Else
                    .FromEDate = txtFromEDate.SelectedDate
                End If
                If TXTLCNo.Text = "" Then
                    .LCNO = ""
                Else
                    .LCNO = TXTLCNo.Text.ToUpper
                End If
                If txtDateOfIssue.SelectedDate.ToString = "" Then
                    .DateOfIssue = "01/01/1900"
                Else
                    .DateOfIssue = txtDateOfIssue.SelectedDate
                End If
                If TXTLCTerms.Text = "" Then
                    .LCTerms = ""
                Else
                    .LCTerms = TXTLCTerms.Text.ToUpper
                End If
                .ShipModeID = cmbShipMode.SelectedValue
                If txtDrawnOn.Text = "" Then
                    .DrawnOn = ""
                Else
                    .DrawnOn = txtDrawnOn.Text.ToUpper
                End If
                .FinalDest = CMBFinalDestination.SelectedItem.Text

                If txtWeightCTN.Text = "" Then
                    .WeightCTN = 0
                Else
                    .WeightCTN = txtWeightCTN.Text
                End If
                If txtTermOfSale.Text = "" Then
                    .TermOfSale = ""
                Else
                    .TermOfSale = txtTermOfSale.Text.ToUpper
                End If
                If txtByOrderAndRiskOf.Text = "" Then
                    .ByOrderAndRisk = ""
                Else
                    .ByOrderAndRisk = txtByOrderAndRiskOf.Text.ToUpper
                End If
                .Currencyid = cmbCurrencyNew.SelectedValue
                If txtMarksAndNumbers.Text = "" Then
                    .MarksAndNumbers = ""
                Else
                    .MarksAndNumbers = txtMarksAndNumbers.Text.ToUpper
                End If
                If txtRemarksNew.Text = "" Then
                    .RemarksNew = ""
                Else
                    .RemarksNew = txtRemarksNew.Text.ToUpper
                End If
                .WithStyleNo = 0
                .WithOrderNo = 0
                .Both = 0
                If txtForwardingAgent.Text = "" Then
                    .ForwardingAgent = ""
                Else
                    .ForwardingAgent = txtForwardingAgent.Text
                End If
                If TXTETDDate.SelectedDate.ToString = "" Then
                    .ETDDate = "01/01/1900"
                Else
                    .ETDDate = TXTETDDate.SelectedDate
                End If
                If txtClearningAgent.Text = "" Then
                    .ClearningAgent = ""
                Else
                    .ClearningAgent = txtClearningAgent.Text
                End If
                .SaveCargo()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridOnEdit()
        Dim Dtt As DataTable = Session("DTAdd")
        dgArticle.DataSource = Dtt
        dgArticle.DataBind()
        Dim ReleaseQuantity As TextBox
        Dim ShippedRate As Decimal
        Dim SystemInvoiceValue As Decimal = 0
        Dim SystemReleaseQuantity As Integer = 0
        Dim SystemCTN As Integer = 0
        Dim Gross As Decimal = 0
        Dim cartonn As Decimal = 0
        For x = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            Dim txtHsCode As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim TXTStyle As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim Cartons As TextBox = DirectCast(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            Dim txtWhitePCS As TextBox = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            Dim txtWhiteCarton As TextBox = CType(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
            TXTCommodity.Text = Dtt.Rows(x)("Commodity")
            LBLCommodityID.Text = Dtt.Rows(x)("CommodityID")
            txtHsCode.Text = Dtt.Rows(x)("HsCode")
            txtReleaseQuantity.Text = Dtt.Rows(x)("PCS")
            Cartons.Text = Dtt.Rows(x)("CTNS")
            txtWhitePCS.Text = Dtt.Rows(x)("WhitePCS")
            txtWhiteCarton.Text = Dtt.Rows(x)("WhiteCTN")
            TXTStyle.Text = Dtt.Rows(x)("StyleArticle")
            TXTWeightPCS.Text = Dtt.Rows(x)("WeightPerPcs")
            Gross = Math.Round(Gross + Val(TXTWeightPCS.Text) * Val(txtReleaseQuantity.Text), 2)
            lblmsg.Visible = True
            ReleaseQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            ShippedRate = dgArticle.Items(x).Cells(18).Text()
            SystemInvoiceValue = SystemInvoiceValue + (Convert.ToDecimal(ReleaseQuantity.Text) * Convert.ToDecimal(ShippedRate))
            SystemReleaseQuantity = SystemReleaseQuantity + Convert.ToDecimal(ReleaseQuantity.Text)
            SystemCTN = SystemCTN + Val(Cartons.Text)
            lblmsg.Text = "-: System Calculated Invoice Value is :  " + SystemInvoiceValue.ToString()
            lblSystemValue.Text = SystemInvoiceValue.ToString()
            txtInvoiceValue.Text = Val(lblSystemValue.Text)
            lblReleaseQTY.Visible = True
            lblReleaseQTY.Text = "-: System Calculated Shipped Quantity : " + SystemReleaseQuantity.ToString()
            lblTotalCTN.Text = "-: System Calculated CTNS : " + SystemCTN.ToString()
            lblOk.Visible = False
            UpMsgs.Update()
            lblTotalCTN.Visible = True
            UptxtInvoiceValue.Update()
            cartonn = cartonn + Dtt.Rows(x)("CTNS")
        Next
        txtNetWeight.Text = Gross
        txtNoOfCarton.Text = cartonn
    End Sub
    Sub SetDetailValues()
        Dim x As Integer
        For x = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            Dim txtHsCode As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            Dim TXTStyle As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim Cartons As TextBox = DirectCast(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            Dim ShippedRate As TextBox = DirectCast(dgArticle.Items(x).FindControl("ShippedRate"), TextBox)
            Dim TXTWeightPCS As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            Dim txtWhitePCS As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            Dim txtWhiteCarton As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
            With ObjCargoDetail
                .CargoDetailID = dgArticle.Items(x).Cells(0).Text
                If ICargoID > 0 Then
                    .CargoID = ICargoID
                Else
                    .CargoID = ObjCargo.GetId
                End If
                .POID = dgArticle.Items(x).Cells(2).Text
                .POPOID = dgArticle.Items(x).Cells(1).Text
                .CustomerID = dgArticle.Items(x).Cells(3).Text
                .StyleArticle = TXTStyle.Text
                .CommodityID = LBLCommodityID.Text
                .Commodity = TXTCommodity.Text
                .HsCode = txtHsCode.Text
                .Quantity = dgArticle.Items(x).Cells(9).Text
                .PCS = txtReleaseQuantity.Text
                .CTNS = Cartons.Text
                .ShippedRate = ShippedRate.Text
                .WeightPerPcs = TXTWeightPCS.text
                .WhitePCS = txtWhitePCS.Text
                .WhiteCTN = txtWhiteCarton.Text
                .SaveCargoDetail()
            End With
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Save" Then
                If txtInvoiceValue.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Invoice Value is Empty")
                ElseIf IsNothing("dtArticle") = True Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Add One Row in Detail")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SetValues()
                    SetDetailValues()
                    Session("dtArticle") = Nothing
                    Session("dtSelection") = Nothing
                    Session("DTAdd") = Nothing
                    Response.Redirect("CargoReleaseView.aspx")
                End If
                Else
                End If
            If btnSave.Text = "Update" Then
                Dim InvoiceVL As Decimal
                If txtInvoiceValue.Text = "" Then
                    InvoiceVL = 0
                Else
                    InvoiceVL = Convert.ToDecimal(txtInvoiceValue.Text)
                End If
                SetValuesEdited()
                ObjCargoDetail.DeleteCargoDetailbyID(ICargoID)
                SetDetailValues()
                Session("dtArticle") = Nothing
                Session("dtSelection") = Nothing
                Session("DTAdd") = Nothing
                Response.Redirect("CargoReleaseView.aspx")
            End If
        Catch ex As Exception
            lblInvoiceMSG.Text = ex.ToString()
            lblInvoiceMSG.Visible = True
        End Try
    End Sub
    Sub SetValuesEdited()
        With ObjCargo
            .CargoID = ICargoID
            .CreationDate = Date.Now
            If txtInvoiceNoo.Text = "" Then
                .InvoiceNo = txtInvoiceNo.Text & " " & txtInvoiceNooo.Text
            Else
                .InvoiceNo = txtInvoiceNo.Text & txtInvoiceNoo.Text & txtInvoiceNooo.Text
            End If

            .InvoiceNoPOne = txtInvoiceNo.Text
            If txtInvoiceNoo.Text = "" Then
                .InvoiceNoPTwo = ""
            Else
                .InvoiceNoPTwo = txtInvoiceNoo.Text
            End If

            .InvoiceNoPThree = txtInvoiceNooo.Text
            If txtInvoiceDatee.SelectedDate.ToString = "" Then
                .InvoiceDate = "01/01/1900"
            Else
                .InvoiceDate = txtInvoiceDatee.SelectedDate
            End If

            .InvoiceValue = Val(txtInvoiceValue.Text)
            .Terms = cmbMode.SelectedItem.Text 'txtTerm.Text
            .ItemDescription = cmbItemDesc.SelectedItem.Text ' txtItemDesc.Text
            If txtMode.Text = "" Then
                .Mode = ""
            Else
                .Mode = txtMode.Text
            End If
            If txtCarrierName.Text = "" Then

                .CarrierName = ""
            Else
                .CarrierName = txtCarrierName.Text
            End If
            If txtVoyageFlight.Text = "" Then
                .VoyageFlight = ""
            Else
                .VoyageFlight = txtVoyageFlight.Text
            End If
            If txtBillNo.Text = "" Then
                .BillNo = ""
            Else
                .BillNo = txtBillNo.Text
            End If
            If txtHandOverDate.SelectedDate.ToString = "" Then
                .HandOverDate = "01/01/1900"
            Else
                .HandOverDate = txtHandOverDate.SelectedDate
            End If
            If txtCargoDatee.SelectedDate.ToString = "" Then
                .ShipmentDate = "01/01/1900"

            Else
                .ShipmentDate = txtCargoDatee.SelectedDate
            End If
            If txtContainer.Text = "" Then
                .ContainerNo = ""
            Else
                .ContainerNo = txtContainer.Text
            End If
            If txtRemarks.Text = "" Then
                .Remarks = ""
            Else
                .Remarks = txtRemarks.Text
            End If
            .IsActive = False
            If txtETDD.SelectedDate.ToString = "" Then
                .ETD = "01/01/1900"
            Else
                .ETD = txtCargoDatee.SelectedDate
            End If
            If txtETAA.SelectedDate.ToString = "" Then
                .ETA = "01/01/1900"
            Else
                .ETA = txtETAA.SelectedDate
            End If
            If txtForwarder.Text = "" Then
                .Forwarder = ""
            Else
                .Forwarder = txtForwarder.Text
            End If


            If txtCBM.Text = "" Then
                .CBM = 0
            Else
                .CBM = txtCBM.Text
            End If
            .Consolidation = cmbConsolidation.SelectedItem.Text
            .ContainerSize = cmbContainerSize.SelectedItem.Text
            .ShippingLine = txtShippingLine.Text
            If txtShippedExchangeRate.Text = "" Then
                .ShippedExchangeRate = 0
            Else
                .ShippedExchangeRate = Val(txtShippedExchangeRate.Text)
            End If
            .UserID = CLng(Session("UserID"))
            If txtNetWeight.Text = "" Then
                .NetWeight = 0
            Else
                .NetWeight = Val(txtNetWeight.Text)
            End If
            If txtGrossWeight.Text = "" Then
                .GrossWeight = 0
            Else
                .GrossWeight = Val(txtGrossWeight.Text)
            End If
            .NetWeightUnit = CmbNetWeighUnit.SelectedItem.Text
            .GrossWeightUnit = cmbgrossWeightUnit.SelectedItem.Text
            .DestinationID = cmbPODPOA.SelectedValue
            If txtNoOfCarton.Text = "" Then
                .NoOfCartoon = 0
            Else
                .NoOfCartoon = txtNoOfCarton.Text
            End If
            If cmbBank.Text = "" Then
                .AccountCode = ""
            Else
                .AccountCode = cmbBank.Text
            End If
            If TXTFromENo.Text = "" Then
                .FromENO = ""
            Else
                .FromENO = TXTFromENo.Text.ToUpper
            End If
            If txtFromEDate.SelectedDate.ToString = "" Then
                .FromEDate = "01/01/1900"
            Else
                .FromEDate = txtFromEDate.SelectedDate
            End If
            If TXTLCNo.Text = "" Then
                .LCNO = ""
            Else
                .LCNO = TXTLCNo.Text.ToUpper
            End If
            If txtDateOfIssue.SelectedDate.ToString = "" Then
                .DateOfIssue = "01/01/1900"
            Else
                .DateOfIssue = txtDateOfIssue.SelectedDate
            End If
            If TXTLCTerms.Text = "" Then
                .LCTerms = ""
            Else
                .LCTerms = TXTLCTerms.Text.ToUpper
            End If

            .ShipModeID = cmbShipMode.SelectedValue
            If txtDrawnOn.Text = "" Then
                .DrawnOn = ""
            Else
                .DrawnOn = txtDrawnOn.Text.ToUpper
            End If
         
                .FinalDest = CMBFinalDestination.SelectedItem.Text

            If txtWeightCTN.Text = "" Then
                .WeightCTN = 0
            Else
                .WeightCTN = txtWeightCTN.Text
            End If
            If txtTermOfSale.Text = "" Then
                .TermOfSale = ""
            Else
                .TermOfSale = txtTermOfSale.Text.ToUpper
            End If
            If txtByOrderAndRiskOf.Text = "" Then
                .ByOrderAndRisk = ""
            Else
                .ByOrderAndRisk = txtByOrderAndRiskOf.Text.ToUpper
            End If

            .Currencyid = cmbCurrencyNew.SelectedValue
            If txtMarksAndNumbers.Text = "" Then
                .MarksAndNumbers = ""
            Else
                .MarksAndNumbers = txtMarksAndNumbers.Text.ToUpper
            End If

            .RemarksNew = txtRemarksNew.Text.ToUpper
            .WithStyleNo = 0
                .WithOrderNo = 0
            .Both = 0
            If txtForwardingAgent.Text = "" Then
                .ForwardingAgent = ""
            Else
                .ForwardingAgent = txtForwardingAgent.Text
            End If
            If TXTETDDate.SelectedDate.ToString = "" Then
                .ETDDate = "01/01/1900"
            Else
                .ETDDate = TXTETDDate.SelectedDate
            End If
            If txtClearningAgent.Text = "" Then
                .ClearningAgent = ""
            Else
                .ClearningAgent = txtClearningAgent.Text
            End If
            .SaveCargo()
        End With
    End Sub
    Sub SetValuesEditMod()
        Try
            Dim Dt As DataTable
            Dim x As Integer
            Dt = ObjCargo.GetCargoInfoAllNewNew(ICargoID)
            If Dt.Rows.Count = Nothing Then
            Else
                txtInvoiceNo.Text = Dt.Rows(0)("InvoiceNo")
                If Dt.Rows(0)("InvoiceDate") = "01/01/1900" Then
                Else
                    txtInvoiceDatee.SelectedDate = Dt.Rows(0)("InvoiceDate")
                End If
                txtInvoiceValue.Text = Dt.Rows(0)("InvoiceValue")
                cmbMode.SelectedItem.Text = Dt.Rows(0)("Terms")
                txtItemDesc.Text = Dt.Rows(0)("ItemDescription")
                cmbItemDesc.SelectedItem.Text = Dt.Rows(0)("ItemDescription")
                txtMode.Text = Dt.Rows(0)("Mode")
                txtCarrierName.Text = Dt.Rows(0)("CarrierName")
                txtVoyageFlight.Text = Dt.Rows(0)("VoyageFlight")
                txtBillNo.Text = Dt.Rows(0)("BillNo")
                If Dt.Rows(0)("HandOverDate") = "01/01/1900" Then
                Else
                    txtHandOverDate.SelectedDate = Dt.Rows(0)("HandOverDate")
                End If
                If Dt.Rows(0)("ShipmentDate") = "01/01/1900" Then
                Else
                    txtCargoDatee.SelectedDate = Dt.Rows(0)("ShipmentDate")
                End If
                txtContainer.Text = Dt.Rows(0)("ContainerNo")
                txtRemarks.Text = Dt.Rows(0)("Remarks")
                If Dt.Rows(0)("ETD") = "01/01/1900" Then
                Else
                    txtETDD.SelectedDate = Dt.Rows(0)("ETD")
                End If
                If Dt.Rows(0)("ETA") = "01/01/1900" Then
                Else
                    txtETAA.SelectedDate = Dt.Rows(0)("ETA")
                End If
                txtForwarder.Text = Dt.Rows(0)("Forwarder")
                txtCBM.Text = Dt.Rows(0)("CBM")
                cmbConsolidation.SelectedValue = Dt.Rows(0)("Consolidation")
                cmbContainerSize.SelectedValue = Dt.Rows(0)("ContainerSize")
                txtShippingLine.Text = Dt.Rows(0)("ShippingLine")
                txtShippedExchangeRate.Text = Dt.Rows(0)("ShippedExchangeRate")
                txtNetWeight.Text = Dt.Rows(0)("NetWeight")
                txtGrossWeight.Text = Dt.Rows(0)("GrossWeight")
                CmbNetWeighUnit.SelectedItem.Text = Dt.Rows(0)("NetWeightUnit")
                cmbgrossWeightUnit.SelectedItem.Text = Dt.Rows(0)("GrossWeightUnit")
                cmbPODPOA.SelectedValue = Dt.Rows(0)("DestinationID")
                txtNoOfCarton.Text = Dt.Rows(0)("NoOfCartoon")
                cmbBank.Text = Dt.Rows(0)("AccountCode")
                txtForwardingAgent.Text = Dt.Rows(0)("ForwardingAgent")
                If Dt.Rows(0)("ETDDate") = "01/01/1900" Then
                Else
                    TXTETDDate.SelectedDate = Dt.Rows(0)("ETDDate")
                End If
                txtClearningAgent.Text = Dt.Rows(0)("ClearningAgent")
                TXTFromENo.Text = Dt.Rows(0)("FromENO")
                If Dt.Rows(0)("FromEDate") = "01/01/1900" Then
                Else
                    txtFromEDate.SelectedDate = Dt.Rows(0)("FromEDate")
                End If
                TXTLCNo.Text = Dt.Rows(0)("LCNO")
                If Dt.Rows(0)("DateOfIssue") = "01/01/1900" Then
                Else
                    txtDateOfIssue.SelectedDate = Dt.Rows(0)("DateOfIssue")
                End If
                TXTLCTerms.Text = Dt.Rows(0)("LCTerms")
                cmbShipMode.SelectedValue = Dt.Rows(0)("ShipModeID")
                txtDrawnOn.Text = Dt.Rows(0)("DrawnOn")
                CMBFinalDestination.SelectedItem.Text = Dt.Rows(0)("FinalDest")
                txtWeightCTN.Text = Dt.Rows(0)("WeightCTN")
                txtTermOfSale.Text = Dt.Rows(0)("TermOfSale")
                txtByOrderAndRiskOf.Text = Dt.Rows(0)("ByOrderAndRisk")
                cmbCurrencyNew.SelectedValue = Dt.Rows(0)("Currencyid")
                txtMarksAndNumbers.Text = Dt.Rows(0)("MarksAndNumbers")
                txtRemarksNew.Text = Dt.Rows(0)("RemarksNew")
                txtInvoiceNo.Text = Dt.Rows(0)("InvoiceNoPOne")
                txtInvoiceNoo.Text = Dt.Rows(0)("InvoiceNoPTwo")
                txtInvoiceNooo.Text = Dt.Rows(0)("InvoiceNoPThree")
                Dim WithStyleNo As Boolean = Dt.Rows(0)("WithStyleNo")
                dtArticle = Nothing
                Session("DTAdd") = Nothing
                dtArticle = New DataTable
                With dtArticle
                       .Columns.Add("CargoDetailid", GetType(String))
                    .Columns.Add("POPOID", GetType(String))
                    .Columns.Add("POID", GetType(Long))
                    .Columns.Add("CustomerID", GetType(String))
                    .Columns.Add("StyleArticle", GetType(String))
                    .Columns.Add("HsCode", GetType(String))
                    .Columns.Add("CommodityID", GetType(String))
                    .Columns.Add("Commodity", GetType(String))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("CustomerName", GetType(String))
                    .Columns.Add("Quantity", GetType(String))
                    .Columns.Add("ShippedQty", GetType(String))
                    .Columns.Add("PCS", GetType(String))
                    .Columns.Add("CTNS", GetType(String))
                    .Columns.Add("ShippedRate", GetType(String))
                    .Columns.Add("WeightPerPcs", GetType(String))
                    .Columns.Add("WhitePCS", GetType(String))
                    .Columns.Add("WhiteCTN", GetType(String))
                End With
                For x = 0 To Dt.Rows.Count - 1
                    Dr = dtArticle.NewRow()
                    Dr("CargoDetailid") = Dt.Rows(x)("CargoDetailid")
                    Dr("POPOID") = Dt.Rows(x)("POPOID")
                    Dr("POID") = Dt.Rows(x)("POID")
                    Dr("CustomerID") = Dt.Rows(x)("CustomerID")
                    Dr("StyleArticle") = Dt.Rows(x)("StyleArticle")
                    Dr("CommodityID") = Dt.Rows(x)("CommodityID")
                    Dr("Commodity") = Dt.Rows(x)("Commodity")
                    Dr("HsCode") = Dt.Rows(x)("HsCode")
                    Dr("SRNO") = Dt.Rows(x)("PONo")
                    Dr("CustomerName") = Dt.Rows(x)("CustomerName")
                    Dr("Quantity") = Dt.Rows(x)("QuantityY")
                    Dr("ShippedQty") = Dt.Rows(x)("QuantityY")
                    Dr("PCS") = Dt.Rows(x)("PCS")
                    Dr("CTNS") = Dt.Rows(x)("CTNS")
                    Dr("ShippedRate") = Dt.Rows(x)("ShippedRate")
                    Dr("WeightPerPcs") = Dt.Rows(x)("WeightPerPcs")
                    Dr("WhitePCS") = Dt.Rows(x)("WhitePCS")
                    Dr("WhiteCTN") = Dt.Rows(x)("WhiteCTN")
                    dtArticle.Rows.Add(Dr)
                Next
                Session("DTAdd") = dtArticle
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtWeightCTN_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWeightCTN.TextChanged
        Try
            txtGrossWeight.Text = Math.Round(Val(txtWeightCTN.Text) * Val(txtNoOfCarton.Text), 0) + Val(txtNetWeight.Text)
            UpTXTGrossWeightKGS.Update()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgArticle_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgArticle.ItemCommand
        Select Case e.CommandName
            Case Is = "AddCommdity"
                Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("TXTCommodity"), TextBox)
                Dim imgSyleAdd As ImageButton = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("imgSyleAdd"), ImageButton)
                Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("LBLCommodityID"), Label)
                If TXTCommodity.Text = "" Then
                    Errormgs.Text = "Please Fill Style."
                Else
                    Errormgs.Text = ""
                    With ObjCommodityClass
                        .Commodityid = 0
                        .Commodity = TXTCommodity.Text.ToUpper
                        .save()
                        TXTCommodity.Text = ""
                        LBLCommodityID.Text = 0
                        TXTCommodity.Focus()
                    End With
                End If
            Case "Remove"
                DTAdd = CType(Session("DTAdd"), DataTable)
                If (Not DTAdd Is Nothing) Then
                    If (DTAdd.Rows.Count > 0) Then
                        Dim PoDetailId As Integer = dgArticle.Items(e.Item.ItemIndex).Cells(0).Text
                        DTAdd.Rows.RemoveAt(e.Item.ItemIndex)
                        ObjCommodityClass.DeleteDetail(PoDetailId)
                        BindGridAfterRemove()
                    End If
                End If
        End Select
    End Sub
    Private Sub BindGridAfterRemove()
        Dim Dtt As DataTable = Session("DTAdd")
        dgArticle.DataSource = Dtt
        dgArticle.DataBind()
        Dim x As Integer
        Dim ReleaseQuantity As TextBox
        Dim ShippedRate As Decimal
        Dim SystemInvoiceValue As Decimal = 0
        Dim SystemReleaseQuantity As Integer = 0
        Dim SystemCTN As Integer = 0
        Dim Gross As Decimal = 0
        Dim cartonn As Decimal = 0
        For x = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            Dim txtHsCode As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim TXTStyle As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim Cartons As TextBox = DirectCast(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            Dim txtWhitePCS As TextBox = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            Dim txtWhiteCarton As TextBox = CType(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
            TXTCommodity.Text = Dtt.Rows(x)("Commodity")
            LBLCommodityID.Text = Dtt.Rows(x)("CommodityID")
            txtHsCode.Text = Dtt.Rows(x)("HsCode")
            txtReleaseQuantity.Text = Dtt.Rows(x)("PCS")
            Cartons.Text = Dtt.Rows(x)("CTNS")
            txtWhitePCS.Text = Dtt.Rows(x)("WhitePCS")
            txtWhiteCarton.Text = Dtt.Rows(x)("WhiteCTN")
            TXTStyle.Text = Dtt.Rows(x)("StyleArticle")
            TXTWeightPCS.Text = Dtt.Rows(x)("WeightPerPcs")
            Gross = Math.Round(Gross + Val(TXTWeightPCS.Text) * Val(txtReleaseQuantity.Text), 2)
            lblmsg.Visible = True
            ReleaseQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            ShippedRate = dgArticle.Items(x).Cells(18).Text()
            SystemInvoiceValue = SystemInvoiceValue + (Convert.ToDecimal(ReleaseQuantity.Text) * Convert.ToDecimal(ShippedRate))
            SystemReleaseQuantity = SystemReleaseQuantity + Convert.ToDecimal(ReleaseQuantity.Text)
            SystemCTN = SystemCTN + Val(Cartons.Text)
            lblmsg.Text = "-: System Calculated Invoice Value is :  " + SystemInvoiceValue.ToString()
            lblSystemValue.Text = SystemInvoiceValue.ToString()
            txtInvoiceValue.Text = Val(lblSystemValue.Text)
            lblReleaseQTY.Visible = True
            lblReleaseQTY.Text = "-: System Calculated Shipped Quantity : " + SystemReleaseQuantity.ToString()
            lblTotalCTN.Text = "-: System Calculated CTNS : " + SystemCTN.ToString()
            lblOk.Visible = False
            UpMsgs.Update()
            lblTotalCTN.Visible = True
            UptxtInvoiceValue.Update()
            cartonn = cartonn + Dtt.Rows(x)("CTNS")
        Next
        txtNetWeight.Text = Gross
        txtNoOfCarton.Text = cartonn
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If cmbPackingNo.SelectedValue = 0 Then
                Errormgs.Text = "Select Packing No"
            Else
                Errormgs.Text = ""
                Dim objDataTable As DataTable
                objDataTable = ObjCargoDetail.GetDataForPackingNew(cmbPackingNo.SelectedValue)
                If objDataTable.Rows.Count = Nothing Then
                    Errormgs.Text = " No Record Found"
                    dgArticle.Visible = False
                    Errormgs.Visible = True
                Else
                    Errormgs.Visible = False
                    dgArticle.Visible = True
                    SaveSession()
                    BindGrid()
                End If
            End If
        Catch objUDException As UDException
        End Try
    End Sub
    Sub SaveSession()
        Dim dt As DataTable = ObjCargoDetail.GetDataForPackingNew(cmbPackingNo.SelectedValue)
        If (Not CType(Session("DTAdd"), DataTable) Is Nothing) Then
            DTAdd = Session("DTAdd")
        Else
            DTAdd = New DataTable
            With DTAdd
                .Columns.Add("CargoDetailid", GetType(String))
                .Columns.Add("POPOID", GetType(String))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("CustomerID", GetType(String))
                .Columns.Add("StyleArticle", GetType(String))
                .Columns.Add("HsCode", GetType(String))
                .Columns.Add("CommodityID", GetType(String))
                .Columns.Add("Commodity", GetType(String))
                .Columns.Add("SRNO", GetType(String))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("ShippedQty", GetType(String))
                .Columns.Add("PCS", GetType(String))
                .Columns.Add("CTNS", GetType(String))
                .Columns.Add("ShippedRate", GetType(String))
                .Columns.Add("WeightPerPcs", GetType(String))
                .Columns.Add("WhitePCS", GetType(String))
                .Columns.Add("WhiteCTN", GetType(String))
            End With
        End If
        For x = 0 To dt.Rows.Count - 1
            Dr = DTAdd.NewRow()
            Dr("CargoDetailid") = dt.Rows(x)("CargoDetailid")
            Dr("POPOID") = dt.Rows(x)("joborderid")
            Dr("POID") = dt.Rows(x)("JoborderDetailid")
            Dr("CustomerID") = dt.Rows(x)("CustomerID")
            Dr("StyleArticle") = dt.Rows(x)("Model")
            Dr("HsCode") = ""
            Dr("CommodityID") = 0
            Dr("Commodity") = ""
            Dr("SRNO") = dt.Rows(x)("SRNO")
            Dr("CustomerName") = dt.Rows(x)("CustomerName")
            Dr("Quantity") = dt.Rows(x)("Quantity")
            Dr("ShippedQty") = dt.Rows(x)("ShippedQuantity")
            Dr("ShippedRate") = dt.Rows(x)("UnitPrice")
            Dr("WhitePCS") = 0
            Dr("WhiteCTN") = 0
            Dim dtt As DataTable = ObjCargoDetail.GetDataForPackingQuantites(dt.Rows(x)("JobOrderId"))
            If dtt.Rows.Count > 0 Then
                Dr("PCS") = dt.Rows(0)("Qty")
                Dr("CTNS") = dt.Rows(0)("NoOfCarton")
                If dt.Rows(0)("Weight") = 0 Then
                    Dr("WeightPerPcs") = 0
                Else
                    Dr("WeightPerPcs") = dt.Rows(0)("Weight") / dt.Rows(0)("Qty")
                End If
            Else
                Dr("PCS") = 0
                Dr("CTNS") = 0
                Dr("WeightPerPcs") = 0
            End If
            DTAdd.Rows.Add(Dr)
        Next
        Session("DTAdd") = DTAdd
        Session("objDataView") = Session("DTAdd")
    End Sub
    Private Sub BindGrid()
        Dim Dtt As DataTable = Session("objDataView")
        dgArticle.DataSource = Dtt
        dgArticle.DataBind()
        Dim x As Integer
        Dim ReleaseQuantity As TextBox
        Dim ShippedRate As Decimal
        Dim SystemInvoiceValue As Decimal = 0
        Dim SystemReleaseQuantity As Integer = 0
        Dim SystemCTN As Integer = 0
        Dim cartonn As Decimal = 0
        Dim Gross As Decimal = 0
        For x = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            Dim txtHsCode As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim TXTStyle As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim Cartons As TextBox = DirectCast(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            Dim txtWhitePCS As TextBox = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            Dim txtWhiteCarton As TextBox = CType(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
            TXTCommodity.Text = Dtt.Rows(x)("Commodity")
            LBLCommodityID.Text = Dtt.Rows(x)("CommodityID")
            txtHsCode.Text = Dtt.Rows(x)("HsCode")
            txtReleaseQuantity.Text = Dtt.Rows(x)("PCS")
            Cartons.Text = Dtt.Rows(x)("CTNS")
            txtWhitePCS.Text = Dtt.Rows(x)("WhitePCS")
            txtWhiteCarton.Text = Dtt.Rows(x)("WhiteCTN")
            TXTStyle.Text = Dtt.Rows(x)("StyleArticle")
            TXTWeightPCS.Text = Dtt.Rows(x)("WeightPerPcs")
            Gross = Math.Round(Gross + Val(TXTWeightPCS.Text) * Val(txtReleaseQuantity.Text), 2)
            lblmsg.Visible = True
            ReleaseQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            ShippedRate = dgArticle.Items(x).Cells(18).Text()
            SystemInvoiceValue = SystemInvoiceValue + (Convert.ToDecimal(ReleaseQuantity.Text) * Convert.ToDecimal(ShippedRate))
            SystemReleaseQuantity = SystemReleaseQuantity + Convert.ToDecimal(ReleaseQuantity.Text)
            SystemCTN = SystemCTN + Val(Cartons.Text)
            lblmsg.Text = "-: System Calculated Invoice Value is :  " + SystemInvoiceValue.ToString()
            lblSystemValue.Text = SystemInvoiceValue.ToString()
            txtInvoiceValue.Text = Val(lblSystemValue.Text)
            lblReleaseQTY.Visible = True
            lblReleaseQTY.Text = "-: System Calculated Shipped Quantity : " + SystemReleaseQuantity.ToString()
            lblTotalCTN.Text = "-: System Calculated CTNS : " + SystemCTN.ToString()
            lblOk.Visible = False
            UpMsgs.Update()
            lblTotalCTN.Visible = True
            UptxtInvoiceValue.Update()
            cartonn = cartonn + Dtt.Rows(x)("CTNS")
        Next
        txtNetWeight.Text = Gross
        txtNoOfCarton.Text = cartonn
    End Sub
    Protected Sub TXTCommodity_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
        For i As Integer = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(i).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(i).FindControl("LBLCommodityID"), Label)
            Dim DT As DataTable = ObjCargoDetail.GetCommodity(TXTCommodity.Text)
            If DT.Rows.Count > 0 Then
                Errormgs.Text = ""
                Errormgs.Visible = False
                LBLCommodityID.Text = DT.Rows(0)("CommodityID")
            Else
                Errormgs.Visible = True
                If TXTCommodity.Text = "" Then
                Else
                    Errormgs.Text = "Commodity Not Found Please Add"
                End If
                LBLCommodityID.Text = ""
            End If
        Next
    End Sub
    Sub BindPackingNo()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objDPIMst.GetPackingNo(cmbCustomer.SelectedValue)
            cmbPackingNo.DataSource = dtcmbSeason
            cmbPackingNo.DataTextField = "PackingNo"
            cmbPackingNo.DataValueField = "PackingMstId"
            cmbPackingNo.DataBind()
            cmbPackingNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub TXTWeightPCS_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("DTAdd"), DataTable)
        Dim Gross As Decimal = 0
        For i As Integer = 0 To dgArticle.Items.Count - 1
            Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(i).FindControl("TXTWeightPCS"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(i).FindControl("txtReleaseQuantity"), TextBox)
            Gross = Gross + Val(TXTWeightPCS.Text) * Val(txtReleaseQuantity.Text)
        Next
        txtNetWeight.Text = Gross
    End Sub
    Protected Sub Cartons_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("DTAdd"), DataTable)
        Dim CTNS As Decimal = 0
        For i As Integer = 0 To dgArticle.Items.Count - 1
            Dim Cartons As TextBox = CType(dgArticle.Items(i).FindControl("Cartons"), TextBox)
            CTNS = CTNS + Cartons.Text
        Next
        lblTotalCTN.Text = "-: System Calculated CTNS : " + CTNS.ToString()
        lblTotalCTN.Visible = True
        txtNoOfCarton.Text = CTNS
        txtGrossWeight.Text = Math.Round(Val(txtWeightCTN.Text) * Val(txtNoOfCarton.Text), 0) + Val(txtNetWeight.Text)
        UpTXTGrossWeightKGS.Update()
    End Sub
    Protected Sub txtReleaseQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("DTAdd"), DataTable)
        Dim x As Integer
        Dim ReleaseQuantity As TextBox
        Dim ShippedRate As Decimal
        Dim SystemInvoiceValue As Decimal = 0
        Dim SystemReleaseQuantity As Integer = 0
        Dim SystemCTN As Integer = 0
        Dim cartonn As Decimal = 0
        Dim Gross As Decimal = 0
        For x = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            Dim txtHsCode As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            Dim txtReleaseQuantity As TextBox = DirectCast(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim TXTStyle As TextBox = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim Cartons As TextBox = DirectCast(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            Dim txtWhitePCS As TextBox = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            Dim txtWhiteCarton As TextBox = CType(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
            Gross = Math.Round(Gross + Val(TXTWeightPCS.Text) * Val(txtReleaseQuantity.Text), 2)
            lblmsg.Visible = True
            ReleaseQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            ShippedRate = dgArticle.Items(x).Cells(18).Text()
            SystemInvoiceValue = SystemInvoiceValue + (Convert.ToDecimal(ReleaseQuantity.Text) * Convert.ToDecimal(ShippedRate))
            SystemReleaseQuantity = SystemReleaseQuantity + Convert.ToDecimal(ReleaseQuantity.Text)
            SystemCTN = SystemCTN + Val(Cartons.Text)
            lblmsg.Text = "-: System Calculated Invoice Value is :  " + SystemInvoiceValue.ToString()
            lblSystemValue.Text = SystemInvoiceValue.ToString()
            txtInvoiceValue.Text = Val(lblSystemValue.Text)
            lblReleaseQTY.Visible = True
            lblReleaseQTY.Text = "-: System Calculated Shipped Quantity : " + SystemReleaseQuantity.ToString()
            lblTotalCTN.Text = "-: System Calculated CTNS : " + SystemCTN.ToString()
            lblOk.Visible = False
            UpMsgs.Update()
            lblTotalCTN.Visible = True
            UptxtInvoiceValue.Update()
        Next
        txtNetWeight.Text = Gross
        txtNoOfCarton.Text = cartonn
    End Sub
    Protected Sub txtPackingPCS_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer
        For x = 0 To dgArticle.Items.Count - 1
            Dim txtPackingPCS As TextBox = CType(dgArticle.Items(x).FindControl("txtPackingPCS"), TextBox)
            Dim txtReleaseQuantity As TextBox = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim Cartons As TextBox = CType(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            If txtPackingPCS.Text = 0 Then
                Cartons.Text = 0
            Else
                Cartons.Text = Math.Round(Val(txtReleaseQuantity.Text) / Val(txtPackingPCS.Text), 2)
            End If
        Next
    End Sub
End Class
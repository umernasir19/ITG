Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class PurchaseOrderPreviewPopup
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim lPOID As Long
    Dim dtPurchaseOrder As New DataTable
    Dim Dr As DataRow
    Dim Dt As New DataTable
    Dim objCurrency As New Currency
    Dim objSupplyChainRadWindow As New SupplyChainRadWindow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            Session("IPOID") = Nothing
            SetValuesEditMod()
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMasterView(lPOID)
            lblPONO.Text = Dt.Rows(0)("PONO")
            lblMerchant.Text = Dt.Rows(0)("Username")
            lblMerchantDesignation.Text = Dt.Rows(0)("Designation")
            lblECPDivision.Text = Dt.Rows(0)("ECPDivistion")
            lnkMerchantViewProfile.ID = Dt.Rows(0)("UserId")
            lblOrderType.Text = Dt.Rows(0)("POTYPE") + "(" + Dt.Rows(0)("PORefNo") + ")"
            lblPlacementDate.Text = Dt.Rows(0)("PlacementDatee")
            lblDeliveryDate.Text = Dt.Rows(0)("ShipmentDatee")
            lblShipmentDate.Text = Dt.Rows(0)("ShipmentDatee")
            lblTolerance.Text = "+/-" + Dt.Rows(0)("Toleranceindays") + "%"
            lblLeadTimeMargin.Text = Dt.Rows(0)("TimeSpame").ToString() + "Days"
            lblProductPortfolio.Text = Dt.Rows(0)("ProductGroup")
            lblProductCategories.Text = Dt.Rows(0)("ProductCategories")
            lblSeason.Text = Dt.Rows(0)("Season")
            lblDeliveryMode.Text = Dt.Rows(0)("ShipmentModeName")
            lblPreferredPaymentTerms.Text = Dt.Rows(0)("PaymentTypeName")
            lblTransactionshouldbein.Text = Dt.Rows(0)("Currency")
            lblDestination.Text = Dt.Rows(0)("Destination")
            lnkCustomerViewProfile.ID = Dt.Rows(0)("CustomerID")
            lnkSupplierViewProfile.ID = Dt.Rows(0)("SupplierID")
            lblEknumber.Text = Dt.Rows(0)("Eknumber") + "(Buying Department No.)"
            lblCustomer.Text = Dt.Rows(0)("CustomerName")
            If String.IsNullOrEmpty(Dt.Rows(0)("ShortName").ToString()) = False Then
                lblShortname.Text = Dt.Rows(0)("ShortName")
            Else
                lblShortname.Text = ""
            End If
            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(Dt.Rows(0)("SupplierID"), Dt.Rows(0)("CustomerID"))
            If dtCheck.Rows.Count > 0 Then
                lblLKZNo.Text = dtCheck.Rows(0)("LKZNumber") + "(LKZ No)"
                lblLKZNo.ToolTip = "This is LKZ number" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + lblSupplier.Text + " To " + lblCustomer.Text
            Else
                lblLKZNo.Text = ""
                lblLKZNo.ToolTip = ""
                lblLKZNo.Visible = True
            End If
            Dim dtSupplierContactPerson As New DataTable
            dtSupplierContactPerson = objSupplierLKZ.CheckContactPerson(Dt.Rows(0)("SupplierID"))
            If dtSupplierContactPerson.Rows.Count > 0 Then
                lblSupplier.Text = "Mr. " + dtSupplierContactPerson.Rows(0)("PersonName")
                lblSupplierDesignation.Text = dtSupplierContactPerson.Rows(0)("Designation")
            Else
                lblSupplier.Text = ""
                lblSupplierDesignation.Text = ""
            End If
            'End LKZ
            '-------------------- Detail Values
            dtPurchaseOrder = Nothing
            Session("dtPurchaseOrder") = Nothing
            dtPurchaseOrder = New DataTable
            With dtPurchaseOrder
                .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("ArticleDescription", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("StyleDetailID", GetType(Long))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtPurchaseOrder.NewRow()
                Dr("PurchaseOrderDetailID") = Dt.Rows(x)("PODetailID")
                Dr("Quantity") = Dt.Rows(x)("Quantity")
                Dr("Rate") = Dt.Rows(x)("Rate")
                Dr("Amount") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                Dr("StyleID") = Dt.Rows(x)("StyleID")
                Dr("Remarks") = Dt.Rows(x)("Remarks")
                Dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
                '-------------
                If String.IsNullOrEmpty(Dt.Rows(x)("Article").ToString()) = False Then
                    Dr("Article") = Dt.Rows(x)("Article")
                Else
                    Dr("Article") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("SizeRange").ToString()) = False Then
                    Dr("Size") = Dt.Rows(x)("SizeRange")
                Else
                    Dr("Size") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("Colorway").ToString()) = False Then
                    Dr("Color") = Dt.Rows(x)("Colorway")
                Else
                    Dr("Color") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("Rate").ToString()) = False Then
                    Dr("Rate") = Dt.Rows(x)("Rate")
                Else
                    Dr("Rate") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("StyleNo").ToString()) = False Then
                    Dr("Style") = Dt.Rows(x)("StyleNo")
                Else
                    Dr("Style") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("ArticleDescription").ToString()) = False Then
                    Dr("ArticleDescription") = Dt.Rows(x)("ArticleDescription")
                Else
                    Dr("ArticleDescription") = ""
                End If
                dtPurchaseOrder.Rows.Add(Dr)
            Next
            Session("dtPurchaseOrder") = dtPurchaseOrder
            BindGrid()
            Dim TAmount As Decimal = 0
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                TotalQty = Math.Round(TotalQty + CDec(Val(dtPurchaseOrder.Rows(x)("Quantity"))), 0)
                TAmount = Math.Round(TAmount + CDec(Val(dtPurchaseOrder.Rows(x)("Amount"))), 2)
                lblTotalAmount.Text = TAmount
                lblTotalQty.Text = TotalQty
            Next
            If Dt.Rows(0)("Currency") = "Dollar" Then
                lblTotalAmount.Text = "$ " + lblTotalAmount.Text
            ElseIf Dt.Rows(0)("Currency") = "Euro" Then
                lblTotalAmount.Text = "€ " + lblTotalAmount.Text
            Else
                lblTotalAmount.Text = lblTotalAmount.Text + " " + Dt.Rows(0)("Currency")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtPurchaseOrder Is Nothing) Then
            If (dtPurchaseOrder.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtPurchaseOrder
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True
                TryCast(dgPurchaseOrder.MasterTableView.GetColumn("PurchaseOrderDetailID"), GridBoundColumn).Display = False
                TryCast(dgPurchaseOrder.MasterTableView.GetColumn("StyleID"), GridBoundColumn).Display = False
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub lnkCustomerViewProfile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkCustomerViewProfile.Click
        Dim script As String = "function f(){$find(""" + rwBuyerInfo.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Sub GetDataForCustomerProfile()
        Dim dtCustomerInfo As New DataTable
        dtCustomerInfo = objSupplyChainRadWindow.GetCustomerInfoForRW(lPOID)
        lblNames.Text = dtCustomerInfo.Rows(0)("CustomerName")
        lblCountries.Text = dtCustomerInfo.Rows(0)("Country")
        lblGeogterr.Text = dtCustomerInfo.Rows(0)("Territory")
        lblPGroup.Text = dtCustomerInfo.Rows(0)("Parent")
    End Sub
    Sub GetDataForSupplierProfile()
        Dim dtSupplierInfo As New DataTable
        dtSupplierInfo = objSupplyChainRadWindow.GetSupplierInfoForRW(lPOID)
        lblSName.Text = dtSupplierInfo.Rows(0)("VenderName")
        lblSCountries.Text = dtSupplierInfo.Rows(0)("CountryName")
        lblPhone.Text = dtSupplierInfo.Rows(0)("PhoneNumber")
        lblAddress.Text = dtSupplierInfo.Rows(0)("Address1")
    End Sub
    Sub GetDataForMerchantProfile()
        Dim dtMerchantInfo As New DataTable
        dtMerchantInfo = objSupplyChainRadWindow.GetMerchantInfoForRW(lPOID)
        lblMerName.Text = dtMerchantInfo.Rows(0)("UserName")
        lblMDesignation.Text = dtMerchantInfo.Rows(0)("Designation")
        lblECPDiv.Text = dtMerchantInfo.Rows(0)("ECPDivistion")
    End Sub
    Sub GetDataForCertificate()
        Dim dtCertificateInfo As New DataTable
        dtCertificateInfo = objSupplyChainRadWindow.GetCertificateInfoForRW(lPOID)
        dgCertificates.DataSource = dtCertificateInfo
        dgCertificates.DataBind()
    End Sub
    Protected Sub rwBuyerInfo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles rwBuyerInfo.Load
        GetDataForCustomerProfile()
    End Sub
    Protected Sub rwSupplierInfo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles rwSupplierInfo.Load
        GetDataForSupplierProfile()
    End Sub
    Protected Sub lnkSupplierViewProfile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkSupplierViewProfile.Click
        Dim script As String = "function f(){$find(""" + rwSupplierInfo.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Protected Sub lnkMerchantViewProfile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkMerchantViewProfile.Click
        Dim script As String = "function f(){$find(""" + rwMerchantInfo.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub
    Protected Sub rwMerchantInfo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles rwMerchantInfo.Load
        GetDataForMerchantProfile()
    End Sub
    Protected Sub rwCertificateInfo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles rwCertificateInfo.Load
        GetDataForCertificate()
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        Dim script As String = "function f(){$find(""" + rwCertificateInfo.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub

End Class
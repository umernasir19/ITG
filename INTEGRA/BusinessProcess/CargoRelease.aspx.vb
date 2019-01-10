Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class CargoRelease
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    ' Dim ObjVendor As New Vendor
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtArticle As New DataTable
    Dim dtPurchaseOrder As New DataTable
    Dim lPOID As Long
    Dim Dr As DataRow
    Dim ICargoID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("POID")
        ICargoID = Request.QueryString("IcargoID")
        If Not Page.IsPostBack Then
            PageHeader("Shipment Release")

            If lPOID > 0 Then
                lPOID = lPOID
            Else
                lPOID = 0
            End If
            'New 
            If ICargoID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            'End
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SetValues()

        With ObjCargo
            .CreationDate = Date.Now
            .InvoiceNo = txtInvoiceNo.Text
            .InvoiceDate = txtInvoiceDate.SelectedDate
            .InvoiceValue = txtInvoiceValue.Text
            .Terms = txtTerm.Text
            .ItemDescription = txtItemDesc.Text
            .Mode = txtMode.Text
            .CarrierName = txtCarrierName.Text
            .VoyageFlight = txtVoyageFlight.Text
            .BillNo = txtBillNo.Text
            .ShipmentDate = txtCargoDate.SelectedDate
            .ContainerNo = txtContainer.Text
            .Remarks = txtRemarks.Text
            .IsActive = False
            .ETD = txtETD.SelectedDate
            .ETA = txtETA.SelectedDate
            .Forwarder = txtForwarder.Text
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
                .ShippedExchangeRate = txtShippedExchangeRate.Text
            End If
            .SaveCargo()
        End With
    End Sub
    Sub ClearControls()
        txtTerm.Text = ""
        txtInvoiceNo.Text = ""
        txtInvoiceDate.SelectedDate = ""
        txtMode.Text = ""
        txtCargoDate.SelectedDate = ""
        txtBillNo.Text = ""
        txtRemarks.Text = ""
    End Sub
    Sub SetDetailValues()
        Dim CargoID As Long = ObjCargo.GetId
        Dim dt As New DataTable
        dt = Session("dtArticle")
        Dim x As Integer
        With ObjCargoDetail
            For x = 0 To dt.Rows.Count - 1
                .CargoID = ObjCargo.GetId
                .POID = dt.Rows(x)("POID")
                .Quantity = dt.Rows(x)("ReleaseQuantity")
                .Styles = dt.Rows(x)("StyleNo")
                .Cartons = dt.Rows(x)("Cartons")
                .CustomerID = dt.Rows(x)("CustomerID")
                .SupplierID = dt.Rows(x)("VendorID")
                .POPOID = dt.Rows(x)("POPOID")
                .ShippedRate = dt.Rows(x)("ShippedRate")
                .SaveCargoDetail()
            Next
        End With
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Save" Then
                'first Check Curre4ncy and SystemInvoice value both same then save
                If Convert.ToDecimal(lblSystemValue.Text) = Convert.ToDecimal(txtInvoiceValue.Text) Then
                    'Check Invoice No Duplicate
                    Dim DtInvoice As New DataTable
                    DtInvoice = ObjCargo.GetCargoinfoSearch(txtInvoiceNo.Text)
                    If DtInvoice.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Invoice Already Exist.")

                    Else
                        '------------- Master
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        SetValues()
                        '---------Detail
                        SetDetailValues()
                        'Save Po status as Shipped
                        SavePOStatus()

                        Session("dtArticle") = Nothing
                        Session("dtSelection") = Nothing
                        Response.Redirect("CargoReleaseView.aspx")
                    End If
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Your System Invoice Value didn't match with your Enter Value.")
                End If
            ElseIf btnSave.Text = "Update" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                '------------- Master
                SetValuesEdited()
                'Now Befor Save Detail First Delete Pervious Detail
                'Delete CargoDetail
                ObjCargoDetail.DeleteCargoDetailbyID(ICargoID)
                '---------Detail
                SetDetailValuesEdited()
                'Save Po status as Shipped
                SavePOStatus()

                Session("dtArticle") = Nothing
                Session("dtSelection") = Nothing
                Response.Redirect("CargoReleaseView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SavePOStatus()
        Try
            Dim x As Integer
            For x = 0 To dgCargo.Items.Count - 1
                'Get POPOID from grid
                Dim POID As String = Convert.ToDecimal(dgCargo.Items(x).Cells(17).Text())
                ObjPO.UpdatePOStatus(POID)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValuesEdited()
        With ObjCargo
            .CargoID = ICargoID
            .CreationDate = Date.Now
            .InvoiceNo = txtInvoiceNo.Text
            .InvoiceDate = txtInvoiceDate.SelectedDate
            .InvoiceValue = txtInvoiceValue.Text
            .Terms = txtTerm.Text
            .ItemDescription = txtItemDesc.Text
            .Mode = txtMode.Text
            .CarrierName = txtCarrierName.Text
            .VoyageFlight = txtVoyageFlight.Text
            .BillNo = txtBillNo.Text
            .ShipmentDate = txtCargoDate.SelectedDate
            .ContainerNo = txtContainer.Text
            .Remarks = txtRemarks.Text
            .IsActive = False
            .ETD = txtETD.SelectedDate
            .ETA = txtETA.SelectedDate
            .Forwarder = txtForwarder.Text
            .Currency = cmbCurrency.SelectedItem.Text
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
                .ShippedExchangeRate = txtShippedExchangeRate.Text
            End If

            .SaveCargo()
        End With
    End Sub
    Sub SetDetailValuesEdited()
        ' Dim CargoID As Long = ObjCargo.GetId
        Dim dt As New DataTable
        dt = Session("dtArticle")
        Dim x As Integer
        With ObjCargoDetail
            For x = 0 To dt.Rows.Count - 1
                .CargoID = ICargoID
                .POID = dt.Rows(x)("POID")
                .Quantity = dt.Rows(x)("ReleaseQuantity")
                .Styles = dt.Rows(x)("StyleNo")
                .Cartons = dt.Rows(x)("Cartons")
                .CustomerID = dt.Rows(x)("CustomerID")
                .SupplierID = dt.Rows(x)("VendorID")
                .POPOID = dt.Rows(x)("POPOID")
                .ShippedRate = dt.Rows(x)("ShippedRate")
                .SaveCargoDetail()
            Next
        End With
    End Sub
    Protected Sub GetArticle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GetArticle.Click
        Try
            Response.Write("<script> window.open('ArticlePopUp.aspx?', 'newwindow', 'left=100, top=180, height=500, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnArticleNoNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArticleNoNew.Click
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindGridNew()
        Try
            If (Not dtArticle Is Nothing) Then
                If (dtArticle.Rows.Count > 0) Then
                    dgCargo.DataSource = dtArticle
                    dgCargo.DataBind()
                    dgCargo.Visible = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgCargo_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgCargo.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                dtArticle = CType(Session("dtArticle"), DataTable)
                If (Not dtArticle Is Nothing) Then
                    If (dtArticle.Rows.Count > 0) Then
                        Dim lCustomerDetailID As Integer = dtArticle.Rows(e.Item.ItemIndex)("POID")
                        dtArticle.Rows.RemoveAt(e.Item.ItemIndex)
                        BindGridNew()
                        If dtArticle.Rows.Count = 0 Then
                            dgCargo.Visible = False
                        End If
                    End If
                Else
                    dgCargo.Visible = False
                End If
        End Select
    End Sub
    Sub FillGrid()
        If (Not CType(Session("dtArticle"), DataTable) Is Nothing) Then
            dtArticle = Session("dtArticle")
        Else
            dtArticle = New DataTable
            With dtArticle
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("Quantity", GetType(Decimal))
                .Columns.Add("ShippedQty", GetType(Decimal))
                .Columns.Add("ReleaseQuantity", GetType(Decimal))
                .Columns.Add("Cartons", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("CustomerID", GetType(Long))
                .Columns.Add("VendorID", GetType(Long))
                .Columns.Add("POPOID", GetType(Long))
                .Columns.Add("ShippedRate", GetType(String))
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("SupplierName", GetType(String))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Colorway", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
            End With
        End If
        Dim x As Integer = 0
        dtPurchaseOrder = Session("dtSelection")
        If Not dtPurchaseOrder Is Nothing Then
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                Dr = dtArticle.NewRow()
                Dr("POID") = dtPurchaseOrder.Rows(x)("POID")
                Dr("StyleID") = dtPurchaseOrder.Rows(x)("StyleID")
                Dr("StyleNo") = dtPurchaseOrder.Rows(x)("StyleNo")
                Dr("Quantity") = dtPurchaseOrder.Rows(x)("Quantity")
                Dr("ShippedQty") = dtPurchaseOrder.Rows(x)("ShippedQty")
                Dr("ReleaseQuantity") = dtPurchaseOrder.Rows(x)("ReleaseQuantity")
                Dr("Cartons") = dtPurchaseOrder.Rows(x)("Cartons")
                Dr("PONO") = dtPurchaseOrder.Rows(x)("PONO")
                Dr("CustomerID") = dtPurchaseOrder.Rows(x)("CustomerID")
                Dr("VendorID") = dtPurchaseOrder.Rows(x)("VendorID")
                Dr("POPOID") = dtPurchaseOrder.Rows(x)("POPOID")
                Dr("ShippedRate") = dtPurchaseOrder.Rows(x)("ShippedRate")
                Dr("Currency") = dtPurchaseOrder.Rows(x)("Currency")
                Dr("CustomerName") = dtPurchaseOrder.Rows(x)("CustomerName")
                Dr("SupplierName") = dtPurchaseOrder.Rows(x)("SupplierName")
                Dr("Article") = dtPurchaseOrder.Rows(x)("Article")
                Dr("Colorway") = dtPurchaseOrder.Rows(x)("Colorway")
                Dr("SizeRange") = dtPurchaseOrder.Rows(x)("SizeRange")
                dtArticle.Rows.Add(Dr)
            Next
        End If
        Session("dtArticle") = dtArticle
        BindGridNew()
    End Sub
    Sub SetValuesEditMod()
        Try
            Dim Dt As DataTable
            Dim x As Integer
            Dt = ObjCargo.GetCargoInfoAll(ICargoID)
            'Master Cargo Information
            If Dt.Rows.Count = Nothing Then
            Else
                txtInvoiceNo.Text = Dt.Rows(0)("InvoiceNo")
                txtInvoiceDate.SelectedDate = Dt.Rows(0)("InvoiceDate")
                txtInvoiceValue.Text = Dt.Rows(0)("InvoiceValue")
                txtTerm.Text = Dt.Rows(0)("Terms")
                txtItemDesc.Text = Dt.Rows(0)("ItemDescription")
                txtMode.Text = Dt.Rows(0)("Mode")
                txtCarrierName.Text = Dt.Rows(0)("CarrierName")
                txtVoyageFlight.Text = Dt.Rows(0)("VoyageFlight")
                txtBillNo.Text = Dt.Rows(0)("BillNo")
                txtCargoDate.SelectedDate = Dt.Rows(0)("ShipmentDate")
                txtContainer.Text = Dt.Rows(0)("ContainerNo")
                txtRemarks.Text = Dt.Rows(0)("Remarks")
                txtETD.SelectedDate = Dt.Rows(0)("ETD")
                txtETA.SelectedDate = Dt.Rows(0)("ETA")
                txtForwarder.Text = Dt.Rows(0)("Forwarder")
                cmbCurrency.SelectedValue = Dt.Rows(0)("Currency")
                txtCBM.Text = Dt.Rows(0)("CBM")
                cmbConsolidation.SelectedValue = Dt.Rows(0)("Consolidation")
                cmbContainerSize.SelectedValue = Dt.Rows(0)("ContainerSize")
                txtShippingLine.Text = Dt.Rows(0)("ShippingLine")
                txtShippedExchangeRate.Text = Dt.Rows(0)("ShippedExchangeRate")
                'End
                'CargoDetail
                dtArticle = Nothing
                Session("dtArticle") = Nothing
                dtArticle = New DataTable
                With dtArticle
                    .Columns.Add("POID", GetType(Long))
                    .Columns.Add("StyleID", GetType(Long))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("Quantity", GetType(Decimal))
                    .Columns.Add("ShippedQty", GetType(Decimal))
                    .Columns.Add("ReleaseQuantity", GetType(Decimal))
                    .Columns.Add("Cartons", GetType(String))
                    .Columns.Add("PONO", GetType(String))
                    .Columns.Add("CustomerID", GetType(Long))
                    .Columns.Add("VendorID", GetType(Long))
                    .Columns.Add("POPOID", GetType(Long))
                    .Columns.Add("ShippedRate", GetType(String))
                    .Columns.Add("Currency", GetType(String))
                    .Columns.Add("CustomerName", GetType(String))
                    .Columns.Add("SupplierName", GetType(String))
                    .Columns.Add("Article", GetType(String))
                    .Columns.Add("Colorway", GetType(String))
                    .Columns.Add("SizeRange", GetType(String))
                End With
                For x = 0 To Dt.Rows.Count - 1
                    Dr = dtArticle.NewRow()
                    Dr("POID") = Dt.Rows(x)("POID")
                    Dr("StyleID") = 0
                    Dr("StyleNo") = Dt.Rows(x)("Styles")
                    Dr("Quantity") = Dt.Rows(x)("POQTY")
                    Dr("ShippedQty") = Dt.Rows(x)("Quantity")
                    Dr("ReleaseQuantity") = Dt.Rows(x)("Quantity")
                    Dr("Cartons") = Dt.Rows(x)("Cartons")
                    Dr("PONO") = Dt.Rows(x)("PONO")
                    Dr("CustomerID") = Dt.Rows(x)("CustomerID")
                    Dr("VendorID") = Dt.Rows(x)("VendorID")
                    Dr("POPOID") = Dt.Rows(x)("POPOID")
                    Dr("ShippedRate") = Dt.Rows(x)("ShippedRate")
                    Dr("Currency") = Dt.Rows(x)("poCurrency")
                    Dr("CustomerName") = Dt.Rows(x)("CustomerName")
                    Dr("SupplierName") = Dt.Rows(x)("SupplierName")
                    Dr("Article") = Dt.Rows(x)("Article")
                    Dr("Colorway") = Dt.Rows(x)("Colorway")
                    Dr("SizeRange") = Dt.Rows(x)("SizeRange")
                    dtArticle.Rows.Add(Dr)
                Next
                Session("dtArticle") = dtArticle
                BindGridNew()
            End If
            'End
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Session("dtArticle") = Nothing
        Session("dtSelection") = Nothing
        Response.Redirect("CargoReleaseView.aspx")
    End Sub
    Protected Sub btnAutoCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAutoCalculate.Click
        Try
            'Calculate system Invoice value. multiple quantity with shipped rate
            Dim x As Integer
            Dim ReleaseQuantity As TextBox
            Dim ShippedRate As Decimal
            Dim SystemInvoiceValue As Decimal = 0
            Dim SystemReleaseQuantity As Integer = 0
            For x = 0 To dgCargo.Items.Count - 1
                ReleaseQuantity = CType(dgCargo.Items(x).FindControl("txtReleaseQuantity"), TextBox)
                ShippedRate = dgCargo.Items(x).Cells(15).Text()
                SystemInvoiceValue = SystemInvoiceValue + (Convert.ToDecimal(ReleaseQuantity.Text) * Convert.ToDecimal(ShippedRate))
                SystemReleaseQuantity = SystemReleaseQuantity + Convert.ToDecimal(ReleaseQuantity.Text)
            Next

            lblmsg.Visible = True
            lblmsg.Text = "-: System Calculated Invoice Value is :  " + SystemInvoiceValue.ToString()
            lblSystemValue.Text = SystemInvoiceValue.ToString()
            lblReleaseQTY.Visible = True
            lblReleaseQTY.Text = "-: System Calculated Shipped Quantity : " + SystemReleaseQuantity.ToString()

        Catch ex As Exception
        End Try
    End Sub
End Class
Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class FPlanEntryNew2
    Inherits System.Web.UI.Page

    Dim ObjFabricCostMst As New FPlanMstNew
    Dim ObjFabricCostDtl As New FPlanDtlNew

    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim FPlanDt As DataTable
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then


            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
            FillMasterdate()
            BindFabric()
            bindCurrency()
            bindSupplier()
            bindSUnit()
            FPlanDt = ObjFabricCostMst.GetFPLANdetailNew(JobOrderID)

            If FPlanDt.Rows.Count > 0 Then
                Session("dtDetail") = FPlanDt
                lblFabricCostMstid.Text = FPlanDt.Rows(0)("FPlanMstNewID")
                lblcreationDate.Text = FPlanDt.Rows(0)("CreationDate")
                BindGrid()
                btnSave.Visible = True
            End If

            ' BindFibricCode()


        End If

    End Sub
    Sub FillMasterdate()
        Try


            jOBdT = ObjFabricCostMst.GetJobOrderData(JobOrderID)

            txtJobOrder.Text = jOBdT.Rows(0)("SRNo")

            txtBuyer.Text = jOBdT.Rows(0)("CustomerName")

            txtQty.Text = jOBdT.Rows(0)("Qty")
            txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
            cmbColor.DataSource = jOBdT
            cmbColor.DataValueField = "JobOrderDetailId"
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, New ListItem("SELECT", "0"))
        Catch ex As Exception

        End Try

    End Sub
    Sub BindFabric()
        Dim Dt As DataTable
        Dt = ObjFabricCostMst.GetFabricnEW()

        cmbFabric.DataSource = Dt
        cmbFabric.DataTextField = "ItemName"
        cmbFabric.DataValueField = "IMSItemId" '    "ProductDatabaseID"
        cmbFabric.DataBind()
        cmbFabric.DataSource = Dt
        cmbFabric.Items.Insert(0, New ListItem("Select..", "0"))

    End Sub
    Sub bindCurrency()
        Dim Dt As DataTable
        Dt = ObjFabricCostMst.GetCurrency()

        cmbCurrencys.DataSource = Dt
        cmbCurrencys.DataTextField = "CurrencyName"
        cmbCurrencys.DataValueField = "CurrencyID" '    "ProductDatabaseID"
        cmbCurrencys.DataBind()
        cmbCurrencys.DataSource = Dt


    End Sub
    Sub bindSupplier()
        Dim Dt As DataTable
        Dt = ObjFabricCostMst.GetFSupplier()

        cmbsupplier.DataSource = Dt
        cmbsupplier.DataTextField = "SupplierName"
        cmbsupplier.DataValueField = "SupplierDatabaseID" '    "ProductDatabaseID"
        cmbsupplier.DataBind()
        cmbsupplier.DataSource = Dt
        cmbsupplier.Items.Insert(0, New ListItem("Select..", "0"))

    End Sub
    Sub bindSUnit()
        Dim Dt As DataTable
        Dt = ObjFabricCostMst.GetUnit()

        cmbUnit.DataSource = Dt
        cmbUnit.DataTextField = "Symbol"
        cmbUnit.DataValueField = "ItemUnitID" '    "ProductDatabaseID"
        cmbUnit.DataBind()
        cmbUnit.DataSource = Dt
        cmbUnit.Items.Insert(0, New ListItem("", "0"))

        cmbUnit2.DataSource = Dt
        cmbUnit2.DataTextField = "Symbol"
        cmbUnit2.DataValueField = "ItemUnitID" '    "ProductDatabaseID"
        cmbUnit2.DataBind()
        cmbUnit2.DataSource = Dt
        cmbUnit2.Items.Insert(0, New ListItem("", "0"))

    End Sub

    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabric.SelectedIndexChanged
        Try

            Dim Dt As DataTable
            Dt = ObjFabricCostMst.GetFabricDataNew(cmbFabric.SelectedValue)
            If Dt.Rows.Count > 0 Then
                txtWidth.Text = Dt.Rows(0)("FabricWidth")
                txtxFabricCons.Text = "" 'Dt.Rows(0)("Construction")
                txtComposition.Text = Dt.Rows(0)("CompositionName")
                cmbUnit.SelectedValue = Dt.Rows(0)("ItemUnitId")
                cmbUnit2.SelectedValue = Dt.Rows(0)("ItemUnitId")
                cmbsupplier.SelectedValue = Dt.Rows(0)("SupplierID")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub
       
    Protected Sub txtxconsumption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtxconsumption.TextChanged
        Try
            lblFabricReq.Text = Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text)
            If txtExtra.Text = "" Then
                txtExtra.Text = 0
            End If
            lblgross.Text = Math.Round(Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text) + (Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text) * Val(txtExtra.Text) / 100), 0)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtFabricCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFabricCost.TextChanged
        Try
            If txtExtra.Text = "" Then

            Else
                lblAmount.Text = Val(txtFabricCost.Text) * Val(lblgross.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtExtra_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtra.TextChanged
        Try
            If txtxconsumption.Text = "" Then
            Else
                lblFabricReq.Text = Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text)

                lblgross.Text = Math.Round(Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text) + (Val(txtxconsumption.Text) * Val(txtQtyPerPiece.Text) * Val(txtExtra.Text) / 100), 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtExchangeRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExchangeRate.TextChanged
        Try
            If txtFabricCost.Text = "" Then

            Else
                lblusd.Text = Math.Round(Val(txtFabricCost.Text) * Val(lblgross.Text) / Val(txtExchangeRate.Text), 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            If txtfabric.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fabric Empty")
            ElseIf cmbFabrictype.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Placement")
            ElseIf txtxconsumption.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Consumption Empty")
            ElseIf txtxconsumption.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Consumption Empty")
            ElseIf txtFabricCost.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fabric Cost Empty")
            ElseIf txtExchangeRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Exchange Rate Empty")
            ElseIf cmbsupplier.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Source")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveSession()
                clear()
                btnSave.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("FPlanDtlNewID", GetType(Long))
                .Columns.Add("FabricdataBaseId", GetType(Long))
                .Columns.Add("FabricWeave", GetType(String))
                .Columns.Add("FabricTypeId", GetType(Long))
                .Columns.Add("FabricType", GetType(String))
                .Columns.Add("Construction", GetType(String))
                .Columns.Add("Width", GetType(String))
                .Columns.Add("Composition", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("FabricReq", GetType(String))
                .Columns.Add("Extra", GetType(String))
                .Columns.Add("Gross", GetType(String))
                .Columns.Add("IMSSupplierId", GetType(String))
                .Columns.Add("IMSSupplierName", GetType(String))
                .Columns.Add("FabricCost", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("ExchangeRate", GetType(String))
                .Columns.Add("USD", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("QtyColorWise", GetType(Decimal))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("JobOrderDetailId", GetType(Long))
                .Columns.Add("CurrencyId", GetType(String))
                .Columns.Add("Currency", GetType(String))
            End With
        End If



        dr = dtDetail.NewRow()
        dr("FPlanDtlNewID") = 0
        dr("FabricdataBaseId") = lblFabricItemId.Text ' cmbFabric.SelectedValue
        dr("FabricWeave") = txtfabric.Text ' cmbFabric.SelectedItem.Text
        dr("FabricTypeId") = cmbFabrictype.SelectedValue
        dr("FabricType") = cmbFabrictype.SelectedItem.Text
        dr("Construction") = txtxFabricCons.Text
        dr("Width") = txtWidth.Text
        dr("Composition") = txtComposition.Text
        dr("Consumption") = txtxconsumption.Text
        dr("FabricReq") = lblFabricReq.Text
        dr("Extra") = txtExtra.Text
        dr("Gross") = lblgross.Text
        dr("IMSSupplierId") = cmbsupplier.SelectedValue
        dr("IMSSupplierName") = cmbsupplier.SelectedItem.Text
        dr("FabricCost") = txtFabricCost.Text
        dr("Amount") = lblAmount.Text
        dr("ExchangeRate") = txtExchangeRate.Text
        dr("USD") = lblusd.Text
        dr("Item") = txtItem.Text
        dr("Style") = txtstyle.Text
        dr("QtyColorWise") = txtQtyPerPiece.Text
        dr("Color") = cmbColor.SelectedItem.Text
        dr("JobOrderDetailId") = cmbColor.SelectedValue
        dr("CurrencyId") = cmbCurrencys.SelectedValue
        dr("Currency") = cmbCurrencys.SelectedItem.Text
        dtDetail.Rows.Add(dr)
        Session("dtDetail") = dtDetail
        BindGrid()

    End Sub
    Sub clear()
        'txtTotalFabric.Text = ""
        cmbFabric.SelectedValue = 0
        cmbFabrictype.SelectedValue = 0
        txtxFabricCons.Text = ""
        txtWidth.Text = ""
        txtComposition.Text = ""
        txtxconsumption.Text = ""
        lblFabricReq.Text = "0.00"
        txtExtra.Text = ""
        lblgross.Text = "0.00"
        cmbsupplier.SelectedValue = 0
        txtFabricCost.Text = ""
        lblAmount.Text = "0.00"
        txtExchangeRate.Text = ""
        lblusd.Text = "0.00"
        lblFabricItemId.Text = 0
        txtfabric.Text = ""
    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgFabricCost.RecordCount = objDataview.Count
        dgFabricCost.DataSource = objDataview
        dgFabricCost.DataBind()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            save()
            'Response.Redirect("Marchandising.aspx")
            'Response.Redirect("JobOrderDatabaseView.aspx")
            Response.Redirect("Fabric.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Sub save()
        With ObjFabricCostMst
            If lblFabricCostMstid.Text = " " Then
                .FPlanMstNewID = 0
            Else
                .FPlanMstNewID = lblFabricCostMstid.Text
            End If

            .JobOrderId = JobOrderID
            .JobOrderNo = txtJobOrder.Text
            .Item = "N/A"
            .Style = "N/A"
            .Quantity = txtQty.Text
            .TotalFabric = 0
            .TGross = 0
            .TotalAmount = 0
            .USDAmount = 0
            .InquiryId = 0
            If lblcreationDate.Text = "" Then
                .CreationDate = Date.Today
            Else
                .CreationDate = lblcreationDate.Text
            End If

            .SaveFPlanMst()
        End With
        Dim x As Integer
        For x = 0 To dgFabricCost.Items.Count - 1
            With ObjFabricCostDtl
                .FPlanDtlNewID = dgFabricCost.Items(x).Cells(0).Text
                If lblFabricCostMstid.Text = " " Then
                    .FPlanMstNewID = ObjFabricCostMst.GetID
                Else
                    .FPlanMstNewID = lblFabricCostMstid.Text
                End If
                .FabricdataBaseId = dgFabricCost.Items(x).Cells(1).Text
                .FabricTypeId = dgFabricCost.Items(x).Cells(3).Text
                .FabricType = dgFabricCost.Items(x).Cells(4).Text
                .Consumption = dgFabricCost.Items(x).Cells(8).Text
                .FabricReq = dgFabricCost.Items(x).Cells(9).Text
                .Extra = dgFabricCost.Items(x).Cells(10).Text
                .Gross = dgFabricCost.Items(x).Cells(11).Text
                .IMSSupplierId = dgFabricCost.Items(x).Cells(12).Text
                .FabricCost = dgFabricCost.Items(x).Cells(14).Text
                .Amount = dgFabricCost.Items(x).Cells(15).Text
                .ExchangeRate = dgFabricCost.Items(x).Cells(16).Text
                .CurrencyId = dgFabricCost.Items(x).Cells(17).Text
                .Currency = dgFabricCost.Items(x).Cells(18).Text
                .USD = dgFabricCost.Items(x).Cells(19).Text
                .Item = dgFabricCost.Items(x).Cells(21).Text
                .Style = dgFabricCost.Items(x).Cells(22).Text
                .QtyColorWise = dgFabricCost.Items(x).Cells(23).Text
                .Color = dgFabricCost.Items(x).Cells(20).Text
                .JobOrderDetailId = dgFabricCost.Items(x).Cells(24).Text
                .FabricWidth = dgFabricCost.Items(x).Cells(6).Text
                .SaveFPlanDtl()
            End With

        Next

    End Sub
    Protected Sub LinkFabricPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkFabricPopup.Click
        Try
            Response.Write("<script> window.open('FabricDataBasePopup.aspx', 'newwindow', 'left=150, top=250, height=400, width=950, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            BindFabric()
        Catch ex As Exception

        End Try
    End Sub


    Sub BindPlacement()
        Dim Dt As DataTable
        Dt = ObjFabricCostMst.GetPlacement(lblrndid.Text)

        cmbFabrictype.DataSource = Dt
        cmbFabrictype.DataTextField = "Description"
        cmbFabrictype.DataValueField = "DPRNDStyleDetailid" '    "ProductDatabaseID"
        cmbFabrictype.DataBind()
        cmbFabrictype.DataSource = Dt
        cmbFabrictype.Items.Insert(0, New ListItem("Select..", "0"))

    End Sub
    Protected Sub cmbColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            BindDetails()
            BindPlacement()
        Catch ex As Exception

        End Try

    End Sub
    Sub BindDetails()
        Try
            If cmbColor.SelectedValue > 0 Then
                Dim Colordt As DataTable = ObjFabricCostMst.GetColorWiseData(cmbColor.SelectedValue)
                If Colordt.Rows.Count > 0 Then
                    txtstyle.Text = Colordt.Rows(0)("style")
                    txtItem.Text = Colordt.Rows(0)("ItemDesc")
                    txtQtyPerPiece.Text = Colordt.Rows(0)("Quantity")
                    lblrndid.Text = Colordt.Rows(0)("DPRNDID")
                Else
                    txtstyle.Text = ""
                    txtItem.Text = ""
                    txtQtyPerPiece.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgFabricCost_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFabricCost.ItemCommand
        Select Case e.CommandName
            Case "Remove"
                dtDetail = CType(Session("dtDetail"), DataTable)
                If (Not dtDetail Is Nothing) Then
                    If (dtDetail.Rows.Count > 0) Then
                        Dim FPlanDtlNewID As Integer = dtDetail.Rows(e.Item.ItemIndex)("FPlanDtlNewID")
                        dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        ObjFabricCostDtl.DeleteDetailFab(FPlanDtlNewID)
                        BindGrid()
                        If dtDetail.Rows.Count = 0 Then
                            dgFabricCost.Visible = False
                        End If
                    Else
                        dgFabricCost.Visible = False
                    End If
                End If


        End Select
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("Fabric.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtfabric_TextChanged(sender As Object, e As EventArgs) Handles txtfabric.TextChanged
        Try
            Dim dt As DataTable = ObjFabricCostMst.GetFabricItemId(txtfabric.Text)
            If dt.Rows.Count > 0 Then
                lblFabricItemId.Text = dt.Rows(0)("IMSItemID")
            End If
            Dim Dtt As DataTable
            Dtt = ObjFabricCostMst.GetFabricDataNew2(lblFabricItemId.Text)
            If Dt.Rows.Count > 0 Then
                'txtWidth.Text = Dtt.Rows(0)("FabricWidth")
                txtxFabricCons.Text = "" 'Dt.Rows(0)("Construction")
                txtComposition.Text = Dtt.Rows(0)("ItemComposition")
                cmbUnit.SelectedValue = Dtt.Rows(0)("ItemUnitId")
                cmbUnit2.SelectedValue = Dtt.Rows(0)("ItemUnitId")
                'cmbsupplier.SelectedValue = Dtt.Rows(0)("SupplierID")
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

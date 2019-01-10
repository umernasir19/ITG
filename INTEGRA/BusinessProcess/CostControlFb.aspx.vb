Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable

Public Class CostControlFb
    Inherits System.Web.UI.Page

    Dim ObjFabricCostMst As New FabricCostMst
    Dim ObjFabricCostDtl As New FabricCostDtl

    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim FPlanDt As DataTable
    Dim dr As DataRow
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objplacement As New PlacementClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then


            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
            FillMasterdate()
            BindFabric()
            bindSupplier()
            bindSUnit()
            BindPlacement()
            FPlanDt = ObjFabricCostMst.GetFPLANdetailNew(JobOrderID)

            If FPlanDt.Rows.Count > 0 Then
                Session("dtDetail") = FPlanDt
                lblFabricCostMstid.Text = FPlanDt.Rows(0)("FabricCostMstid")
                lblcreationDate.Text = FPlanDt.Rows(0)("CreationDate")
                BindGrid()
                btnSave.Visible = True
            End If

            ' BindFibricCode()


        End If

    End Sub
    Sub BindSeason()
        Dim Dt As DataTable
        Dt = objSizeRange.GetSeasons()
        cmbFabric.DataSource = Dt
        cmbFabric.DataTextField = "SeasonName"
        cmbFabric.DataValueField = "SeasonDatabaseId" '    "ProductDatabaseID"
        cmbFabric.DataBind()
        cmbFabric.DataSource = Dt
        cmbFabric.Items.Insert(0, New ListItem("Select..", "0"))

    End Sub
    Sub FillMasterdate()
        Try
            jOBdT = ObjFabricCostMst.GetJobOrderDataNew(JobOrderID)
            txtSeason.Text = jOBdT.Rows(0)("SeasonName")
            txtJobOrder.Text = jOBdT.Rows(0)("SrNo")
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
        'cmbUnit.DataSource = Dt
        cmbUnit.SelectedValue = 7
        'cmbUnit.Items.Insert(0, New ListItem("", "0"))

        cmbUnit2.DataSource = Dt
        cmbUnit2.DataTextField = "Symbol"
        cmbUnit2.DataValueField = "ItemUnitID" '    "ProductDatabaseID"
        cmbUnit2.DataBind()
        ' cmbUnit2.DataSource = Dt
        cmbUnit2.Items.Insert(0, New ListItem("", "0"))

    End Sub

    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabric.SelectedIndexChanged
        Try

            Dim Dt As DataTable
            Dt = ObjFabricCostMst.GetFabricDataNew2(cmbFabric.SelectedValue)


            If Dt.Rows.Count > 0 Then
                ' txtWidth.Text = Dt.Rows(0)("FabricWidth")
                txtxFabricCons.Text = Dt.Rows(0)("ItemQuality")
                txtComposition.Text = Dt.Rows(0)("ItemComposition")
                cmbUnit.SelectedValue = Dt.Rows(0)("ItemUnitId")
                cmbUnit2.SelectedValue = Dt.Rows(0)("ItemUnitId")
                'cmbsupplier.SelectedValue = Dt.Rows(0)("SupplierID")
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

         If cmbFabrictype.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Fabric Type")
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
                .Columns.Add("FabricCostDtlId", GetType(Long))
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
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("IMSItemId", GetType(Long))
                .Columns.Add("ItemCode", GetType(String))
                .Columns.Add("FabricQuality", GetType(String))
                .Columns.Add("FabricQualityForBuyer", GetType(String))
            End With
        End If



        dr = dtDetail.NewRow()
        dr("FabricCostDtlId") = 0
        dr("FabricdataBaseId") = cmbFabric.SelectedValue
        Dim FabricWeave As String = cmbFabric.SelectedItem.Text
        FabricWeave = FabricWeave.Replace("Select..", "")
        dr("FabricWeave") = FabricWeave 'cmbFabric.SelectedItem.Text
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
        dr("Currency") = cmbCurrencys.SelectedItem.Text
        dr("IMSItemId") = lblItemID.Text
        dr("ItemCode") = txtItemCode.Text
     dr("FabricQuality") = txtFABRICQUALITY.Text.ToUpper
     dr("FabricQualityForBuyer") = txtFABRICQUALITYBUYER.Text.ToUpper
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
        lblItemID.Text = ""
        txtItemCode.Text = ""
        txtFABRICQUALITY.Text = ""
        txtFABRICQUALITYBUYER.Text = ""
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
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        With ObjFabricCostMst
            If lblFabricCostMstid.Text = " " Then
                .FabricCostMstID = 0
            Else
                .FabricCostMstID = lblFabricCostMstid.Text
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
                .FabricCostDtlID = dgFabricCost.Items(x).Cells(0).Text
                If lblFabricCostMstid.Text = " " Then
                    .FabricCostMstID = ObjFabricCostMst.GetID
                Else
                    .FabricCostMstID = lblFabricCostMstid.Text
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
                .USD = dgFabricCost.Items(x).Cells(17).Text
                .Item = dgFabricCost.Items(x).Cells(19).Text
                .Style = dgFabricCost.Items(x).Cells(20).Text
                .QtyColorWise = dgFabricCost.Items(x).Cells(21).Text
                .Color = dgFabricCost.Items(x).Cells(18).Text
                .JobOrderDetailId = dgFabricCost.Items(x).Cells(22).Text
                .Currency = dgFabricCost.Items(x).Cells(23).Text
                .FabricWidth = dgFabricCost.Items(x).Cells(6).Text
                .IMSItemId = dgFabricCost.Items(x).Cells(24).Text
                .ItemCode = dgFabricCost.Items(x).Cells(25).Text
                .FabricQuality = dgFabricCost.Items(x).Cells(26).Text
                .FabricQualityForBuyer = dgFabricCost.Items(x).Cells(27).Text
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
    Protected Sub cmbColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            BindDetails()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub cmbFabrictype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabrictype.SelectedIndexChanged
        Try
            txtFABRICQUALITY.Text = ""
            txtFABRICQUALITYBUYER.Text = ""
            lblItemID.Text = ""
            txtItemCode.Text = ""
            cmbColor.SelectedValue = 0
        Catch ex As Exception

        End Try

    End Sub
    Sub BindDetails()
        Try
            If cmbColor.SelectedValue > 0 Then
                Dim Colordt As DataTable = ObjFabricCostMst.GetColorWiseDataNew(cmbColor.SelectedValue)
                If Colordt.Rows.Count > 0 Then
                    txtstyle.Text = Colordt.Rows(0)("style")
                    txtItem.Text = Colordt.Rows(0)("ItemDesc")
                    txtQtyPerPiece.Text = Colordt.Rows(0)("Quantity")
                    If cmbFabrictype.SelectedItem.Text = "Body Fabric" Then
                        txtItemCode.Text = Colordt.Rows(0)("ItemCode")
                        txtFABRICQUALITY.Text = Colordt.Rows(0)("Content")
                        txtFABRICQUALITYBUYER.Text = Colordt.Rows(0)("ContentForBuyer")
                        lblItemID.Text = Colordt.Rows(0)("IMSItemId")
                        txtComposition.Text = Colordt.Rows(0)("ItemComposition")
                        txtWidth.Text = Colordt.Rows(0)("Width")
                    End If
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
                        Dim FabricCostDtlId As Integer = dtDetail.Rows(e.Item.ItemIndex)("FabricCostDtlId")
                        dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        ObjFabricCostDtl.DeleteDetailFab(FabricCostDtlId)
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
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged
        Try
            Dim dtItem As DataTable = objJobOrderdatabase.GetItemDataCodeNew(txtItemCode.Text)
            Dim dtItem2 As DataTable = objJobOrderdatabase.GetItemDataCodeForDalRefNo(txtItemCode.Text)
            If dtItem.Rows.Count > 0 Then
                lblItemID.Text = dtItem.Rows(0)("imsitemid")
                txtFABRICQUALITY.Text = dtItem.Rows(0)("FabricQualityy")
                txtFABRICQUALITYBUYER.Text = dtItem.Rows(0)("FabricQualityy")
            ElseIf dtItem2.Rows.Count > 0 Then
                lblItemID.Text = dtItem2.Rows(0)("imsitemid")
                txtFABRICQUALITY.Text = dtItem2.Rows(0)("FabricQualityy")
                txtFABRICQUALITYBUYER.Text = dtItem2.Rows(0)("FabricQualityy")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnAddFabrictype_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddFabrictype.Click
        Try
            PnlBrand2.Visible = True
            PnlBrand1.Visible = False

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnFabrictypeSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnFabrictypeSave.Click
        Try
            If txtFabrictypeSave.Text <> "" Then
                With objplacement
                    .PlacementID = 0
                    .Placement = txtFabrictypeSave.Text
                    .Save()
                End With
            End If

        Catch ex As Exception

        End Try
        PnlBrand1.Visible = True
        PnlBrand2.Visible = False
        BindPlacement()
    End Sub
    Sub BindPlacement()
        Dim dt As DataTable
        dt = objSizeRange.GetPlacement()
        cmbFabrictype.DataSource = dt
        cmbFabrictype.DataTextField = "Placement"
        cmbFabrictype.DataValueField = "PlacementId"
        cmbFabrictype.DataBind()
        cmbFabrictype.Items.Insert(0, New ListItem("Select..", "0"))
    End Sub
End Class

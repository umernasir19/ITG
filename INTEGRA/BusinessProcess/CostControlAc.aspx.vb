Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class CostControlac
    Inherits System.Web.UI.Page
    Dim ObjAccessoriesCostMst As New AccessoriesCostMst
    Dim ObjAccessoriesCostDtl As New AccessoriesCostDtl
    Dim ObjFabricCostDtl As New FabricCostDtl

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
            BindAcctype()
            'bindSupplier()
            bindSUnit()
            bindStyle()
            ' bindSUnit()
            FPlanDt = ObjAccessoriesCostMst.GetFPLANdetailL(JobOrderID)

            If FPlanDt.Rows.Count > 0 Then
                Session("dtDetail") = FPlanDt
                lblAccessoriesCostMstid.Text = FPlanDt.Rows(0)("AccessoriesCostMstid")
                lblAccessoriesTotalCost.Text = FPlanDt.Rows(0)("GrossAmount")
                lblgross.Text = FPlanDt.Rows(0)("TGross")
                txtMisc.Text = FPlanDt.Rows(0)("Miscellaneous")
                txtRatee.Text = FPlanDt.Rows(0)("MisRate")

                BindGrid()
                btnSave.Visible = True
                lblAccessoriesTotalCost.Visible = True
                ' lblgross.Visible = True
                lblheading.Visible = True
            End If

            ' BindFibricCode()


        End If

    End Sub
    Sub FillMasterdate()
        jOBdT = ObjAccessoriesCostMst.GetJobOrderData(JobOrderID)
        If jOBdT.Rows.Count > 0 Then
            txtJobOrder.Text = jOBdT.Rows(0)("SRNO")
            'txtstyle.Text = jOBdT.Rows(0)("style")
            txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
            '   txtItem.Text = jOBdT.Rows(0)("ItemName")
            txtQty.Text = jOBdT.Rows(0)("Qty")
            txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
        End If



    End Sub
    Sub bindStyle()
        Dim dtST As DataTable
        Try
            dtST = ObjAccessoriesCostDtl.GetStyleByJobOrder(JobOrderID)
            cmbStyle.DataSource = dtST
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataValueField = "StyleId"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New ListItem("SELECT", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub bindSUnit()
        Dim Dt As DataTable
        Dt = ObjAccessoriesCostMst.GetUnitNEW()
        cmbUnit.DataSource = Dt
        cmbUnit.DataTextField = "Symbol"
        cmbUnit.DataValueField = "ItemUnitID" '    "ProductDatabaseID"
        cmbUnit.DataBind()
        'cmbUnit.DataSource = Dt
        'cmbUnit.Items.Insert(0, New ListItem("", "0"))
    End Sub
    Sub BindAcctype()
        Dim Dt As DataTable
        Dt = ObjAccessoriesCostMst.GetACCSCATcLASS()
        cmbAccessoriesType.DataSource = Dt
        cmbAccessoriesType.DataTextField = "ItemCategoryName"
        cmbAccessoriesType.DataValueField = "IMSItemCategoryID"
        cmbAccessoriesType.DataBind()
        cmbAccessoriesType.DataSource = Dt
        cmbAccessoriesType.Items.Insert(0, New ListItem("Select..", "0"))


    End Sub
    Sub bindItem()
        Dim Dt As DataTable
        Dt = ObjAccessoriesCostMst.GetImsItemNew(cmbAccessoriesType.SelectedValue)
        cmbitem.DataSource = Dt
        cmbitem.DataTextField = "ItemName"
        cmbitem.DataValueField = "IMSItemID"
        cmbitem.DataBind()
        cmbitem.DataSource = Dt
        cmbitem.Items.Insert(0, New ListItem("Select..", "0"))
    End Sub
    Protected Sub cmbAccessoriesType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccessoriesType.SelectedIndexChanged
        Try
            'If cmbAccessoriesType.SelectedItem.Text = "THREAD" Then
            '    cmbUnit.SelectedValue = 7
            '    cmbUnit.Enabled = False
            'End If
            If cmbAccessoriesType.SelectedItem.Text = "ZIPPER" Or cmbAccessoriesType.SelectedItem.Text = "STICKER" Or cmbAccessoriesType.SelectedItem.Text = "MAIN LABEL" Or cmbAccessoriesType.SelectedItem.Text = "HANG TAG" Or cmbAccessoriesType.SelectedItem.Text = "CARTON" Or cmbAccessoriesType.SelectedItem.Text = "ALARAM" Or cmbAccessoriesType.SelectedItem.Text = "CARE LABEL" Or cmbAccessoriesType.SelectedItem.Text = "BELT" Or cmbAccessoriesType.SelectedItem.Text = "LEATHER PATCH" Or cmbAccessoriesType.SelectedItem.Text = "PRICE TKT" Or cmbAccessoriesType.SelectedItem.Text = "JOCKER TAG" Then
                cmbUnit.SelectedValue = 3
            ElseIf cmbAccessoriesType.SelectedItem.Text = "RIVETS" Or cmbAccessoriesType.SelectedItem.Text = "METAL TRIMS" Or cmbAccessoriesType.SelectedItem.Text = "BUTTON" Or cmbAccessoriesType.SelectedItem.Text = "BUTTON PLASTIC" Then
                cmbUnit.SelectedValue = 12
            ElseIf cmbAccessoriesType.SelectedItem.Text = "ELASTIC" Then
                cmbUnit.SelectedValue = 7
            ElseIf cmbAccessoriesType.SelectedItem.Text = "THREAD" Then
                cmbUnit.SelectedValue = 15
            End If
            Dim Accessoriseclassid As Long = cmbAccessoriesType.SelectedValue
            Session("ItemclassId") = Accessoriseclassid
            bindItem()
            If cmbAccessoriesType.SelectedItem.Text = "THREAD" Then
                txtQtyColorWise.Text = ""
                BindColor()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtAccessories_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccessories.TextChanged
        Try
            Dim dtitem As DataTable
            If txtAccessories.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Item")
            ElseIf txtAccessories.Text <> "" Then
                dtitem = ObjAccessoriesCostMst.GetItem(txtAccessories.Text)
                'AccountCode = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                If dtitem.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")

                    AccessoriesId.Text = dtitem.Rows(0)("AccessoriesId")
                    cmbUnit.SelectedValue = dtitem.Rows(0)("ItemUnitId")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Item Not Exist")
                End If




            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        Dim GROSSS As Decimal
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleId", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("AccessoriesCostDtlID", GetType(Long))
                .Columns.Add("AccessoriesId", GetType(Long))
                .Columns.Add("AccessoriesType", GetType(String))
                .Columns.Add("AccessoriesTypeId", GetType(String))
                .Columns.Add("AccessoriesName", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("Symbol", GetType(String))
                .Columns.Add("ItemUnitid", GetType(String))
                .Columns.Add("UnitCost", GetType(String))
                .Columns.Add("Extra", GetType(String))
                .Columns.Add("ConQuantity", GetType(String))
                .Columns.Add("Gross", GetType(String))
                .Columns.Add("GrossCost", GetType(String))
                .Columns.Add("CostPerUnit", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("QtyColorWise", GetType(String))
            End With
        End If

        Dim gross As Decimal = Math.Round((Val(txtxconsumption.Text) * Val(txtQty.Text)) + (Val(txtxconsumption.Text) * Val(txtQty.Text) * Val(txtExtra.Text) / 100), 2)
        dr = dtDetail.NewRow()
        dr("StyleId") = cmbStyle.SelectedValue
        dr("Style") = cmbStyle.SelectedItem.Text
        dr("AccessoriesCostDtlID") = 0
        dr("AccessoriesId") = cmbitem.SelectedValue 'AccessoriesId.Text
        dr("AccessoriesType") = cmbAccessoriesType.SelectedItem.Text 'txtAccessories.Text
        dr("AccessoriesTypeId") = cmbAccessoriesType.SelectedValue
        dr("AccessoriesName") = cmbitem.SelectedItem.Text 'txtAccessories.Text
        dr("Consumption") = txtxconsumption.Text
        dr("Symbol") = cmbUnit.SelectedItem.Text
        dr("ItemUnitid") = cmbUnit.SelectedValue
        dr("Extra") = txtExtra.Text
        dr("UnitCost") = txtUnitCost.Text
        dr("QtyColorWise") = txtQtyColorWise.Text
        dr("Color") = cmbColor.SelectedItem.Text

        If cmbAccessoriesType.SelectedItem.Text = "THREAD" And cmbColor.SelectedItem.Text = "ALL" Then

            Dim Perc As Decimal = Val(txtQty.Text * txtExtra.Text) / 100 'Val(txtQtyColorWise.Text * txtExtra.Text) / 100 
            GROSSS = Val(txtQty.Text * txtxconsumption.Text) / 1000 'Val(txtQtyColorWise.Text * txtxconsumption.Text) / 1000
            Dim TOT As Decimal = Val(GROSSS + Perc)
            dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2) + Perc 'Math.Round(Val(txtxconsumption.Text) * Val(txtQtyColorWise.Text), 2)
            dr("Gross") = Math.Round(Val(dr("ConQuantity") / 1000), 2) 'TOT
            dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * Val(dr("Gross"))), 2)
            dr("CostPerUnit") = Math.Round((Val(dr("GrossCost")) / Val(txtQty.Text)), 2)
        ElseIf cmbAccessoriesType.SelectedItem.Text = "THREAD" Then

            Dim Perc As Decimal = Val(txtQtyColorWise.Text * txtExtra.Text) / 100 'Val(txtQty.Text * txtExtra.Text) / 100
            GROSSS = Val(txtQtyColorWise.Text * txtxconsumption.Text) / 1000 'Val(txtQty.Text * txtxconsumption.Text) / 1000
            Dim TOT As Decimal = Val(GROSSS + Perc)
            dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQtyColorWise.Text), 2) + Perc 'Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2)
            dr("Gross") = Math.Round(Val(dr("ConQuantity") / 1000), 2) 'Math.Round(Val(txtxconsumption.Text) * Val(txtQtyColorWise.Text), 2)'TOT
            dr("GrossCost") = Math.Round(Val(txtUnitCost.Text * Val(dr("Gross"))), 2) 'Math.Round((Val(txtUnitCost.Text) * TOT), 2)
            dr("CostPerUnit") = Math.Round((Val(dr("GrossCost")) / Val(txtQtyColorWise.Text)), 2)
        Else
            dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2)
            dr("Gross") = Math.Round((Val(txtxconsumption.Text) * Val(txtQty.Text)) + (Val(txtxconsumption.Text) * Val(txtQty.Text) * Val(txtExtra.Text) / 100), 2)
            dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * Val(dr("Gross"))), 2)
            dr("CostPerUnit") = Math.Round((Val(dr("GrossCost")) / Val(txtQty.Text)), 2)

            'dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * gross), 2)
            'If cmbUnit.SelectedValue = 3 Then
            '    Dim PC As Decimal = Val(txtxconsumption.Text) / 144
            '    Dim PCGRS As Decimal = Val(PC) * Val(txtUnitCost.Text)
            '    Dim PCGROSS As Decimal = Val(PCGRS) + Val((txtExtra.Text) * Val(txtQty.Text) / 100)
            '    dr("ConQuantity") = Math.Round(Val(PC) * Val(txtQty.Text), 2)
            '    dr("Gross") = Math.Round(PCGROSS, 2)
            '    dr("CostPerUnit") = Math.Round(PCGRS, 2)
            '    dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * PCGROSS), 2)

            'ElseIf cmbUnit.SelectedValue = 12 Then
            '    Dim GURS As Decimal = Val(txtxconsumption.Text) * 144
            '    Dim GURSGRS As Decimal = Val(GURS) * Val(txtUnitCost.Text)
            '    Dim PERC As Decimal = Val((txtExtra.Text) * Val(txtQty.Text)) / 100
            '    Dim PCGROSS As Decimal = Val(GURSGRS) + Val(PERC)
            '    dr("ConQuantity") = Math.Round(Val(GURS) * Val(txtQty.Text), 2)
            '    dr("Gross") = Math.Round(PCGROSS, 2)
            '    dr("CostPerUnit") = Math.Round(GURSGRS, 2)
            '    dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * PCGROSS), 2)
            'ElseIf cmbUnit.SelectedValue = 15 Then
            '    Dim YD As Decimal = Val(txtxconsumption.Text * txtUnitCost.Text) / 1000
            '    Dim YDGRS As Decimal = Val(txtxconsumption.Text * txtUnitCost.Text) + Val((txtQty.Text) * Val(txtExtra.Text) / 100)
            '    dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2)
            '    dr("Gross") = Math.Round(YDGRS, 2)
            '    dr("CostPerUnit") = Math.Round(YD, 2)
            '    dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * YDGRS), 2)

            'ElseIf cmbUnit.SelectedValue = 7 Then
            '    Dim MT3 As Decimal = Math.Round(Val(txtxconsumption.Text * txtQty.Text) / 39.37 + Val((txtQty.Text) * Val(txtExtra.Text) / 100), 2)
            '    dr("Gross") = Math.Round(MT3, 2)
            '    dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2)
            '    Dim MTCost3 As Decimal = Math.Round(Val(dr("Gross")) / Val(txtUnitCost.Text), 2)
            '    dr("CostPerUnit") = Math.Round(MTCost3, 2)
            '    dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * MT3), 2)
            'Else
            '    dr("ConQuantity") = Math.Round(Val(txtxconsumption.Text) * Val(txtQty.Text), 2)
            '    dr("CostPerUnit") = Math.Round(Val(dr("GrossCost")) / (Val(txtQty.Text)), 2)
            '    dr("GrossCost") = Math.Round((Val(txtUnitCost.Text) * gross), 2)
            '    dr("QtyColorWise") = txtQtyColorWise.Text
            'End If

        End If
        dtDetail.Rows.Add(dr)
        Session("dtDetail") = dtDetail
        BindGrid()
        btnSave.Visible = True

    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgAccessoriesCost.RecordCount = objDataview.Count
        dgAccessoriesCost.DataSource = objDataview
        dgAccessoriesCost.DataBind()
        Dim x As Integer
        Dim totalcost As Decimal = 0
        Dim totalgross As Decimal = 0
        For x = 0 To dgAccessoriesCost.Items.Count - 1
            totalcost = totalcost + Val(dgAccessoriesCost.Items(x).Cells(13).Text)
            totalgross = totalgross + Val(dgAccessoriesCost.Items(x).Cells(12).Text)
        Next
        lblAccessoriesTotalCost.Visible = True
        ' lblgross.Visible = True
        lblheading.Visible = True
        lblAccessoriesTotalCost.Text = Val(totalcost) + Val(txtRatee.Text)
        lblgross.Text = totalgross

    End Sub
    Sub clear()
        cmbAccessoriesType.SelectedValue = 0
        cmbitem.SelectedValue = 0
        txtAccessories.Text = ""
        txtxconsumption.Text = ""
        cmbUnit.SelectedValue = 0
        txtExtra.Text = ""
        txtUnitCost.Text = ""


    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbAccessoriesType.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Type")
            ElseIf cmbitem.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Accessories ")
            ElseIf txtxconsumption.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Consumption Empty")
            ElseIf txtExtra.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Loss/Extra Empty")
            ElseIf txtUnitCost.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Unit Cost Empty")
            ElseIf cmbStyle.SelectedItem.Text = "SELECT" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                clear()
                btnSave.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            save()
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Sub save()
        With ObjAccessoriesCostMst
            If lblAccessoriesCostMstid.Text = " " Then
                .AccessoriesCostMstID = 0
            Else
                .AccessoriesCostMstID = lblAccessoriesCostMstid.Text
            End If

            .JobOrderId = JobOrderID
            .JobOrderNo = txtJobOrder.Text
            .Item = txtItem.Text
            .Style = "N/A" 'txtstyle.Text
            .Quantity = txtQty.Text
            .TGross = lblgross.Text
            .GrossAmount = lblAccessoriesTotalCost.Text
            .Miscellaneous = txtMisc.Text
            .MisRate = txtRatee.Text
            .SaveAcCostMst()
        End With
        Dim x As Integer
        For x = 0 To dgAccessoriesCost.Items.Count - 1
            With ObjAccessoriesCostDtl
                .AccessoriesCostDtlID = dgAccessoriesCost.Items(x).Cells(0).Text
                If lblAccessoriesCostMstid.Text = " " Then
                    .AccessoriesCostMstID = ObjAccessoriesCostMst.GetID
                Else
                    .AccessoriesCostMstID = lblAccessoriesCostMstid.Text
                End If
                .StyleId = dgAccessoriesCost.Items(x).Cells(1).Text
                .Style = dgAccessoriesCost.Items(x).Cells(2).Text
                .AccessoriesId = dgAccessoriesCost.Items(x).Cells(3).Text
                .AccessoriesType = dgAccessoriesCost.Items(x).Cells(4).Text
                .Consumption = dgAccessoriesCost.Items(x).Cells(6).Text
                .ItemUnitid = dgAccessoriesCost.Items(x).Cells(8).Text
                .UnitCost = dgAccessoriesCost.Items(x).Cells(9).Text
                .Extra = dgAccessoriesCost.Items(x).Cells(10).Text
                .ConQuantity = dgAccessoriesCost.Items(x).Cells(11).Text
                .Gross = dgAccessoriesCost.Items(x).Cells(12).Text
                .GrossCost = dgAccessoriesCost.Items(x).Cells(13).Text
                .CostPerUnit = dgAccessoriesCost.Items(x).Cells(14).Text
                .Color = dgAccessoriesCost.Items(x).Cells(15).Text
                .QtyColorWise = dgAccessoriesCost.Items(x).Cells(16).Text
                .AccessoriesTypeId = dgAccessoriesCost.Items(x).Cells(17).Text
                .SaveAcCostdtl()
            End With
        Next

    End Sub

    Protected Sub cmbitem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem.SelectedIndexChanged
        Try
            Dim dtitem As DataTable
            If cmbitem.SelectedValue > 0 Then
                dtitem = ObjAccessoriesCostMst.GetItembYiDAcc(cmbitem.SelectedValue)
                'AccountCode = objtblBankMst.GetUniqueAccountName(txtAccountName.Text)
                If dtitem.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    AccessoriesId.Text = dtitem.Rows(0)("AccessoriesId")
                    cmbUnit.SelectedValue = dtitem.Rows(0)("ItemUnitId")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkAccessoriesePopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkAccessoriesePopup.Click
        Try
            Response.Write("<script> window.open('AccessoriesDataBasePopup.aspx', 'newwindow', 'left=100, top=180, height=350, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAccPOPUP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccPOPUP.Click
        Try
            Response.Write("<script> window.open('AccPOPUPNew.aspx', 'newwindow', 'left=100, top=180, height=350, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            BindAcctype()



        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            BindColor()

        Catch ex As Exception

        End Try


    End Sub
    Sub BindColor()
        Dim dtColor As DataTable
        Try

            If cmbAccessoriesType.SelectedItem.Text = "THREAD" Then
                dtColor = ObjAccessoriesCostDtl.BindColorStyleWise(JobOrderID)
                If dtColor.Rows.Count > 0 Then
                    cmbColor.DataSource = dtColor
                    cmbColor.DataTextField = "BuyerColor"
                    cmbColor.DataValueField = "BuyerColor"
                    cmbColor.DataBind()
                    cmbColor.Items.Insert(0, New ListItem("ALL", "0"))
                    BindQtyColorWiseNew()
                End If

            Else
                dtColor = ObjAccessoriesCostDtl.BindColorStyleWiseWithStyleId(JobOrderID, cmbStyle.SelectedValue)
                If dtColor.Rows.Count > 0 Then
                    cmbColor.DataSource = dtColor
                    cmbColor.DataTextField = "BuyerColor"
                    cmbColor.DataValueField = "BuyerColor"
                    cmbColor.DataBind()
                    cmbColor.Items.Insert(0, New ListItem("ALL", "0"))
                    BindQtyForStyleAll()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub BindQtyForStyleAll()
        Dim dt As DataTable
        Try
            dt = ObjAccessoriesCostDtl.BindQtyStyleWisee(JobOrderID, cmbStyle.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtQtyColorWise.Text = dt.Rows.Item(0)("Quantity")
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Sub BindQtyColorWise()
    '    Dim dtQty As DataTable
    '    Try


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub cmbColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            BindQtyColorWiseNew()
        Catch ex As Exception

        End Try

    End Sub
    Sub BindQtyColorWiseNew()
        Dim dtQty As DataTable
        Try
            If cmbAccessoriesType.SelectedItem.Text = "THREAD" And cmbColor.SelectedItem.Text = "ALL" Then
                dtQty = ObjAccessoriesCostDtl.BindQtyStyleWiseALL(JobOrderID)
                If dtQty.Rows.Count > 0 Then
                    txtQtyColorWise.Text = dtQty.Rows.Item(0)("Quantity")
                End If
            ElseIf cmbColor.SelectedItem.Text = "ALL" Then
                BindQtyForStyleAll()
            Else
                'dtQty = ObjAccessoriesCostDtl.BindQtyStyleWise(JobOrderID, cmbStyle.SelectedValue)
                dtQty = ObjAccessoriesCostDtl.BindQtyStyleWiseNew(JobOrderID, cmbColor.SelectedItem.Text)
                If dtQty.Rows.Count > 0 Then
                    txtQtyColorWise.Text = dtQty.Rows.Item(0)("Quantity")
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgAccessoriesCost_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAccessoriesCost.ItemCommand
        Select Case e.CommandName
            Case "Remove"
                dtDetail = CType(Session("dtDetail"), DataTable)
                If (Not dtDetail Is Nothing) Then
                    If (dtDetail.Rows.Count > 0) Then
                        Dim AccessoriesCostDtlID As Integer = dtDetail.Rows(e.Item.ItemIndex)("AccessoriesCostDtlID")
                        dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        ObjAccessoriesCostDtl.DeleteDetail(AccessoriesCostDtlID)
                        BindGrid()
                        If dtDetail.Rows.Count = 0 Then
                            dgAccessoriesCost.Visible = False
                        End If
                    Else
                        dgAccessoriesCost.Visible = False
                    End If
                End If


        End Select
    End Sub

    Protected Sub txtRatee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRatee.TextChanged
        Try
            Dim x As Integer
            Dim totalcost As Decimal = 0
            Dim totalgross As Decimal = 0
            For x = 0 To dgAccessoriesCost.Items.Count - 1
                totalcost = totalcost + Val(dgAccessoriesCost.Items(x).Cells(13).Text)
                totalgross = totalgross + Val(dgAccessoriesCost.Items(x).Cells(12).Text)
            Next
            lblAccessoriesTotalCost.Visible = True
            ' lblgross.Visible = True
            lblheading.Visible = True
            lblAccessoriesTotalCost.Text = Val(totalcost) + Val(txtRatee.Text)
            lblgross.Text = totalgross
        Catch ex As Exception

        End Try
    End Sub
End Class


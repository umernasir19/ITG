Imports Integra.EuroCentra

Imports System.Data
Imports System.Data.DataTable
Public Class CostHead
    Inherits System.Web.UI.Page

    '  Dim ObjCostCutToPackMst As New CostCutToPackMst
    Dim ObjCostOtherHeadDtll As New CostOtherHeadDtl
    Dim ObjCostOtherHeadMst As New CostOtherHeadMst
    ' Dim ObjCostCutToPackDtl As New CostCutToPackDtl

    Dim ObjFPlanDtl As New FPlanDtl
    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim FPlanDt As DataTable
    Dim dr As DataRow
    Dim ObjCostCutToPackMst As New CostCutToPackMst
    Dim objCostAheadClass As New CostAheadClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
            FillMasterdate()
            bindCostAhead()
            bindCostFrc()

            FPlanDt = ObjCostOtherHeadMst.GetFPLANdetail(JobOrderID)

            If FPlanDt.Rows.Count > 0 Then
                Session("dtDetail") = FPlanDt
                lblCostAHeadMstID.Text = FPlanDt.Rows(0)("CostOtherHeadMstID")

                lblAccessoriesTotalCost.Text = FPlanDt.Rows(0)("TotalCostAmount")
                lblheading.Visible = True
                lblAccessoriesTotalCost.Visible = True
                BindGrid()
                btnSave.Visible = True
            End If


        End If

    End Sub
    Protected Sub btnAddCostHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddCostHead.Click
        Try
            PnlOperationtype1.Visible = False
            PnlOperationtype2.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveCostHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveCostHead.Click
        Try

            If txtCostHead.Text <> "" Then
                Dim dt As DataTable = ObjCostCutToPackMst.CheckExistingCostAhead(txtCostHead.Text)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Operation Type Already Exist")
                    PnlOperationtype2.Visible = False
                    PnlOperationtype1.Visible = True
                    bindCostAhead()
                    txtCostHead.Text = ""
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    With objCostAheadClass
                        .CostAheadID = 0
                        .CostAhead = txtCostHead.Text.ToUpper()
                        .Save()
                    End With
                    PnlOperationtype2.Visible = False
                    PnlOperationtype1.Visible = True
                    bindCostAhead()
                    txtCostHead.Text = ""
                End If

            Else
                PnlOperationtype2.Visible = False
                PnlOperationtype1.Visible = True
                bindCostAhead()
                txtCostHead.Text = ""
            End If

        Catch ex As Exception

        End Try


    End Sub

    Sub bindCostAhead()
        Dim Dt As DataTable
        Dt = ObjCostOtherHeadMst.GetCostAhead()
        cmbCostHead.DataSource = Dt
        cmbCostHead.DataTextField = "CostAhead"
        cmbCostHead.DataValueField = "CostAheadId"
        cmbCostHead.DataBind()
        cmbCostHead.DataSource = Dt
        cmbCostHead.Items.Insert(0, New ListItem("Select..", "0"))
    End Sub
    Sub bindCostFrc()
        Dim Dt As DataTable
        Dt = ObjCostOtherHeadMst.GetCostFrc()
        cmbChooseFraction.DataSource = Dt
        cmbChooseFraction.DataTextField = "CostFrac"
        cmbChooseFraction.DataValueField = "CostFracId"
        cmbChooseFraction.DataBind()
        cmbChooseFraction.DataSource = Dt
        cmbChooseFraction.Items.Insert(0, New ListItem("Select..", "0"))
    End Sub
    Sub FillMasterdate()
        jOBdT = ObjCostOtherHeadMst.GetJobOrderData(JobOrderID)
        txtJobOrder.Text = jOBdT.Rows(0)("SRNO")
        ' txtstyle.Text = jOBdT.Rows(0)("style")
        txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
        '  txtItem.Text = jOBdT.Rows(0)("ItemName")
        txtQty.Text = jOBdT.Rows(0)("Qty")
        txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            If cmbCostHead.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Cost Head")
            ElseIf cmbChooseFraction.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Fraction")
            ElseIf txtCost.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cost Empty")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Amount Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveSession()
                btnSave.Visible = True
                cmbCostHead.SelectedValue = 0
                cmbChooseFraction.SelectedValue = 0
                txtCost.Text = ""
                txtAmount.Text = ""

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
                .Columns.Add("CostOtherHeadDtlID", GetType(Long))
                .Columns.Add("CostAHeadId", GetType(String))
                .Columns.Add("CostAHead", GetType(String))
                .Columns.Add("CostFracId", GetType(String))
                .Columns.Add("CostFrac", GetType(String))
                .Columns.Add("Cost", GetType(String))
                .Columns.Add("Amount", GetType(String))
            End With
        End If



        dr = dtDetail.NewRow()
        dr("CostOtherHeadDtlID") = 0
        dr("CostAHeadId") = cmbCostHead.SelectedValue
        dr("CostAHead") = cmbCostHead.SelectedItem.Text
        dr("CostFracId") = cmbChooseFraction.SelectedValue  'Convert.ToDecimal(txtOperationRate.Text).ToString("F2")
        dr("CostFrac") = cmbChooseFraction.SelectedItem.Text
        dr("Cost") = txtCost.Text
        dr("Amount") = Convert.ToDecimal(Val(txtAmount.Text)).ToString("F2")
        dtDetail.Rows.Add(dr)
        Session("dtDetail") = dtDetail
        BindGrid()

    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgCosthead.RecordCount = objDataview.Count
        dgCosthead.DataSource = objDataview
        dgCosthead.DataBind()
        Dim x As Integer
        Dim totalcost As Decimal = 0
        Dim totalgross As Decimal = 0
        For x = 0 To dgCosthead.Items.Count - 1
            totalcost = totalcost + Val(dgCosthead.Items(x).Cells(6).Text)
        Next
        lblAccessoriesTotalCost.Visible = True
        ' lblgross.Visible = True
        lblheading.Visible = True
        lblAccessoriesTotalCost.Text = totalcost.ToString("F2")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            save()
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Sub save()
        With ObjCostOtherHeadMst
            If lblCostOtherHeadMstID.Text = " " Then
                .CostOtherHeadMstID = 0
            Else
                .CostOtherHeadMstID = lblCostOtherHeadMstID.Text
            End If

            .JobOrderId = JobOrderID
            .JobOrderNo = txtJobOrder.Text
            .Item = txtItem.Text
            .Style = txtstyle.Text
            .Quantity = txtQty.Text
            .TOtalCostAmount = lblAccessoriesTotalCost.Text
            .SaveCostAheadMst()
        End With
        Dim x As Integer

        For x = 0 To dgCosthead.Items.Count - 1
            With ObjCostOtherHeadDtll
                .CostOtherHeadDtlID = dgCosthead.Items(x).Cells(0).Text
                If lblCostOtherHeadMstID.Text = " " Then
                    .CostOtherHeadMstID = ObjCostOtherHeadMst.GetID
                Else
                    .CostOtherHeadMstID = lblCostOtherHeadMstID.Text
                End If
                .CostAHeadId = dgCosthead.Items(x).Cells(1).Text
                .CostFracId = dgCosthead.Items(x).Cells(3).Text
                .Cost = dgCosthead.Items(x).Cells(5).Text
                .Amount = dgCosthead.Items(x).Cells(6).Text
                .SavecostheadDtl()
            End With
        Next


    End Sub
End Class

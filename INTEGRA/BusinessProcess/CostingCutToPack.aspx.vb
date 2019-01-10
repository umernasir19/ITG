Imports Integra.EuroCentra

Imports System.Data
Imports System.Data.DataTable
Public Class CostingCutToPack
    Inherits System.Web.UI.Page
    Dim ObjCostCutToPackMst As New CostCutToPackMst
    Dim ObjCostCutToPackDtl As New CostCutToPackDtl
    ' Dim ObjFabricCostMst As New FabricCostMst
    ' Dim ObjFabricCostDtl As New FabricCostDtl
    ' Dim ObjFPlanDtl As New FPlanDtl
    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim FPlanDt As DataTable
    Dim dr As DataRow
    Dim objProductionOperation As New ProductionOperation
    Dim Qty As Decimal = 0
    Dim Qtyy As Decimal = 0
    Dim FQtyy As Decimal = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
         
            FillMasterdate()
            bindOperatioType()
            bindRDCostPara()
            bindSUnit()
            FPlanDt = ObjCostCutToPackMst.GetFPLANdetail(JobOrderID)

            If FPlanDt.Rows.Count > 0 Then
                Session("dtDetail") = FPlanDt
                lblCostCutToPackMstID.Text = FPlanDt.Rows(0)("CostCutToPackMstID")
                RdbCMCostParameter.SelectedValue = FPlanDt.Rows(0)("CMCostParameterID")
                lblAccessoriesTotalCost.Text = FPlanDt.Rows(0)("TotalCMCost")
                lblheading.Visible = True
                lblAccessoriesTotalCost.Visible = True

                BindGrid()
                btnSave.Visible = True
            End If

            ' BindFibricCode()


        End If

    End Sub
    Protected Sub btnAddOperationType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddOperationType.Click
        Try
            PnlOperationtype1.Visible = False
            PnlOperationtype2.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveOperationType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveOperationType.Click
        Try
         
            If txtOperationType.Text <> "" Then
                Dim dt As DataTable = ObjCostCutToPackMst.CheckExistingProductionOperation(txtOperationType.Text)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Operation Type Already Exist")
                    PnlOperationtype2.Visible = False
                    PnlOperationtype1.Visible = True
                    bindOperatioType()
                    txtOperationType.Text = ""
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    With objProductionOperation
                        .ProductionOperationID = 0
                        .ProductionOperation = txtOperationType.Text.ToUpper()
                        .Save()
                    End With
                    PnlOperationtype2.Visible = False
                    PnlOperationtype1.Visible = True
                    bindOperatioType()
                    txtOperationType.Text = ""
                End If
               
            Else
                PnlOperationtype2.Visible = False
                PnlOperationtype1.Visible = True
                bindOperatioType()
                txtOperationType.Text = ""
            End If

        Catch ex As Exception

        End Try


    End Sub
    Sub FillMasterdate()
        jOBdT = ObjCostCutToPackMst.GetJobOrderDataNew(JobOrderID)
        If jOBdT.Rows.Count > 0 Then
            txtJobOrder.Text = jOBdT.Rows(0)("SRNO")
            '  txtstyle.Text = jOBdT.Rows(0)("style")
            txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
            '     txtItem.Text = jOBdT.Rows(0)("ItemName")
            Qty = jOBdT.Rows(0)("Qty")
            Qtyy = jOBdT.Rows(0)("AssQty")
            If Qtyy = 0 Then
                txtQty.Text = Qty 'jOBdT.Rows(0)("Qty")
            Else
                FQtyy = ((Qty * Qtyy) / 100) + Qty
                txtQty.Text = FQtyy 'jOBdT.Rows(0)("Qty")
            End If
            txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
        End If
    End Sub
    Sub bindSUnit()
        Dim Dt As DataTable
        Dt = ObjCostCutToPackMst.GetUnit()
        cmbUnit.DataSource = Dt
        cmbUnit.DataTextField = "Unit"
        cmbUnit.DataValueField = "OperationUnitId"
        cmbUnit.DataBind()
        cmbUnit.DataSource = Dt
        'cmbUnit.Items.Insert(0, New ListItem("", "0"))
    End Sub
    Sub bindOperatioType()
        Dim Dt As DataTable
        Dt = ObjCostCutToPackMst.GetProductionOPer()
        cmbOperationType.DataSource = Dt
        cmbOperationType.DataTextField = "ProductionOperation"
        cmbOperationType.DataValueField = "ProductionOperationID" '    "ProductDatabaseID"
        cmbOperationType.DataBind()
        cmbOperationType.DataSource = Dt
        cmbOperationType.Items.Insert(0, New ListItem("Select..", "0"))

    End Sub
    Sub bindRDCostPara()
        Dim Dt As DataTable
        Dt = ObjCostCutToPackMst.GetCostParameter()
        RdbCMCostParameter.DataSource = Dt
        RdbCMCostParameter.DataTextField = "CMCostParameter"
        RdbCMCostParameter.DataValueField = "CMCostParameterID" '    "ProductDatabaseID"
        RdbCMCostParameter.DataBind()
        RdbCMCostParameter.SelectedValue = 1
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("CostCutToPackDtlID", GetType(Long))
                .Columns.Add("ProductionOperation", GetType(String))
                .Columns.Add("ProductionOperationId", GetType(String))
                .Columns.Add("OperationRate", GetType(String))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("OperationUnitId", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Total", GetType(String))

            End With
        End If



        dr = dtDetail.NewRow()
        dr("CostCutToPackDtlID") = 0
        dr("ProductionOperation") = cmbOperationType.SelectedItem.Text
        dr("ProductionOperationId") = cmbOperationType.SelectedValue
        dr("OperationRate") = Convert.ToDecimal(txtOperationRate.Text).ToString("F2")
        dr("Unit") = cmbUnit.SelectedItem.Text
        dr("OperationUnitId") = cmbUnit.SelectedValue
        dr("Quantity") = txtQty.Text
        dr("Total") = Convert.ToDecimal(Val(txtOperationRate.Text) * Val(txtQty.Text)).ToString("F2")

        dtDetail.Rows.Add(dr)
        Session("dtDetail") = dtDetail
        BindGrid()

    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgCostingCuttoPack.RecordCount = objDataview.Count
        dgCostingCuttoPack.DataSource = objDataview
        dgCostingCuttoPack.DataBind()
        Dim x As Integer
        Dim totalcost As Decimal = 0
        Dim totalgross As Decimal = 0
        For x = 0 To dgCostingCuttoPack.Items.Count - 1
            totalcost = totalcost + Val(dgCostingCuttoPack.Items(x).Cells(7).Text)
        Next
        lblAccessoriesTotalCost.Visible = True
        ' lblgross.Visible = True
        lblheading.Visible = True
        lblAccessoriesTotalCost.Text = totalcost.ToString("F2")


    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbOperationType.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Operation Type")
            ElseIf txtOperationRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Operation Rate Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveSession()
                cmbOperationType.SelectedValue = 0
                txtOperationRate.Text = ""
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
        With ObjCostCutToPackMst
            If lblCostCutToPackMstID.Text = " " Then
                .CostCutToPackMstID = 0
            Else
                .CostCutToPackMstID = lblCostCutToPackMstID.Text
            End If

            .JobOrderId = JobOrderID
            .JobOrderNo = txtJobOrder.Text
            .Item = txtItem.Text
            .Style = txtstyle.Text
            .Quantity = txtQty.Text
            .TotalCMCost = lblAccessoriesTotalCost.Text
            .CMCostParameterID = RdbCMCostParameter.SelectedValue
            .SaveAcCostMst()
        End With
        Dim x As Integer

        For x = 0 To dgCostingCuttoPack.Items.Count - 1
            With ObjCostCutToPackDtl
                .CostCutToPackDtlID = dgCostingCuttoPack.Items(x).Cells(0).Text
                If lblCostCutToPackMstID.Text = " " Then
                    .CostCutToPackMstID = ObjCostCutToPackMst.GetID
                Else
                    .CostCutToPackMstID = lblCostCutToPackMstID.Text
                End If

                .ProductionOperationId = dgCostingCuttoPack.Items(x).Cells(2).Text
                .OperationRate = dgCostingCuttoPack.Items(x).Cells(3).Text
                .OperationUnitId = dgCostingCuttoPack.Items(x).Cells(5).Text
                .Quantity = dgCostingCuttoPack.Items(x).Cells(6).Text
                .Total = dgCostingCuttoPack.Items(x).Cells(7).Text
                .Savecostcuttopack()
            End With
        Next


    End Sub
End Class

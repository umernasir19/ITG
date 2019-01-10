Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ConsumptionEntryExport
    Inherits System.Web.UI.Page
    Dim dtCon As DataTable
    Dim Dr As DataRow
    Dim objCuttingProMst As New CuttingProMst
    Dim objCuttingProDetail As New CuttingProDetail
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim UserId, JobOrderId As Long
    Dim objCuttingRevisedDate As New CuttingRevisedDate
    Dim dtCutting As DataTable
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjConsumptionEntryMst As New ConsumptionEntryMst
    Dim ObjConsumptionEntryDtl As New ConsumptionEntryDtl
    Dim objAccCheckListMst As New AccCheckListMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("Joborderid")
        UserId = Session("UserId")
        If Not IsPostBack Then
            Session("dtCon") = Nothing
            Dim dtcheck As DataTable = objAccCheckListMst.CheckConData(lJobOrderID)
            If dtcheck.Rows.Count > 0 Then
                lblConMstID.Text = dtcheck.Rows(0)("ConMstID")
                Edit()
            Else
                FillMasterData()
                GetDetailData()
                BindSuppier()
            End If
            dgView.Columns(6).Visible = False
            dgView.Columns(7).Visible = False
            dgView.Columns(8).Visible = False
            dgView.Columns(9).Visible = False
            txtFabricRecvDate.ReadOnly = True
            CalendarExtender2.Enabled = False
            ImageButton2.Enabled = False
            cmbSupplier.Enabled = False
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JobOrderDatabaseViewExportView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveMaster()
                SaveDetail()
                Response.Redirect("JobOrderDatabaseViewExportView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Dim dt As DataTable = objAccCheckListMst.ConDataEdit(lblConMstID.Text)
        If dt.Rows.Count > 0 Then
            lblUserID.Text = dt.Rows(0)("UserId")
            BindSuppier()
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            txtSeason.Text = dt.Rows(0)("SeasonName")
            txtCustomer.Text = dt.Rows(0)("Customer")
            txtOrderNo.Text = dt.Rows(0)("OrderNo")
            If dt.Rows(0)("OrderRecvDate") = "" Then
                txtFabricRecvDate.Text = ""
            Else
                txtFabricRecvDate.Text = dt.Rows(0)("OrderRecvDate")
            End If
            Session("dtCon") = dt
            BindGrid()
        End If
    End Sub
    Sub BindSuppier()
        Try
            Dim dt As DataTable
            dt = objPORecvMaster.BindSupplier
            cmbSupplier.DataSource = dt
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseid"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub FillMasterData()
        Dim dt As DataTable = objCuttingProMst.GetJobOrderdata(lJobOrderID)
        If dt.Rows.Count > 0 Then
            txtSeason.Text = dt.Rows(0)("SeasonName")
            txtCustomer.Text = dt.Rows(0)("CustomerName")
            txtOrderNo.Text = dt.Rows(0)("CustomerOrder")
        End If
    End Sub
    Sub GetDetailData()
        Dim dt As DataTable = objCuttingProMst.GetJobOrderdata(lJobOrderID)
        If (Not CType(Session("dtCon"), DataTable) Is Nothing) Then
            dtCon = Session("dtCon")
        Else
            dtCon = New DataTable
            With dtCon
                .Columns.Add("ConDtlID", GetType(Long))
                .Columns.Add("JoborderDetailID", GetType(Long))
                .Columns.Add("SrNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(Decimal))
                .Columns.Add("EstCon", GetType(Decimal))
                .Columns.Add("OrderCon", GetType(Decimal))
                .Columns.Add("ActCon", GetType(Decimal))
                .Columns.Add("FabricReqQty", GetType(Decimal))
                .Columns.Add("ShippedQty", GetType(Decimal))
                .Columns.Add("BalanceQty", GetType(Decimal))
                .Columns.Add("StitchFactories", GetType(String))
                .Columns.Add("StitchDate", GetType(String))
                .Columns.Add("InspectionDate", GetType(String))
                .Columns.Add("Packing", GetType(Decimal))
                .Columns.Add("Length", GetType(Decimal))
                .Columns.Add("Width", GetType(Decimal))
                .Columns.Add("Height", GetType(Decimal))
            End With
            For x = 0 To dt.Rows.Count - 1
                Dr = dtCon.NewRow()
                Dr("ConDtlID") = dt.Rows(x)("ConDtlID")
                Dr("JoborderDetailID") = dt.Rows(x)("JoborderDetailID")
                Dr("SrNo") = dt.Rows(x)("SRNo")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("Color") = dt.Rows(x)("Color")
                Dr("Quantity") = dt.Rows(x)("Quantity")
                Dr("EstCon") = 0
                Dr("OrderCon") = 0
                Dr("ActCon") = 0
                Dr("FabricReqQty") = 0
                Dr("ShippedQty") = dt.Rows(x)("ShippedQuantity")
                Dr("BalanceQty") = 0
                Dr("StitchFactories") = dt.Rows(x)("StitchingFactory")
                Dr("StitchDate") = dt.Rows(x)("StitchingDate")
                Dr("InspectionDate") = ""
                Dr("Packing") = 0
                Dr("Length") = 0
                Dr("Width") = 0
                Dr("Height") = 0
                dtCon.Rows.Add(Dr)
            Next
            Session("dtCon") = dtCon
            BindGrid()
        End If
    End Sub
    Sub BindGrid()
        Dim dtt As DataTable = Session("dtCon")
        dgView.DataSource = dtt
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim txtEstCon As TextBox = CType(dgView.Items(x).FindControl("txtEstCon"), TextBox)
            Dim txtOrderCon As TextBox = CType(dgView.Items(x).FindControl("txtOrderCon"), TextBox)
            Dim txtActCon As TextBox = CType(dgView.Items(x).FindControl("txtActCon"), TextBox)
            Dim txtFabricReqQty As TextBox = CType(dgView.Items(x).FindControl("txtFabricReqQty"), TextBox)
            Dim txtBalanceQty As TextBox = CType(dgView.Items(x).FindControl("txtBalanceQty"), TextBox)
            Dim txtPacking As TextBox = CType(dgView.Items(x).FindControl("txtPacking"), TextBox)
            Dim txtLength As TextBox = CType(dgView.Items(x).FindControl("txtLength"), TextBox)
            Dim txtWidth As TextBox = CType(dgView.Items(x).FindControl("txtWidth"), TextBox)
            Dim txtHeight As TextBox = CType(dgView.Items(x).FindControl("txtHeight"), TextBox)
            Dim txtInspectionDate As TextBox = CType(dgView.Items(x).FindControl("txtInspectionDate"), TextBox)
            Dim StitchDate As String = dgView.Items(x).Cells(13).Text
            If lblConMstID.Text > 0 Then
                txtInspectionDate.Text = dtt.Rows(x)("InspectionDate")
                txtEstCon.Text = dtt.Rows(x)("EstCon")
                txtOrderCon.Text = dtt.Rows(x)("OrderCon")
                txtActCon.Text = dtt.Rows(x)("ActCon")
                txtFabricReqQty.Text = dtt.Rows(x)("FabricReqQty")
                txtBalanceQty.Text = dtt.Rows(x)("BalanceQty")
                txtPacking.Text = dtt.Rows(x)("Packing")
                txtLength.Text = dtt.Rows(x)("Length")
                txtWidth.Text = dtt.Rows(x)("Width")
                txtHeight.Text = dtt.Rows(x)("Height")
                If StitchDate = "01/01/1900 00:00:00" Then
                    dgView.Items(x).Cells(13).Text = ""
                End If
            Else
                txtInspectionDate.Text = ""
                txtEstCon.Text = 0
                txtOrderCon.Text = 0
                txtActCon.Text = 0
                txtFabricReqQty.Text = 0
                txtBalanceQty.Text = 0
                txtPacking.Text = 0
                txtLength.Text = 0
                txtWidth.Text = 0
                txtHeight.Text = 0
            End If
        Next
    End Sub
    Sub SaveMaster()
        With ObjConsumptionEntryMst
            If lblConMstID.Text > 0 Then
                .ConMstID = lblConMstID.Text
            Else
                .ConMstID = 0
            End If
            .CreationDate = Date.Now
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                If lblConMstID.Text <> 0 Then
                    .UserId = lblUserID.Text
                Else
                    .UserId = 270
                End If
            Else
                If lblConMstID.Text <> 0 Then
                    .UserId = lblUserID.Text
                Else
                    .UserId = UserId
                End If
            End If
            .SupplierID = cmbSupplier.SelectedValue
            .SeasonName = txtSeason.Text.ToUpper
            .Customer = txtCustomer.Text.ToUpper
            .OrderNo = txtOrderNo.Text.ToUpper
            If txtFabricRecvDate.Text = "" Then
                .OrderRecvDate = ""
            Else
                .OrderRecvDate = txtFabricRecvDate.Text
            End If
            .JobOrderId = lJobOrderID
            .Save()
        End With
    End Sub
    Sub SaveDetail()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim txtEstCon As TextBox = CType(dgView.Items(x).FindControl("txtEstCon"), TextBox)
            Dim txtOrderCon As TextBox = CType(dgView.Items(x).FindControl("txtOrderCon"), TextBox)
            Dim txtActCon As TextBox = CType(dgView.Items(x).FindControl("txtActCon"), TextBox)
            Dim txtFabricReqQty As TextBox = CType(dgView.Items(x).FindControl("txtFabricReqQty"), TextBox)
            Dim txtBalanceQty As TextBox = CType(dgView.Items(x).FindControl("txtBalanceQty"), TextBox)
            Dim txtPacking As TextBox = CType(dgView.Items(x).FindControl("txtPacking"), TextBox)
            Dim txtLength As TextBox = CType(dgView.Items(x).FindControl("txtLength"), TextBox)
            Dim txtWidth As TextBox = CType(dgView.Items(x).FindControl("txtWidth"), TextBox)
            Dim txtHeight As TextBox = CType(dgView.Items(x).FindControl("txtHeight"), TextBox)
            Dim txtInspectionDate As TextBox = CType(dgView.Items(x).FindControl("txtInspectionDate"), TextBox)
            With ObjConsumptionEntryDtl
                .ConDtlID = dgView.Items(x).Cells(0).Text
                If lblConMstID.Text > 0 Then
                    .ConMstID = lblConMstID.Text
                Else
                    .ConMstID = ObjConsumptionEntryMst.GetID
                End If
                .JoborderDetailID = dgView.Items(x).Cells(1).Text
                .SrNo = dgView.Items(x).Cells(2).Text
                .Style = dgView.Items(x).Cells(3).Text
                .Color = dgView.Items(x).Cells(4).Text
                If dgView.Items(x).Cells(13).Text = "&nbsp;" Or dgView.Items(x).Cells(13).Text = "" Then
                    .StitchDate = "01/01/1900"
                Else
                    .StitchDate = dgView.Items(x).Cells(13).Text
                End If
                .InspectionDate = txtInspectionDate.Text
                If dgView.Items(x).Cells(12).Text = "&nbsp;" Then
                    .StitchFactories = ""
                Else
                    .StitchFactories = dgView.Items(x).Cells(12).Text
                End If
                .Quantity = dgView.Items(x).Cells(5).Text
                If txtEstCon.Text = "" Then
                    .EstCon = 0
                Else
                    .EstCon = txtEstCon.Text
                End If
                If txtOrderCon.Text = "" Then
                    .OrderCon = 0
                Else
                    .OrderCon = txtOrderCon.Text
                End If
                If txtActCon.Text = "" Then
                    .ActCon = 0
                Else
                    .ActCon = txtActCon.Text
                End If
                If txtFabricReqQty.Text = "" Then
                    .FabricReqQty = 0
                Else
                    .FabricReqQty = txtFabricReqQty.Text
                End If
                If dgView.Items(x).Cells(10).Text = "&nbsp;" Then
                    .ShippedQty = 0
                Else
                    .ShippedQty = dgView.Items(x).Cells(10).Text
                End If
                If txtBalanceQty.Text = "" Then
                    .BalanceQty = 0
                Else
                    .BalanceQty = txtBalanceQty.Text
                End If
                .Packing = 0
                .Length = 0
                .Width = 0
                .Height = 0
                .Save()
            End With
        Next
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class FinishingLineEntry
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim objPurchaseOrderDetail As New PurchaseOrderDetail
    Dim dtDates As New DataTable
    Dim dr As DataRow
    Dim objFinishingLine As New FinishingLine
    Dim objFinishingLineDetail As New FinishingLineDetail
    Dim IFinishingLineID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IFinishingLineID = Request.QueryString("IFinishingLineID")
        If Not Page.IsPostBack Then
            PageHeader("Input Panel - Washing / Pressing / Packing / Ready to Inspect")
            BindCustomer()
            btnGenerateColumn.Visible = False
            btnUpdateBelowEntries.Visible = False
            txtPOID.Visible = False
            If IFinishingLineID > 0 Then
                cmbCustomer.Visible = False
                cmbPONo.Visible = False
                cmbSupplier.Visible = False
                cmbStyleNo.Visible = False
                txtcustomer.Visible = True
                txtsupplier.Visible = True
                txtStyleNo.Visible = True
                txtPONO.Visible = True
                btnUpdateBelowEntries.Visible = True
                EditMode()
            Else
                cmbCustomer.Visible = True
                cmbPONo.Visible = True
                cmbSupplier.Visible = True
                cmbStyleNo.Visible = True
                txtcustomer.Visible = False
                txtsupplier.Visible = False
                txtPONO.Visible = False
                txtStyleNo.Visible = False

            End If

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindCustomer()
        Dim objCustomer As New Customer
        Dim dtCustomer As DataTable
        dtCustomer = objCustomer.GetPOCustomerForCuttingStatus
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            Dim dtVender As DataTable
            Dim objVendor As New Vender
            dtVender = objVendor.GetPOVendersForClaim(cmbCustomer.SelectedValue)
            cmbSupplier.DataSource = dtVender
            cmbSupplier.DataTextField = "VenderName"
            cmbSupplier.DataValueField = "VenderLibraryID"
            cmbSupplier.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            Dim Dt As DataTable
            Dt = objPurchaseOrder.GetPOForClaim(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue)
            With cmbPONo
                .DataSource = Dt
                .DataTextField = "PONo"
                .DataValueField = "POID"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPONo.SelectedIndexChanged
        Try
            Dim dtStyleNo As DataTable
            dtStyleNo = objPurchaseOrderDetail.LoadAllStyle(cmbPONo.SelectedValue)
            cmbStyleNo.DataSource = dtStyleNo
            cmbStyleNo.DataTextField = "StyleNo"
            cmbStyleNo.DataValueField = "StyleID"
            cmbStyleNo.DataBind()

            txtDeliveryDate.Text = dtStyleNo.Rows(0)("ShipmentDatee")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyleNo.SelectedIndexChanged
        Try
            Dim ObjStitchingStatusDetail As New StitchingStatusDetail
            Dim dtStyleQty As DataTable
            dtStyleQty = objPurchaseOrderDetail.LoadAllStyleQty(cmbPONo.SelectedValue, cmbStyleNo.SelectedItem.Text)
            txtStyleQty.Text = dtStyleQty.Rows(0)("TotalQty").ToString() + " Pcs"
            Dim dtStitchingQtyL1 As DataTable
            Dim dtStitchingQtyL2 As DataTable
            Dim StitchingQty As Decimal
            dtStitchingQtyL1 = ObjStitchingStatusDetail.GetStitchingQtyL1(cmbPONo.SelectedValue, cmbStyleNo.SelectedItem.Text)
            dtStitchingQtyL2 = ObjStitchingStatusDetail.GetStitchingQtyL2(cmbPONo.SelectedValue, cmbStyleNo.SelectedItem.Text)
            StitchingQty = dtStitchingQtyL1.Rows(0)("L1Qty") + dtStitchingQtyL2.Rows(0)("L2Qty")

            If StitchingQty = 0 Then
                btnGenerateColumn.Visible = False
                btnUpdateBelowEntries.Visible = False
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Stitching is not started yet, please update stitching")
            Else
                txtStitched.Text = StitchingQty.ToString() + " Pcs"
                btnGenerateColumn.Visible = True
                btnUpdateBelowEntries.Visible = True
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGenerateColumn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerateColumn.Click
        Try
            'Make Dates
            Dim Timespan As TimeSpan = txtLineExitDt.SelectedDate.Value.Subtract(txtLineinitiateDt.SelectedDate.Value)
            Dim DaysRequried As Long = Timespan.Days + 1

            dtDates = Nothing
            Session("DtDates") = Nothing
            DtDates = New DataTable
            With dtDates
                .Columns.Add("FinishingLineDetailID", GetType(Long))
                .Columns.Add("FinishingLineID", GetType(Long))
                .Columns.Add("Dates", GetType(DateTime))
            End With
            For x = 0 To DaysRequried - 1
                dr = dtDates.NewRow()
                If x = 0 Then
                    Dim NewDate As Date = txtLineinitiateDt.SelectedDate
                    dr("Dates") = NewDate
                    dr("FinishingLineDetailID") = 0
                    dr("FinishingLineID") = 0
                Else
                    Dim NewDate As Date = txtLineinitiateDt.SelectedDate
                    dr("Dates") = NewDate.AddDays(x)
                    dr("FinishingLineDetailID") = 0
                    dr("FinishingLineID") = 0
                End If
                dtDates.Rows.Add(dr)
            Next
            Session("dtDates") = dtDates
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtDates Is Nothing) Then
            If (dtDates.Rows.Count > 0) Then
                dgFinishingLine.DataSource = dtDates
                dgFinishingLine.DataBind()
                dgFinishingLine.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub btnUpdateBelowEntries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateBelowEntries.Click
        Try
            If IFinishingLineID > 0 Then
                SaveStitchingStatusDetail()
            Else
                Dim dtcheck As New DataTable
                dtcheck = objFinishingLine.CheckExisting(cmbPONo.SelectedValue)
                If dtcheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Order Already Exist in Finishing Line.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveStitchingStatus()
                    SaveStitchingStatusDetail()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveStitchingStatus()
        Try
            With objFinishingLine
                If IFinishingLineID > 0 Then
                    .FinishingLineID = IFinishingLineID
                    .POID = txtPOID.Text
                Else
                    .FinishingLineID = 0
                    .POID = cmbPONo.SelectedValue
                End If
                .CreationDate = Date.Now
                .LineInitiateDate = txtLineinitiateDt.SelectedDate
                .LineExitDate = txtLineExitDt.SelectedDate
                .SaveFinishingLine()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveStitchingStatusDetail()
        Try
            Dim txtWashing As RadTextBox
            Dim txtPressing As RadTextBox
            Dim txtPacking As RadTextBox
            Dim txtReadyToInspect As RadTextBox
            Dim cmbDayStatus As RadComboBox
            Dim txtProductionDt As RadDatePicker
            For x = 0 To dgFinishingLine.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgFinishingLine.MasterTableView.Items(x), GridDataItem)
                cmbDayStatus = CType(dgFinishingLine.Items(x).FindControl("cmbDayStatus"), RadComboBox)
                txtWashing = CType(dgFinishingLine.Items(x).FindControl("txtWashing"), RadTextBox)
                txtPressing = CType(dgFinishingLine.Items(x).FindControl("txtPressing"), RadTextBox)
                txtPacking = CType(dgFinishingLine.Items(x).FindControl("txtPacking"), RadTextBox)
                txtReadyToInspect = CType(dgFinishingLine.Items(x).FindControl("txtReadyToInspect"), RadTextBox)
                txtProductionDt = CType(dgFinishingLine.Items(x).FindControl("txtProductionDt"), RadDatePicker)
                With objFinishingLineDetail
                    If IFinishingLineID > 0 Then
                        .FinishingLineDetailID = item("FinishingLineDetailID").Text
                        .FinishingLineID = IFinishingLineID
                    Else
                        .FinishingLineDetailID = item("FinishingLineDetailID").Text
                        .FinishingLineID = objFinishingLine.GetId
                    End If

                    .StyleNo = cmbStyleNo.SelectedItem.Text
                    .ProductionDate = txtProductionDt.SelectedDate
                    .DayStatus = cmbDayStatus.SelectedItem.Text
                    .Washing = txtWashing.Text
                    .Pressing = txtPressing.Text
                    .Packing = txtPacking.Text
                    .ReadyToInspect = txtReadyToInspect.Text
                    .SaveFinishingLineDetail()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objFinishingLine.SetEditMode(IFinishingLineID)
            txtcustomer.Text = dt.Rows(0)("CustomerName")
            txtsupplier.Text = dt.Rows(0)("Vendername")
            txtPONO.Text = dt.Rows(0)("PONO")
            txtPOID.Text = dt.Rows(0)("POID")
            txtDeliveryDate.Text = dt.Rows(0)("ShipmentDatee")
            txtStyleNo.Text = dt.Rows(0)("StyleNo")

            Dim ObjStitchingStatusDetail As New StitchingStatusDetail
            Dim dtStyleQty As DataTable
            dtStyleQty = objPurchaseOrderDetail.LoadAllStyleQty(txtPOID.Text, txtStyleNo.Text)
            txtStyleQty.Text = dtStyleQty.Rows(0)("TotalQty").ToString() + " Pcs"
            Dim dtStitchingQtyL1 As DataTable
            Dim dtStitchingQtyL2 As DataTable
            Dim StitchingQty As Decimal
            dtStitchingQtyL1 = ObjStitchingStatusDetail.GetStitchingQtyL1(txtPOID.Text, txtStyleNo.Text)
            dtStitchingQtyL2 = ObjStitchingStatusDetail.GetStitchingQtyL2(txtPOID.Text, txtStyleNo.Text)
            StitchingQty = dtStitchingQtyL1.Rows(0)("L1Qty") + dtStitchingQtyL2.Rows(0)("L2Qty")

            txtStitched.Text = StitchingQty.ToString() + " Pcs"

            dgFinishingLine.DataSource = dt
            dgFinishingLine.DataBind()
            dgFinishingLine.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("MGTSheetForAldiOrders.aspx")
    End Sub
End Class
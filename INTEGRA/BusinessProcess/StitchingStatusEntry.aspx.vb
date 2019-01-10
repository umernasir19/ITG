Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class StitchingStatusEntry
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim objPurchaseOrderDetail As New PurchaseOrderDetail
    Dim dtDates As New DataTable
    Dim dr As DataRow
    Dim objStitchingStatus As New StitchingStatus
    Dim objStitchingStatusDetail As New StitchingStatusDetail
    Dim IStitchingStatusID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IStitchingStatusID = Request.QueryString("StitchingStatusID")
        If Not Page.IsPostBack Then
            PageHeader("Input Panel - Stitching Status")
            BindCustomer()
            btnGenerateColumn.Visible = False
            btnUpdateBelowEntries.Visible = False
            txtPOID.Visible = False
            If IStitchingStatusID > 0 Then
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
            Dim ObjCuttingStatussDetail As New CuttingStatussDetail
            Dim dtStyleQty As DataTable
            dtStyleQty = objPurchaseOrderDetail.LoadAllStyleQty(cmbPONo.SelectedValue, cmbStyleNo.SelectedItem.Text)
            txtStyleQty.Text = dtStyleQty.Rows(0)("TotalQty").ToString() + " Pcs"
            Dim CuttingQty As DataTable
            CuttingQty = ObjCuttingStatussDetail.GetCuttingQty(cmbPONo.SelectedValue, cmbStyleNo.SelectedItem.Text)
            If CuttingQty.Rows(0)("CuttingQty") = 0 Then
                btnGenerateColumn.Visible = False
                btnUpdateBelowEntries.Visible = False
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cutting is not started yet, please update cutting")
            Else
                txtCuttingStatus.Text = CuttingQty.Rows(0)("CuttingQty").ToString() + " Pcs"
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

           
            DtDates = Nothing
            Session("DtDates") = Nothing
            DtDates = New DataTable
            With dtDates
                .Columns.Add("StitchingStatusDetailID", GetType(Long))
                .Columns.Add("StitchingStatusID", GetType(Long))
                .Columns.Add("Dates", GetType(DateTime))
            End With
            For x = 0 To DaysRequried - 1
                dr = dtDates.NewRow()
                If x = 0 Then
                    Dim NewDate As Date = txtLineinitiateDt.SelectedDate
                    dr("Dates") = NewDate
                    dr("StitchingStatusDetailID") = 0
                    dr("StitchingStatusID") = 0
                Else
                    Dim NewDate As Date = txtLineinitiateDt.SelectedDate
                    dr("Dates") = NewDate.AddDays(x)
                    dr("StitchingStatusDetailID") = 0
                    dr("StitchingStatusID") = 0
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
                dgStitchingStatus.DataSource = dtDates
                dgStitchingStatus.DataBind()
                dgStitchingStatus.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub btnUpdateBelowEntries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateBelowEntries.Click
        Try
            If IStitchingStatusID > 0 Then
                SaveStitchingStatusDetail()
            Else
                Dim dtcheck As New DataTable
                dtcheck = objStitchingStatus.CheckExisting(cmbPONo.SelectedValue)
                If dtcheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" This Order Already Exist in Stitching.")
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
            With objStitchingStatus
                If IStitchingStatusID > 0 Then
                    .StitchingStatusID = IStitchingStatusID
                    .POID = txtPOID.Text
                Else
                    .StitchingStatusID = 0
                    .POID = cmbPONo.SelectedValue
                End If
                .CreationDate = Date.Now
                .LineInitiateDate = txtLineinitiateDt.SelectedDate
                .LineExitDate = txtLineExitDt.SelectedDate
                .SaveStitchingStatus()
            End With

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveStitchingStatusDetail()
        Try
            Dim txtL1Plan As RadTextBox
            Dim txtL1Actual As RadTextBox
            Dim txtL2Plan As RadTextBox
            Dim txtL2Actual As RadTextBox
            Dim cmbDayStatus As RadComboBox
            Dim txtProductionDt As RadDatePicker
            For x = 0 To dgStitchingStatus.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgStitchingStatus.MasterTableView.Items(x), GridDataItem)
                cmbDayStatus = CType(dgStitchingStatus.Items(x).FindControl("cmbDayStatus"), RadComboBox)
                txtL1Plan = CType(dgStitchingStatus.Items(x).FindControl("txtL1Plan"), RadTextBox)
                txtL1Actual = CType(dgStitchingStatus.Items(x).FindControl("txtL1Actual"), RadTextBox)
                txtL2Plan = CType(dgStitchingStatus.Items(x).FindControl("txtL2Plan"), RadTextBox)
                txtL2Actual = CType(dgStitchingStatus.Items(x).FindControl("txtL2Actual"), RadTextBox)
                txtProductionDt = CType(dgStitchingStatus.Items(x).FindControl("txtProductionDt"), RadDatePicker)
                With objStitchingStatusDetail
                    If IStitchingStatusID > 0 Then
                        .StitchingStatusDetailID = item("StitchingStatusDetailID").Text
                        .StitchingStatusID = IStitchingStatusID
                    Else
                        .StitchingStatusDetailID = item("StitchingStatusDetailID").Text
                        .StitchingStatusID = objStitchingStatus.GetId
                    End If
                    
                    .StyleNo = cmbStyleNo.SelectedItem.Text
                    .ProductionDate = txtProductionDt.SelectedDate
                    .DayStatus = cmbDayStatus.SelectedItem.Text
                    .L1Plan = txtL1Plan.Text
                    .L1Actual = txtL1Actual.Text
                    .L2Plan = txtL2Plan.Text
                    .L2Actual = txtL2Actual.Text
                    .SaveStitchingStatusDetail()
                End With
            Next
           
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objStitchingStatus.SetEditMode(IStitchingStatusID)
            txtcustomer.Text = dt.Rows(0)("CustomerName")
            txtsupplier.Text = dt.Rows(0)("Vendername")
            txtPONO.Text = dt.Rows(0)("PONO")
            txtPOID.Text = dt.Rows(0)("POID")
            txtDeliveryDate.Text = dt.Rows(0)("ShipmentDatee")
            txtStyleNo.Text = dt.Rows(0)("StyleNo")

            Dim ObjCuttingStatussDetail As New CuttingStatussDetail
            Dim dtStyleQty As DataTable
            dtStyleQty = objPurchaseOrderDetail.LoadAllStyleQty(txtPOID.Text, txtStyleNo.Text)
            txtStyleQty.Text = dtStyleQty.Rows(0)("TotalQty").ToString() + " Pcs"
            Dim CuttingQty As DataTable
            CuttingQty = ObjCuttingStatussDetail.GetCuttingQty(txtPOID.Text, txtStyleNo.Text)
            txtCuttingStatus.Text = CuttingQty.Rows(0)("CuttingQty").ToString() + " Pcs"

            dgStitchingStatus.DataSource = dt
            dgStitchingStatus.DataBind()
            dgStitchingStatus.Visible = True


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("MGTSheetForAldiOrders.aspx")
    End Sub
End Class

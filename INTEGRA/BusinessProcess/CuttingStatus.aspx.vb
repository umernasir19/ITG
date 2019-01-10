Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class CuttingStatus
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim dtCutting As New DataTable
    Dim Dr As DataRow
    Dim objTNAChart As New TNAChart
    Dim objPurchaseOrderDetail As New PurchaseOrderDetail
    Dim objCuttingStatuss As New CuttingStatuss
    Dim objCuttingStatussDetail As New CuttingStatussDetail
    Dim ICuttingStatusID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ICuttingStatusID = Request.QueryString("CuttingStatusID")
        If Not Page.IsPostBack Then
            Session("dtCutting") = Nothing
            PageHeader("Input Panel - Cutting Status")
            BindCustomer()
            txtPOID.Visible = False

            If ICuttingStatusID > 0 Then
                cmbCustomer.Visible = False
                cmbPONo.Visible = False
                cmbSupplier.Visible = False
                txtcustomer.Visible = True
                txtPONO.Visible = True
                txtsupplier.Visible = True

                EditMode()
            Else
                btnAdd.Visible = False
                btnSave.Visible = False
                cmbCustomer.Visible = True
                cmbPONo.Visible = True
                cmbSupplier.Visible = True
                txtcustomer.Visible = False
                txtPONO.Visible = False
                txtsupplier.Visible = False
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
            'Check TNA Cutting Approval from Buyer
        
            Dim dtStatus As DataTable = objTNAChart.CheckCuttingApprovalStatus(cmbPONo.SelectedValue, 33)
            If dtStatus.Rows.Count > 0 Then
                dgCuttingStatus.Visible = True
                Dim x As Integer
                Dim cmbStyleNo As RadComboBox
                dgCuttingStatus.DataSource = dtStatus
                dgCuttingStatus.DataBind()
                dgCuttingStatus.BackColor = Drawing.Color.White
                For x = 0 To dgCuttingStatus.Items.Count - 1
                    cmbStyleNo = CType(dgCuttingStatus.Items(x).FindControl("cmbStyleNo"), RadComboBox)
                    Dim dtStyleNo As DataTable
                    dtStyleNo = objPurchaseOrderDetail.LoadAllStyle(cmbPONo.SelectedValue)
                    cmbStyleNo.DataSource = dtStyleNo
                    cmbStyleNo.DataTextField = "StyleNo"
                    cmbStyleNo.DataValueField = "StyleID"
                    cmbStyleNo.DataBind()
                Next
                txtPOID.Text = cmbPONo.SelectedValue
                btnAdd.Visible = True

                lblApproval.Text = "* Cutting approval given by buyer on " + dtStatus.Rows(0)("ActualDatee")
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Else
                lblApproval.Text = ""
                dgCuttingStatus.Visible = False
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You are not allowed for cutting, please take buyer's approval")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Dim InputDate As RadDatePicker
            Dim LotNo As RadTextBox
            Dim InputQty As RadNumericTextBox
            Dim OutputDate As RadDatePicker
            Dim StyleNo As RadComboBox
            InputDate = CType(dgCuttingStatus.Items(0).FindControl("txtInputDate"), RadDatePicker)
            LotNo = CType(dgCuttingStatus.Items(0).FindControl("txtLotNo"), RadTextBox)
            InputQty = CType(dgCuttingStatus.Items(0).FindControl("txtInputQty"), RadNumericTextBox)
            OutputDate = CType(dgCuttingStatus.Items(0).FindControl("txtOutputDate"), RadDatePicker)
            StyleNo = CType(dgCuttingStatus.Items(0).FindControl("cmbStyleNo"), RadComboBox)

            Dim OutputDatee As String = OutputDate.SelectedDate.ToString()
            Dim InputDatee As String = InputDate.SelectedDate.ToString()
            If StyleNo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style No.")
            ElseIf InputDatee = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Input Date Required.")
            ElseIf LotNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Lot No Required.")
            ElseIf InputQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Input Qty Required.")
            ElseIf OutputDatee = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Output Date Required.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()

                btnSave.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        Try
            If (Not CType(Session("dtCutting"), DataTable) Is Nothing) Then
                dtCutting = Session("dtCutting")
            Else
                dtCutting = New DataTable
                With dtCutting
                    .Columns.Add("CuttingStatusDetailID", GetType(Long))
                    .Columns.Add("CuttingStatusID", GetType(Long))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("InputDate", GetType(DateTime))
                    .Columns.Add("LotNo", GetType(String))
                    .Columns.Add("InputQty", GetType(Decimal))
                    .Columns.Add("OutputDate", GetType(DateTime))
                    .Columns.Add("Consumption", GetType(Decimal))
                    .Columns.Add("OutputQty", GetType(Decimal))
                    .Columns.Add("Remarks", GetType(String))
                End With
            End If

            Dim x As Integer
            Dim InputDate As RadDatePicker
            Dim LotNo As RadTextBox
            Dim InputQty As RadNumericTextBox
            Dim OutputDate As RadDatePicker
            Dim Consumption As RadNumericTextBox
            Dim OutputQty As RadNumericTextBox
            Dim Remarks As RadTextBox
            Dim StyleNo As RadComboBox
            For x = 0 To dgCuttingStatus.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgCuttingStatus.MasterTableView.Items(x), GridDataItem)
                InputDate = CType(dgCuttingStatus.Items(x).FindControl("txtInputDate"), RadDatePicker)
                LotNo = CType(dgCuttingStatus.Items(x).FindControl("txtLotNo"), RadTextBox)
                InputQty = CType(dgCuttingStatus.Items(x).FindControl("txtInputQty"), RadNumericTextBox)
                OutputDate = CType(dgCuttingStatus.Items(x).FindControl("txtOutputDate"), RadDatePicker)
                Consumption = CType(dgCuttingStatus.Items(x).FindControl("txtConsumption"), RadNumericTextBox)
                OutputQty = CType(dgCuttingStatus.Items(x).FindControl("txtOutputQty"), RadNumericTextBox)
                Remarks = CType(dgCuttingStatus.Items(x).FindControl("txtRemarks"), RadTextBox)
                StyleNo = CType(dgCuttingStatus.Items(x).FindControl("cmbStyleNo"), RadComboBox)

                Dr = dtCutting.NewRow()
                Dr("CuttingStatusDetailID") = 0 'item("CuttingStatusDetailID").Text
                If ICuttingStatusID > 0 Then
                    Dr("CuttingStatusID") = ICuttingStatusID
                Else
                    Dr("CuttingStatusID") = 0 'item("CuttingStatusID").Text
                End If
                Dr("StyleNo") = StyleNo.SelectedItem.Text
                Dr("InputDate") = InputDate.SelectedDate
                Dr("LotNo") = LotNo.Text
                If InputQty.Text = "" Then
                    Dr("InputQty") = 0
                Else
                    Dr("InputQty") = InputQty.Text
                End If
                Dim OutputDatee As String = OutputDate.SelectedDate.ToString()
                If OutputDatee = "" Then
                    Dr("OutputDate") = DBNull.Value
                Else
                    Dr("OutputDate") = OutputDate.SelectedDate
                End If
                If Consumption.Text = "" Then
                    Dr("Consumption") = 0
                Else
                    Dr("Consumption") = Consumption.Text
                End If
                If OutputQty.Text = "" Then
                    Dr("OutputQty") = 0
                Else
                    Dr("OutputQty") = OutputQty.Text
                End If

                Dr("Remarks") = Remarks.Text
                dtCutting.Rows.Add(Dr)
            Next
            Session("dtCutting") = dtCutting
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtCutting Is Nothing) Then
            If (dtCutting.Rows.Count > 0) Then
                dgCuttingDetail.DataSource = dtCutting
                dgCuttingDetail.DataBind()
                dgCuttingDetail.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            'check Already Exist
            If ICuttingStatusID > 0 Then
                SaveCuttingStatus()
                SaveCuttingStatusDetail()
                Session("dtCutting") = Nothing
                Session("dtCutting") = Nothing
                Response.Redirect("MGTSheetForAldiOrders.aspx")
            Else
                Dim dtcheck As DataTable
                dtcheck = objCuttingStatuss.CheckExisting(cmbPONo.SelectedValue)
                If dtcheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Order have already Cutting Exist.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveCuttingStatus()
                    SaveCuttingStatusDetail()
                    Session("dtCutting") = Nothing
                    Session("dtCutting") = Nothing
                    Response.Redirect("MGTSheetForAldiOrders.aspx")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveCuttingStatus()
        Try
            With objCuttingStatuss
                If ICuttingStatusID > 0 Then
                    .CuttingStatusID = ICuttingStatusID
                    .POID = txtPOID.Text
                Else
                    .CuttingStatusID = 0
                    .POID = cmbPONo.SelectedValue
                End If
                .CreationDate = Date.Now
                .SaveCuttingStatus()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveCuttingStatusDetail()
        Try
            Dim x As Integer
            Dim InputDate As RadDatePicker
            Dim LotNo As RadTextBox
            Dim InputQty As RadNumericTextBox
            Dim OutputDate As RadDatePicker
            Dim Consumption As RadTextBox
            Dim OutputQty As RadNumericTextBox
            Dim Remarks As RadTextBox
            Dim StyleNo As RadComboBox
            For x = 0 To dgCuttingDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgCuttingDetail.MasterTableView.Items(x), GridDataItem)
                InputDate = CType(dgCuttingDetail.Items(x).FindControl("txtInputDate"), RadDatePicker)
                LotNo = CType(dgCuttingDetail.Items(x).FindControl("txtLotNo"), RadTextBox)
                InputQty = CType(dgCuttingDetail.Items(x).FindControl("txtInputQty"), RadNumericTextBox)
                OutputDate = CType(dgCuttingDetail.Items(x).FindControl("txtOutputDate"), RadDatePicker)
                Consumption = CType(dgCuttingDetail.Items(x).FindControl("txtConsumption1"), RadTextBox)
                OutputQty = CType(dgCuttingDetail.Items(x).FindControl("txtOutputQty1"), RadNumericTextBox)
                Remarks = CType(dgCuttingDetail.Items(x).FindControl("txtRemarks"), RadTextBox)
                StyleNo = CType(dgCuttingDetail.Items(x).FindControl("cmbStyleNo"), RadComboBox)

                With objCuttingStatussDetail
                    .CuttingStatusDetailID = item("CuttingStatusDetailID").Text
                    If ICuttingStatusID > 0 Then
                        .CuttingStatusID = ICuttingStatusID
                    Else
                        .CuttingStatusID = objCuttingStatuss.GetId
                    End If
                    .StyleNo = item("StyleNo").Text
                    .InputDate = InputDate.SelectedDate
                    .LotNo = LotNo.Text
                    .InputQty = InputQty.Text
                    .OutputDate = OutputDate.SelectedDate
                    .Consumption = Consumption.Text
                    .OutputQty = OutputQty.Text
                    .Remarks = Remarks.Text
                    .SaveCuttingStatusDetail()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objCuttingStatuss.SetEditMode(ICuttingStatusID)
            txtcustomer.Text = dt.Rows(0)("CustomerName")
            txtsupplier.Text = dt.Rows(0)("Vendername")
            txtPONO.Text = dt.Rows(0)("PONO")
            txtPOID.Text = dt.Rows(0)("POID")

            Dim dtStatus As DataTable = objTNAChart.CheckCuttingApprovalStatus(txtPOID.Text, 33)
            If dtStatus.Rows.Count > 0 Then
                dgCuttingStatus.Visible = True
                Dim x As Integer
                Dim cmbStyleNo As RadComboBox
                dgCuttingStatus.DataSource = dtStatus
                dgCuttingStatus.DataBind()
                dgCuttingStatus.BackColor = Drawing.Color.White
                For x = 0 To dgCuttingStatus.Items.Count - 1
                    cmbStyleNo = CType(dgCuttingStatus.Items(x).FindControl("cmbStyleNo"), RadComboBox)
                    Dim dtStyleNo As DataTable
                    dtStyleNo = objPurchaseOrderDetail.LoadAllStyle(txtPOID.Text)
                    cmbStyleNo.DataSource = dtStyleNo
                    cmbStyleNo.DataTextField = "StyleNo"
                    cmbStyleNo.DataValueField = "StyleID"
                    cmbStyleNo.DataBind()
                Next
            Else
                dgCuttingStatus.Visible = False
            End If



            If (Not CType(Session("dtCutting"), DataTable) Is Nothing) Then
                dtCutting = Session("dtCutting")
            Else
                dtCutting = New DataTable
                With dtCutting
                    .Columns.Add("CuttingStatusDetailID", GetType(Long))
                    .Columns.Add("CuttingStatusID", GetType(Long))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("InputDate", GetType(DateTime))
                    .Columns.Add("LotNo", GetType(String))
                    .Columns.Add("InputQty", GetType(Decimal))
                    .Columns.Add("OutputDate", GetType(DateTime))
                    .Columns.Add("Consumption", GetType(Decimal))
                    .Columns.Add("OutputQty", GetType(Decimal))
                    .Columns.Add("Remarks", GetType(String))
                End With
            End If

            Dim xx As Integer
            For xx = 0 To dt.Rows.Count - 1
                Dr = dtCutting.NewRow()
                Dr("CuttingStatusDetailID") = dt.Rows(xx)("CuttingStatusDetailID")
                Dr("CuttingStatusID") = dt.Rows(xx)("CuttingStatusID")
                Dr("StyleNo") = dt.Rows(xx)("StyleNo")
                Dr("InputDate") = dt.Rows(xx)("InputDate")
                Dr("LotNo") = dt.Rows(xx)("LotNo")
                Dr("InputQty") = dt.Rows(xx)("InputQty")
                Dr("OutputDate") = dt.Rows(xx)("OutputDate")
                Dr("Consumption") = dt.Rows(xx)("Consumption")
                Dr("OutputQty") = dt.Rows(xx)("OutputQty")
                Dr("Remarks") = dt.Rows(xx)("Remarks")
                dtCutting.Rows.Add(Dr)
            Next
            Session("dtCutting") = dtCutting
            BindGrid()
            dgCuttingDetail.BackColor = Drawing.Color.White

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Session("dtCutting") = Nothing
            Response.Redirect("MGTSheetForAldiOrders.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtConsumption_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim InputQty As RadNumericTextBox
        Dim Consumption As RadNumericTextBox
        Dim OutputQty As RadNumericTextBox
        InputQty = CType(dgCuttingStatus.Items(0).FindControl("txtInputQty"), RadNumericTextBox)
        Consumption = CType(dgCuttingStatus.Items(0).FindControl("txtConsumption"), RadNumericTextBox)
        OutputQty = CType(dgCuttingStatus.Items(0).FindControl("txtOutputQty"), RadNumericTextBox)
        Dim InputQuantity As Decimal
        Dim Consumptions As Decimal
        InputQuantity = InputQty.Text
        Consumptions = Consumption.Text
        OutputQty.Text = InputQuantity / Consumptions
    End Sub
    Protected Sub txtConsumption1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim InputQty As RadNumericTextBox
        Dim Consumption As RadTextBox
        Dim OutputQty As RadNumericTextBox
        InputQty = CType(dgCuttingDetail.Items(0).FindControl("txtInputQty"), RadNumericTextBox)
        Consumption = CType(dgCuttingDetail.Items(0).FindControl("txtConsumption1"), RadTextBox)
        OutputQty = CType(dgCuttingDetail.Items(0).FindControl("txtOutputQty1"), RadNumericTextBox)
        Dim InputQuantity As Decimal
        Dim Consumptions As Decimal
        InputQuantity = InputQty.Text
        Consumptions = Consumption.Text
        OutputQty.Text = InputQuantity / Consumptions
    End Sub

End Class
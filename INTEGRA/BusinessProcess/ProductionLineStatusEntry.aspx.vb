Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class ProductionLineStatusEntry
    Inherits System.Web.UI.Page
    Dim objProductionLineStatus As New ProductionLineStatus
    Dim objProductionLineStatusDetail As New ProductionLineStatusDetail
    Dim PLSEID As Long
    Dim dtPurchaseOrder As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PLSEID = Request.QueryString("lPLSEID")
        txtCustomer.Visible = False
        txtCustomerID.Visible = False
        txtSuplierID.Visible = False
        txtSupplier.Visible = False
        txtPOID.Visible = False
        txtPONO.Visible = False
        If Not Page.IsPostBack Then
            BindCustomer()
            If PLSEID > 0 Then
                txtCustomer.Visible = True
                txtSupplier.Visible = True
                txtPONO.Visible = True
                txtTodayDate.Text = Today.Date
                SetValuesEditMod()

            End If
        End If
        
    End Sub
    Private Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objProductionLineStatus.GetCustomers
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSuppliers(ByVal CustomerID)
        Try
            Dim dtSuppliers As DataTable
            dtSuppliers = objProductionLineStatus.GetSuppliers(CustomerID)
            cmbSupplier.DataSource = dtSuppliers
            cmbSupplier.DataValueField = "VenderLibraryID"
            cmbSupplier.DataTextField = "VenderName"
            cmbSupplier.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged

        Dim CustomerID As Long = cmbCustomer.SelectedValue()
        BindSuppliers(CustomerID)
    End Sub
    Sub BindPONO(ByVal CustomerID, ByVal SupplierID)
        Try
            Dim dtPONO As DataTable
            dtPONO = objProductionLineStatus.GetPONO(CustomerID, SupplierID)

            cmbPONO.DataSource = dtPONO
            cmbPONO.DataValueField = "POID"
            cmbPONO.DataTextField = "PONO"
            cmbPONO.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Dim CustomerID As Long = cmbCustomer.SelectedValue()
        Dim VenderLibraryID As String = cmbSupplier.SelectedValue()
        BindPONO(CustomerID, VenderLibraryID)
    End Sub
    Protected Sub cmbPONO_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPONO.SelectedIndexChanged
        Dim POID As Long = cmbPONO.SelectedValue
        Dim dtdata As DataTable = objProductionLineStatus.GetDates(POID)
        txtShipmentDate.Text = dtdata.Rows(0)("ShipmentDate").ToString()
        txtPlacementDate.Text = dtdata.Rows(0)("PlacementDate").ToString()
        txtBookedQuantity.Text = dtdata.Rows(0)("BookedQuantity").ToString()
        txtTodayDate.Text = Today.Date
        txtDaysLeft.Text = dtdata.Rows(0)("DaysDif").ToString()
        If txtDaysLeft.Text <= 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You are not able to planned production line")
            lblTotalLines.Visible = False
            txtTotalLines.Visible = False
            lblProductionLine.Visible = False
            txtProductionLine.Visible = False
            lblProductionDay.Visible = False
            txtProductionDay.Visible = False
            lblDaysRequired.Visible = False
            txtDaysRequired.Visible = False
            lblLineInitiated.Visible = False
            cmbLineInitiatedOn.Visible = False
            lblLineClosing.Visible = False
            cmbLineClosing.Visible = False
            btnSave.Visible = False
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

            lblTotalLines.Visible = True
            txtTotalLines.Visible = True
            lblProductionLine.Visible = True
            txtProductionLine.Visible = True
            lblProductionDay.Visible = True
            txtProductionDay.Visible = True
            lblDaysRequired.Visible = True
            txtDaysRequired.Visible = True
            lblLineInitiated.Visible = True
            cmbLineInitiatedOn.Visible = True
            lblLineClosing.Visible = True
            cmbLineClosing.Visible = True
            btnSave.Visible = True
            '''''''''''''''''''''''''for Validation''''''''''''''''''''''''''
            Dim dtValidate As New DataTable
            dtValidate = objProductionLineStatus.CheckExistingValue(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbPONO.SelectedValue)
            If dtValidate.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Production Entry for this PO No is already Done.")
                lblTotalLines.Visible = False
                txtTotalLines.Visible = False
                lblProductionLine.Visible = False
                txtProductionLine.Visible = False
                lblProductionDay.Visible = False
                txtProductionDay.Visible = False
                lblDaysRequired.Visible = False
                txtDaysRequired.Visible = False
                lblLineInitiated.Visible = False
                cmbLineInitiatedOn.Visible = False
                lblLineClosing.Visible = False
                cmbLineClosing.Visible = False
                btnSave.Visible = False
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                lblTotalLines.Visible = True
                txtTotalLines.Visible = True
                lblProductionLine.Visible = True
                txtProductionLine.Visible = True
                lblProductionDay.Visible = True
                txtProductionDay.Visible = True
                lblDaysRequired.Visible = True
                txtDaysRequired.Visible = True
                lblLineInitiated.Visible = True
                cmbLineInitiatedOn.Visible = True
                lblLineClosing.Visible = True
                cmbLineClosing.Visible = True
                btnSave.Visible = True
                '''''''''''''''''''''For Style''''''''''''''''''''''''''''''''''
                Dim dtStyle As New DataTable
                dtStyle = objProductionLineStatus.GetStyleData(cmbPONO.SelectedValue)
                Dim objDataView As DataView
                objDataView = New DataView(dtStyle)
                Session("objDataView") = objDataView
                BindGrid()
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgPurchaseOrder.DataSource = objDataView
            dgPurchaseOrder.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtTotalLines_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTotalLines.TextChanged
        If Not String.IsNullOrEmpty(txtTotalLines.Text) AndAlso Not String.IsNullOrEmpty(txtProductionLine.Text) Then
            txtProductionDay.Text = (Convert.ToInt32(txtTotalLines.Text) * Convert.ToInt32(txtProductionLine.Text)).ToString()
        End If
    End Sub
    Protected Sub txtProductionLine_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtProductionLine.TextChanged
        If Not String.IsNullOrEmpty(txtTotalLines.Text) AndAlso Not String.IsNullOrEmpty(txtProductionLine.Text) Then
            txtProductionDay.Text = (Convert.ToInt32(txtTotalLines.Text) * Convert.ToInt32(txtProductionLine.Text)).ToString()
        End If
    End Sub
    Protected Sub cmbLineClosing_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles cmbLineClosing.SelectedDateChanged
        Dim LineInitiatedOn As String = cmbLineInitiatedOn.SelectedDate.ToString()
        If LineInitiatedOn = "" Then
        Else
            Dim Timespan As TimeSpan = cmbLineClosing.SelectedDate.Value.Subtract(cmbLineInitiatedOn.SelectedDate.Value)
            Dim DaysRequried As Long = Timespan.Days
            txtDaysRequired.Text = DaysRequried + 1
        End If
    End Sub
    Protected Sub cmbLineInitiatedOn_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles cmbLineInitiatedOn.SelectedDateChanged
        Dim LineClosing As String = cmbLineClosing.SelectedDate.ToString()
        If LineClosing = "" Then
        Else
            Dim Timespan As TimeSpan = cmbLineClosing.SelectedDate.Value.Subtract(cmbLineInitiatedOn.SelectedDate.Value)
            Dim DaysRequried As Long = Timespan.Days
            txtDaysRequired.Text = DaysRequried + 1
        End If
    End Sub
    Sub SaveProductionLineStatus()
        With objProductionLineStatus
            If PLSEID > 0 Then
                .PLSEID = PLSEID
            Else
                .PLSEID = 0
            End If
            .POID = cmbPONO.SelectedValue
            .CustomerID = cmbCustomer.SelectedValue
            .SupplierID = cmbSupplier.SelectedValue
            .TotalLines = txtTotalLines.Text
            .ProductionLine = txtProductionLine.Text
            .SumProduction = txtProductionDay.Text
            .SumDaysRequired = txtDaysRequired.Text
            .LineInitiatedOn = cmbLineInitiatedOn.SelectedDate
            .LineClosing = cmbLineClosing.SelectedDate
            .SaveProductionStatus()
        End With
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If PLSEID > 0 Then
            Validation()
            Response.Redirect("ProductionLineStatusView.aspx")
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        Else
            Dim dtValidate As New DataTable
            dtValidate = objProductionLineStatus.CheckExistingValue(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbPONO.SelectedValue)
            If dtValidate.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Production Entry for this PO No is already Done.")
            Else
                Validation()
                Response.Redirect("ProductionLineStatusView.aspx")
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            End If
        End If


    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/BusinessProcess/ProductionLineStatusView.aspx")
    End Sub
    Sub SaveProductionLineStatusDetail()
        Dim x As Integer
        Dim PLSDID As Integer = 0
        Dim chkSelected As CheckBox
        Dim txtBookedLines As RadNumericTextBox
        Dim Lines As Decimal = 0
        Dim BookedLines As Decimal

        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
            chkSelected = CType(dgPurchaseOrder.Items(x).FindControl("chkSelected"), CheckBox)
            If chkSelected.Checked = True Then
                txtBookedLines = CType(dgPurchaseOrder.Items(x).FindControl("txtBookedLines"), RadNumericTextBox)
                If txtBookedLines.Text = "" Then
                    BookedLines = 0
                End If
                BookedLines = Convert.ToInt32(txtBookedLines.Text)
                Lines = Lines + BookedLines

                If Lines > txtTotalLines.Text Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Booked Lines.")
                Else
                    If txtBookedLines.Text > txtTotalLines.Text Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Booked Lines.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With objProductionLineStatusDetail
                            Dim dtdetailID As New DataTable
                            dtdetailID = objProductionLineStatusDetail.GetDetailID(PLSEID)
                            If PLSEID > 0 Then
                                .PLSEID = PLSEID
                                .PLSDID = dtdetailID.Rows(0)("PLSDID")
                            Else
                                .PLSDID = 0
                                .PLSEID = objProductionLineStatus.GetId
                            End If
                            .StyleNo = item("StyleNo").Text
                            .BookedQuantity = item("BookedQuantity").Text
                            .BookedLines = txtBookedLines.Text
                            .SaveProductionStatusDetail()

                        End With
                    End If
                End If
            End If
        Next
    End Sub
    Sub Validation()
        If txtTotalLines.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Total Lines.")
        ElseIf txtProductionLine.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Production Line.")
        Else
            SaveProductionLineStatus()
            SaveProductionLineStatusDetail()
            Response.Redirect("~/BusinessProcess/ProductionLineStatusView.aspx")
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim x As Integer
        Dim txtBookedLines As RadNumericTextBox
        Dim objDataViewStyle As DataView
        Try
            dt = objProductionLineStatus.GetProductionStatusPlanningValues(PLSEID)
           
            cmbPONO.SelectedValue = dt.Rows(0)("POID")
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            cmbCustomer.Visible = False
            cmbSupplier.Visible = False
            cmbPONO.Visible = False

            txtCustomerID.Text = dt.Rows(0)("CustomerID")
            txtSuplierID.Text = dt.Rows(0)("SupplierID")
            txtPOID.Text = dt.Rows(0)("POID")
            txtCustomer.Text = dt.Rows(0)("CustomerName")
            txtSupplier.Text = dt.Rows(0)("VenderName")
            txtPONO.Text = dt.Rows(0)("PONO")
            txtPlacementDate.Text = dt.Rows(0)("PlacementDate")
            txtShipmentDate.Text = dt.Rows(0)("ShipmentDate")
            txtDaysLeft.Text = dt.Rows(0)("DaysDif")
            txtBookedQuantity.Text = dt.Rows(0)("BookedQuantity")
            txtTotalLines.Text = dt.Rows(0)("TotalLines")
            txtProductionLine.Text = dt.Rows(0)("ProductionLine")
            txtProductionDay.Text = dt.Rows(0)("SumProduction")
            txtDaysRequired.Text = dt.Rows(0)("SumDaysRequired")
            cmbLineInitiatedOn.SelectedDate = dt.Rows(0)("LineInitiatedOn")
            cmbLineClosing.SelectedDate = dt.Rows(0)("LineClosing")
            Dim dtStyleEdit As New DataTable
          
            With dtStyleEdit
                .Columns.Add("PLSDID", GetType(Long))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("BookedQuantity", GetType(Decimal))
                .Columns.Add("BookedLines", GetType(Decimal))
            End With
            For x = 0 To dt.Rows.Count - 1
                dr = dtStyleEdit.NewRow()
                dr("PLSDID") = dt.Rows(x)("PLSDID")
                dr("StyleNo") = dt.Rows(x)("StyleNo")
                dr("BookedQuantity") = dt.Rows(x)("BookedQuantity")
                dr("BookedLines") = dt.Rows(x)("BookedLines")
                dtStyleEdit.Rows.Add(dr)
            Next
            Session("dtStyleEdit") = dtStyleEdit
            objDataViewStyle = New DataView(dtStyleEdit)

            dgPurchaseOrder.DataSource = objDataViewStyle
            dgPurchaseOrder.DataBind()

            For x = 0 To dtStyleEdit.Rows.Count - 1
                Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
                txtBookedLines = CType(dgPurchaseOrder.Items(x).FindControl("txtBookedLines"), RadNumericTextBox)
                txtBookedLines.Text = dtStyleEdit.Rows(x)("BookedLines")
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
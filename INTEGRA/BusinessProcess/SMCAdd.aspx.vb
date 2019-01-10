Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class SMCAdd
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim objSMC As New SMC
    Dim MarchandID As Long
    Dim POID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MarchandID = Session("UserId")
        POID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            BindCustomer()
            Try
                If POID > 0 Then
                    cmbCustomer.Visible = False
                    cmbPONo.Visible = False
                    cmbSupplier.Visible = False
                    txtcustomer.Visible = True
                    txtPONO.Visible = True
                    txtsupplier.Visible = True
                    EditMode()
                    btnSave.Text = "Update"
                Else
                    cmbCustomer.Visible = True
                    cmbPONo.Visible = True
                    cmbSupplier.Visible = True
                    txtcustomer.Visible = False
                    txtPONO.Visible = False
                    txtsupplier.Visible = False
                    btnSave.Text = "Save"
                End If
            Catch ex As Exception

            End Try
            PageHeader("SMC")
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
        dtCustomer = objCustomer.GetPOCustomerForSMC
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            Dim dtVender As DataTable
            Dim objVendor As New Vender
            dtVender = objVendor.GetPOVendersForSMC(cmbCustomer.SelectedValue)
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
            Dt = objPurchaseOrder.GetPOForSMC(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue)
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
            Dim dtcheck As DataTable = objSMC.chkPOID(cmbPONo.SelectedValue)
            If dtcheck.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already Exist SMC.")
            Else
                Dim dtSMC As DataTable = objPurchaseOrder.GetSMCData(cmbPONo.SelectedValue)
                If dtSMC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    dgSMC.Visible = True
                    dgSMC.DataSource = dtSMC
                    dgSMC.DataBind()
                Else
                    dgSMC.Visible = False
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Record Found.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim x As Integer
        Dim CmbSMCType As RadComboBox
        Dim txtSMCPercentage As RadNumericTextBox
        Dim txtB2BStatus As RadTextBox
        Dim txtSMCUSD As RadNumericTextBox
        Try
            For x = 0 To dgSMC.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgSMC.MasterTableView.Items(x), GridDataItem)
                CmbSMCType = CType(dgSMC.Items(x).FindControl("CmbSMCType"), RadComboBox)
                txtSMCPercentage = CType(dgSMC.Items(x).FindControl("txtSMCPercentage"), RadNumericTextBox)
                txtB2BStatus = CType(dgSMC.Items(x).FindControl("txtB2BStatus"), RadTextBox)
                txtSMCUSD = CType(dgSMC.Items(x).FindControl("txtSMCUSD"), RadNumericTextBox)
                With objSMC
                    .SMCID = item("SMCID").Text
                    .POID = item("POID").Text
                    .POdetailID = item("POdetailID").Text
                    .StyleID = item("StyleID").Text
                    .StyleDetailID = item("StyleDetailID").Text
                    .UserId = MarchandID
                    .CreationDate = Date.Now
                    .B2bStatus = txtB2BStatus.Text
                    .SMCType = CmbSMCType.SelectedItem.Text
                    If txtSMCPercentage.Text = "" Then
                        .SMCDigit = 0
                    Else
                        .SMCDigit = txtSMCPercentage.Text
                    End If

                    .POStatus = item("POStatus").Text
                    .TurnOverUSD = item("TurnoverUSD").Text
                    If txtSMCUSD.Text = "" Then
                        .SMCUSD = 0
                    Else
                        .SMCUSD = txtSMCUSD.Text
                    End If
                    .SaveSMC()
                End With
            Next
        Catch ex As Exception

        End Try
        Response.Redirect("SMCView.aspx")
    End Sub
    Protected Sub txtSMCPercentage_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim txtSMCPercentage As RadNumericTextBox
        Dim txtSMCUSD As RadNumericTextBox
        Dim CmbSMCType As RadComboBox
        Dim a As Integer
        Try
            For a = 0 To dgSMC.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgSMC.MasterTableView.Items(a), GridDataItem)
                CmbSMCType = CType(dgSMC.Items(a).FindControl("CmbSMCType"), RadComboBox)
                txtSMCPercentage = CType(dgSMC.Items(a).FindControl("txtSMCPercentage"), RadNumericTextBox)
                txtSMCUSD = CType(dgSMC.Items(a).FindControl("txtSMCUSD"), RadNumericTextBox)
                If CmbSMCType.SelectedItem.Text = "Cent" Then
                    txtSMCUSD.Text = (item("Quantity").Text * txtSMCPercentage.Text)
                Else
                    txtSMCUSD.Text = (item("TurnoverUSD").Text * txtSMCPercentage.Text) / 100
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim CmbSMCType As RadComboBox
            Dim txtSMCPercentage As RadNumericTextBox
            Dim txtB2BStatus As RadTextBox
            Dim txtSMCUSD As RadNumericTextBox

            Dim dt As DataTable
            dt = objSMC.GetSMCForEdit(POID)
            txtcustomer.Text = dt.Rows(0)("CustomerName")
            txtsupplier.Text = dt.Rows(0)("Vendername")
            txtPONO.Text = dt.Rows(0)("PONO")
            dgSMC.DataSource = dt
            dgSMC.DataBind()

            For x = 0 To dt.Rows.Count - 1
                CmbSMCType = CType(dgSMC.Items(x).FindControl("CmbSMCType"), RadComboBox)
                txtSMCPercentage = CType(dgSMC.Items(x).FindControl("txtSMCPercentage"), RadNumericTextBox)
                txtB2BStatus = CType(dgSMC.Items(x).FindControl("txtB2BStatus"), RadTextBox)
                txtSMCUSD = CType(dgSMC.Items(x).FindControl("txtSMCUSD"), RadNumericTextBox)

                CmbSMCType.SelectedItem.Text = dt.Rows(x)("SMCType")
                txtSMCPercentage.Text = dt.Rows(x)("SMCDigit")
                txtB2BStatus.Text = dt.Rows(x)("B2bStatus")
                txtSMCUSD.Text = dt.Rows(x)("SMCUSD")
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
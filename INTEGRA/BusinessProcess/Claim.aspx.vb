Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class Claim
    Inherits System.Web.UI.Page
    Dim objpurchaseOrder As New PurchaseOrder
    Dim ObjClaim As New POClaim
    Dim ObjClaimDetail As New POClaimDetail
    Dim objDataView As DataView
    Dim objCurrency As New Currency
    Dim lPOClaimID As Long
    Dim Dt As New DataTable
    Dim dtClaim As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOClaimID = Request.QueryString("lPOClaimID")
        If Not Page.IsPostBack Then
            Try
                BindCustomer()
                BindCurrency()
                BindSEASON()
                BindNatureIfCliam()
                If cmbCustomer.SelectedValue > 0 Then
                    BindVendor(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
                End If
              
                'BindVendor(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
                'If cmbSupplier.SelectedValue > 0 Then
                '    BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
                'End If

                If lPOClaimID > 0 Then
                    cmbCustomer.Visible = True
                    cmbSupplier.Visible = True
                    txtcustomer.Visible = False
                    txtsupplier.Visible = False
                    cmbPONo.Visible = False
                    SetValueEdit()
                    btnSave.Text = "Update"
                Else
                    txtSettleAmountt.Text = 0
                    txtcustomer.Visible = False
                    txtsupplier.Visible = False
                    txtPONO.Visible = False
                    btnSave.Text = "Save"
                End If
            Catch objUDException As UDException
            End Try
            PageHeader("P.O Claim")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindCurrency()
        Try
            Dim dtCurrency As DataTable = objCurrency.Getalldata()
            cmbCurrency.DataSource = dtCurrency
            cmbCurrency.DataTextField = "CurrencyName"
            cmbCurrency.DataValueField = "CurrencyID"
            cmbCurrency.DataBind()
            cmbCurrency.Items(0).Text = "Dollar"
        Catch ex As Exception

        End Try
    End Sub
    Sub BindNatureIfCliam()
        Try
            Dim dtNatureofclaim As DataTable = ObjClaim.GetNatureofclaim()
            cmbNatureofClaim.DataSource = dtNatureofclaim
            cmbNatureofClaim.DataTextField = "Natureofclaim"
            cmbNatureofClaim.DataValueField = "Natureofclaimid"
            cmbNatureofClaim.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindSEASON()
        Try
            Dim dtCurrency As DataTable = ObjClaim.Getseason()
            cmbSeason.DataSource = dtCurrency
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "season"
            cmbSeason.DataBind()
           
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Dim objCustomer As New Customer
        Dim dtCustomer As DataTable
        dtCustomer = objCustomer.GetPOCustomerForClaimNew
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
        If cmbCustomer.SelectedValue > 0 Then
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            Dim item1 As New RadComboBoxItem()
            item1.Text = "Select"
            item1.Value = "0"
            cmbBuyingDept.Items.Add(item1)

        End If
       
    End Sub
    Sub BindVendor(ByVal lCustomerID As Long, ByVal lbuyingdept As String)
        Dim dtVender As DataTable
        Dim objVendor As New Vender
        dtVender = objVendor.GetPOVendersForClaimWithBuyingDeptNew(lCustomerID, lbuyingdept)
        cmbSupplier.DataSource = dtVender
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataBind()
        Dim dtCurrency As DataTable = ObjClaim.Getseason()
        cmbSeason.DataSource = dtCurrency
        cmbSeason.DataTextField = "season"
        cmbSeason.DataValueField = "season"
        cmbSeason.DataBind()
        'If cmbCustomer.SelectedValue > 0 And dtVender.Rows.Count > 0 And cmbSeason.SelectedItem.Text <> "Select Season" Then
        '    BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
        'End If

    End Sub
    Sub BindPOCombo(ByVal lBuyer As Long, ByVal lSupplier As Long, ByVal lbuyingdept As String, ByVal lSeason As String)
        Try
            Dim Dt As DataTable
            Dt = objpurchaseOrder.GetPOForClaimwithbuyingdeptNew(lBuyer, lSupplier, lbuyingdept, lSeason)
            With cmbPONo
                .DataSource = Dt
                .DataValueField = "POID"
                .DataTextField = "PONo"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
       
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            cmbCustomer.Enabled = True
            If cmbCustomer.SelectedValue > 0 Then
                BindVendor(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            End If
            
            ' BindVendor(cmbCustomer.SelectedValue)
            'cmbPONo.SelectedValue = "0"
            ''--- After selecting disable
            'cmbCustomer.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            cmbBuyingDept.Enabled = True
            If cmbCustomer.SelectedValue > 0 Then
                BindVendor(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            End If
           
            ' BindVendor(cmbCustomer.SelectedValue)
            'cmbPONo.SelectedValue = "0"
            ''--- After selecting disable
            'cmbCustomer.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            cmbSupplier.Enabled = True
            If cmbCustomer.SelectedValue > 0 Then
                BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
            End If
            
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            cmbSeason.Enabled = True
            If cmbCustomer.SelectedValue > 0 Then
                BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
            End If
            ''bindpo
            'If cmbCustomer.SelectedValue > 0 And cmbSupplier.SelectedValue > 0 Then
            '    BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
            'End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPONo.SelectedIndexChanged
        Session("objDataView") = Nothing
        Try
            objDataView = LoadData(cmbPONo.SelectedValue)
            Session("objDataView") = objDataView

            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgClaim.Visible = True
                dgClaim.DataSource = objDataView
                dgClaim.DataBind()
            Else
                dgClaim.Visible = False
            End If
            ''--- After selecting disable
            'cmbSupplier.Enabled = False
            'cmbPONo.Enabled = False
        Catch objUDException As UDException
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal lPOID As Long) As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = ObjClaim.GetCLaim(lPOID)
            objDataView = New DataView(objDataTable)
            Session("objDataTable") = objDataTable
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click
        Calculate()
    End Sub
    Sub Calculate()
        Dim txtClaimQty As RadNumericTextBox
        Dim TotalClaimPcs As Double = 0
        Dim x As Integer
        For x = 0 To dgClaim.Items.Count - 1
            txtClaimQty = CType(dgClaim.Items(x).FindControl("txtClaimPcs"), RadNumericTextBox)
            If txtClaimQty.Text = "" Then
                txtClaimQty.Text = 0
            End If
            TotalClaimPcs = TotalClaimPcs + Val(txtClaimQty.Text)
            txtTotalClaimPcs.Text = TotalClaimPcs
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim txtClaimQty As RadNumericTextBox
        Dim chkSelect As CheckBox
        Try
            If txtTotalClaimPcs.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Pcs Required.")
            ElseIf txtClaimDate.SelectedDate.ToString() = Nothing Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Date Required.")
            ElseIf txtClaimAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Amount Required.")
            ElseIf txtClaimNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim No Required.")
            ElseIf txtclaimReason.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Reason Required.")
            Else
                If lPOClaimID > 0 Then
                    SaveClaim()
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Save Successfully.")
                    Response.Redirect("ClaimView.aspx")
                Else
                    Dim ClaimNo As String = ObjClaim.checkclaimAlreadyexist(txtClaimNo.Text)
                    If ClaimNo = txtClaimNo.Text Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim No Already Exist.")
                    Else

                        Dim XSelect As Long = 0
                        Dim xx As Integer
                        For xx = 0 To dgClaim.Items.Count - 1
                            chkSelect = CType(dgClaim.Items(xx).FindControl("chkSelect"), CheckBox)
                            If chkSelect.Checked = True Then
                                XSelect = 1
                                Exit For
                            End If
                        Next

                        If XSelect = 1 Then
                            SaveClaim()
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            Response.Redirect("ClaimView.aspx")
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Any one Article")
                        End If
                      
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveClaim()
        Dim txtClaimQty As RadNumericTextBox
        Dim chkSelect As CheckBox
        Try
            Calculate()
            '----Save Claim  Master
            With ObjClaim
                .CreationDate = Now.Date
                .IsActive = True
                If lPOClaimID > 0 Then
                    .POClaimID = lPOClaimID
                Else
                    .POClaimID = 0
                End If
                .POID = cmbPONo.SelectedValue
                .ClaimAmount = txtClaimAmount.Text
                .ClaimPcs = txtTotalClaimPcs.Text
                .Currency = cmbCurrency.SelectedItem.Text
                .ClaimNo = txtClaimNo.Text
                .ClaimReason = txtclaimReason.Text
                .ClaimDate = txtClaimDate.SelectedDate
                If txtSettleAmountt.Text = 0 Then
                    .SettleAmount = 0
                Else
                    .SettleAmount = txtSettleAmountt.Text
                End If
                .buyingdept = cmbBuyingDept.SelectedItem.Text
                .season = cmbSeason.SelectedItem.Text
                .Remarks = txtremarks.Text
                .NatureofClaim = cmbNatureofClaim.SelectedItem.Text
                .JobNo = txtJobNo.Text
                .NatureofClaimid = cmbNatureofClaim.SelectedValue
                .SavePoClaim()
            End With
                '----End Save Claim  Master

                '----Save Claim  Detail
                For x = 0 To dgClaim.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgClaim.MasterTableView.Items(x), GridDataItem)
                txtClaimQty = CType(dgClaim.Items(x).FindControl("txtClaimPcs"), RadNumericTextBox)
                    chkSelect = CType(dgClaim.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        Dim ClaimEnteredQty As Decimal = txtClaimQty.Text
                        Dim POQuantity As Decimal = item("POQuantity").Text
                        With ObjClaimDetail
                            .POClaimDetailID = item("POClaimDetailID").Text
                            If lPOClaimID > 0 Then
                                .POClaimID = lPOClaimID
                            Else
                                .POClaimID = ObjClaim.GetId
                            End If
                            .PODetailID = item("PODetailID").Text
                            .StyleID = item("StyleID").Text
                            .StyleDetailID = item("StyleDetailID").Text
                            .ClaimQuantity = txtClaimQty.Text
                            .POQuantity = item("POQuantity").Text
                            .SavePOClaimDetail()
                        End With
                    End If
                Next

            '----End Save Claim  Detail
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValueEdit()
        Dim x As Integer
        Dim dr As DataRow
        Dim txtClaimPcs As RadNumericTextBox
        Dim chkSelect As CheckBox
        Try
            Dt = ObjClaim.GetValeForEdit(lPOClaimID)
            cmbCustomer.SelectedValue = Dt.Rows(0)("CustomerID")
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.SelectedValue = Dt.Rows(0)("buyingdept")
            cmbCustomer.Enabled = False
            cmbBuyingDept.Enabled = False
            cmbSeason.SelectedValue = Dt.Rows(0)("season")
            BindVendor(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            txtcustomer.Text = Dt.Rows(0)("CustomerName")
            cmbSupplier.SelectedValue = Dt.Rows(0)("SupplierID")

            cmbSupplier.Enabled = False
            cmbSeason.Enabled = False
            txtremarks.Text = Dt.Rows(0)("Remarks")
            cmbSupplier.Enabled = False
            BindPOCombo(cmbCustomer.SelectedValue, cmbSupplier.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbSeason.SelectedItem.Text)
            txtsupplier.Text = Dt.Rows(0)("VenderName")
            cmbPONo.Enabled = False
            cmbPONo.SelectedValue = Dt.Rows(0)("POID")
            txtPONO.Text = Dt.Rows(0)("PONO")
            txtcustomer.ReadOnly = True
            txtsupplier.ReadOnly = True
            txtPONO.ReadOnly = True
            cmbNatureofClaim.SelectedValue = Dt.Rows(0)("NatureofClaimid")
            txtJobNo.Text = Dt.Rows(0)("JobNo")
            ' cmbPONo.SelectedValue = Dt.Rows(0)("POID")
            If String.IsNullOrEmpty(Dt.Rows(0)("ClaimPcs").ToString()) = False Then
                txtTotalClaimPcs.Text = Dt.Rows(0)("ClaimPcs")
            Else
                txtTotalClaimPcs.Text = ""
            End If
            txtClaimDate.SelectedDate = Dt.Rows(0)("ClaimDate")

            If String.IsNullOrEmpty(Dt.Rows(0)("ClaimAmount").ToString()) = False Then
                txtClaimAmount.Text = Dt.Rows(0)("ClaimAmount")
            Else
                txtClaimAmount.Text = ""
            End If

            cmbCurrency.SelectedItem.Text = Dt.Rows(0)("Currency")

            If String.IsNullOrEmpty(Dt.Rows(0)("ClaimNo").ToString()) = False Then
                txtClaimNo.Text = Dt.Rows(0)("ClaimNo")
            Else
                txtClaimNo.Text = ""
            End If
            If String.IsNullOrEmpty(Dt.Rows(0)("ClaimReason").ToString()) = False Then
                txtclaimReason.Text = Dt.Rows(0)("ClaimReason")
            Else
                txtclaimReason.Text = ""
            End If
            txtSettleAmountt.Text = Dt.Rows(0)("SettleAmount")

            '-------------------- Detail Values
            dtClaim = Nothing
            Session("dtClaim") = Nothing
            dtClaim = New DataTable
            With dtClaim
                .Columns.Add("POClaimDetailID", GetType(Long))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("StyleDetailID", GetType(Long))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Colorway", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("POQuantity", GetType(String))

            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtClaim.NewRow()
                dr("POClaimDetailID") = Dt.Rows(x)("POClaimDetailID")
                dr("StyleID") = Dt.Rows(x)("StyleID")
                dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
                dr("PODetailID") = Dt.Rows(x)("PODetailID")

                If String.IsNullOrEmpty(Dt.Rows(x)("StyleNo").ToString()) = False Then
                    dr("StyleNo") = Dt.Rows(x)("StyleNo")
                Else
                    dr("StyleNo") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("Article").ToString()) = False Then
                    dr("Article") = Dt.Rows(x)("Article")
                Else
                    dr("Article") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("Colorway").ToString()) = False Then
                    dr("Colorway") = Dt.Rows(x)("Colorway")
                Else
                    dr("Colorway") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("SizeRange").ToString()) = False Then
                    dr("SizeRange") = Dt.Rows(x)("SizeRange")
                Else
                    dr("SizeRange") = ""
                End If

                If String.IsNullOrEmpty(Dt.Rows(x)("POQuantity").ToString()) = False Then
                    dr("POQuantity") = Dt.Rows(x)("POQuantity")
                Else
                    dr("POQuantity") = 0
                End If

                '-------------              
                dtClaim.Rows.Add(dr)
            Next
            objDataView = dtClaim.AsDataView()
            dgClaim.DataSource = objDataView
            dgClaim.DataBind()
            dgClaim.Visible = True

            For x = 0 To Dt.Rows.Count - 1
                chkSelect = CType(dgClaim.Items(x).FindControl("chkSelect"), CheckBox)
                txtClaimPcs = CType(dgClaim.Items(x).FindControl("txtClaimPcs"), RadNumericTextBox)
                chkSelect.Enabled = False
                chkSelect.Checked = True
                If String.IsNullOrEmpty(Dt.Rows(x)("POQuantity").ToString()) = False Then
                    txtClaimPcs.Text = Dt.Rows(x)("ClaimQuantity")
                Else
                    txtClaimPcs.Text = "0"
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim txtClaimQty As RadNumericTextBox
        Dim chkSelect As CheckBox
        Try
            For x = 0 To dgClaim.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgClaim.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(dgClaim.Items(x).FindControl("chkSelect"), CheckBox)
                txtClaimQty = CType(dgClaim.Items(x).FindControl("txtClaimPcs"), RadNumericTextBox)
                If chkSelect.Checked = True Then
                    txtClaimQty = CType(dgClaim.Items(x).FindControl("txtClaimPcs"), RadNumericTextBox)
                    chkSelect = CType(dgClaim.Items(x).FindControl("chkSelect"), CheckBox)
                    Dim ClaimEnteredQty As Decimal = txtClaimQty.Text
                    Dim POQuantity As Decimal = item("POQuantity").Text
                    If ClaimEnteredQty <= POQuantity Then
                        txtClaimQty.ForeColor = Drawing.Color.Black
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Else
                        txtClaimQty.ForeColor = Drawing.Color.Red
                        chkSelect.Checked = False
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim Pcs must be less then or equal to PO Quantity.")
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ClaimView.aspx")
        Catch ex As Exception

        End Try
    End Sub

   End Class
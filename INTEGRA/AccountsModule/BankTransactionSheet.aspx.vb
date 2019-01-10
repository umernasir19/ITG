Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class BankTransactionSheet
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New ChartOfAccount
    Dim objBankTransaction As New BankTransaction
    Dim objBankTransactionDetail As New BankTransactionDetail
    Dim BankTransactionID As Long
    Dim dr As DataRow
    Dim DtBankTransactionDetail As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BankTransactionID = Request.QueryString("lBankTransactionID")
        If Not Page.IsPostBack Then
            BindAccountHead()
            BindHKCode()
            BindECPCode()
            txtTransactionDate.SelectedDate = Date.Now
            txtTexTotalAmount.Text = 0
            txtTotalAmount.Text = 0
            txtTotalSum.Text = 0
            Session("DtBankTransactionDetail") = Nothing
            If BankTransactionID > 0 Then
                EditMode()
            Else
                txtIsTaxableDeduction.Text = 0
            End If
        End If
    End Sub
    Sub BindAccountHead()
        Try
            Dim dtAccountHead As DataTable
            dtAccountHead = objChartOfAccount.GetAccountHeadBankTransaction(rblTranscationType.SelectedValue)
            cmbAccountHead.DataSource = dtAccountHead
            cmbAccountHead.DataTextField = "AccountHead"
            cmbAccountHead.DataValueField = "ChartofAccountID"
            cmbAccountHead.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindHKCode()
        Try
            Dim dtHKCode As DataTable
            dtHKCode = objChartOfAccount.GetHKCode()
            cmbHKCode.DataSource = dtHKCode
            cmbHKCode.DataTextField = "HKCode"
            cmbHKCode.DataValueField = "HKCodeID"
            cmbHKCode.DataBind()
            ' cmbHKCode.Items.Add(New RadComboBoxItem("HK Code", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindECPCode()
        Try
            Dim dtECPCode As DataTable
            dtECPCode = objChartOfAccount.GetECPCode()
            cmbECPCode.DataSource = dtECPCode
            cmbECPCode.DataTextField = "ECPCode"
            cmbECPCode.DataValueField = "ECPCodeID"
            cmbECPCode.DataBind()
            'cmbECPCode.Items.Add(New RadComboBoxItem("ECP Code", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub rblTranscationType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblTranscationType.SelectedIndexChanged
        Try
            BindAccountHead()
            upcmbAccountHead.Update()
            If rblTranscationType.SelectedValue = "BPV" Then

                chkIsTax.Visible = True
                txtIsTaxableDeduction.Visible = True
                lblbank.Visible = True
                txtTexTotalAmount.Visible = True
                lblTaxChequeNo.Visible = True
                txtTexableChequeNo.Visible = True
                lblDeduction.Visible = True

                chkIsTax.Checked = True

                uptxtTexTotalAmount.Update()
                uptxtIsTaxableDeduction.Update()
                uplblDeduction.Update()
                uptxtTexableChequeNo.Update()
                uplblTaxChequeNo.Update()
                upchkIsTax.Update()
                uplblDeduction.Update()
            Else
                chkIsTax.Visible = False
                txtIsTaxableDeduction.Visible = False
                lblbank.Visible = False
                txtTexTotalAmount.Visible = False
                lblTaxChequeNo.Visible = False
                txtTexableChequeNo.Visible = False
                lblDeduction.Visible = False

                chkIsTax.Checked = False
                uptxtTexTotalAmount.Update()
                uptxtIsTaxableDeduction.Update()
                uplblDeduction.Update()
                uptxtTexableChequeNo.Update()
                uplblTaxChequeNo.Update()
                upchkIsTax.Update()
                uplblDeduction.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtIsTaxableDeduction_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtIsTaxableDeduction.TextChanged
        Try
            If txtTotalSum.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Amount, Then Proceed to Tax")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim TexAmount As Decimal = 0
                TexAmount = (Convert.ToDecimal(txtTotalSum.Text) * Convert.ToDecimal(txtIsTaxableDeduction.Text)) / 100
                txtTexTotalAmount.Text = TexAmount
                'after Text Minus this Value from Orgnl value

                'For Sum
                txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text)

                uptxtTexTotalAmount.Update()
                uptxtTotalAmount.Update()
                uptxtTotalSum.Update()
                txtTexableChequeNo.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub chkIsTax_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkIsTax.CheckedChanged
        Try
            If chkIsTax.Checked = True Then
                txtIsTaxableDeduction.Visible = True
                lblbank.Visible = True
                txtTexTotalAmount.Visible = True
                lblTaxChequeNo.Visible = True
                txtTexableChequeNo.Visible = True
                lblDeduction.Visible = True

                txtTexTotalAmount.Text = 0
                txtIsTaxableDeduction.Text = ""
                txtTexableChequeNo.Text = ""
                uptxtTexTotalAmount.Update()
                uptxtIsTaxableDeduction.Update()
                uplblDeduction.Update()
                uptxtTexableChequeNo.Update()
                uplblTaxChequeNo.Update()

                Dim TexAmount As Decimal = 0
                TexAmount = (Convert.ToDecimal(txtTotalSum.Text) * Convert.ToDecimal(txtIsTaxableDeduction.Text)) / 100
                txtTexTotalAmount.Text = TexAmount
                'after Text Minus this Value from Orgnl value
                'For Sum
                txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text)

                uptxtTexTotalAmount.Update()
                uptxtTotalAmount.Update()
                uptxtTotalSum.Update()

            Else
                txtIsTaxableDeduction.Visible = False
                lblbank.Visible = False
                txtTexTotalAmount.Visible = False
                lblTaxChequeNo.Visible = False
                txtTexableChequeNo.Visible = False
                lblDeduction.Visible = False

                txtTexTotalAmount.Text = 0
                txtIsTaxableDeduction.Text = ""
                txtTexableChequeNo.Text = ""

                uptxtTexTotalAmount.Update()
                uptxtIsTaxableDeduction.Update()
                uplblDeduction.Update()
                uptxtTexableChequeNo.Update()
                uplblTaxChequeNo.Update()

                'For Sum
                txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text) + Convert.ToDecimal(txtTotalAmount.Text)

                uptxtTexTotalAmount.Update()
                uptxtTotalAmount.Update()
                uptxtTotalSum.Update()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtTotalAmount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTotalAmount.TextChanged
        Try
            If rblTranscationType.SelectedValue = "BPV" Then
                If chkIsTax.Checked = True Then
                    If txtTotalAmount.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Amount, Then Proceed to Tax")
                    Else

                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        Dim TexAmount As Decimal = 0
                        TexAmount = (Convert.ToDecimal(txtTotalAmount.Text) * Convert.ToDecimal(txtIsTaxableDeduction.Text)) / 100
                        txtTexTotalAmount.Text = TexAmount
                        'after Text Minus this Value from Orgnl value
                        'For Sum
                        txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text) + Convert.ToDecimal(txtTotalAmount.Text)

                        uptxtTexTotalAmount.Update()
                        uptxtTotalAmount.Update()
                        uptxtTotalSum.Update()
                    End If
                Else
                    txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text) + Convert.ToDecimal(txtTotalAmount.Text)
                    uptxtTotalSum.Update()
                End If
            Else
                txtTotalSum.Text = Convert.ToDecimal(txtTotalSum.Text) + Convert.ToDecimal(txtTotalAmount.Text)
                uptxtTotalSum.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("BankTransactionSheetView.aspx?BitStatus=0")
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objBankTransaction.GetEditMode(BankTransactionID)
            txtTransactionDate.SelectedDate = dt.Rows(0)("TransactionDate")
            rblTranscationType.SelectedValue = dt.Rows(0)("TranscationType")
            CmbCurrency.SelectedValue = dt.Rows(0)("Currency")
            txtIsTaxableDeduction.Text = dt.Rows(0)("Deduction")
            chkIsTax.Checked = dt.Rows(0)("IsTaxable")
            txtTexTotalAmount.Text = dt.Rows(0)("DeductionTotalAmount1")
            txtTexableChequeNo.Text = dt.Rows(0)("TaxChequeNo")
            txtTotalSum.Text = dt.Rows(0)("TotalSumAmount1")
            cmbHKCode.SelectedValue = objBankTransaction.GetHKCodeIndex(dt.Rows(0)("HKCode"))
            cmbECPCode.SelectedValue = objBankTransaction.GetECPCodeIndex(dt.Rows(0)("ECPCode"))
            '-------------------- Detail Values
            DtBankTransactionDetail = Nothing
            Session("DtBankTransactionDetail") = Nothing
            DtBankTransactionDetail = New DataTable
            With DtBankTransactionDetail
                .Columns.Add("BankTransactionDetailID", GetType(Long))
                .Columns.Add("ChartofAccountID", GetType(Long))
                .Columns.Add("NameOfPayee", GetType(String))
                .Columns.Add("HKCode", GetType(String))
                .Columns.Add("ECPCode", GetType(String))
                .Columns.Add("Narration", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("Notes", GetType(String))
                .Columns.Add("ChequeNo", GetType(String))
                .Columns.Add("AccountHead", GetType(String))
            End With
            For x = 0 To dt.Rows.Count - 1
                dr = DtBankTransactionDetail.NewRow()
                dr("BankTransactionDetailID") = dt.Rows(x)("BankTransactionDetailID")
                dr("ChartofAccountID") = dt.Rows(x)("ChartofAccountID")
                Dim dtCA As DataTable = objChartOfAccount.GetAccountHeadName(dt.Rows(x)("ChartofAccountID"))
                dr("AccountHead") = dtCA.Rows(0)("AccountType")
                dr("NameOfPayee") = dt.Rows(x)("NameOfPayee")
                dr("HKCode") = dt.Rows(x)("HKCode")
                dr("ECPCode") = dt.Rows(x)("ECPCode")
                dr("Narration") = dt.Rows(x)("Narration")
                dr("Notes") = dt.Rows(x)("Notes")
                dr("Amount") = dt.Rows(x)("Amount1")
                dr("ChequeNo") = dt.Rows(x)("ChequeNo")
                DtBankTransactionDetail.Rows.Add(dr)
            Next
            Session("DtBankTransactionDetail") = DtBankTransactionDetail
            BindGrid()
             
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If rblTranscationType.SelectedValue = "BPV" Then
                If cmbECPCode.SelectedValue <> "" And cmbHKCode.SelectedValue <> "" And txtNameOfPayee.Text <> "" And txtNarration.Text <> "" And txtChequeNo.Text <> "" And txtTotalAmount.Text <> "" And txtTotalSum.Text <> "" Then
                    rblTranscationType.Enabled = False
                    SaveSession()
                    BindGrid()
                    ClearControls()
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill All Boxes.")
                End If
            Else
                If cmbECPCode.SelectedValue <> "" And cmbHKCode.SelectedValue <> "" And txtNameOfPayee.Text <> "" And txtNarration.Text <> "" And txtChequeNo.Text <> "" And txtTotalAmount.Text <> "" And txtTotalSum.Text <> "" Then
                    rblTranscationType.Enabled = False
                    SaveSession()
                    BindGrid()
                    ClearControls()
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill All Boxes.")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtBankTransactionDetail"), DataTable) Is Nothing) Then
            DtBankTransactionDetail = Session("DtBankTransactionDetail")
        Else
            DtBankTransactionDetail = New DataTable
            With DtBankTransactionDetail
                .Columns.Add("BankTransactionDetailID", GetType(Long))
                .Columns.Add("ChartofAccountID", GetType(Long))
                .Columns.Add("NameOfPayee", GetType(String))
                .Columns.Add("HKCode", GetType(String))
                .Columns.Add("ECPCode", GetType(String))
                .Columns.Add("Narration", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("Notes", GetType(String))
                .Columns.Add("ChequeNo", GetType(String))
                .Columns.Add("AccountHead", GetType(String))
            End With
        End If
        dr = DtBankTransactionDetail.NewRow()
        dr("BankTransactionDetailID") = 0
        dr("ChartofAccountID") = cmbAccountHead.SelectedValue
        Dim dtCA As DataTable = objChartOfAccount.GetAccountHeadName(cmbAccountHead.SelectedValue)
        dr("AccountHead") = dtCA.Rows(0)("AccountType")
        dr("NameOfPayee") = txtNameOfPayee.Text
        dr("HKCode") = cmbHKCode.SelectedItem.Text
        dr("ECPCode") = cmbECPCode.SelectedItem.Text
        dr("Narration") = txtNarration.Text
        dr("Notes") = txtNotes.Text
        dr("Amount") = txtTotalAmount.Text
        dr("ChequeNo") = txtChequeNo.Text
        DtBankTransactionDetail.Rows.Add(dr)
        Session("DtBankTransactionDetail") = DtBankTransactionDetail

    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtBankTransactionDetail")
            If objDatatble.Rows.Count > 0 Then
                dgBankTransactionDetail.Visible = True
                dgBankTransactionDetail.VirtualItemCount = objDatatble.Rows.Count
                dgBankTransactionDetail.DataSource = objDatatble
                dgBankTransactionDetail.DataBind()
            Else
                dgBankTransactionDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtNameOfPayee.Text = ""
        txtNarration.Text = ""
        txtTotalAmount.Text = ""
        txtChequeNo.Text = ""
        txtNotes.Text = ""
    End Sub
    Protected Sub btnPostthisvoucher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPostthisvoucher.Click
        Try
            If dgBankTransactionDetail.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Detail Required.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objBankTransaction
                    .BankTransactionID = BankTransactionID
                    .TransactionDate = txtTransactionDate.SelectedDate
                    .TranscationType = rblTranscationType.SelectedValue
                    .Currency = CmbCurrency.SelectedItem.Text
                    .CreationDate = Date.Now
                    If txtIsTaxableDeduction.Text = "" Then
                        .Deduction = 0
                    Else
                        .Deduction = txtIsTaxableDeduction.Text
                    End If

                    If chkIsTax.Checked = True Then
                        .IsTaxable = True
                    Else
                        .IsTaxable = False
                    End If

                    .DeductionChartofAccountID = 84

                    If rblTranscationType.SelectedValue = "BPV" Then
                        If txtTexTotalAmount.Text = "" Then
                            .DeductionTotalAmount = 0
                        Else
                            .DeductionTotalAmount = "-" + txtTexTotalAmount.Text
                        End If
                    ElseIf rblTranscationType.SelectedValue = "BRV" Then
                        If txtTexTotalAmount.Text = "" Then
                            .DeductionTotalAmount = 0
                        Else
                            .DeductionTotalAmount = txtTexTotalAmount.Text
                        End If
                    End If
                    .TaxChequeNo = txtTexableChequeNo.Text

                    If rblTranscationType.SelectedValue = "BPV" Then
                        If txtTexTotalAmount.Text = "" Then
                            .TotalSumAmount = "-" + txtTotalSum.Text
                        Else
                            If txtTotalSum.Text < 0 Then
                                .TotalSumAmount = txtTotalSum.Text
                            Else
                                .TotalSumAmount = "-" + txtTotalSum.Text
                            End If
                        End If
                    ElseIf rblTranscationType.SelectedValue = "BRV" Then
                        If txtTexTotalAmount.Text = "" Then
                            .TotalSumAmount = txtTotalSum.Text
                        Else
                            .TotalSumAmount = Convert.ToDecimal(txtTotalSum.Text)
                        End If
                    End If
                    .SaveBankTransaction()
                End With

                Dim x As Integer
                For x = 0 To dgBankTransactionDetail.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgBankTransactionDetail.MasterTableView.Items(x), GridDataItem)
                    With objBankTransactionDetail
                        If BankTransactionID > 0 Then
                            .BankTransactionID = BankTransactionID
                        Else
                            .BankTransactionID = objBankTransaction.GetId
                        End If
                        .BankTransactionDetailID = item("BankTransactionDetailID").Text
                        .ChartofAccountID = item("ChartofAccountID").Text
                        .NameOfPayee = item("NameOfPayee").Text
                        .HKCode = item("HKCode").Text
                        .ECPCode = item("ECPCode").Text
                        .Narration = item("Narration").Text
                        If rblTranscationType.SelectedValue = "BPV" Then
                            If item("Amount").Text < 0 Then
                                .Amount = item("Amount").Text
                            Else
                                .Amount = "-" + item("Amount").Text
                            End If
                        ElseIf rblTranscationType.SelectedValue = "BRV" Then
                            .Amount = item("Amount").Text
                        End If
                        .Notes = item("Notes").Text
                        .ChequeNo = item("ChequeNo").Text
                        .SaveBankTransactionDetail()
                    End With
                Next
                Response.Redirect("BankTransactionSheetView.aspx?BitStatus=1&BitMonth=" & txtTransactionDate.SelectedDate.Value.Month & "&BitYear=" & txtTransactionDate.SelectedDate.Value.Year & "")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbECPCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbECPCode.SelectedIndexChanged
        Try
            If cmbECPCode.SelectedValue = 1 Then
                cmbHKCode.SelectedValue = 1
            ElseIf cmbECPCode.SelectedValue = 2 Then
                cmbHKCode.SelectedValue = 2
            ElseIf cmbECPCode.SelectedValue = 3 Then
                cmbHKCode.SelectedValue = 3
            ElseIf cmbECPCode.SelectedValue = 4 Then
                cmbHKCode.SelectedValue = 4
            ElseIf cmbECPCode.SelectedValue = 5 Then
                cmbHKCode.SelectedValue = 5
            ElseIf cmbECPCode.SelectedValue = 6 Then
                cmbHKCode.SelectedValue = 6
            ElseIf cmbECPCode.SelectedValue = 7 Then
                cmbHKCode.SelectedValue = 7
            ElseIf cmbECPCode.SelectedValue = 8 Then
                cmbHKCode.SelectedValue = 8
            ElseIf cmbECPCode.SelectedValue = 9 Then
                cmbHKCode.SelectedValue = 9
            ElseIf cmbECPCode.SelectedValue = 10 Then
                cmbHKCode.SelectedValue = 10
            ElseIf cmbECPCode.SelectedValue = 11 Then
                cmbHKCode.SelectedValue = 11
            ElseIf cmbECPCode.SelectedValue = 12 Then
                cmbHKCode.SelectedValue = 12
            Else
                cmbHKCode.SelectedValue = 1
            End If
            upcmbHKCode.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgBankTransactionDetail_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgBankTransactionDetail.DeleteCommand
        DtBankTransactionDetail = CType(Session("DtBankTransactionDetail"), DataTable)
        If (Not DtBankTransactionDetail Is Nothing) Then
            If (DtBankTransactionDetail.Rows.Count > 0) Then
                Dim BankTransactionDetailID As Integer = DtBankTransactionDetail.Rows(e.Item.ItemIndex)("BankTransactionDetailID")
                DtBankTransactionDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objBankTransactionDetail.DeleteBankTrnDetail(BankTransactionDetailID)
                BindGrid()

            Else

            End If
        End If
    End Sub

End Class
Imports System.Data
Imports System.Data.DataTable
Imports Integra.EuroCentra
Public Class ContraVoucherAdd
    Inherits System.Web.UI.Page
    Dim Dr As DataRow
    Dim dt As DataTable
    Dim dtDetail As DataTable
    Dim ObjContraVoucherMst As New ContraVoucherMst
    Dim ObjContraVoucherDtl As New ContraVoucherDtl
    Dim lContraVoucherMstID As Long
    Dim objgeneralCode As New GeneralCode
    Dim objtblBankMst As New tblBankMst 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lContraVoucherMstID = Request.QueryString("lContraVoucherMstID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            If lContraVoucherMstID > 0 Then
                edit()
                btnSave.Text = "Update"
                btnSave.Visible = True
            Else
                BindBookAccount()
                VoucherNoGenerateOnLoad()
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
            End If
        End If
    End Sub
    Sub edit()
        Try
            Dim dt As DataTable = ObjContraVoucherMst.GetEdit(lContraVoucherMstID)
            Dim A As Boolean
            A = dt.Rows(0)("ChkDate")
            If A = True Then
                chkshowCalander.Checked = True
                txtContradate.Text = dt.Rows(0)("ContraPaymentDate")
                txtVoucherdate2.Visible = False
                txtContradate.Visible = True
                ImageButton1.Visible = True
            Else
                chkshowCalander.Checked = False
                txtVoucherdate2.Text = dt.Rows(0)("ContraPaymentDate")
                txtVoucherdate2.Visible = True
                txtContradate.Visible = False
                ImageButton1.Visible = False
            End If
            'txtContradate.Text = dt.Rows(0)("ContraPaymentDate")
            txtContraNo.Text = dt.Rows(0)("ContraNo")
            txtchkno.Text = dt.Rows(0)("ChkNo")

            BindBookAccount()
            cmbAccount.SelectedValue = dt.Rows(0)("AccountCode")

            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail

                    .Columns.Add("ContraVoucherDtlID", GetType(Long))
                    .Columns.Add("Particulars", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("Narration", GetType(String))
                    .Columns.Add("AccountCode", GetType(String))
                    .Columns.Add("DrCr", GetType(String))
                    .Columns.Add("CostCenterId", GetType(String))
                    .Columns.Add("Cost", GetType(String))
                End With
            End If

            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("ContraVoucherDtlID") = dt.Rows(0)("ContraVoucherDtlID")
                Dr("Particulars") = dt.Rows(0)("Particulars").ToUpper
                Dr("AccountCode") = dt.Rows(0)("AccountCode")
                Dr("Narration") = dt.Rows(0)("Narration")
                Dr("Amount") = dt.Rows(0)("Amount")
                Dr("DrCr") = dt.Rows(0)("DrCr")
                Dr("CostCenterId") = dt.Rows(0)("CostCenterId")
                Dr("Cost") = dt.Rows(0)("Cost")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()


            Try
                Dim DebitPv As Decimal = 0
                Dim CreditPv As Decimal = 0
                Dim DebitJV As Decimal = 0
                Dim CreditJV As Decimal = 0
                Dim DebitCV As Decimal = 0
                Dim CreditCV As Decimal = 0
                Dim DebitCONV As Decimal = 0
                Dim CreditCONV As Decimal = 0

                Dim TotalBankBalance As Decimal = 0
                Dim dtbankamount As DataTable
                Dim dtJVamount As DataTable
                Dim dtCVamount As DataTable
                Dim dtCONTamount As DataTable

                dtbankamount = objtblBankMst.GetBPVData(cmbAccount.SelectedValue)
                dtJVamount = objtblBankMst.GetJVData(cmbAccount.SelectedValue)
                dtCVamount = objtblBankMst.GetCVData(cmbAccount.SelectedValue)
                dtCONTamount = objtblBankMst.GetCCONTRData(cmbAccount.SelectedValue)

                If dtbankamount.Rows.Count > 0 Then
                    DebitPv = Convert.ToInt32(dtbankamount.Compute("SUM(Debit)", String.Empty))
                    CreditPv = Convert.ToInt32(dtbankamount.Compute("SUM(Credit)", String.Empty))
                End If
                If dtJVamount.Rows.Count > 0 Then
                    DebitJV = Convert.ToInt32(dtJVamount.Compute("SUM(Debit)", String.Empty))
                    CreditJV = Convert.ToInt32(dtJVamount.Compute("SUM(Credit)", String.Empty))
                End If
                If dtCVamount.Rows.Count > 0 Then
                    DebitCV = Convert.ToInt32(dtCVamount.Compute("SUM(Debit)", String.Empty))
                    CreditCV = Convert.ToInt32(dtCVamount.Compute("SUM(Credit)", String.Empty))
                End If
                If dtCONTamount.Rows.Count > 0 Then
                    DebitCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Debit)", String.Empty))
                    CreditCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Credit)", String.Empty))
                End If

                '----Detail AccountCode Data
                Dim dtbankamountt As DataTable
                Dim dtCVamountt As DataTable
                Dim dtContramount As DataTable

                Dim DebitPvvd As Decimal = 0
                Dim CreditPvvd As Decimal = 0
                Dim CreditCVvd As Decimal = 0
                Dim DebitCVvd As Decimal = 0
                Dim CreditConVvd As Decimal = 0
                Dim DebitConVvd As Decimal = 0

                dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
                dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
                dtContramount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)
                If dtbankamountt.Rows.Count > 0 Then
                    DebitPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                    CreditPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
                End If

                If dtCVamountt.Rows.Count > 0 Then
                    DebitCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                    CreditCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
                End If
                If dtContramount.Rows.Count > 0 Then
                    DebitConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Debit)", String.Empty))
                    CreditConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Credit)", String.Empty))
                End If





                TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV + DebitPvvd + DebitCVvd + DebitConVvd) - Val(CreditPv + CreditJV + CreditCV + CreditCONV + CreditPvvd + CreditCVvd + CreditConVvd)
                ' TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV) - Val(CreditPv + CreditJV + CreditCV + CreditCONV)
                txtBankbalance.Text = Convert.ToDecimal(TotalBankBalance).ToString("#,##0.00")

                If txtBankbalance.Text >= 0 Then
                    lblCurrBalanceCRDR.Text = "Dr"
                Else
                    lblCurrBalanceCRDR.Text = "Cr"
                End If

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Sub BindBookAccount()
        Dim dt As DataTable
        dt = ObjContraVoucherMst.BookAccountName()
        cmbAccount.DataSource = dt
        cmbAccount.DataTextField = "AccountName"
        cmbAccount.DataValueField = "AccountCode"
        cmbAccount.DataBind()
        cmbAccount.Items.Insert(0, New ListItem("Select", "0"))
        'cmbAccount.SelectedValue = 6
    End Sub
    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Try
            Dim dtAC As DataTable
            If txtAccountName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtAccountName.Text <> "" Then
                dtAC = ObjContraVoucherMst.GetUniqueAccountName(txtAccountName.Text)
                'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If

                txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                    txtAccountLevel.BackColor = Drawing.Color.LightGreen
                Else
                    txtAccountLevel.BackColor = Drawing.Color.Red
                End If

                If cmbAccount.SelectedValue = txtAccountCode.Text Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Same Account Name Not Allow")
                    txtAccountName.Text = ""
                    txtAccountLevel.Text = ""
                    txtAccountCode.Text = ""
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                End If

                '----------------For Ledger Balance
                Dim DebitPvv As Decimal = 0
                Dim CreditPvv As Decimal = 0
                Dim DebitJVv As Decimal = 0
                Dim CreditJVv As Decimal = 0

                Dim CreditCVv As Decimal = 0
                Dim DebitCVv As Decimal = 0
                Dim CreditConVv As Decimal = 0
                Dim DebitConVv As Decimal = 0

                Dim TotalLedgerBalancee As Decimal = 0
                Dim dtbankamountt As DataTable
                Dim dtJVamountt As DataTable
                Dim dtCVamountt As DataTable
                Dim dtContamount As DataTable

                dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
                dtJVamountt = objtblBankMst.GetJVDataForLedger(txtAccountCode.Text)
                dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
                dtContamount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)

                If dtbankamountt.Rows.Count > 0 Then
                    DebitPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                    CreditPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
                End If
                If dtJVamountt.Rows.Count > 0 Then
                    DebitJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Debit)", String.Empty))
                    CreditJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Credit)", String.Empty))
                End If

                If dtCVamountt.Rows.Count > 0 Then
                    DebitCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                    CreditCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
                End If
                If dtContamount.Rows.Count > 0 Then
                    DebitConVv = Convert.ToInt32(dtContamount.Compute("SUM(Debit)", String.Empty))
                    CreditConVv = Convert.ToInt32(dtContamount.Compute("SUM(Credit)", String.Empty))
                End If

                TotalLedgerBalancee = Val(DebitPvv + DebitJVv + DebitCVv + DebitConVv) - Val(CreditPvv + CreditJVv + CreditCVv + CreditConVv)
                txtLedgerBalance.Text = Convert.ToDecimal(TotalLedgerBalancee).ToString("#,##0.00")
            End If

            If txtLedgerBalance.Text >= 0 Then
                lblLedgerBalanceCRDR.Text = "Dr"
            Else
                lblLedgerBalanceCRDR.Text = "Cr"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtCostCenter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenter.TextChanged
        Try
            Dim dtAC As DataTable
            If txtCostCenter.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Cost Center")
            ElseIf txtAccountName.Text <> "" Then
                dtAC = ObjContraVoucherMst.GetUniqueCostCenter(txtCostCenter.Text)
                'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                If dtAC.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    lblCostCenterId.Text = dtAC.Rows(0)("CostCenterId")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cost Center Not Exist")
                    lblCostCenterId.Text = 0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim VoucherType As String
            Dim Voucherdate As Date
            If chkshowCalander.Checked = True Then
                Voucherdate = txtContradate.Text
            Else
                Voucherdate = txtVoucherdate2.Text
            End If

            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim Month As String = Voucherdate.Month
            Dim CodeMonth As String
            If Month = 1 Then
                CodeMonth = "01"
            ElseIf Month = 2 Then
                CodeMonth = "02"
            ElseIf Month = 3 Then
                CodeMonth = "03"
            ElseIf Month = 4 Then
                CodeMonth = "04"
            ElseIf Month = 5 Then
                CodeMonth = "05"
            ElseIf Month = 6 Then
                CodeMonth = "06"
            ElseIf Month = 7 Then
                CodeMonth = "07"
            ElseIf Month = 8 Then
                CodeMonth = "08"
            ElseIf Month = 9 Then
                CodeMonth = "09"
            Else
                CodeMonth = Month
            End If

            Dim LastVoucherNo As String = ObjContraVoucherMst.GetLastVoucherNo(Month, yearP)
            Dim PreviousMonth As Integer
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "00001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(4, 5)
                LastCode = LastVoucherNo.Substring(4, 5)
                'If PreviousMonth = Month Then
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "000" & Val(LastCode + 1)
                    Else
                        LastCode = "0000" & Val(LastCode + 1)
                    End If
                    ' LastCode = "0000" & Val(LastCode + 1)
                ElseIf LastCode < 100 Or LastCode >= 10 Then
                    If LastCode = 99 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                    'LastCode = "000" & Val(LastCode + 1)
                ElseIf LastCode < 1000 Or LastCode >= 100 Then
                    If LastCode = 999 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                    'LastCode = "00" & Val(LastCode + 1)
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If

                'LastCode = "00001"
            End If
            ' End If
            VoucherNo = "CHQ" & "-" & LastCode
            txtContraNo.Text = VoucherNo

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail

                .Columns.Add("ContraVoucherDtlID", GetType(Long))
                .Columns.Add("Particulars", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("Narration", GetType(String))
                .Columns.Add("AccountCode", GetType(String))
                .Columns.Add("DrCr", GetType(String))
                .Columns.Add("CostCenterId", GetType(String))
                .Columns.Add("Cost", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow() 
        If lbldetail.Text = "" Then
            Dr("ContraVoucherDtlID") = 0
        Else
            Dr("ContraVoucherDtlID") = lbldetail.Text
        End If
        Dr("Particulars") = txtAccountName.Text.ToUpper
        Dr("AccountCode") = txtAccountCode.Text
        If txtNarration.Text = "" Then
            Dr("Narration") = "N/A"
        Else
            Dr("Narration") = txtNarration.Text
        End If
        Dr("Amount") = txtAmount.Text
        Dr("DrCr") = lbldrcrD.Text
        Dr("CostCenterId") = lblCostCenterId.Text
        Dr("Cost") = txtCostCenter.Text
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
        BindGrid()
    End Sub
    Private Sub BindGrid()
        Dim objDatatble As DataTable
        objDatatble = Session("dtDetail")
        If objDatatble.Rows.Count > 0 Then
            dgView.Visible = True
            dgView.RecordCount = objDatatble.Rows.Count
            dgView.DataSource = objDatatble
            dgView.DataBind()
        Else
            dgView.Visible = False

        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtAccountCode.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Code Empty.")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Amount Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveSession()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbAccount.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Account Name. ")
            ElseIf dgView.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Detail Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Save()
                Response.Redirect("ContraVoucherView.aspx")
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        With ObjContraVoucherMst
            If lContraVoucherMstID > 0 Then
                .ContraVoucherMstID = lContraVoucherMstID
            Else
                .ContraVoucherMstID = 0
            End If

            If chkshowCalander.Checked = True Then
                .ContraPaymentDate = objgeneralCode.GetDate(txtContradate.Text)
            Else
                .ContraPaymentDate = objgeneralCode.GetDate(txtVoucherdate2.Text)
            End If

            ' .ContraPaymentDate = txtContradate.Text
            .Account = cmbAccount.SelectedItem.Text
            .AccountCode = cmbAccount.SelectedValue
            .ContraNo = txtContraNo.Text
            If txtchkno.Text = "" Then
                .ChkNo = ""
            Else
                .ChkNo = txtchkno.Text
            End If

            .DrCr = lbldrcrM.Text
            If chkshowCalander.Checked = True Then
                .ChkDate = True
            Else
                .ChkDate = False
            End If
            .Save()
        End With

        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            With ObjContraVoucherDtl
                .ContraVoucherDtlID = dgView.Items(x).Cells(0).Text
                If lContraVoucherMstID > 0 Then
                    .ContraVoucherMstID = lContraVoucherMstID
                Else
                    .ContraVoucherMstID = ObjContraVoucherMst.GetID()
                End If
                .Particulars = dgView.Items(x).Cells(1).Text.ToUpper
                .Narration = dgView.Items(x).Cells(3).Text.ToUpper
                .AccountCode = dgView.Items(x).Cells(4).Text.ToUpper
                Dim A As Decimal = 0
                A = dgView.Items(x).Cells(2).Text
                .Amount = A
                .DrCr = dgView.Items(x).Cells(5).Text
                .CostCenterId = dgView.Items(x).Cells(7).Text
                .SaveDetail()

            End With

        Next


    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ContraVoucherView.aspx")
    End Sub

    Protected Sub txtContradate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContradate.TextChanged
        Try
            VoucherNoGenerateOnLoad()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtVoucherdate2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherdate2.TextChanged
        Try
            VoucherNoGenerateOnLoad()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub chkshowCalander_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkshowCalander.CheckedChanged
        Try
            If chkshowCalander.Checked = True Then
                txtVoucherdate2.Visible = False
                txtContradate.Visible = True
                ImageButton1.Visible = True

            Else
                txtVoucherdate2.Visible = True
                txtContradate.Visible = False
                ImageButton1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccount.SelectedIndexChanged
        Try
            Dim DebitPv As Decimal = 0
            Dim CreditPv As Decimal = 0
            Dim DebitJV As Decimal = 0
            Dim CreditJV As Decimal = 0
            Dim DebitCV As Decimal = 0
            Dim CreditCV As Decimal = 0
            Dim DebitCONV As Decimal = 0
            Dim CreditCONV As Decimal = 0

            Dim TotalBankBalance As Decimal = 0
            Dim dtbankamount As DataTable
            Dim dtJVamount As DataTable
            Dim dtCVamount As DataTable
            Dim dtCONTamount As DataTable

            dtbankamount = objtblBankMst.GetBPVData(cmbAccount.SelectedValue)
            dtJVamount = objtblBankMst.GetJVData(cmbAccount.SelectedValue)
            dtCVamount = objtblBankMst.GetCVData(cmbAccount.SelectedValue)
            dtCONTamount = objtblBankMst.GetCCONTRData(cmbAccount.SelectedValue)

            If dtbankamount.Rows.Count > 0 Then
                DebitPv = Convert.ToInt32(dtbankamount.Compute("SUM(Debit)", String.Empty))
                CreditPv = Convert.ToInt32(dtbankamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtJVamount.Rows.Count > 0 Then
                DebitJV = Convert.ToInt32(dtJVamount.Compute("SUM(Debit)", String.Empty))
                CreditJV = Convert.ToInt32(dtJVamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtCVamount.Rows.Count > 0 Then
                DebitCV = Convert.ToInt32(dtCVamount.Compute("SUM(Debit)", String.Empty))
                CreditCV = Convert.ToInt32(dtCVamount.Compute("SUM(Credit)", String.Empty))
            End If
            If dtCONTamount.Rows.Count > 0 Then
                DebitCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Debit)", String.Empty))
                CreditCONV = Convert.ToInt32(dtCONTamount.Compute("SUM(Credit)", String.Empty))
            End If

            '----Detail AccountCode Data
            Dim dtbankamountt As DataTable
            Dim dtCVamountt As DataTable
            Dim dtContramount As DataTable

            Dim DebitPvvd As Decimal = 0
            Dim CreditPvvd As Decimal = 0
            Dim CreditCVvd As Decimal = 0
            Dim DebitCVvd As Decimal = 0
            Dim CreditConVvd As Decimal = 0
            Dim DebitConVvd As Decimal = 0

            dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
            dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
            dtContramount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)
            If dtbankamountt.Rows.Count > 0 Then
                DebitPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                CreditPvvd = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
            End If

            If dtCVamountt.Rows.Count > 0 Then
                DebitCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                CreditCVvd = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
            End If
            If dtContramount.Rows.Count > 0 Then
                DebitConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Debit)", String.Empty))
                CreditConVvd = Convert.ToInt32(dtContramount.Compute("SUM(Credit)", String.Empty))
            End If





            TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV + DebitPvvd + DebitCVvd + DebitConVvd) - Val(CreditPv + CreditJV + CreditCV + CreditCONV + CreditPvvd + CreditCVvd + CreditConVvd)
            ' TotalBankBalance = Val(DebitPv + DebitJV + DebitCV + DebitCONV) - Val(CreditPv + CreditJV + CreditCV + CreditCONV)
            txtBankbalance.Text = Convert.ToDecimal(TotalBankBalance).ToString("#,##0.00")

            If txtBankbalance.Text >= 0 Then
                lblCurrBalanceCRDR.Text = "Dr"
            Else
                lblCurrBalanceCRDR.Text = "Cr"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim ContraVoucherDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindGrid()
                            btnAdd.Visible = True



                            Try
                                Dim dtAC As DataTable
                                If txtAccountName.Text = "" Then
                                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
                                ElseIf txtAccountName.Text <> "" Then
                                    dtAC = ObjContraVoucherMst.GetUniqueAccountName(txtAccountName.Text)
                                    'AccountCode = objtblCashMst.GetUniqueAccountName(txtAccountName.Text)
                                    If dtAC.Rows.Count > 0 Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                                    Else
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                                    End If

                                    txtAccountCode.Text = dtAC.Rows(0)("AccountCode")
                                    txtAccountLevel.Text = dtAC.Rows(0)("AccountLevel").ToString() + " Account"
                                    If dtAC.Rows(0)("AccountLevel") = "Detail" Then
                                        txtAccountLevel.BackColor = Drawing.Color.LightGreen
                                    Else
                                        txtAccountLevel.BackColor = Drawing.Color.Red
                                    End If

                                    If cmbAccount.SelectedValue = txtAccountCode.Text Then
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Same Account Name Not Allow")
                                        txtAccountName.Text = ""
                                        txtAccountLevel.Text = ""
                                        txtAccountCode.Text = ""
                                    Else
                                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                                    End If

                                    '----------------For Ledger Balance
                                    Dim DebitPvv As Decimal = 0
                                    Dim CreditPvv As Decimal = 0
                                    Dim DebitJVv As Decimal = 0
                                    Dim CreditJVv As Decimal = 0

                                    Dim CreditCVv As Decimal = 0
                                    Dim DebitCVv As Decimal = 0
                                    Dim CreditConVv As Decimal = 0
                                    Dim DebitConVv As Decimal = 0

                                    Dim TotalLedgerBalancee As Decimal = 0
                                    Dim dtbankamountt As DataTable
                                    Dim dtJVamountt As DataTable
                                    Dim dtCVamountt As DataTable
                                    Dim dtContamount As DataTable

                                    dtbankamountt = objtblBankMst.GetBPVDataForLedger(txtAccountCode.Text)
                                    dtJVamountt = objtblBankMst.GetJVDataForLedger(txtAccountCode.Text)
                                    dtCVamountt = objtblBankMst.GetCVDataForLedger(txtAccountCode.Text)
                                    dtContamount = objtblBankMst.GetContraDataForLedger(txtAccountCode.Text)

                                    If dtbankamountt.Rows.Count > 0 Then
                                        DebitPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditPvv = Convert.ToInt32(dtbankamountt.Compute("SUM(Credit)", String.Empty))
                                    End If
                                    If dtJVamountt.Rows.Count > 0 Then
                                        DebitJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditJVv = Convert.ToInt32(dtJVamountt.Compute("SUM(Credit)", String.Empty))
                                    End If

                                    If dtCVamountt.Rows.Count > 0 Then
                                        DebitCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Debit)", String.Empty))
                                        CreditCVv = Convert.ToInt32(dtCVamountt.Compute("SUM(Credit)", String.Empty))
                                    End If
                                    If dtContamount.Rows.Count > 0 Then
                                        DebitConVv = Convert.ToInt32(dtContamount.Compute("SUM(Debit)", String.Empty))
                                        CreditConVv = Convert.ToInt32(dtContamount.Compute("SUM(Credit)", String.Empty))
                                    End If

                                    TotalLedgerBalancee = Val(DebitPvv + DebitJVv + DebitCVv + DebitConVv) - Val(CreditPvv + CreditJVv + CreditCVv + CreditConVv)
                                    txtLedgerBalance.Text = Convert.ToDecimal(TotalLedgerBalancee).ToString("#,##0.00")
                                End If

                                If txtLedgerBalance.Text >= 0 Then
                                    lblLedgerBalanceCRDR.Text = "Dr"
                                Else
                                    lblLedgerBalanceCRDR.Text = "Cr"
                                End If

                            Catch ex As Exception

                            End Try
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try 
            lbldetail.Text = dtDetail.Rows(dtrowNo)("ContraVoucherDtlID")
            txtAccountName.Text = dtDetail.Rows(dtrowNo)("Particulars").ToUpper
            txtAccountCode.Text = dtDetail.Rows(dtrowNo)("AccountCode")
            txtNarration.Text = dtDetail.Rows(dtrowNo)("Narration")
            txtAmount.Text = dtDetail.Rows(dtrowNo)("Amount")
            lbldrcrD.Text = dtDetail.Rows(dtrowNo)("DrCr") 
            lblCostCenterId.Text = dtDetail.Rows(dtrowNo)("CostCenterId")
            txtCostCenter.Text = dtDetail.Rows(dtrowNo)("Cost")
        Catch ex As Exception
        End Try
    End Sub
End Class

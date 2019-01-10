Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class HRPayRollGeneration
    Inherits System.Web.UI.Page
    Dim objHRMain As New HRMain
    Dim objHRPayrollGenerateTable As New HRPayrollGenerateTable
    Dim objHRPayroll As New HRPayroll
    Dim lHRID As Long
    Dim objBankTransaction As New BankTransaction
    Dim objCashTransaction As New CashTransaction
    Dim objHRPayrollHistory As New HRPayrollHistory
    Dim Dr As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Payroll Generation")

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim x As Integer
        Dim dt As New DataTable
        Dim txtDeduction As RadTextBox
        Dim txtBonus As RadTextBox
        Dim txtBasic As RadTextBox
        Dim txtConveyanceAllowance As RadTextBox
        Dim txtMobileAllowance As RadTextBox
        Dim txtMiscAllowance As RadTextBox
        Dim txtOtherAllow As RadTextBox
        Dim txtDeductionEOBI As RadTextBox
        Dim txtDeductionTax As RadTextBox
        Dim txtCheckno As RadTextBox
        Try
            dt = objHRPayrollGenerateTable.GetDataForPayrollGeneration()
            Dim objDataView As DataView
            objDataView = New DataView(dt) ' Session("objDataView")
            dgPayroll.DataSource = objDataView
            dgPayroll.DataBind()
            dgPayroll.Columns(14).Display = False
            For x = 0 To dt.Rows.Count - 1
                txtDeduction = CType(dgPayroll.Items(x).FindControl("txtDeduction"), RadTextBox)
                ' txtCheckno = CType(dgPayroll.Items(x).FindControl("txtCheckno"), RadTextBox)
                txtBonus = CType(dgPayroll.Items(x).FindControl("txtBonus"), RadTextBox)
                txtBasic = CType(dgPayroll.Items(x).FindControl("txtBasic"), RadTextBox)
                txtConveyanceAllowance = CType(dgPayroll.Items(x).FindControl("txtConveyanceAllowance"), RadTextBox)
                txtMobileAllowance = CType(dgPayroll.Items(x).FindControl("txtMobileAllowance"), RadTextBox)
                txtMiscAllowance = CType(dgPayroll.Items(x).FindControl("txtMiscAllowance"), RadTextBox)
                txtOtherAllow = CType(dgPayroll.Items(x).FindControl("txtOtherAllow"), RadTextBox)
                txtDeductionEOBI = CType(dgPayroll.Items(x).FindControl("txtDeductionEOBI"), RadTextBox)
                txtDeductionTax = CType(dgPayroll.Items(x).FindControl("txtDeductionTax"), RadTextBox)

                txtDeduction.Text = dt.Rows(x)("Deduction01")
                txtBonus.Text = dt.Rows(x)("Bonus")
                txtBasic.Text = dt.Rows(x)("Basic")
                txtConveyanceAllowance.Text = dt.Rows(x)("ConveyanceAllowance")
                txtMobileAllowance.Text = dt.Rows(x)("MobileAllowance")
                txtMiscAllowance.Text = dt.Rows(x)("MiscAllowance")
                txtOtherAllow.Text = dt.Rows(x)("OtherAllow")
                txtDeductionEOBI.Text = dt.Rows(x)("DeductionEOBI")
                txtDeductionTax.Text = dt.Rows(x)("DeductionTax")
                ' txtCheckno.Text = dt.Rows(x)("Deduction01")
            Next

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objHRPayrollGenerateTable.GetDataForPayrollGeneration()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click

        Try
            btnGenerate.Enabled = True
            Dim y As Integer
            Dim chkSelect As CheckBox
            Dim txtDeduction As RadTextBox
            Dim txtBonus As RadTextBox
            Dim CMBVoucher As RadComboBox
            Dim txtCheckno As RadTextBox
            Dim txtBasic As RadTextBox
            Dim txtConveyanceAllowance As RadTextBox
            Dim txtMobileAllowance As RadTextBox
            Dim txtMiscAllowance As RadTextBox
            Dim txtOtherAllow As RadTextBox
            Dim txtDeductionEOBI As RadTextBox
            Dim txtDeductionTax As RadTextBox

            For y = 0 To dgPayroll.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPayroll.MasterTableView.Items(y), GridDataItem)
                txtDeduction = CType(dgPayroll.Items(y).FindControl("txtDeduction"), RadTextBox)
                txtBonus = CType(dgPayroll.Items(y).FindControl("txtBonus"), RadTextBox)
                txtCheckno = CType(dgPayroll.Items(y).FindControl("txtCheckno"), RadTextBox)
                CMBVoucher = CType(dgPayroll.Items(y).FindControl("CMBVoucher"), RadComboBox)
                txtBasic = CType(dgPayroll.Items(y).FindControl("txtBasic"), RadTextBox)
                txtConveyanceAllowance = CType(dgPayroll.Items(y).FindControl("txtConveyanceAllowance"), RadTextBox)
                txtMobileAllowance = CType(dgPayroll.Items(y).FindControl("txtMobileAllowance"), RadTextBox)
                txtMiscAllowance = CType(dgPayroll.Items(y).FindControl("txtMiscAllowance"), RadTextBox)
                txtOtherAllow = CType(dgPayroll.Items(y).FindControl("txtOtherAllow"), RadTextBox)
                txtDeductionEOBI = CType(dgPayroll.Items(y).FindControl("txtDeductionEOBI"), RadTextBox)
                txtDeductionTax = CType(dgPayroll.Items(y).FindControl("txtDeductionTax"), RadTextBox)

                Dim GrossSalary As Decimal = ((Convert.ToDecimal(txtBasic.Text)) + (Convert.ToDecimal(txtConveyanceAllowance.Text)) + (Convert.ToDecimal(txtMobileAllowance.Text)) + (Convert.ToDecimal(txtOtherAllow.Text)) + (Convert.ToDecimal(txtBonus.Text)))
                item("GrossSalary").Text = GrossSalary
                item("NetSalary").Text = GrossSalary - ((Convert.ToDecimal(txtDeductionEOBI.Text)) + (Convert.ToDecimal(txtDeductionTax.Text)) + (Convert.ToDecimal(txtDeduction.Text)))

                Dim oldGrosssalarySession As Decimal = item("GrossSalary").Text
                Dim oldNetsalarySession As Decimal = item("NetSalary").Text
                Session("oldGrosssalary") = oldGrosssalarySession
                Session("oldNetsalary") = oldNetsalarySession
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBonus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBonus.Click
        Try
            dgPayroll.Columns(14).Display = True
            Dim a As Integer
            Dim txtBonus As RadTextBox
            Dim txtBasic As RadTextBox
            For a = 0 To dgPayroll.Items.Count - 1
                txtBonus = CType(dgPayroll.Items(a).FindControl("txtBonus"), RadTextBox)
                txtBasic = CType(dgPayroll.Items(a).FindControl("txtBasic"), RadTextBox)
                txtBonus.ReadOnly = False
                txtBonus.Text = txtBasic.Text / 2
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerate.Click
        Try
            Dim xx As Integer
            Dim chkSelect As CheckBox
            Dim txtDeduction As RadTextBox
            Dim txtBonus As RadTextBox
            Dim CMBVoucher As RadComboBox
            Dim txtCheckno As RadTextBox
            Dim txtBasic As RadTextBox
            Dim txtConveyanceAllowance As RadTextBox
            Dim txtMobileAllowance As RadTextBox
            Dim txtMiscAllowance As RadTextBox
            Dim txtOtherAllow As RadTextBox
            Dim txtDeductionEOBI As RadTextBox
            Dim txtDeductionTax As RadTextBox

            For xx = 0 To dgPayroll.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPayroll.MasterTableView.Items(xx), GridDataItem)
                chkSelect = CType(dgPayroll.Items(xx).FindControl("chkSelect"), CheckBox)
                txtDeduction = CType(dgPayroll.Items(xx).FindControl("txtDeduction"), RadTextBox)
                txtBonus = CType(dgPayroll.Items(xx).FindControl("txtBonus"), RadTextBox)
                txtCheckno = CType(dgPayroll.Items(xx).FindControl("txtCheckno"), RadTextBox)
                CMBVoucher = CType(dgPayroll.Items(xx).FindControl("CMBVoucher"), RadComboBox)
                txtBasic = CType(dgPayroll.Items(xx).FindControl("txtBasic"), RadTextBox)
                txtConveyanceAllowance = CType(dgPayroll.Items(xx).FindControl("txtConveyanceAllowance"), RadTextBox)
                txtMobileAllowance = CType(dgPayroll.Items(xx).FindControl("txtMobileAllowance"), RadTextBox)
                txtMiscAllowance = CType(dgPayroll.Items(xx).FindControl("txtMiscAllowance"), RadTextBox)
                txtOtherAllow = CType(dgPayroll.Items(xx).FindControl("txtOtherAllow"), RadTextBox)
                txtDeductionEOBI = CType(dgPayroll.Items(xx).FindControl("txtDeductionEOBI"), RadTextBox)
                txtDeductionTax = CType(dgPayroll.Items(xx).FindControl("txtDeductionTax"), RadTextBox)

                If chkSelect.Checked = True Then
                    Dim HRID As String = item("HRID").Text
                    Dim HRPayrollID As String = item("HRPayrollID").Text
                    Dim dtPayrollGeneratedId As New DataTable

                    Dim oldGrosssalary As Decimal = Session("oldGrosssalary")
                    Dim oldNetsalary As Decimal = Session("oldNetsalary")

                    '----Get Paroll Generated Table id 
                    dtPayrollGeneratedId = objHRPayrollGenerateTable.GetGeneratedTableId(HRPayrollID)
                    '----Updated Payroll table 
                    With objHRPayroll
                        Dim dtPRoll As New DataTable
                        dtPRoll = objHRPayroll.GetHRPayrollID(lHRID)
                        .HRID = HRID
                        .HRPayrollID = HRPayrollID
                        .Basic = txtBasic.Text
                        .ConveyanceAllowance = txtConveyanceAllowance.Text
                        .MobileAllowance = txtMobileAllowance.Text
                        .OtherAllow = txtOtherAllow.Text
                        .MiscAllowance = txtMiscAllowance.Text
                        .Bonus = txtBonus.Text
                        .Deduction01 = txtDeduction.Text
                        .DeductionTax = txtDeductionTax.Text
                        .DeductionEOBI = txtDeductionEOBI.Text
                        .GrossSalary = item("GrossSalary").Text
                        .NetSalary = item("NetSalary").Text
                        .FiscalYear = cmbFiscalYear.SelectedItem.Text
                        .TaxPercentage = ((item("GrossSalary").Text) * (txtDeductionTax.Text)) / 100
                        .CreationDate = Date.Now
                        .SaveHRPayroll()
                    End With
                    '----Updated Payroll generated table 
                    With objHRPayrollGenerateTable
                        .HRID = item("HRID").Text
                        .HRPayrollGeneratedID = 0 'dtPayrollGeneratedId.Rows(0)("HRPayrollGeneratedID")
                        .HRPayrollID = item("HRPayrollID").Text
                        .Month = CmbMonth.SelectedItem.Text
                        .Basic = txtBasic.Text
                        .ConveyanceAllowance = txtConveyanceAllowance.Text
                        .MobileAllowance = txtMobileAllowance.Text
                        .OtherAllow = txtOtherAllow.Text
                        .MiscAllowance = txtMiscAllowance.Text
                        .Bonus = txtBonus.Text
                        .Deduction01 = txtDeduction.Text
                        .DeductionTax = txtDeductionTax.Text
                        .DeductionEOBI = txtDeductionEOBI.Text
                        .GrossSalary = item("GrossSalary").Text
                        .NetSalary = item("NetSalary").Text
                        .FiscalYear = cmbFiscalYear.SelectedItem.Text
                        .TaxPercentage = ((item("GrossSalary").Text) * (txtDeductionTax.Text)) / 100
                        .CreationDate = Date.Now
                        .SaveHRPayrollGenerateTable()
                    End With

                    '--------Updated Payroll History
                    Dim NewGrosssalary As Decimal = item("GrossSalary").Text
                    Dim NewNetsalary As Decimal = item("NetSalary").Text

                    If NewGrosssalary = oldGrosssalary Or NewNetsalary = oldNetsalary Then

                    Else
                        With objHRPayrollHistory
                            Dim dtPRoll As New DataTable
                            dtPRoll = objHRPayroll.GetHRPayrollID(lHRID)
                            .HRID = item("HRID").Text
                            .HistoryID = 0
                            .HistoryDate = Date.Now()
                            .GrossSalary = NewGrosssalary
                            .Basic = txtBasic.Text
                            .ConveyanceAllowance = txtConveyanceAllowance.Text
                            .MobileAllowance = txtMobileAllowance.Text
                            .OtherAllow = txtOtherAllow.Text
                            .MiscAllowance = txtMiscAllowance.Text
                            .FiscalYear = cmbFiscalYear.SelectedItem.Text
                            .Bonus = txtBonus.Text
                            .Deduction01 = txtDeduction.Text
                            .DeductionTax = txtDeductionTax.Text
                            .DeductionEOBI = txtDeductionEOBI.Text
                            .TaxPercentage = ((NewGrosssalary * txtDeductionTax.Text) / 100)
                            .NetSalary = NewNetsalary
                            .Month = CmbMonth.SelectedItem.Text
                            .SaveHRPayrollHistory()
                        End With
                    End If
                   
                    '---------End 

                    '---Updated Bank Transaction  
                    '---Get GrossSum and net salary Currently save in Payroll and payrollGenerated tables
                    Dim dtGrossandnet As New DataTable
                    dtGrossandnet = objHRPayroll.GetGrossandNetSalary(HRID)
                    If CMBVoucher.SelectedItem.Text = "BPV" Then
                        With objBankTransaction
                            .BankTransactionID = 0
                            .TransactionDate = txtTransactiondate.SelectedDate
                            .TranscationType = CMBVoucher.SelectedItem.Text
                            '.ChartofAccountID = 13
                            '.NameOfPayee = item("EmployeeAlias").Text
                            '.HKCode = item("HKCode").Text
                            '.ECPCode = item("ECPCode").Text
                            '.Narration = "N/A"
                            '.Amount = "-" + dtGrossandnet.Rows(0)("GrossSalary").ToString()
                            '.Notes = "N/A"
                            '.ChequeNo = txtCheckno.Text
                            .CreationDate = Date.Now
                            .Currency = "PKR"
                            '.IsTaxable = True
                            If txtDeductionTax.Text = "" Then
                                .Deduction = 0
                            Else
                                .Deduction = txtDeductionTax.Text
                            End If
                            '.DeductionChartofAccountID = 84
                            'Dim deduction As String = (dtGrossandnet.Rows(0)("GrossSalary").ToString() * Convert.ToDecimal(txtDeductionTax.Text)) / 100
                            'If deduction = "" Then
                            '    .DeductionTotalAmount = 0
                            'Else
                            '    .DeductionTotalAmount = "-" + deduction
                            'End If
                            '.TaxChequeNo = "N/A"
                            'If item("GrossSalary").Text = "" Then
                            '    .TotalSumAmount = "-" + dtGrossandnet.Rows(0)("GrossSalary").ToString() + 0
                            'Else
                            '    .TotalSumAmount = "-" + dtGrossandnet.Rows(0)("GrossSalary").ToString()
                            'End If
                            .SaveBankTransaction()
                        End With
                    Else

                        '----Updated Cash Transaction 
                        With objCashTransaction
                            .CashTransactionID = 0
                            .TransactionDate = txtTransactiondate.SelectedDate
                            .TranscationType = CMBVoucher.SelectedItem.Text
                            '.ChartofAccountID = 13
                            '.NameOfPayee = item("EmployeeAlias").Text
                            '.HKCode = item("HKCode").Text
                            '.ECPCode = item("ECPCode").Text
                            '.Narration = "N/A"
                            '.Amount = "-" + dtGrossandnet.Rows(0)("GrossSalary").ToString()
                            '.Notes = "N/A"
                            .CreationDate = Date.Now
                            .SaveCashTransaction()
                        End With
                    End If
                End If
            Next
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Payroll Generated Successfully")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CmbMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CmbMonth.SelectedIndexChanged
        Dim objDataView As DataView
        Dim dtCheckMonthlySalary As DataTable
        Dim dtmonth As DataTable
        Dim ID As Long
        Dim txtDeduction As RadTextBox
        Dim txtBonus As RadTextBox
        Dim txtBasic As RadTextBox
        Dim txtConveyanceAllowance As RadTextBox
        Dim txtMobileAllowance As RadTextBox
        Dim txtMiscAllowance As RadTextBox
        Dim txtOtherAllow As RadTextBox
        Dim txtDeductionEOBI As RadTextBox
        Dim txtDeductionTax As RadTextBox
        Dim dtcheckMonth As DataTable
        Try
            '------------------------------------------------
            If (Not CType(Session("objDataView"), DataTable) Is Nothing) Then
                dtmonth = Session("objDataView")
            Else

                dtmonth = New DataTable
                With dtmonth
                    .Columns.Add("HRID", GetType(Long))
                    .Columns.Add("HRpayrollID", GetType(Long))
                    .Columns.Add("EmployeeAlias", GetType(String))
                    .Columns.Add("Designation", GetType(String))
                    .Columns.Add("DateOfJoining", GetType(String))
                    .Columns.Add("HKCode", GetType(String))
                    .Columns.Add("ECPCode", GetType(String))
                    .Columns.Add("GrossSalary", GetType(String))
                    .Columns.Add("NetSalary", GetType(Long))
                End With
            End If
            Dim x As Integer
            Dim objDataTable As DataTable
            objDataTable = objHRPayrollGenerateTable.GetDataForPayrollGeneration()
            dtcheckMonth = objHRPayrollGenerateTable.CheckMonth(CmbMonth.SelectedItem.Text)
            If dtcheckMonth.Rows.Count > 0 Then
                ' dtCheckMonthlySalary = Session("objDataView")
                If Not objDataTable Is Nothing Then
                    For x = 0 To objDataTable.Rows.Count - 1
                        ID = objDataTable.Rows(x)("HRpayrollID")
                        dtCheckMonthlySalary = objHRPayrollGenerateTable.CheckMonthlySalary(ID)
                        If dtCheckMonthlySalary.Rows.Count > 0 Then
                            lblTransactiondate.Visible = False
                            txtTransactiondate.Visible = False
                            dgPayroll.Visible = False
                            btnBonus.Visible = False
                            btnGenerate.Visible = False
                            btnCalculate.Visible = False
                        Else
                            Dr = dtmonth.NewRow()
                            Dr("HRID") = objDataTable.Rows(x)("HRID")
                            Dr("HRpayrollID") = objDataTable.Rows(x)("HRpayrollID")
                            Dr("EmployeeAlias") = objDataTable.Rows(x)("EmployeeAlias")
                            Dr("Designation") = objDataTable.Rows(x)("Designation")
                            Dr("DateOfJoining") = objDataTable.Rows(x)("DateOfJoining")
                            Dr("HKCode") = objDataTable.Rows(x)("HKCode")
                            Dr("ECPCode") = objDataTable.Rows(x)("ECPCode")
                            Dr("GrossSalary") = objDataTable.Rows(x)("GrossSalary")
                            Dr("NetSalary") = objDataTable.Rows(x)("NetSalary")
                            dtmonth.Rows.Add(Dr)
                            Session("dtmonth") = dtmonth
                        End If
                    Next
                    Dim aa As Integer
                    If dtmonth.Rows.Count > 0 Then
                        btnBonus.Visible = True
                        btnGenerate.Visible = True
                        btnCalculate.Visible = True
                        lblTransactiondate.Visible = True
                        txtTransactiondate.Visible = True
                        dgPayroll.Visible = True
                        objDataView = New DataView(Session("dtmonth"))
                        dgPayroll.DataSource = objDataView
                        dgPayroll.DataBind()
                        dgPayroll.Columns(14).Display = False
                        For aa = 0 To dtmonth.Rows.Count - 1
                            txtDeduction = CType(dgPayroll.Items(aa).FindControl("txtDeduction"), RadTextBox)
                            txtBonus = CType(dgPayroll.Items(aa).FindControl("txtBonus"), RadTextBox)
                            txtBasic = CType(dgPayroll.Items(aa).FindControl("txtBasic"), RadTextBox)
                            txtConveyanceAllowance = CType(dgPayroll.Items(aa).FindControl("txtConveyanceAllowance"), RadTextBox)
                            txtMobileAllowance = CType(dgPayroll.Items(aa).FindControl("txtMobileAllowance"), RadTextBox)
                            txtMiscAllowance = CType(dgPayroll.Items(aa).FindControl("txtMiscAllowance"), RadTextBox)
                            txtOtherAllow = CType(dgPayroll.Items(aa).FindControl("txtOtherAllow"), RadTextBox)
                            txtDeductionEOBI = CType(dgPayroll.Items(aa).FindControl("txtDeductionEOBI"), RadTextBox)
                            txtDeductionTax = CType(dgPayroll.Items(aa).FindControl("txtDeductionTax"), RadTextBox)

                            txtDeduction.Text = objDataTable.Rows(aa)("Deduction01")
                            txtBonus.Text = objDataTable.Rows(aa)("Bonus")
                            txtBasic.Text = objDataTable.Rows(aa)("Basic")
                            txtConveyanceAllowance.Text = objDataTable.Rows(aa)("ConveyanceAllowance")
                            txtMobileAllowance.Text = objDataTable.Rows(aa)("MobileAllowance")
                            txtMiscAllowance.Text = objDataTable.Rows(aa)("MiscAllowance")
                            txtOtherAllow.Text = objDataTable.Rows(aa)("OtherAllow")
                            txtDeductionEOBI.Text = objDataTable.Rows(aa)("DeductionEOBI")
                            txtDeductionTax.Text = objDataTable.Rows(aa)("DeductionTax")
                        Next
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No any Data fro Payroll Generation of " + CmbMonth.SelectedItem.Text + "   Moth")
                    End If

                End If
            Else
                ' objDataView = LoadData()
                ' Session("objDataView") = objDataView
                BindGrid()
                btnBonus.Visible = True
                btnGenerate.Visible = True
                btnCalculate.Visible = True
                lblTransactiondate.Visible = True
                txtTransactiondate.Visible = True
                dgPayroll.Visible = True
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            End If
            '--------------------------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtTransactiondate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtTransactiondate.SelectedDateChanged
        Try
            btnCalculate.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
End Class
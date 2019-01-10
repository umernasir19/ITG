Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LoanRequest
    Inherits System.Web.UI.Page
    Dim objLoanmaster As New LoanMaster
    Dim objLoanDetail As New LoanDetail
    Dim objHRMain As New HRMain
    Dim dtLoan As New DataTable
    Dim lHRID As Long
    Dim lLoanMasterID As Long
    Dim objUser As New EuroCentra.User
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lLoanMasterID = Request.QueryString("lLoanMasterID")
        If Not Page.IsPostBack Then
            If lLoanMasterID > 0 Then
                SetValueEdit()
                btnSave.Text = "Update"
                btnSave.Visible = False
            Else
                PageHeader("Loan Request")
                GetLoanInformation()
                btnSave.Visible = False
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub GetLoanInformation()
        Try
            Dim dtUser As DataTable = objUser.GetUSerInfoNew(CLng(Session("Userid")))
            lHRID = dtUser.Rows(0)("EmployeeId")
            Dim objdt As DataTable = objHRMain.GetInformationForLoan(lHRID)
            If objdt.Rows.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You are not authorized for Loan.")
                btncancel.Visible = False
                pnlinfo.Visible = False
            Else
                txtUserName.Text = objdt.Rows(0)("EmployeeName")
                txtCnicNo.Text = objdt.Rows(0)("NICNo")
                btncancel.Visible = True
                pnlinfo.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerate.Click
        Try
            '--When Edit First Delete from Detail New Generate Loan
            If lLoanMasterID > 0 Then
                objLoanmaster.DeleteFromLoan(lLoanMasterID)
            Else

            End If
            Session.Remove("dtLoan")
            SaveSession()
            BindGrid()
            btnSave.Visible = True
            'Session.Remove("dtLoan")
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        Try
            If (Not CType(Session("dtLoan"), DataTable) Is Nothing) Then
                dtLoan = Session("dtLoan")
            Else
                dtLoan = New DataTable
                With dtLoan
                    .Columns.Add("LoanDetailID", GetType(Long))
                    .Columns.Add("InstallmentAmount", GetType(Decimal))
                    .Columns.Add("InstallmentYear", GetType(Decimal))
                    .Columns.Add("InstallmentMonth", GetType(String))
                    .Columns.Add("LoanOutStatnding", GetType(Decimal))
                    .Columns.Add("InstallmentMonthYear", GetType(String))
                End With
            End If
            Dim x As Integer
            Dim dr As DataRow
            Dim Month As Integer = cmbMonth.SelectedValue
            Dim TotalMontInstallment As Integer = txtInstallmentMonthPeriod.Text
            Dim monthnumber As Integer = cmbMonth.SelectedValue
            Dim year As String = cmbYear.SelectedItem.Text
            Dim OutstandingAmount As Decimal
            For x = 0 To TotalMontInstallment
                dr = dtLoan.NewRow()
                If x = 0 Then
                    dr("LoanDetailID") = 0
                    dr("InstallmentMonth") = cmbMonth.SelectedValue
                    dr("InstallmentYear") = cmbYear.SelectedItem.Text
                    dr("InstallmentAmount") = txtMonthlyInstallment.Text
                    dr("LoanOutStatnding") = Val(txtPrincipalAmount.Text) - Val(txtMonthlyInstallment.Text)
                    dr("InstallmentMonthYear") = cmbMonth.SelectedItem.Text & ", " & cmbYear.SelectedItem.Text
                    OutstandingAmount = Val(txtPrincipalAmount.Text) - Val(txtMonthlyInstallment.Text)
                Else
                    Dim Monthname As String
                    monthnumber = monthnumber + 1
                    If monthnumber > 12 Then
                        monthnumber = 1
                        year = year + 1
                    Else

                    End If
                    dr("LoanDetailID") = 0
                    dr("InstallmentYear") = year
                    dr("InstallmentAmount") = txtMonthlyInstallment.Text

                    If monthnumber = 1 Then
                        Monthname = "January"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 2 Then
                        Monthname = "February"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 3 Then
                        Monthname = "March"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 4 Then
                        Monthname = "April"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 5 Then
                        Monthname = "May"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 6 Then
                        Monthname = "June"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 7 Then
                        Monthname = "July"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 8 Then
                        Monthname = "August"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 9 Then
                        Monthname = "September"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 10 Then
                        Monthname = "October"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 11 Then
                        Monthname = "November"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    ElseIf monthnumber = 12 Then
                        Monthname = "December"
                        dr("InstallmentMonth") = monthnumber
                        dr("InstallmentMonthYear") = Monthname & ", " & year
                    End If
                   
                    dr("LoanOutStatnding") = OutstandingAmount - Val(txtMonthlyInstallment.Text)
                    OutstandingAmount = OutstandingAmount - Val(txtMonthlyInstallment.Text)
                End If
                If OutstandingAmount < 0 Then
                    Exit For
                Else
                    dtLoan.Rows.Add(dr)
                End If
            Next
            Session("dtLoan") = dtLoan
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        dtLoan = Session("dtLoan")
        If (Not dtLoan Is Nothing) Then
            If (dtLoan.Rows.Count > 0) Then
                dgLoan.DataSource = dtLoan
                dgLoan.DataBind()
                dgLoan.Visible = True
                Return (True)
            End If
            Session.Remove("dtLoan")
        End If
        Return (False)
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveLoanMaster()
            SaveLoanDetail()
            Response.Redirect("LoanView.aspx")
        Catch ex As Exception

        End Try
        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Loan Successfully.")
    End Sub
    Sub SaveLoanMaster()
        Try
            With objLoanmaster
                If lLoanMasterID > 0 Then
                    .LoanMasterID = lLoanMasterID
                Else
                    .LoanMasterID = 0
                End If
                Dim dtUser As DataTable = objUser.GetUSerInfoNew(CLng(Session("Userid")))
                lHRID = dtUser.Rows(0)("EmployeeId")
                .HRID = lHRID
                .CreationDate = Date.Now
                .PrincipalAmount = txtPrincipalAmount.Text
                .InstallmentAmount = txtMonthlyInstallment.Text
                .TotalInstallmenMonth = txtInstallmentMonthPeriod.Text
                .InstallmentYearFrom = cmbYear.SelectedItem.Text
                .InstallmentMonthFrom = cmbMonth.SelectedValue
                .Status = 0
                .SaveLoanMaster()

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveLoanDetail()
        Try
            Dim x As Integer
            For x = 0 To dgLoan.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgLoan.MasterTableView.Items(x), GridDataItem)
                With objLoanDetail
                    .LoanDetailID = 0
                    .LoanMasterID = objLoanmaster.GetId
                    .InstallmentAmount = item("InstallmentAmount").Text
                    .InstallmentYear = item("InstallmentYear").Text
                    .InstallmentMonth = item("InstallmentMonth").Text
                    .LoanOutStatnding = item("LoanOutStatnding").Text
                    .SaveLoanDetail()

                End With

            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtInstallmentMonthPeriod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtInstallmentMonthPeriod.TextChanged
        Try
            txtMonthlyInstallment.Text = (txtPrincipalAmount.Text) / (txtInstallmentMonthPeriod.Text)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncancel.Click
        Try
            Response.Redirect("LoanView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValueEdit()
        Dim Dtedit As New DataTable
        Dim dr As DataRow
        Dim dtLoanEdit As DataTable
        Try
            Dtedit = objLoanmaster.GetValeForEdit(lLoanMasterID)
            txtUserName.Text = Dtedit.Rows(0)("EmployeeName")
            txtCnicNo.Text = Dtedit.Rows(0)("NICNo")
            txtPrincipalAmount.Text = Dtedit.Rows(0)("PrincipalAmount")
            txtMonthlyInstallment.Text = Dtedit.Rows(0)("InstallmentAmount")
            txtInstallmentMonthPeriod.Text = Dtedit.Rows(0)("TotalInstallmenMonth")
            cmbYear.SelectedItem.Text = Dtedit.Rows(0)("InstallmentYearFrom")
            cmbMonth.SelectedValue = Dtedit.Rows(0)("InstallmentMonthFrom")

            Dim i As Integer
            dtLoanEdit = Nothing
            Session("DteditLoan") = Nothing
            dtLoanEdit = New DataTable
            With dtLoanEdit
                .Columns.Add("LoanDetailID", GetType(Long))
                .Columns.Add("InstallmentAmount", GetType(Decimal))
                .Columns.Add("InstallmentYear", GetType(Decimal))
                .Columns.Add("InstallmentMonth", GetType(String))
                .Columns.Add("LoanOutStatnding", GetType(Decimal))
                .Columns.Add("InstallmentMonthYear", GetType(String))
            End With
            For i = 0 To Dtedit.Rows.Count - 1
                dr = dtLoanEdit.NewRow()
                dr("LoanDetailID") = Dtedit.Rows(i)("LoanDetailID")
                dr("InstallmentYear") = Dtedit.Rows(i)("InstallmentYear")
                dr("InstallmentAmount") = Dtedit.Rows(i)("InstallmentAmount")
                dr("LoanOutStatnding") = Dtedit.Rows(i)("LoanOutStatnding")

                Dim MontNumberonedit As Integer = Dtedit.Rows(i)("InstallmentMonth")
                Dim MonthnameOnEdit As String

                If MontNumberonedit = 1 Then
                    MonthnameOnEdit = "January"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 2 Then
                    MonthnameOnEdit = "February"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 3 Then
                    MonthnameOnEdit = "March"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 4 Then
                    MonthnameOnEdit = "April"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 5 Then
                    MonthnameOnEdit = "May"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 6 Then
                    MonthnameOnEdit = "June"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 7 Then
                    MonthnameOnEdit = "July"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 8 Then
                    MonthnameOnEdit = "August"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 9 Then
                    MonthnameOnEdit = "September"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 10 Then
                    MonthnameOnEdit = "October"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 11 Then
                    MonthnameOnEdit = "November"
                    dr("InstallmentMonth") = MontNumberonedit
                ElseIf MontNumberonedit = 12 Then
                    MonthnameOnEdit = "December"
                    dr("InstallmentMonth") = MontNumberonedit
                End If
                dr("InstallmentMonthYear") = MonthnameOnEdit & ", " & Dtedit.Rows(i)("InstallmentYear")
                dtLoanEdit.Rows.Add(dr)
            Next
            Session("dtLoan") = dtLoanEdit
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub

End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports Telerik.Web.UI.DrivingLicences
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Imports Telerik.Web.UI.Upload
Imports System.Collections.Generic
Public Class HRMainAdd
    Inherits System.Web.UI.Page
    Dim objHRMain As New HRMain
    Dim objHRLanguage As New HRLanguage
    Dim objHRHealthCare As New HRHealthCare
    Dim objHRPayroll As New HRPayroll
    Dim objHRPayrollGenerateTable As New HRPayrollGenerateTable
    Dim objHRLeaveTable As New HRLeaveTable
    Dim objHRLeaveHistory As New HRLeaveHistory
    Dim objHRCostControl As New HRCostControl
    Dim objHRPayrollHistory As New HRPayrollHistory
    Dim lHRID As Long
    Dim Dt As New DataTable
    Dim DtLanguage As New DataTable
    Dim dtClaim As New DataTable
    Dim OldGrossSum As Decimal
    Dim OldNetSalory As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lHRID = Request.QueryString("lHRID")
        If Not Page.IsPostBack Then
            If lHRID > 0 Then
                SetValueEdit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BindLanguage()
        Try
            Dim dtLanguage As DataTable
            dtLanguage = objHRLanguage.GetLanguage()
            cmbLanguages.DataSource = dtLanguage
            cmbLanguages.DataTextField = "Languages"
            cmbLanguages.DataValueField = "LanguageID"
            cmbLanguages.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveHRMain()
            SaveHRLanguage()
            SaveHRHealthCare()
            SaveHRPayroll()
            SaveHRPayrollGenerateTable()
            SaveHRLeaveTable()
            SaveHRLeaveHistory()
            SaveHRCostControl()
            SaveHistory()
            Response.Redirect("HRMainView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveHRMain()
        Try
            With objHRMain
                If lHRID > 0 Then
                    .HRID = lHRID
                Else
                    .HRID = 0
                End If
                .HRCode = 0
                .HRCode = txtHRCode.Text
                .EmployeeName = txtFullName.Text
                .EmployeeAlias = txtSurname.Text
                .PrincipalDepartment = 0
                .PrincipalGroup = txtPrincipalGroup.Text
                .HKCode = txtHKCode.Text
                .ECPCode = txtECPCode.Text
                .Designation = txtDesignation.Text
                .PostedAt = txtPostedat.Text
                .DateOfBirth = txtDateOfBirth.SelectedDate

                If txtDateofJoining.SelectedDate Is Nothing Then
                    .DateOfJoining = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .DateOfJoining = txtDateofJoining.SelectedDate
                End If
                .Nationality = cmbNationality.SelectedItem.Text
                .NICNo = txtCNIC.Text
                If txtCNICValidity.SelectedDate Is Nothing Then
                    .NICExpiryDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .NICExpiryDate = txtCNICValidity.SelectedDate
                End If
                .PassportNo = txtPassport.Text
                If txtPassportValidity.SelectedDate Is Nothing Then
                    .PassportExpirtyDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .PassportExpirtyDate = txtPassportValidity.SelectedDate
                End If
                .DrivingLicenseNo = txtDrivingLicense.Text
                If txtDrivingLicenseValidity.SelectedDate Is Nothing Then
                    .DrivingLicenseExpiryDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .DrivingLicenseExpiryDate = txtDrivingLicenseValidity.SelectedDate
                End If
                .InsurancePolicyNo = txtInsurancePolicy.Text
                .DrivingLicenseNo = txtDrivingLicense.Text

                If txtInsurancePolicyValidity.SelectedDate Is Nothing Then
                    .PolicyExpiryDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .PolicyExpiryDate = txtInsurancePolicyValidity.SelectedDate
                End If
                .NTNNo = txtNTNNo.Text
                .ComputerSkills = txtComputerSkills.Text
                .Capabilities = "N/A"   '-----= txtTechnicalSkills.Text
                .Product = "N/A"
                .ResidenceLine1 = txtResidenceAddress.Text
                .ResidenceLine2 = txtResidenceAddress2.Text
                .ResidenceTelephone = txtResidencePhoneNo.Text
                .EmployeeCellNo = txtCellNo.Text
                .EmployeeEmailId = 0
                .EmployeeEmailidSecondary = "ass@yahoo.com"
                .EmergencyContactNo = txtEmergencyContactNo.Text
                .MarriedStatus = cmbMaternalStatus.SelectedItem.Text
                .NexttoKin = txtNexttokin.Text
                .EmployeeEducation = "N/A"
                .EmployeeLastDegree = txtLastDegree.Text
                .LastDegreeYear = txtLastDegreeYear.Text
                .EmployeeBankAccountNo = txtBankAccountNo.Text
                ' .EmployeeImage = "hhhh"
                ' .NICImage = "hhhh"
                '  .PassportImage = "hhhh"
                '  .DrivingLicense = "hhhh"

                If lHRID > 0 Then
                    If imgEmployee.FileName = "" Then
                        .EmployeeImage = objHRMain.GetimgEployee(lHRID)
                    Else
                        System.IO.Directory.Delete(Server.MapPath("~/HRImages/" & lHRID & "/Employee"), True)
                        Dim di111 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & lHRID & "/Employee"))
                        di111.Create()
                        imgEmployee.SaveAs(Server.MapPath("~/HRImages/" & lHRID & "/Employee/" & imgEmployee.FileName))
                        .EmployeeImage = "HRImages/" & lHRID & "/Employee/" & imgEmployee.FileName
                        'System.IO.Directory.Delete(Server.MapPath("~/CustomerImages/" & lCustomerID & "/logo"), True)
                        'Dim di11 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/CustomerImages/" & lCustomerID & "/logo"))
                        'di11.Create()
                        'txtLogo.SaveAs(Server.MapPath("~/CustomerImages/" & lCustomerID & "/Logo/" & txtLogo.FileName))
                        '.imgOriginalLogo = "CustomerImages/" & lCustomerID & "/Logo/" & txtLogo.FileName
                    End If
                    If imgCNIC.FileName = "" Then
                        .NICImage = objHRMain.GetimgCNIC(lHRID)
                    Else
                        System.IO.Directory.Delete(Server.MapPath("~/HRImages/" & lHRID & "/CNIC"), True)
                        Dim di11 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & lHRID & "/CNIC"))
                        di11.Create()
                        imgCNIC.SaveAs(Server.MapPath("~/HRImages/" & lHRID & "/CNIC/" & imgCNIC.FileName))
                        .NICImage = "HRImages/" & lHRID & "/CNIC/" & imgCNIC.FileName

                    End If
                    If imgPassport.FileName = "" Then
                        .PassportImage = objHRMain.GetimgPasport(lHRID)
                    Else
                        System.IO.Directory.Delete(Server.MapPath("~/HRImages/" & lHRID & "/Pasport"), True)
                        Dim di22 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & lHRID & "/Pasport"))
                        di22.Create()
                        imgPassport.SaveAs(Server.MapPath("~/HRImages/" & lHRID & "/Pasport/" & imgPassport.FileName))
                        .PassportImage = "HRImages/" & lHRID & "/Pasport/" & imgPassport.FileName

                    End If
                    If ImgDrivingLicense.FileName = "" Then
                        .DrivingLicense = objHRMain.GetimgDrivinfLicence(lHRID)
                    Else
                        System.IO.Directory.Delete(Server.MapPath("~/HRImages/" & lHRID & "/DrivingLicences"), True)
                        Dim di33 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & lHRID & "/DrivingLicences"))
                        di33.Create()
                        ImgDrivingLicense.SaveAs(Server.MapPath("~/HRImages/" & lHRID & "/DrivingLicences/" & ImgDrivingLicense.FileName))
                        .DrivingLicense = "HRImages/" & lHRID & "/DrivingLicences/" & ImgDrivingLicense.FileName

                    End If
                Else
                    Dim HRID As Long = Convert.ToInt32(objHRMain.GetId) + 1
                    If (Directory.Exists(Server.MapPath("~/HRImages/" & HRID & ""))) Then
                        ' imgCNIC.SaveAs(Server.MapPath("~/HRImages/" & HRID & "/CNIC/" & imgCNIC.FileName))
                        'Edit work not done
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & HRID & ""))
                        di.Create()
                        Dim dii As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & HRID & "/Employee"))
                        dii.Create()
                        Dim di1 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & HRID & "/CNIC"))
                        di1.Create()
                        Dim di2 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & HRID & "/Pasport"))
                        di2.Create()
                        Dim di3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/HRImages/" & HRID & "/DrivingLicences"))
                        di3.Create()

                        If imgEmployee.FileName = "" Then
                            File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/HRImages/" & HRID & "/Employee/no-image.jpg"))
                            .EmployeeImage = "HRImages/" & HRID & "/Employee/no-image.jpg"

                            'File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/CustomerImages/" & CurrentCustomerID & "/Logo/no-image.jpg"))
                            '.imgOriginalLogo = "CustomerImages/" & CurrentCustomerID & "/Logo/no-image.jpg"
                        Else
                            imgEmployee.SaveAs(Server.MapPath("~/HRImages/" & HRID & "/Employee/" & imgEmployee.FileName))
                            .EmployeeImage = "HRImages/" & HRID & "/Employee/" & imgEmployee.FileName

                        End If

                        If imgCNIC.FileName = "" Then
                            File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/HRImages/" & HRID & "/CNIC/no-image.jpg"))
                            .NICImage = "HRImages/" & HRID & "/CNIC/no-image.jpg"
                        Else
                            imgCNIC.SaveAs(Server.MapPath("~/HRImages/" & HRID & "/CNIC/" & imgCNIC.FileName))
                            .NICImage = "HRImages/" & HRID & "/CNIC/" & imgCNIC.FileName
                        End If

                        If imgPassport.FileName = "" Then
                            File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/HRImages/" & HRID & "/Pasport/no-image.jpg"))
                            .PassportImage = "HRImages/" & HRID & "/Pasport/no-image.jpg"
                        Else
                            imgPassport.SaveAs(Server.MapPath("~/HRImages/" & HRID & "/Pasport/" & imgPassport.FileName))
                            .PassportImage = "HRImages/" & HRID & "/Pasport/" & imgPassport.FileName
                        End If
                        If ImgDrivingLicense.FileName = "" Then
                            File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/HRImages/" & HRID & "/DrivingLicences/no-image.jpg"))
                            .DrivingLicense = "HRImages/" & HRID & "/DrivingLicences/no-image.jpg"
                        Else
                            ImgDrivingLicense.SaveAs(Server.MapPath("~/HRImages/" & HRID & "/DrivingLicences/" & ImgDrivingLicense.FileName))
                            .DrivingLicense = "HRImages/" & HRID & "/DrivingLicences/" & ImgDrivingLicense.FileName
                        End If
                    End If

                End If
                .IsActive = True
                .TechnicalSkills = txtTechnicalSkills.Text
                .SaveHRMain()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRLanguage()
        Try
            Dim x As Integer
            For x = 0 To cmbLanguages.CheckedItems.Count - 1
                With objHRLanguage
                    If lHRID > 0 Then
                        .HRID = lHRID
                        .LanguageID = 0
                    Else
                        .HRID = objHRMain.GetId
                        .LanguageID = 0
                    End If
                    .Languages = cmbLanguages.CheckedItems(x).Text
                    .SaveHRLanguage()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRHealthCare()
        Try
            With objHRHealthCare
                Dim dtHC As New DataTable
                dtHC = objHRHealthCare.GetHealthCareID(lHRID)
                If lHRID > 0 Then
                    .HRID = lHRID
                    .HRHealthcareID = dtHC.Rows(0)("HRHealthcareID")
                Else
                    .HRID = objHRMain.GetId
                    .HRHealthcareID = 0
                End If
                .EmployeeEyeSight = txtEyeSight.Text
                .EmployeeBloodGroup = txtBloodGroup.Text
                .EmployeeAllergic = txtAllergic.Text
                .EmployeeBloodPressure = cmbBloodPressure.SelectedItem.Text
                .EmployeeSugarLevel = cmbSugarLevel.SelectedItem.Text
                .EmployeeIsSmoke = cmbIsSmoke.SelectedItem.Text
                .EmployeeFamilyDoctorName = txtFaimalyDoctorName.Text
                .EmployeeFamilyDoctorNo = txtFamilyDoctorContact.Text
                If txtLastPhysicalCheckup.SelectedDate Is Nothing Then
                    .EmployeeLastPhysicalCheckupDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .EmployeeLastPhysicalCheckupDate = txtLastPhysicalCheckup.SelectedDate
                End If
                If txtLastDentalCheckup.SelectedDate Is Nothing Then
                    .EmployeeLastDentalCheckupDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .EmployeeLastDentalCheckupDate = txtLastDentalCheckup.SelectedDate
                End If
                If txtEmployeeLastVacationDate.SelectedDate Is Nothing Then
                    .EmployeeLastVacationDate = Convert.ToDateTime("1900-11-11 00:00:00.000")
                Else
                    .EmployeeLastVacationDate = txtEmployeeLastVacationDate.SelectedDate
                End If
                .EmployeeCriticalDiagonasis = txtCriticalDiagonasis.Text
                .SaveHRHealthCare()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRPayroll()
        Try
            '--Get Old grossSum and netsalary to maintain history saving
            If lHRID > 0 Then
                Dim dthistory As New DataTable
                dthistory = objHRPayroll.GetAmount(lHRID)
                OldGrossSum = dthistory.Rows(0)("GrossSalary")
                OldNetSalory = dthistory.Rows(0)("NetSalary")
            Else
            End If
            '---Endd
            '-----Some logice use Pending
            With objHRPayroll
                Dim dtPRoll As New DataTable
                dtPRoll = objHRPayroll.GetHRPayrollID(lHRID)
                If lHRID > 0 Then
                    .HRID = lHRID
                    .HRPayrollID = dtPRoll.Rows(0)("HRPayrollID")
                Else
                    .HRID = objHRMain.GetId
                    .HRPayrollID = 0
                End If
                If txtBasic.Text = "" Then
                    .Basic = 0
                Else
                    .Basic = txtBasic.Text
                End If
                If txtConvAllowance.Text = "" Then
                    .ConveyanceAllowance = 0
                Else
                    .ConveyanceAllowance = txtConvAllowance.Text
                End If
                If txtMobileAllowance.Text = "" Then
                    .MobileAllowance = 0
                Else
                    .MobileAllowance = txtMobileAllowance.Text
                End If
                If txtOtherAllowance.Text = "" Then
                    .OtherAllow = 0
                Else
                    .OtherAllow = txtOtherAllowance.Text
                End If
                If txtLeaveFiscalYear.Text = "" Then
                    .FiscalYear = 0
                Else
                    .FiscalYear = txtLeaveFiscalYear.Text
                End If
                If txtMiscAllowance.Text = "" Then
                    .MiscAllowance = 0
                Else
                    .MiscAllowance = txtMiscAllowance.Text
                End If
                .Bonus = 0
                .GrossSalary = txtGrossSum.Text

                If txtOther.Text = "" Then
                    .Deduction01 = 0
                Else
                    .Deduction01 = txtOther.Text
                End If
                If txtTax.Text = "" Then
                    .DeductionTax = 0
                Else

                    .DeductionTax = txtTax.Text
                End If
                .TaxPercentage = ((txtGrossSum.Text) * (txtTax.Text)) / 100
                If txtEOBI.Text = "" Then
                    .DeductionEOBI = 0
                Else
                    .DeductionEOBI = txtEOBI.Text
                End If
                .NetSalary = txtNetSalary.Text
                .CreationDate = Date.Now
                .SaveHRPayroll()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRPayrollGenerateTable()
        Try
            With objHRPayrollGenerateTable
                Dim dtHRPayrollGenerateTable As New DataTable
                dtHRPayrollGenerateTable = objHRPayrollGenerateTable.GetHRPayrollGenerateTableID(lHRID)
                If lHRID > 0 Then
                    .HRID = lHRID
                    .HRPayrollID = dtHRPayrollGenerateTable.Rows(0)("HRPayrollID")
                    .HRPayrollGeneratedID = dtHRPayrollGenerateTable.Rows(0)("HRPayrollGeneratedID")
                Else
                    .HRID = objHRMain.GetId
                    .HRPayrollGeneratedID = 0
                    .HRPayrollID = objHRPayroll.GetId
                End If
                .Month = "N/A"

                If txtBasic.Text = "" Then
                    .Basic = 0
                Else
                    .Basic = txtBasic.Text
                End If

                If txtConvAllowance.Text = "" Then
                    .ConveyanceAllowance = 0
                Else
                    .ConveyanceAllowance = txtConvAllowance.Text
                End If

                If txtMobileAllowance.Text = "" Then
                    .MobileAllowance = 0
                Else
                    .MobileAllowance = txtMobileAllowance.Text
                End If

                If txtOtherAllowance.Text = "" Then
                    .OtherAllow = 0
                Else
                    .OtherAllow = txtOtherAllowance.Text
                End If

                If txtMiscAllowance.Text = "" Then
                    .MiscAllowance = 0
                Else
                    .MiscAllowance = txtMiscAllowance.Text
                End If

                .Bonus = 0
                .GrossSalary = txtGrossSum.Text
                If txtOther.Text = "" Then
                    .Deduction01 = 0
                Else
                    .Deduction01 = txtOther.Text
                End If

                If txtTax.Text = "" Then
                    .DeductionTax = 0
                Else
                    .DeductionTax = txtTax.Text
                End If
                .TaxPercentage = ((txtGrossSum.Text) * (txtTax.Text)) / 100

                If txtEOBI.Text = "" Then
                    .DeductionEOBI = 0
                Else
                    .DeductionEOBI = txtEOBI.Text
                End If
                .NetSalary = txtNetSalary.Text
                .CreationDate = Date.Now
                .SaveHRPayrollGenerateTable()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRLeaveTable()
        Try
            With objHRLeaveTable
                Dim dtHRLeaveTable As New DataTable
                dtHRLeaveTable = objHRLeaveTable.GetHRLeaveTableID(lHRID)
                If lHRID > 0 Then
                    .HRID = lHRID
                    .HRLeaveID = dtHRLeaveTable.Rows(0)("HRLeaveID")
                Else
                    .HRID = objHRMain.GetId
                    .HRLeaveID = 0
                End If
                .LeaveFiscalYear = txtLeaveFiscalYear.Text
                .TotalLeaveGranted = txtLeaveGranted.Text
                .TotalLeaveAvailed = txtLeaveAvailed.Text
                .MedicalLeave = txtMedicalLeave.Text
                .CasualLeave = txtCasualLeave.Text
                .DivideRule = "N/A"
                .SpecialInstructions = txtInstruction.Text
                .SaveHRLeaveTable()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRLeaveHistory()
        Try
            With objHRLeaveHistory
                Dim dtHRLeaveTable As New DataTable
                dtHRLeaveTable = objHRLeaveTable.GetHRLeaveTableID(lHRID)
                If lHRID > 0 Then
                    .HRLeaveID = dtHRLeaveTable.Rows(0)("HRLeaveID")
                    .HRLeaveHistoryID = dtHRLeaveTable.Rows(0)("HRLeaveHistoryID")
                Else
                    .HRLeaveHistoryID = 0
                    .HRLeaveID = objHRLeaveTable.GetId
                End If
                .LeaveMonth = "N/A"
                .LeaveTotal = 0
                .LeaveAvailable = 0
                .LeaveAvailed = txtLeaveAvailed.Text
                .LeaveType = "N/a"
                .SaveHRLeaveHistory()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveHRCostControl()
        Try
            With objHRCostControl
                .HRCostControlID = 0
                .HRID = objHRMain.GetId()
                .FiscalYear = txtLeaveFiscalYear.Text
                .TotalBudgetGranted = 0
                .TravelBudget = 0
                .CommunicationBudget = 0
                .CourierBudget = 0
                .EntertainmentBudget = 0
                .CostCenterRule = 0
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveHistory()
        Try
            With objHRPayrollHistory
                Dim dtPRoll As New DataTable
                dtPRoll = objHRPayroll.GetHRPayrollID(lHRID)
                ' If lHRID > 0 Then
                '.HRID = lHRID
                ' .HistoryID = dtPRoll.Rows(0)("HistoryID")
                '  Else
                .HRID = objHRMain.GetId
                .HistoryID = 0
                '  End If
                .HistoryDate = Date.Now()
                .GrossSalary = txtGrossSum.Text
                If txtBasic.Text = "" Then
                    .Basic = 0
                Else
                    .Basic = txtBasic.Text
                End If
                If txtConvAllowance.Text = "" Then
                    .ConveyanceAllowance = 0
                Else
                    .ConveyanceAllowance = txtConvAllowance.Text
                End If
                If txtMobileAllowance.Text = "" Then
                    .MobileAllowance = 0
                Else
                    .MobileAllowance = txtMobileAllowance.Text
                End If
                If txtOtherAllowance.Text = "" Then
                    .OtherAllow = 0
                Else
                    .OtherAllow = txtOtherAllowance.Text
                End If
                If txtMiscAllowance.Text = "" Then
                    .MiscAllowance = 0
                Else
                    .MiscAllowance = txtMiscAllowance.Text
                End If
                If txtLeaveFiscalYear.Text = "" Then
                    .FiscalYear = 0
                Else
                    .FiscalYear = txtLeaveFiscalYear.Text
                End If
                .Bonus = 0
                If txtOther.Text = "" Then
                    .Deduction01 = 0
                Else
                    .Deduction01 = txtOther.Text
                End If
                If txtTax.Text = "" Then
                    .DeductionTax = 0
                Else
                    .DeductionTax = txtTax.Text
                End If
                .TaxPercentage = ((txtGrossSum.Text) * (txtTax.Text)) / 100

                If txtEOBI.Text = "" Then
                    .DeductionEOBI = 0
                Else
                    .DeductionEOBI = txtEOBI.Text
                End If
                .NetSalary = txtNetSalary.Text
                If lHRID > 0 Then
                    '----Save History                    
                    Dim NewGrossSum As Decimal = txtGrossSum.Text
                    Dim NewNetSalory As Decimal = txtNetSalary.Text
                    If OldGrossSum = NewGrossSum Or OldNetSalory = NewNetSalory Then
                    Else
                        .HRID = lHRID
                        .HistoryID = 0
                        .SaveHRPayrollHistory()
                    End If
                Else
                    .SaveHRPayrollHistory()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtMiscAllowance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMiscAllowance.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtBasic.Text) AndAlso Not String.IsNullOrEmpty(txtConvAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMobileAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtOtherAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMiscAllowance.Text) Then
            txtGrossSum.Text = (Convert.ToDecimal(txtBasic.Text) + Convert.ToDecimal(txtConvAllowance.Text) + Convert.ToDecimal(txtMobileAllowance.Text) + Convert.ToDecimal(txtOtherAllowance.Text) + Convert.ToDecimal(txtMiscAllowance.Text)).ToString()
            ' End If
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text)).ToString()
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtOtherAllowance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOtherAllowance.TextChanged
        Try
            '  If Not String.IsNullOrEmpty(txtBasic.Text) AndAlso Not String.IsNullOrEmpty(txtConvAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMobileAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtOtherAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMiscAllowance.Text) Then
            txtGrossSum.Text = (Convert.ToDecimal(txtBasic.Text) + Convert.ToDecimal(txtConvAllowance.Text) + Convert.ToDecimal(txtMobileAllowance.Text) + Convert.ToDecimal(txtOtherAllowance.Text) + Convert.ToDecimal(txtMiscAllowance.Text)).ToString()
            ' End If
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text)).ToString()
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtMobileAllowance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMobileAllowance.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtBasic.Text) AndAlso Not String.IsNullOrEmpty(txtConvAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMobileAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtOtherAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMiscAllowance.Text) Then
            txtGrossSum.Text = (Convert.ToDecimal(txtBasic.Text) + Convert.ToDecimal(txtConvAllowance.Text) + Convert.ToDecimal(txtMobileAllowance.Text) + Convert.ToDecimal(txtOtherAllowance.Text) + Convert.ToDecimal(txtMiscAllowance.Text)).ToString()
            'End If
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text)).ToString()
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtConvAllowance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtConvAllowance.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtBasic.Text) AndAlso Not String.IsNullOrEmpty(txtConvAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMobileAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtOtherAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMiscAllowance.Text) Then
            txtGrossSum.Text = (Convert.ToDecimal(txtBasic.Text) + Convert.ToDecimal(txtConvAllowance.Text) + Convert.ToDecimal(txtMobileAllowance.Text) + Convert.ToDecimal(txtOtherAllowance.Text) + Convert.ToDecimal(txtMiscAllowance.Text)).ToString()
            'End If
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text)).ToString()
            '  End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtBasic_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBasic.TextChanged
        Try
            'If Not String.IsNullOrEmpty(txtBasic.Text) AndAlso Not String.IsNullOrEmpty(txtConvAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMobileAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtOtherAllowance.Text) AndAlso Not String.IsNullOrEmpty(txtMiscAllowance.Text) Then
            txtGrossSum.Text = (Convert.ToDecimal(txtBasic.Text) + Convert.ToDecimal(txtConvAllowance.Text) + Convert.ToDecimal(txtMobileAllowance.Text) + Convert.ToDecimal(txtOtherAllowance.Text) + Convert.ToDecimal(txtMiscAllowance.Text))
            ' End If
            'If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToInt32(txtOther.Text))
            '  End If
        Catch ex As Exception

        End Try
    End Sub
    '----Deduction
    Protected Sub txtOther_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOther.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text))
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtTax_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTax.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text))
            '  End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtEOBI_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEOBI.TextChanged
        Try
            ' If Not String.IsNullOrEmpty(txtEOBI.Text) AndAlso Not String.IsNullOrEmpty(txtTax.Text) AndAlso Not String.IsNullOrEmpty(txtOther.Text) Then
            txtNetSalary.Text = Convert.ToDecimal(txtGrossSum.Text) - (Convert.ToDecimal(txtEOBI.Text) + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(txtOther.Text))
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValueEdit()
        Dim x As Integer
        Try
            Dt = objHRMain.GetValeForEdit(lHRID)
            '--------EDIT HRMain
            ' Dim EmployeeImageName As String = Dt.Rows(0)("EmployeeImageName")
            ' Image2.ImageUrl = "~/HRImages/" & lHRID & "/DrivingLicences/" & EmployeeImageName

            Image2.ImageUrl = "~/" + Dt.Rows(0)("EmployeeImage")

            ' Dt.Rows(0)("EmployeeImage")
            txtHRCode.Text = Dt.Rows(0)("HRCode")
            txtFullName.Text = Dt.Rows(0)("EmployeeName")
            txtSurname.Text = Dt.Rows(0)("EmployeeAlias")
            '.PrincipalDepartment = Dt.Rows(0)("PrincipalDepartment")
            txtPrincipalGroup.Text = Dt.Rows(0)("PrincipalGroup")
            txtHKCode.Text = Dt.Rows(0)("HKCode")
            txtECPCode.Text = Dt.Rows(0)("ECPCode")
            txtDesignation.Text = Dt.Rows(0)("Designation")
            txtPostedat.Text = Dt.Rows(0)("PostedAt")

            Dim DOJ As String = txtDateofJoining.SelectedDate.ToString()
            If Dt.Rows(0)("DateOfJoining") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                DOJ = ""
            Else
                txtDateofJoining.SelectedDate = Dt.Rows(0)("DateOfJoining")
            End If

            txtDateOfBirth.SelectedDate = Dt.Rows(0)("DateOfBirth")


            cmbNationality.SelectedItem.Text = Dt.Rows(0)("Nationality")
            txtCNIC.Text = Dt.Rows(0)("NICNo")

            Dim NIC As String = txtCNICValidity.SelectedDate.ToString()
            If Dt.Rows(0)("NICExpiryDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                NIC = ""
            Else
                txtCNICValidity.SelectedDate = Dt.Rows(0)("NICExpiryDate")
            End If


            txtPassport.Text = Dt.Rows(0)("PassportNo")

            Dim PassPort As String = txtPassportValidity.SelectedDate.ToString()
            If Dt.Rows(0)("PassportExpirtyDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                PassPort = ""
            Else
                txtPassportValidity.SelectedDate = Dt.Rows(0)("PassportExpirtyDate")
            End If


            txtDrivingLicense.Text = Dt.Rows(0)("DrivingLicenseNo")


            Dim DrivingLicences As String = txtDrivingLicenseValidity.SelectedDate.ToString()
            If Dt.Rows(0)("DrivingLicenseExpiryDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                DrivingLicences = ""
            Else
                txtDrivingLicenseValidity.SelectedDate = Dt.Rows(0)("DrivingLicenseExpiryDate")
            End If

            txtInsurancePolicy.Text = Dt.Rows(0)("InsurancePolicyNo")

            Dim PolicyExpiryDate As String = txtInsurancePolicyValidity.SelectedDate.ToString()
            If Dt.Rows(0)("PolicyExpiryDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                PolicyExpiryDate = ""
            Else
                txtInsurancePolicyValidity.SelectedDate = Dt.Rows(0)("PolicyExpiryDate")
            End If


            txtNTNNo.Text = Dt.Rows(0)("NTNNo")
            txtComputerSkills.Text = Dt.Rows(0)("ComputerSkills")
            ' .Capabilities = Dt.Rows(0)("Capabilities")
            txtTechnicalSkills.Text = Dt.Rows(0)("TechnicalSkills")
            '.Product = Dt.Rows(0)("Product")
            txtResidenceAddress.Text = Dt.Rows(0)("ResidenceLine1")
            txtResidenceAddress2.Text = Dt.Rows(0)("ResidenceLine2")
            txtResidencePhoneNo.Text = Dt.Rows(0)("ResidenceTelephone")
            txtCellNo.Text = Dt.Rows(0)("EmployeeCellNo")
            '.EmployeeEmailId= Dt.Rows(0)("EmployeeEmailId")
            ' .EmployeeEmailidSecondary= Dt.Rows(0)("EmployeeEmailidSecondary")
            txtEmergencyContactNo.Text = Dt.Rows(0)("EmergencyContactNo")
            cmbMaternalStatus.SelectedItem.Text = Dt.Rows(0)("MarriedStatus")
            txtNexttokin.Text = Dt.Rows(0)("NexttoKin")
            '.EmployeeEducation= Dt.Rows(0)("EmployeeEducation")
            txtLastDegree.Text = Dt.Rows(0)("EmployeeLastDegree")
            txtLastDegreeYear.Text = Dt.Rows(0)("LastDegreeYear")
            txtBankAccountNo.Text = Dt.Rows(0)("EmployeeBankAccountNo")
            'imgEmployee.PostedFile.FileName = Dt.Rows(0)("EmployeeImage")
            '.NICImage = Dt.Rows(0)("NICImage")
            '.PassportImage = Dt.Rows(0)("PassportImage")
            '.DrivingLicences = Dt.Rows(0)("DrivingLicencesImage")

            ''--------EDIT HRLanguage
            DtLanguage = objHRLanguage.HRLanguageOnEdit(lHRID)
            Dim i As Integer
            For i = 0 To DtLanguage.Rows.Count - 1
                ' cmbLanguages.Items.FindItemByValue(DtLanguage.Rows(i)("LanguageID")).Checked = True
                cmbLanguages.Items.FindItemByText(DtLanguage.Rows(i)("Languages")).Checked = True
            Next

            ''--------EDIT HRHealthCare
            txtEyeSight.Text = Dt.Rows(0)("EmployeeEyeSight")
            txtBloodGroup.Text = Dt.Rows(0)("EmployeeBloodGroup")
            txtAllergic.Text = Dt.Rows(0)("EmployeeAllergic")
            cmbBloodPressure.SelectedItem.Text = Dt.Rows(0)("EmployeeBloodPressure")
            cmbSugarLevel.SelectedItem.Text = Dt.Rows(0)("EmployeeSugarLevel")
            cmbIsSmoke.SelectedItem.Text = Dt.Rows(0)("EmployeeIsSmoke")
            txtFaimalyDoctorName.Text = Dt.Rows(0)("EmployeeFamilyDoctorName")
            txtFamilyDoctorContact.Text = Dt.Rows(0)("EmployeeFamilyDoctorNo")

            Dim EmployeeLastPhysicalCheckupDate As String = txtLastPhysicalCheckup.SelectedDate.ToString()
            If Dt.Rows(0)("EmployeeLastPhysicalCheckupDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                EmployeeLastPhysicalCheckupDate = ""
            Else
                txtLastPhysicalCheckup.SelectedDate = Dt.Rows(0)("EmployeeLastPhysicalCheckupDate")
            End If


            Dim EmployeeLastDentalCheckupDate As String = txtLastDentalCheckup.SelectedDate.ToString()
            If Dt.Rows(0)("EmployeeLastDentalCheckupDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                EmployeeLastDentalCheckupDate = ""
            Else
                txtLastDentalCheckup.SelectedDate = Dt.Rows(0)("EmployeeLastDentalCheckupDate")
            End If

            Dim EmployeeLastVacationDate As String = txtEmployeeLastVacationDate.SelectedDate.ToString()
            If Dt.Rows(0)("EmployeeLastVacationDate") = Convert.ToDateTime("1900-11-11 00:00:00.000") Then
                EmployeeLastVacationDate = ""
            Else
                txtEmployeeLastVacationDate.SelectedDate = Dt.Rows(0)("EmployeeLastVacationDate")
            End If

            txtCriticalDiagonasis.Text = Dt.Rows(0)("EmployeeCriticalDiagonasis")


            '--------EDIT HRPayroll
            txtGrossSum.Text = Dt.Rows(0)("GrossSalary")
            txtBasic.Text = Dt.Rows(0)("Basic")
            txtConvAllowance.Text = Dt.Rows(0)("ConveyanceAllowance")
            txtMobileAllowance.Text = Dt.Rows(0)("MobileAllowance")
            txtOtherAllowance.Text = Dt.Rows(0)("OtherAllow")
            '.Bonus = Dt.Rows(0)("Bonus")
            txtOther.Text = Dt.Rows(0)("Deduction01")
            txtTax.Text = Dt.Rows(0)("DeductionTax")
            txtEOBI.Text = Dt.Rows(0)("DeductionEOBI")
            txtNetSalary.Text = Dt.Rows(0)("NetSalary")
            txtLeaveFiscalYear.Text = Dt.Rows(0)("FiscalYear")
            txtMiscAllowance.Text = Dt.Rows(0)("MiscAllowance")
            '--------EDIT HRPayrollGenerateTable

            ' .Month  = Dt.Rows(0)("Month")
            txtGrossSum.Text = Dt.Rows(0)("GrossSalary")
            ' .Basic = txtBasic.Text = Dt.Rows(0)("Basic")
            txtConvAllowance.Text = Dt.Rows(0)("ConveyanceAllowance")
            txtMobileAllowance.Text = Dt.Rows(0)("MobileAllowance")
            txtOtherAllowance.Text = Dt.Rows(0)("OtherAllow")
            '.Bonus = Dt.Rows(0)("Bonus")
            txtOther.Text = Dt.Rows(0)("Deduction01")
            txtTax.Text = Dt.Rows(0)("DeductionTax")
            txtEOBI.Text = Dt.Rows(0)("DeductionEOBI")
            txtNetSalary.Text = Dt.Rows(0)("NetSalary")

            '--------EDIT HRLeaveTable
            txtLeaveFiscalYear.Text = Dt.Rows(0)("LeaveFiscalYear")
            txtLeaveGranted.Text = Dt.Rows(0)("TotalLeaveGranted")
            txtLeaveAvailed.Text = Dt.Rows(0)("TotalLeaveAvailed")
            txtMedicalLeave.Text = Dt.Rows(0)("MedicalLeave")
            txtCasualLeave.Text = Dt.Rows(0)("CasualLeave")
            '.DivideRule = Dt.Rows(0)("DivideRule")
            txtInstruction.Text = Dt.Rows(0)("SpecialInstructions")

            '--------EDIT HRLeaveHistory
            '.LeaveMonth = Dt.Rows(0)("LeaveMonth")
            ' .LeaveTotal = Dt.Rows(0)("LeaveTotal")
            ' .LeaveAvailable = Dt.Rows(0)("LeaveAvailable")
            txtLeaveAvailed.Text = Dt.Rows(0)("LeaveAvailed")
            ' .LeaveType = Dt.Rows(0)("LeaveType")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("HRMainView.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class
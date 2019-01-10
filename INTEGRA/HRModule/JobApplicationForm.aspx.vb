Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class JobApplicationForm
    Inherits System.Web.UI.Page
    Dim objJobapplication As New JobApplications
    Dim objLanguage As New LanguageJobApplication
    Dim lJobApplicationID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobApplicationID = Request.QueryString("lJobApplicationID")
        If Not Page.IsPostBack Then

        End If
    End Sub
   
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveJobApplicationData()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save SuccessFully.")
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveJobApplicationData()
        Dim img As FileUpload = CType(imgEmployee, FileUpload)
        Dim imgByte As Byte() = Nothing
        If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
            'To create a PostedFile
            Dim File As HttpPostedFile = imgEmployee.PostedFile
            'Create byte Array with file len
            imgByte = New Byte(File.ContentLength - 1) {}
            'force the control to load data in array
            File.InputStream.Read(imgByte, 0, File.ContentLength)
        End If
        With objJobapplication
            .JobApplicationID = 0
            .CreationDate = Date.Now
            .AppliedAs = txtApplied.Text
            .FullName = txtFullName.Text
            .image = imgByte
            .SurName = txtSurname.Text
            .FatherName = txtFatherName.Text
            .DOB = txtDateOfBirth.SelectedDate
            .Nationality = cmbNationality.SelectedItem.Text '--Design time bind
            .City = txtCity.Text
            .CNIC = txtCNIC.Text
            .ResidenceAddressA = txtResidenceAddressA.Text
            .ResidenceAddressB = txtResidenceAddressB.Text
            .ResidencePhoneNo = txtResidencePhoneNo.Text
            .CellNo = txtCellNo.Text
            .EmergenctContactNo = txtEmergencyContactNo.Text
            .NextToKin = txtNexttokin.Text
            .MaritalStatus = cmbMaternalStatus.SelectedItem.Text '--Design time bind
            .Gender = cmbGender.SelectedItem.Text '--Design time bind
            .LastDegree = txtLastDegree.Text
            .Year = txtLastDegreeYear.Text
            .Instruction = txtInstitution.Text
            .PercentageMarks = txtmarks.Text
            .TechnicalSkills = txtTechnicalSkills.Text
            .ComputersSkills = txtComputerSkills.Text
            .Organizations = txtOrganization.Text
            .Locations = txtLocation.Text
            .Designation = txtDesignationn.Text
            .DurationInYear = txtDuration.Text
            .NatureOfJob = txtNatureofJob.Text
            .PerMontSalary = txtPerMonthSalary.Text
            .ReasonForQuitting = txtReasonforquitting.Text
            .Remarks = txtRemarks.Text
            .SaveJobApplication()
        End With
        'For Vertical Integration
        Dim xx As Integer
        For xx = 0 To cmbLanguages.CheckedItems.Count - 1
            With objLanguage
                .LanguagesId = 0
                .JobApplicationID = objJobapplication.GetId
                .Language = cmbLanguages.CheckedItems(xx).Value
                .SaveLanguageJobApplication()
            End With
        Next
    End Sub
End Class
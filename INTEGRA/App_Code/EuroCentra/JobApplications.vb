Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class JobApplications
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobApplication"
            m_strPrimaryFieldName = "JobApplicationID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lJobApplicationID As Long
        Private m_dtCreationDate As Date
        Private m_strAppliedAs As String
        Private m_strFullName As String
        Private m_image As Object
        Private m_strSurName As String
        Private m_strFatherName As String
        Private m_dtDOB As Date
        Private m_strNationality As String
        Private m_strCity As String
        Private m_strCNIC As String
        Private m_strResidenceAddressA As String
        Private m_strResidenceAddressB As String
        Private m_strResidencePhoneNo As String
        Private m_strCellNo As String
        Private m_strEmergenctContactNo As String
        Private m_strNextToKin As String
        Private m_strMaritalStatus As String
        Private m_strGender As String
        Private m_strLastDegree As String
        Private m_strYear As String
        Private m_strInstruction As String
        Private m_strPercentageMarks As String
        Private m_strTechnicalSkills As String
        Private m_strComputersSkills As String
        Private m_strOrganizations As String
        Private m_strLocations As String
        Private m_strDesignation As String
        Private m_strDurationInYear As String
        Private m_strNatureOfJob As String
        Private m_strPerMontSalary As String
        Private m_strReasonForQuitting As String
        Private m_strRemarks As String
        Public Property JobApplicationID() As Long
            Get
                JobApplicationID = m_lJobApplicationID
            End Get
            Set(ByVal value As Long)
                m_lJobApplicationID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property AppliedAs() As String
            Get
                AppliedAs = m_strAppliedAs
            End Get
            Set(ByVal value As String)
                m_strAppliedAs = value
            End Set
        End Property
        Public Property FullName() As String
            Get
                FullName = m_strFullName
            End Get
            Set(ByVal value As String)
                m_strFullName = value
            End Set
        End Property
        Public Property image() As Object
            Get
                image = m_image
            End Get
            Set(ByVal value As Object)
                m_image = value
            End Set
        End Property
        Public Property SurName() As String
            Get
                SurName = m_strSurName
            End Get
            Set(ByVal value As String)
                m_strSurName = value
            End Set
        End Property
        Public Property FatherName() As String
            Get
                FatherName = m_strFatherName
            End Get
            Set(ByVal value As String)
                m_strFatherName = value
            End Set
        End Property
        Public Property DOB() As Date
            Get
                DOB = m_dtDOB
            End Get
            Set(ByVal value As Date)
                m_dtDOB = value
            End Set
        End Property
        Public Property Nationality() As String
            Get
                Nationality = m_strNationality
            End Get
            Set(ByVal value As String)
                m_strNationality = value
            End Set
        End Property
        Public Property City() As String
            Get
                City = m_strCity
            End Get
            Set(ByVal value As String)
                m_strCity = value
            End Set
        End Property
        Public Property CNIC() As String
            Get
                CNIC = m_strCNIC
            End Get
            Set(ByVal value As String)
                m_strCNIC = value
            End Set
        End Property
        Public Property ResidenceAddressA() As String
            Get
                ResidenceAddressA = m_strResidenceAddressA
            End Get
            Set(ByVal value As String)
                m_strResidenceAddressA = value
            End Set
        End Property
        Public Property ResidenceAddressB() As String
            Get
                ResidenceAddressB = m_strResidenceAddressB
            End Get
            Set(ByVal value As String)
                m_strResidenceAddressB = value
            End Set
        End Property
        Public Property ResidencePhoneNo() As String
            Get
                ResidencePhoneNo = m_strResidencePhoneNo
            End Get
            Set(ByVal value As String)
                m_strResidencePhoneNo = value
            End Set
        End Property
        Public Property CellNo() As String
            Get
                CellNo = m_strCellNo
            End Get
            Set(ByVal value As String)
                m_strCellNo = value
            End Set
        End Property
        Public Property EmergenctContactNo() As String
            Get
                EmergenctContactNo = m_strEmergenctContactNo
            End Get
            Set(ByVal value As String)
                m_strEmergenctContactNo = value
            End Set
        End Property
        Public Property NextToKin() As String
            Get
                NextToKin = m_strNextToKin
            End Get
            Set(ByVal value As String)
                m_strNextToKin = value
            End Set
        End Property
        Public Property MaritalStatus() As String
            Get
                MaritalStatus = m_strMaritalStatus
            End Get
            Set(ByVal value As String)
                m_strMaritalStatus = value
            End Set
        End Property
        Public Property Gender() As String
            Get
                Gender = m_strGender
            End Get
            Set(ByVal value As String)
                m_strGender = value
            End Set
        End Property
        Public Property LastDegree() As String
            Get
                LastDegree = m_strLastDegree
            End Get
            Set(ByVal value As String)
                m_strLastDegree = value
            End Set
        End Property
        Public Property Year() As String
            Get
                Year = m_strYear
            End Get
            Set(ByVal value As String)
                m_strYear = value
            End Set
        End Property
        Public Property Instruction() As String
            Get
                Instruction = m_strInstruction
            End Get
            Set(ByVal value As String)
                m_strInstruction = value
            End Set
        End Property
        Public Property PercentageMarks() As String
            Get
                PercentageMarks = m_strPercentageMarks
            End Get
            Set(ByVal value As String)
                m_strPercentageMarks = value
            End Set
        End Property
        Public Property TechnicalSkills() As String
            Get
                TechnicalSkills = m_strTechnicalSkills
            End Get
            Set(ByVal value As String)
                m_strTechnicalSkills = value
            End Set
        End Property
        Public Property ComputersSkills() As String
            Get
                ComputersSkills = m_strComputersSkills
            End Get
            Set(ByVal value As String)
                m_strComputersSkills = value
            End Set
        End Property
        Public Property Organizations() As String
            Get
                Organizations = m_strOrganizations
            End Get
            Set(ByVal value As String)
                m_strOrganizations = value
            End Set
        End Property
        Public Property Locations() As String
            Get
                Locations = m_strLocations
            End Get
            Set(ByVal value As String)
                m_strLocations = value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strDesignation
            End Get
            Set(ByVal value As String)
                m_strDesignation = value
            End Set
        End Property
        Public Property DurationInYear() As String
            Get
                DurationInYear = m_strDurationInYear
            End Get
            Set(ByVal value As String)
                m_strDurationInYear = value
            End Set
        End Property
        Public Property NatureOfJob() As String
            Get
                NatureOfJob = m_strNatureOfJob
            End Get
            Set(ByVal value As String)
                m_strNatureOfJob = value
            End Set
        End Property
        Public Property PerMontSalary() As String
            Get
                PerMontSalary = m_strPerMontSalary
            End Get
            Set(ByVal value As String)
                m_strPerMontSalary = value
            End Set
        End Property
        Public Property ReasonForQuitting() As String
            Get
                ReasonForQuitting = m_strReasonForQuitting
            End Get
            Set(ByVal value As String)
                m_strReasonForQuitting = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        
        Public Function SaveJobApplication()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        


    End Class
End Namespace



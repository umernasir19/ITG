Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class HRMain
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRMain"
            m_strPrimaryFieldName = "HRID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''

        Private m_lHRID As Long
        Private m_strHRCode As String
        Private m_strEmployeeName As String
        Private m_strEmployeeAlias As String
        Private m_strPrincipalDepartment As String
        Private m_strPrincipalGroup As String
        Private m_strHKCode As String
        Private m_strECPCode As String
        Private m_strDesignation As String
        Private m_strPostedAt As String
        Private m_dtDateOfJoining As Date
        Private m_dtDateOfBirth As Date
        Private m_strNationality As String
        Private m_strNICNo As String
        Private m_dtNICExpiryDate As Date
        Private m_strPassportNo As String
        Private m_dtPassportExpirtyDate As Date
        Private m_strDrivingLicenseNo As String
        Private m_dtDrivingLicenseExpiryDate As Date
        Private m_strInsurancePolicyNo As String
        Private m_dtPolicyExpiryDate As Date
        Private m_strNTNNo As String
        Private m_strComputerSkills As String
        Private m_strCapabilities As String
        Private m_strProduct As String
        Private m_strResidenceLine1 As String
        Private m_strResidenceLine2 As String
        Private m_strResidenceTelephone As String
        Private m_strEmployeeCellNo As String
        Private m_lEmployeeEmailId As Long
        Private m_strEmployeeEmailidSecondary As String
        Private m_strEmergencyContactNo As String
        Private m_strMarriedStatus As String
        Private m_strNexttoKin As String
        Private m_strEmployeeEducation As String
        Private m_strEmployeeLastDegree As String
        Private m_strLastDegreeYear As String

        Private m_strEmployeeBankAccountNo As String
        Private m_imgEmployeeImage As String

        Private m_imgNICImage As String
        Private m_imgPassportImage As String
        Private m_imgDrivingLicense As String
        Private m_bIsActive As Boolean
        Private m_strTechnicalSkills As String

       
        '----------------Properties


        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
            End Set
        End Property
        Public Property HRCode() As String
            Get
                HRCode = m_strHRCode
            End Get
            Set(ByVal value As String)
                m_strHRCode = value
            End Set
        End Property
        Public Property EmployeeName() As String
            Get
                EmployeeName = m_strEmployeeName
            End Get
            Set(ByVal value As String)
                m_strEmployeeName = value
            End Set
        End Property
        Public Property EmployeeAlias() As String
            Get
                EmployeeAlias = m_strEmployeeAlias
            End Get
            Set(ByVal value As String)
                m_strEmployeeAlias = value
            End Set
        End Property
        Public Property PrincipalDepartment() As String
            Get
                PrincipalDepartment = m_strPrincipalDepartment
            End Get
            Set(ByVal value As String)
                m_strPrincipalDepartment = value
            End Set
        End Property
        Public Property PrincipalGroup() As String
            Get
                PrincipalGroup = m_strPrincipalGroup
            End Get
            Set(ByVal value As String)
                m_strPrincipalGroup = value
            End Set
        End Property
        Public Property HKCode() As String
            Get
                HKCode = m_strHKCode
            End Get
            Set(ByVal value As String)
                m_strHKCode = value
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
        Public Property PostedAt() As String
            Get
                PostedAt = m_strPostedAt
            End Get
            Set(ByVal value As String)
                m_strPostedAt = value
            End Set
        End Property
        Public Property DateOfJoining() As Date
            Get
                DateOfJoining = m_dtDateOfJoining
            End Get
            Set(ByVal value As Date)
                m_dtDateOfJoining = value
            End Set
        End Property
        Public Property DateOfBirth() As Date
            Get
                DateOfBirth = m_dtDateOfBirth
            End Get
            Set(ByVal value As Date)
                m_dtDateOfBirth = value
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
        Public Property NICNo() As String
            Get
                NICNo = m_strNICNo
            End Get
            Set(ByVal value As String)
                m_strNICNo = value
            End Set
        End Property
        Public Property NICExpiryDate() As Date
            Get
                NICExpiryDate = m_dtNICExpiryDate
            End Get
            Set(ByVal value As Date)
                m_dtNICExpiryDate = value
            End Set
        End Property
        Public Property PassportNo() As String
            Get
                PassportNo = m_strPassportNo
            End Get
            Set(ByVal value As String)
                m_strPassportNo = value
            End Set
        End Property
        Public Property PassportExpirtyDate() As Date
            Get
                PassportExpirtyDate = m_dtPassportExpirtyDate
            End Get
            Set(ByVal value As Date)
                m_dtPassportExpirtyDate = value
            End Set
        End Property
        Public Property DrivingLicenseNo() As String
            Get
                DrivingLicenseNo = m_strDrivingLicenseNo
            End Get
            Set(ByVal value As String)
                m_strDrivingLicenseNo = value
            End Set
        End Property
        Public Property DrivingLicenseExpiryDate() As Date
            Get
                DrivingLicenseExpiryDate = m_dtDrivingLicenseExpiryDate
            End Get
            Set(ByVal value As Date)
                m_dtDrivingLicenseExpiryDate = value
            End Set
        End Property
        Public Property InsurancePolicyNo() As String
            Get
                InsurancePolicyNo = m_strInsurancePolicyNo
            End Get
            Set(ByVal value As String)
                m_strInsurancePolicyNo = value
            End Set
        End Property
        Public Property PolicyExpiryDate() As Date
            Get
                PolicyExpiryDate = m_dtPolicyExpiryDate
            End Get
            Set(ByVal value As Date)
                m_dtPolicyExpiryDate = value
            End Set
        End Property
        Public Property NTNNo() As String
            Get
                NTNNo = m_strNTNNo
            End Get
            Set(ByVal value As String)
                m_strNTNNo = value
            End Set
        End Property
        Public Property ComputerSkills() As String
            Get
                ComputerSkills = m_strComputerSkills
            End Get
            Set(ByVal value As String)
                m_strComputerSkills = value
            End Set
        End Property
        Public Property Capabilities() As String
            Get
                Capabilities = m_strCapabilities
            End Get
            Set(ByVal value As String)
                m_strCapabilities = value
            End Set
        End Property
        Public Property Product() As String
            Get
                Product = m_strProduct
            End Get
            Set(ByVal value As String)
                m_strProduct = value
            End Set
        End Property
        Public Property ResidenceLine1() As String
            Get
                ResidenceLine1 = m_strResidenceLine1
            End Get
            Set(ByVal value As String)
                m_strResidenceLine1 = value
            End Set
        End Property
        Public Property ResidenceLine2() As String
            Get
                ResidenceLine2 = m_strResidenceLine2
            End Get
            Set(ByVal value As String)
                m_strResidenceLine2 = value
            End Set
        End Property
        Public Property ResidenceTelephone() As String
            Get
                ResidenceTelephone = m_strResidenceTelephone
            End Get
            Set(ByVal value As String)
                m_strResidenceTelephone = value
            End Set
        End Property
        Public Property EmployeeCellNo() As String
            Get
                EmployeeCellNo = m_strEmployeeCellNo
            End Get
            Set(ByVal value As String)
                m_strEmployeeCellNo = value
            End Set
        End Property
        Public Property EmployeeEmailId() As Long
            Get
                EmployeeEmailId = m_lEmployeeEmailId
            End Get
            Set(ByVal value As Long)
                m_lEmployeeEmailId = value
            End Set
        End Property
        Public Property EmployeeEmailidSecondary() As String
            Get
                EmployeeEmailidSecondary = m_strEmployeeEmailidSecondary
            End Get
            Set(ByVal value As String)
                m_strEmployeeEmailidSecondary = value
            End Set
        End Property
        Public Property EmergencyContactNo() As String
            Get
                EmergencyContactNo = m_strEmergencyContactNo
            End Get
            Set(ByVal value As String)
                m_strEmergencyContactNo = value
            End Set
        End Property
        Public Property MarriedStatus() As String
            Get
                MarriedStatus = m_strMarriedStatus
            End Get
            Set(ByVal value As String)
                m_strMarriedStatus = value
            End Set
        End Property
        Public Property NexttoKin() As String
            Get
                NexttoKin = m_strNexttoKin
            End Get
            Set(ByVal value As String)
                m_strNexttoKin = value
            End Set
        End Property
        Public Property EmployeeEducation() As String
            Get
                EmployeeEducation = m_strEmployeeEducation
            End Get
            Set(ByVal value As String)
                m_strEmployeeEducation = value
            End Set
        End Property
        Public Property EmployeeLastDegree() As String
            Get
                EmployeeLastDegree = m_strEmployeeLastDegree
            End Get
            Set(ByVal value As String)
                m_strEmployeeLastDegree = value
            End Set
        End Property
        Public Property LastDegreeYear() As String
            Get
                LastDegreeYear = m_strLastDegreeYear
            End Get
            Set(ByVal value As String)
                m_strLastDegreeYear = value
            End Set
        End Property
        Public Property EmployeeBankAccountNo() As String
            Get
                EmployeeBankAccountNo = m_strEmployeeBankAccountNo
            End Get
            Set(ByVal value As String)
                m_strEmployeeBankAccountNo = value
            End Set
        End Property
        Public Property EmployeeImage() As String
            Get
                EmployeeImage = m_imgEmployeeImage
            End Get
            Set(ByVal value As String)
                m_imgEmployeeImage = value
            End Set
        End Property
        Public Property NICImage() As String
            Get
                NICImage = m_imgNICImage
            End Get
            Set(ByVal value As String)
                m_imgNICImage = value
            End Set
        End Property
        Public Property PassportImage() As String
            Get
                PassportImage = m_imgPassportImage
            End Get
            Set(ByVal value As String)
                m_imgPassportImage = value
            End Set
        End Property
        Public Property DrivingLicense() As String
            Get
                DrivingLicense = m_imgDrivingLicense
            End Get
            Set(ByVal value As String)
                m_imgDrivingLicense = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
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
        Public Property ECPCode() As String
            Get
                ECPCode = m_strECPCode
            End Get
            Set(ByVal value As String)
                m_strECPCode = value
            End Set
        End Property
        Public Function SaveHRMain()
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
        Function GetValeForEdit(ByVal HRID As Long)
            Dim Str As String
            Str = "select * from HRMain HRM "
            Str &= "left join HRHealthCare HRC on HRC.HRID =HRM.HRID "
            Str &= "left join HRPayroll HRP on HRP.HRID =HRM.HRID "
            Str &= "left join HRPayrollGenerateTable HRPGT on HRPGT.HRID =HRM.HRID "
            Str &= "left join HRLeaveTable HRLT on HRLT.HRID =HRM.HRID "
            Str &= "left join HRLeaveHistory HRLH on HRLH.HRLeaveID =HRLT.HRLeaveID where HRM.HRID= " & HRID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetHRMOduleForView()
            Dim Str As String

            'Str = "  select HRM.*,Convert(Varchar,HRM.DateOfJoining,103) as DateOfJoiningg"
            'Str &= " ,HRL.TotalLeaveGranted,HRL.TotalLeaveAvailed  ,"
            'Str &= " (HRL.TotalLeaveGranted-HRL.TotalLeaveAvailed) as 'BalanceLeave' ,"
            'Str &= " (case when  cast(HRM.NICExpiryDate as datetime) ='1900-11-11' then"
            'Str &= " '--'"
            'Str &= " (case when cast(HRM.NICExpiryDate as datetime) > = CONVERT (datetime, GETDATE(), 103)then"
            'Str &= " 'Valid'"
            'Str &= " else"
            'Str &= " 'Expired' end)  as 'CNIC'"
            'Str &= " ,(case when cast(HRM.PassportExpirtyDate as datetime) ='1900-11-11' then"
            'Str &= " '--'"
            'Str &= "   (case when cast(HRM.PassportExpirtyDate as datetime)  < DATEADD(MONTH, 6, GETDATE())then"
            'Str &= "  'Valid' else 'Expired' end) as 'PasPort'"
            'Str &= "   ,(case when cast(HRM.DrivingLicenseExpiryDate as datetime)='1900-11-11' then"
            'Str &= "   '--'"
            'Str &= " (case when cast(HRM.DrivingLicenseExpiryDate as datetime)  < = CONVERT (datetime, GETDATE(), 103)then"
            'Str &= "   'Valid' else 'Expired' end) as 'DrivingLicence'"
            'Str &= " from HRMain HRM  join HRLeaveTable HRL on HRL.HRID =HRM.HRID "



            Str = "  select HRM.*,Convert(Varchar,HRM.DateOfJoining,103) as DateOfJoiningg"
            Str &= " ,HRL.TotalLeaveGranted,HRL.TotalLeaveAvailed  ,"
            Str &= " (HRL.TotalLeaveGranted-HRL.TotalLeaveAvailed) as 'BalanceLeave',"
            Str &= " (case when  cast(HRM.NICExpiryDate as datetime) ='1900-11-11' then"
            Str &= "        '--'"
            Str &= " when  cast(HRM.NICExpiryDate as datetime) > = CONVERT (datetime, GETDATE(), 103)then"
            Str &= "     'Valid'"
            Str &= " else"
            Str &= "   'Expired' end) as 'CNIC'"
            Str &= " ,(case when cast(HRM.PassportExpirtyDate as datetime) ='1900-11-11' then"
            Str &= "     '--'"
            Str &= " when cast(HRM.PassportExpirtyDate as datetime)  < DATEADD(MONTH, 6, GETDATE())then"
            Str &= "   'Valid' else 'Expired' end) as 'PasPort'"
            Str &= " ,(case when cast(HRM.DrivingLicenseExpiryDate as datetime)='1900-11-11' then"
            Str &= "    '--'"
            Str &= " when cast(HRM.DrivingLicenseExpiryDate as datetime)  < = CONVERT (datetime, GETDATE(), 103)then"
            Str &= "         'Valid' else 'Expired' end) as 'DrivingLicence'"
            Str &= " from HRMain HRM  join HRLeaveTable HRL on HRL.HRID =HRM.HRID "



            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Function GetimgCNIC(ByVal lHRID As Long)
            Dim str As String
            str = "Select NICImage from HRMain where HRID=" & lHRID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgPasport(ByVal lHRID As Long)
            Dim str As String
            str = "Select PassportImage from HRMain where HRID=" & lHRID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgDrivinfLicence(ByVal lHRID As Long)
            Dim str As String
            str = "Select DrivingLicense from HRMain where HRID=" & lHRID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgEployee(ByVal lHRID As Long)
            Dim str As String
            str = "Select EmployeeImage from HRMain where HRID=" & lHRID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetLoanForView() As DataTable
            Dim Str As String
            Str = "select LM.*,HR.EmployeeName,HR.NICNo  from LoanMaster LM  join HRMain HR on HR.HRID =LM.HRID "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetInformationForLoan(ByVal lHRID As Long) As DataTable
            Dim str As String
            str = "select EmployeeName ,NICNo  from HRMain  where HRID=" & lHRID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
End Class
End Namespace

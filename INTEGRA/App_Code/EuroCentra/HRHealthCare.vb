Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

Public Class HRHealthCare
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRHealthCare"
            m_strPrimaryFieldName = "HRHealthcareID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRHealthcareID As Long
        Private m_lHRID As Long
        Private m_strEmployeeEyeSight As String
        Private m_strEmployeeBloodGroup As String
        Private m_strEmployeeAllergic As String
        Private m_strEmployeeBloodPressure As String
        Private m_strEmployeeSugarLevel As String

        Private m_strEmployeeIsSmoke As String
        Private m_strEmployeeFamilyDoctorName As String
        Private m_strEmployeeFamilyDoctorNo As String

        Private m_dtEmployeeLastPhysicalCheckupDate As Date
        Private m_dtEmployeeLastDentalCheckupDate As Date
        Private m_dtEmployeeLastVacationDate As Date

        Private m_strEmployeeCriticalDiagonasis As String


        '----------------Properties
        Public Property HRHealthcareID() As Long
            Get
                HRHealthcareID = m_lHRHealthcareID
            End Get
            Set(ByVal value As Long)
                m_lHRHealthcareID = value
            End Set
        End Property
        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
            End Set
        End Property
        Public Property EmployeeEyeSight() As String
            Get
                EmployeeEyeSight = m_strEmployeeEyeSight
            End Get
            Set(ByVal value As String)
                m_strEmployeeEyeSight = value
            End Set
        End Property
        Public Property EmployeeBloodGroup() As String
            Get
                EmployeeBloodGroup = m_strEmployeeBloodGroup
            End Get
            Set(ByVal value As String)
                m_strEmployeeBloodGroup = value
            End Set
        End Property
        Public Property EmployeeAllergic() As String
            Get
                EmployeeAllergic = m_strEmployeeAllergic
            End Get
            Set(ByVal value As String)
                m_strEmployeeAllergic = value
            End Set
        End Property
        Public Property EmployeeBloodPressure() As String
            Get
                EmployeeBloodPressure = m_strEmployeeBloodPressure
            End Get
            Set(ByVal value As String)
                m_strEmployeeBloodPressure = value
            End Set
        End Property
        Public Property EmployeeSugarLevel() As String
            Get
                EmployeeSugarLevel = m_strEmployeeSugarLevel
            End Get
            Set(ByVal value As String)
                m_strEmployeeSugarLevel = value
            End Set
        End Property
        Public Property EmployeeIsSmoke() As String
            Get
                EmployeeIsSmoke = m_strEmployeeIsSmoke
            End Get
            Set(ByVal value As String)
                m_strEmployeeIsSmoke = value
            End Set
        End Property
        Public Property EmployeeFamilyDoctorName() As String
            Get
                EmployeeFamilyDoctorName = m_strEmployeeFamilyDoctorName
            End Get
            Set(ByVal value As String)
                m_strEmployeeFamilyDoctorName = value
            End Set
        End Property
        Public Property EmployeeFamilyDoctorNo() As String
            Get
                EmployeeFamilyDoctorNo = m_strEmployeeFamilyDoctorNo
            End Get
            Set(ByVal value As String)
                m_strEmployeeFamilyDoctorNo = value
            End Set
        End Property
        Public Property EmployeeLastPhysicalCheckupDate() As Date
            Get
                EmployeeLastPhysicalCheckupDate = m_dtEmployeeLastPhysicalCheckupDate
            End Get
            Set(ByVal value As Date)
                m_dtEmployeeLastPhysicalCheckupDate = value
            End Set
        End Property
        Public Property EmployeeLastDentalCheckupDate() As Date
            Get
                EmployeeLastDentalCheckupDate = m_dtEmployeeLastDentalCheckupDate
            End Get
            Set(ByVal value As Date)
                m_dtEmployeeLastDentalCheckupDate = value
            End Set
        End Property
        Public Property EmployeeLastVacationDate() As Date
            Get
                EmployeeLastVacationDate = m_dtEmployeeLastVacationDate
            End Get
            Set(ByVal value As Date)
                m_dtEmployeeLastVacationDate = value
            End Set
        End Property
        Public Property EmployeeCriticalDiagonasis() As String
            Get
                EmployeeCriticalDiagonasis = m_strEmployeeCriticalDiagonasis
            End Get
            Set(ByVal value As String)
                m_strEmployeeCriticalDiagonasis = value
            End Set
        End Property


        Public Function SaveHRHealthCare()
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
        Function GetHealthCareID(ByVal lHRID As Long)
            Dim str As String
            str = "  Select * from HRHealthCare where  HRID =" & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

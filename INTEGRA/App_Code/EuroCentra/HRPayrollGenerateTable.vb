Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class HRPayrollGenerateTable
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRPayrollGenerateTable"
            m_strPrimaryFieldName = "HRPayrollGeneratedID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRPayrollGeneratedID As Long
        Private m_lHRPayrollID As Long
        Private m_lHRID As Long
        Private m_strMonth As String
        Private m_dGrossSalary As Decimal
        Private m_dBasic As Decimal
        Private m_dConveyanceAllowance As Decimal
        Private m_dMobileAllowance As Decimal
        Private m_dOtherAllow As Decimal
        Private m_dBonus As Decimal
        Private m_dDeduction01 As Decimal
        Private m_dDeductionTax As Decimal
        Private m_dDeductionEOBI As Decimal
        Private m_dNetSalary As Decimal
        Private m_dMiscAllowance As Decimal
        Private m_dTaxPercentage As Decimal
        Private m_strFiscalYear As String
        Private m_dtCreationDate As Date

        '----------------Properties
        Public Property FiscalYear() As String
            Get
                FiscalYear = m_strFiscalYear
            End Get
            Set(ByVal value As String)
                m_strFiscalYear = value
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
        Public Property TaxPercentage() As Decimal
            Get
                TaxPercentage = m_dTaxPercentage
            End Get
            Set(ByVal value As Decimal)
                m_dTaxPercentage = value
            End Set
        End Property
        Public Property HRPayrollGeneratedID() As Long
            Get
                HRPayrollGeneratedID = m_lHRPayrollGeneratedID
            End Get
            Set(ByVal value As Long)
                m_lHRPayrollGeneratedID = value
            End Set
        End Property
        Public Property HRPayrollID() As Long
            Get
                HRPayrollID = m_lHRPayrollID
            End Get
            Set(ByVal value As Long)
                m_lHRPayrollID = value
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
        Public Property Month() As String
            Get
                Month = m_strMonth
            End Get
            Set(ByVal value As String)
                m_strMonth = value
            End Set
        End Property
        Public Property GrossSalary() As Decimal
            Get
                GrossSalary = m_dGrossSalary
            End Get
            Set(ByVal value As Decimal)
                m_dGrossSalary = value
            End Set
        End Property
        Public Property Basic() As Decimal
            Get
                Basic = m_dBasic
            End Get
            Set(ByVal value As Decimal)
                m_dBasic = value
            End Set
        End Property
        Public Property ConveyanceAllowance() As Decimal
            Get
                ConveyanceAllowance = m_dConveyanceAllowance
            End Get
            Set(ByVal value As Decimal)
                m_dConveyanceAllowance = value
            End Set
        End Property
        Public Property MobileAllowance() As Decimal
            Get
                MobileAllowance = m_dMobileAllowance
            End Get
            Set(ByVal value As Decimal)
                m_dMobileAllowance = value
            End Set
        End Property
        Public Property OtherAllow() As Decimal
            Get
                OtherAllow = m_dOtherAllow
            End Get
            Set(ByVal value As Decimal)
                m_dOtherAllow = value
            End Set
        End Property
        Public Property Bonus() As Decimal
            Get
                Bonus = m_dBonus
            End Get
            Set(ByVal value As Decimal)
                m_dBonus = value
            End Set
        End Property
        Public Property Deduction01() As Decimal
            Get
                Deduction01 = m_dDeduction01
            End Get
            Set(ByVal value As Decimal)
                m_dDeduction01 = value
            End Set
        End Property
        Public Property DeductionTax() As Decimal
            Get
                DeductionTax = m_dDeductionTax
            End Get
            Set(ByVal value As Decimal)
                m_dDeductionTax = value
            End Set
        End Property
        Public Property DeductionEOBI() As Decimal
            Get
                DeductionEOBI = m_dDeductionEOBI
            End Get
            Set(ByVal value As Decimal)
                m_dDeductionEOBI = value
            End Set
        End Property
        Public Property NetSalary() As Decimal
            Get
                NetSalary = m_dNetSalary
            End Get
            Set(ByVal value As Decimal)
                m_dNetSalary = value
            End Set
        End Property
        Public Property MiscAllowance() As Decimal
            Get
                MiscAllowance = m_dMiscAllowance
            End Get
            Set(ByVal value As Decimal)
                m_dMiscAllowance = value
            End Set
        End Property
        Public Function SaveHRPayrollGenerateTable()
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
        Function GetHRPayrollGenerateTableID(ByVal lHRID As Long)
            Dim str As String
            str = "select HRP.HRPayrollID ,HRPGT.HRPayrollGeneratedID  from  HRPayroll HRP "
            str &= "join HRPayrollGenerateTable HRPGT on HRPGT.HRPayrollID =HRP.HRPayrollID "
            str &= " where HRID = " & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForPayrollGeneration()
            Dim str As String
            str = " select HRM.HRID,HRP.HRpayrollID,HRM.EmployeeAlias,HRM.HRCode,HRM.HKCode,HRM.ECPCode,HRP.Bonus,"
            str &= " HRM.Designation,CONVERT (Varchar, HRM.DateOfBirth, 103) as DateOfBirth"
            str &= " ,Convert(Varchar,HRM.DateOfJoining,103) as DateOfJoining"
            str &= "  ,HRP.Basic,HRp.ConveyanceAllowance ,HRP.MobileAllowance ,HRP.MiscAllowance "
            str &= " ,HRP.OtherAllow ,HRP.DeductionEOBI,HRP.DeductionTax,HRP.Deduction01 ,HRP.GrossSalary ,HRP.NetSalary "
            str &= " from HRMain HRM join HRPayroll HRP on HRM.HRID =HRP.HRID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetGeneratedTableId(ByVal HRPayrollID As Long)
            Dim str As String
            str = " select HRPayrollGeneratedID  from HRPayrollGenerateTable where HRPayrollID = " & HRPayrollID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckMonthlySalary(ByVal HRPayrollID As Long)
            Dim str As String
            str = " select * from HRPayrollGenerateTable where HRPayrollID = " & HRPayrollID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckMonth(ByVal Month As String)
            Dim str As String
            str = " select * from HRPayrollGenerateTable where Month = '" & Month & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


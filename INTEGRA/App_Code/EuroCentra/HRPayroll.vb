Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class HRPayroll
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "HRPayroll"
            m_strPrimaryFieldName = "HRPayrollID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRPayrollID As Long
        Private m_lHRID As Long
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
        Private m_strFiscalYear As String
        Private m_dMiscAllowance As Decimal
        Private m_dTaxPercentage As Decimal
        Private m_dtCreationDate As Date

        '----------------Properties
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
        Public Property FiscalYear() As String
            Get
                FiscalYear = m_strFiscalYear
            End Get
            Set(ByVal value As String)
                m_strFiscalYear = value
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
        Public Function SaveHRPayroll()
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
        Function GetHRPayrollID(ByVal lHRID As Long)
            Dim str As String
            str = "Select * from HRPayroll where  HRID =" & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAmount(ByVal lHRID As Long)
            Dim str As String
            str = "select GrossSalary,NetSalary from HRPayroll where HRID = " & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function GetGrossandNetSalary(ByVal lHRID As Long)
            Dim str As String
            str = "select GrossSalary ,NetSalary  from HRPayroll where HRID = " & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

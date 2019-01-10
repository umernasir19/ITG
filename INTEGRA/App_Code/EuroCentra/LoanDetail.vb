Imports System.Data
    
Namespace EuroCentra
    Public Class LoanDetail

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LoanDetail"
            m_strPrimaryFieldName = "LoanDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lLoanDetailID As Long
        Private m_lLoanMasterID As Long
        Private m_dInstallmentAmount As Decimal
        Private m_strInstallmentYear As String
        Private m_strInstallmentMonth As String
        Private m_dLoanOutStatnding As Decimal
        ''---------------- Properties
        Public Property LoanDetailID() As Long
            Get
                LoanDetailID = m_lLoanDetailID
            End Get
            Set(ByVal value As Long)
                m_lLoanDetailID = value
            End Set
        End Property
        Public Property LoanMasterID() As Long
            Get
                LoanMasterID = m_lLoanMasterID
            End Get
            Set(ByVal value As Long)
                m_lLoanMasterID = value
            End Set
        End Property
        Public Property InstallmentAmount() As Decimal
            Get
                InstallmentAmount = m_dInstallmentAmount
            End Get
            Set(ByVal value As Decimal)
                m_dInstallmentAmount = value
            End Set
        End Property
        Public Property InstallmentYear() As String
            Get
                InstallmentYear = m_strInstallmentYear
            End Get
            Set(ByVal value As String)
                m_strInstallmentYear = value
            End Set
        End Property
        Public Property InstallmentMonth() As String
            Get
                InstallmentMonth = m_strInstallmentMonth
            End Get
            Set(ByVal value As String)
                m_strInstallmentMonth = value
            End Set
        End Property
        Public Property LoanOutStatnding() As Decimal
            Get
                LoanOutStatnding = m_dLoanOutStatnding
            End Get
            Set(ByVal value As Decimal)
                m_dLoanOutStatnding = value
            End Set
        End Property
        Public Function SaveLoanDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrencyById(ByVal lCurrencyID As Long)
            Try
                Return MyBase.GetById(lCurrencyID)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

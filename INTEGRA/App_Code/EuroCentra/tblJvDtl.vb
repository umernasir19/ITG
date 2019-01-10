Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblJvDtl

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblJvDtl"
            m_strPrimaryFieldName = "tblJvDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblJvDtlID As Long
        Private m_ltblJVMstID As Long
        Private m_strCompanyId As String
        Private m_strVoucherNo As String
        Private m_strAccountCode As String
        Private m_strDescriptionEntry As String
        Private m_strVoucherType As String
        Private m_dDebit As Decimal
        Private m_dCredit As Decimal
        Private m_strCancel As String
        Private m_dChqClear As Decimal
        Private m_dtChqClearDate As Date
        Private m_dtBankStDate As Date
        Private m_strStaxInvNo As String
        Private m_dtSTaxInvDate As Date
        Private m_strTypeCode As String
        Private m_dExcludingStAmt As Decimal
        Private m_dStaxPer As Decimal
        Private m_dSTaxAmt As Decimal
        Private m_dNetAmount As Decimal
        Private m_dTransfer As Decimal
        Private m_dNotCharge As Decimal
        Private m_strCostCCode As String
        Private m_strSubCostCCode As String
        Private m_lSno As Long
        Private m_dtClear_Date As Date

        Public Property tblJvDtlID() As Long
            Get
                tblJvDtlID = m_ltblJvDtlID
            End Get
            Set(ByVal Value As Long)
                m_ltblJvDtlID = Value
            End Set
        End Property
        Public Property tblJVMstID() As Long
            Get
                tblJVMstID = m_ltblJVMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblJVMstID = Value
            End Set
        End Property
        Public Property CompanyId() As String
            Get
                CompanyId = m_strCompanyId
            End Get
            Set(ByVal Value As String)
                m_strCompanyId = Value
            End Set
        End Property
        Public Property VoucherNo() As String
            Get
                VoucherNo = m_strVoucherNo
            End Get
            Set(ByVal Value As String)
                m_strVoucherNo = Value
            End Set
        End Property
        Public Property AccountCode() As String
            Get
                AccountCode = m_strAccountCode
            End Get
            Set(ByVal Value As String)
                m_strAccountCode = Value
            End Set
        End Property
        Public Property DescriptionEntry() As String
            Get
                DescriptionEntry = m_strDescriptionEntry
            End Get
            Set(ByVal Value As String)
                m_strDescriptionEntry = Value
            End Set
        End Property
        Public Property VoucherType() As String
            Get
                VoucherType = m_strVoucherType
            End Get
            Set(ByVal Value As String)
                m_strVoucherType = Value
            End Set
        End Property
        Public Property Debit() As Decimal
            Get
                Debit = m_dDebit
            End Get
            Set(ByVal Value As Decimal)
                m_dDebit = Value
            End Set
        End Property
        Public Property Credit() As Decimal
            Get
                Credit = m_dCredit
            End Get
            Set(ByVal Value As Decimal)
                m_dCredit = Value
            End Set
        End Property
        Public Property Cancel() As String
            Get
                Cancel = m_strCancel
            End Get
            Set(ByVal Value As String)
                m_strCancel = Value
            End Set
        End Property
        Public Property ChqClear() As Decimal
            Get
                ChqClear = m_dChqClear
            End Get
            Set(ByVal Value As Decimal)
                m_dChqClear = Value
            End Set
        End Property
        Public Property ChqClearDate() As Date
            Get
                ChqClearDate = m_dtChqClearDate
            End Get
            Set(ByVal Value As Date)
                m_dtChqClearDate = Value
            End Set
        End Property
        Public Property BankStDate() As Date
            Get
                BankStDate = m_dtBankStDate
            End Get
            Set(ByVal Value As Date)
                m_dtBankStDate = Value
            End Set
        End Property
        Public Property StaxInvNo() As String
            Get
                StaxInvNo = m_strStaxInvNo
            End Get
            Set(ByVal Value As String)
                m_strStaxInvNo = Value
            End Set
        End Property
        Public Property STaxInvDate() As Date
            Get
                STaxInvDate = m_dtSTaxInvDate
            End Get
            Set(ByVal Value As Date)
                m_dtSTaxInvDate = Value
            End Set
        End Property
        Public Property TypeCode() As String
            Get
                TypeCode = m_strTypeCode
            End Get
            Set(ByVal Value As String)
                m_strTypeCode = Value
            End Set
        End Property
        Public Property ExcludingStAmt() As Decimal
            Get
                ExcludingStAmt = m_dExcludingStAmt
            End Get
            Set(ByVal Value As Decimal)
                m_dExcludingStAmt = Value
            End Set
        End Property
        Public Property StaxPer() As Decimal
            Get
                StaxPer = m_dStaxPer
            End Get
            Set(ByVal Value As Decimal)
                m_dStaxPer = Value
            End Set
        End Property
        Public Property STaxAmt() As Decimal
            Get
                STaxAmt = m_dSTaxAmt
            End Get
            Set(ByVal Value As Decimal)
                m_dSTaxAmt = Value
            End Set
        End Property
        Public Property NetAmount() As Decimal
            Get
                NetAmount = m_dNetAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dNetAmount = Value
            End Set
        End Property
        Public Property Transfer() As Decimal
            Get
                Transfer = m_dTransfer
            End Get
            Set(ByVal Value As Decimal)
                m_dTransfer = Value
            End Set
        End Property
        Public Property NotCharge() As Decimal
            Get
                NotCharge = m_dNotCharge
            End Get
            Set(ByVal Value As Decimal)
                m_dNotCharge = Value
            End Set
        End Property
        Public Property CostCCode() As String
            Get
                CostCCode = m_strCostCCode
            End Get
            Set(ByVal Value As String)
                m_strCostCCode = Value
            End Set
        End Property
        Public Property SubCostCCode() As String
            Get
                SubCostCCode = m_strSubCostCCode
            End Get
            Set(ByVal Value As String)
                m_strSubCostCCode = Value
            End Set
        End Property
        Public Property Sno() As Long
            Get
                Sno = m_lSno
            End Get
            Set(ByVal Value As Long)
                m_lSno = Value
            End Set
        End Property
        Public Property Clear_Date() As Date
            Get
                Clear_Date = m_dtClear_Date
            End Get
            Set(ByVal Value As Date)
                m_dtClear_Date = Value
            End Set
        End Property

        Public Function SavetblJvDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class

End Namespace


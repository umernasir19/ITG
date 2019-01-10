Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblCashDtl

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblCashDtl"
            m_strPrimaryFieldName = "tblCashDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblCashDtlID As Long
        Private m_ltblCashMstID As Long
        Private m_strCompanyId As String
        Private m_strVoucherNo As String
        Private m_strAccountCode As String
        Private m_strDescriptionEntry As String
        Private m_strChequeNo As String
        Private m_dtChequeDate As String
        Private m_strType As String
        Private m_dAmount As Decimal
        Private m_strCancel As String
        Private m_dChqClear As Decimal
        Private m_dtChqClearDate As Date
        Private m_dtBankStDate As Date
        Private m_dNotCharge As Decimal
        Private m_strVoucherNoOld As String
        Private m_strCostCCode As String
        Private m_strSubCostCCode As String

        Private m_strBank_Name As String
        Private m_strBank_Branch As String
        Private m_bIs_Cancel As Boolean
        Private m_bIs_Clear As Boolean

        Private m_dtClear_Date As Date
        Private m_lSno As Long
        Private m_strDOC_RefNo As String
        Private m_lCostCenterId As Long
        Public Property CostCenterId() As Long
            Get
                CostCenterId = m_lCostCenterId
            End Get
            Set(ByVal Value As Long)
                m_lCostCenterId = Value
            End Set
        End Property
        Public Property tblCashDtlID() As Long
            Get
                tblCashDtlID = m_ltblCashDtlID
            End Get
            Set(ByVal Value As Long)
                m_ltblCashDtlID = Value
            End Set
        End Property
        Public Property tblCashMstID() As Long
            Get
                tblCashMstID = m_ltblCashMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblCashMstID = Value
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
        Public Property ChequeNo() As String
            Get
                ChequeNo = m_strChequeNo
            End Get
            Set(ByVal Value As String)
                m_strChequeNo = Value
            End Set
        End Property
        Public Property ChequeDate() As String
            Get
                ChequeDate = m_dtChequeDate
            End Get
            Set(ByVal Value As String)
                m_dtChequeDate = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal Value As String)
                m_strType = Value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dAmount = Value
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
        Public Property NotCharge() As Decimal
            Get
                NotCharge = m_dNotCharge
            End Get
            Set(ByVal Value As Decimal)
                m_dNotCharge = Value
            End Set
        End Property
        Public Property VoucherNoOld() As String
            Get
                VoucherNoOld = m_strVoucherNoOld
            End Get
            Set(ByVal Value As String)
                m_strVoucherNoOld = Value
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

        Public Property Bank_Name() As String
            Get
                Bank_Name = m_strBank_Name
            End Get
            Set(ByVal Value As String)
                m_strBank_Name = Value
            End Set
        End Property
        Public Property Bank_Branch() As String
            Get
                Bank_Branch = m_strBank_Branch
            End Get
            Set(ByVal Value As String)
                m_strBank_Branch = Value
            End Set
        End Property
        Public Property Is_Cancel() As Boolean
            Get
                Is_Cancel = m_bIs_Cancel
            End Get
            Set(ByVal Value As Boolean)
                m_bIs_Cancel = Value
            End Set
        End Property
        Public Property Is_Clear() As Boolean
            Get
                Is_Clear = m_bIs_Clear
            End Get
            Set(ByVal Value As Boolean)
                m_bIs_Clear = Value
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
        Public Property Sno() As Long
            Get
                Sno = m_lSno
            End Get
            Set(ByVal Value As Long)
                m_lSno = Value
            End Set
        End Property
        Public Property DOC_RefNo() As String
            Get
                DOC_RefNo = m_strDOC_RefNo
            End Get
            Set(ByVal Value As String)
                m_strDOC_RefNo = Value
            End Set
        End Property

        Public Function SavetblCashDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class

End Namespace

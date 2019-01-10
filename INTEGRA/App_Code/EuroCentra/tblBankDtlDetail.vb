Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class tblBankDtlDetail


        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblBankDtlDetail"
            m_strPrimaryFieldName = "tblBankDtlDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblBankDtlDetailID As Long
        Private m_ltblBankMstID As Long
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

        Private m_dInitialAmount As Decimal
        Private m_dWHTaxPercentage As Decimal
        Private m_dWHTaxAmountCr As Decimal
        Private m_dGSTaxPercentage As Decimal
        Private m_dGSTaxAmountCr As Decimal
        Private m_dWHTaxAmountDB As Decimal
        Private m_dGSTaxAmountDB As Decimal

        Private m_lPaymentTermID As Long
        Private m_strInvNo As String
        Private m_lCostCenterId As Long
        Public Property CostCenterId() As Long
            Get
                CostCenterId = m_lCostCenterId
            End Get
            Set(ByVal Value As Long)
                m_lCostCenterId = Value
            End Set
        End Property
        Public Property InvNo() As String
            Get
                InvNo = m_strInvNo
            End Get
            Set(ByVal Value As String)
                m_strInvNo = Value
            End Set
        End Property
        Public Property tblBankDtlDetailID() As Long
            Get
                tblBankDtlDetailID = m_ltblBankDtlDetailID
            End Get
            Set(ByVal Value As Long)
                m_ltblBankDtlDetailID = Value
            End Set
        End Property
        Public Property tblBankMstID() As Long
            Get
                tblBankMstID = m_ltblBankMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblBankMstID = Value
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

        Public Property InitialAmount() As Decimal
            Get
                InitialAmount = m_dInitialAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dInitialAmount = Value
            End Set
        End Property



        Public Property WHTaxPercentage() As Decimal
            Get
                WHTaxPercentage = m_dWHTaxPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_dWHTaxPercentage = Value
            End Set
        End Property
        Public Property WHTaxAmountCr() As Decimal
            Get
                WHTaxAmountCr = m_dWHTaxAmountCr
            End Get
            Set(ByVal Value As Decimal)
                m_dWHTaxAmountCr = Value
            End Set
        End Property
        Public Property GSTaxPercentage() As Decimal
            Get
                GSTaxPercentage = m_dGSTaxPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_dGSTaxPercentage = Value
            End Set
        End Property
        Public Property GSTaxAmountCr() As Decimal
            Get
                GSTaxAmountCr = m_dGSTaxAmountCr
            End Get
            Set(ByVal Value As Decimal)
                m_dGSTaxAmountCr = Value
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
        Public Property WHTaxAmountDB() As Decimal
            Get
                WHTaxAmountDB = m_dWHTaxAmountDB
            End Get
            Set(ByVal Value As Decimal)
                m_dWHTaxAmountDB = Value
            End Set
        End Property
        Public Property GSTaxAmountDB() As Decimal
            Get
                GSTaxAmountDB = m_dGSTaxAmountDB
            End Get
            Set(ByVal Value As Decimal)
                m_dGSTaxAmountDB = Value
            End Set
        End Property

        Public Property PaymentTermID() As Long
            Get
                PaymentTermID = m_lPaymentTermID
            End Get
            Set(ByVal Value As Long)
                m_lPaymentTermID = Value
            End Set
        End Property
        Public Function SavetblBankDtlDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class

End Namespace


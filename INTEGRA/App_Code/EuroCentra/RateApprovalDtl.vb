Imports System.Data
Public Class RateApprovalDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "RateApprovalDtl"
        m_strPrimaryFieldName = "RateApprovalDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lRateApprovalDtlID As Long
    Private m_lRateApprovalMstID As Long
    Private m_lBankID As Long
    Private m_lRate As Decimal
    Public Property RateApprovalDtlID() As Long
        Get
            RateApprovalDtlID = m_lRateApprovalDtlID
        End Get
        Set(ByVal Value As Long)
            m_lRateApprovalDtlID = Value
        End Set
    End Property
    Public Property RateApprovalMstID() As Long
        Get
            RateApprovalMstID = m_lRateApprovalMstID
        End Get
        Set(ByVal Value As Long)
            m_lRateApprovalMstID = Value
        End Set
    End Property
    Public Property BankID() As Long
        Get
            BankID = m_lBankID
        End Get
        Set(ByVal Value As Long)
            m_lBankID = Value
        End Set
    End Property
    Public Property Rate() As Decimal
        Get
            Rate = m_lRate
        End Get
        Set(ByVal value As Decimal)
            m_lRate = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

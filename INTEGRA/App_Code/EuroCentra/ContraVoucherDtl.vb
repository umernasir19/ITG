Imports Microsoft.VisualBasic
Imports System.Data
Public Class ContraVoucherDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ContraVoucherDtl"
        m_strPrimaryFieldName = "ContraVoucherDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lContraVoucherDtlID As Long
    Private m_lContraVoucherMstID As Long
    Private m_strParticulars As String
    Private m_dAmount As Decimal
    Private m_strNarration As String
    Private m_strAccountCode As String
    Private m_strDrCr As String
    Private m_lCostCenterId As Long
    Public Property CostCenterId() As Long
        Get
            CostCenterId = m_lCostCenterId
        End Get
        Set(ByVal Value As Long)
            m_lCostCenterId = Value
        End Set
    End Property
    Public Property ContraVoucherDtlID() As Long
        Get
            ContraVoucherDtlID = m_lContraVoucherDtlID
        End Get
        Set(ByVal Value As Long)
            m_lContraVoucherDtlID = Value
        End Set
    End Property
    Public Property ContraVoucherMstID() As Long
        Get
            ContraVoucherMstID = m_lContraVoucherMstID
        End Get
        Set(ByVal Value As Long)
            m_lContraVoucherMstID = Value
        End Set
    End Property

    Public Property Particulars() As String
        Get
            Particulars = m_strParticulars
        End Get
        Set(ByVal Value As String)
            m_strParticulars = Value
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
    Public Property Narration() As String
        Get
            Narration = m_strNarration
        End Get
        Set(ByVal Value As String)
            m_strNarration = Value
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
    Public Property DrCr() As String
        Get
            DrCr = m_strDrCr
        End Get
        Set(ByVal Value As String)
            m_strDrCr = Value
        End Set
    End Property
    Public Function SaveDetail()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

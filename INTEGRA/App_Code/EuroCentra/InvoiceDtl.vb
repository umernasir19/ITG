Imports System.Data
Imports Microsoft.VisualBasic

Public Class InvoiceDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "tblInvoiceDtl"
        m_strPrimaryFieldName = "InvoiceDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lInvoiceDtlID As Long
    Private m_lInvoiceMstID As Long
    Private m_dtCreationDate As Date
    Private m_dOpeningAmount As Decimal
    Private m_dAjustedAmount As Decimal
    Private m_dBalanceAmountDTL As Decimal
    Private m_strPaymentType As String
    Private m_strPaymentVocuherRefNo As String
    Public Property InvoiceDtlID() As Long
        Get
            InvoiceDtlID = m_lInvoiceDtlID
        End Get
        Set(ByVal value As Long)
            m_lInvoiceDtlID = value
        End Set
    End Property
    Public Property InvoiceMstID() As Long
        Get
            InvoiceMstID = m_lInvoiceMstID
        End Get
        Set(ByVal value As Long)
            m_lInvoiceMstID = value
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
    Public Property OpeningAmount() As Decimal
        Get
            OpeningAmount = m_dOpeningAmount
        End Get
        Set(ByVal value As Decimal)
            m_dOpeningAmount = value
        End Set
    End Property
    Public Property AjustedAmount() As Decimal
        Get
            AjustedAmount = m_dAjustedAmount
        End Get
        Set(ByVal value As Decimal)
            m_dAjustedAmount = value
        End Set
    End Property
    Public Property BalanceAmountDTL() As Decimal
        Get
            BalanceAmountDTL = m_dBalanceAmountDTL
        End Get
        Set(ByVal value As Decimal)
            m_dBalanceAmountDTL = value
        End Set
    End Property
    Public Property PaymentType() As String
        Get
            PaymentType = m_strPaymentType
        End Get
        Set(ByVal value As String)
            m_strPaymentType = value
        End Set
    End Property
   
    Public Property PaymentVocuherRefNo() As String
        Get
            PaymentVocuherRefNo = m_strPaymentVocuherRefNo
        End Get
        Set(ByVal value As String)
            m_strPaymentVocuherRefNo = value
        End Set
    End Property
    Public Function SaveInvoiceDtl()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function

End Class

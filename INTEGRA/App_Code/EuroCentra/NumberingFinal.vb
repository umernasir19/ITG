Imports Microsoft.VisualBasic
Imports System.Data
Public Class NumberingFinal
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "NumberingFinal"
        m_strPrimaryFieldName = "NumberingFinalID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lNumberingFinalID As Long
    Private m_lNumberingID As Long
    Private m_dCreationDate As Date
    Private m_lUserId As Long
    Private m_strReceivingNo As String
    Private m_lCustomerID As Long
    Private m_strCustomerPoNo As String
    Private m_dReceiveDate As Date
    Private m_dQty As Decimal
    Private m_dCarton As Decimal
    Private m_dWeight As Decimal
    Public Property Weight() As Decimal
        Get
            Weight = m_dWeight
        End Get
        Set(ByVal value As Decimal)
            m_dWeight = value
        End Set
    End Property
    Public Property Qty() As Decimal
        Get
            Qty = m_dQty
        End Get
        Set(ByVal value As Decimal)
            m_dQty = value
        End Set
    End Property
    Public Property Carton() As Decimal
        Get
            Carton = m_dCarton
        End Get
        Set(ByVal value As Decimal)
            m_dCarton = value
        End Set
    End Property
    Public Property ReceiveDate() As Date
        Get
            ReceiveDate = m_dReceiveDate
        End Get
        Set(ByVal Value As Date)
            m_dReceiveDate = Value
        End Set
    End Property
    Public Property CustomerPoNo() As String
        Get
            CustomerPoNo = m_strCustomerPoNo
        End Get
        Set(ByVal value As String)
            m_strCustomerPoNo = value
        End Set
    End Property
    Public Property CustomerID() As Long
        Get
            CustomerID = m_lCustomerID
        End Get
        Set(ByVal Value As Long)
            m_lCustomerID = Value
        End Set
    End Property
    Public Property NumberingID() As Long
        Get
            NumberingID = m_lNumberingID
        End Get
        Set(ByVal Value As Long)
            m_lNumberingID = Value
        End Set
    End Property
    Public Property ReceivingNo() As String
        Get
            ReceivingNo = m_strReceivingNo
        End Get
        Set(ByVal value As String)
            m_strReceivingNo = value
        End Set
    End Property
    Public Property NumberingFinalID() As Long
        Get
            NumberingFinalID = m_lNumberingFinalID
        End Get
        Set(ByVal Value As Long)
            m_lNumberingFinalID = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dCreationDate = Value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal Value As Long)
            m_lUserId = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
End Class


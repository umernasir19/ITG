Imports Microsoft.VisualBasic
Imports System.Data
Public Class ConsumptionEntryMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ConMst"
        m_strPrimaryFieldName = "ConMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lConMstID As Long
    Private m_dCreationDate As Date
    Private m_lUserId As Long
    Private m_lSupplierID As Long
    Private m_dSeasonName As String
    Private m_stCustomer As String
    Private m_strOrderNo As String
    Private m_strOrderRecvDate As String
    Private m_lJobOrderId As Long
    Public Property JobOrderId() As Long
        Get
            JobOrderId = m_lJobOrderId
        End Get
        Set(ByVal Value As Long)
            m_lJobOrderId = Value
        End Set
    End Property
    Public Property ConMstID() As Long
        Get
            ConMstID = m_lConMstID
        End Get
        Set(ByVal Value As Long)
            m_lConMstID = Value
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
    Public Property SupplierID() As Long
        Get
            SupplierID = m_lSupplierID
        End Get
        Set(ByVal Value As Long)
            m_lSupplierID = Value
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
    Public Property OrderRecvDate() As String
        Get
            OrderRecvDate = m_strOrderRecvDate
        End Get
        Set(ByVal Value As String)
            m_strOrderRecvDate = Value
        End Set
    End Property
    Public Property SeasonName() As String
        Get
            SeasonName = m_dSeasonName
        End Get
        Set(ByVal Value As String)
            m_dSeasonName = Value
        End Set
    End Property
   
    Public Property Customer() As String
        Get
            Customer = m_stCustomer
        End Get
        Set(ByVal Value As String)
            m_stCustomer = Value
        End Set
    End Property
    Public Property OrderNo() As String
        Get
            OrderNo = m_strOrderNo
        End Get
        Set(ByVal Value As String)
            m_strOrderNo = Value
        End Set
    End Property
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

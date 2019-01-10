Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class PoReturnClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POReturn"
        m_strPrimaryFieldName = "POReturnId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_POReturnId As Long
    Private m_POID As Long
    Private m_UserId As Long
    Private m_CreationDate As Date
    Private m_ReturnDate As Date
    Private m_dReturnQty As Decimal
    Private m_strDCNO As String
    Private m_strReturnRemarks As String
    Private m_PoDetailId As Long
    Private m_PORecvMasterID As Long
    Private m_PORecvDetailID As Long
    Private m_ItemID As Long
    Public Property ItemID() As Long
        Get
            ItemID = m_ItemID
        End Get
        Set(ByVal value As Long)
            m_ItemID = value
        End Set
    End Property
    Public Property PORecvDetailID() As Long
        Get
            PORecvDetailID = m_PORecvDetailID
        End Get
        Set(ByVal value As Long)
            m_PORecvDetailID = value
        End Set
    End Property
    Public Property PORecvMasterID() As Long
        Get
            PORecvMasterID = m_PORecvMasterID
        End Get
        Set(ByVal value As Long)
            m_PORecvMasterID = value
        End Set
    End Property
    Public Property PoDetailId() As Long
        Get
            PoDetailId = m_PoDetailId
        End Get
        Set(ByVal value As Long)
            m_PoDetailId = value
        End Set
    End Property
    Public Property DCNO() As String
        Get
            DCNO = m_strDCNO
        End Get
        Set(ByVal value As String)
            m_strDCNO = value
        End Set
    End Property
    Public Property ReturnRemarks() As String
        Get
            ReturnRemarks = m_strReturnRemarks
        End Get
        Set(ByVal value As String)
            m_strReturnRemarks = value
        End Set
    End Property
    Public Property POReturnId() As Long
        Get
            POReturnId = m_POReturnId
        End Get
        Set(ByVal value As Long)
            m_POReturnId = value
        End Set
    End Property
    Public Property POID() As Long
        Get
            POID = m_POID
        End Get
        Set(ByVal value As Long)
            m_POID = value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_UserId
        End Get
        Set(ByVal value As Long)
            m_UserId = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_CreationDate
        End Get
        Set(ByVal value As Date)
            m_CreationDate = value
        End Set
    End Property
    Public Property ReturnDate() As Date
        Get
            ReturnDate = m_ReturnDate
        End Get
        Set(ByVal value As Date)
            m_ReturnDate = value
        End Set
    End Property
    Public Property ReturnQty() As Decimal
        Get
            ReturnQty = m_dReturnQty
        End Get
        Set(ByVal value As Decimal)
            m_dReturnQty = value
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

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class FPOReturn
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "FPOReturn"
        m_strPrimaryFieldName = "FPOReturnId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_FPOReturnId As Long
    Private m_POID As Long
    Private m_PODetailID As Long
    Private m_PORecvMasterID As Long
    Private m_PORecvDetailID As Long
    Private m_UserId As Long
    Private m_CreationDate As Date
    Private m_ReturnDate As Date
    Private m_dReturnQty As Decimal
    Private m_ItemID As Long
    Private m_lLocationID As Long
    Public Property LocationID() As Long
        Get
            LocationID = m_lLocationID
        End Get
        Set(ByVal value As Long)
            m_lLocationID = value
        End Set
    End Property
    Public Property FPOReturnId() As Long
        Get
            FPOReturnId = m_FPOReturnId
        End Get
        Set(ByVal value As Long)
            m_FPOReturnId = value
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
    Public Property PODetailID() As Long
        Get
            PODetailID = m_PODetailID
        End Get
        Set(ByVal value As Long)
            m_PODetailID = value
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
    Public Property PORecvDetailID() As Long
        Get
            PORecvDetailID = m_PORecvDetailID
        End Get
        Set(ByVal value As Long)
            m_PORecvDetailID = value
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
    Public Property ItemID() As Long
        Get
            ItemID = m_ItemID
        End Get
        Set(ByVal value As Long)
            m_ItemID = value
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

    Public Function GetLocation(ByVal PORecvMasterID As Long)
        Dim str As String
        Try
            str = " select * from PORecvMaster pom join Location lc on LC.Locationid=pom.Locationid "
            str &= "   where PORecvMasterID='" & PORecvMasterID & "'  "
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetReturnedQty(ByVal POID As Long, ByVal PODetailID As Long, ByVal PORecvMasterID As Long, ByVal PORecvDetailID As Long, ByVal ItemID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from FPOReturn  "
            str &= "   where POID='" & POID & "' and PODetailID='" & PODetailID & "' and PORecvMasterID='" & PORecvMasterID & "' and PORecvDetailID='" & PORecvDetailID & "' and ItemID='" & ItemID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUpdateReturnQty(ByVal ReturnQty As Decimal, ByVal PODetailID As Long, ByVal PORecvMasterID As Long, ByVal PORecvDetailID As Long)
        Dim str As String
        Try
            str = " UPDATE PORecvDetail set ReturnQty='" & ReturnQty & "'"
            str &= "   where PODetailID='" & PODetailID & "' and PORecvMasterID='" & PORecvMasterID & "' and PORecvDetailID='" & PORecvDetailID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

End Class

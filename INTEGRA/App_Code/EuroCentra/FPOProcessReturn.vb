Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class FPOProcessReturn
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "FPOProcessReturn"
        m_strPrimaryFieldName = "FPOProcessReturnId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_FPOProcessReturnId As Long
    Private m_ProcessOrderMstID As Long
    Private m_ProcessOrderDtlID As Long
    Private m_POProcessRecvMasterID As Long
    Private m_POProcessRecvDetailID As Long
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
    Public Property FPOProcessReturnId() As Long
        Get
            FPOProcessReturnId = m_FPOProcessReturnId
        End Get
        Set(ByVal value As Long)
            m_FPOProcessReturnId = value
        End Set
    End Property
    Public Property ProcessOrderMstID() As Long
        Get
            ProcessOrderMstID = m_ProcessOrderMstID
        End Get
        Set(ByVal value As Long)
            m_ProcessOrderMstID = value
        End Set
    End Property
    Public Property ProcessOrderDtlID() As Long
        Get
            ProcessOrderDtlID = m_ProcessOrderDtlID
        End Get
        Set(ByVal value As Long)
            m_ProcessOrderDtlID = value
        End Set
    End Property
    Public Property POProcessRecvMasterID() As Long
        Get
            POProcessRecvMasterID = m_POProcessRecvMasterID
        End Get
        Set(ByVal value As Long)
            m_POProcessRecvMasterID = value
        End Set
    End Property
    Public Property POProcessRecvDetailID() As Long
        Get
            POProcessRecvDetailID = m_POProcessRecvDetailID
        End Get
        Set(ByVal value As Long)
            m_POProcessRecvDetailID = value
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

    Public Function GetLocation(ByVal POProcessRecvMasterID As Long)
        Dim str As String
        Try
            str = " select * from POProcessRecvMaster pom join Location lc on LC.Locationid=pom.Locationid "
            str &= "   where POProcessRecvMasterID='" & POProcessRecvMasterID & "'  "
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetReturnedQty(ByVal ProcessOrderMstID As Long, ByVal ProcessOrderDtlID As Long, ByVal POProcessRecvMasterID As Long, ByVal POProcessRecvDetailID As Long, ByVal ItemID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from FPOProcessReturn  "
            str &= "   where ProcessOrderMstID='" & ProcessOrderMstID & "' and ProcessOrderDtlID='" & ProcessOrderDtlID & "' and POProcessRecvMasterID='" & POProcessRecvMasterID & "' and POProcessRecvDetailID='" & POProcessRecvDetailID & "' and ItemID='" & ItemID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUpdateReturnQty(ByVal ReturnQty As Decimal, ByVal ProcessOrderDtlID As Long, ByVal POProcessRecvMasterID As Long, ByVal POProcessRecvDetailID As Long)
        Dim str As String
        Try
            str = " UPDATE POProcessRecvDetail set ReturnQty='" & ReturnQty & "'"
            str &= "   where ProcessOrderDtlID='" & ProcessOrderDtlID & "' and POProcessRecvMasterID='" & POProcessRecvMasterID & "' and POProcessRecvDetailID='" & POProcessRecvDetailID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

End Class


Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class CommercialPackingListMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CommercialPackingListMst"
        m_strPrimaryFieldName = "CommercialPackingListMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lCommercialPackingListMstID As Long
    Private m_lUserId As Long
    Private m_lCargoId As Long
    Private m_lJobOrderId As Long
    Private m_dtCreationDate As Date
    Public Property CommercialPackingListMstID() As Long
        Get
            CommercialPackingListMstID = m_lCommercialPackingListMstID
        End Get
        Set(ByVal value As Long)
            m_lCommercialPackingListMstID = value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal value As Long)
            m_lUserId = value
        End Set
    End Property
    Public Property CargoId() As Long
        Get
            CargoId = m_lCargoId
        End Get
        Set(ByVal value As Long)
            m_lCargoId = value
        End Set
    End Property
    Public Property JobOrderId() As Long
        Get
            JobOrderId = m_lJobOrderId
        End Get
        Set(ByVal value As Long)
            m_lJobOrderId = value
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
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception
        End Try
    End Function
End Class

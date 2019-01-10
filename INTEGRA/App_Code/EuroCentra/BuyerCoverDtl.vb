Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class BuyerCoverDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BuyerCoverDtl"
        m_strPrimaryFieldName = "BuyerCoverDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lBuyerCoverDtlID As Long
    Private m_lBuyerCoverMstID As Long
    Private m_lListID As Long
    Private m_strListNo As String

    Public Property BuyerCoverDtlID() As Long
        Get
            BuyerCoverDtlID = m_lBuyerCoverDtlID
        End Get
        Set(ByVal value As Long)
            m_lBuyerCoverDtlID = value
        End Set
    End Property
    Public Property BuyerCoverMstID() As Long
        Get
            BuyerCoverMstID = m_lBuyerCoverMstID
        End Get
        Set(ByVal value As Long)
            m_lBuyerCoverMstID = value
        End Set
    End Property
    Public Property ListID() As Long
        Get
            ListID = m_lListID
        End Get
        Set(ByVal value As Long)
            m_lListID = value
        End Set
    End Property
    Public Property ListNo() As String
        Get
            ListNo = m_strListNo
        End Get
        Set(ByVal value As String)
            m_strListNo = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Public Class BankCoverDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BankCoverDtl"
        m_strPrimaryFieldName = "BankCoverDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lBankCoverDtlID As Long
    Private m_lBankCoverMstID As Long
    Private m_lListID As Long
    Private m_strListNo As String

    Public Property BankCoverDtlID() As Long
        Get
            BankCoverDtlID = m_lBankCoverDtlID
        End Get
        Set(ByVal value As Long)
            m_lBankCoverDtlID = value
        End Set
    End Property
    Public Property BankCoverMstID() As Long
        Get
            BankCoverMstID = m_lBankCoverMstID
        End Get
        Set(ByVal value As Long)
            m_lBankCoverMstID = value
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


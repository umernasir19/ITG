Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class CargoStyleDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CargoStyleDtl"
        m_strPrimaryFieldName = "CargoStyleDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCargoStyleDtlID As Long
    Private m_lCargoID As Long
    Private m_lDesc As String
    Private m_strStyle As String
    Private m_dtPCS As Decimal
    Public Property CargoStyleDtlID() As Long
        Get
            CargoStyleDtlID = m_lCargoStyleDtlID
        End Get
        Set(ByVal value As Long)
            m_lCargoStyleDtlID = value
        End Set
    End Property
    Public Property CargoID() As Long
        Get
            CargoID = m_lCargoID
        End Get
        Set(ByVal value As Long)
            m_lCargoID = value
        End Set
    End Property
    Public Property Style() As String
        Get
            Style = m_strStyle
        End Get
        Set(ByVal value As String)
            m_strStyle = value
        End Set
    End Property
    Public Property Desc() As String
        Get
            Desc = m_lDesc
        End Get
        Set(ByVal value As String)
            m_lDesc = value
        End Set
    End Property
    Public Property PCS() As Decimal
        Get
            PCS = m_dtPCS
        End Get
        Set(ByVal value As Decimal)
            m_dtPCS = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
End Class

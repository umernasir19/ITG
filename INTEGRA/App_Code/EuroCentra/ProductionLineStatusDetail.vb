Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class ProductionLineStatusDetail
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ProductionLineStatusDetail"
        m_strPrimaryFieldName = "PLSDID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPLSDID As Long
    Private m_lPLSEID As Long
    Private m_strStyleNo As String
    Private m_strBookedQuantity As String
    Private m_strBookedLines As String
    '''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''
    Public Property PLSDID() As Long
        Get
            PLSDID = m_lPLSDID
        End Get
        Set(ByVal value As Long)
            m_lPLSDID = value
        End Set
    End Property
    Public Property PLSEID() As Long
        Get
            PLSEID = m_lPLSEID
        End Get
        Set(ByVal value As Long)
            m_lPLSEID = value
        End Set
    End Property
    Public Property StyleNo() As String
        Get
            StyleNo = m_strStyleNo
        End Get
        Set(ByVal value As String)
            m_strStyleNo = value
        End Set
    End Property
    Public Property BookedQuantity() As String
        Get
            BookedQuantity = m_strBookedQuantity
        End Get
        Set(ByVal value As String)
            m_strBookedQuantity = value
        End Set
    End Property
    Public Property BookedLines() As String
        Get
            BookedLines = m_strBookedLines
        End Get
        Set(ByVal value As String)
            m_strBookedLines = value
        End Set
    End Property

    ''''''''''''''''''''''''''''''''''''''''''''''Quries''''''''''''''''''''''''''''''''''''''
    Public Function SaveProductionStatusDetail()
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
    Public Function GetDetailID(ByVal PLSEID As Long) As DataTable
        Dim str As String
        str = " Select PLSDID from ProductionLineStatusDetail Where PLSEID =" & PLSEID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class

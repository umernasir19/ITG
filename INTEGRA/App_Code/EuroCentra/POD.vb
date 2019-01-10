Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class POD
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "tblPOD"
        m_strPrimaryFieldName = "PODId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lPODId As Long
    Private m_strPOD As String
    Public Property PODId() As Long
        Get
            PODId = m_lPODId
        End Get
        Set(ByVal value As Long)
            m_lPODId = value
        End Set
    End Property
    Public Property POD() As String
        Get
            POD = m_strPOD
        End Get
        Set(ByVal value As String)
            m_strPOD = value
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

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class Location

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "Location"
        m_strPrimaryFieldName = "LocationId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''

    Private m_lLocationId As Long
    Private m_strLocation As String
  
    Public Property LocationId() As Long
        Get
            LocationId = m_lLocationId
        End Get
        Set(ByVal value As Long)
            m_lLocationId = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Location = m_strLocation
        End Get
        Set(ByVal value As String)
            m_strLocation = value
        End Set
    End Property
    Public Function SaveGodown()
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

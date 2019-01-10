Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class StyleAccessories
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleAccessories"
            m_strPrimaryFieldName = "SAID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_SAID As Long
        Private m_lStyleID As Long
        Private m_AccessoriesID As Long
        Private m_AccessoriesDescription As String
        Private m_Source As String

        Public Property SAID() As Long
            Get
                SAID = m_SAID
            End Get
            Set(ByVal value As Long)
                m_SAID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
            End Set
        End Property
        Public Property AccessoriesID() As Long
            Get
                AccessoriesID = m_AccessoriesID
            End Get
            Set(ByVal value As Long)
                m_AccessoriesID = value
            End Set
        End Property
        Public Property AccessoriesDescription() As String
            Get
                AccessoriesDescription = m_AccessoriesDescription
            End Get
            Set(ByVal value As String)
                m_AccessoriesDescription = value
            End Set
        End Property
        Public Property Source() As String
            Get
                Source = m_Source
            End Get
            Set(ByVal value As String)
                m_Source = value
            End Set
        End Property
        Public Function SaveStyleAccessories()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetailFromStyleAccessDetail(ByVal SAID As Long, ByVal StyleID As Long)
            Dim Str As String
            Str = " Delete from StyleAccessories where SAID=' " & SAID & " ' and StyleID='" & StyleID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
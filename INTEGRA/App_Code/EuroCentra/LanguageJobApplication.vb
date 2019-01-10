Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class LanguageJobApplication
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobApplicationLanguage"
            m_strPrimaryFieldName = "LanguagesId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lLanguagesId As Long
        Private m_lJobApplicationID As Long
        Private m_strLanguage As String
        Public Property LanguagesId() As Long
            Get
                LanguagesId = m_lLanguagesId
            End Get
            Set(ByVal value As Long)
                m_lLanguagesId = value
            End Set
        End Property
        Public Property JobApplicationID() As Long
            Get
                JobApplicationID = m_lJobApplicationID
            End Get
            Set(ByVal value As Long)
                m_lJobApplicationID = value
            End Set
        End Property
        Public Property Language() As String
            Get
                Language = m_strLanguage
            End Get
            Set(ByVal value As String)
                m_strLanguage = value
            End Set
        End Property

        Public Function SaveLanguageJobApplication()
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
End Namespace




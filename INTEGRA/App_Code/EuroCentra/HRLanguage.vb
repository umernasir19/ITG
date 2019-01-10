Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

Public Class HRLanguage
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRLanguage"
            m_strPrimaryFieldName = "LanguageID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lLanguageID As Long
        Private m_lHRID As Long
        Private m_strLanguages As String
        '----------------Properties
        Public Property LanguageID() As Long
            Get
                LanguageID = m_lLanguageID
            End Get
            Set(ByVal value As Long)
                m_lLanguageID = value
            End Set
        End Property
        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
            End Set
        End Property
        Public Property Languages() As String
            Get
                Languages = m_strLanguages
            End Get
            Set(ByVal value As String)
                m_strLanguages = value
            End Set
        End Property


        Public Function SaveHRLanguage()
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
        Public Function GetLanguage() As DataTable
            Dim Str As String
            Str = "Select LanguageID,Languages from HRLanguage"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function HRLanguageOnEdit(ByVal lHRID As Long)
            Dim str As String
            str = "  Select * from HRLanguage where  HRID =" & lHRID
             
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

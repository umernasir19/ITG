Imports Microsoft.VisualBasic
Imports System.Data
Public Class Gender1
    Inherits SQLManager
    Public Sub New()

        m_strTableName = "Gender1"
        m_strPrimaryFieldName = "GenderId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lGenderId As Long
    Private m_strGender As String
    Public Property GenderId() As Long
        Get
            GenderId = m_lGenderId
        End Get
        Set(ByVal Value As Long)
            m_lGenderId = Value
        End Set
    End Property
    Public Property Gender() As String
        Get
            Gender = m_strGender
        End Get
        Set(ByVal Value As String)
            m_strGender = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

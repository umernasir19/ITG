Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class SymbolTumbleDry
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SymbolTumbleDry"
            m_strPrimaryFieldName = "TumbleDryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_TumbleDryID As Long
        Private m_TumbleDryname As String
        Private m_imTumbleDryImage As Object

        Public Property TumbleDryID() As Long
            Get
                TumbleDryID = m_TumbleDryID
            End Get
            Set(ByVal value As Long)
                m_TumbleDryID = value
            End Set
        End Property
        Public Property TumbleDryname() As String
            Get
                TumbleDryname = m_TumbleDryname
            End Get
            Set(ByVal value As String)
                m_TumbleDryname = value
            End Set
        End Property
        Public Property TumbleDryImage() As Object
            Get
                TumbleDryImage = m_imTumbleDryImage
            End Get
            Set(ByVal Value As Object)
                m_imTumbleDryImage = Value
            End Set
        End Property
        Public Function SaveTSymbol()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

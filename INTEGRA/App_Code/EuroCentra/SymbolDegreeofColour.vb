Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class SymbolDegreeofColour
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SymbolDegreeofColour"
            m_strPrimaryFieldName = "DegreeofColourID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_DegreeofColourID As Long
        Private m_DegreeofColourname As String
        Private m_imDegreeofColourImage As Object

        Public Property DegreeofColourID() As Long
            Get
                DegreeofColourID = m_DegreeofColourID
            End Get
            Set(ByVal value As Long)
                m_DegreeofColourID = value
            End Set
        End Property
        Public Property DegreeofColourname() As String
            Get
                DegreeofColourname = m_DegreeofColourname
            End Get
            Set(ByVal value As String)
                m_DegreeofColourname = value
            End Set
        End Property
        Public Property DegreeofColourImage() As Object
            Get
                DegreeofColourImage = m_imDegreeofColourImage
            End Get
            Set(ByVal Value As Object)
                m_imDegreeofColourImage = Value
            End Set
        End Property
        Public Function SaveDSymbol()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


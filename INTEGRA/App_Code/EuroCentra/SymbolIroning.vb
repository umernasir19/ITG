Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class SymbolIroning
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SymbolIroning"
            m_strPrimaryFieldName = "IroningSymbolID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_IroningSymbolID As Long
        Private m_IroningSymbolname As String
        Private m_imIroningSymbolImage As Object

        Public Property IroningSymbolID() As Long
            Get
                IroningSymbolID = m_IroningSymbolID
            End Get
            Set(ByVal value As Long)
                m_IroningSymbolID = value
            End Set
        End Property
        Public Property IroningSymbolname() As String
            Get
                IroningSymbolname = m_IroningSymbolname
            End Get
            Set(ByVal value As String)
                m_IroningSymbolname = value
            End Set
        End Property
        Public Property IroningSymbolImage() As Object
            Get
                IroningSymbolImage = m_imIroningSymbolImage
            End Get
            Set(ByVal Value As Object)
                m_imIroningSymbolImage = Value
            End Set
        End Property
        Public Function SaveISymbol()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

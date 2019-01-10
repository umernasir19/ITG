Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class SymbolBleaching
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SymbolBleaching"
            m_strPrimaryFieldName = "BleachingSymbolID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_BleachingSymbolID As Long
        Private m_BleachingSymbolname As String
        Private m_imBleachingSymbolImage As Object
       
        Public Property BleachingSymbolID() As Long
            Get
                BleachingSymbolID = m_BleachingSymbolID
            End Get
            Set(ByVal value As Long)
                m_BleachingSymbolID = value
            End Set
        End Property
        Public Property BleachingSymbolname() As String
            Get
                BleachingSymbolname = m_BleachingSymbolname
            End Get
            Set(ByVal value As String)
                m_BleachingSymbolname = value
            End Set
        End Property
        Public Property BleachingSymbolImage() As Object
            Get
                BleachingSymbolImage = m_imBleachingSymbolImage
            End Get
            Set(ByVal Value As Object)
                m_imBleachingSymbolImage = Value
            End Set
        End Property
        Public Function SaveBSymbol()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

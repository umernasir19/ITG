Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class SymbolDryCleaning
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SymbolDryCleaning"
            m_strPrimaryFieldName = "DryCleaningSymbolID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_DryCleaningSymbolID As Long
        Private m_DryCleaningSymbolname As String
        Private m_imDryCleaningSymbolImage As Object

        Public Property DryCleaningSymbolID() As Long
            Get
                DryCleaningSymbolID = m_DryCleaningSymbolID
            End Get
            Set(ByVal value As Long)
                m_DryCleaningSymbolID = value
            End Set
        End Property
        Public Property DryCleaningSymbolname() As String
            Get
                DryCleaningSymbolname = m_DryCleaningSymbolname
            End Get
            Set(ByVal value As String)
                m_DryCleaningSymbolname = value
            End Set
        End Property
        Public Property DryCleaningSymbolImage() As Object
            Get
                DryCleaningSymbolImage = m_imDryCleaningSymbolImage
            End Get
            Set(ByVal Value As Object)
                m_imDryCleaningSymbolImage = Value
            End Set
        End Property
        Public Function SaveCSymbol()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace


Imports System.Data

Namespace EuroCentra
    Public Class TypeOfPrint
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TypeOfPrint"
            m_strPrimaryFieldName = "TypeOfPrintID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_TypeOfPrintID As Long
        Private m_TypeOfPrintName As String

        Public Property TypeOfPrintID() As Long
            Get
                TypeOfPrintID = m_TypeOfPrintID
            End Get
            Set(ByVal Value As Long)
                m_TypeOfPrintID = Value
            End Set
        End Property
        Public Property TypeOfPrintName() As String
            Get
                TypeOfPrintName = m_TypeOfPrintName
            End Get
            Set(ByVal value As String)
                m_TypeOfPrintName = value
            End Set
        End Property

        Public Function SaveTypeOfPrint()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal TypeOfPrintID As String)
            Dim Str As String
            Str = "select * from TypeOfPrint where TypeOfPrintID = '" & TypeOfPrintID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from TypeOfPrint  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal TypeOfPrintid As Long)
            Dim Str As String
            Str = " delete from TypeOfPrint where TypeOfPrintid='" & TypeOfPrintid & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
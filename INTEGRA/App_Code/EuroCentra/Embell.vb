Imports System.Data

Namespace EuroCentra
    Public Class Embell
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Embell"
            m_strPrimaryFieldName = "EmbellID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_EmbellID As Long
        Private m_EmbellName As String

        Public Property EmbellID() As Long
            Get
                EmbellID = m_EmbellID
            End Get
            Set(ByVal Value As Long)
                m_EmbellID = Value
            End Set
        End Property
        Public Property EmbellName() As String
            Get
                EmbellName = m_EmbellName
            End Get
            Set(ByVal value As String)
                m_EmbellName = value
            End Set
        End Property

        Public Function SaveEmbell()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal EmbellID As String)
            Dim Str As String
            Str = "select * from Embell where EmbellID = '" & EmbellID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Embell  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal EmbellID As Long)
            Dim Str As String
            Str = "delete from Embell where EmbellID='" & EmbellID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
Imports System.Data

Namespace EuroCentra
    Public Class Composition
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Composition"
            m_strPrimaryFieldName = "CompositionID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_CompositionID As Long
        Private m_CompositionName As String

        Public Property CompositionID() As Long
            Get
                CompositionID = m_CompositionID
            End Get
            Set(ByVal Value As Long)
                m_CompositionID = Value
            End Set
        End Property
        Public Property CompositionName() As String
            Get
                CompositionName = m_CompositionName
            End Get
            Set(ByVal value As String)
                m_CompositionName = value
            End Set
        End Property
        
        Public Function SaveComposition()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal CompositionID As String)
            Dim Str As String
            Str = "select * from Composition where CompositionID = '" & CompositionID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Composition  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal CompositionID As Long)
            Dim Str As String
            Str = "delete from Composition where CompositionID='" & CompositionID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class

End Namespace
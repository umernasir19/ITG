Imports System.Data

Namespace EuroCentra
    Public Class TypeOfWashing
        Inherits SQLManager
         Public Sub New()
            m_strTableName = "TypeOfWashing"
            m_strPrimaryFieldName = "TypeOfWashingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_TypeOfWashingID As Long
        Private m_TypeOfWashingName As String

        Public Property TypeOfWashingID() As Long
            Get
                TypeOfWashingID = m_TypeOfWashingID
            End Get
            Set(ByVal Value As Long)
                m_TypeOfWashingID = Value
            End Set
        End Property
        Public Property TypeOfWashingName() As String
            Get
                TypeOfWashingName = m_TypeOfWashingName
            End Get
            Set(ByVal value As String)
                m_TypeOfWashingName = value
            End Set
        End Property
        Public Function SaveTypeOfWashing()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal TypeOfWashingID As String)
            Dim Str As String
            Str = "select * from TypeOfWashing where TypeOfWashingID = '" & TypeOfWashingID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from TypeOfWashing "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal TypeOfWashingID As Long)
            Dim Str As String
            Str = "delete from TypeOfWashing where TypeOfWashingID= '" & TypeOfWashingID & "'"
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
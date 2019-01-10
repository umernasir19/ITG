Imports System.Data

Namespace EuroCentra
    Public Class TypeOfDyes
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TypeOfDyes"
            m_strPrimaryFieldName = "TypeOfDyesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_TypeOfDyesID As Long
        Private m_TypeOfDyesName As String

        Public Property TypeOfDyesID() As Long
            Get
                TypeOfDyesID = m_TypeOfDyesID
            End Get
            Set(ByVal Value As Long)
                m_TypeOfDyesID = Value
            End Set
        End Property
        Public Property TypeOfDyesName() As String
            Get
                TypeOfDyesName = m_TypeOfDyesName
            End Get
            Set(ByVal value As String)
                m_TypeOfDyesName = value
            End Set
        End Property

        Public Function SaveTypeOfDyes()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal TypeOfDyesID As String)
            Dim Str As String
            Str = "select * from TypeOfDyes where TypeOfDyesID = '" & TypeOfDyesID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from TypeOfDyes  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal TypeOfDyesID As Long)
            Dim Str As String
            Str = " delete from TypeOfDyes where TypeOfDyesID='" & TypeOfDyesID & "' "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
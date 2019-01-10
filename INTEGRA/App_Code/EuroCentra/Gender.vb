Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class Gender
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Gender"
            m_strPrimaryFieldName = "GenderID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lGenderID As Long

        Private m_strGender As String


        Public Property GenderID() As Long
            Get
                GenderID = m_lGenderID
            End Get
            Set(ByVal Value As Long)
                m_lGenderID = Value
            End Set
        End Property

        Public Property Gender() As String
            Get
                Gender = m_strGender
            End Get
            Set(ByVal Value As String)
                m_strGender = Value
            End Set
        End Property


        Public Function saveGender()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Function GetGenderID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGenderforView() As DataTable
            Dim str As String
            str = " Select * from Gender "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGenderForEdit(ByVal lGenderID As Long) As DataTable
            Dim str As String
            str = " Select * from Gender"
            str &= " where GenderID=" & lGenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteGender(ByVal lGenderID As Long)
            Dim Str As String
            Str = " Delete from Gender where GenderID=" & lGenderID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace

Imports System.Data

Namespace EuroCentra
    Public Class TypeOfSampling
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TypeOfSampling"
            m_strPrimaryFieldName = "TypeOfSamplingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTypeOfSamplingID As Long
        Private m_strTypeName As String
        Private m_bisactive As Boolean

        Public Property TypeOfSamplingID() As Long
            Get
                TypeOfSamplingID = m_lTypeOfSamplingID
            End Get
            Set(ByVal value As Long)
                m_lTypeOfSamplingID = value
            End Set
        End Property
        Public Property TypeName() As String
            Get
                TypeName = m_strTypeName
            End Get
            Set(ByVal value As String)
                m_strTypeName = value
            End Set
        End Property
        Public Property isactive() As Boolean
            Get
                isactive = m_bisactive
            End Get
            Set(ByVal value As Boolean)
                m_bisactive = value
            End Set
        End Property
        Public Function SaveTypeOfSampling()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForView()
            Dim str As String
            str = "Select * from TypeOfSampling "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForEdit(ByVal TypeOfSamplingID As Long)
            Dim str As String
            str = "Select * from TypeOfSampling where TypeOfSamplingID=" & TypeOfSamplingID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace
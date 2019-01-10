Imports System.Data
Namespace EuroCentra
    Public Class ErrorCode
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "errorcodes"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lID As Long
        Private m_strErrorNo As String
        Private m_strerrorDescription As String

        ''---------------- Properties
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal value As Long)
                m_lID = value
            End Set
        End Property
        Public Property ErrorNo() As String
            Get
                ErrorNo = m_strErrorNo
            End Get
            Set(ByVal value As String)
                m_strErrorNo = value
            End Set
        End Property
        Public Property errorDescription() As String
            Get
                errorDescription = m_strerrorDescription
            End Get
            Set(ByVal value As String)
                m_strerrorDescription = value
            End Set
        End Property

        Public Function SaveErrorCodes()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetErrorById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetErrorCodesforView() As DataTable
            Dim str As String
            str = "select  * from errorcodes "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetErrorCodesData(ByVal ID As Integer) As DataTable
            Dim str As String
            str = "select * from errorcodes where ID=" & ID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace

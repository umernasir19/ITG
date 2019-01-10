Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class Destination
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblDestination"
            m_strPrimaryFieldName = "DestinationID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDestinationID As Long
        Private m_strDestinationName As String
        Public Property DestinationID() As Long
            Get
                DestinationID = m_lDestinationID
            End Get
            Set(ByVal value As Long)
                m_lDestinationID = value
            End Set
        End Property

        Public Property DestinationName() As String
            Get
                DestinationName = m_strDestinationName
            End Get
            Set(ByVal value As String)
                m_strDestinationName = value
            End Set
        End Property
        Public Function SaveDestination()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDestination(ByVal DestinationID As String)
            Dim Str As String
            Str = "select * from tblDestination where DestinationID = '" & DestinationID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAll()
            Dim Str As String
            Str = "select * from tblDestination  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace


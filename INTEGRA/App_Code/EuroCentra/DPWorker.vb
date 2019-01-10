Imports System.Data

Namespace EuroCentra
    Public Class DPWorker
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPWorker"
            m_strPrimaryFieldName = "WorkerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_WorkerID As Long
        Private m_WorkerName As String

        Public Property WorkerID() As Long
            Get
                WorkerID = m_WorkerID
            End Get
            Set(ByVal Value As Long)
                m_WorkerID = Value
            End Set
        End Property
        Public Property WorkerName() As String
            Get
                WorkerName = m_WorkerName
            End Get
            Set(ByVal value As String)
                m_WorkerName = value
            End Set
        End Property

        Public Function SaveWorker()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
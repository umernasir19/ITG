Imports System.Data

Namespace EuroCentra
    Public Class FabricIssueWorkerDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPFabricIssueWorkerDtl"
            m_strPrimaryFieldName = "FabricIssueWorkerDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricIssueWorkerDtlID As Long
        Private m_lFabricIssueID As Long
        Private m_lWorkerID As Long
        Private m_strWorkerName As String
        Public Property FabricIssueWorkerDtlID() As Long
            Get
                FabricIssueWorkerDtlID = m_lFabricIssueWorkerDtlID
            End Get
            Set(ByVal Value As Long)
                m_lFabricIssueWorkerDtlID = Value
            End Set
        End Property
        Public Property FabricIssueID() As Long
            Get
                FabricIssueID = m_lFabricIssueID
            End Get
            Set(ByVal Value As Long)
                m_lFabricIssueID = Value
            End Set
        End Property
        Public Property WorkerID() As Long
            Get
                WorkerID = m_lWorkerID
            End Get
            Set(ByVal Value As Long)
                m_lWorkerID = Value
            End Set
        End Property
        Public Property WorkerName() As String
            Get
                WorkerName = m_strWorkerName
            End Get
            Set(ByVal value As String)
                m_strWorkerName = value
            End Set
        End Property

        Public Function SaveFabricIssueWorkerDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function Deletedetail(ByVal FabricIssueWorkerDtlId As Long)
            Dim str As String
            str = " Delete  from FabricIssueWorkerDtl where FabricIssueWorkerDtlId ='" & FabricIssueWorkerDtlId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

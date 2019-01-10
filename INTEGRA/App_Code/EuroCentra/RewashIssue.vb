Imports Microsoft.VisualBasic
Imports System.Data

Public Class RewashIssue
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "RewashIssue"
        m_strPrimaryFieldName = "RewashIssueID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_RewashIssueID As Long
    Private m_IssueDate As DateTime
    Private m_SeasonDatabaseID As Long
    Private m_JobOrderId As Long
    Private m_JobOrderDetailId As Long
    Private m_RewashIssueQty As Decimal
    Private m_Remarks As String

    Public Property RewashIssueID() As Long
        Get
            RewashIssueID = m_RewashIssueID
        End Get
        Set(ByVal value As Long)
            m_RewashIssueID = value
        End Set
    End Property
    Public Property IssueDate() As DateTime
        Get
            IssueDate = m_IssueDate
        End Get
        Set(ByVal value As DateTime)
            m_IssueDate = value
        End Set
    End Property
    Public Property SeasonDatabaseID() As Long
        Get
            SeasonDatabaseID = m_SeasonDatabaseID
        End Get
        Set(ByVal value As Long)
            m_SeasonDatabaseID = value
        End Set
    End Property
    Public Property JobOrderId() As Long
        Get
            JobOrderId = m_JobOrderId
        End Get
        Set(ByVal value As Long)
            m_JobOrderId = value
        End Set
    End Property
    Public Property JobOrderDetailId() As Long
        Get
            JobOrderDetailId = m_JobOrderDetailId
        End Get
        Set(ByVal value As Long)
            m_JobOrderDetailId = value
        End Set
    End Property
    Public Property RewashIssueQty() As Decimal
        Get
            RewashIssueQty = m_RewashIssueQty
        End Get
        Set(ByVal value As Decimal)
            m_RewashIssueQty = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Remarks = m_Remarks
        End Get
        Set(ByVal value As String)
            m_Remarks = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSeasonsFromJobOrderDatabase() As DataTable
        Dim str As String
        str = " Select distinct SD.seasondatabaseID,SD.SeasonName from SeasonDatabase SD join JobOrderDatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSrnOForCutting(ByVal SeasonDatabaseID As Long) As DataTable
        Dim str As String
        str = " select DISTINCT JO.Joborderid,JO.SRNO   from JobOrderdatabase jo"
        str &= " join SeasonDatabase sd on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
        str &= " where sd.SeasonDatabaseID=" & SeasonDatabaseID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetColorForCutting(ByVal seasondatabaseid As Long, ByVal JobOrderId As Long) As DataTable
        Dim str As String
        str = " select * from JobOrderdatabase jo"
        str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
        str &= " where jo.Joborderid='" & JobOrderId & "' and Jo.seasondatabaseid='" & seasondatabaseid & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetRewashIssueAllData() As DataTable
        Dim str As String
        str = " SELECT ri.*, seaDb.SeasonName, jo.SRNO, joDtl.BuyerColor FROM RewashIssue ri "
        str &= " JOIN SeasonDatabase  seaDb ON seaDb.SeasonDatabaseID = ri.SeasonDatabaseID "
        str &= " JOIN JobOrderdatabase jo ON jo.Joborderid = ri.JobOrderId "
        str &= " JOIN JobOrderdatabaseDetail joDtl ON joDtl.JoborderDetailid = ri.JobOrderDetailId "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function DeleteRewashIssue(ByVal RewashIssueID As Long)
        Dim str As String
        str = " DELETE FROM RewashIssue WHERE RewashIssueID ='" & RewashIssueID & "'"
        Try
            MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetRewashIssueByID(ByVal RewashIssueID As Long) As DataTable
        Dim str As String
        str = " SELECT * FROM RewashIssue WHERE RewashIssueID ='" & RewashIssueID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
Imports Microsoft.VisualBasic
Imports System.Data

Public Class RewashRecv
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "RewashRecv"
        m_strPrimaryFieldName = "RewashRecID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_RewashRecID As Long
    Private m_RecDate As DateTime
    Private m_ChallanNo As String
    Private m_SeasonDatabaseID As Long
    Private m_JobOrderId As Long
    Private m_JobOrderDetailId As Long
    Private m_RewashQty As Decimal
    Private m_Remarks As String

    Public Property RewashRecID() As Long
        Get
            RewashRecID = m_RewashRecID
        End Get
        Set(ByVal value As Long)
            m_RewashRecID = value
        End Set
    End Property
    Public Property RecDate() As DateTime
        Get
            RecDate = m_RecDate
        End Get
        Set(ByVal value As DateTime)
            m_RecDate = value
        End Set
    End Property
    Public Property ChallanNo() As String
        Get
            ChallanNo = m_ChallanNo
        End Get
        Set(ByVal value As String)
            m_ChallanNo = value
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
    Public Property RewashQty() As Decimal
        Get
            RewashQty = m_RewashQty
        End Get
        Set(ByVal value As Decimal)
            m_RewashQty = value
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

    Public Function GetRewashRecvAllData() As DataTable
        Dim str As String
        str = " SELECT rewash.*, seaDb.SeasonName, jo.SRNO, joDtl.BuyerColor FROM RewashRecv rewash "
        str &= " JOIN SeasonDatabase  seaDb ON seaDb.SeasonDatabaseID = rewash.SeasonDatabaseID "
        str &= " JOIN JobOrderdatabase jo ON jo.Joborderid = rewash.JobOrderId "
        str &= " JOIN JobOrderdatabaseDetail joDtl ON joDtl.JoborderDetailid = rewash.JobOrderDetailId "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function DeleteRewashRecv(ByVal RewashRecID As Long)
        Dim str As String
        str = " DELETE FROM RewashRecv WHERE RewashRecID ='" & RewashRecID & "'"
        Try
            MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetRewashRecvByID(ByVal RewashRecID As Long) As DataTable
        Dim str As String
        str = " SELECT * FROM RewashRecv WHERE RewashRecID ='" & RewashRecID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function CheckDateAndChallan(ByVal RecvDate As Date, ByVal Challan As String) As DataTable
        Dim str As String
       
            str = " select * from RewashRecv where convert(varchar,RecDate,103) = '" & RecvDate & "' AND ChallanNo = '" & Challan & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    'Public Function CheckDateByID(ByVal RecvDate As Date, ByVal RecvID As Long) As DataTable
    '    Dim str As String
    '    str = " select * from RewashRecv where RecDate = '" & RecvDate & "'"
    '    Try
    '        Return MyBase.GetDataTable(str)
    '    Catch ex As Exception

    '    End Try
    'End Function

End Class


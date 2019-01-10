Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class ProcessIssueReturn
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POProcessIssueReturn"
        m_strPrimaryFieldName = "POProcessIssueReturnId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lPOProcessIssueReturnId As Long
    Private m_ProcessOrderMstID As Long

    Private m_POProcessRecvMasterID As Long
    Private m_POProcessRecvDetailID As Long
    Private m_UserId As Long
    Private m_CreationDate As Date
    Private m_ReturnDate As Date
    Private m_dReturnQty As Decimal
    Private m_ItemID As Long
    Private m_ProcessIssueID As Long
    Private m_ProcessIssueDtlID As Long
    Private m_lLocationid As Long
    Public Property Locationid() As Long
        Get
            Locationid = m_lLocationid
        End Get
        Set(ByVal value As Long)
            m_lLocationid = value
        End Set
    End Property
    Public Property POProcessIssueReturnId() As Long
        Get
            POProcessIssueReturnId = m_lPOProcessIssueReturnId
        End Get
        Set(ByVal value As Long)
            m_lPOProcessIssueReturnId = value
        End Set
    End Property
    Public Property ProcessOrderMstID() As Long
        Get
            ProcessOrderMstID = m_ProcessOrderMstID
        End Get
        Set(ByVal value As Long)
            m_ProcessOrderMstID = value
        End Set
    End Property

    Public Property POProcessRecvMasterID() As Long
        Get
            POProcessRecvMasterID = m_POProcessRecvMasterID
        End Get
        Set(ByVal value As Long)
            m_POProcessRecvMasterID = value
        End Set
    End Property
    Public Property POProcessRecvDetailID() As Long
        Get
            POProcessRecvDetailID = m_POProcessRecvDetailID
        End Get
        Set(ByVal value As Long)
            m_POProcessRecvDetailID = value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_UserId
        End Get
        Set(ByVal value As Long)
            m_UserId = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_CreationDate
        End Get
        Set(ByVal value As Date)
            m_CreationDate = value
        End Set
    End Property
    Public Property ReturnDate() As Date
        Get
            ReturnDate = m_ReturnDate
        End Get
        Set(ByVal value As Date)
            m_ReturnDate = value
        End Set
    End Property
    Public Property ReturnQty() As Decimal
        Get
            ReturnQty = m_dReturnQty
        End Get
        Set(ByVal value As Decimal)
            m_dReturnQty = value
        End Set
    End Property
    Public Property ItemID() As Long
        Get
            ItemID = m_ItemID
        End Get
        Set(ByVal value As Long)
            m_ItemID = value
        End Set
    End Property
    Public Property ProcessIssueID() As Long
        Get
            ProcessIssueID = m_ProcessIssueID
        End Get
        Set(ByVal value As Long)
            m_ProcessIssueID = value
        End Set
    End Property
    Public Property ProcessIssueDtlID() As Long
        Get
            ProcessIssueDtlID = m_ProcessIssueDtlID
        End Get
        Set(ByVal value As Long)
            m_ProcessIssueDtlID = value
        End Set
    End Property
    Public Function SaveReturn()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function

    Public Function GetLocation(ByVal POProcessRecvMasterID As Long)
        Dim str As String
        Try
            str = " select * from POProcessRecvMaster pom join Location lc on LC.Locationid=pom.Locationid "
            str &= "   where POProcessRecvMasterID='" & POProcessRecvMasterID & "'  "
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetReturnedQty(ByVal ProcessOrderMstID As Long, ByVal ProcessOrderDtlID As Long, ByVal POProcessRecvMasterID As Long, ByVal POProcessRecvDetailID As Long, ByVal ItemID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from FPOProcessReturn  "
            str &= "   where ProcessOrderMstID='" & ProcessOrderMstID & "' and ProcessOrderDtlID='" & ProcessOrderDtlID & "' and POProcessRecvMasterID='" & POProcessRecvMasterID & "' and POProcessRecvDetailID='" & POProcessRecvDetailID & "' and ItemID='" & ItemID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUpdateReturnQty(ByVal ReturnQty As Decimal, ByVal ProcessOrderDtlID As Long, ByVal POProcessRecvMasterID As Long, ByVal POProcessRecvDetailID As Long)
        Dim str As String
        Try
            str = " UPDATE POProcessRecvDetail set ReturnQty='" & ReturnQty & "'"
            str &= "   where ProcessOrderDtlID='" & ProcessOrderDtlID & "' and POProcessRecvMasterID='" & POProcessRecvMasterID & "' and POProcessRecvDetailID='" & POProcessRecvDetailID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetReturnedQty(ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from POIssueReturn  "
            str &= " where IssueID = '" & IssueID & "' And IssueDtlID = '" & IssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetProcessIssueReturnedQty(ByVal ProcessIssueID As Long, ByVal ProcessIssueDtlID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from POProcessIssueReturn  "
            str &= " where ProcessIssueID = '" & ProcessIssueID & "' And ProcessIssueDtlID = '" & ProcessIssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetIssueReturn(ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = " select   mst.ManualChallanNo,isnull(ISD.Style,'N/A') as Style,ITM.ItemName as ItemName,(ISD.IssueQty ) AS IssueQtyy, "
            str &= " (ISD.RecvQty-ISD.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date , (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,"
            str &= " isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  ISD on ISD.IssueID =Mst.IssueID"
            str &= " left join POMaster pm on pm.POID =mst.POID    "
            str &= " join IMSItem ITM on ITM.IMSItemID=ISD.ItemID  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =ISD.DeptDatabaseID "
            str &= " Join Location lcc on lcc.Locationid=mst.Locationid"
            str &= " where Mst.IssueID = '" & IssueID & "' And ISD.IssueDtlID = '" & IssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetIssueReturnNew(ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = " select   mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee,(ISD.IssueQty ) AS IssueQtyy, "
            str &= " (ISD.RecvQty-ISD.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date , (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,"
            str &= " isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  ISD on ISD.IssueID =Mst.IssueID"
            str &= " left join POMaster pm on pm.POID =mst.POID    "
            str &= " join IMSItem ITM on ITM.IMSItemID=ISD.ItemID  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =ISD.DeptDatabaseID "
            str &= " Join Location lcc on lcc.Locationid=mst.Locationid"
            str &= " where Mst.IssueID = '" & IssueID & "' And ISD.IssueDtlID = '" & IssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetProcessIssueReturn(ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = "     select   mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee,(ISD.IssueQty ) AS IssueQtyy, "
            str &= " (ISD.RecvQty-ISD.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date ,"
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,"
            str &= " isnull(pm.PONo,'In Stock') as PONoo  from   processIssueMst  mst  "
            str &= " join processIssuedetail  ISD on ISD.ProcessIssueID =Mst.ProcessIssueID"
            str &= " left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= " join IMSItem ITM on ITM.IMSItemID=ISD.ItemID  left join IMSDepartmentDataBase "
            str &= " idd on idd .DeptDatabaseId =ISD.DeptDatabaseID "
            str &= " Join Location lcc on lcc.Locationid=mst.Locationid"
            str &= " where Mst.ProcessIssueID = '" & IssueID & "' And ISD.ProcessIssueDtlID = '" & IssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUpdateReturnQty(ByVal ReturnQty As Decimal, ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = " UPDATE IssueDetail set IssueReturn='" & ReturnQty & "'"
            str &= "   where IssueID='" & IssueID & "' and IssueDtlID='" & IssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUpdateReturnQtyForProcessIssue(ByVal ReturnQty As Decimal, ByVal ProcessIssueID As Long, ByVal ProcessIssueDtlID As Long)
        Dim str As String
        Try
            str = " UPDATE processIssuedetail set IssueReturn='" & ReturnQty & "'"
            str &= "   where ProcessIssueID='" & ProcessIssueID & "' and ProcessIssueDtlID='" & ProcessIssueDtlID & "'"
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class

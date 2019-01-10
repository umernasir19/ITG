Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class FPOIssueReturn
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POIssueReturn"
        m_strPrimaryFieldName = "POIssueReturnId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lPOIssueReturnId As Long
    Private m_POID As Long

    Private m_PORecvMasterID As Long
    Private m_PORecvDetailID As Long
    Private m_UserId As Long
    Private m_CreationDate As Date
    Private m_ReturnDate As Date
    Private m_dReturnQty As Decimal
    Private m_ItemID As Long
    Private m_IssueID As Long
    Private m_IssueDtlID As Long
    Private m_lLocationid As Long
    Public Property Locationid() As Long
        Get
            Locationid = m_lLocationid
        End Get
        Set(ByVal value As Long)
            m_lLocationid = value
        End Set
    End Property
    Public Property POIssueReturnId() As Long
        Get
            POIssueReturnId = m_lPOIssueReturnId
        End Get
        Set(ByVal value As Long)
            m_lPOIssueReturnId = value
        End Set
    End Property
    Public Property POID() As Long
        Get
            POID = m_POID
        End Get
        Set(ByVal value As Long)
            m_POID = value
        End Set
    End Property
     
    Public Property PORecvMasterID() As Long
        Get
            PORecvMasterID = m_PORecvMasterID
        End Get
        Set(ByVal value As Long)
            m_PORecvMasterID = value
        End Set
    End Property
    Public Property PORecvDetailID() As Long
        Get
            PORecvDetailID = m_PORecvDetailID
        End Get
        Set(ByVal value As Long)
            m_PORecvDetailID = value
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
    Public Property IssueID() As Long
        Get
            IssueID = m_IssueID
        End Get
        Set(ByVal value As Long)
            m_IssueID = value
        End Set
    End Property
    Public Property IssueDtlID() As Long
        Get
            IssueDtlID = m_IssueDtlID
        End Get
        Set(ByVal value As Long)
            m_IssueDtlID = value
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
    Public Function GetReturnedQty(ByVal IssueID As Long, ByVal IssueDtlID As Long)
        Dim str As String
        Try
            str = "select ISNULL(sum(ReturnQty),0) as ReturnedQty  from POIssueReturn  "
            str &= " where IssueID = '" & IssueID & "' And IssueDtlID = '" & IssueDtlID & "'"
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

Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSStoreIssue
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSStoreIssue"
            m_strPrimaryFieldName = "StoreIssueID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lStoreIssueID As Long
        Private m_dtCreationDate As Date
        Private m_lCreatedbyID As Long
        Private m_dtEntryDate As Date
        Dim m_strSIVNo As String

        Dim m_strCCNo As String
        Private m_dbTokenNo As Decimal
        Private m_lIssueTypeID As Long
        Dim m_strCounterNo As String
        Public Property CounterNo() As String
            Get
                CounterNo = m_strCounterNo
            End Get
            Set(ByVal Value As String)
                m_strCounterNo = Value
            End Set
        End Property
        Public Property IssueTypeID() As Long
            Get
                IssueTypeID = m_lIssueTypeID
            End Get
            Set(ByVal Value As Long)
                m_lIssueTypeID = Value
            End Set
        End Property
        Public Property StoreIssueID() As Long
            Get
                StoreIssueID = m_lStoreIssueID
            End Get
            Set(ByVal Value As Long)
                m_lStoreIssueID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property CreatedbyID() As Long
            Get
                CreatedbyID = m_lCreatedbyID
            End Get
            Set(ByVal Value As Long)
                m_lCreatedbyID = Value
            End Set
        End Property
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal Value As Date)
                m_dtEntryDate = Value
            End Set
        End Property
        Public Property SIVNo() As String
            Get
                SIVNo = m_strSIVNo
            End Get
            Set(ByVal Value As String)
                m_strSIVNo = Value
            End Set
        End Property
        
        Public Property CCNo() As String
            Get
                CCNo = m_strCCNo
            End Get
            Set(ByVal Value As String)
                m_strCCNo = Value
            End Set
        End Property
        Public Property TokenNo() As Decimal
            Get
                TokenNo = m_dbTokenNo
            End Get
            Set(ByVal value As Decimal)
                m_dbTokenNo = value
            End Set
        End Property
        Public Function SaveIMSStoreIssue()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssueCode(ByVal year As Integer)
            Dim str As String
            str = " select Top 1 SIVNo from IMSStoreIssue where   year(CreationDate)='" & year & "' order By StoreIssueID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricClassName() As DataTable
            Dim str As String
            str = "  Select ItemClassName,IMSItemClassID  from IMSItemClass where IMSItemClassID =6"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllData() As DataTable
            Dim str As String
            str = "  select *,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee, "
            str &= " (Select isnull(Sum(QtyIssue),0) from IMSStoreIssueDetail IMS_SID where IMS_SID.StoreIssueID=IMS_SI.StoreIssueID )as QtyIssue , "
            str &= " (Select isnull(Sum(Amount),0) from IMSStoreIssueDetail IMS_SID where IMS_SID.StoreIssueID=IMS_SI.StoreIssueID )as Amount "
            str &= " from IMSStoreIssue IMS_SI"
            str &= " order by IMS_SI.StoreIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNew() As DataTable
            Dim str As String
            str = "  select *,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSStoreIssue IMS_SI"
            str &= " join IMSStoreIssueDetail IMS_SID on IMS_SID.StoreIssueID=IMS_SI.StoreIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_DD.DeptDatabaseId=IMS_SID.DeptDatabaseId"
            str &= " order by IMS_SI.StoreIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUser(ByVal UserId As Long) As DataTable
            Dim str As String
            str = "  select *,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSStoreIssue IMS_SI"
            str &= " join IMSStoreIssueDetail IMS_SID on IMS_SID.StoreIssueID=IMS_SI.StoreIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_DD.DeptDatabaseId=IMS_SID.DeptDatabaseId"
            str &= "  WHERE cREATEDBYID ='" & UserId & "' order by IMS_SI.StoreIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditData(ByVal StoreIssueID As Long) As DataTable
            Dim str As String
            str = "select *,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee"
            str &= " from IMSStoreIssue IMS_SI"
            str &= " join  IMSStoreIssueDetail IMS_SID on IMS_SID.StoreIssueID=IMS_SI.StoreIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID "
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_SID.DeptDatabaseId=IMS_DD.DeptDatabaseId "
            str &= " join IMSTransactionMethod IMS_TM on IMS_SID.TransactionMethodID=IMS_TM.TransactionMethodID "
            str &= " where IMS_SI.StoreIssueID=" & StoreIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForGodownIssueNew(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = " select L.Location as FromLocation,LL.Location as ToLocation,*,Convert(Varchar,IMS_SI.EntryDate,103) "
            str &= " as EntryDatee "
            str &= "  from IMSGodownIssue IMS_SI "
            str &= " join  IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID  "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID    "
            str &= "  join  Location L on L.LocationID =IMS_SID.FromLocationID  "
            str &= "  join  Location LL on LL.LocationID =IMS_SID.ToLocationID  "
            str &= " where IMS_SI.GodownIssueID=" & GodownIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForGodownIssueNewForProcess(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = " select L.Location as FromLocation,LL.Location as ToLocation,*,Convert(Varchar,IMS_SI.EntryDate,103) "
            str &= " as EntryDatee "
            str &= "  from IMSGodownIssueForProcess IMS_SI "
            str &= " join  IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID  "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID    "
            str &= "  join  Location L on L.LocationID =IMS_SID.FromLocationID  "
            str &= "  join  Location LL on LL.LocationID =IMS_SID.ToLocationID  "
            str &= " where IMS_SI.GodownIssueID=" & GodownIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForGodownIssue(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = " select L.Location as FromLocation,LL.Location as ToLocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee"
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join  IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID "
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_SID.DeptDatabaseId=IMS_DD.DeptDatabaseId "
            str &= " join IMSTransactionMethod IMS_TM on IMS_SID.TransactionMethodID=IMS_TM.TransactionMethodID "
            str &= " join  Location L on L.LocationID =IMS_SID.FromLocationID "
            str &= " join  Location LL on LL.LocationID =IMS_SID.ToLocationID "
            str &= " where IMS_SI.GodownIssueID=" & GodownIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForFabricIssue(ByVal IssueID As Long) As DataTable
            Dim str As String
            str = " select * from IssueMst mst"
            str &= " join IssueDetail Dtl on dtl.IssueID =mst.IssueID "
            str &= "  join Location L on L.LocationID =mst.LocationID "
            str &= " JOIN IMSDepartmentDataBase DB on DB.DeptDatabaseId =DTL.DeptDatabaseID "
            str &= " JOIN IMSITEM IM on IM.IMSITEMId =Dtl.ItemID "
            str &= " where mst.IssueID=" & IssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForFabricIssueNewNewForAstore(ByVal IssueID As Long) As DataTable
            Dim str As String
            str = " select *,Dtl.RecvQty - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =mst.POID AND POR.ItemID"
            str &= " =Dtl.ItemId ),0) as RecvQtyy,SD.SeasonNAME AS SeasonNAMEE,JO.SRNO AS SRNOOO,Dtl.JOBORDERID AS JOBORDERIDD,Dtl.SeasonDataBaseID AS SeasonDataBaseIDD from IssueMst mst"
            str &= " join IssueDetail Dtl on dtl.IssueID =mst.IssueID "
            str &= "  join Location L on L.LocationID =mst.LocationID "
            str &= " JOIN IMSDepartmentDataBase DB on DB.DeptDatabaseId =DTL.DeptDatabaseID "
            str &= " JOIN IMSITEM IM on IM.IMSITEMId =Dtl.ItemID "
            str &= " left JOIN SeasonDataBase SD on SD.SeasonDataBaseId =Dtl.SeasonDataBaseId "
            str &= " left JOIN JobOrderDatabase Jo on jo.JobOrderId =Dtl.JobOrderId "
            str &= " where mst.IssueID=" & IssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForFabricIssueNewNew(ByVal IssueID As Long) As DataTable
            Dim str As String
            str = " select Dtl.Rate as Ratee,POM.pono,*,Dtl.RecvQty - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =Dtl.POID AND POR.ItemID"
            str &= " =Dtl.ItemId ),0) as RecvQtyy,SD.SeasonNAME AS SeasonNAMEE,JO.SRNO AS SRNOOO,Dtl.JOBORDERID AS JOBORDERIDD,Dtl.SeasonDataBaseID AS SeasonDataBaseIDD from IssueMst mst"
            str &= " join IssueDetail Dtl on dtl.IssueID =mst.IssueID "
            str &= "  join Location L on L.LocationID =mst.LocationID "
            str &= " JOIN IMSDepartmentDataBase DB on DB.DeptDatabaseId =DTL.DeptDatabaseID "
            str &= " JOIN IMSITEM IM on IM.IMSITEMId =Dtl.ItemID "
            str &= " left JOIN SeasonDataBase SD on SD.SeasonDataBaseId =Dtl.SeasonDataBaseId "
            str &= " left JOIN JobOrderDatabase Jo on jo.JobOrderId =Dtl.JobOrderId "
            str &= " JOIN POMASTER POM on POM.PoId =Dtl.PoId "
            str &= " where mst.IssueID=" & IssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForProcessIssueNew(ByVal processIssueID As Long) As DataTable
            Dim str As String
            str = "  select * from processIssueMst mst"
            str &= " join processIssueDetail Dtl on dtl.processIssueID =mst.processIssueID "
            str &= " join Location L on L.LocationID =mst.LocationID "
            str &= " JOIN IMSDepartmentDataBase DB on DB.DeptDatabaseId =DTL.DeptDatabaseID "
            str &= " JOIN IMSITEM IM on IM.IMSITEMId =Dtl.ItemID "
            str &= " where mst.processIssueID=" & processIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditDataForProcessIssue(ByVal processIssueID As Long) As DataTable
            Dim str As String
            str = "  select *,SD.SeasonNAME AS SeasonNAMEE,JO.SRNO AS SRNOOO,Dtl.JOBORDERID AS JOBORDERIDD,Dtl.SeasonDataBaseID AS SeasonDataBaseIDD from processIssueMst mst"
            str &= " join processIssueDetail Dtl on dtl.processIssueID =mst.processIssueID "
            str &= " join Location L on L.LocationID =mst.LocationID "
            str &= " JOIN IMSDepartmentDataBase DB on DB.DeptDatabaseId =DTL.DeptDatabaseID "
            str &= " JOIN IMSITEM IM on IM.IMSITEMId =Dtl.ItemID "
            str &= " LEFT JOIN SeasonDatabase SD on SD.SeasonDatabaseId =Dtl.SeasonDatabaseId "
            str &= " LEFT  join JobOrderdatabase JO on JO.Joborderid =DTL.Joborderid"
            str &= " where mst.processIssueID=" & processIssueID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemnAMEanDcODE(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = "  Select *  from IMSItem where IMSItemID " & IMSItemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassWithoutFabric() As DataTable
            Dim str As String
            str = "  Select ItemClassName,IMSItemClassID  from IMSItemClass where IMSItemClassID NOT IN(6)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassWithoutFabricNew() As DataTable
            Dim str As String
            str = "  Select IM.ItemClassName,IM.IMSItemClassID  from IMSItemClass  IM"
            str &= " join StoreReceiptVoucherDtl SRV on SRV.IMSItemClassID=IM.IMSItemClassID"
            str &= " where IM.IMSItemClassID NOT IN(6)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemName(ByVal IMSItemClassID As Long) As DataTable
            Dim str As String
            'str = "select * from IMSItem "
            'str &= " where IMSItemClassID=" & IMSItemClassID

            str = "select distinct  IM.IMSItemID ,IM.ItemName from IMSItem IM  "
            str &= " join StoreReceiptVoucherDtl SRD ON SRD.IMSItemID=IM.IMSItemID "
            str &= " where IM.IMSItemClassID=" & IMSItemClassID


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemNameFabric() As DataTable
            Dim str As String
            'str = "select * from IMSItem "
            'str &= " where IMSItemClassID=" & IMSItemClassID

            str = " select distinct  IM.IMSItemID ,IM.ItemName from IMSItem IM   "
            str &= " join IMSStoreLedger LG ON LG.IMSItemID=IM.IMSItemID  "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IM.IMSItemClassID "
            str &= "   where IMS_ICL.StoreTypeID = 1 "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemNameAcc() As DataTable
            Dim str As String
            'str = "select * from IMSItem "
            'str &= " where IMSItemClassID=" & IMSItemClassID

            str = " select distinct  IM.IMSItemID ,IM.ItemName from IMSItem IM   "
            str &= " join IMSStoreLedger LG ON LG.IMSItemID=IM.IMSItemID  "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IM.IMSItemClassID "
            str &= "   where IMS_ICL.StoreTypeID = 2 "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function FabricCode(ByVal ItemCodee As String)
            Dim Str As String
            'Str = " select distinct IMST.ItemCodee from POProcessRecvMaster POM "
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid= pom.fabricId "
            'Str &= " WHERE IMST.ItemCodee like '" & ItemCodee & "%' "

            Str = " select IMST.ItemCodee as ItemCodee from ProcessOrderMst POM   join ProcessOrderDtl POD on POd.ProcessOrderMstID=POM.ProcessOrderMstID  "
            Str &= " left join POProcessRecvDetail PRD on PRD.ProcessOrderDtlID= POd.ProcessOrderDtlID  "
            Str &= " left join POProcessRecvMaster PRM on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID and POM.ProcessOrderMstID=PRM.ProcessOrderMstID  "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId where POM.FabricPOrder=1 and IMST.ItemCodee  like '" & ItemCodee & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
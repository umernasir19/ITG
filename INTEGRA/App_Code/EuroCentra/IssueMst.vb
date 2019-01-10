Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class IssueMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IssueMst"
            m_strPrimaryFieldName = "IssueID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lIssueID As Long
        Private m_strPOType As String
        Private m_dCreationDate As Date
        Private m_BolFabricStatus As Boolean
        Private m_lLocationId As Long
        Private m_strManualChallanNo As String
        Private m_strAuditorStatus As String
        Private m_lUserID As Long
        Private m_lAuditorID As Long
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal Value As Long)
                m_lUserID = Value
            End Set
        End Property
        Public Property AuditorID() As Long
            Get
                AuditorID = m_lAuditorID
            End Get
            Set(ByVal Value As Long)
                m_lAuditorID = Value
            End Set
        End Property
        Public Property AuditorStatus() As String
            Get
                AuditorStatus = m_strAuditorStatus
            End Get
            Set(ByVal value As String)
                m_strAuditorStatus = value
            End Set
        End Property
        Public Property ManualChallanNo() As String
            Get
                ManualChallanNo = m_strManualChallanNo
            End Get
            Set(ByVal Value As String)
                m_strManualChallanNo = Value
            End Set
        End Property
        Public Property LocationId() As Long
            Get
                LocationId = m_lLocationId
            End Get
            Set(ByVal Value As Long)
                m_lLocationId = Value
            End Set
        End Property
        Public Property IssueID() As Long
            Get
                IssueID = m_lIssueID
            End Get
            Set(ByVal Value As Long)
                m_lIssueID = Value
            End Set
        End Property
        Public Property POType() As String
            Get
                POType = m_strPOType
            End Get
            Set(ByVal Value As String)
                m_strPOType = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dCreationDate = Value
            End Set
        End Property
        Public Property FabricStatus() As Boolean
            Get
                FabricStatus = m_BolFabricStatus
            End Get
            Set(ByVal Value As Boolean)
                m_BolFabricStatus = Value
            End Set
        End Property

        Public Function saveIssue()
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
        Public Function BindLocation() As DataTable
            Dim str As String

            str = " select * from Location "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvForprocessIssue(ByVal ProcessOrderMstID As Long, ByVal Itemid As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from processIssueMst  mst "
            str &= " join processIssueDetail  D on d.processIssueID =Mst.processIssueID where mst.ProcessOrderMstID ='" & ProcessOrderMstID & "'  and  D.Itemid='" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvForprocessIssueNew(ByVal Itemid As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from processIssueMst  mst "
            str &= " join processIssueDetail  D on d.processIssueID =Mst.processIssueID where  D.Itemid='" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPO() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=0"

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function deleteIssueMst(ByVal IssueID As Long)
            Dim Str As String
            Str = " delete from IssueMst where IssueID='" & IssueID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deleteProcessIssueMst(ByVal ProcessIssueID As Long)
            Dim Str As String
            Str = " delete from processIssueMst where ProcessIssueID='" & ProcessIssueID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deleteProcessIssueDtl(ByVal ProcessIssueID As Long)
            Dim Str As String
            Str = " delete from processIssuedetail where ProcessIssueID='" & ProcessIssueID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOnEW() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=0"

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " join PODetail POD on POD.POID=POM.POID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POD.Joborderid where FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONew(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = "      select DISTINCT POD.Style,(POM.PONO+' '+'('+isnull(JOD.JobOrderNo,'TFA-JO-000')+')') as PONoo,POD.ItemID ,"
            str &= " isnull(I.Accessoriesname,a.fabricweave) as ItemName,POM.* from POMaster POM  left jOIN PODetail POD ON POD .POID =POM.POID "
            str &= " Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId  "
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID left join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid "
            str &= "   where FabricPOrder = 0 and ItemId = '" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemNameForIssue(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " select * frOm IMSItem"
            str &= "   where ItemCodee = '" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonForGodown(ByVal itemId As Long) As DataTable
            Dim str As String
            str = " select * from IssueMst Mst"
            str &= "   JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID "
            str &= "   join SeasonDatabase SD on SD.SeasonDatabaseID =MST.SeasonDatabaseID"
            str &= "   where Dtl.ItemID = '" & itemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoForGodownNewAll() As DataTable
            Dim str As String
            str = " select * from joborderdatabase "
            str &= "   order by SRNOPOne,SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoForGodownNewNew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderdatabase Mst"
            str &= "   where Mst.SeasonDatabaseID = '" & SeasonDatabaseID & "'"
            str &= "   order by Mst.SRNOPOne,Mst.SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoForGodownNew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select * from IssueMst Mst"
            str &= "  JOIN JobOrderdatabase JO on JO.JobOrderID =mst.JobOrderID"
            str &= "   where Mst.SeasonDatabaseID = '" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoForGodown(ByVal itemId As Long) As DataTable
            Dim str As String
            str = " select * from IssueMst Mst"
            str &= "   JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID "
            str &= "   join SeasonDatabase SD on SD.SeasonDatabaseID =MST.SeasonDatabaseID"
            str &= "   where Dtl.ItemID = '" & itemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemID(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " select IMSItemID frOm IMSItem"
            str &= "   where ItemCodee = '" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOForAccGStore() As DataTable
            Dim str As String

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where POM.GStoreStatus=1 and POM.ClosedStatus = 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOForAcc() As DataTable
            Dim str As String

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=0 and  POM.GStoreStatus=0 and POM.ClosedStatus = 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabric() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=1"

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=1  and POM.ClosedStatus = 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNew() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=1"

            str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            str &= " Join PODetail POD on POD.POID=POM.POID"
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POD.Joborderid where FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricForProcessIssue() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=1"

            str = " select Distinct POM.ProcessOrderMstID,POM.PONO as PONo from    POProcessRecvMaster PRM   "
            str &= " join POProcessRecvDetail PRD on PRM.POProcessRecvMASTERID= PRD.POProcessRecvMASTERID join  ProcessOrderMst POM on POM.ProcessOrderMstID=PRM.ProcessOrderMstID "
            str &= " left join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewNewForProcess(ByVal ProcessItemNameId As Long) As DataTable
            Dim str As String

            str = " select distinct POM.PONO,POM.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from ProcessOrderMst POM  "
            str &= " jOIN ProcessOrderDtl POD ON POD .ProcessOrderMstID =POM.ProcessOrderMstID   JOIN POProcessRecvDetail PRD ON PRD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.SRNoID   "
            str &= " where     POD.ProcessItemNameId= '" & ProcessItemNameId & "'  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewForProcess(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = " select distinct POM.PONO,POM.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from ProcessOrderMst POM  "
            str &= " jOIN ProcessOrderdTL POD ON POD .ProcessOrderMst =POM.ProcessOrderMst   JOIN POProcessRecvdETAIL PRD ON PRD.ProcessOrderdTLID =POD.ProcessOrderdTLID "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.SrNoID   "
            str &= " where     POD.ProcessItemNameId= '" & ItemId & "'  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNew(ByVal ItemId As Long) As DataTable
            Dim str As String

           

            str = " select distinct POM.PONO,POM.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from POMaster POM  "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID   "
            str &= " where     POD.ItemId= '" & ItemId & "' and POM.FabricPOrder=1  and POM.ClosedStatus = 0 "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewForAstore(ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = " select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName,POM.* from POMaster POM  "
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join Accessories I on I.AccessoriesID =POD.ItemId  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            'str &= " where FabricPOrder=1 and ItemId= '" & ItemId & "'  "
            str = " select distinct POM.PONO,POM.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from POMaster POM  "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID   "
            str &= " where     POD.ItemId= '" & ItemId & "' and POM.FabricPOrder=0  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewAcc(ByVal ItemId As Long) As DataTable
            Dim str As String
         

            str = " SELECT distinct POM.PONO,POM.POID,(POM.PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= "  FROM PORecvMaster PRM"
            str &= " JOIN PORecvDetail PRD ON PRD.PORecvMasterID =PRM.PORecvMasterID"
            str &= "  JOIN POMaster POM on POM.POID =prm.POID "
            str &= "  left join JobOrderdatabase jb on jb.Joborderid =PRM.JoborderID  "
            str &= " where     PRD.ItemId= '" & ItemId & "' and POM.FabricPOrder=0  and POM.GStoreStatus=0 and POM.ClosedStatus = 0 "

        


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewAccGStore(ByVal ItemId As Long) As DataTable
            Dim str As String


            str = " SELECT distinct POM.PONO,POM.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= "  FROM PORecvMaster PRM"
            str &= " JOIN PORecvDetail PRD ON PRD.PORecvMasterID =PRM.PORecvMasterID"
            str &= "  JOIN POMaster POM on POM.POID =prm.POID "
            str &= "  left join JobOrderdatabase jb on jb.Joborderid =PRM.JoborderID  "
            str &= " where     PRD.ItemId= '" & ItemId & "' and POM.GStoreStatus=1 and POM.ClosedStatus = 0 "




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOFabricNewForProcessIssue(ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = " select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName,POM.* from POMaster POM  "
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join Accessories I on I.AccessoriesID =POD.ItemId  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            'str &= " where FabricPOrder=1 and ItemId= '" & ItemId & "'  "
            str = " select distinct POM.PONO,POM.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from ProcessOrderMst POM  "
            str &= " jOIN ProcessOrderDtl POD ON POD .ProcessOrderMstID =POM.ProcessOrderMstID   JOIN POProcessRecvDetail PRD ON PRD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.SrnoID   "
            str &= " where     POD.ProcessItemNameId= '" & ItemId & "'  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItem(ByVal POID As Long) As DataTable
            Dim str As String
            'str = " select DISTINCT ITP.ItemID ,ITP.ItemName   from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= " Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " JOIN ItemProduct ITP  ON ITP.ItemID =POD.ItemId "
            'str &= " WHERE POM.POID ='" & POID & "'"

            str = " select DISTINCT POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName   from POMaster POM "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            str &= " Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "
            str &= " left join Accessories I on I.AccessoriesID =POD.ItemId  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID WHERE POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemWithStyle(ByVal POID As Long) As DataTable
            Dim str As String
            str = "  select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName from POMaster POM  jOIN PODetail POD ON POD .POID =POM.POID "
            str &= " Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId "
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID  WHERE POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQty(ByVal POID As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            str = " Select PRD.PORecvDetailID,sum(prd.RecvQuantity) as  RecvQuantity  from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            str &= " left join Accessories I on I.AccessoriesID=POD.ItemId "
            str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "'  group by PRD.PORecvDetailID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithStyle(ByVal POID As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = " Select PRD.Style,PRD.PORecvDetailID,sum(prd.RecvQuantity) as  RecvQuantity  from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join Accessories I on I.AccessoriesID=POD.ItemId "
            'str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "'  group by PRD.PORecvDetailID,PRD.Style"

            str = "  Select distinct PRD.Style,PRD.PORecvDetailID,(prd.RecvQuantity - sum(D.IssueQty)) as Balance  from POMaster POM "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  left join Accessories I on I.AccessoriesID=POD.ItemId "
            str &= " join IssueMst  mst on mst.POID=POM.POID join IssueDetail  D on d.IssueID =Mst.IssueID  "
            str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "' group by PRD.PORecvDetailID,PRD.Style,PRD.RecvQuantity,D.IssueQty"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRecvQtyFromReturn(ByVal ItemId As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = "  Select  isnull(sum(POD.RecvQuantity),0) as  RecvQuantity from PORecvMaster POM"
            str &= " jOIN PORecvDetail POD ON POD .PORecvMasterID =POM.PORecvMasterID  "
            str &= " join PODetail PD on PD.PoDetailId =POD.PODetailID "
            str &= " WHERE PD.ItemId='" & ItemId & "' and POM.POID='" & POID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForSubtractForprocess(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID=10"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID=10"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
       
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdate(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForSubtractForprocess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JobOrderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.JoborderID='" & JobOrderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JobOrderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.JoborderID='" & JobOrderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JobOrderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.JoborderID='" & JobOrderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNew(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JobOrderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.JoborderID='" & JobOrderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForSubtractForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdate(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForSubtractForprocess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNewwForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " join IMSGodownIssueForProcess Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForUpdateForNewFOrUpdateForNeww(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " join IMSGodownIssue Dtl on DTL.GodownIssueID=MST.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID=10 and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvNewwwForprocess(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvNewww(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcessNew(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecv(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForSubtractForprocess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
  
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeason(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID='" & ToLocationID & "' And Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNOForSubtractForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.FromLocationID='" & ToLocationID & "' And Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvonlySRNO(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.JoborderID='" & JobOrderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForProcess(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JobOrderId='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForSubtract(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JobOrderId='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNoForSubtractForprocessNew(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetailForProcess Mst"
            str &= " Join IMSGodownIssueForProcess Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.fromLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JobOrderId='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseRecvSeasonAndSrNo(ByVal ItemId As Long, ByVal ToLocationID As Long, ByVal SeasonDatabaseID As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Mst.QtyIssue),0)  as RecvQty from IMSGodownIssueDetail Mst"
            str &= " Join IMSGodownIssue Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.IMSItemID='" & ItemId & "' and Mst.ToLocationID='" & ToLocationID & "' And Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JobOrderId='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseForProcess(ByVal ItemId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "    select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from processIssueMst Mst"
            str &= " JOIN processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetiSSUEqTYFromReturn(ByVal ItemId As Long, ByVal POId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.POID='" & POId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseForCahnge(ByVal ItemId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
       
        
        Public Function GetInhandQtyFORiSSUECodeAndLocationVise(ByVal ItemId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseForAcc(ByVal ItemId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " JOIN POmaster PO on PO.POID =mst.POID"
            str &= " WHERE PO.FabricPOrder=0 and Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseOnlySRNOForProcess(ByVal ItemId As Long, ByVal LocationId As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from processIssueMst Mst"
            str &= " JOIN processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Mst.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseOnlySRNO(ByVal ItemId As Long, ByVal LocationId As Long, ByVal JoborderID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Dtl.JoborderID='" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseSeasonForProcess(ByVal ItemId As Long, ByVal LocationId As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from processIssueMst Mst"
            str &= " JOIN processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Mst.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
      

        Public Function GetInhandQtyFORiSSUECodeAndLocationViseSeason(ByVal ItemId As Long, ByVal LocationId As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseSeasonaNDSRNOForProcess(ByVal ItemId As Long, ByVal LocationId As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from processIssueMst Mst"
            str &= " JOIN processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Mst.SeasonDatabaseID='" & SeasonDatabaseID & "' and Mst.JoborderId='" & JoborderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyFORiSSUECodeAndLocationViseSeasonaNDSRNO(ByVal ItemId As Long, ByVal LocationId As Long, ByVal SeasonDatabaseID As Long, ByVal JoborderId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "' and Dtl.SeasonDatabaseID='" & SeasonDatabaseID & "' and Dtl.JoborderId='" & JoborderId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyForGodownTransfer(ByVal ItemId As Long, ByVal JobOrderId As Long, ByVal SeasonDatabaseId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty ),0)  as IssueQty from IssueMst Mst"
            str &= " JOIN IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " WHERE Mst.JobOrderId ='" & JobOrderId & "' and Mst.SeasonDatabaseId ='" & SeasonDatabaseId & "' and Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInhandQtyForGodownTransferForProcess(ByVal ItemId As Long, ByVal JobOrderId As Long, ByVal SeasonDatabaseId As Long, ByVal LocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.IssueQty),0)  as IssueQty from processIssueMst Mst"
            str &= " JOIN processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " WHERE Mst.JobOrderId ='" & JobOrderId & "' and Mst.SeasonDatabaseId ='" & SeasonDatabaseId & "' and Dtl.ItemId='" & ItemId & "' and Mst.LocationId='" & LocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAlreadyForGodownTransfer(ByVal IMSItemId As Long, ByVal JobOrderId As Long, ByVal SeasonDatabaseId As Long, ByVal FromLocationId As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.QtyIssue) ,0) as QtyIssuee from IMSGodownIssue Mst"
            str &= " join IMSGodownIssueDetail Dtl on DTL.GodownIssueID=Mst.GodownIssueID"
            str &= " WHERE Mst.JobOrderId ='" & JobOrderId & "' and Mst.SeasonDatabaseId ='" & SeasonDatabaseId & "' and Dtl.IMSItemId='" & IMSItemId & "' and Dtl.FromLocationId='" & FromLocationId & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindRecvQtyWithStyleNew(ByVal ItemId As Long, ByVal POID As Long, ByVal PORecvDetailID As Long) As DataTable
            Dim str As String
            str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  ,PORecvDetailID from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "' and PRD.PORecvDetailID='" & PORecvDetailID & "' group by PORecvDetailID "

            'str = "    Select distinct isnull(D.RecvQTY,0) as RecvQTY,POD.ItemId,PRD.Style,PRD.PORecvDetailID, isnull((D.RecvQTY - sum(D.IssueQty)),0) as Balance"
            'str &= " from POMaster POM  jOIN PODetail POD ON POD .POID =POM.POID JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "
            'str &= " left join Accessories I on I.AccessoriesID=POD.ItemId left join IssueMst  mst on mst.POID=POM.POID "
            'str &= " left join IssueDetail  D on d.IssueID =Mst.IssueID  WHERE POD.ItemId ='" & ItemId & "' and POM.POID ='" & POID & "' "
            'str &= " group by PRD.PORecvDetailID,PRD.Style,D.RecvQTY,D.IssueQty,POD.ItemId "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithPONewNew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select  sum(POD.RecvQuantity) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =PDD.POID AND POR.ItemID"
            str &= " =PDD.ItemId ),0)as  RecvQuantity from PORecvMaster POM jOIN PORecvDetail "
            str &= "  POD ON POD .PORecvMasterID =POM.PORecvMasterID  "
            str &= "  join PODetail PDD on PDD.PoDetailId =POD.PODetailID "
            str &= " WHERE POM.POID ='" & POID & "'"
            str &= "   GROUP BY PDD.POID,PDD.ItemId"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithPOForNewIusse(ByVal POID As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            str = " Select  sum(POD.RecvQuantity) as  RecvQuantity from PORecvMaster POM jOIN PORecvDetail POD ON POD .PORecvMasterID =POM.PORecvMasterID  "
            str &= " join PODetail PDD on PDD.PoDetailId  =POD.PODetailID "
            str &= " WHERE POM.POID ='" & POID & "' and PDD.ItemId ='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithPO(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select  sum(POD.RecvQuantity) as  RecvQuantity from PORecvMaster POM jOIN PORecvDetail POD ON POD .PORecvMasterID =POM.PORecvMasterID  "
            str &= " WHERE POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithStyleNewNew(ByVal ItemId As Long, ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  ,PORecvDetailID from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "'"
            str &= " group by PORecvDetailID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForAny()

            Dim str As String
            str = "select JobOrderId,Srno from JobOrderdatabase"
            str &= "   order by SRNOPOne,SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForAnyForStoreIssueReport()

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join IssueDetail IM on IM.JobOrderID =JO.Joborderid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReportForProcess()

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join POProcessRecvMaster IM on IM.JobOrderID =JO.Joborderid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReport()

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join PORecvMaster IM on IM.JobOrderID =JO.Joborderid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReportForProcessIsssue()

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join processIssueDetail IM on IM.JobOrderID =JO.Joborderid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssue(ByVal SeasonDatabaseID As Long)

            Dim str As String
            str = "select  JobOrderId,Srno from JobOrderdatabase"
            str &= " where SeasonDatabaseID='" & SeasonDatabaseID & "'"
            str &= "   order by SRNOPOne,SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForNew(ByVal SeasonDatabaseID As Long, ByVal ItemCode As String)

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid"
            str &= " where JO.SeasonDatabaseID='" & SeasonDatabaseID & "' and jod.ItemCode='" & ItemCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerOrderNoFromIssue(ByVal JobOrderId As Long)

            Dim str As String
            str = "select * from JobOrderdatabase"
            str &= " where JobOrderId='" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFromIssue(ByVal JobOrderId As Long)

            Dim str As String
            str = "select * from JobOrderdatabaseDetail"
            str &= " where JobOrderId='" & JobOrderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDescriptionAndModelFromIssue(ByVal JobOrderDetaiId As Long)

            Dim str As String
            str = "select * from JobOrderdatabaseDetail"
            str &= " where JobOrderDetailId='" & JobOrderDetaiId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCONSUMPTIONFromIssue(ByVal JobOrderDetaiId As Long)

            Dim str As String
            str = "select * from ConDtl Dtl"
            str &= " join ConMst Mst ON Mst.ConMstID=Dtl.ConMstID"
            str &= " join SupplierDatabase SD ON SD.sUPPLIERDatabaseID=Mst.SupplierID"
            str &= " where Dtl.JobOrderDetailId='" & JobOrderDetaiId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizessFromIssue(ByVal JobOrderDetaiId As Long)

            Dim str As String
            str = " select DISTINCT SR.SizeRange AS SizeRange,isnull((jod.Quantity * SAM.ExtraQty)/100 ,0) as MulPercent,SAM.ExtraQty as PercentRatio,isnull((select sum(Sadd.Asortqty)+sum(Sadd.extraqTY)  from StyleAssortmentMaster Samm join  StyleAssortmentDetail Sadd on Sadd.StyleAssortmentMasterID "
            str &= " =Samm.StyleAssortmentMasterID where Samm.JoborderDetailid =jod.JoborderDetailid ),0) as ExtraQty,jod.BuyerColor,JOD.JoborderdetailID,JOD.Quantity from JobOrderdatabaseDetail JOD"
            str &= " join StyleAssortmentMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= " JOIN StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID =SAM.StyleAssortmentMasterID "
            str &= " JOIN SizeRange SR on SR.SizeRangeID =SAD.SizeRangeID"
            str &= " where JOD.JobOrderDetailId='" & JobOrderDetaiId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForStoreReport(ByVal SeasonDatabaseID As Long)

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join IssueDetail IM on IM.JobOrderID =JO.Joborderid "
            str &= " where IM.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForStoreReportForGoodRecvNoteForProcess(ByVal SeasonDatabaseID As Long)

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join POProcessRecvMaster IM on IM.JobOrderID =JO.Joborderid "
            str &= " where IM.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForStoreReportForGoodRecvNote(ByVal SeasonDatabaseID As Long)

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join PORecvMaster IM on IM.JobOrderID =JO.Joborderid "
            str &= " where IM.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromIssueForStoreReportForGoodRecvNoteForProcessIsssueReport(ByVal SeasonDatabaseID As Long)

            Dim str As String
            str = " select distinct JO.JobOrderId,JO.Srno from JobOrderdatabase JO"
            str &= " join processIssueDetail IM on IM.JobOrderID =JO.Joborderid "
            str &= " where IM.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromIssueForStoreReport()

            Dim str As String
            str = " select distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD"
            str &= " join IssueDetail IM on IM.SeasonDatabaseID =SD.SeasonDatabaseID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromIssueForStoreReportForGoogRecvNote()

            Dim str As String
            str = " select distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD"
            str &= " join PORecvMaster IM on IM.SeasonDatabaseID =SD.SeasonDatabaseID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromIssueForStoreReportForGoogRecvNoteForProcessIssue()

            Dim str As String
            str = " select distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD"
            str &= " join processIssueDetail IM on IM.SeasonDatabaseID =SD.SeasonDatabaseID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromIssueForStoreReportForGoogRecvNoteForProcess()

            Dim str As String
            str = " select distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD"
            str &= " join POProcessRecvMaster IM on IM.SeasonDatabaseID =SD.SeasonDatabaseID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromIssue()

            Dim str As String
            str = "select distinct SeasonDatabaseID,SeasonName from SeasonDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoAndSeasonFromIssue(ByVal POID As Long)

            Dim str As String
            str = "select * from PODetail dtl"
            str &= " join JobOrderdatabase Jo on JO.Joborderid =dtl.joborderid"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= " where dtl.POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithPONew(ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String
            str = " Select  sum(POD.RecvQuantity) as  RecvQuantity from POProcessRecvMaster POM jOIN POProcessRecvdETAIL POD ON POD .POProcessRecvMasterID =POM.POProcessRecvMasterID  "
            str &= " WHERE POM.ProcessOrderMstID ='" & ProcessOrderMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithPONewNewNew(ByVal ProcessOrderMstID As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            str = " Select  isnull(sum(POD.RecvQuantity),0) as  RecvQuantity from POProcessRecvMaster POM jOIN POProcessRecvdETAIL POD "
            str &= " ON POD .POProcessRecvMasterID =POM.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl PDD on PDD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " WHERE POM.ProcessOrderMstID ='" & ProcessOrderMstID & "' and PDD.ProcessItemNameID ='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithStyleNewNewForProcessIssueNew(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  from POProcessRecvMaster POM  "
            str &= " JOIN POProcessRecvDetail PRD ON PRD.POProcessRecvMasterID =PRD.POProcessRecvMasterID"
            str &= " WHERE  POM.fabricid='" & ItemId & "'"
            'str &= " group by POProcessRecvDetailID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithStyleNewNewForProcessIssue(ByVal ItemId As Long, ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String
            str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  ,POProcessRecvDetailID from ProcessOrderMst POM jOIN ProcessOrderDtl POD ON POD .ProcessOrderMstID =POM.ProcessOrderMstID  "
            str &= " JOIN POProcessRecvDetail PRD ON PRD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " WHERE POM.ProcessOrderMstID ='" & ProcessOrderMstID & "' and POD.ItemId ='" & ItemId & "'"
            str &= " group by POProcessRecvDetailID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithEntryType(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = "  select distinct sum(OpeningQuantity) as RecvQuantity, '0' as PORecvDetailID,EntryType,IMSItemId from IMSItem "
            str &= " where EntryType='In Stock' and IMSItemId ='" & ItemId & "'  group by EntryType,IMSItemId"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithEntryTypeForProcessIssue(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = "  select distinct sum(OpeningQuantity) as RecvQuantity, '0' as PORecvDetailID,EntryType,IMSItemId from IMSItem "
            str &= " where EntryType='In Stock' and IMSItemId ='" & ItemId & "'  group by EntryType,IMSItemId"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemWithStyleNew() As DataTable
            Dim str As String
            'str = "      Select distinct POD.ItemId,PRD.Style,PRD.PORecvDetailID,isnull((D.RecvQTY - sum(D.IssueQty)),0) as Balance  from POMaster POM "
            'str &= " jOIN PODetai            l POD ON POD .POID =POM.POID   JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join Accessories I on I.AccessoriesID=POD.ItemId left  join IssueMst  mst on mst.POID=POM.POID"
            'str &= " left join IssueDetail  D on d.IssueID =Mst.IssueID  where POM.CEOApproval = 1 And POM.FabricPorder = 0 "
            'str &= " group by PRD.PORecvDetailID,PRD.Style,D.RecvQTY,D.IssueQty,POD.ItemId "
            str = " Select distinct POD.ItemId,isnull(PRD.Style,'N/A') as Style,isnull(PRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull((D.RecvQTY - sum(D.IssueQty)),0) as Balance "
            str &= " from  POMaster POM  jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " left JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId          "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= " left join IssueMst  mst on mst.POID=POM.POID  "
            str &= " left join IssueDetail  D on d.IssueID =Mst.IssueID  where POM.CEOApproval = 1 And POM.FabricPorder = 0"
            str &= " group by PRD.PORecvDetailID,PRD.Style,D.RecvQTY,D.IssueQty,POD.ItemId "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindFabricWithStyleNew() As DataTable
            Dim str As String
            ''str = "      Select distinct POD.ItemId,isnull(PRD.Style,'N/A') as Style,isnull(PRD.PORecvDetailID,0) as PORecvDetailID,isnull((D.RecvQTY - sum(D.IssueQty)),0) as Balance  from "
            ''str &= " POMaster POM  jOIN PODetail POD ON POD .POID =POM.POID  left JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId          "
            ''str &= " left join Accessories I on I.AccessoriesID=POD.ItemId left join IssueMst  mst on mst.POID=POM.POID  "
            ''str &= " left join IssueDetail  D on d.IssueID =Mst.IssueID  where POM.CEOApproval = 1 And POM.FabricPorder = 1"
            ''str &= " group by PRD.PORecvDetailID,PRD.Style,D.RecvQTY,D.IssueQty,POD.ItemId "

            str = "   Select distinct POD.ItemId,isnull(PRD.Style,'N/A') as Style,isnull(PRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull((D.RecvQTY - sum(D.IssueQty)),0) as Balance "
            str &= " from  POMaster POM  jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId          "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= " left join IssueMst  mst on mst.POID=POM.POID  "
            str &= " left join IssueDetail  D on d.IssueID =Mst.IssueID  where POM.CEOApproval = 1 And POM.FabricPorder = 1"
            str &= " group by PRD.PORecvDetailID,PRD.Style,D.RecvQTY,D.IssueQty,POD.ItemId "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOtype() As DataTable
            Dim str As String
            str = " select * from ContractType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindDept() As DataTable
            Dim str As String
            str = " select DeptDatabaseID,DeptDatabaseName +' ('+ DeptAbbrivation +')' as DeptDatabaseName from IMSDepartmentDataBase"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindDeptFab() As DataTable
            Dim str As String
            str = " select DeptDatabaseID,DeptDatabaseName +' ('+ DeptAbbrivation +')' as DeptDatabaseName"
            str &= " from IMSDepartmentDataBase where DeptDatabaseId=29 or DeptDatabaseId=52 or DeptDatabaseId=14"
            str &= " or DeptDatabaseId=15 or DeptDatabaseId=16 or DeptDatabaseId=17 or DeptDatabaseId=18"
            str &= " or DeptDatabaseId=23 or DeptDatabaseId=24 or DeptDatabaseId=25 order by DeptDatabaseName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindDeptFabNew() As DataTable
            Dim str As String
            str = " select DeptDatabaseID,DeptDatabaseName +' ('+ DeptAbbrivation +')' as DeptDatabaseName"
            str &= " from IMSDepartmentDataBase order by DeptDatabaseName asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindContractor() As DataTable
            Dim str As String
            str = "  select PRM.SupplierId,Sd.SupplierName"
            str &= " from    PORecvMaster PRM   "
            str &= " left join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoMstrecvid(ByVal POID As Long, ByVal PORecvDetailID As Long) As DataTable
            Dim str As String
            str = " Select * from PORecvMaster pm join PORecvDetail PRD on pm.PORecvMasterID= PRD.PORecvMasterID where pm.POID='" & POID & "' and PORecvDetailID='" & PORecvDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoMstrecvidNew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select * from PORecvMaster pm join PORecvDetail PRD on pm.PORecvMasterID= PRD.PORecvMasterID where pm.POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoMstrecvidNewForProcessRecv(ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String
            str = " Select * from POProcessRecvMaster pm join POProcessRecvDetail PRD on pm.POProcessRecvMasterID= PRD.POProcessRecvMasterID where pm.ProcessOrderMstID='" & ProcessOrderMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoMstrecvidNewForProcessRecvNew(ByVal fabricId As Long) As DataTable
            Dim str As String
            str = " Select * from POProcessRecvMaster pm join POProcessRecvDetail PRD on pm.POProcessRecvMasterID= PRD.POProcessRecvMasterID where pm.fabricId='" & fabricId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoMstByInStockItem(ByVal ItemName As String) As DataTable
            Dim str As String
            ' str = " Select * from PORecvMaster where FabricRecv='" & ItemName & "'"
            str = " Select * from IMSItem where EntryType='In Stock' and ItemName='" & ItemName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemCode(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = " Select ItemCodee from IMSItem where IMSItemID='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIuuedQty(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select * from PORecvDetail PRD"
            str &= "  join IssueDetail ID on ID.PORecvDetailID =PRD.PORecvDetailID  "
            str &= "where POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecv(ByVal POID As Long, ByVal Itemid As Long, ByVal PORecvDetailID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueMst  mst "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID where mst.POID ='" & POID & "'  and  D.Itemid='" & Itemid & "' and PORecvDetailID='" & PORecvDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRate(ByVal POID As Long, ByVal ItemID As Long) As DataTable
            Dim str As String
            str = "  select TOP 1 POD.Rate * POD.ExchangeRate AS Rate from POMaster Mst"
            str &= " join PODetail POD on POD.POID =Mst.POID "
            str &= " WHERE mst.POID ='" & POID & "' and POD.ItemID ='" & ItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyyyyyyyFORGodwon(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(QtyIssue),0) as QtyIssue from IMSGodownIssueDetail  "
            str &= " where ToLocationID =10 and IMSItemID ='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyyyyyyyFORGodwonForprocess(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(QtyIssue),0) as QtyIssue from IMSGodownIssueDetailForProcess  "
            str &= " where ToLocationID =10 and IMSItemID ='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyyyyyyy(ByVal POID As Long, ByVal ItemID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(ReturnQty),0) as returnQty from POReturn  "
            str &= " where POID ='" & POID & "' and ItemID ='" & ItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvNewNew(ByVal POID As Long, ByVal ItemID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(Dtl.IssueQty),0) as AlreadyIssued from IssueMst  mst  "
            str &= " join IssueDetail Dtl on Dtl.IssueID =mst.IssueID"
            str &= " where Dtl.POID ='" & POID & "' and Dtl.ItemID ='" & ItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvNew(ByVal POID As Long, ByVal Itemid As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueMst  mst "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID where mst.POID ='" & POID & "'  and  D.Itemid='" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvNewNewForProcessIssue(ByVal ProcessOrderMstID As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(Dtl.IssueQty),0) as AlreadyIssued from processIssueMst  mst  "
            str &= " join processIssueDetail Dtl on Dtl.processIssueID =mst.processIssueID"
            str &= " where mst.ProcessOrderMstID ='" & ProcessOrderMstID & "' and Dtl.ItemId='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvNewForProcessIssue(ByVal POID As Long, ByVal Itemid As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueMst  mst "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID where mst.POID ='" & POID & "'  and  D.Itemid='" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyRecvNew(ByVal Itemid As Long) As DataTable
            Dim str As String
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID "
            str &= " where  D.Itemid='" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            'str = "   select *,(select Sum(IssueQty) from IssueDetail D where d.IssueID =Mst.IssueID ) as IssueQty"
            'str &= " ,(select sum( RecvQty)  from IssueDetail D where d.IssueID =Mst.IssueID ) as RecvQty"
            'str &= " from IssueMst  mst "
            'str &= "join POMaster pm on pm.POID =mst.POID "

            '--Style Added by Bilal Awan
            str = " select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,ITM.ItemName,a.FabricWeave) as ItemName,"
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
            str &= " left   join IssueDetail  D on d.IssueID =Mst.IssueID left  join POMaster pm on pm.POID =mst.POID "
            str &= " left  join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID  "
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID left JOIN IMSItem ITM ON ITM.IMSItemid=D.ITEMID  "
            '  str &= "  join ItemProduct ip on ip .ItemID =D .ItemID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNew() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = " select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=0 "

            str = " select  mst.ManualChallanNo,isnull(D.Style,'N/A') as Style, ITM.ItemName as ItemName, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "    join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "     where mst.FabricStatus=0 "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForALL() As DataTable
            Dim str As String
              str = " select  mst.ManualChallanNo, ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "    join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForAcc() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = " select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=0 "

            str = " select  mst.ManualChallanNo, ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "    join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "     where mst.FabricStatus=0 "
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewWithEntryWise() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,ITM.ItemName) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*,"
            str &= "  convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee "
            str &= "  from IssueMst  mst left  join IssueDetail  D on d.IssueID =Mst.IssueID  left join POMaster pm on pm.POID =mst.POID   "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID   left join Accessories I on I.AccessoriesID=D.ItemID "
            str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID left join IMSItem ITM on ITM.IMSItemId=d.ItemId"
            '  str &= "  join ItemProduct ip on ip .ItemID =D .ItemID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSearch(ByVal ItemName As String) As DataTable
            Dim str As String
           
            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus=1 and ITM.ItemName ='" & ItemName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function ViewALLIssue() As DataTable
            Dim str As String
           
            str = "      select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID "
            str &= "  join POMaster pm on pm.POID =mst.POID "
            str &= "  join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
            str &= "  where pm.FabricPOrder=0 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabric() As DataTable
            Dim str As String
            'str = "   select *,(select Sum(IssueQty) from IssueDetail D where d.IssueID =Mst.IssueID ) as IssueQty"
            'str &= " ,(select sum( RecvQty)  from IssueDetail D where d.IssueID =Mst.IssueID ) as RecvQty"
            'str &= " from IssueMst  mst "
            'str &= "join POMaster pm on pm.POID =mst.POID "

            '--Style Added by Bilal Awan
            'str = "      select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID "
            'str &= "  join POMaster pm on pm.POID =mst.POID "
            'str &= "  join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID  where pm.FabricPOrder=1 "
            ''  str &= "  join ItemProduct ip on ip .ItemID =D .ItemID "

            str = " select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName,"
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from "
            str &= "  IssueMst  mst   join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID  "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID  left join Accessories I on I.AccessoriesID=D.ItemID "
            str &= "  left join IMSItem ITM on ITM.IMSItemID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID  where pm.FabricPOrder=1  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNew() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = "   select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=1   "

            str = " select  mst.ManualChallanNo,isnull(D.Style,'N/A') as Style,ITM.ItemName as ItemName, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus=1 "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssueForDepartmentVise(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & ManualChallanNo & "'"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssueFormanualChallanVise(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1 and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssueForitemCodeVise(ByVal itemCodee As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1 and ITM.itemCodee= '" & itemCodee & "'"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssueForPonoVise(ByVal PONO As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1 and pm.pono= '" & PONO & "'"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssueAllCaseNew() As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewProcessIssue() As DataTable
            Dim str As String
         
            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo "
            str &= "   from   processIssueMst  mst  "
            str &= "  join processIssuedetail  D on d.processIssueID =Mst.processIssueID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID    "
            str &= "  left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "  where mst.FabricStatus = 1"
            str &= "   order by mst.processIssueID desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForPONOViseIssuedVise(ByVal pono As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus=1  and pm.pono= '" & pono & "'"
            str &= " order by pm.PONO "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForPONOVise(ByVal pono As String) As DataTable
            Dim str As String

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus=1  and pm.pono= '" & pono & "'"
            str &= " order by pm.PONO "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForFabricCodeViseViseForAll(ByVal ItemCodee As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=0  and ITM.ItemCodee= '" & ItemCodee & "'"
            'str &= " order by pm.PONO "

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  ITM.ItemCodee= '" & ItemCodee & "'"
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForFabricCodeViseViseForAcc(ByVal ItemCodee As String) As DataTable
            Dim str As String

         

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 0 and pm.GStoreStatus=0 and ITM.ItemCodee= '" & ItemCodee & "'"
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForFabricCodeViseViseForAccGStore(ByVal ItemCodee As String) As DataTable
            Dim str As String



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.GStoreStatus=1 and ITM.ItemCodee= '" & ItemCodee & "'"
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForFabricCodeViseViseForAuditor(ByVal ItemCodee As String) As DataTable
            Dim str As String




            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  Mst.AuditorStatus =0 and ITM.ItemCodee= '" & ItemCodee & "'"
            str &= " order by mst.IssueID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForFabricCodeViseVise(ByVal ItemCodee As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=1  and ITM.ItemCodee= '" & ItemCodee & "'"
            'str &= " order by pm.PONO "


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 1 and ITM.ItemCodee= '" & ItemCodee & "'"
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForManulaChalanViseForAll(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=0  and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            'str &= " order by pm.PONO "


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where   mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForManulaChalanViseForAcc(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

        

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 0 and pm.GStoreStatus=0 and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForManulaChalanViseForAccGStore(ByVal ManualChallanNo As String) As DataTable
            Dim str As String



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.GStoreStatus=1 and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForManulaChalanViseForAuditor(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  Mst.AuditorStatus =0 and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= " order by mst.IssueID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForManulaChalanVise(ByVal ManualChallanNo As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=1  and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            'str &= " order by pm.PONO "


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 1 and mst.ManualChallanNo= '" & ManualChallanNo & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForDepartmentViseForAll(ByVal DeptDatabaseName As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=0  and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            'str &= " order by pm.PONO "



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where   (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForDepartmentViseForAcc(ByVal DeptDatabaseName As String) As DataTable
            Dim str As String


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 0 and pm.GStoreStatus=0 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForDepartmentViseForAccGStore(ByVal DeptDatabaseName As String) As DataTable
            Dim str As String


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.GStoreStatus=1 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForDepartmentViseForAuditor(ByVal DeptDatabaseName As String) As DataTable
            Dim str As String


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  Mst.AuditorStatus =0 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            str &= " order by mst.IssueID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForDepartmentVise(ByVal DeptDatabaseName As String) As DataTable
            Dim str As String

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=1  and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            'str &= " order by pm.PONO "


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 1 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')= '" & DeptDatabaseName & "'"
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForAccAll() As DataTable
            Dim str As String

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where pm.FabricPOrder = 0 and pm.GStoreStatus=0 "
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForAcc() As DataTable
            Dim str As String

            str = "   DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"
            str &= " select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where pm.FabricPOrder = 0 and pm.GStoreStatus=0 "
            str &= " and mst.creationdate between @datefrom and @todate "
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForAccGStoreAll() As DataTable
            Dim str As String

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where pm.GStoreStatus=1 "
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForAccGStore() As DataTable
            Dim str As String

            str = "   DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"
            str &= " select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where pm.GStoreStatus=1 "
            str &= " and mst.creationdate between @datefrom and @todate "
            str &= " order by mst.IssueID desc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateAny() As DataTable
            Dim str As String

            str = "    DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"

            str &= "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where mst.FabricStatus = 1 Or pm.FabricPOrder = 1 "
            str &= " and mst.creationdate between @datefrom and @todate "
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateAlll() As DataTable
            Dim str As String



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where mst.FabricStatus = 1 Or pm.FabricPOrder = 1 "
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateAllAll() As DataTable
            Dim str As String



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateAll() As DataTable
            Dim str As String

            str = "    DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"

            str &= "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.creationdate between @datefrom and @todate "
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNew() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = "   select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=1   "

            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus=1 or pm.FabricPOrder=1 "
            str &= " order by pm.PONO "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewPONOViseForIssuedForAll(ByVal PONO As String) As DataTable
            Dim str As String

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.PONO='" & PONO & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewPONOViseForIssuedForAcc(ByVal PONO As String) As DataTable
            Dim str As String

          

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.FabricPOrder = 0 and pm.GStoreStatus=0 and pm.PONO='" & PONO & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewPONOViseForIssuedForAccGStore(ByVal PONO As String) As DataTable
            Dim str As String



            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "            where  pm.GStoreStatus=1 and pm.PONO='" & PONO & "'"
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewPONOViseForIssuedForAuditor(ByVal PONO As String) As DataTable
            Dim str As String

            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "   where pm.PONO='" & PONO & "' and  Mst.AuditorStatus = 0 "
            str &= " order by mst.IssueID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewPONOViseForIssued(ByVal PONO As String) As DataTable
            Dim str As String

          


            str = "  select  Mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "   where pm.PONO='" & PONO & "' and  pm.FabricPOrder = 1 "
            str &= " order by mst.IssueID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function BindFabricOnLoad(ByVal PORecvDetailid As Long)
            Dim str As String
            'str = "  select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= "  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where FabricPOrder=1 and ItemId='" & ItemId & "' "

            'str = "  select DISTINCT POD.Style,POD.ItemID ,isnull(a.fabricweave,'N/A') as ItemName from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= "  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where FabricPOrder=1 and ItemId='" & ItemId & "' 
            str = "  select IMSItemId,ItemName   from POMaster POM "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId   "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "  where PORecvDetailid = '" & PORecvDetailid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindFabricOnLoadNew(ByVal ItemID As Long)
            Dim str As String
                   str = "  select IMSItemId,ItemName   from POMaster POM "
            str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId   "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "  where POD.ItemId = '" & ItemID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemOnLoad(ByVal ItemId As Long)
            Dim str As String
            'str = "  select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= "  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where FabricPOrder=0 and ItemId='" & ItemId & "' "

            str = "  select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,'N/A') as ItemName from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= "  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId "
            str &= "  where FabricPOrder=0 and ItemId='" & ItemId & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPartyFabricWiseForcmbParty()
            Dim str As String
            str = " select  idd.DeptDatabaseId,idd.DeptDatabaseName from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=1 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyItemWiseForcmbParty()
            Dim str As String
            str = " select  idd.DeptDatabaseId,idd.DeptDatabaseName from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=0 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricWiseForcmbItem()
            Dim str As String
            str = "  select i.AccessoriesName,i.AccessoriesId from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=1 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemItemWiseForcmbItem()
            Dim str As String
            str = "  select  i.AccessoriesName,i.AccessoriesId from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=0 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFabricWiseForStyle()
            Dim str As String
            str = " select  isnull(D.Style,'N/A') as Style,d.IssueDtlId from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=1 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleItemWiseForStyle()
            Dim str As String
            str = " select  isnull(D.Style,'N/A') as Style,d.IssueDtlId from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID where pm.FabricPOrder=0 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMonthWiseViewForFabric(ByVal Style As String, ByVal Item As String, ByVal Party As String) As DataTable
            Dim str As String

            If Style <> "" And Item <> "" And Party <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "' and idd.DeptdatabaseName='" & Party & "' and i.AccessoriesName='" & Item & "'"
            ElseIf Style <> "" And Item <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "'  and i.AccessoriesName='" & Item & "'"
            ElseIf Style <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "'"
            ElseIf Style = "" And Item = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and idd.DeptdatabaseName='" & Party & "'"
            ElseIf Style = "" And Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1  and i.AccessoriesName='" & Item & "'"
            ElseIf Item = "" And Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "' "
            ElseIf Style = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1  and idd.DeptdatabaseName='" & Party & "' and i.AccessoriesName='" & Item & "'"
            ElseIf Item = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "' and idd.DeptdatabaseName='" & Party & "'"
            ElseIf Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 and Style='" & Style & "'  and i.AccessoriesName='" & Item & "'"
            Else
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=1 "
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMonthWiseViewForItem(ByVal Style As String, ByVal Item As String, ByVal Party As String) As DataTable
            Dim str As String

            If Style <> "" And Item <> "" And Party <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "' and idd.DeptdatabaseName='" & Party & "' and i.AccessoriesName='" & Item & "'"
            ElseIf Style <> "" And Item <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "'  and i.AccessoriesName='" & Item & "'"
            ElseIf Style <> "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "'"
            ElseIf Style = "" And Item = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and idd.DeptdatabaseName='" & Party & "'"
            ElseIf Style = "" And Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0  and i.AccessoriesName='" & Item & "'"
            ElseIf Item = "" And Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "' "
            ElseIf Style = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0  and idd.DeptdatabaseName='" & Party & "' and i.AccessoriesName='" & Item & "'"
            ElseIf Item = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "' and idd.DeptdatabaseName='" & Party & "'"
            ElseIf Party = "" Then
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 and Style='" & Style & "'  and i.AccessoriesName='" & Item & "'"
            Else
                str = " select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*"
                str &= " ,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
                str &= " join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID"
                str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
                str &= " where pm.FabricPOrder=0 "
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemAllInfoISSUE(ByVal ItemName As String)
            Dim str As String
            str = "  select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) "
            str &= " as Balance,*,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')')"
            str &= " as DeptDatabaseNamee  from IssueMst  mst join IssueDetail  D on d.IssueID =Mst.IssueID join POMaster pm on pm.POID =mst.POID "
            str &= " join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID left join Accessories I on I.AccessoriesID=D.ItemID"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID"
            str &= " where I.Accessoriesname Like '" & ItemName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabric()
            Dim str As String
            str = " select DISTINCT POD.ItemID ,COALESCE (I.Accessoriesname,a.fabricweave,IMS.ItemName) as ItemName from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            str &= " Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId left join Accessories I on I.AccessoriesID =POD.ItemId "
            str &= "left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID join IMSItem IMS on IMS.IMSItemId=POD.ITEMID  where FabricPOrder=1 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemForFabric()
            Dim str As String
            str = "  select distinct ItemId,COALESCE (a.fabricweave,IM.ItemName) as ItemName from IssueMst ISM"
            str &= " left join IssueDetail ISD on ISD.IssueID=ISM.IssueID left  join IMSItem IM on IM.IMSItemID=ISD.ItemID "
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=ISD.ITEMID where ISM.FabricStatus=1 and ISM.POID>0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetInStockFabric()
            Dim str As String
            str = " select distinct ItemId,COALESCE (I.Accessoriesname,IM.ItemName) as ItemName from IssueMst ISM left join IssueDetail ISD on ISD.IssueID=ISM.IssueID left  join IMSItem IM on IM.IMSItemID=ISD.ItemID "
            str &= " left join Accessories I on I.AccessoriesID =ISD.ItemId  where ISM.FabricStatus=1 and ISM.POID=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetInStockAcc()
            Dim str As String
            str = " select distinct ItemId,COALESCE (I.Accessoriesname,IM.ItemName) as ItemName from IssueMst ISM left join IssueDetail ISD on ISD.IssueID=ISM.IssueID left  join IMSItem IM on IM.IMSItemID=ISD.ItemID "
            str &= " left join Accessories I on I.AccessoriesID =ISD.ItemId  where ISM.FabricStatus=0 and ISM.POID=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemForAccessories()
            Dim str As String
            str = "  select distinct ItemId,COALESCE (I.Accessoriesname,IM.ItemName) as ItemName from IssueMst ISM"
            str &= " left join IssueDetail ISD on ISD.IssueID=ISM.IssueID left  join IMSItem IM on IM.IMSItemID=ISD.ItemID "
            str &= " left join Accessories I on I.AccessoriesID =ISD.ItemId  where ISM.FabricStatus=0 and ISM.POID>0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTableTemp()
            Dim str As String
            str = " Truncate Table TempRecvIssueLedger "
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTableTempFinal()
            Dim str As String
            str = " Truncate Table TempRecvIssueLedgerFinal "
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertRecvInTempAcc(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger select distinct PM.PoRecvMasterId,PRM.PoRecvDetailId,PRM.POQuantity,PRM.ReceiveDate as TempDate,PRM.Style,PRM.SupplierId,"
            str &= " '0' as IssueID,'0' as POID,'0' as IssueDtlID,'0' as ItemID,'' as DeptName,'0' as contractor,PRM.RecvQuantity,'0' as IssueQty,"
            str &= " '0' as EntryType,isnull(a.AccessoriesName,PM.FabricRecv) as ItemName from PoRecvMaster PM "
            str &= " join PoRecvDetailHistory PRM on PRM.PoRecvMasterId=PM.PoRecvMasterId join PoMaster POM on POM.PoId=PM.PoId"
            str &= " join PoDetail POD on POD.PoId=PM.PoId left join Accessories a on a.IMSitemid=POD.ItemId"
            str &= " where PM.FabricRecv='" & ItemName & "' or a.AccessoriesName='" & ItemName & "' "

            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertRecvInTempStock(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger select Top 1  '0' as PoRecvMasterId,'0' as PoRecvDetailId,'0' as "
            ' str &= " POQuantity,Issm.CreationDate as TempDate,'0' as Style,'0' as SupplierId, ISd.IssueID,"
            str &= " POQuantity,IMs.EntryDate as TempDate,'0' as Style,'0' as SupplierId, ISd.IssueID,"
            str &= " '0' as POID,IsD.IssueDtlID,Isd.ItemID,'' as DeptName,isd.contractor,"
            str &= " Isd.RecvQty as RecvQuantity,'0' as IssueQty,Isd.EntryType, isnull(IMs.ItemName,'N/A') as ItemName"
            str &= " from IssueDetail ISd join IMSItem IMs on IMs.IMSITEMID=ISd.ItemID"
            str &= " join IssueMst Issm on Issm.IssueID=isd.IssueID"
            str &= "  join IMSDepartmentDataBase DDB on DDB.DeptDataBaseID=IsD.DeptDataBaseID"
            str &= " where ItemName='" & ItemName & "' "

            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertRecvInTempFab(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger select distinct PM.PoRecvMasterId,PRM.PoRecvDetailId,PRM.POQuantity,PRM.ReceiveDate as TempDate,PRM.Style,PRM.SupplierId,"
            str &= "  '0' as IssueID,'0' as POID,'0' as IssueDtlID,'0' as ItemID,'' as DeptName,'0' as contractor,PRM.RecvQuantity,'0' as IssueQty,"
            str &= "  '0' as EntryType,isnull(a.FabricWeave,PM.FabricRecv) as ItemName from PoRecvMaster PM "
            str &= "  join PoRecvDetailHistory PRM on PRM.PoRecvMasterId=PM.PoRecvMasterId join PoMaster POM on POM.PoId=PM.PoId"
            str &= "  join PoDetail POD on POD.PoId=PM.PoId left join FabricDatabase a on a.IMSitemid=POD.ItemId"
            str &= " where PM.FabricRecv='" & ItemName & "' or a.FabricWeave='" & ItemName & "' "

            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertIssueInTempAcc(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger  select distinct  '0' as PoRecvMasterId,'0' as PoRecvDetailId,'0' as "
            str &= " POQuantity,IM.CreationDate as TempDate,'0' as Style,'0' as SupplierId, IM.IssueID,"
            str &= " IM.POID,IsD.IssueDtlID,Isd.ItemID,DDB.DeptDatabaseName as DeptName,isd.contractor,"
            str &= " '0' as RecvQuantity,isd.IssueQty,Isd.EntryType, isnull(FB.AccessoriesName,RSM.FabricRecv)"
            str &= " as ItemName from IssueMst IM join IssueDetail IsD on IM.IssueID=IsD.IssueID "
            str &= " join IMSDepartmentDataBase DDB on DDB.DeptDataBaseID=IsD.DeptDataBaseID"
            str &= " left join Accessories FB on FB.IMSitemid=isd.ItemId "
            str &= " left join IMSItem IMS on IMS.IMSitemid=isd.ItemId"
            str &= " left join PorecvDetail RSD on RSD.PoRecvDetailID=IsD.PoRecvDetailID  "
            str &= " left join PorecvMaster RSM on RSM.PoRecvMasterID=RSD.PoRecvMasterID"
            str &= " where FB.AccessoriesName='" & ItemName & "' or RSM.FabricRecv='" & ItemName & "'  "
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertIssueInTempStock(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger  select distinct  '0' as PoRecvMasterId,'0' as PoRecvDetailId,'0' as "
            str &= " POQuantity,Issm.CreationDate as TempDate,'0' as Style,'0' as SupplierId, ISd.IssueID,"
            str &= " '0' as POID,IsD.IssueDtlID,Isd.ItemID,DDB.DeptDatabaseName as DeptName,isd.contractor,"
            str &= " '0' as RecvQuantity,Isd.IssueQty,Isd.EntryType, isnull(IMs.ItemName,'N/A') as ItemName"
            str &= " from IssueDetail ISd join IMSItem IMs on IMs.IMSITEMID=ISd.ItemID"
            str &= " join IssueMst Issm on Issm.IssueID=isd.IssueID"
            str &= " join IMSDepartmentDataBase DDB on DDB.DeptDataBaseID=IsD.DeptDataBaseID"
            str &= " where ItemName='" & ItemName & "'"

            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertIssueInTempFab(ByVal ItemName As String)
            Dim str As String
            str = " insert into TempRecvIssueLedger  select distinct  '0' as PoRecvMasterId,'0' as PoRecvDetailId,'0' as "
            str &= " POQuantity,IM.CreationDate as TempDate,'0' as Style,'0' as SupplierId, IM.IssueID,"
            str &= " IM.POID,IsD.IssueDtlID,Isd.ItemID,DDB.DeptDatabaseName as DeptName,isd.contractor,"
            str &= " '0' as RecvQuantity,isd.IssueQty,Isd.EntryType, isnull(FB.fabricweave,RSM.FabricRecv)"
            str &= " as ItemName from IssueMst IM join IssueDetail IsD on IM.IssueID=IsD.IssueID "
            str &= " join IMSDepartmentDataBase DDB on DDB.DeptDataBaseID=IsD.DeptDataBaseID"
            str &= " left join FabricDatabase FB on FB.IMSitemid=isd.ItemId "
            str &= " left join IMSItem IMS on IMS.IMSitemid=isd.ItemId "
            str &= " left join PorecvDetail RSD on RSD.PoRecvDetailID=IsD.PoRecvDetailID   "
            str &= " left join PorecvMaster RSM on RSM.PoRecvMasterID=RSD.PoRecvMasterID"
            str &= " where FB.fabricweave='" & ItemName & "' or RSM.FabricRecv='" & ItemName & "' "
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function InsertInTempFinal()
            Dim str As String
            str = " insert into TempRecvIssueLedgerFinal select PoRecvMasterId,PoRecvDetailId,POQuantity,TempDate,Style,SupplierId,IssueID,POID,IssueDtlID,ItemID,DeptName,contractor"
            str &= " ,RecvQuantity,IssueQty,EntryType,ItemName  from TempRecvIssueLedger order by TempDate"
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
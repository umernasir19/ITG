Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class IssueProcessMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IssueProcessMst"
            m_strPrimaryFieldName = "IssueProcessID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lIssueProcessID As Long
        Private m_strPOType As String
        Private m_dCreationDate As Date
        Private m_lProcessOrderMstID As Long
        Private m_lPOProcessRecvMasterID As Long
        Private m_BolFabricStatus As Boolean
        Private m_lLocationId As Long
        Private m_strManualChallanNo As String
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
        Public Property IssueProcessID() As Long
            Get
                IssueProcessID = m_lIssueProcessID
            End Get
            Set(ByVal Value As Long)
                m_lIssueProcessID = Value
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
        Public Property ProcessOrderMstID() As Long
            Get
                ProcessOrderMstID = m_lProcessOrderMstID
            End Get
            Set(ByVal Value As Long)
                m_lProcessOrderMstID = Value
            End Set
        End Property
        Public Property POProcessRecvMasterID() As Long
            Get
                POProcessRecvMasterID = m_lPOProcessRecvMasterID
            End Get
            Set(ByVal Value As Long)
                m_lPOProcessRecvMasterID = Value
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
        Public Function BindPO() As DataTable
            Dim str As String
            'str = "  select Distinct POM.POID,POM.PONO from POMaster POM"
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   "
            'str &= " right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId  "


            'str = "  select Distinct POM.POID,POM.PONO from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID"
            'str &= " join  POMaster POM on POM.POID=PRM.POID where FabricPOrder=0"

            'str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    PORecvMaster PRM   "
            'str &= " join PORecvDetail PRD on PRM.PORecvMasterID= PRD.PORecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            'str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=0 "

            str = " select Distinct POM.ProcessOrderMstID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo"
            str &= "  from    POProcessRecvMaster PRM   "
            str &= " join POProcessRecvDetail PRD on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID "
            str &= " join  ProcessOrderMst POM on POM.ProcessOrderMstID=PRM.ProcessOrderMstID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=0 "
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
        Public Function GetIMSItemID(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " select IMSItemID frOm IMSItem"
            str &= "   where ItemCodee = '" & ItemCodee & "'"
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

            'str = " select Distinct POM.POID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo from    POProcessRecvMaster PRM   "
            'str &= " join POProcessRecvDetail PRD on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID join  POMaster POM on POM.POID=PRM.POID "
            'str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=1 "


            str = " select Distinct POM.ProcessOrderMstID,(POM.PONO+' '+'('+JOD.JobOrderNo+')') as PONo"
            str &= " from    POProcessRecvMaster PRM  join POProcessRecvDetail PRD on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID "
            str &= " join  ProcessOrderMst POM on POM.ProcessOrderMstID=PRM.ProcessOrderMstID "
            str &= " join JobOrderDataBase JOD on JOD.Joborderid=POM.Joborderid where FabricPOrder=1 "
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
        Public Function BindPOFabricNew(ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = " select DISTINCT POD.Style,POD.ItemID ,isnull(I.Accessoriesname,a.fabricweave) as ItemName,POM.* from POMaster POM  "
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID  Right JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join Accessories I on I.AccessoriesID =POD.ItemId  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            'str &= " where FabricPOrder=1 and ItemId= '" & ItemId & "'  "
            'str = " select distinct POM.PONO,POM.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO from POMaster POM  "
            'str &= " jOIN PODetail POD ON POD .POID =POM.POID   JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " left join JobOrderdatabase jb on jb.Joborderid =POM.JoborderID   "
            'str &= " where     POD.ItemId= '" & ItemId & "'  "



            str = " select distinct POM.PONO,POM.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from ProcessOrderMst POM  "
            str &= " jOIN ProcessOrderDtl POD ON POD .ProcessOrderMstID =POM.ProcessOrderMstID"
            str &= " JOIN POProcessRecvDetail PRD ON PRD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POM.JoborderID   "
            str &= "   where POD.ProcessItemNameID=  '" & ItemId & "' "


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
        Public Function BindRecvQtyWithStyleNewNew(ByVal ItemId As Long, ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String
            'str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  ,PORecvDetailID from POMaster POM jOIN PODetail POD ON POD .POID =POM.POID  "
            'str &= " JOIN PORecvDetail PRD ON PRD.PODetailID =POD.PoDetailId "
            'str &= " WHERE POM.POID ='" & POID & "' and POD.ItemId ='" & ItemId & "'"
            'str &= " group by PORecvDetailID "

            str = " Select  sum(prd.RecvQuantity)-sum(ReturnQty) as  RecvQuantity  "
            str &= " ,POProcessRecvDetailID from ProcessOrderMst POM "
            str &= " jOIN ProcessOrderDtl POD ON POD .ProcessOrderMstID =POM.ProcessOrderMstID  "
            str &= "  JOIN POProcessRecvDetail PRD ON PRD.ProcessOrderDtlID =POD.ProcessOrderDtlID "
            str &= " WHERE POM.ProcessOrderMstID ='" & ProcessOrderMstID & "' and POD.ProcessItemNameID ='" & ItemId & "'"
            str &= "  group by POProcessRecvDetailID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindRecvQtyWithEntryType(ByVal ItemId As Long) As DataTable
            Dim str As String
            str = "  select distinct sum(OpeningQuantity) as RecvQuantity, '0' as POProcessRecvDetailID,EntryType,IMSItemId from IMSItem "
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
            str &= " from IMSDepartmentDataBase order by DeptDatabaseName"
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
        Public Function GetPoMstrecvidNew(ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String
            ' str = " Select * from PORecvMaster pm join PORecvDetail PRD on pm.PORecvMasterID= PRD.PORecvMasterID where pm.POID='" & POID & "'"
            str = "   Select * from POProcessRecvMaster pm "
            str &= " join POProcessRecvDetail PRD on pm.POProcessRecvMasterID= PRD.POProcessRecvMasterID "
            str &= " where pm.ProcessOrderMstID='" & ProcessOrderMstID & "'"
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
        Public Function GetAlreadyRecvNew(ByVal ProcessOrderMstID As Long, ByVal Itemid As Long) As DataTable
            Dim str As String
            'str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueMst  mst "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID where mst.POID ='" & POID & "'  and  D.Itemid='" & Itemid & "'"
            str = "  select isnull(SUM(IssueQty),0) as AlreadyIssued from IssueProcessMst  mst "
            str &= " join IssueProcessDetail  D on d.IssueProcessID =Mst.IssueProcessID "
            str &= " where mst.ProcessOrderMstID ='" & ProcessOrderMstID & "'  and  D.Itemid='" & Itemid & "'"
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
        Public Function ViewNewForAcc() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = " select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=0 "

            'str = " select  mst.ManualChallanNo, ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "    join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "     where mst.FabricStatus=0 "
            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee,"
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,"
            str &= " isnull(pm.PONo,'In Stock') as PONoo  from   IssueProcessMst  mst  "
            str &= " join IssueProcessDetail  D on d.IssueProcessID =Mst.IssueProcessID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID  "
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus = 0"


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
            'str = "   select *,(select Sum(IssueQty) from IssueDetail D where d.IssueID =Mst.IssueID ) as IssueQty"
            'str &= " ,(select sum( RecvQty)  from IssueDetail D where d.IssueID =Mst.IssueID ) as RecvQty"
            'str &= " from IssueMst  mst "
            'str &= "join POMaster pm on pm.POID =mst.POID "

            '--Style Added by Bilal Awan
            str = "      select  isnull(D.Style,'N/A') as Style,isnull(I.Accessoriesname,a.fabricweave) as ItemName,(D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date,(Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee  from IssueMst  mst "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID "
            str &= "  join POMaster pm on pm.POID =mst.POID "
            str &= "  join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID "
            str &= "  where pm.FabricPOrder=0 and I.AccessoriesName='" & ItemName & "'"
            '  str &= "  join ItemProduct ip on ip .ItemID =D .ItemID "
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
        Public Function ViewFabricNewNew() As DataTable
            Dim str As String
            '--Style Added by Bilal Awan
            'str = "   select  isnull(D.Style,'N/A') as Style,COALESCE(I.Accessoriesname,a.fabricweave,ITM.ItemName) as ItemName, "
            'str &= "  (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= "  (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= "  left join Accessories I on I.AccessoriesID=D.ItemID  left join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= "  left JOIN FabricDatabase a ON a.FabricDatabaseid=D.ITEMID   where mst.FabricStatus=1   "

            'str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            'str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            'str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo  from   IssueMst  mst  "
            'str &= " join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =mst.POID   left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            'str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            'str &= " where mst.FabricStatus=1 "


            str = " select  mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee,"
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,"
            str &= " isnull(pm.PONo,'In Stock') as PONoo  from   IssueProcessMst  mst  "
            str &= " join IssueProcessDetail  D on d.IssueProcessID =Mst.IssueProcessID "
            str &= "  left join ProcessOrderMst pm on pm.ProcessOrderMstID =mst.ProcessOrderMstID  "
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= " join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= " where mst.FabricStatus = 1"


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
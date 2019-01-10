Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class POProcessRecvMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "POProcessRecvMaster"
            m_strPrimaryFieldName = "POProcessRecvMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPOProcessRecvMasterID As Long
        Private m_dtPORecvDate As Date
        Private m_strGatePassNo As String
        Private m_strPartyDCNo As String
        Private m_lSupplierID As Long
        Private m_lProcessOrderMstID As Long
        Private m_strStyle As String
        Private m_lFabricId As Long
        Private m_lLocationID As Long
        Private m_lSeasonDatabaseID As Long
        Private m_lJobOrderID As Long
        Private m_strSeasonName As String
        Private m_strSrNoo As String
        Public Property SeasonName() As String
            Get
                SeasonName = m_strSeasonName
            End Get
            Set(ByVal value As String)
                m_strSeasonName = value
            End Set
        End Property
        Public Property SrNoo() As String
            Get
                SrNoo = m_strSrNoo
            End Get
            Set(ByVal value As String)
                m_strSrNoo = value
            End Set
        End Property
        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        
        Public Property LocationID() As Long
            Get
                LocationID = m_lLocationID
            End Get
            Set(ByVal Value As Long)
                m_lLocationID = Value
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
        Public Property PORecvDate() As Date
            Get
                PORecvDate = m_dtPORecvDate
            End Get
            Set(ByVal value As Date)
                m_dtPORecvDate = value
            End Set
        End Property
        Public Property GatePassNo() As String
            Get
                GatePassNo = m_strGatePassNo
            End Get
            Set(ByVal value As String)
                m_strGatePassNo = value
            End Set
        End Property
        Public Property PartyDCNo() As String
            Get
                PartyDCNo = m_strPartyDCNo
            End Get
            Set(ByVal value As String)
                m_strPartyDCNo = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
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
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property
        Public Property FabricId() As Long
            Get
                FabricId = m_lFabricId
            End Get
            Set(ByVal Value As Long)
                m_lFabricId = Value
            End Set
        End Property

        Public Function SavePORecvMaster()
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
        Public Function GetPOData(ByVal POID As Long) As DataTable
            Dim str As String
            'str = " select  YPD.YarnPurchaseContractDetailID,isnull(YRD.YarnRecvDetailID,0) as YarnRecvDetailID,isnull(YRD.VehicleNo,'N/A') as VehicleNo, YPM.POID,CT.ContractType,isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            'str &= " PT.PaymentTerm  ,isnull(FL.FactoryLocationID,'0') as FactoryLocationID,isnull(YRD.RecvQtyinBag,'0') as RecvQtyinBag,B.BlendName as Composition,YDB.YarnCount,YPM.Mill,YPD.Quantity as ContractQTY"
            'str &= " from YarnPurchaseContractMaster YPM"
            'str &= " join YarnPurchaseContractDetail YPD on YPD.POID=YPM.POID"
            'str &= " join ContractType CT on CT.ContractTypeID=YPM.ContractTypeID"
            'str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPM.JobOrderID"
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPM.SupplierDatabaseId"
            'str &= " join PaymentTerm PT on PT.PaymentTermID=YPM.PaymentTermID"
            'str &= " left join YarnRecvDetail YRD on YRD.YarnPurchaseContractDetailID=YPD.YarnPurchaseContractDetailID"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.FactoryLocationID"
            'str &= "   join BlendDropdown B on B.BlendID=YPD.BlendID"
            'str &= " join YarnDatabase YDB on YDB.YarnDatabaseID=YPD.YarnDatabaseID"
            'str &= " where YPM.POID=" & POID

            str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,(Select distinct Itemname from ItemProduct I where I.ItemID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
            str &= " ,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1 and POM.POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeliveryDate(ByVal ProcessOrderDtlID As Long, ByVal ProcessOrderMstID As Long, ByVal SupplierID As Long) As DataTable
            Dim str As String

            str = " select * from ProcessOrderDtl "
            str &= " where ProcessOrderDtlID='" & ProcessOrderDtlID & "' AND ProcessOrderMstID='" & ProcessOrderMstID & "'  and AccountPayablePartyId='" & SupplierID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPODataNew(ByVal POID As Long, ByVal PartyId As Long) As DataTable
            Dim str As String
            'str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            'str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            'str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            'str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            'str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            'str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            'str &= " ,(Select distinct Itemname from ItemProduct I where I.ItemID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
            'str &= " ,YPD.Rate as  PORate from POMaster POM"
            'str &= " join PODetail YPD on YPD.POID=POM.POID"
            'str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            'str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            'str &= " where  POM.CEOApproval=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID=" & POID

            '''new Query For Safa

            str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,(Select distinct Accessoriesname from Accessories I where I.AccessoriesID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
            str &= " ,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPODataNewForStyleForAcc(ByVal POID As Long, ByVal PartyId As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            'str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            'str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            'str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            'str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            'str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            'str &= " ,(Select distinct Itemname from ItemProduct I where I.ItemID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
            'str &= " ,YPD.Rate as  PORate from POMaster POM"
            'str &= " join PODetail YPD on YPD.POID=POM.POID"
            'str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            'str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            'str &= " where  POM.CEOApproval=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID=" & POID

            '''new Query For Safa

            str = "     select YPD.Style , YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,"
            str &= " SD.SupplierName, isnull(FL.FactoryLocationID,'0') as FactoryLocationID, isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,"
            str &= " YPD.Quantity as POQTY, (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty ,"
            str &= " isnull((Select distinct Accessoriesname from Accessories I where I.AccessoriesID= YPD.ItemID)  "
            str &= " /*(Select distinct Fabricweave from FabricDatabase I where I.FabricDatabaseID= YPD.ItemID)*/,'N/A') as Itemname ,"
            str &= " YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM join PODetail YPD on YPD.POID=POM.POID "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID "
            str &= " where  POM.CEOApproval=1 and POM.FabricPOrder=0 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID='" & POID & "'and YPD.ItemID='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPODataNewForStyleForFabric(ByVal POID As Long, ByVal PartyId As Long, ByVal ItemId As Long) As DataTable
            Dim str As String
            'str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            'str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            'str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            'str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            'str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            'str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            'str &= " ,(Select distinct Itemname from ItemProduct I where I.ItemID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
            'str &= " ,YPD.Rate as  PORate from POMaster POM"
            'str &= " join PODetail YPD on YPD.POID=POM.POID"
            'str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            'str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            'str &= " where  POM.CEOApproval=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID=" & POID

            '''new Query For Safa

            str = "    select YPD.Style , YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,"
            str &= " SD.SupplierName, isnull(FL.FactoryLocationID,'0') as FactoryLocationID, isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,"
            str &= " YPD.Quantity as POQTY, (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty ,"
            str &= " isnull(/*(Select distinct Accessoriesname from Accessories I where I.AccessoriesID= YPD.ItemID) ,*/ "
            str &= " (Select distinct Fabricweave from FabricDatabase I where I.FabricDatabaseID= YPD.ItemID),'N/A') as Itemname ,"
            str &= " YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM join PODetail YPD on YPD.POID=POM.POID "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID "
            str &= " where  POM.CEOApproval=1 and POM.FabricPOrder=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID='" & POID & "'and YPD.ItemID='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPODataNewForStyleNEW(ByVal POID As Long, ByVal PartyId As Long) As DataTable
            Dim str As String


            '''new Query For Safa

            str = "  select YPD.Style , YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,isnull((Select distinct Accessoriesname from Accessories I where I.AccessoriesID= YPD.ItemID)"
            str &= "  ,(Select distinct Fabricweave from FabricDatabase I where I.FabricDatabaseID= YPD.ItemID)) as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1 and YPD.AccountpayablePartyid='" & PartyId & "'and POM.POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATA(ByVal ProcessOrderMstID As Long, ByVal Supplierid As Long, ByVal Itemid As Long)
            Dim str As String
            'str = "  select YPD.Style ,isnull(YRD.ReturnQty,0) as ReturnQtyy, YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            'str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            'str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            'str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            'str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            'str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            'str &= " ,  IMST.ItemName as Itemname"
            'str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            'str &= " join PODetail YPD on YPD.POID=POM.POID"
            'str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            'str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            'str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            'str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "'"

            str = "   select YPD.Style ,isnull(YRD.ReturnQty,0) as ReturnQtyy, YPD.ItemID,YPD.ProcessOrderDtlID,"
            str &= " isnull(YRD.POProcessRecvDetailID,0) as POProcessRecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.ProcessOrderMstID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,  IMST.ItemName as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate,IMST.ItemCodee as ItemCodee from ProcessOrderMst POM"
            str &= " join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=POM.ProcessOrderMstID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ProcessItemNameID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join POProcessRecvDetail YRD on YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1  and POM.ProcessOrderMstID='" & ProcessOrderMstID & "'  "
            str &= " and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ProcessItemNameId = '" & Itemid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANewOnEdit(ByVal ProcessOrderMstID As Long, ByVal Supplierid As Long, ByVal ProcessOrderDtlID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "   select YPD.Style ,"
            str &= " (isnull((Select Sum(YRD.ReturnQty) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as ReturnQtyy,"
            str &= " YPD.ItemID,YPD.ProcessOrderDtlID,  '0' as POProcessRecvDetailID, 'N/A' as VehicleNo,"
            str &= " POM.ProcessOrderMstID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "    '0' as FactoryLocationID,     "
            str &= " (isnull((Select Sum(YRD.RecvQuantity) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as RecvQtyinBag,"
            str &= " YPD.Quantity as POQTY, "
            str &= " (isnull(YPD.Quantity ,'0')- (isnull((Select Sum(YRD.RecvQuantity)"
            str &= " from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0')) ) as RemainingQty ,"
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,IMST.ItemCodee as ItemCodee "
            str &= "  from ProcessOrderMst POM "
            str &= " join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=POM.ProcessOrderMstID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ProcessItemNameID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= "   left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " -- left join POProcessRecvDetail YRD on YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID"
            'str &= "   -- left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID "

            str &= " where  POM.CEOApproval=1  and POM.ProcessOrderMstID='" & ProcessOrderMstID & "'  "
            str &= " and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ProcessItemNameId = '" & Itemid & "' and YPD.ProcessOrderDtlID='" & ProcessOrderDtlID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANewForProcessonEdit(ByVal ProcessOrderMstID As Long, ByVal Supplierid As Long, ByVal ProcessOrderDtlID As Long, ByVal POProcessRecvMasterID As Long)
            Dim str As String
            str = "    select YPD.Style ,'N/A' as VehicleNo,'0' as FactoryLocationID, IMST.ItemCodee as ItemCodee,"
            str &= "  YPD.ItemID,YPD.ProcessOrderDtlID,"
            str &= "  POM.ProcessOrderMstID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= "  YPD.Quantity as POQTY,"
            str &= "  (isnull((Select Sum(YRD.ReturnQty) from POProcessRecvDetail YRD  where  "
            str &= "  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as ReturnQtyy"
            str &= "  ,'0' AS  POProcessRecvDetailID"
            str &= "  ,(isnull(YPD.Quantity ,'0')- (isnull((Select Sum(YRD.RecvQuantity)"
            str &= "  from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0')) ) as RemainingQty ,"
            str &= "  (isnull((Select Sum(YRD.RecvQuantity) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID="
            str &= "  YPD.ProcessOrderDtlID),'0'))as RecvQtyinBag"
            str &= "   from ProcessOrderMst POM "
            str &= "  join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=POM.ProcessOrderMstID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= "  join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= "  left join JobOrderDatabase JO on JO.JobOrderID=YPD.SRNoID  "
            str &= "   join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= "   Join POProcessRecvMaster POMS on POMS.ProcessOrderMstID=POM.ProcessOrderMstID"
            str &= " where  POM.CEOApproval=1  and POM.ProcessOrderMstID='" & ProcessOrderMstID & "'  "
            str &= " and YPD.AccountPayablePartyId='" & Supplierid & "' AND  YPD.ProcessOrderDtlID='" & ProcessOrderDtlID & "' AND POMS.POProcessRecvMasterID='" & POProcessRecvMasterID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANewForProcess(ByVal ProcessOrderMstID As Long, ByVal Supplierid As Long, ByVal ProcessOrderDtlID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "    select YPD.Style ,'N/A' as VehicleNo,'0' as FactoryLocationID, IMST.ItemName as ItemName,"
            str &= "  YPD.ItemID,YPD.ProcessOrderDtlID,"
            str &= "  POM.ProcessOrderMstID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= "  YPD.Quantity as POQTY,"
            str &= "  (isnull((Select Sum(YRD.ReturnQty) from POProcessRecvDetail YRD  where  "
            str &= "  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as ReturnQtyy"
            str &= "  ,'0' AS  POProcessRecvDetailID"
            str &= "  ,(isnull(YPD.Quantity ,'0')- (isnull((Select Sum(YRD.RecvQuantity)"
            str &= "  from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0')) ) as RemainingQty ,"
            str &= "  (isnull((Select Sum(YRD.RecvQuantity) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID="
            str &= "  YPD.ProcessOrderDtlID),'0'))as RecvQtyinBag"
            str &= "   from ProcessOrderMst POM "
            str &= "  join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=POM.ProcessOrderMstID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= "  join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= "  left join JobOrderDatabase JO on JO.JobOrderID=YPD.SRNoID  "
            str &= "   join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.ProcessOrderMstID='" & ProcessOrderMstID & "'  "
            str &= " and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ProcessItemNameId = '" & Itemid & "' and YPD.ProcessOrderDtlID='" & ProcessOrderDtlID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew(ByVal ProcessOrderMstID As Long, ByVal Supplierid As Long, ByVal ProcessOrderDtlID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "   select YPD.Style ,"
            'str &= " --isnull(YRD.ReturnQty,0) as ReturnQtyy,"
            str &= " (isnull((Select Sum(YRD.ReturnQty) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as ReturnQtyy,"
            str &= " YPD.ItemID,YPD.ProcessOrderDtlID,  '0' as POProcessRecvDetailID, 'N/A' as VehicleNo,"
            str &= " POM.ProcessOrderMstID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "    '0' as FactoryLocationID,     "
            str &= " (isnull((Select Sum(YRD.RecvQuantity) from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0'))as RecvQtyinBag,"
            'str &= " -- isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,"
            str &= " YPD.Quantity as POQTY, "
            'str &= " --(isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty ,"
            str &= " (isnull(YPD.Quantity ,'0')- (isnull((Select Sum(YRD.RecvQuantity)"
            str &= " from POProcessRecvDetail YRD  where  YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID),'0')) ) as RemainingQty ,"
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,IMST.ItemCodee as ItemCodee "
            str &= "  from ProcessOrderMst POM "
            str &= " join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=POM.ProcessOrderMstID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ProcessItemNameID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= "   left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            'str &= " -- left join POProcessRecvDetail YRD on YRD.ProcessOrderDtlID=YPD.ProcessOrderDtlID"
            'str &= "   -- left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID "

            str &= " where  POM.CEOApproval=1  and POM.ProcessOrderMstID='" & ProcessOrderMstID & "'  "
            str &= " and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ProcessItemNameId = '" & Itemid & "' and YPD.ProcessOrderDtlID='" & ProcessOrderDtlID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetGridDataOnEdit(ByVal ProcessMstID As Long)
            Dim str As String
            str = " select pm.ProcessOrderMstID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0') as RecvQtyinBag, "
            str &= " (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0')) as RemainingQty,YPD.Quality as Quality, "
            str &= " YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy"
            str &= " ,isnull(loc.LocationID ,'0') as FactoryLocationID, isnull(prd.VehicleNo,'N/A') as VehicleNo,"
            str &= "  isnull(prd.LotNo ,'0') as LotNo,  isnull(prd.NoOfRoll ,'0') as NoOfRoll, * "
            str &= " from POProcessRecvMaster pm "
            str &= " join POProcessRecvDetail prd on prd.POProcessRecvMasterID =pm.POProcessRecvMasterID   "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID   "
            str &= " join  ProcessOrderMst pomm on pomm.ProcessOrderMstID =pm.ProcessOrderMstID  "
            str &= "  join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join ProcessOrderDtl YPD on  YPD.ProcessOrderDtlID =Prd.ProcessOrderDtlID  "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join Location loc on loc.LocationID = pm.LocationID  "
            str &= " where pm.POProcessRecvMasterID='" & ProcessMstID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPODataNewForStyleNEWwwwwwwwwww(ByVal POID As Long) As DataTable
            Dim str As String


            '''new Query For Safa

            str = "  select YPD.Style , YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,isnull((Select distinct Accessoriesname from Accessories I where I.AccessoriesID= YPD.ItemID)"
            str &= "  ,(Select distinct Fabricweave from FabricDatabase I where I.FabricDatabaseID= YPD.ItemID)) as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1 and  POM.FABRICPORDER=0 and POM.POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetYarnReceivingOnEdit(ByVal YarnRecvMasterID As Long) As DataTable
            Dim str As String
            str = "   select YRM.GatePassNo,YRM.PartyDCNo,YRM.InformAccountsDept,YRM.InformMerchandiserHead,YRM.BatchNo, convert(varchar,YRM.PORecvDate,103) as PORecvDate, YRM.SupplierID as SupplierDatabaseId ,B.BlendID,JO.JobOrderID,YRM.YarnRecvMasterID,YPD.YarnPurchaseContractDetailID,YRMD.YarnRecvDetailID,"
            str &= " YRMD.VehicleNo as VehicleNo, YPM.POID,CT.ContractType,Jo.JobOrderNo,SD.SupplierName,"
            str &= " PT.PaymentTerm  ,FL.FactoryLocationID,YRMD.RecvQtyinBag ,B.BlendName as Composition,YDB.YarnCount,YPM.Mill,YPD.Quantity as ContractQTY"
            str &= " from YarnRecvMaster YRM "
            str &= " join YarnRecvDetail YRMD on YRMD.YarnRecvMasterID=YRM.YarnRecvMasterID"
            str &= " join YarnPurchaseContractMaster YPM on YPM.POID=YRM.POID"
            str &= " join YarnPurchaseContractDetail YPD on YPD.POID=YRM.POID and YRMD.YarnPurchaseContractDetailID=YPD.YarnPurchaseContractDetailID"
            str &= " join ContractType CT on CT.ContractTypeID=YPM.ContractTypeID"
            str &= " join JobOrderDatabase JO on JO.JobOrderID=YPM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPM.SupplierDatabaseId"
            str &= " join PaymentTerm PT on PT.PaymentTermID=YPM.PaymentTermID"
            str &= " join FactoryLocation FL on FL.FactoryLocationID=YRMD.FactoryLocationID"
            str &= " join BlendDropdown B on B.BlendID=YPD.BlendID"
            str &= " join YarnDatabase YDB on YDB.YarnDatabaseID=YPD.YarnDatabaseID"
            str &= " where YRM.YarnRecvMasterID  =" & YarnRecvMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetYarnReceivingOnEditNewNew(ByVal POProcessRecMstID As Long) As DataTable
            Dim str As String
            str = " select pm.ProcessOrderMstID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0') as RecvQtyinBag, "
            str &= " (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0')) as RemainingQty,YPD.Quality as Quality,"
            str &= " YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy,isnull(loc.LocationID ,'0') as FactoryLocationID,"
            str &= " isnull(prd.VehicleNo,'N/A') as VehicleNo, isnull(prd.LotNo ,'0') as LotNo, "
            str &= " isnull(prd.NoOfRoll ,'0') as NoOfRoll, * "
            str &= " from POProcessRecvMaster pm "
            str &= " join POProcessRecvDetail prd on prd.POProcessRecvMasterID =pm.POProcessRecvMasterID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID  "
            str &= " join  ProcessOrderMst pomm on pomm.ProcessOrderMstID =pm.ProcessOrderMstID  "
            str &= " join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join ProcessOrderDtl YPD on YPD.ProcessOrderMstID=pomm.ProcessOrderMstID and "
            str &= " YPD.ProcessOrderDtlId = prd.ProcessOrderDtlId"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join Location loc on loc.LocationID = pm.LocationID"
            str &= " WHERE pm.POProcessRecvMasterID = '" & POProcessRecMstID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetYarnReceivingOnEditNew(ByVal POProcessRecMstID As Long) As DataTable
            Dim str As String
            str = " select *,'N/A' as ContractType  from POProcessRecvMaster ppRcvM "
            str &= " JOIN POProcessRecvDetail ppRcvD ON ppRcvD.POProcessRecvMasterID = ppRcvM.POProcessRecvMasterID "
            str &= " WHERE ppRcvD.POProcessRecvMasterID = '" & POProcessRecMstID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function BindOfficeLocations() As DataTable
            Dim str As String
            str = " select * from FactoryLocation"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONONew() As DataTable
            Dim str As String
            str = "select (PONo+' '+'('+JobOrderNo +')') as PONo ,* from POMaster POM join JobOrderdatabase JOD on POM.Joborderid=JOD.Joborderid where   CEOApproval=1 and FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONO() As DataTable
            Dim str As String
            str = " select * from POMaster where   CEOApproval=1 and FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOFabric() As DataTable
            Dim str As String
            str = " select * from POMaster where   CEOApproval=1 and FabricPOrder=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOFabricNew() As DataTable
            Dim str As String
            str = " select (PONo+' '+'('+JobOrderNo+')') as PONo ,* from POMaster POM join JobOrderdatabase JOD on POM.Joborderid=JOD.Joborderid where   CEOApproval=1 and FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindFabricItem() As DataTable
            Dim str As String

            str = " select distinct POD.ItemId,a.FabricWeave from POMaster POM join PODetail POD on POM.POID=POD.POID JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ItemId"
            str &= " where CEOApproval=1 and FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemFBDP() As DataTable
            Dim str As String

            'str = " select distinct POD.ItemId,IMST.ItemName from POMaster POM"
            'str &= " join PODetail POD on POM.POID=POD.POID "
            'str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            'str &= "    where FabricPOrder = 1 "

            str = "  select distinct POD.ProcessItemNameId,IMST.ItemName from ProcessOrderMst POM"
            str &= "  join ProcessOrderDtl POD on POM.ProcessOrderMstID=POD.ProcessOrderMstID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            str &= "  where FabricPOrder = 1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemACCDP() As DataTable
            Dim str As String

            str = " select distinct POD.ItemId,IMST.ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where FabricPOrder = 0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindFabricNEW(ByVal POID As Long) As DataTable
            Dim str As String
            str = "  select Distinct FB.FabricDatabaseId,FB.FabricWeave from POMaster PO join  PODetail POM on PO.POID=POM.POID"
            str &= " join FabricDatabase FB on POM.ItemId=FB.FabricDatabaseId  where  PO.CEOApproval=1 and PO.FabricPOrder=1 and POM.AccountPayablePArtyID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindAccessoriesItem() As DataTable
            Dim str As String

            str = " select distinct POD.ItemId,a.AccessoriesName from POMaster POM join PODetail POD on POM.POID=POD.POID JOIN Accessories a ON a.AccessoriesId=POD.ItemId"
            str &= " where CEOApproval = 1 and FabricPOrder=0 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindAccessoriesItemNEW(ByVal POID As Long) As DataTable
            Dim str As String

            str = " select distinct a.AccessoriesID,a.AccessoriesName from POMaster POM join PODetail POD on POM.POID=POD.POID JOIN Accessories a ON a.AccessoriesId=POD.ItemId"
            str &= " where CEOApproval = 1 And FabricPOrder = 0 and POD.AccountPayablePArtyID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindAccessoriesItemNEWW() As DataTable
            Dim str As String

            str = "  select distinct POD.ItemId,a.AccessoriesName,POM.POID from POMaster POM join PODetail POD on POM.POID=POD.POID JOIN Accessories a ON a.AccessoriesId=POD.ItemId "
            str &= " where CEOApproval = 1 and FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplier(ByVal Supplierid As Long) As DataTable
            Dim str As String
            str = " select distinct PO.PONO,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID where AccountpayablePartyid='" & Supplierid & "' and   PO.CEOApproval=1 and FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyle(ByVal Supplierid As Long) As DataTable
            Dim str As String
            str = " select distinct POD.Style,PO.PONO,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID where AccountpayablePartyid='" & Supplierid & "' and   PO.CEOApproval=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleee(ByVal Supplierid As Long) As DataTable
            Dim str As String
            str = "  select distinct POD.Style,PO.PONO,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID  where PO.FabricPOrder=0 and PO.POID='" & Supplierid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleeeJo(ByVal Supplierid As Long) As DataTable
            Dim str As String
            str = "  select distinct POD.Style,PO.PONO,PO.POID,(PONo+' '+'     ('+isnull(JobOrderNo,'Open')+')') as POJO from POMaster PO join PODetail POD on POD.POID=PO.POID  left join JobOrderdatabase jb on jb.Joborderid =po.JoborderID  where PO.FabricPOrder=0 and PO.POID='" & Supplierid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOSupNItemWiseDP(ByVal Supplierid As Long, ByVal IMSItemId As Long)

            Dim str As String
            'str = " select distinct PO.PONO,PO.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            'str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            'str &= " left join JobOrderdatabase jb on jb.Joborderid =po.JoborderID  "
            'str &= " where POD.AccountPayablePartyId='" & Supplierid & "' AND POD.ItemId = '" & IMSItemId & "'"

            str = "  select distinct PO.PONO,PO.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from ProcessOrderMst PO join ProcessOrderDtl POD on POD.ProcessOrderMstID=PO.ProcessOrderMstID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =po.JoborderID  "
            str &= "  where POD.AccountPayablePartyId='" & Supplierid & "' AND POD.ProcessItemNameId = '" & IMSItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function BindPONOBySupplierwithStylee(ByVal POID As Long) As DataTable
            Dim str As String
            str = "  select distinct POD.Style,PO.PONO,PO.POID from POMaster PO  join PODetail POD on POD.POID=PO.POID where PO.POID='" & POID & "' and   PO.CEOApproval=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleNewFORFabric(ByVal POID As Long) As DataTable
            Dim str As String
            str = "select distinct POD.Style,PO.PONo,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " join FabricDatabase FB on FB.FabricDatabaseid=POD.ItemId"
            str &= " where    PO.CEOApproval=1 and PO.FabricPOrder=1 and  ItemId='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleNewFORFabricJO(ByVal POID As Long) As DataTable 'ByVal POID As Long
            Dim str As String
            str = " select distinct POD.Style,PO.PONo,PO.POID,jb.JoborderNo,"
            str &= "(PONo+' '+'     ('+isnull(JobOrderNo,'Open')+')') as POJO from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " join FabricDatabase FB on FB.FabricDatabaseid=POD.ItemId"
            str &= " left join JobOrderdatabase jb on jb.Joborderid =po.JoborderID "
            str &= " where PO.CEOApproval=1 and PO.FabricPOrder=1 "
            str &= " and  ItemId='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleNew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select distinct POD.Style,PO.PONO,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID   "
            str &= " join Accessories FB on FB.Accessoriesid=POD.ItemId "
            str &= " where    PO.CEOApproval=1 and PO.FabricPOrder=0 and ItemId='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPONOBySupplierwithStyleNewJO(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select distinct POD.Style,PO.PONO,PO.POID,(PONo+' '+'     ('+isnull(JobOrderNo,'Open')+')') as POJO from POMaster PO join PODetail POD on POD.POID=PO.POID   "
            str &= " join Accessories FB on FB.Accessoriesid=POD.ItemId "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =po.JoborderID "
            str &= " where    PO.CEOApproval=1 and PO.FabricPOrder=0 and ItemId='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPO() As DataTable
            Dim str As String
            'str = " select Distinct SDB.SupplierName, SDB.SupplierDatabaseId from SupplierDatabase SDB"
            'str &= " join  POMaster POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId"

            str = " select Distinct SDB.SupplierName, SDB.SupplierDatabaseId from SupplierDatabase SDB"
            str &= " join  POdetail POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPOO(ByVal IMSItemId As Long) As DataTable

            Dim str As String
            ' str = " select * from POmaster POM join POdetail POD on POD.POID=POM.POID  where POM.CEOApproval = 1  And POM.IMSItemId = '" & IMSItemId & "'"

            'str = " select distinct SupplierDatabaseid,SupplierName from POmaster POM join POdetail POD on POD.POID=POM.POID  "
            'str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            'str &= " where POM.CEOApproval = 1  And POD.ItemId = '" & IMSItemId & "'"
            str = "   select distinct SupplierDatabaseid,SupplierName from ProcessOrderMst POM"
            str &= " join ProcessOrderDtl POD on POD.ProcessOrderMstID=POM.ProcessOrderMstID  "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1  And POD.ProcessItemNameId = '" & IMSItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPONew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select Distinct SDB.SupplierName, SDB.SupplierDatabaseId from SupplierDatabase SDB"
            str &= " join  PODetail POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId join POMaster PO on PO.POID=POM.POID where PO.POID=' " & POID & "  ' and PO.CEOApproval=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPONewWWWw() As DataTable
            Dim str As String
            str = " select *, SDB.SupplierName, POM.AccountpayablePartyid from SupplierDatabase SDB"
            str &= " join  PODetail POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId join POMaster PO on PO.POID=POM.POID where  PO.CEOApproval=1 and PO.FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForFabricRecPONewWWWw() As DataTable
            Dim str As String
            str = " select distinct SDB.SupplierName, POM.AccountpayablePartyid from SupplierDatabase SDB join  PODetail POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId "
            str &= " join POMaster PO on PO.POID=POM.POID where  PO.CEOApproval=1 and PO.FabricPOrder=1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal YarnRecvMasterID As Long) As DataTable
            Dim str As String
            str = " Select * from YarnRecvMaster where YarnRecvMasterID=" & YarnRecvMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            '  str = " Select * from YarnRecvMaster  "
            str = " Select * ,(select Sum(YarnContractQtyinBag) from YarnRecvDetail YRD where YRD.YarnRecvMasterID=YM.YarnRecvMasterID) as ContractQTY ,"
            str &= " (select Sum(RecvQtyinBag) from YarnRecvDetail YRD where YRD.YarnRecvMasterID=YM.YarnRecvMasterID) as RecvQtyinBag from YarnRecvMaster YM"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPORECforView()
            Dim Str As String
            'Str = " Select *, convert(varchar,PO.PORecvDate,103) Date,(Select Sum(POQuantity) "
            'Str &= " from PORecvDetail PRD where PRD.PORecvMasterID=PO.PORecvMasterID ) as POQty ,"
            'Str &= " (select Sum(RecvQuantity) from PORecvDetail PRD "
            'Str &= " where PRD.PORecvMasterID=PO.PORecvMasterID ) as RecvQty   from PORecvMaster PO"
            'Str &= " join POMaster POM  on POM.POID=PO.POID"

            'Str = " select Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,IP.ItemName,"
            'Str &= " isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
            'Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            'Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
            'Str &= " from POMaster POM "
            'Str &= " join PODetail POD on POd.POId=POM.POId"
            'Str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
            'Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
            'Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"

            ''new Query By safa
            Str = "  select *, Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , "
            Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,isnull(IP.Accessoriesname,a.fabricweave) as ItemName,"
            Str &= " isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
            Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
            Str &= " join PODetail POD on POd.POId=POM.POId  "
            Str &= " left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID "
            Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(Str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewNew()
            Dim Str As String

            'Str = " select *,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            'Str &= " isnull(IP.Accessoriesname,'N/A') as ItemName, isnull(POD.Quantity,0) as POQTY,"
            'Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            'Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            'Str &= " from POMaster POM   join PODetail POD on POd.POId=POM.POId   left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            'Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            'Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            'Str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=0  "


            Str = "   select Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            Str &= " ,* from POMaster POM   join PODetail POD on POd.POId=POM.POId  "
            Str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId where POM.FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(Str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewForSearch(ByVal ItemName As String)
            Dim Str As String
            Str = "  select *, Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , "
            Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,isnull(IP.Accessoriesname,a.fabricweave) as ItemName,"
            Str &= " isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
            Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
            Str &= " join PODetail POD on POd.POId=POM.POId  "
            Str &= " left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID "
            Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=0 and ip.AccessoriesName='" & ItemName & "' "
            Try
                Return MyBase.GetDataTable(Str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetMonthWiseViewForItem(ByVal Style As String, ByVal Item As String, ByVal Party As String)
            Dim Str As String

            ''new Query By Bilal Awan
            If Style <> "" And Item <> "" And Party <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' and sd.SupplierName='" & Party & "'"
            ElseIf Style <> "" And Item <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' "
            ElseIf Style <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "'  "
            ElseIf Style = "" And Item = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and sd.SupplierName='" & Party & "'"
            ElseIf Style = "" And Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and ip.AccessoriesName='" & Item & "' "
            ElseIf Item = "" And Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "' "
            ElseIf Style = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and ip.AccessoriesName='" & Item & "' and sd.SupplierName='" & Party & "' "
            ElseIf Item = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "' and sd.SupplierName='" & Party & "' "
            ElseIf Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' "
            Else
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=0"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMonthWiseViewForFabric(ByVal Style As String, ByVal Item As String, ByVal Party As String)
            Dim Str As String

            ''new Query By Bilal Awan
            If Style <> "" And Item <> "" And Party <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' and sd.SupplierName='" & Party & "'"
            ElseIf Style <> "" And Item <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' "
            ElseIf Style <> "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "'  "
            ElseIf Style = "" And Item = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and sd.SupplierName='" & Party & "'"
            ElseIf Style = "" And Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and ip.AccessoriesName='" & Item & "' "
            ElseIf Item = "" And Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "' "
            ElseIf Style = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and ip.AccessoriesName='" & Item & "' and sd.SupplierName='" & Party & "' "
            ElseIf Item = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "' and sd.SupplierName='" & Party & "' "
            ElseIf Party = "" Then
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1 and POD.Style='" & Style & "' and ip.AccessoriesName='" & Item & "' "
            Else
                Str = "   select * ,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID , isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
                Str &= " isnull(IP.Accessoriesname,a.fabricweave) as ItemName, isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
                Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
                Str &= " join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
                Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
                Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID "
                Str &= " where POM.FabricPOrder=1"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewForprocessOrderForItemVise(ByVal ItemName As String)
            Dim Str As String
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert"
            Str &= " (varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= " from POProcessRecvMaster Mst"
            Str &= " join POProcessRecvDetail Dtl on Dtl.POProcessRecvMasterID =mst.POProcessRecvMasterID "
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID =MST.ProcessOrderMstID "
            Str &= " JOIN ProcessOrderDtl POD on POD.ProcessOrderMstID =POM.ProcessOrderMstID and POD.ProcessOrderDtlId =DTL.ProcessOrderDtlId "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            Str &= " WHERE POM.FabricPOrder = 1 and IMST.ItemName='" & ItemName & "'"
            Str &= " order by  Mst.POProcessRecvMasterID  desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewForprocessOrderForStyleVise(ByVal Style As String)
            Dim Str As String
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert"
            Str &= " (varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= " from POProcessRecvMaster Mst"
            Str &= " join POProcessRecvDetail Dtl on Dtl.POProcessRecvMasterID =mst.POProcessRecvMasterID "
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID =MST.ProcessOrderMstID "
            Str &= " JOIN ProcessOrderDtl POD on POD.ProcessOrderMstID =POM.ProcessOrderMstID and POD.ProcessOrderDtlId =DTL.ProcessOrderDtlId "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            Str &= " WHERE POM.FabricPOrder = 1 and POD.Style='" & Style & "'"
            Str &= " order by  Mst.POProcessRecvMasterID  desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewForprocessOrderForsUPPLIERVise(ByVal PartyAccount As String)
            Dim Str As String
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert"
            Str &= " (varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= " from POProcessRecvMaster Mst"
            Str &= " join POProcessRecvDetail Dtl on Dtl.POProcessRecvMasterID =mst.POProcessRecvMasterID "
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID =MST.ProcessOrderMstID "
            Str &= " JOIN ProcessOrderDtl POD on POD.ProcessOrderMstID =POM.ProcessOrderMstID and POD.ProcessOrderDtlId =DTL.ProcessOrderDtlId "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            Str &= " WHERE POM.FabricPOrder = 1 and POD.PartyAccount='" & PartyAccount & "'"
            Str &= " order by  Mst.POProcessRecvMasterID  desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewForprocessOrderForPONOVise(ByVal PONO As String)
            Dim Str As String
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert"
            Str &= " (varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= " from POProcessRecvMaster Mst"
            Str &= " join POProcessRecvDetail Dtl on Dtl.POProcessRecvMasterID =mst.POProcessRecvMasterID "
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID =MST.ProcessOrderMstID "
            Str &= " JOIN ProcessOrderDtl POD on POD.ProcessOrderMstID =POM.ProcessOrderMstID and POD.ProcessOrderDtlId =DTL.ProcessOrderDtlId "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            Str &= " WHERE POM.FabricPOrder = 1 and POM.PONO='" & PONO & "'"
            Str &= " order by  Mst.POProcessRecvMasterID  desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewForprocessOrder()
            Dim Str As String
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert"
            Str &= " (varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= " from POProcessRecvMaster Mst"
            Str &= " join POProcessRecvDetail Dtl on Dtl.POProcessRecvMasterID =mst.POProcessRecvMasterID "
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID =MST.ProcessOrderMstID "
            Str &= " JOIN ProcessOrderDtl POD on POD.ProcessOrderMstID =POM.ProcessOrderMstID and POD.ProcessOrderDtlId =DTL.ProcessOrderDtlId "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            Str &= " WHERE POM.FabricPOrder = 1"
            Str &= " order by  Mst.POProcessRecvMasterID  desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewProcessCodeViseItemVise(ByVal itemCodee As String)
            Dim Str As String


            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1 and IMST.itemCodee='" & itemCodee & "'"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewStyleProcessVise(ByVal Style As String)
            Dim Str As String


            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1 and POD.Style='" & Style & "'"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusNo(ByVal PONO As String)
            Dim Str As String


            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1 and POM.PONO='" & PONO & "'"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewSuppliersVise(ByVal PartyAccount As String)
            Dim Str As String


            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1 and POD.PartyAccount='" & PartyAccount & "'"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewProcessNoVise(ByVal PONO As String)
            Dim Str As String


            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1 and POM.PONO='" & PONO & "'"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNew()
            Dim Str As String
          

            Str = "   select POM.ProcessOrderMstID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= " convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp where "
            Str &= " pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0) )"
            Str &= " ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= " ,isnull((select SUM(pp.RecvQuantity) from POProcessRecvDetail pp "
            Str &= " where pp.ProcessOrderDtlID = POD.ProcessOrderDtlID ),0)"
            Str &= " as RecvQuantity,IMST.ItemCodee as CodeEntry"
            Str &= " from ProcessOrderMst POM  "
            Str &= " join ProcessOrderDtl POD on POd.ProcessOrderMstId=POM.ProcessOrderMstId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameID    "
            Str &= "      where POM.FabricPOrder = 1"
            Str &= " group by POM.ProcessOrderMstID ,pom.PONo ,pod.ProcessOrderDtlId ,IMST.ItemName,pod.DeliveryDate"
            Str &= " ,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName,IMST.ItemCodee"
            Str &= "  order by POM.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabric()
            Dim Str As String
            'Str = " Select *, convert(varchar,PO.PORecvDate,103) Date,(Select Sum(POQuantity) "
            'Str &= " from PORecvDetail PRD where PRD.PORecvMasterID=PO.PORecvMasterID ) as POQty ,"
            'Str &= " (select Sum(RecvQuantity) from PORecvDetail PRD "
            'Str &= " where PRD.PORecvMasterID=PO.PORecvMasterID ) as RecvQty   from PORecvMaster PO"
            'Str &= " join POMaster POM  on POM.POID=PO.POID"

            'Str = " select Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,IP.ItemName,"
            'Str &= " isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
            'Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            'Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
            'Str &= " from POMaster POM "
            'Str &= " join PODetail POD on POd.POId=POM.POId"
            'Str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
            'Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
            'Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"

            ''new Query By safa
            'Str = "    select *,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            'Str &= " isnull((a.fabricweave),'N/A') as ItemName, isnull(POD.Quantity,0) as POQTY,"
            'Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            'Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            'Str &= " from POMaster POM   join PODetail POD on POd.POId=POM.POId   left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            'Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            'Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            'Str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=1 "


            'Str = "   select POD.ItemId,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            'Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            'Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            'Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            'Str &= " ,* from POMaster POM   join PODetail POD on POd.POId=POM.POId  "
            'Str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            'Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId where POM.FabricPOrder=1 "


            'Str = "   select POD.ItemId,Sd.SupplierName,POM.ProcessOrderMstID,POD.ProcessOrderDtlID,isnull(PRM.POProcessRecvMasterID,0) as PORecvMasterID ,"
            'Str &= " isnull(PRD.POProcessRecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            'Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            'Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            'Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, "
            'Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            'Str &= " ,* from ProcessOrderMst POM   join ProcessOrderDtl POD on POd.ProcessOrderMstID=POM.ProcessOrderMstID  "
            'Str &= " left join POProcessRecvDetail PRD on PRD.ProcessOrderDtlID= POd.ProcessOrderDtlID  "
            'Str &= " left join POProcessRecvMaster PRM on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID and POM.ProcessOrderMstID=PRM.ProcessOrderMstID  "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId where POM.FabricPOrder=1 "



            Str = "   select POD.ItemId,Sd.SupplierName,POM.ProcessOrderMstID,POD.ProcessOrderDtlID,isnull(PRM.POProcessRecvMasterID,0) as PORecvMasterID ,"
            Str &= " isnull(PRD.POProcessRecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, "
            Str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            Str &= " ,* from ProcessOrderMst POM   join ProcessOrderDtl POD on POd.ProcessOrderMstID=POM.ProcessOrderMstID  "
            Str &= " left join POProcessRecvDetail PRD on PRD.ProcessOrderDtlID= POd.ProcessOrderDtlID  "
            Str &= " left join POProcessRecvMaster PRM on PRM.POProcessRecvMasterID= PRD.POProcessRecvMasterID and POM.ProcessOrderMstID=PRM.ProcessOrderMstID  "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=PRM.fabricid where POM.FabricPOrder=1 "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String

            str = " select Top 1 GatePassNo from POProcessRecvMaster where year(PORecvDate)='" & year & "' order By POProcessRecvMasterID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPOQTY(ByVal POID As Integer)
            Dim str As String

            str = " select isnull(POD.Quantity,0) as POQTY,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
            str &= " from POMaster POM "
            str &= " join PODetail POD on POd.POId=POM.POId"
            str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
            str &= "  where  POM.POId  =" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetRecvQTY(ByVal POID As Integer)
            Dim str As String

            str = " select isnull(POD.Quantity,0) as POQTY,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
            str &= " isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
            str &= " from POMaster POM "
            str &= " join PODetail POD on POd.POId=POM.POId"
            str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
            str &= "  where  POM.POId  =" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetBalanceQTY(ByVal POID As Integer)
            Dim str As String

            str = " select isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
            str &= " from POMaster POM "
            str &= " join PODetail POD on POd.POId=POM.POId"
            str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
            str &= "  where POM.POId  =" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetALLPOFromRecv()
            Dim str As String
            str = " select distinct POM.POId,POM.PONO"
            str &= " from POMaster POM "
            str &= "  join PORecvMaster PRM on POM.POID=PRM.POID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOByFabricItem(ByVal ItemId As Long)
            Dim str As String
            str = " select distinct POM.POID,(PONo+' '+'('+JobOrderNo +')') as PONo ,* from POMaster POM join JobOrderdatabase JOD on POM.Joborderid=JOD.Joborderid "
            str &= " join PODetail POD on POM.POID=POD.POID where CEOApproval = 1 And FabricPOrder = 1 And POD.ItemId = '" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOByItem(ByVal ItemId As Long)
            Dim str As String
            str = " select distinct POM.POID, (PONo+' '+'('+JobOrderNo +')') as PONo ,* from POMaster POM join JobOrderdatabase JOD on POM.Joborderid=JOD.Joborderid "
            str &= " join PODetail POD on POM.POID=POD.POID  where   CEOApproval=1 and FabricPOrder=0 and POD.ItemId='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyFabricWiseForcmbParty()
            Dim str As String
            str = " select  Sd.SupplierName,sd.SupplierDatabaseId from POMaster POM join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            str &= " where POM.FabricPOrder=1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyItemWiseForcmbParty()
            Dim str As String
            str = " select  Sd.SupplierName,Sd.SupplierDatabaseId from POMaster POM   join PODetail POD on POd.POId=POM.POId   "
            str &= " left join Accessories ip on  ip.Accessoriesid=POD.ITEMID left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID "
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId  left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            str &= " where POM.FabricPOrder = 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricWiseForcmbItem()
            Dim str As String
            str = "  select  ip.AccessoriesName,ip.AccessoriesId from POMaster POM join PODetail POD on POd.POId=POM.POId  "
            str &= " left join Accessories ip on  ip.Accessoriesid=POD.ITEMID left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID "
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemItemWiseForcmbItem()
            Dim str As String
            str = "  select  ip.AccessoriesName,ip.AccessoriesId from POMaster POM join PODetail POD on POd.POId=POM.POId  "
            str &= " left join Accessories ip on  ip.Accessoriesid=POD.ITEMID left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID "
            str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            str &= " left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID where POM.FabricPOrder=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFabricWiseForStyle()
            Dim str As String
            str = "  select  POD.POId,POD.Style  from POMaster POM join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            str &= "  where POM.FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleItemWiseForStyle()
            Dim str As String
            str = "  select  POD.POId,POD.Style from POMaster POM join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            str &= "  where POM.FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemAllInfoPORECV(ByVal ItemName As String)
            Dim str As String
            str = "  select *,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,"
            str &= "  POM.PONO,isnull(IP.Accessoriesname,a.fabricweave) as ItemName,isnull(POD.Quantity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
            str &= "  isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty from POMaster POM  "
            str &= "  join PODetail POD on POd.POId=POM.POId left join Accessories ip on  ip.Accessoriesid=POD.ITEMID"
            str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID "
            str &= "  join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId left JOIN FabricDatabase a ON a.FabricDatabaseid=POD.ITEMID"
            str &= "  where ip.AccessoriesName Like '" & ItemName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForInvoiceFromPOReceive() As DataTable
            Dim str As String
            str = " select distinct D.SupplierID ,SD.SupplierName  from PORecvDetailHistory D join SupplierDatabase SD on SD.SupplierDatabaseId =D.SupplierID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindDCNOForInvoiceFromPOReceive(ByVal SupplierID As Long) As DataTable
            Dim str As String
            str = " select distinct D.PORecvMasterID,D.PartyDCNo   from PORecvMaster D join PORecvDetailHistory DD on DD.PORecvMasterID=D.PORecvMasterID  where D.SupplierID = '" & SupplierID & "'" 'and DD.IsCompleted=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPodetailNew(ByVal PORecvMasterID As Long, ByVal SupplierID As Long) As DataTable
            Dim str As String

            str = "   select '0' as POInvoiceDetailID,IT.ItemID,PORD.PartyDCNo,IT.ItemCode,IT.ItemName,"
            str &= " (PORD.RecvQuantity-isnull(PORD.InvoiceQty,0)) as TotalQTY  ,POD.Weight,POD.Rate,"
            str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)) as GrossAmount,"
            str &= " POD.DiscPercent,"
            str &= " ((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as DiscAmount,"
            str &= " (((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate))) as ValExcloudSalesTax,"
            str &= " POD.SalesTaxPercentage,"
            str &= " ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as SalesTaxAmount,"
            str &= " ((((((POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))+ ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))) as NetAmount,"
            str &= " POD.PODetailID,PORD.PORecvDetailTwoID,"
            str &= " PORD.PORecvMasterID,isnull(PORD.InvoiceQty,0) as PreInvoiceQty"
            str &= " from  POMaster POM"
            str &= " join PODetail POD  On POD.POID=POM.POID  "
            str &= " join ItemProduct IT ON IT.ItemID=POD.ItemID "
            str &= " join PORecvDetailTwo PORD on PORD.PODetailID =POD.PoDetailId "
            str &= " and PORD.POID=POM.POID "
            str &= "  where PORD.PORecvMasterID = '" & PORecvMasterID & "'And PORD.SupplierID = '" & SupplierID & "' and PORD.IsCompleted=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function TruncatetbleRcvIsu()
            Dim str As String
            str = " Truncate table TempRecvIssueLedger "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncatetbleRcvIsuFinal()
            Dim str As String
            str = " Truncate table TempRecvIssueLedgerFinal "
            Try
                MyBase.ExecuteNonQuery(str)
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
        Public Function BindSupplierForRecPOONew() As DataTable

            Dim str As String
            str = " select distinct SupplierDatabaseid,SupplierName from ProcessOrderMst POM"
            str &= " join ProcessOrderDtl POD on POD.ProcessOrderMstID=POM.ProcessOrderMstID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOSupNItemWiseDPNew(ByVal Supplierid As Long)

            Dim str As String
            str = "  select distinct PO.PONO,PO.ProcessOrderMstID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from ProcessOrderMst PO join ProcessOrderDtl POD on POD.ProcessOrderMstID=PO.ProcessOrderMstID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.srnoID   "
            str &= "  where POD.AccountPayablePartyId='" & Supplierid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemFBDPNew(ByVal Supplierid As Long, ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String

            str = "  select  POD.ProcessOrderDtlId ,IMST.ItemCodee + '   (' + convert(varchar,POD.DeliveryDate,103) +')' as ItemName from ProcessOrderMst POM"
            str &= " join ProcessOrderDtl POD on POM.ProcessOrderMstID=POD.ProcessOrderMstID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId "
            str &= "  where sd.SupplierDatabaseId  ='" & Supplierid & "' and pom.ProcessOrderMstID ='" & ProcessOrderMstID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemName(ByVal Supplierid As Long, ByVal ProcessOrderMstID As Long) As DataTable
            Dim str As String

            str = "  select distinct IMST.ItemName from ProcessOrderMst POM"
            str &= " join ProcessOrderDtl POD on POM.ProcessOrderMstID=POD.ProcessOrderMstID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId"
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId "
            str &= "  where sd.SupplierDatabaseId  ='" & Supplierid & "' and pom.ProcessOrderMstID ='" & ProcessOrderMstID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

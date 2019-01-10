Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PORecvMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PORecvMaster"
            m_strPrimaryFieldName = "PORecvMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPORecvMasterID As Long
        Private m_dtPORecvDate As Date
        Private m_strGatePassNo As String
        Private m_strPartyDCNo As String
        Private m_lSupplierID As Long
        Private m_lPOID As Long
        Private m_strStyle As String
        Private m_strFabricRecv As String
        Private m_lLocationID As Long
        Private m_lSeasonDatabaseID As Long
        Private m_lJobOrderID As Long
        Private m_strSeasonName As String
        Private m_strSrNoo As String
        Private m_strAuditorStatus As String
        Private m_lAuditorID As Long
        Private m_lUserID As Long
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
        Public Property PORecvMasterID() As Long
            Get
                PORecvMasterID = m_lPORecvMasterID
            End Get
            Set(ByVal Value As Long)
                m_lPORecvMasterID = Value
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
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
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
        Public Property FabricRecv() As String
            Get
                FabricRecv = m_strFabricRecv
            End Get
            Set(ByVal Value As String)
                m_strFabricRecv = Value
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
        Public Function GetAllOrders() As DataTable
            Dim str As String
            str = " select * from JobOrderDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllOrdersPreviousYear(ByVal year As String) As DataTable
            Dim str As String
            str = " select * from JobOrderDatabase where year(creationdate)<'" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllOrdersThisYear(ByVal year As String) As DataTable
            Dim str As String
            str = " select * from JobOrderDatabase where year(creationdate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllTodayStitching(ByVal CreationDate As String) As DataTable
            Dim str As String
            str = " select * from TFAStitching where convert(varchar,CreationDate,103)='" & CreationDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllTodayWash(ByVal CreationDate As String) As DataTable
            Dim str As String
            str = " select * from TFAWashing where convert(varchar,CreationDate,103)='" & CreationDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllTodayDDLReceiving(ByVal CreationDate As String) As DataTable
            Dim str As String
            str = " select * from TFAFinishing where convert(varchar,CreationDate,103)='" & CreationDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllTodayReceveWash(ByVal CreationDate As String) As DataTable
            Dim str As String
            str = " select * from TFAWashingRecv where convert(varchar,CreationDate,103)='" & CreationDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllOrdersThisMonth(ByVal Month As String) As DataTable
            Dim str As String
            str = " select * from JobOrderDatabase where Month(creationdate)='" & Month & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDeliveryDateForAstore(ByVal POID As Long, ByVal SupplierID As Long) As DataTable
            Dim str As String

            str = " select * from PODetail "
            str &= " where  POID='" & POID & "'  and AccountPayablePartyId='" & SupplierID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeliveryDate(ByVal PODetailID As Long, ByVal POID As Long, ByVal SupplierID As Long) As DataTable
            Dim str As String

            str = " select * from PODetail "
            str &= " where PODetailID='" & PODetailID & "' AND POID='" & POID & "'  and AccountPayablePartyId='" & SupplierID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeliveryDateNew(ByVal ItemID As Long, ByVal POID As Long, ByVal SupplierID As Long, ByVal PODetailID As Long) As DataTable
            Dim str As String

            str = " select * from PODetail "
            str &= " where ItemID='" & ItemID & "' AND POID='" & POID & "'  and AccountPayablePartyId='" & SupplierID & "' and PODetailID='" & PODetailID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOIDForReturn(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String
            str = " select * from PORecvMaster"
            str &= "  where PORecvMasterID = '" & PORecvMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckEditDataForReturn(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String
            str = " select * from POReturn"
            str &= "  where PORecvMasterID = '" & PORecvMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckEditDataForReturnEdit(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String
            str = " select PR.ItemId as ItemIdd,* ,PR.POReturnID AS POReturnIDD"
            str &= " ,isnull((SELECT RR.ReturnQty  FROM POReturn RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as PreReturnQty"
            str &= " ,isnull((SELECT sum(RR.RecvQuantity) FROM PORecvDetail RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as RecvQty"
            str &= " ,isnull((SELECT sum(RR.RecvQuantity) FROM PORecvDetail RR where RR.PORecvMasterID  =prm.PORecvMasterID),0)-"
            str &= " isnull((SELECT RR.ReturnQty  FROM POReturn RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as BalanceQty"
            str &= " from POReturn PR"
            str &= " JOIN  PORecvMaster PRM on PRM.PORecvMasterID=PR.PORecvMasterID"
            str &= " join PORecvDetail prd on prd.PORecvMasterID =PRM.PORecvMasterID"
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =PRM.SupplierID   "
            str &= " join  POMaster pomm on pomm.POID =PRM.POID   "
            str &= " join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join PODetail YPD on YPD.POID=pomm.POID and YPD.PoDetailId =prd.PODetailID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            str &= " LEFT JOIN POReturn POR on POR.PORecvMasterID =PRM.PORecvMasterID"
            str &= "  where PR.PORecvMasterID = '" & PORecvMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForReturn(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String



            str = " SELECT YPD.Itemid as ItemidD,*,'0' as POReturnIDD"
            str &= " ,(case when isnull(POR.DCNO,'') ='' then '' else DCNO end ) as DCNOO"
            str &= " ,(case when isnull(POR.ReturnRemarks,'') ='' then '' else DCNO end ) as ReturnRemarkss"
            str &= " ,(case when isnull(POR.ReturnQty,0) ='0' then '0' else POR.ReturnQty end ) as ReturnQtyy"
            str &= " ,isnull((SELECT RR.ReturnQty  FROM POReturn RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as PreReturnQty"
            str &= " ,isnull((SELECT sum(RR.RecvQuantity) FROM PORecvDetail RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as RecvQty"
            str &= " ,isnull((SELECT sum(RR.RecvQuantity) FROM PORecvDetail RR where RR.PORecvMasterID  =prm.PORecvMasterID),0)-"
            str &= " isnull((SELECT RR.ReturnQty  FROM POReturn RR where RR.PORecvMasterID  =prm.PORecvMasterID),0) as BalanceQty"
            str &= " FROM PORecvMaster PRM"
            str &= " join PORecvDetail prd on prd.PORecvMasterID =PRM.PORecvMasterID"
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =PRM.SupplierID   "
            str &= " join  POMaster pomm on pomm.POID =PRM.POID   "
            str &= " join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join PODetail YPD on YPD.POID=pomm.POID and YPD.PoDetailId =prd.PODetailID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            str &= " LEFT JOIN POReturn POR on POR.PORecvMasterID =PRM.PORecvMasterID"
            str &= " where PRM.PORecvMasterID='" & PORecvMasterID & "'"




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditNew(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String

           

            str = " select pm.POID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0')- ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.PORecvMasterID"
            str &= " =pm.PORecvMasterID ),0) as RecvQtyinBag, "
            str &= "  (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0'))- ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.PORecvMasterID"
            str &= " =pm.PORecvMasterID ),0) as RemainingQty,YPD.Quality as Quality,"
            str &= "  YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy,isnull(loc.LocationID ,'0') as FactoryLocationID, "
            str &= " isnull(prd.VehicleNo,'N/A') as VehicleNo, isnull(prd.LotNo ,'0') as LotNo,  isnull(prd.NoOfRoll ,'0') "
            str &= " as NoOfRoll, * "
            str &= "  from PORecvMaster pm "
            str &= " join PORecvDetail prd on prd.PORecvMasterID =pm.PORecvMasterID   "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID   "
            str &= " join  POMaster pomm on pomm.POID =pm.POID   "
            str &= "  join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join PODetail YPD on YPD.POID=pomm.POID and YPD.PoDetailId =prd.PODetailID"
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId  "
            str &= "  join Location loc on loc.LocationID = pm.LocationID  "
            str &= " where pm.PORecvMasterID='" & PORecvMasterID & "'"




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditNewForAstore(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String



            str = " select IMST.itemCodee as ItemNAme,pm.POID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0')- ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.PORecvMasterID"
            str &= " =pm.PORecvMasterID ),0) as RecvQtyinBag, "
            str &= "  (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0'))- ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.PORecvMasterID"
            str &= " =pm.PORecvMasterID ),0) as RemainingQty,YPD.Quality as Quality,"
            str &= "  YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy,isnull(loc.LocationID ,'0') as FactoryLocationID, "
            str &= " isnull(prd.VehicleNo,'N/A') as VehicleNo, isnull(prd.LotNo ,'0') as LotNo,  isnull(prd.NoOfRoll ,'0') "
            str &= " as NoOfRoll, * "
            str &= "  from PORecvMaster pm "
            str &= " join PORecvDetail prd on prd.PORecvMasterID =pm.PORecvMasterID   "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID   "
            str &= " join  POMaster pomm on pomm.POID =pm.POID   "
            str &= "  join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join PODetail YPD on YPD.POID=pomm.POID and YPD.PoDetailId =prd.PODetailID"
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId  "
            str &= "  join Location loc on loc.LocationID = pm.LocationID  "
            str &= " where pm.PORecvMasterID='" & PORecvMasterID & "'"




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEdit(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String

            'str = " select pm.POID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0') as RecvQtyinBag,"
            'str &= " (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0')) as RemainingQty,YPD.Quality as Quality,YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy,isnull(FL.FactoryLocationID,'0') as FactoryLocationID,isnull(prd.VehicleNo,'N/A') as VehicleNo, isnull(prd.LotNo ,'0') as LotNo,"
            'str &= " isnull(prd.NoOfRoll ,'0') as NoOfRoll, * from PORecvMaster pm"
            'str &= " join PORecvDetail prd on prd.PORecvMasterID =pm.PORecvMasterID "
            'str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
            'str &= " join  POMaster pomm on pomm.POID =pm.POID "
            'str &= " join ContractType ct on ct.ContractTypeID =pomm.POTypeID"
            'str &= " join PODetail YPD on YPD.POID=pomm.POID"
            'str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            'str &= " left join FactoryLocation FL on FL.FactoryLocationID=prd.StoreLocationID"
            'str &= " where pm.PORecvMasterID='" & PORecvMasterID & "'"

            str = " select pm.POID As Poidd,prd.POQuantity as POQTy,isnull(prd.RecvQuantity,'0') as RecvQtyinBag, "
            str &= " (isnull(YPD.Quantity ,'0')- isnull(prd.RecvQuantity,'0')) as RemainingQty,YPD.Quality as Quality,"
            str &= " YPD.Rate as  PORate,isnull(prd.ReturnQty,0) as ReturnQtyy,isnull(loc.LocationID ,'0') as FactoryLocationID,"
            str &= " isnull(prd.VehicleNo,'N/A') as VehicleNo, isnull(prd.LotNo ,'0') as LotNo, "
            str &= " isnull(prd.NoOfRoll ,'0') as NoOfRoll, * "
            str &= " from PORecvMaster pm "
            str &= " join PORecvDetail prd on prd.PORecvMasterID =pm.PORecvMasterID  "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID  "
            str &= " join  POMaster pomm on pomm.POID =pm.POID  "
            str &= "  join ContractType ct on ct.ContractTypeID =pomm.POTypeID "
            str &= " join PODetail YPD on YPD.POID=pomm.POID and YPD.PoDetailId =prd.PODetailID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join Location loc on loc.LocationID = pm.LocationID "
            str &= " where pm.PORecvMasterID='" & PORecvMasterID & "'"






            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANewEdit(ByVal POID As Long, ByVal Supplierid As Long, ByVal Item As String)
            Dim str As String
            str = "  select YPD.Style ,isnull(YRD.ReturnQty,0) as ReturnQtyy, YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,  IMST.ItemName as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND IMST.ItemName = '" & Item & "'"
            Try
                Return MyBase.GetDataTable(str)
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
        Public Function GETGridDATA(ByVal POID As Long, ByVal Supplierid As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style ,isnull(YRD.ReturnQty,0) as ReturnQtyy, YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,  IMST.ItemName as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=POM.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew(ByVal POID As Long, ByVal Supplierid As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style ,isnull(YRD.ReturnQty,0) as ReturnQtyy, YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
            str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
            str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
            str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
            str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Quantity as POQTY,"
            str &= " (isnull(YPD.Quantity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
            str &= " ,  IMST.ItemName as Itemname"
            str &= " ,YPD.Quality as Quality,YPD.Rate as  PORate from POMaster POM"
            str &= " join PODetail YPD on YPD.POID=POM.POID"
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId"
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID"
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid"
            str &= " left join PORecvDetail YRD on YRD.PODetailID=YPD.PODetailID"
            str &= " left join FactoryLocation FL on FL.FactoryLocationID=YRD.StoreLocationID"
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2ForEdit(ByVal POID As Long, ByVal Supplierid As Long, ByVal PoDetailID As Long, ByVal PoRecvMasterID As Long)
            Dim str As String
            str = "  select YPD.Style  ,"
            str &= " YPD.ItemID,YPD.PODetailID,"
            str &= " POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= " YPD.Quantity as POQTY,"
            str &= " isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as ReturnQtyy"
            str &= " ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')-(SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID) ) "
            str &= " as RemainingQty"
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as RecvQtyinBag"
            str &= " from POMaster POM "
            str &= " join PODetail YPD on YPD.POID=POM.POID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " join PORecvMaster POMS on POMS.POID =pom.POID"
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.PoDetailID = '" & PoDetailID & "' and POMS.PORecvMasterID ='" & PoRecvMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2(ByVal POID As Long, ByVal Supplierid As Long, ByVal PODetailID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style  ,"
            str &= " YPD.ItemID,YPD.PODetailID,"
            str &= " POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= "  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= " YPD.Quantity as POQTY,"
            str &= " isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as ReturnQtyy"
            str &= " ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')-(SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID) ) "
            str &= " as RemainingQty"
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as RecvQtyinBag"
            str &= " from POMaster POM "
            str &= " join PODetail YPD on YPD.POID=POM.POID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "' and YPD.PODetailID='" & PODetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2nEWForAstoreForNew(ByVal POID As Long, ByVal Supplierid As Long)
            Dim str As String
            str = "   select YPD.Style  ,"
            str &= " YPD.ItemID,YPD.PODetailID,"
            str &= " POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= " IMST.ItemCodee as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= " YPD.Quantity  as POQTY,"
            str &= " isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as ReturnQtyy"
            str &= " ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')-(SELECT SUM(Dtl.RecvQuantity) "
            str &= " FROM PORecvDetail Dtl where Dtl.PODetailID"
            str &= " =YPD.PODetailID) )"
            str &= " as RemainingQty"
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) "
            str &= " as "
            str &= " RecvQtyinBag"
            str &= " from POMaster POM "
            str &= " join PODetail YPD on YPD.POID=POM.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2nEWForAstore(ByVal POID As Long, ByVal Supplierid As Long)
            Dim str As String
            str = "  select YPD.Style  ,"
            str &= " YPD.ItemID,YPD.PODetailID,"
            str &= "  POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= " IMST.ItemCodee as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= " YPD.Quantity  as POQTY,"
            str &= " isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as ReturnQtyy"
            str &= " ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')-(SELECT SUM(Dtl.RecvQuantity) "
            str &= "  FROM PORecvDetail Dtl where Dtl.PODetailID"
            str &= "  =YPD.PODetailID) ) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.ItemID"
            str &= " =YPD.ItemId ),0)"
            str &= " as RemainingQty"
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) "
            str &= " - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.ItemID"
            str &= " =YPD.ItemId ),0)"
            str &= " as "
            str &= "    RecvQtyinBag"
            str &= " from POMaster POM "
            str &= " join PODetail YPD on YPD.POID=POM.POID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2nEW(ByVal POID As Long, ByVal Supplierid As Long, ByVal PODetailID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style  ,"
            str &= " YPD.ItemID,YPD.PODetailID,"
            str &= "  POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName, "
            str &= " IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,"
            str &= " YPD.Quantity  as POQTY,"
            str &= " isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) as ReturnQtyy"
            str &= " ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')-(SELECT SUM(Dtl.RecvQuantity) "
            str &= "  FROM PORecvDetail Dtl where Dtl.PODetailID"
            str &= "  =YPD.PODetailID) ) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.ItemID"
            str &= " =YPD.ItemId ),0)"
            str &= " as RemainingQty"
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0) "
            str &= " - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =YPD.POID AND POR.ItemID"
            str &= " =YPD.ItemId ),0)"
            str &= " as "
            str &= "    RecvQtyinBag"
            str &= " from POMaster POM "
            str &= " join PODetail YPD on YPD.POID=POM.POID "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "' and YPD.PODetailID='" & PODetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2nEWNew(ByVal POID As Long, ByVal Supplierid As Long, ByVal PODetailID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style  , YPD.ItemID,YPD.PODetailID,  POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as"
            str &= " JobOrderNo,SD.SupplierName,  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate, "
            str &= " YPD.Quantity  as POQTY, isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID "
            str &= " =YPD.PODetailID),0) as ReturnQtyy ,'0' AS  PORecvDetailID ,(isnull(YPD.Quantity ,'0')"
            str &= " -(SELECT SUM(Dtl.RecvQuantity)   FROM PORecvDetail Dtl where Dtl.PODetailID  =YPD.PODetailID) ) "
            str &= " -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR "
            str &= " join PORecvMaster PRM on PRM.PORecvMasterID "
            str &= " =POR.PORecvMasterID "
            str &= " WHERE POR.POID =YPD.POID AND POR.PORecvMasterID =PRM.PORecvMasterID ),0) "
            str &= " as RemainingQty "
            str &= " ,isnull((SELECT SUM(Dtl.RecvQuantity) "
            str &= " FROM PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0)  "
            str &= " - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR join PORecvMaster PRM on PRM.PORecvMasterID "
            str &= " =POR.PORecvMasterID "
            str &= "  WHERE POR.POID = YPD.POID"
            str &= " AND POR.PORecvMasterID =PRM.PORecvMasterID ),0) as     RecvQtyinBag"
            str &= " from POMaster POM  "
            str &= "  join PODetail YPD on YPD.POID=POM.POID   "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId  "
            str &= "  join ContractType CT on CT.ContractTypeID=POM.POTypeID "
            str &= "  left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "' and YPD.PODetailID='" & PODetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETGridDATANew2nEWNewYasir(ByVal POID As Long, ByVal Supplierid As Long, ByVal PODetailID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style  , YPD.ItemID,YPD.PODetailID,  POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as "
            str &= " JobOrderNo,SD.SupplierName,  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,  YPD.Quantity  "
            str &= "  as POQTY"
            str &= "  , isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl where Dtl.PODetailID  =YPD.PODetailID),0) "
            str &= " as ReturnQtyy "
            str &= " ,'0' AS  PORecvDetailID ,(isnull(YPD.Quantity ,'0') -(SELECT SUM(Dtl.RecvQuantity)   "
            str &= " FROM PORecvDetail Dtl where Dtl.PODetailID  =YPD.PODetailID) )  -ISNULL((SELECT SUM(POR.ReturnQty) "
            str &= " FROM POReturn POR  join PORecvMaster PRM on PRM.PORecvMasterID  =POR.PORecvMasterID"
            str &= " JOIN PORecvDetail PRD on PRD.ItemID =POR.ItemID "
            str &= "      WHERE POR.POID = YPD.POID"
            str &= " AND POR.PORecvMasterID =PRM.PORecvMasterID and PRD.ItemID =POR.ItemID),0)  as RemainingQty  "
            str &= "  ,isnull((SELECT SUM(Dtl.RecvQuantity)  FROM "
            str &= "  PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0)   - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn "
            str &= "  POR join PORecvMaster PRM on PRM.PORecvMasterID  =POR.PORecvMasterID  JOIN PORecvDetail PRD on PRD.ItemID =POR.ItemID WHERE POR.POID = YPD.POID AND "
            str &= "  POR.PORecvMasterID =PRM.PORecvMasterID and PRD.ItemID =POR.ItemID),0) as     RecvQtyinBag "
            str &= " from POMaster POM    "
            str &= "  join PODetail YPD "
            str &= " on YPD.POID=POM.POID     JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId    "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID   "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID   "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "' and YPD.PODetailID='" & PODetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GETGridDATANew2nEWNewYasirLatest(ByVal POID As Long, ByVal Supplierid As Long, ByVal PODetailID As Long, ByVal Itemid As Long)
            Dim str As String
            str = "  select YPD.Style  , YPD.ItemID,YPD.PODetailID,  POM.POID,CT.ContractType, isnull(Jo.JobOrderNo,'N/A') as  "
            str &= " JobOrderNo,SD.SupplierName,  IMST.ItemName as Itemname ,YPD.Quality as Quality,YPD.Rate as  PORate,  "
            str &= "  YPD.Quantity    as POQTY  "
            str &= " , isnull((SELECT SUM(Dtl.ReturnQty) FROM PORecvDetail Dtl "
            str &= " where Dtl.PODetailID  =YPD.PODetailID),0)  as ReturnQtyy  "
            str &= "  ,'0' AS  PORecvDetailID"
            str &= " ,(isnull(YPD.Quantity ,'0')"
            str &= " -(SELECT SUM(Dtl.RecvQuantity)    FROM PORecvDetail Dtl where Dtl.PODetailID  =YPD.PODetailID) )  "
            str &= "  -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID = YPD.POID and POR.ItemID =YPD.ItemID )"
            str &= "  ,0) as RemainingQty"
            str &= "  ,isnull((SELECT SUM(Dtl.RecvQuantity)  FROM   PORecvDetail Dtl where Dtl.PODetailID =YPD.PODetailID),0)"
            str &= "  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn   POR join POMaster  PRM on PRM.POID "
            str &= " =POR.POID  WHERE POR.POID = YPD.POID and POR.ItemID =YPD.ItemID),0) as     RecvQtyinBag "
            str &= " from POMaster POM    "
            str &= " join PODetail YPD  on YPD.POID=POM.POID   "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=YPD.ItemId     "
            str &= " join ContractType CT on CT.ContractTypeID=POM.POTypeID    "
            str &= " left join JobOrderDatabase JO on JO.JobOrderID=YPD.JobOrderID    "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId=YPD.AccountpayablePartyid "
            str &= " where  POM.CEOApproval=1  and POM.POID='" & POID & "'  and YPD.AccountPayablePartyId='" & Supplierid & "' AND YPD.ItemId = '" & Itemid & "' and YPD.PODetailID='" & PODetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GETQtyy(ByVal POID As Long, ByVal Supplierid As Long, ByVal Itemid As Long, ByVal PORecvMasterID As Long)
            Dim str As String

            str = "  select SUM(Dtl.RecvQuantity) as Qty from PORecvMaster  mST"
            str &= " JOIN PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID"
            str &= "  join POMaster PO on PO.POID =MST.POID "
            str &= "  JOIN PODetail POD on POD.POID =PO.POID "
            str &= " WHERE mST.POID ='" & POID & "' AND MST.PORecvMasterID ='" & PORecvMasterID & "' AND POD.AccountPayablePartyId='" & Supplierid & "' AND "
            str &= " POD.ItemId='" & Itemid & "'"
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

            str = " select distinct POD.ItemId,IMST.ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where FabricPOrder = 1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemFBDPNew(ByVal AccountPayablePartyID As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = " select  POD.PODetailId,IMST.ItemCodee + '   (' + convert(varchar,POD.DeliveryDate,103) +')' as ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where FabricPOrder = 1 and pod.AccountPayablePartyID ='" & AccountPayablePartyID & "' and POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemFBDPNewForAcc(ByVal AccountPayablePartyID As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = " select  POD.PODetailId,IMST.ItemCodee + '   (' + convert(varchar,POD.DeliveryDate,103) +')' as ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where FabricPOrder =0 and POM.GStoreStatus=0 and pod.AccountPayablePartyID ='" & AccountPayablePartyID & "' and POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemFBDPNewForAccGstore(ByVal AccountPayablePartyID As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = " select  POD.PODetailId,IMST.ItemCodee + '   (' + convert(varchar,POD.DeliveryDate,103) +')' as ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where  POM.GStoreStatus=1 and pod.AccountPayablePartyID ='" & AccountPayablePartyID & "' and POM.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindItemACCDPNew(ByVal AccountPayablePartyID As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = " select  POD.ItemId,IMST.ItemName from POMaster POM"
            str &= " join PODetail POD on POM.POID=POD.POID "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= "    where FabricPOrder = 0 and pod.AccountPayablePartyID ='" & AccountPayablePartyID & "' and POM.POID ='" & POID & "'"
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
            str = " select distinct PO.PONO,PO.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID  "
            str &= " where POD.AccountPayablePartyId='" & Supplierid & "' AND POD.ItemId = '" & IMSItemId & "'"
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

            str = " select distinct SupplierDatabaseid,SupplierName from POmaster POM join POdetail POD on POD.POID=POM.POID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1  And POD.ItemId = '" & IMSItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPOONew() As DataTable

            Dim str As String
            str = " select distinct SupplierDatabaseid,SupplierName from POmaster POM join POdetail POD on POD.POID=POM.POID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPOONewForAstore() As DataTable

            Dim str As String
            str = " select distinct SupplierDatabaseid,SupplierName from POmaster POM join POdetail POD on POD.POID=POM.POID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1 and POM.FabricPOrder =0 and POM.GStoreStatus=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForRecPOONewForAstoreGSTore() As DataTable

            Dim str As String
            str = " select distinct SupplierDatabaseid,SupplierName from POmaster POM join POdetail POD on POD.POID=POM.POID  "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseid=POD.AccountPayablePartyId"
            str &= " where POM.CEOApproval = 1 and  POM.GStoreStatus=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckDepartment(ByVal UserId As Long)

            Dim str As String
            str = " select * from UMUser"
            str &= " where UserId='" & UserId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckImsItemIdInGodownTransfer(ByVal IMSItemID As Long)

            Dim str As String
            str = " select * from IMSGodownIssue mst"
            str &= " join IMSGodownIssueDetail dTL on Dtl.GodownIssueID =mst.GodownIssueID "
            str &= " where dtl.FromLocationID =4 and dtl.IMSItemID='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOSupNItemWiseDPEdit(ByVal Supplierid As Long, ByVal IMSItem As String)

            Dim str As String
            str = " select distinct PO.PONO,PO.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID  "
            str &= " join IMSItem im on im.IMSItemID =pod.ItemId "
            str &= " where POD.AccountPayablePartyId='" & Supplierid & "' AND im.ItemName = '" & IMSItem & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindProcessNoForReport()

            Dim str As String
            str = " select distinct PO.PONO,PO.ProcessOrderMstID"
            str &= " from ProcessOrderMst PO"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForProcessReport()

            Dim str As String
            str = " select distinct PO.partyAccount"
            str &= " from ProcessOrderDtl PO"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForGoodRecvNoteReportForAuditor()

            Dim str As String

            str = " select DISTINCT  Mst.SupplierID,sd.SUPPLIERnAME  FROM PORecvMaster Mst"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId =MST.SupplierID "
            str &= " join POMaster po on po.POId =Mst.POId "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForGoodRecvNoteReportForAcc()

            Dim str As String

            str = " select DISTINCT  Mst.SupplierID,sd.SUPPLIERnAME  FROM PORecvMaster Mst"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId =MST.SupplierID "
            str &= " join POMaster po on po.POId =Mst.POId "
            str &= " WHERE po.FabricPOrder =0 and PO.GStoreStatus=0"



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForGoodRecvNoteReportForAccGStore()

            Dim str As String

            str = " select DISTINCT  Mst.SupplierID,sd.SUPPLIERnAME  FROM PORecvMaster Mst"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId =MST.SupplierID "
            str &= " join POMaster po on po.POId =Mst.POId "
            str &= " WHERE PO.GStoreStatus=1"



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForGoodRecvNoteReportForProcess()

            Dim str As String

            str = " select DISTINCT  Mst.SupplierID,sd.SUPPLIERnAME  FROM POProcessRecvMaster Mst"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId =MST.SupplierID "
            str &= " join ProcessOrdermst po on po.ProcessOrdermstid =Mst.ProcessOrdermstid "
            str &= " WHERE po.FabricPOrder =1 "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForGoodRecvNoteReport()

            Dim str As String

            str = " select DISTINCT  Mst.SupplierID,sd.SUPPLIERnAME  FROM PORecvMaster Mst"
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseId =MST.SupplierID "
            str &= " join POMaster po on po.POId =Mst.POId "
            str &= " WHERE po.FabricPOrder =1 "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForReportForAccForAuditor()

            Dim str As String
            str = " select distinct PO.partyAccount"
            str &= " from PODetail PO join POMaster POM on POM.POID=PO.POID "
            str &= " order by PO.partyAccount asc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForReportForAcc()

            Dim str As String
            str = " select distinct PO.partyAccount"
            str &= " from PODetail PO join POMaster POM on POM.POID=PO.POID Where POM.FabricPOrder=0 and POM.GStoreStatus=0"
            str &= " order by PO.partyAccount asc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForReportForAccGSTORE()

            Dim str As String
            str = " select distinct PO.partyAccount"
            str &= " from PODetail PO join POMaster POM on POM.POID=PO.POID Where POM.GStoreStatus=1"
            str &= " order by PO.partyAccount asc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSupplierForReport()

            Dim str As String
            str = " select distinct PO.partyAccount"
            str &= " from PODetail PO join POMaster POM on POM.POID=PO.POID Where POM.FabricPOrder=1"
            str &= " order by PO.partyAccount asc"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindProcessnumber()

            Dim str As String
            str = " select distinct ProcessOrderMstID,PONO"
            str &= " from ProcessOrderMst "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportForfabricForProcess()

            Dim str As String
            str = " select distinct PO.POProcessRecvMasterID,PO.GatePassNo"
            str &= " from POProcessRecvMaster PO join ProcessOrdermst POM on POM.ProcessOrdermstid=PO.ProcessOrdermstid where POM.FabricPOrder = 1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportForfabric()

            Dim str As String
            str = " select distinct PO.PORecvMasterID,PO.GatePassNo"
            str &= " from PORecvMaster PO join POMaster POM on POM.poid=PO.POID where POM.FabricPOrder = 1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindManualChallanNoForReportForfabric()

            Dim str As String
            'str = "select * from IssueMst mst"
            'str &= " join POMaster POM on POM.POID =MST.POID "
            'str &= "  WHERE POM.FabricPOrder = 1 "

            str = "  select * from IssueMst mst "
            str = " join IssueDetail ID on ID.IssueID =MST.IssueID "
            str = " join POMaster POM on POM.POID =ID.POID   WHERE POM.FabricPOrder = 1 "
            str = " AND mst.ManualChallanNo  <>''"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindManualChallanNoForReportForfabricForAll()

            Dim str As String
            'str = "select * from IssueMst mst"
            'str &= " join POMaster POM on POM.POID =MST.POID "

            str = " select * from IssueMst mst "
            str &= " join IssueDetail ID on ID.IssueID =MST.IssueID "
            str &= " join POMaster POM on POM.POID =ID.POID   WHERE "
            str &= " mst.ManualChallanNo  <>''"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindManualChallanNoForReportForfabricForAllForProcess()

            Dim str As String
            str = " select * from processIssueMst mst"
            str &= " join ProcessOrderMst POM on pom.ProcessOrderMstID=mst.ProcessOrderMstID"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindManualChallanNoForReportForfabricForAcc()

            Dim str As String
           
            str = "   select * from IssueMst mst "
            str &= " join IssueDetail ID on ID.IssueID =MST.IssueID "
            str &= " join POMaster POM on POM.POID =ID.POID   WHERE POM.FabricPOrder = 0 and POM.GStoreStatus=0"
            str &= " AND mst.ManualChallanNo  <>''"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindManualChallanNoForReportForfabricForAccGStore()

            Dim str As String

            str = "   select * from IssueMst mst "
            str &= " join IssueDetail ID on ID.IssueID =MST.IssueID "
            str &= " join POMaster POM on POM.POID =ID.POID   WHERE POM.GStoreStatus=1"
            str &= " AND mst.ManualChallanNo  <>''"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportForAuditor()

            Dim str As String
            str = " select distinct PO.PORecvMasterID,PO.GatePassNo"
            str &= " from PORecvMaster PO join POMaster POM on POM.poid=PO.POID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportForAcc()

            Dim str As String
            str = " select distinct PO.PORecvMasterID,PO.GatePassNo"
            str &= " from PORecvMaster PO join POMaster POM on POM.poid=PO.POID where POM.FabricPOrder = 0 and POM.GStoreStatus=0"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportForAccGStore()

            Dim str As String
            str = " select distinct PO.PORecvMasterID,PO.GatePassNo"
            str &= " from PORecvMaster PO join POMaster POM on POM.poid=PO.POID where POM.GStoreStatus=1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReport()

            Dim str As String
            str = " select distinct PO.GatePassNo"
            str &= " from PORecvMaster PO"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportNew()

            Dim str As String
            str = " select * "
            str &= "  from POMaster "
            str &= "      WHERE FabricPOrder = 1 "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportNewForAccFoRAuditor()

            Dim str As String
            str = " select * "
            str &= "  from POMaster "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportNewForAcc()

            Dim str As String
            str = " select * "
            str &= "  from POMaster "
            str &= "      WHERE FabricPOrder = 0 and GStoreStatus=0"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInvoiceNoForReportNewForGStore()

            Dim str As String
            str = " select * "
            str &= "  from POMaster "
            str &= "      WHERE GStoreStatus=1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOForReport()

            Dim str As String
            str = " select distinct PO.PONO,PO.POID"
            str &= " from POMaster PO where PO.FabricPOrder =1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoAndSeasonFromRecv(ByVal POID As Long)

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
        Public Function BindPOSupNItemWiseDPEditNewForAcc(ByVal Supplierid As Long)

            Dim str As String
            str = " select distinct PO.PONO,PO.POID,(PO.PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID  "
            str &= " join IMSItem im on im.IMSItemID =pod.ItemId "
            str &= " where po.FabricPOrder=0 and po.GStoreStatus=0 and POD.AccountPayablePartyId='" & Supplierid & "'"
            str &= " and po.ClosedStatus = 0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOSupNItemWiseDPEditNewForAccGstore(ByVal Supplierid As Long)

            Dim str As String
            str = " select distinct PO.PONO,PO.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID  "
            str &= " join IMSItem im on im.IMSItemID =pod.ItemId "
            str &= " where  po.GStoreStatus=1 and POD.AccountPayablePartyId='" & Supplierid & "'"
            ' Atif Work on 03 May 2018
            str &= " and po.ClosedStatus = 0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindPOSupNItemWiseDPEditNew(ByVal Supplierid As Long)

            Dim str As String
            str = " select distinct PO.PONO,PO.POID,(PONo+' '+'  ('+isnull(SRNO,'Open')+')') as POJO"
            str &= " from POMaster PO join PODetail POD on POD.POID=PO.POID  "
            str &= " left join JobOrderdatabase jb on jb.Joborderid =POD.JoborderID  "
            str &= " join IMSItem im on im.IMSItemID =pod.ItemId "
            str &= " where po.FabricPOrder=1 and POD.AccountPayablePartyId='" & Supplierid & "'"
            ' Atif Work on 03 May 2018
            str &= " and po.ClosedStatus = 0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function BindSupplier() As DataTable
            Dim str As String
            str = " select * from SupplierDatabase SDB"

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
        Public Function GetPORECforViewFabricNewForACC()
            Dim Str As String

            Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            Str &= " from POMaster POM  "
            Str &= " join PODetail POD on POd.POId=POM.POId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "     where POM.FabricPOrder = 0"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= " POD.Style, Sd.SupplierName"
            Str &= "   order by POM.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewNewForAll()
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewNewForAcc()
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 0 and POM.GStoreStatus=0"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewNewForAccGStore()
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.GStoreStatus=1"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricNewNew()
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 1"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetPORECforViewFabricNew()
            Dim Str As String

            Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            Str &= " from POMaster POM  "
            Str &= " join PODetail POD on POd.POId=POM.POId       "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "     where POM.FabricPOrder = 1"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= " POD.Style, Sd.SupplierName"
            Str &= "   order by POM.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusPONOVise(ByVal PONO As String)
            Dim Str As String

            'Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            'Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            'Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            'Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            'Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            'Str &= " from POMaster POM  "
            'Str &= " join PODetail POD on POd.POId=POM.POId       "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            'Str &= "     where POM.FabricPOrder = 1 "
            'Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            'Str &= " POD.Style, Sd.SupplierName"
            'Str &= "   order by POM.POID"

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 1 and POM.PONO= '" & PONO & "' "
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "   order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusPONOViseForAll(ByVal PONO As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.PONO= '" & PONO & "' "
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity, POD.ItemId, POD.POID,"
            Str &= "  POD.Style, Sd.SupplierName"
            Str &= "   order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusPONOViseForAcc(ByVal PONO As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 0 and POM.GStoreStatus=0 and POM.PONO= '" & PONO & "' "
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity, POD.ItemId, POD.POID,"
            Str &= "  POD.Style, Sd.SupplierName"
            Str &= "   order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusPONOViseForAccGstore(ByVal PONO As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.GStoreStatus=1 and POM.PONO= '" & PONO & "' "
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity, POD.ItemId, POD.POID,"
            Str &= "  POD.Style, Sd.SupplierName"
            Str &= "   order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusStyleViseForAll(ByVal Style As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where  POD.Style= '" & Style & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

          
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusStyleViseForAcc(ByVal Style As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 0 and POM.GStoreStatus=0 and POD.Style= '" & Style & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusStyleViseForAccGStore(ByVal Style As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.GStoreStatus=1 and POD.Style= '" & Style & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusStyleVise(ByVal Style As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 1 and POD.Style= '" & Style & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"



            'Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            'Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            'Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            'Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            'Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            'Str &= " from POMaster POM  "
            'Str &= " join PODetail POD on POd.POId=POM.POId       "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            'Str &= "     where POM.FabricPOrder = 1 and POD.Style= '" & Style & "'"
            'Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            'Str &= " POD.Style, Sd.SupplierName"
            'Str &= "   order by POM.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusSupplierVise(ByVal PartyAccount As String)
            Dim Str As String

            'Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            'Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            'Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            'Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            'Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            'Str &= " from POMaster POM  "
            'Str &= " join PODetail POD on POd.POId=POM.POId       "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            'Str &= "     where POM.FabricPOrder = 1 and POD.PartyAccount= '" & PartyAccount & "'"
            'Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            'Str &= " POD.Style, Sd.SupplierName"
            'Str &= "   order by POM.POID"

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 1 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusSupplierViseForAll(ByVal PartyAccount As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where  POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

          
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusSupplierViseForAcc(ByVal PartyAccount As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 0 and POM.GStoreStatus=0 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusSupplierViseForAccGStore(ByVal PartyAccount As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.GStoreStatus=1 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusItemViseForAll(ByVal Itemname As String)
            Dim Str As String



            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where  IMST.Itemname= '" & Itemname & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusItemViseForAcc(ByVal Itemname As String)
            Dim Str As String

            

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 0 and POM.GStoreStatus=0 and IMST.Itemname= '" & Itemname & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusItemViseForAccGStore(ByVal Itemname As String)
            Dim Str As String

            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.GStoreStatus=1 and IMST.Itemname= '" & Itemname & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOStatusItemVise(ByVal Itemname As String)
            Dim Str As String

            'Str = "      select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            'Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            'Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) )"
            'Str &= "  ,0)  as BalanceQty,POD.Style,Sd.SupplierName  "
            'Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0) as RecvQuantity"
            'Str &= " from POMaster POM  "
            'Str &= " join PODetail POD on POd.POId=POM.POId       "
            'Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            'Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            'Str &= "     where POM.FabricPOrder = 1 and IMST.Itemname= '" & Itemname & "'"
            'Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            'Str &= " POD.Style, Sd.SupplierName"
            'Str &= "   order by POM.POID"


            Str = "       select POM.POID,pom.PONo,IMST.ItemName,convert(varchar,pod.DeliveryDate,103) as DeliveryDate, "
            Str &= "  convert(varchar,POM.CreationDate,103) as POdate, isnull(POD.Quantity,0) as POQTY,  "
            Str &= "  isnull((isnull(POD.Quantity,0)-isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID "
            Str &= "  = POD.PoDetailId ),0) )"
            Str &= "   ,0) -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as BalanceQty,POD.Style,Sd.SupplierName  "
            Str &= "  ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId ),0)-ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0)"
            Str &= "   as RecvQuantity"
            Str &= "   from POMaster POM  "
            Str &= "  join PODetail POD on POd.POId=POM.POId       "
            Str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   where POM.FabricPOrder = 1 and IMST.Itemname= '" & Itemname & "'"
            Str &= "  group by POM.POID ,pom.PONo ,pod.PoDetailId ,IMST.ItemName,pod.DeliveryDate,POM.CreationDate,POD.Quantity,"
            Str &= "  POD.Style, Sd.SupplierName, POD.ItemId, POD.POID"
            Str &= "  order by POM.POID desc"
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


            Str = "   select POD.ItemId,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            Str &= " ,*,PRM.PORecvDate from POMaster POM   join PODetail POD on POd.POId=POM.POId  "
            Str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID"
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId where POM.FabricPOrder=1 "
            Str &= "  order by POM.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForPONOViseForAuditor(ByVal PONO As String)
            Dim Str As String

            Str = "     select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE Mst.AuditorStatus =0  and POM.PONO= '" & PONO & "'"
            Str &= "   order by  POM.PONO Asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForPONOVise(ByVal PONO As String)
            Dim Str As String

            Str = "     select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 and POM.PONO= '" & PONO & "'"
            Str &= "  order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForPONOViseForAccGSStore(ByVal PONO As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.GStoreStatus=1 and POM.PONO= '" & PONO & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForPONOViseForAcc(ByVal PONO As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =0 and POM.GStoreStatus=0 and POM.PONO= '" & PONO & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForPONOViseForAll(ByVal PONO As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE  POM.PONO= '" & PONO & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforSearchingPONOViseForAuditor(ByVal PONO As String)

            Dim Str As String

            Str = "  select PO.FabricPOrder,PO.InditexPONo,FabricStatus,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " ,(select top 1 cONVERT(VARCHAR,podd.DeliveryDate,103) from PODetail podd where podd.POID=PO.POID) AS DeliveryDatee,PO.AuditorStatus, Po.ClosedStatus"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where  PO.PONO='" & PONO & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,FabricStatus,POTypeID,PO.InditexPONo,PO.AuditorStatus,PO.FabricPOrder, Po.ClosedStatus"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforSearchingPONOVise(ByVal PONO As String)

            Dim Str As String

            Str = "  select PO.InditexPONo,FabricStatus,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " ,(select top 1 cONVERT(VARCHAR,podd.DeliveryDate,103) from PODetail podd where podd.POID=PO.POID) AS DeliveryDatee,PO.AuditorStatus"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where FabricStatus = 1 and PO.PONO='" & PONO & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,FabricStatus,POTypeID,PO.InditexPONo,PO.AuditorStatus"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforSearchingSupplierViseForAuditor(ByVal PartyAccount As String)

            Dim Str As String

            Str = "  select PO.FabricPOrder,PO.InditexPONo,FabricStatus,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " ,(select top 1 cONVERT(VARCHAR,podd.DeliveryDate,103) from PODetail podd where podd.POID=PO.POID) AS DeliveryDatee,PO.AuditorStatus, Po.ClosedStatus"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where POD.PartyAccount='" & PartyAccount & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,FabricStatus,POTypeID,PO.InditexPONo,PO.AuditorStatus,PO.FabricPOrder ,Po.ClosedStatus"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforSearchingSupplierVise(ByVal PartyAccount As String)

            Dim Str As String

            Str = "  select PO.InditexPONo,FabricStatus,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " ,(select top 1 cONVERT(VARCHAR,podd.DeliveryDate,103) from PODetail podd where podd.POID=PO.POID) AS DeliveryDatee,PO.AuditorStatus"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where FabricStatus = 1 and POD.PartyAccount='" & PartyAccount & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,FabricStatus,POTypeID,PO.InditexPONo,PO.AuditorStatus"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForStyleViseForAll(ByVal Style As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE  POD.Style= '" & Style & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForStyleViseForAccGStore(ByVal Style As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE  POM.GStoreStatus=1 and POD.Style= '" & Style & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForStyleViseForAcc(ByVal Style As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =0 and POM.GStoreStatus=0 and POD.Style= '" & Style & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForStyleViseForAuditor(ByVal Style As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE Mst.AuditorStatus =0 and POD.Style= '" & Style & "'"
            Str &= "   order by  POM.PONO Asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForStyleVise(ByVal Style As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 and POD.Style= '" & Style & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForItemViseForAuditor(ByVal ItemName As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE Mst.AuditorStatus =0 and IMST.ItemName= '" & ItemName & "'"
            Str &= "   order by  POM.PONO Asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForItemVise(ByVal ItemName As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 and IMST.ItemName= '" & ItemName & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForItemViseForAll(ByVal ItemName As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE  IMST.ItemName= '" & ItemName & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForItemViseForACC(ByVal ItemName As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =0 and POM.GStoreStatus=0 and IMST.ItemName= '" & ItemName & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForItemViseForACCGStore(ByVal ItemName As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.GStoreStatus=1 and IMST.ItemName= '" & ItemName & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForSupplierViseForAcc(ByVal PartyAccount As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 and POM.GStoreStatus=0 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForSupplierViseForAccGStore(ByVal PartyAccount As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.GStoreStatus=1 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForSupplierViseForAll(ByVal PartyAccount As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForSupplierViseForAuditor(ByVal PartyAccount As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE Mst.AuditorStatus =0 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "   order by  POM.PONO Asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForSupplierVise(ByVal PartyAccount As String)
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.ItemID"
            Str &= "  =POD.ItemId ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 and POD.PartyAccount= '" & PartyAccount & "'"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForAllNew()
            Dim Str As String
          
            Str = "     select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForAll()
            Dim Str As String
            Str = "     DECLARE @datefrom as datetime,@todate as datetime"
            Str &= "   set @todate =convert(date,GETDATE(),103)"
            Str &= "   set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"
            Str &= "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId    "
            Str &= "   and Mst.PORecvDate between @datefrom and @todate"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForAccAll()
            Dim Str As String
          
            Str = "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.FabricPOrder =0 and POM.GStoreStatus=0  "
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForAcc()
            Dim Str As String
            Str = "     DECLARE @datefrom as datetime,@todate as datetime"
            Str &= "   set @todate =convert(date,GETDATE(),103)"
            Str &= "   set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"
            Str &= "  select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.FabricPOrder =0 and POM.GStoreStatus=0  "
            Str &= "   and Mst.PORecvDate between @datefrom and @todate"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForGSToreAll()
            Dim Str As String
           
            Str = "  select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.GStoreStatus =1   "
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvForGSTore()
            Dim Str As String
            Str = "     DECLARE @datefrom as datetime,@todate as datetime"
            Str &= "   set @todate =convert(date,GETDATE(),103)"
            Str &= "   set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"
            Str &= " select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.GStoreStatus =1   "
            Str &= "   and Mst.PORecvDate between @datefrom and @todate"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewWithUserAllAuditorAuthNewww() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= "  ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "   WHERE IMS_SI.AuditorStatus = 0"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserAllAuditorAuth() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= "  ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "   WHERE IMS_SI.AuditorStatus = 1"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserAllAuditor() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= "  ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "   WHERE IMS_SI.AuditorStatus = 1"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateForIssueAuditor() As DataTable
            Dim str As String
            str = "  select  mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "   WHERE Mst.AuditorStatus = 1"
            str &= " order by mst.IssueID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewFabricNewNewForUpdateForIssueAuditorNew() As DataTable
            Dim str As String
            str = "  select  mst.AuditorStatus,mst.ManualChallanNo,ITM.ItemName as ItemName,ITM.ItemCodee, "
            str &= " (D.RecvQty-D.IssueQty) as Balance,*,convert(varchar,mst.creationdate,103) as date, "
            str &= " (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as DeptDatabaseNamee,isnull(pm.PONo,'In Stock') as PONoo"
            str &= " ,d.RecvQty  - ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =D.POID AND POR.ItemID"
            str &= " =D.ItemId ),0) as RecvQtyy"
            str &= " from   IssueMst  mst  "
            str &= "  join IssueDetail  D on d.IssueID =Mst.IssueID left join POMaster pm on pm.POID =D.POID "
            str &= "    left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =D .DeptDatabaseID "
            str &= "  join IMSItem ITM on ITM.IMSItemID=D.ItemID "
            str &= "   WHERE Mst.AuditorStatus = 0"
            str &= " order by mst.IssueID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForPORecvNewForAuditorAuth()
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE Mst.AuditorStatus =1   "
            Str &= "   order by  Mst.PORecvMasterID DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvNewForAuditor()
            Dim Str As String

            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID ),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE Mst.AuditorStatus =0   "
            Str &= "   order by  Mst.PORecvMasterID DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvNewAll()
            Dim Str As String

           

            Str = "     select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.FabricPOrder =1   "
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecvNew()
            Dim Str As String

            Str = "     DECLARE @datefrom as datetime,@todate as datetime"
            Str &= "   set @todate =convert(date,GETDATE(),103)"
            Str &= "   set @datefrom = convert(date,DATEADD(d,-30,@todate),103)"

            Str &= "   select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,"
            Str &= "   convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate "
            Str &= "   ,Dtl.RecvQuantity -ISNULL((SELECT SUM(POR.ReturnQty) FROM POReturn POR WHERE POR.POID =POD.POID AND POR.PORecvMasterID"
            Str &= "  =Mst.PORecvMasterID),0) as RecvQuantityy"
            Str &= "  from PORecvMaster Mst join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID  "
            Str &= "  join POMaster POM on POM.POID =MST.POID  JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId "
            Str &= "  =DTL.PODetailID   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID   "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   WHERE POM.FabricPOrder =1   "
            Str &= "   and Mst.PORecvDate between @datefrom and @todate"
            Str &= "   order by  Mst.PORecvMasterID  desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPORecv()
            Dim Str As String
            
            Str = "    select *,(POD.Quantity-Dtl.RecvQuantity) as BalanceQty,POD.Quantity as POQty,convert(varchar,POM.CreationDate,103) as PoDATE,convert(varchar,Mst.PORecvDate ,103) as PORecvDate from PORecvMaster Mst"
            Str &= " join PORecvDetail Dtl on Dtl.PORecvMasterID =mst.PORecvMasterID "
            Str &= " join POMaster POM on POM.POID =MST.POID "
            Str &= " JOIN PODetail POD on POD.POID =POM.POID and POD.PoDetailId =DTL.PODetailID "
            Str &= "  join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID "
            Str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            Str &= "   WHERE POM.FabricPOrder =1 "
            Str &= "   order by  POM.PONO Asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPORECforViewFabricbySearch(ByVal ItemName As String)
            Dim Str As String
            Str = "   select POD.ItemId,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
            Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
            Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
            Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
            Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
            Str &= " ,*,PRM.PORecvDate from POMaster POM   join PODetail POD on POd.POId=POM.POId  "
            Str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
            Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
            Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
            Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId where POM.FabricPOrder=1 and IMST.ItemName = '" & ItemName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        'Public Function GetPORECforViewFabricbySearchNew(ByVal txtSearchText As String)
        '    Dim Str As String
        '    Str = "   select POD.ItemId,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
        '    Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,"
        '    Str &= " IMST.ItemName  as ItemName, isnull(POD.Quantity,0) as POQTY,"
        '    Str &= " isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate, isnull(PRM.GatePassNo,'N/A') as GatePassNo,"
        '    Str &= " isnull(PRD.RecvQuantity,0) as RecvQuantity, isnull((isnull(POD.Quantity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty "
        '    Str &= " ,*,PRM.PORecvDate from POMaster POM   join PODetail POD on POd.POId=POM.POId  "
        '    Str &= "  left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID  "
        '    Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID  "
        '    Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId"
        '    Str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId where POM.FabricPOrder=1 and ("
        '    Str &= " IMST.ItemName like('" & txtSearchText.Trim().ToString() & "%') or sd.SupplierName like('" & txtSearchText.Trim().ToString() & "%') or POM.PONO like('" & txtSearchText.Trim().ToString() & "%')) "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function

        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String

            str = " select Top 1 GatePassNo from PORecvMaster where year(PORecvDate)='" & year & "' order By PORecvMasterID DESC "
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
    End Class
End Namespace

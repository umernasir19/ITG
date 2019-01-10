Imports System.Data
Imports Microsoft.VisualBasic

Public Class POInvoiceAdjDetail
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POInvoiceAdjDetail"
        m_strPrimaryFieldName = "POInvoiceAdjDetailID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPOInvoiceAdjDetailID As Long
    Private m_lPOInvoiceMasterID As Long
    Private m_lSupplierID As Long
    Private m_ltblBankMstID As Long
    Private m_dtCreationDate As Date
    Private m_dOpeningAmount As Decimal
    Private m_dAdjustedAmount As Decimal
    Private m_dBalanceAmountDTL As Decimal
    Private m_strPaymentType As String
    Private m_strPaymentVocuherRefNo As String

    Private m_dInitialAmount As Decimal
    Private m_dSTaxPercentage As Decimal
    Private m_dSTaxAmount As Decimal
    Private m_dWHTaxPercentage As Decimal
    Private m_dWHTaxAmount As Decimal
    Private m_dGSTaxPercentage As Decimal
    Private m_dGSTaxAmount As Decimal

    Public Property POInvoiceAdjDetailID() As Long
        Get
            POInvoiceAdjDetailID = m_lPOInvoiceAdjDetailID
        End Get
        Set(ByVal value As Long)
            m_lPOInvoiceAdjDetailID = value
        End Set
    End Property
    Public Property POInvoiceMasterID() As Long
        Get
            POInvoiceMasterID = m_lPOInvoiceMasterID
        End Get
        Set(ByVal value As Long)
            m_lPOInvoiceMasterID = value
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
    Public Property tblBankMstID() As Long
        Get
            tblBankMstID = m_ltblBankMstID
        End Get
        Set(ByVal value As Long)
            m_ltblBankMstID = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal value As Date)
            m_dtCreationDate = value
        End Set
    End Property
    Public Property OpeningAmount() As Decimal
        Get
            OpeningAmount = m_dOpeningAmount
        End Get
        Set(ByVal value As Decimal)
            m_dOpeningAmount = value
        End Set
    End Property
    Public Property AdjustedAmount() As Decimal
        Get
            AdjustedAmount = m_dAdjustedAmount
        End Get
        Set(ByVal value As Decimal)
            m_dAdjustedAmount = value
        End Set
    End Property
    Public Property BalanceAmountDTL() As Decimal
        Get
            BalanceAmountDTL = m_dBalanceAmountDTL
        End Get
        Set(ByVal value As Decimal)
            m_dBalanceAmountDTL = value
        End Set
    End Property
    Public Property PaymentType() As String
        Get
            PaymentType = m_strPaymentType
        End Get
        Set(ByVal value As String)
            m_strPaymentType = value
        End Set
    End Property

    Public Property PaymentVocuherRefNo() As String
        Get
            PaymentVocuherRefNo = m_strPaymentVocuherRefNo
        End Get
        Set(ByVal value As String)
            m_strPaymentVocuherRefNo = value
        End Set
    End Property
    Public Property InitialAmount() As Decimal
        Get
            InitialAmount = m_dInitialAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dInitialAmount = Value
        End Set
    End Property
    Public Property STaxPercentage() As Decimal
        Get
            STaxPercentage = m_dSTaxPercentage
        End Get
        Set(ByVal Value As Decimal)
            m_dSTaxPercentage = Value
        End Set
    End Property
    Public Property STaxAmount() As Decimal
        Get
            STaxPercentage = m_dSTaxAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dSTaxAmount = Value
        End Set
    End Property
    Public Property WHTaxPercentage() As Decimal
        Get
            WHTaxPercentage = m_dWHTaxPercentage
        End Get
        Set(ByVal Value As Decimal)
            m_dWHTaxPercentage = Value
        End Set
    End Property
    Public Property WHTaxAmount() As Decimal
        Get
            WHTaxAmount = m_dWHTaxAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dWHTaxAmount = Value
        End Set
    End Property
    Public Property GSTaxPercentage() As Decimal
        Get
            GSTaxPercentage = m_dGSTaxPercentage
        End Get
        Set(ByVal Value As Decimal)
            m_dGSTaxPercentage = Value
        End Set
    End Property
    Public Property GSTaxAmount() As Decimal
        Get
            GSTaxAmount = m_dGSTaxAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dGSTaxPercentage = Value
        End Set
    End Property


    Public Function SavePOInvoiceAdjDetail()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function UpdateOpeningAmount(ByVal POInvoiceMasterID As Long, ByVal Amount As Decimal)
        Dim Str As String
        Str = " update POInvoiceAdjDetail set OpeningAmount='" & Amount & "' where POInvoiceMasterID=" & POInvoiceMasterID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function getinvoceamount(ByVal POmASTERiD As Long) As DataTable
        Dim str As String
        str = " select SUM (PD.NetAmount) as NetAmount,SUM (PD.SalesTaxAmount) as SalesTaxAmount from POInvoiceMaster PM join POInvoiceDetail PD"
        str &= " ON PM.POInvoiceMasterID=PD.POInvoiceMasterID"
        str &= " WHERE PM.POInvoiceMasterID='" & POmASTERiD & "' "

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
        str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Qunatity as POQTY,"
        str &= " (isnull(YPD.Qunatity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
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
        str = "  select  YPD.ItemID,YPD.PODetailID,isnull(YRD.PORecvDetailID,0) as PORecvDetailID,"
        str &= " isnull(YRD.VehicleNo,'N/A') as VehicleNo, POM.POID,CT.ContractType,"
        str &= " isnull(Jo.JobOrderNo,'N/A') as JobOrderNo,SD.SupplierName,"
        str &= " isnull(FL.FactoryLocationID,'0') as FactoryLocationID,"
        str &= " isnull(YRD.RecvQuantity,'0') as RecvQtyinBag,YPD.Qunatity as POQTY,"
        str &= " (isnull(YPD.Qunatity ,'0')- isnull(YRD.RecvQuantity,'0')) as RemainingQty"
        str &= " ,(Select distinct Itemname from ItemProduct I where I.ItemID= YPD.ItemID) as Itemname,YPD.Quality as Quality "
        str &= " ,YPD.Rate as  PORate,POM.CreationDate from POMaster POM"
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
    Public Function BindPONO() As DataTable
        Dim str As String
        str = " select * from POMaster where   CEOApproval=1"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindPONONew() As DataTable
        Dim str As String
        str = " select PO.POID,(PO.PONO+'  JOB#: '+Isnull(Jo.JoborderNo,CT.ContractType) ) as PONO "
        str &= " from POMaster PO"
        str &= " left join Joborderdatabase JO on JO.JoborderID=PO.JoborderID "
        str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  "
        str &= " where   CEOApproval=1 order by PO.POID DESC"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindPONOBySupplier(ByVal Supplierid As Long) As DataTable
        Dim str As String
        str = " select distinct PO.PONO,PO.POID from POMaster PO join PODetail POD on POD.POID=PO.POID where AccountpayablePartyid='" & Supplierid & "' and   PO.CEOApproval=1"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindSupplierForRecPO() As DataTable
        Dim str As String
        str = " select Distinct SDB.SupplierName, SDB.SupplierDatabaseId from SupplierDatabase SDB"
        str &= " join  POMaster POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetPOdate(ByVal POID As Long) As DataTable
        Dim str As String
        str = "  select convert(varchar,CreationDate,103) as CreationDate from pomaster where     POID='" & POID & "' "
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

        Str = " select isnull(jb.Joborderno,'Open') as Joborderno,Sd.SupplierName,POM.POID,POD.PODetailID,isnull(PRM.PORecvMasterID,0) as PORecvMasterID ,"
        Str &= " isnull(PRD.PORecvDetailID,0) as PORecvDetailID ,convert(varchar,POM.CreationDate,103) as POdate,POM.PONO,IP.ItemName,"
        Str &= " isnull(POD.Qunatity,0) as POQTY,isnull(convert(varchar,PRM.PORECVDate,103),'N/A') as GPDate,"
        Str &= " isnull(PRM.GatePassNo,'N/A') as GatePassNo,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
        Str &= " isnull((isnull(POD.Qunatity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
        Str &= " from POMaster POM "
        Str &= " join PODetail POD on POd.POId=POM.POId"
        Str &= " join ItemProduct IP on IP.ItemID=POd.ItemID"
        Str &= " left join PORecvDetail PRD on PRD.PODetailID= POd.PODetailID"
        Str &= " left join PORecvMaster PRM on PRM.PORecvMasterID= PRD.PORecvMasterID and POM.POID=PRM.POID"
        Str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=PRM.SupplierId  left join Joborderdatabase jb on jb.JoborderID= POM.JoborderID"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
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

        str = " select isnull(POD.Qunatity,0) as POQTY,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
        str &= " isnull((isnull(POD.Qunatity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
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

        str = " select isnull(POD.Qunatity,0) as POQTY,isnull(PRD.RecvQuantity,0) as RecvQuantity,"
        str &= " isnull((isnull(POD.Qunatity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
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

        str = " select isnull((isnull(POD.Qunatity,0)-isnull(PRD.RecvQuantity,0) ),0) as BalanceQty"
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
    Public Function ChkPartyDCNo(ByVal PartyDCNo As String) As DataTable
        Dim str As String
        str = " select * from PORecvMaster where PartyDCNo='" & PartyDCNo & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    '------function use in Invoice Page
    Public Function GetPartyFrom(ByVal Partyid As Long) As DataTable
        Dim str As String
        str = " select  SupplierDatabaseID as SupplierID ,Name as SupplierName,Type  from TempINVParties where SupplierDatabaseID='" & Partyid & "' order by Name ASC "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindSupplierForInvoiceFromPOReceiveNew() As DataTable
        Dim str As String
        str = " select  SupplierDatabaseID as SupplierID ,Name as SupplierName,Type  from TempINVParties order by Name ASC "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindSupplierForInvoiceFromPOReceive() As DataTable
        Dim str As String
        str = " select distinct D.SupplierID ,SD.SupplierName  from PORecvDetailTwo D join SupplierDatabase SD on SD.SupplierDatabaseId =D.SupplierID "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function BindDCNOForInvoiceFromPOReceive(ByVal SupplierID As Long) As DataTable
        Dim str As String
        str = " select distinct D.PORecvMasterID,D.PartyDCNo   from PORecvMaster D join PORecvDetail DD on DD.PORecvMasterID=D.PORecvMasterID    where D.SupplierID = '" & SupplierID & "' and DD.IsCompleted=0"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindDCNOForInvoiceFromYarnReceive(ByVal SupplierID As Long) As DataTable
        Dim str As String
        str = " select distinct D.POReceiveMstID as PORecvMasterID,D.DCNo   from DPPOReceiveMst D join DPPOReceiveDtl DD on DD.POReceiveMstID=D.POReceiveMstID    where D.SupplierID = '" & SupplierID & "' and DD.IsCompleted=0 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetPodetailNew(ByVal PORecvMasterID As Long, ByVal SupplierID As Long) As DataTable
        Dim str As String


        str = "   select  PORD.RecvQuantity,'0' as POInvoiceDetailID,IT.IMSItemID,PP.PartyDCNo,IT.ItemCodeE,IT.ItemName, "
        str &= " (PORD.RecvQuantity-isnull(PORD.InvoiceQty,0)) as TotalQTY  ,POD.Weight,POD.Rate, "
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)) as GrossAmount, POD.DiscPercent, "
        str &= " ((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as DiscAmount, "
        str &= " (((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull"
        str &= " (PORD.InvoiceQty,0))* (POD.Rate))) as ValExcloudSalesTax, POD.SalesTaxPercentage, ((((POD.SalesTaxPercentage)*"
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as SalesTaxAmount, ((((((POD.DiscPercent)*"
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* "
        str &= " (POD.Rate)))+ ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))) as "
        str &= " NetAmount, POD.PODetailID,PORD.PODetailID,PORD.PORecvDetailID, PORD.PORecvMasterID,isnull(PORD.InvoiceQty,0) as PreInvoiceQty "
        str &= " ,POM.PONO ,convert(varchar,PP.PORecvDate,103) as DCDate from  POMaster POM join PODetail POD  On POD.POID=POM.POID   "
        str &= " join ImsItem IT ON IT.IMSItemID=POD.ItemID  "
        str &= " JOIN PORecvMaster PP on PP.POID=POM.POID and PP.POID=POD.POID"
        str &= " join PORecvDetail PORD on PORD.PORecvMasterID =PP.PORecvMasterID  "
        str &= " where PORD.PORecvMasterID = '" & PORecvMasterID & "' And PP.SupplierID = '" & SupplierID & "' and PORD.IsCompleted=0 "


        'str = "   select  PORD.RecvQuantity,'0' as POInvoiceDetailID,IT.ItemID,PORD.PartyDCNo,IT.ItemCode,IT.ItemName,"
        'str &= " (PORD.RecvQuantity-isnull(PORD.InvoiceQty,0)) as TotalQTY  ,POD.Weight,POD.Rate,"
        'str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)) as GrossAmount,"
        'str &= " POD.DiscPercent,"
        'str &= " ((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as DiscAmount,"
        'str &= " (((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate))) as ValExcloudSalesTax,"
        'str &= " POD.SalesTaxPercentage,"
        'str &= " ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as SalesTaxAmount,"
        'str &= " ((((((POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))+ ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))) as NetAmount,"
        'str &= " POD.PODetailID,PORD.PORecvDetailTwoID,"
        'str &= " PORD.PORecvMasterID,isnull(PORD.InvoiceQty,0) as PreInvoiceQty"
        'str &= " ,POM.PONO ,convert(varchar,PP.PORecvDate,103) as DCDate from  POMaster POM"
        'str &= " join PODetail POD  On POD.POID=POM.POID  "
        'str &= " join ItemProduct IT ON IT.ItemID=POD.ItemID "
        'str &= " join PORecvDetailTwo PORD on PORD.PODetailID =POD.PoDetailId  "
        'str &= " and PORD.POID=POM.POID  join PORecvMaster PP on PP.PORecvMasterID=PORD.PORecvMasterID"
        'str &= "  where PORD.PORecvMasterID = '" & PORecvMasterID & "'And PORD.SupplierID = '" & SupplierID & "' and PORD.IsCompleted=0 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPodetailNewNew(ByVal POID As Long, ByVal SupplierID As Long) As DataTable
        Dim str As String


        str = "   select  PORD.RecvQuantity,'0' as POInvoiceDetailID,IT.IMSItemID,PP.PartyDCNo,IT.ItemCodeE,IT.ItemName, "
        str &= " (PORD.RecvQuantity-isnull(PORD.InvoiceQty,0)) as TotalQTY  ,POD.Weight,POD.Rate, "
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)) as GrossAmount, POD.DiscPercent, "
        str &= " ((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as DiscAmount, "
        str &= " (((( (POD.DiscPercent)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull"
        str &= " (PORD.InvoiceQty,0))* (POD.Rate))) as ValExcloudSalesTax, POD.SalesTaxPercentage, ((((POD.SalesTaxPercentage)*"
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as SalesTaxAmount, ((((((POD.DiscPercent)*"
        str &= " ((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* "
        str &= " (POD.Rate)))+ ((((POD.SalesTaxPercentage)*((PORD.RecvQuantity-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))) as "
        str &= " NetAmount, POD.PODetailID,PORD.PODetailID,PORD.PORecvDetailID, PORD.PORecvMasterID,isnull(PORD.InvoiceQty,0) as PreInvoiceQty "
        str &= " ,POM.PONO ,convert(varchar,PP.PORecvDate,103) as DCDate from  POMaster POM join PODetail POD  On POD.POID=POM.POID   "
        str &= " join ImsItem IT ON IT.IMSItemID=POD.ItemID  "
        str &= " where POM.POID = '" & POID & "' And PP.SupplierID = '" & SupplierID & "' and PORD.IsCompleted=0 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetYarnRecvdetailNew(ByVal PORecvMasterID As Long, ByVal SupplierID As Long) As DataTable
        Dim str As String

        str = "     select  PORD.ReceivedNetWeightKg as RecvQuantity,'0' as POInvoiceDetailID,IT.YarnDatabaseID as ItemID"
        str &= "  ,PP.PartyDCNo,IT.YarnCode as ItemCode,IT.YarnCount as ItemName,"
        str &= "   (PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0)) as TotalQTY  ,POD.KG as Weight,POD.Rate,"
        str &= "   ((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)) as GrossAmount,"
        str &= "    '0' as DiscPercent,"
        str &= "   ((( ('0')*((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as DiscAmount,"
        str &= "   (((( ('0')*((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate))) as ValExcloudSalesTax,"
        str &= "   '0' as SalesTaxPercentage,"
        str &= "    (((('0')*((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100)) as SalesTaxAmount,"
        str &= "    (((((('0')*((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))+((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))+ (((('0')*((PORD.ReceivedNetWeightKg-isnull(PORD.InvoiceQty,0))* (POD.Rate)))/100))) as NetAmount,"
        str &= "     POD.tblyarnPurchaseContractdetailID as PODetailID"
        str &= "  , PORD.YarnRecvDetailID as PORecvDetailTwoID,"
        str &= "     PORD.YarnRecvMasterID as PORecvMasterID,isnull(PORD.InvoiceQty,0) as PreInvoiceQty"
        str &= "   , POM.ContractNo as PONO ,convert(varchar,PP.YarnRecvDate,103) as DCDate"
        str &= "   from  tblyarnPurchaseContractMaster POM"
        str &= "    join tblyarnPurchaseContractdetail POD  On POD.tblyarnPurchaseContractMasterID=POM.tblyarnPurchaseContractMasterID  "
        str &= "     join YarnDatabase IT ON IT.YarnDatabaseID=POD.YarnDatabaseID "
        str &= "    join YarnRecvDetail PORD on PORD.tblyarnPurchaseContractdetailID =POD.tblyarnPurchaseContractdetailID  "
        str &= "    join YarnRecvMaster PP on PP.YarnRecvMasterID=PORD.YarnRecvMasterID"
        str &= "    where PORD.YarnRecvMasterID = '" & PORecvMasterID & "' And PP.SupplierID = '" & SupplierID & "' And PORD.IsCompleted = 0 "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function ChkInvoiceDuplication(ByVal SaleTaxInvoiceNo As String) As DataTable
        Dim str As String
        str = " select *  from POInvoiceMst    where SaleTaxInvoiceNo = '" & SaleTaxInvoiceNo & "'  "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function InsertPORecvParty()
        Dim str As String = "  insert into TempINVParties select distinct SD.SupplierDatabaseID as SupplierDatabaseID ,SD.SupplierName as Name "
        str &= " ,'PORECEIVE' as Type   from SupplierDatabase SD "
        'str &= " join PORecvMaster D on SD.SupplierDatabaseId =D.SupplierID "

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertYarnRecvParty()
        Dim str As String = " insert into TempINVParties select distinct SD.SupplierDatabaseID as SupplierDatabaseID ,SD.SupplierName as Name "
        str &= " ,'RNDPORECEIVE' as Type   from SupplierDatabase SD "
        str &= " join DPPOReceiveMst YR on YR.SupplierId =SD.SupplierDatabaseId "

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempINVPartiesTable()
        Dim str As String = "TRUNCATE TABLE  TempINVParties"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function

End Class


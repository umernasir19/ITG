Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PODetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PODetail"
            m_strPrimaryFieldName = "PoDetailId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
        End Sub
        Private m_lPoDetailId As Long
        Private m_lPOID As Long
        Private m_lItemId As String
        Private m_strQuality As String
        Private m_dQuantity As Decimal
        Private m_dWeight As Decimal
        Private m_dRate As Decimal
        Private m_dGrossAmount As Decimal
        Private m_dDiscPercent As Decimal
        Private m_dDiscAmount As Decimal
        Private m_dValExcloudSalesTax As Decimal
        Private m_dSalesTaxPercentage As Decimal
        Private m_dSalesTaxAmount As Decimal
        Private m_dNetAmount As Decimal
        Private m_dInvoiceQTY As Decimal
        Private m_strColor As String
        Private m_strSize As String
        Private m_strPartyAccount As String
        Private m_lAccountPayablePartyID As Long
        Private m_lProductTypeId As Long
        Private m_lUOMID As Long
        Private m_strStyle As String
        Private m_strProductType As String
        Private m_lCurrencyId As Long
        Private m_strCurrency As String
        Private m_dcExchangeRate As Decimal
        Private m_lJoborderID As Long
        Private m_lSeasonDatabaseID As Long
        Private m_dcFreshQty As Decimal
        Private m_dcBQualityQty As Decimal

        Private m_dtDeliveryDate As Date
        Private m_dClearanceCharges As Decimal
        Private m_strRemarks As String
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property ClearanceCharges() As Decimal
            Get
                ClearanceCharges = m_dClearanceCharges
            End Get
            Set(ByVal Value As Decimal)
                m_dClearanceCharges = Value
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
        Public Property DeliveryDate() As Date
            Get
                DeliveryDate = m_dtDeliveryDate
            End Get
            Set(ByVal Value As Date)
                m_dtDeliveryDate = Value
            End Set
        End Property
      
        Public Property FreshQty() As Decimal
            Get
                FreshQty = m_dcFreshQty
            End Get
            Set(ByVal Value As Decimal)
                m_dcFreshQty = Value
            End Set
        End Property
        Public Property BQualityQty() As Decimal
            Get
                BQualityQty = m_dcBQualityQty
            End Get
            Set(ByVal Value As Decimal)
                m_dcBQualityQty = Value
            End Set
        End Property
        Public Property JoborderID() As Long
            Get
                JoborderID = m_lJoborderID
            End Get
            Set(ByVal Value As Long)
                m_lJoborderID = Value
            End Set
        End Property
        Public Property ExchangeRate() As Decimal
            Get
                ExchangeRate = m_dcExchangeRate
            End Get
            Set(ByVal Value As Decimal)
                m_dcExchangeRate = Value
            End Set
        End Property
        Public Property CurrencyId() As Long
            Get
                CurrencyId = m_lCurrencyId
            End Get
            Set(ByVal Value As Long)
                m_lCurrencyId = Value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal Value As String)
                m_strCurrency = Value
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

        Public Property PoDetailId() As Long
            Get
                PoDetailId = m_lPoDetailId
            End Get
            Set(ByVal Value As Long)
                m_lPoDetailId = Value
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
        Public Property ItemId() As Long
            Get
                ItemId = m_lItemId
            End Get
            Set(ByVal Value As Long)
                m_lItemId = Value
            End Set
        End Property
        Public Property Quality() As String
            Get
                Quality = m_strQuality
            End Get
            Set(ByVal Value As String)
                m_strQuality = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_dQuantity = Value
            End Set
        End Property
        Public Property Weight() As Decimal
            Get
                Weight = m_dWeight
            End Get
            Set(ByVal Value As Decimal)
                m_dWeight = Value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dRate
            End Get
            Set(ByVal Value As Decimal)
                m_dRate = Value
            End Set
        End Property
        Public Property GrossAmount() As Decimal
            Get
                GrossAmount = m_dGrossAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dGrossAmount = Value
            End Set
        End Property
        Public Property DiscPercent() As Decimal
            Get
                DiscPercent = m_dDiscPercent
            End Get
            Set(ByVal Value As Decimal)
                m_dDiscPercent = Value
            End Set
        End Property
        Public Property DiscAmount() As Decimal
            Get
                DiscAmount = m_dDiscAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dDiscAmount = Value
            End Set
        End Property
        Public Property ValExcloudSalesTax() As Decimal
            Get
                ValExcloudSalesTax = m_dValExcloudSalesTax
            End Get
            Set(ByVal Value As Decimal)
                m_dValExcloudSalesTax = Value
            End Set
        End Property
        Public Property SalesTaxPercentage() As Decimal
            Get
                SalesTaxPercentage = m_dSalesTaxPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_dSalesTaxPercentage = Value
            End Set
        End Property
        Public Property SalesTaxAmount() As Decimal
            Get
                SalesTaxAmount = m_dSalesTaxAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dSalesTaxAmount = Value
            End Set
        End Property
        Public Property NetAmount() As Decimal
            Get
                NetAmount = m_dNetAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dNetAmount = Value
            End Set
        End Property
        Public Property InvoiceQTY() As Decimal
            Get
                InvoiceQTY = m_dInvoiceQTY
            End Get
            Set(ByVal Value As Decimal)
                m_dInvoiceQTY = Value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal Value As String)
                m_strColor = Value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal Value As String)
                m_strSize = Value
            End Set
        End Property
        Public Property PartyAccount() As String
            Get
                PartyAccount = m_strPartyAccount
            End Get
            Set(ByVal Value As String)
                m_strPartyAccount = Value
            End Set
        End Property
        Public Property AccountPayablePartyID() As Long
            Get
                AccountPayablePartyID = m_lAccountPayablePartyID
            End Get
            Set(ByVal Value As Long)
                m_lAccountPayablePartyID = Value
            End Set
        End Property
        Public Property ProductTypeId() As Long
            Get
                ProductTypeId = m_lProductTypeId
            End Get
            Set(ByVal Value As Long)
                m_lProductTypeId = Value
            End Set
        End Property
        Public Property UOMID() As Long
            Get
                UOMID = m_lUOMID
            End Get
            Set(ByVal Value As Long)
                m_lUOMID = Value
            End Set
        End Property
        Public Property ProductType() As String
            Get
                ProductType = m_strProductType
            End Get
            Set(ByVal Value As String)
                m_strProductType = Value
            End Set
        End Property


        Public Function SavePODetail()
            Try
                MyBase.Save()
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

        Public Function GetStleFromGodownOpeningDtl(ByVal Name As String, ByVal Item As String)
            Dim str As String

            str = " select PartyAccount from PODetail POD join ImsItem IM on IM.IMSItemID=POD.ItemID "
            str &= " where IM.ItemName='" & Item & "' and POD.PartyAccount like '%" & Name & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyAccountFromPODetail(ByVal Name As String)
            Dim str As String
            str = " select distinct PartyAccount from PODetail where PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntryPONOForAstore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM where POM.FabricPOrder=0 and GStoreStatus=0 and POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentViewNumberingno(ByVal Name As String)
            Dim str As String

            str = " select distinct NumberingNo AS NAME from Numbering  where NumberingNo  like '%" & Name & "%'  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentViewSeason(ByVal Name As String)
            Dim str As String

            str = " select distinct sd.SeasonName  AS NAME from NumberingDtl dtl "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where sd.SeasonName  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentViewCustomer(ByVal Name As String)
            Dim str As String

            str = " select distinct sd.CustomerName   AS NAME from NumberingDtl dtl "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "
            str &= " join Customer  sd on sd.CustomerID =jo.CustomerDatabaseID  "
            str &= " where sd.CustomerName  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentViewSrNo(ByVal Name As String)
            Dim str As String

            str = " select distinct jo.srno   AS NAME from NumberingDtl dtl "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "
            str &= " where jo.srno  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentViewBrand(ByVal Name As String)
            Dim str As String

            str = " select distinct bd.Brand   AS NAME from NumberingDtl dtl "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "
            str &= " join BrandDatabase bd ON bd.BrandDatabaseID =jo.BrandDatabaseID"
            str &= " where bd.Brand  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntryPONOForAstoreGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM where POM.GStoreStatus=1 and POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntryPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessEntryPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from ProcessOrderMst POM where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessEntrySupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PartyAccount AS NAME from ProcessOrderDtl POM where POM.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntrySupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PartyAccount AS NAME from PODetail POM where POM.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntrySupplierForAstore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PartyAccount AS NAME from PODetail POM join POMaster POD on POD.POID=POM.POID where POD.FabricPOrder=0 and POD.GStoreStatus=0 and POM.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoEntrySupplierForAstoreGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PartyAccount AS NAME from PODetail POM join POMaster POD on POD.POID=POM.POID where POD.GStoreStatus=1 and POM.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM "
            str &= " join IssueMst PRD ON PRD.POID=POM.POID "
            str &= " where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessissuePONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from ProcessOrderMst POM join processIssueMst PRD ON PRD.ProcessOrderMstID=POM.ProcessOrderMstID where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoissuePONOForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join IssueDetail PRD ON PRD.POID=POM.POID where POM.FabricPOrder=0 and POM.GStoreStatus=0 and POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoissuePONOForAccGSTore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join IssueDetail PRD ON PRD.POID=POM.POID where POM.GStoreStatus=1 and POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoissuePONOForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join IssueDetail PRD ON PRD.POID=POM.POID where  POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoissuePONOForAutitor(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join IssueDetail PRD ON PRD.POID=POM.POID where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoissuePONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join IssueDetail PRD ON PRD.POID=POM.POID where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessRecevPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from ProcessOrderMst POM join POProcessRecvMaster PRD ON PRD.ProcessOrderMstID=POM.ProcessOrderMstID where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSivNo(ByVal Name As String)
            Dim str As String

            str = " select distinct SIVNO AS NAME from IMSGodownIssue where SIVNO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSivNoForProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct SIVNO AS NAME from IMSGodownIssueForProcess where SIVNO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemCodeForGodownSearching(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.ItemCodee AS NAME from IMSGodownIssueDetail Dtl join IMSItem IM on IM.ImsItemID=Dtl.ImsItemID where IM.ItemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemCodeForGodownSearchingForProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.ItemCodee AS NAME from IMSGodownIssueDetailForProcess Dtl join IMSItem IM on IM.ImsItemID=Dtl.ImsItemID where IM.ItemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFromLocationForGodownSearching(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.Location AS NAME from IMSGodownIssueDetail Dtl join Location IM on IM.LocationID=Dtl.FromLocationID where IM.Location like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFromLocationForGodownSearchingForProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.Location AS NAME from IMSGodownIssueDetailForProcess Dtl join Location IM on IM.LocationID=Dtl.FromLocationID where IM.Location like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetToLocationForGodownSearching(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.Location AS NAME from IMSGodownIssueDetail Dtl join Location IM on IM.LocationID=Dtl.ToLocationID where IM.Location like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetToLocationForGodownSearchingForProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct IM.Location AS NAME from IMSGodownIssueDetailForProcess Dtl join Location IM on IM.LocationID=Dtl.ToLocationID where IM.Location like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join PORecvMaster PRD ON PRD.POID=POM.POID where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevPONOForAuditor(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join PORecvMaster PRD ON PRD.POID=POM.POID where  POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevPONOForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join PORecvMaster PRD ON PRD.POID=POM.POID where  POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevPONOForACC(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join PORecvMaster PRD ON PRD.POID=POM.POID where POM.FabricPOrder =0 and POM.GStoreStatus=0 AND POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevPONOForACCGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM join PORecvMaster PRD ON PRD.POID=POM.POID where  POM.GStoreStatus=1 AND POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessStatusPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from ProcessOrderMst POM  where POM.PONO like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusPONO(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM  where  POM.PONO  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusPONOForall(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM  where  POM.PONO  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusPONOForaCC(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM  where FabricPOrder =0 and POM.GStoreStatus=0 and POM.PONO  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusPONOForaCCGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct POM.PONO AS NAME from POMaster POM  where  POM.GStoreStatus=1 and POM.PONO  like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessStatusItem(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemCodee as Name "
            str &= " from ProcessOrderMst POM "
            str &= " join ProcessOrderDtl POD on POM.ProcessOrderMstID=POD.ProcessOrderMstID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId   "
            str &= "  where IMST.ItemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetPoStatusItemForAll(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetPoStatusItemForACC(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where FabricPOrder =0 and POM.GStoreStatus=0 AND IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetPoStatusItemForACCGStore(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where POM.GStoreStatus=1 AND IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetPoStatusItem(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetPoIssueDepartment(ByVal Name As String)
            Dim str As String

            str = "  select  distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') as Name "
            str &= " from IssueDetail POM "
            str &= "  left join IMSDepartmentDataBase idd on idd.DeptDatabaseId =POM.DeptDatabaseID"
            str &= "  where (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessRecevItem(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from ProcessOrderMst POM "
            str &= " join ProcessOrderDtl POD on POM.ProcessOrderMstID=POD.ProcessOrderMstID  "
            str &= " join POProcessRecvMaster PRD on PRD.ProcessOrderMstID=POM.ProcessOrderMstID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ProcessItemNameId   "
            str &= "  where IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevItemForAuditor(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= " join PORecvMaster PRD on PRD.POID=POM.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevItemForAll(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= " join PORecvMaster PRD on PRD.POID=POM.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where  IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevItemForAcc(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= " join PORecvMaster PRD on PRD.POID=POM.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where POM.FabricPOrder =0 and POM.GStoreStatus=0 and IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevItemForAccGStore(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= " join PORecvMaster PRD on PRD.POID=POM.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where POM.GStoreStatus=1 and IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevItem(ByVal Name As String)
            Dim str As String

            str = "  select  distinct IMST.ItemName as Name "
            str &= " from POMaster POM "
            str &= " join PODetail POD on POM.POID=POD.POID  "
            str &= " join PORecvMaster PRD on PRD.POID=POM.POID  "
            str &= "  JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId   "
            str &= "  where IMST.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessStatusSupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from ProcessOrderDtl Dtl  where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusSupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl  where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusSupplierForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join POMaster Pom on pom.POID =Dtl.POID where  Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusSupplierForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join POMaster Pom on pom.POID =Dtl.POID where Pom.FabricPOrder =0 and pom.GStoreStatus=0 and Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusSupplierForAccGstore(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join POMaster Pom on pom.POID =Dtl.POID where pom.GStoreStatus=1 and Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingdeopartmentWiseProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') AS NAME from processIssueMst Mst join processIssueDetail Dtl on Dtl.processIssueID=Mst.processIssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =Dtl .DeptDatabaseID"
            str &= " where (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingdeopartmentWiseForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =Dtl .DeptDatabaseID"
            str &= " where (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingdeopartmentWiseForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =Dtl .DeptDatabaseID"
            str &= " where po.FabricPOrder=0 and po.GStoreStatus=0 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingdeopartmentWiseForAccGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =Dtl .DeptDatabaseID"
            str &= " where po.GStoreStatus=1 and (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingdeopartmentWise(ByVal Name As String)
            Dim str As String

            str = " select distinct (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= " left join IMSDepartmentDataBase idd on idd .DeptDatabaseId =Dtl .DeptDatabaseID"
            str &= " where (Idd.DeptDatabaseName + '(' + idd.DeptAbbrivation+ ')') like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingProcess(ByVal Name As String)
            Dim str As String

            str = " select distinct IMS.itemCodee AS NAME from processIssueMst Mst join processIssueDetail Dtl on Dtl.processIssueID=Mst.processIssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= " where IMS.itemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct IMS.itemCodee AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " where  IMS.itemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct IMS.itemCodee AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " where po.FabricPOrder=0 and po.GStoreStatus=0 and IMS.itemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearchingForAccGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct IMS.itemCodee AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= "  join POMASTER PO on PO.POID=Dtl.POID"
            str &= " where po.GStoreStatus=1 and IMS.itemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssuedFabricCodeviseSearching(ByVal Name As String)
            Dim str As String

            str = " select distinct IMS.itemCodee AS NAME from IssueMst Mst join IssueDetail Dtl on Dtl.IssueID=Mst.IssueID"
            str &= " join IMSITEM IMS on IMS.IMSITEMID=Dtl.ItemId"
            str &= " where IMS.itemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessRecevSupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from ProcessOrderDtl Dtl join POProcessRecvMaster PRD on PRD.ProcessOrderMstID=Dtl.ProcessOrderMstID where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevSupplier(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevSupplierForAuditor(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevSupplierForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevSupplierForACC(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where POMM.FabricPOrder =0 and POMM.GStoreStatus=0 AND Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevSupplierForACCGstore(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.PartyAccount AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where  POMM.GStoreStatus=1 AND Dtl.PartyAccount like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessStatusStyle(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from ProcessOrderDtl Dtl  where Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusStyle(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl  where Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusStyleForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join POMaster Pom on Pom.POID =Dtl.POID where  Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusStyleForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join POMaster Pom on Pom.POID =Dtl.POID where Pom.FabricPOrder =0 and pom.GStoreStatus=0 and Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoStatusStyleForAccGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join POMaster Pom on Pom.POID =Dtl.POID where  pom.GStoreStatus=1 and Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedFabricCode(ByVal Name As String)
            Dim str As String

            str = " select distinct ITM.ItemCodee AS NAME from IssueDetail Dtl "
            str &= " join IMSItem ITM on ITM.IMSItemID=Dtl.ItemID   "
            str &= " where ITM.ItemCodee like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedMaunalChalanNo(ByVal Name As String)
            Dim str As String

            str = " select distinct ManualChallanNo AS NAME from IssueMst  "
            str &= " where ManualChallanNo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessIssuedManualChallanNo(ByVal Name As String)
            Dim str As String

            str = " select distinct ManualChallanNo AS NAME from processIssueMst  where ManualChallanNo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedManualChallanNoForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct mST.ManualChallanNo AS NAME from IssueMst mST    where  mST.ManualChallanNo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedManualChallanNoForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct mST.ManualChallanNo AS NAME from IssueMst mST    where  mST.ManualChallanNo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoIssuedManualChallanNo(ByVal Name As String)
            Dim str As String

            str = " select distinct ManualChallanNo AS NAME from IssueMst  where ManualChallanNo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessRecevStyle(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from ProcessOrderDtl Dtl join POProcessRecvMaster PRD on PRD.ProcessOrderMstID=Dtl.ProcessOrderMstID where Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevStyle(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid where Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevStyleForAuditor(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevStyleForAll(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where  Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevStyleForAcc(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where POMM.FabricPOrder =0  AND POMM.GStoreStatus=0  and Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPoRecevStyleForAccGStore(ByVal Name As String)
            Dim str As String

            str = " select distinct Dtl.Style AS NAME from PODetail Dtl join PORecvMaster PRD on PRD.POID=Dtl.poid join Pomaster POMM on POMM.POID=PRD.POID where POMM.GStoreStatus=1  and Dtl.Style like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFromPODetail(ByVal Name As String)
            Dim str As String
            str = " select distinct IM.ItemName from PODetail POD join ImsItem IM on IM.IMSItemID=POD.ItemID "
            str &= " where IM.ItemName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOFromPOMaster(ByVal Name As String)
            Dim str As String
            str = " select distinct PONo from POMaster  where PONo like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccFromPOMaster(ByVal Name As String)
            Dim str As String
            str = " select distinct AccessoriesName from Accessories  where AccessoriesName like '%" & Name & "%' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

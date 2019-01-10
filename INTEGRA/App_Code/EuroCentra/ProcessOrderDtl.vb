Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class ProcessOrderDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ProcessOrderDtl"
            m_strPrimaryFieldName = "ProcessOrderDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
        End Sub
        Private m_lProcessOrderDtlID As Long
        Private m_lProcessOrderMstID As Long
        Private m_lDeptDatabaseId As Long
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
        Private m_lIssueTypeID As Long
        Private m_lProcessItemCodeID As Long
        Private m_lProcessItemTypeID As Long
        Private m_lProcessItemNameID As Long
        Private m_strProcessQuality As String
        Private m_strProcessShade As String
        Private m_dProcessQuantity As Decimal
        Private m_dProcessSalesTax As Decimal
        Private m_lSRNoID As Long
        Private m_dFreshQty As Decimal
        Private m_dBQualityQty As Decimal
        Private m_dPORate As Decimal
        Private m_dtDeliveryDate As Date
        Private m_strRemarks As String
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property PORate() As Decimal
            Get
                PORate = m_dPORate
            End Get
            Set(ByVal Value As Decimal)
                m_dPORate = Value
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
                FreshQty = m_dFreshQty
            End Get
            Set(ByVal Value As Decimal)
                m_dFreshQty = Value
            End Set
        End Property
        Public Property BQualityQty() As Decimal
            Get
                BQualityQty = m_dBQualityQty
            End Get
            Set(ByVal Value As Decimal)
                m_dBQualityQty = Value
            End Set
        End Property

        Public Property SRNoID() As Long
            Get
                SRNoID = m_lSRNoID
            End Get
            Set(ByVal Value As Long)
                m_lSRNoID = Value
            End Set
        End Property
        Public Property ProcessItemCodeID() As Long
            Get
                ProcessItemCodeID = m_lProcessItemCodeID
            End Get
            Set(ByVal Value As Long)
                m_lProcessItemCodeID = Value
            End Set
        End Property
        Public Property ProcessItemTypeID() As Long
            Get
                ProcessItemTypeID = m_lProcessItemTypeID
            End Get
            Set(ByVal Value As Long)
                m_lProcessItemTypeID = Value
            End Set
        End Property
        Public Property ProcessItemNameID() As Long
            Get
                ProcessItemNameID = m_lProcessItemNameID
            End Get
            Set(ByVal Value As Long)
                m_lProcessItemNameID = Value
            End Set
        End Property
        Public Property ProcessQuality() As String
            Get
                ProcessQuality = m_strProcessQuality
            End Get
            Set(ByVal Value As String)
                m_strProcessQuality = Value
            End Set
        End Property
        Public Property ProcessShade() As String
            Get
                ProcessShade = m_strProcessShade
            End Get
            Set(ByVal Value As String)
                m_strProcessShade = Value
            End Set
        End Property
        Public Property ProcessQuantity() As Decimal
            Get
                ProcessQuantity = m_dProcessQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_dProcessQuantity = Value
            End Set
        End Property
        Public Property ProcessSalesTax() As Decimal
            Get
                ProcessSalesTax = m_dProcessSalesTax
            End Get
            Set(ByVal Value As Decimal)
                m_dProcessSalesTax = Value
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

        Public Property ProcessOrderDtlID() As Long
            Get
                ProcessOrderDtlID = m_lProcessOrderDtlID
            End Get
            Set(ByVal Value As Long)
                m_lProcessOrderDtlID = Value
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
        Public Property DeptDatabaseId() As Long
            Get
                DeptDatabaseId = m_lDeptDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lDeptDatabaseId = Value
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
        Public Property IssueTypeID() As Long
            Get
                IssueTypeID = m_lIssueTypeID
            End Get
            Set(ByVal Value As Long)
                m_lIssueTypeID = Value
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


        Public Function SaveProcessOrderDtl()
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



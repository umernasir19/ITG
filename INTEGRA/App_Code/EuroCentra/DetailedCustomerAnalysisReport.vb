Imports Integra.EuroCentra
Imports System.Data
Public Class DetailedCustomerAnalysisReport
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "DetailedCustomerAnalysisReport"
        m_strPrimaryFieldName = "DCARID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lDCARID As Long
    Private m_dtCreationDate As Date
    Private m_lCustomerID As Long
    Private m_strCustomerName As String
    Private m_lSupplierID As Long
    Private m_strSupplierName As String
    Private m_dcBookedInQuantity As Decimal
    Private m_dcBookedForQuantity As Decimal
    Private m_dcShippedQuantity As Decimal
    Private m_dcShippedQtyOnTime As Decimal
    Private m_dcBookedInPos As Decimal
    Private m_dcBookedForPos As Decimal
    Private m_dcTotalShippedPos As Decimal
    Private m_dcShippedPosOnTime As Decimal
    Private m_dcBalanceToGoPos As Decimal
    Private m_dcBookedInTurnOver As Decimal
    Private m_dcBookedForTurnOver As Decimal
    Private m_dcShippedTurnOver As Decimal
    Private m_dcShippedTurnOverOnTime As Decimal
    Private m_dcBTGTurnover As Decimal
    Private m_dcBookedCommission As Decimal
    Private m_dcShippedCommission As Decimal
    Private m_dcDeliveryPerformance As Decimal
    Private m_dcProductionPerformance As Decimal
    Private m_dcQualityPerformance As Decimal
    Private m_dcBalanceToGoQty As Decimal
    '--------------------------------------
    Public Property DCARID() As Long
        Get
            DCARID = m_lDCARID
        End Get
        Set(ByVal value As Long)
            m_lDCARID = value
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
    Public Property CustomerID() As Long
        Get
            CustomerID = m_lCustomerID
        End Get
        Set(ByVal value As Long)
            m_lCustomerID = value
        End Set
    End Property
    Public Property CustomerName() As String
        Get
            CustomerName = m_strCustomerName
        End Get
        Set(ByVal value As String)
            m_strCustomerName = value
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
    Public Property SupplierName() As String
        Get
            SupplierName = m_strSupplierName
        End Get
        Set(ByVal value As String)
            m_strSupplierName = value
        End Set
    End Property
    Public Property BookedInQuantity() As Decimal
        Get
            BookedInQuantity = m_dcBookedInQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedInQuantity = value
        End Set
    End Property
    Public Property BookedForQuantity() As Decimal
        Get
            BookedForQuantity = m_dcBookedForQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedForQuantity = value
        End Set
    End Property
    Public Property ShippedQuantity() As Decimal
        Get
            ShippedQuantity = m_dcShippedQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedQuantity = value
        End Set
    End Property
    Public Property ShippedQtyOnTime() As Decimal
        Get
            ShippedQtyOnTime = m_dcShippedQtyOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedQtyOnTime = value
        End Set
    End Property
    Public Property BookedInPos() As Decimal
        Get
            BookedInPos = m_dcBookedInPos
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedInPos = value
        End Set
    End Property
    Public Property BookedForPos() As Decimal
        Get
            BookedForPos = m_dcBookedForPos
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedForPos = value
        End Set
    End Property
    Public Property TotalShippedPos() As Decimal
        Get
            TotalShippedPos = m_dcTotalShippedPos
        End Get
        Set(ByVal value As Decimal)
            m_dcTotalShippedPos = value
        End Set
    End Property
    Public Property ShippedPosOnTime() As Decimal
        Get
            ShippedPosOnTime = m_dcShippedPosOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedPosOnTime = value
        End Set
    End Property
    Public Property BalanceToGoPos() As Decimal
        Get
            BalanceToGoPos = m_dcBalanceToGoPos
        End Get
        Set(ByVal value As Decimal)
            m_dcBalanceToGoPos = value
        End Set
    End Property
    Public Property BookedInTurnOver() As Decimal
        Get
            BookedInTurnOver = m_dcBookedInTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedInTurnOver = value
        End Set
    End Property
    Public Property BookedForTurnOver() As Decimal
        Get
            BookedForTurnOver = m_dcBookedForTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedForTurnOver = value
        End Set
    End Property
    Public Property ShippedTurnOver() As Decimal
        Get
            ShippedTurnOver = m_dcShippedTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedTurnOver = value
        End Set
    End Property
    Public Property ShippedTurnOverOnTime() As Decimal
        Get
            ShippedTurnOverOnTime = m_dcShippedTurnOverOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedTurnOverOnTime = value
        End Set
    End Property
    Public Property BTGTurnover() As Decimal
        Get
            BTGTurnover = m_dcBTGTurnover
        End Get
        Set(ByVal value As Decimal)
            m_dcBTGTurnover = value
        End Set
    End Property
    Public Property BookedCommission() As Decimal
        Get
            BookedCommission = m_dcBookedCommission
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedCommission = value
        End Set
    End Property
    Public Property ShippedCommission() As Decimal
        Get
            ShippedCommission = m_dcShippedCommission
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedCommission = value
        End Set
    End Property
    Public Property DeliveryPerformance() As Decimal
        Get
            DeliveryPerformance = m_dcDeliveryPerformance
        End Get
        Set(ByVal value As Decimal)
            m_dcDeliveryPerformance = value
        End Set
    End Property
    Public Property ProductionPerformance() As Decimal
        Get
            ProductionPerformance = m_dcProductionPerformance
        End Get
        Set(ByVal value As Decimal)
            m_dcProductionPerformance = value
        End Set
    End Property
    Public Property QualityPerformance() As Decimal
        Get
            QualityPerformance = m_dcQualityPerformance
        End Get
        Set(ByVal value As Decimal)
            m_dcQualityPerformance = value
        End Set
    End Property
    Public Property BalanceToGoQty() As Decimal
        Get
            BalanceToGoQty = m_dcBalanceToGoQty
        End Get
        Set(ByVal value As Decimal)
            m_dcBalanceToGoQty = value
        End Set
    End Property

    '--------------------------------------------------------------
    Public Function SaveDetailedCustomerAnalysisReport()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTable()
        Dim str As String
        str = "  truncate table DetailedCustomerAnalysisReport"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetSupplierData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
        Dim Str As String
        Str = "  select Distinct  V.venderlibraryid ,V.VenderName from vender V "
        Str &= " join Purchaseorder Po on Po.SupplierID= V.venderlibraryid"
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
        Str &= " order by      V.VenderName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetCustomerData(ByVal FromDate As Date, ByVal ToDate As Date)
        Dim Str As String
        Str = " select Distinct  c.CustomerID ,c.CustomerName, C.Commission from Customer C "
        Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID"
        Str &= "  where Year(PO.creationDate) >= 2012 "
        Str &= " order by     c.CustomerName ASC"
      
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetBookedInQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((POD.Quantity)),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.PlacementDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetBookedForQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((POD.Quantity)),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetShippedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((cd.quantity)),0)  as ShippedQty "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
        Str &= " And PO.SupplierID = '" & SupplierID & "'  "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetBookedInPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.PlacementDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' "
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' "
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTotalShippedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' "
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BookeedInTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long) As DataTable
        Dim Str As String
        Str = "Select PO.EkNumber, PO.ExchangeRate,  "
        Str &= "  (case when PO.Currency <> 'Dollar' then"
        Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
        Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " where po.PlacementDate between '" & FromDate & "' and '" & ToDate & "'  and po.status !='Cancel' And Po.CustomerID ='" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BookeedForTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long) As DataTable
        Dim Str As String
        Str = "Select PO.EkNumber, PO.ExchangeRate,  "
        Str &= "  (case when PO.Currency <> 'Dollar' then"
        Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
        Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'  and po.status !='Cancel' And Po.CustomerID ='" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function ShippeedTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long) As DataTable
        Dim Str As String
        Str = "  select "
        Str &= " (case when PO.Currency <> 'Dollar' then "
        Str &= " ("
        Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
        Str &= " ))*Isnull((C.ShippedExchangeRate),0)"
        Str &= " else"
        Str &= " ("
        Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
        Str &= " )) end) as"
        Str &= " ShippedTurOver"
        Str &= " from Cargodetail cd join Cargo c on c.cargoid=cd.cargoid"
        Str &= "  join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & FromDate & "' and '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function ShippeedTurnOverOnTime(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long) As DataTable
        Dim Str As String
        Str = "  select "
        Str &= " (case when PO.Currency <> 'Dollar' then  ( ((( select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd "
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid  "
        Str &= " where PO.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel'"
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Str &= " and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO  where PO.ShipmentDate "
        Str &= " between '" & FromDate & "' and '" & ToDate & "'    and po.status !='Cancel' "
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  ) "
        Str &= " and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 )*Isnull((cd.Shippedrate),0))  ))* "
        Str &= " Isnull((C.ShippedExchangeRate),0) else ( ((( select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd "
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid  "
        Str &= " where PO.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel'"
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Str &= " and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO  where PO.ShipmentDate "
        Str &= " between '" & FromDate & "' and '" & ToDate & "'  and po.status !='Cancel'"
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  )"
        Str &= " and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0) *"
        Str &= " Isnull((cd.Shippedrate),0))  )) end) as ShippedTurnOverOnTime "
        Str &= "  from Cargodetail cd join Cargo c on c.cargoid=cd.cargoid "
        Str &= "  join purchaseorder po on po.poid=cd.popoid"
        Str &= "   where c.etd  between '" & FromDate & "' and '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetBookedComm(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = "Select   sum(case when PO.Currency <> 'Dollar' then "
        Str &= " (Convert(Decimal, ( (Isnull((POD.Quantity),0)*Isnull((POD.Rate),0)) "
        Str &= " ),0))*Isnull((PO.ExchangeRate),0)"
        Str &= " else (Convert(Decimal, ( (Isnull((POD.Quantity),0)*Isnull((POD.Rate),0)) "
        Str &= " ),0)) end) * c.Commission /100 as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
        Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012   and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Str &= " group by C.Commission "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetClaimPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal SupplierID As Long)
        Dim Str As String
        Str = " Select Count(Distinct(POC.POID)) as ClaimPos From POClaim POC "
        Str &= " Join PurchaseOrder PO on PO.POID = POC.POID"
        Str &= " join Customer C on C.CustomerID = PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID"
        Str &= " Where POC.ClaimDate Between '" & Fromdate & "' And '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

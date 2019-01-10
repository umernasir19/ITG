Imports Integra.EuroCentra
Imports System.Data

Public Class BuyingDepartmentAnalysis
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BuyingDepartmentAnalysis"
        m_strPrimaryFieldName = "BuyingDepartmentAnalysisID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lBuyingDepartmentAnalysisID As Long
    Private m_lCustomerID As Long
    Private m_strCustomerName As String
    Private m_lEKNumber As String
    Private m_dBookedTurnOver As Decimal
    Private m_dShippedTurnOver As Decimal
    Private m_dProductionPerformance As Decimal
    Private m_dcDeliveryPerformance As Decimal
    Private m_dcShippedQuantityOnTime As Decimal
    Private m_dcBookedForPOs As Decimal
    Private m_dcShippedPOsOnTime As Decimal
    Private m_dcBookedQuantity As Decimal

    Public Property BuyingDepartmentAnalysisID() As Long
        Get
            BuyingDepartmentAnalysisID = m_lBuyingDepartmentAnalysisID
        End Get
        Set(ByVal value As Long)
            m_lBuyingDepartmentAnalysisID = value
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
    Public Property EKNumber() As String
        Get
            EKNumber = m_lEKNumber
        End Get
        Set(ByVal value As String)
            m_lEKNumber = value
        End Set
    End Property

    Public Property BookedTurnOver() As Decimal
        Get
            BookedTurnOver = m_dBookedTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dBookedTurnOver = value
        End Set
    End Property
    Public Property ShippedTurnOver() As Decimal
        Get
            ShippedTurnOver = m_dShippedTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dShippedTurnOver = value
        End Set
    End Property

    Public Property ProductionPerformance() As Decimal
        Get
            ProductionPerformance = m_dProductionPerformance
        End Get
        Set(ByVal value As Decimal)
            m_dProductionPerformance = value
        End Set
    End Property
    Public Property BookedQuantity() As Decimal
        Get
            BookedQuantity = m_dcBookedQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedQuantity = value
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
    Public Property ShippedQuantityOnTime() As Decimal
        Get
            ShippedQuantityOnTime = m_dcShippedQuantityOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedQuantityOnTime = value
        End Set
    End Property
    Public Property BookedForPOs() As Decimal
        Get
            BookedForPOs = m_dcBookedForPOs
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedForPOs = value
        End Set
    End Property
    Public Property ShippedPOsOnTime() As Decimal
        Get
            ShippedPOsOnTime = m_dcShippedPOsOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedPOsOnTime = value
        End Set
    End Property
    Public Function SaveBuyingDepartmentAnalysis()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function BookeedTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String) As DataTable
        Dim Str As String
        Str = "Select PO.EkNumber, PO.ExchangeRate "
        Str &= "  ,(case when PO.Currency <> 'Dollar' then"
        Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
        Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012   and po.status !='Cancel' And Po.CustomerID ='" & CustomerID & "' And PO.EkNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function ShippeedTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String) As DataTable
        Dim str As String
        str = "  select PO.EKNumber, "
        str &= " (case when C.Currency <> 'Dollar' then "
        str &= " ("
        str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
        str &= " ))*Isnull((C.ShippedExchangeRate),0)"
        str &= " else"
        str &= " ("
        str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
        str &= " )) end) as"
        str &= " ShippedTurOver"
        str &= " from Cargodetail cd join Cargo c on c.cargoid=cd.cargoid"
        str &= "  join purchaseorder po on po.poid=cd.popoid "
        str &= " where c.etd  between '" & FromDate & "' and '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BuyingPerformance(ByVal ID As String, ByVal EkId As String, ByVal toDate As String, ByVal fromDate As String) As DataTable
        Dim str As String

        str = " Select PO.POID,PO.PONo,PO.Status,"
        str &= " (case when ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
        str &= " where SbPOD.POPOID =PO.POID),0))) > ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0))) then "
        str &= " (Convert(varchar,(Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0))))"
        str &= " else"
        str &= " (Convert(varchar,(Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
        str &= " where SbPOD.POPOID =PO.POID),0)))) "
        str &= " end)as ShipQTy"
        str &= " ,(Convert(varchar,(Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0)))) as QTY"
        str &= " ,"
        str &= " (case when ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
        str &= " where SbPOD.POPOID =PO.POID),0))) > ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0))) then "
        str &= " ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0)))/"
        str &= " ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0)))* 100 "
        str &= " else"
        str &= " ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
        str &= " where SbPOD.POPOID =PO.POID),0))) /"
        str &= " ((Convert(Decimal,(Select"
        str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
        str &= " where SbPOD.POID =PO.POID),0)))*100 "
        str &= " end) as PercentQTY"
        str &= "  from Purchaseorder PO where PO.POID "
        str &= " in (Select Distinct POPOID from cargodetail where CustomerID='" & ID & "') and EKnumber='" & EkId & "' and Year(PO.CreationDate) >=2012"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetCustomer() As DataTable
        Dim Str As String
        'Str = " select CustomerID,CustomerName from Customer where CustomerID in(Select Distinct CustomerID from Purchaseorder) order by customerid"
        Str = " select CustomerID,CustomerName from Customer where CustomerID in(1,7,8,9,27) order by customerid"

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetEKNumber(ByVal id As String) As DataTable
        Dim Str As String
        Str = " Select  Distinct EKnumber from Purchaseorder where CustomerID='" & id & "' and Year(CreationDate) >=2012"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function TruncateTable() As DataTable
        Dim Str As String
        Str = "Truncate table BuyingDepartmentAnalysis "
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  IsNull(Sum(POD.Quantity),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedQTYOnTimeEK(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= " ) and DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0"

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOsEK(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTimeEK(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Str &= " ) and DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedQTYEK(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long, ByVal EKNumber As String)
        Dim Str As String
        Str = " select  Isnull(Sum(POD.Quantity),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = '" & CustomerID & "' And PO.EKNumber = '" & EKNumber & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class MGTSupplierCustomerReports
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "MGTSupplier_Customer"
        m_strPrimaryFieldName = "SCID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lSCID As Long
    Private m_dtCreationDate As Date
    Private m_lMarchandID As Long
    Private m_strMarchandName As String
    Private m_lCustomerID As Long
    Private m_strCustomerName As String
    Private m_lSupplierID As Long
    Private m_strSupplierName As String
    Private m_dcBookedQuantity As Decimal
    Private m_dcShippedQuantity As Decimal
    Private m_dcBookedTurnOver As Decimal
    Private m_dcShippedTurnOver As Decimal
    Private m_dcDeliveryPerformance As Decimal
    Private m_dcProductionPerformance As Decimal
    Private m_dcShippedQuantityOnTime As Decimal
    Private m_dcBookedForPOs As Decimal
    Private m_dcTotalShippedPOs As Decimal
    Private m_dcShippedPOsOnTime As Decimal
    Private m_strPeriodicType As String
    '----------------Properties
    Public Property SCID() As Long
        Get
            SCID = m_lSCID
        End Get
        Set(ByVal value As Long)
            m_lSCID = value
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
    Public Property MarchandID() As Long
        Get
            MarchandID = m_lMarchandID
        End Get
        Set(ByVal value As Long)
            m_lMarchandID = value
        End Set
    End Property
    Public Property MarchandName() As String
        Get
            MarchandName = m_strMarchandName
        End Get
        Set(ByVal value As String)
            m_strMarchandName = value
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
    Public Property BookedQuantity() As Decimal
        Get
            BookedQuantity = m_dcBookedQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedQuantity = value
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
    Public Property BookedTurnOver() As Decimal
        Get
            BookedTurnOver = m_dcBookedTurnOver
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedTurnOver = value
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
    Public Property TotalShippedPOs() As Decimal
        Get
            TotalShippedPOs = m_dcTotalShippedPOs
        End Get
        Set(ByVal value As Decimal)
            m_dcTotalShippedPOs = value
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
    Public Property PeriodicType() As String
        Get
            PeriodicType = m_strPeriodicType
        End Get
        Set(ByVal value As String)
            m_strPeriodicType = value
        End Set
    End Property
    Public Function SaveSuplierCustomer()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTable()
        Dim str As String
        str = "  truncate table MGTSupplier_Customer"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMarchand() As DataTable
        Dim str As String
        str = " Select Distinct PO.MarchandID, UM.UserName  from PurchaseOrder PO "
        str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        str &= " Where UM.Designation = 'Merchant' And UM.IsActive = 1"
        str &= " order By UM.UserName "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetMgtSupplierData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
        Dim Str As String
        Str = "  select Distinct  V.venderlibraryid ,V.VenderName from vender V "
        Str &= " join Purchaseorder Po on Po.SupplierID= V.venderlibraryid"
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        Str &= " order by      V.VenderName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMgtSupplierDataNew(ByVal FromDate As String, ByVal ToDate As String, ByVal MarchandID As Long)
        Dim Str As String
        Str = "  select Distinct  V.venderlibraryid ,V.VenderName from vender V "
        Str &= " join Purchaseorder Po on Po.SupplierID= V.venderlibraryid"
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        Str &= " order by      V.VenderName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMgtCustomerData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = "  select Distinct C.CustomerID, C.CustomerName From Customer C "
        Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID "
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        Str &= " And PO.SupplierID = " & SupplierID
        Str &= " order by C.CustomerName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMgtCustomerDataNew(ByVal FromDate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = "  select Distinct C.CustomerID, C.CustomerName From Customer C "
        Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID "
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        Str &= " And PO.SupplierID = " & SupplierID
        Str &= " order by C.CustomerName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((POD.Quantity)),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((POD.Quantity)),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((cd.quantity)),0)  as ShippedQty "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((cd.quantity)),0)  as ShippedQty "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantityOnTime from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "'  And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'   "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

        ' DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedQTYOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantityOnTime from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "'  And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'   "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

        ' DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTTotalShippedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTTotalShippedPosNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
        Str &= " from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.SupplierID = " & SupplierID
        Str &= " And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "'"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BookeedTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long) As DataTable
        Dim Str As String
        Str = "Select PO.EkNumber, PO.ExchangeRate,  "
        Str &= "  (case when PO.Currency <> 'Dollar' then"
        Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
        Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And Po.CustomerID ='" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BookeedTurnOverNew(ByVal FromDate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long) As DataTable
        Dim Str As String
        Str = "Select PO.EkNumber, PO.ExchangeRate,  "
        Str &= "  (case when PO.Currency <> 'Dollar' then"
        Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
        Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
        Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
        Str &= " where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel' And Po.CustomerID ='" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function ShippeedTurnOver(ByVal FromDate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long) As DataTable
        Dim str As String
        str = "  select PO.EKNumber, "
        str &= " (case when PO.Currency <> 'Dollar' then "
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
        str &= " where c.etd  between '" & FromDate & "' and '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  And PO.MarchandID =  '" & MarchandID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function ShippeedTurnOverNew(ByVal FromDate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long) As DataTable
        Dim str As String
        str = "  select PO.EKNumber, "
        str &= " (case when PO.Currency <> 'Dollar' then "
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
        str &= " where c.etd  between '" & FromDate & "' and '" & ToDate & "' And PO.CustomerID = '" & CustomerID & "' And PO.SupplierID = '" & SupplierID & "'  And PO.MarchandID =  '" & MarchandID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetMGTShippedQTYOnTimeIND(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0"

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOsIND(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTimeIND(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Str &= " ) and DATEDIFF(DAY,PO.ShipmentDate, C.ETD) <=0"
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedQTYIND(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal MarchandID As Long)
        Dim Str As String
        Str = " select  Isnull(Sum(POD.Quantity),0)  as BookedQuantity "
        Str &= " from PurchaseOrder PO "
        Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
        Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.MarchandID = '" & MarchandID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

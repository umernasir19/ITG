Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class MGTCustomer
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "MGTCustomerReport"
            m_strPrimaryFieldName = "MGTId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''

        Private m_lMGTId As Long
        Private m_dtCreationDate As Date
        Private m_lCustomerId As Long
        Private m_strCustomerName As String
        Private m_dcBookedQuantity As Decimal
        Private m_dcShippedQuantity As Decimal
        Private m_dcBookedTurnOver As Decimal
        Private m_dcShippedTurnOver As Decimal
        Private m_dcBookedCommission As Decimal
        Private m_dcShippedCommission As Decimal
        Private m_dcNoOfClaimed As Decimal
        Private m_dcTotalPos As Decimal
        Private m_dcTimelyShipped As Decimal
        Private m_dcDeliveryPerformance As Decimal
        Private m_dcProductionPerformance As Decimal
        Private m_dcShippedQuantityOnTime As Decimal
        Private m_dcBookedForPOs As Decimal
        Private m_dcTotalShippedPOs As Decimal
        Private m_dcShippedPOsOnTime As Decimal
        Private m_dcBackLogCleared As Decimal
        '----------------Properties
        Public Property MGTId() As Long
            Get
                MGTId = m_lMGTId
            End Get
            Set(ByVal value As Long)
                m_lMGTId = value
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
        Public Property CustomerId() As Long
            Get
                CustomerId = m_lCustomerId
            End Get
            Set(ByVal value As Long)
                m_lCustomerId = value
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
        Public Property NoOfClaimed() As Decimal
            Get
                NoOfClaimed = m_dcNoOfClaimed
            End Get
            Set(ByVal value As Decimal)
                m_dcNoOfClaimed = value
            End Set
        End Property
        Public Property TotalPos() As Decimal
            Get
                TotalPos = m_dcTotalPos
            End Get
            Set(ByVal value As Decimal)
                m_dcTotalPos = value
            End Set
        End Property
        Public Property TimelyShipped() As Decimal
            Get
                TimelyShipped = m_dcTimelyShipped
            End Get
            Set(ByVal value As Decimal)
                m_dcTimelyShipped = value
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
        Public Property BackLogCleared() As Decimal
            Get
                BackLogCleared = m_dcBackLogCleared
            End Get
            Set(ByVal value As Decimal)
                m_dcBackLogCleared = value
            End Set
        End Property
        Public Function SaveMGT()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoById(ByVal lCargoId As Long)
            Try
                Return MyBase.GetById(lCargoId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        'Public Function TruncateTable()
        '    Dim str As String
        '    str = "  truncate table MGTCustomerReport"
        '    Try
        '        MyBase.ExecuteNonQuery(str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetMGTBookedCommNew(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedCommNew2(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerList(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerListKints(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " where Year(CR.ETD)=" & Year
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerListWoven(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= "  and U.Ecpdivistion in ('Synergies 03','Synergies 04','Synergies 05')"
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandCustomerList(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from   Purchaseorder PO "
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " where Year(PO.shipmentdate)=" & Year
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandCustomerListOIH(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from   Purchaseorder PO "
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " where Year(PO.shipmentDate)=" & Year
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandCustomerListWovenOIH(ByVal Year As Long)
            Dim str As String
            str = " select distinct PO.Customerid,C.Customername from   Purchaseorder PO "
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " where Year(PO.Tolerance)=" & Year
            str &= "  and U.Ecpdivistion in ('Synergies 03','Synergies 04','Synergies 05')"
            str &= " and (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then "
            str &= " IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)"
            str &= " -IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)else"
            str &= " IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0)end)  > 0"
            str &= " order by C.Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShippedValue(ByVal Customerid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = "  select(case when C.Currency <> 'Dollar' then (((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            str &= " ))*Isnull((c.ShippedExchangeRate),0) else(((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)))) end) as ShipValue "
            str &= " from Cargodetail cd"
            str &= " join Cargo c on c.cargoid=cd.cargoid"
            str &= " join purchaseorder po on po.poid=cd.popoid"
            str &= " join Customer CS on CS.CustomerID=po.CustomerID"
            str &= " left join purchaseorderdetail pod on pod.Podetailid=cd.poid"
            str &= " where Year(C.ETD)=" & Year
            str &= " and month(C.ETD)=" & month
            str &= " and CS.Customerid=" & Customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShippedQty(ByVal Customerid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " select isnull(Sum(Cd.Quantity),0) from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " where Year(CR.ETD)=" & Year
            str &= " and month(CR.ETD)=" & month
            str &= " and C.Customerid=" & Customerid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalShippedQty(ByVal Customerid As Long, ByVal Year As Long)
            Dim str As String
            str = " select isnull(Sum(Cd.Quantity),0) from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Customer C on C.Customerid=Po.Customerid"
            str &= " where Year(CR.ETD)=" & Year
            str &= " and C.Customerid=" & Customerid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalShippedValue(ByVal Customerid As Long, ByVal Year As Long)
            Dim str As String
            str = "  select(case when C.Currency <> 'Dollar' then (((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            str &= " ))*Isnull((c.ShippedExchangeRate),0) else(((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)))) end) as ShipValue "
            str &= " from Cargodetail cd"
            str &= " join Cargo c on c.cargoid=cd.cargoid"
            str &= " join purchaseorder po on po.poid=cd.popoid"
            str &= " join Customer CS on CS.CustomerID=po.CustomerID"
            str &= " left join purchaseorderdetail pod on pod.Podetailid=cd.poid"
            str &= " where Year(C.ETD)=" & Year
            str &= " and CS.Customerid=" & Customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandValue(ByVal Customerid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " Select   Isnull (POD.Quantity ,0) as InHandqty,  (case when PO.Currency <> 'Dollar' then "
            str &= " Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)*Isnull(PO.ExchangeRate,0) else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end) as  InHandValue "
            str &= " from Purchaseorder PO"
            str &= " join PurchaseOrderDetail POD on POD.POID=PO.POID"
            str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            str &= " where po.status !='Close' and po.status !='Cancel'"
            str &= " and Year(Po.shipmentDate) =" & Year
            str &= " and Month(Po.shipmentDate) =" & month
            str &= " and C.Customerid=" & Customerid
            str &= " and PO.POID not in (Select POPOID from CargoDetail)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalInhandValue(ByVal Customerid As Long, ByVal Year As Long)
            Dim str As String
            str = " Select   Isnull (POD.Quantity ,0) as InHandqty,  (case when PO.Currency <> 'Dollar' then "
            str &= " Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)*Isnull(PO.ExchangeRate,0) else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end) as  InHandValue "
            str &= " from Purchaseorder PO"
            str &= " join PurchaseOrderDetail POD on POD.POID=PO.POID"
            str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            str &= " where po.status !='Close' and po.status !='Cancel'"
            str &= " and Year(Po.shipmentDate) =" & Year
            str &= " and C.Customerid=" & Customerid
            str &= " and PO.POID not in (Select POPOID from CargoDetail)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandQty(ByVal Customerid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " Select   Isnull (POD.Quantity ,0) as InHandqty,  (case when PO.Currency <> 'Dollar' then "
            str &= " Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)*Isnull(PO.ExchangeRate,0) else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end) as  InHandValue "
            str &= " from Purchaseorder PO"
            str &= " join PurchaseOrderDetail POD on POD.POID=PO.POID"
            str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            str &= " where po.status !='Close' and po.status !='Cancel'"
            str &= " and Year(Po.shipmentDate) =" & Year
            str &= " and Month(Po.shipmentDate) =" & month
            str &= " and C.Customerid=" & Customerid
            str &= " and PO.POID not in (Select POPOID from CargoDetail)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalInhandQty(ByVal Customerid As Long, ByVal Year As Long)
            Dim str As String
            str = " Select   Isnull (POD.Quantity ,0) as InHandqty,  (case when PO.Currency <> 'Dollar' then "
            str &= " Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)*Isnull(PO.ExchangeRate,0) else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end) as  InHandValue "
            str &= " from Purchaseorder PO"
            str &= " join PurchaseOrderDetail POD on POD.POID=PO.POID"
            str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            str &= " where po.status !='Close' and po.status !='Cancel'"
            str &= " and Year(Po.shipmentDate) =" & Year
            str &= " and C.Customerid=" & Customerid
            str &= " and PO.POID not in (Select POPOID from CargoDetail)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierList(ByVal Year As Long)
            Dim str As String
            str = " select distinct V.VenderlibraryID,V.Vendername from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid"
            str &= "  where Year(CR.shipmentdate) =" & Year
            str &= " order by V.Vendername  ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierShippedValue(ByVal Supplierid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " select distinct(case when CR.Currency <> 'Euro' then isnull(Sum(distinct Cr.Invoicevalue),0) "
            str &= " else isnull(Sum(distinct Cr.Invoicevalue),0)* Po.ExchangeRate end) as shippedvalue "
            str &= " from Cargodetail CD "
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= " and month(CR.shipmentdate)=" & month
            str &= " and PO.Supplierid=" & Supplierid
            str &= " group by PO.ExchangeRate,CR.Currency "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierShippedQty(ByVal Supplierid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " select isnull(Sum(Cd.Quantity),0) from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= " and month(CR.shipmentdate)=" & month
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalSupplierShippedQty(ByVal Supplierid As Long, ByVal Year As Long)
            Dim str As String
            str = " select isnull(Sum(Cd.Quantity),0) from Cargodetail CD"
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= "  join Vender V on v.VenderlibraryID=PO.Supplierid"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalSupplierShippedValue(ByVal Supplierid As Long, ByVal Year As Long)
            Dim str As String
            str = " select distinct(case when CR.Currency <> 'Euro' then isnull( (  Cr.Invoicevalue),0) "
            str &= " else isnull(  (  Cr.Invoicevalue),0)* Po.ExchangeRate end) as shippedvalue "
            str &= " from Cargodetail CD "
            str &= " join Cargo Cr on Cr.Cargoid=CD.Cargoid"
            str &= " join Purchaseorder PO on Po.Poid=CD.POPOid"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid"
            str &= " where Year(CR.shipmentdate)=" & Year
            str &= " and PO.Supplierid=" & Supplierid
            ' str &= " group by PO.ExchangeRate,CR.Currency "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetInhandSupplierList(ByVal Year As Long)
            Dim str As String
            str = " select distinct V.VenderlibraryID,V.Vendername from   Purchaseorder PO "
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid "
            str &= " where Year(PO.shipmentdate)=" & Year
            str &= " order by V.Vendername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierInhandValue(ByVal Supplierid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = "  SELECT  (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) -IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) else (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0)"
            str &= " ))* PO.Exchangerate  else ( IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0)"
            str &= " )) end)end) as InHandValue"
            str &= " From PurchaseORder PO "
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid "
            str &= "  where Year(Po.ShipmentDate) =" & Year
            str &= " and month(Po.ShipmentDate)=" & month
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierInhandQty(ByVal Supplierid As Long, ByVal Year As Long, ByVal month As Long)
            Dim str As String
            str = " SELECT (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then  IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) -IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)else IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0) end) as InHandqty"
            str &= " From PurchaseORder PO "
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid "
            str &= " where Year(Po.ShipmentDate) =" & Year
            str &= " and month(Po.ShipmentDate)=" & month
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalSupplierInhandQty(ByVal Supplierid As Long, ByVal Year As Long)
            Dim str As String
            str = " SELECT (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then  IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) -IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)else IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0) end) as InHandqty"
            str &= " From PurchaseORder PO "
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid  "
            str &= " where Year(Po.ShipmentDate) =" & Year
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTotalSupplierInhandValue(ByVal Supplierid As Long, ByVal Year As Long)
            Dim str As String
            str = "  SELECT  (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) -IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) else (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0)"
            str &= " ))* PO.Exchangerate  else ( IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(Quantity) From POCancelQuantity POC Where PO.POID=POC.POID),0)"
            str &= " )) end)end) as InHandValue"
            str &= " From PurchaseORder PO "
            str &= " join UmUser U on u.UserID=Po.MarchandID"
            str &= " join Vender V on v.VenderlibraryID=PO.Supplierid  "
            str &= "  where Year(Po.ShipmentDate) =" & Year
            str &= " and PO.Supplierid=" & Supplierid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function TruncateTable()
            Dim str As String
            str = " TRUNCATE TABLE  ShippedAnalysis "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getCustomerShipped()
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_CustomerShippedXL", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function getCustomerExcelSheetOIH()
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_CustomerOIHXL", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Function GetGategory()
            Dim str As String
            str = " select * from IMSItemCategory"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDistinctCustomer()
            Dim str As String

            str = " select distinct c.CustomerID ,c.CustomerName  from POMaster pm"
            str &= "  join PODetail pd on pd.POID =pm.POID "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  join Customer c on c.CustomerID =jo.CustomerDatabaseID"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierNameOrAmount()
            Dim str As String
            str = " select sd.SupplierDatabaseId,sd.SupplierName , CONVERT(varchar,CAST((isnull(sum((pod.Quantity * pod.Rate )* (pod.ExchangeRate)),0))As money),1)  as Amount from pomaster mst"
            str &= "  join podetail pod on pod.poid=mst.poid"
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pod.AccountPayablePartyID "
            str &= "  join  PORecvDetail pdd on pdd.PODetailID =pod.PoDetailId "
            str &= "  group by sd.SupplierDatabaseId,sd.SupplierName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetGategoryNew()
            Dim str As String
            str = " select distinct imss.IMSItemCategoryID ,imss.ItemCategoryName  from IMSItemCategory imss"
            str &= "  join IMSItem IM on IM.IMSItemCategoryID=imss.IMSItemCategoryID"
            str &= "  JOIN PODetail PD on PD.ItemId =im.IMSItemID "
            str &= "  where PD.joborderid  in (select joborderid from tempPurchasingSummarySrno tt where tt.JobOrdeId =PD.joborderid)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSerailNo()
            Dim str As String
            str = " select * from tempPurchasingSummarySrno"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataOrderStatus(ByVal StartDate As String, ByVal EndDate As String, ByVal SeasonDatabaseId As Long)
            Dim str As String
            str = " select  JO.SRNO,sum(JOD.Quantity) as Booking  "
            str &= " ,(select COUNT(SS.StitchingBit) from TFAStitching SS where ss.Joborderid =jo.Joborderid) as Offlinee"
            str &= " ,(select COUNT(SS.WashingBit) from TFAWashing SS where ss.Joborderid =jo.Joborderid) as Washing"
            str &= " ,(select COUNT(SS.FinishingBit) from TFAFinishing SS where ss.Joborderid =jo.Joborderid) as Finishing"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " where jo.SeasonDatabaseID='" & SeasonDatabaseId & "' and  JOD.StyleShipmentDate between '" & StartDate & "' and '" & EndDate & "'  "
            str &= " GROUP BY jo.Joborderid ,JO.SRNO"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataDate()
            Dim str As String

            'str = "     select CONVERT(VARCHAR,TT.CREATIONDATE,103) as CRDate"
            'str &= " from  JobOrderdatabase JO   "
            'str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            'str &= " join StyleAssortmentDetail  SAd on SAd.StyleAssortmentMasterId=SAM.StyleAssortmentMasterId  "
            'str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            'str &= " join TFAStitching tt on tt.Joborderid =jo.Joborderid"
            'str &= " WHERE tt.CreationDate BETWEEN '06/01/2018' AND '06/30/2018'"
            'str &= " group BY CONVERT(VARCHAR,TT.CREATIONDATE,103)"
            'str &= " order by CONVERT(VARCHAR,TT.CREATIONDATE,103) asc"

            str = "  select CONVERT(VARCHAR,TT.CREATIONDATE,103) as CRDate"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join StyleAssortmentDetail  SAd on SAd.StyleAssortmentMasterId=SAM.StyleAssortmentMasterId  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " join TFAStitching tt on tt.Joborderid =jo.Joborderid AND YEAR(tt.CreationDate) = YEAR(GETDATE()) "
            str &= " and Month(tt.CreationDate) = Month(GETDATE())"
            str &= " group BY CONVERT(VARCHAR,TT.CREATIONDATE,103)"
            str &= " order by CONVERT(VARCHAR,TT.CREATIONDATE,103) desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataDateDAL1(ByVal StartDate As String)
            Dim str As String
            str = "   select  COUNT(tt.StitchingBit) as Offlinee"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join StyleAssortmentDetail  SAd on SAd.StyleAssortmentMasterId=SAM.StyleAssortmentMasterId  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " join TFAStitching tt on tt.Joborderid =jo.Joborderid "
            str &= " where SAd.LineNumber in ('A','B','C','D') and convert(varchar,tt.CreationDate,103) ='" & StartDate & "'"
            str &= "  group BY CONVERT(VARCHAR,TT.CREATIONDATE,103)"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataDateDAL2(ByVal StartDate As String)
            Dim str As String
            str = "   select  COUNT(tt.StitchingBit) as Offlinee"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join StyleAssortmentDetail  SAd on SAd.StyleAssortmentMasterId=SAM.StyleAssortmentMasterId  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " join TFAStitching tt on tt.Joborderid =jo.Joborderid "
            str &= " where SAd.LineNumber in ('G','H','I','J','K','L') and convert(varchar,tt.CreationDate,103) ='" & StartDate & "'"
            str &= "  group BY CONVERT(VARCHAR,TT.CREATIONDATE,103)"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataDateDAL3(ByVal StartDate As String)
            Dim str As String
            str = "   select  COUNT(tt.StitchingBit) as Offlinee"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join StyleAssortmentDetail  SAd on SAd.StyleAssortmentMasterId=SAM.StyleAssortmentMasterId  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " join TFAStitching tt on tt.Joborderid =jo.Joborderid "
            str &= " where SAd.LineNumber in ('M','N','O','P') and convert(varchar,tt.CreationDate,103) ='" & StartDate & "'"
            str &= "  group BY CONVERT(VARCHAR,TT.CREATIONDATE,103)"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForPOMonthWiseFstore(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " select distinct MONTH(CreationDate ) as Month,Year(CreationDate ) as Year from pomaster pm join podetail pd on pd.poid=pm.poid    where  pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'  order by  Year(CreationDate )  ,MONTH(CreationDate ) asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAmountt(ByVal AccountPayablePartyID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " select CONVERT(varchar,CAST((isnull(sum((PD.Quantity * PD.Rate )* (PD.ExchangeRate)),0))As money),1)  as Amount  from PODetail PD"
            str &= " join POMaster Pm on pm.POID=PD.POID "
            str &= "  where AccountPayablePartyID='" & AccountPayablePartyID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAmounttNewwww(ByVal AccountPayablePartyID As Long)
            Dim str As String
            str = " select isnull(sum((PD.Quantity * PD.Rate )* (PD.ExchangeRate)),0)  as Amount  from PODetail PD"
            str &= " join POMaster Pm on pm.POID=PD.POID "
            str &= "  where AccountPayablePartyID='" & AccountPayablePartyID & "'   "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForDifferenceNewwwww(ByVal SupplierDatabaseId As Long)
            Dim str As String
            str = " select sd.SupplierName,pom.PONo,pod.DeliveryDate "
            str &= " ,(select top 1(pp.ReceiveDate) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId )"
            str &= "  as Recvdate"
            str &= "  ,DATEDIFF(day, pod.DeliveryDate, (select top 1(pp.ReceiveDate) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId )) as Diff"
            str &= " from POMaster POM  "
            str &= "  join PODetail POD on POd.POId=POM.POId       "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= " join IMSItemUnit UMI on UMI.ItemUnitId=POD.UOMID"
            str &= " LEFT JOIN JobOrderdatabase JO on JO.Joborderid =POD.joborderid "
            str &= "  where sd.SupplierDatabaseId='" & SupplierDatabaseId & "'  "
            str &= " group by sd.SupplierName,POM.POID ,pom.PONo ,pod.PoDetailId ,pod.DeliveryDate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForDifference(ByVal SupplierDatabaseId As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " select sd.SupplierName,pom.PONo,pod.DeliveryDate "
            str &= " ,(select top 1(pp.ReceiveDate) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId )"
            str &= "  as Recvdate"
            str &= "  ,DATEDIFF(day, pod.DeliveryDate, (select top 1(pp.ReceiveDate) from PORecvDetail pp where pp.PODetailID = POD.PoDetailId )) as Diff"
            str &= " from POMaster POM  "
            str &= "  join PODetail POD on POd.POId=POM.POId       "
            str &= " join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            str &= " JOIN IMSItem IMST ON IMST.IMSItemid=POD.ItemId"
            str &= " join IMSItemUnit UMI on UMI.ItemUnitId=POD.UOMID"
            str &= " LEFT JOIN JobOrderdatabase JO on JO.Joborderid =POD.joborderid "
            str &= "  where sd.SupplierDatabaseId='" & SupplierDatabaseId & "' and  POM.CreationDate between '" & StartDate & "' and '" & EndDate & "' and pom.POID in (select POID from PORecvMaster prmm where prmm.POID =pom.POID)"
            str &= " group by sd.SupplierName,POM.POID ,pom.PONo ,pod.PoDetailId ,pod.DeliveryDate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.Quantity)*"
            str &= "  (pd.Rate)*(pd.ExchangeRate)),0) as POAmount from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemIDaNDItemNAme(ByVal CustomerDatabaseID As Long)
            Dim str As String
            str = " select  distinct IM.IMSItemID ,im.ItemName  from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemIDaNDItemNAmeDateVise(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " select  distinct IM.IMSItemID ,im.ItemName  from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemIDaNDItemNAmerrrrrrrrrrrrrrrrrr(ByVal CustomerDatabaseID As Long)
            Dim str As String
            str = " select  distinct IM.IMSItemID ,im.ItemName  from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetItemIDaNDItemNAmerrrrrrrrrrrrrrrrrrDateWise(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " select  distinct IM.IMSItemID ,im.ItemName  from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "'  and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Function GetPOQtyCateViseNewwwwwwww(ByVal CustomerDatabaseID As Long)
            Dim str As String
            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount,im.ItemName "

            str &= " ,(select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= "  from PORecvMaster pmm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pmm.PORecvMasterid"
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID"
            str &= " where pmm.POID =pm.POID and PDD.ItemId =IM.IMSItemID ) "
            str &= "  as RecvAmount"

            str &= "  ,(select  isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount "
            str &= "   from IssueMst pmm  "
            str &= "  join IssueDetail pd on pd.Issueid=pmm.Issueid"
            str &= "  where pd.POID =pm.POID and pd.ItemId =IM.IMSItemID ) "
            str &= " as IssueAmount"

            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= " join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' "
            str &= " group by im.ItemName ,pm.POID ,IM.IMSItemID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwwwwwwwAllCase(ByVal CustomerDatabaseID As Long)
            Dim str As String
            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount,im.ItemName "

            str &= " ,(select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= "  from PORecvMaster pmm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pmm.PORecvMasterid"
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID"
            str &= " where pmm.POID =pm.POID and PDD.ItemId =IM.IMSItemID ) "
            str &= "  as RecvAmount"

            str &= "  ,(select  isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount "
            str &= "   from IssueMst pmm  "
            str &= "  join IssueDetail pd on pd.Issueid=pmm.Issueid"
            str &= "  where pd.POID =pm.POID and pd.ItemId =IM.IMSItemID ) "
            str &= " as IssueAmount"

            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= " join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= " join tempPurchasingSummarySrno joo on joo.Jobordeid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' "
            str &= " group by im.ItemName ,pm.POID ,IM.IMSItemID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNeww(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwNew(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = " select  "
            str &= " (select isnull(sum((pdd.Quantity * pdd.Rate )* (pdd.ExchangeRate)),0) from PODetail "
            str &= " pdd where  pdd.ItemId =IM.imsitemid) as POAmount"
            str &= " from pomaster pm  "
            str &= "  join podetail pd on pd.poid=pm.poid     "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId   "
            str &= " join JobOrderdatabase jo on jo.Joborderid =pd.joborderid "
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            str &= "  group by im.IMSItemID,IM.ItemName"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwPOAmountDtaa(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and  IM.IMSItemID = '" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwPOAmountDtaaDateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and  IM.IMSItemID = '" & IMSItemID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwPOAmountDtaaDateWiseWithoutsum(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and  IM.IMSItemID = '" & IMSItemID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwPOAmountDtaaAnyCase(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and  IM.IMSItemID = '" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwPOAmountDtaaAnyCaseDateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = " select  isnull(sum((pd.Quantity * pd.Rate )* (pd.ExchangeRate)),0) as POAmount"
            str &= "  from pomaster pm   "
            str &= "  join podetail pd on pd.poid=pm.poid   "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join JobOrderdatabase jo on jo.Joborderid =pd.joborderid"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and  IM.IMSItemID = '" & IMSItemID & "' and pm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwRecv(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= " from PORecvMaster pm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid "
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID  "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= " join POMaster pmm on pmm.POID =pm.poid"
            str &= " join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwRec4444444444444v(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = "  select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= " from PORecvMaster pm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid "
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID  "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= " join POMaster pmm on pmm.POID =pm.poid"
            str &= " join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwRec4444444444444vdateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= " from PORecvMaster pm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid "
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID  "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= " join POMaster pmm on pmm.POID =pm.poid"
            str &= " join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwRec4444444444444vAnuCase(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = "  select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= " from PORecvMaster pm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid "
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID  "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= " join POMaster pmm on pmm.POID =pm.poid"
            str &= " join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PDD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwRec4444444444444vAnuCaseDateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select  isnull(sum((pd.RecvQuantity * PDD.Rate )* (PDD.ExchangeRate)),0) as POAmount "
            str &= " from PORecvMaster pm  "
            str &= "  join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid "
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID  "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= " join POMaster pmm on pmm.POID =pm.poid"
            str &= " join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid"
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =PDD.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwIssue(ByVal CustomerDatabaseID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select   isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount from IssueMst pm  "
            str &= "   join IssueDetail pd on pd.Issueid=pm.Issueid  "
            str &= "   join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= "  join POMaster pmm on pmm.POID =pd.poid "
            str &= "   join PODetail pdd on pdd.POID =pmm.POID "
            str &= "   join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid "
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwIssue6666666666666666(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = "  select   isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount from IssueMst pm  "
            str &= "   join IssueDetail pd on pd.Issueid=pm.Issueid  "
            str &= "   join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= "  join POMaster pmm on pmm.POID =pd.poid "
            str &= "   join PODetail pdd on pdd.POID =pmm.POID "
            str &= "   join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid "
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwIssue6666666666666666DateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select   isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount from IssueMst pm  "
            str &= "   join IssueDetail pd on pd.Issueid=pm.Issueid  "
            str &= "   join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= "  join POMaster pmm on pmm.POID =pd.poid "
            str &= "   join PODetail pdd on pdd.POID =pmm.POID "
            str &= "   join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid "
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwIssue6666666666666666AnyCase(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = "  select   isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount from IssueMst pm  "
            str &= "   join IssueDetail pd on pd.Issueid=pm.Issueid  "
            str &= "   join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= "  join POMaster pmm on pmm.POID =pd.poid "
            str &= "   join PODetail pdd on pdd.POID =pmm.POID "
            str &= "   join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid "
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =pdd.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseNewwIssue6666666666666666AnyCaseDateWise(ByVal CustomerDatabaseID As Long, ByVal IMSItemID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            str = "  select   isnull(sum((pd.IssueQty * pd.Rate )),0) as POAmount from IssueMst pm  "
            str &= "   join IssueDetail pd on pd.Issueid=pm.Issueid  "
            str &= "   join IMSItem IM on IM.IMSItemID =PD.ItemId  "
            str &= "  join POMaster pmm on pmm.POID =pd.poid "
            str &= "   join PODetail pdd on pdd.POID =pmm.POID "
            str &= "   join JobOrderdatabase jo on jo.Joborderid =PDD.joborderid "
            str &= "  join tempPurchasingSummarySrno IMm on IMm.JobOrdeId =pdd.JobOrderId"
            str &= "  where jo.CustomerDatabaseID='" & CustomerDatabaseID & "' AND IM.IMSItemID= '" & IMSItemID & "' and pmm.CreationDate between '" & StartDate & "' and '" & EndDate & "'"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOQtyCateViseJoborderVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.Quantity)*"
            str &= "  (pd.Rate)*(pd.ExchangeRate)),0) as POAmount from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid "
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  join tempPurchasingSummarySrno IMT on IMT.JobOrdeId =PD.JobOrderId"
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPORecvQtyCateVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.RecvQuantity)*"
            str &= " (PDD.Rate)*(PDD.ExchangeRate)),0) as POAmount from PORecvMaster pm "
            str &= " join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid"
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPORecvQtyCateViseSrNoVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.RecvQuantity)*"
            str &= " (PDD.Rate)*(PDD.ExchangeRate)),0) as POAmount from PORecvMaster pm "
            str &= " join PORecvDetail pd on pd.PORecvMasterid=pm.PORecvMasterid"
            str &= " JOIN PODetail PDD on PDD.PoDetailId = pd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemID =PD.ItemId"
            str &= "  join tempPurchasingSummarySrno IMT on IMT.JobOrdeId =pm.JobOrderId"
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOIssueQtyCateVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.IssueQty)*"
            str &= "  (pd.Rate)),0) as POAmount from IssueMst pm "
            str &= "  join IssueDetail pd on pd.Issueid=pm.Issueid"
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPOIssueQtyCateViseSrNoVise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = " select  ISNULL(((pd.IssueQty)*"
            str &= "  (pd.Rate)),0) as POAmount from IssueMst pm "
            str &= "  join IssueDetail pd on pd.Issueid=pm.Issueid"
            str &= "  join IMSItem IM on IM.IMSItemID =PD.ItemId "
            str &= "  join tempPurchasingSummarySrno IMT on IMT.JobOrdeId =PD.JobOrderId"
            str &= "  where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSuppliers(ByVal Type As String, ByVal Year As String, ByVal Month As String)
            Dim str As String
            str = " select distinct sd.SupplierDatabaseId ,sd.SupplierName from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid  "
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =pd.AccountPayablePartyID "
            If Type = "Fabric Store" Then
                str &= "  where PM.FabricPOrder =1  "
            Else
                str &= "  where PM.FabricPOrder =0  "
            End If
            If Year <> "All" Then
                str &= "  and Year(pm.CreationDate)='" & Year & "'"
            End If
            If Month <> "All" Then
                str &= "  and Month(pm.CreationDate)='" & Month & "'"

            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataAllcase(ByVal Type As String, ByVal Year As String, ByVal Month As String)
            Dim str As String
            str = "   select sd.SupplierDatabaseId ,sd.SupplierName ,sum(pd.Quantity) as Quantity ,"
            str &= " sum((pd.Quantity)*(pd.Rate)*(pd.ExchangeRate)) as Amount "
            str &= " from pomaster pm  "
            str &= " join podetail pd on pd.poid=pm.poid "
            str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pd.AccountPayablePartyID  "
            If Type = "Fabric Store" Then
                str &= "  where PM.FabricPOrder =1 "
            Else
                str &= "  where PM.FabricPOrder =0  "
            End If
            If Year <> "All" Then
                str &= "  and Year(pm.CreationDate)='" & Year & "'"
            End If
            If Month <> "All" Then
                str &= "  and Month(pm.CreationDate)='" & Month & "'"
            End If
            str &= "  group by sd.SupplierDatabaseId ,sd.SupplierName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForPOMonthWiseFstoreForInnerLoop(ByVal Year As String, ByVal Month As String)
            Dim str As String
            str = " select MONTH(CreationDate ) as Month,Year(CreationDate ) as Year,pd.Quantity ,pd.Rate ,((pd.Quantity)*(pd.Rate)*(pd.ExchangeRate)) as Amount from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid  "
            str &= "  where PM.FabricPOrder =1 and MONTH(CreationDate )='" & Month & "' and Year(CreationDate )='" & Year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataForPOMonthWiseAstoreForInnerLoop(ByVal Year As String, ByVal Month As String)
            Dim str As String
            str = " select MONTH(CreationDate ) as Month,Year(CreationDate ) as Year,pd.Quantity ,pd.Rate ,((pd.Quantity)*(pd.Rate)*(pd.ExchangeRate)) as Amount from pomaster pm "
            str &= "  join podetail pd on pd.poid=pm.poid  "
            str &= "  where PM.FabricPOrder =0 and PM.GStoreStatus=0 and MONTH(CreationDate )='" & Month & "' and Year(CreationDate )='" & Year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierBRUNEIDARUSSALAM()
            Dim str As String
            str = " select * from vender where CountryID =34"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterMarch(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount  from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='03' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterApril(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='04' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterMay(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='05' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterJune(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='06' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterJuly(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='07' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterAug(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='08' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterSep(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='09' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterOct(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='10' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterNov(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='11' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterDec(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='12' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterFeb(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='02' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterJan(ByVal year As String)
            Dim str As String
            str = "  select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm join podetail pd on pd.poid=pm.poid where month(pm.CreationDate)='01' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterSrNoViseFstore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "    select  isnull(SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from PORecvMaster pm "
            str &= " join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID "
            str &= "  join podetail pd on pd.poid=pm.poid"
            str &= "  join poMaster pom on pom.poid=pm.poid"
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pd.Joborderid"
            str &= " where pom.FabricPOrder=1 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOMasterSrNoViseastore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "    select isnull(SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from PORecvMaster pm "
            str &= " join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID "
            str &= "  join podetail pd on pd.poid=pm.poid"
            str &= "  join poMaster pom on pom.poid=pm.poid"
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pd.Joborderid"
            str &= " where pom.FabricPOrder=0 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetFQty(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String

            str = "   select  isnull(pod.Rate,0) as Rate ,isnull(SUM(POD.Quantity),0) as POQuantity  "
            str &= "   ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp JOIN PORecvMaster PRM"
            str &= "   ON PRM.PORecvMasterID =PP.PORecvMasterID "
            str &= "   where PRM.SeasonDatabaseID  = JO.SeasonDatabaseID AND PRM.JobOrderID =JO.Joborderid),0)"
            str &= "    as RecvQuantity"
            str &= "    ,isnull((select SUM(ID.IssueQty) from IssueDetail  ID "
            str &= "    where ID.SeasonDatabaseID  = JO.SeasonDatabaseID AND ID.JobOrderID =JO.Joborderid),0)"
            str &= "    as IssueQuantity"
            str &= "      ,isnull((select SUM(ID.Rate) from IssueDetail  ID "
            str &= "   where ID.SeasonDatabaseID  = JO.SeasonDatabaseID AND ID.JobOrderID =JO.Joborderid),0)"
            str &= "    as IssueRate"
            str &= "   from POMaster POM  "
            str &= "   join PODetail POD on POd.POId=POM.POId       "
            str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            str &= "   JOIN JobOrderdatabase JO ON JO.Joborderid =POD.joborderid "
            str &= "    where POD.SeasonDatabaseID = '" & SeasonDatabaseID & "' And POD.joborderid = '" & Joborderid & "' And POM.FabricPOrder = 1 "
            str &= "   GROUP BY JO.SeasonDatabaseID,JO.joborderid,POD.PoDetailId,pod.Rate  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAQty(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String

            str = "   select  isnull(pod.Rate,0) as Rate ,isnull(SUM(POD.Quantity),0) as POQuantity  "
            str &= "   ,isnull((select SUM(pp.RecvQuantity) from PORecvDetail pp JOIN PORecvMaster PRM"
            str &= "   ON PRM.PORecvMasterID =PP.PORecvMasterID "
            str &= "   where PRM.SeasonDatabaseID  = JO.SeasonDatabaseID AND PRM.JobOrderID =JO.Joborderid),0)"
            str &= "    as RecvQuantity"
            str &= "    ,isnull((select SUM(ID.IssueQty) from IssueDetail  ID "
            str &= "    where ID.SeasonDatabaseID  = JO.SeasonDatabaseID AND ID.JobOrderID =JO.Joborderid),0)"
            str &= "    as IssueQuantity"
            str &= "      ,isnull((select SUM(ID.Rate) from IssueDetail  ID "
            str &= "   where ID.SeasonDatabaseID  = JO.SeasonDatabaseID AND ID.JobOrderID =JO.Joborderid),0)"
            str &= "    as IssueRate"
            str &= "   from POMaster POM  "
            str &= "   join PODetail POD on POd.POId=POM.POId       "
            str &= "   join SupplierDatabase Sd on SD.SupplierDatabaseId=POD.AccountPayablePartyID  "
            str &= "   JOIN JobOrderdatabase JO ON JO.Joborderid =POD.joborderid "
            str &= "    where POD.SeasonDatabaseID = '" & SeasonDatabaseID & "' And POD.joborderid = '" & Joborderid & "' And POM.FabricPOrder = 0 "
            str &= "   GROUP BY JO.SeasonDatabaseID,JO.joborderid,POD.PoDetailId,pod.Rate  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvSrNoViseFstore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "    select  isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm "
            str &= " join podetail pd on pd.poid=pm.poid"
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pd.Joborderid"
            str &= " where pm.FabricPOrder=1 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvSrNoViseAstore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "    select isnull(SUM((pd.Quantity) *(pd.rate)*(pd.ExchangeRate)),0) as Amount from pomaster pm "
            str &= " join podetail pd on pd.poid=pm.poid"
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pd.Joborderid"
            str &= " where pm.FabricPOrder=0 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueSrNoViseFstore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "     select isnull(SUM((PDD.IssueQty) *(pdd.rate)),0) as Amount from IssueMst pm "
            str &= " join IssueDetail  PDD on pdd.IssueID  =pm.IssueID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pdd.Joborderid"
            str &= "  join poMaster pom on pom.poid=PDD.poid"
            str &= " where pom.FabricPOrder=1 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueSrNoViseAstore(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long)
            Dim str As String
            str = "     select isnull(SUM((PDD.IssueQty) *(pdd.rate)),0) as Amount from IssueMst pm "
            str &= " join IssueDetail  PDD on pdd.IssueID  =pm.IssueID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =pdd.Joborderid"
            str &= "  join poMaster pom on pom.poid=PDD.poid"
            str &= " where pom.FabricPOrder=0 and Jo.SeasonDatabaseID  ='" & SeasonDatabaseID & "' and Jo.Joborderid='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueJan(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='01' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueFeb(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='02' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuemarch(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='03' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueapril(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='04' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuemay(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='05' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuejune(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='06' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuejuly(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='07' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueaug(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='08' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuesep(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='09' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssueoct(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='10' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuenov(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='11' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOIssuedec(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.IssueQty) *(pdd.Rate)) as Amount from IssueMst   pm join IssueDetail  PDD on pdd.IssueID  =pm.IssueID where month(pm.CreationDate)='12' and year(pm.CreationDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvJan(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='01' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvmARCH(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='03' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvaPRIL(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='04' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvMay(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='05' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvjune(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='06' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvjuly(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='07' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvaUG(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='08' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvsEP(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='09' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvOct(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='10' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvnov(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='11' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvDec(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='12' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPORecvFeb(ByVal year As String)
            Dim str As String
            str = "  select SUM((PDD.RecvQuantity) *(pd.rate)*(pd.ExchangeRate)) as Amount from PORecvMaster  pm join PORecvDetail PDD on pdd.PORecvMasterID =pm.PORecvMasterID join podetail pd on pd.poid=pm.poid  where month(pm.PORecvDate)='02' and year(pm.PORecvDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOFstore(ByVal year As String, ByVal Month As String)
            Dim str As String
            str = " select Sum(pd.quantity * pd.Rate) as Amountt from pomaster pm join podetail pd on pd.poid=pm.poid  where month(pm.CreationDate)='" & Month & "' and year(pm.CreationDate)='" & year & "' AND PM.FabricPOrder =1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataPOAstore(ByVal year As String, ByVal Month As String)
            Dim str As String
            str = " select Sum(pd.quantity * pd.Rate) as Amountt from pomaster pm join podetail pd on pd.poid=pm.poid  where month(pm.CreationDate)='" & Month & "' and year(pm.CreationDate)='" & year & "' AND PM.FabricPOrder =0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierBangaladesh()
            Dim str As String
            str = " select * from vender where CountryID =20"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
       
        Function GetDataTurnoverJan(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='01' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverFeb(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='02' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverMarch(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='03' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverApril(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='04' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverMay(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='05' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverJune(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='06' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverJuly(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='07' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverAug(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='08' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverSep(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='09' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverOct(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='10' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverNov(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='11' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataTurnoverDec(ByVal year As String)
            Dim str As String
            str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='12' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnJan(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='01' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnFeb(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='02' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnMarch(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='03' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnApril(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='04' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnMay(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='05' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnJune(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='06' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnJuly(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='07' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnAug(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='08' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnSep(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='09' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnOct(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='10' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnNov(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='11' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataSeasonVolumnDec(ByVal Year As String, ByVal SeasonDatabaseID As Long)
            Dim str As String
            str = " select isnull(SUM(jod.Quantity),0) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='12' and year(jod.StyleShipmentDate)='" & Year & "' and jo.SeasonDatabaseID='" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetReportdateForAccOrderWIse(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where "
            Str &= " SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) "
            Str &= " as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid join tempPurchasingSummarySrno jj on jj.JobOrdeId=jo.JobOrderId"
            Str &= "  where"
            Str &= " jo.ShipmentStatus =0"
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetReportdateForAcc(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where "
            Str &= " SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) "
            Str &= " as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid"
            Str &= "  where"
            Str &= " jo.ShipmentStatus =0"
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetTotalSamples(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select  ISNULL(sum(Quantity),0) as Quantity from TblDPRND jo"
            Str &= "  where"
            Str &= " jo.ContactNo ='na'"
            If Year <> "All" Then
                Str &= " and year(jo.CreatDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jo.CreatDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetTotalSamplesSupplierVise(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select  ISNULL(sum(Quantity),0) as Quantity from TblDPRND jo join DPFabricDbMst dp on dp.FabricDBMstId =jo.FabricDBMstId join TempTotalSamples ss on ss.SupplierId=dp.SupplierID "
            Str &= "  where"
            Str &= " jo.ContactNo ='na'"
            If Year <> "All" Then
                Str &= " and year(jo.CreatDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jo.CreatDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetTurnover(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity "
            Str &= "   from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid"
            Str &= "  where"
            Str &= " jo.ShipmentStatus =0"
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetTurnoverOrderVise(ByVal Year As String, ByVal Month As String)
            Dim Str As String

            Str = " select isnull((isnull((jod.Quantity),0)*  isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0))/100 +(jod.Quantity),0) * (jod.UnitPrice) as Quantity "
            Str &= "   from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid join tempTurnOver tt on tt.JobOrdeid=jo.JobOrderId"
            Str &= "  where"
            Str &= " jo.ShipmentStatus =0"
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataVolumnJan(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='01' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnFeb(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='02' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnMarch(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='03' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnApril(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='04' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnMay(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='05' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnJune(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='06' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnJuly(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='07' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnAug(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='08' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnSep(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='09' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnOct(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='10' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnNov(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='11' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataVolumnDec(ByVal year As String)
            Dim str As String
            str = " select (isnull((jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 +(jod.Quantity) as Quantity  from JobOrderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where month(jod.StyleShipmentDate)='12' and year(jod.StyleShipmentDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDJan(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='01' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDFeb(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='02' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDMarch(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='03' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDApril(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='04' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDMay(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='05' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDJune(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='06' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDJuly(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='07' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDAug(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='08' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDSep(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='09' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDOct(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='10' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDNov(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='11' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataRNDDec(ByVal year As String)
            Dim str As String
            str = " select ISNULL(sum(Quantity),0) as Quantity from TblDPRND where month(CreatDate )='12' and year(CreatDate)='" & year & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomer2018()
            Dim str As String
            str = " select * from Customer where Year(CreationDate)='2018'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomer2017()
            Dim str As String
            str = " select * from Customer where Year(CreationDate)='2017'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetTaiwan()
            Dim str As String
            str = " select * from vender where CountryID =218"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPakistan()
            Dim str As String
            str = " select * from vender where CountryID =171"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetChina()
            Dim str As String
            str = " select * from vender where CountryID =46"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCAMBODIA()
            Dim str As String
            str = " select * from vender where CountryID =38"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerAll()
            Dim str As String
            str = " select * from Customer "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierAll()
            Dim str As String
            str = " select * from vender "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAllUserId()
            Dim str As String
            str = " select distinct O.OfficeID from UMUser um"
            str &= " join Offices O on O.OfficeID=um.OfficeID where IsActive=1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAllpobRANCHcODE()
            Dim str As String
            str = " select distinct u.BranchCode,u.BranchDescription from PurchaseOrder Po "
            str &= " join UMUser U on u.UserId =po.MarchandID"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCountriesIds()
            Dim str As String
            str = " select distinct v.CountryID  from Vender V"
            str &= " join VenderGradingScale VC on VC.VenderID =V.VenderLibraryID "
            str &= " join Countries  C on C.Country_id  =V.CountryID  "
            str &= "  WHERE V.WPF = 1"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierAllForGarments()
            Dim str As String
            str = " select distinct v.CountryID,C.CountryName   from vender v"
            str &= " join PurchaseOrder  po on po.SupplierID =v.VenderLibraryID "
            str &= " join VenderDetail vd on vd.VenderID =v.VenderLibraryID "
            str &= " join SupplierType st on st.TypeId =vd.ID"
            str &= "  join Countries C on C.Country_id =V.CountryID"
            str &= " where st.SupplierType ='GARMENTS SUPPLIER' and vd.Type ='Supplier Type'"
            str &= " order by C.CountryName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCountryViseData(ByVal CountryID As Long)
            Dim str As String
            'str = " select *,UPPER(LEFT(C.CountryName,1))+LOWER(SUBSTRING(C.CountryName,2,LEN(C.CountryName))) as Name from Vender V"
            'str &= " join Countries C on C.Country_id =v.CountryID"
            'str &= "  where v.CountryID =" & CountryID

            str = " Select distinct v.VenderLibraryID"
            str &= " from PurchaseOrder po "
            str &= " join PurchaseOrderDetail POD on POD.POID=Po.POID "
            str &= " join StyleMaster SS on SS.StyleID=pod.StyleID "
            str &= " join StyleDetail SD on SD.StyleDetailID =POD.StyleDetailID "
            str &= " Join UnitOfMeasurement UO on UO.UOMID=POD.UnitID"
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid     "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID   "
            str &= " join Offices OFFi ON  OFFi.OfficeID= UM. OfficeID  "
            str &= " join Departments DEP on DEP.ID =PO.Composition "
            str &= " join Countries ccc on ccc.Country_id =v.CountryID "
            str &= " where v.CountryID  =' " & CountryID & " ' and year(po.ShipmentDate)<>'2019' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShortName(ByVal CountryID As Long)

            Dim str As String

            str = " select *,UPPER(LEFT(C.CountryName,1))+LOWER(SUBSTRING(C.CountryName,2,LEN(C.CountryName))) as Name from Countries C"
            str &= "  where C.Country_ID =" & CountryID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetOfficeViseUsers(ByVal OfficeID As Long)

            Dim str As String

            str = " Select OfficeName, BranchDescription, UserId, UserName, ECPDivistion from UMUser UM"
            str &= " join Offices O on O.OfficeID=um.OfficeID"
            str &= "   where IsActive=1 and UM.OfficeID =" & OfficeID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShipmentData2018(ByVal BranchCode As Long)

            Dim str As String

            str = " select isnull(SUM((POD.Quantity) * (POD.Rate)),0) AS Turnover from PurchaseOrder Po "
            str &= " join PurchaseOrderDetail POD on POD.POID =Po.POID "
            str &= " join UMUser U on u.UserId =po.MarchandID"
            str &= "  where  year(Po.ShipmentDate)='2018' and U.BranchCode  =" & BranchCode

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetNotActiveDetox(ByVal CountryID As Long)

            Dim str As String

            str = " select isnull(st.SupplierType,'') as SupplierStatus,*"
            str &= " ,(case when VC.DETOXTo <GETDATE() then 'Not Active' else 'Active' end) as StatussActive"
            str &= " ,(case when (select TOP 1 vv.CertificateID from venderCertificate VV where vv.VenderID =V.VenderLibraryID)=19 then 'Yes' else 'No' end) as DetoxStatuss"
            str &= " from Vender V"
            str &= " join VenderGradingScale VC on VC.VenderID =V.VenderLibraryID "
            str &= " join Countries  C on C.Country_id  =V.CountryID  "
            str &= " left join VenderDetail VD on vd.VenderID=v.VenderLibraryID "
            str &= " left join SupplierType ST on ST.TypeId =VD.id"
            str &= " where  V.WPF =1 and vd.Type ='Supplier Type' and V.CountryID =" & CountryID
            str &= " order by V.VenderName asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetActiveDetox(ByVal CountryID As Long)

            Dim str As String

            str = " select isnull(st.SupplierType,'') as SupplierStatus,*"
            str &= " ,(case when VC.DETOXTo <GETDATE() then 'Not Active' else 'Active' end) as StatussActive"
            str &= " ,(case when (select TOP 1 vv.CertificateID from venderCertificate VV where vv.VenderID =V.VenderLibraryID)=19 then 'Yes' else 'No' end) as DetoxStatuss"
            str &= " from Vender V"
            str &= " join VenderGradingScale VC on VC.VenderID =V.VenderLibraryID "
            str &= " join Countries  C on C.Country_id  =V.CountryID  "
            str &= " left join VenderDetail VD on vd.VenderID=v.VenderLibraryID "
            str &= " left join SupplierType ST on ST.TypeId =VD.id"
            str &= "  where V.WPF =1 and vd.Type ='Supplier Type' and VC.DETOXTo>=GETDATE() and V.CountryID =" & CountryID
            str &= " order by V.VenderName asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShipmentData2017(ByVal BranchCode As Long)

            Dim str As String

            str = " select isnull(SUM((POD.Quantity) * (POD.Rate)),0) AS Turnover from PurchaseOrder Po "
            str &= " join PurchaseOrderDetail POD on POD.POID =Po.POID "
            str &= " join UMUser U on u.UserId =po.MarchandID"
            str &= "  where  year(Po.ShipmentDate)='2017' and U.BranchCode  =" & BranchCode

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

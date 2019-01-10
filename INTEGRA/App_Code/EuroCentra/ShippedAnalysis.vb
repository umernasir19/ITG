Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class ShippedAnalysis
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ShippedAnalysis"
            m_strPrimaryFieldName = "ShippedAnalysisID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lShippedAnalysisID As Long
        Private m_lCustomerid As Long
        Private m_strCustomername As String
        Private m_strJanQty As Decimal
        Private m_strJanValue As Decimal
        Private m_strFebQty As Decimal
        Private m_strFebValue As Decimal
        Private m_strMarQty As Decimal
        Private m_strMarValue As Decimal
        Private m_strAprQty As Decimal
        Private m_strAprValue As Decimal
        Private m_strMayQty As Decimal
        Private m_strMayValue As Decimal
        Private m_strJunQty As Decimal
        Private m_strJunValue As Decimal
        Private m_strJulQty As Decimal
        Private m_strJulValue As Decimal
        Private m_strAugQty As Decimal
        Private m_strAugValue As Decimal
        Private m_strSepQty As Decimal
        Private m_strSepValue As Decimal
        Private m_strOctQty As Decimal
        Private m_strOctValue As Decimal
        Private m_strNovQty As Decimal
        Private m_strNovValue As Decimal
        Private m_strDecQty As Decimal
        Private m_strDecValue As Decimal
        Private m_strTotalQty As Decimal
        Private m_strTotalValue As Decimal

        Public Property ShippedAnalysisID() As Long
            Get
                ShippedAnalysisID = m_lShippedAnalysisID
            End Get
            Set(ByVal value As Long)
                m_lShippedAnalysisID = value
            End Set
        End Property
        Public Property Customerid() As Long
            Get
                Customerid = m_lCustomerid
            End Get
            Set(ByVal value As Long)
                m_lCustomerid = value
            End Set
        End Property
        Public Property Customername() As String
            Get
                Customername = m_strCustomername
            End Get
            Set(ByVal value As String)
                m_strCustomername = value
            End Set
        End Property
        Public Property JanQty() As Decimal
            Get
                JanQty = m_strJanQty
            End Get
            Set(ByVal value As Decimal)
                m_strJanQty = value
            End Set
        End Property
        Public Property JanValue() As Decimal
            Get
                JanValue = m_strJanValue
            End Get
            Set(ByVal value As Decimal)
                m_strJanValue = value
            End Set
        End Property
        Public Property FebQty() As Decimal
            Get
                FebQty = m_strFebQty
            End Get
            Set(ByVal value As Decimal)
                m_strFebQty = value
            End Set
        End Property
        Public Property FebValue() As Decimal
            Get
                FebValue = m_strFebValue
            End Get
            Set(ByVal value As Decimal)
                m_strFebValue = value
            End Set
        End Property
        Public Property MarQty() As Decimal
            Get
                MarQty = m_strMarQty
            End Get
            Set(ByVal value As Decimal)
                m_strMarQty = value
            End Set
        End Property
        Public Property MarValue() As Decimal
            Get
                MarValue = m_strMarValue
            End Get
            Set(ByVal value As Decimal)
                m_strMarValue = value
            End Set
        End Property
        Public Property AprQty() As Decimal
            Get
                AprQty = m_strAprQty
            End Get
            Set(ByVal value As Decimal)
                m_strAprQty = value
            End Set
        End Property
        Public Property AprValue() As Decimal
            Get
                AprValue = m_strAprValue
            End Get
            Set(ByVal value As Decimal)
                m_strAprValue = value
            End Set
        End Property
        Public Property MayQty() As Decimal
            Get
                MayQty = m_strMayQty
            End Get
            Set(ByVal value As Decimal)
                m_strMayQty = value
            End Set
        End Property
        Public Property MayValue() As Decimal
            Get
                MayValue = m_strMayValue
            End Get
            Set(ByVal value As Decimal)
                m_strMayValue = value
            End Set
        End Property
        Public Property JunQty() As Decimal
            Get
                JunQty = m_strJunQty
            End Get
            Set(ByVal value As Decimal)
                m_strJunQty = value
            End Set
        End Property
        Public Property JunValue() As Decimal
            Get
                JunValue = m_strJunValue
            End Get
            Set(ByVal value As Decimal)
                m_strJunValue = value
            End Set
        End Property
        Public Property JulQty() As Decimal
            Get
                JulQty = m_strJulQty
            End Get
            Set(ByVal value As Decimal)
                m_strJulQty = value
            End Set
        End Property
        Public Property JulValue() As Decimal
            Get
                JulValue = m_strJulValue
            End Get
            Set(ByVal value As Decimal)
                m_strJulValue = value
            End Set
        End Property
        Public Property AugQty() As Decimal
            Get
                AugQty = m_strAugQty
            End Get
            Set(ByVal value As Decimal)
                m_strAugQty = value
            End Set
        End Property
        Public Property AugValue() As Decimal
            Get
                AugValue = m_strAugValue
            End Get
            Set(ByVal value As Decimal)
                m_strAugValue = value
            End Set
        End Property
        Public Property SepQty() As Decimal
            Get
                SepQty = m_strSepQty
            End Get
            Set(ByVal value As Decimal)
                m_strSepQty = value
            End Set
        End Property
        Public Property SepValue() As Decimal
            Get
                SepValue = m_strSepValue
            End Get
            Set(ByVal value As Decimal)
                m_strSepValue = value
            End Set
        End Property
        Public Property OctQty() As Decimal
            Get
                OctQty = m_strOctQty
            End Get
            Set(ByVal value As Decimal)
                m_strOctQty = value
            End Set
        End Property
        Public Property OctValue() As Decimal
            Get
                OctValue = m_strOctValue
            End Get
            Set(ByVal value As Decimal)
                m_strOctValue = value
            End Set
        End Property
        Public Property NovQty() As Decimal
            Get
                NovQty = m_strNovQty
            End Get
            Set(ByVal value As Decimal)
                m_strNovQty = value
            End Set
        End Property
        Public Property NovValue() As Decimal
            Get
                NovValue = m_strNovValue
            End Get
            Set(ByVal value As Decimal)
                m_strNovValue = value
            End Set
        End Property
        Public Property DecQty() As Decimal
            Get
                DecQty = m_strDecQty
            End Get
            Set(ByVal value As Decimal)
                m_strDecQty = value
            End Set
        End Property
        Public Property DecValue() As Decimal
            Get
                DecValue = m_strDecValue
            End Get
            Set(ByVal value As Decimal)
                m_strDecValue = value
            End Set
        End Property
        Public Property TotalQty() As Decimal
            Get
                TotalQty = m_strTotalQty
            End Get
            Set(ByVal value As Decimal)
                m_strTotalQty = value
            End Set
        End Property
        Public Property TotalValue() As Decimal
            Get
                TotalValue = m_strTotalValue
            End Get
            Set(ByVal value As Decimal)
                m_strTotalValue = value
            End Set
        End Property
        Public Function SaveShippedAnalysis()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerList(ByVal Year As Long)
            Dim str As String
            str = " select distinct C.Customerid,C.Customername from Cargodetail CD"
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
            str = " select distinct C.Customerid,C.Customername from Cargodetail CD"
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
            str = " select distinct C.Customerid,C.Customername from Cargodetail CD"
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
            str = " select distinct C.Customerid,C.Customername from   Purchaseorder PO "
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
            str = " select distinct C.Customerid,C.Customername from   Purchaseorder PO "
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
            str = " select distinct C.Customerid,C.Customername from   Purchaseorder PO "
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
    End Class
End Namespace
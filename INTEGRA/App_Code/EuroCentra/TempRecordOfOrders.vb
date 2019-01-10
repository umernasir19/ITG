Imports System.Data

Namespace EuroCentra
    Public Class TempRecordOfOrders
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempRecordOfOrders"
            m_strPrimaryFieldName = "TableID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTableID As Long
        Private m_lPOID As Long
        Private m_dcBookedQuantity As Decimal
        Private m_dcBookedValueInDollar As Decimal
        Private m_dcShippedQuantity As Decimal
        Private m_dcShipValue As Decimal
        Private m_dcCancelQuantity As Decimal
        Private m_dcCancelValue As Decimal
        Private m_dcInHandQty As Decimal
        Private m_dcInHandValue As Decimal
        Public Property TableID() As Long
            Get
                TableID = m_lTableID
            End Get
            Set(ByVal value As Long)
                m_lTableID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
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
        Public Property BookedValueInDollar() As Decimal
            Get
                BookedValueInDollar = m_dcBookedValueInDollar
            End Get
            Set(ByVal value As Decimal)
                m_dcBookedValueInDollar = value
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
        Public Property ShipValue() As Decimal
            Get
                ShipValue = m_dcShipValue
            End Get
            Set(ByVal value As Decimal)
                m_dcShipValue = value
            End Set
        End Property
        Public Property CancelQuantity() As Decimal
            Get
                CancelQuantity = m_dcCancelQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcCancelQuantity = value
            End Set
        End Property
        Public Property CancelValue() As Decimal
            Get
                CancelValue = m_dcCancelValue
            End Get
            Set(ByVal value As Decimal)
                m_dcCancelValue = value
            End Set
        End Property
        Public Property InHandQty() As Decimal
            Get
                InHandQty = m_dcInHandQty
            End Get
            Set(ByVal value As Decimal)
                m_dcInHandQty = value
            End Set
        End Property
        Public Property InHandValue() As Decimal
            Get
                InHandValue = m_dcInHandValue
            End Get
            Set(ByVal value As Decimal)
                m_dcInHandValue = value
            End Set
        End Property
        Public Function SaveTempRecordOfOrders()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function BookedData(ByVal FromDate As String, ByVal ToDate As String)
            Dim str As String
            str = " Select POID from Purchaseorder PO "
            str &= " where  PO.shipmentdate between '" & FromDate & "' and '" & ToDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getBookedQuantity(ByVal POID As Integer)
            Dim str As String
            str = " Select SUM(POD.Quantity) From Purchaseorderdetail POD join Purchaseorder PO on PO.POID=POD.POID"
            str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getBookedValueInDollar(ByVal POID As Integer)
            Dim str As String
            str = " Select  (Select (Case when PO.Currency  <> 'Dollar' then  SUM(POD.Quantity * POD.Rate) * PO.Exchangerate"
            str &= " else SUM(POD.Quantity * POD.Rate)"
            str &= " end)  from Purchaseorderdetail POD"
            str &= " where POD.POID=PO.POID) as BookedVal From Purchaseorder PO "
            str &= " where PO.POID =" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShippedQtyData(ByVal POID As Integer, ByVal FromDate As String, ByVal ToDate As String)
            Dim str As String
            str = " Select Isnull(SUM(CD.Quantity),0) From CargoDetail CD join Cargo CR on CR.CargoID=CD.CargoID "
            str &= " where   CR.ETD between '" & FromDate & "' and '" & ToDate & "' and CD.POPOID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getShipValue(ByVal POID As Integer, ByVal FromDate As String, ByVal ToDate As String)
            Dim str As String
            str &= " select (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull(SUm(CD.quantity),0)))* PO.Exchangerate"
            str &= " else ( IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull(SUm(CD.quantity),0)) ) end) "
            str &= " from CargoDetail CD join Cargo C ON C.CargoID=CD.CargoID "
            str &= " join Purchaseorder PO on PO.POID=Cd.POPOID "
            str &= " where   C.etd between '" & FromDate & "' and '" & ToDate & "' and CD.POPOID=" & POID
            str &= " group by PO.ExchangeRate,PO.POID,PO.Currency "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCancelQuantity(ByVal POID As Integer)
            Dim str As String
            str = "  Select isnull(SUM(POC.CancelQty),0) From POCancelDetail POC Where POC.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCancelValue(ByVal POID As Integer)
            Dim str As String
            str = " Select (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * IsNull((Select SUM(POC.CancelQty) From POCancelDetail POC Where "
            str &= " POC.POID=PO.POID),0))* PO.Exchangerate"
            str &= " else (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * IsNull((Select SUM(POC.CancelQty) From POCancelDetail POC Where "
            str &= " POC.POID=PO.POID),0)) end) "
            str &= " From PurchaseORder PO "
            str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getInHandQty(ByVal POID As Integer)
            Dim str As String
            str = " Select (case when IsNull((Select SUM(CD.Quantity) From CargoDetail CD Where "
            str &= " CD.POPOID=PO.POID),0) >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then 0 else IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) - IsNull((Select SUM(CD.Quantity) From CargoDetail CD Where "
            str &= " CD.POPOID=PO.POID),0) - IsNull((Select SUM(CancelQty) From POCancelDetail POC Where PO.POID=POC.POID),0)end)"
            str &= " From PurchaseORder PO "
            str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getInHandValue(ByVal POID As Integer)
            Dim str As String
            str = " Select (case when IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " >= IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) then IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)-IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)else (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(CancelQty) From POCancelDetail POC Where PO.POID=POC.POID),0)"
            str &= " ))* PO.Exchangerate  else ( IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0)- IsNull((Select SUM(Quantity) From Cargodetail COD Where PO.POID=COD.POPOID),0)"
            str &= " - IsNull((Select SUM(CancelQty) From POCancelDetail POC Where PO.POID=POC.POID),0))) end)end)"
            str &= " From PurchaseORder PO "
            str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CargoData(ByVal FromDate As String, ByVal ToDate As String)
            Dim str As String
            str = " Select Distinct CD.POPOID from Cargodetail CD join Cargo CR on CR.cargoID=Cd.CargoID"
            str &= " where CR.ShipmentDate between '" & FromDate & "' and '" & ToDate & "' "
            str &= " and Cd.POPOID not in (Select POID from Purchaseorder where Tolerance between '" & FromDate & "' and '" & ToDate & "')"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function TruncateTable()
            Dim str As String
            str = " TRUNCATE TABLE  TempRecordOfOrders "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function checkLastYearData(ByVal POID As Integer)
            Dim str As String
            str = " Select * from Purchaseorder Where POID=" & POID
            str &= " and Year(Tolerance)< 2013"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getBookedQuantityLastYear(ByVal POID As Integer)
            Dim str As String
            str = " Select SUM(POD.Quantity) From Purchaseorderdetail POD join Purchaseorder PO on PO.POID=POD.POID"
            str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShippedQtyDataLasteYear(ByVal POID As Integer)
            Dim str As String
            str = " Select Isnull(SUM(CD.Quantity),0) From CargoDetail CD join Cargo CR on CR.CargoID=CD.CargoID "
            str &= " where   Year(CR.ShipmentDate) < 2013 and CD.POPOID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCancelQuantityLastYear(ByVal POID As Integer)
            Dim str As String
            str = "  Select isnull(SUM(POC.Quantity),0) From POCancelQuantity POC Where  Year(POC.Creationdate) < 2013 and POC.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getBookedValueInLastYear(ByVal POID As Integer)
            Dim str As String
            str = " Select (case when PO.Currency <> 'Dollar' then  SUM(POD.Quantity * Rate) * PO.Exchangerate else (POD.Quantity * POD.Rate) end) as BookedVal From Purchaseorderdetail POD join Purchaseorder PO on PO.POID=POD.POID"
            str &= " where PO.POID=" & POID
            str &= "  group by PO.ExchangeRate,PO.Currency,POD.Quantity,POD.Rate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getShipValueLastYear(ByVal POID As Integer)
            Dim str As String
            str &= " select (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull(SUm(CD.quantity),0)))* PO.Exchangerate"
            str &= " else ( IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * (IsNull(SUm(CD.quantity),0)) ) end) "
            str &= " from CargoDetail CD join Cargo C ON C.CargoID=CD.CargoID "
            str &= " join Purchaseorder PO on PO.POID=Cd.POPOID "
            str &= " where   Year(CR.ShipmentDate) < 2013  and CD.POPOID=" & POID
            str &= " group by PO.ExchangeRate,PO.POID,PO.Currency "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCancelValueLastYear(ByVal POID As Integer)
            Dim str As String
            str = " Select (case when PO.Currency <>'Dollar' then "
            str &= " (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * IsNull((Select SUM(POC.Quantity) From POCancelQuantity POC Where "
            str &= " POC.POID=PO.POID),0))* PO.Exchangerate"
            str &= " else (IsNull((Select SUM(Quantity * rate)/SUM(Quantity) From Purchaseorderdetail POD Where "
            str &= " PO.POID=POD.POID),0) * IsNull((Select SUM(POC.Quantity) From POCancelQuantity POC Where "
            str &= " POC.POID=PO.POID),0)) end) "
            str &= " From PurchaseORder PO "
            str &= " where  Year(POC.Creationdate) < 2013 and PO.POID=" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace
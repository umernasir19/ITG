Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class MGTMarchand


 Inherits SQLManager
        Public Sub New()
            m_strTableName = "MGTMarchandReport"
            m_strPrimaryFieldName = "MGTId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''

        Private m_lMGTId As Long
        Private m_dtCreationDate As Date
        Private m_lMarchandID As Long
        Private m_strMarchandName As String
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
        Public Function SaveMGTMarchand()
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
        Public Function TruncateTable()
            Dim str As String
            str = "  truncate table MGTMarchandReport "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtMarchandData()
            Dim Str As String
            Str = "  select Distinct U.Userid,U.Username from Umuser U "
            Str &= " join Purchaseorder Po on Po.Marchandid=U.Userid "
            Str &= " where (Year(PO.creationDate) >= 2012) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Str &= " group by po.MarchandID"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Str &= " group by po.MarchandID"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTimeETA(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  Join PORelatedFields SM on PO.ShipmentMode =  SM.ID where "

            Str &= "  (case when  SM.name='Seafreight' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35,  PO.Shipmentdate)  else DATEADD(DAY, 27,  PO.Shipmentdate)"
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7,  PO.Shipmentdate)  else DATEADD(DAY, 5,  PO.Shipmentdate)  end)  end)"
            Str &= "   between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.MarchandID = " & MarchandID

            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO  where "
            Str &= "  (case when  SM.name='Seafreight' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35,  PO.Shipmentdate)  else DATEADD(DAY, 27,  PO.Shipmentdate)"
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7,  PO.Shipmentdate)  else DATEADD(DAY, 5,  PO.Shipmentdate)  end)  end)"
            Str &= "   between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , "
            Str &= "  (case when  C.Terms='Sea' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35, C.ETD)  else DATEADD(DAY, 27,  C.ETD) "
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7, C.ETD)  else DATEADD(DAY, 5,  C.ETD)  end)  end) ))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function

        'Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
        '    Dim Str As String
        '    Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        '    Str &= " join Cargo c on c.cargoid=cd.cargoid"
        '    Str &= " join purchaseorder po on po.poid=cd.popoid "
        '    'Str &= " join purchaseorderdetail pod on pod.Podetailid=cd.poid"
        '    Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        '    Try
        '        Return MyBase.GetScaler(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedForPOsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Str &= " group by po.MarchandID"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPosNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Str &= " group by po.MarchandID"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTimeETA(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  Join PORelatedFields SM on PO.ShipmentMode =  SM.ID where "

            Str &= "  (case when  SM.name='Seafreight' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35,  PO.Shipmentdate)  else DATEADD(DAY, 27,  PO.Shipmentdate)"
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7,  PO.Shipmentdate)  else DATEADD(DAY, 5,  PO.Shipmentdate)  end)  end)"
            Str &= "   between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.MarchandID = " & MarchandID

            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO  where "
            Str &= "  (case when  SM.name='Seafreight' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35,  PO.Shipmentdate)  else DATEADD(DAY, 27,  PO.Shipmentdate)"
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7,  PO.Shipmentdate)  else DATEADD(DAY, 5,  PO.Shipmentdate)  end)  end)"
            Str &= "   between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
            Str &= " and po.status !='Cancel' And PO.MarchandID =" & MarchandID
            Str &= " ) and (DATEDIFF(dd, "
            Str &= "  (case when  SM.name='Seafreight' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35,  PO.Shipmentdate)  else DATEADD(DAY, 27,  PO.Shipmentdate)"
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7,  PO.Shipmentdate)  else DATEADD(DAY, 5,  PO.Shipmentdate)  end)  end) , "
            Str &= "  (case when  C.Terms='Sea' then  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 35, C.ETD)  else DATEADD(DAY, 27,  C.ETD) "
            Str &= " end) else  (case when  PO.Destination='USA' then"
            Str &= " DATEADD(DAY, 7, C.ETD)  else DATEADD(DAY, 5,  C.ETD)  end)  end) ))/7 <=0 "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
        '    Dim Str As String
        '    Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
        '    Str &= " join Cargo c on c.cargoid=cd.cargoid"
        '    Str &= " join purchaseorder po on po.poid=cd.popoid "
        '    Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.MarchandID = " & MarchandID
        '    Try
        '        Return MyBase.GetScaler(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetMGTBookedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "Select  PO.ExchangeRate, "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = "Select  PO.ExchangeRate, "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012   and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select "
            Str &= " (case when C.Currency <> 'Dollar' then "
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
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select "
            Str &= " (case when C.Currency <> 'Dollar' then "
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
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedCommNew(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedCommNew2(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And PO.MarchandID = " & MarchandID
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedCommNew(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select Sum("
            Str &= " (case when PO.Currency <> 'Dollar' then "
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " ))*Isnull((C.ShippedExchangeRate),0)"
            Str &= " else"
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " )) end) * cc.Commission /100) as"
            Str &= " ShippedTurOver"
            Str &= " from Cargodetail cd join Cargo c on c.cargoid=cd.cargoid"
            Str &= "  join purchaseorder po on po.poid=cd.popoid join Customer CC on CC.Customerid=PO.Customerid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedCommNew2(ByVal Fromdate As String, ByVal ToDate As String, ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select Sum("
            Str &= " (case when PO.Currency <> 'Dollar' then "
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " ))*Isnull((C.ShippedExchangeRate),0)"
            Str &= " else"
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " )) end) * cc.Commission /100) as"
            Str &= " ShippedTurOver"
            Str &= " from Cargodetail cd join Cargo c on c.cargoid=cd.cargoid"
            Str &= "  join purchaseorder po on po.poid=cd.popoid join Customer CC on CC.Customerid=PO.Customerid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTClaiPcs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select  PO.ExchangeRate,SUM(Isnull((C.ClaimPcs),0))  as ClaimPcs from POClaim  C "
            Str &= "  join PurchaseOrder PO on po.POID=c.POID "
            Str &= " where c.creationdate  between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "   select count(PO.POID) as TotalPOs from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPosCheckTimelyShipped(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "   select PO.POID from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPOsTimelyShippedSecond(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal POID As Long)
            Dim Str As String
            Str = "select cd.POID  from Cargodetail cd"
            Str &= "  join Cargo c on c.cargoid=cd.cargoid"
            Str &= "  join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.POID = " & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBookedCommission(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "   select PO.Commission from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBookedEXRate(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal MarchandID As Long)
            Dim Str As String
            Str = "   select PO.Commission from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.MarchandID = " & MarchandID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GEtECP()
            Dim Str As String
            Str = " select distinct  U.ECPDivistion  from PurchaseOrder PO join UMUser U on U.UserId =PO.MarchandID where Year(shipmentdate)>= 2013"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductGroup(ByVal ECPDivision As String)
            Dim Str As String
            Str = " select Distinct ProductPortfolioID, P.ProductPortfolio    from ProductPortfolio P"
            Str &= " join PurchaseOrder PO on PO.ProductGroup=P.ProductPortfolio"
            Str &= " join UMUser U on U.UserId =PO.MarchandID"
            Str &= " where U.ECPDivistion = '" & ECPDivision & "'"
            Str &= " and Year(PO.shipmentdate)>= 2013 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductCategories(ByVal ProductPortfolioID As Long, ByVal ECPDivision As String)
            Dim Str As String
            Str = " Select  Distinct PC.ProductCategories from ProductCategories PC"
            Str &= " join ProductPortfolio P on P.ProductPortfolioID=PC.ProductPortfolioID"
            Str &= " join PurchaseOrder PO on PO.ProductCategories=PC.ProductCategories"
            Str &= " join UMUser U on U.UserId =PO.MarchandID"
            Str &= " Where Pc.ProductPortfolioID = '" & ProductPortfolioID & "' and U.ECPDivistion = '" & ECPDivision & "'"
            Str &= " and Year(PO.shipmentdate)>= 2013 "
            Str &= " order by PC.ProductCategories ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductCategoriesForAll(ByVal ECPDivision As String)
            Dim Str As String
            Str = " Select Distinct PC.ProductCategories from ProductCategories PC"
            Str &= " join ProductPortfolio P on P.ProductPortfolioID=PC.ProductPortfolioID"
            Str &= " join PurchaseOrder PO on PO.ProductCategories=PC.ProductCategories"
            Str &= " join UMUser U on U.UserId =PO.MarchandID"
            Str &= " Where  U.ECPDivistion = '" & ECPDivision & "'"
            Str &= " and Year(PO.shipmentdate)>= 2013 "
            Str &= " order by PC.ProductCategories ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

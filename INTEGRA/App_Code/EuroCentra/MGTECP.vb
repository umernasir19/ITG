Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class MGTECP
Inherits SQLManager
        Public Sub New()
            m_strTableName = "MGTECPReport"
            m_strPrimaryFieldName = "MGTId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''

        Private m_lMGTId As Long
        Private m_dtCreationDate As Date
        Private m_lUserID As Long
        Private m_strECPDivistion As String
        Private m_strProductGroup As String
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
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal value As Long)
                m_lUserID = value
            End Set
        End Property
        Public Property ECPDivistion() As String
            Get
                ECPDivistion = m_strECPDivistion
            End Get
            Set(ByVal value As String)
                m_strECPDivistion = value
            End Set
        End Property
        Public Property ProductGroup() As String
            Get
                ProductGroup = m_strProductGroup
            End Get
            Set(ByVal value As String)
                m_strProductGroup = value
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
        Public Function SaveMGTECP()
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
            str = " TRUNCATE TABLE MGTECPReport "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtECPData()
            Dim Str As String
            Str = " select Distinct U.ECPDivistion from Umuser U "
            Str &= " join Purchaseorder Po on Po.Marchandid=U.Userid "
            Str &= " where Year(PO.creationDate) >= 2012 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " group by UM.ECPDivistion"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " group by UM.ECPDivistion"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
            Str &= " and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'  "
            Str &= " and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
        '    Dim Str As String
        '    Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
        '    Str &= " join Cargo c on c.cargoid=cd.cargoid"
        '    Str &= " join purchaseorder po on po.poid=cd.popoid "
        '    Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
        '    Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
        '    Try
        '        Return MyBase.GetScaler(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "' "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedForPOsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "' "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= " group by UM.ECPDivistion"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPosNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= " group by UM.ECPDivistion"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'   and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
        '    Dim Str As String
        '    Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
        '    Str &= " join Cargo c on c.cargoid=cd.cargoid"
        '    Str &= " join purchaseorder po on po.poid=cd.popoid "
        '    Str &= "  join UMUser UM on UM.UserId = PO.MarchandID"
        '    Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And UM.ECPDivistion = '" & ECPDivistion & "'"
        '    Try
        '        Return MyBase.GetScaler(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetMGTBookedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "Select  PO.ExchangeRate, "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "Select  PO.ExchangeRate, "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
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
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion='" & ECPDivistion & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
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
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion='" & ECPDivistion & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTClaiPcs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "  select  PO.ExchangeRate,SUM(Isnull((C.ClaimPcs),0))  as ClaimPcs from POClaim  C "
            Str &= "  join PurchaseOrder PO on po.POID=c.POID "
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.creationdate  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select count(PO.POID) as TotalPOs from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPosCheckTimelyShipped(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select PO.POID from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
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
        Public Function GetMGTBookedCommNew(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedCommNew2(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
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
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012  and po.status !='Cancel' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Str &= " group by C.Commission "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetMGTShippedCommNew(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
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
            Str &= "  join purchaseorder po on po.poid=cd.popoid join Customer CC on CC.Customerid=PO.Customerid  Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedCommNew2(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
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
            Str &= "  join purchaseorder po on po.poid=cd.popoid join Customer CC on CC.Customerid=PO.Customerid  Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBookedCommission(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select PO.Commission from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBookedEXRate(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select PO.Commission from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductGroup(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select PO.MarchandID,PO.ProductGroup from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Return MyBase.GetScaler(Str)
            Try
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductGroupNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal ECPDivistion As String)
            Dim Str As String
            Str = "   select PO.MarchandID,PO.ProductGroup from PurchaseOrder PO"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And UM.ECPDivistion ='" & ECPDivistion & "'"
            Return MyBase.GetScaler(Str)
            Try
            Catch ex As Exception
            End Try
        End Function
      
    End Class
End Namespace
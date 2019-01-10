Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class PurchaseOrder
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PurchaseOrder"
            m_strPrimaryFieldName = "POID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Const _maxItems As Integer = 100000

        Private m_lPOId As Long
        Private m_strPONO As String
        Private m_strStatus As String
        Private m_strPOtype As String
        Private m_iCustomerID As Integer
        Private m_iSupplierID As Integer
        Private m_DPlacementDate As Date
        Private m_DShipmentDate As Date
        Private m_dCommission As Decimal
        Private m_strTolerance As String
        Private m_strToleranceindays As String
        Private m_lTimeSpame As Long
        Private m_dtCreationDate As Date
        Private m_strProductGroup As String
        Private m_strDesign As String
        ''-----------------Properties  
        Private m_strSeason As String
        Private m_strQuality As String
        Private m_strConstruction As String
        Private m_strShipmentMode As String
        Private m_strPaymentMode As String
        Private m_strPaymentType As String
        Private m_strEKNumber As String
        Private m_strDeliveryType As String
        Private m_strCurrency As String
        Private m_strPORefNo As String
        Private m_dbExchangeRate As Double
        Private m_dtExchangeDate As Date
        Private m_dtLastUpdate As Date
        Private m_lMarchandID As Long
        Private m_strXMLFileName As String
        Private m_strBuyerName As String
        Private m_strBuyingDepartment As String
        Private m_strContactName As String
        Private m_strBuyerStreet As String
        Private m_strBuyerZip As String
        Private m_strBuyerCity As String
        Private m_strBuyerCountry As String
        Private m_strContactPhone As String
        Private m_strContactFax As String
        Private m_strContactEmail As String
        Private m_strDeliveryName As String
        Private m_strDeliveryStreet As String
        Private m_strDeliveryZip As String
        Private m_strDeliveryCity As String
        Private m_strAirFreight As String
        Private m_strSeaFreight As String
        Private m_strComposition As String
        Private m_strDestination As String
        Private m_strProcessType As String
        Private m_strProductCategories As String
        Private m_bIsActive As Boolean

        Private m_dtInqDate As Date
        Private m_strStage As String
        Private m_lUserID As Long
        Private m_strPOComplaintType As String
        Private m_strInquiryPurpose As String
        Private m_lInquiryInitialID As Long
        Private m_lInquiryRepeatlID As Long
        Private m_strMasterPO As String
      
        Public Property InqDate() As Date
            Get
                InqDate = m_dtInqDate
            End Get
            Set(ByVal value As Date)
                m_dtInqDate = value
            End Set
        End Property
        Public Property Stage() As String
            Get
                Stage = m_strStage
            End Get
            Set(ByVal value As String)
                m_strStage = value
            End Set
        End Property
        Public Property InquiryPurpose() As String
            Get
                InquiryPurpose = m_strInquiryPurpose
            End Get
            Set(ByVal value As String)
                m_strInquiryPurpose = value
            End Set
        End Property
        Public Property InquiryInitialID() As Long
            Get
                InquiryInitialID = m_lInquiryInitialID
            End Get
            Set(ByVal value As Long)
                m_lInquiryInitialID = value
            End Set
        End Property
        Public Property InquiryRepeatlID() As Long
            Get
                InquiryRepeatlID = m_lInquiryRepeatlID
            End Get
            Set(ByVal value As Long)
                m_lInquiryRepeatlID = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Property ProcessType() As String
            Get
                ProcessType = m_strProcessType
            End Get
            Set(ByVal value As String)
                m_strProcessType = value
            End Set
        End Property
        Public Property ProductCategories() As String
            Get
                ProductCategories = m_strProductCategories
            End Get
            Set(ByVal value As String)
                m_strProductCategories = value
            End Set
        End Property
        Public Property Destination() As String
            Get
                Destination = m_strDestination
            End Get
            Set(ByVal value As String)
                m_strDestination = value
            End Set
        End Property
        Public Property Composition() As String
            Get
                Composition = m_strComposition
            End Get
            Set(ByVal value As String)
                m_strComposition = value
            End Set
        End Property
        Public Property Season() As String
            Get
                Season = m_strSeason
            End Get
            Set(ByVal value As String)
                m_strSeason = value
            End Set
        End Property
        Public Property Quality() As String
            Get
                Quality = m_strQuality
            End Get
            Set(ByVal value As String)
                m_strQuality = value
            End Set
        End Property
        Public Property Construction() As String
            Get
                Construction = m_strConstruction
            End Get
            Set(ByVal value As String)
                m_strConstruction = value
            End Set
        End Property
        Public Property ShipmentMode() As String
            Get
                ShipmentMode = m_strShipmentMode
            End Get
            Set(ByVal value As String)
                m_strShipmentMode = value
            End Set
        End Property
        Public Property PaymentMode() As String
            Get
                PaymentMode = m_strPaymentMode
            End Get
            Set(ByVal value As String)
                m_strPaymentMode = value
            End Set
        End Property
        Public Property PaymentType() As String
            Get
                PaymentType = m_strPaymentType
            End Get
            Set(ByVal value As String)
                m_strPaymentType = value
            End Set
        End Property
        Public Property EKNumber() As String
            Get
                EKNumber = m_strEKNumber
            End Get
            Set(ByVal value As String)
                m_strEKNumber = value
            End Set
        End Property
        Public Property DeliveryType() As String
            Get
                DeliveryType = m_strDeliveryType
            End Get
            Set(ByVal value As String)
                m_strDeliveryType = value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal value As String)
                m_strCurrency = value
            End Set
        End Property
        Public Property PORefNo() As String
            Get
                PORefNo = m_strPORefNo
            End Get
            Set(ByVal value As String)
                m_strPORefNo = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOId
            End Get
            Set(ByVal Value As Long)
                m_lPOId = Value
            End Set
        End Property
        Public Property PONO() As String
            Get
                PONO = m_strPONO
            End Get
            Set(ByVal value As String)
                m_strPONO = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal value As String)
                m_strStatus = value
            End Set
        End Property
        Public Property POtype() As String
            Get
                POtype = m_strPOtype
            End Get
            Set(ByVal value As String)
                m_strPOtype = value
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
        Public Property Design() As String
            Get
                Design = m_strDesign
            End Get
            Set(ByVal value As String)
                m_strDesign = value
            End Set
        End Property
        Public Property CustomerID() As Integer
            Get
                CustomerID = m_iCustomerID
            End Get
            Set(ByVal value As Integer)
                m_iCustomerID = value
            End Set
        End Property
        Public Property SupplierID() As Integer
            Get
                SupplierID = m_iSupplierID
            End Get
            Set(ByVal value As Integer)
                m_iSupplierID = value
            End Set
        End Property
        Public Property PlacementDate() As Date
            Get
                PlacementDate = m_DPlacementDate
            End Get
            Set(ByVal value As Date)
                m_DPlacementDate = value
            End Set
        End Property
        Public Property ShipmentDate() As Date
            Get
                ShipmentDate = m_DShipmentDate
            End Get
            Set(ByVal value As Date)
                m_DShipmentDate = value
            End Set
        End Property
        Public Property Commission() As Decimal
            Get
                Commission = m_dCommission
            End Get
            Set(ByVal value As Decimal)
                m_dCommission = value
            End Set
        End Property
        Public Property Tolerance() As String
            Get
                Tolerance = m_strTolerance
            End Get
            Set(ByVal value As String)
                m_strTolerance = value
            End Set
        End Property
        Public Property Toleranceindays() As String
            Get
                Toleranceindays = m_strToleranceindays
            End Get
            Set(ByVal value As String)
                m_strToleranceindays = value
            End Set
        End Property
        Public Property TimeSpame() As Long
            Get
                TimeSpame = m_lTimeSpame
            End Get
            Set(ByVal Value As Long)
                m_lTimeSpame = Value
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
        Public Property ExchangeRate() As Double
            Get
                ExchangeRate = m_dbExchangeRate
            End Get
            Set(ByVal value As Double)
                m_dbExchangeRate = value
            End Set
        End Property
        Public Property ExchangeDate() As Date
            Get
                ExchangeDate = m_dtExchangeDate
            End Get
            Set(ByVal value As Date)
                m_dtExchangeDate = value
            End Set
        End Property
        Public Property LastUpdate() As Date
            Get
                LastUpdate = m_dtLastUpdate
            End Get
            Set(ByVal value As Date)
                m_dtLastUpdate = value
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
        Public Property XMLFileName() As String
            Get
                XMLFileName = m_strXMLFileName
            End Get
            Set(ByVal value As String)
                m_strXMLFileName = value
            End Set
        End Property
        Public Property BuyerName() As String
            Get
                BuyerName = m_strBuyerName
            End Get
            Set(ByVal value As String)
                m_strBuyerName = value
            End Set
        End Property
        Public Property BuyingDepartment() As String
            Get
                BuyingDepartment = m_strBuyingDepartment
            End Get
            Set(ByVal value As String)
                m_strBuyingDepartment = value
            End Set
        End Property
        Public Property ContactName() As String
            Get
                ContactName = m_strContactName
            End Get
            Set(ByVal value As String)
                m_strContactName = value
            End Set
        End Property
        Public Property BuyerStreet() As String
            Get
                BuyerStreet = m_strBuyerStreet
            End Get
            Set(ByVal value As String)
                m_strBuyerStreet = value
            End Set
        End Property
        Public Property BuyerZip() As String
            Get
                BuyerZip = m_strBuyerZip
            End Get
            Set(ByVal value As String)
                m_strBuyerZip = value
            End Set
        End Property
        Public Property BuyerCity() As String
            Get
                BuyerCity = m_strBuyerCity
            End Get
            Set(ByVal value As String)
                m_strBuyerCity = value
            End Set
        End Property
        Public Property BuyerCountry() As String
            Get
                BuyerCountry = m_strBuyerCountry
            End Get
            Set(ByVal value As String)
                m_strBuyerCountry = value
            End Set
        End Property
        Public Property ContactPhone() As String
            Get
                ContactPhone = m_strContactPhone
            End Get
            Set(ByVal value As String)
                m_strContactPhone = value
            End Set
        End Property
        Public Property ContactFax() As String
            Get
                ContactFax = m_strContactFax
            End Get
            Set(ByVal value As String)
                m_strContactFax = value
            End Set
        End Property
        Public Property ContactEmail() As String
            Get
                ContactEmail = m_strContactEmail
            End Get
            Set(ByVal value As String)
                m_strContactEmail = value
            End Set
        End Property
        Public Property DeliveryName() As String
            Get
                DeliveryName = m_strDeliveryName
            End Get
            Set(ByVal value As String)
                m_strDeliveryName = value
            End Set
        End Property
        Public Property DeliveryStreet() As String
            Get
                DeliveryStreet = m_strDeliveryStreet
            End Get
            Set(ByVal value As String)
                m_strDeliveryStreet = value
            End Set
        End Property
        Public Property DeliveryZip() As String
            Get
                DeliveryZip = m_strDeliveryZip
            End Get
            Set(ByVal value As String)
                m_strDeliveryZip = value
            End Set
        End Property
        Public Property DeliveryCity() As String
            Get
                DeliveryCity = m_strDeliveryCity
            End Get
            Set(ByVal value As String)
                m_strDeliveryCity = value
            End Set
        End Property
        Public Property AirFreight() As String
            Get
                AirFreight = m_strAirFreight
            End Get
            Set(ByVal value As String)
                m_strAirFreight = value
            End Set
        End Property
        Public Property SeaFreight() As String
            Get
                SeaFreight = m_strSeaFreight
            End Get
            Set(ByVal value As String)
                m_strSeaFreight = value
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
        Public Property POComplaintType() As String
            Get
                POComplaintType = m_strPOComplaintType
            End Get
            Set(ByVal value As String)
                m_strPOComplaintType = value
            End Set
        End Property
        Public Property MasterPO() As String
            Get
                MasterPO = m_strMasterPO
            End Get
            Set(ByVal value As String)
                m_strMasterPO = value
            End Set
        End Property
        Public Function SavePurchaseOrderSetup()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOById(ByVal lPOId As Long)
            Try
                Return MyBase.GetById(lPOId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPurchaseOrder(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If

            Dim Str As String
            ' Str = "Select * from PurchaseOrder"
            ' Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor,"
            'Str &= " (Select Isnull(SUM(Quantity)*Sum(Rate),0) from PurchaseOrderDetail where POID =PO.POID)as Amount   from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor, (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD where SbPOD.POID =PO.POID),0)))) as Amount,U.UserName from PurchaseOrder PO "
            'Str &= "  Join PurchaseOrderDetail POD on POD.POID =PO.POID"
            Str &= "  Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on UserID=PO.MarchandID"
            Str &= "  where PONO<>''  and status !='Cancel'  "
            If Not Status = "ALL" Then
                Str &= " and Status='" & Status & "'"
            End If
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            If Not Buyer = "ALL" Then
                Str &= " and PO.CustomerID ='" & Buyer & "'"
            End If
            If Not Shipment = "ALL" Then
                Shipment = GetMonth(Shipment)
                Str &= " and Month(PO.ShipmentDate)='" & Shipment & "'"
            End If
            If Not Booked = "ALL" Then
                Booked = GetMonth(Booked)
                Str &= " and Month(PO.PlacementDate)='" & Booked & "'"
            End If
            If Not RoleID = 1 Or RoleID = 12 Or RoleID = 4 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= "Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName,Currency order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrder2(ByVal USerID As String, ByVal RoleID As Long, ByVal PONO As String) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If

            Dim Str As String
            ' Str = "Select * from PurchaseOrder"
            ' Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor,"
            'Str &= " (Select Isnull(SUM(Quantity)*Sum(Rate),0) from PurchaseOrderDetail where POID =PO.POID)as Amount   from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor, (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD where SbPOD.POID =PO.POID),0)))) as Amount,U.UserName from PurchaseOrder PO "
            'Str &= "  Join PurchaseOrderDetail POD on POD.POID =PO.POID"
            Str &= "  Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on UserID=PO.MarchandID"
            Str &= "  where PONO<>''  and   year(PO.creationdate)>= '2012'  "
            Str &= " and PONO='" & PONO & "'"
            If Not RoleID = 1 Or RoleID = 12 Or RoleID = 4 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= "Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName,Currency,U.UserName order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderNew(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal PONo As String, ByVal UserID As String, ByVal RoleID As Long, ByVal ShipmentYear As String) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If
            Dim Str As String
            ' Str = "Select * from PurchaseOrder"
            ' Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor,"
            'Str &= " (Select Isnull(SUM(Quantity)*Sum(Rate),0) from PurchaseOrderDetail where POID =PO.POID)as Amount   from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor, (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD where SbPOD.POID =PO.POID),0)))) as Amount,U.UserName  "
            Str &= "  ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= "  order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= "  ,isNUll((Select Top 1 ('Article:'+ SD.Article +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= " join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip'"
            Str &= "  from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on UserID=PO.MarchandID"
            Str &= "  where PONO<>''  and status !='Cancel' and Year(PO.CreationDate)>= '2012'  "
            If Status = "Open" Then
                Str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
            Else
                If Not Status = "ALL" Then
                    Str &= " and Status='" & Status & "' "
                End If
            End If
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "' "
            End If
            If Not Buyer = "ALL" Then
                Str &= " and PO.CustomerID ='" & Buyer & "' "
            End If
            If Not Shipment = "ALL" Then
                Shipment = GetMonth(Shipment)
                Str &= " and Month(PO.ShipmentDate)='" & Shipment & "' "
            End If
            If Not ShipmentYear = "ALL" Then
                Str &= " and Year(PO.ShipmentDate)='" & ShipmentYear & "' "
            End If
            If Not Booked = "ALL" Then
                Booked = GetMonth(Booked)
                Str &= " and Month(PO.PlacementDate)='" & Booked & "' "
            End If
            If Not PONo = "ALL" Then
                Str &= " and PO.PONO='" & PONo & "' "
            End If

            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                If UserID = 68 Or UserID = 69 Or UserID = 70 Or UserID = 71 Then
                    Str &= "  and  U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') "
                Else
                    Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & UserID & "')"
                End If
            End If

            Str &= " Group by PO.POID,PO.PONo, U.UserName,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName,Currency order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderNewPO(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal POID As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If
            Dim Str As String
            ' Str = "Select * from PurchaseOrder"
            ' Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor,"
            'Str &= " (Select Isnull(SUM(Quantity)*Sum(Rate),0) from PurchaseOrderDetail where POID =PO.POID)as Amount   from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor, (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD where SbPOD.POID =PO.POID),0)))) as Amount,U.UserName from PurchaseOrder PO "
            'Str &= "  Join PurchaseOrderDetail POD on POD.POID =PO.POID"
            Str &= "  Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on UserID=PO.MarchandID"
            Str &= "  where PONO<>''  and status !='Cancel' and Year(PO.CreationDate)>= '2012' "
            If Not Status = "ALL" Then
                Str &= " and Status='" & Status & "'"
            End If
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            If Not Buyer = "ALL" Then
                Str &= " and PO.CustomerID ='" & Buyer & "'"
            End If
            If Not Shipment = "ALL" Then
                Shipment = GetMonth(Shipment)
                Str &= " and Month(PO.ShipmentDate)='" & Shipment & "'"
            End If
            If Not Booked = "ALL" Then
                Booked = GetMonth(Booked)
                Str &= " and Month(PO.PlacementDate)='" & Booked & "'"
            End If
            If Not POID = "ALL" Then
                Str &= " and PO.POID='" & POID & "'"
            End If
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                If USerID = 68 Or USerID = 69 Or USerID = 70 Or USerID = 71 Then
                    Str &= "  and  U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & USerID & "') "
                Else
                    Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
                End If

            End If
            Str &= "Group by PO.POID,PO.PONo, U.UserName,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName,Currency order by po.PONo desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderStylewise(ByVal Vender As String, ByVal Buyer As String, ByVal Style As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If
            Dim Str As String
            Str = "select PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as "
            Str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            Str &= " C.CustomerName as CustomerName,V.VenderName as vendorName "
            Str &= " ,S.styleNo,Sum(POD.Quantity)as Quantity from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"
            Str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " join UmUser u on U.UserID=Po.MarchandID"
            Str &= "  where PONO<>''  "
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            If Not Buyer = "ALL" Then
                Str &= " and PO.CustomerID ='" & Buyer & "'"
            End If
            If Not Style = "ALL" Then

                Str &= " and  S.StyleNo= '" & Style & "'"
            End If
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= "group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStylewiseData(ByVal Style As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If
            Dim Str As String
            Str = "select PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as "
            Str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            Str &= " C.CustomerName as CustomerName,V.VenderName as vendorName "
            Str &= " ,S.styleNo,Sum(POD.Quantity)as Quantity from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"
            Str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " join UmUser u on U.UserID=Po.MarchandID"
            Str &= "  where PONO<>''  "
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= "group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetMonth(ByVal Month As String)
            Select Case Month
                Case "January"
                    Return 1
                Case "February"
                    Return 2
                Case "March"
                    Return 3
                Case "April"
                    Return 4
                Case "May"
                    Return 5
                Case "June"
                    Return 6
                Case "July"
                    Return 7
                Case "August"
                    Return 8
                Case "September"
                    Return 9
                Case "October"
                    Return 10
                Case "November"
                    Return 11
                Case "December"
                    Return 12
            End Select
        End Function
        Public Function GetPurchaseOrderByNo(ByVal USerID As String, ByVal RoleID As Long, ByVal POType As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTo As String = "", Optional ByVal CustomerID As Long = 0, Optional ByVal VendorID As Long = 0, Optional ByVal Claim As String = "", Optional ByVal POStatus As String = "", Optional ByVal SeachType As String = "") As DataTable
            Dim Str As String
            Str = "Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName as Customer,V.VenderName as vendor, Convert(Decimal,(Select Isnull(SUM(Quantity)*Sum(Rate),0) from PurchaseOrderDetail where POID =PO.POID),0)as Amount   "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD on POD.POID =PO.POID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            If POType <> "All Type" Then
                Str &= "Where PO.POTYpe='" & POType & "' "
            Else
                Str &= "Where PO.POTYpe in ('New','Repeat','Short Shipment') "
            End If
            If SeachType = "PODate" Then
                If DateFrom <> "" And DateTo = "" Then
                    DateFrom = DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2)
                    Str &= " and PlacementDate ='" & DateFrom & "'"
                End If
                If DateTo <> "" And DateFrom = "" Then
                    DateTo = DateTo.Substring(6, 4) & "-" & DateTo.Substring(3, 2) & "-" & DateTo.Substring(0, 2)
                    Str &= " and PlacementDate ='" & DateTo & "'"
                End If
                If DateTo <> "" And DateFrom <> "" Then
                    Str &= " and PlacementDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTo.Substring(6, 4) & "-" & DateTo.Substring(3, 2) & "-" & DateTo.Substring(0, 2) & "'"
                End If
            Else
                If DateFrom <> "" And DateTo = "" Then
                    Str &= " and PONO ='" & DateFrom & "'"
                End If
                If DateTo <> "" And DateFrom = "" Then
                    Str &= " and PNo ='" & DateTo & "'"
                End If
                If DateTo <> "" And DateFrom <> "" Then
                    Str &= " and PONO Between '" & DateFrom & "' and '" & DateTo & "' "
                End If
            End If
            If CustomerID <> 0 Then
                Str &= " and PO.CustomerID ='" & CustomerID & "'"
            End If
            If VendorID <> 0 Then
                Str &= " and PO.SupplierID ='" & VendorID & "'"
            End If
            If Claim = "Completed Succesfully" Then
                Str &= " and PO.POID Not in( Select POID From POClaim)"
            ElseIf Claim = "Under Claim" Then
                Str &= " and PO.POID in( Select POID From POClaim)"
            End If
            If POStatus = "Confirmed" Then
                Str &= " and PO.Status ='Confirmed'"
            ElseIf POStatus = "Close" Then
                Str &= " and PO.Status ='Close'"
            End If
            ' New
            If Not RoleID = "1" Then
                Str &= " and   PO.MarchandID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            'end
            Str &= " Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderByPO(ByVal lPOID As Long) As DataTable
            Dim Str As String
            '  Str = "Select * from PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID=POD.POID Join Style Sty on Sty.StyleID=POD.StyleID where  PO.POID=" & lPOID
            'old
            'Str = " Select *,Dt.Name as DeliveryTypeName,PM.Name as PaymentModeName, PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            'Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID=POD.POID Join Style Sty on Sty.StyleID=POD.StyleID "
            'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            'Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            'Str &= " where  PO.POID=" & lPOID
            Str = " Select *,POD.StyleDetailID,SD.Article,SD.ArticleDescription,SD.Colorway,SD.SizeRange,SD.Price,Dt.Name as DeliveryTypeName,PM.Name as PaymentModeName, PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID=POD.POID Join StyleMaster Sty on Sty.StyleID=POD.StyleID "
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForTNASelection()
            Dim Str As String
            '  Str = "Select POID,PONO from PurchaseOrder Where POID Not in(Select POID from TNAChart)"
            Str = "Select PO.POID,PO.PONO  from PurchaseOrder PO Join  PurchaseOrderDetail POD on POD.POID =PO.POID Where PO.POID Not in(Select POID from TNAChart) group by PO.POID,PO.PONO"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForTNAChart(ByVal BuyerID As Long, ByVal VenderID As Long)
            Dim Str As String
            Str = "Select POID,PONO from PurchaseOrder Where POID in(Select POID from TNAChart) And CustomerID=" & BuyerID & " and SupplierID=" & VenderID & " "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForSampleDev()
            Dim Str As String
            Str = "Select POID,PONo,SupplierID,PlacementDate,ShipmentDate  from PurchaseOrder where Status Not in('Close') and POType ='New'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPODetailByPOID(ByVal POID As Long)
            Dim Str As String
            Str = "Select SupplierID,PlacementDate,ShipmentDate  from PurchaseOrder where POID=" & POID & ""
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVenderByPOID(ByVal POID As Long) As Long
            Dim Str As String
            Str = "Select SupplierID  from PurchaseOrder where POID=" & POID & ""
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOBySupplier(ByVal lSupplierID As Long)
            Dim Str As String
            Str = "Select POID,PONo from PurchaseOrder where Status='Confirmed' and POType='New' and SupplierID=" & lSupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforAI()
            Dim Str As String
            Str = "Select POID,PONo from PurchaseOrder where Status='Confirmed' and POType='New' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOReport()
            Dim Str As String
            Str = "Select POID,PONo from PurchaseOrder where Status='Confirmed'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPODetailforTestRpt(ByVal lPOID As Long)
            Dim Str As String
            Str = "Select Convert(varchar,PlacementDate,106)as PlacementDate,TimeSpame,Convert(Varchar,ShipmentDate,106)as ShipmentDate from PurchaseOrder where   POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDetailForTNA(ByVal lPOID As Long)
            Dim Str As String
            Str = "Select PlacementDate,TimeSpame from PurchaseOrder Where POID =" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforShipment(ByVal lPOID As Long)
            Dim Str As String
            ' Str = "Select ISnull(ShipmentStatisticsID,0)as ShipmentStatisticsID,*,Convert(Decimal,Quantity*Rate,2) as Cvalue , ISNull((Select InspectedQuantityPCS from ProductionStatus where PODetailID=POD.PODetailID),0)as InspectedQuantity From PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID =POD.POID Join Style S On S.StyleID=PoD.StyleID  left Join ShipmentStatistics SS on SS.POID=PO.POID  where PO.POID=" & lPOID
            'Str = " Select PO.Design,PO.Status,PO.PlacementDate,POD.Quantity,IsNull(ShipmentStatisticsID,0)as ShipmentStatisticsID,IsNull(ShippedQuantity,0)as ShippedQuantity,IsNull(Defference,0)as Defference,IsNull(InvoiceValue,0)as InvoiceValue,IsNull(ETA,0)as ETA,IsNull(PODPak,0)as PODPak,IsNull(POD,0)as POD,IsNull(InvoiceNo,0)as InvoiceNo,IsNull(ShippingLine,0)as ShippingLine,IsNull(Vessel,0)as Vessel,IsNull(Voyage,0)as Voyage,IsNull(Container,0)as Container,IsNull(Ss.Remarks,0)as Remarks"
            'Str &= ",S.*,Convert(Decimal,Quantity*Rate,2) as Cvalue , ISNull((Select InspectedQuantityPCS from ProductionStatus where PODetailID=POD.PODetailID),0)as InspectedQuantity "
            'Str &= "From PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID =POD.POID Join Style S On S.StyleID=PoD.StyleID "
            'Str &= "left Join ShipmentStatistics SS on SS.POID=PO.POID and SS.StyleID=POD.StyleID "
            'Str &= " where PO.POID=" & lPOID
            Str = "Select PO.Design,PO.Status,PO.PlacementDate,POD.Quantity,Convert(Decimal,Quantity*Rate,2) as Cvalue,S.*,SS.* from ShipmentStatistics SS Join"
            Str &= " PurchaseOrder PO on PO.POID=SS.POID Join PurchaseOrderDetail POD on POD.POID=PO.POID Join ProductionStatus PS On POD.PODetailID=PS.PODetailID Join Style S On S.StyleID=SS.StyleID"
            Str &= " And SS.StyleID=POD.StyleID  where PS.Approved=1 and SS.POID=" & lPOID


            ' Str = "Select * from ShipmentStatistics where POID=" & lPOID

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetConfirmedPO(ByVal UserID As Long, ByVal RoleID As Long)
            Dim Str As String
            'Str = " Select PO.PONo  From  PurchaseOrder PO  Join TNAChart Cht on PO.POID=Cht.POID Join  UMUser U on UserID=PO.MarchandID "
            Str = "Select PO.PONo,CustomerName,VenderName,Process,"
            Str &= " (select SUM(POD.Quantity) From PurchaseOrderDetail POD Where PO.POID=POD.POID)as Quantity"
            Str &= " From  PurchaseOrder PO  Join TNAChart Cht on PO.POID=Cht.POID "
            Str &= " Join  UMUser U on UserID=PO.MarchandID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join TNAProcess Prcs on Prcs.ProcessID=Cht.TNAProcessID"
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " where  TNAProcessID in(24,21,19) and month(DateEstemated)=" & Now.Month & " and Day(DateEstemated)= " & Now.Day & " and year(DateEstemated)= " & Now.Year & " and PO.Status='Confirmed'"

            Else
                'Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and TNAProcessID in(24,21,19) and month(DateEstemated)=" & Now.Month & " and Day(DateEstemated)= " & Now.Day & " and year(DateEstemated)= " & Now.Year & " and PO.Status='Confirmed'"
                Str &= " where U.UserID in(Select UserID From UMUser where UserID='" & UserID & "') and TNAProcessID in(24,21,19) and month(DateEstemated)=" & Now.Month & " and Day(DateEstemated)= " & Now.Day & " and year(DateEstemated)= " & Now.Year & " and PO.Status='Confirmed'"

            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrentPO(ByVal UserID As Long, ByVal RoleID As Long)
            Dim Str As String
            Str = " Select Count(PO.PONo) as TotalCurrentPO  From  PurchaseOrder PO Join  UMUser U on UserID=PO.MarchandID "
            ' Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and Status='Confirmed'"
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " where  Status='Confirmed'"

            Else
                Str &= " where U.UserID in(Select UserID From UMUser where UserID='" & UserID & "') and Status='Confirmed'"

            End If
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOCreationDate(ByVal lPOID As Long) As Date
            Dim Str As String
            Str = " Select CreationDate  From  PurchaseOrder where POID=" & lPOID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetExchangeDate(ByVal lPOID As Long) As Date
            Dim Str As String
            Str = " Select ExchangeDate  From  PurchaseOrder where POID=" & lPOID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetExchangeRate(ByVal lPOID As Long) As Double
            Dim Str As String
            Str = " Select ExchangeRate  From  PurchaseOrder where POID=" & lPOID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataforChart(ByVal RoleID As Integer, ByVal UserID As Long)
            Dim Str As String
            Str = "Select"
            Str &= " (Select Count(PO.PONO) From PurchaseOrder PO  Join  UMUser U on UserID=PO.MarchandID "
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " Where Status='Confirmed' )as CurrentPO,"
            Else
                Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and  Status='Confirmed'  )as CurrentPO,"
            End If

            Str &= "(Select Count(TNAChartID) from TNAChart cht Join PurchaseOrder PO on cht.POID=PO.POID Join  UMUser U on UserID=PO.MarchandID where TNAChartID not in(Select TNAChartID from TNAChartHistory where  Status Not in('Created') and TNAProcessID=18)and TNAProcessID=18 "
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and PO.Status='Confirmed' )as CriticalZone "
            Else
                Str &= " and U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and PO.Status='Confirmed' )as CriticalZone"
            End If

            Str &= ",(Select Count(PO.POID)as ProductionPO  from ProductionStatus PS"
            Str &= " Join PurchaseOrderDetail PD on PD.PODetailID=PS.PODetailID "
            Str &= "Join PurchaseOrder PO on PO.POID=PD.POID Join  UMUser U on UserID=PO.MarchandID "


            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " Where Po.Status='Confirmed') as ProductionPO "
            Else
                Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and Status='Confirmed' )as ProductionPO"
            End If
            Str &= ",(Select Count(Po.POID)as InspectionPO from Inspection Ins Join PurchaseOrder PO on PO.POID=Ins.POID Join  UMUser U on UserID=PO.MarchandID"
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " Where Po.Status='Confirmed' )as Inspection"
            Else
                Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and Po.Status='Confirmed' )as Inspection"
            End If


            '            Str &= ",(Select count(PO.POID)as ShipmentStatisticsPO from ShipmentStatistics SS Join PurchaseOrder PO on PO.POID=SS.POID Join  UMUser U on UserID=PO.MarchandID"
            '           If RoleID = 1 Then
            'Str &= " Where Po.Status='Confirmed' )as ShipmentPO"
            'Else
            'Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and Po.Status='Confirmed' )as ShipmentPO"
            'End If

            Str &= " ,(Select Count(Distinct PONO)From PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID=POD.POID"
            Str &= " Join Style S on S.StyleID=POD.StyleID Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplieriD Join ImportXL SXL on SXL.OrderNO=PONo and SXL.CustomerID=C.CustomerID and SXL.SupplierNo=V.VenderCode and SXL.ArticleNo=S.Article"
            Str &= " Join UMUser U on UserID=PO.MarchandID "

            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " Where Po.Status='Confirmed' )as ShipmentPO"
            Else
                Str &= " where U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') and Po.Status='Confirmed' )as ShipmentPO"
            End If



            Str &= ",(Select Count(PO.POID) From PurchaseOrder PO where (case "
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-03'+'-31')) then 'Q1'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-06'+'-30')) then 'Q2'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-09'+'-30')) then 'Q3'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-12'+'-31')) then 'Q4'"
            Str &= " end )='Q1' and Po.Status='Close')as Q1Closed"

            Str &= ",(Select Count(PO.POID) From PurchaseOrder PO where (case "
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-03'+'-31')) then 'Q1'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-06'+'-30')) then 'Q2'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-09'+'-30')) then 'Q3'"
            Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-12'+'-31')) then 'Q4'"
            Str &= " end )='Q2' and Po.Status='Close')as Q2Closed"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SelectCount() As Integer
            Return _maxItems
        End Function
        Function GetDataforChartBYECP(ByVal ECPNo As String)
            Dim Str As String
            Str = "Select"
            Str &= " (Select Count(PO.PONO) From PurchaseOrder PO  Join  UMUser U on UserID=PO.MarchandID "

            Str &= " where U.ECPDivistion ='" & ECPNo & "' and  Status='Confirmed'  )as CurrentPO,"

            Str &= "(Select Count(TNAChartID) from TNAChart cht Join PurchaseOrder PO on cht.POID=PO.POID Join  UMUser U on UserID=PO.MarchandID where TNAChartID not in(Select TNAChartID from TNAChartHistory where  Status Not in('Created') and TNAProcessID=18)and TNAProcessID=18 "
            Str &= " and U.ECPDivistion ='" & ECPNo & "' and PO.Status='Confirmed' )as CriticalZone"

            Str &= ",(Select Count(PO.POID)as ProductionPO  from ProductionStatus PS"
            Str &= " Join PurchaseOrderDetail PD on PD.PODetailID=PS.PODetailID "
            Str &= "Join PurchaseOrder PO on PO.POID=PD.POID Join  UMUser U on UserID=PO.MarchandID "



            Str &= " where U.ECPDivistion ='" & ECPNo & "' and Status='Confirmed' )as ProductionPO"
            Str &= ",(Select Count(Po.POID)as InspectionPO from Inspection Ins Join PurchaseOrder PO on PO.POID=Ins.POID Join  UMUser U on UserID=PO.MarchandID"
            Str &= " where U.ECPDivistion ='" & ECPNo & "' and Po.Status='Confirmed' )as Inspection"


            ' Str &= ",(Select count(PO.POID)as ShipmentStatisticsPO from ShipmentStatistics SS Join PurchaseOrder PO on PO.POID=SS.POID Join  UMUser U on UserID=PO.MarchandID"
            ' Str &= " where U.ECPDivistion ='" & ECPNo & "' and Po.Status='Confirmed' )as ShipmentPO"

            Str &= " ,(Select Count(Distinct PONO)From PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID=POD.POID"
            Str &= " Join Style S on S.StyleID=POD.StyleID Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplieriD Join ImportXL SXL on SXL.OrderNO=PONo and SXL.CustomerID=C.CustomerID and SXL.SupplierNo=V.VenderCode and SXL.ArticleNo=S.Article"
            Str &= " Join UMUser U on UserID=PO.MarchandID "
            Str &= " where U.ECPDivistion ='" & ECPNo & "' and Po.Status='Confirmed' )as ShipmentPO"

            'Str &= ",(Select Count(PO.POID) From PurchaseOrder PO where (case "
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-03'+'-31')) then 'Q1'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-06'+'-30')) then 'Q2'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-09'+'-30')) then 'Q3'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-12'+'-31')) then 'Q4'"
            'Str &= " end )='Q1' and Po.Status='Close')as Q1Closed"

            'Str &= ",(Select Count(PO.POID) From PurchaseOrder PO where (case "
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(GETDATE()))+'-03'+'-31')) then 'Q1'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-06'+'-30')) then 'Q2'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-09'+'-30')) then 'Q3'"
            'Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(GETDATE()))+'-12'+'-31')) then 'Q4'"
            'Str &= " end )='Q2' and Po.Status='Close')as Q2Closed"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataforChartECPDivision()
            Dim Str As String
            Str = "Select (Select Count(PONo) from PurchaseOrder where  Status='Confirmed')as TotalPO,"
            Str &= " (Select Count(PONO) From UmUser U Join  RMUserRoles UR On U.UserId=Ur.UseriD Join RMRole R on UR.RoleID=R.RoleID"
            Str &= " inner Join PurchaseOrder PO on PO.MarchandID=U.UserID where U.ECPDivistion='ECP 01' and PO.Status='Confirmed')as ECP1"
            Str &= " ,(Select Count(PONO) From UmUser U Join  RMUserRoles UR On U.UserId=Ur.UseriD"
            Str &= " Join RMRole R on UR.RoleID=R.RoleID inner Join PurchaseOrder PO on PO.MarchandID=U.UserID"
            Str &= " where U.ECPDivistion='ECP 02'and PO.Status='Confirmed')as ECP2"
            Str &= " ,(Select Count(PONO) From UmUser U "
            Str &= " Join  RMUserRoles UR On U.UserId=Ur.UseriD"
            Str &= " Join RMRole R on UR.RoleID=R.RoleID"
            Str &= " inner Join PurchaseOrder PO on PO.MarchandID=U.UserID"
            Str &= " where U.ECPDivistion='ECP 03' and PO.Status='Confirmed')as ECP3"
            Str &= " ,(Select Count(PONO) From UmUser U "
            Str &= " Join  RMUserRoles UR On U.UserId=Ur.UseriD"
            Str &= " Join RMRole R on UR.RoleID=R.RoleID"
            Str &= " inner Join PurchaseOrder PO on PO.MarchandID=U.UserID"
            Str &= " where U.ECPDivistion='ECP 04' and PO.Status='Confirmed')as ECP4"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyWithTol(ByVal lPOID As Long, ByVal StyleID As Long) As Double
            Dim Str As String
            Str = "Select ((Convert(Decimal,(SUM(Quantity)/100)*5,3))+SUM(Quantity)) From PurchaseOrderDetail Where POID='" & lPOID & "' and StyleID='" & StyleID & "' "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSilderData()
            Dim str As String
            str = "Select Ranking='Top',ECP='ECP01',Merchand='XXXX',Image='~/Images/default_user_image.png'"
            str &= " Union Select Ranking='2nd',ECP='ECP02',Merchand='XXXX',Image='~/Images/default_user_image.png'"
            str &= " Union Select Ranking='3rd',ECP='ECP03',Merchand='XXXX',Image='~/Images/default_user_image.png'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetShipmentPopUpData(ByVal ShpimentDate As Date)
            Dim Str As String
            Str = " Select  PO.PONo,PO.POID,C.CustomerName,V.VenderName,SUM(Delivery)as InspectionQty from Inspection I"
            Str &= " Join PurchaseOrder PO on PO.POID=I.POID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            If Not ShpimentDate = #1/1/1900# Then
                Dim DefaullStyle As String = CStr(ShpimentDate.Year) + "-" + CStr(ShpimentDate.Month) + "-" + CStr(ShpimentDate.Day)

                Str &= " where ShipmentDate= '" & DefaullStyle & "'"
            End If
            Str &= " Group by PO.POID,PO.PONo,C.CustomerName,V.VenderName "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforFinalInsp(ByVal CustomerID As Long, ByVal SupID As Long)
            Dim Str As String
            Str = "Select POID,PONo from PurchaseOrder where CustomerID =" & CustomerID & " and SupplierID=" & SupID & " order by POno "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetArticle(ByVal POID As Long)
            Dim Str As String
            Str = "Select  Distinct Article  from PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID=POD.POID Join Style S on S.StyleID=POD.StyleID Where PO.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleNo(ByVal POID As Long)
            Dim Str As String
            Str = "Select  Distinct StyleNo  from PurchaseOrder PO Join PurchaseOrderDetail POD on PO.POID=POD.POID Join Style S on S.StyleID=POD.StyleID Where PO.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderByCustomerAndVender(ByVal CustomerID As Long, ByVal VenderID As Long)
            Dim Str As String
            Str = "Select PONo,POID From PurchaseOrder where CustomerID=" & CustomerID & " and SupplierID=" & VenderID & " and Status='Confirmed'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInspectedPOs()
            Dim Str As String
            Str = "Select Distinct PO.POID,PO.PONO From Inspection Ins Join PurchaseOrder PO On Ins.POID=PO.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOIDByvendorCodeandPONO(ByVal PONO As String, ByVal CustomerID As Long, ByVal VenderCode As String) As Long
            Dim Str As String
            Str = "Select POID  from PurchaseOrder PO Join Vender V on Po.SupplierID=V.VenderLibraryID where PONo='" & PONO & "' and CustomerID=" & CustomerID & " and  V.VenderCode='" & VenderCode & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSchedule() As DataTable
            Dim Str As String
            Str = "Select  Sequence,ProcessID,ScheduleTime as SchedularTime from TNAPRocess order by Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleNew(ByVal ECPDivision As String) As DataTable
            Dim Str As String
            If ECPDivision = "GIA 1" Then
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "   order by Sequence"
            Else
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "   order by Sequence"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyle(ByVal poid As Long) As DataTable
            Dim Str As String

            Str = "  select * from PurchaseOrderDetail where poid='" & poid & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleNewwithKnits(ByVal ECPDivision As String, ByVal ProductPortfolioID As Long) As DataTable
            Dim Str As String
            If ECPDivision = "GIA 1" Then
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= "from TNAProcess where Knits=1 AND  ACTIVE=1   order by Sequence"
            Else
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= "from TNAProcess where Knits=1  AND  ACTIVE=1  order by Sequence"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleNewwithHomeTextile(ByVal ECPDivision As String, ByVal ProductPortfolioID As Long) As DataTable
            Dim Str As String
            If ECPDivision = "GIA 1" Then
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= " from TNAProcess where HomeTextile=1  AND  ACTIVE=1  order by Sequence"
            Else
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= " from TNAProcess where HomeTextile=1 AND  ACTIVE=1   order by Sequence"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleNewwithWoven(ByVal ECPDivision As String, ByVal ProductPortfolioID As Long) As DataTable
            Dim Str As String
            If ECPDivision = "GIA 1" Then
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= "from TNAProcess where Woven=1  AND  ACTIVE=1  order by Sequence"
            Else
                Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
                Str &= "from TNAProcess where Woven=1  AND  ACTIVE=1  order by Sequence"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductInfo(ByVal Styleid As Long) As DataTable
            Dim Str As String

            Str = "  select * from StyleProductInformation where styleid='" & Styleid & "' "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleCELIO(ByVal ECPDivision As String) As DataTable
            Dim Str As String
            Str = "   Select    Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
            Str &= " where  ProcessID  between 90 and 118  order by Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllPO(Optional ByVal lPOID As Long = 0) As DataTable
            Dim Str As String
            If lPOID = 0 Then
                Str = "Select * from  PurchaseOrder Where POID not in (Select POID From TNAChart) order by POID"
            Else
                Str = "Select * from  PurchaseOrder Where POID not in (Select POID From TNAChart) and POID=" & lPOID & " order by POID"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getforedit(ByVal lPOID As Long) As DataTable
            Dim Str As String
            If lPOID = 0 Then
                Str = "Select * from  PurchaseOrder Where POID not in (Select POID From TNAChart) order by POID"
            Else
                Str = "Select * from  PurchaseOrder Where POID not in (Select POID From TNAChart) and POID=" & lPOID & " order by POID"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllPOForCP(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = "Select * from  PurchaseOrder Where CustomerID=46 and POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPOData(ByVal POID As Long)
            Dim Str As String
            Str = "Select timespame as LeadTime,PONo,CustomerName,VenderName,ShipmentDate,PlacementDate,SupplierID as VenderID,Season,EKNumber as DepartmentNo From PurchaseOrder PO"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on VenderLibraryID=SupplierID"
            Str &= " Where POID=" & POID

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPODataNew(ByVal joborderID As Long)
            Dim Str As String
            Str = " Select * From JobOrderdatabase  PO"
            Str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =PO.Joborderid "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            Str &= " Where PO.joborderID=" & joborderID

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Function GetStyleCommaSep(ByVal POID As Long)
            Dim Str As String
            Str = "  select distinct StyleNo from PurchaseorderDetail POD"
            Str &= "  Join StyleMaster SM on SM.StyleID=POD.StyleID  "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID  "
            Str &= " where POD.POID =" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetStyleNoE(ByVal StyleID As Long)
            Dim Str As String
            Str = "  select * from  StyleMaster "
            Str &= " where StyleID =" & StyleID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getPOPlacementDate(ByVal lPOID As Long)
            Dim Str As String
            Str = "Select PlacementDate From PurchaseOrder Where POID=" & lPOID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckXMLFileName(ByVal StrXMLFileName As String) As String
            Dim Str As String
            Str = "Select Isnull((Select PO='False' From PurchaseOrder where XMLFileName='" & StrXMLFileName & "'),'True')"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSupplyChain(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            Try
                Dim Str As String
                Str = "Select PO.POID ,(case when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))"
                Str &= " end ) as Q,PO.PONO,VenderName,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription,Sum(pod.Quantity) as POQuantity"
                Str &= " ,Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)as ShipmnetQty"
                Str &= " ,Cast((((Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)-SUM(POD.Quantity))/SUM(POD.Quantity))*100) as decimal(10,0))as Difference"
                Str &= " ,Cast(SUM(POD.Quantity*POD.rate)as decimal(10,2)) as Amount ,Convert(varchar,PO.Placementdate,106)as Placementdate,Convert(varchar,PO.ShipmentDate,106)as ShipmentDate "
                Str &= ",StrikeOffForecast='',StrikeOffActual='' ,YarnInHouseForecast='' ,YarnInHouseActual='' "
                Str &= ",YarnInHouseRPTorecast='',YarnInHouseRPTActual='',PhotoSamplesForecast='' "
                Str &= ",PhotoSamplesActual='' "
                Str &= ",SizeSetsSamplesForecast='' "
                Str &= ",SizeSetsSamplesActual=''"
                Str &= ",FabricInHouseForecast='' "
                Str &= ",FabricInHouseActual='' "
                Str &= ",FabricInHouseRPTForecast='' "
                Str &= ",FabricInHouseRPTActual=''"
                Str &= ",SoftProofofAccessoriesForecast=''"
                Str &= ",SoftProofofAccessoriesActual=''"
                Str &= " ,PhysicalAccessoriesForecast=''"
                Str &= " ,PhysicalAccessoriesActual=''"
                Str &= ",DyeingForecast=''"
                Str &= ",DyeingActual=''"
                Str &= " ,TechnicalSampleForecast=''"
                Str &= ",TechnicalSampleActual=''"
                Str &= ",SGSITSLabReportForecast=''"
                Str &= ",SGSITSLabReportActual=''"
                Str &= " ,PreProductionSamplesForecast=''"
                Str &= ",PreProductionSamplesActual=''"
                Str &= ",FoldingForecast=''"
                Str &= ",FoldingActual=''"
                Str &= " ,ShadeBandForecast=''"
                Str &= " ,ShadeBandActual=''"
                Str &= " ,CuttingForecast=''"
                Str &= " ,CuttingActual=''"
                Str &= " ,IstinlineInspectionForecast=''"
                Str &= ",IstinlineInspectionActual=''"
                Str &= " ,StitchingForecast=''"
                Str &= " ,StitchingActual=''"
                Str &= ",SecndinlineInspectionForecast=''"
                Str &= " ,SecndinlineInspectionActual=''"
                Str &= " ,PackingForecast=''"
                Str &= ",PackingActual=''"
                Str &= ",FinalInspectionForecast=''"
                Str &= ",FinalInspectionActual=''"
                Str &= ",ExMillDeliveryForecast=''"
                Str &= ",ExMillDeliveryActual=''"
                Str &= " ,ExPakistanDeliveryForecast=''"
                Str &= " ,ExPakistanDeliveryActual=''"
                Str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid Join Vender V on PO.SupplierID=V.VenderLibraryID Join Customer C on C.CustomerID=PO.Customerid Join Style s on S.StyleID=POD.StyleiD"
                'Str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid Join Vender V on PO.SupplierID=V.VenderLibraryID Join Customer C on C.CustomerID=PO.Customerid Join Style s on S.StyleID=POD.StyleiD where PO.POID> 0 "
                'If Buyer <> "All" Then
                '    Str &= " and PO.CustomerID ='" & Buyer & "'"
                'End If
                'If Vender <> 0 Then
                '    Str &= " and PO.SupplierID ='" & Vender & "'"
                'End If


                Str &= " group by PO.POID ,VenderName,PO.PONO,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription , PO.Shipmentdate,v.Vendercode,Po.CustomerID,PO.Placementdate"
                Str &= " order by pono"
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplyChainn(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            Try
                Dim Str As String
                Str = "Select PO.POID ,(case when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))"
                Str &= " end ) as Q,PO.PONO,VenderName,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription,Sum(pod.Quantity) as POQuantity"
                Str &= " ,Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)as ShipmnetQty"
                Str &= " ,Cast((((Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)-SUM(POD.Quantity))/SUM(POD.Quantity))*100) as decimal(10,0))as Difference"
                Str &= " ,Cast(SUM(POD.Quantity*POD.rate)as decimal(10,2)) as Amount ,Convert(varchar,PO.Placementdate,106)as Placementdate,Convert(varchar,PO.ShipmentDate,106)as ShipmentDate "
                Str &= ",StrikeOffForecast='',StrikeOffActual='' ,YarnInHouseForecast='' ,YarnInHouseActual='' "
                Str &= ",YarnInHouseRPTorecast='',YarnInHouseRPTActual='',PhotoSamplesForecast='' "
                Str &= ",PhotoSamplesActual='' "
                Str &= ",SizeSetsSamplesForecast='' "
                Str &= ",SizeSetsSamplesActual=''"
                Str &= ",FabricInHouseForecast='' "
                Str &= ",FabricInHouseActual='' "
                Str &= ",FabricInHouseRPTForecast='' "
                Str &= ",FabricInHouseRPTActual=''"
                Str &= ",SoftProofofAccessoriesForecast=''"
                Str &= ",SoftProofofAccessoriesActual=''"
                Str &= " ,PhysicalAccessoriesForecast=''"
                Str &= " ,PhysicalAccessoriesActual=''"
                Str &= ",DyeingForecast=''"
                Str &= ",DyeingActual=''"
                Str &= " ,TechnicalSampleForecast=''"
                Str &= ",TechnicalSampleActual=''"
                Str &= ",SGSITSLabReportForecast=''"
                Str &= ",SGSITSLabReportActual=''"
                Str &= " ,PreProductionSamplesForecast=''"
                Str &= ",PreProductionSamplesActual=''"
                Str &= ",FoldingForecast=''"
                Str &= ",FoldingActual=''"
                Str &= " ,ShadeBandForecast=''"
                Str &= " ,ShadeBandActual=''"
                Str &= " ,CuttingForecast=''"
                Str &= " ,CuttingActual=''"
                Str &= " ,IstinlineInspectionForecast=''"
                Str &= ",IstinlineInspectionActual=''"
                Str &= " ,StitchingForecast=''"
                Str &= " ,StitchingActual=''"
                Str &= ",SecndinlineInspectionForecast=''"
                Str &= " ,SecndinlineInspectionActual=''"
                Str &= " ,PackingForecast=''"
                Str &= ",PackingActual=''"
                Str &= ",FinalInspectionForecast=''"
                Str &= ",FinalInspectionActual=''"
                Str &= ",ExMillDeliveryForecast=''"
                Str &= ",ExMillDeliveryActual=''"
                Str &= " ,ExPakistanDeliveryForecast=''"
                Str &= " ,ExPakistanDeliveryActual=''"
                ' Str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid Join Vender V on PO.SupplierID=V.VenderLibraryID Join Customer C on C.CustomerID=PO.Customerid Join Style s on S.StyleID=POD.StyleiD"

                Str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid Join Vender V on PO.SupplierID=V.VenderLibraryID Join Customer C on C.CustomerID=PO.Customerid Join Style s on S.StyleID=POD.StyleiD where PO.POID> 0 "
                If Buyer <> "All" Then
                    Str &= " and PO.CustomerID ='" & Buyer & "'"
                End If
                If Vender <> 0 Then
                    Str &= " and PO.SupplierID ='" & Vender & "'"
                End If
                Str &= " group by PO.POID ,VenderName,PO.PONO,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription , PO.Shipmentdate,v.Vendercode,Po.CustomerID,PO.Placementdate"
                Str &= " order by pono"
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplyChainWithMileStone(ByVal Status As String, ByVal Vender As String, ByVal Buyer As String, ByVal Shipment As String, ByVal Booked As String, ByVal USerID As String, ByVal RoleID As Long, ByVal POID As String) As DataTable
            Try
                Dim Str As String
                Str = " Select po.poid,(Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=1 and PO.POID=chrt.POID)as 'StrikeOffForecast',"
                Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=1 and PO.POID=chrt.POID)as 'StrikeOffActual',"
                Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=4 and PO.POID=chrt.POID)as 'YarnInHouseForecast', "
                Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=4 and PO.POID=chrt.POID)as 'YarnInHouseActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=7 and PO.POID=chrt.POID)as'YarnInHouseRPTorecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=7 and PO.POID=chrt.POID)as'YarnInHouseRPTActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=5 and PO.POID=chrt.POID)as'PhotoSamplesForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=5 and PO.POID=chrt.POID)as'PhotoSamplesActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=6 and PO.POID=chrt.POID)as'SizeSetsSamplesForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=6 and PO.POID=chrt.POID)as'SizeSetsSamplesActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=8 and PO.POID=chrt.POID)as'FabricInHouseForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=8 and PO.POID=chrt.POID)as'FabricInHouseActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=9 and PO.POID=chrt.POID)as'FabricInHouseRPTForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=9 and PO.POID=chrt.POID)as'FabricInHouseRPTActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=10  and PO.POID=chrt.POID)as'SoftProofofAccessoriesForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=10  and PO.POID=chrt.POID)as'SoftProofofAccessoriesActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=11  and PO.POID=chrt.POID)as'PhysicalAccessoriesForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=11  and PO.POID=chrt.POID)as'PhysicalAccessoriesActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=12  and PO.POID=chrt.POID)as'DyeingForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=12  and PO.POID=chrt.POID)as'DyeingActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'TechnicalSampleForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'TechnicalSampleActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'SGSITSLabReportForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'SGSITSLabReportActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=15  and PO.POID=chrt.POID)as'PreProductionSamplesForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=15  and PO.POID=chrt.POID)as'PreProductionSamplesActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=16  and PO.POID=chrt.POID)as'FoldingForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=16  and PO.POID=chrt.POID)as'FoldingActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=17  and PO.POID=chrt.POID)as'ShadeBandForecast', (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=17  and PO.POID=chrt.POID)as'ShadeBandActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=18  and PO.POID=chrt.POID)as'CuttingForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=18  and PO.POID=chrt.POID)as'CuttingActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=19  and PO.POID=chrt.POID)as'IstinlineInspectionForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=19  and PO.POID=chrt.POID)as'IstinlineInspectionActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=20  and PO.POID=chrt.POID)as'StitchingForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=20  and PO.POID=chrt.POID)as'StitchingActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=21  and PO.POID=chrt.POID)as'SecndinlineInspectionForecast', (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=21  and PO.POID=chrt.POID)as'SecndinlineInspectionActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=22  and PO.POID=chrt.POID)as'PackingForecast', (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=22  and PO.POID=chrt.POID)as'PackingActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=24  and PO.POID=chrt.POID)as'FinalInspectionForecast', (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=24  and PO.POID=chrt.POID)as'FinalInspectionActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=25  and PO.POID=chrt.POID)as'ExMillDeliveryForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=25  and PO.POID=chrt.POID)as'ExMillDeliveryActual', (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=26  and PO.POID=chrt.POID)as'ExPakistanDeliveryForecast', (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=26  and PO.POID=chrt.POID)as'ExPakistanDeliveryActual',"
                Str &= " (case when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(varchar,year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate)) "
                Str &= " when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))"
                Str &= " end ) as Q,PO.PONO,VenderName,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription,Sum(pod.Quantity) as POQuantity"
                Str &= " ,Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)as ShipmnetQty"
                Str &= " ,Cast((((Isnull((Select SUM(CAST(Replace(xl.NoofPieces,',','')as decimal)) from importXl xl where xl.Customerid=Po.CustomerID and xl.Supplierno=v.Vendercode and xl.articleno=s.article and po.Eknumber=xl.DepartmentNo and xl.Orderno=Po.PONO ),0)-SUM(POD.Quantity))/SUM(POD.Quantity))*100) as decimal(10,0))as Difference"
                Str &= " ,Cast(SUM(POD.Quantity*POD.rate)as decimal(10,2)) as Amount ,Convert(varchar,PO.Placementdate,106)as Placementdate,Convert(varchar,PO.ShipmentDate,106)as ShipmentDate "
                Str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid Join Vender V on PO.SupplierID=V.VenderLibraryID Join Customer C on C.CustomerID=PO.Customerid Join Style s on S.StyleID=POD.StyleiD "
                ' Str = "Where Month(PO.ShipmentDate)='1' and Year(PO.ShipmentDate)='2010'"
                Str &= "where Po.POID in" & POID
                Str &= "group by PO.POID,VenderName,PO.PONO,C.Customername,EKNumber,S.Article,S.Styleno,S.ItemDescription , PO.Shipmentdate,v.Vendercode,Po.CustomerID,PO.Placementdate order by pono"
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getMilestones(ByVal POID As String)
            Dim Str As String
            Str = " Select (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=1 and PO.POID=chrt.POID)as 'Strike  Off / Lab Dips-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=1 and PO.POID=chrt.POID)as 'Strike  Off / Lab Dips-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=4 and PO.POID=chrt.POID)as 'Yarn In-House-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=4 and PO.POID=chrt.POID)as 'Yarn In-House-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=7 and PO.POID=chrt.POID)as'ECP + Factory Yarn Report-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=7 and PO.POID=chrt.POID)as'ECP + Factory Yarn Report-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=5 and PO.POID=chrt.POID)as'Photo Samples-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=5 and PO.POID=chrt.POID)as'Photo Samples-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=6 and PO.POID=chrt.POID)as'Size Sets Samples-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=6 and PO.POID=chrt.POID)as'Size Sets Samples-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=8 and PO.POID=chrt.POID)as'Fabric In-House-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=8 and PO.POID=chrt.POID)as'Fabric In-House-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=9 and PO.POID=chrt.POID)as'ECP + Factory Greige  Report-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=9 and PO.POID=chrt.POID)as'ECP + Factory Greige  Report-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=10  and PO.POID=chrt.POID)as'Soft Proof of Accessories-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=10  and PO.POID=chrt.POID)as'Soft Proof of Accessories-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=11  and PO.POID=chrt.POID)as'Physical Accessories-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=11  and PO.POID=chrt.POID)as'Physical Accessories-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=12  and PO.POID=chrt.POID)as'Dyeing / Printing-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=12  and PO.POID=chrt.POID)as'Dyeing / Printing-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'Technical Sample-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'Technical Sample-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'ECP/ Factory / SGS/ITS Lab  Report-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=13  and PO.POID=chrt.POID)as'ECP/ Factory / SGS/ITS Lab  Report-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=15  and PO.POID=chrt.POID)as'Pre Production Samples-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=15  and PO.POID=chrt.POID)as'Pre Production Samples-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated  From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=16  and PO.POID=chrt.POID)as'Folding-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=16  and PO.POID=chrt.POID)as'Folding-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=17  and PO.POID=chrt.POID)as'Shade Band-Forecast',"
            Str &= " (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=17  and PO.POID=chrt.POID)as'Shade Band-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=18  and PO.POID=chrt.POID)as'Cutting-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=18  and PO.POID=chrt.POID)as'Cutting-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=19  and PO.POID=chrt.POID)as'Ist inline Inspection-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=19  and PO.POID=chrt.POID)as'Ist inline Inspection-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=20  and PO.POID=chrt.POID)as'Stitching-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=20  and PO.POID=chrt.POID)as'Stitching-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=21  and PO.POID=chrt.POID)as'2nd inline Inspection-Forecast',"
            Str &= " (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=21  and PO.POID=chrt.POID)as'2nd inline Inspection-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=22  and PO.POID=chrt.POID)as'Packing-Forecast',"
            Str &= " (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=22  and PO.POID=chrt.POID)as'Packing-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=24  and PO.POID=chrt.POID)as'Final Inspection-Forecast',"
            Str &= " (Select IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=24  and PO.POID=chrt.POID)as'Final Inspection-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=25  and PO.POID=chrt.POID)as'Ex Mill Delivery-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=25  and PO.POID=chrt.POID)as'Ex Mill Delivery-Actual',"
            Str &= " (Select Convert(Varchar,DateEstemated,106)as DateEstemated From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=26  and PO.POID=chrt.POID)as'Ex Pakistan Delivery-Forecast',"
            Str &= " (Select  IsNull(Convert(Varchar,(Select Max(ActualDate) From TNACharthistory chrth where Status='Completed' and chrth.TNAChartID=chrt.TNAChartID ),106),'') as ActualDate From TNAChart chrt Join TNAProcess prcs on chrt.TNAProcessid=prcs.Processid where TNAProcessID=26  and PO.POID=chrt.POID)as'Ex Pakistan Delivery-Actual'"
            Str &= " from purchaseOrder PO join purchaseOrderDetail pod on PO.POID=POD.POID   where Po.POID in" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrentPOClick(ByVal UserID As Long)
            Dim Str As String
            Str = " Select Count(PO.PONo) as TotalCurrentPO  From  PurchaseOrder PO Join  UMUser U on UserID=PO.MarchandID "
            Str &= " where U.UserID in(Select UserID From UMUser where UserID='" & UserID & "') and Status !='Cancel' and PO.ShipmentDate >='01/01/2011'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrentPOClickSeason(ByVal UserID As Long)
            Dim Str As String
            Str = " Select Count(PO.PONo) as TotalCurrentPO  From  PurchaseOrder PO Join  UMUser U on UserID=PO.MarchandID "
            Str &= " where U.UserID in(Select UserID From UMUser where UserID='" & UserID & "') and Status !='Cancel' and Season like '%125' and Season like '%125%' and Season like '125%'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTurnover(ByVal UserID As Long)
            Dim Str As String
            Str = " Select (select Count(PONo) as TotalCurrentPO  from  PurchaseOrder   "
            Str &= " where Marchandid = '" & UserID & "') as TotalCurrentPO ,SUM(POD.Quantity * POD.Rate) as CValue"
            Str &= " ,Case when PO.Currency ='Dollar' then"
            Str &= " SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where UserID='" & UserID & "') and Status !='Cancel' and ShipmentDate >='01/01/2011' Group by PO.Marchandid,PO.Currency,PO.ExchangeRate "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTurnoverSeason(ByVal UserID As Long)
            Dim Str As String
            Str = " Select (select Count(PONo) as TotalCurrentPO  from  PurchaseOrder   "
            Str &= " where Marchandid = '" & UserID & "') as TotalCurrentPO ,SUM(POD.Quantity * POD.Rate) as CValue"
            Str &= " ,Case when PO.Currency ='Dollar' then"
            Str &= " SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where UserID='" & UserID & "') and Status !='Cancel' and Season like '%125' and Season like '%125%' and Season like '125%' Group by PO.Marchandid,PO.Currency,PO.ExchangeRate "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommission(ByVal UserID As Long)
            Dim Str As String
            Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str &= " (select Commission as Commission  from  PurchaseOrder   "
            Str &= " where Marchandid = '" & UserID & "' and POID= PO.POID)"
            Str &= " as CValue,"
            Str &= " Case when PO.Currency ='Dollar'"
            Str &= " then SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as"
            Str &= " 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where UserID='" & UserID & "') and Status !='Cancel' and ShipmentDate >='01/01/2011' Group by PO.Marchandid "
            Str &= " ,PO.POID ,PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommissionSeason(ByVal UserID As Long)
            Dim Str As String
            Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str &= " (select Commission as Commission  from  PurchaseOrder   "
            Str &= " where Marchandid = '" & UserID & "' and POID= PO.POID)"
            Str &= " as CValue,"
            Str &= " Case when PO.Currency ='Dollar'"
            Str &= " then SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as"
            Str &= " 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where UserID='" & UserID & "') and Status !='Cancel' and ShipmentDate >='01/01/2011' Group by PO.Marchandid "
            Str &= " ,PO.POID ,PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTurnoverDvnlHead(ByVal RoleID As Long, ByVal ECP As String)
            Dim Str As String
            Str = "  Select (select Count(PONo) as TotalCurrentPO  from  PurchaseOrder "
            Str &= " where Marchandid IN ( Select UserID From UMUser where ECPdivistion= '" & ECP & "') and Status !='Cancel'  and ShipmentDate >='01/01/2011') as TotalCurrentPO"
            Str &= " ,SUM(POD.Quantity * POD.Rate) as CValue "
            Str &= " ,Case when PO.Currency ='Dollar' then"
            Str &= " SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD"
            Str &= "  On PO.POID =POD.POID Join   UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where ECPdivistion= '" & ECP & "') and  Status !='Cancel'  and ShipmentDate >='01/01/2011'"
            Str &= " group by PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTurnoverDvnlHeadSeason(ByVal RoleID As Long, ByVal ECP As String)
            Dim Str As String
            Str = "  Select (select Count(PONo) as TotalCurrentPO  from  PurchaseOrder "
            Str &= " where Marchandid IN ( Select UserID From UMUser where ECPdivistion= '" & ECP & "') and Status !='Cancel'  and Season like '%125' or Season like '%125%' or Season like '125%') as TotalCurrentPO"
            Str &= " ,SUM(POD.Quantity * POD.Rate) as CValue "
            Str &= " ,Case when PO.Currency ='Dollar' then"
            Str &= " SUM(POD.Quantity * POD.Rate) else SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD"
            Str &= "  On PO.POID =POD.POID Join   UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where ECPdivistion= '" & ECP & "') and  Status !='Cancel'  and Season like '%125' and Season like '%125%' and Season like '125%'"
            Str &= " group by PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommissionDivinalhead(ByVal RoleID As Long, ByVal ECP As String)
            Dim Str As String
            ' Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str &= " (select Commission as Commission  from  PurchaseOrder "
            Str &= " where Marchandid IN"
            Str &= " (Select UserID From UMUser where ECPdivistion= '" & ECP & "')"
            Str &= " and POID= PO.POID)as CValue"
            Str &= "  ,Case when PO.Currency ='Dollar' "
            Str &= " then SUM(POD.Quantity * POD.Rate /100)*(select Commission as Commission "
            Str &= "  from  PurchaseOrder  where Marchandid IN (Select UserID From UMUser"
            Str &= "  where ECPdivistion= '" & ECP & "') and POID= PO.POID) else"
            Str &= " ((SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate)/100)*(select Commission as Commission "
            Str &= "  from  PurchaseOrder  where Marchandid IN (Select UserID From UMUser"
            Str &= "  where ECPdivistion= '" & ECP & "') and POID= PO.POID) end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where ECPdivistion= '" & ECP & "')  and Status !='Cancel'  and ShipmentDate >='01/01/2011' Group by PO.Marchandid "
            Str &= " ,PO.POID ,PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommissionDivinalheadSeason(ByVal RoleID As Long, ByVal ECP As String)
            Dim Str As String
            ' Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str = " Select SUM(POD.Quantity * POD.Rate /100) * "
            Str &= " (select Commission as Commission  from  PurchaseOrder "
            Str &= " where Marchandid IN"
            Str &= " (Select UserID From UMUser where ECPdivistion= '" & ECP & "')"
            Str &= " and POID= PO.POID)as CValue"
            Str &= "  ,Case when PO.Currency ='Dollar' "
            Str &= " then SUM(POD.Quantity * POD.Rate /100)*(select Commission as Commission "
            Str &= "  from  PurchaseOrder  where Marchandid IN (Select UserID From UMUser"
            Str &= "  where ECPdivistion= '" & ECP & "') and POID= PO.POID) else"
            Str &= " ((SUM(POD.Quantity * POD.Rate)* PO.ExchangeRate)/100)*(select Commission as Commission "
            Str &= "  from  PurchaseOrder  where Marchandid IN (Select UserID From UMUser"
            Str &= "  where ECPdivistion= '" & ECP & "') and POID= PO.POID) end as 'CValueNew'"
            Str &= " From  PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID =POD.POID Join "
            Str &= " UMUser U on UserID=PO.MarchandID  where U.UserID in(Select UserID"
            Str &= " From UMUser where ECPdivistion= '" & ECP & "')  and Status !='Cancel'  and Season like '%125' and Season like '%125%' and Season like '125%' Group by PO.Marchandid "
            Str &= " ,PO.POID ,PO.Currency,PO.ExchangeRate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetExistPODetail(ByVal PONO As Long, ByVal CustomerID As String, ByVal SupplierID As String, ByVal ShipmentDate As String)
            Dim Str As String
            Str = " Select * from PurchaseOrder where "
            Str &= " PONO='" & PONO & "' and CustomerID='" & CustomerID & "' and SupplierID='" & SupplierID & "'"
            Str &= " and ShipmentDate='" & ShipmentDate & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetlastRecord()
            Dim str As String
            str = "SELECT TOP 1 POID FROM PurchaseOrder ORDER BY POID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getexcelsheetNew()
            '  Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection").ConnectionString
            Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
            Dim objSqlConnection As New SqlConnection
            Dim sqlCmd As New SqlCommand
            objSqlConnection = New SqlConnection(strConnection)
            sqlCmd = New SqlCommand("sp_AdminSupplyChainExcelSheetLatestNew", objSqlConnection)
            sqlCmd.CommandType = CommandType.StoredProcedure
            ' sqlCmd.Parameters.Add(New SqlParameter("@marchandID", SqlDbType.VarChar)).Value = userid
            objSqlConnection.Open()
            sqlCmd.ExecuteNonQuery()
            objSqlConnection.Close()
        End Function
        Public Function getexcelsheetFiltration(ByVal POIDs As String)
            Try
                Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_AdminSupplyChainExcelSheetLatestFiltration", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@POIDs", SqlDbType.VarChar)).Value = POIDs
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function getexcelsheet(ByVal userid As String)
            Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
            Dim objSqlConnection As New SqlConnection
            Dim sqlCmd As New SqlCommand
            objSqlConnection = New SqlConnection(strConnection)
            If userid <> 28 Then
                sqlCmd = New SqlCommand("sp_testproc", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@marchandID", SqlDbType.VarChar)).Value = userid
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Else
                'sqlCmd = New SqlCommand("sp_AdminSupplyChainExcelSheet", objSqlConnection)
                'sqlCmd.CommandType = CommandType.StoredProcedure
                'objSqlConnection.Open()
                'sqlCmd.ExecuteNonQuery()
                'objSqlConnection.Close()
            End If
        End Function
        Public Function getMasterExcel(ByVal MarchantID As String)
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_AdminSupplyChainExcelSheetMarchantVise", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@Marchandid", SqlDbType.VarChar)).Value = MarchantID
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function getMasterExcelSupplier(ByVal Supplierid As String, ByVal SpName As String)
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand(SpName, objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.VarChar)).Value = Supplierid
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Function GetPOById(ByVal UserID As String)
            Dim str As String
            str = "select POID,PONO from  Purchaseorder  where marchandID='" & UserID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetAllPOById(ByVal UserID As String, ByVal RoleID As String)
            Dim str As String
            str = "   Select PO.*,v.venderName,C.customerName from Purchaseorder PO"
            str &= " Join Customer C on C.customerID=Po.CustomerID"
            str &= " join Vender V on V.venderlibraryID=Po.SupplierID"
            str &= " where Po.MarchandID='" & UserID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdatePObyPopup(ByVal LastUpdate As Date, ByVal PlacementDate As Date, ByVal ShipmentDate As Date, ByVal Season As String, ByVal Quality As String, ByVal Construction As String, ByVal Design As String, ByVal TimeSpame As String, ByVal Composition As String, ByVal POID As String)
            Dim str As String
            str = "   Update Purchaseorder Set LastUpdate='" & LastUpdate & "' ,PlacementDate='" & PlacementDate & "',ShipmentDate='" & ShipmentDate & "',Season='" & Season & "',Quality='" & Quality & "' "
            str &= " ,Construction='" & Construction & "',Design='" & Design & "',TimeSpame='" & TimeSpame & "',Composition='" & Composition & "' "
            str &= "  where POID='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPOsByStyleNo(ByVal StyleNo As String, ByVal USerID As String, ByVal RoleID As Long)
            Dim str As String
            str = "    select PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as"
            str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            str &= "  C.CustomerName as CustomerName,V.VenderName as vendorName,Sum(POD.Quantity)as Quantity  ,S.styleNo from Purchaseorder Po "
            str &= " join PurchaseorderDetail POD on POD.POID=PO.POID join StyleMaster S on S.styleID=POD.StyleID "
            str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            str &= " Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  "
            str &= " join UmUser u on U.UserID=Po.MarchandID  "
            If Not RoleID = 1 Then
                str &= "where  S.StyleNo='" & StyleNo & "' and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            str &= " group by Po.PONO,S.StyleNo,Po.PlacementDate"
            str &= " ,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetQuantityByStyleNo(ByVal StyleNo As String)
            Dim str As String
            str = "  select Sum(POD.Quantity) as quantity from PurchaseorderDetail POD"
            str &= " join StyleMaster S on S.styleID=POD.StyleID where S.StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetOnlyPOID(ByVal StyleNo As String)
            Dim str As String
            str = " select PO.POID from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"
            str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            str &= " join StyleDetail Sd on SD.StyleDetailID=POD.StyleDetailID"
            str &= " join UmUser u on U.UserID=Po.MarchandID"
            str &= " where S.StyleNo='" & StyleNo & "'"
            str &= " group by Po.PONO,Po.POID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderForTransfer(ByVal USerID As String) As DataTable
            Dim Str As String
            Str = "   Select PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            Str &= " C.CustomerName as Customer,V.VenderName as vendor from PurchaseOrder PO "
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on UserID=PO.MarchandID"
            Str &= " where PONO<>''   and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            Str &= " Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,PO.TimeSpame,C.CustomerName,V.VenderName,Currency order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function TransferOrderToMarchand(ByVal MarchandID As String, ByVal POID As String)
            Dim str As String
            str = " update Purchaseorder set MarchandID='" & MarchandID & "' where POID='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOIDForTransfer(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = "Select * from  PurchaseOrder Where POID = '" & lPOID & "' order by POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderByPOUsingStyleMaster(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select *  ,convert(varchar,DetailShipMentdate,101) as DetailShipMentdatee, PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"

            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " where  PO.POID=" & lPOID

            'Str = " Select * , PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            'Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            'Str &= " On PO.POID=POD.POID"
            'Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            'Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"

            'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            'Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            'Str &= " join Umuser U on U.userid=Po.Marchandid"
            'Str &= " where  PO.POID=" & lPOID


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getArtcile(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " select distinct sd.Article from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getArtcileData(ByVal lPOID As Long, ByVal Article As String) As DataTable
            Dim Str As String
            Str = "  select ComplainDatabaseDetailID=0, * ,(Select isnull(Sum(Quantity),0) from CargoDetail Cd where Cd.POID=POD.PodetailID)as ShipQty,"
            Str &= " isnull((Select top 1 InspectionStatus  from QDInspection Q where Q.PodetailID =POD.PodetailID and InspectionStatus='1st Inline' and InspStatus='Pass' "
            Str &= " order by QDInspectionID DESC ),'Missed') as Inline,"
            Str &= " isnull((Select top 1 InspectionStatus  from QDInspection Q where Q.PodetailID =POD.PodetailID and InspectionStatus='Final' and InspStatus='Pass' "
            Str &= " order by QDInspectionID DESC ),'Missed') as FRI,"
            Str &= " isnull((Select top 1 U.Username  from QDInspection Q join Umuser u on u.Userid=Q.QDUserid where Q.PodetailID =POD.PodetailID"
            Str &= "  and InspectionStatus='Final' and InspStatus='Pass'  order by QDInspectionID DESC ),'--') as FRIQDName"
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD  On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " where  PO.POID=" & lPOID
            Str &= " and sd.Article='" & Article & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderByPOUsingStyleMasterView(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select * , PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            Str &= " ,Convert(Varchar,Po.ShipmentDate,103) as ShipmentDatee ,Convert(Varchar,Po.PlacementDate,103) as PlacementDatee"
            Str &= " ,POD.Quantity  from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"

            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMarchandID(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = "select * from Purchaseorder PO join Umuser U on U.userID=Po.MarchandID"
            Str &= " where Po.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRepeatPO(ByVal lPONO As String, ByVal IcustomerID As Long, ByVal ISupplierID As Long) As DataTable
            Dim Str As String
            Str = " select * from Purchaseorder where PONO='" & lPONO & "'"
            Str &= "  and CustomerID='" & IcustomerID & "' and SupplierID='" & ISupplierID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRepeatStyle(ByVal StyleNo As String) As DataTable
            Dim Str As String
            Str = "Select Count(Distinct(PONO)) as RepteadStyle from Purchaseorder PO join PUrchaseorderDetail POD on PO.POID=pOD.POID"
            Str &= "  join StyleMaster SM on Sm.StyleID=pOD.StyleID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where SM.StyleNO='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSeason() As DataTable
            Dim str As String
            str = " select   * from season  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMarchandizer() As DataTable
            Dim Str As String
            ' Str = " select * from umuser where ecpdivistion <> 'admin' and ecpdivistion <> 'ECKO' and ecpdivistion <> 'Developer' and ecpdivistion <> 'Quality Dept'"
            Str = " select * from umuser  where  ecpdivistion like 'GIA%' and Designation = 'Merchant' and isactive='1'  "
            Str &= " order by username ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetYears() As DataTable
            Dim Str As String
            Str = " select * from Years  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCountries() As DataTable
            Dim Str As String
            Str = " select * from Countries  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMarchandizerByID(ByVal ID As String) As DataTable
            Dim Str As String
            Str = "select * from umuser where userid = " & ID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleForSamples(ByVal Divisition As String) As DataTable
            Dim Str As String
            If Divisition = "ECP 01" Then
                Str = "Select top 5  Sequence,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= " where  ProcessID in(Select top 31 ProcessID from TNAProcess where ProcessID>0 and ProcessID <33 and Active=1 and ISSample=1 )"
            ElseIf Divisition = "ECP 02" Then
                Str = "Select top 5  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= " where  ProcessID  in(Select top 52 ProcessID from TNAProcess where ProcessID>32 and ProcessID <54 and Active=1 and ISSample=1 )"
            ElseIf Divisition = "ECP 03" Then
                Str = "Select top 5  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= " where  ProcessID  in(Select top 52 ProcessID from TNAProcess where ProcessID>53 and ProcessID <71 and Active=1 and ISSample=1 )"
            Else
                Str = " Select top 5  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= " where  ProcessID  in(Select top 52 ProcessID from TNAProcess where ProcessID>71 and ProcessID <89 and Active=1 and ISSample=1 )"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllPosByMarchandID(ByVal Userid As String, ByVal roleid As String) As DataTable
            Dim Str As String
            Str = " Select PO.POID,PO.PONo,"
            Str &= " PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate,"
            Str &= " Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate, "
            Str &= " Convert(varchar,PO.TimeSpame)+' Days'as TimeSpame,C.CustomerName "
            Str &= " as Customer,V.VenderName as vendor, "
            Str &= " (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,"
            Str &= " (Select SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0))"
            Str &= " from PurchaseOrderDetail SbPOD where SbPOD.POID =PO.POID),0))))"
            Str &= " as Amount,U.UserName from PurchaseOrder PO   "
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join  UMUser U on UserID=PO.MarchandID  where PONO<>''"
            Str &= " and status !='Cancel' and year(PO.creationdate)>= '2012'  "
            If Not roleid = "1" Or roleid = "4" Or roleid = "12" Then
                Str &= " and U.UserID in(Select UserID From UMUser where UserID='" & Userid & "')"
            End If
            Str &= "Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,"
            Str &= " PO.TimeSpame,C.CustomerName,V.VenderName,Currency,U.UserName order by po.PONo ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindComboCountry() As DataTable
            Dim str As String
            str = "select distinct Destination from purchaseorder where Year(CreationDate)=2012  order by Destination ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindComboSeason() As DataTable
            Dim str As String
            str = "select distinct Season from purchaseorder where Year(CreationDate)=2012 order by Season ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindComboDept() As DataTable
            Dim str As String
            str = "select distinct Eknumber from purchaseorder where Year(CreationDate)=2012 order by Eknumber ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindComboPO() As DataTable
            Dim str As String
            str = "Select POID,PONO from Purchaseorder Po  where Year(PO.CreationDate)=2012 order by PONO ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPurchaseOrderPOID(ByVal RoleID As Long, ByVal Buyer As String, ByVal Vender As String, ByVal ECP As String, ByVal Marchant As String, ByVal Country As String, ByVal Season As String, ByVal Dept As String, ByVal StyleNo As String, ByVal PONO As String, Optional ByVal PlacementDateFrom As String = "", Optional ByVal PlacementDateTo As String = "", Optional ByVal ShipmentDateFrom As String = "", Optional ByVal ShipmentDateTo As String = "") As DataTable
            Dim Str As String
            Str = "Select PO.POID,PO.PONo from PurchaseOrder PO "
            Str &= "  Join Customer C on PO.CustomerID=C.CustomerID  "
            Str &= "  Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= "  Join  UMUser U on UserID=PO.MarchandID"
            Str &= "  where PONO<>'' and Year(PO.CreationDate)=2012  "
            ' and status !='Cancel' and Year(PO.CreationDate)='2012'  "
            If Not Buyer = 0 Then
                Str &= " and PO.CustomerID ='" & Buyer & "'"
            End If
            If Not Vender = 0 Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            If Not ECP = "All ECP" Then
                Str &= " and U.ECPDivistion='" & ECP & "'"
            End If
            If Not Marchant = 0 Then
                Str &= " and PO.MarchandID='" & Marchant & "'"
            End If
            If Not Country = "All Country" Then
                Str &= " and PO.Destination='" & Country & "'"
            End If
            If Not Season = "All Season" Then
                Str &= " and PO.Season='" & Season & "'"
            End If
            If Not Dept = "All Dept" Then
                Str &= " and PO.Eknumber='" & Dept & "'"
            End If
            If Not StyleNo = "" Then
                'Str &= " and ='" & StyleNo & "'"
            End If
            If Not PONO = 0 Then
                Str &= " and PO.POID='" & PONO & "'"
            End If

            If PlacementDateFrom <> "" And PlacementDateTo <> "" Then
                Str &= " and PlacementDate between '" & PlacementDateFrom.Substring(6, 4) & "-" & PlacementDateFrom.Substring(3, 2) & "-" & PlacementDateFrom.Substring(0, 2) & "' and  '" & PlacementDateTo.Substring(6, 4) & "-" & PlacementDateTo.Substring(3, 2) & "-" & PlacementDateTo.Substring(0, 2) & "'"
            End If

            If ShipmentDateFrom <> "" And ShipmentDateTo <> "" Then
                Str &= " and ShipmentDate between '" & ShipmentDateFrom.Substring(6, 4) & "-" & ShipmentDateFrom.Substring(3, 2) & "-" & ShipmentDateFrom.Substring(0, 2) & "' and  '" & ShipmentDateTo.Substring(6, 4) & "-" & ShipmentDateTo.Substring(3, 2) & "-" & ShipmentDateTo.Substring(0, 2) & "'"
            End If
            Str &= " Group by PO.POID,PO.PONo  order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllProductType() As DataTable
            Dim str As String
            str = " Select * from ProductType order by ProductType ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAccessoriesList() As DataTable
            Dim str As String
            str = "Select * from StyleAccessoriesList order by AccessoriesName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTypeOfDyes() As DataTable
            Dim str As String
            str = "Select * from TypeOfDyes order by TypeOfDyesName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTypeOfPrint() As DataTable
            Dim str As String
            str = "Select * from TypeOfPrint order by TypeOfPrintName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTypeOfWashing() As DataTable
            Dim str As String
            str = "Select * from TypeOfWashing order by TypeOfWashingName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUnits() As DataTable
            Dim str As String
            str = "Select * from Units order by UnitName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrand() As DataTable
            Dim str As String
            str = "Select * from Brand order by BrandName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleInfo(ByVal StyleID As String) As DataTable
            Dim str As String
            str = "Select * from StyleMaster where StyleID in (" & StyleID & ")"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckStyle(ByVal StyleNo As String) As DataTable
            Dim str As String
            str = "Select * from StyleMaster where StyleNo ='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckPO(ByVal PONO As String) As DataTable
            Dim str As String
            str = "Select * from PurchaseOrder where PONO ='" & PONO & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductPortfolio() As DataTable
            Dim str As String
            str = "Select * from ProductPortfolio order by ProductPortfolio ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeRange() As DataTable
            Dim str As String
            str = " select distinct sizerange from SizeRangeDB  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetStyle() As DataTable
            Dim str As String
            str = " SELECT Distinct IQS.InquiryStyleID,StyleNo FROM InquiryStyle IQS "
            str &= " Join InquiryStyleProductInformation ISP ON IQS.InquiryStyleID=ISP.InquiryStyleID"
            str &= " Join TblInquiryConfirmed ISC ON ISC.InquiryStyleID=IQS.InquiryStyleID AND ISC.InquirySproductID=ISC.InquirySproductID where IQS.EnquiryPurpose='Buying Meeting'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDegree1() As DataTable
            Dim str As String
            str = " select * from SymbolDegreeofColour "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBLEACHING() As DataTable
            Dim str As String
            str = " select * from SymbolBleaching "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIroning() As DataTable
            Dim str As String
            str = " select * from SymbolIroning "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDryCleaning() As DataTable
            Dim str As String
            str = " select * from SymbolDryCleaning "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTumlbeDry() As DataTable
            Dim str As String
            str = " select * from SymbolTumbleDry "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getEnquirystyledata(ByVal styleNo As String) As DataTable
            Dim str As String
            str = " select * from EnquiriesSystemAdd where styleNo='" & styleNo & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getInquirystyledata(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = " select * from InquiryStyle where InquiryStyleID='" & InquiryStyleID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEmbell() As DataTable
            Dim str As String
            str = " select   * from Embell  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetComposition() As DataTable
            Dim str As String
            str = " select   * from Composition  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductConsumer() As DataTable
            Dim str As String
            str = " select   * from ProductConsumer  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductConsumer1(ByVal ProductConsumerName As String) As DataTable
            Dim str As String
            str = " select   * from ProductConsumer  where ProductConsumerName ='" & ProductConsumerName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason1(ByVal season As String) As DataTable
            Dim str As String
            str = " select   * from season  where season ='" & season & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetComposition1(ByVal CompositionName As String) As DataTable
            Dim str As String
            str = " select   * from Composition  where CompositionName ='" & CompositionName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeRange11(ByVal sizerange As String) As DataTable
            Dim str As String
            str = " select * from SizeRangeDB where sizerange='" & sizerange & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductTypeID(ByVal ProductType As String) As DataTable
            Dim str As String
            str = "Select * from ProductType where ProductType='" & ProductType & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductPortfolioID(ByVal ProductPortfolio As String) As DataTable
            Dim str As String
            str = "Select * from ProductPortfolio where ProductPortfolio='" & ProductPortfolio & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductCategoriesID(ByVal ProductCategories As String, ByVal ProductPortfolioID As Long) As DataTable
            Dim str As String
            str = "Select * from ProductCategories where ProductCategories='" & ProductCategories & "' and ProductPortfolioID =" & ProductPortfolioID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategories(ByVal ProductPortfolioID As Long) As DataTable
            Dim str As String
            str = "  Select * from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            str &= "  where PC.ProductPortfolioID =" & ProductPortfolioID
            str &= " order by PC.ProductCategories ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllCustomer() As DataTable
            Dim str As String
            str = " select Distinct CS.CustomerID,CS.CustomerName  from  Customer CS  "
            str &= " order by CS.CustomerName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllSupplier() As DataTable
            Dim str As String
            str = " select Distinct V.VenderLibraryID,V.VenderName from    Vender V "
            str &= "  order by V.VenderName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllMarchandiser() As DataTable
            Dim str As String
            str = " select Distinct PO.MarchandID,UM.UserName  from  purchaseorder po   "
            str &= "  Join UMUser UM on UM.UserID=PO.MarchandID "
            str &= "  where Year(PO.creationdate) >= 2012 "
            str &= "  order by UM.UserName"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllECPDivistion() As DataTable
            Dim str As String
            str = " select Distinct UM.ECPDivistion from  purchaseorder po  "
            str &= "  Join UMUser UM on UM.UserID=PO.MarchandID "
            str &= "  where Year(PO.creationdate) >= 2012"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllSeason() As DataTable
            Dim str As String
            str = " select Distinct PO.Season from  purchaseorder po  "
            str &= "  where(Year(PO.creationdate) >= 2012)"
            str &= "  order by PO.Season   "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllEKNumber() As DataTable
            Dim str As String
            str = "  select Distinct PO.Eknumber from  purchaseorder po  "
            str &= " where Year(PO.creationdate) >= 2012 "
            str &= " order by PO.Eknumber "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOForChangeShipmetDate(ByVal lPOID As Long) As DataTable
            Dim Str As String

            Str = "Select * from  PurchaseOrder Where POID= " & lPOID & ""

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOShipmentMonth() As DataTable
            Dim Str As String
            Str = "  Select Distinct  CONVERT(VARCHAR(15), DATENAME(MM,(PO.ShipmentDate)), 100)as Shipmentmonth,"
            Str &= " month(PO.ShipmentDate) as ShipmentmonthNo"
            Str &= " from PurchaseOrder PO"
            Str &= " where status !='Cancel' and Year(PO.CreationDate)>= '2012'"
            Str &= " order by month(PO.ShipmentDate) asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOShipmentYear() As DataTable
            Dim Str As String
            Str = "  Select Distinct  year(PO.ShipmentDate) as ShipmentYear"
            Str &= " from PurchaseOrder PO"
            Str &= " where status !='Cancel' and Year(PO.CreationDate)>= '2012'"
            Str &= " order by year(PO.ShipmentDate) asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrentDate() As DataTable
            Dim Str As String
            Str = " select Convert(Varchar,GETDATE(),106)  as CurrentDate "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdatePOStatus(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Update PurchaseOrder set Status='Shipped' ,creationdate='" & Date.Now & "'"
            Str &= "  where POID=" & lPOID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdatePOStatusNew(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Update Joborderdatabase set Status='Shipped' ,creationdate='" & Date.Now & "'"
            Str &= "  where POID=" & lPOID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdatePOCommssion(ByVal lPOID As Long, ByVal Commission As Decimal) As DataTable
            Dim Str As String
            Str = " Update PurchaseOrder set Commission='" & Commission & "'"
            Str &= "  where POID=" & lPOID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllPOhavingStatusTobeShipped() As DataTable
            Dim Str As String
            Str = "  select * from Purchaseorder "
            Str &= " where POID in (select distinct POPOID from cargodetail)"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForExchangeRate(ByVal ShipStartDate As String, ByVal ShipEndDate As String)
            Dim str As String
            Try
                str = "   Select * from Purchaseorder  "
                str &= " where ShipmentDate between '" & ShipStartDate & "' and '" & ShipEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForExchangeRateWithCurrency(ByVal ShipStartDate As String, ByVal ShipEndDate As String, ByVal Currency As String)
            Dim str As String
            Try
                str = "   Select * from Purchaseorder  "
                str &= " where Currency='" & Currency & "' and ShipmentDate between '" & ShipStartDate & "' and '" & ShipEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateBookedExchangeRate(ByVal lPOID As Long, ByVal BookedExchangeRate As String)
            Dim str As String
            str = "Update Purchaseorder set ExchangeRate='" & BookedExchangeRate & "' where POID='" & lPOID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TemproryFUN(ByVal IPOID As Long)
            Dim str As String
            Try
                str = "  select PO.POID,PO.PONO,PO.POrefNO,C.Customername,V.Vendername"
                str &= " ,PO.Placementdate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,S.styleNo,S.StyleName,sd.article,SD.sizerange, POD.PODetailID"
                str &= " ,SD.Colorway,"
                str &= " (Select Top 1 PRS.ShipmentDate from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC) as  RevisedShipmentDate "
                str &= " from Purchaseorder Po"
                str &= " Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID    "
                str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID    "
                str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID    "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= "  where Year(PO.CreationDate) >= 2012"
                If IPOID <> 0 Then
                    str &= " and PO.POID=" & IPOID
                End If
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function TemproryFUN1(ByVal IPOID As Long)
            Dim str As String
            Try
                str = "  select distinct PO.POID,PO.PONO,PO.POrefNO,C.Customername,V.Vendername"
                str &= " ,PO.Placementdate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,S.styleNo,S.StyleName,sd.article,"
                str &= " (Select Top 1 PRS.ShipmentDate from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC) as  RevisedShipmentDate "
                str &= " from Purchaseorder Po"
                str &= " Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID    "
                str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID    "
                str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID    "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= "  where Year(PO.CreationDate) >= 2012"
                If IPOID <> 0 Then
                    str &= " and PO.POID=" & IPOID
                End If
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllForWIPTracking(ByVal Userid As Long, Optional ByVal DateFrom As String = "")
            Dim str As String
            Try
                str = " Select  Po.PONO, SD.Article , SD.Colorway , SD.SizeRange, wp.processName,WC.Remarks,U.Username,C.Customername,V.vendername  from WIPChart WC"
                str &= "  join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
                str &= " join Purchaseorder PO on Po.POID=WC.POID"
                str &= " join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
                str &= " Join Customer C on C.CustomerID=PO.CustomerID"
                str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
                str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
                str &= " join UMuser U on U.Userid=Wc.Userid"
                str &= "  where "
                If Userid <> 0 Then
                    str &= " Wc.Userid='" & Userid & "' and "
                End If
                If DateFrom <> "" Then
                    str &= " Convert(Varchar,WC.CreationDate,110)= '" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "-" & DateFrom.Substring(6, 4) & "' "
                End If
                str &= " order by wc.WIPChartId  "
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllForLastWIPTracking(ByVal Userid As Long)
            Dim str As String
            Try
                str = " Select top 1 Po.PONO, SD.Article , SD.Colorway , SD.SizeRange, wp.processName,WC.Remarks,U.Username,C.Customername,V.vendername  from WIPChart WC"
                str &= "  join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
                str &= " join Purchaseorder PO on Po.POID=WC.POID"
                str &= " join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
                str &= " Join Customer C on C.CustomerID=PO.CustomerID"
                str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
                str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
                str &= " join UMuser U on U.Userid=Wc.Userid"
                str &= "  where "
                If Userid <> 0 Then
                    str &= " Wc.Userid='" & Userid & "'   "
                End If

                str &= " order by wc.WIPChartId  DESC"
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function QRCodeForMGT(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select Count(distinct SD.Article) as TotalArticle "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTotalArticles(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select Count(PO.POID) as TotalArticle "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID "
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function QRCodeTotalQty(ByVal lPOID As Long)
            Dim Str As String
            Str = " Select Sum(Quantity) as TotalQuantity  "
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " where  PO.POID=" & lPOID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMail()
            Dim str As String
            Try
                str = " select * "
                str &= " ,Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee"
                str &= " ,cast(POD.Quantity as decimal(10,0))as ArticleQTY ,"
                str &= " cast((POD.Quantity * POD.Rate) as decimal(10,2))as ArticleValue"
                str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID    "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                'str &= " and Getdate() > DATEADD(dd, ((PO.TimeSpame * 45)/100) , PO.PlacementDate)"
                str &= " order by ECPdivistion ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllSupplierForMail()
            Dim str As String
            Try
                str = "  select distinct V.VenderLibraryID,v.vendername"
                str &= " from PurchaseOrder po "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013  and PO.status !='Cancel' and PO.status !='Close' "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by v.vendername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllMerchandiserForMail()
            Dim str As String
            Try
                str = "  select distinct um.userid,um.username"
                str &= " from PurchaseOrder po "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 and PO.status !='Cancel' and PO.status !='Close' "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by um.username ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyer(ByVal Supplierid As Long)
            Dim str As String
            Try
                str = " select distinct C.CustomerID, C.CustomerName from Purchaseorder PO "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= "  where Year(PO.Shipmentdate) >= 2013 and PO.status !='Cancel' and PO.status !='Close' and PO.Supplierid=" & Supplierid
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMasterSupplierMail(ByVal Supplierid As Long)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  , Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee, '' as ReminderCount,'' as Process  "
                str &= " from PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.Supplierid=" & Supplierid
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by C.Customername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMasterSupplierMaill(ByVal Supplierid As Long, ByVal Customerid As Long)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee, '' as ReminderCount,'' as Process,  "
                str &= "   DATEDIFF(DAY,PO.PlacementDate,(Select Top 1  PRS.ShipmentDate  "
                str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC)) as NewTimeSpame, "
                str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,106) from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC) as  ShipmentDatee "
                str &= " from PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 and PO.status !='Cancel' and PO.status !='Close' "
                str &= " and PO.Supplierid=" & Supplierid
                str &= " and PO.CustomerID=" & Customerid
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by C.Customername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMasterSupplierMailCustomer(ByVal Customerid As Long, ByVal MarchandID As Long, ByVal SupplierID As Long)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  , Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee, '' as ReminderCount,'' as Process  "
                str &= " from PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.Customerid=" & Customerid
                str &= " and PO.MarchandID=" & MarchandID
                str &= " and PO.Supplierid=" & SupplierID
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by C.Customername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetAllDataForMasterMerchantMail(ByVal MarchandID As Long)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty"
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee, '' as ReminderCount,  "
                str &= "  isnull(DATEDIFF(DAY,PO.PlacementDate,(Select Top 1  PRS.ShipmentDate  "
                str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC)),0) as NewTimeSpame, "
                str &= "  isnull((Select Top 1  Convert(Varchar,PRS.ShipmentDate,106) from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC),Convert(Varchar,PO.ShipmentDate,106)) as  ShipmentDatee "
                str &= " from PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 and PO.status !='Cancel' and PO.status !='Close' "
                str &= " and PO.MarchandID=" & MarchandID
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by C.Customername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllMerchantSupplierForMail(ByVal MarchandID As Long)
            Dim str As String
            Try
                str = "  select distinct V.VenderLibraryID,v.vendername"
                str &= " from PurchaseOrder po "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013"
                str &= " and PO.MarchandID=" & MarchandID
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by v.vendername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllMerchantSuppliersForMail(ByVal MarchandID As Long, ByVal SupplierID As Long)
            Dim str As String
            Try
                str = "  select distinct C.customername,C.customerid"
                str &= " from PurchaseOrder po "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013"
                str &= " and PO.MarchandID=" & MarchandID
                str &= " and PO.SupplierID=" & SupplierID
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by C.customername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMasterMail()
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  , Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee   from  "
                str &= " PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                'str &= " and Getdate() > DATEADD(dd, ((PO.TimeSpame * 45)/100) , PO.PlacementDate)"
                str &= " order by ECPdivistion ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForMasterSupplierMail()
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  , Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee ,'' as Process  from  "
                str &= " PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                'str &= " and Getdate() > DATEADD(dd, ((PO.TimeSpame * 45)/100) , PO.PlacementDate)"
                str &= " order by V.vendername ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForRedAlertMail(ByVal Process As String)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  ,  "
                str &= " (Select Top 1  Convert(Varchar,PRS.ShipmentDate,106) from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC) as  ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee   from  "
                str &= " PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= "  join EmailReminder ER on ER.POID=PO.POID  "
                str &= " where Year(PO.Shipmentdate) >= 2013 "
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= "  and ER.ReminderCount >=3 and ER.Process='" & Process & "'"
                str &= " order by V.vendername ASC,C.customername ASC,ER.ReminderCount DESC"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetAllDataForWeekShipmentMail(ByVal WeekStartDate As Date, ByVal WeekEndDate As Date)
            Dim str As String
            Try
                str = " select *,(case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar, (Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
                str &= " where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
                str &= "  where POID =PO.POID) as Qty  , Convert(Varchar,PO.ShipmentDate,106)as ShipmentDatee "
                str &= " ,Convert(Varchar,PO.PlacementDate,106)as PlacementDatee   from  "
                str &= " PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
                str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where PO.Shipmentdate between '" & WeekStartDate.ToString("yyyy-MM-dd") & "' and '" & WeekEndDate.ToString("yyyy-MM-dd") & "'"
                str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
                str &= " order by PO.Shipmentdate ASC "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForMerchant(ByVal IUserid As Long)
            Dim Str As String
            Str = "  select PO.POID,POD.PODetailID,stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season,stm.StyleNo,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= "  por.Name as ShipmentMode ,po.PONO,std.Article,std.Colorway, std.SizeRange  as SizeRange "
            Str &= " ,pod.Rate, CAST(POD.quantity AS DECIMAL(10,0)) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then CAST(POD.quantity AS DECIMAL(10,0)) else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= "  on WP.WIPProcessID=WC.WIPProcessID where wc.POdetailID=POD.POdetailID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= "  ,  (case when IsNull((Select  Sum(SS.Quantity)  from SplitShipmentDetail SS  where SS.PODetailID=POD.PODetailID),0)>0 then "
            Str &= " 'Yes' else 'No' end) as 'Splitted' "
            Str &= "  ,  (case when IsNull((Select  Sum(SS.Quantity)  from SplitShipmentDetail SS  where SS.PODetailID=POD.PODetailID),0)>0 then "
            Str &= "   'Yes' else 'No' end) as 'Splitted' "
            Str &= "  ,(Case when  (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID)=0 then"
            Str &= "  'Open'  when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
            Str &= "  <  round((POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100),0) then "
            Str &= "  'Shipped with shortfall'"
            Str &= "  when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
            Str &= "  >= round((POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100),0)"
            Str &= "  and (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID)<"
            Str &= "   round((POD.Quantity + (POD.Quantity * PO.Toleranceindays) / 100), 0)"
            Str &= "  then  'Shipped'    when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID)="
            Str &= "  round((POD.Quantity + (POD.Quantity * PO.Toleranceindays) / 100), 0)"
            Str &= "  then   'Shipped'  else    'Shipped with excess'    end) as ArticleStatus "

            Str &= "  from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "  join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "  join PORelatedFields por on por.ID = Po.ShipmentMode "
            Str &= "  where Po.marchandid =" & IUserid
            Str &= "  and  Year(PO.Shipmentdate) >=2013 "
            Str &= " order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForMerchantNew(ByVal IUserid As Long)
            Dim Str As String
            Str = "  select PO.POID,stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " por.Name as ShipmentMode "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo ,po.PONO,"
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POPOID=PO.POID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then "
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID)"
            Str &= "  else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= " ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= " order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= " ,isNUll((Select Top 1 ('Article:'+ SD.Article +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip'"
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields por on por.ID = Po.ShipmentMode "
            Str &= " where Po.marchandid =" & IUserid
            Str &= " and  Year(PO.Shipmentdate) >=2013 "
            Str &= " order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForCelioNewOrder(ByVal IUserid As Long)
            Dim Str As String
            Str = "  select PO.POID, C.CustomerName as CustomerName,PO.EKNumber, V.VenderName "
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " por.Name as ShipmentMode "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo ,po.PONO,"
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POPOID=PO.POID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then "
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID)"
            Str &= "  else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= " ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= " order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= " ,isNUll((Select Top 1 ('Article:'+ SD.ColorRefNo +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip',UM.Username"
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields por on por.ID = Po.ShipmentMode "
            Str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            Str &= " where Po.POtype='New' "
            Str &= " and PO.CustomerID=46 "
            Str &= " and Year(PO.Shipmentdate) >=2013 "
            Str &= " order by PO.POID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForCelioNewOrderCCP()
            Dim Str As String
            Str = "  select PO.POID,stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " por.Name as ShipmentMode "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID) as StyleNo ,po.PONO,"
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POPOID=PO.POID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then "
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID)"
            Str &= "  else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= " ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= " order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= " ,isNUll((Select Top 1 ('Article:'+ SD.Article +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip'"
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields por on por.ID = Po.ShipmentMode "
            Str &= " where Po.POtype='New' "
            Str &= " and PO.CustomerID=46 "
            Str &= " and Year(PO.Shipmentdate) >=2013 "
            Str &= " order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOCloseStatusPanelOrders(ByVal IUserid As Long)
            Dim Str As String
            Str = "  select PO.POID,stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " por.Name as ShipmentMode "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID) as StyleNo ,po.PONO,"
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POPOID=PO.POID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then "
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID)"
            Str &= "  else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= " ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= " order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= " ,isNUll((Select Top 1 ('Article:'+ SD.Article +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip'"
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields por on por.ID = Po.ShipmentMode "
            If IUserid = 26 Then
                Str &= " where  Year(PO.Shipmentdate) >=2013 "
            ElseIf IUserid = 28 Then
                Str &= " where  Year(PO.Shipmentdate) >=2013 "
            ElseIf IUserid = 93 Then
                Str &= " where  Year(PO.Shipmentdate) >=2013 "
            ElseIf IUserid = 77 Then
                Str &= " where  Year(PO.Shipmentdate) >=2013 "
            Else
                Str &= " where Po.marchandid =" & IUserid
                Str &= " and  Year(PO.Shipmentdate) >=2013 "
            End If
            Str &= " and PO.Status <> 'Close' and PO.POID in (Select Distinct POPOID from CargoDetail) "
            Str &= " order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForManagement()
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass as CustomerName,PO.EKNumber,"
            Str &= " v.ShortName  as VenderName "
            Str &= " , stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue , (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " isNull((Convert(varchar,(Select cast (SUM(Isnull((CD.Quantity),0)* Isnull((CD.ShippedRate),0)) as money) from "
            Str &= " CargoDetail CD where CD.POPOID =PO.POID),1)),'--')"
            Str &= " as ShippedValue, (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " isNull((Convert(varchar,cast((Select cast (SUM(Isnull((CD.Quantity),0)* Isnull((CD.ShippedRate),0)) as money) from "
            Str &= " CargoDetail CD where CD.POPOID =PO.POID) * C.COmmission /100 as Decimal (10,2)) ,1)),'--') as Commission"
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity , CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= " , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate ,PO.Currency,"
            Str &= " isnull((Select Sum(CD.Quantity) from CargoDetail CD  where CD.POPOID=PO.POID),0)as ShippedQty"
            Str &= " , IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,Cast('0' as DEcimal(10,0)) as ClaimQty  from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013"
            ' Str &= "  and PO.POID in (Select Distinct POPOID from cargodetail)"
            Str &= "  order by year(PO.Shipmentdate) DESC, month(PO.Shipmentdate) DESC, day(PO.Shipmentdate) DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOpenOrderForManagement()
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " , stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  order by year(PO.Shipmentdate) DESC, month(PO.Shipmentdate) DESC, day(PO.Shipmentdate) DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOpenOrderForManagementBacklog()
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " , stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency,PO.TimeSpame,PO.PlacementDate as PlacementDatee"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  order by year(PO.Shipmentdate) DESC, month(PO.Shipmentdate) DESC, day(PO.Shipmentdate) DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOpenOrderForManagementForInspectionLoad()
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " ,  stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency"
            Str &= "  ,isnull((Select DateEstemated  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as ProcessDateEstemated "
            Str &= "  ,isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as"
            Str &= "  ProcessWeekNo, datepart(wk,getdate()) as CurrentWeek"
            Str &= "  ,(case when (Select COunt(Distinct I.POID)  from ICR I where I.POID=PO.POID ) > 0 then 'Issued' else 'Not Issued' end) as ICR"
            Str &= "  ,isnull((Select left( DATENAME(Month,DateEstemated),3)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspMonth "
            Str &= "  ,isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspDate"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  order by case "
            Str &= "   when  isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = datepart(wk,getdate()) then 1"
            Str &= "   when  isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) < datepart(wk,getdate())then 2"
            Str &= "  when  isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) > datepart(wk,getdate()) then 3"
            Str &= "   end ASC"
            Str &= "   ,  isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) DESC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendInspectionRosterForNextWeek()
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " ,  stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency"
            Str &= "  ,isnull((Select DateEstemated  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as ProcessDateEstemated "
            Str &= "  ,isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as"
            Str &= "  ProcessWeekNo, datepart(wk,getdate()) as CurrentWeek"
            Str &= "  ,(case when (Select COunt(Distinct I.POID)  from ICR I where I.POID=PO.POID ) > 0 then 'Issued' else 'Not Issued' end) as ICR"
            Str &= "  ,isnull((Select left( DATENAME(Month,DateEstemated),3)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspMonth "
            Str &= "  ,isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspDate"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2014"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  and isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = (datepart(wk,getdate())+ 1) "
            Str &= " order by isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendInspectionRosterForNextWeekDistinctMarchant()
            Dim Str As String
            Str = "  select distinct PO.MarchandID,U.Username "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2014"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  and isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = (datepart(wk,getdate())+ 1) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendInspectionRosterForNextWeekMarchant(ByVal MarchandID As Long)
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " ,  stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency"
            Str &= "  ,isnull((Select DateEstemated  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as ProcessDateEstemated "
            Str &= "  ,isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as"
            Str &= "  ProcessWeekNo, datepart(wk,getdate()) as CurrentWeek"
            Str &= "  ,(case when (Select COunt(Distinct I.POID)  from ICR I where I.POID=PO.POID ) > 0 then 'Issued' else 'Not Issued' end) as ICR"
            Str &= "  ,isnull((Select left( DATENAME(Month,DateEstemated),3)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspMonth "
            Str &= "  ,isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspDate"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2014"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  and isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = (datepart(wk,getdate())+ 1) "
            Str &= " and PO.MarchandID=" & MarchandID
            Str &= " order by isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendInspectionRosterForNextWeekDistinctSupplier()
            Dim Str As String
            Str = "  select distinct PO.SupplierID,V.Vendername "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2014"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  and isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = (datepart(wk,getdate())+ 1) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendInspectionRosterForNextWeekSupplier(ByVal SupplierID As Long)
            Dim Str As String
            Str = "  select PO.POID, (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= "  (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= " end ) as [BusinessQuarter],left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth"
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName  as VenderName "
            Str &= " ,  stuff(U.Username,7,40,'..')as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency"
            Str &= "  ,isnull((Select DateEstemated  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as ProcessDateEstemated "
            Str &= "  ,isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as"
            Str &= "  ProcessWeekNo, datepart(wk,getdate()) as CurrentWeek"
            Str &= "  ,(case when (Select COunt(Distinct I.POID)  from ICR I where I.POID=PO.POID ) > 0 then 'Issued' else 'Not Issued' end) as ICR"
            Str &= "  ,isnull((Select left( DATENAME(Month,DateEstemated),3)  from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspMonth "
            Str &= "  ,isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0)as InspDate"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2014"
            Str &= "  and PO.POID not in (Select Distinct POPOID from cargodetail)"
            Str &= "  and isnull((Select datepart(wk,DateEstemated)  from TNAChart TNA  where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) = (datepart(wk,getdate())+ 1) "
            Str &= " and PO.SupplierID=" & SupplierID
            Str &= " order by isnull((Select  CONVERT(VARCHAR(11), TNA.DateEstemated, 103)   from TNAChart TNA where TNA.POID=PO.POID and TNA.TNAProcessID=24),0) ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForSrManagement()
            Dim Str As String
            Str = "  select Po.POID,stuff(DATENAME(mm,PO.ShipmentDate),4,12,'') AS Month ,stuff(Cs.CustomerName,4,40,'..')as CustomerName, "
            Str &= "  '002' as TotalPos,pod.Quantity as bookQty,cd.quantity as Squantity, '0000' as 'BookedValue',"
            Str &= " '0000' as 'shipVal','000' as 'BookComm','000' as 'ShipComm','000' as 'ClaimedPcs',"
            Str &= " '000' as 'TimelyShipPcs','000' as 'DelPerfor',"
            Str &= " C.Currency"
            Str &= " ,((Isnull((cd.Quantity),0)* Isnull((cd.Shippedrate),0) )"
            Str &= " )  as Generalvalue,c.ShippedExchangeRate,"
            Str &= " (case when C.Currency <> 'Dollar' then "
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " ))*Isnull((c.ShippedExchangeRate),0)"
            Str &= " else"
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " )) end) as DollarVales,Po.Commission,"
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " )) * Po.Commission /100as GeneralCommission,"
            Str &= " (case when C.Currency <> 'Dollar' then "
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " ))*Isnull((c.ShippedExchangeRate),0)"
            Str &= " else"
            Str &= " ("
            Str &= " ((Isnull((cd.Quantity),0)*Isnull((cd.Shippedrate),0)) "
            Str &= " )) end)  * Po.Commission /100  asDollarCommision"
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " join Customer CS on CS.CustomerID=po.CustomerID"
            Str &= " left join purchaseorderdetail pod on pod.Podetailid=cd.poid"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForSupplier(ByVal Supplierid As Long)
            Dim Str As String
            Str = "   select PO.POID,POD.PODetailID, PO.Destination,"
            Str &= "   left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth,"
            Str &= "   DATEPART(wk, PO.ShipmentDate) as ShipWeek"
            Str &= " , stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName, U.EcpDivistion ,stuff(U.Username,7,40,'..')as UserName "
            Str &= "  ,PO.Season, Po.ProductCategories,PO.ProductGroup,PO.Composition,"
            Str &= " stm.StyleNo,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= "   po.PONO,std.Article,std.Colorway, std.SizeRange  as Size,PO.Currency "
            Str &= " ,pod.Rate, CAST(POD.quantity AS DECIMAL(10,0)) as ItemQty,"
            Str &= " (case when PO.Currency <> 'Dollar'  then '€' else '$'"
            Str &= " end )+ Convert(varchar,(Pod.Rate*POD.quantity)) AS ItemValue, "
            Str &= "  IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID"
            Str &= "   and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= "  ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= "  ,Cast('0' as DEcimal(10,0)) as 'POCancelQty',  Cast('0' as DEcimal(10,0)) as 'ClaimQty', "
            Str &= "   (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "   where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'Revised',PO.Status "
            Str &= "   ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= "  on WP.WIPProcessID=WC.WIPProcessID where wc.POdetailID=POD.POdetailID order by wc.WIPChartId DESC),'--') as 'ActualWp'"
            Str &= "  ,'' as ICR , '' as PL, '' as InvoiceNo, porf.Name as ShipmentMode, porff.Name as ShipmentTerm "
            Str &= " from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "   join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "   join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields porf on porf.ID =po.ShipmentMode "
            Str &= " join PORelatedFields porff on porff.ID =po.PaymentMode "
            Str &= "   join Umuser U on U.Userid=Po.Marchandid"
            Str &= "      where  Year(PO.Shipmentdate) >= 2013 and Po.Supplierid=" & Supplierid
            Str &= "  order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForCustomer(ByVal CustomerID As Long)
            Dim Str As String
            Str = "  select PO.POID "
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.VenderName  as VenderName "
            Str &= " ,  U.Username  as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency, "
            Str &= "    (case when (Select Count(PRS.POReviseShipmentID) from PurchaseOrderReviseShipment PRS  "
            Str &= "  where PRS.POID=PO.POID)>1 then (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) "
            Str &= "  as ShipmentDate  from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID  order by PRS.POReviseShipmentID DESC) "
            Str &= "  else '--'  end) as 'Revised', "
            Str &= "   stuff(Po.ProductCategories,5,40,'..') as  ProductCategories,stuff(PO.ProductGroup,5,40,'..') as ProductGroup "
            Str &= "   ,isnull((Select top 1 wp.processName + ' '+ convert(varchar,"
            Str &= "  (count(distinct PODetailID) * 100) / (select count(distinct PODetailID) from purchaseorderDetail where "
            Str &= "  poid=Po.POID )) + '%' from WIPChart WC join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  where wc.POID=PO.POID GROUP BY  WC.WIPProcessID,WC.WIPProcessID ,WP.ProcessName"
            Str &= "  order by WC.WIPProcessID DESC),'--') as 'WIPStatus' , PO.TimeSpame,PO.PlacementDate as PlacementDatee "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013 "
            If CustomerID = 0 Then
                Str &= " and po.CustomerID in (33, 40) "
            Else
                Str &= " and PO.CustomerID=" & CustomerID
            End If
            Str &= "  order by year(PO.Shipmentdate) DESC, month(PO.Shipmentdate) DESC, day(PO.Shipmentdate) DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForCustomerMail()
            Dim Str As String
            Str = "  select PO.POID "
            Str &= " , C.Aliass  CustomerName,PO.EKNumber,"
            Str &= "  V.VenderName  as VenderName "
            Str &= " ,  U.Username  as UserName,po.PONO, "
            Str &= " (case when Currency='Dollar' then '$ ' when Currency='Euro' then '€ ' end) +"
            Str &= " (Convert(varchar,(Select cast (SUM(Isnull((POD.Quantity),0)* Isnull((POD.Rate),0)) as money) from "
            Str &= " PurchaseOrderDetail POD where POD.POID =PO.POID),1))"
            Str &= " as BookedValue "
            Str &= " , isnull((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,   CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate, PO.PlacementDate as PlacementDatee, PO.TimeSpame "
            Str &= "  , CONVERT(VARCHAR(11), PO.Shipmentdate, 103) as Shipmentdate,PO.Currency, "
            Str &= "    (case when (Select Count(PRS.POReviseShipmentID) from PurchaseOrderReviseShipment PRS  "
            Str &= "  where PRS.POID=PO.POID)>1 then (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) "
            Str &= "  as ShipmentDate  from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID  order by PRS.POReviseShipmentID DESC) "
            Str &= "  else '--'  end) as 'Revised', "
            Str &= "   stuff(Po.ProductCategories,5,40,'..') as  ProductCategories,stuff(PO.ProductGroup,5,40,'..') as ProductGroup "
            Str &= "   ,isnull((Select top 1 wp.processName + ' '+ convert(varchar,"
            Str &= "  (count(distinct PODetailID) * 100) / (select count(distinct PODetailID) from purchaseorderDetail where "
            Str &= "  poid=Po.POID )) + '%' from WIPChart WC join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  where wc.POID=PO.POID GROUP BY  WC.WIPProcessID,WC.WIPProcessID ,WP.ProcessName"
            Str &= "  order by WC.WIPProcessID DESC),'--') as 'WIPStatus' , PO.TimeSpame,PO.PlacementDate as PlacementDatee , "
            Str &= "   DATEDIFF(DAY,PO.PlacementDate,(Select Top 1  PRS.ShipmentDate  "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC)) as NewTimeSpame "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013 "
            Str &= " and po.CustomerID in (33, 40) and PO.POID not in (select distinct POPOID from Cargodetail) "
            Str &= "  order by year(PO.Shipmentdate) DESC, month(PO.Shipmentdate) DESC, day(PO.Shipmentdate) DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForSupplyChain()
            Dim Str As String
            Str = "   select PO.POID,POD.PODetailID,"
            Str &= " (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= " (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "   when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= "   end ) as [BusinessQuarter],"
            Str &= "   left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth,"
            Str &= "   DATEPART(wk, PO.ShipmentDate) as ShipWeek"
            Str &= " ,  C.Aliass as CustomerName,PO.EKNumber, V.ShortName "
            Str &= "  as VenderName, U.EcpDivistion ,stuff(U.Username,7,40,'..')as UserName "
            Str &= "  ,PO.Season, stuff(Po.ProductCategories,5,40,'..') as  ProductCategories,stuff(PO.ProductGroup,5,40,'..') as ProductGroup,PO.Composition,"
            Str &= " stm.StyleNo,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= "   po.PONO,std.Article,std.Colorway, std.SizeRange  as Size "
            Str &= " ,pod.Rate, CAST(POD.quantity AS DECIMAL(10,0)) as ItemQty,"
            Str &= " (case when PO.Currency <> 'Dollar'  then '€' else '$'"
            Str &= " end )+ Convert(varchar,(Pod.Rate*POD.quantity)) AS ItemValue, "
            Str &= "  IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID"
            Str &= "   and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= "  ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= "  ,Cast('0' as DEcimal(10,0)) as 'POCancelQty',  Cast('0' as DEcimal(10,0)) as 'ClaimQty', "
            Str &= "   (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "   where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'Revised',PO.Status "
            Str &= "  ,(case when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '1' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '11' then"
            Str &= "  'Yarn Procurement'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '12' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '45'  then"
            Str &= "  'Fabric In House'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '46' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '56'  then"
            Str &= "   'Processing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '57' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '60'  then"
            Str &= "  'Material Testing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '61' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '70'  then"
            Str &= "   'Cutting'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '71' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '90'  then"
            Str &= "   'Stitching'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '91' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '98'  then"
            Str &= "   'Packing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '99' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '100'  then"
            Str &= "  'Goods Release'"
            Str &= "  else 'Close'  end ) as 'ForecastWp'"
            Str &= "   ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= "  on WP.WIPProcessID=WC.WIPProcessID where wc.POdetailID=POD.POdetailID order by wc.WIPChartId DESC),'--') as 'ActualWp'"
            Str &= "  ,  (case when IsNull((Select  Sum(SS.Quantity)  from SplitShipmentDetail SS  where SS.PODetailID=POD.PODetailID),0)>0 then "
            Str &= "   'Yes' else 'No' end) as 'Splitted'"
            Str &= "  ,isnull((select TOP 1 LS.LogisticStatus from LogisticStatus LS "
            Str &= "  where LS.POID=PO.POID and LS.PODetailID=POD.PODetailID ),'--') as FinalStatus"
            Str &= "  from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "  join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "  join Umuser U on U.Userid=Po.Marchandid"
            Str &= "  where   Year(PO.Shipmentdate) >= 2013 "
            Str &= "  order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderDetailsForMerchantD(ByVal MarchantID As Long)
            Dim Str As String
            Dim Userid As Long = MarchantID
            Str = "   select PO.POID,POD.PODetailID,"
            Str &= " (case when PO.Shipmentdate Between Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-01'+'-01')) and Convert(Datetime,(Convert(nvarchar(20),year(PO.ShipmentDate))+'-03'+'-31')) then 'Q1'+'-'+ Convert(nvarchar  "
            Str &= " (20),year(PO.ShipmentDate))  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-04'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-06'+'-30')) then 'Q2'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "  when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-07'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-09'+'-30')) then 'Q3'+'-'+ Convert(varchar,year(PO.ShipmentDate))     "
            Str &= "   when PO.Shipmentdate Between Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-10'+'-01')) and Convert(Datetime,(Convert(varchar,Year(PO.ShipmentDate))+'-12'+'-31')) then 'Q4'+'-'+ Convert(varchar,year(PO.ShipmentDate))    "
            Str &= "   end ) as [BusinessQuarter],"
            Str &= "   left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth,"
            Str &= "   DATEPART(wk, PO.ShipmentDate) as ShipWeek"
            Str &= " ,  C.Aliass as CustomerName,PO.EKNumber, V.ShortName "
            Str &= "  as VenderName, U.EcpDivistion ,stuff(U.Username,7,40,'..')as UserName "
            Str &= "  ,PO.Season, stuff(Po.ProductCategories,5,40,'..') as  ProductCategories,stuff(PO.ProductGroup,5,40,'..') as ProductGroup,PO.Composition,"
            Str &= " stm.StyleNo,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= "   po.PONO,std.Article,std.Colorway, std.SizeRange  as Size "
            Str &= " ,pod.Rate, CAST(POD.quantity AS DECIMAL(10,0)) as ItemQty,"
            Str &= " (case when PO.Currency <> 'Dollar'  then '€' else '$'"
            Str &= " end )+ Convert(varchar,(Pod.Rate*POD.quantity)) AS ItemValue, "
            Str &= "  IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID"
            Str &= "   and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= "  ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= "  ,Cast('0' as DEcimal(10,0)) as 'POCancelQty',  Cast('0' as DEcimal(10,0)) as 'ClaimQty', "
            Str &= "   (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "   where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'Revised',PO.Status "
            Str &= "  ,(case when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '1' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '11' then"
            Str &= "  'Yarn Procurement'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '12' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '45'  then"
            Str &= "  'Fabric In House'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '46' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '56'  then"
            Str &= "   'Processing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '57' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '60'  then"
            Str &= "  'Material Testing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '61' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '70'  then"
            Str &= "   'Cutting'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '71' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '90'  then"
            Str &= "   'Stitching'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '91' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '98'  then"
            Str &= "   'Packing'"
            Str &= "  when (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame >= '99' and (DATEDIFF(DAY,  PO.PlacementDate ,Getdate())*100)/PO.timespame <= '100'  then"
            Str &= "  'Goods Release'"
            Str &= "  else 'Close'  end ) as 'ForecastWp'"
            Str &= "   ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= "  on WP.WIPProcessID=WC.WIPProcessID where wc.POdetailID=POD.POdetailID order by wc.WIPChartId DESC),'--') as 'ActualWp'"
            Str &= "  ,  (case when IsNull((Select  Sum(SS.Quantity)  from SplitShipmentDetail SS  where SS.PODetailID=POD.PODetailID),0)>0 then "
            Str &= "   'Yes' else 'No' end) as 'Splitted'"
            Str &= "  ,isnull((select TOP 1 LS.LogisticStatus from LogisticStatus LS "
            Str &= "  where LS.POID=PO.POID and LS.PODetailID=POD.PODetailID ),'--') as FinalStatus"
            Str &= "  from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "  join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "  join Umuser U on U.Userid=Po.Marchandid"
            Str &= "  where   Year(PO.Shipmentdate) >= 2013 "
            Str &= " and Po.Marchandid=" & Userid
            Str &= "  order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForQD()
            Dim Str As String
            Str = " select U.UserName,c.CustomerName,PO.POID, DATEPART(wk, PO.ShipmentDate) as ShipWeek"
            Str &= " , stuff(C.CustomerName,4,40,'..')as CustomerName,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= " as VenderName  ,PO.Season, Po.ProductCategories,stuff(PO.ProductGroup,7,40,'..')as ProductGroup,PO.Composition,"
            Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " po.PONO "
            Str &= " ,  CAST((Select (Sum(POD.Quantity)) from PurchaseorderDetail POD where POD.POID=PO.POID)  AS DECIMAL(10,0)) as ItemQty,"
            Str &= "  IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,Cast('0' as DEcimal(10,0)) as 'POCancelQty', Cast('0' as DEcimal(10,0)) as 'ClaimQty'"
            Str &= "  ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'ActualWp'"
            Str &= "  , stuff(U.Username,7,40,'..')as UserName , U.ecpdivistion"
            Str &= "  from PurchaseOrder Po"
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "  join Umuser U on PO.Marchandid=U.userid "
            Str &= "  where  "
            Str &= "  Year(PO.Shipmentdate) >=2013   order by PO.POID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForLogistic()
            Dim Str As String
            Str &= "  select PO.POID, '01' as 'Quarter',stuff(DATENAME(mm,PO.ShipmentDate),4,12,'') AS Month,"
            Str &= " DATEPART(wk, po.ShipmentDate)as 'week',stuff(C.CustomerName,4,40,'..')as CustomerName,"
            Str &= " stuff(V.VenderName,5,50,'..') as VenderName ,u.ECPDivistion , stuff(u.UserName,6,50,'..') "
            Str &= " as UserName,  PO.Season,PO.EKNumber, stuff(stm.StyleNo,5,50,'..') as StyleNo ,po.PONO"
            Str &= " ,std.Article, std.Colorway, std.SizeRange as size,pod.Rate,"
            Str &= " CONVERT(VARCHAR(11),po.PlacementDate,103) AS PlacementDate, CAST(POD.quantity"
            Str &= " AS DECIMAL(10,0)) as ItemQty,'001122' as 'ItemValue', CONVERT(VARCHAR(11),"
            Str &= " PO.ShipmentDate, 103) as ShipmentDate ,  "
            Str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS "
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' ,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID "
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty' "
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= " ,'Mode' as 'Mode' ,PO.Status "
            Str &= " from PurchaseOrder Po"
            Str &= " join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= " join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= " join StyleDetail std on std.StyleDetailID =POD.StyleDetailID"
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID"
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID "
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Year(Po.Shipmentdate)>=2013 and po.status='Shipped'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TemproryFUNForICR(ByVal IPOID As Long)
            Dim str As String
            Try
                str = "  select PO.POID,PO.PONO,PO.POrefNO,C.Customername,V.Vendername"
                str &= " ,PO.Placementdate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,S.styleNo,S.StyleName,sd.article,SD.sizerange, POD.PODetailID"
                str &= " ,SD.Colorway,PO.Destination,PO.EKNumber,cast(PoD.Quantity as decimal(10,0)) as Quantity,PO.ShipmentMode,SM.Name,Convert(Varchar,ROSD.ShipmentDate,106) as RvDate"
                str &= " from Purchaseorder Po"
                str &= " Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID    "
                str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID    "
                str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID    "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID "
                str &= " join PurchaseOrderReviseShipment ROSD on ROSD.POID=PO.POID"
                str &= "  where Year(PO.CreationDate) >= 2012 "
                If IPOID <> 0 Then
                    str &= " and PO.POID=" & IPOID
                End If
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForDataFeeder()
            Dim Str As String
            Str = "  Select PO.Commission,PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName as VenderName ,"
            Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
            Str &= "  Po.Destination , po.PONO, "
            Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
            Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
            Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
            Str &= "  from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013 "
            Str &= " order by Po.POID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForDataFeederBYMerchandiser(ByVal MarchandID As Long)
            Dim Str As String
            If MarchandID = 234 Then
                Str = "  Select PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
                Str &= "  V.ShortName as VenderName ,"
                Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
                Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
                Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
                Str &= "  Po.Destination , po.PONO, "
                Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
                Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
                Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
                Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
                Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
                Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
                Str &= "  from PurchaseOrder Po "
                Str &= " join Customer c on c.CustomerID =PO.CustomerID "
                Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
                Str &= "  join UMUser U on u.UserId =po.MarchandID"
                'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
                'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
                'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
                'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
                Str &= "  where Year(Po.ShipmentDate) >= 2013   "
                Str &= " order by Po.POID DESC "
            Else
                Str = "  Select PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
                Str &= "  V.ShortName as VenderName ,"
                Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
                Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
                Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
                Str &= "  Po.Destination , po.PONO, "
                Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
                Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
                Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
                Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
                Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
                Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
                Str &= "  from PurchaseOrder Po "
                Str &= " join Customer c on c.CustomerID =PO.CustomerID "
                Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
                Str &= "  join UMUser U on u.UserId =po.MarchandID"
                'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
                'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
                'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
                'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
                Str &= "  where Year(Po.ShipmentDate) >= 2013  and po.Userid='" & MarchandID & "'"
                Str &= " order by Po.POID DESC "
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForDataFeederBYMerchandiserBySearch(ByVal MarchandID As Long, ByVal PONO As String)
            Dim Str As String
            If MarchandID = 234 Then
                Str = "  Select PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
                Str &= "  V.ShortName as VenderName ,"
                Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
                Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
                Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
                Str &= "  Po.Destination , po.PONO, "
                Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
                Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
                Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
                Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
                Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
                Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
                Str &= "  from PurchaseOrder Po "
                Str &= " join Customer c on c.CustomerID =PO.CustomerID "
                Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
                Str &= "  join UMUser U on u.UserId =po.MarchandID"
                'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
                'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
                'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
                'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
                Str &= "  where Year(Po.ShipmentDate) >= 2013  AND PO.PONO='" & PONO & "' "
                Str &= " order by Po.POID DESC "
            Else
                Str = "  Select PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
                Str &= "  V.ShortName as VenderName ,"
                Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
                Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
                Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
                Str &= "  Po.Destination , po.PONO, "
                Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
                Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
                Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
                Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
                Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
                Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
                Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
                Str &= "  from PurchaseOrder Po "
                Str &= " join Customer c on c.CustomerID =PO.CustomerID "
                Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
                Str &= "  join UMUser U on u.UserId =po.MarchandID"
                'Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
                'Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
                'Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
                'Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
                Str &= "  where Year(Po.ShipmentDate) >= 2013  and po.Userid='" & MarchandID & "' AND PO.PONO='" & PONO & "' "
                Str &= " order by Po.POID DESC "
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForDataFeederBYManagement()
            Dim Str As String

            Str = "  Select PO.Commission,PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName as VenderName ,"
            Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
            Str &= "  Po.Destination , po.PONO, "
            Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
            Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
            Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
            Str &= "  from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013   "
            Str &= " order by Po.POID DESC "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForDataFeederBYManagementBySearch(ByVal PONO As String)
            Dim Str As String

            Str = "  Select PO.Commission,PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName as VenderName ,"
            Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season, "
            Str &= "  Po.Destination , po.PONO, "
            Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
            Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
            Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
            Str &= "  from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013  AND PO.PONO='" & PONO & "' "
            Str &= " order by Po.POID DESC "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Check(ByVal poid As Long)
            Dim Str As String
            Str = "  select * from TNAChart where poid='" & poid & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSampling()
            Dim Str As String
            Str = "  select st.StyleID , Convert(varchar,Creationdate,103) as Creationdate ,c.customername,  st.productgroup, stuff(st.stylename,10,20,'...') as stylename , stuff(st.materialcomposition,10,50,'...')"
            Str &= "  as materialcomposition,  st.styleno from stylemaster st "
            Str &= "  join customer c on c.customerid=st.buyer"
            Str &= "  order by St.StyleID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommercialInvoiceFrPopupr(ByVal PONO As String)
            Dim Str As String
            Str = "   select '0'  as 'CommercialInvoiceDetailID',POd.StyleID ,PO.POID,POD.PODetailID, PO.Destination,"
            Str &= "  left( DATENAME(Month, Po.ShipmentDate),3)  AS ShipMonth,"
            Str &= "  DATEPART(wk, PO.ShipmentDate) as ShipWeek"
            Str &= "  , stuff(C.CustomerName,4,40,'..')as CustomerName, C.CustomerName as CustomerName1,PO.EKNumber,stuff(V.VenderName,5,50,'..')"
            Str &= "  as VenderName, U.EcpDivistion ,stuff(U.Username,7,40,'..')as UserName "
            Str &= "  ,PO.Season, Po.ProductCategories,PO.ProductGroup,PO.Composition,"
            Str &= "  stm.StyleNo,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= "  po.PONO,std.Article,std.Colorway, std.SizeRange  as Size "
            Str &= "  ,pod.Rate, CAST(POD.quantity AS DECIMAL(10,0)) as ItemQty,"
            Str &= "  (case when PO.Currency <> 'Dollar'  then '€' else '$'"
            Str &= "  end )+ Convert(varchar,(Pod.Rate*POD.quantity)) AS ItemValue, "
            Str &= "  IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.PODetailID=POD.PODetailID"
            Str &= "  and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= "  ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POID=POD.PODetailID ),0)as 'ShippedQty'"
            Str &= "  ,'0' as 'POCancelQty',  '0' as 'ClaimQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'Revised',PO.Status "
            Str &= "  ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= "  on WP.WIPProcessID=WC.WIPProcessID where wc.POdetailID=POD.POdetailID order by wc.WIPChartId DESC),'--') as 'ActualWp'"
            Str &= "  ,'' as ICR , '' as PL, '' as InvoiceNo, porf.Name as ShipmentMode,Po.currency,porff.Name as ShipmentTerm "
            Str &= "  from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "  join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "  join PORelatedFields porf on porf.ID =po.ShipmentMode "
            Str &= "  join PORelatedFields porff on porff.ID =po.PaymentMode "
            Str &= "  join Umuser U on U.Userid=Po.Marchandid"
            Str &= "  where   Year(PO.Shipmentdate) >= 2013 and Po.PONO='" & PONO & " '"
            Str &= "  order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForClaim(ByVal BuyerID As Long, ByVal VenderID As Long)
            Dim Str As String
            Str = " Select POID,PONO from PurchaseOrder"
            Str &= " Where CustomerID=" & BuyerID & " and SupplierID=" & VenderID & " "
            Str &= " and   year(ShipmentDate)>=2012  order by PONO asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForClaimNew(ByVal BuyerID As Long, ByVal VenderID As Long)
            Dim Str As String
            Str = "   Select Distinct PO.POID,PO.PONO from PurchaseOrder PO"
            Str &= " join CargoDetail Cd on Po.POID=Cd.POPOID "
            Str &= " Where PO.CustomerID=" & BuyerID & " and PO.SupplierID=" & VenderID & " "
            Str &= "  and   Year(PO.ShipmentDate)>=2012 "
            Str &= " order by PO.PONO asc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForClaimwithbuyingdeptNew(ByVal BuyerID As Long, ByVal VenderID As Long, ByVal lbuyingdept As String, ByVal lSEASON As String)
            Dim Str As String
            Str = "   Select Distinct PO.POID,PO.PONO from PurchaseOrder PO"
            Str &= " join CargoDetail Cd on Po.POID=Cd.POPOID "
            Str &= " Where PO.CustomerID=" & BuyerID & " and PO.SupplierID=" & VenderID & "  and po.EKNumber='" & lbuyingdept & "' and PO.SEASON='" & lSEASON & "'"
            Str &= "  and   Year(PO.ShipmentDate)>=2012 "
            Str &= " order by PO.PONO asc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtCustomerData()
            Dim Str As String
            Str &= " select Distinct  c.CustomerID ,c.CustomerName, C.Commission from Customer C "
            Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID"
            Str &= "  where Year(PO.creationDate) >= 2012 "
            Str &= " order by     c.CustomerName ASC"
            'Str = "    select distinct c.CustomerID ,c.CustomerName, C.Commission from  Customer C"
            'Str &= "  where IsActive = 1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                'Return MyBase.GetScaler(Str)
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((POD.Quantity),0))  as BookedQuantity "
            Str &= " from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on po.POID=pod.POID "
            Str &= "   where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
                'Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtCustomerArticleData()
            Dim Str As String
            Str &= " select Distinct  c.CustomerID ,c.CustomerName, C.Commission from Customer C "
            Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID"
            Str &= "  where Year(PO.creationDate) >= 2012 "
            Str &= " order by     c.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetMGTShippedQTY(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Str &= " group by po.customerid"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  SUM(Isnull((cd.quantity),0))  as ShippedQty "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Str &= " group by po.customerid"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'"
            Str &= " and po.status !='Cancel' And PO.CustomerID =" & CustomerID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedQTYOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Isnull(SUM((CD.Quantity)),0)  as ShippedQuantity from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'"
            Str &= " and po.status !='Cancel' And PO.CustomerID =" & CustomerID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedForPOsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedArticlePOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select Count(Distinct std.Article) as TotalBookedPos from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "  group by PO.PONO"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Str &= " group by po.customerid"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedPosNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select  Count(Distinct PO.POID)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Str &= " group by po.customerid"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalShippedArticle(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = "  Select  Count(Distinct std.Article)  as TotalShippedPOs "
            Str &= " from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " join PurchaseOrderDetail POD on POD.PODetailID=cd.poid "
            Str &= " join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Str &= " group by PO.PONO"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And PO.CustomerID =" & CustomerID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            'Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            'Str &= " join Cargo c on c.cargoid=cd.cargoid"
            'Str &= " join purchaseorder po on po.poid=cd.popoid "
            'Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedPOsOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And PO.CustomerID =" & CustomerID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "

            'Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime from Cargodetail cd"
            'Str &= " join Cargo c on c.cargoid=cd.cargoid"
            'Str &= " join purchaseorder po on po.poid=cd.popoid "
            'Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedArticleOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = " select Count(Distinct std.Article)  as ShippedPOsOnTime from Cargodetail cd"
            Str &= " join Cargo c on c.cargoid=cd.cargoid"
            Str &= " join purchaseorder po on po.poid=cd.popoid "
            Str &= " join PurchaseOrderDetail POD on POD.PODetailID=cd.poid "
            Str &= " join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Str &= "   and std.Article in ( select Distinct std.Article from PurchaseOrder PO "
            Str &= " join PurchaseOrderDetail POD on POD.POID=PO.poid "
            Str &= " join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
            Str &= " and po.status !='Cancel' And PO.CustomerID =" & CustomerID
            Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
            Str &= " group by PO.PONO"


            'Str = " select Count(Distinct std.Article)  as ShippedPOsOnTime from Cargodetail cd"
            'Str &= " join Cargo c on c.cargoid=cd.cargoid"
            'Str &= " join purchaseorder po on po.poid=cd.popoid "
            'Str &= " join PurchaseOrderDetail POD on POD.PODetailID=cd.poid "
            'Str &= " join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            'Str &= "  where c.etd between '" & Fromdate & "' and '" & ToDate & "' and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            'Str &= " and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
            ' Str &= " group by PO.PONO"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = "Select  "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012 and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTBookedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = "Select  "
            Str &= "  (case when PO.Currency <> 'Dollar' then"
            Str &= "   (Isnull(POD.Quantity,0)*Isnull(POD.Rate,0)) * Isnull(PO.ExchangeRate,0)"
            Str &= " else Isnull(POD.Quantity,0)*Isnull(POD.Rate,0) end)   as  BookedTurnOver "
            Str &= " from Purchaseorder PO join PurchaseOrderDetail POD on POD.POID=PO.POID"
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and year(PO.creationDate)>=2012 and po.status !='Cancel' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOver(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
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
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTShippedTurOverNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
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
            Str &= " where c.etd  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTClaiPcs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = "  select  SUM(Isnull((C.ClaimPcs),0))  as ClaimPcs from POClaim  C "
            Str &= "  join PurchaseOrder PO on po.POID=c.POID "
            Str &= " where c.creationdate  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTClaiPcsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal CustomerID As Long)
            Dim Str As String
            Str = "  select  SUM(Isnull((C.ClaimPcs),0))  as ClaimPcs from POClaim  C "
            Str &= "  join PurchaseOrder PO on po.POID=c.POID "
            Str &= " where c.creationdate  between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = "   select count(PO.POID) as TotalPOs from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMGTTotalPosCheckTimelyShipped(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal CustomerID As Long)
            Dim Str As String
            Str = "   select PO.POID from PurchaseOrder PO"
            Str &= " where po.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' And PO.CustomerID = " & CustomerID
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
        Public Function GetChartValues()
            Dim str As String
            str = "select distinct U.ecpdivistion ,Count (PO.POID) as showColum from Purchaseorder Po "
            str &= " join Umuser u on u.userid=po.marchandid"
            str &= " where Year(PO.ShipmentDate) >= 2013  group by U.ecpdivistion"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function bookedorders(ByVal id As Long, ByVal Type As String)
            Dim str As String
            str = " Select 'Booked' as Name,  Count (PO.POID) as value"
            str &= " from PurchaseOrder po  Where  year(PO.ShipmentDate )>=2013 "
            If Type = "Supplier" Then
                str &= " and po.Supplierid ='" & id & "'"
            ElseIf Type = "Merchant" Then
                str &= " and po.MarchandID ='" & id & "'"
            ElseIf Type = "Customer" Then
                If id = 0 Then
                    str &= " and po.CustomerID in (33, 40) "
                Else
                    str &= " and po.CustomerID ='" & id & "'"
                End If
            Else
                'All
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function bookedordersAldi()
            Dim str As String
            str = " Select 'Booked' as Name,  Count (PO.POID) as value"
            str &= " from PurchaseOrder po  Where  year(PO.ShipmentDate )>=2013"
            str &= " and PO.CustomerID in (13,19)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColor(ByVal StyleID As Long)
            Dim str As String
            str = " select distinct Colorway from StyleDetail where  StyleID='" & StyleID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPo()
            Dim str As String
            str = " select * from PurchaseOrder "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingDeptForComparsionReport()
            Dim str As String
            str = " select distinct EKNumber from PurchaseOrder"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindCombo() As DataTable
            Dim str As String
            str = "select CustomerID,CustomerName from Customer where isactive='1' order by CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingDeptForComparsionReportNew(ByVal CustomerID As Long)
            Dim str As String
            str = " select distinct EKNumber from PurchaseOrder where CustomerID='" & CustomerID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getStyleID(ByVal POID As Long)
            Dim str As String
            str = " select * from PurchaseOrderDetail where POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOIDOnPoNo(ByVal PONO As String)
            Dim str As String
            str = " select * from PurchaseOrder  where PONO='" & PONO & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function shippedAldi()
            Dim str As String
            str = " select 'Shipped' as Name,  Count (distinct cd.poPOID) as value from Cargodetail cd"
            str &= " join purchaseorder po on po.poid=cd.popoid"
            str &= "   where Year(po.ShipmentDate) >= 2013"
            str &= " and PO.CustomerID in (13,19)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function shipped(ByVal id As Long, ByVal Type As String)
            Dim str As String
            str = " select 'Shipped' as Name,  Count (distinct cd.poPOID) as value from Cargodetail cd"
            str &= " join purchaseorder po on po.poid=cd.popoid"
            str &= "   where Year(po.ShipmentDate) >= 2013"
            If Type = "Supplier" Then
                str &= "and po.Supplierid ='" & id & "'"
            ElseIf Type = "Merchant" Then
                str &= "and po.MarchandID ='" & id & "'"
            ElseIf Type = "Customer" Then
                If id = 0 Then
                    str &= " and po.CustomerID in (33, 40) "
                Else
                    str &= " and po.CustomerID ='" & id & "'"
                End If
            Else
                'All
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ClaimedAldi()
            Dim str As String
            str &= " select 'Claim' as Name,  Count (PO.POID) as value from POClaim C "
            str &= " join PurchaseOrder po on po.POID=c.POID "
            str &= " where Year(PO.ShipmentDate) >= 2013 "
            str &= " and PO.CustomerID in (13,19)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Claimed(ByVal id As Long, ByVal Type As String)
            Dim str As String
            str &= " select 'Claim' as Name,  Count (PO.POID) as value from POClaim C "
            str &= " join PurchaseOrder po on po.POID=c.POID "
            str &= " where Year(PO.ShipmentDate) >= 2013 "
            If Type = "Supplier" Then
                str &= "and po.Supplierid ='" & id & "'"
            ElseIf Type = "Merchant" Then
                str &= "and po.MarchandID ='" & id & "'"
            ElseIf Type = "Customer" Then
                If id = 0 Then
                    str &= " and po.CustomerID in (33, 40) "
                Else
                    str &= " and po.CustomerID ='" & id & "'"
                End If
            Else
                'All
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMasterOrderForAldiOrders()
            Dim Str As String
            Str = "  Select PO.POID, C.Aliass as CustomerName,PO.EKNumber,"
            Str &= "  V.ShortName as VenderName ,"
            Str &= " IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,u.ECPDivistion , stuff(u.UserName,6,50,'..') as UserName, PO.Season,PO.Design as 'ProductPortfolio'"
            Str &= " ,stuff(PO.ProductCategories,5,40,'..')  as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as 'ProductGroup',PO.Composition as 'Composition',"
            Str &= "  stuff(PO.Quality,7,40,'..') as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination ,SM.name  as 'ShipmentMode',"
            Str &= "   Dt.Name as 'DeliveryType',po.PONO, "
            Str &= " isnull((Select Sum(POD.Quantity * POD.Rate) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POValue , isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD"
            Str &= " where POD.POID=PO.POID),0)as POQuantity ,PO.Toleranceindays as 'Tolerance',"
            Str &= "  CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate"
            Str &= "  ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate  "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= "  where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency"
            Str &= "  ,Convert(Varchar,PO.CreationDate,103) as CreationDate "
            Str &= "  from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "  join UMUser U on u.UserId =po.MarchandID"
            Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= "  where Year(Po.ShipmentDate) >= 2013"
            Str &= " and PO.CustomerID in (13,19)"
            Str &= " and PO.IsActive=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForSMC(ByVal BuyerID As Long, ByVal VenderID As Long)
            Dim Str As String
            Str = " Select POID,PONO from PurchaseOrder"
            Str &= " Where CustomerID=" & BuyerID & " and SupplierID=" & VenderID & " "
            Str &= " and   year(ShipmentDate)>=2012  order by PONO asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSMCData(ByVal POID As Long)
            Dim Str As String

            Str = "   Select  'SMCID'='0',PO.CustomerID, po.SupplierID,PO.POID,POd.PODetailID,POD.StyleID ,POD.StyleDetailID  ,SM.StyleNo ,SD.Article "
            Str &= " ,SD.Colorway ,POD.Quantity ,POD.Rate as 'FOBPrice',CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate"
            Str &= " ,PO.Currency,  Cast ( (case when PO.Currency <> 'Dollar' then "
            Str &= " (Convert(Decimal,( (Isnull((POD.Quantity),0)*Isnull((POD.Rate),0))  ),0))*Isnull((PO.ExchangeRate),0)"
            Str &= " else"
            Str &= " (Convert(Decimal,( (Isnull((POD.Quantity),0)*Isnull((POD.Rate),0)) "
            Str &= " ),0)) end) as decimal (10,2)) as 'TurnoverUSD',"
            Str &= "  (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID) as"
            Str &= " ShipedQuantity ,PO.Toleranceindays,"
            Str &= " (POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100) as 'Lowest Limit'"
            Str &= " ,(POD.Quantity + (POD.Quantity*PO.Toleranceindays)/100) as 'Higher Limit'"
            Str &= " ,(Case when  (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)=0 then"
            Str &= "  'Open'  when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
            Str &= " < (POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100) then "
            Str &= " 'Shipped with shortfall'"
            Str &= "  when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
            Str &= " >=(POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100)"
            Str &= " and (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)<"
            Str &= " (POD.Quantity + (POD.Quantity*PO.Toleranceindays)/100)"
            Str &= " then  'Shipped'"
            Str &= " when (Select isnull(SUM(CPOD.Quantity),0)"
            Str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)="
            Str &= " (POD.Quantity + (POD.Quantity*PO.Toleranceindays)/100)"
            Str &= " then   'Shipped'  else    'Shipped with Excess'    end) as POStatus"
            Str &= " from PurchaseOrder PO "
            Str &= " Join PurchaseOrderDetail POD      On PO.POID=POD.POID"
            Str &= " Join StyleMaster SM on SM.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID     "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= "  where PO.POID =" & POID

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function POInfor(ByVal id As Long, ByVal Type As String)
            Dim str As String
            str = "  Select U.Username, Count(Po.POID) as TotalOrders "
            str &= " from PurchaseOrder Po "
            str &= " join Customer c on c.CustomerID =PO.CustomerID "
            str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            str &= "   join UMUser U on u.UserId =po.MarchandID"
            str &= "  where Year(Po.ShipmentDate) =" & Date.Now.Year
            If Type = "Supplier" Then
                str &= " and po.Supplierid ='" & id & "'"
            ElseIf Type = "Merchant" Then
                str &= " and po.MarchandID ='" & id & "'"
            ElseIf Type = "Customer" Then
                If id = 0 Then
                    str &= " and po.CustomerID in (33, 40) "
                Else
                    str &= " and po.CustomerID ='" & id & "'"
                End If
            Else
                'All
            End If

            str &= " group by U.UserName order by U.UserName ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentYearBookedOrders(ByVal CurrentYear As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select * "
            Str &= "   ,cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as QTY"
            Str &= " from   Purchaseorder PO where  year(PO.shipmentdate)= " & CurrentYear
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentYearOIHOrders(ByVal CurrentYear As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "   select * "
            Str &= "  ,cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as BookedQty"
            Str &= " ,cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0))as ShipedQty"
            Str &= " ,"
            Str &= " (Case when cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0)) >= cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0)) then "
            Str &= "  0"
            Str &= " else"
            Str &= " cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))"
            Str &= " -"
            Str &= " cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0))"
            Str &= " end) as OIH"
            Str &= " from   Purchaseorder PO where  year(PO.shipmentdate)= " & CurrentYear
            Str &= "  and Po.POID not in (Select Distinct POPOID from cargodetail) "
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentYearShippedOrders(ByVal CurrentYear As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select distinct CD.POPOID from cargo CR"
            Str &= " join Cargodetail CD on Cd.cargoid=Cr.cargoid"
            Str &= " join Purchaseorder po on po.POID=cd.popoid"
            Str &= "  where  year(PO.shipmentdate)= " & CurrentYear
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentMonthBookedOrders(ByVal CurrentYear As String, ByVal CurrentMonth As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select * "
            Str &= "   ,cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as QTY"
            Str &= " from   Purchaseorder PO where   month(PO.shipmentdate)= '" & CurrentMonth & "' and year(PO.shipmentdate)=" & CurrentYear
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentMonthCancelOrders(ByVal CurrentYear As String, ByVal CurrentMonth As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select * "
            Str &= "   ,cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as QTY"
            Str &= " from   Purchaseorder PO where PO.Status='Cancel' and month(PO.shipmentdate)= '" & CurrentMonth & "' and year(PO.shipmentdate)=" & CurrentYear
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentMonthOIHOrders(ByVal CurrentYear As String, ByVal CurrentMonth As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "   select * "
            Str &= "  ,cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as BookedQty"
            Str &= " ,cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0))as ShipedQty"
            Str &= " ,"
            Str &= " (Case when cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0)) >= cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0)) then"
            Str &= " 0 "
            Str &= " else"
            Str &= " cast ((Select isnull(SUM(POD.Quantity),0)   from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))"
            Str &= " -"
            Str &= " cast ((Select isnull(SUM(CD.Quantity),0)   from Cargodetail CD where CD.POPOID = PO.POID)as decimal (10,0))"
            Str &= " end) as OIH"
            Str &= " from   Purchaseorder PO where    month(PO.shipmentdate)= '" & CurrentMonth & "' and year(PO.shipmentdate)=" & CurrentYear
            Str &= "  and Po.POID not in (Select Distinct POPOID from cargodetail) "
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentMonthShippedOrders(ByVal CurrentYear As String, ByVal CurrentMonth As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select distinct CD.POPOID from cargo CR"
            Str &= " join Cargodetail CD on Cd.cargoid=Cr.cargoid"
            Str &= " join Purchaseorder po on po.POID=cd.popoid"
            Str &= " where Year(PO.shipmentdate) = '" & CurrentYear & "'"
            Str &= " and month(PO.shipmentdate)='" & CurrentMonth & "'"
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentYearShippedOrdersSUM(ByVal CurrentYear As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select sum(isnull(CD.Quantity,0))as ShipedQuantity from cargo CR"
            Str &= " join Cargodetail CD on Cd.cargoid=Cr.cargoid"
            Str &= " join Purchaseorder po on po.POID=cd.popoid"
            Str &= "  where Year(PO.shipmentdate) = " & CurrentYear
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function BindCurrentMonthShippedOrdersSUM(ByVal CurrentYear As String, ByVal CurrentMonth As String, ByVal UserID As String, ByVal RoleID As String) As DataTable
            Dim Str As String
            Str = "  select isnull(sum(CD.Quantity),0) as ShipedQuantity from cargo CR"
            Str &= " join Cargodetail CD on Cd.cargoid=Cr.cargoid"
            Str &= " join Purchaseorder po on po.POID=cd.popoid"
            Str &= " where Year(PO.shipmentdate) = '" & CurrentYear & "'"
            Str &= " and month(PO.shipmentdate)='" & CurrentMonth & "'"
            If RoleID = 13 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 14 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 15 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 16 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            ElseIf RoleID = 17 Then
                Str &= " and po.MarchandID ='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtECPReportData(ByVal ECPDivision As String, ByVal ProductGroup As String, ByVal ProductCategories As String)
            Dim Str As String
            Str &= " select distinct PO.CustomerID  , U.ECPDivistion ,C.CustomerName ,C.Commission  "
            Str &= " from PurchaseOrder PO join"
            Str &= " UMUser U on U.UserId =PO.MarchandID join Customer C on c.CustomerID =PO.CustomerID  "
            Str &= " where Year(PO.creationDate) >= 2012 "
            Str &= "  and ECPDivistion ='" & ECPDivision & "' and"
            Str &= "  ProductGroup ='" & ProductGroup & "' and ProductCategories ='" & ProductCategories & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMgtECPReportDataAll(ByVal ECPDivision As String)
            Dim Str As String
            Str &= " select distinct PO.CustomerID  , U.ECPDivistion ,C.CustomerName ,C.Commission  "
            Str &= " from PurchaseOrder PO join"
            Str &= " UMUser U on U.UserId =PO.MarchandID join Customer C on c.CustomerID =PO.CustomerID  "
            Str &= " where Year(PO.creationDate) >= 2012 "
            Str &= "  and ECPDivistion ='" & ECPDivision & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterOrderForPDM(ByVal IUserid As Long)
            Dim Str As String
            Str = "  select PO.POID, C.CustomerName as CustomerName,PO.EKNumber, V.VenderName "
            Str &= " as VenderName ,IsNull((Select LKZNumber From SupplierLKZ lkz Where lkz.SupplierID=v.VenderLibraryID "
            Str &= " and lkz.CustomerID=c.CustomerID),0)   as 'LKZ'"
            Str &= " ,PO.Season ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,"
            Str &= " por.Name as ShipmentMode "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo ,po.PONO,"
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID) as ItemQty,"
            Str &= " IsNull((Select Sum(QDI.InspectedQty) From QDInspection QDI Where QDI.POID=PO.POID"
            Str &= " and QDi.InspectionStatus='Final' and QDI.InspStatus='Pass'),0)as 'InspectedQty'"
            Str &= " ,IsNull((Select Sum(CD.Quantity) From CargoDetail CD Where CD.POPOID=PO.POID ),0)as 'ShippedQty'"
            Str &= " ,(Case when PO.Status='Cancel' then "
            Str &= " (Select Sum(Quantity) from Purchaseorderdetail POD where PO.POID=POD.POID)"
            Str &= "  else Cast('0' as DEcimal(10,0))  end) as 'POCancelQty', "
            Str &= "  (Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate  from PurchaseOrderReviseShipment PRS"
            Str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'LastRev' "
            Str &= " ,isnull((Select Top 1 wp.processName from WIPChart WC join WIPProcess WP"
            Str &= " on WP.WIPProcessID=WC.WIPProcessID where wc.POID=PO.POID order by wc.WIPChartId DESC),'--') as 'LastStatus'"
            Str &= " ,isNUll((Select Top 1 Convert(Varchar,WC.Creationdate,106) from WIPChart WC where wc.POID=PO.POID "
            Str &= " order by wc.WIPChartId DESC),'') as 'WIPLastDate'"
            Str &= " ,isNUll((Select Top 1 ('Article:'+ SD.Article +' Color: ' + SD.Colorway + ' Size: ' + SD.SizeRange + ' WIP: ' + wp.processName ) from WIPChart WC"
            Str &= " join WIPProcess WP  on WP.WIPProcessID=WC.WIPProcessID"
            Str &= "  join PurchaseorderDetail POD on POD.PODetailID=WC.PODetailID"
            Str &= "  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where wc.POID=PO.POID order by wc.WIPChartId DESC),'') as 'WIPLastDateToolTip'"
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= " join PORelatedFields por on por.ID = Po.ShipmentMode "
            Str &= " where "
            If IUserid = 28 Then
            ElseIf IUserid = 93 Then
            ElseIf IUserid = 87 Then
            ElseIf IUserid = 88 Then
            ElseIf IUserid = 89 Then
            ElseIf IUserid = 90 Then
            ElseIf IUserid = 22 Then
            ElseIf IUserid = 77 Then
            ElseIf IUserid = 63 Then
            Else
                Str &= " Po.marchandid =" & IUserid
                Str &= " and "
            End If
            Str &= " Year(PO.Shipmentdate) >=2013 "
            Str &= " and PO.Status <> 'Cancel' "
            Str &= " and PO.POID not in (Select distinct POPOID from Cargodetail)"
            Str &= " order by PO.POID DESC,C.Customername ASC, Po.Eknumber DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApproval()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID, C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype ,PO.timespame"
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Year(Po.Shipmentdate) >= 2013"
            Str &= " and PO.Status <> 'Cancel'"
            Str &= " and PO.POID not in (Select distinct POPOID from Cargodetail)"
            Str &= " and PO.POID not in (select distinct POID from CuttingApproval)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApprovalMail()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApprovalMailDistinctMerchant()
            Dim Str As String
            Str = "  Select Distinct Po.MarchandID "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApprovalMailMerchant(ByVal MarchandID As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Str &= " po.MarchandID=" & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApprovalMailDistinctSupplier()
            Dim Str As String
            Str = "  Select Distinct Po.SupplierID,V.Vendername "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForCuttingApprovalMailSupplier(ByVal SupplierID As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Str &= " Po.SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForInlineIspectionMail()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " left join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where Day(CA.CreationDate) =" & Date.Now.Day
            Str &= " And Month(CA.CreationDate) =" & Date.Now.Month
            Str &= " And Year(CA.CreationDate) =" & Date.Now.Year
            Str &= " and PO.POID  not in (Select Distinct POID from QDInspection where inspectionstatus='1st Inline') "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataFor2ndInlineIspectionMail()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " left join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where PO.POID in (Select Distinct POID from QDInspection QDI where inspectionstatus='1st Inline'"
            Str &= " and Day(QDI.CreationDate) =" & Date.Now.Day
            Str &= " And Month(QDI.CreationDate) =" & Date.Now.Month
            Str &= " And Year(QDI.CreationDate) =" & Date.Now.Year
            Str &= " ) and PO.POID not in (Select Distinct POPOID from cargodetail ) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataFor2ndInlineIspectionMailDistinctSupplier()
            Dim Str As String
            Str = "  Select Distinct po.SupplierID, V.VenderName"

            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " left join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where PO.POID in (Select Distinct POID from QDInspection QDI where inspectionstatus='1st Inline'"
            Str &= " and Day(QDI.CreationDate) =" & Date.Now.Day
            Str &= " And Month(QDI.CreationDate) =" & Date.Now.Month
            Str &= " And Year(QDI.CreationDate) =" & Date.Now.Year
            Str &= " ) and PO.POID not in (Select Distinct POPOID from cargodetail ) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataFor2ndInlineIspectionMailSupplier(ByVal SupplierID As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " left join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where PO.POID in (Select Distinct POID from QDInspection QDI where inspectionstatus='1st Inline'"
            Str &= " and Day(QDI.CreationDate) =" & Date.Now.Day
            Str &= " And Month(QDI.CreationDate) =" & Date.Now.Month
            Str &= " And Year(QDI.CreationDate) =" & Date.Now.Year
            Str &= " ) and PO.POID not in (Select Distinct POPOID from cargodetail ) "
            Str &= " and po.SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendFinalInspectionPlanning()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " left join CuttingApproval CA on CA.POID=PO.POID "
            Str &= " where PO.POID in (Select Distinct POID from QDInspection QDI where inspectionstatus='2nd Inline'"
            Str &= " and Day(QDI.CreationDate) =" & Date.Now.Day
            Str &= " And Month(QDI.CreationDate) =" & Date.Now.Month
            Str &= " And Year(QDI.CreationDate) =" & Date.Now.Year
            Str &= " ) and PO.POID not in (Select Distinct POPOID from cargodetail ) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendCloseOrders()
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =Po.MarchandID "
            Str &= " where Day(PO.CreationDate) =" & Date.Now.Day
            Str &= " And Month(PO.CreationDate) =" & Date.Now.Month
            Str &= " And Year(PO.CreationDate) =" & Date.Now.Year
            Str &= " and PO.Status='Close' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendCloseOrdersDistinctMerchant()
            Dim Str As String
            Str = "  Select distinct Po.MarchandID, U.UserName "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =Po.MarchandID "
            Str &= " where Day(PO.CreationDate) =" & Date.Now.Day
            Str &= " And Month(PO.CreationDate) =" & Date.Now.Month
            Str &= " And Year(PO.CreationDate) =" & Date.Now.Year
            Str &= " and PO.Status='Close' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SendCloseOrdersForMarchant(ByVal MarchandID As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID , C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype,PO.timespame "
            Str &= " ,(Select Top 1 SM.StyleNo from Purchaseorderdetail POD"
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID order by POD.PoDetailID DESC) as StyleNo"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =Po.MarchandID "
            Str &= " where Day(PO.CreationDate) =" & Date.Now.Day
            Str &= " And Month(PO.CreationDate) =" & Date.Now.Month
            Str &= " And Year(PO.CreationDate) =" & Date.Now.Year
            Str &= " and PO.Status='Close' "
            Str &= " and Po.MarchandID=" & MarchandID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNedRevisdShip()
            Dim Str As String
            Str = " select * from Purchaseorder where poid not in"
            Str &= " (select distinct POID  from PurchaseOrderReviseShipment)"
            Str &= " and year(shipmentdate)>= 2013"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNedRevisdShipFromTest(ByVal POID As Long)
            Dim Str As String
            Str = " select top 1 * from [Testt].[dbo].[PurchaseOrderReviseShipment] where poid=" & POID
            Str &= "  order by POReviseshipmentid DESC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStatus(ByVal POID As Long)
            Dim Str As String
            Str = " Select Status from Purchaseorder where poid=" & POID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOInfo(ByVal POID As Long)
            Dim Str As String
            Str = " Select *,Convert(Varchar,PO.ShipmentDate,103) as ShipmentDatee,"
            Str &= " (Select Top 1 SM.StyleNo from Purchaseorderdetail POD "
            Str &= " join StyleMaster SM on SM.StyleID=POD.StyleID where PO.POID=POD.POID )as StyleNo "
            Str &= " from PurchaseOrder Po"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID "
            Str &= " where Po.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerForRpt()
            Dim str As String
            str = "  select Distinct PO.CustomerID,C.CustomerName from  PURCHASEORDER PO join Customer C on C.CustomerID=PO.CustomerID Order by C.CustomerName  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonForRpt()
            Dim str As String
            str = "  select Distinct PO.Season from  PURCHASEORDER PO "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeptCustomerWise(ByVal CustomerId As Long)
            Dim str As String
            If CustomerId > 0 Then
                str = " select distinct EKNumber as BuyingDept from PURCHASEORDER where customerID='" & CustomerId & "' "
            Else
                str = " select distinct EKNumber as BuyingDept from PURCHASEORDER "
            End If

            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function GetPurchaseOrderForCancel(ByVal Vender As String, ByVal USerID As String, ByVal RoleID As Long, ByVal Team As String) As DataTable
            If RoleID = 1 Or RoleID = 4 Then
                RoleID = 1
            End If
            Dim Str As String
            Str = " Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate"
            Str &= " ,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate"
            Str &= " ,C.CustomerName as Customer,V.VenderName as vendor,"
            Str &= " cast((Select SUM(Isnull((POD.Quantity),0)) "
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID) as decimal (10,0)) as BookedQty"
            Str &= " , (Select SUM(Isnull((CD.Quantity),0)) "
            Str &= " from Cargodetail CD where CD.POPOID = PO.POID) as ShippedQty"
            Str &= " from PurchaseOrder PO "
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join  UMUser U on U.UserID=PO.MarchandID "
            Str &= " where PO.POID in"
            Str &= " (Select Distinct POPOID from Cargodetail Cd"
            Str &= " join Purchaseorder PO on PO.POID=cd.POPOID"
            Str &= "  where "
            Str &= " Isnull((Select SUM(Isnull((CD.Quantity),0)) "
            Str &= " from Cargodetail CD where CD.POPOID = PO.POID),0) < Isnull((Select SUM(Isnull((POD.Quantity),0)) "
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID),0) "
            Str &= "  -"
            Str &= " Isnull((Select SUM(Isnull((POC.Quantity),0))  from "
            Str &= " POCancelQuantity POC where POC.POID = PO.POID),0) )"
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            If RoleID = "1" Or USerID = "3" Or USerID = "35" Or USerID = "4" Or USerID = "5" Then
                If RoleID = "1" Or RoleID = "4" Then
                    'Then All 
                    If Team = "All" Then
                        'All 
                    ElseIf Team = "Chennai" Then
                        Str &= " and U.Team='Chennai'"
                    ElseIf Team = "Mumbai" Then
                        Str &= " and U.Team='Mumbai'"
                    End If
                Else
                    Str &= " and   U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & USerID & "')"
                End If
            Else
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= " order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPurchaseOrderForCancelNew(ByVal Vender As String, ByVal USerID As String) As DataTable

            Dim Str As String

            Str = " Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate"
            Str &= " ,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate"
            Str &= " ,C.CustomerName as Customer,V.VenderName as vendor,"
            Str &= " cast((Select SUM(Isnull((POD.Quantity),0)) "
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID) as decimal (10,0)) as BookedQty"
            Str &= " , (Select SUM(Isnull((CD.Quantity),0)) "
            Str &= " from Cargodetail CD where CD.POPOID = PO.POID) as ShippedQty"
            Str &= " from PurchaseOrder PO "
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join  UMUser U on U.UserID=PO.MarchandID "
            Str &= " where PO.POID in"
            Str &= " (Select Distinct POPOID from Cargodetail Cd"
            Str &= " join Purchaseorder PO on PO.POID=cd.POPOID"
            Str &= "  where "
            Str &= " Isnull((Select SUM(Isnull((CD.Quantity),0)) "
            Str &= " from Cargodetail CD where CD.POPOID = PO.POID),0) < Isnull((Select SUM(Isnull((POD.Quantity),0)) "
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID),0) "
            Str &= "  -"
            Str &= " Isnull((Select SUM(Isnull((POC.Quantity),0))  from "
            Str &= " POCancelQuantity POC where POC.POID = PO.POID),0) ) and PO.UserID='" & USerID & "'"
            If Not Vender = "ALL" Then
                Str &= " and PO.SupplierID='" & Vender & "'"
            End If
            Str &= " order by po.POID desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPoDataForCancelQTYNew(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select Sty.Article,Sty.StyleNo,Sty.Colorway,Sty.Size ,PO.POID, POD.PODetailID,PO.PONO,Convert(Varchar,PO.PlacementDate,106)as PlacementDate, "
            Str &= " Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate , C.CustomerName as Customer,V.VenderName as vendor"
            Str &= " , (Isnull((POD.Quantity),0))as BookedQTY ,(Isnull(POD.Quantity,0) * Isnull(POD.Rate,0)) as Amount "
            Str &= " ,cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)from  POCancelQuantity POC where POC.PODetailID = POD.PODetailID)as decimal (10,0))as CancelQTY "
            Str &= " ,cast ((Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from  CargoDetail CD where CD.POID = POD.PODetailID)as decimal (10,0))as ShippedQTY  ,"
            Str &= " (Isnull((POD.Quantity),0)) - cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)from  POCancelQuantity POC "
            Str &= " where POC.PODetailID = POD.PODetailID)as decimal (10,0)) - (Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from   CargoDetail CD "
            Str &= " where CD.POID = POD.PODetailID) as Differenc from Purchaseorder PO     "
            Str &= " Join PurchaseOrderDetail POD On PO.POID =POD.POID "
            Str &= " Join Style Sty on Sty.StyleID=POD.StyleID"
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID   "
            Str &= " Join  UMUser U on U.UserID=PO.MarchandID "
            Str &= "   where PO.Status = 'Confirmed' And PO.POID = '" & lPOID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPoDataForCancelQTYNeww(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = "  Select SD.cOLORrEFnO AS Article,Sty.StyleNo, SD.Colorway,SD.Sizes as Size ,PO.POID, POD.PODetailID,PO.PONO,"
            Str &= " Convert(Varchar,PO.PlacementDate,106)as PlacementDate,  Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate ,"
            Str &= " C.CustomerName as Customer,V.VenderName as vendor , (Isnull((POD.Quantity),0))as BookedQTY ,"
            Str &= " (Isnull(POD.Quantity,0) * Isnull(POD.Rate,0)) as Amount  ,cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)"
            Str &= " from  POCancelQuantity POC where POC.PODetailID = POD.PODetailID)as decimal (10,0))as CancelQTY  ,"
            Str &= " cast ((Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from  CargoDetail CD where CD.POID = POD.PODetailID)as decimal"
            Str &= " (10,0))as ShippedQTY  , (Isnull((POD.Quantity),0)) - cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)"
            Str &= " from  POCancelQuantity POC  where POC.PODetailID = POD.PODetailID)as decimal (10,0)) - (Select Isnull(SUM(Isnull((CD.Quantity),0)),0)"
            Str &= " from   CargoDetail CD  where CD.POID = POD.PODetailID) as Differenc from Purchaseorder PO     "
            Str &= " Join PurchaseOrderDetail POD On PO.POID =POD.POID Join StyleMaster Sty on Sty.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID Join Customer C on PO.CustomerID=C.CustomerID  "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID  Join  UMUser U on u.UserID=PO.MarchandID where PO.POID = '" & lPOID & "'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPoDataForInfoNew(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select  PO.POID, PO.PONO,Convert(Varchar,PO.PlacementDate,106)as PlacementDate, "
            Str &= " Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate , C.CustomerName as Customer,V.VenderName as vendor, "
            Str &= " cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)from  POCancelQuantity POC where POC.POID = PO.POID)as decimal (10,0))as CancelQTY ,"
            Str &= " cast ((Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from  CargoDetail CD where CD.POID = PO.POID)as decimal (10,0))as ShippedQTY  "
            Str &= " from Purchaseorder PO     "
            Str &= " Join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID   "
            Str &= " Join  UMUser U on U.UserID=PO.MarchandID "
            Str &= " Where PO.POID = '" & lPOID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function CheckTNA(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select * FROM TNAChart WHERE poid='" & lPOID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetInqInitial(ByVal InquiryPurpose As String, ByVal InQuiryType As String) As DataTable
            Dim Str As String
            Str = "  SELECT Distinct IQS.InquiryStyleID,StyleNo+'('+convert(varchar,RecvDate,112)+')' as StyleNo"
            Str &= " FROM InquiryStyle IQS "
            Str &= " Join InquiryStyleProductInformation ISP ON IQS.InquiryStyleID=ISP.InquiryStyleID"
            Str &= " Join TblInquiryConfirmed ISC ON ISC.InquiryStyleID=IQS.InquiryStyleID"
            Str &= " AND ISC.InquirySproductID=ISC.InquirySproductID where IQS.EnquiryPurpose='" & InquiryPurpose & "' and EnquiryType='" & InQuiryType & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetInqRepeat(ByVal InquiryPurpose As String, ByVal InQuiryType As String) As DataTable
            Dim Str As String
            Str = " SELECT Distinct GeneralInquiryMstID,StyleNo+'('+convert(varchar,InqRecvDate,112)+')' as StyleNo from "
            Str &= " GeneralInquiryMst where InquiryStatus='Approved' and  InquiryPurpose='" & InquiryPurpose & "' and InQuiryType='" & InQuiryType & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForShipRateNewforBOOKED(ByVal ETDStartDate As String, ByVal ETDEndDate As String, ByVal Currency As String)
            Dim str As String
            Try
                ' str = "   Select * from ShipExchangeRate  "
                ' str &= " where currency = '" & Currency & "' and MonthStartDate <= '" & ETDStartDate & "' and MonthendDate >= '" & ETDEndDate & "' "

                str = "   Select * from BookedExchangeRate  "
                str &= " where  Currency='" & Currency & "'  and ShipStartDate <= '" & ETDStartDate & "' and ShipendDate >= '" & ETDEndDate & "'"
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class ShipmentFormClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "Shipment"
        m_strPrimaryFieldName = "ShipmentID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lShipmentID As Long
    Private m_dtCreationDate As Date
    Private m_lUserID As Long
    Private m_lCargoID As Long
    Private m_strBuyer As String
    Private m_strCurrency As String
    Private m_dcInvoiceAmount As Decimal
    Private m_dtInvoiceDate As Date
    Private m_dtExFactoryDate As Date
    Private m_dcQty As Decimal
    Private m_strLCNO As String
    Private m_dtLCDate As Date
    Private m_lShipmentModeID As Long
    Private m_lShipmentTermID As Long
    Private m_strBankCode As String
    Private m_strFromENo As String
    Private m_dtFromEDate As Date
    Private m_strBLORAWB As String
    Private m_dtBLORAWBDate As Date
    Private m_strContainerNo As String
    Private m_strContainerSize As String
    Private m_dtETADestination As Date
    Private m_strClearingAgent As String
    Private m_strGDNo As String
    Private m_dtGDDate As Date
    Private m_strPaymentTerms As String
    Private m_dcPaymentDays As Decimal
    Private m_dtDocsSubmitIntoBankOn As Date
    Private m_strBankToBankDHLNo As String
    Private m_dtBankToBankDHLDate As Date
    Private m_strBuyerDHLNo As String
    Private m_dtBuyerDHLDate As Date
    Private m_strExpectedPayRcvDate As Date
    Private m_dtDiscrepacyMsgDate As Date
    Private m_dtTelexSendingDate As Date
    Private m_dtPayMaburityDate As Date
    Private m_dcAmountToBeRealized As Decimal
    Private m_dcExchangeRate As Decimal
    Private m_dcAmountInPKR As Decimal
    Private m_dcPurchaseAmount As Decimal
    Private m_dcPurchaseRate As Decimal
    Private m_dcPurchaseAmountPKR As Decimal
    Private m_dtPurchaseDate As Date
    Private m_dcBalRealizedAmount As Decimal
    Private m_dcRealizedRate As Decimal
    Private m_dcBalRealizedAmountPKR As Decimal
    Private m_dtRealizedDate As Date
    Private m_dcFBCharges As Decimal
    Private m_dcNetRealizedAmount As Decimal
    Private m_dcNetRealizedAmountPKR As Decimal
    Private m_strRemarks As String
    Private m_strStatus As Byte
    Public Property Status() As Boolean
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As Boolean)
            m_strStatus = value
        End Set
    End Property
    Public Property ShipmentID() As Long
        Get
            ShipmentID = m_lShipmentID
        End Get
        Set(ByVal value As Long)
            m_lShipmentID = value
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
    Public Property CargoID() As Long
        Get
            CargoID = m_lCargoID
        End Get
        Set(ByVal value As Long)
            m_lCargoID = value
        End Set
    End Property
    Public Property Buyer() As String
        Get
            Buyer = m_strBuyer
        End Get
        Set(ByVal value As String)
            m_strBuyer = value
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
    Public Property InvoiceAmount() As Decimal
        Get
            InvoiceAmount = m_dcInvoiceAmount
        End Get
        Set(ByVal value As Decimal)
            m_dcInvoiceAmount = value
        End Set
    End Property
    Public Property InvoiceDate() As Date
        Get
            InvoiceDate = m_dtInvoiceDate
        End Get
        Set(ByVal value As Date)
            m_dtInvoiceDate = value
        End Set
    End Property
    Public Property ExFactoryDate() As Date
        Get
            ExFactoryDate = m_dtExFactoryDate
        End Get
        Set(ByVal value As Date)
            m_dtExFactoryDate = value
        End Set
    End Property
    Public Property Qty() As Decimal
        Get
            Qty = m_dcQty
        End Get
        Set(ByVal value As Decimal)
            m_dcQty = value
        End Set
    End Property
    Public Property LCNO() As String
        Get
            LCNO = m_strLCNO
        End Get
        Set(ByVal value As String)
            m_strLCNO = value
        End Set
    End Property
    Public Property LCDate() As Date
        Get
            LCDate = m_dtLCDate
        End Get
        Set(ByVal value As Date)
            m_dtLCDate = value
        End Set
    End Property
    Public Property ShipmentModeID() As Long
        Get
            ShipmentModeID = m_lShipmentModeID
        End Get
        Set(ByVal value As Long)
            m_lShipmentModeID = value
        End Set
    End Property
    Public Property ShipmentTermID() As Long
        Get
            ShipmentTermID = m_lShipmentTermID
        End Get
        Set(ByVal value As Long)
            m_lShipmentTermID = value
        End Set
    End Property
    Public Property BankCode() As String
        Get
            BankCode = m_strBankCode
        End Get
        Set(ByVal value As String)
            m_strBankCode = value
        End Set
    End Property
    Public Property FromENo() As String
        Get
            FromENo = m_strFromENo
        End Get
        Set(ByVal value As String)
            m_strFromENo = value
        End Set
    End Property
    Public Property FromEDate() As Date
        Get
            FromEDate = m_dtFromEDate
        End Get
        Set(ByVal value As Date)
            m_dtFromEDate = value
        End Set
    End Property
    Public Property BLORAWB() As String
        Get
            BLORAWB = m_strBLORAWB
        End Get
        Set(ByVal value As String)
            m_strBLORAWB = value
        End Set
    End Property
    Public Property BLORAWBDate() As Date
        Get
            BLORAWBDate = m_dtBLORAWBDate
        End Get
        Set(ByVal value As Date)
            m_dtBLORAWBDate = value
        End Set
    End Property
    Public Property ContainerNo() As String
        Get
            ContainerNo = m_strContainerNo
        End Get
        Set(ByVal value As String)
            m_strContainerNo = value
        End Set
    End Property
    Public Property ContainerSize() As String
        Get
            ContainerSize = m_strContainerSize
        End Get
        Set(ByVal value As String)
            m_strContainerSize = value
        End Set
    End Property
    Public Property ETADestination() As Date
        Get
            ETADestination = m_dtETADestination
        End Get
        Set(ByVal value As Date)
            m_dtETADestination = value
        End Set
    End Property
    Public Property ClearingAgent() As String
        Get
            ClearingAgent = m_strClearingAgent
        End Get
        Set(ByVal value As String)
            m_strClearingAgent = value
        End Set
    End Property
    Public Property GDNo() As String
        Get
            GDNo = m_strGDNo
        End Get
        Set(ByVal value As String)
            m_strGDNo = value
        End Set
    End Property
    Public Property GDDate() As Date
        Get
            GDDate = m_dtGDDate
        End Get
        Set(ByVal value As Date)
            m_dtGDDate = value
        End Set
    End Property
    Public Property PaymentTerms() As String
        Get
            PaymentTerms = m_strPaymentTerms
        End Get
        Set(ByVal value As String)
            m_strPaymentTerms = value
        End Set
    End Property
    Public Property BankToBankDHLNo() As String
        Get
            BankToBankDHLNo = m_strBankToBankDHLNo
        End Get
        Set(ByVal value As String)
            m_strBankToBankDHLNo = value
        End Set
    End Property
    Public Property DocsSubmitIntoBankOn() As Date
        Get
            DocsSubmitIntoBankOn = m_dtDocsSubmitIntoBankOn
        End Get
        Set(ByVal value As Date)
            m_dtDocsSubmitIntoBankOn = value
        End Set
    End Property
    Public Property BankToBankDHLDate() As Date
        Get
            BankToBankDHLDate = m_dtBankToBankDHLDate
        End Get
        Set(ByVal value As Date)
            m_dtBankToBankDHLDate = value
        End Set
    End Property
    Public Property PaymentDays() As Decimal
        Get
            PaymentDays = m_dcPaymentDays
        End Get
        Set(ByVal value As Decimal)
            m_dcPaymentDays = value
        End Set
    End Property
    Public Property BuyerDHLNo() As String
        Get
            BuyerDHLNo = m_strBuyerDHLNo
        End Get
        Set(ByVal value As String)
            m_strBuyerDHLNo = value
        End Set
    End Property
    Public Property BuyerDHLDate() As Date
        Get
            BuyerDHLDate = m_dtBuyerDHLDate
        End Get
        Set(ByVal value As Date)
            m_dtBuyerDHLDate = value
        End Set
    End Property
    Public Property ExpectedPayRcvDate() As Date
        Get
            ExpectedPayRcvDate = m_strExpectedPayRcvDate
        End Get
        Set(ByVal value As Date)
            m_strExpectedPayRcvDate = value
        End Set
    End Property
    Public Property DiscrepacyMsgDate() As Date
        Get
            DiscrepacyMsgDate = m_dtDiscrepacyMsgDate
        End Get
        Set(ByVal value As Date)
            m_dtDiscrepacyMsgDate = value
        End Set
    End Property
    Public Property TelexSendingDate() As Date
        Get
            TelexSendingDate = m_dtTelexSendingDate
        End Get
        Set(ByVal value As Date)
            m_dtTelexSendingDate = value
        End Set
    End Property
    Public Property PayMaburityDate() As Date
        Get
            PayMaburityDate = m_dtPayMaburityDate
        End Get
        Set(ByVal value As Date)
            m_dtPayMaburityDate = value
        End Set
    End Property
    Public Property AmountToBeRealized() As Decimal
        Get
            AmountToBeRealized = m_dcAmountToBeRealized
        End Get
        Set(ByVal value As Decimal)
            m_dcAmountToBeRealized = value
        End Set
    End Property
    Public Property ExchangeRate() As Decimal
        Get
            ExchangeRate = m_dcExchangeRate
        End Get
        Set(ByVal value As Decimal)
            m_dcExchangeRate = value
        End Set
    End Property
    Public Property AmountInPKR() As Decimal
        Get
            AmountInPKR = m_dcAmountInPKR
        End Get
        Set(ByVal value As Decimal)
            m_dcAmountInPKR = value
        End Set
    End Property
    Public Property PurchaseAmount() As Decimal
        Get
            PurchaseAmount = m_dcPurchaseAmount
        End Get
        Set(ByVal value As Decimal)
            m_dcPurchaseAmount = value
        End Set
    End Property
    Public Property PurchaseRate() As Decimal
        Get
            PurchaseRate = m_dcPurchaseRate
        End Get
        Set(ByVal value As Decimal)
            m_dcPurchaseRate = value
        End Set
    End Property
    Public Property PurchaseAmountPKR() As Decimal
        Get
            PurchaseAmountPKR = m_dcPurchaseAmountPKR
        End Get
        Set(ByVal value As Decimal)
            m_dcPurchaseAmountPKR = value
        End Set
    End Property
    Public Property BalRealizedAmount() As Decimal
        Get
            BalRealizedAmount = m_dcBalRealizedAmount
        End Get
        Set(ByVal value As Decimal)
            m_dcBalRealizedAmount = value
        End Set
    End Property
    Public Property RealizedRate() As Decimal
        Get
            RealizedRate = m_dcRealizedRate
        End Get
        Set(ByVal value As Decimal)
            m_dcRealizedRate = value
        End Set
    End Property
    Public Property BalRealizedAmountPKR() As Decimal
        Get
            BalRealizedAmountPKR = m_dcBalRealizedAmountPKR
        End Get
        Set(ByVal value As Decimal)
            m_dcBalRealizedAmountPKR = value
        End Set
    End Property
    Public Property FBCharges() As Decimal
        Get
            FBCharges = m_dcFBCharges
        End Get
        Set(ByVal value As Decimal)
            m_dcFBCharges = value
        End Set
    End Property
    Public Property NetRealizedAmount() As Decimal
        Get
            NetRealizedAmount = m_dcNetRealizedAmount
        End Get
        Set(ByVal value As Decimal)
            m_dcNetRealizedAmount = value
        End Set
    End Property
    Public Property NetRealizedAmountPKR() As Decimal
        Get
            NetRealizedAmountPKR = m_dcNetRealizedAmountPKR
        End Get
        Set(ByVal value As Decimal)
            m_dcNetRealizedAmountPKR = value
        End Set
    End Property
    Public Property PurchaseDate() As Date
        Get
            PurchaseDate = m_dtPurchaseDate
        End Get
        Set(ByVal value As Date)
            m_dtPurchaseDate = value
        End Set
    End Property
    Public Property RealizedDate() As Date
        Get
            RealizedDate = m_dtRealizedDate
        End Get
        Set(ByVal value As Date)
            m_dtRealizedDate = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Remarks = m_strRemarks
        End Get
        Set(ByVal value As String)
            m_strRemarks = value
        End Set
    End Property
    Public Function SaveCargo()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
  Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception
        End Try
    End Function
    End Class

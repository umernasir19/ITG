Imports System.Data
Imports Microsoft.VisualBasic

Public Class SMC
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SMC"
        m_strPrimaryFieldName = "SMCID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lSMCID As Long
    Private m_lPOId As Long
    Private m_lPOdetailID As Long
    Private m_lStyleId As Long
    Private m_lStyleDetailID As Long
    Private m_dtCreationDate As Date
    Private m_strB2bStatus As String
    Private m_strSMCType As String
    Private m_dSMCDigit As Decimal
    Private m_dSMCUSD As Decimal
    Private m_lUserId As Long
    Private m_strPOStatus As String
    Private m_dTurnOverUSD As Decimal
    ''---------------- Properties
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal value As Long)
            m_lUserId = value
        End Set
    End Property
    Public Property SMCID() As Long
        Get
            SMCID = m_lSMCID
        End Get
        Set(ByVal value As Long)
            m_lSMCID = value
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
    Public Property POdetailID() As Long
        Get
            POdetailID = m_lPOdetailID
        End Get
        Set(ByVal value As Long)
            m_lPOdetailID = value
        End Set
    End Property
    Public Property StyleID() As Long
        Get
            StyleID = m_lStyleId
        End Get
        Set(ByVal value As Long)
            m_lStyleId = value
        End Set
    End Property
    Public Property StyleDetailID() As Long
        Get
            StyleDetailID = m_lStyleDetailID
        End Get
        Set(ByVal Value As Long)
            m_lStyleDetailID = Value
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
    Public Property B2bStatus() As String
        Get
            B2bStatus = m_strB2bStatus
        End Get
        Set(ByVal value As String)
            m_strB2bStatus = value
        End Set
    End Property
    Public Property SMCType() As String
        Get
            SMCType = m_strSMCType
        End Get
        Set(ByVal value As String)
            m_strSMCType = value
        End Set
    End Property
    Public Property SMCDigit() As Decimal
        Get
            SMCDigit = m_dSMCDigit
        End Get
        Set(ByVal Value As Decimal)
            m_dSMCDigit = Value
        End Set
    End Property

    Public Property SMCUSD() As Decimal
        Get
            SMCUSD = m_dSMCUSD
        End Get
        Set(ByVal Value As Decimal)
            m_dSMCUSD = Value
        End Set
    End Property
    Public Property POStatus() As String
        Get
            POStatus = m_strPOStatus
        End Get
        Set(ByVal value As String)
            m_strPOStatus = value
        End Set
    End Property
    Public Property TurnOverUSD() As Decimal
        Get
            TurnOverUSD = m_dTurnOverUSD
        End Get
        Set(ByVal Value As Decimal)
            m_dTurnOverUSD = Value
        End Set
    End Property
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function SaveSMC()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSMCForView()
        Dim Str As String
        'Str = "  select SMC.*,C.CustomerName ,V.VenderName ,PO.PONO ,SM.StyleNo ,SD.Article "
        'Str &= " ,SD.Colorway ,POD.Quantity ,POD.Rate as 'FOBPrice',"
        'Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate ,CONVERT(varchar(11),PO.PlacementDate ,103) as PlacementDate from SMC SMC"
        'Str &= " join  PurchaseOrder PO on PO.POID=SMC.POID"
        'Str &= " Join PurchaseOrderDetail POD  On POD.PODetailID =SMC.PODetailID"
        'Str &= " Join StyleMaster SM on SM.StyleID=SMC.StyleID "
        'Str &= " JOIN StyleDetail SD on SD.StyleDetailID=SMC.StyleDetailID     "
        'Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
        'Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
        Str = " select distinct SMC.POID,C.CustomerName ,V.VenderName ,PO.PONO  ,"
        Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate ,"
        Str &= " CONVERT(varchar(11),PO.PlacementDate ,103) as PlacementDate "
        Str &= " from  PurchaseOrder PO "
        Str &= " join  SMC SMC on PO.POID=SMC.POID"
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetSMCForEdit(ByVal POID As Long)
        Dim Str As String
        Str = "  select SMC.*,C.CustomerName ,V.VenderName ,PO.PONO ,SM.StyleNo ,SD.Article "
        Str &= " ,SD.Colorway ,POD.Quantity ,POD.Rate as 'FOBPrice',"
        Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate from SMC SMC"
        Str &= " join  PurchaseOrder PO on PO.POID=SMC.POID"
        Str &= " Join PurchaseOrderDetail POD  On POD.PODetailID =SMC.PODetailID"
        Str &= " Join StyleMaster SM on SM.StyleID=SMC.StyleID "
        Str &= " JOIN StyleDetail SD on SD.StyleDetailID=SMC.StyleDetailID     "
        Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
        Str &= " Join Customer C on C.CustomerID=PO.CustomerID where SMC.POID=" & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function chkPOID(ByVal POID As Long)
        Dim Str As String
        Str = "  select  *  from SMC  where POID=" & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

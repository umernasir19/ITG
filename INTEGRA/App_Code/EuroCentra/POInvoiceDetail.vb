Imports System.Data.SqlClient
Imports System.Text

Public Class POInvoiceDetail
    
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POInvoiceDetail"
        m_strPrimaryFieldName = "PoInvoiceDetailId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
    End Sub
    Private m_lPoInvoiceDetailId As Long
    Private m_lPOInvoiceMasterID As Long
    Private m_strDeptDatabasename As String
    Private m_lItemId As String
    Private m_strQuality As String
    Private m_dQunatity As Decimal
    Private m_dWeight As Decimal
    Private m_dRate As Decimal
    Private m_dGrossAmount As Decimal
    Private m_dDiscPercent As Decimal
    Private m_dDiscAmount As Decimal
    Private m_dValExcloudSalesTax As Decimal
    Private m_dSalesTaxPercentage As Decimal
    Private m_dSalesTaxAmount As Decimal
    Private m_dNetAmount As Decimal
    Private m_lPODetailId As Long
    Private m_strAdditionalChargesAccountCode As String
    Private m_dAdditionalCharges As Decimal

    ''''''''''''
    'Properties'
    ''''''''''''
    Public Property PoInvoiceDetailId() As Long
        Get
            PoInvoiceDetailId = m_lPoInvoiceDetailId
        End Get
        Set(ByVal Value As Long)
            m_lPoInvoiceDetailId = Value
        End Set
    End Property

    Public Property POInvoiceMasterID() As Long
        Get
            POInvoiceMasterID = m_lPOInvoiceMasterID
        End Get
        Set(ByVal Value As Long)
            m_lPOInvoiceMasterID = Value
        End Set
    End Property
    Public Property DeptDatabasename() As String
        Get
            DeptDatabasename = m_strDeptDatabasename
        End Get
        Set(ByVal Value As String)
            m_strDeptDatabasename = Value
        End Set
    End Property

    Public Property ItemId() As Long
        Get
            ItemId = m_lItemId
        End Get
        Set(ByVal Value As Long)
            m_lItemId = Value
        End Set
    End Property
    Public Property Quality() As String
        Get
            Quality = m_strQuality
        End Get
        Set(ByVal Value As String)
            m_strQuality = Value
        End Set
    End Property

    Public Property Qunatity() As Decimal
        Get
            Qunatity = m_dQunatity
        End Get
        Set(ByVal Value As Decimal)
            m_dQunatity = Value
        End Set
    End Property
    Public Property Weight() As Decimal
        Get
            Weight = m_dWeight
        End Get
        Set(ByVal Value As Decimal)
            m_dWeight = Value
        End Set
    End Property
    Public Property Rate() As Decimal
        Get
            Rate = m_dRate
        End Get
        Set(ByVal Value As Decimal)
            m_dRate = Value
        End Set
    End Property
    Public Property GrossAmount() As Decimal
        Get
            GrossAmount = m_dGrossAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dGrossAmount = Value
        End Set
    End Property
    Public Property DiscPercent() As Decimal
        Get
            DiscPercent = m_dDiscPercent
        End Get
        Set(ByVal Value As Decimal)
            m_dDiscPercent = Value
        End Set
    End Property
    Public Property DiscAmount() As Decimal
        Get
            DiscAmount = m_dDiscAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dDiscAmount = Value
        End Set
    End Property
    Public Property ValExcloudSalesTax() As Decimal
        Get
            ValExcloudSalesTax = m_dValExcloudSalesTax
        End Get
        Set(ByVal Value As Decimal)
            m_dValExcloudSalesTax = Value
        End Set
    End Property
    Public Property SalesTaxPercentage() As Decimal
        Get
            SalesTaxPercentage = m_dSalesTaxPercentage
        End Get
        Set(ByVal Value As Decimal)
            m_dSalesTaxPercentage = Value
        End Set
    End Property
    Public Property SalesTaxAmount() As Decimal
        Get
            SalesTaxAmount = m_dSalesTaxAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dSalesTaxAmount = Value
        End Set
    End Property
    Public Property NetAmount() As Decimal
        Get
            NetAmount = m_dNetAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dNetAmount = Value
        End Set
    End Property

    Public Property PODetailId() As Long
        Get
            PODetailId = m_lPODetailId
        End Get
        Set(ByVal Value As Long)
            m_lPODetailId = Value
        End Set
    End Property

    Public Property AdditionalChargesAccountCode() As String
        Get
            AdditionalChargesAccountCode = m_strAdditionalChargesAccountCode
        End Get
        Set(ByVal Value As String)
            m_strAdditionalChargesAccountCode = Value
        End Set
    End Property

    Public Property AdditionalCharges() As Decimal
        Get
            AdditionalCharges = m_dAdditionalCharges
        End Get
        Set(ByVal Value As Decimal)
            m_dAdditionalCharges = Value
        End Set
    End Property

    Public Function SavePODetail()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function UpdateStatus(ByVal YarnCountId As Long, ByVal Supplierid As Long, ByVal JobOderId As Long)
        Dim Str As String
        'Str = " update IMSStoreReceivedDetail set InvoiceStatus='" & InvoiceStatus & "' where StoreReceivedDetailID='" & StoreReceivedDetailID & "'"

        Str = " update YarnIssuedtl  set InvoiceStatus=1 "
        Str &= " WHERE YarnDatabaseId='" & YarnCountId & "' and kNITTERiD='" & Supplierid & "' AND YarnIssueMstId in (select ym.YarnIssueMstId from YarnIssueMst YM where ym.JoborderId='" & JobOderId & "')"
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DeleteFrmLedger(ByVal Supplierid As Long, ByVal POInvoiceMstId As Long)
        Dim Str As String
        'Str = " update IMSStoreReceivedDetail set InvoiceStatus='" & InvoiceStatus & "' where StoreReceivedDetailID='" & StoreReceivedDetailID & "'"

        ' Str = " update YarnIssuedtl  set InvoiceStatus=1 "
        'Str &= " WHERE YarnDatabaseId='" & YarnCountId & "' and kNITTERiD='" & Supplierid & "' AND YarnIssueMstId in (select ym.YarnIssueMstId from YarnIssueMst YM where ym.JoborderId='" & JobOderId & "')"
        Str = " Delete SupplierLedger where POInvoiceMstId='" & POInvoiceMstId & "' and IMSSupplierid='" & Supplierid & "' "
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
End Class


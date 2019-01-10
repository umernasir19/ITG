Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Public Class POInvoiceMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POInvoiceMst"
        m_strPrimaryFieldName = "POInvoiceMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
    End Sub
    Private m_lPOInvoiceMstID As Long
    Private m_strTransactionNo As String
    Private m_strVoucherNo As String
    Private m_strSaleTaxInvoiceNo As String
    Private m_strSaleTaxType As String
    Private m_dtCreationDate As Date
    Private m_strGSTType As String
    Private m_dtBillDate As Date
    Private m_strSupplierRefNo As String
    Private m_strCompanySTNo As String
    Private m_strOtherRefNo As String
    Private m_strBuyerSTNo As String
    Private m_strCompanyCSTNo As String
    Private m_strCompanyPAN As String
    Private m_lAccountPayablePartyID As Long
    Private m_lSNO As Long
    '---User in PaymentVoucher
    Private m_dInvoiceNetAmount As Decimal
    Private m_dPaymentAmount As Decimal
    Private m_bPaymentBit As Boolean

    Private m_strLedgerAccountName As String
    Private m_strLedgerAccountCode As String
    Private m_strINVFrom As String
    Private m_bChkDate As Boolean

    Private m_strDescription As String
    Public Property Description() As String
        Get
            Description = m_strDescription
        End Get
        Set(ByVal Value As String)
            m_strDescription = Value
        End Set
    End Property

    Public Property ChkDate() As Boolean
        Get
            ChkDate = m_bChkDate
        End Get
        Set(ByVal Value As Boolean)
            m_bChkDate = Value
        End Set
    End Property
   
  

    Public Property POInvoiceMstID() As Long
        Get
            POInvoiceMstID = m_lPOInvoiceMstID
        End Get
        Set(ByVal Value As Long)
            m_lPOInvoiceMstID = Value
        End Set
    End Property
    Public Property TransactionNo() As String
        Get
            TransactionNo = m_strTransactionNo
        End Get
        Set(ByVal Value As String)
            m_strTransactionNo = Value
        End Set
    End Property
    Public Property VoucherNo() As String
        Get
            VoucherNo = m_strVoucherNo
        End Get
        Set(ByVal Value As String)
            m_strVoucherNo = Value
        End Set
    End Property
    Public Property SaleTaxInvoiceNo() As String
        Get
            SaleTaxInvoiceNo = m_strSaleTaxInvoiceNo
        End Get
        Set(ByVal value As String)
            m_strSaleTaxInvoiceNo = value
        End Set
    End Property
    Public Property SaleTaxType() As String
        Get
            SaleTaxType = m_strSaleTaxType
        End Get
        Set(ByVal value As String)
            m_strSaleTaxType = value
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
    Public Property GSTType() As String
        Get
            GSTType = m_strGSTType
        End Get
        Set(ByVal value As String)
            m_strGSTType = value
        End Set
    End Property
    Public Property BillDate() As Date
        Get
            BillDate = m_dtBillDate
        End Get
        Set(ByVal value As Date)
            m_dtBillDate = value
        End Set
    End Property
    Public Property SupplierRefNo() As String
        Get
            SupplierRefNo = m_strSupplierRefNo
        End Get
        Set(ByVal value As String)
            m_strSupplierRefNo = value
        End Set
    End Property
    Public Property CompanySTNo() As String
        Get
            CompanySTNo = m_strCompanySTNo
        End Get
        Set(ByVal value As String)
            m_strCompanySTNo = value
        End Set
    End Property
    Public Property OtherRefNo() As String
        Get
            OtherRefNo = m_strOtherRefNo
        End Get
        Set(ByVal value As String)
            m_strOtherRefNo = value
        End Set
    End Property
    Public Property BuyerSTNo() As String
        Get
            BuyerSTNo = m_strBuyerSTNo
        End Get
        Set(ByVal value As String)
            m_strBuyerSTNo = value
        End Set
    End Property
    Public Property CompanyCSTNo() As String
        Get
            CompanyCSTNo = m_strCompanyCSTNo
        End Get
        Set(ByVal value As String)
            m_strCompanyCSTNo = value
        End Set
    End Property
    Public Property CompanyPAN() As String
        Get
            CompanyPAN = m_strCompanyPAN
        End Get
        Set(ByVal value As String)
            m_strCompanyPAN = value
        End Set
    End Property
    Public Property AccountPayablePartyID() As Long
        Get
            AccountPayablePartyID = m_lAccountPayablePartyID
        End Get
        Set(ByVal Value As Long)
            m_lAccountPayablePartyID = Value
        End Set
    End Property
    Public Property SNO() As Long
        Get
            SNO = m_lSNO
        End Get
        Set(ByVal Value As Long)
            m_lSNO = Value
        End Set
    End Property
    '---User in PaymentVoucher
    Public Property InvoiceNetAmount() As Decimal
        Get
            InvoiceNetAmount = m_dInvoiceNetAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dInvoiceNetAmount = Value
        End Set
    End Property
    Public Property PaymentAmount() As Decimal
        Get
            PaymentAmount = m_dPaymentAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dPaymentAmount = Value
        End Set
    End Property
    Public Property PaymentBit() As Boolean
        Get
            PaymentBit = m_bPaymentBit
        End Get
        Set(ByVal Value As Boolean)
            m_bPaymentBit = Value
        End Set
    End Property
    Public Property LedgerAccountName() As String
        Get
            LedgerAccountName = m_strLedgerAccountName
        End Get
        Set(ByVal Value As String)
            m_strLedgerAccountName = Value
        End Set
    End Property
    Public Property LedgerAccountCode() As String
        Get
            LedgerAccountCode = m_strLedgerAccountCode
        End Get
        Set(ByVal Value As String)
            m_strLedgerAccountCode = Value
        End Set
    End Property
    Public Property INVFrom() As String
        Get
            INVFrom = m_strINVFrom
        End Get
        Set(ByVal Value As String)
            m_strINVFrom = Value
        End Set
    End Property
    Public Function SavePOInvoiceMst()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
   
    Public Function GetPOInvoiceforView()
        Dim Str As String
        'Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.BillDate,103) BillDatee from POInvoiceMaster PO  "


        Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,Sd.SupplierName as AccountPayable,"
        Str &= " convert(varchar,PO.BillDate,103) BillDatee,"
        Str &= " (select sum (netamount) from POInvoiceDtl POD WHERE POD.POInvoiceMstID= PO.POInvoiceMstID) AS AMOUNT   "
        Str &= " from POInvoiceMst PO join SupplierDatabase Sd on Sd.Supplierdatabaseid=PO.AccountPayablePartyID"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    
End Class




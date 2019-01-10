Imports Microsoft.VisualBasic
Imports System.Data

Public Class CrdDbNotePurchaseOrder
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CrdDbNotePurchaseOrder"
        m_strPrimaryFieldName = "CrdDbNotePOID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCrdDbNotePOID As Long
    Private m_dCDNoteNo As String
    Private m_dDatee As Date
    Private m_lNoteTypeID As Long
    Private m_strNoteType As String
    Private m_lSupplierID As Long
    Private m_strSupplier As String
    Private m_lInvoiceNoID As Long
    Private m_lInvNo As String
    Private m_dInvAmt As Decimal
    Private m_dAmount As Decimal

    Public Property CrdDbNotePOID() As Long
        Get
            CrdDbNotePOID = m_lCrdDbNotePOID
        End Get
        Set(ByVal Value As Long)
            m_lCrdDbNotePOID = Value
        End Set
    End Property

    Public Property CDNoteNo() As String
        Get
            CDNoteNo = m_dCDNoteNo
        End Get
        Set(ByVal Value As String)
            m_dCDNoteNo = Value
        End Set
    End Property
    Public Property Datee() As Date
        Get
            Datee = m_dDatee
        End Get
        Set(ByVal Value As Date)
            m_dDatee = Value
        End Set
    End Property
    Public Property NoteType() As String
        Get
            NoteType = m_strNoteType
        End Get
        Set(ByVal Value As String)
            m_strNoteType = Value
        End Set
    End Property

    Public Property Supplier() As String
        Get
            Supplier = m_strSupplier
        End Get
        Set(ByVal Value As String)
            m_strSupplier = Value
        End Set
    End Property


    Public Property InvAmt() As Decimal
        Get
            InvAmt = m_dInvAmt
        End Get
        Set(ByVal Value As Decimal)
            m_dInvAmt = Value
        End Set
    End Property
    Public Property InvoiceNoID() As Long
        Get
            InvoiceNoID = m_lInvoiceNoID
        End Get
        Set(ByVal Value As Long)
            m_lInvoiceNoID = Value
        End Set
    End Property
    Public Property SupplierID() As Long
        Get
            SupplierID = m_lSupplierID
        End Get
        Set(ByVal Value As Long)
            m_lSupplierID = Value
        End Set
    End Property
    Public Property NoteTypeID() As Long
        Get
            NoteTypeID = m_lNoteTypeID
        End Get
        Set(ByVal Value As Long)
            m_lNoteTypeID = Value
        End Set
    End Property


    Public Property InvNo() As String
        Get
            InvNo = m_lInvNo
        End Get
        Set(ByVal Value As String)
            m_lInvNo = Value
        End Set
    End Property
    Public Property Amount() As Decimal
        Get
            Amount = m_dAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dAmount = Value
        End Set
    End Property
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function SaveCDNotePO()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSupplier() As DataTable
        Dim str As String
        str = "  select distinct Ims.SupplierDatabaseId ,ims.SupplierName "
        str &= "  from POInvoiceMst ti "
        str &= "  join SupplierDatabase ims on ims.SupplierDatabaseId =ti.AccountPayablePartyID   order by ims.SupplierName "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSupplierNew() As DataTable
        Dim str As String
        str = "  select distinct Ims.SupplierDatabaseId ,ims.SupplierName "
        str &= "  from POInvoiceMst ti "
        str &= "  join SupplierDatabase ims on ims.SupplierDatabaseId =ti.POInvoiceMstID   order by ims.SupplierName "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetView() As DataTable
        Dim str As String
        str = " select  CONVERT (varchar, Datee ,103)as PODate,* from CrdDbNotePurchaseOrder "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetLastNoteNo(ByVal year As Integer)
        Dim str As String
        ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
        str = " select Top 1 CDNoteNo from CrdDbNotePurchaseOrder where year(Datee)='" & year & "' order By CrdDbNotePOID DESC"
        ' str = " select VoucherNo from tblBankMst where substring(VoucherNo,11,20)=" & lastNo & " and  month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceNo(ByVal IMSSupplierId As Long) As DataTable
        Dim str As String
        'str = " select * from tblPurchaseInvoiceMst im "
        ' str &= " join IMSSupplier cm on cm.IMSSupplierId =im .IMSSupplierId  where im.IMSSupplierId ='" & IMSSupplierId & "'"

        str = " select * from POInvoiceMst ti "
        str &= " join SupplierDatabase ims on ims.SupplierDatabaseId =ti.AccountPayablePartyID"
        str &= " WHERE ti.AccountPayablePartyID='" & IMSSupplierId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceNoNew(ByVal IMSSupplierId As Long) As DataTable
        Dim str As String
        'str = " select * from tblPurchaseInvoiceMst im "
        ' str &= " join IMSSupplier cm on cm.IMSSupplierId =im .IMSSupplierId  where im.IMSSupplierId ='" & IMSSupplierId & "'"

        str = " select * from POInvoiceMst ti "
        str &= " join SupplierDatabase ims on ims.SupplierDatabaseId =ti.POInvoiceMstID"
        str &= " WHERE ti.POInvoiceMstID='" & IMSSupplierId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetItems(ByVal PurchaseInvoiceMstId As Long) As DataTable
        Dim str As String

        'str = " select distinct it .ItemName ,it.IMSItemID,* from tblPurchaseInvoiceMst ind"
        'str &= " join TblPurchaseInvoiceDtl TID on TID.PurchaseInvoiceMstId=ind.PurchaseInvoiceMstId "
        'str &= " join IMSItem it on it.IMSItemID =TID.IMSItemID "
        'str &= " where ind.PurchaseInvoiceMstId ='" & PurchaseInvoiceMstId & "'"

        str = " select distinct it .ItemName ,it.ItemID,* from POInvoiceMst ind "
        str &= " join POInvoiceDtl TID on TID.POInvoiceMstId=ind.POInvoiceMstId  "
        str &= " join itemproduct it on it.ItemID =TID.ItemID  where ind.POInvoiceMstId ='" & PurchaseInvoiceMstId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceDetail(ByVal PurchaseInvoiceMstId As Long) As DataTable
        Dim str As String
        'str = " Select  distinct i.IMSItemID ,i.ItemName , ti.InvoiceAmount,* from tblInvoiceMst ti "
        'str &= " join TblInvoiceDtl td on td.InvoiceMstId =ti .InvoiceMstId join IMSItem i on i.IMSItemID=td.IMSItemID "
        'str &= " where  ti.InvoiceMstId ='" & InvoiceMstId & "'"
        'str = " Select Distinct td .IMSItemID ,i.ItemName , ti.InvoiceAmount,0  as CDNotePODtlID from tblPurchaseInvoiceMst ti"
        'str &= " join TblPurchaseInvoiceDtl td on td.PurchaseInvoiceMstId =ti .PurchaseInvoiceMstId "
        'str &= " join IMSItem i on i.IMSItemID=td.IMSItemID "
        'str &= " where  ti.PurchaseInvoiceMstId ='" & PurchaseInvoiceMstId & "'"

        str = " Select Distinct td .ItemID ,i.ItemName , ti.InvoiceNetAmount as InvoiceAmount,0  as CDNotePODtlID from POInvoiceMst ti"
        str &= " join POInvoiceDtl td on td.POInvoiceMstId =ti .POInvoiceMstId  "
        str &= " join itemproduct i on i.ItemID=td.ItemID  where  ti.POInvoiceMstId ='" & PurchaseInvoiceMstId & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceDetailNew(ByVal PurchaseInvoiceMstId As Long) As DataTable
        Dim str As String
        str = " Select Distinct td .ItemID ,i.ItemName , ti.InvoiceNetAmount as InvoiceAmount,0  as CDNotePODtlID from POInvoiceMst ti"
        str &= " join POInvoiceDtl td on td.POInvoiceMstId =ti .POInvoiceMstId  "
        str &= " join itemproduct i on i.ItemID=td.ItemID  where  ti.POInvoiceMstId ='" & PurchaseInvoiceMstId & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class

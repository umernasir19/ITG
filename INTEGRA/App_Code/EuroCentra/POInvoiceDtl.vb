Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Public Class POInvoiceDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POInvoiceDtl"
        m_strPrimaryFieldName = "POInvoiceDtlId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
    End Sub
    Private m_lPOInvoiceDtlId As Long
    Private m_lPOInvoiceMstID As Long
    Private m_lItemId As String
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
    Private m_lPORecvDetailTwoID As Long
    Private m_lPORecvMasterID As Long
    Private m_strINVFrom As String


    Private m_lTblYarnPurchaseContractDetailID As Long
    Private m_lYarnRecvDetailID As Long
    Private m_lYarnRecvmasterID As Long

    ''''''''''''
    'Properties'
    ''''''''''''
    Public Property POInvoiceDtlId() As Long
        Get
            POInvoiceDtlId = m_lPOInvoiceDtlId
        End Get
        Set(ByVal Value As Long)
            m_lPOInvoiceDtlId = Value
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
    Public Property ItemId() As Long
        Get
            ItemId = m_lItemId
        End Get
        Set(ByVal Value As Long)
            m_lItemId = Value
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
    Public Property PORecvDetailTwoID() As Long
        Get
            PORecvDetailTwoID = m_lPORecvDetailTwoID
        End Get
        Set(ByVal Value As Long)
            m_lPORecvDetailTwoID = Value
        End Set
    End Property
    Public Property PORecvMasterID() As Long
        Get
            PORecvMasterID = m_lPORecvMasterID
        End Get
        Set(ByVal Value As Long)
            m_lPORecvMasterID = Value
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
    Public Property TblYarnPurchaseContractDetailID() As Long
        Get
            TblYarnPurchaseContractDetailID = m_lTblYarnPurchaseContractDetailID
        End Get
        Set(ByVal Value As Long)
            m_lTblYarnPurchaseContractDetailID = Value
        End Set
    End Property
    Public Property YarnRecvDetailID() As Long
        Get
            YarnRecvDetailID = m_lYarnRecvDetailID
        End Get
        Set(ByVal Value As Long)
            m_lYarnRecvDetailID = Value
        End Set
    End Property
    Public Property YarnRecvmasterID() As Long
        Get
            YarnRecvmasterID = m_lYarnRecvmasterID
        End Get
        Set(ByVal Value As Long)
            m_lYarnRecvmasterID = Value
        End Set
    End Property
    Public Function SavePOInvoiceDtl()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetYarnRecvQUANTITY(ByVal PORecvDetailTwoID As Long) As DataTable
        Dim str As String
        str = "  SELECT isnull(sum(InvoiceQTY),0) as InvoiceQTY FROM PORecvDetail WHERE PORecvDetailID='" & PORecvDetailTwoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPOID(ByVal PONO As String)
        Dim Str As String

        Str = " select * from POMaster WHERE PONO='" & PONO & "'"

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetYarnPreviousQUANTITY(ByVal YarnRecvDetailID As Long) As DataTable
        Dim str As String
        str = " SELECT  SUM(qUNATITY) AS PREVOIUSSUM FROM  POInvoiceMst 	POM join POInvoiceDtl POD  "
        str &= " on POM.POInvoicemstid=POD.POInvoicemstid"
        str &= " WHERE POD.YarnRecvDetailID = '" & YarnRecvDetailID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPORecvQUANTITY(ByVal PORecvDetailTwoID As Long) As DataTable
        Dim str As String
        str = " SELECT * FROM PORecvDetailTwo WHERE PORecvDetailTwoID='" & PORecvDetailTwoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function

    Public Function GetPOPreviousQUANTITY(ByVal PORecvDetailTwoID As Long) As DataTable
        Dim str As String
        str = " SELECT  SUM(qUNATITY) AS PREVOIUSSUM FROM  POInvoiceMst 	POM join POInvoiceDtl POD  "
        str &= " on POM.POInvoicemstid=POD.POInvoicemstid"
        str &= " WHERE POD.PORecvDetailTwoID = '" & PORecvDetailTwoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function UPDATEInVOICEqTYNew(ByVal PORecvDetailID As Long, ByVal InvoiceQty As Decimal, ByVal INVFrom As String)
        Dim str As String
        If INVFrom = "PORECEIVE" Then
            str = "  update PORecvDetail set InvoiceQTY='" & InvoiceQty & "' where PORecvDetailID='" & PORecvDetailID & "'   "
        ElseIf INVFrom = "YARNRECEIVE" Then
            str = "  update YarnRecvDetail set InvoiceQTY='" & InvoiceQty & "' where YarnRecvDetailID='" & PORecvDetailID & "'   "
        Else

        End If

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function UPDATEInVOICEqTY(ByVal PORecvDetailTwoID As Long, ByVal InvoiceQty As Decimal)
        Dim str As String
        str = "  update PORecvDetailTwo set InvoiceQTY='" & InvoiceQty & "' where PORecvDetailTwoID='" & PORecvDetailTwoID & "'   "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetYarnQUANTITY(ByVal YarnRecvDetailID As Long) As DataTable
        Dim str As String
        str = " SELECT ReceivedNetWeightKg as RecvQuantity,InvoiceQTY FROM YarnRecvDetail WHERE YarnRecvDetailID='" & YarnRecvDetailID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPOQUANTITY(ByVal PORecvDetailTwoID As Long) As DataTable
        Dim str As String
        str = " SELECT * FROM PORecvDetail WHERE PORecvDetailID='" & PORecvDetailTwoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function UPDATEInVOICEStatus(ByVal PORecvDetailTwoID As Long)
        Dim str As String
        str = "  update PORecvDetailTwo set IsCompleted=1 where PORecvDetailTwoID='" & PORecvDetailTwoID & "'   "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function UPDATEInVOICEStatusNew(ByVal PORecvDetailTwoID As Long, ByVal INVFrom As String)
        Dim str As String
        If INVFrom = "PORECEIVE" Then
            str = "  update PORecvDetail set IsCompleted=1 where PORecvDetailID='" & PORecvDetailTwoID & "'   "
        ElseIf INVFrom = "YARNRECEIVE" Then
            str = "  update YarnRecvDetail set IsCompleted=1 where YarnRecvDetailID='" & PORecvDetailTwoID & "'   "
        Else

        End If


        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class



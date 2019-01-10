Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class StoreReceiptVoucherDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StoreReceiptVoucherDtl"
            m_strPrimaryFieldName = "StoreReceiptVoucherDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lStoreReceiptVoucherDtlID As Long
        Private m_lStorereceiptVoucherMstID As Long
        Private m_dtReceiptDate As Date
        Private m_strRollNumber As String
        Private m_strCodeNo As String
        Private m_strItemName As String
        Private m_lIMSItemID As Long
        Private m_strColor As String
        Private m_strDCNo As String
        Private m_strOrderNo As String
        Private m_strMills As String
        Private m_strParticulars As String

        Private m_dcFabricReceived As Decimal

        Private m_strBuyers As String
        Private m_strGRNNo As String
        Private m_strCartage As String
        Private m_strStatus As String

        Private m_dcSalesTax As Decimal
        Private m_dcAmount As Decimal
        Private m_strVehicleNo As String
        'Private m_strAccountCode As String
        Private m_lIMSItemClassID As Long
        Private m_lItemUnitId As Long
        Private m_lSupplierDatabaseId As Long
        Private m_dcRate As Decimal

      
        Public Property ReceiptDate() As Date
            Get
                ReceiptDate = m_dtReceiptDate
            End Get
            Set(ByVal value As Date)
                m_dtReceiptDate = value
            End Set
        End Property
        Public Property StoreReceiptVoucherDtlID() As Long
            Get
                StoreReceiptVoucherDtlID = m_lStoreReceiptVoucherDtlID
            End Get
            Set(ByVal value As Long)
                m_lStoreReceiptVoucherDtlID = value
            End Set
        End Property
        Public Property StoreReceiptVoucherMstID() As Long
            Get
                StoreReceiptVoucherMstID = m_lStorereceiptVoucherMstID
            End Get
            Set(ByVal value As Long)
                m_lStorereceiptVoucherMstID = value
            End Set
        End Property
        'Public Property AccountCode() As String
        '    Get
        '        AccountCode = m_strAccountCode
        '    End Get
        '    Set(ByVal value As String)
        '        m_strAccountCode = value
        '    End Set
        'End Property
        Public Property RollNumber() As String
            Get
                RollNumber = m_strRollNumber
            End Get
            Set(ByVal value As String)
                m_strRollNumber = value
            End Set
        End Property
        Public Property CodeNo() As String
            Get
                CodeNo = m_strCodeNo
            End Get
            Set(ByVal value As String)
                m_strCodeNo = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal value As String)
                m_strItemName = value
            End Set
        End Property
        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal value As Long)
                m_lIMSItemID = value
            End Set
        End Property
        Public Property ItemUnitId() As Long
            Get
                ItemUnitId = m_lItemUnitId
            End Get
            Set(ByVal value As Long)
                m_lItemUnitId = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dcRate
            End Get
            Set(ByVal value As Decimal)
                m_dcRate = value
            End Set
        End Property


        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Property DCNo() As String
            Get
                DCNo = m_strDCNo
            End Get
            Set(ByVal value As String)
                m_strDCNo = value
            End Set
        End Property
        Public Property OrderNo() As String
            Get
                OrderNo = m_strOrderNo
            End Get
            Set(ByVal value As String)
                m_strOrderNo = value
            End Set
        End Property
        Public Property Mills() As String
            Get
                Mills = m_strMills
            End Get
            Set(ByVal value As String)
                m_strMills = value
            End Set
        End Property
        Public Property Particulars() As String
            Get
                Particulars = m_strParticulars
            End Get
            Set(ByVal value As String)
                m_strParticulars = value
            End Set
        End Property

        Public Property FabricReceived() As Decimal
            Get
                FabricReceived = m_dcFabricReceived
            End Get
            Set(ByVal value As Decimal)
                m_dcFabricReceived = value
            End Set
        End Property

        Public Property Buyers() As String
            Get
                Buyers = m_strBuyers
            End Get
            Set(ByVal value As String)
                m_strBuyers = value
            End Set
        End Property
        Public Property GRNNo() As String
            Get
                GRNNo = m_strGRNNo
            End Get
            Set(ByVal value As String)
                m_strGRNNo = value
            End Set
        End Property
        Public Property Cartage() As String
            Get
                Cartage = m_strCartage
            End Get
            Set(ByVal value As String)
                m_strCartage = value
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

        Public Property SalesTax() As Decimal
            Get
                SalesTax = m_dcSalesTax
            End Get
            Set(ByVal value As Decimal)
                m_dcSalesTax = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dcAmount
            End Get
            Set(ByVal value As Decimal)
                m_dcAmount = value
            End Set
        End Property

        Public Property VehicleNo() As String
            Get
                VehicleNo = m_strVehicleNo
            End Get
            Set(ByVal value As String)
                m_strVehicleNo = value
            End Set
        End Property
        Public Property IMSItemClassID() As Long
            Get
                IMSItemClassID = m_lIMSItemClassID
            End Get
            Set(ByVal value As Long)
                m_lIMSItemClassID = value
            End Set
        End Property
        Public Property SupplierDatabaseId() As Long
            Get
                SupplierDatabaseId = m_lSupplierDatabaseId
            End Get
            Set(ByVal value As Long)
                m_lSupplierDatabaseId = value
            End Set
        End Property

        Public Function SaveStoreReceiptVoucherDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
   
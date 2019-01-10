Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class POProcessRecvDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "POProcessRecvDetail"
            m_strPrimaryFieldName = "POProcessRecvDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPOProcessRecvDetailID As Long
        Private m_lPOProcessRecvMasterID As Long
        Private m_lProcessOrderDtlID As Long
        Private m_dPOQuantity As Decimal
        Private m_dRecvQuantity As Decimal
        Private m_strVehicleNo As String
        Private m_lStoreLocationID As Long
        Private m_dtReceiveDate As Date
        Private m_strStyle As String
        Private m_dReturnQty As Decimal
        Private m_strLotNo As String
        Private m_dNoOfRoll As Decimal
        Private m_strIsCompleted As Byte
        Private m_dInvoiceQty As Decimal
        Private m_freshQty As Decimal
        Private m_BQualityQty As Decimal

        Public Property BQualityQty() As Decimal
            Get
                BQualityQty = m_BQualityQty
            End Get
            Set(ByVal value As Decimal)
                m_BQualityQty = value
            End Set
        End Property
        Public Property freshQty() As Decimal
            Get
                freshQty = m_freshQty
            End Get
            Set(ByVal value As Decimal)
                m_freshQty = value
            End Set
        End Property
        Public Property InvoiceQty() As Decimal
            Get
                InvoiceQty = m_dInvoiceQty
            End Get
            Set(ByVal value As Decimal)
                m_dInvoiceQty = value
            End Set
        End Property
        Public Property IsCompleted() As Boolean
            Get
                IsCompleted = m_strIsCompleted
            End Get
            Set(ByVal value As Boolean)
                m_strIsCompleted = value
            End Set
        End Property
        Public Property NoOfRoll() As Decimal
            Get
                NoOfRoll = m_dNoOfRoll
            End Get
            Set(ByVal value As Decimal)
                m_dNoOfRoll = value
            End Set
        End Property
        Public Property LotNo() As String
            Get
                LotNo = m_strLotNo
            End Get
            Set(ByVal value As String)
                m_strLotNo = value
            End Set
        End Property

        Public Property ReturnQty() As Decimal
            Get
                ReturnQty = m_dReturnQty
            End Get
            Set(ByVal value As Decimal)
                m_dReturnQty = value
            End Set
        End Property
        Public Property ReceiveDate() As Date
            Get
                ReceiveDate = m_dtReceiveDate
            End Get
            Set(ByVal Value As Date)
                m_dtReceiveDate = Value
            End Set
        End Property
        Public Property POProcessRecvDetailID() As Long
            Get
                POProcessRecvDetailID = m_lPOProcessRecvDetailID
            End Get
            Set(ByVal Value As Long)
                m_lPOProcessRecvDetailID = Value
            End Set
        End Property
        Public Property POProcessRecvMasterID() As Long
            Get
                POProcessRecvMasterID = m_lPOProcessRecvMasterID
            End Get
            Set(ByVal Value As Long)
                m_lPOProcessRecvMasterID = Value
            End Set
        End Property
        Public Property ProcessOrderDtlID() As Long
            Get
                ProcessOrderDtlID = m_lProcessOrderDtlID
            End Get
            Set(ByVal value As Long)
                m_lProcessOrderDtlID = value
            End Set
        End Property
        Public Property POQuantity() As Decimal
            Get
                POQuantity = m_dPOQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dPOQuantity = value
            End Set
        End Property
        Public Property RecvQuantity() As Decimal
            Get
                RecvQuantity = m_dRecvQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dRecvQuantity = value
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
        Public Property StoreLocationID() As Long
            Get
                StoreLocationID = m_lStoreLocationID
            End Get
            Set(ByVal value As Long)
                m_lStoreLocationID = value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property

        Public Function SavePORecvDetail()
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

    End Class
End Namespace

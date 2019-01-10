Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PORecvDetailHistory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PORecvDetailHistory"
            m_strPrimaryFieldName = "PORecvDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPORecvDetailID As Long
        Private m_lPORecvMasterID As Long
        Private m_lPODetailID As Long
        Private m_dPOQuantity As Decimal
        Private m_dRecvQuantity As Decimal
        Private m_strVehicleNo As String
        Private m_lStoreLocationID As Long
        Private m_dtReceiveDate As Date
        Private m_strStyle As String
        Private m_strIGPNo As String
        Private m_strPartyDCNo As String
        Private m_lSupplierID As Long
        Private m_dcBalance As Decimal

        Public Property ReceiveDate() As Date
            Get
                ReceiveDate = m_dtReceiveDate
            End Get
            Set(ByVal Value As Date)
                m_dtReceiveDate = Value
            End Set
        End Property
        Public Property PORecvDetailID() As Long
            Get
                PORecvDetailID = m_lPORecvDetailID
            End Get
            Set(ByVal Value As Long)
                m_lPORecvDetailID = Value
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
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
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
        Public Property IGPNo() As String
            Get
                IGPNo = m_strIGPNo
            End Get
            Set(ByVal Value As String)
                m_strIGPNo = Value
            End Set
        End Property
        Public Property PartyDCNo() As String
            Get
                PartyDCNo = m_strPartyDCNo
            End Get
            Set(ByVal Value As String)
                m_strPartyDCNo = Value
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
        Public Property Balance() As Decimal
            Get
                Balance = m_dcBalance
            End Get
            Set(ByVal Value As Decimal)
                m_dcBalance = Value
            End Set
        End Property

        Public Function SavePORecvDetailHistory()
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



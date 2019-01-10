Imports Microsoft.VisualBasic
Imports System.Data
Public Class ConsumptionEntryDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ConDtl"
        m_strPrimaryFieldName = "ConDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lConDtlID As Long
    Private m_lConMstID As Long
    Private m_lJoborderDetailID As Long
    Private m_dSrNo As String
    Private m_dStyle As String
    Private m_dStitchDate As Date
    Private m_dStitchFactories As String
     Private m_dQuantity As Decimal
    Private m_dEstCon As Decimal
    Private m_dOrderCon As Decimal
    Private m_dActCon As Decimal
    Private m_dFabricReqQty As Decimal
    Private m_dShippedQty As Decimal
    Private m_dBalanceQty As Decimal
    Private m_dPacking As Decimal
    Private m_dLength As Decimal
    Private m_dWidth As Decimal
    Private m_dHeight As Decimal
    Private m_dInspectionDate As String
    Private m_dColor As String
    Public Property Color() As String
        Get
            Color = m_dColor
        End Get
        Set(ByVal Value As String)
            m_dColor = Value
        End Set
    End Property
    Public Property InspectionDate() As String
        Get
            InspectionDate = m_dInspectionDate
        End Get
        Set(ByVal Value As String)
            m_dInspectionDate = Value
        End Set
    End Property
    Public Property ConDtlID() As Long
        Get
            ConDtlID = m_lConDtlID
        End Get
        Set(ByVal Value As Long)
            m_lConDtlID = Value
        End Set
    End Property
    Public Property ConMstID() As Long
        Get
            ConMstID = m_lConMstID
        End Get
        Set(ByVal Value As Long)
            m_lConMstID = Value
        End Set
    End Property
    Public Property JoborderDetailID() As Long
        Get
            JoborderDetailID = m_lJoborderDetailID
        End Get
        Set(ByVal Value As Long)
            m_lJoborderDetailID = Value
        End Set
    End Property
    Public Property SrNo() As String
        Get
            SrNo = m_dSrNo
        End Get
        Set(ByVal Value As String)
            m_dSrNo = Value
        End Set
    End Property
    Public Property Style() As String
        Get
            Style = m_dStyle
        End Get
        Set(ByVal Value As String)
            m_dStyle = Value
        End Set
    End Property

    Public Property StitchDate() As Date
        Get
            StitchDate = m_dStitchDate
        End Get
        Set(ByVal value As Date)
            m_dStitchDate = value
        End Set
    End Property
   
    Public Property StitchFactories() As String
        Get
            StitchFactories = m_dStitchFactories
        End Get
        Set(ByVal Value As String)
            m_dStitchFactories = Value
        End Set
    End Property
    Public Property ActCon() As Decimal
        Get
            ActCon = m_dActCon
        End Get
        Set(ByVal Value As Decimal)
            m_dActCon = Value
        End Set
    End Property
    Public Property FabricReqQty() As Decimal
        Get
            FabricReqQty = m_dFabricReqQty
        End Get
        Set(ByVal Value As Decimal)
            m_dFabricReqQty = Value
        End Set
    End Property
    Public Property ShippedQty() As Decimal
        Get
            ShippedQty = m_dShippedQty
        End Get
        Set(ByVal Value As Decimal)
            m_dShippedQty = Value
        End Set
    End Property
    Public Property BalanceQty() As Decimal
        Get
            BalanceQty = m_dBalanceQty
        End Get
        Set(ByVal Value As Decimal)
            m_dBalanceQty = Value
        End Set
    End Property

    Public Property Quantity() As Decimal
        Get
            Quantity = m_dQuantity
        End Get
        Set(ByVal Value As Decimal)
            m_dQuantity = Value
        End Set
    End Property
    Public Property EstCon() As Decimal
        Get
            EstCon = m_dEstCon
        End Get
        Set(ByVal Value As Decimal)
            m_dEstCon = Value
        End Set
    End Property
    Public Property OrderCon() As Decimal
        Get
            OrderCon = m_dOrderCon
        End Get
        Set(ByVal Value As Decimal)
            m_dOrderCon = Value
        End Set
    End Property
    Public Property Width() As Decimal
        Get
            Width = m_dWidth
        End Get
        Set(ByVal Value As Decimal)
            m_dWidth = Value
        End Set
    End Property
    Public Property Height() As Decimal
        Get
            Height = m_dHeight
        End Get
        Set(ByVal Value As Decimal)
            m_dHeight = Value
        End Set
    End Property
    Public Property Packing() As Decimal
        Get
            Packing = m_dPacking
        End Get
        Set(ByVal Value As Decimal)
            m_dPacking = Value
        End Set
    End Property
    Public Property Length() As Decimal
        Get
            Length = m_dLength
        End Get
        Set(ByVal Value As Decimal)
            m_dLength = Value
        End Set
    End Property
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

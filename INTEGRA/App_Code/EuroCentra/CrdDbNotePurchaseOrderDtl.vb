Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CrdDbNotePurchaseOrderDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CrdDbNotePurchaseOrderDtl"
            m_strPrimaryFieldName = "CDNotePODtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCDNotePODtlID As Long
        Private m_lCrdDbNotePOID As Long
        Private m_strItemName As String
        Private m_dQtyy As Decimal


        Private m_dRate As Decimal
        Private m_dAmount As Decimal
        Private m_dGstPer As String
        Private m_dGstAmount As Decimal

        Private m_dNetAmount As Decimal
        Private m_lItemID As Long
        Private m_dWHT As Decimal
        Private m_dWHTAXAmount As Decimal
        Private m_dUpdateStatus As Boolean
        Public Property CDNotePODtlID() As Long
            Get
                CDNotePODtlID = m_lCDNotePODtlID
            End Get
            Set(ByVal Value As Long)
                m_lCDNotePODtlID = Value
            End Set
        End Property
        Public Property CrdDbNotePOID() As Long
            Get
                CrdDbNotePOID = m_lCrdDbNotePOID
            End Get
            Set(ByVal Value As Long)
                m_lCrdDbNotePOID = Value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal Value As String)
                m_strItemName = Value
            End Set
        End Property
        Public Property Qtyy() As Decimal
            Get
                Qtyy = m_dQtyy
            End Get
            Set(ByVal Value As Decimal)
                m_dQtyy = Value
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
        Public Property Amount() As Decimal
            Get
                Amount = m_dAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dAmount = Value
            End Set
        End Property
        Public Property GstPer() As String
            Get
                GstPer = m_dGstPer
            End Get
            Set(ByVal Value As String)
                m_dGstPer = Value
            End Set
        End Property
        Public Property GstAmount() As Decimal
            Get
                GstAmount = m_dGstAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dGstAmount = Value
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
        Public Property ItemID() As Long
            Get
                ItemID = m_lItemID
            End Get
            Set(ByVal Value As Long)
                m_lItemID = Value
            End Set
        End Property
        Public Property WHT() As Decimal
            Get
                WHT = m_dWHT
            End Get
            Set(ByVal Value As Decimal)
                m_dWHT = Value
            End Set
        End Property
        Public Property WHTAXAmount() As Decimal
            Get
                WHTAXAmount = m_dWHTAXAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dWHTAXAmount = Value
            End Set
        End Property
        Public Property UpdateStatus() As Boolean
            Get
                UpdateStatus = m_dUpdateStatus
            End Get
            Set(ByVal Value As Boolean)
                m_dUpdateStatus = Value
            End Set
        End Property
        Public Function SaveCrdDbPODtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
Imports System.Data
Namespace EuroCentra
    Public Class DPWashRecvDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPWashRecvDtl"
            m_strPrimaryFieldName = "DPWashRecvDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPWashRecvDtlID As Long
        Private m_lDPWashRecvMstID As Long
        Private m_lWashTypeID As Long
        Private m_lDalID As Long
        Private m_lStyleID As Long
        Private m_strWashType As String
        Private m_strDalNo As String
        Private m_strStyle As String
        Private m_dQty As Decimal
        Private m_dReceiveQuantity As Decimal
        Private m_dReceivedQty As Decimal
        Private m_dRejectQty As Decimal
        Public Property RejectQty() As Decimal
            Get
                RejectQty = m_dRejectQty
            End Get
            Set(ByVal value As Decimal)
                m_dRejectQty = value
            End Set
        End Property
        Public Property DPWashRecvDtlID() As Long
            Get
                DPWashRecvDtlID = m_lDPWashRecvDtlID
            End Get
            Set(ByVal value As Long)
                m_lDPWashRecvDtlID = value
            End Set
        End Property
        Public Property DPWashRecvMstID() As Long
            Get
                DPWashRecvMstID = m_lDPWashRecvMstID
            End Get
            Set(ByVal value As Long)
                m_lDPWashRecvMstID = value
            End Set
        End Property
        Public Property WashTypeID() As Long
            Get
                WashTypeID = m_lWashTypeID
            End Get
            Set(ByVal value As Long)
                m_lWashTypeID = value
            End Set
        End Property
        Public Property DalID() As Long
            Get
                DalID = m_lDalID
            End Get
            Set(ByVal value As Long)
                m_lDalID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
            End Set
        End Property
        Public Property WashType() As String
            Get
                WashType = m_strWashType
            End Get
            Set(ByVal value As String)
                m_strWashType = value
            End Set
        End Property
        Public Property DalNo() As String
            Get
                DalNo = m_strDalNo
            End Get
            Set(ByVal value As String)
                m_strDalNo = value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property Qty() As Decimal
            Get
                Qty = m_dQty
            End Get
            Set(ByVal value As Decimal)
                m_dQty = value
            End Set
        End Property
        Public Property ReceiveQuantity() As Decimal
            Get
                ReceiveQuantity = m_dReceiveQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dReceiveQuantity = value
            End Set
        End Property
        Public Property ReceivedQty() As Decimal
            Get
                ReceivedQty = m_dReceivedQty
            End Get
            Set(ByVal value As Decimal)
                m_dReceivedQty = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
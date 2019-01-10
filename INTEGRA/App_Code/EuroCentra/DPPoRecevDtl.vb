Imports System.Data
Namespace EuroCentra
    Public Class DPPoRecevDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPPOReceiveDtl"
            m_strPrimaryFieldName = "POReceiveDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lPOReceiveDtlID As Long
        Private m_lPOReceiveMstID As Long
        Private m_lDPPOMstID As Long
        Private m_lDPFabricMstID As Long
        Private m_lDPPODtlID As Long
        Private m_dcPOReceivedQty As Decimal
        Private m_dcReceiveQty As Decimal
        Public Property POReceiveDtlID() As Long
            Get
                POReceiveDtlID = m_lPOReceiveDtlID
            End Get
            Set(ByVal value As Long)
                m_lPOReceiveDtlID = value
            End Set
        End Property
        Public Property POReceiveMstID() As Long
            Get
                POReceiveMstID = m_lPOReceiveMstID
            End Get
            Set(ByVal value As Long)
                m_lPOReceiveMstID = value
            End Set
        End Property
        Public Property DPPOMstID() As Long
            Get
                DPPOMstID = m_lDPPOMstID
            End Get
            Set(ByVal value As Long)
                m_lDPPOMstID = value
            End Set
        End Property
        Public Property DPPODtlID() As Long
            Get
                DPPODtlID = m_lDPPODtlID
            End Get
            Set(ByVal value As Long)
                m_lDPPODtlID = value
            End Set
        End Property
        Public Property DPFabricMstID() As Long
            Get
                DPFabricMstID = m_lDPFabricMstID
            End Get
            Set(ByVal value As Long)
                m_lDPFabricMstID = value
            End Set
        End Property

        Public Property POReceivedQty() As Decimal
            Get
                POReceivedQty = m_dcPOReceivedQty
            End Get
            Set(ByVal value As Decimal)
                m_dcPOReceivedQty = value
            End Set
        End Property
        Public Property ReceiveQty() As Decimal
            Get
                ReceiveQty = m_dcReceiveQty
            End Get
            Set(ByVal value As Decimal)
                m_dcReceiveQty = value
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



Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CostOtherHeadDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CostOtherHeadDtl"
            m_strPrimaryFieldName = "CostOtherHeadDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCostOtherHeadDtlID As Long
        Private m_lCostOtherHeadMstID As Long
        Private m_lCostAHeadId As Long
        Private m_lCostFracId As Long
        Private m_dcCost As Decimal
        Private m_dcAmount As Decimal
        Public Property CostOtherHeadDtlID() As Long
            Get
                CostOtherHeadDtlID = m_lCostOtherHeadDtlID
            End Get
            Set(ByVal Value As Long)
                m_lCostOtherHeadDtlID = Value
            End Set
        End Property
        Public Property CostOtherHeadMstID() As Long
            Get
                CostOtherHeadMstID = m_lCostOtherHeadMstID
            End Get
            Set(ByVal Value As Long)
                m_lCostOtherHeadMstID = Value
            End Set
        End Property
        Public Property CostAHeadId() As Long
            Get
                CostAHeadId = m_lCostAHeadId
            End Get
            Set(ByVal Value As Long)
                m_lCostAHeadId = Value
            End Set
        End Property

        Public Property CostFracId() As Long
            Get
                CostFracId = m_lCostFracId
            End Get
            Set(ByVal Value As Long)
                m_lCostFracId = Value
            End Set
        End Property
        Public Property Cost() As Decimal
            Get
                Cost = m_dcCost
            End Get
            Set(ByVal Value As Decimal)
                m_dcCost = Value
            End Set

        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dcAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dcAmount = Value
            End Set

        End Property
        Public Function SavecostheadDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

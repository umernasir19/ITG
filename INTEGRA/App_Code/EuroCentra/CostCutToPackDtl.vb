Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CostCutToPackDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CostCutToPackDtl"
            m_strPrimaryFieldName = "CostCutToPackDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCostCutToPackDtlID As Long
        Private m_lCostCutToPackMstID As Long
        Private m_lProductionOperationId As Long
        Private m_dcOperationRate As Decimal
        Private m_lOperationUnitId As Long
        Private m_dcQuantity As Decimal
        Private m_dcTotal As Decimal
        Public Property CostCutToPackDtlID() As Long
            Get
                CostCutToPackDtlID = m_lCostCutToPackDtlID
            End Get
            Set(ByVal Value As Long)
                m_lCostCutToPackDtlID = Value
            End Set
        End Property
        Public Property CostCutToPackMstID() As Long
            Get
                CostCutToPackMstID = m_lCostCutToPackMstID
            End Get
            Set(ByVal Value As Long)
                m_lCostCutToPackMstID = Value
            End Set
        End Property
        Public Property ProductionOperationId() As Long
            Get
                ProductionOperationId = m_lProductionOperationId
            End Get
            Set(ByVal Value As Long)
                m_lProductionOperationId = Value
            End Set
        End Property
        Public Property OperationRate() As Decimal
            Get
                OperationRate = m_dcOperationRate
            End Get
            Set(ByVal Value As Decimal)
                m_dcOperationRate = Value
            End Set
        End Property

        Public Property OperationUnitId() As Long
            Get
                OperationUnitId = m_lOperationUnitId
            End Get
            Set(ByVal Value As Long)
                m_lOperationUnitId = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_dcQuantity = Value
            End Set
        End Property
        Public Property Total() As Decimal
            Get
                Total = m_dcTotal
            End Get
            Set(ByVal Value As Decimal)
                m_dcTotal = Value
            End Set

        End Property

        Public Function Savecostcuttopack()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function



    End Class
End Namespace

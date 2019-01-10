Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabricationSheetDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricationSheetDtl"
            m_strPrimaryFieldName = "FabricationSheetDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricationSheetDtlID As Long
        Private m_lFabricationSheetMstID As Long
        Private m_strStyleNo As String
        Private m_strFabricCode As String
        Private m_strWash As String
        Private m_dOrderQty As Decimal
        Private m_dConsumption As Decimal
        Private m_dQtyInMtr As Decimal
        Private m_strSize As String
        Private m_strPercent As String
        Private m_lFabricIMSItemID As Long
        
        Public Property FabricationSheetDtlID() As Long
            Get
                FabricationSheetDtlID = m_lFabricationSheetDtlID
            End Get
            Set(ByVal value As Long)
                m_lFabricationSheetDtlID = value
            End Set
        End Property
        Public Property FabricationSheetMstID() As Long
            Get
                FabricationSheetMstID = m_lFabricationSheetMstID
            End Get
            Set(ByVal value As Long)
                m_lFabricationSheetMstID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property FabricCode() As String
            Get
                FabricCode = m_strFabricCode
            End Get
            Set(ByVal value As String)
                m_strFabricCode = value
            End Set
        End Property
        Public Property Wash() As String
            Get
                Wash = m_strWash
            End Get
            Set(ByVal value As String)
                m_strWash = value
            End Set
        End Property
        Public Property OrderQty() As Decimal
            Get
                OrderQty = m_dOrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dOrderQty = value
            End Set
        End Property
        Public Property Consumption() As Decimal
            Get
                Consumption = m_dConsumption
            End Get
            Set(ByVal value As Decimal)
                m_dConsumption = value
            End Set
        End Property
        Public Property QtyInMtr() As Decimal
            Get
                QtyInMtr = m_dQtyInMtr
            End Get
            Set(ByVal value As Decimal)
                m_dQtyInMtr = value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal value As String)
                m_strSize = value
            End Set
        End Property
        Public Property Percent() As String
            Get
                Percent = m_strPercent
            End Get
            Set(ByVal value As String)
                m_strPercent = value
            End Set
        End Property
        Public Property FabricIMSItemID() As Long
            Get
                FabricIMSItemID = m_lFabricIMSItemID
            End Get
            Set(ByVal value As Long)
                m_lFabricIMSItemID = value
            End Set
        End Property
        Public Function SaveFabricationSheetDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
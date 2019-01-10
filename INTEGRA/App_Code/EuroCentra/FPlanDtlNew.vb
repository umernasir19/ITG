﻿Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
Public Class FPlanDtlNew
 Inherits SQLManager
        Public Sub New()
            m_strTableName = "FPlanDtlNew"
            m_strPrimaryFieldName = "FPlanDtlNewID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFPlanDtlNewID As Long
        Private m_lFPlanMstNewID As Long
        Private m_lFabricdataBaseId As Long
        Private m_lFabricTypeId As Long
        Private m_strFabricType As String
        Private m_dcConsumption As Decimal
        Private m_dcFabricReq As Decimal
        Private m_dcGross As Decimal
        Private m_dcExtra As Decimal
        Private m_lIMSSupplierId As Long
        Private m_dcFabricCost As Decimal
        Private m_dcAmount As Decimal
        Private m_dcExchangeRate As Decimal
        Private m_dcUSD As Decimal
        Private m_dFabricMeter As Decimal

        Private m_dcQtyColorWise As Decimal
        Private m_strcolor As String
        Private m_lJobOrderDetailId As Long
        Private m_strStyle As String

        Private m_strItem As String
        Private m_lCurrencyId As Long
        Private m_strCurrency As String
        Private m_strFabricWidth As String
        Public Property FabricWidth() As String
            Get
                FabricWidth = m_strFabricWidth
            End Get
            Set(ByVal Value As String)
                m_strFabricWidth = Value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal Value As String)
                m_strCurrency = Value
            End Set
        End Property
        Public Property CurrencyId() As Long
            Get
                CurrencyId = m_lCurrencyId
            End Get
            Set(ByVal Value As Long)
                m_lCurrencyId = Value
            End Set
        End Property
        Public Property FPlanDtlNewID() As Long
            Get
                FPlanDtlNewID = m_lFPlanDtlNewID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanDtlNewID = Value
            End Set
        End Property
        Public Property FPlanMstNewID() As Long
            Get
                FPlanMstNewID = m_lFPlanMstNewID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanMstNewID = Value
            End Set
        End Property

        Public Property FabricdataBaseId() As Long
            Get
                FabricdataBaseId = m_lFabricdataBaseId
            End Get
            Set(ByVal Value As Long)
                m_lFabricdataBaseId = Value
            End Set
        End Property
        Public Property FabricTypeId() As Long
            Get
                FabricTypeId = m_lFabricTypeId
            End Get
            Set(ByVal Value As Long)
                m_lFabricTypeId = Value
            End Set
        End Property

        Public Property FabricType() As String
            Get
                FabricType = m_strFabricType
            End Get
            Set(ByVal Value As String)
                m_strFabricType = Value
            End Set
        End Property

        Public Property Consumption() As Decimal
            Get
                Consumption = m_dcConsumption
            End Get
            Set(ByVal Value As Decimal)
                m_dcConsumption = Value
            End Set
        End Property

        Public Property FabricReq() As Decimal
            Get
                FabricReq = m_dcFabricReq
            End Get
            Set(ByVal Value As Decimal)
                m_dcFabricReq = Value
            End Set
        End Property
        Public Property Extra() As Decimal
            Get
                Extra = m_dcExtra
            End Get
            Set(ByVal Value As Decimal)
                m_dcExtra = Value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal Value As String)
                m_strItem = Value
            End Set
        End Property
        Public Property Gross() As Decimal
            Get
                Gross = m_dcGross
            End Get
            Set(ByVal Value As Decimal)
                m_dcGross = Value
            End Set
        End Property
        Public Property IMSSupplierId() As Long
            Get
                IMSSupplierId = m_lIMSSupplierId
            End Get
            Set(ByVal Value As Long)
                m_lIMSSupplierId = Value
            End Set
        End Property
        Public Property FabricCost() As Decimal
            Get
                FabricCost = m_dcFabricCost
            End Get
            Set(ByVal Value As Decimal)
                m_dcFabricCost = Value
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
        Public Property ExchangeRate() As Decimal
            Get
                ExchangeRate = m_dcExchangeRate
            End Get
            Set(ByVal Value As Decimal)
                m_dcExchangeRate = Value
            End Set
        End Property
        Public Property USD() As Decimal
            Get
                USD = m_dcUSD
            End Get
            Set(ByVal Value As Decimal)
                m_dcUSD = Value
            End Set
        End Property
        Public Property FabricMeter() As Decimal
            Get
                FabricMeter = m_dFabricMeter
            End Get
            Set(ByVal Value As Decimal)
                m_dFabricMeter = Value
            End Set
        End Property
        Public Property QtyColorWise() As Decimal
            Get
                QtyColorWise = m_dcQtyColorWise
            End Get
            Set(ByVal Value As Decimal)
                m_dcQtyColorWise = Value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strcolor
            End Get
            Set(ByVal Value As String)
                m_strcolor = Value
            End Set
        End Property
        Public Property JobOrderDetailId() As Long
            Get
                JobOrderDetailId = m_lJobOrderDetailId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderDetailId = Value
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

        Public Function SaveFPlanDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetailFab(ByVal FPlanDtlNewID As Long)
            Dim str As String
            str = " delete FPlanDtlNew where  FPlanDtlNewID='" & FPlanDtlNewId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
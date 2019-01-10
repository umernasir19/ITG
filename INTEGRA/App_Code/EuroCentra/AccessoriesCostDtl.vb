Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class AccessoriesCostDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccessoriesCostDtl"
            m_strPrimaryFieldName = "AccessoriesCostDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccessoriesCostDtlID As Long
        Private m_lAccessoriesCostMstID As Long
        Private m_lAccessoriesId As Long
        Private m_DCConsumption As Decimal
        Private m_lItemUnitid As Long
        Private m_DCUnitCost As Decimal
        Private m_DCExtra As Decimal
        Private m_DCConQuantity As Decimal
        Private m_DCGross As Decimal
        Private m_DCGrossCost As Decimal
        Private m_DCCostPerUnit As Decimal
        Private m_lStyleId As Long
        Private m_strStyle As String
        Private m_strColor As String
        Private m_dcQtyColorWise As Decimal
        Private m_strAccessoriesType As String
        Private m_strAccessoriesTypeId As Long
        Public Property AccessoriesTypeId() As Long
            Get
                AccessoriesTypeId = m_strAccessoriesTypeId
            End Get
            Set(ByVal Value As Long)
                m_strAccessoriesTypeId = Value
            End Set
        End Property
        Public Property AccessoriesCostDtlID() As Long
            Get
                AccessoriesCostDtlID = m_lAccessoriesCostDtlID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesCostDtlID = Value
            End Set
        End Property
        Public Property AccessoriesCostMstID() As Long
            Get
                AccessoriesCostMstID = m_lAccessoriesCostMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesCostMstID = Value
            End Set
        End Property
        Public Property AccessoriesId() As Long
            Get
                AccessoriesId = m_lAccessoriesId
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesId = Value
            End Set
        End Property

        Public Property Consumption() As Decimal
            Get
                Consumption = m_DCConsumption
            End Get
            Set(ByVal Value As Decimal)
                m_DCConsumption = Value
            End Set
        End Property
        Public Property ItemUnitid() As Long
            Get
                ItemUnitid = m_lItemUnitid
            End Get
            Set(ByVal Value As Long)
                m_lItemUnitid = Value
            End Set
        End Property
        Public Property UnitCost() As Decimal
            Get
                UnitCost = m_DCUnitCost
            End Get
            Set(ByVal Value As Decimal)
                m_DCUnitCost = Value
            End Set
        End Property
        Public Property Extra() As Decimal
            Get
                Extra = m_DCExtra
            End Get
            Set(ByVal Value As Decimal)
                m_DCExtra = Value
            End Set
        End Property
        Public Property ConQuantity() As Decimal
            Get
                ConQuantity = m_DCConQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_DCConQuantity = Value
            End Set
        End Property
        Public Property Gross() As Decimal
            Get
                Gross = m_DCGross
            End Get
            Set(ByVal Value As Decimal)
                m_DCGross = Value
            End Set
        End Property
        Public Property GrossCost() As Decimal
            Get
                GrossCost = m_DCGrossCost
            End Get
            Set(ByVal Value As Decimal)
                m_DCGrossCost = Value
            End Set
        End Property
        Public Property CostPerUnit() As Decimal
            Get
                CostPerUnit = m_DCCostPerUnit
            End Get
            Set(ByVal Value As Decimal)
                m_DCCostPerUnit = Value
            End Set
        End Property
        Public Property StyleId() As Long
            Get
                StyleId = m_lStyleId
            End Get
            Set(ByVal Value As Long)
                m_lStyleId = Value
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
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal Value As String)
                m_strColor = Value
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
        Public Property AccessoriesType() As String
            Get
                AccessoriesType = m_strAccessoriesType
            End Get
            Set(ByVal Value As String)
                m_strAccessoriesType = Value
            End Set
        End Property

        Public Function SaveAcCostdtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByJobOrder(ByVal Joborderid As Long)
            Dim str As String
            str = " select distinct styleId,Style from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindColorStyleWise(ByVal Joborderid As Long)
            Dim str As String
            str = "  select distinct BuyerColor,styleId,Style,* from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindColorStyleWiseWithStyleId(ByVal Joborderid As Long, ByVal StyleId As Long)
            Dim str As String
            str = "  select distinct BuyerColor,styleId,Style,* from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' and StyleId='" & StyleId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindQtyStyleWiseALL(ByVal Joborderid As Long)
            Dim str As String
            ' str = " select distinct Quantity,styleId,Style,* from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' "
            str = " select distinct sum(Quantity) as Quantity from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindQtyStyleWise(ByVal Joborderid As Long, ByVal StyleId As Long)
            Dim str As String
            str = " select distinct Quantity,styleId,Style  from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' and styleId='" & StyleId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindQtyStyleWisee(ByVal Joborderid As Long, ByVal StyleId As Long)
            Dim str As String
            str = "  select distinct isnull(sum(Quantity),0) as Quantity,styleId,Style  from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' and styleId='" & StyleId & "' group by StyleID,Style "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindQtyStyleWiseNew(ByVal Joborderid As Long, ByVal BuyerColor As String)
            Dim str As String
            str = " select distinct Quantity,styleId,Style from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' and BuyerColor='" & BuyerColor & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindQtyStyleWiseALL(ByVal Joborderid As Long, ByVal StyleId As Long)
            Dim str As String
            str = " select distinct Quantity,styleId,Style from JobOrderdatabaseDetail where JobOrderId='" & Joborderid & "' and styleId='" & StyleId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal AccessoriesCostDtlID As Long)
            Dim str As String
            str = " delete  AccessoriesCostDtl where AccessoriesCostDtlID='" & AccessoriesCostDtlID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

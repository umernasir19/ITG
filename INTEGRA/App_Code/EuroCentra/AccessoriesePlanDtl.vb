Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class AccessoriesePlanDtl

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccessoriesePlanDtl"
            m_strPrimaryFieldName = "AccessoriesePlanDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lAccessoriesePlanDtlID As Long
        Private m_lAccessoriesePlanMstID As Long
        Private m_lAccessoriesID As Long
        Private m_strStyle As String
        Private m_dPercentage As Decimal
        Private m_dPerPcsAvg As Decimal
        Private m_dQty As Decimal
        Private m_strRemarks As String
        Private m_lUOMID As Long
        Private m_bAccReqStatus As Boolean


        Public Property AccessoriesePlanDtlID() As Long
            Get
                AccessoriesePlanDtlID = m_lAccessoriesePlanDtlID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesePlanDtlID = Value
            End Set
        End Property
        Public Property AccessoriesePlanMstID() As Long
            Get
                AccessoriesePlanMstID = m_lAccessoriesePlanMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesePlanMstID = Value
            End Set
        End Property
        Public Property AccessoriesID() As Long
            Get
                AccessoriesID = m_lAccessoriesID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesID = Value
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
        Public Property Percentage() As Decimal
            Get
                Percentage = m_dPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_dPercentage = Value
            End Set
        End Property
        Public Property PerPcsAvg() As Decimal
            Get
                PerPcsAvg = m_dPerPcsAvg
            End Get
            Set(ByVal Value As Decimal)
                m_dPerPcsAvg = Value
            End Set
        End Property
        Public Property Qty() As Decimal
            Get
                Qty = m_dQty
            End Get
            Set(ByVal Value As Decimal)
                m_dQty = Value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        Public Property UOMID() As Long
            Get
                UOMID = m_lUOMID
            End Get
            Set(ByVal Value As Long)
                m_lUOMID = Value
            End Set
        End Property
        Public Property AccReqStatus() As Boolean
            Get
                AccReqStatus = m_bAccReqStatus
            End Get
            Set(ByVal Value As Boolean)
                m_bAccReqStatus = Value
            End Set
        End Property

        Public Function SaveAccessoriesePlanDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


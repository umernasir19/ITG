Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CuttingProDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPCuttingProDetail"
            m_strPrimaryFieldName = "CuttingProDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCuttingProDetailID As Long
        Private m_lCuttingProMasterID As Long
        Private m_lStyleAssortmentDetailID As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_lSizeRangeID As Long
        Private m_lSizeDatabaseID As Long
        Private m_strSize As String
        Private m_dTotalQty As Decimal
        Public Property CuttingProDetailID() As Long
            Get
                CuttingProDetailID = m_lCuttingProDetailID
            End Get
            Set(ByVal Value As Long)
                m_lCuttingProDetailID = Value
            End Set
        End Property
        Public Property CuttingProMasterID() As Long
            Get
                CuttingProMasterID = m_lCuttingProMasterID
            End Get
            Set(ByVal Value As Long)
                m_lCuttingProMasterID = Value
            End Set
        End Property
        Public Property StyleAssortmentDetailID() As Long
            Get
                StyleAssortmentDetailID = m_lStyleAssortmentDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentDetailID = Value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentMasterID = Value
            End Set
        End Property
        Public Property SizeRangeID() As Long
            Get
                SizeRangeID = m_lSizeRangeID
            End Get
            Set(ByVal Value As Long)
                m_lSizeRangeID = Value
            End Set
        End Property
        Public Property SizeDatabaseID() As Long
            Get
                SizeDatabaseID = m_lSizeDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSizeDatabaseID = Value
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
        Public Property TotalQty() As Decimal
            Get
                TotalQty = m_dTotalQty
            End Get
            Set(ByVal value As Decimal)
                m_dTotalQty = value
            End Set
        End Property
        Public Function SaveCuttingProDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

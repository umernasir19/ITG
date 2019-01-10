Imports System.Data
Namespace eurocentra
    Public Class ZipperCheckListDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ZipperCheckListDetail"
            m_strPrimaryFieldName = "ZipperCheckListDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lZipperCheckListDetailID As Long
        Private m_lAccCheckListMstID As Long
        Private m_lIMSItemId As Long
        Private m_lIMSItemCategoryID As Long
        Private m_dUsagePC As Decimal
        Private m_dTotal As Decimal
        Private m_dPercent As Decimal
        Private m_dOrderQty As Decimal
        Private m_strRemarks As String
        Private m_dCalQTy As Decimal
        Private m_strAssortSize As String
        Private m_lStyleAssortmentDetailID As Long
        Private m_strDescription As String
        Private m_strItemCode As String
        Private m_strColorZippersizes As String
        Private m_lIMSItemClassID As Long

        Public Property IMSItemClassID() As Long
            Get
                IMSItemClassID = m_lIMSItemClassID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemClassID = Value
            End Set
        End Property
        Public Property ColorZippersizes() As String
            Get
                ColorZippersizes = m_strColorZippersizes
            End Get
            Set(ByVal value As String)
                m_strColorZippersizes = value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = m_strItemCode
            End Get
            Set(ByVal value As String)
                m_strItemCode = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        Public Property ZipperCheckListDetailID() As Long
            Get
                ZipperCheckListDetailID = m_lZipperCheckListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lZipperCheckListDetailID = Value
            End Set
        End Property
        Public Property AccCheckListMstID() As Long
            Get
                AccCheckListMstID = m_lAccCheckListMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListMstID = Value
            End Set
        End Property
        Public Property IMSItemId() As Long
            Get
                IMSItemId = m_lIMSItemId
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemId = Value
            End Set
        End Property
        Public Property IMSItemCategoryID() As Long
            Get
                IMSItemCategoryID = m_lIMSItemCategoryID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemCategoryID = Value
            End Set
        End Property
        Public Property UsagePC() As Decimal
            Get
                UsagePC = m_dUsagePC
            End Get
            Set(ByVal value As Decimal)
                m_dUsagePC = value
            End Set
        End Property
        Public Property Total() As Decimal
            Get
                Total = m_dTotal
            End Get
            Set(ByVal value As Decimal)
                m_dTotal = value
            End Set
        End Property
        Public Property Percent() As Decimal
            Get
                Percent = m_dPercent
            End Get
            Set(ByVal value As Decimal)
                m_dPercent = value
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

        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        Public Property CalQTy() As Decimal
            Get
                CalQTy = m_dCalQTy
            End Get
            Set(ByVal value As Decimal)
                m_dCalQTy = value
            End Set
        End Property
        Public Property AssortSize() As String
            Get
                AssortSize = m_strAssortSize
            End Get
            Set(ByVal value As String)
                m_strAssortSize = value
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
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

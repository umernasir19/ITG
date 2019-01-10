Imports Microsoft.VisualBasic
Imports System.Data
Public Class SizeWiseWeightListDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SizeWiseWeightListDtl"
        m_strPrimaryFieldName = "SizeWiseWeightListDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSizeWiseWeightListDtlID As Long
    Private m_lSizeWiseWeightListMstID As Long
    Private m_strColor As String
    Private m_strSize As String
    Private m_dWeightPerPiece As Decimal
    Private m_dPcsPerCarton As Decimal
    Private m_dNoOfCarton As Decimal
    Private m_strDimension As String
    Private m_dQty As Decimal
    Private m_dExtra As Decimal
    Private m_dTotalQtyy As Decimal
    Private m_dBalance As Decimal
    Private m_lSizeRangeId As Long
    Private m_lSizeDatabaseId As Long
    Private m_lStyleAssortmentDetailID As Long
    Private m_lStyleAssortmentMasterID As Long
    Private m_lCuttingProDetailID As Long
    Private m_lCuttingProMasterID As Long
    Private m_lJoborderid As Long
    Private m_lJoborderDetailid As Long
    Private m_dWeight As Decimal
    
    Public Property Weight() As Decimal
        Get
            Weight = m_dWeight
        End Get
        Set(ByVal value As Decimal)
            m_dWeight = value
        End Set
    End Property
    Public Property JoborderDetailid() As Long
        Get
            JoborderDetailid = m_lJoborderDetailid
        End Get
        Set(ByVal Value As Long)
            m_lJoborderDetailid = Value
        End Set
    End Property
    Public Property Joborderid() As Long
        Get
            Joborderid = m_lJoborderid
        End Get
        Set(ByVal Value As Long)
            m_lJoborderid = Value
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
    Public Property CuttingProDetailID() As Long
        Get
            CuttingProDetailID = m_lCuttingProDetailID
        End Get
        Set(ByVal Value As Long)
            m_lCuttingProDetailID = Value
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
    Public Property StyleAssortmentDetailID() As Long
        Get
            StyleAssortmentDetailID = m_lStyleAssortmentDetailID
        End Get
        Set(ByVal Value As Long)
            m_lStyleAssortmentDetailID = Value
        End Set
    End Property
    Public Property SizeRangeId() As Long
        Get
            SizeRangeId = m_lSizeRangeId
        End Get
        Set(ByVal Value As Long)
            m_lSizeRangeId = Value
        End Set
    End Property
    Public Property SizeDatabaseId() As Long
        Get
            SizeDatabaseId = m_lSizeDatabaseId
        End Get
        Set(ByVal Value As Long)
            m_lSizeDatabaseId = Value
        End Set
    End Property
    Public Property Balance() As Decimal
        Get
            Balance = m_dBalance
        End Get
        Set(ByVal value As Decimal)
            m_dBalance = value
        End Set
    End Property
    Public Property Extra() As Decimal
        Get
            Extra = m_dExtra
        End Get
        Set(ByVal value As Decimal)
            m_dExtra = value
        End Set
    End Property
    Public Property TotalQtyy() As Decimal
        Get
            TotalQtyy = m_dTotalQtyy
        End Get
        Set(ByVal value As Decimal)
            m_dTotalQtyy = value
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
    Public Property Dimension() As String
        Get
            Dimension = m_strDimension
        End Get
        Set(ByVal value As String)
            m_strDimension = value
        End Set
    End Property
    Public Property NoOfCarton() As Decimal
        Get
            NoOfCarton = m_dNoOfCarton
        End Get
        Set(ByVal value As Decimal)
            m_dNoOfCarton = value
        End Set
    End Property
    Public Property PcsPerCarton() As Decimal
        Get
            PcsPerCarton = m_dPcsPerCarton
        End Get
        Set(ByVal value As Decimal)
            m_dPcsPerCarton = value
        End Set
    End Property
    Public Property WeightPerPiece() As Decimal
        Get
            WeightPerPiece = m_dWeightPerPiece
        End Get
        Set(ByVal value As Decimal)
            m_dWeightPerPiece = value
        End Set
    End Property
    Public Property Color() As String
        Get
            Color = m_strColor
        End Get
        Set(ByVal value As String)
            m_strColor = value
        End Set
    End Property
    
    Public Property SizeWiseWeightListDtlID() As Long
        Get
            SizeWiseWeightListDtlID = m_lSizeWiseWeightListDtlID
        End Get
        Set(ByVal Value As Long)
            m_lSizeWiseWeightListDtlID = Value
        End Set
    End Property

    Public Property SizeWiseWeightListMstID() As Long
        Get
            SizeWiseWeightListMstID = m_lSizeWiseWeightListMstID
        End Get
        Set(ByVal Value As Long)
            m_lSizeWiseWeightListMstID = Value
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
  
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
End Class

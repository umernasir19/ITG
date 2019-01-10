Imports System.Data
Namespace EuroCentra
    Public Class PackingDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PackingDtl"
            m_strPrimaryFieldName = "PackingDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPackingDtlID As Long
        Private m_lPackingMstID As Long
        Private m_lNumberingFinalID As Long
        Private m_lCustomerID As Long
        Private m_dQty As Decimal
        Private m_dNoOfCarton As Decimal
        Private m_strBuyerColor As String
        Private m_strStyle As String
        Private m_dWeight As Decimal
        Private m_strCustomerPoNo As String

        Private m_lNumberingFinalDtlID As Long
        Private m_lNumberingDtlID As Long
        Private m_lNumberingID As Long
        Private m_lSizeRangeId As Long
        Private m_lSizeDatabaseId As Long
        Private m_lStyleAssortmentDetailID As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_lCuttingProDetailID As Long
        Private m_lCuttingProMasterID As Long
        Private m_lJoborderid As Long
        Private m_lJoborderDetailid As Long
        Public Property Joborderid() As Long
            Get
                Joborderid = m_lJoborderid
            End Get
            Set(ByVal value As Long)
                m_lJoborderid = value
            End Set
        End Property
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal value As Long)
                m_lJoborderDetailid = value
            End Set
        End Property
        Public Property CuttingProDetailID() As Long
            Get
                CuttingProDetailID = m_lCuttingProDetailID
            End Get
            Set(ByVal value As Long)
                m_lCuttingProDetailID = value
            End Set
        End Property
        Public Property CuttingProMasterID() As Long
            Get
                CuttingProMasterID = m_lCuttingProMasterID
            End Get
            Set(ByVal value As Long)
                m_lCuttingProMasterID = value
            End Set
        End Property
        Public Property StyleAssortmentDetailID() As Long
            Get
                StyleAssortmentDetailID = m_lStyleAssortmentDetailID
            End Get
            Set(ByVal value As Long)
                m_lStyleAssortmentDetailID = value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal value As Long)
                m_lStyleAssortmentMasterID = value
            End Set
        End Property
        Public Property SizeRangeId() As Long
            Get
                SizeRangeId = m_lSizeRangeId
            End Get
            Set(ByVal value As Long)
                m_lSizeRangeId = value
            End Set
        End Property
        Public Property SizeDatabaseId() As Long
            Get
                SizeDatabaseId = m_lSizeDatabaseId
            End Get
            Set(ByVal value As Long)
                m_lSizeDatabaseId = value
            End Set
        End Property
        Public Property NumberingFinalDtlID() As Long
            Get
                NumberingFinalDtlID = m_lNumberingFinalDtlID
            End Get
            Set(ByVal value As Long)
                m_lNumberingFinalDtlID = value
            End Set
        End Property
        Public Property NumberingDtlID() As Long
            Get
                NumberingDtlID = m_lNumberingDtlID
            End Get
            Set(ByVal value As Long)
                m_lNumberingDtlID = value
            End Set
        End Property
        Public Property NumberingID() As Long
            Get
                NumberingID = m_lNumberingID
            End Get
            Set(ByVal value As Long)
                m_lNumberingID = value
            End Set
        End Property

        Public Property CustomerPoNo() As String
            Get
                CustomerPoNo = m_strCustomerPoNo
            End Get
            Set(ByVal Value As String)
                m_strCustomerPoNo = Value
            End Set
        End Property
        Public Property Weight() As Decimal
            Get
                Weight = m_dWeight
            End Get
            Set(ByVal Value As Decimal)
                m_dWeight = Value
            End Set
        End Property
        Public Property BuyerColor() As String
            Get
                BuyerColor = m_strBuyerColor
            End Get
            Set(ByVal Value As String)
                m_strBuyerColor = Value
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
        Public Property Qty() As Decimal
            Get
                Qty = m_dQty
            End Get
            Set(ByVal Value As Decimal)
                m_dQty = Value
            End Set
        End Property
        Public Property NoOfCarton() As Decimal
            Get
                NoOfCarton = m_dNoOfCarton
            End Get
            Set(ByVal Value As Decimal)
                m_dNoOfCarton = Value
            End Set
        End Property
        Public Property PackingDtlID() As Long
            Get
                PackingDtlID = m_lPackingDtlID
            End Get
            Set(ByVal value As Long)
                m_lPackingDtlID = value
            End Set
        End Property
        Public Property PackingMstID() As Long
            Get
                PackingMstID = m_lPackingMstID
            End Get
            Set(ByVal value As Long)
                m_lPackingMstID = value
            End Set
        End Property
        Public Property NumberingFinalID() As Long
            Get
                NumberingFinalID = m_lNumberingFinalID
            End Get
            Set(ByVal value As Long)
                m_lNumberingFinalID = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLiningType() As DataTable
            Dim str As String
            str = " select   * from LiningType  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 PackingNo from PackingMst  order By PackingMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


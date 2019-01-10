Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class InquiryStyleProductionInformation
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "InquiryStyleProductInformation"
            m_strPrimaryFieldName = "InquirySproductID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_InquirySproductID As Long
        Private m_InquiryStyleID As Long
        Private m_RowNo As String
        Private m_ProductPortfolioID As Long
        Private m_ProductCategoriesID As Long
        Private m_ProductConsumerID As Long
        Private m_Pack As String
        Private m_Item As String
        Private m_HSCode As String
        Private m_FabricTypeID As Long
        Private m_FabicCons As String
        Private m_CompositionID As Long
        Private m_FabicWt As Decimal
        Private m_FabicWtUnitID As Long
        Private m_GarmentWt As Decimal
        Private m_GarmentWtUnitID As Long
        Private m_Color As String
        Private m_Rremarks As String
        Private m_FabFinishID As Long
        Private m_Lining As String
        Private m_LiningTypeID As Long
        Private m_LiningCons As String
        Private m_LiningCompId As Long
        Private m_LiningWt As Decimal
        Private m_dBuyerTargetPrice As Decimal
        Private m_strBuyerPriceUnit As String
        Private m_dBuyerMOQ As Decimal

        Public Property FabFinishID() As Long
            Get
                FabFinishID = m_FabFinishID
            End Get
            Set(ByVal value As Long)
                m_FabFinishID = value
            End Set
        End Property

        Public Property InquirySproductID() As Long
            Get
                InquirySproductID = m_InquirySproductID
            End Get
            Set(ByVal value As Long)
                m_InquirySproductID = value
            End Set
        End Property
        Public Property InquiryStyleID() As Long
            Get
                InquiryStyleID = m_InquiryStyleID
            End Get
            Set(ByVal value As Long)
                m_InquiryStyleID = value
            End Set
        End Property
        Public Property RowNo() As String
            Get
                RowNo = m_RowNo
            End Get
            Set(ByVal value As String)
                m_RowNo = value
            End Set
        End Property
        Public Property ProductPortfolioID() As Long
            Get
                ProductPortfolioID = m_ProductPortfolioID
            End Get
            Set(ByVal value As Long)
                m_ProductPortfolioID = value
            End Set
        End Property
        Public Property ProductCategoriesID() As Long
            Get
                ProductCategoriesID = m_ProductCategoriesID
            End Get
            Set(ByVal value As Long)
                m_ProductCategoriesID = value
            End Set
        End Property
        Public Property ProductConsumerID() As Long
            Get
                ProductConsumerID = m_ProductConsumerID
            End Get
            Set(ByVal value As Long)
                m_ProductConsumerID = value
            End Set
        End Property
        Public Property Pack() As String
            Get
                Pack = m_Pack
            End Get
            Set(ByVal value As String)
                m_Pack = value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_Item
            End Get
            Set(ByVal value As String)
                m_Item = value
            End Set
        End Property
        Public Property HSCode() As String
            Get
                HSCode = m_HSCode
            End Get
            Set(ByVal value As String)
                m_HSCode = value
            End Set
        End Property
        Public Property FabricTypeID() As Long
            Get
                FabricTypeID = m_FabricTypeID
            End Get
            Set(ByVal value As Long)
                m_FabricTypeID = value
            End Set
        End Property
        Public Property FabicCons() As String
            Get
                FabicCons = m_FabicCons
            End Get
            Set(ByVal value As String)
                m_FabicCons = value
            End Set
        End Property
        Public Property CompositionID() As Long
            Get
                CompositionID = m_CompositionID
            End Get
            Set(ByVal value As Long)
                m_CompositionID = value
            End Set
        End Property
        Public Property FabicWt() As Decimal
            Get
                FabicWt = m_FabicWt
            End Get
            Set(ByVal value As Decimal)
                m_FabicWt = value
            End Set
        End Property
        Public Property FabicWtUnitID() As Long
            Get
                FabicWtUnitID = m_FabicWtUnitID
            End Get
            Set(ByVal value As Long)
                m_FabicWtUnitID = value
            End Set
        End Property
        Public Property GarmentWt() As Decimal
            Get
                GarmentWt = m_GarmentWt
            End Get
            Set(ByVal value As Decimal)
                m_GarmentWt = value
            End Set
        End Property
        Public Property GarmentWtUnitID() As Long
            Get
                GarmentWtUnitID = m_GarmentWtUnitID
            End Get
            Set(ByVal value As Long)
                m_GarmentWtUnitID = value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_Color
            End Get
            Set(ByVal value As String)
                m_Color = value
            End Set
        End Property
        Public Property Rremarks() As String
            Get
                Rremarks = m_Rremarks
            End Get
            Set(ByVal value As String)
                m_Rremarks = value
            End Set
        End Property
        Public Property Lining() As String
            Get
                Lining = m_Lining
            End Get
            Set(ByVal value As String)
                m_Lining = value
            End Set
        End Property
        Public Property LiningTypeID() As Long
            Get
                LiningTypeID = m_LiningTypeID
            End Get
            Set(ByVal value As Long)
                m_LiningTypeID = value
            End Set
        End Property
        Public Property LiningCons() As String
            Get
                LiningCons = m_LiningCons
            End Get
            Set(ByVal value As String)
                m_LiningCons = value
            End Set
        End Property

        Public Property LiningCompId() As Long
            Get
                LiningCompId = m_LiningCompId
            End Get
            Set(ByVal value As Long)
                m_LiningCompId = value
            End Set
        End Property
        Public Property LiningWt() As Decimal
            Get
                LiningWt = m_LiningWt
            End Get
            Set(ByVal value As Decimal)
                m_LiningWt = value
            End Set
        End Property

        Public Property BuyerTargetPrice() As Decimal
            Get
                BuyerTargetPrice = m_dBuyerTargetPrice
            End Get
            Set(ByVal value As Decimal)
                m_dBuyerTargetPrice = value
            End Set
        End Property
        Public Property BuyerPriceUnit() As String
            Get
                BuyerPriceUnit = m_strBuyerPriceUnit
            End Get
            Set(ByVal value As String)
                m_strBuyerPriceUnit = value
            End Set
        End Property
        Public Property BuyerMOQ() As Decimal
            Get
                BuyerMOQ = m_dBuyerMOQ
            End Get
            Set(ByVal value As Decimal)
                m_dBuyerMOQ = value
            End Set
        End Property

        Public Function SaveStyleProductInformation()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal InquirySproductID As Long)
            Dim Str As String
            Str = " delete from InquiryStyleProductInformation where  InquirySproductID='" & InquirySproductID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
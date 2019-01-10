Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class TblInquiryConfirmed
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TblInquiryConfirmed"
            m_strPrimaryFieldName = "InquiryConformedID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_InquiryConformedID As Long
        Private m_InquiryStyleID As Long
        Private m_InquirySproductID As Long
        Private m_SupplierId As Long
        Private m_Color As String
        Private m_Qty As Decimal
        Private m_ConfirmRemarks As String
        Private m_CadArtDate As Date
        Private m_TackPack As Date
        Private m_Price As Decimal
        Private m_ConFConstruction As String
        Private m_ConCompostionId As Long
        Private m_ConFwt As Decimal
        Private m_StylingDetail As String
        Public Property InquiryConformedID() As Long
            Get
                InquiryConformedID = m_InquiryConformedID
            End Get
            Set(ByVal value As Long)
                m_InquiryConformedID = value
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
        Public Property InquirySproductID() As Long
            Get
                InquirySproductID = m_InquirySproductID
            End Get
            Set(ByVal value As Long)
                m_InquirySproductID = value
            End Set
        End Property
        Public Property SupplierId() As Long
            Get
                SupplierId = m_SupplierId
            End Get
            Set(ByVal value As Long)
                m_SupplierId = value
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

        Public Property Qty() As Decimal
            Get
                Qty = m_Qty
            End Get
            Set(ByVal value As Decimal)
                m_Qty = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_Price
            End Get
            Set(ByVal value As Decimal)
                m_Price = value
            End Set
        End Property
        Public Property ConfirmRemarks() As String
            Get
                ConfirmRemarks = m_ConfirmRemarks
            End Get
            Set(ByVal value As String)
                m_ConfirmRemarks = value
            End Set
        End Property

        Public Property CadArtDate() As Date
            Get
                CadArtDate = m_CadArtDate
            End Get
            Set(ByVal value As Date)
                m_CadArtDate = value
            End Set
        End Property
        Public Property TackPack() As Date
            Get
                TackPack = m_TackPack
            End Get
            Set(ByVal value As Date)
                m_TackPack = value
            End Set
        End Property

        Public Property ConFConstruction() As String
            Get
                ConFConstruction = m_ConFConstruction
            End Get
            Set(ByVal value As String)
                m_ConFConstruction = value
            End Set
        End Property
        Public Property ConCompostionId() As Long
            Get
                ConCompostionId = m_ConCompostionId
            End Get
            Set(ByVal value As Long)
                m_ConCompostionId = value
            End Set
        End Property
        Public Property ConFwt() As Decimal
            Get
                ConFwt = m_ConFwt
            End Get
            Set(ByVal value As Decimal)
                m_ConFwt = value
            End Set
        End Property
        Public Property StylingDetail() As String
            Get
                StylingDetail = m_StylingDetail
            End Get
            Set(ByVal value As String)
                m_StylingDetail = value
            End Set
        End Property

        Public Function SaveInquiryConformed()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

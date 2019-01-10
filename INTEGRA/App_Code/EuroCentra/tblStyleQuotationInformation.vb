Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class tblStyleQuotationInformation
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblStyleQuotationInformation"
            m_strPrimaryFieldName = "InquiryQuotationID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_InquiryQuotationID As Long
        Private m_InquiryStyleID As Long
        Private m_InquirySproductID As Long
        Private m_RowNo As String
        Private m_BuyerTargetPrice As Decimal
        Private m_BuyerPriceUnit As String
        Private m_BuyerMOQ As Decimal
        Private m_SupplierID1 As Long
        Private m_QuotedPrice1 As Decimal
        Private m_QuotedPriceUnit1 As String
        Private m_SupplierID2 As Long
        Private m_QuotedPrice2 As Decimal
        Private m_QuotedPriceUnit2 As String
        Private m_SupplierID3 As Long
        Private m_QuotedPrice3 As Decimal
        Private m_QuotedPriceUnit3 As String
        Private m_SupplierID4 As Long
        Private m_QuotedPrice4 As Decimal
        Private m_QuotedPriceUnit4 As String
        Private m_SupplierID5 As Long
        Private m_QuotedPrice5 As Decimal
        Private m_QuotedPriceUnit5 As String
        Private m_FCons1 As String
        Private m_CompositionID1 As Long
        Private m_FWT1 As Decimal
        Private m_FCons2 As String
        Private m_CompositionID2 As Long
        Private m_FWT2 As Decimal
        Private m_FCons3 As String
        Private m_CompositionID3 As Long
        Private m_FWT3 As Decimal
        Private m_FCons4 As String
        Private m_CompositionID4 As Long
        Private m_FWT4 As Decimal
        Private m_FCons5 As String
        Private m_CompositionID5 As Long
        Private m_FWT5 As Decimal
        Private m_QuotedRemarks As String
        Private m_SupplierMOQ1 As Decimal
        Private m_SupplierMOQ2 As Decimal
        Private m_SupplierMOQ3 As Decimal
        Private m_SupplierMOQ4 As Decimal
        Private m_SupplierMOQ5 As Decimal
        Public Property SupplierMOQ1() As Decimal
            Get
                SupplierMOQ1 = m_SupplierMOQ1
            End Get
            Set(ByVal value As Decimal)
                m_SupplierMOQ1 = value
            End Set
        End Property
        Public Property SupplierMOQ2() As Decimal
            Get
                SupplierMOQ2 = m_SupplierMOQ2
            End Get
            Set(ByVal value As Decimal)
                m_SupplierMOQ2 = value
            End Set
        End Property
        Public Property SupplierMOQ3() As Decimal
            Get
                SupplierMOQ3 = m_SupplierMOQ3
            End Get
            Set(ByVal value As Decimal)
                m_SupplierMOQ3 = value
            End Set
        End Property
        Public Property SupplierMOQ4() As Decimal
            Get
                SupplierMOQ4 = m_SupplierMOQ4
            End Get
            Set(ByVal value As Decimal)
                m_SupplierMOQ4 = value
            End Set
        End Property
        Public Property SupplierMOQ5() As Decimal
            Get
                SupplierMOQ5 = m_SupplierMOQ5
            End Get
            Set(ByVal value As Decimal)
                m_SupplierMOQ5 = value
            End Set
        End Property
        Public Property InquiryQuotationID() As Long
            Get
                InquiryQuotationID = m_InquiryQuotationID
            End Get
            Set(ByVal value As Long)
                m_InquiryQuotationID = value
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

        Public Property RowNo() As String
            Get
                RowNo = m_RowNo
            End Get
            Set(ByVal value As String)
                m_RowNo = value
            End Set
        End Property
        Public Property BuyerTargetPrice() As Decimal
            Get
                BuyerTargetPrice = m_BuyerTargetPrice
            End Get
            Set(ByVal value As Decimal)
                m_BuyerTargetPrice = value
            End Set
        End Property
        Public Property BuyerPriceUnit() As String
            Get
                BuyerPriceUnit = m_BuyerPriceUnit
            End Get
            Set(ByVal value As String)
                m_BuyerPriceUnit = value
            End Set
        End Property
        Public Property BuyerMOQ() As Decimal
            Get
                BuyerMOQ = m_BuyerMOQ
            End Get
            Set(ByVal value As Decimal)
                m_BuyerMOQ = value
            End Set
        End Property

        Public Property SupplierID1() As Long
            Get
                SupplierID1 = m_SupplierID1
            End Get
            Set(ByVal value As Long)
                m_SupplierID1 = value
            End Set
        End Property
        Public Property QuotedPrice1() As Decimal
            Get
                QuotedPrice1 = m_QuotedPrice1
            End Get
            Set(ByVal value As Decimal)
                m_QuotedPrice1 = value
            End Set
        End Property
        Public Property QuotedPriceUnit1() As String
            Get
                QuotedPriceUnit1 = m_QuotedPriceUnit1
            End Get
            Set(ByVal value As String)
                m_QuotedPriceUnit1 = value
            End Set
        End Property

        Public Property SupplierID2() As Long
            Get
                SupplierID2 = m_SupplierID2
            End Get
            Set(ByVal value As Long)
                m_SupplierID2 = value
            End Set
        End Property
        Public Property QuotedPrice2() As Decimal
            Get
                QuotedPrice2 = m_QuotedPrice2
            End Get
            Set(ByVal value As Decimal)
                m_QuotedPrice2 = value
            End Set
        End Property
        Public Property QuotedPriceUnit2() As String
            Get
                QuotedPriceUnit2 = m_QuotedPriceUnit2
            End Get
            Set(ByVal value As String)
                m_QuotedPriceUnit2 = value
            End Set
        End Property

        Public Property SupplierID3() As Long
            Get
                SupplierID3 = m_SupplierID3
            End Get
            Set(ByVal value As Long)
                m_SupplierID3 = value
            End Set
        End Property
        Public Property QuotedPrice3() As Decimal
            Get
                QuotedPrice3 = m_QuotedPrice3
            End Get
            Set(ByVal value As Decimal)
                m_QuotedPrice3 = value
            End Set
        End Property
        Public Property QuotedPriceUnit3() As String
            Get
                QuotedPriceUnit3 = m_QuotedPriceUnit3
            End Get
            Set(ByVal value As String)
                m_QuotedPriceUnit3 = value
            End Set
        End Property

        Public Property SupplierID4() As Long
            Get
                SupplierID4 = m_SupplierID4
            End Get
            Set(ByVal value As Long)
                m_SupplierID4 = value
            End Set
        End Property
        Public Property QuotedPrice4() As Decimal
            Get
                QuotedPrice4 = m_QuotedPrice4
            End Get
            Set(ByVal value As Decimal)
                m_QuotedPrice4 = value
            End Set
        End Property
        Public Property QuotedPriceUnit4() As String
            Get
                QuotedPriceUnit4 = m_QuotedPriceUnit4
            End Get
            Set(ByVal value As String)
                m_QuotedPriceUnit4 = value
            End Set
        End Property

        Public Property SupplierID5() As Long
            Get
                SupplierID5 = m_SupplierID5
            End Get
            Set(ByVal value As Long)
                m_SupplierID5 = value
            End Set
        End Property
        Public Property QuotedPrice5() As Decimal
            Get
                QuotedPrice5 = m_QuotedPrice5
            End Get
            Set(ByVal value As Decimal)
                m_QuotedPrice5 = value
            End Set
        End Property
        Public Property QuotedPriceUnit5() As String
            Get
                QuotedPriceUnit5 = m_QuotedPriceUnit5
            End Get
            Set(ByVal value As String)
                m_QuotedPriceUnit5 = value
            End Set
        End Property
        Public Property FCons1() As String
            Get
                FCons1 = m_FCons1
            End Get
            Set(ByVal value As String)
                m_FCons1 = value
            End Set
        End Property
        Public Property CompositionID1() As Long
            Get
                CompositionID1 = m_CompositionID1
            End Get
            Set(ByVal value As Long)
                m_CompositionID1 = value
            End Set
        End Property
        Public Property FWT1() As Decimal
            Get
                FWT1 = m_FWT1
            End Get
            Set(ByVal value As Decimal)
                m_FWT1 = value
            End Set
        End Property

        Public Property FCons2() As String
            Get
                FCons2 = m_FCons2
            End Get
            Set(ByVal value As String)
                m_FCons2 = value
            End Set
        End Property
        Public Property CompositionID2() As Long
            Get
                CompositionID2 = m_CompositionID2
            End Get
            Set(ByVal value As Long)
                m_CompositionID2 = value
            End Set
        End Property
        Public Property FWT2() As Decimal
            Get
                FWT2 = m_FWT2
            End Get
            Set(ByVal value As Decimal)
                m_FWT2 = value
            End Set
        End Property

        Public Property FCons3() As String
            Get
                FCons3 = m_FCons3
            End Get
            Set(ByVal value As String)
                m_FCons3 = value
            End Set
        End Property
        Public Property CompositionID3() As Long
            Get
                CompositionID3 = m_CompositionID3
            End Get
            Set(ByVal value As Long)
                m_CompositionID3 = value
            End Set
        End Property
        Public Property FWT3() As Decimal
            Get
                FWT3 = m_FWT3
            End Get
            Set(ByVal value As Decimal)
                m_FWT3 = value
            End Set
        End Property

        Public Property FCons4() As String
            Get
                FCons4 = m_FCons4
            End Get
            Set(ByVal value As String)
                m_FCons4 = value
            End Set
        End Property
        Public Property CompositionID4() As Long
            Get
                CompositionID4 = m_CompositionID4
            End Get
            Set(ByVal value As Long)
                m_CompositionID4 = value
            End Set
        End Property
        Public Property FWT4() As Decimal
            Get
                FWT4 = m_FWT4
            End Get
            Set(ByVal value As Decimal)
                m_FWT4 = value
            End Set
        End Property

        Public Property FCons5() As String
            Get
                FCons5 = m_FCons5
            End Get
            Set(ByVal value As String)
                m_FCons5 = value
            End Set
        End Property
        Public Property CompositionID5() As Long
            Get
                CompositionID5 = m_CompositionID5
            End Get
            Set(ByVal value As Long)
                m_CompositionID5 = value
            End Set
        End Property
        Public Property FWT5() As Decimal
            Get
                FWT5 = m_FWT5
            End Get
            Set(ByVal value As Decimal)
                m_FWT5 = value
            End Set
        End Property

        Public Property QuotedRemarks() As String
            Get
                QuotedRemarks = m_QuotedRemarks
            End Get
            Set(ByVal value As String)
                m_QuotedRemarks = value
            End Set
        End Property
        Public Function SaveInquiryQuotation()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function check(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "select * from tblStyleQuotationInformation where InquiryStyleID='" & InquiryStyleID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Costedit(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            'str = "select isnull(v1.VenderName,'') as Supplier1,"
            'str &= " isnull(v2.VenderName,'') as Supplier2,"
            'str &= " isnull(v3.VenderName,'') as Supplier3,"
            'str &= " isnull(v4.VenderName,'') as Supplier4,"
            'str &= " isnull(v5.VenderName,'') as Supplier5,* "
            'str &= " from tblStyleQuotationInformation TSQ "
            'str &= " left JOIN Vender v1 on v1.VenderLibraryID=TSQ.SupplierID1"
            'str &= " left JOIN Vender v2 on v2.VenderLibraryID=TSQ.SupplierID2"
            'str &= " left JOIN Vender v3 on v3.VenderLibraryID=TSQ.SupplierID3"
            'str &= " left JOIN Vender v4 on v4.VenderLibraryID=TSQ.SupplierID4"
            'str &= " left JOIN Vender v5 on v5.VenderLibraryID=TSQ.SupplierID5"
            'str &= "    where InquiryStyleID = '" & InquiryStyleID & "'"
            str = " select isnull(CMP1.Compositionname,'') as FComp1,isnull(CMP2.Compositionname,'') as FComp2,"
            str &= "  isnull(CMP3.Compositionname,'') as FComp3,isnull(CMP4.Compositionname,'') as FComp4,"
            str &= "  isnull(CMP5.Compositionname,'') as FComp5,isnull(v1.VenderName,'') as Supplier1,"
            str &= "  isnull(v2.VenderName,'') as Supplier2,"
            str &= "  isnull(v3.VenderName,'') as Supplier3,"
            str &= "  isnull(v4.VenderName,'') as Supplier4,"
            str &= "  isnull(v5.VenderName,'') as Supplier5,* "
            str &= "  from tblStyleQuotationInformation TSQ "
            str &= "  left JOIN Vender v1 on v1.VenderLibraryID=TSQ.SupplierID1"
            str &= "  left JOIN Vender v2 on v2.VenderLibraryID=TSQ.SupplierID2"
            str &= "  left JOIN Vender v3 on v3.VenderLibraryID=TSQ.SupplierID3"
            str &= "  left JOIN Vender v4 on v4.VenderLibraryID=TSQ.SupplierID4"
            str &= "  left JOIN Vender v5 on v5.VenderLibraryID=TSQ.SupplierID5"
            str &= "  left  JOIN Composition CMP1 ON CMP1.CompositionID=TSQ.CompositionID1"
            str &= "  left  JOIN Composition CMP2 ON CMP2.CompositionID=TSQ.CompositionID2"
            str &= "  left  JOIN Composition CMP3 ON CMP3.CompositionID=TSQ.CompositionID3"
            str &= "  left  JOIN Composition CMP4 ON CMP4.CompositionID=TSQ.CompositionID4"
            str &= "  left  JOIN Composition CMP5 ON CMP5.CompositionID=TSQ.CompositionID5"
            str &= "   where InquiryStyleID = '" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class GeneralInquiryDtl
 Inherits SQLManager
        Public Sub New()
            m_strTableName = "GeneralInquiryDtl"
            m_strPrimaryFieldName = "GeneralInquiryDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_GeneralInquiryDtlID As Long
        Private m_GeneralInquiryMstID As Long
        Private m_Item As String
        Private m_Color As String
        Private m_Qty As Decimal
        Public Property GeneralInquiryDtlID() As Long
            Get
                GeneralInquiryDtlID = m_GeneralInquiryDtlID
            End Get
            Set(ByVal value As Long)
                m_GeneralInquiryDtlID = value
            End Set
        End Property
        Public Property GeneralInquiryMstID() As Long
            Get
                GeneralInquiryMstID = m_GeneralInquiryMstID
            End Get
            Set(ByVal value As Long)
                m_GeneralInquiryMstID = value
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
        Public Function SaveInquiriesDtl()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteDetail(ByVal GeneralInquiryDtlID As Long)
            Dim str As String = "Delete GeneralInquiryDtl where GeneralInquiryDtlID=" & GeneralInquiryDtlID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
End Class
End Namespace 
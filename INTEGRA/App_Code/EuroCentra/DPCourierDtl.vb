Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPCourierDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPCourierDtl"
            m_strPrimaryFieldName = "DPCourierDtlId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPCourierDtlId As Long
        Private m_lDPCourierMstId As Long
        Private m_strNoOfPackage As String
        Private m_dQty As Decimal
        Private m_dRate As Decimal
        Private m_strQtyType As String
        Private m_strDesc As String
        Private m_strDeliveryDate As String
        Private m_dConvergeRate As Decimal
        Private m_dAmount As Decimal
        Private m_lCurrencyID As Long
        Public Property DPCourierDtlId() As Long
            Get
                DPCourierDtlId = m_lDPCourierDtlId
            End Get
            Set(ByVal value As Long)
                m_lDPCourierDtlId = value
            End Set
        End Property
        Public Property DPCourierMstId() As Long
            Get
                DPCourierMstId = m_lDPCourierMstId
            End Get
            Set(ByVal value As Long)
                m_lDPCourierMstId = value
            End Set
        End Property
        Public Property NoOfPackage() As String
            Get
                NoOfPackage = m_strNoOfPackage
            End Get
            Set(ByVal value As String)
                m_strNoOfPackage = value
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
        Public Property Rate() As Decimal
            Get
                Rate = m_dRate
            End Get
            Set(ByVal value As Decimal)
                m_dRate = value
            End Set
        End Property
        Public Property QtyType() As String
            Get
                QtyType = m_strQtyType
            End Get
            Set(ByVal value As String)
                m_strQtyType = value
            End Set
        End Property
        Public Property Desc() As String
            Get
                Desc = m_strDesc
            End Get
            Set(ByVal value As String)
                m_strDesc = value
            End Set
        End Property
        Public Property DeliveryDate() As String
            Get
                DeliveryDate = m_strDeliveryDate
            End Get
            Set(ByVal value As String)
                m_strDeliveryDate = value
            End Set
        End Property
        
        Public Property ConvergeRate() As Decimal
            Get
                ConvergeRate = m_dConvergeRate
            End Get
            Set(ByVal value As Decimal)
                m_dConvergeRate = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dAmount
            End Get
            Set(ByVal value As Decimal)
                m_dAmount = value
            End Set
        End Property
        Public Property CurrencyID() As Long
            Get
                CurrencyID = m_lCurrencyID
            End Get
            Set(ByVal value As Long)
                m_lCurrencyID = value
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
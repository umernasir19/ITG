Imports System.Data
Namespace EuroCentra
    Public Class CommercialDetail

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CommercialInvoiceDetail"
            m_strPrimaryFieldName = "CommercialInvoiceDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCommercialInvoiceDetailID As Long
        Private m_lCommercialInvoiceID As Long
        Private m_lPOID As Long
        Private m_lPODetailID As Long
        Private m_dcQuantity As Decimal
        Private m_strUOM As String
        Private m_dcRate As Decimal
        '----------------Properties
        Public Property CommercialInvoiceDetailID() As Long
            Get
                CommercialInvoiceDetailID = m_lCommercialInvoiceDetailID
            End Get
            Set(ByVal value As Long)
                m_lCommercialInvoiceDetailID = value
            End Set
        End Property
        Public Property CommercialInvoiceID() As Long
            Get
                CommercialInvoiceID = m_lCommercialInvoiceID
            End Get
            Set(ByVal value As Long)
                m_lCommercialInvoiceID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcQuantity = value
            End Set
        End Property
        Public Property UOM() As String
            Get
                UOM = m_strUOM
            End Get
            Set(ByVal value As String)
                m_strUOM = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dcRate
            End Get
            Set(ByVal value As Decimal)
                m_dcRate = value
            End Set
        End Property
      
        Public Function SaveCommercialInvoiceDetail()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommercialInvoiceDetailID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoById(ByVal CommercialInvoiceDetailID As Long)
            Try
                Return MyBase.GetById(CommercialInvoiceDetailID)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

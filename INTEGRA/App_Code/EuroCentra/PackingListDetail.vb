Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PackingListDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PackingListDetail"
            m_strPrimaryFieldName = "PackingListDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''Properties'''''''''''''''''''''''''''''''''''''''''
        Private m_lPackingListDetailID As Long
        Private m_lPackingListID As Long
        Private m_dCartonSeriesStart As Decimal
        Private m_dCartonSeriesEnd As Decimal
        Private m_lPOID As Long
        Private m_lPODetailID As Long
        Private m_dQuantity As Decimal

        Public Property PackingListDetailID() As Long
            Get
                PackingListDetailID = m_lPackingListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lPackingListDetailID = Value
            End Set
        End Property
        Public Property PackingListID() As Long
            Get
                PackingListID = m_lPackingListID
            End Get
            Set(ByVal Value As Long)
                m_lPackingListID = Value
            End Set
        End Property
        Public Property CartonSeriesStart() As Decimal
            Get
                CartonSeriesStart = m_dCartonSeriesStart
            End Get
            Set(ByVal value As Decimal)
                m_dCartonSeriesStart = value
            End Set
        End Property
        Public Property CartonSeriesEnd() As Decimal
            Get
                CartonSeriesEnd = m_dCartonSeriesEnd
            End Get
            Set(ByVal value As Decimal)
                m_dCartonSeriesEnd = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal Value As Long)
                m_lPODetailID = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dQuantity = value
            End Set
        End Property
        Public Function SavePackingListDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetailFromPackingListDetail(ByVal PackingListDetailID As Long)
            Dim Str As String
            Str = " Delete from PackingListDetail where PackingListDetailID=" & PackingListDetailID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


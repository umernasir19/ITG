Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystemDetailAdd
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystemDetailAdd"
            m_strPrimaryFieldName = "EnquiriesSystemDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemDetailID As Long
        Private m_EnquiriesSystemID As Long
        Private m_Colorways As String
        Private m_MOQ As String
        Private m_Price As String
        Private m_PriceUnit As String
        Private m_Fabric As String
        Private m_FabricRemarks As String
        Private m_Construction As String
        Private m_BuyerTargetPrice As String
        Private m_BuyerTargetPriceUnit As String
        Private m_Compostion As String
        Private m_Weight As String

        Public Property EnquiriesSystemDetailID() As Long
            Get
                EnquiriesSystemDetailID = m_EnquiriesSystemDetailID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemDetailID = value
            End Set
        End Property
        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_EnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemID = value
            End Set
        End Property
     
     
        Public Property Colorways() As String
            Get
                Colorways = m_Colorways
            End Get
            Set(ByVal value As String)
                m_Colorways = value
            End Set
        End Property
        Public Property MOQ() As String
            Get
                MOQ = m_MOQ
            End Get
            Set(ByVal value As String)
                m_MOQ = value
            End Set
        End Property
        Public Property Price() As String
            Get
                Price = m_Price
            End Get
            Set(ByVal value As String)
                m_Price = value
            End Set
        End Property

        Public Property PriceUnit() As String
            Get
                PriceUnit = m_PriceUnit
            End Get
            Set(ByVal value As String)
                m_PriceUnit = value
            End Set
        End Property
        Public Property BuyerTargetPrice() As String
            Get
                BuyerTargetPrice = m_BuyerTargetPrice
            End Get
            Set(ByVal value As String)
                m_BuyerTargetPrice = value
            End Set
        End Property

        Public Property BuyerTargetPriceUnit() As String
            Get
                BuyerTargetPriceUnit = m_BuyerTargetPriceUnit
            End Get
            Set(ByVal value As String)
                m_BuyerTargetPriceUnit = value
            End Set
        End Property
        Public Property Fabric() As String
            Get
                Fabric = m_Fabric
            End Get
            Set(ByVal value As String)
                m_Fabric = value
            End Set
        End Property
        Public Property FabricRemarks() As String
            Get
                FabricRemarks = m_FabricRemarks
            End Get
            Set(ByVal value As String)
                m_FabricRemarks = value
            End Set
        End Property
        Public Property Construction() As String
            Get
                Construction = m_Construction
            End Get
            Set(ByVal value As String)
                m_Construction = value
            End Set
        End Property
        Public Property Compostion() As String
            Get
                Compostion = m_Compostion
            End Get
            Set(ByVal value As String)
                m_Compostion = value
            End Set
        End Property
        Public Property Weight() As String
            Get
                Weight = m_Weight
            End Get
            Set(ByVal value As String)
                m_Weight = value
            End Set
        End Property
        Public Function SaveEnquiriesSystemDetail()
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
        Public Function DeleteDetailById(ByVal EnquiriesSystemDetailID As Long)
            Dim str As String = "Delete EnquiriesSystemDetail where EnquiriesSystemDetailID=" & EnquiriesSystemDetailID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


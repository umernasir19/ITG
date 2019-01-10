Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_TopCustomer
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_TopCustomer"
            m_strPrimaryFieldName = "VAF_TopCustomerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_TopCustomerID As Long
        Private m_lVAFID As Long
        Private m_strCustomerName As String
        Private m_lCountry_id As Long
        Private m_strCustomerCountry As String
        Private m_dcCustomerPercentOfBuss As Decimal
        Private m_strCustomerProduct As String
        Public Property VAF_TopCustomerID() As Long
            Get
                VAF_TopCustomerID = m_lVAF_TopCustomerID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_TopCustomerID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property CustomerName() As String
            Get
                CustomerName = m_strCustomerName
            End Get
            Set(ByVal value As String)
                m_strCustomerName = value
            End Set
        End Property
        Public Property Country_id() As Long
            Get
                Country_id = m_lCountry_id
            End Get
            Set(ByVal Value As Long)
                m_lCountry_id = Value
            End Set
        End Property
        Public Property CustomerCountry() As String
            Get
                CustomerCountry = m_strCustomerCountry
            End Get
            Set(ByVal value As String)
                m_strCustomerCountry = value
            End Set
        End Property
        Public Property CustomerPercentOfBuss() As Decimal
            Get
                CustomerPercentOfBuss = m_dcCustomerPercentOfBuss
            End Get
            Set(ByVal Value As Decimal)
                m_dcCustomerPercentOfBuss = Value
            End Set
        End Property
        Public Property CustomerProduct() As String
            Get
                CustomerProduct = m_strCustomerProduct
            End Get
            Set(ByVal value As String)
                m_strCustomerProduct = value
            End Set
        End Property
        Public Function SaveVAF_TopCustomer()
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
        Public Function DeleteRow(ByVal VAF_TopCustomerID As Long)
            Dim Str As String
            Str = "Delete from VAF_TopCustomer  "
            Str &= " where VAF_TopCustomerID=" & VAF_TopCustomerID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
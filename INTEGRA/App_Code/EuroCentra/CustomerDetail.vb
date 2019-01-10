Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra


    Public Class CustomerDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CustomerDetail"
            m_strPrimaryFieldName = "CustomerDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lCustomerDetailID As Long
        Private m_lCustomerID As Long
        Private m_strContact_Type_ID As String
        Private m_strBuyer_Name As String
        Private m_strCellNo As String
        Private m_strEmail As String
        Private m_strdesignation As String
        Private m_strDepartmentNo As String
        Private m_strImg_Foto As String
        Private m_FaxNumber As String
        Private m_BrandName As String
        '----------------Properties
        Public Property BrandName() As String
            Get
                BrandName = m_BrandName
            End Get
            Set(ByVal value As String)
                m_BrandName = value
            End Set
        End Property
        Public Property FaxNumber() As String
            Get
                FaxNumber = m_FaxNumber
            End Get
            Set(ByVal value As String)
                m_FaxNumber = value
            End Set
        End Property
        Public Property CustomerDetailID() As Long
            Get
                CustomerDetailID = m_lCustomerDetailID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerDetailID = Value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerID = Value
            End Set
        End Property
        Public Property Img_Foto() As String
            Get
                Img_Foto = m_strImg_Foto
            End Get
            Set(ByVal value As String)
                m_strImg_Foto = value
            End Set
        End Property

        Public Property Buyer_Name() As String
            Get
                Buyer_Name = m_strBuyer_Name
            End Get
            Set(ByVal value As String)
                m_strBuyer_Name = value
            End Set
        End Property
        Public Property CellNo() As String
            Get
                CellNo = m_strCellNo
            End Get
            Set(ByVal value As String)
                m_strCellNo = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Email = m_strEmail
            End Get
            Set(ByVal value As String)
                m_strEmail = value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strdesignation
            End Get
            Set(ByVal value As String)
                m_strdesignation = value
            End Set
        End Property
        Public Property Contact_Type_ID() As String
            Get
                Contact_Type_ID = m_strContact_Type_ID
            End Get
            Set(ByVal value As String)
                m_strContact_Type_ID = value
            End Set
        End Property
        Public Property DepartmentNo() As String
            Get
                DepartmentNo = m_strDepartmentNo
            End Get
            Set(ByVal value As String)
                m_strDepartmentNo = value
            End Set
        End Property

        Public Sub SaveCustomerDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetCustomerDetailById(ByVal lCustomerDetailId As Long)
            Try
                Return MyBase.GetById(lCustomerDetailId)
            Catch ex As Exception

            End Try
        End Function

        Function DeleteDetailFromCustomerDetail(ByVal CustomerDetailID As Long)
            Dim Str As String
            Str = " Delete from CustomerDetail where CustomerDetailID=" & CustomerDetailID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
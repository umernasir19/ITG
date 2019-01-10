Imports System.Data.SqlClient
Imports System.Text
Imports System.Data

Namespace EuroCentra
    Public Class IMSSupplierCategory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SupplierDatabaseCategory"
            m_strPrimaryFieldName = "SupplierCategoryId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Dim m_lSupplierCategoryId As Long
        Dim m_strSupplierCategory As String
        Dim m_strSupplierCategoryShortName As String
        Public Property SupplierCategoryId() As Long
            Get
                SupplierCategoryId = m_lSupplierCategoryId
            End Get
            Set(ByVal Value As Long)
                m_lSupplierCategoryId = Value
            End Set
        End Property
        Public Property SupplierCategory() As String
            Get
                SupplierCategory = m_strSupplierCategory
            End Get
            Set(ByVal Value As String)
                m_strSupplierCategory = Value
            End Set
        End Property
        Public Property SupplierCategoryShortName() As String
            Get
                SupplierCategoryShortName = m_strSupplierCategoryShortName
            End Get
            Set(ByVal Value As String)
                m_strSupplierCategoryShortName = Value
            End Set
        End Property
        Public Function SaveIMSSupplierCategory()
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
        Public Function GetIMSSupplierCategorybyID(ByVal IMSSupplierCategoryId As Long)
            Dim Str As String
            Str = "select * from IMSSupplierCategory where IMSSupplierCategoryId=" & IMSSupplierCategoryId
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSSupplierCategory()
            Dim Str As String
            Str = " select * from IMSSupplierCategory "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal IMSSupplierCategoryId As Long)
            Dim Str As String
            Str = "Delete IMSSupplierCategory where IMSSupplierCategoryId=" & IMSSupplierCategoryId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
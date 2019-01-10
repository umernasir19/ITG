Imports System.Data

Namespace EuroCentra
    Public Class ProductCategories
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ProductCategories"
            m_strPrimaryFieldName = "ProductCategoriesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lProductCategoriesID As Long
        Private m_lProductPortfolioID As Long
        Private m_strProductCategories As String
        Private m_bIsActive As Boolean
        Public Property ProductCategoriesID() As Long
            Get
                ProductCategoriesID = m_lProductCategoriesID
            End Get
            Set(ByVal value As Long)
                m_lProductCategoriesID = value
            End Set
        End Property
        Public Property ProductPortfolioID() As Long
            Get
                ProductPortfolioID = m_lProductPortfolioID
            End Get
            Set(ByVal value As Long)
                m_lProductPortfolioID = value
            End Set
        End Property
        Public Property ProductCategories() As String
            Get
                ProductCategories = m_strProductCategories
            End Get
            Set(ByVal value As String)
                m_strProductCategories = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Function SaveProductCategories()
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
        Public Function GetAllProductCategories()
            Dim str As String
            Try
                str = " Select * from ProductCategories PC"
                str &= " join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID "
                str &= " order by PC.ProductCategoriesID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetExistProductCategories(ByVal ProductCategories As String, ByVal ProductPortfolioID As Long)
            Dim str As String
            Try
                str = " Select * from ProductCategories  "
                str &= " where ProductCategories='" & ProductCategories & "'  and  ProductPortfolioID='" & ProductPortfolioID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetEditProductCategoriesEntry(ByVal ProductCategoriesID As Long)
            Dim str As String
            Try
                str = "   Select * from ProductCategories  "
                str &= "  where ProductCategoriesID=" & ProductCategoriesID

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function

        Public Function deletepodtl(ByVal ProductCategoriesID As Long)
            Dim str As String
            Try
                str = " delete from ProductCategories where ProductCategoriesID='" & ProductCategoriesID & "' "

                ExecuteNonQuery(str)

            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
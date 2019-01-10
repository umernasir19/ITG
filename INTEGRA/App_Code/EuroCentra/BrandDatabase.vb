Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class BrandDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BrandDatabase"
            m_strPrimaryFieldName = "BrandDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBrandDatabaseID As Long
        Private m_dtCreationDate As Date
        Private m_lUmuserID As Long
        Private m_strBrand As String

        Public Property BrandDatabaseID() As Long
            Get
                BrandDatabaseID = m_lBrandDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lBrandDatabaseID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property UmuserID() As Long
            Get
                UmuserID = m_lUmuserID
            End Get
            Set(ByVal Value As Long)
                m_lUmuserID = Value
            End Set
        End Property

        Public Property Brand() As String
            Get
                Brand = m_strBrand
            End Get
            Set(ByVal Value As String)
                m_strBrand = Value
            End Set
        End Property
        Public Function saveBrandDatabase()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetBrandDatabaseID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductSpeciality() As DataTable
            Dim str As String
            str = " select * from FabricCatDatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllBrandForSizeRange() As DataTable
            Dim str As String
            str = " select BrandDatabaseId,Brand from BrandDatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandForJob() As DataTable
            Dim str As String
            str = " select distinct BD.BrandDatabaseId,BD.Brand from BrandDatabase BD"
            str &= " join StyleMasterDatabase SMD on SMD.BrandDatabaseID=BD.BrandDatabaseID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandDatabaseforView() As DataTable
            Dim str As String
            str = "  Select BD.*,U.UserName,convert(varchar,BD.CreationDate,103) as CreationDatee"
            str &= "  from BrandDatabase BD "
            str &= " join umuser U on u.userid=BD.UmuserID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandDataBaseForEdit(ByVal lBrandDatabaseID As Long) As DataTable
            Dim str As String
            str = "  Select BD.*,U.UserName,convert(varchar,BD.CreationDate,103) as CreationDatee"
            str &= " from BrandDatabase BD "
            str &= " join umuser U on u.userid=BD.UmuserID  "
            str &= "  where BrandDatabaseID=" & lBrandDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteBrandDatabase(ByVal lBrandDatabaseID As Long)
            Dim Str As String
            Str = " Delete from BrandDatabase where BrandDatabaseID=" & lBrandDatabaseID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerDatabaseView() As DataTable
            Dim str As String
            str = "select * from CustomerDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductPortfolio() As DataTable
            Dim str As String
            str = "Select * from ProductPortfolio where isactive=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategoriesAll() As DataTable
            Dim str As String
            str = "  Select * from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategoriesAllN() As DataTable
            Dim str As String
            str = "  Select * from ProductCategories PC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategories(ByVal ProductPortfolioID As Long) As DataTable
            Dim str As String
            str = "  Select * from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            str &= "  where PC.ProductPortfolioID =" & ProductPortfolioID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductType() As DataTable
            Dim str As String
            str = "Select * from ProductType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadCustomer(ByVal BrandDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select * from BrandDatabase BD"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=BD.CustomerDatabaseID"
            str &= " where BD.BrandDatabaseID=" & BrandDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSubStyle(ByVal CustomerDatabaseID As Long) As DataTable
            Dim str As String
            str &= " Select Distinct SM.SUBStyleNo from StyleMasterDatabase SMD"
            str &= " join StyleDetailDatabase SDD on SDD.StyleMasterDatabaseID=SMD.StyleMasterDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=SMD.BrandDatabaseID"
            str &= " join SizeRangeMaster SM on SM.SizeRangeMasterID=SDD.SizeRangeMasterID"
            str &= " where BD.CustomerDatabaseID =" & CustomerDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

Imports system.data
Imports microsoft.visualbasic
Namespace EuroCentra
    Public Class tblSupplierCategory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SupplierCategory"
            m_strPrimaryFieldName = "SupplierCategoryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSupplierCategoryID As Long
        Private m_strSupplierCategoryName As String

        Public Property SupplierCategoryID() As Long
            Get
                SupplierCategoryID = m_lSupplierCategoryID
            End Get
            Set(ByVal value As Long)
                m_lSupplierCategoryID = value
            End Set
        End Property
        Public Property SupplierCategoryName() As String
            Get
                SupplierCategoryName = m_strSupplierCategoryName
            End Get
            Set(ByVal value As String)
                m_strSupplierCategoryName = value
            End Set
        End Property
        Public Function SaveSupplierCategory()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllCategories()
            Dim Str As String
            Str = "  Select * from SupplierCategory "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
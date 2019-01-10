Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class StyleDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleDetail"
            m_strPrimaryFieldName = "StyleDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lStyleDetailID As Long
        Private m_lStyleID As Long
        Private m_ColorRefNo As String
        Private m_strColorway As String
        Private m_strSizeRange As String
        Private m_Sizes As String
        Private m_strPrice As Decimal
        Private m_PriceUnit As String
        Private m_BaseRow As String

        ''---------------- Properties
        Public Property StyleDetailID() As Long
            Get
                StyleDetailID = m_lStyleDetailID
            End Get
            Set(ByVal value As Long)
                m_lStyleDetailID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
            End Set
        End Property
        Public Property ColorRefNo() As String
            Get
                ColorRefNo = m_ColorRefNo
            End Get
            Set(ByVal value As String)
                m_ColorRefNo = value
            End Set
        End Property
        Public Property Colorway() As String
            Get
                Colorway = m_strColorway
            End Get
            Set(ByVal value As String)
                m_strColorway = value
            End Set
        End Property
        Public Property SizeRange() As String
            Get
                SizeRange = m_strSizeRange
            End Get
            Set(ByVal value As String)
                m_strSizeRange = value
            End Set
        End Property
        Public Property Sizes() As String
            Get
                Sizes = m_Sizes
            End Get
            Set(ByVal value As String)
                m_Sizes = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_strPrice
            End Get
            Set(ByVal value As Decimal)
                m_strPrice = value
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
        Public Property BaseRow() As String
            Get
                BaseRow = m_BaseRow
            End Get
            Set(ByVal value As String)
                m_BaseRow = value
            End Set
        End Property
 
        Public Function SaveStyleDetail()
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
        Public Function GetStyleById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleDetail(ByVal StyleSetailID As String, ByVal StyleID As String) As DataTable
            Dim str As String
            str = " Select * from StyleDetail  where  StyleDetailID='" & StyleSetailID & "' and StyleiD='" & StyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GelDetailSytleByStyleID(ByVal styleID As String)
            Dim Str As String
            Str = "select * from StyleDetailXML where Styleid = '" & styleID & "'"
            Try
                MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckArticleRepeat(ByVal StyleID As String, ByVal ArticleNo As String) As DataTable
            Dim str As String
            str = " select * from StyleDetail where Article='" & ArticleNo & "' and StyleID='" & StyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckStyleDetail(ByVal StyleDetailID As String) As DataTable
            Dim str As String
            str = "  Select * from Purchaseorderdetail  where StyleDetailID ='" & StyleDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal id As String) As DataTable
            Dim str As String
            str = " Delete from styleDetail where  StyleDetailID =" & id
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function DeleteDetailall(ByVal StyleID As String) As DataTable
            Dim str As String
            str = " Delete from styleDetail where  StyleID =" & StyleID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class D_Style
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "D_Style"
            m_strPrimaryFieldName = "DstyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lDstyleID As Long
        Private m_dtCreationDate As Date
        Private m_strStyle As String
        Private m_strCategory As String
        Private m_strDescription As String
        Private m_Image_Fornt As Object
        Private m_Image_Back As Object
        Private m_Image_Left As Object
        Private m_Image_Right As Object
        Private m_URL_Fornt As String
        Private m_URL_Back As String
        Private m_URL_Left As String
        Private m_URL_Right As String
        Private m_Thumbnail_Fornt As String
        Private m_Thumbnail_Back As String
        Private m_Thumbnail_Left As String
        Private m_Thumbnail_Right As String
        Private m_Thumbnail_Fornt_List As String
        Private m_Thumbnail_Back_List As String
        Private m_Thumbnail_Left_List As String
        Private m_Thumbnail_Right_List As String
        Private m_strMaterial As String
        Private m_Price As Decimal
        Private m_lCurrencyID As Long
        Private m_MOQ As Decimal

        Public Property DstyleID() As Long
            Get
                DstyleID = m_lDstyleID
            End Get
            Set(ByVal Value As Long)
                m_lDstyleID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property Category() As String
            Get
                Category = m_strCategory
            End Get
            Set(ByVal value As String)
                m_strCategory = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        Public Property Image_Fornt() As Object
            Get
                Image_Fornt = m_Image_Fornt
            End Get
            Set(ByVal value As Object)
                m_Image_Fornt = value
            End Set
        End Property
        Public Property Image_Back() As Object
            Get
                Image_Back = m_Image_Back
            End Get
            Set(ByVal value As Object)
                m_Image_Back = value
            End Set
        End Property
        Public Property Image_Left() As Object
            Get
                Image_Left = m_Image_Left
            End Get
            Set(ByVal value As Object)
                m_Image_Left = value
            End Set
        End Property
        Public Property Image_Right() As Object
            Get
                Image_Right = m_Image_Right
            End Get
            Set(ByVal value As Object)
                m_Image_Right = value
            End Set
        End Property
        Public Property URL_Fornt() As String
            Get
                URL_Fornt = m_URL_Fornt
            End Get
            Set(ByVal value As String)
                m_URL_Fornt = value
            End Set
        End Property
        Public Property URL_Back() As String
            Get
                URL_Back = m_URL_Back
            End Get
            Set(ByVal value As String)
                m_URL_Back = value
            End Set
        End Property
        Public Property URL_Left() As String
            Get
                URL_Left = m_URL_Left
            End Get
            Set(ByVal value As String)
                m_URL_Left = value
            End Set
        End Property
        Public Property URL_Right() As String
            Get
                URL_Right = m_URL_Right
            End Get
            Set(ByVal value As String)
                m_URL_Right = value
            End Set
        End Property
        Public Property Thumbnail_Fornt() As String
            Get
                Thumbnail_Fornt = m_Thumbnail_Fornt
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Fornt = value
            End Set
        End Property
        Public Property Thumbnail_Back() As String
            Get
                Thumbnail_Back = m_Thumbnail_Back
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Back = value
            End Set
        End Property
        Public Property Thumbnail_Left() As String
            Get
                Thumbnail_Left = m_Thumbnail_Left
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Left = value
            End Set
        End Property
        Public Property Thumbnail_Right() As String
            Get
                Thumbnail_Right = m_Thumbnail_Right
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Right = value
            End Set
        End Property
        Public Property Thumbnail_Fornt_List() As String
            Get
                Thumbnail_Fornt_List = m_Thumbnail_Fornt_List
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Fornt_List = value
            End Set
        End Property
        Public Property Thumbnail_Back_List() As String
            Get
                Thumbnail_Back_List = m_Thumbnail_Back_List
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Back_List = value
            End Set
        End Property
        Public Property Thumbnail_Left_List() As String
            Get
                Thumbnail_Left_List = m_Thumbnail_Left_List
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Left_List = value
            End Set
        End Property
        Public Property Thumbnail_Right_List() As String
            Get
                Thumbnail_Right_List = m_Thumbnail_Right_List
            End Get
            Set(ByVal value As String)
                m_Thumbnail_Right_List = value
            End Set
        End Property
        Public Property Material() As String
            Get
                Material = m_strMaterial
            End Get
            Set(ByVal value As String)
                m_strMaterial = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_Price
            End Get
            Set(ByVal Value As Decimal)
                m_Price = Value
            End Set
        End Property
        Public Property CurrencyID() As Long
            Get
                CurrencyID = m_lCurrencyID
            End Get
            Set(ByVal Value As Long)
                m_lCurrencyID = Value
            End Set
        End Property
        Public Property MOQ() As Decimal
            Get
                MOQ = m_MOQ
            End Get
            Set(ByVal Value As Decimal)
                m_MOQ = Value
            End Set
        End Property
        Public Function SaveD_Style()
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
        Public Function Show(ByVal DstyleID As Long)
            Dim str As String
            str = "  Select * from D_Style "
            str &= "  where DstyleID=" & DstyleID

            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ShowAll()
            Dim str As String
            str = "  Select * from D_Style "
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace
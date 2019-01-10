Imports System.Data

Namespace EuroCentra
    Public Class Brand
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Brand"
            m_strPrimaryFieldName = "BrandID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_BrandID As Long
        Private m_BrandName As String

        Public Property BrandID() As Long
            Get
                BrandID = m_BrandID
            End Get
            Set(ByVal Value As Long)
                m_BrandID = Value
            End Set
        End Property
        Public Property BrandName() As String
            Get
                BrandName = m_BrandName
            End Get
            Set(ByVal value As String)
                m_BrandName = value
            End Set
        End Property

        Public Function SaveBrand()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal BrandDatabaseID As Long)
            Dim Str As String
            Str = "select * from BrandDatabase where BrandDatabaseID = '" & BrandDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Brand  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllNew()
            Dim Str As String
            Str = "select * from BrandDatabase  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
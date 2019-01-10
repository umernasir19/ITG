Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class SizeDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SizeDatabase"
            m_strPrimaryFieldName = "SizeDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSizeDatabaseID As Long
        Private m_strSizes As String
        Private m_strRatio As Decimal
        Public Property SizeDatabaseID() As Long
            Get
                SizeDatabaseID = m_lSizeDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSizeDatabaseID = Value
            End Set
        End Property
        Public Property Sizes() As String
            Get
                Sizes = m_strSizes
            End Get
            Set(ByVal Value As String)
                m_strSizes = Value
            End Set
        End Property
        Public Property Ratio() As Decimal
            Get
                Ratio = m_strRatio
            End Get
            Set(ByVal Value As Decimal)
                m_strRatio = Value
            End Set
        End Property
        Public Function SaveSizeDatabase()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewAll() As DataTable
            Dim str As String
            str = " select * from SizeDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Delete(ByVal SizeDatabaseID As Long)
            Dim str As String
            str = " Delete from SizeDatabase where SizeDatabaseID=" & SizeDatabaseID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

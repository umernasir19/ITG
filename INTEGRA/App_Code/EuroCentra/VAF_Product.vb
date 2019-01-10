Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_Product
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_Product"
            m_strPrimaryFieldName = "VAF_ProductID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_ProductID As Long
        Private m_lVAFID As Long
        Private m_lProductID As Long
        Public Property VAF_ProductID() As Long
            Get
                VAF_ProductID = m_lVAF_ProductID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_ProductID = Value
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
        Public Property ProductID() As Long
            Get
                ProductID = m_lProductID
            End Get
            Set(ByVal Value As Long)
                m_lProductID = Value
            End Set
        End Property
        Public Function SaveVAF_Product()
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
        Public Function Delete(ByVal VAFID As Long)
            Dim Str As String
            Str = "Delete from VAF_Product  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
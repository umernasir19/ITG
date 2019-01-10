Imports Microsoft.VisualBasic
Imports System.Data
Public Class CommodityClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "Commodity"
        m_strPrimaryFieldName = "Commodityid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCommodityid As Long
    Private m_strCommodity As String


    Public Property Commodityid() As Long
        Get
            Commodityid = m_lCommodityid
        End Get
        Set(ByVal Value As Long)
            m_lCommodityid = Value
        End Set
    End Property
    Public Property Commodity() As String
        Get
            Commodity = m_strCommodity
        End Get
        Set(ByVal Value As String)
            m_strCommodity = Value
        End Set
    End Property
    
    Public Function save()
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
    Function DeleteDetail(ByVal CargoDetailID As Long)
        Dim Str As String
        Str = " Delete from CargoDetail where CargoDetailID=" & CargoDetailID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

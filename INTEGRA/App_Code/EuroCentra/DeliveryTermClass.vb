Imports Microsoft.VisualBasic
Imports System.Data
Public Class DeliveryTermClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "DeliveryTerm"
        m_strPrimaryFieldName = "DeliveryTermId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lDeliveryTermId As Long
    Private m_strDeliveryTerm As String

    Public Property DeliveryTermId() As Long
        Get
            DeliveryTermId = m_lDeliveryTermId
        End Get
        Set(ByVal Value As Long)
            m_lDeliveryTermId = Value
        End Set
    End Property
    Public Property DeliveryTerm() As String
        Get
            DeliveryTerm = m_strDeliveryTerm
        End Get
        Set(ByVal value As String)
            m_strDeliveryTerm = value
        End Set
    End Property
    Public Function Save()
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
End Class

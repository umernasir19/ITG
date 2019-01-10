Imports System.Data
Public Class IMSItemMaster
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "IMSItemMaster"
        m_strPrimaryFieldName = "IMSItemMasterId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lIMSItemMasterId As Long
 
    Private m_dtCreationDate As Date
    Private m_dCounter As Decimal
    '''''''''''''''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''''''''''''''''
    Public Property IMSItemMasterId() As Long
        Get
            IMSItemMasterId = m_lIMSItemMasterId
        End Get
        Set(ByVal value As Long)
            m_lIMSItemMasterId = value
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
    Public Property Counter() As Decimal
        Get
            Counter = m_dCounter
        End Get
        Set(ByVal value As Decimal)
            m_dCounter = value
        End Set
    End Property
    Public Function Save()
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
End Class

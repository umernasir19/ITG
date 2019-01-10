Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class PurchaseOrderOriginalShipmentDatehistory
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PurchaseOrderOriginalShipmentDatehistory"
        m_strPrimaryFieldName = "POOSDHID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPOOSDHID As Long
    Private m_lPOId As Long
    Private m_dtCreationDate As DateTime
    Public Property POOSDHID() As Long
        Get
            POOSDHID = m_lPOOSDHID
        End Get
        Set(ByVal Value As Long)
            m_lPOOSDHID = Value
        End Set
    End Property
    Public Property POID() As Long
        Get
            POID = m_lPOId
        End Get
        Set(ByVal Value As Long)
            m_lPOId = Value
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
    Public Function SavePurchaseOrderOriginalShipmentDateHistory()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class

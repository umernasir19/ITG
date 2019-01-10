Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Public Class POTracking
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "POTracking"
        m_strPrimaryFieldName = "PoTrackingID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lPoTrackingID As Long
    Private m_lPOId As Long
    Private m_dtCreationDate As Date
    Private m_strTrackingObject As String

    Public Property PoTrackingID() As Long
        Get
            PoTrackingID = m_lPoTrackingID
        End Get
        Set(ByVal value As Long)
            m_lPoTrackingID = value
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
    Public Property POID() As Long
        Get
            POID = m_lPOId
        End Get
        Set(ByVal Value As Long)
            m_lPOId = Value
        End Set
    End Property
    Public Property TrackingObject() As String
        Get
            TrackingObject = m_strTrackingObject
        End Get
        Set(ByVal value As String)
            m_strTrackingObject = value
        End Set
    End Property
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception
        End Try
    End Function
    Public Function SavePOTracking()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTrackingInfo(ByRef IPOID As Long)
        Dim str As String
        str = " select *, Convert(Varchar,Creationdate,103) as ActivityDate from POTracking where POID= '" & IPOID & "'"
        str &= " order by CreationDate ASC"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTrackingInfoAll()
        Dim str As String
        str = " select *, Convert(Varchar,PT.Creationdate,103) as ActivityDate, "
        str &= " (case when PO.Currency='Dollar' then '$ ' Else'€ ' end)+ Convert(varchar,(Select Isnull(SUM(Quantity * Rate),0) from PurchaseOrderDetail "
        str &= "  where POID =PO.POID)) as Amount , (Select Isnull(SUM(Quantity),0) from PurchaseOrderDetail "
        str &= "   where POID =PO.POID) as Qty "
        str &= "  from POTracking PT join Purchaseorder PO on PT.POID=PO.POID "
        str &= "  Join Vender V on PO.SupplierID=V.VenderLibraryID "
        str &= " Join Customer C on C.CustomerID=PO.Customerid   "
        str &= " join Umuser UM on UM.UserID=Po.MarchandID "
        str &= " order by PO.POID DESC,  PT.CreationDate ASC"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class

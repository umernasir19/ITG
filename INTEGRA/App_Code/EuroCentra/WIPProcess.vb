Imports System.Data
Imports Microsoft.VisualBasic

Public Class WIPProcess
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "WIPProcess"
        m_strPrimaryFieldName = "WIPProcessID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lWIPProcessID As Long
    Private m_strProcessName As String
    Private m_bIsActive As Boolean
    ''---------------- Properties
    Public Property WIPProcessID() As Long
        Get
            WIPProcessID = m_lWIPProcessID
        End Get
        Set(ByVal value As Long)
            m_lWIPProcessID = value
        End Set
    End Property
    Public Property ProcessName() As String
        Get
            ProcessName = m_strProcessName
        End Get
        Set(ByVal value As String)
            m_strProcessName = value
        End Set
    End Property
    Public Property IsActive() As Boolean
        Get
            IsActive = m_bIsActive
        End Get
        Set(ByVal value As Boolean)
            m_bIsActive = value
        End Set
    End Property

    Public Function SaveAccessories()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetWIPProcess() As DataTable
        Dim Str As String
        Str = "Select * from WIPProcess where IsActive='1'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetCurrentWIPProcess(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select Top 1 * from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= "  where WC.POID='" & POID & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function allOrder() As DataTable
        Dim Str As String
        '  Str = " select * from Purchaseorder where Year(CreationDate) >=2012"
        Str = "  select * from Purchaseorder where poid in ( "
        Str &= " select distinct POPOID as POID from cargodetail where popoid in ("
        Str &= " select Po.POID  from Purchaseorder PO"
        Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
        Str &= " Join Customer C on C.CustomerID=PO.Customerid    "
        Str &= "  where Year(PO.Shipmentdate) = 2012 "
        Str &= " and year(PO.Creationdate)< 2012))"

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

    Function GetWIPProcessForNewStyle() As DataTable
        Dim Str As String
        Str = "Select * from WIPProcess where IsActive='1'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetWIPProcessForRepeatStyle() As DataTable
        Dim Str As String
        Str = " Select * from WIPProcess where WIPProcessID in (5,6,7,8,9,10,11,12) "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
End Class

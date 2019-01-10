Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class BIInstMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BIInstMst"
        m_strPrimaryFieldName = "BIInstMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lBIInstMstID As Long
    Private m_lUserID As Long
    Private m_dtCreationDate As Date
    Private m_strBLNo As String
    Public Property BLNo() As String
        Get
            BLNo = m_strBLNo
        End Get
        Set(ByVal value As String)
            m_strBLNo = value
        End Set
    End Property
    Public Property BIInstMstID() As Long
        Get
            BIInstMstID = m_lBIInstMstID
        End Get
        Set(ByVal value As Long)
            m_lBIInstMstID = value
        End Set
    End Property
    Public Property UserID() As Long
        Get
            UserID = m_lUserID
        End Get
        Set(ByVal value As Long)
            m_lUserID = value
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
    Public Function Save()
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
    Public Function GetEditData(ByVal BIInstMstID As Long) As DataTable
        Dim str As String
        str = " select * from BiInstMst mst"
        str &= " join BIInstDtl dtl on dtl.BIInstMstID=mst.BIInstMstID "
        str &= " join Cargo c on c.CargoID =dtl.InvoiceID"
        str &= " where mst.BIInstMstID ='" & BIInstMstID & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceNo() As DataTable
        Dim str As String
        str = " Select * from Cargo "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetView() As DataTable
        Dim str As String
        str = "  select CONVERT(varchar,dtl.FormEDate ,103)as Datee,* from BiInstMst mst"
        str &= " join BIInstDtl dtl on dtl.BIInstMstID=mst.BIInstMstID "
        str &= " join Cargo c on c.CargoID =dtl.InvoiceID"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDatafrmCargoToStyleDes(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select *,cod.Quantity as qtyy,'0' as CargoStyleDtlID from Cargo co"
        str &= " join CargoDetail cod on cod.CargoID =co.CargoID "
        str &= " join Customer c on c.CustomerID =cod.CustomerID"
        str &= " where co.CargoID ='" & CargoID & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetLastNo()
        Dim str As String
        str = "  select Top 1 BLNo from BiInstMst  order By BiInstMstID DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDatafrmCargoStyleDtl(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select *,'0' as BIInstDtlID from CargoStyleDtl co"
       str &= " where co.CargoID ='" & CargoID & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDatafrmCargo(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select *,cod.Quantity as qtyy,'0' as BIInstDtlID,(select SUM(Quantity) from CargoDetail CDD where cdd.CargoID =co.CargoID ) as PCSS from Cargo co"
        str &= " join CargoDetail cod on cod.CargoID =co.CargoID "
        str &= " join Customer c on c.CustomerID =cod.CustomerID"
        str &= " where co.CargoID ='" & CargoID & "' "
    
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDatafrmCargoOnEdit(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select *,Style as Styles,PCS as qtyy from CargoStyleDtl "
        str &= " where CargoID ='" & CargoID & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceNo(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select * from Cargo "
        str &= " where CargoID ='" & CargoID & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class

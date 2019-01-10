Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class YeraltSummaryofwithheld
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempYeraltSummaryofwithheld"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strDepartment As String
        Private m_dcY1QTY As Decimal
        Private m_dcY1WITHHELD As Decimal
        Private m_dcY2QTY As Decimal
        Private m_dcY2WITHHELD As Decimal
        Private m_dcY3QTY As Decimal
        Private m_dcY3WITHHELD As Decimal
        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal value As Long)
                m_lTempId = value
            End Set
        End Property
        Public Property Department() As String
            Get
                Department = m_strDepartment
            End Get
            Set(ByVal value As String)
                m_strDepartment = value
            End Set
        End Property
        Public Property Y1QTY() As Decimal
            Get
                Y1QTY = m_dcY1QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcY1QTY = value
            End Set
        End Property
        Public Property Y1WITHHELD() As Decimal
            Get
                Y1WITHHELD = m_dcY1WITHHELD
            End Get
            Set(ByVal value As Decimal)
                m_dcY1WITHHELD = value
            End Set
        End Property
        Public Property Y2QTY() As Decimal
            Get
                Y2QTY = m_dcY2QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcY2QTY = value
            End Set
        End Property
        Public Property Y2WITHHELD() As Decimal
            Get
                Y2WITHHELD = m_dcY2WITHHELD
            End Get
            Set(ByVal value As Decimal)
                m_dcY2WITHHELD = value
            End Set
        End Property

        Public Property Y3QTY() As Decimal
            Get
                Y3QTY = m_dcY3QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcY3QTY = value
            End Set
        End Property
        Public Property Y3WITHHELD() As Decimal
            Get
                Y3WITHHELD = m_dcY3WITHHELD
            End Get
            Set(ByVal value As Decimal)
                m_dcY3WITHHELD = value
            End Set
        End Property
        Public Function SaveTempYeraltSummaryofwithheld()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDept(ByVal Customerid As String) As DataTable
            Dim Str As String
            Str = " select distinct(po.EkNumber) as Department from Cargo cr join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join PurchaseOrder po on po.POID=cd.POPOID where po.CustomerID='" & Customerid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12(ByVal Dept As String, ByVal Year As String) As DataTable
            Dim Str As String
            Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
            Str &= " where po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12New(ByVal Dept As String, ByVal Year As String, ByVal Customerid As String) As DataTable
            Dim Str As String
            Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
            Str &= " where po.CustomerID='" & Customerid & "' and po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12NewMonthWise(ByVal Dept As String, ByVal Year As String, ByVal Customerid As String, ByVal MonthOne As String, ByVal MonthTwo As String) As DataTable
            Dim Str As String
            Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
            Str &= " where po.CustomerID='" & Customerid & "' and po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "' and month(po.shipmentdate) between '" & MonthOne & "' and '" & MonthTwo & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12withHeld(ByVal Dept As String, ByVal Year As String) As DataTable
            Dim Str As String
            Str = " select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC JOIN PurchaseOrder PO ON PO.POID=PC.POID"
            Str &= " where po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12withHeldNew(ByVal Dept As String, ByVal Year As String, ByVal Customerid As String) As DataTable
            Dim Str As String
            Str = " select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC JOIN PurchaseOrder PO ON PO.POID=PC.POID"
            Str &= " where po.CustomerID='" & Customerid & "' and po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport12withHeldNewMonthWise(ByVal Dept As String, ByVal Year As String, ByVal Customerid As String, ByVal MonthOne As String, ByVal MonthTwo As String) As DataTable
            Dim Str As String
            Str = " select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC JOIN PurchaseOrder PO ON PO.POID=PC.POID"
            Str &= " where po.CustomerID='" & Customerid & "' and po.EKNumber='" & Dept & "' and year(po.shipmentdate)='" & Year & "' and month(po.shipmentdate) between '" & MonthOne & "' and '" & MonthTwo & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempYeraltSummaryofwithheld"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerForRpt()
            Dim str As String
            str = "  select Distinct PO.CustomerID,C.CustomerName from  PURCHASEORDER PO join Customer C on C.CustomerID=PO.CustomerID Order by C.CustomerName  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeptCustomerWise(ByVal CustomerId As Long)
            Dim str As String
            If CustomerId > 0 Then
                str = " select distinct EKNumber as BuyingDept from PURCHASEORDER where customerID='" & CustomerId & "' "
            Else
                str = " select distinct EKNumber as BuyingDept from PURCHASEORDER "
            End If

            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

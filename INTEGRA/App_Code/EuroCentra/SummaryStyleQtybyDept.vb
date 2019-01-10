Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class SummaryStyleQtybyDept
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempSummaryStyleQtybyDept"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strDepartment As String
        Private m_dcS1QTY As Decimal
        Private m_dcS1LINE As Decimal
        Private m_dcS2QTY As Decimal
        Private m_dcS2LINE As Decimal
        Private m_dcS3QTY As Decimal
        Private m_dcS3LINE As Decimal
        Private m_dcS4QTY As Decimal
        Private m_dcS4LINE As Decimal
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
        Public Property S1QTY() As Decimal
            Get
                S1QTY = m_dcS1QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcS1QTY = value
            End Set
        End Property
        Public Property S1LINE() As Decimal
            Get
                S1LINE = m_dcS1LINE
            End Get
            Set(ByVal value As Decimal)
                m_dcS1LINE = value
            End Set
        End Property
        Public Property S2QTY() As Decimal
            Get
                S2QTY = m_dcS2QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcS2QTY = value
            End Set
        End Property
        Public Property S2LINE() As Decimal
            Get
                S2LINE = m_dcS2LINE
            End Get
            Set(ByVal value As Decimal)
                m_dcS2LINE = value
            End Set
        End Property

        Public Property S3QTY() As Decimal
            Get
                S3QTY = m_dcS3QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcS3QTY = value
            End Set
        End Property
        Public Property S3LINE() As Decimal
            Get
                S3LINE = m_dcS3LINE
            End Get
            Set(ByVal value As Decimal)
                m_dcS3LINE = value
            End Set
        End Property
        Public Property S4QTY() As Decimal
            Get
                S4QTY = m_dcS4QTY
            End Get
            Set(ByVal value As Decimal)
                m_dcS4QTY = value
            End Set
        End Property
        Public Property S4LINE() As Decimal
            Get
                S4LINE = m_dcS4LINE
            End Get
            Set(ByVal value As Decimal)
                m_dcS4LINE = value
            End Set
        End Property
        
        Public Function SaveTempSummaryStyleQtybyDept()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDept() As DataTable
            Dim Str As String
            Str = " SELECT  distinct(po.EkNumber) as Department FROM PURCHASEORDER po   order by EkNumber"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport7(ByVal Dept As String, ByVal Season As String) As DataTable
            Dim Str As String
            Str = " Select count(distinct POD.styleid) as line ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID"
            Str &= " where    Po.Season ='" & Season & "' and po.EkNumber='" & Dept & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport7New(ByVal Dept As String, ByVal Season As String, ByVal Customer As String) As DataTable
            Dim Str As String

            Str = " Select count(distinct POD.styleid) as line ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " where    Po.Season ='" & Season & "' and po.EkNumber='" & Dept & "' and C.CustomerName='" & Customer & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempSummaryStyleQtybyDept"
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

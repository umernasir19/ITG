Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class tempKnittedVsWoven
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tempKnittedVsWoven"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strDepartment As String
        Private m_dcY1QTY As Decimal
        Private m_dcY1NoOfOrder As Decimal
        Private m_dcY1NoOfSupplier As Decimal
        Private m_dcY2QTY As Decimal
        Private m_dcY2NoOfOrder As Decimal
        Private m_dcY2NoOfSupplier As Decimal
        Private m_dcY3QTY As Decimal
        Private m_dcY3NoOfOrder As Decimal
        Private m_dcY3NoOfSupplier As Decimal
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
        Public Property Y1NoOfOrder() As Decimal
            Get
                Y1NoOfOrder = m_dcY1NoOfOrder
            End Get
            Set(ByVal value As Decimal)
                m_dcY1NoOfOrder = value
            End Set
        End Property
        Public Property Y1NoOfSupplier() As Decimal
            Get
                Y1NoOfSupplier = m_dcY1NoOfSupplier
            End Get
            Set(ByVal value As Decimal)
                m_dcY1NoOfSupplier = value
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
        Public Property Y2NoOfOrder() As Decimal
            Get
                Y2NoOfOrder = m_dcY2NoOfOrder
            End Get
            Set(ByVal value As Decimal)
                m_dcY2NoOfOrder = value
            End Set
        End Property
        Public Property Y2NoOfSupplier() As Decimal
            Get
                Y2NoOfSupplier = m_dcY2NoOfSupplier
            End Get
            Set(ByVal value As Decimal)
                m_dcY2NoOfSupplier = value
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
        Public Property Y3NoOfOrder() As Decimal
            Get
                Y3NoOfOrder = m_dcY3NoOfOrder
            End Get
            Set(ByVal value As Decimal)
                m_dcY3NoOfOrder = value
            End Set
        End Property
        Public Property Y3NoOfSupplier() As Decimal
            Get
                Y3NoOfSupplier = m_dcY3NoOfSupplier
            End Get
            Set(ByVal value As Decimal)
                m_dcY3NoOfSupplier = value
            End Set
        End Property

        Public Function SavetempKnittedVsWoven()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport13(ByVal Dept As String, ByVal Year As String) As DataTable
            Dim Str As String
            'Str = " Select count(distinct PO.SupplierID) as NoOfSupplier,count(distinct PO.POID) as NoOfOrder ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            'Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID"
            'Str &= " where    year(Po.shipmentDate) ='" & Year & "' and po.EkNumber='" & Dept & "'"

            Str = " Select count(distinct PO.SupplierID) as NoOfSupplier,count(distinct PO.MasterPO) as NoOfOrder ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID"
            Str &= " where    year(Po.shipmentDate) ='" & Year & "' and po.EkNumber='" & Dept & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport13Monthwise(ByVal Dept As String, ByVal Year As String, ByVal MonthOne As String, ByVal MonthTwo As String) As DataTable
            Dim Str As String
            'Str = " Select count(distinct PO.SupplierID) as NoOfSupplier,count(distinct PO.POID) as NoOfOrder ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            'Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID"
            'Str &= " where    year(Po.shipmentDate) ='" & Year & "' and  month(po.ShipmentDate) between '" & MonthOne & "' and '" & MonthTwo & "' and po.EkNumber='" & Dept & "'"

            Str = " Select count(distinct PO.SupplierID) as NoOfSupplier,count(distinct PO.MasterPO) as NoOfOrder ,isnull(sum(POD.Quantity),0) as Qty  from PurchaseOrder PO"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID"
            Str &= " where    year(Po.shipmentDate) ='" & Year & "' and  month(po.ShipmentDate) between '" & MonthOne & "' and '" & MonthTwo & "' and po.EkNumber='" & Dept & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  tempKnittedVsWoven"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

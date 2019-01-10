Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class TempNoofOrderAndQtyPlacedWithVen
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempNoofOrderAndQtyPlacedWithVen"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        Private m_strSupplier As String
        Private m_dcY1NoOforder As Decimal
        Private m_dcY1OrderQty As Decimal
        Private m_dcY1NoofLines As Decimal
        Private m_dcY2NoOforder As Decimal
        Private m_dcY2OrderQty As Decimal
        Private m_dcY2NoofLines As Decimal
        Private m_dcY3NoOforder As Decimal
        Private m_dcY3OrderQty As Decimal
        Private m_dcY3NoofLines As Decimal

        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal value As Long)
                m_lTempId = value
            End Set
        End Property
        Public Property Supplier() As String
            Get
                Supplier = m_strSupplier
            End Get
            Set(ByVal value As String)
                m_strSupplier = value
            End Set
        End Property
        Public Property Y1NoOforder() As Decimal
            Get
                Y1NoOforder = m_dcY1NoOforder
            End Get
            Set(ByVal value As Decimal)
                m_dcY1NoOforder = value
            End Set
        End Property
        Public Property Y1OrderQty() As Decimal
            Get
                Y1OrderQty = m_dcY1OrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dcY1OrderQty = value
            End Set
        End Property
        Public Property Y1NoofLines() As Decimal
            Get
                Y1NoofLines = m_dcY1NoofLines
            End Get
            Set(ByVal value As Decimal)
                m_dcY1NoofLines = value
            End Set
        End Property

        Public Property Y2NoOforder() As Decimal
            Get
                Y2NoOforder = m_dcY2NoOforder
            End Get
            Set(ByVal value As Decimal)
                m_dcY2NoOforder = value
            End Set
        End Property
        Public Property Y2OrderQty() As Decimal
            Get
                Y2OrderQty = m_dcY2OrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dcY2OrderQty = value
            End Set
        End Property
        Public Property Y2NoofLines() As Decimal
            Get
                Y2NoofLines = m_dcY2NoofLines
            End Get
            Set(ByVal value As Decimal)
                m_dcY2NoofLines = value
            End Set
        End Property

        Public Property Y3NoOforder() As Decimal
            Get
                Y3NoOforder = m_dcY3NoOforder
            End Get
            Set(ByVal value As Decimal)
                m_dcY3NoOforder = value
            End Set
        End Property
        Public Property Y3OrderQty() As Decimal
            Get
                Y3OrderQty = m_dcY3OrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dcY3OrderQty = value
            End Set
        End Property
        Public Property Y3NoofLines() As Decimal
            Get
                Y3NoofLines = m_dcY3NoofLines
            End Get
            Set(ByVal value As Decimal)
                m_dcY3NoofLines = value
            End Set
        End Property
        Public Function SaveTempOrderDisKnittedItemsbyVendor()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempNoofOrderAndQtyPlacedWithVen"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVender() As DataTable
            Dim Str As String
            Str = " SELECT  distinct Supplierid ,V.VenderName "
            Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid"
            Str &= " order by V.VenderName "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport3(ByVal Year As String, ByVal Supplierid As String) As DataTable
            Dim Str As String
            Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
            Str &= " FROM PURCHASEORDER po"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport3New(ByVal Year As String, ByVal Supplierid As String, ByVal BuyingDept As String, ByVal CustomerID As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerID & "' "

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerID & "' "

            Else
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerID & "' and PO.EkNumber='" & BuyingDept & "' "

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerID & "' and PO.EkNumber='" & BuyingDept & "' "

            End If
          
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReportCustomerWise(ByVal BuyingDept As String, ByVal CustomerID As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where  PO.CustomerID='" & CustomerID & "'"
            Else
                Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,COUNT(DISTINCT POD.styleiD) AS NoofLines"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where PO.EkNumber='" & BuyingDept & "' AND PO.CustomerID='" & CustomerID & "'"
            End If
           

            Try
                Return MyBase.GetDataTable(Str)
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

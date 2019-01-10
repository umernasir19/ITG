Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class TempOrderDisWovenItemsbyVendor
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempOrderDisWovenItemsbyVendor"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        Private m_strSupplier As String
        Private m_dcY1NoOforder As Decimal
        Private m_dcY1OrderQty As Decimal

        Private m_dcY2NoOforder As Decimal
        Private m_dcY2OrderQty As Decimal

        Private m_dcY3NoOforder As Decimal
        Private m_dcY3OrderQty As Decimal

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

        Public Function SaveTempOrderDisWovenItemsbyVendor()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempOrderDisWovenItemsbyVendor"
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
        Public Function GetVenderNew(ByVal customerid As String, ByVal EKNumber As String) As DataTable
            Dim Str As String
            If EKNumber = "All" Then
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid where po.customerid='" & customerid & "'  "
                Str &= " order by V.VenderName "
            Else
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid where po.customerid='" & customerid & "' and po.EKNumber='" & EKNumber & "'"
                Str &= " order by V.VenderName "
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1(ByVal Year As String, ByVal Supplierid As String) As DataTable
            Dim Str As String
            Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
            Str &= " FROM PURCHASEORDER po"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1New(ByVal Year As String, ByVal Supplierid As String, ByVal customerid As String, ByVal EKNumber As String) As DataTable
            Dim Str As String
            If EKNumber = "All" Then
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "'   and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                'Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                'Str &= " where PO.POID=POD.POID)='Woven Apparels'"

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "'   and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                Str &= " where PO.POID=POD.POID)='Woven Apparels'"
            Else
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and po.EKNumber='" & EKNumber & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                'Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                'Str &= " where PO.POID=POD.POID)='Woven Apparels'"

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and po.EKNumber='" & EKNumber & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                Str &= " where PO.POID=POD.POID)='Woven Apparels'"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1NewMonthWise(ByVal Year As String, ByVal Supplierid As String, ByVal customerid As String, ByVal EKNumber As String, ByVal Monthone As String, ByVal MonthTwo As String) As DataTable
            Dim Str As String
            If EKNumber = "All" Then
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' and Month(po.ShipmentDate) between '" & Monthone & "' and '" & MonthTwo & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                'Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                'Str &= " where PO.POID=POD.POID)='Woven Apparels'"

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' and Month(po.ShipmentDate) between '" & Monthone & "' and '" & MonthTwo & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                Str &= " where PO.POID=POD.POID)='Woven Apparels'"
            Else
                'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' and Month(po.ShipmentDate) between '" & Monthone & "' and '" & MonthTwo & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and po.EKNumber='" & EKNumber & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                'Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                'Str &= " where PO.POID=POD.POID)='Woven Apparels'"

                Str = " SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' and Month(po.ShipmentDate) between '" & Monthone & "' and '" & MonthTwo & "' AND PO.Supplierid='" & Supplierid & "' and po.customerid='" & customerid & "' and po.EKNumber='" & EKNumber & "' and  (Select top 1 ProductPortfolio from  PurchaseOrderDetail POD "
                Str &= " join StyleProductInformation sp on  sp.StyleID=POD.StyleID  join ProductPortfolio pp on pp.ProductPortfolioid=sp.ProductPortfolioid "
                Str &= " where PO.POID=POD.POID)='Woven Apparels'"
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



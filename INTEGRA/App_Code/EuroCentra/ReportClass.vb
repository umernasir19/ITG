Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class ReportClass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempOrderDisByFabric"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        Private m_strFabricType As String
        Private m_dcY1NoOforder As Decimal
        Private m_dcY1OrderQty As Decimal
        Private m_dcY1PerTotal As Decimal
        Private m_dcY2NoOforder As Decimal
        Private m_dcY2OrderQty As Decimal
        Private m_dcY2PerTotal As Decimal
        Private m_dcY3NoOforder As Decimal
        Private m_dcY3OrderQty As Decimal
        Private m_dcY3PerTotal As Decimal
        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal value As Long)
                m_lTempId = value
            End Set
        End Property
        Public Property FabricType() As String
            Get
                FabricType = m_strFabricType
            End Get
            Set(ByVal value As String)
                m_strFabricType = value
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
        Public Property Y1PerTotal() As Decimal
            Get
                Y1PerTotal = m_dcY1PerTotal
            End Get
            Set(ByVal value As Decimal)
                m_dcY1PerTotal = value
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
        Public Property Y2PerTotal() As Decimal
            Get
                Y2PerTotal = m_dcY2PerTotal
            End Get
            Set(ByVal value As Decimal)
                m_dcY2PerTotal = value
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
        Public Property Y3PerTotal() As Decimal
            Get
                Y3PerTotal = m_dcY3PerTotal
            End Get
            Set(ByVal value As Decimal)
                m_dcY3PerTotal = value
            End Set
        End Property
        Public Function SaveTempOrderDisByFabric()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempOrderDisByFabric"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabric() As DataTable
            Dim Str As String
            'Str = " SELECT  distinct(ft.FabricType) FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " JOIN StyleProductInformation sp ON  sP.StyleID=pod.StyleID"
            'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID"
            'Str &= " order by FabricType"

            Str = " SELECT distinct (select top 1  FabricType  from StyleProductInformation sP "
            Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType "
            Str &= " FROM PURCHASEORDER po JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport8(ByVal Year As String, ByVal Fabric As String, ByVal startmonth As Long, ByVal endmonth As Long) As DataTable
            Dim Str As String
            'Str = " SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,ft.FabricType"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " JOIN StyleProductInformation sp ON  sP.StyleID=pod.StyleID"
            'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID"
            'Str &= " where year(po.ShipmentDate)='" & Year & "' AND ft.FabricType='" & Fabric & "'"
            'Str &= " GROUP BY ft.FabricType"

            Str = "    SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,"
            Str &= " (select top 1  FabricType  from StyleProductInformation sP "
            Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType"
            Str &= " FROM PURCHASEORDER po"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Str &= " where year(po.ShipmentDate)='" & Year & "' and  month(po.ShipmentDate) between '" & startmonth & "' and '" & endmonth & "' and"
            Str &= " (select top 1  FabricType  from StyleProductInformation sP "
            Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID)='" & Fabric & "'"
            Str &= " GROUP BY pod.StyleID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport8New(ByVal Year As String, ByVal Fabric As String, ByVal startmonth As Long, ByVal endmonth As Long, ByVal Customer As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                'Str = "    SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,"
                'Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID join Customer C on PO.CustomerID=C.CustomerID "
                'Str &= " where year(po.ShipmentDate)='" & Year & "' and  month(po.ShipmentDate) between '" & startmonth & "' and '" & endmonth & "' and C.CustomerName='" & Customer & "' and"
                'Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID)='" & Fabric & "'"
                'Str &= " GROUP BY pod.StyleID"

                Str = "    SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,"
                Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID join Customer C on PO.CustomerID=C.CustomerID "
                Str &= " where year(po.ShipmentDate)='" & Year & "' and  month(po.ShipmentDate) between '" & startmonth & "' and '" & endmonth & "' and C.CustomerName='" & Customer & "' and"
                Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID)='" & Fabric & "'"
                Str &= " GROUP BY pod.StyleID"
            Else
                'Str = "    SELECT COUNT(DISTINCT po.poiD) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,"
                'Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType"
                'Str &= " FROM PURCHASEORDER po"
                'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID join Customer C on PO.CustomerID=C.CustomerID"
                'Str &= " where year(po.ShipmentDate)='" & Year & "' and  month(po.ShipmentDate) between '" & startmonth & "' and '" & endmonth & "'  and C.CustomerName='" & Customer & "' and PO.EKNumber='" & BuyingDept & "' and"
                'Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                'Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID)='" & Fabric & "'"
                'Str &= " GROUP BY pod.StyleID"

                Str = "    SELECT COUNT(DISTINCT po.MasterPO) AS NoOfOrder, isnull(sum (POD.Quantity),0) as OrderQty,"
                Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID) as FabricType"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " where year(po.ShipmentDate)='" & Year & "' and  month(po.ShipmentDate) between '" & startmonth & "' and '" & endmonth & "'  and C.CustomerName='" & Customer & "' and PO.EKNumber='" & BuyingDept & "' and"
                Str &= " (select top 1  FabricType  from StyleProductInformation sP "
                Str &= " join FabricType ft on ft.FabricTypeID=sp.FabricTypeID where sP.StyleID=pod.StyleID)='" & Fabric & "'"
                Str &= " GROUP BY pod.StyleID"
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

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class TempSummaryOfWorkLoadCustomerWise
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempSummaryOfWorkLoadCustomerWise"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        'Private m_strSupplier As String
        Private m_strCustomerName As String
        Private m_dcNoOfLines As Decimal
        Private m_dcNoOforder As Decimal
        Private m_dcOrderQty As Decimal
        Private m_dcOrderQtyInPcs As Decimal
        Private m_dcShippedOrderQty As Decimal
        Private m_dcShippedOrderQtyInPcs As Decimal

        Private m_dcOrderQtyM1 As Decimal
        Private m_dcOrderQtyInPcsM1 As Decimal
        Private m_dcOrderQtyM2 As Decimal
        Private m_dcOrderQtyInPcsM2 As Decimal

        Private m_dcShippedOrderQtyM1 As Decimal
        Private m_dcShippedOrderQtyInPcsM1 As Decimal
        Private m_dcShippedOrderQtyM2 As Decimal
        Private m_dcShippedOrderQtyInPcsM2 As Decimal

        Public Property ShippedOrderQtyInPcsM2() As Decimal
            Get
                ShippedOrderQtyInPcsM2 = m_dcShippedOrderQtyInPcsM2
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQtyInPcsM2 = value
            End Set
        End Property

        Public Property ShippedOrderQtyM2() As Decimal
            Get
                ShippedOrderQtyM2 = m_dcShippedOrderQtyM2
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQtyM2 = value
            End Set
        End Property

        Public Property ShippedOrderQtyInPcsM1() As Decimal
            Get
                ShippedOrderQtyInPcsM1 = m_dcShippedOrderQtyInPcsM1
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQtyInPcsM1 = value
            End Set
        End Property

        Public Property ShippedOrderQtyM1() As Decimal
            Get
                ShippedOrderQtyM1 = m_dcShippedOrderQtyM1
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQtyM1 = value
            End Set
        End Property

        Public Property OrderQtyM1() As Decimal
            Get
                OrderQtyM1 = m_dcOrderQtyM1
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQtyM1 = value
            End Set
        End Property
        Public Property OrderQtyM2() As Decimal
            Get
                OrderQtyM2 = m_dcOrderQtyM2
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQtyM2 = value
            End Set
        End Property

        Public Property OrderQtyInPcsM1() As Decimal
            Get
                OrderQtyInPcsM1 = m_dcOrderQtyInPcsM1
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQtyInPcsM1 = value
            End Set
        End Property
        Public Property OrderQtyInPcsM2() As Decimal
            Get
                OrderQtyInPcsM2 = m_dcOrderQtyInPcsM2
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQtyInPcsM2 = value
            End Set
        End Property

        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal value As Long)
                m_lTempId = value
            End Set
        End Property
        Public Property CustomerName() As String
            Get
                CustomerName = m_strCustomerName
            End Get
            Set(ByVal value As String)
                m_strCustomerName = value
            End Set
        End Property
        Public Property NoOfLines() As Decimal
            Get
                NoOfLines = m_dcNoOfLines
            End Get
            Set(ByVal value As Decimal)
                m_dcNoOfLines = value
            End Set
        End Property
        Public Property NoOforder() As Decimal
            Get
                NoOforder = m_dcNoOforder
            End Get
            Set(ByVal value As Decimal)
                m_dcNoOforder = value
            End Set
        End Property
        Public Property OrderQty() As Decimal
            Get
                OrderQty = m_dcOrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQty = value
            End Set
        End Property
        Public Property OrderQtyInPcs() As Decimal
            Get
                OrderQtyInPcs = m_dcOrderQtyInPcs
            End Get
            Set(ByVal value As Decimal)
                m_dcOrderQtyInPcs = value
            End Set
        End Property


        Public Property ShippedOrderQty() As Decimal
            Get
                ShippedOrderQty = m_dcShippedOrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQty = value
            End Set
        End Property
        Public Property ShippedOrderQtyInPcs() As Decimal
            Get
                ShippedOrderQtyInPcs = m_dcShippedOrderQtyInPcs
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedOrderQtyInPcs = value
            End Set
        End Property

        Public Function saveTempSummaryOfWorkLoadCustomerWise()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempSummaryOfWorkLoadCustomerWise"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVender(ByVal startdate As String, ByVal Enddate As String, ByVal SEASON As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String

            'If supplieridd <> 0 Then
            If SEASON = "All" And BuyingDept = "All" Then
                Str = "  SELECT distinct  CustomerName,PO.CustomerID,Aliass as CustomerFullNAME  "
                Str &= " FROM PURCHASEORDER po JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID "
                Str &= " join Customer V on V.CustomerID=PO.CustomerID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID "
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' order by CustomerName "

            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = "  SELECT distinct  CustomerName,PO.CustomerID ,Aliass as CustomerFullNAME "
                Str &= " FROM PURCHASEORDER po JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID "
                Str &= " join Customer V on V.CustomerID=PO.CustomerID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID "
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= "  eknumber='" & BuyingDept & "'  order by CustomerName "
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = "  SELECT distinct  CustomerName,PO.CustomerID  "
                Str &= " FROM PURCHASEORDER po JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID "
                Str &= " join Customer V on V.CustomerID=PO.CustomerID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID "
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "'  order by CustomerName "
            Else
                Str = "  SELECT distinct  CustomerName,PO.CustomerID ,Aliass as CustomerFullNAME "
                Str &= " FROM PURCHASEORDER po JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID "
                Str &= " join Customer V on V.CustomerID=PO.CustomerID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID "
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'  order by CustomerName "
            End If
            'Else
            'If SEASON = "All" And BuyingDept = "All" Then
            '    Str = " SELECT distinct  VenderName,PO.Supplierid "
            '    Str &= " FROM PURCHASEORDER po"
            '    Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            '    Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            '    Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            '    Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' "

            'ElseIf SEASON = "All" And BuyingDept <> "All" Then
            '    Str = " SELECT distinct  VenderName,PO.Supplierid "
            '    Str &= " FROM PURCHASEORDER po"
            '    Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            '    Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            '    Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            '    Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            '    Str &= "  eknumber='" & BuyingDept & "'"
            'ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
            '    Str = " SELECT distinct  VenderName,PO.Supplierid "
            '    Str &= " FROM PURCHASEORDER po"
            '    Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            '    Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            '    Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            '    Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            '    Str &= " Season='" & SEASON & "' "
            'Else
            '    Str = " SELECT distinct  VenderName,PO.Supplierid "
            '    Str &= " FROM PURCHASEORDER po"
            '    Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            '    Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            '    Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            '    Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            '    Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'"
            'End If
            'End If

            'Str = " SELECT distinct  VenderName,PO.Supplierid "
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummary(ByVal startdate As String, ByVal Enddate As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal customerId As Long) As DataTable
            Dim Str As String
            'Str = "  SELECT POD.POID,POD.STYLEID,POD.Quantity*SM.QtyPack as OrderQtyInPcs ,POD.Quantity as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"
            If SEASON = "All" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and PO.CustomerID='" & customerId & "' "
                ' Str &= "    PO.Supplierid='" & Supplierid & "'  "
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and "
                Str &= "   eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerId & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "'  and PO.CustomerID='" & customerId & "' "
            Else
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "' and   eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerId & "'"

            End If
            'Str = "  SELECT isnull(count(distinct PO.POID),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
            'Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummarySHIPPED(ByVal startdate As String, ByVal Enddate As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal CustomerID As Long) As DataTable
            Dim Str As String
            If SEASON = "All" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and PO.CustomerID='" & customerID & "' "
                'Str &= "   PO.Supplierid='" & Supplierid & "'"
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and "
                Str &= "   eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerID & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "' and PO.CustomerID='" & customerID & "'  "

            Else
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerID & "'"

            End If
            'Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
            'Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            'Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'and  PO.Supplierid='" & Supplierid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummaryForMonth1(ByVal Month1 As String, ByVal Year As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal customerid As Long) As DataTable
            Dim Str As String
            'Str = "  SELECT POD.POID,POD.STYLEID,POD.Quantity*SM.QtyPack as OrderQtyInPcs ,POD.Quantity as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"
            If SEASON = "All" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM1 ,isnull(sum(POD.Quantity),0) as OrderQtyM1 "
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  Month(po.ShipmentDate) ='" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "' and PO.CustomerID='" & customerid & "' "
                'Str &= "    PO.Supplierid='" & Supplierid & "'  "
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM1 ,isnull(sum(POD.Quantity),0) as OrderQtyM1"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  Month(po.ShipmentDate) ='" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "'  "
                Str &= "  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM1 ,isnull(sum(POD.Quantity),0) as OrderQtyM1"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  Month(po.ShipmentDate) ='" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "'  and "
                Str &= " Season='" & SEASON & "' and PO.CustomerID='" & customerid & "'  "
            Else
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM1 ,isnull(sum(POD.Quantity),0) as OrderQtyM1"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  Month(po.ShipmentDate) ='" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "'  and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"

            End If
            'Str = "  SELECT isnull(count(distinct PO.POID),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
            'Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummarySHIPPEDMonth1(ByVal Month1 As String, ByVal Year As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal customerid As Long) As DataTable
            Dim Str As String
            If SEASON = "All" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM1 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM1 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "' and PO.CustomerID='" & customerid & "' "
                'Str &= "   PO.Supplierid='" & Supplierid & "'"
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM1 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM1 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "' and "
                Str &= "   eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM1 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM1 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "' and "
                Str &= " Season='" & SEASON & "' and PO.CustomerID='" & customerid & "'  "

            Else
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM1 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM1 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month1 & "' and Year(po.ShipmentDate)='" & Year & "'  and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"

            End If
            'Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
            'Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            'Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'and  PO.Supplierid='" & Supplierid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummaryForMonth2(ByVal Month2 As String, ByVal Year As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal customerid As Long) As DataTable
            Dim Str As String
            'Str = "  SELECT POD.POID,POD.STYLEID,POD.Quantity*SM.QtyPack as OrderQtyInPcs ,POD.Quantity as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"
            If SEASON = "All" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM2 ,isnull(sum(POD.Quantity),0) as OrderQtyM2"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  Month(po.ShipmentDate) ='" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and PO.CustomerID='" & customerid & "' "
                'Str &= "    PO.Supplierid='" & Supplierid & "'  "
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM2 ,isnull(sum(POD.Quantity),0) as OrderQtyM2"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where Month(po.ShipmentDate) ='" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and PO.CustomerID='" & customerid & "' "
                Str &= "   and eknumber='" & BuyingDept & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM2 ,isnull(sum(POD.Quantity),0) as OrderQtyM2"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where Month(po.ShipmentDate) ='" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "'  and "
                Str &= " Season='" & SEASON & "' and PO.CustomerID='" & customerid & "' "
            Else
                Str = "  SELECT isnull(count(distinct PO.Masterpo),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcsM2 ,isnull(sum(POD.Quantity),0) as OrderQtyM2"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where Month(po.ShipmentDate) ='" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"

            End If
            'Str = "  SELECT isnull(count(distinct PO.POID),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
            'Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforWorkLoadSummarySHIPPEDMonth2(ByVal Month2 As String, ByVal Year As String, ByVal SEASON As String, ByVal BuyingDept As String, ByVal customerid As Long) As DataTable
            Dim Str As String
            If SEASON = "All" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM2 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM2 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and PO.CustomerID='" & customerid & "' "
                'Str &= "   PO.Supplierid='" & Supplierid & "'"
            ElseIf SEASON = "All" And BuyingDept <> "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM2 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM2 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and "
                Str &= "   eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"
            ElseIf SEASON <> "ALL" And BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM2 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM2 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "'  and "
                Str &= " Season='" & SEASON & "' and PO.CustomerID='" & customerid & "'  "

            Else
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcsM2 ,isnull(sum(cd.Quantity),0) as ShippedOrderQtyM2 from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where  month(po.ShipmentDate)= '" & Month2 & "' and Year(po.ShipmentDate)='" & Year & "' and "
                Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "' and PO.CustomerID='" & customerid & "'"

            End If
            'Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
            'Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            'Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "'  and eknumber='" & BuyingDept & "'and  PO.Supplierid='" & Supplierid & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class TempQcWiseload
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempQcWiseload"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        Private m_strSupplier As String
        Private m_dcNoOfLines As Decimal
        Private m_dcNoOforder As Decimal
        Private m_dcOrderQty As Decimal
        Private m_dcOrderQtyInPcs As Decimal
        Private m_dcShippedOrderQty As Decimal
        Private m_dcShippedOrderQtyInPcs As Decimal
        Private m_strQANAME As String


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
        Public Property QANAME() As String
            Get
                QANAME = m_strQANAME
            End Get
            Set(ByVal value As String)
                m_strQANAME = value
            End Set
        End Property
        Public Function saveTempSummaryOfWorkLoad()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempQcWiseload"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVender(ByVal startdate As String, ByVal Enddate As String, ByVal Buyingdept As String) As DataTable
            Dim Str As String


            Str = " SELECT distinct  VenderName,PO.Supplierid "
            Str &= " FROM PURCHASEORDER po"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and PO.EKNumber='" & Buyingdept & "' "

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
        Public Function GetVenderNew(ByVal startdate As String, ByVal Enddate As String, ByVal Buyingdept As String, ByVal CustomerID As Long) As DataTable
            Dim Str As String

            If Buyingdept = "All" Then
                Str = " SELECT distinct  VenderName,PO.Supplierid "
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and PO.CustomerID='" & CustomerID & "' "

            Else
                Str = " SELECT distinct  VenderName,PO.Supplierid "
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and PO.EKNumber='" & Buyingdept & "' and PO.CustomerID='" & CustomerID & "' "

            End If

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
        Public Function getdataforWorkLoadSummary(ByVal startdate As String, ByVal Enddate As String, ByVal Supplierid As String) As DataTable
            Dim Str As String
            'Str = "  SELECT POD.POID,POD.STYLEID,POD.Quantity*SM.QtyPack as OrderQtyInPcs ,POD.Quantity as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"

            Str = "  SELECT isnull(count(distinct PO.POID),0) as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
            Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
            Str &= " FROM PURCHASEORDER po"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and  PO.Supplierid='" & Supplierid & "'  "


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
        Public Function getdataforWorkLoadSummaryNew(ByVal startdate As String, ByVal Enddate As String, ByVal Supplierid As String, ByVal BuyingDept As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String
            'Str = "  SELECT POD.POID,POD.STYLEID,POD.Quantity*SM.QtyPack as OrderQtyInPcs ,POD.Quantity as OrderQty"
            'Str &= " FROM PURCHASEORDER po"
            'Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
            'Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            'Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' AND po.customerid='" & Customerid & "' and "
            'Str &= " Season='" & SEASON & "' and  PO.Supplierid='" & Supplierid & "' and eknumber='" & BuyingDept & "'"
            If BuyingDept = "All" Then
                Str = "  SELECT isnull(count(distinct PO.MasterPO),'N/A') as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and  PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerId & "' "
            Else
                Str = "  SELECT isnull(count(distinct PO.MasterPO),'N/A') as Nooforder,isnull(count(distinct POD.STYLEID),0) as Nooflines,"
                Str &= " isnull(sum(POD.Quantity*SM.QtyPack),0) as OrderQtyInPcs ,isnull(sum(POD.Quantity),0) as OrderQty"
                Str &= " FROM PURCHASEORDER po"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "'  and  PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerId & "' and PO.EKNumber='" & BuyingDept & "' "

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
        Public Function getdataforWorkLoadSummarySHIPPED(ByVal startdate As String, ByVal Enddate As String, ByVal Supplierid As String) As DataTable
            Dim Str As String

            Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
            Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
            Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
            Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
            Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and  PO.Supplierid='" & Supplierid & "'"


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
        Public Function getdataforWorkLoadSummarySHIPPEDNew(ByVal startdate As String, ByVal Enddate As String, ByVal Supplierid As String, ByVal BuyingDept As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String
            If BuyingDept = "All" Then
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and  PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerId & "'"
            Else
                Str = " select isnull(sum(cd.Quantity*SM.QtyPack),0) as ShippedOrderQtyInPcs ,isnull(sum(cd.Quantity),0) as ShippedOrderQty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= "  join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " JOIN PurchaseOrderDetail POD ON PO.POID=POD.POID and POD.PoDetailId=cd.POID"
                Str &= " Join StyleMaster SM ON SM.STYLEID=POD.STYLEID"
                Str &= " where po.ShipmentDate between '" & startdate & "' and '" & Enddate & "' and  PO.Supplierid='" & Supplierid & "' and PO.CustomerID='" & CustomerId & "' and PO.EKNumber='" & BuyingDept & "'"

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
        Public Function getdataqa(ByVal startdate As String, ByVal Enddate As String, ByVal Supplierid As String) As DataTable
            Dim Str As String

            Str = " select dISTINCT QANAME from QAProfileMST qm "
            Str &= " join QAProfileDtl qd on qm.QAMstId=qd.QAMstId"
            Str &= " where STARTDATEQA BETWEEN '" & startdate & "' AND '" & Enddate & "' AND FactoryID='" & Supplierid & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

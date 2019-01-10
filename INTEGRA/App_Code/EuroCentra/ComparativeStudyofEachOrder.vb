Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class ComparativeStudyofEachOrder
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempComparativeStudyofEachOrder"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lTempId As Long
        Private m_strSupplier As String
        Private m_strRYear As String
        Private m_dcC1 As Decimal
        Private m_dcC2 As Decimal

        Private m_dcC3 As Decimal
        Private m_dcC4 As Decimal

        Private m_dcC5 As Decimal
        Private m_dcC6 As Decimal
        Private m_dcC7 As Decimal
        Private m_dcC8 As Decimal

        Private m_dcC9 As Decimal
        Private m_dcC10 As Decimal

        Private m_dcC11 As Decimal
        Private m_dcC12 As Decimal

        Private m_dcC13 As Decimal
        Private m_dcC14 As Decimal

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
        Public Property RYear() As String
            Get
                RYear = m_strRYear
            End Get
            Set(ByVal value As String)
                m_strRYear = value
            End Set
        End Property
        Public Property C1() As Decimal
            Get
                C1 = m_dcC1
            End Get
            Set(ByVal value As Decimal)
                m_dcC1 = value
            End Set
        End Property
        Public Property C2() As Decimal
            Get
                C2 = m_dcC2
            End Get
            Set(ByVal value As Decimal)
                m_dcC2 = value
            End Set
        End Property

        Public Property C3() As Decimal
            Get
                C3 = m_dcC3
            End Get
            Set(ByVal value As Decimal)
                m_dcC3 = value
            End Set
        End Property
        Public Property C4() As Decimal
            Get
                C4 = m_dcC4
            End Get
            Set(ByVal value As Decimal)
                m_dcC4 = value
            End Set
        End Property


        Public Property C5() As Decimal
            Get
                C5 = m_dcC5
            End Get
            Set(ByVal value As Decimal)
                m_dcC5 = value
            End Set
        End Property
        Public Property C6() As Decimal
            Get
                C6 = m_dcC6
            End Get
            Set(ByVal value As Decimal)
                m_dcC6 = value
            End Set
        End Property


        Public Property C7() As Decimal
            Get
                C7 = m_dcC7
            End Get
            Set(ByVal value As Decimal)
                m_dcC7 = value
            End Set
        End Property
        Public Property C8() As Decimal
            Get
                C8 = m_dcC8
            End Get
            Set(ByVal value As Decimal)
                m_dcC8 = value
            End Set
        End Property

        Public Property C9() As Decimal
            Get
                C9 = m_dcC9
            End Get
            Set(ByVal value As Decimal)
                m_dcC9 = value
            End Set
        End Property
        Public Property C10() As Decimal
            Get
                C10 = m_dcC10
            End Get
            Set(ByVal value As Decimal)
                m_dcC10 = value
            End Set
        End Property


        Public Property C11() As Decimal
            Get
                C11 = m_dcC11
            End Get
            Set(ByVal value As Decimal)
                m_dcC11 = value
            End Set
        End Property
        Public Property C12() As Decimal
            Get
                C12 = m_dcC12
            End Get
            Set(ByVal value As Decimal)
                m_dcC12 = value
            End Set
        End Property
        Public Property C13() As Decimal
            Get
                C13 = m_dcC13
            End Get
            Set(ByVal value As Decimal)
                m_dcC13 = value
            End Set
        End Property
        Public Property C14() As Decimal
            Get
                C14 = m_dcC14
            End Get
            Set(ByVal value As Decimal)
                m_dcC14 = value
            End Set
        End Property

        Public Function SaveTempComparativeStudyofEachOrder()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempComparativeStudyofEachOrder"
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
        Public Function GetVender2(ByVal YEAR As String, ByVal Customerid As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "All" Then
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " where YEAR(PO.SHIPMENTDATE)='" & YEAR & "' and PO.CustomerID='" & Customerid & "'   order by V.VenderName "

            Else
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " where YEAR(PO.SHIPMENTDATE)='" & YEAR & "' and PO.CustomerID='" & Customerid & "' and PO.EKNumber='" & BuyingDept & "' order by V.VenderName "

            End If
         Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVender3(ByVal Customerid As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " where  PO.CustomerID='" & Customerid & "'   order by V.VenderName "

            Else
                Str = " SELECT  distinct Supplierid ,V.VenderName "
                Str &= " FROM PURCHASEORDER po join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " where  PO.CustomerID='" & Customerid & "' and PO.EKNumber='" & BuyingDept & "' order by V.VenderName "

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1(ByVal Supplierid As String, ByVal Startval As Decimal, ByVal Endval As Decimal, ByVal YEAR As String) As DataTable
            Dim Str As String
            Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
            Str &= " where  POD.POID=po.POID)as QTYtotal  "
            Str &= " from PurchaseOrder PO"
            Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
            Str &= " WHERE PO.Supplierid='" & Supplierid & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
            Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
            Str &= " where  POD.POID=po.POID)<='" & Endval & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1New(ByVal Supplierid As String, ByVal Startval As Decimal, ByVal Endval As Decimal, ByVal YEAR As String, ByVal Customerid As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "All" Then
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and PO.CustomerID='" & Customerid & "' "
            Else
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and PO.CustomerID='" & Customerid & "' and PO.EKNumber='" & BuyingDept & "'"
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
        Public Function getdataforReport1NewMonthWise(ByVal Supplierid As String, ByVal Startval As Decimal, ByVal Endval As Decimal, ByVal YEAR As String, ByVal Customer As String, ByVal BuyingDept As String, ByVal Month1 As String, ByVal Month2 As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "' and Month(PO.SHIPMENTDATE) between '" & Month1 & "' and  '" & Month2 & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and C.CustomerName='" & Customer & "' "
            Else
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "' and Month(PO.SHIPMENTDATE) between '" & Month1 & "' and  '" & Month2 & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and C.CustomerName='" & Customer & "' and PO.EKNumber='" & BuyingDept & "'"
            End If


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport1NewThreeYear(ByVal Supplierid As String, ByVal Startval As Decimal, ByVal Endval As Decimal, ByVal YEAR As String, ByVal Customer As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and C.CustomerName='" & Customer & "' "
            Else
                Str = " select PO.POID ,PO.SUPPLIERID,(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)as QTYtotal  "
                Str &= " from PurchaseOrder PO"
                Str &= " join Vender v on v.VenderLibraryid=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " WHERE PO.Supplierid='" & Supplierid & "'  and YEAR(PO.SHIPMENTDATE)='" & YEAR & "'AND(select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)>='" & Startval & "' AND (select ISNULL(sum(POD.Quantity),0) from PurchaseOrderDetail POD "
                Str &= " where  POD.POID=po.POID)<='" & Endval & "' and C.CustomerName='" & Customer & "' and PO.EKNumber='" & BuyingDept & "'"
            End If


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


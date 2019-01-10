Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class WithheldAgainstQty
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempWithheldAgainstQty"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strSupplier As String
        Private m_dcY1QTY As Decimal
        Private m_dcY1WITHHELD As Decimal
        'Private m_dcY2QTY As Decimal
        'Private m_dcY2WITHHELD As Decimal
        'Private m_dcY3QTY As Decimal
        'Private m_dcY3WITHHELD As Decimal
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
        'Public Property Y2QTY() As Decimal
        '    Get
        '        Y2QTY = m_dcY2QTY
        '    End Get
        '    Set(ByVal value As Decimal)
        '        m_dcY2QTY = value
        '    End Set
        'End Property
        'Public Property Y2WITHHELD() As Decimal
        '    Get
        '        Y2WITHHELD = m_dcY2WITHHELD
        '    End Get
        '    Set(ByVal value As Decimal)
        '        m_dcY2WITHHELD = value
        '    End Set
        'End Property

        'Public Property Y3QTY() As Decimal
        '    Get
        '        Y3QTY = m_dcY3QTY
        '    End Get
        '    Set(ByVal value As Decimal)
        '        m_dcY3QTY = value
        '    End Set
        'End Property
        'Public Property Y3WITHHELD() As Decimal
        '    Get
        '        Y3WITHHELD = m_dcY3WITHHELD
        '    End Get
        '    Set(ByVal value As Decimal)
        '        m_dcY3WITHHELD = value
        '    End Set
        'End Property
        Public Function SaveTempWithheldAgainstQty()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVender() As DataTable
            Dim Str As String
            Str = " select distinct cd.Supplierid,V.VenderName  from Cargo cr "
            Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join Vender V on V.VenderLibraryID=cd.Supplierid"
            Str &= " order by V.VenderName "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport4(ByVal Supplierid As String, ByVal Year As String) As DataTable
            Dim Str As String
            Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr "
            Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
            Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
            Str &= " where cd.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport4New(ByVal Supplierid As String, ByVal Year As String, ByVal Customer As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " where cd.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "' and C.CustomerName='" & Customer & "' "
            Else
                Str = "select isnull(sum (Quantity),0) as Qty from Cargo cr "
                Str &= " join CargoDetail cd on cr.cargoid=cd.cargoid"
                Str &= " join PurchaseOrder po on po.POID=cd.POPOID"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " where cd.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "' and C.CustomerName='" & Customer & "' and PO.EKNumber='" & BuyingDept & "'"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport4withHeld(ByVal Supplierid As String, ByVal Year As String) As DataTable
            Dim Str As String
            Str = "  select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC "
            Str &= " JOIN PurchaseOrder PO ON PO.POID=PC.POID"
            Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
            Str &= " where PO.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getdataforReport4withHeldNew(ByVal Supplierid As String, ByVal Year As String, ByVal CustomerID As String, ByVal BuyingDept As String) As DataTable
            Dim Str As String
            If BuyingDept = "ALL" Then
                Str = "  select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC "
                Str &= " JOIN PurchaseOrder PO ON PO.POID=PC.POID"
                Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " where PO.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "'and  C.CustomerName='" & CustomerID & "' "
            Else
                Str = "  select isnull(sum(ClaimPcs),0) as WITHHELD from POClaim PC "
                Str &= " JOIN PurchaseOrder PO ON PO.POID=PC.POID"
                Str &= " join Vender V on V.VenderLibraryID=PO.Supplierid"
                Str &= " join Customer C on PO.CustomerID=C.CustomerID"
                Str &= " where PO.Supplierid='" & Supplierid & "' and year(po.shipmentdate)='" & Year & "'and  C.CustomerName='" & CustomerID & "' and PO.EKNumber='" & BuyingDept & "'"
            End If
           
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempWithheldAgainstQty"
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

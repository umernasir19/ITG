Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class ProductionLineStatus
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ProductionLineStatus"
            m_strPrimaryFieldName = "PLSEID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPLSEID As Long
        Private m_lPOID As Long
        Private m_lCustomerID As Long
        Private m_lSupplierID As Long
        Private m_dTotalLines As Decimal
        Private m_dProductionLine As Decimal
        Private m_dSumProduction As Decimal
        Private m_dSumDaysRequired As Decimal
        Private m_dtLineInitiatedOn As Date
        Private m_dtLineClosing As Date

        '''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''
        Public Property PLSEID() As Long
            Get
                PLSEID = m_lPLSEID
            End Get
            Set(ByVal value As Long)
                m_lPLSEID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
            End Set
        End Property
        Public Property TotalLines() As Decimal
            Get
                TotalLines = m_dTotalLines
            End Get
            Set(ByVal value As Decimal)
                m_dTotalLines = value
            End Set
        End Property
        Public Property ProductionLine() As Decimal
            Get
                ProductionLine = m_dProductionLine
            End Get
            Set(ByVal value As Decimal)
                m_dProductionLine = value
            End Set
        End Property
        Public Property SumProduction() As Decimal
            Get
                SumProduction = m_dSumProduction
            End Get
            Set(ByVal value As Decimal)
                m_dSumProduction = value
            End Set
        End Property
        Public Property SumDaysRequired() As Decimal
            Get
                SumDaysRequired = m_dSumDaysRequired
            End Get
            Set(ByVal value As Decimal)
                m_dSumDaysRequired = value
            End Set
        End Property
        Public Property LineinitiatedOn() As Date
            Get
                LineinitiatedOn = m_dtLineInitiatedOn
            End Get
            Set(ByVal value As Date)
                m_dtLineInitiatedOn = value
            End Set
        End Property
        Public Property LineClosing() As Date
            Get
                LineClosing = m_dtLineClosing
            End Get
            Set(ByVal value As Date)
                m_dtLineClosing = value
            End Set
        End Property

        ''''''''''''''''''''''''''''''''''''''''''''''Quries''''''''''''''''''''''''''''''''''''''
        Public Function SaveProductionStatus()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomers() As DataTable
            Dim str As String
            str = " Select distinct C.CustomerID , C.CustomerName from Customer C"
            str &= " join PurchaseOrder Po on Po.CustomerID=C.CustomerID "
            str &= " where Year(Po.Shipmentdate) >= 2013  and DATEDIFF(DAY,GETDATE(),ShipmentDate) > 0 "
            str &= " Order By C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSuppliers(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = "Select Distinct V.VenderName, V.VenderLibraryID From PurchaseOrder PO "
            str &= " join Vender V on V.VenderLibraryID = PO.SupplierID  Where  Year(Po.Shipmentdate) >= 2013 and DATEDIFF(DAY,GETDATE(),ShipmentDate) > 0 and CustomerID = '" & CustomerID & "' order by v.VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPONO(ByVal CustomerID As Long, ByVal VenderLibraryID As String) As DataTable
            Dim str As String
            str = "Select Po.PONO, Po.POID from PurchaseOrder Po where CustomerID = '" & CustomerID & "' and SupplierID='" & VenderLibraryID & "' and Year(Po.Shipmentdate) >= 2013 and DATEDIFF(DAY,GETDATE(),ShipmentDate) > 0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDates(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select CONVERT(VARCHAR(11),PlacementDate,103) AS PlacementDate,CONVERT(VARCHAR(11),ShipmentDate,103) AS ShipmentDate ,DATEDIFF(DAY,GETDATE(),ShipmentDate)as DaysDif ,IsNull((Select SUM(Quantity) From Purchaseorderdetail POD Where PO.POID=POD.POID),0) as BookedQuantity from PurchaseOrder PO where PO.POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductionStatusView() As DataTable
            Dim str As String
            str = " Select PLS.PLSEID,PLs.POID, PO.PONO,C.Aliass,V.ShortName  from ProductionLineStatus PLS join PurchaseOrder Po on PO.POID = PLS.POID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            str &= " Join UMUser UM on UM.UserID=PO.MarchandID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductionStatusPlanningValues(ByVal PLSEID As Long) As DataTable
            Dim str As String
            str = " Select PLS.*,PLSD.*, PO.PONO,PO.CustomerId,PO.SupplierID,PO.POID, CONVERT(VARCHAR(11),PlacementDate,103) AS PlacementDate,CONVERT(VARCHAR(11),ShipmentDate,103) AS ShipmentDate ,DATEDIFF(DAY,GETDATE(),ShipmentDate)as DaysDif , PLs.POID, C.CustomerName, V.VenderName   ,DATEDIFF(DAY,PLS.LineInitiatedOn,PLS.LineClosing)as DateDaysDif,  CONVERT(VARCHAR(11),PLS.LineInitiatedOn,103) as LineInitiatedOnnew "
            str &= "  ,(Select (PLSD.BookedQuantity) - Sum(PLSH.StitchedQty)  from ProductionLineStatusHistory PLSH Where PLSH.PLSDID = PLSD.PLSDID) as BalanceQty "
            str &= "  from ProductionLineStatus PLS  "
            str &= " left join ProductionLineStatusDetail PLSD on PLSD.PLSEID = PLS.PLSEID"
            str &= " join PurchaseOrder Po on PO.POID = PLS.POID"
            str &= " join Customer C on C.CustomerID = PO.CustomerID"
            str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID"
            str &= " Where PLS.PLSEID = '" & PLSEID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleData(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select distinct SM.StyleNo, SUM(POD.Quantity)as BookedQuantity from PurchaseOrder PO"
            str &= " join PurchaseOrderDetail POD on POD.POID = PO.POID"
            str &= " join StyleMaster SM on SM.StyleID = POD.StyleID"
            str &= " Where PO.POID =" & POID
            str &= " Group By SM.StyleNo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingValue(ByVal CustomerID As Long, ByVal SupplierID As Long, ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select PLS.PLSEID, PLS.CustomerID, PLS.SupplierID, PLS.POID From ProductionLineStatus PLS "
            str &= " Where PLS.CustomerID = '" & CustomerID & "' And PLS.SupplierID = '" & SupplierID & "' And PLS.POID = '" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class AdministrationActivities
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PurchaseOrder"
        m_strPrimaryFieldName = "POID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Public Function GetGridData(ByVal PONO As String) As DataTable
        Dim str As String
        str = " Select PO.POID, PO.PONO, C.CustomerName, V.VenderName, UM.UserName,Convert(Varchar,PO.PlacementDate,103) as PlacementDate ,Convert(Varchar,PO.ShipmentDate,103) as ShipmentDate ,Convert(Varchar,PO.CreationDate,103) as CreationDate"
        str &= " ,(case when (Select count(Distinct POPOID) From CargoDetail CD"
        str &= "  Where CD.POPOID = PO.POID)>0 then 'Yes' else 'No'   end) as InShipment ,PO.ShipmentDate as ShipmentDatee from PurchaseOrder PO "
        str &= "  join Customer C on C.CustomerID = PO.CustomerID"
        str &= "  Join Vender V on V.VenderLibraryID = PO.SupplierID"
        str &= "  Join UMUser UM on UM.UserId = PO.MarchandID"
        str &= "  Where PO.PONO = '" & PONO & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function DeleteTNA(ByVal lPOID As Long)
        Dim str As String
        str = " delete  TNAChartHistory where TNAChartID IN (Select TNAChartID  from TNAChart where POID = '" & lPOID & "') "
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function DeleteTNAChart(ByVal lPOID As Long)
        Dim str As String
        str = "delete TNAChart where POID = '" & lPOID & "' "
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function DeletePurchaseOrderDetail(ByVal lPOID As Long)
        Dim str As String
        str = "delete PurchaseOrderDetail where POID = '" & lPOID & "' "
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function DeletePurchaseOrder(ByVal lPOID As Long)
        Dim str As String
        str = "DELETE FROM purchaseorder where POID =  '" & lPOID & "' "
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function UpdateShipmentDate(ByVal NewShipmentDate As DateTime, ByVal lPOID As Long)
        Dim str As String
        str = " update PurchaseOrderReviseShipment set shipmentdate='" & NewShipmentDate & "' where"
        str &= " POreviseshipmentID in "
        str &= " (select Top 1 POreviseshipmentID from PurchaseOrderReviseShipment where poid='" & lPOID & "'"
        str &= " order by POreviseshipmentID DESC)"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function UpdatePOShipmentDate(ByVal ShipmentDate As DateTime, ByVal lPOID As Long)
        Dim str As String
        str = "update purchaseorder set shipmentdate='" & ShipmentDate & "' where poid = '" & lPOID & "'"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
End Class

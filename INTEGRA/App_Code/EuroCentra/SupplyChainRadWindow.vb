Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class SupplyChainRadWindow
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PurchaseOrder"
        m_strPrimaryFieldName = "POID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Public Function GetCustomerInfoForRW(ByVal lPOID As Long) As DataTable
        Dim str As String
        str = " Select C.CustomerID, C.CustomerName, C.Country, C.ParentGroupID, PG.Parent, C.Geographical_Territory_ID, GT.Territory from PurchaseOrder PO "
        str &= " join Customer C on C.CustomerID = PO.CustomerID"
        str &= " join ParentGroup PG on PG.ParentGroupID = C.ParentGroupID"
        str &= " Join Geographical_Territory GT on GT.Geographical_Territory_ID = C.Geographical_Territory_ID"
        str &= " Where Po.POID = " & lPOID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSupplierInfoForRW(ByVal lPOID As Long) As DataTable
        Dim str As String
        str = "Select V.VenderName,  V.PhoneNumber, V.Address1, C.CountryName  from PurchaseOrder PO"
        str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID "
        str &= " Join Countries C on C.Country_id = V.CountryID"
        str &= " Where Po.POID = " & lPOID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetMerchantInfoForRW(ByVal lPOID As Long) As DataTable
        Dim str As String
        str = " Select UM.UserName, UM.Designation, UM.ECPDivistion from PurchaseOrder PO"
        str &= " join UMUser UM on UM.UserId = PO.MarchandID "
        str &= " Where Po.POID = " & lPOID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetCertificateInfoForRW(ByVal lPOID As Long) As DataTable
        Dim str As String
        str = " Select C.Certificate  from PurchaseOrder PO"
        str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID "
        str &= " Join VenderCertificate VC  on VC.VenderID = V.VenderLibraryID"
        str &= " Join Certificate C on C.CertificateID = VC.CertificateID"
        str &= " Where Po.POID = " & lPOID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class

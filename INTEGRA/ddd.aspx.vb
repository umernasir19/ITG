Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Public Class ddd
    Inherits System.Web.UI.Page
    Dim objVendor As New Vender
    Dim objVenderDetail As New VenderDetail
    Dim ObjVenderGradingScale As New VenderGradingScale
    Dim objCustomerDatabase As New CustomerDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Dim x As Integer
            Dim dtSupplier As DataTable = objVendor.getDataforBindCombo

            For x = 0 To dtSupplier.Rows.Count - 1
                With objVendor
                    .VenderLibraryID = dtSupplier.Rows(x)("VenderLibraryID")
                    .SupplierStatus = "Active"
                    .VenderName = dtSupplier.Rows(x)("VenderName")
                    .VenderCode = 0
                    .Address1 = "N/A"
                    .Address2 = "N/A"
                    .ZipCode = 0
                    .PhoneNumber = 0
                    .City = 942
                    .CountryID = 171
                    .ShortName = dtSupplier.Rows(x)("VenderName")
                    .FaxNo = 0
                    .IsActive = True
                    .Website = "www.abc.com"
                    .LongitudeandLatitude = ""
                    .imgOriginalLogo = ""
                    .imgWaterMark = ""
                    .VAF = ""
                    .SaveVender()
                End With




            Next


        Catch ex As Exception

        End Try
    End Sub
  
 
    Protected Sub Button22_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button22.Click
        Try
            SaveCustomerDatabase()
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveCustomerDatabase()
        Try
            Dim x As Integer
            Dim dtCustomer As DataTable = objCustomerDatabase.CheckCustomerTemp
            For x = 0 To dtCustomer.Rows.Count - 1
                With objCustomerDatabase
                    .CustomerID = dtCustomer.Rows(x)("CustomerID")
                    .CustomerTypeID = 1
                    .Country = "Germany"
                    .Geographical_Territory_ID = 1
                    .CustomerName = dtCustomer.Rows(x)("CustomerName")
                    .Aliass = dtCustomer.Rows(x)("CustomerName")
                    .ParentGroupID = 1
                    .Address1 = "N/A"
                    .Address2 = "N/A"
                    .City = "Hamburg"
                    .WebSite = "N/A"
                    .ContactNo = "N/A"
                    .FaxNo = "N/A"
                    .IndustryTypeWholesale = True
                    .IndustryTypeRetail = True
                   .IndustryTypeImporter = True
                    .IndustryTypeWarehouse = True
                    .Commission = dtCustomer.Rows(x)("Commission")
                    .CustomerNo = "0"
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & ""))
                    di.Create()
                    Dim di1 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/logo"))
                    di1.Create()
                    Dim di2 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/WaterMarked"))
                    di2.Create()
                    Dim di3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/Barcode"))
                    di3.Create()
                    File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/Logo/no-image.jpg"))
                    .imgOriginalLogo = "CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/Logo/no-image.jpg"
                    File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/WaterMarked/no-image.jpg"))
                    .imgWaterMark = "CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/WaterMarked/no-image.jpg"
                    File.Copy(Server.MapPath("~/Images/no-image.jpg"), Server.MapPath("~/CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/Barcode/no-image.jpg"))
                    .imgBarcode = "CustomerImages/" & dtCustomer.Rows(x)("CustomerID") & "/Barcode/no-image.jpg"
                    .IsActive = True
                    .SaveCustomer()

                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
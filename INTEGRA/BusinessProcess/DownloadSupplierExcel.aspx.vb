Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.SqlClient
Public Class DownloadSupplierExcel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            PageHeader("Supplier Order Status Download")
            btnsupplychn.Text = "Download Order Supplier Status"

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnsupplychn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsupplychn.Click
        Try
            If cmbYYear.SelectedItem.Text = "2014 & Over PO. Vise" Then

                Dim objPurchaseOrder As New PurchaseOrder
                Dim FileName As String = "OrderStatus"
                Dim SpName As String = "sp_AdminSupplyChainExcelSheetSupplierPoVise-" + CLng(Session("SupplierId")).ToString()
                objPurchaseOrder.getMasterExcelSupplier(CLng(Session("SupplierId")), SpName)

                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplierPOviseGenerated/" + CLng(Session("SupplierId")).ToString()
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status_PO_Vise_" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()

            ElseIf cmbYYear.SelectedItem.Text = "2014 & Over Item Vise" Then

                Dim objPurchaseOrder As New PurchaseOrder
                Dim FileName As String = "MySupplyChain"
                Dim SpName As String = "sp_AdminSupplyChainExcelSheetSupplierItemVise-" + CLng(Session("SupplierId")).ToString()
                objPurchaseOrder.getMasterExcelSupplier(CLng(Session("SupplierId")), SpName)

                Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplierItemviseGenerated/" + CLng(Session("SupplierId")).ToString()
                Dim sDate_time As String
                Dim sDestination_path As String
                Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
                myExportOptions = New CrystalDecisions.Shared.ExportOptions()
                File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
                sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
                sDestination_path = MyPath + FileName + ".pdf"
                File_destination.DiskFileName = sDestination_path
                Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
                If thefile.Exists Then
                    System.IO.File.Delete(sDestination_path)
                End If
                Response.ContentType = "PDF"
                Dim Day As String = Date.Now().Day()
                Dim month As String = Date.Now().Month
                Dim year As String = Date.Now().Year
                Dim Hour As String = Date.Now().Hour
                Dim Minute As String = Date.Now().Minute
                Dim AMorPMResult As String = Now.ToString("tt ")
                Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
                Response.AppendHeader("Content-Disposition", "attachment; filename=""Order Status_Item_Vise_" + datee + ".xls")
                Response.TransmitFile(MyPath + "/" + FileName + ".xls")
                Response.End()
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
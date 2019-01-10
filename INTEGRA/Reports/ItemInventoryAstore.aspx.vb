Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class ItemInventoryAstore
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCategory()
            BindiTEM()
        End If
    End Sub
    Sub BindCategory()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetBindItemCategoryAstore
            cmbItemCategory.DataSource = dtsupplier
            cmbItemCategory.DataTextField = "ItemCategoryname"
            cmbItemCategory.DataValueField = "IMSItemCategoryID"
            cmbItemCategory.DataBind()
            cmbItemCategory.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindiTEM()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetBindItemNameaLLAstore()
            cmbItemName.DataSource = dtsupplier
            cmbItemName.DataTextField = "Itemname"
            cmbItemName.DataValueField = "IMSIteMID"
            cmbItemName.DataBind()
            cmbItemName.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbItemCategory_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbItemCategory.SelectedIndexChanged
        Try
            If cmbItemCategory.SelectedValue > 0 Then
                Dim dtsupplier As DataTable
                dtsupplier = objDPPoRecevMst.GetBindItemNameAstore(cmbItemCategory.SelectedValue)
                cmbItemName.DataSource = dtsupplier
                cmbItemName.DataTextField = "Itemname"
                cmbItemName.DataValueField = "IMSIteMID"
                cmbItemName.DataBind()
                cmbItemName.Items.Insert(0, New RadComboBoxItem("All", 0))

            Else

                Dim dtsupplier As DataTable
                dtsupplier = objDPPoRecevMst.GetBindItemNameaLLAstore()
                cmbItemName.DataSource = dtsupplier
                cmbItemName.DataTextField = "Itemname"
                cmbItemName.DataValueField = "IMSIteMID"
                cmbItemName.DataBind()
                cmbItemName.Items.Insert(0, New RadComboBoxItem("All", 0))
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            Dim CategoryID As String = cmbItemCategory.SelectedItem.Text
            Dim ItemID As String = cmbItemName.SelectedItem.Text
            'Delete All PDF files from Folder

            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/ItemInventoryAstoreReport.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Item Invetory AStore Report"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, CategoryID)
            Report.SetParameterValue(1, ItemID)

            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If



        Catch ex As Exception

        End Try
    End Sub

End Class
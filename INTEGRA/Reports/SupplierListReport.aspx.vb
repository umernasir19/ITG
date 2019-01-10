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
Public Class SupplierListReport
    Inherits System.Web.UI.Page

    Dim objDPPoRecevMst As New DPPoRecevMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindSupplierCode()
            BindSupplierCategory()
        End If
    End Sub
    Sub BindDALNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetSupplierForFabricLedger()
            cmbSupplier.DataSource = dtDalNo
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplierCode()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetSupplierCodeForFabricLedger()
            cmbSupplierCode.DataSource = dtDalNo
            cmbSupplierCode.DataTextField = "SupplierCode"
            cmbSupplierCode.DataValueField = "SupplierDatabaseID"
            cmbSupplierCode.DataBind()
            cmbSupplierCode.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplierCategory()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetSupplierCategoryForFabricLedger()
            cmbSupplierCategory.DataSource = dtDalNo
            cmbSupplierCategory.DataTextField = "SupplierCategory"
            cmbSupplierCategory.DataValueField = "SupplierCategoryID"
            cmbSupplierCategory.DataBind()
            cmbSupplierCategory.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click

        Dim SupplierId As Long = cmbSupplier.SelectedValue
        Dim SupplierCode As String = cmbSupplierCode.SelectedItem.Text
        Dim SupplierCategory As String = cmbSupplierCategory.SelectedItem.Text

        'Delete All PDF files from Folder
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        'End Delete
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/SupplierList.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "SupplierListSheet"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

        Report.SetParameterValue(0, SupplierId)
        Report.SetParameterValue(1, SupplierCode)
        Report.SetParameterValue(2, SupplierCategory)

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






        'If cmbSupplier.SelectedValue <> 0 Then

        '    Dim DalNo As Long = cmbSupplier.SelectedValue
        '    'Delete All PDF files from Folder
        '    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
        '        System.IO.File.Delete(Uploadedfiles)
        '    Next
        '    'End Delete
        '    Dim Report As New ReportDocument
        '    Dim Options As New ExportOptions
        '    Report.Load(Server.MapPath("..\Reports/SupplierList.rpt"))
        '    Report.Refresh()
        '    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        '    di.Create()
        '    Dim FileName As String = "Supplier List Sheet"
        '    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        '    Report.SetParameterValue(0, DalNo)

        '    Dim FileOption As New DiskFileDestinationOptions
        '    FileOption.DiskFileName = sTempFileName
        '    Options = Report.ExportOptions
        '    Options.ExportDestinationType = ExportDestinationType.DiskFile
        '    Options.ExportFormatType = ExportFormatType.PortableDocFormat
        '    Options.DestinationOptions = FileOption
        '    Options.ExportDestinationOptions = FileOption
        '    Report.SetDatabaseLogon("sa", "pwd")
        '    Report.Export()

        '    If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
        '        Dim strFileSize As String = ""
        '        Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
        '        Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
        '        Dim fi As IO.FileInfo
        '        For Each fi In aryFi
        '            Response.ClearHeaders()
        '            Response.ClearContent()
        '            Response.ContentType = "application/octet-stream"
        '            Response.Charset = "UTF-8"
        '            Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
        '            Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
        '            Response.End()
        '        Next
        '    End If


        'Else
        '    'Delete All PDF files from Folder
        '    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
        '        System.IO.File.Delete(Uploadedfiles)
        '    Next
        '    'End Delete
        '    Dim Report As New ReportDocument
        '    Dim Options As New ExportOptions
        '    Report.Load(Server.MapPath("..\Reports/SupplierListAll.rpt"))
        '    Report.Refresh()
        '    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        '    di.Create()
        '    Dim FileName As String = "Supplier List Sheet"
        '    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        '    Dim FileOption As New DiskFileDestinationOptions
        '    FileOption.DiskFileName = sTempFileName
        '    Options = Report.ExportOptions
        '    Options.ExportDestinationType = ExportDestinationType.DiskFile
        '    Options.ExportFormatType = ExportFormatType.PortableDocFormat
        '    Options.DestinationOptions = FileOption
        '    Options.ExportDestinationOptions = FileOption
        '    Report.SetDatabaseLogon("sa", "pwd")
        '    Report.Export()
        '    If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
        '        Dim strFileSize As String = ""
        '        Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
        '        Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
        '        Dim fi As IO.FileInfo
        '        For Each fi In aryFi
        '            Response.ClearHeaders()
        '            Response.ClearContent()
        '            Response.ContentType = "application/octet-stream"
        '            Response.Charset = "UTF-8"
        '            Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
        '            Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
        '            Response.End()
        '        Next
        '    End If


        'End If

    End Sub
End Class
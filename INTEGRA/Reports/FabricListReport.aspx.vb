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

Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class FabricListReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim objDPPoRecevMst As New DPPoRecevMst

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindSupplier()
        End If

    End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcel.Click
    '    Try
    '        objDPPoRecevMst.TruncateTableSampleProgram()
    '        Dim x As Integer
    '        For x = 0 To dgViewMaster.Items.Count - 1
    '            Dim ChkDownLoad As CheckBox = DirectCast(dgViewMaster.Items(x).FindControl("ChkDownLoad"), CheckBox)
    '            If ChkDownLoad.Checked = True Then
    '                With ObjtempSampleProgramSheet
    '                    .Tempid = 0
    '                    .DalNo = dgViewMaster.Items(x).Cells(2).Text
    '                    .Buyer = dgViewMaster.Items(x).Cells(3).Text
    '                    .Style = dgViewMaster.Items(x).Cells(4).Text
    '                    .Descriptionn = dgViewMaster.Items(x).Cells(5).Text
    '                    .Sizee = dgViewMaster.Items(x).Cells(6).Text.Replace("&nbsp;", "")
    '                    .Quantity = dgViewMaster.Items(x).Cells(7).Text
    '                    .CompositionName = dgViewMaster.Items(x).Cells(8).Text
    '                    .FabricName = dgViewMaster.Items(x).Cells(9).Text
    '                    .PocketLining = dgViewMaster.Items(x).Cells(10).Text
    '                    .WashingDetail = dgViewMaster.Items(x).Cells(11).Text.Replace("&nbsp;", "")
    '                    .Remarks = dgViewMaster.Items(x).Cells(12).Text.Replace("&nbsp;", "")
    '                    .ThreadsNew = dgViewMaster.Items(x).Cells(13).Text
    '                    .WidthCutable = dgViewMaster.Items(x).Cells(14).Text.Replace("&nbsp;", "")
    '                    .CreatDatee = dgViewMaster.Items(x).Cells(16).Text
    '                    .Save()
    '                End With
    '            End If
    '        Next












    '        Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
    '        Dim objSqlConnection As New SqlConnection
    '        Dim sqlCmd As New SqlCommand
    '        objSqlConnection = New SqlConnection(strConnection)
    '        'sqlCmd = New SqlCommand("sp_ProductionExcel", objSqlConnection)
    '        sqlCmd = New SqlCommand("sp_SampleProgramSheetExcelExcelNew", objSqlConnection)
    '        sqlCmd.CommandType = CommandType.StoredProcedure
    '        ' sqlCmd.Parameters.Add(New SqlParameter("@marchandID", SqlDbType.VarChar)).Value = userid
    '        objSqlConnection.Open()
    '        sqlCmd.CommandTimeout = 5000
    '        sqlCmd.ExecuteNonQuery()
    '        objSqlConnection.Close()

    '        Dim FileName As String = "SampleProgramSheet"
    '        Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/PDMGenerated/"
    '        Dim sDate_time As String
    '        Dim sDestination_path As String
    '        Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
    '        Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
    '        Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
    '        myExportOptions = New CrystalDecisions.Shared.ExportOptions()
    '        File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
    '        Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
    '        sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
    '        sDestination_path = MyPath + FileName + ".pdf"
    '        File_destination.DiskFileName = sDestination_path
    '        Dim thefile As System.IO.FileInfo = New System.IO.FileInfo(sDestination_path)
    '        If thefile.Exists Then
    '            System.IO.File.Delete(sDestination_path)
    '        End If
    '        Response.ContentType = "PDF"
    '        ' Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls")
    '        Dim Day As String = Date.Now().Day()
    '        Dim month As String = Date.Now().Month
    '        Dim year As String = Date.Now().Year
    '        Dim Hour As String = Date.Now().Hour
    '        Dim Minute As String = Date.Now().Minute
    '        Dim AMorPMResult As String = Now.ToString("tt ")
    '        Dim datee As String = Day + "-" + month + "-" + year + " " + Hour + "-" + Minute + " " + AMorPMResult
    '        Response.AppendHeader("Content-Disposition", "attachment; filename=""Sample Programme Sheet" + ".xls")
    '        Response.TransmitFile(MyPath + "/" + FileName + ".xls")
    '        Response.End()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub BindDALNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetDalNOforSummary()
            cmbDal.DataSource = dtDalNo
            cmbDal.DataTextField = "DalNo"
            cmbDal.DataValueField = "FabricDbMstID"
            cmbDal.DataBind()
            cmbDal.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dt As DataTable
            dt = objDPPoRecevMst.GetSupplierforSummary()
            cmbSupplier.DataSource = dt
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
 Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        ' If cmbDal.SelectedValue <> 0 Then

        Dim DalNo As Long = cmbDal.SelectedValue
        Dim Supplier As Long = cmbSupplier.SelectedValue
        'Delete All PDF files from Folder
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        'End Delete
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/DALFabricList.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "FabricListSheet"
        '+ txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            CheckDate = 1
            Report.SetParameterValue(0, DalNo)

            Report.SetParameterValue(1, Supplier)
            Report.SetParameterValue(2, txtDateFrom.SelectedDate)
            Report.SetParameterValue(3, txtDateTo.SelectedDate)
            'Report.SetParameterValue(5, FabricName)
            Report.SetParameterValue(4, CheckDate)
        Else
            CheckDate = 0
            Report.SetParameterValue(0, DalNo)
            Report.SetParameterValue(1, Supplier)
            Report.SetParameterValue(2, Date.Now)
            Report.SetParameterValue(3, Date.Now)
            'Report.SetParameterValue(5, FabricName)
            Report.SetParameterValue(4, CheckDate)

        End If
        'Report.SetParameterValue(0, DalNo)
        'Report.SetParameterValue(1, txtDateFrom.SelectedDate)
        'Report.SetParameterValue(2, txtDateTo.SelectedDate)

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
        'Else
        '    'Delete All PDF files from Folder
        '    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
        '        System.IO.File.Delete(Uploadedfiles)
        '    Next
        '    'End Delete
        '    Dim Report As New ReportDocument
        '    Dim Options As New ExportOptions
        '    Report.Load(Server.MapPath("..\Reports/DALFabricListAll.rpt"))
        '    Report.Refresh()
        '    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        '    di.Create()
        '    Dim FileName As String = "Fabric List Sheet_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
        '    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        '    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
        '    Report.SetParameterValue(1, txtDateTo.SelectedDate)
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
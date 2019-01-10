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
Public Class SampleProgrammeSheet
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Dim objDPPOMst As New DPPOMst
    Dim objDPPODtl As New DPPODtl
    Dim dtAccess As DataTable
    Dim Dr As DataRow
    Dim ObjtempSampleProgramSheet As New tempSampleProgramSheet
    Dim startDate, enddate As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSupplier()
            BindStyle()
            BindDalNo()
            Session("dtAccess") = Nothing
        End If
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetSupplierComboNNew
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "CustomerName"
            cmbSupplier.DataValueField = "CustomerID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDalNo()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetDalNoFroSampleProgramSheet
            cmbDalNO.DataSource = dtsupplier
            cmbDalNO.DataTextField = "DalNo"
            cmbDalNO.DataBind()
            cmbDalNO.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetStyleFroSampleProgramSheet
            cmbStyle.DataSource = dtsupplier
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            objDPPoRecevMst.TruncateTableSampleProgram()
            Session("dtAccess") = Nothing
            Bind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcel.Click
        Try
            Dim FileName As String = ""
            objDPPoRecevMst.TruncateTableSampleProgram()
            Dim x As Integer
            For x = 0 To dgViewMaster.Items.Count - 1
                Dim ChkDownLoad As CheckBox = DirectCast(dgViewMaster.Items(x).FindControl("ChkDownLoad"), CheckBox)
                If ChkDownLoad.Checked = True Then
                    With ObjtempSampleProgramSheet
                        .Tempid = 0
                        .DalNo = dgViewMaster.Items(x).Cells(2).Text
                        .Buyer = dgViewMaster.Items(x).Cells(3).Text
                        .Style = dgViewMaster.Items(x).Cells(4).Text
                        .Descriptionn = dgViewMaster.Items(x).Cells(5).Text
                        .Sizee = dgViewMaster.Items(x).Cells(6).Text.Replace("&nbsp;", "")
                        .Quantity = dgViewMaster.Items(x).Cells(7).Text
                        .CompositionName = dgViewMaster.Items(x).Cells(8).Text
                        .FabricName = dgViewMaster.Items(x).Cells(9).Text
                        .PocketLining = dgViewMaster.Items(x).Cells(10).Text
                        .WashingDetail = dgViewMaster.Items(x).Cells(11).Text.Replace("&nbsp;", "")
                        .Remarks = dgViewMaster.Items(x).Cells(12).Text.Replace("&nbsp;", "")
                        .ThreadsNew = dgViewMaster.Items(x).Cells(13).Text
                        .WidthCutable = dgViewMaster.Items(x).Cells(14).Text.Replace("&nbsp;", "")
                        .CreatDatee = dgViewMaster.Items(x).Cells(16).Text
                        .Save()
                    End With
                End If
            Next
            Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
            Dim objSqlConnection As New SqlConnection
            Dim sqlCmd As New SqlCommand
            objSqlConnection = New SqlConnection(strConnection)
            sqlCmd = New SqlCommand("sp_SampleProgramSheetExcelExcelNew", objSqlConnection)
            sqlCmd.CommandType = CommandType.StoredProcedure
            objSqlConnection.Open()
            sqlCmd.CommandTimeout = 5000
            sqlCmd.ExecuteNonQuery()
            objSqlConnection.Close()
            Dim MyPath As String = Request.PhysicalApplicationPath + "/SupplyChainXL/SupplyChainGenerated/"
            Dim sDate_time As String
            Dim sDestination_path As String
            Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
            Dim File_destination As CrystalDecisions.Shared.DiskFileDestinationOptions
            Dim Format_options As CrystalDecisions.Shared.PdfRtfWordFormatOptions
            myExportOptions = New CrystalDecisions.Shared.ExportOptions()
            File_destination = New CrystalDecisions.Shared.DiskFileDestinationOptions()
            Format_options = New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
            sDate_time = DateTime.Now.ToString("ddMMyyyyHHmmssff")
            FileName = "SampleProgramSheet"
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
            datee = ""
            Response.AppendHeader("Content-Disposition", "attachment; filename=""SampleProgramSheet-" + datee + ".xls")
            Response.TransmitFile(MyPath + "/" + FileName + ".xls")
            Response.End()
        Catch ex As Exception
        End Try
    End Sub
    Sub Bind()
        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            CheckDate = 1
        Else
            CheckDate = 0
        End If
        Dim CustomerName As String = cmbSupplier.SelectedItem.Text
        Dim DalNo As String = cmbDalNO.SelectedItem.Text
        Dim Style As String = cmbStyle.SelectedItem.Text

        Dim OBJDATE As New GeneralCode
        Dim sdatee, edate As String


        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            sdatee = OBJDATE.GetDateByMonth(txtDateFrom.SelectedDate)
            edate = OBJDATE.GetDateByMonth(txtDateTo.SelectedDate)
        Else
            sdatee = txtDateFrom.SelectedDate.ToString
            edate = txtDateTo.SelectedDate.ToString
        End If



        'Dim dt As DataTable = objDPPOMst.GetReportData(CustomerName, Style, DalNo, CheckDate, txtDateFrom.SelectedDate.Value.ToString("dd/MM/yyyy"), txtDateTo.SelectedDate.Value.ToString("dd/MM/yyyy"))
        Dim dt As DataTable = objDPPOMst.GetReportData(CustomerName, Style, DalNo, CheckDate, sdatee, edate)
        If dt.Rows.Count > 0 Then
            dtAccess = New DataTable
            With dtAccess
                .Columns.Add("DPRNDid", GetType(Long))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("Buyer", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Descriptionn", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Quantity", GetType(Decimal))
                .Columns.Add("CompositionName", GetType(String))
                .Columns.Add("FabricName", GetType(String))
                .Columns.Add("PocketLining", GetType(String))
                .Columns.Add("WashingDetail", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("ThreadsNew", GetType(String))
                .Columns.Add("WidthCutable", GetType(String))
                .Columns.Add("SampleStatus", GetType(Byte))
                .Columns.Add("CreatDatee", GetType(Date))
            End With
            For x = 0 To dt.Rows.Count - 1
                Dr = dtAccess.NewRow()
                Dr("DPRNDid") = dt.Rows(x)("DPRNDid")
                Dr("DalNo") = dt.Rows(x)("DalNo")
                Dr("Buyer") = dt.Rows(x)("Buyer")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("Descriptionn") = dt.Rows(x)("Descriptionn")
                Dr("Size") = dt.Rows(x)("Size")
                Dr("Quantity") = dt.Rows(x)("Quantity")
                Dr("CompositionName") = dt.Rows(x)("CompositionName")
                Dr("FabricName") = dt.Rows(x)("FabricName")
                Dr("PocketLining") = dt.Rows(x)("PocketLining")
                Dr("WashingDetail") = dt.Rows(x)("WashingDetail")
                Dr("Remarks") = dt.Rows(x)("Remarks")
                Dr("ThreadsNew") = dt.Rows(x)("ThreadsNew")
                Dr("WidthCutable") = dt.Rows(x)("WidthCutable")
                Dr("SampleStatus") = dt.Rows(x)("SampleStatus")
                Dr("CreatDatee") = dt.Rows(x)("CreatDatee")
                dtAccess.Rows.Add(Dr)
            Next
            Session("dtAccess") = dtAccess
            BINDGrid()
        Else
            Session("dtAccess") = dtAccess
            BINDGrid()
        End If


    End Sub
    Sub BINDGrid()
        dgViewMaster.DataSource = Session("dtAccess")
        dgViewMaster.DataBind()
        Dim X As Integer
        For X = 0 To dgViewMaster.Items.Count - 1
            Dim ChkDownLoad As CheckBox = CType(dgViewMaster.Items(X).FindControl("ChkDownLoad"), CheckBox)
            Dim samplestatus As Byte = dgViewMaster.Items(X).Cells(15).Text
            If samplestatus = 1 Then
                ChkDownLoad.Checked = True
            Else
                ChkDownLoad.Checked = False
            End If
        Next
    End Sub
    Protected Sub UpdateStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable
        Dim objDataView As DataView
        Dim x As Integer
        For x = 0 To dgViewMaster.Items.Count - 1
            Dim ChkDownLoad As CheckBox = CType(dgViewMaster.Items(x).FindControl("ChkDownLoad"), CheckBox)
            dt = Session("dtAccess")
            If ChkDownLoad.Checked = True Then
                dt.Rows(x)("SampleStatus") = 1
            Else
                dt.Rows(x)("SampleStatus") = 0
            End If
        Next
        Session("dtAccess") = dt
        BINDGrid()
    End Sub
    Protected Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgViewMaster.PageIndexChanged
        BINDGrid()
    End Sub
    Protected Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgViewMaster.SortCommand
        BINDGrid()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            objDPPoRecevMst.TruncateTableSampleProgram()
            Dim x As Integer
            For x = 0 To dgViewMaster.Items.Count - 1
                Dim ChkDownLoad As CheckBox = DirectCast(dgViewMaster.Items(x).FindControl("ChkDownLoad"), CheckBox)
                If ChkDownLoad.Checked = True Then
                    With ObjtempSampleProgramSheet
                        .Tempid = 0
                        .DalNo = dgViewMaster.Items(x).Cells(2).Text
                        .Buyer = dgViewMaster.Items(x).Cells(3).Text
                        .Style = dgViewMaster.Items(x).Cells(4).Text
                        .Descriptionn = dgViewMaster.Items(x).Cells(5).Text
                        .Sizee = dgViewMaster.Items(x).Cells(6).Text.Replace("&nbsp;", "")
                        .Quantity = dgViewMaster.Items(x).Cells(7).Text
                        .CompositionName = dgViewMaster.Items(x).Cells(8).Text
                        .FabricName = dgViewMaster.Items(x).Cells(9).Text
                        .PocketLining = dgViewMaster.Items(x).Cells(10).Text
                        .WashingDetail = dgViewMaster.Items(x).Cells(11).Text.Replace("&nbsp;", "")
                        .Remarks = dgViewMaster.Items(x).Cells(12).Text.Replace("&nbsp;", "")
                        .ThreadsNew = dgViewMaster.Items(x).Cells(13).Text
                        .WidthCutable = dgViewMaster.Items(x).Cells(14).Text.Replace("&nbsp;", "")
                        .CreatDatee = dgViewMaster.Items(x).Cells(16).Text
                        .Save()
                    End With
                End If
            Next
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/SampleProgrammeSheetForRNDNew.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "SampleProgramSheet"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                startDate = txtDateFrom.SelectedDate
                enddate = txtDateTo.SelectedDate
                CheckDate = 1
            Else
                CheckDate = 0
            End If
            Report.SetParameterValue(0, startDate)
            Report.SetParameterValue(1, enddate)
            Report.SetParameterValue(2, CheckDate)
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
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
Public Class FabricReceiveListReport
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindSupplier()
            BindSupplierArtNo()
        End If

    End Sub
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
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetSupplierforFabricReceiveList()
            cmbSupplier.DataSource = dtDalNo
            cmbSupplier.DataTextField = "SupplierName"
            'cmbSupplier.DataValueField = "SupplierID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplierArtNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetSupplierArtNoFroFabricReceiveList()
            cmbFabricName.DataSource = dtDalNo
            cmbFabricName.DataTextField = "FabricName"
            'cmbSupplierArtNo.DataValueField = "FabricDbMstID"
            cmbFabricName.DataBind()
            cmbFabricName.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click

        Dim DalNo As Long = cmbDal.SelectedValue
        Dim SupplierName As String = cmbSupplier.SelectedItem.Text
        Dim FabricName As String = cmbFabricName.SelectedItem.Text

        'Delete All PDF files from Folder
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        'End Delete
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/FabricReceive.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "FabricReceiveListSheet"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"



        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            CheckDate = 1
            Report.SetParameterValue(0, DalNo)
            Report.SetParameterValue(1, txtDateFrom.SelectedDate)
            Report.SetParameterValue(2, txtDateTo.SelectedDate)
            Report.SetParameterValue(3, SupplierName)
            Report.SetParameterValue(5, FabricName)
            Report.SetParameterValue(4, CheckDate)

        Else
            CheckDate = 0
           Report.SetParameterValue(0, DalNo)
            Report.SetParameterValue(1, Date.Now)
            Report.SetParameterValue(2, Date.Now)
            Report.SetParameterValue(3, SupplierName)
            Report.SetParameterValue(5, FabricName)
            Report.SetParameterValue(4, CheckDate)

        End If

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

    End Sub
End Class
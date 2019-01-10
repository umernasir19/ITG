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
Public Class GGTConsumptionReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim objDPPoRecevMst As New DPPoRecevMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindStyle()
            BindBuyer()
        End If

    End Sub
    Sub BindDALNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetDalNoFromRNDANDFabricCon()
            cmbDal.DataSource = dtDalNo
            cmbDal.DataTextField = "DalNo"
            cmbDal.DataBind()
            cmbDal.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dt As DataTable
            dt = objDPPoRecevMst.GetStyleFromRNDANDFabricCon()
            cmbStyle.DataSource = dt
            cmbStyle.DataTextField = "StyleCode"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindBuyer()
        Try
            Dim dt As DataTable
            dt = objDPPoRecevMst.GetBuyerFromRNDANDFabricCon()
            cmbBuyer.DataSource = dt
            cmbBuyer.DataTextField = "CustomerName"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        ' If cmbDal.SelectedValue <> 0 Then

        Dim DalNo As String = cmbDal.SelectedItem.Text
        Dim Supplier As String = cmbStyle.SelectedItem.Text
        Dim Buyer As String = cmbBuyer.SelectedItem.Text

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
        Dim FileName As String = "Fabric List Sheet_"
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
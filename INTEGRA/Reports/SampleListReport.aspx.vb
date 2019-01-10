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
Public Class SampleListReport
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim CheckDate As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDALNo()
            BindStyle()
            BindDescription()
        End If

    End Sub
    Sub BindDALNo()
        Try
            Dim dtDalNo As DataTable
            dtDalNo = objDPPoRecevMst.GetDalNOforRND()
            cmbDal.DataSource = dtDalNo
            cmbDal.DataTextField = "DalNo"
            cmbDal.DataValueField = "DPRNDID"
            cmbDal.DataBind()
            cmbDal.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetStylefoRND()
            cmbStyle.DataSource = dtStyle
            cmbStyle.DataTextField = "Style"
            ' cmbStyle.DataValueField = "DPRNDID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindDescription()
        Try
            Dim dtStyle As DataTable
            dtStyle = objDPPoRecevMst.GetDescriptionforRND()
            cmbDescription.DataSource = dtStyle
            cmbDescription.DataTextField = "Description"
            'cmbDescription.DataValueField = "DPRNDID"
            cmbDescription.DataBind()
            cmbDescription.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
   
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click

        Dim DalNo As Long = cmbDal.SelectedValue
        Dim Style As String = cmbStyle.SelectedItem.Text
        Dim Description As String = cmbDescription.SelectedItem.Text

        'Delete All PDF files from Folder
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        'End Delete
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/RNDSampleList.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "SampleListSheet"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"



        If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
            CheckDate = 1
            Report.SetParameterValue(0, DalNo)
            Report.SetParameterValue(1, Style)
            Report.SetParameterValue(2, Description)
            Report.SetParameterValue(5, CheckDate)
            Report.SetParameterValue(3, txtDateFrom.SelectedDate)
            Report.SetParameterValue(4, txtDateTo.SelectedDate)

        Else
            CheckDate = 0
            Report.SetParameterValue(0, DalNo)
            Report.SetParameterValue(1, Style)
            Report.SetParameterValue(2, Description)
            Report.SetParameterValue(3, Date.Now)
            Report.SetParameterValue(4, Date.Now)
            Report.SetParameterValue(5, CheckDate)
         
         


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
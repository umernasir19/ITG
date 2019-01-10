Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Xml
Imports Telerik.Web.UI
Public Class SampleReceiveSheet
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindStyle()
            BindDSRNO()
            BindBuyer()
        End If
    End Sub
    Sub BindStyle()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetStyleForSamploeReceiveSheet
            cmbStyle.DataSource = dtsupplier
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataValueField = "DPRNDID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindDSRNO()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetDSRNOForSamploeReceiveSheet
            cmbDSRNO.DataSource = dtsupplier
            cmbDSRNO.DataTextField = "DSRNO"
            'cmbDSRNO.DataValueField = "DPRNDID"
            cmbDSRNO.DataBind()
            cmbDSRNO.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindBuyer()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetBuyerForSamploeReceiveSheetNew
            cmbBuyer.DataSource = dtsupplier
            cmbBuyer.DataTextField = "Buyer"
            'cmbBuyer.DataValueField = "DPRNDID"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try

            Dim Style As String = cmbStyle.SelectedItem.Text
            Dim DSRNO As String = cmbDSRNO.SelectedItem.Text
            Dim Buyer As String = cmbBuyer.SelectedItem.Text

            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/SampleReceiveSheetStyleWise.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "SampleReceiveSheet"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"



            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                Report.SetParameterValue(1, txtDateTo.SelectedDate)
                Report.SetParameterValue(2, Style)
                Report.SetParameterValue(3, DSRNO)
                Report.SetParameterValue(4, Buyer)
                Report.SetParameterValue(5, CheckDate)

            Else
                CheckDate = 0
               Report.SetParameterValue(0, Date.Now)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, Style)
                Report.SetParameterValue(3, DSRNO)
                Report.SetParameterValue(4, Buyer)
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

         
        Catch ex As Exception

        End Try
    End Sub

End Class
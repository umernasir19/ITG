Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Xml
Imports Telerik.Web.UI
Public Class StyleListReport
    Inherits System.Web.UI.Page

    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindStyle()
            BindDescription()
            BindCustomer()
        End If
    End Sub
    Sub BindStyle()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetStyleForStyleDatabase
            cmbStyle.DataSource = dtsupplier
            cmbStyle.DataTextField = "StyleCode"
            cmbStyle.DataValueField = "DPStyleDatabaseID"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindDescription()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetDescriptionForStyleDatabase
            cmbDescription.DataSource = dtsupplier
            cmbDescription.DataTextField = "Description"
            cmbDescription.DataValueField = "DPStyleDatabaseID"
            cmbDescription.DataBind()
            cmbDescription.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetCustomerForStyleDatabase
            cmbCustomer.DataSource = dtsupplier
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try

            Dim Style As Long = cmbStyle.SelectedValue
            Dim Description As String = cmbDescription.SelectedItem.Text
            Dim CustomerID As Long = cmbCustomer.SelectedValue
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/StyleList.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "StyleListSheet"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                CheckDate = 1
                Report.SetParameterValue(0, Style)
                Report.SetParameterValue(3, Description)
                Report.SetParameterValue(4, CustomerID)
                Report.SetParameterValue(5, CheckDate)
                Report.SetParameterValue(1, txtDateFrom.SelectedDate)
                Report.SetParameterValue(2, txtDateTo.SelectedDate)
            Else
                CheckDate = 0
                Report.SetParameterValue(0, Style)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, Date.Now)
                Report.SetParameterValue(3, Description)
                Report.SetParameterValue(4, CustomerID)
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
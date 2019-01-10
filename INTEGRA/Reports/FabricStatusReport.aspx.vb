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
Public Class FabricStatusReport
    Inherits System.Web.UI.Page

    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSupplier()

        End If
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetSupplierForFabricLedger
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindDalNo()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindDalNo()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetDALNOForFabricLedger(cmbSupplier.SelectedValue)
            cmbDalNo.DataSource = dtsupplier
            cmbDalNo.DataTextField = "DalNo"
            cmbDalNo.DataValueField = "FabricDbMstID"
            cmbDalNo.DataBind()
            cmbDalNo.Items.Insert(0, New RadComboBoxItem("All", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try

            If cmbSupplier.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Supplier")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions


                Dim Supplierid As String = cmbSupplier.SelectedValue
                Dim FabricDbMstid As String = cmbDalNo.SelectedValue
                Report.Load(Server.MapPath("..\Reports/FabricStatus.rpt"))
                Report.Refresh()

                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "FabricStatusSheet"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1
                    Report.SetParameterValue(0, Supplierid)
                    Report.SetParameterValue(1, FabricDbMstid)
                    Report.SetParameterValue(2, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(3, txtDateTo.SelectedDate)
                    Report.SetParameterValue(4, CheckDate)

                Else
                    CheckDate = 0
                    Report.SetParameterValue(0, Supplierid)
                    Report.SetParameterValue(1, FabricDbMstid)
                    Report.SetParameterValue(2, Date.Now)
                    Report.SetParameterValue(3, Date.Now)
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

             
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
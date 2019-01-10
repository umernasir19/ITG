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
Public Class FabricStockLedger
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim CheckDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDalNo()
        End If

    End Sub
    Sub BindDalNo()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetDalNo
            cmbDalNo.DataSource = dtsupplier
            cmbDalNo.DataTextField = "DalNo"
            cmbDalNo.DataValueField = "FabricDBMstID"
            cmbDalNo.DataBind()
            cmbDalNo.Items.Insert(0, New RadComboBoxItem("ALL", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            If cmbDalNo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select DalNo")
            Else
                Dim DalNo As String = cmbDalNo.SelectedItem.Text
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                'Delete All PDF files from Folder
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                ReportFunction()

                Dim dt As DataTable = objDPPoRecevMst.GetOpenQTy(cmbDalNo.SelectedItem.Text) 'GetFBDataforFabStockSumry(SupplierDatabaseID)
                Dim OpenningBalance As Decimal = 0
                OpenningBalance = Val(dt.Rows(0)("OPQty")) + Val(dt.Rows(0)("PurchaseQty"))


                Report.Load(Server.MapPath("..\Reports/FabricStockLedgerNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "FabricStockLedger"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"


                If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                    CheckDate = 1

                    Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                    Report.SetParameterValue(1, txtDateTo.SelectedDate)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, DalNo)
                    Report.SetParameterValue(4, OpenningBalance)

                Else
                    CheckDate = 0

                    Report.SetParameterValue(0, Date.Now)
                    Report.SetParameterValue(1, Date.Now)
                    Report.SetParameterValue(2, CheckDate)
                    Report.SetParameterValue(3, DalNo)
                    Report.SetParameterValue(4, OpenningBalance)
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
    Sub ReportFunction()
        objDPPoRecevMst.TruncateTempStockSummaryTable()
        objDPPoRecevMst.TruncateTempStockSummaryFinal()
        objDPPoRecevMst.InsertIssueDataNewStockSummary()
        objDPPoRecevMst.InsertIssueDataFromFabricIssueforStockSummary()
        objDPPoRecevMst.InsertReceiveDataNewforStockSummary()
        objDPPoRecevMst.InsertFinalTemTableforStockSummary()

    End Sub

End Class
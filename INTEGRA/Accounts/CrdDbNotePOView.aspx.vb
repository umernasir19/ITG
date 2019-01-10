Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class CrdDbNotePOView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objDataView, objMasterDataView As DataView
    Dim ObjCrdDbNotePurchaseOrder As New CrdDbNotePurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                BindGrid()

            Catch objUDException As UDException
            End Try
        End If
    End Sub

    Sub BindGrid()
        Dim dt As DataTable
        dt = ObjCrdDbNotePurchaseOrder.GetView()
        dgInvoiceView.DataSource = dt
        dgInvoiceView.DataBind()

    End Sub
    Protected Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgInvoiceView.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgInvoiceView.SortCommand
        BindGrid()
    End Sub


    Protected Sub btndAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndAdd.Click
        Response.Redirect("CdDbPurchaseOrder.aspx")
    End Sub

    Protected Sub dgInvoiceView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgInvoiceView.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("~/Reports/POCreditDebitNote.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim NoteID As Long = dgInvoiceView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim CDNoteNo As String = dgInvoiceView.Items(e.Item.ItemIndex).Cells(4).Text

                    Dim FileName As String = "P.O.CreditDebitNote-" + CDNoteNo
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, NoteID)
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
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class

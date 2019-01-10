Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra

Imports System.Data.DataTable
Imports Telerik.Web.UI
Public Class ShipmentFormView
    Inherits System.Web.UI.Page

    Dim objComplainDatabase As New ComplainDatabase
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Shipment View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView

            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objComplainDatabase.GetBindShipmentView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("ShipmentFormEntry.aspx")
    End Sub
    'Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
    '    Try
    '        Select Case e.CommandName
    '            Case "PDF"


    '                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
    '                    System.IO.File.Delete(Uploadedfiles)
    '                Next
    '                Dim DPIMstID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text

    '                Report.Load(Server.MapPath("..\Reports/CustomPackingList.rpt"))

    '                Report.Refresh()
    '                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
    '                di.Create()


    '                Dim FileName As String = "PACKINGLIST" '+ SalesContract
    '                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
    '                Report.SetParameterValue(0, DPIMstID)
    '                Dim FileOption As New DiskFileDestinationOptions
    '                FileOption.DiskFileName = sTempFileName
    '                Options = Report.ExportOptions
    '                Options.ExportDestinationType = ExportDestinationType.DiskFile
    '                Options.ExportFormatType = ExportFormatType.PortableDocFormat
    '                Options.DestinationOptions = FileOption
    '                Options.ExportDestinationOptions = FileOption
    '                Report.SetDatabaseLogon("sa", "pwd")
    '                Report.Export()

    '                If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
    '                    Dim strFileSize As String = ""
    '                    Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
    '                    Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
    '                    Dim fi As IO.FileInfo
    '                    For Each fi In aryFi
    '                        Response.ClearHeaders()
    '                        Response.ClearContent()
    '                        Response.ContentType = "application/octet-stream"
    '                        Response.Charset = "UTF-8"
    '                        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
    '                        Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
    '                        Response.End()
    '                    Next
    '                End If

    '        End Select

    '    Catch ex As Exception
    '    End Try
    'End Sub

End Class
Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class PackingListView
    Inherits System.Web.UI.Page
    Dim objPackingList As New PackingList
    Dim dr As DataRow
    Dim dt As DataTable
    Dim dtPackingList As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Session("dtPackingList") = Nothing
                Dim objDataView As DataView
                PageHeader("Packing List Panel")
                objDataView = LoadData("ALL")
                Session("objPackingListView") = objDataView
                BindPackingListView()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadData(ByVal Style) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPackingList.GetPackingListView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindPackingListView()
        Try
            Dim objDataView As DataView
            objDataView = Session("objPackingListView")
            dgPackingListView.DataSource = objDataView
            dgPackingListView.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgPackingListView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPackingListView.ItemCommand
        Select Case e.CommandName
            Case Is = "PDF"
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim PackingListID As String = item("PackingListID").Text
                Dim PackingListNo As String = item("PackingListNo").Text

                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Report.Load(Server.MapPath("..\Reports/PackingList.rpt"))

                Dim FileName As String = "Packing List-" + PackingListNo
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, PackingListID)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "Packing List-" + PackingListNo + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next
        End Select
    End Sub
    Protected Sub btnCreatePackingList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreatePackingList.Click
        Response.Redirect("PackingListAdd.aspx")
    End Sub
End Class
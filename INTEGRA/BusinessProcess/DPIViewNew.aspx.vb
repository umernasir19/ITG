Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPIViewNew
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView


        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgPI.DataSource = objDataView
            dgPI.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjDPIMst.GetView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("DPIAdd.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPi_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPI.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim DPIMstID As String = item("DPIMstID").Text
                    Dim CustomID As String = item("CustomID").Text
                    Dim SalesContract As String = item("SalesContract").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'Dim DPIMstID As Long = dgPI.Items(e.Item.ItemIndex).Cells(0).Text
                    'Dim CustomerID As Long = dgPI.Items(e.Item.ItemIndex).Cells(3).Text
                    'Dim SalesContract As String = dgPI.Items(e.Item.ItemIndex).Cells(4).Text

                    If CustomID = 14 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoicePortrait.rpt"))
                    ElseIf CustomID = 13 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceArmandThierySASPortrait.rpt"))
                    ElseIf CustomID = 12 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceMayoralModaSAUPortrait.rpt"))
                    End If


                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()


                    Dim FileName As String = "PROFORMA INVOICE-" '+ SalesContract
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, DPIMstID)
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
    Protected Sub dgPi_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgPI.NeedDataSource
        ' dgPI.DataSource = ObjDPIMst.GetAllData()
    End Sub
    Protected Sub dgPi_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgPI.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgPi_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgPI.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgPi_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgPI.SortCommand
        BindGrid()
    End Sub


End Class
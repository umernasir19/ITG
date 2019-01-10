Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ItemViewForAccessories
    Inherits System.Web.UI.Page
    Dim ObjIMSItem As New IMSItem
    Dim UserId As Long
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                bindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("ITEM CHART OF ACCOUNT LIST")
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItem.GetIMSItemAllNewAccessories
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgItemView.DataSource = objDataView
        dgItemView.DataBind()
        dgItemView.Columns(5).Visible = False
        dgItemView.Columns(4).Visible = False
        dgItemView.Columns(6).Visible = True
    End Sub
    Protected Sub LinkButtoniTEMlIST_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtoniTEMlIST.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\..\Reports/ItemListReport.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "ItemList"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Report.SetParameterValue(0, 2)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Report.SetParameterValue(0, 1)
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Report.SetParameterValue(0, 2)
                    ' ElseIf UserId = 243 Then
                    '    Report.SetParameterValue(0, 3)
                    'ElseIf UserId = 244 Then
                    '    Report.SetParameterValue(0, 4)
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Report.SetParameterValue(0, 2)
                End If
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
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
   
    Protected Sub dgItemView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgItemView.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "PDF"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim IMSItemID As String = item("IMSItemID").Text

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\..\Reports/ItemList.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "ItemInformation"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, IMSItemID)
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

    Protected Sub dgItemView_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgItemView.NeedDataSource
        dgItemView.DataSource = ObjIMSItem.GetIMSItemAllNewAccessories()
    End Sub
    Protected Sub dgItemView_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgItemView.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgItemView_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgItemView.PageIndexChanged

        dgItemView.Columns(6).Visible = True
        Dim dtt As DataTable
        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
        dgItemView.DataSource = dtt
        dgItemView.DataBind()
        dgItemView.Columns(5).Visible = False
        dgItemView.Columns(4).Visible = False


    End Sub
    Protected Sub dgItemView_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgItemView.SortCommand
        dgItemView.Columns(6).Visible = True
        Dim dtt As DataTable
        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
        dgItemView.DataSource = dtt
        dgItemView.DataBind()
        dgItemView.Columns(5).Visible = False
        dgItemView.Columns(4).Visible = False
    End Sub
End Class
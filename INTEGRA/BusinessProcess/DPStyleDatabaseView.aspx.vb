Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class DPStyleDatabaseView
    Inherits System.Web.UI.Page
    Dim ObjStyleDatabaseClass As New StyleDatabaseClass
    Dim userid As Long
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            GetRights()
        End If
    End Sub
    Sub GetRights()
         Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btnStyleDatabase.Enabled = True
            Else
                btnStyleDatabase.Enabled = False
            End If
            If View = 1 Then
                dgStyleDatabase.MasterTableView.GetColumn("View").Display = True
            Else
                dgStyleDatabase.MasterTableView.GetColumn("View").Display = False
            End If
        End If
    End Sub
    Protected Sub dgStyleDatabase_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgStyleDatabase.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgStyleDatabase.DataSource = objDataView
            dgStyleDatabase.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjStyleDatabaseClass.BindStyleGrid()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgStyleDatabase_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgStyleDatabase.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgStyleDatabase_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgStyleDatabase.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgStyleDatabase_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgStyleDatabase.NeedDataSource
        BindGrid()
    End Sub
    Protected Sub btnStyleDatabase_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStyleDatabase.Click
        Try
            Response.Redirect("DPStyleDatabase.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgStyleDatabase_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgStyleDatabase.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPRNDID As String = item("DPRNDID").Text
                    Response.Redirect("DPRND.aspx?lDPRNDID=" & lDPRNDID & "")
                Case Is = "PDF"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPStyleDatabaseId As String = item("DPStyleDatabaseId").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/StyleDB.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Style_Database_Report"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lDPStyleDatabaseId)
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
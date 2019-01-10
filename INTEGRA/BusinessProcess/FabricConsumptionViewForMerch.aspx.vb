Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FabricConsumptionViewForMerch
    Inherits System.Web.UI.Page
    Dim objfabricconsump As New FabricConsump
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
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "G.G.T" Then
                    cmdAddd.Visible = False
                ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                    cmdAddd.Visible = False
                End If
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
        'If PathArr.Length > 2 Then
        '    Dim Path2 As String = PathArr(1)
        '    Dim Path3 As String = PathArr(2)
        '    Dim Path4 As String = Path2 + "/" + Path3
        '    dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        'ElseIf PathArr.Length > 3 Then
        '    Dim Path1 As String = PathArr(1)
        '    Dim Path2 As String = PathArr(2)
        '    Dim Path3 As String = PathArr(3)
        '    Dim Path4 As String = Path2 + "/" + Path3
        '    dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        'End If
        ' Dim Path2 As String = Path.Substring(1, Path.Length - 1)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                cmdAddd.Enabled = True
            Else
                cmdAddd.Enabled = False
            End If
            If View = 1 Then
                dgVieww.MasterTableView.GetColumn("View").Display = True
            Else
                dgVieww.MasterTableView.GetColumn("View").Display = False
            End If
            If Delete = 1 Then
                dgVieww.MasterTableView.GetColumn("DeleteColumn").Display = True
            Else
                dgVieww.MasterTableView.GetColumn("DeleteColumn").Display = False
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgVieww.DataSource = objDataView
            dgVieww.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objfabricconsump.GetBindGridForFabricConsmpForMerch()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub cmdAddd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddd.Click
        Try
            Response.Redirect("FabricConsumption.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgVieww_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgVieww.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgVieww_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgVieww.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgVieww_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgVieww.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgVieww_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgVieww.ItemCommand
        Try
            Select Case e.CommandName

                Case Is = "PDF"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricConsumptionID As String = item("FabricConsumptionID").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/FabricConsumptionSheet.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "FabricConsumptionReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lFabricConsumptionID)
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
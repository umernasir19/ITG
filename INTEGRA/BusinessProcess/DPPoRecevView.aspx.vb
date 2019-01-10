Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPPoRecevView
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objTblDPRND As New TblDPRND
    Dim OBJPOMST As New DPPOMst
    Dim Userid As Long
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = Session("UserId")
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
        dt = ObjDepartmentDataBase.CheckdataWithAccess(Userid, Path4)
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
                btnAddSampling.Enabled = True
            Else
                btnAddSampling.Enabled = False
            End If
            If View = 1 Then
                dgPOReceive.MasterTableView.GetColumn("View").Display = True
            Else
                dgPOReceive.MasterTableView.GetColumn("View").Display = False
            End If
            If Delete = 1 Then
                dgPOReceive.MasterTableView.GetColumn("DeleteColumn").Display = True
            Else
                dgPOReceive.MasterTableView.GetColumn("DeleteColumn").Display = False
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgPOReceive.DataSource = objDataView
            dgPOReceive.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objDPPoRecevMst.GetAllData()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Response.Redirect("DPPoRecev.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPOReceive_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPOReceive.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOReceiveMstID As String = item("POReceiveMstID").Text
                    Response.Redirect("DPPoRecev.aspx?lPOReceiveMstID=" & lPOReceiveMstID & "")


                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    ' Dim DPCourierMstId As Integer = dgCourier.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOReceiveMstID As String = item("POReceiveMstID").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/POReceiveReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "POReceiveReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lPOReceiveMstID)

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


                Case Is = "Delete"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOReceiveMstID As String = item("POReceiveMstID").Text
                    OBJPOMST.DeletedForPOReceiveMaster(lPOReceiveMstID)
                    OBJPOMST.DeletedForPOReceiveDetail(lPOReceiveMstID)
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()


            End Select
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPOReceive_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgPOReceive.NeedDataSource

        dgPOReceive.DataSource = objDPPoRecevMst.GetAllData()
    End Sub
    Protected Sub dgPOReceive_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgPOReceive.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgPOReceive_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgPOReceive.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgPOReceive_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgPOReceive.SortCommand
        BindGrid()
    End Sub

End Class
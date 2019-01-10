Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FabricConsumptionView
    Inherits System.Web.UI.Page
    Dim objfabricconsump As New FabricConsump
    Dim userid As Long
    Dim objDPPOMst As New DPPOMst
    Dim objDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            GetRights()
            Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    dgVieww.MasterTableView.GetColumn("GGTFromFStore").Display = True
                    dgVieww.MasterTableView.GetColumn("GGTFromMerch").Display = False
                Else
                    Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                    If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                        dgVieww.MasterTableView.GetColumn("GGTFromFStore").Display = False
                        dgVieww.MasterTableView.GetColumn("GGTFromMerch").Display = True
                    ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                        dgVieww.MasterTableView.GetColumn("GGTFromFStore").Display = True
                        dgVieww.MasterTableView.GetColumn("GGTFromMerch").Display = False
                    ElseIf DtCheckk.Rows(0)("Department") = "G.G.T" Then
                        cmdAddd.Visible = False
                        dgVieww.MasterTableView.GetColumn("DeleteColumn").Display = False
                    End If
                End If
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
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                objDataTable = objfabricconsump.GetBindGridForFabricConsmpForFStore()
            Else
                Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                    objDataTable = objfabricconsump.GetBindGridForFabricConsmpForMerch()
                ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                    objDataTable = objfabricconsump.GetBindGridForFabricConsmpForFStore()
                End If
            End If
        End If
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
    Protected Sub dgVieww_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgVieww.NeedDataSource
        Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dgVieww.DataSource = objfabricconsump.GetBindGridForFabricConsmpForFStore()
            Else
                Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                    dgVieww.DataSource = objfabricconsump.GetBindGridForFabricConsmpForMerch()
                ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                    dgVieww.DataSource = objfabricconsump.GetBindGridForFabricConsmpForFStore()
                End If
            End If
        End If
            '  dgVieww.DataSource = objfabricconsump.GetBindGridForFabricConsmpForMerchForDirectorView()
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
                Case Is = "Delete"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricConsumptionID As String = item("FabricConsumptionID").Text
                    objfabricconsump.DeletedFabricConMaster(lFabricConsumptionID)
                    objfabricconsump.DeletedFabricConDetail(lFabricConsumptionID)
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPFabricDBView
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim lFabricIssueID, userid As Long
    Dim objDataView As DataView
    Dim DalNo As String
    Dim Type As String
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindType()
            Type = Request.QueryString("Type")
            cmbType.SelectedValue = Type
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    btnAddSampling.Visible = False
                    dgFabricDB.MasterTableView.GetColumn("View").Display = False
                    dgFabricDB.MasterTableView.GetColumn("PDF").Display = True
                    dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
                Else
                        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                            btnAddSampling.Visible = False
                            dgFabricDB.MasterTableView.GetColumn("View").Display = False
                            dgFabricDB.MasterTableView.GetColumn("PDF").Display = True
                            dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
                        ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                            btnAddSampling.Visible = False
                            dgFabricDB.MasterTableView.GetColumn("View").Display = False
                            dgFabricDB.MasterTableView.GetColumn("PDF").Display = False
                            dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
                        Else
                            btnAddSampling.Visible = True
                        End If
                    End If
                    GetRights()
            End If
        End If
        PageHeader("Fabric View")
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
                btnAddSampling.Enabled = True
            Else
                btnAddSampling.Enabled = False
            End If
            If View = 1 Then
                dgFabricDB.MasterTableView.GetColumn("View").Display = True
            Else
                dgFabricDB.MasterTableView.GetColumn("View").Display = False
            End If
            If Delete = 1 Then
                dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = True
            Else
                dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindType()
        Try
            Dim dtType As DataTable
            dtType = objDPFabricDbMst.GetdpTYPENEW
            cmbType.DataSource = dtType
            cmbType.DataTextField = "DPTypeName"
            cmbType.DataValueField = "DPTypeID"
            cmbType.DataBind()
            cmbType.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbType.SelectedIndexChanged
        Try
            Type = cmbType.SelectedValue
            If cmbType.SelectedValue = 1 Or cmbType.SelectedValue = 2 Then
                Dim dtt As DataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                dgFabricDB.DataSource = dtt
                dgFabricDB.DataBind()
                GetRights()
                Dim dt As DataTable = objDPFabricDbMst.GetAllDataNewForSearching(cmbType.SelectedValue)
                dgFabricDB.DataSource = dt
                dgFabricDB.DataBind()
                GetRights()
            ElseIf cmbType.SelectedValue = 7 Then
                Dim dtt As DataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                dgFabricDB.DataSource = dtt
                dgFabricDB.DataBind()
                GetRights()
                Dim dt As DataTable = objDPFabricDbMst.GetAllDataNewForSearchingImp(cmbType.SelectedValue)
                dgFabricDB.DataSource = dt
                dgFabricDB.DataBind()
                GetRights()
            ElseIf cmbType.SelectedValue = 0 Then
                Dim dtt As DataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                dgFabricDB.DataSource = dtt
                dgFabricDB.DataBind()
                GetRights()
                Dim dt As DataTable = objDPFabricDbMst.GetAllDataNew()
                dgFabricDB.DataSource = dt
                dgFabricDB.DataBind()
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgFabricDB.DataSource = objDataView
            dgFabricDB.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Try
            Type = cmbType.SelectedValue
            If cmbType.SelectedValue = 1 Or cmbType.SelectedValue = 2 Then
                objDataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                objDataTable = objDPFabricDbMst.GetAllDataNewForSearching(cmbType.SelectedValue)
            ElseIf cmbType.SelectedValue = 7 Then
                objDataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                objDataTable = objDPFabricDbMst.GetAllDataNewForSearchingImp(cmbType.SelectedValue)
            ElseIf cmbType.SelectedValue = 0 Then
                objDataTable = objDPFabricDbMst.GetAllDataNewForSearching(0)
                objDataTable = objDPFabricDbMst.GetAllDataNew()
            End If
        Catch ex As Exception
        End Try
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Dim str As String = cmbType.SelectedValue
            Response.Redirect("DAFabricDBEntry.aspx?Type=" & str)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgFabricDB_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgFabricDB.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricDBMstId As String = item("FabricDBMstId").Text
                    Response.Redirect("DAFabricDBEntry.aspx?lECPSamplingID=" & lFabricDBMstId & "")
                Case Is = "PDF"             
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim llFabricDBMstId As String = item("FabricDBMstId").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/FabricReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "FabricReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, llFabricDBMstId)
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
                    Dim lFabricDBMstId As String = item("FabricDBMstId").Text
                    Dim Checkdt As DataTable = objDPFabricDbMst.GetDalNoFromFDB(lFabricDBMstId)
                    If Checkdt.Rows.Count > 0 Then
                        DalNo = Checkdt.Rows(0)("DalNo")
                    End If
                    Dim dt1 As DataTable = objDPFabricDbMst.CheckExistingDataForSampleIssueFromFDB(lFabricDBMstId)
                    Dim dt2 As DataTable = objDPFabricDbMst.CheckExistingDataForSampleReceiveFromFDB(lFabricDBMstId)
                    Dim dt3 As DataTable = objDPFabricDbMst.CheckExistingDataForPOMstFromFDB(lFabricDBMstId)
                    Dim dt4 As DataTable = objDPFabricDbMst.CheckExistingDataForPOReceiveMstFromFDB(lFabricDBMstId)
                    Dim dt5 As DataTable = objDPFabricDbMst.CheckExistingDataForPOReceiveDtlFromFDB(lFabricDBMstId)
                    Dim dt6 As DataTable = objDPFabricDbMst.CheckExistingDataForPOIssueDtlFromFDB(lFabricDBMstId)
                    Dim dt7 As DataTable = objDPFabricDbMst.CheckExistingDataForWashDtlFromFDB(lFabricDBMstId)
                    Dim dt8 As DataTable = objDPFabricDbMst.CheckExistingDataForWashRecvDtlFromFDB(lFabricDBMstId)
                    Dim dt9 As DataTable = objDPFabricDbMst.CheckExistingDataForDPRNDFromFDB(lFabricDBMstId)
                    Dim dt10 As DataTable = objDPFabricDbMst.CheckExistingDataForimsitemFromFDB(lFabricDBMstId)
                    Dim dt11 As DataTable = objDPFabricDbMst.CheckExistingDataForConsumptionFromFDB(DalNo)
                    If dt1.Rows.Count > 0 Or dt2.Rows.Count > 0 Or dt3.Rows.Count > 0 Or dt4.Rows.Count > 0 Or dt5.Rows.Count > 0 Or dt6.Rows.Count > 0 Or dt7.Rows.Count > 0 Or dt8.Rows.Count > 0 Or dt9.Rows.Count > 0 Or dt10.Rows.Count > 0 Or dt11.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objDPFabricDbMst.DeletedDPFabricDbMst(lFabricDBMstId)
                        objDPFabricDbMst.DeletedDPFabricDbDtl(lFabricDBMstId)
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                        GetRights()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgFabricDB_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgFabricDB.NeedDataSource
        If cmbType.SelectedValue = 1 Or cmbType.SelectedValue = 2 Then
            dgFabricDB.DataSource = objDPFabricDbMst.GetAllDataNewForSearching(cmbType.SelectedValue)
     ElseIf cmbType.SelectedValue = 7 Then
            dgFabricDB.DataSource = objDPFabricDbMst.GetAllDataNewForSearchingImp(cmbType.SelectedValue)
          ElseIf cmbType.SelectedValue = 0 Then
            dgFabricDB.DataSource = objDPFabricDbMst.GetAllDataNew()
        End If
    End Sub
    Protected Sub dgFabricDB_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgFabricDB.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgFabricDB_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgFabricDB.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Protected Sub dgFabricDB_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgFabricDB.SortCommand
        BindGrid()
        GetRights()
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPRNDView
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objTblDPRND As New TblDPRND
    Dim objDPPOMst As New DPPOMst
    Dim Userid As Long
    Dim objDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = Session("UserId")
        If Not Page.IsPostBack Then
            Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Department") = "Higher Management" Then
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                    dgRND.MasterTableView.GetColumn("GGTStatuss").Display = False
                    GetRights()
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                    If DtCheck.Rows(0)("Department") = "G.G.T" Then
                        btnAddSampling.Visible = False
                        dgRND.MasterTableView.GetColumn("DeleteColumn").Display = False
                        dgRND.MasterTableView.GetColumn("Status").Display = False
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                        GetRights()
                    ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                        btnAddSampling.Visible = False
                        dgRND.MasterTableView.GetColumn("View").Display = False
                        dgRND.MasterTableView.GetColumn("DeleteColumn").Display = False
                        dgRND.MasterTableView.GetColumn("Status").Display = False
                        dgRND.MasterTableView.GetColumn("GGTStatuss").Display = False
                        GetRights()
                    Else
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                        dgRND.MasterTableView.GetColumn("GGTStatuss").Display = False
                        GetRights()
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
        dt = ObjDepartmentDataBase.CheckdataWithAccess(Userid, Path4)
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
                dgRND.MasterTableView.GetColumn("View").Display = True
            Else
                dgRND.MasterTableView.GetColumn("View").Display = False
            End If
            If Delete = 1 Then
                dgRND.MasterTableView.GetColumn("DeleteColumn").Display = True
            Else
                dgRND.MasterTableView.GetColumn("DeleteColumn").Display = False
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgRND.DataSource = objDataView
            dgRND.DataBind()
           For i As Integer = 0 To dgRND.Items.Count - 1
                Dim lnkEdit As HyperLink = CType(dgRND.Items(i).FindControl("lnkEdit"), HyperLink)
                Dim item As GridDataItem = DirectCast(dgRND.Items(i), GridDataItem)
                Dim lDPRNDID As String = item("DPRNDID").Text
                Dim dt As DataTable = objTblDPRND.GetLocktoggt(lDPRNDID)
                Dim Lockggt As String = dt.Rows(0)("LockToGGT")
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "G.G.T" Then
                    If Lockggt = True Then
                        lnkEdit.Enabled = False
                    Else
                        lnkEdit.Enabled = True
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    lnkEdit.Visible = False
                End If
            Next
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(Userid)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
               objDataTable = objTblDPRND.GetAllDataNew()
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "G.G.T" Then
                    objDataTable = objTblDPRND.GetAllDataForGGT()
                Else
                    objDataTable = objTblDPRND.GetAllDataNew()
                End If
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Response.Redirect("DPRND.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgRND_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgRND.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPRNDID As String = item("DPRNDID").Text
                    Response.Redirect("DPRND.aspx?lDPRNDID=" & lDPRNDID & "")
                Case Is = "Delete"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPRNDID As String = item("DPRNDID").Text
                    Dim dtCheckFabricIssue As DataTable = objDPPOMst.CheckExistingDataForSampleIssue(lDPRNDID)
                    Dim dtSampleReceive As DataTable = objDPPOMst.CheckExistingDataForSampleReceive(lDPRNDID)
                    Dim dtDPPODtl As DataTable = objDPPOMst.CheckExistingDataForPurchaseOrder(lDPRNDID)
                    Dim dtDPWashDtl As DataTable = objDPPOMst.CheckExistingDataForWashIssue(lDPRNDID)
                    Dim dtDPWashRecvDtl As DataTable = objDPPOMst.CheckExistingDataForWashReceive(lDPRNDID)
                    If dtCheckFabricIssue.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Sample Issue")
                    ElseIf dtSampleReceive.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Sample Receive")
                    ElseIf dtDPPODtl.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Purchase Order")
                    ElseIf dtDPWashDtl.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Wash Issue")
                    ElseIf dtDPWashRecvDtl.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Wash Receive")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objDPPOMst.DeletedRNDMaster(lDPRNDID)
                        objDPPOMst.DeletedRNDAccDetail(lDPRNDID)
                        objDPPOMst.DeletedRNDStyleDetail(lDPRNDID)
                        Dim dtt As DataTable = objTblDPRND.GetAllData()
                        dgRND.DataSource = dtt
                        dgRND.DataBind()
                        For i As Integer = 0 To dgRND.Items.Count - 1
                            Dim lnkEdit As HyperLink = CType(dgRND.Items(i).FindControl("lnkEdit"), HyperLink)
                            If Userid = 245 Or Userid = "256" Or Userid = "257" Or Userid = "258" Or Userid = "259" Or Userid = "260" Or Userid = "261" Or Userid = "262" Or Userid = "263" Or Userid = "268" Or Userid = "269" Then
                                lnkEdit.Visible = False
                            End If
                        Next
                        GetRights()
                    End If
                Case Is = "PDF"
                    Dim DigitalSignature As Integer
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPRNDID As String = item("DPRNDID").Text
                    Dim DigitalSignaturee As String = item("DigitalSignature").Text
                    If DigitalSignaturee = True Then
                        DigitalSignature = 1
                    Else
                        DigitalSignature = 0
                    End If
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim dt As DataTable = ObjSupplier.GetUserStatus(Userid)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("Department") = "Higher Management" Then
                            If DigitalSignature > 0 Then
                                Report.Load(Server.MapPath("..\Reports/ConsumptionSheetForNewInquiryNewNewForGS.rpt"))
                                Report.Refresh()
                                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                                di.Create()
                                Dim FileName As String = "ConsumptionSheetForNewInquiryReport"
                                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                                Report.SetParameterValue(0, lDPRNDID)
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
                            Else
                                Report.Load(Server.MapPath("..\Reports/ConsumptionSheetForNewInquiryNewNew.rpt"))
                                Report.Refresh()
                                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                                di.Create()
                                Dim FileName As String = "ConsumptionSheetForNewInquiryReport"
                                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                                Report.SetParameterValue(0, lDPRNDID)
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
                            End If
                        Else
                            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                            If DtCheck.Rows(0)("Department") = "Merchandising" Then
                                Report.Load(Server.MapPath("..\Reports/RNDViewReport.rpt"))
                                Report.Refresh()
                                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                                di.Create()
                                Dim FileName As String = "ConsumptionSheetForNewInquiryReport"
                                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                                Report.SetParameterValue(0, lDPRNDID)
                                Report.SetParameterValue(1, lDPRNDID)
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
                            Else
                                If DigitalSignature > 0 Then
                                    Report.Load(Server.MapPath("..\Reports/ConsumptionSheetForNewInquiryNewNewForGS.rpt"))
                                    Report.Refresh()
                                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                                    di.Create()
                                    Dim FileName As String = "ConsumptionSheetForNewInquiryReport"
                                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                                    Report.SetParameterValue(0, lDPRNDID)
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
                                Else
                                    Report.Load(Server.MapPath("..\Reports/ConsumptionSheetForNewInquiryNewNew.rpt"))
                                    Report.Refresh()
                                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                                    di.Create()
                                    Dim FileName As String = "ConsumptionSheetForNewInquiryReport"
                                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                                    Report.SetParameterValue(0, lDPRNDID)
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
                                End If
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgRND_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgRND.NeedDataSource
        Dim dt As DataTable = ObjSupplier.GetUserStatus(Userid)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                 objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "G.G.T" Then
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Else
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                End If
            End If
        End If
    End Sub
    Protected Sub dgRND_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgRND.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgRND_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgRND.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgRND_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgRND.SortCommand
        BindGrid()
    End Sub
    Private Function DigitalSignature() As Integer
        Throw New NotImplementedException
    End Function
End Class
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
Public Class ItemView
    Inherits System.Web.UI.Page
    Dim ObjIMSItem As New IMSItem
    Dim UserId As Long
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    pnlItemQuality.Visible = True
                    dgItemView.Columns(4).Visible = True
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    cmdAdd.Visible = False
                    For i As Integer = 0 To dgItemView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgItemView.Items(i).FindControl("lnkEdit"), ImageButton)
                        lnkEdit.Visible = False
                    Next
                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    pnlItemQuality.Visible = True
                    dgItemView.Columns(4).Visible = True
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    dgItemView.Columns(5).Visible = True
                    dgItemView.Columns(6).Visible = True
                    dgItemView.Columns(7).Visible = False
                    dgItemView.Columns(8).Visible = True
                    pnlitemcat.Visible = True
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        pnlItemQuality.Visible = True
                        dgItemView.Columns(4).Visible = True
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        dgItemView.Columns(5).Visible = True
                        dgItemView.Columns(6).Visible = True
                        dgItemView.Columns(7).Visible = False
                        dgItemView.Columns(8).Visible = True
                        pnlitemcat.Visible = True
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                        pnlItemQuality.Visible = True
                        dgItemView.Columns(6).Visible = True
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        dgItemView.Columns(5).Visible = False
                        dgItemView.Columns(4).Visible = False
                        pnlDalwise.Visible = False
                    ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                        pnlItemQuality.Visible = True
                        dgItemView.Columns(6).Visible = True
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        dgItemView.Columns(5).Visible = False
                        dgItemView.Columns(4).Visible = False
                        pnlDalwise.Visible = False
                    ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                        pnlItemQuality.Visible = True
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        pnlDalwise.Visible = False
                        cmdAdd.Visible = False
                    ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                        pnlItemQuality.Visible = True
                        dgItemView.Columns(4).Visible = True
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        cmdAdd.Visible = False
                        For i As Integer = 0 To dgItemView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgItemView.Items(i).FindControl("lnkEdit"), ImageButton)
                            If DtCheck.Rows(0)("Department") = "Merchandising" Then
                                lnkEdit.Visible = False
                            End If
                        Next
                    Else
                        pnlItemQuality.Visible = True
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        pnlDalwise.Visible = False
                        cmdAdd.Visible = False
                    End If
                End If
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("ITEM CHART OF ACCOUNT LIST")
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path7 As String = PathArr(PathArr.Length - 3)
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path7 + "/" + Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(UserId, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgItemView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgItemView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
        End If
    End Sub
    Protected Sub txtItemCatForPdf_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemCatForPdf.TextChanged
        Try
            Dim dt As DataTable = ObjIMSItem.GetCateGoryID(txtItemCatForPdf.Text)
            If dt.Rows.Count > 0 Then
                lblItemCateID.Text = dt.Rows(0)("IMSItemCategoryID")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemNameFStore_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemNameFStore.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForF(txtItemNameFStore.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForF(txtItemNameFStore.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForF(txtItemNameFStore.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForA(txtItemNameFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()

                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForAGStore(txtItemNameFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForAForAuditor(txtItemNameFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForF(txtItemNameFStore.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingForAForAuditor(txtItemNameFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemQualityFStore_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemQualityFStore.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForF(txtItemQualityFStore.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForF(txtItemQualityFStore.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForF(txtItemQualityFStore.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForA(txtItemQualityFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForAGStore(txtItemQualityFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForAForAuditor(txtItemQualityFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForF(txtItemQualityFStore.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItmeQualityForAForAuditor(txtItemQualityFStore.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPdff_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPdff.Click
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\..\Reports/ItemListReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "ItemList"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, 1)
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
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                If txtItemCatForPdf.Text = "" Then
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\..\Reports/ItemListReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "ItemList"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, 1)
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
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\..\Reports/ItemListReportForCategoryWise.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "ItemList"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, 1)
                    Report.SetParameterValue(1, lblItemCateID.Text)
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
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    If txtItemCatForPdf.Text = "" Then
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReport.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 1)
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
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForCategoryWise.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 1)
                        Report.SetParameterValue(1, lblItemCateID.Text)
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
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    If txtItemCatForPdf.Text = "" Then
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForAstore.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 2)
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
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForAstoreCategoryVise.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 2)
                        Report.SetParameterValue(1, lblItemCateID.Text)
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
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    If txtItemCatForPdf.Text = "" Then
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForGstore.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 4)
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
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForGstoreCategoryVise.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 4)
                        Report.SetParameterValue(1, lblItemCateID.Text)
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
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    If txtItemCatForPdf.Text = "" Then
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForAstore.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 2)
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
                        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                            System.IO.File.Delete(Uploadedfiles)
                        Next
                        Dim Report As New ReportDocument
                        Dim Options As New ExportOptions
                        Report.Load(Server.MapPath("..\..\Reports/ItemListReportForAstoreCategoryVise.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "ItemList"
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, 2)
                        Report.SetParameterValue(1, lblItemCateID.Text)
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
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\..\Reports/ItemListReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "ItemList"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, 1)
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
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadDataNew() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItem.GetIMSItemAllNew
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgItemView.DataSource = objDataView
        dgItemView.DataBind()
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItem.GetIMSItemAll
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgItemView.PageIndexChanged
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            objDataTable = ObjIMSItem.GetIMSItemAllNewFabric
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = ObjIMSItem.GetIMSItemAllNewFabric
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = ObjIMSItem.GetIMSItemAllNewFabric
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                objDataTable = ObjIMSItem.GetIMSItemAllNewAccessories()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = ObjIMSItem.GetIMSItemAllNewGStore()
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                objDataTable = ObjIMSItem.GetIMSItemAllNewForAuditor()
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                objDataTable = ObjIMSItem.GetIMSItemAllNewFabric
            Else
                objDataTable = ObjIMSItem.GetIMSItemAllNewForAuditor()
            End If
        End If
        dgItemView.DataSource = objDataTable
        dgItemView.DataBind()
        GetRights()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgItemView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgItemView.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("ItemEntry.aspx")
    End Sub
    Protected Sub dgItemView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItemView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim IMSItemID As Long = dgItemView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Response.Redirect("ItemEntry.aspx?IMSItemID=" & IMSItemID & "")
                Case "PDF"
                    Dim IMSItemID As Long = dgItemView.Items(e.Item.ItemIndex).Cells(0).Text
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
    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItem.GetItemAllInfo(ItemName)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub txtShade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtShade.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForF(txtShade.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForF(txtShade.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForF(txtShade.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForA(txtShade.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForAGStore(txtShade.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForAForAuditor(txtShade.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForF(txtShade.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingShadeForAForAuditor(txtShade.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCode.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForF(txtCode.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForF(txtCode.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForF(txtCode.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForA(txtCode.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForAGstore(txtCode.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForAForAuditor(txtCode.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForF(txtCode.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingCodeForAForAuditor(txtCode.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtDalNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNo.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForF(txtDalNo.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForF(txtDalNo.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForF(txtDalNo.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForA(txtDalNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForAGStore(txtDalNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForAForAuditor(txtDalNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForF(txtDalNo.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalNoForAForAuditor(txtDalNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtDalRefNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalRefNo.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForF(txtDalRefNo.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForF(txtDalRefNo.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForF(txtDalRefNo.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForA(txtDalRefNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForAGstore(txtDalRefNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForAForAuditor(txtDalRefNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForF(txtDalRefNo.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingDalRefForAForAuditor(txtDalRefNo.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemCat_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemCat.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForF(txtItemCat.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForF(txtItemCat.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForF(txtItemCat.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForA(txtItemCat.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForAGStore(txtItemCat.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForAForAuditor(txtItemCat.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForF(txtItemCat.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemCatForAForAuditor(txtItemCat.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If       
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemClass_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemClass.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForF(txtItemClass.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForF(txtItemClass.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemView.DataSource = CkDt1
                    dgItemView.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItem.GetIMSItemAllNewFabric()
                    dgItemView.DataSource = dt
                    dgItemView.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForF(txtItemClass.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForA(txtItemClass.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewAccessories()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForAGStore(txtItemClass.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewGStore()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForAForAuditor(txtItemClass.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForF(txtItemClass.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewFabric()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                ElseIf UserId = 251 Then
                    Dim CkDt1 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForChemsTOREE(txtItemClass.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt1
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItem.GetIMSItemAllNewChemStore()
                        dgItemView.DataSource = dt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItem.GetIMSItemAllNewFabricForSearchingItemClassForAForAuditor(txtItemClass.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemView.DataSource = CkDt2
                        dgItemView.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItem.GetIMSItemAllNewForAuditor()
                        dgItemView.DataSource = dtt
                        dgItemView.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

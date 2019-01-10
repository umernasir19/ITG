Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class IssueView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjIssue As New IssueMst
    Dim ObjIssueDtl As New IssueDetail
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
    Dim objPOMaster As New POMaster
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    dgView.Columns(4).HeaderText = "Fabric Code"
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        dgView.Columns(4).HeaderText = "Fabric Code"
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                        dgView.Columns(4).HeaderText = "Item Code"
                    ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                        dgView.Columns(4).HeaderText = "Item Code"
                    Else
                        dgView.Columns(4).HeaderText = "Item Code"
                    End If
                End If
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch ex As Exception
            End Try
            PageHeader("ISSUE VIEW FORM")
        End If
    End Sub
    Protected Sub btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshow.Click
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = ObjIssue.ViewFabricNewNewForUpdateAlll()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = ObjIssue.ViewFabricNewNewForUpdateAlll()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                objDataTable = ObjIssue.ViewFabricNewNewForAccAll()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = ObjIssue.ViewFabricNewNewForAccGStoreAll()
            Else
                objDataTable = ObjIssue.ViewFabricNewNewForUpdateAllAll()
            End If
        End If
        dgView.DataSource = objDataTable
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
            Dim Status As String = dgView.Items(x).Cells(16).Text
            If Status = 1 Then
                lnkEdit.Enabled = False
                lnkRemove.Enabled = False
                cmdAdd.Enabled = False
                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
            Else
                lnkEdit.Enabled = True
                lnkRemove.Enabled = True
                cmdAdd.Enabled = True
            End If
        Next
        GetRights()
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
        GetRights()
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
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = ObjIssue.ViewFabricNewNewForUpdateAny()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = ObjIssue.ViewFabricNewNewForUpdateAny()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                objDataTable = ObjIssue.ViewFabricNewNewForAcc()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = ObjIssue.ViewFabricNewNewForAccGStore()
            Else
                objDataTable = ObjIssue.ViewFabricNewNewForUpdateAll()
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
            Dim Status As String = dgView.Items(x).Cells(16).Text
            If Status = 1 Then
                lnkEdit.Enabled = False
                lnkRemove.Enabled = False
                cmdAdd.Enabled = False
                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
            Else
                lnkEdit.Enabled = True
                lnkRemove.Enabled = True
                cmdAdd.Enabled = True
            End If
        Next
        GetRights()
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("Issue.aspx?IssueID=" & IssueID & "")
                Case "Remove"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    ObjIssue.deleteIssueMst(IssueID)
                    ObjIssueDtl.deleteIssueDtl(IssueID)
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                    GetRights()
            End Select
            Select Case e.CommandName
                Case "PDF"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                        Report.Load(Server.MapPath("..\Reports/POIssueForFabric.rpt"))
                    Else
                        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                            Report.Load(Server.MapPath("..\Reports/POIssueForFabric.rpt"))
                        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                            Report.Load(Server.MapPath("..\Reports/POIssueForAstore.rpt"))
                        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                            Report.Load(Server.MapPath("..\Reports/POIssueForGstore.rpt"))
                        Else
                            Report.Load(Server.MapPath("..\Reports/POIssueForFabric.rpt"))
                        End If
                    End If
                    FileName = "PO_ISSUE_REPORT"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, IssueID)
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
                        Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                        Response.End()
                    End If
                Case "Return"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Response.Redirect("POIssueReturn.aspx?IssueID=" & IssueID & " &IssueDtlID=" & IssueDtlID & "", False)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("Issue.aspx")
    End Sub
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        Try
            Dim objDataView As DataView
            objDataView = LoadData()

            Session("objDataView") = objDataView
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt1 As DataTable = ObjIssue.ViewFabricNewNewPONOViseForIssued(txtShowMe.Text)
                Dim dt2 As DataTable = ObjIssue.ViewFabricNewNewForFabricCodeViseVise(txtShowMe.Text)
                Dim dt3 As DataTable = ObjIssue.ViewFabricNewNewForManulaChalanVise(txtShowMe.Text)
                Dim dt4 As DataTable = ObjIssue.ViewFabricNewNewForDepartmentVise(txtShowMe.Text)
                If dt1.Rows.Count > 0 Then
                    dgView.DataSource = dt1
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                        Dim Status As String = dgView.Items(x).Cells(16).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemove.Enabled = False
                            cmdAdd.Enabled = False
                            dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemove.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt2.Rows.Count > 0 Then
                    dgView.DataSource = dt2
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                        Dim Status As String = dgView.Items(x).Cells(16).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemove.Enabled = False
                            cmdAdd.Enabled = False
                            dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemove.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt3.Rows.Count > 0 Then
                    dgView.DataSource = dt3
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                        Dim Status As String = dgView.Items(x).Cells(16).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemove.Enabled = False
                            cmdAdd.Enabled = False
                            dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemove.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt4.Rows.Count > 0 Then
                    dgView.DataSource = dt4
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                        Dim Status As String = dgView.Items(x).Cells(16).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemove.Enabled = False
                            cmdAdd.Enabled = False
                            dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemove.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim dt1 As DataTable = ObjIssue.ViewFabricNewNewPONOViseForIssued(txtShowMe.Text)
                    Dim dt2 As DataTable = ObjIssue.ViewFabricNewNewForFabricCodeViseVise(txtShowMe.Text)
                    Dim dt3 As DataTable = ObjIssue.ViewFabricNewNewForManulaChalanVise(txtShowMe.Text)
                    Dim dt4 As DataTable = ObjIssue.ViewFabricNewNewForDepartmentVise(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim dt1 As DataTable = ObjIssue.ViewFabricNewNewPONOViseForIssuedForAcc(txtShowMe.Text)
                    Dim dt2 As DataTable = ObjIssue.ViewFabricNewNewForFabricCodeViseViseForAcc(txtShowMe.Text)
                    Dim dt3 As DataTable = ObjIssue.ViewFabricNewNewForManulaChalanViseForAcc(txtShowMe.Text)
                    Dim dt4 As DataTable = ObjIssue.ViewFabricNewNewForDepartmentViseForAcc(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim dt1 As DataTable = ObjIssue.ViewFabricNewNewPONOViseForIssuedForAccGStore(txtShowMe.Text)
                    Dim dt2 As DataTable = ObjIssue.ViewFabricNewNewForFabricCodeViseViseForAccGStore(txtShowMe.Text)
                    Dim dt3 As DataTable = ObjIssue.ViewFabricNewNewForManulaChalanViseForAccGStore(txtShowMe.Text)
                    Dim dt4 As DataTable = ObjIssue.ViewFabricNewNewForDepartmentViseForAccGStore(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                Else
                    Dim dt1 As DataTable = ObjIssue.ViewFabricNewNewPONOViseForIssuedForAll(txtShowMe.Text)
                    Dim dt2 As DataTable = ObjIssue.ViewFabricNewNewForFabricCodeViseViseForAll(txtShowMe.Text)
                    Dim dt3 As DataTable = ObjIssue.ViewFabricNewNewForManulaChalanViseForAll(txtShowMe.Text)
                    Dim dt4 As DataTable = ObjIssue.ViewFabricNewNewForDepartmentViseForAll(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(16).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemove.Enabled = False
                                cmdAdd.Enabled = False
                                dgView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(15).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(16).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class


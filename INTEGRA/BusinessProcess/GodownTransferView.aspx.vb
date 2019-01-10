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
Public Class GodownTransferView
    Inherits System.Web.UI.Page
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim Userid As Long
    Dim objGodownIssueMst As New GodownIssueMst
    Dim lGodownIssueID As Long
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjIMSItem As New IMSItem
    Dim objPORecvMaster As New PORecvMaster
    Dim InhandQty As Decimal
    Dim TansactionMethod As String
    Dim ObjIssue As New IssueMst
    Dim objGodownIssueDetail As New GodownIssueDetail
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Godown to Godown transfer")
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
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
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
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgStoreIssue.RecordCount = objDataView.Count
        dgStoreIssue.DataSource = objDataView
        dgStoreIssue.DataBind()
        Dim x As Integer
        For x = 0 To dgStoreIssue.Items.Count - 1
            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
            If Status = 1 Then
                lnkEdit.Enabled = False
                lnkRemovee.Enabled = False
                cmdAdd.Enabled = False
                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
            Else
                lnkEdit.Enabled = True
                lnkRemovee.Enabled = True
                cmdAdd.Enabled = True
            End If
        Next
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objGodownIssueMst.GetAllDataNewWithUserAll()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objGodownIssueMst.GetAllDataNewWithUserAll()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                objDataTable = objGodownIssueMst.GetAllDataNewWithUserNewForAcc()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = objGodownIssueMst.GetAllDataNewWithUserNewForAccGStore()
            Else
                objDataTable = objGodownIssueMst.GetAllDataNewWithUserNewForAll()
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgStoreIssue.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStoreIssue.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgStoreIssue.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("GodownTarnsfer.aspx")
    End Sub
    Protected Sub dgStoreIssue_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStoreIssue.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim GodownIssueID As Long = dgStoreIssue.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("GodownTarnsfer.aspx?GodownIssueID=" & GodownIssueID & "")
                Case "PDF"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("~/Reports/StoreIssueReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StoreIssueID As Long = dgStoreIssue.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim FileName As String = "FABRIC ISSUE SHEET"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, StoreIssueID)
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
                Case "Remove"
                    Dim GodownIssueID As Long = dgStoreIssue.Items(e.Item.ItemIndex).Cells(0).Text
                    objGodownIssueMst.DeleteFromDodownMAster(GodownIssueID)
                    objGodownIssueMst.DeleteFromDodownDetail(GodownIssueID)
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                    GetRights()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNo(txtShowMe.Text)
                Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodee(txtShowMe.Text)
                Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocation(txtShowMe.Text)
                Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocation(txtShowMe.Text)
                If dt1.Rows.Count > 0 Then
                    dgStoreIssue.DataSource = dt1
                    dgStoreIssue.DataBind()
                    Dim x As Integer
                    For x = 0 To dgStoreIssue.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                        Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemovee.Enabled = False
                            cmdAdd.Enabled = False
                            dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemovee.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt2.Rows.Count > 0 Then
                    dgStoreIssue.DataSource = dt2
                    dgStoreIssue.DataBind()
                    Dim x As Integer
                    For x = 0 To dgStoreIssue.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                        Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemovee.Enabled = False
                            cmdAdd.Enabled = False
                            dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemovee.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt3.Rows.Count > 0 Then
                    dgStoreIssue.DataSource = dt3
                    dgStoreIssue.DataBind()
                    Dim x As Integer
                    For x = 0 To dgStoreIssue.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                        Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemovee.Enabled = False
                            cmdAdd.Enabled = False
                            dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemovee.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                ElseIf dt4.Rows.Count > 0 Then
                    dgStoreIssue.DataSource = dt4
                    dgStoreIssue.DataBind()
                    Dim x As Integer
                    For x = 0 To dgStoreIssue.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                        Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                        If Status = 1 Then
                            lnkEdit.Enabled = False
                            lnkRemovee.Enabled = False
                            cmdAdd.Enabled = False
                            dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                            dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        Else
                            lnkEdit.Enabled = True
                            lnkRemovee.Enabled = True
                            cmdAdd.Enabled = True
                        End If
                    Next
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNo(txtShowMe.Text)
                    Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodee(txtShowMe.Text)
                    Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocation(txtShowMe.Text)
                    Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocation(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt1
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt2
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt3
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt4
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNoForAcc(txtShowMe.Text)
                    Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodeeForAcc(txtShowMe.Text)
                    Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocationForACC(txtShowMe.Text)
                    Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocationForAcc(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt1
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt2
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt3
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt4
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNoForGStore(txtShowMe.Text)
                    Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodeeForAccGStore(txtShowMe.Text)
                    Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocationForACCGStore(txtShowMe.Text)
                    Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocationForAccGstore(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt1
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt2
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt3
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt4
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                Else
                    Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNoForAll(txtShowMe.Text)
                    Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodeeForAll(txtShowMe.Text)
                    Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocationForall(txtShowMe.Text)
                    Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocationForAll(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt1
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt2.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt2
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt3.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt3
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    ElseIf dt4.Rows.Count > 0 Then
                        dgStoreIssue.DataSource = dt4
                        dgStoreIssue.DataBind()
                        Dim x As Integer
                        For x = 0 To dgStoreIssue.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemovee As ImageButton = CType(dgStoreIssue.Items(x).FindControl("lnkRemovee"), ImageButton)
                            Dim Status As String = dgStoreIssue.Items(x).Cells(13).Text
                            If Status = 1 Then
                                lnkEdit.Enabled = False
                                lnkRemovee.Enabled = False
                                cmdAdd.Enabled = False
                                dgStoreIssue.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                                dgStoreIssue.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemovee.Enabled = True
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

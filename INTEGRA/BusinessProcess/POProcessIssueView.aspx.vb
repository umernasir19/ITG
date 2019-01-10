Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POProcessIssueView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjIssue As New IssueMst
    Dim ObjIssueDtl As New IssueDetail
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
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
        End If
        PageHeader("PROCESS ISSUE")
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
            objDataTable = ObjIssue.ViewProcessIssue()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = ObjIssue.ViewProcessIssue()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                objDataTable = ObjIssue.ViewProcessIssue()
            Else
                objDataTable = ObjIssue.ViewProcessIssue()
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
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim ProcessIssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("POProcessIssue.aspx?ProcessIssueID=" & ProcessIssueID & "")

                Case "PDF"
                    Dim ProcessIssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                        Report.Load(Server.MapPath("..\Reports/ProcessIssueReport.rpt"))
                    FileName = "PROCESS_ISSUE_REPORT"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, ProcessIssueID)
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
                    Dim ProcessIssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim ProcessIssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Response.Redirect("POProcessIssueReturn.aspx?ProcessIssueID=" & ProcessIssueID & " &ProcessIssueDtlID=" & ProcessIssueDtlID & "", False)
                Case "Remove"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    ObjIssue.deleteProcessIssueMst(IssueID)
                    ObjIssue.deleteProcessIssueDtl(IssueID)
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                    GetRights()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("POProcessIssue.aspx")
    End Sub
    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = ObjIssue.GetItemAllInfoISSUE(ItemName)
        Else
            objDataTable = ObjIssue.ViewForSearch(ItemName)
        End If

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
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
            Dim dt1 As DataTable = ObjIssue.ViewProcessIssueForPonoVise(txtShowMe.Text)
            Dim dt2 As DataTable = ObjIssue.ViewProcessIssueForitemCodeVise(txtShowMe.Text)
            Dim dt3 As DataTable = ObjIssue.ViewProcessIssueFormanualChallanVise(txtShowMe.Text)
            Dim dt4 As DataTable = ObjIssue.ViewProcessIssueForDepartmentVise(txtShowMe.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                GetRights()
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                GetRights()
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

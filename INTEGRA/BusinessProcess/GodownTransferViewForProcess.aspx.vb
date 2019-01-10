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
Public Class GodownTransferViewForProcess
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
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objGodownIssueMst.GetAllDataNewWithUserAllForProcess()
        Else
            objDataTable = objGodownIssueMst.GetAllDataNewWithUserNewForProcess()
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgStoreIssue.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStoreIssue.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgStoreIssue.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("GodownTarnsferForProcess.aspx")
    End Sub
    Protected Sub dgStoreIssue_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStoreIssue.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim GodownIssueID As Long = dgStoreIssue.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("GodownTarnsferForProcess.aspx?GodownIssueID=" & GodownIssueID & "")
                Case "Remove"
                    Dim GodownIssueID As Long = dgStoreIssue.Items(e.Item.ItemIndex).Cells(0).Text
                    objGodownIssueMst.DeleteFromDodownMAsterForProcess(GodownIssueID)
                    objGodownIssueMst.DeleteFromDodownDetailForProcess(GodownIssueID)
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
            Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNoForProcess(txtShowMe.Text)
            Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodeeForProcess(txtShowMe.Text)
            Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocationForProcess(txtShowMe.Text)
            Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocationForProcess(txtShowMe.Text)
            If dt1.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt1
                dgStoreIssue.DataBind()
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt2
                dgStoreIssue.DataBind()
                GetRights()
            ElseIf dt3.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt3
                dgStoreIssue.DataBind()
                GetRights()
            ElseIf dt4.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt4
                dgStoreIssue.DataBind()
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

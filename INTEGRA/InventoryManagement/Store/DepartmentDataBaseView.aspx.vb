﻿Imports System.Data
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
Public Class DepartmentDataBaseView
    Inherits System.Web.UI.Page
    Public bIsShowException As Boolean
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim UserId, RMFormRoleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        Response.Expires = 0
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
                bIsShowException = True
            End Try
            PageHeader("Department Database View")
        End If
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
                For x = 0 To dgDepartmentDataBase.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgDepartmentDataBase.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgDepartmentDataBase.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgDepartmentDataBase.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgDepartmentDataBase.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgDepartmentDataBase.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgDepartmentDataBase.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgDepartmentDataBase.Items(x).FindControl("lnkRemove"), ImageButton)
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
        If objDataView.Count > 0 Then
            dgDepartmentDataBase.RecordCount = objDataView.Count
            dgDepartmentDataBase.DataSource = objDataView
            dgDepartmentDataBase.DataBind()
            Dim gridItem As DataGridItem
            Dim iPos As Long = 1
            For Each gridItem In dgDepartmentDataBase.Items
                With gridItem
                    Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                    lblSrNo.Text = iPos
                    iPos += 1
                End With
            Next
        Else
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjDepartmentDataBase.GetDepartmentDataBase
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub StatusChanged(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
    End Sub
    Protected Sub dgDepartmentDataBase_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDepartmentDataBase.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Edit"
                    Dim DeptDatabaseId As Long = dgDepartmentDataBase.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("DepartmentDataBase.aspx?lDeptDatabaseId=" & DeptDatabaseId & "")
                Case Is = "Remove"
                    Dim DeptDatabaseId As Long = dgDepartmentDataBase.Items(e.Item.ItemIndex).Cells(0).Text
                    ObjDepartmentDataBase.DeleteDepartmentDatBase(DeptDatabaseId)
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = ObjDepartmentDataBase.GetDepartmentDataBase
                    objDataView = New DataView(objDataTable)
                    Session("objDataView") = objDataView
                    BindGrid()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            Response.Redirect("../Store/DepartmentDataBase.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrint.Click
        Try
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Report.Load(Server.MapPath("..\..\Reports/DepartmentDataBase.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Department Database"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
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
        Catch ex As Exception
        End Try
    End Sub
End Class


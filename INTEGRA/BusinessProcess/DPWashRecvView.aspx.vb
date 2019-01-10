﻿Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPWashRecvView
    Inherits System.Web.UI.Page
    Dim objDPWashRecvMst As New DPWashRecvMst
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim lFabricIssueID, userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
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
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
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
                btnAddWashIssue.Enabled = True
            Else
                btnAddWashIssue.Enabled = False
            End If
            If View = 1 Then
                dgSampleReceive.MasterTableView.GetColumn("View").Display = True
            Else
                dgSampleReceive.MasterTableView.GetColumn("View").Display = False
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgSampleReceive.DataSource = objDataView
            dgSampleReceive.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objDPWashRecvMst.GetBindGridForWashNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgSampleReceive_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgSampleReceive.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgSampleReceive_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgSampleReceive.SortCommand
        BindGrid()
    End Sub

    Protected Sub btnAddWashIssue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddWashIssue.Click
        Try
            Response.Redirect("DPWashReceive.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgSampleReceive_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgSampleReceive.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "PDF"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lDPWashRecvMstID As String = item("DPWashRecvMstID").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Report.Load(Server.MapPath("..\Reports/WashReceive.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "WashReceiveReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lDPWashRecvMstID)

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


End Class
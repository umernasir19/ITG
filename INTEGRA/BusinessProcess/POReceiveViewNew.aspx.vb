Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POReceiveViewNew
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim objPORecvMaster As New PORecvMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim x As Long
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkReturnNew As LinkButton = CType(dgView.Items(x).FindControl("lnkReturnNew"), LinkButton)
                        lnkReturnNew.Visible = True
                    Next
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim x As Long
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkReturnNew As LinkButton = CType(dgView.Items(x).FindControl("lnkReturnNew"), LinkButton)
                        lnkReturnNew.Visible = False
                    Next
                Else
                    Dim x As Long
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkReturnNew As LinkButton = CType(dgView.Items(x).FindControl("lnkReturnNew"), LinkButton)
                        lnkReturnNew.Visible = False
                    Next
                End If
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PO RECEIVING VIEW")
    End Sub
    Protected Sub btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshow.Click
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPORecvMaster.GetDataForPORecvNewAll()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPORecvMaster.GetDataForPORecvNewAll()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                objDataTable = objPORecvMaster.GetDataForPORecvForAccAll()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = objPORecvMaster.GetDataForPORecvForGSToreAll()
            Else
                objDataTable = objPORecvMaster.GetDataForPORecvForAllNew()
            End If
        End If
        dgView.DataSource = objDataTable
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray

            Else
                lnkEdit.Enabled = True
                lnkRemove.Enabled = True
                cmdAdd.Enabled = True
            End If
        Next
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
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray

            Else
                lnkEdit.Enabled = True
                lnkRemove.Enabled = True
                cmdAdd.Enabled = True
            End If
        Next
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPORecvMaster.GetDataForPORecvNew()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPORecvMaster.GetDataForPORecvNew()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                objDataTable = objPORecvMaster.GetDataForPORecvForAcc()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                objDataTable = objPORecvMaster.GetDataForPORecvForGSTore()
            Else
                objDataTable = objPORecvMaster.GetDataForPORecvForAll()
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Response.Redirect("POReceiveEntry.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim PORecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("POReceiveEntry.aspx?PORecvMasterID=" & PORecvMasterID & "")
                Case "Remove"
                    Dim PORecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingData(PORecvMasterID)
                    If dt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeleteFromPORecvMAster(PORecvMasterID)
                        objPOMaster.DeleteFromPORecvDetail(PORecvMasterID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        Dim objDataView As DataView
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                        GetRights()
                    End If
                Case "PDF"
                    Dim PODetailID As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    Report.Load(Server.MapPath("..\Reports/PORecieveNEW.rpt"))
                    FileName = "POReceieveReport"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, PODetailID)
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
                    Dim PORecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Response.Redirect("POReturnNew.aspx?PORecvMasterID=" & PORecvMasterID & "", False)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = objPORecvMaster.GetPORECforViewFabric()
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPORecvMaster.GetPORECforViewFabric()
        Else
            objDataTable = objPORecvMaster.GetPORECforViewFabric()
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
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOVise(txtShowMe.Text)
                Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleVise(txtShowMe.Text)
                Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemVise(txtShowMe.Text)
                Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierVise(txtShowMe.Text)
                If dt1.Rows.Count > 0 Then
                    dgView.DataSource = dt1
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                        Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                        Dim Status As String = dgView.Items(x).Cells(19).Text
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
                            dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                        Dim Status As String = dgView.Items(x).Cells(19).Text
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
                            dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                        Dim Status As String = dgView.Items(x).Cells(19).Text
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
                            dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                        Dim Status As String = dgView.Items(x).Cells(19).Text
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
                            dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                            dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                    Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOVise(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleVise(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemVise(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierVise(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOViseForAcc(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleViseForAcc(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemViseForACC(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierViseForAcc(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If

                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOViseForAccGSStore(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleViseForAccGStore(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemViseForACCGStore(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierViseForAccGStore(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
                            Else
                                lnkEdit.Enabled = True
                                lnkRemove.Enabled = True
                                cmdAdd.Enabled = True
                            End If
                        Next
                        GetRights()
                    End If
                Else
                    Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOViseForAll(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleViseForAll(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemViseForAll(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierViseForAll(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            Dim lnkEdit As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                            Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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
                            Dim Status As String = dgView.Items(x).Cells(19).Text
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
                                dgView.Items.Item(x).Cells(17).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(18).BackColor = Drawing.Color.Gray
                                dgView.Items.Item(x).Cells(19).BackColor = Drawing.Color.Gray
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




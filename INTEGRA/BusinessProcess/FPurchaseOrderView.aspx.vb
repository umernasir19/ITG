Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class FPurchaseOrderView
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim dtSummary As DataTable
    Dim objDataTable As DataTable
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                dtSummary = loadSummary()
                Session("dtSummary") = dtSummary
                BindSummaryGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PURCHASE ORDER")
    End Sub
    Protected Sub btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshow.Click
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetPOforFabricViewSummaryAll()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPOMaster.GetPOforFabricViewSummaryAll()
            Else
                objDataTable = objPOMaster.GetPOforFabricViewSummaryAll()
            End If
        End If
        dgSummaryView.DataSource = objDataTable
        dgSummaryView.DataBind()
        dgSummaryView.Visible = True
        Dim x As Integer
        For x = 0 To dgSummaryView.Items.Count - 1
            Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)
            Dim lnkRemovee As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
            Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
            If Status = 1 Then
                lnkEditt.Enabled = False
                lnkRemovee.Enabled = False
                cmdAdd.Enabled = False
                dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
            Else
                lnkEditt.Enabled = True
                lnkRemovee.Enabled = True
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
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)

                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)

                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
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
    Private Sub BindSummaryGrid()
        Try
            Dim dt As DataTable
            dt = Session("dtSummary")
            dgSummaryView.RecordCount = dt.Rows.Count
            dgSummaryView.DataSource = dt
            dgSummaryView.DataBind()
            dgSummaryView.Visible = True
            Dim x As Integer
            For x = 0 To dgSummaryView.Items.Count - 1
                Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)
                Dim lnkRemovee As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
                Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                If Status = 1 Then
                    lnkEditt.Enabled = False
                    lnkRemovee.Enabled = False
                    cmdAdd.Enabled = False
                    dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                    dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                Else
                    lnkEditt.Enabled = True
                    lnkRemovee.Enabled = True
                    cmdAdd.Enabled = True
                End If
            Next
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        dgView.Visible = True
    End Sub
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetPOforFabricViewSummary()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPOMaster.GetPOforFabricViewSummary()
            Else
                objDataTable = objPOMaster.GetPOforFabricViewSummary()
            End If
        End If
        Return objDataTable
    End Function
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = objPOMaster.GetPOforFabricViewNew()
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetPOforFabricViewNew()
        Else
            objDataTable = objPOMaster.GetPOforViewNew()
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSummaryView.PageIndexChanged
        BindSummaryGrid()
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
        GetRights()
    End Sub
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSummaryView.SortCommand
        BindSummaryGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("FabricPurchaseOrderEntry.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim POID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim FabriocOrder As Boolean = dgView.Items(e.Item.ItemIndex).Cells(10).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    If FabriocOrder = True Then
                        Response.Redirect("FabricPurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    Else
                        Response.Redirect("PurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    End If
                Case "Remove"
                    Dim POID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingDataForPORecv(POID)
                    Dim dtt As DataTable = objPOMaster.GetCheckExistingDataForPOIssue(POID)
                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeletePOMAster(POID)
                        objPOMaster.DeletePODetail(POID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        Dim objDataView As DataView
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                    End If
                Case "PDF"
                    Dim poid As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    FileName = "PurchaseOrder"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, poid)
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
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgSummaryView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSummaryView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim POID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim FabriocOrder As Boolean = dgSummaryView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    If FabriocOrder = True Then
                        Response.Redirect("FabricPurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    Else
                        Response.Redirect("PurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    End If
                Case "Remove"
                    Dim POID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingDataForPORecv(POID)
                    Dim dtt As DataTable = objPOMaster.GetCheckExistingDataForPOIssue(POID)
                    Dim dttt As DataTable = objPOMaster.GetCheckExistingDataForPOReturn(POID)
                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Or dttt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeletePOMAster(POID)
                        objPOMaster.DeletePODetail(POID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        dtSummary = loadSummary()
                        Session("dtSummary") = dtSummary
                        BindSummaryGrid()
                    End If
                Case "PDF"
                    Dim poid As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim potype As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim InditexPONo As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(6).Text
                    InditexPONo = InditexPONo.Replace("&nbsp;", "")
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If InditexPONo = "" Then
                        Report.Load(Server.MapPath("..\Reports/FabricLocalPurchaseorder.rpt"))
                    Else
                        Report.Load(Server.MapPath("..\Reports/FabricLocalPurchaseorderForInitexNo.rpt"))
                    End If
                    FileName = "PurchaseOrder"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, poid)
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
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Function loadSummaryNew(ByVal ItemName As String) As DataTable
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = objPOMaster.GetPOforFabricViewSummarysearch(ItemName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetPOforFabricViewSummarysearch(ItemName)
        Else
            objDataTable = objPOMaster.GetPOforViewSummarySearch(ItemName)
        End If
        Return objDataTable
    End Function
    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = objPOMaster.GetItemAllInfo(ItemName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetItemAllInfo(ItemName)
        Else
            objDataTable = objPOMaster.GetPOforViewNewSearch(ItemName)
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
        txtShowMe.Text = ""
    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If txtShowMe.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enter Search Term")
            ElseIf txtShowMe.Text <> "" Then
                Dim objDataView As DataView
                objDataView = LoadData(txtShowMe.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Invalid Search Term")
                End If
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtSummarySearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSummarySearch.TextChanged
        Try
            Dim dt1 As DataTable = objPORecvMaster.GetPOforSearchingPONOVise(txtSummarySearch.Text)
            Dim dt2 As DataTable = objPORecvMaster.GetPOforSearchingSupplierVise(txtSummarySearch.Text)
            If dt1.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt1
                dgSummaryView.DataBind()
                Dim x As Integer
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)
                    Dim lnkRemovee As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
                    Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                    If Status = 1 Then
                        lnkEditt.Enabled = False
                        lnkRemovee.Enabled = False
                        cmdAdd.Enabled = False
                        dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                    Else
                        lnkEditt.Enabled = True
                        lnkRemovee.Enabled = True
                        cmdAdd.Enabled = True
                    End If
                Next
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt2
                dgSummaryView.DataBind()
                Dim x As Integer
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkEditt"), ImageButton)
                    Dim lnkRemovee As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemove"), ImageButton)
                    Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                    If Status = 1 Then
                        lnkEditt.Enabled = False
                        lnkRemovee.Enabled = False
                        cmdAdd.Enabled = False
                        dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Gray
                        dgSummaryView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Gray
                    Else
                        lnkEditt.Enabled = True
                        lnkRemovee.Enabled = True
                        cmdAdd.Enabled = True
                    End If
                Next
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            PanelDetail.Visible = True
            btnHideDetail.Visible = True
            btnDetail.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSummaryShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSummaryShowAll.Click
        Try
            dtSummary = loadSummary()
            Session("dtSummary") = dtSummary
            BindSummaryGrid()
            txtSummarySearch.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnHideDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHideDetail.Click
        Try
            PanelDetail.Visible = False
            btnHideDetail.Visible = False
            btnDetail.Visible = True
        Catch ex As Exception
        End Try
    End Sub
End Class




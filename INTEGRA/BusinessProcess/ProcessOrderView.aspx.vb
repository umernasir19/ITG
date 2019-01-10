Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ProcessOrderView
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim dtSummary As DataTable
    Dim objDataTable As DataTable
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
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
        PageHeader("PROCESS ORDER")
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
                    Dim lnkRemove As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemovee"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgSummaryView.Items(x).FindControl("lnkRemovee"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPOMaster.GetViewNew
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPOMaster.GetViewNew
            Else
                objDataTable = objPOMaster.GetViewNew
            End If
        End If
        Return objDataTable
    End Function
    Private Sub BindSummaryGrid()
        Try
            Dim dt As DataTable
            dt = Session("dtSummary")
            dgSummaryView.RecordCount = dt.Rows.Count
            dgSummaryView.DataSource = dt
            dgSummaryView.DataBind()
            dgSummaryView.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSummaryView.PageIndexChanged
        BindSummaryGrid()
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged

    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand

    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSummaryView.SortCommand
        BindSummaryGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("ProcessOrderEntry.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim PurchaseOrderMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    '   Dim FabriocOrder As Boolean = dgView.Items(e.Item.ItemIndex).Cells(10).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    'If FabriocOrder = True Then
                    '    Response.Redirect("ProcessOrderEntry.aspx?lPOID=" & POID & "")
                    'Else
                    Response.Redirect("ProcessOrderEntry.aspx?lPurchaseOrderMstID=" & PurchaseOrderMstID & "")
                    ' End If

                Case "Remove"

                    Dim POID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingDataForPOProcessRecv(POID)
                    Dim dtt As DataTable = objPOMaster.GetCheckExistingDataForPOProcessIssue(POID)

                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeletePOProcessMAster(POID)
                        objPOMaster.DeletePOProcessDetail(POID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        dtSummary = loadSummary()
                        Session("dtSummary") = dtSummary
                        BindSummaryGrid()
                    End If
                Case "PDF"
                    Dim poid As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String

                    'If userid = 241 Then
                    '    Report.Load(Server.MapPath("..\Accounts/FabricLocalPurchaseorder.rpt"))
                    'Else
                    '    Report.Load(Server.MapPath("..\Accounts/FabricRefPurchaseorder.rpt"))
                    'End If

                    FileName = "Process Order"

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
                    Dim ProcessOrderMstID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    'Dim FabriocOrder As Boolean = dgSummaryView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ProcessOrderEntry.aspx?ProcessOrderMstID=" & ProcessOrderMstID & "")

                Case "Remove"

                    Dim PurchaseOrderMstID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingDataForPOProcessRecv(PurchaseOrderMstID)
                    Dim dtt As DataTable = objPOMaster.GetCheckExistingDataForPOProcessIssue(PurchaseOrderMstID)

                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeletePOProcessMAster(PurchaseOrderMstID)
                        objPOMaster.DeletePOProcessDetail(PurchaseOrderMstID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        Dim objDataView As DataView
                        dtSummary = loadSummary()
                        Session("dtSummary") = dtSummary
                        BindSummaryGrid()
                        GetRights()
                    End If
                Case "PDF"
                    Dim ProcessOrderMstID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim InditexPONo As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(6).Text
                    InditexPONo = InditexPONo.Replace("&nbsp;", "")
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String
                    If InditexPONo = "" Then
                        Report.Load(Server.MapPath("..\Reports/FabricProcessLocalPurchaseorder.rpt"))
                    Else
                        Report.Load(Server.MapPath("..\Reports/FabricProcessLocalPurchaseorderForInitexNo.rpt"))
                    End If
                    FileName = "ProcessOrder"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, ProcessOrderMstID)


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
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        Try
          
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
           
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtSummarySearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSummarySearch.TextChanged
        Try
            Dim dt1 As DataTable = objPOMaster.GetViewNewForProcessNoVise(txtSummarySearch.Text)
            Dim dt2 As DataTable = objPOMaster.GetViewNewForProcessSupplierVise(txtSummarySearch.Text)
            If dt1.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt1
                dgSummaryView.DataBind()
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt2
                dgSummaryView.DataBind()
                GetRights()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try
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
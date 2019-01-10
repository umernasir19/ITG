Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POViewForAuditor
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim dtSummary, dtSummaryAuth As DataTable
    Dim objDataTable As DataTable
    Dim objPORecvMaster As New PORecvMaster
    Dim objJobOrderdatabase As New JobOrderdatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                dtSummary = loadSummary()
                Session("dtSummary") = dtSummary
                BindSummaryGrid()

                dtSummaryAuth = loadSummaryAuth()
                Session("dtSummaryAuth") = dtSummaryAuth
                BindSummaryGridAuth()

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PURCHASE ORDER")
    End Sub
    Protected Sub btnGetDateWise_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetDateWise.Click
        Try
            If txtDateFrom.SelectedDate.ToString = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                'Dim Estdatee As String = txtDateFrom.SelectedDate.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objPOMaster.GetPOforFabricViewSummaryForAuditordateVise(SDate)
                dgSummaryView.DataSource = dt
                dgSummaryView.DataBind()
                dgSummaryView.Visible = True
                Dim x As Integer
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindSummaryGridAuth()
        Try
            Dim dt As DataTable
            dt = Session("dtSummaryAuth")
            DgAuthorised.RecordCount = dt.Rows.Count
            DgAuthorised.DataSource = dt
            DgAuthorised.DataBind()
            DgAuthorised.Visible = True
            Dim x As Integer
            For x = 0 To DgAuthorised.Items.Count - 1
                Dim ChkAuditorStatus As CheckBox = CType(DgAuthorised.Items(x).FindControl("ChkAuditorStatusAuth"), CheckBox)
                Dim Status As String = DgAuthorised.Items(x).Cells(10).Text
                If Status = 1 Then
                    ChkAuditorStatus.Checked = True
                Else
                    ChkAuditorStatus.Checked = False
                End If
            Next
        Catch ex As Exception
        End Try
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
                Dim POqTY As Decimal = 0
                Dim ChkAuditorStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                Dim POID As Long = dgSummaryView.Items(x).Cells(0).Text
                POqTY = dgSummaryView.Items(x).Cells(5).Text
                If Status = 1 Then
                    ChkAuditorStatus.Checked = True
                Else
                    ChkAuditorStatus.Checked = False
                End If
                ' for Closed Auditor Status
                Dim ChkAuditorClosedStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorClosedStatus"), CheckBox)
                Dim Status1 As String = dgSummaryView.Items(x).Cells(13).Text
                If Status1 = 1 Then
                    ChkAuditorClosedStatus.Checked = True
                    ChkAuditorStatus.Enabled = False
                Else
                    ChkAuditorClosedStatus.Checked = False
                    ChkAuditorStatus.Enabled = True
                End If
                Dim dtCheck As DataTable = objPOMaster.CheckIssueQty(POID)
                If dtCheck.Rows.Count > 0 Then
                    If POqTY = dtCheck.Rows(0)("IssueQty") Or POqTY < dtCheck.Rows(0)("IssueQty") Then
                        dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Yellow
                        dgSummaryView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Yellow
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function loadSummaryAuth() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOMaster.GetPOforFabricViewSummaryForAuditorAuth()
        Return objDataTable
    End Function
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOMaster.GetPOforFabricViewSummaryForAuditor()
        Return objDataTable
    End Function
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSummaryView.PageIndexChanged
        BindSummaryGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSummaryView.SortCommand
        BindSummaryGrid()
    End Sub
    Protected Sub dgSummaryView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSummaryView.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"
                    Dim poid As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim InditexPONo As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(6).Text
                    Dim FabricPOrder As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(13).Text
                    InditexPONo = InditexPONo.Replace("&nbsp;", "")
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If FabricPOrder = True Then
                        If InditexPONo = "" Then
                            Report.Load(Server.MapPath("..\Reports/FabricLocalPurchaseorder.rpt"))
                        Else
                            Report.Load(Server.MapPath("..\Reports/FabricLocalPurchaseorderForInitexNo.rpt"))
                        End If
                    Else
                        If InditexPONo = "" Then
                            Report.Load(Server.MapPath("..\Reports/ACCPurchaseorder.rpt"))
                        Else
                            Report.Load(Server.MapPath("..\Reports/ACCPurchaseorderForIditexNo.rpt"))
                        End If
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
    Protected Sub txtSummarySearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSummarySearch.TextChanged
        Try
            Dim dt1 As DataTable = objPORecvMaster.GetPOforSearchingPONOViseForAuditor(txtSummarySearch.Text)
            Dim dt2 As DataTable = objPORecvMaster.GetPOforSearchingSupplierViseForAuditor(txtSummarySearch.Text)
            If dt1.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt1
                dgSummaryView.DataBind()
                Dim x As Integer
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim POqTY As Decimal = 0
                    Dim ChkAuditorStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                    Dim POID As Long = dgSummaryView.Items(x).Cells(0).Text
                    POqTY = dgSummaryView.Items(x).Cells(5).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If


                    ' for Closed Auditor Status
                    Dim ChkAuditorClosedStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorClosedStatus"), CheckBox)
                    Dim Status1 As String = dgSummaryView.Items(x).Cells(13).Text
                    If Status1 = 1 Then
                        ChkAuditorClosedStatus.Checked = True
                        ChkAuditorStatus.Enabled = False
                    Else
                        ChkAuditorClosedStatus.Checked = False
                        ChkAuditorStatus.Enabled = True
                    End If
                    Dim dtCheck As DataTable = objPOMaster.CheckIssueQty(POID)
                    If dtCheck.Rows.Count > 0 Then
                        If POqTY = dtCheck.Rows(0)("IssueQty") Or POqTY < dtCheck.Rows(0)("IssueQty") Then
                            dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Yellow
                        End If
                    End If
                Next




            ElseIf dt2.Rows.Count > 0 Then
                dgSummaryView.DataSource = dt2
                dgSummaryView.DataBind()
                Dim x As Integer
                For x = 0 To dgSummaryView.Items.Count - 1
                    Dim POqTY As Decimal = 0
                    Dim ChkAuditorStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgSummaryView.Items(x).Cells(10).Text
                    Dim POID As Long = dgSummaryView.Items(x).Cells(0).Text
                    POqTY = dgSummaryView.Items(x).Cells(5).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If


                    ' for Closed Auditor Status
                    Dim ChkAuditorClosedStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorClosedStatus"), CheckBox)
                    Dim Status1 As String = dgSummaryView.Items(x).Cells(13).Text
                    If Status1 = 1 Then
                        ChkAuditorClosedStatus.Checked = True
                        ChkAuditorStatus.Enabled = False
                    Else
                        ChkAuditorClosedStatus.Checked = False
                        ChkAuditorStatus.Enabled = True
                    End If
                    Dim dtCheck As DataTable = objPOMaster.CheckIssueQty(POID)
                    If dtCheck.Rows.Count > 0 Then
                        If POqTY = dtCheck.Rows(0)("IssueQty") Or POqTY < dtCheck.Rows(0)("IssueQty") Then
                            dgSummaryView.Items.Item(x).Cells(0).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(1).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(2).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(3).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(4).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(5).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(6).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(8).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(10).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(11).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(12).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(13).BackColor = Drawing.Color.Yellow
                            dgSummaryView.Items.Item(x).Cells(14).BackColor = Drawing.Color.Yellow
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub AuditorStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim POID As Integer
        Dim x As Integer
        For x = 0 To dgSummaryView.Items.Count - 1
            Dim ChkAuditorStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
           
            ' for Audit Check
            If ChkAuditorStatus.Checked = True Then
                POID = dgSummaryView.Items(x).Cells(0).Text
                objJobOrderdatabase.AuditorStatus(POID)
                objJobOrderdatabase.UpdateAuditorID(POID, userid)
            Else
                POID = dgSummaryView.Items(x).Cells(0).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOID(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusFalse(POID)
                    objJobOrderdatabase.AuditorIDFalse(POID)
                End If
            End If

            ' for Closed Check           Atif Work : 03 May 2018
            Dim ChkAuditorClosedStatus As CheckBox = CType(dgSummaryView.Items(x).FindControl("ChkAuditorClosedStatus"), CheckBox)
            If ChkAuditorClosedStatus.Checked = True Then
                POID = dgSummaryView.Items(x).Cells(0).Text
                objJobOrderdatabase.AuditorClosedStatus(POID)
                objJobOrderdatabase.UpdateAuditorID(POID, userid)
            Else
                POID = dgSummaryView.Items(x).Cells(0).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDClosed(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusFalseClosed(POID)
                    objJobOrderdatabase.AuditorIDFalse(POID)
                End If
            End If
        Next
        dtSummary = loadSummary()
        Session("dtSummary") = dtSummary
        BindSummaryGrid()


        dtSummaryAuth = loadSummaryAuth()
        Session("dtSummaryAuth") = dtSummaryAuth
        BindSummaryGridAuth()

    End Sub
    Protected Sub AuditorStatusAuth(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim POID As Integer
        Dim x As Integer
        For x = 0 To DgAuthorised.Items.Count - 1
            Dim ChkAuditorStatus As CheckBox = CType(DgAuthorised.Items(x).FindControl("ChkAuditorStatusAuth"), CheckBox)

            If ChkAuditorStatus.Checked = False Then
                POID = DgAuthorised.Items(x).Cells(0).Text
                objJobOrderdatabase.AuditorStatusFalse(POID)
                objJobOrderdatabase.AuditorIDFalse(POID)
            Else
                POID = DgAuthorised.Items(x).Cells(0).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDNew(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatus(POID)
                    objJobOrderdatabase.UpdateAuditorID(POID, userid)
                End If
            End If
        Next
        dtSummaryAuth = loadSummaryAuth()
        Session("dtSummaryAuth") = dtSummaryAuth
        BindSummaryGridAuth()

        dtSummary = loadSummary()
        Session("dtSummary") = dtSummary
        BindSummaryGrid()
    End Sub
End Class




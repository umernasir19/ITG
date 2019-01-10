Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POReceiveForAuditor
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
        PageHeader("PURCHASE RECEIVE")
    End Sub
    Protected Sub btnGetDateWise_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetDateWise.Click
        Try
            If txtDateFrom.SelectedDate.ToString = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objPOMaster.GetDataForPORecvNewForAuditorForDateWiseSearch(SDate)
                dgView.DataSource = dt
                dgView.DataBind()
                dgView.Visible = True
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgView.Items(x).Cells(13).Text
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
                Dim Status As String = DgAuthorised.Items(x).Cells(13).Text
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
            dgView.RecordCount = dt.Rows.Count
            dgView.DataSource = dt
            dgView.DataBind()
            dgView.Visible = True
            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                Dim Status As String = dgView.Items(x).Cells(13).Text
                If Status = 1 Then
                    ChkAuditorStatus.Checked = True
                Else
                    ChkAuditorStatus.Checked = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Function loadSummaryAuth() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPORecvMaster.GetDataForPORecvNewForAuditorAuth()
        Return objDataTable
    End Function
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPORecvMaster.GetDataForPORecvNewForAuditor()
        Return objDataTable
    End Function
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindSummaryGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindSummaryGrid()
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
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
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub AuditorStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim POID As Integer
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
            If ChkAuditorStatus.Checked = True Then
                POID = dgView.Items(x).Cells(2).Text
                objJobOrderdatabase.AuditorStatusForRecv(POID)
                objJobOrderdatabase.UpdateAuditorIDForPORecv(POID, userid)
            Else
                POID = dgView.Items(x).Cells(2).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDForPOrecv(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusFalseForPORecv(POID)
                    objJobOrderdatabase.AuditorIDFalseForPORecv(POID)
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
                POID = DgAuthorised.Items(x).Cells(2).Text
                objJobOrderdatabase.AuditorStatusFalseForPORecv(POID)
                objJobOrderdatabase.AuditorIDFalseForPORecv(POID)
            Else
                POID = DgAuthorised.Items(x).Cells(2).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDNewForrecv(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusForRecv(POID)
                    objJobOrderdatabase.UpdateAuditorIDForPORecv(POID, userid)
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
    Protected Sub txtSummarySearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSummarySearch.TextChanged
        Try
            Dim dt1 As DataTable = objPORecvMaster.GetDataForPORecvForPONOViseForAuditor(txtSummarySearch.Text)
            Dim dt2 As DataTable = objPORecvMaster.GetDataForPORecvForStyleViseForAuditor(txtSummarySearch.Text)
            Dim dt3 As DataTable = objPORecvMaster.GetDataForPORecvForItemViseForAuditor(txtSummarySearch.Text)
            Dim dt4 As DataTable = objPORecvMaster.GetDataForPORecvForSupplierViseForAuditor(txtSummarySearch.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataSource = dt1
                dgView.DataBind()
                dgView.Visible = True
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgView.Items(x).Cells(13).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataSource = dt2
                dgView.DataBind()
                dgView.Visible = True
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgView.Items(x).Cells(13).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataSource = dt3
                dgView.DataBind()
                dgView.Visible = True
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgView.Items(x).Cells(13).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataSource = dt4
                dgView.DataBind()
                dgView.Visible = True
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgView.Items(x).Cells(13).Text
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
End Class
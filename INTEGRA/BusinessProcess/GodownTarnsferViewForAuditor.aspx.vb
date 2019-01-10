Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class GodownTarnsferViewForAuditor
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
    Dim objGodownIssueMst As New GodownIssueMst
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
        PageHeader("Godown Transfer")
    End Sub
    Protected Sub txtSummarySearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSummarySearch.TextChanged
        Try
            Dim dt1 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForSIVNoForAuditor(txtSummarySearch.Text)
            Dim dt2 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForItemCodeeForAuditor(txtSummarySearch.Text)
            Dim dt3 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForFromLocationForAuditor(txtSummarySearch.Text)
            Dim dt4 As DataTable = objGodownIssueMst.GetAllDataNewWithUserNewForToLocationForAuditor(txtSummarySearch.Text)
            If dt1.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt1
                dgStoreIssue.DataSource = dt1
                dgStoreIssue.DataBind()
                dgStoreIssue.Visible = True
                Dim x As Integer
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt2.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt2
                dgStoreIssue.DataSource = dt2
                dgStoreIssue.DataBind()
                dgStoreIssue.Visible = True
                Dim x As Integer
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt3.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt3
                dgStoreIssue.DataSource = dt3
                dgStoreIssue.DataBind()
                dgStoreIssue.Visible = True
                Dim x As Integer
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
                    If Status = 1 Then
                        ChkAuditorStatus.Checked = True
                    Else
                        ChkAuditorStatus.Checked = False
                    End If
                Next
            ElseIf dt4.Rows.Count > 0 Then
                dgStoreIssue.DataSource = dt4
                dgStoreIssue.DataSource = dt4
                dgStoreIssue.DataBind()
                dgStoreIssue.Visible = True
                Dim x As Integer
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
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
    Protected Sub btnGetDateWise_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetDateWise.Click
        Try
            If txtDateFrom.SelectedDate.ToString = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim Date1 As Date = txtDateFrom.SelectedDate
                Dim SDate As String = Date1.ToString("dd/MM/yyyy")
                Dim dt As DataTable = objPOMaster.GetAllDataNewWithUserAllAuditorAuthNewwwDateVise(SDate)
                dgStoreIssue.DataSource = dt
                dgStoreIssue.DataBind()
                dgStoreIssue.Visible = True
                Dim x As Integer
                For x = 0 To dgStoreIssue.Items.Count - 1
                    Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                    Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
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
            dgStoreIssue.RecordCount = dt.Rows.Count
            dgStoreIssue.DataSource = dt
            dgStoreIssue.DataBind()
            dgStoreIssue.Visible = True
            Dim x As Integer
            For x = 0 To dgStoreIssue.Items.Count - 1
                Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
                Dim Status As String = dgStoreIssue.Items(x).Cells(10).Text
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
        objDataTable = objPORecvMaster.GetAllDataNewWithUserAllAuditorAuth()
        Return objDataTable
    End Function
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPORecvMaster.GetAllDataNewWithUserAllAuditorAuthNewww()
        Return objDataTable
    End Function
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgStoreIssue.PageIndexChanged
        BindSummaryGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStoreIssue.SortCommand
        BindSummaryGrid()
    End Sub
    Protected Sub dgStoreIssue_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStoreIssue.ItemCommand
        Try
            Select Case e.CommandName
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub AuditorStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim POID As Integer
        Dim x As Integer
        For x = 0 To dgStoreIssue.Items.Count - 1
            Dim ChkAuditorStatus As CheckBox = CType(dgStoreIssue.Items(x).FindControl("ChkAuditorStatus"), CheckBox)
            If ChkAuditorStatus.Checked = True Then
                POID = dgStoreIssue.Items(x).Cells(0).Text
                objJobOrderdatabase.AuditorStatusForRecvGodownTransfer(POID)
                objJobOrderdatabase.UpdateAuditorIDForPOGowonIssueee(POID, userid)
            Else
                POID = dgStoreIssue.Items(x).Cells(0).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDForPOrecvGodownTransfer(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusFalseForPORecvGodownTransfer(POID)
                    objJobOrderdatabase.AuditorIDFalseForGodownIssue(POID)
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
                objJobOrderdatabase.AuditorStatusFalseForPORecvGodownTransfer(POID)
                objJobOrderdatabase.AuditorIDFalseForGodownIssue(POID)
            Else
                POID = DgAuthorised.Items(x).Cells(0).Text
                Dim dt As DataTable = objJobOrderdatabase.CheckAlreadyCheckPOIDNewForrecvGodownTransfer(POID)
                If dt.Rows.Count > 0 Then
                Else
                    objJobOrderdatabase.AuditorStatusForRecvGodownTransfer(POID)
                    objJobOrderdatabase.UpdateAuditorIDForPOGowonIssueee(POID, userid)
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

Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class TrackingPanel
    Inherits System.Web.UI.Page
    Dim objWIPChart As New WIPChart
    Dim objQDInspection As New QDInspection
    Dim dtsearch As New DataTable
    Dim objDataView As DataView
    Dim objDataViewInspection As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                PageHeader("WIP & Inspection Tracking Panel")
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnTracking_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTracking.Click
        Try
            If cmbTracking.SelectedIndex = 0 Then
                dgWipTracking.Visible = False
                dgInspectionTracking.Visible = False
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing

            ElseIf cmbTracking.SelectedIndex = 1 Then
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
                dgWipTracking.Visible = True
                dgInspectionTracking.Visible = False
                dtsearch = objWIPChart.GetTrackingData(txtStartDate.SelectedDate, txtEndDate.SelectedDate)
                Session("objDataView") = dtsearch.DefaultView
                BindGrid()

            ElseIf cmbTracking.SelectedIndex = 2 Then
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
                dgInspectionTracking.Visible = True
                dgWipTracking.Visible = False
                dtsearch = objQDInspection.GetDataForInspectionTracking(txtStartDate.SelectedDate, txtEndDate.SelectedDate)
                Session("objDataViewInspection") = dtsearch.DefaultView
                BindInspectionGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGrid()
        Try
            objDataView = Session("objDataView")
            dgWipTracking.DataSource = objDataView
            dgWipTracking.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindInspectionGrid()
        Try
            objDataViewInspection = Session("objDataViewInspection")
            dgInspectionTracking.DataSource = objDataViewInspection
            dgInspectionTracking.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgWipTracking_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgWipTracking.NeedDataSource
        objDataView = Session("objDataView")
        dgWipTracking.DataSource = objDataView
    End Sub
    Protected Sub dgWipTracking_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgWipTracking.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgWipTracking_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgWipTracking.SortCommand
        BindGrid()
    End Sub
    Protected Sub cmbTracking_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbTracking.SelectedIndexChanged
        Try
            If cmbTracking.SelectedIndex = 0 Then
                dgWipTracking.Visible = False
                dgInspectionTracking.Visible = False
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
                lblHeading.Text = ""
            ElseIf cmbTracking.SelectedIndex = 1 Then
                dgInspectionTracking.Visible = False
                dgWipTracking.Visible = True
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
                lblHeading.Text = "WIP Tracking"
            ElseIf cmbTracking.SelectedIndex = 2 Then
                dgWipTracking.Visible = False
                dgInspectionTracking.Visible = True
                Session("objDataView") = Nothing
                Session("objDataViewInspection") = Nothing
                lblHeading.Text = "Inspection Tracking"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgInspectionTracking_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgInspectionTracking.PageIndexChanged
        BindInspectionGrid()
    End Sub
    Protected Sub dgInspectionTracking_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgInspectionTracking.SortCommand
        BindInspectionGrid()
    End Sub
    Protected Sub dgInspectionTracking_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgInspectionTracking.NeedDataSource
        objDataView = Session("objDataViewInspection")
        dgInspectionTracking.DataSource = objDataView
    End Sub

End Class
Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System

Public Class ProductionLineStatusPlanning
    Inherits System.Web.UI.Page
    Dim objProductionLineStatus As New ProductionLineStatus
    Dim objProductionLineStatusDetail As New ProductionLineStatusDetail
    Dim objProductionLineStatusHistory As New ProductionLineStatusHistory
    Dim PLSEID As Long
    Dim Dr As DataRow
    Dim DtDates As New DataTable
    Dim StyleNo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PLSEID = Request.QueryString("lPLSEID")
        txtTodayDate.Text = Today.Date
        If Not Page.IsPostBack Then
            If PLSEID > 0 Then
                SetValuesEditMod()
                BindGrid()
            End If
           
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim dt As DataTable
        Try
            dt = objProductionLineStatus.GetProductionStatusPlanningValues(PLSEID)
            txtPONO.Text = dt.Rows(0)("PONO")
            txtSupplier.Text = dt.Rows(0)("VenderName")
            txtCustomer.Text = dt.Rows(0)("CustomerName")

            txtPlacementDate.Text = dt.Rows(0)("PlacementDate")
            txtShipmentDate.Text = dt.Rows(0)("ShipmentDate")
            txtDaysLeft.Text = dt.Rows(0)("DaysDif")
            txtTotalLines.Text = dt.Rows(0)("TotalLines")
            txtProductionLine.Text = dt.Rows(0)("ProductionLine")
            txtProductionDay.Text = dt.Rows(0)("SumProduction")
            txtDaysRequired.Text = dt.Rows(0)("SumDaysRequired")
            txtLineInitiatedOn.Text = dt.Rows(0)("LineInitiatedOn")
            txtLineClosing.Text = dt.Rows(0)("LineClosing")

            Dim objDataView As DataView
            objDataView = New DataView(dt)
            Session("ProductionPlanning") = objDataView
            BindPackingListView()
            Dates()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindPackingListView()
        Try
            Dim objDataView As DataView
            objDataView = Session("ProductionPlanning")
            dgProductionLineStatusPlanning.DataSource = objDataView
            dgProductionLineStatusPlanning.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub Dates()
        Try
            '-------------------- Detail Values
            Dim x As Integer
            Dim dt As New DataTable
            dt = objProductionLineStatus.GetProductionStatusPlanningValues(PLSEID)
            DtDates = Nothing
            Session("DtDates") = Nothing
            DtDates = New DataTable
            With DtDates
                .Columns.Add("Dates", GetType(String))
            End With
            For x = 0 To dt.Rows(0)("DateDaysDif") - 1
                Dr = DtDates.NewRow()
                If x = 0 Then
                    Dim NewDate As Date = dt.Rows(0)("LineInitiatedOn")
                    Dr("Dates") = NewDate.ToString("dd/MM/yyyy")
                Else
                    Dim NewDate As Date = dt.Rows(0)("LineInitiatedOn")
                    Dr("Dates") = NewDate.AddDays(x).ToString("dd/MM/yyyy")
                End If
                DtDates.Rows.Add(Dr)
            Next
            Dr = DtDates.NewRow()
            Dim NewDatee As Date = dt.Rows(0)("LineInitiatedOn")
            Dr("Dates") = NewDatee.AddDays(x).ToString("dd/MM/yyyy")
            DtDates.Rows.Add(Dr)

            x = 0
            Dim cmbDate As RadComboBox
            For x = 0 To dgProductionLineStatusPlanning.Items.Count - 1
                cmbDate = CType(dgProductionLineStatusPlanning.Items(x).FindControl("cmbDate"), RadComboBox)
                cmbDate.DataSource = DtDates
                cmbDate.DataTextField = "Dates"
                cmbDate.DataBind()
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim objProductionLinestatusHistory As New ProductionLineStatusHistory
            Dim x As Integer = 0
            Dim txtStitchedSoFar As RadNumericTextBox
            Dim cmbDate As RadComboBox

            For x = 0 To dgProductionLineStatusPlanning.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgProductionLineStatusPlanning.MasterTableView.Items(x), GridDataItem)
                cmbDate = CType(dgProductionLineStatusPlanning.Items(x).FindControl("cmbDate"), RadComboBox)
                txtStitchedSoFar = CType(dgProductionLineStatusPlanning.Items(x).FindControl("txtStitchedSoFar"), RadNumericTextBox)

                If Not txtStitchedSoFar.Text = "" Then
                    With objProductionLinestatusHistory

                        .PLSHID = 0
                        .PLSDID = item("PLSDID").Text
                        .CreationDate = Today.Date
                        .StitchedQty = txtStitchedSoFar.Text
                        .StitchedDate = cmbDate.SelectedItem.Text
                        .SaveProductionLineStatusHistory()
                    End With
                End If
            Next
            BindGrid()
            '''''''''''''''''''''Again Bing Style Grid
            Dim dtstyle As New DataTable
            dtstyle = objProductionLineStatus.GetProductionStatusPlanningValues(PLSEID)
            Dim objDataView As DataView
            objDataView = New DataView(dtstyle)
            Session("ProductionPlanning") = objDataView
            BindPackingListView()
            Dates()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Try

            dgProductionPlannedHistory.DataSource = objProductionLineStatusHistory.GetProductionPlannedHistoryView(PLSEID)
            dgProductionPlannedHistory.DataBind()
        Catch ex As Exception
        End Try
    End Sub
   
    Protected Sub dgProductionPlannedHistory_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgProductionPlannedHistory.NeedDataSource

        dgProductionPlannedHistory.DataSource = objProductionLineStatusHistory.GetProductionPlannedHistoryView(PLSEID)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/BusinessProcess/ProductionLineStatusView.aspx")
    End Sub
End Class
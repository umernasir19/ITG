Imports System
Imports System.Data
Imports System.Configuration
Imports Integra.EuroCentra
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Telerik.Charting
Imports Telerik.Web.UI

Public Class ProductionLineStatusActivityView
    Inherits System.Web.UI.Page
    Dim objProductionLineStatus As New ProductionLineStatus
    Dim objProductionLineStatusDetail As New ProductionLineStatusDetail
    Dim objProductionLineStatusHistory As New ProductionLineStatusHistory
    Dim PLSEID As Long
    Dim Dr As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PLSEID = Request.QueryString("lPLSEID")
        'Dim selectedIndex As Integer = ProductionPlanned.SelectedItem.Index
        'ProductionPlanned.Items(selectedIndex + 1).Enabled = True
        'ProductionPlanned.Items(selectedIndex).Expanded = False
        GoToNextItem()
        txtTodayDate.Text = Today.Date
        If Not Page.IsPostBack Then
            If PLSEID > 0 Then
                SetValuesEditMod()
                PlannedGrid()
            End If

        End If
    End Sub
    Private Sub GoToNextItem()
        Dim selectedIndex As Integer = ProductionPlanned.SelectedItem.Index
        ProductionPlanned.Items(selectedIndex + 0).Selected = True
        ProductionPlanned.Items(selectedIndex + 0).Expanded = True
        ProductionPlanned.Items(selectedIndex + 0).Enabled = True
        ProductionPlanned.Items(selectedIndex + 0).Expanded = False
    End Sub
    Sub SetValuesEditMod()
        Dim dt As DataTable
        Dim ProductionLineItem As RadPanelItem = DirectCast(ProductionPlanned.FindItemByValue("ProductionLinePlanned"), RadPanelItem)
        Dim txtTotalLines As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtTotalLines"), RadTextBox)
        Dim txtProductionLine As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtProductionLine"), RadTextBox)
        Dim txtProductionDay As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtProductionDay"), RadTextBox)
        Dim txtDaysRequired As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtDaysRequired"), RadTextBox)
        Dim txtLineInitiatedOn As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtLineInitiatedOn"), RadTextBox)
        Dim txtLineClosing As RadTextBox = DirectCast(ProductionLineItem.FindControl("txtLineClosing"), RadTextBox)

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
        Catch ex As Exception

        End Try
    End Sub
    Sub PlannedGrid()
        Try
            Dim x As Integer
            Dim dtDate As New DataTable
            dtDate = objProductionLineStatus.GetProductionStatusPlanningValues(PLSEID)
            Dim dtPlanned As New DataTable
            Dim Count As Integer
            Dim SumPlanned As Decimal
            Dim LineInitiatedOn As DateTime
            Dim LineInitiatedOns As String
            dtPlanned = New DataTable
            With dtPlanned
                .Columns.Add("Days", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("PlannedDate", GetType(String))
                .Columns.Add("Planned", GetType(Decimal))
                .Columns.Add("Produced", GetType(Decimal))
                .Columns.Add("Producedsum", GetType(Decimal))
            End With
            For x = 0 To dtDate.Rows(0)("DateDaysDif") - 1
                SumPlanned = dtDate.Rows(0)("ProductionLine")
                Dr = dtPlanned.NewRow()
                If x = 0 Then
                    Dr("Days") = "Day 1"
                    Dr("StyleNo") = dtDate.Rows(0)("StyleNo")
                    Dr("Planned") = SumPlanned
                    LineInitiatedOn = dtDate.Rows(0)("LineInitiatedOn")
                    LineInitiatedOns = LineInitiatedOn.ToString("dd/MM/yyyy")
                    Dr("PlannedDate") = LineInitiatedOns
                    Dr("Produced") = objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
                    Dr("Producedsum") = objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
                    Count = 2
                Else
                    Dim NewDate As DateTime = dtDate.Rows(0)("LineInitiatedOn")
                    Dr("Days") = "Day " + Count.ToString()
                    Dr("StyleNo") = dtDate.Rows(0)("StyleNo")
                    Dr("Planned") = SumPlanned * Count
                    Dr("PlannedDate") = NewDate.AddDays(x).ToString("dd/MM/yyyy")
                    LineInitiatedOns = NewDate.AddDays(x).ToString("dd/MM/yyyy")
                    Dr("Produced") = objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
                    Dr("Producedsum") = dtPlanned.Rows(dtPlanned.Rows.Count - 1)("Producedsum") + objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
                    Count = Count + 1
                End If
                dtPlanned.Rows.Add(Dr)
            Next
            Dr = dtPlanned.NewRow()
            Dim NewDatee As DateTime = dtDate.Rows(0)("LineInitiatedOn")
            Dr("PlannedDate") = NewDatee.AddDays(x).ToString("dd/MM/yyyy")
            Dr("Days") = "Day " + Count.ToString()
            Dr("StyleNo") = dtDate.Rows(0)("StyleNo")
            Dr("Planned") = dtDate.Rows(0)("ProductionLine") * Count
            LineInitiatedOns = NewDatee.AddDays(x).ToString("dd/MM/yyyy")
            Dr("Produced") = objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
            Dr("Producedsum") = dtPlanned.Rows(dtPlanned.Rows.Count - 1)("Producedsum") + objProductionLineStatusHistory.GetStitchedQuantity(PLSEID, LineInitiatedOns)
            dtPlanned.Rows.Add(Dr)
            Dim objDataView As DataView
            objDataView = New DataView(dtPlanned)
            Session("Productionhistory") = objDataView
            BindProductionPlannedHistory()
            '''''''''''''''Code for Rad Chart'''''''''''''''''''''''
            RadChart1.DataSource = dtPlanned

            Dim ChartSeries As New ChartSeries
            ChartSeries.Appearance.LabelAppearance.Visible = True
            ChartSeries.Name = "Produced"
            ChartSeries.DataYColumn = "producedsum"
            ChartSeries.Type = Telerik.Charting.ChartSeriesType.Line
            ChartSeries.Appearance.PointMark.Dimensions.Width = 5
            ChartSeries.Appearance.PointMark.Dimensions.Height = 5
            ChartSeries.Appearance.LineSeriesAppearance.Color = Drawing.Color.Green
            ChartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.White
            ChartSeries.Appearance.PointMark.Visible = True
            ChartSeries.Appearance.TextAppearance.TextProperties.Color = Drawing.Color.White

            Dim ChartSeries3 As New ChartSeries
            ChartSeries3.Appearance.LabelAppearance.Visible = True
            ChartSeries3.Name = "Planned"
            ChartSeries3.DataYColumn = "Planned"
            ChartSeries3.Type = Telerik.Charting.ChartSeriesType.Line
            ChartSeries3.Appearance.PointMark.Dimensions.Width = 5
            ChartSeries3.Appearance.PointMark.Dimensions.Height = 5
            ChartSeries3.Appearance.LineSeriesAppearance.Color = Drawing.Color.White
            ChartSeries3.Appearance.LineSeriesAppearance.PenStyle = Drawing.Drawing2D.DashStyle.Dash
            ChartSeries3.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black
            ChartSeries3.Appearance.PointMark.Visible = True
            ChartSeries3.Appearance.TextAppearance.TextProperties.Color = Drawing.Color.White

            RadChart1.Appearance.FillStyle.MainColor = Drawing.Color.White
            RadChart1.PlotArea.Appearance.FillStyle.MainColor = Drawing.Color.LightBlue
            RadChart1.ChartTitle.TextBlock.Text = "Stitching Line Status"
            RadChart1.Legend.Appearance.FillStyle.MainColor = Drawing.Color.LightBlue

            RadChart1.PlotArea.YAxis.AxisLabel.TextBlock.Text = "Planned"
            RadChart1.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = Drawing.Color.Black
            RadChart1.PlotArea.YAxis.AxisMode = ChartYAxisMode.Extended
            RadChart1.PlotArea.YAxis.AxisLabel.Visible = True
            RadChart1.PlotArea.YAxis.Appearance.TextAppearance.TextProperties.Color = Drawing.Color.Black

            RadChart1.PlotArea.XAxis.DataLabelsColumn = "PlannedDate"
            RadChart1.PlotArea.XAxis.Appearance.ValueFormat = Telerik.Charting.Styles.ChartValueFormat.ShortDate
            RadChart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = Drawing.Color.Black

            RadChart1.AddChartSeries(ChartSeries)
            RadChart1.AddChartSeries(ChartSeries3)
            RadChart1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindProductionPlannedHistory()
        Try
            Dim ProductionActivityHistoryItem As RadPanelItem = DirectCast(ActivityHistoryBar.FindItemByValue("ProductionActivityHistory"), RadPanelItem)
            Dim dgProductionPlannedHistory As RadGrid = DirectCast(ProductionActivityHistoryItem.FindControl("dgProductionPlannedHistory"), RadGrid)
            Dim objDataView As DataView
            objDataView = Session("Productionhistory")
            dgProductionPlannedHistory.DataSource = objDataView
            dgProductionPlannedHistory.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub RadChart1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Charting.ChartItemDataBoundEventArgs) Handles RadChart1.ItemDataBound
        e.SeriesItem.Name = (CType(e.DataItem, DataRowView))("Planned").ToString()
        e.SeriesItem.Name = (CType(e.DataItem, DataRowView))("Produced").ToString()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/BusinessProcess/ProductionLineStatusView.aspx")
    End Sub

    Protected Sub ProductionPlanned_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadPanelBarEventArgs) Handles ProductionPlanned.ItemClick

    End Sub
End Class
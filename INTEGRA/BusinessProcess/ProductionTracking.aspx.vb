Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ProductionTracking
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim lPOID As Long
    Dim objWIPProcess As New WIPProcess
    Dim objWIPChart As New WIPChart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            LoadEditDate()
            objDataView = LoadData()
            Session("objDataTracking") = objDataView
            BindGrid()
        End If
    End Sub
    Sub LoadEditDate()
        Dim Dt As DataTable
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMasterView(lPOID)
            lblPONO.Text = Dt.Rows(0)("PONO")
            lblShipment.Text = Dt.Rows(0)("ShipmentDatee")
            lblCustomer.Text = Dt.Rows(0)("CustomerName")
            lblSupplier.Text = Dt.Rows(0)("VenderName")
            lblEknumber.Text = Dt.Rows(0)("eknumber")
            lblSeason.Text = Dt.Rows(0)("Season")
            lblPORefNo.Text = Dt.Rows(0)("POrefNO")
            lblPOQty.Text = Dt.Compute("sum(Quantity)", "").ToString() + "Pcs"
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If lblPORefNo.Text = 0 Then
            objDataTable = objWIPProcess.GetWIPProcessForNewStyle()
        Else
            objDataTable = objWIPProcess.GetWIPProcessForRepeatStyle()
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataTracking")
        If objDataView.Count > 0 Then
            dgSelecttion.Visible = True
            dgSelecttion.DataSource = objDataView
            dgSelecttion.DataBind()
        Else
            dgSelecttion.Visible = False
        End If
        Dim x As Integer
        Dim Dt, dtArticle, DtDate, dtBookedQty, dtEstimated As DataTable
        dtArticle = objPurchaseMaster.GetTotalArticles(lPOID)
        Dim ProcessPercent As Long
        Dim PercentValue As Decimal = Math.Round(100 / dtArticle.Rows(0)("TotalArticle"), 2)
        Dim lblProcessStage, lblEstimatedDate As Label
        Dim lblYield As Label
        For x = 0 To dgSelecttion.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgSelecttion.MasterTableView.Items(x), GridDataItem)
            lblProcessStage = CType(dgSelecttion.Items(x).FindControl("lblProcessStage"), Label)
            lblEstimatedDate = CType(dgSelecttion.Items(x).FindControl("lblEstimatedDate"), Label)
            lblYield = CType(dgSelecttion.Items(x).FindControl("lblYield"), Label)
            Dim ProcessID As Integer = item("WIPProcessID").Text
            Dt = objWIPChart.GetWIPChartTracking(lPOID, ProcessID)
            dtEstimated = objWIPChart.GetWIPEstimatedDate(lPOID, ProcessID)
            lblEstimatedDate.Text = dtEstimated.Rows(0)("EstimatedDate")
            If Dt.Rows(0)("WIPArticle") = 0 Then
                lblProcessStage.Text = "---"
                lblYield.Text = "---"
            Else
                If ProcessID >= 9 Then
                    dtBookedQty = objWIPChart.GetBookedQty(lPOID, ProcessID)
                    DtDate = objWIPChart.GetTopWIPChartTracking(lPOID, ProcessID)
                    lblProcessStage.Text = DtDate.Rows(0)("ActivityDate")
                    lblYield.Text = dtBookedQty.Rows(0)("Quantity").ToString() + "Pcs"
                Else
                    DtDate = objWIPChart.GetTopWIPChartTracking(lPOID, ProcessID)
                    ProcessPercent = PercentValue * Dt.Rows(0)("WIPArticle")
                    lblProcessStage.Text = DtDate.Rows(0)("ActivityDate")
                    lblYield.Text = ProcessPercent.ToString() + "%"
                End If
            End If
            ProcessPercent = 0
        Next
    End Sub

End Class
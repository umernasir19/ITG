Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class StitchingStatusView
    Inherits System.Web.UI.Page
    Dim objStitchingStatus As New StitchingStatus
    Dim dtProductionDay As New DataTable
    Dim Dr As DataRow
    Dim IPOID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IPOID = Request.QueryString("IPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgStitchingStatusView.DataSource = objDataView
            dgStitchingStatusView.DataBind()

            Dim x As Integer
            Dim CapacityPlanL1 As Decimal = 0
            Dim CapacityPlanL2 As Decimal = 0
            Dim CapacityPlan As Decimal = 0
            Dim CapacityActualL1 As Decimal = 0
            Dim CapacityActualL2 As Decimal = 0
            Dim CapacityActual As Decimal = 0
            Dim lblActual As Label
            Dim lblPlan As Label
            For x = 0 To dgStitchingStatusView.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgStitchingStatusView.MasterTableView.Items(x), GridDataItem)
                lblActual = CType(dgStitchingStatusView.Items(x).FindControl("lblActual"), Label)
                lblPlan = CType(dgStitchingStatusView.Items(x).FindControl("lblPlan"), Label)
                CapacityPlanL1 = objStitchingStatus.CapacityPlanL1(item("StitchingStatusDetailID").Text)
                CapacityPlanL2 = objStitchingStatus.CapacityPlanL2(item("StitchingStatusDetailID").Text)
                CapacityPlan = CapacityPlanL1 + CapacityPlanL2
                lblPlan.Text = CapacityPlan
                CapacityActualL1 = objStitchingStatus.CapacityActualL1(item("StitchingStatusDetailID").Text)
                CapacityActualL2 = objStitchingStatus.CapacityActualL2(item("StitchingStatusDetailID").Text)
                CapacityActual = CapacityActualL1 + CapacityActualL2
                lblActual.Text = CapacityActual
            Next

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStitchingStatus.GetData(IPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'Function GetData()
    '    dtProductionDay = objStitchingStatus.GetData
    '    Dim dt As New DataTable
    '    With dt
    '        .Columns.Add("StitchingStatusID", GetType(Double))
    '        .Columns.Add("L1Plan", GetType(String))
    '        .Columns.Add("L1Actual", GetType(String))
    '        .Columns.Add("L2Plan", GetType(String))
    '        .Columns.Add("L2Actual", GetType(String))
    '        .Columns.Add("CapacityPlan", GetType(String))
    '        .Columns.Add("CapacityActual", GetType(String))
    '    End With
    '    Dim xx As Integer
    '    For xx = 0 To dtProductionDay.Rows.Count - 1
    '        Dr = dt.NewRow()
    '        Dr = ("StitchingStatusID") = dtProductionDay.Rows(xx)("StitchingStatusID")
    '        Dr = ("L1Plan") = dtProductionDay.Rows(xx)("L1Plan")
    '        Dr = ("L1Actual") = dtProductionDay.Rows(xx)("L1Actual")
    '        Dr = ("L2Plan") = dtProductionDay.Rows(xx)("L2Plan")
    '        Dr = ("L2Actual") = dtProductionDay.Rows(xx)("L2Actual")
    '        Dr = ("CapacityPlan") = dtProductionDay.Rows(xx)("L1Plan") + dtProductionDay.Rows(xx)("L2Plan")
    '        Dr = ("CapacityActual") = dtProductionDay.Rows(xx)("L1Actual") + dtProductionDay.Rows(xx)("L2Actual")
    '        dt.Rows.Add(Dr)
    '    Next
    '    Session("dtProductionDay") = dt
    'End Function
End Class
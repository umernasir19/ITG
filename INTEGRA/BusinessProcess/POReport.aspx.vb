Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class POReport
    Inherits System.Web.UI.Page
    Dim rd As New ReportDocument
    Dim POID, ReportName, DebitNoteID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("POID")
        ReportName = Request.QueryString("ReportName")
        DebitNoteID = Request.QueryString("DebitNoteID")
        Page.Title = ReportName
        If ReportName = "TNAChart" Then
            rd.Load(Server.MapPath("..\Reports/TNAChart.rpt"))
            rd.SetDatabaseLogon("sa", "pwd")
            rd.SetParameterValue(0, POID)
            CRViewer.ReportSource = rd
            CRViewer.SelectionFormula = "{SP_TNAChart;1.POID}=" & POID & ""
            CRViewer.DisplayGroupTree = False
            CRViewer.DataBind()
        ElseIf ReportName = "ProductionStatistics" Then
            rd.Load(Server.MapPath("..\Reports/ProductionStatistics.rpt"))
            rd.SetDatabaseLogon("sa", "pwd")
            rd.SetParameterValue(0, POID)
            CRViewer.ReportSource = rd
            CRViewer.SelectionFormula = "{SP_ProductionStatistics;1.POID}=" & POID & ""
            CRViewer.DisplayGroupTree = False
            CRViewer.DataBind()
        ElseIf ReportName = "DebitNote" Then
            rd.Load(Server.MapPath("..\Reports/rptDebitNote.rpt"))
            rd.SetDatabaseLogon("sa", "pwd")
            rd.SetParameterValue(0, DebitNoteID)
            CRViewer.ReportSource = rd
            CRViewer.DisplayGroupTree = False
            CRViewer.DataBind()
        Else
            rd.Load(Server.MapPath("..\Reports/rptPurchaseOrder.rpt"))
            rd.SetDatabaseLogon("sa", "pwd")
            CRViewer.ReportSource = rd
            CRViewer.SelectionFormula = "{SP_PurchaseOrder;1.POID}=" & POID
            CRViewer.DisplayGroupTree = False
            CRViewer.DataBind()
        End If
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rd.Dispose()
        rd.Clone()
    End Sub

    Protected Sub CRViewer_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRViewer.Unload
        rd.Dispose()
        rd.Clone()
    End Sub
End Class
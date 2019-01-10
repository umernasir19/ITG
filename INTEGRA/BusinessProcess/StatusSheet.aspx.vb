Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class StatusSheet
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgMGTSheetForAldiOrders.DataSource = objDataView
        dgMGTSheetForAldiOrders.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForAldiOrders()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgMGTSheetForAldiOrders_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMGTSheetForAldiOrders.NeedDataSource
        dgMGTSheetForAldiOrders.DataSource = objPo.GetMasterOrderForAldiOrders()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMGTSheetForAldiOrders.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMGTSheetForAldiOrders.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMGTSheetForAldiOrders.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgMGTSheetForAldiOrders.ItemCommand
        Select Case e.CommandName
            Case Is = "Status"
                Dim dtcheck As New DataTable
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                Dim st As StringBuilder = New StringBuilder()
                st.Append("<script language='javascript'>")
                st.Append("var w = window.open('ProductionStatus.aspx?IPOID=" & lPOID & "','PopUpWindowName','left=50, top=150, height=600, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                st.Append("w.focus()")
                st.Append("</script>")
                Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
        End Select
    End Sub

End Class
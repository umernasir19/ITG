Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class LeadTimeAlreadyApproved
    Inherits System.Web.UI.Page
    Dim objLeadTimeApproval As New LeadTimeApproved
    Dim IMerchandid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMerchandid = Request.QueryString("Merchandid")
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
        dgLeadTimeApprovalSheet.DataSource = objDataView
        dgLeadTimeApprovalSheet.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As New DataView
            Dim objDataTable, objDataTable1 As DataTable
            objDataTable = objLeadTimeApproval.GetLeadTimeApprovalForNewOrderAlready(IMerchandid)
            objDataTable1 = objLeadTimeApproval.GetLeadTimeApprovalForRepeatOrderAlready(IMerchandid)
            If objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count > 0 Then
                objDataTable.Merge(objDataTable1)
                objDataView = New DataView(objDataTable)
            ElseIf objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count = 0 Then
                objDataView = New DataView(objDataTable)
            ElseIf objDataTable.Rows.Count = 0 And objDataTable1.Rows.Count > 0 Then
                objDataView = New DataView(objDataTable1)
            Else
                objDataView = New DataView(objDataTable)
            End If
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgLeadTimeApprovalSheet_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgLeadTimeApprovalSheet.NeedDataSource
        Dim objDataTable, objDataTable1 As DataTable
        objDataTable = objLeadTimeApproval.GetLeadTimeApprovalForNewOrderAlready(IMerchandid)
        objDataTable1 = objLeadTimeApproval.GetLeadTimeApprovalForRepeatOrderAlready(IMerchandid)
        If objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count > 0 Then
            objDataTable.Merge(objDataTable1)
            dgLeadTimeApprovalSheet.DataSource = objDataTable
        ElseIf objDataTable.Rows.Count > 0 And objDataTable1.Rows.Count = 0 Then
            dgLeadTimeApprovalSheet.DataSource = objDataTable
        ElseIf objDataTable.Rows.Count = 0 And objDataTable1.Rows.Count > 0 Then
            dgLeadTimeApprovalSheet.DataSource = objDataTable1
        Else
            dgLeadTimeApprovalSheet.DataSource = objDataTable
        End If
    End Sub
    Protected Sub dgLeadTimeApprovalSheet_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgLeadTimeApprovalSheet.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgLeadTimeApprovalSheet_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgLeadTimeApprovalSheet.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgLeadTimeApprovalSheet_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgLeadTimeApprovalSheet.SortCommand
        BindGrid()
    End Sub
    

End Class
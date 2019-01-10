Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class ShippedApprovalSheet
    Inherits System.Web.UI.Page
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjShippedApproval As New ShippedApproval
    Dim MarchandID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MarchandID = Request.QueryString("MarchandID")
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
        dgShippedApprovalSheet.DataSource = objDataView
        dgShippedApprovalSheet.DataBind()
        UpdatePanel3.Update()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As New DataView
            Dim objDataTable As DataTable
            objDataTable = ObjShippedApproval.GetDataForShippedApproval(MarchandID)
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgShippedApprovalSheet_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgShippedApprovalSheet.NeedDataSource
        Dim objDataTable As DataTable
        objDataTable = ObjShippedApproval.GetDataForShippedApproval(MarchandID)
        dgShippedApprovalSheet.DataSource = objDataTable
    End Sub
    Protected Sub dgShippedApprovalSheet_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgShippedApprovalSheet.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgShippedApprovalSheet_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgShippedApprovalSheet.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgShippedApprovalSheet_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgShippedApprovalSheet.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgShippedApprovalSheet_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgShippedApprovalSheet.ItemCommand
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            Select Case e.CommandName
                Case Is = "Approved"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOID As String = item("POID").Text
                    Dim lMerchantID As String = item("MarchandID").Text
                    Dim StyleNo As String = item("StyleNo").Text
                    With ObjShippedApproval
                        .ShippedApprovalID = 0
                        .CreationDate = Date.Now
                        .POID = lPOID
                        .MerchantID = lMerchantID
                        .Status = "okay to ship"
                        .SaveShippedApproval()
                    End With
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Shipped Approved Successfully.")
                              
            End Select
        Catch ex As Exception

        End Try
    End Sub

End Class
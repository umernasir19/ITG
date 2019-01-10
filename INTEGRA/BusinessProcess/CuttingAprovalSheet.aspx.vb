Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class CuttingAprovalSheet
    Inherits System.Web.UI.Page
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjCuttingApproval As New CuttingApproval
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        dgCuttingAprovalSheet.DataSource = objDataView
        dgCuttingAprovalSheet.DataBind()
        UpdatePanel3.Update()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As New DataView
            Dim objDataTable As DataTable
            objDataTable = ObjPurchaseOrder.GetDataForCuttingApproval()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgCuttingAprovalSheet_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgCuttingAprovalSheet.NeedDataSource
        Dim objDataTable As DataTable
        objDataTable = ObjPurchaseOrder.GetDataForCuttingApproval()
        dgCuttingAprovalSheet.DataSource = objDataTable
    End Sub
    Protected Sub dgCuttingAprovalSheet_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgCuttingAprovalSheet.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgCuttingAprovalSheet_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgCuttingAprovalSheet.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgCuttingAprovalSheet_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgCuttingAprovalSheet.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgCuttingAprovalSheet_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgCuttingAprovalSheet.ItemCommand
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            Select Case e.CommandName
                Case Is = "Approved"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOID As String = item("POID").Text
                    Dim lMerchantID As String = item("MarchandID").Text
                    Dim StyleNo As String = item("StyleNo").Text
                    'Now chking the PP Sample is completed
                    Dim dtPPsample As DataTable = ObjCuttingApproval.GetPPSample(lPOID)
                        If dtPPsample.Rows.Count > 0 Then
                            'Now chking the CD Chart is completed
                        Dim dtCDChart As DataTable = ObjCuttingApproval.GetCDChart(lPOID)
                            If dtCDChart.Rows.Count > 0 Then
                                With ObjCuttingApproval
                                    .CuttingApprovalID = 0
                                    .CreationDate = Date.Now
                                    .POID = lPOID
                                    .MerchantID = lMerchantID
                                    .Status = "Approved"
                                    .SaveCuttingApproval()
                                End With
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Cutting Approved Successfully.")
                                Dim objDataview As DataView
                                objDataview = LoadData()
                                Session("objDataView") = objDataview
                                BindGrid()
                            Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PP and/or CD Chart not approved, Please complete this process, then give approval")
                            End If
                        Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PP and/or CD Chart not approved, Please complete this process, then give approval")
                        End If
                    
            End Select
        Catch ex As Exception

        End Try
    End Sub
    
End Class
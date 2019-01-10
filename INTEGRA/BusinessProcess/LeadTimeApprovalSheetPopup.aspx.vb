Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class LeadTimeApprovalSheetPopup
    Inherits System.Web.UI.Page
    Dim objLeadTimeApproval As New LeadTimeApproved
    Dim IMerchandid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMerchandid = Request.QueryString("Merchandid")
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                lblMsg.Text = ""
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
        UpdatePanel3.Update()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As New DataView
            Dim objDataTable, objDataTable1 As DataTable
            objDataTable = objLeadTimeApproval.GetLeadTimeApprovalForNewOrder(IMerchandid)
            objDataTable1 = objLeadTimeApproval.GetLeadTimeApprovalForRepeatOrder(IMerchandid)
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
        objDataTable = objLeadTimeApproval.GetLeadTimeApprovalForNewOrder(IMerchandid)
        objDataTable1 = objLeadTimeApproval.GetLeadTimeApprovalForRepeatOrder(IMerchandid)
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
    Protected Sub dgLeadTimeApprovalSheet_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgLeadTimeApprovalSheet.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Approved"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lPOID As String = item("POID").Text
                    Dim lMerchantID As String = item("MarchandID").Text

                    With objLeadTimeApproval
                        .LeadTimeApprovalID = 0
                        .CreationDate = Date.Now
                        .POID = lPOID
                        .MerchantID = lMerchantID
                        .Status = "Approved"
                        .SaveLeadTimeApproval()
                    End With
            End Select
            lblMsg.Text = "Lead Time Approved Successfully."
            Dim objDataview As DataView
            objDataview = LoadData()
            Session("objDataView") = objDataview
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class
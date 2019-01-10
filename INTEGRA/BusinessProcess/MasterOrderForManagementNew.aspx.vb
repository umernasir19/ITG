Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class MasterOrderForManagementNew
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Public MarchandID, RoleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MarchandID = Session("UserId")
        Response.Expires = 0
        RoleID = Session("RoleId")
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
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgMasterOrderForDataFeeder.DataSource = objDataView
            dgMasterOrderForDataFeeder.DataBind()
            'Dim x As Integer
            ''Dim dgView As RadGrid = DirectCast(dgView.FindControl("dgView"), RadGrid)
            'For x = 0 To dgMasterOrderForDataFeeder.Items.Count - 1

            '    Dim item As GridDataItem = DirectCast(dgMasterOrderForDataFeeder.MasterTableView.Items(x), GridDataItem)
            '    Dim lnkTnaEditt As HyperLink = DirectCast(item.FindControl("lnkTnaEditt"), HyperLink)
            '    Dim poid As Long = item("POID").Text
            '    Dim Commission As Decimal = item("Commission2").Text
            '    Dim txtCommission As RadNumericTextBox = CType(item.FindControl("txtCommission"), RadNumericTextBox)
            '    txtCommission.Text = Commission
            '    Dim dtcheck As DataTable = objPo.Check(poid)
            '    If dtcheck.Rows.Count > 0 Then
            '        lnkTnaEditt.Enabled = True
            '    Else
            '        lnkTnaEditt.Enabled = False
            '    End If

            'Next
        Catch ex As Exception

        End Try

    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            'objDataTable = objPo.GetMasterOrderForDataFeeder()

            objDataTable = objPo.GetMasterOrderForDataFeederBYManagement

            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgMasterOrderForDataFeeder_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForDataFeeder.NeedDataSource
        dgMasterOrderForDataFeeder.DataSource = objPo.GetMasterOrderForDataFeeder()
    End Sub
    Protected Sub dgMasterOrderForDataFeeder_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMasterOrderForDataFeeder.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If

    End Sub
    Protected Sub btnAddOrder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddOrder.Click
        Try
            ' Response.Redirect("PurchaseOrderAdd.aspx")
            Dim x As Integer
            Dim chkSelect As CheckBox
            Dim objDataview As DataView
            Dim POid As Long
            For x = 0 To dgMasterOrderForDataFeeder.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgMasterOrderForDataFeeder.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(dgMasterOrderForDataFeeder.Items(x).FindControl("chkSelect"), CheckBox)

                Dim txtCommission As RadNumericTextBox = CType(item.FindControl("txtCommission"), RadNumericTextBox)
                '   txtCommission = CType(dgMasterOrderForDataFeeder.Items(x).FindControl("txtCommission"), RadNumericTextBox)
                POid = item("POID").Text
                If chkSelect.Checked = True Then
                    objPo.UpdatePOCommssion(POid, txtCommission.Text)
                End If
            Next
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Successfully")
            objDataview = LoadData()
            Session("objDataView") = objDataview
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForDataFeeder_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForDataFeeder.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForDataFeeder_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForDataFeeder.SortCommand
        BindGrid()
    End Sub
End Class
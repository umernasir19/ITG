Imports System.Data
Imports Telerik.Web.UI
Imports Integra.EuroCentra
Public Class CustomerProfileView
    Inherits System.Web.UI.Page
    Dim objCustomer As New Customer
    Dim userRole As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        userRole = Session("RoleId")
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
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        RadGrid1.DataSource = objDataView
        RadGrid1.DataBind()
        If userRole = 32 Then
            RadGrid1.MasterTableView.GetColumn("Commission").Display = True
        Else
            RadGrid1.MasterTableView.GetColumn("Commission").Display = False
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCustomer.GetCustomerView
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
   
    Protected Sub btnAddCustomer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddCustomer.Click
        HttpContext.Current.Response.Redirect("~/Generalsetup/CustomerProfile.aspx")
    End Sub
    Protected Sub RadGrid1_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = objCustomer.GetCustomerView()
    End Sub
    Protected Sub RadGrid1_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
            Dim combo As RadComboBox = DirectCast(filterItem("CustomerName").FindControl("cmbCustomerName"), RadComboBox)
            Dim item1 As New RadComboBoxItem()
            combo.DataSource = objCustomer.GetCustomerView()
            combo.DataTextField = "CustomerName"
            combo.DataValueField = "CustomerName"
            combo.DataBind()
        End If
    End Sub
    
    Protected Sub RadGrid1_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub RadGrid1_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        BindGrid()
    End Sub
End Class


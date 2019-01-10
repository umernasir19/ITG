Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class GIACodingSupplierView
    Inherits System.Web.UI.Page
    Dim objGIACodingSupplier As New GIACodingSupplier


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData("ALL", "ALL")
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Supplier GIA Number Control Panel")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgLKZ.Visible = True
                dgLKZ.DataSource = objDataView
                dgLKZ.DataBind()
            Else
                dgLKZ.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal Vender, ByVal Buyer) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objGIACodingSupplier.CheckALlLKZ(Vender, Buyer)
        objDataView = New DataView(objDataTable)

        Return objDataView
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("GIACodingSupplierEntry.aspx")
    End Sub

    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub

    Protected Sub dgLKZ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLKZ.ItemCommand
        Dim objDataView As DataView
        Try
            Select Case e.CommandName

                Case "Remove"
                    Dim supplierid As Long = dgLKZ.Items(e.Item.ItemIndex).Cells(0).Text
                    objGIACodingSupplier.deletepodtl(supplierid)
                    objDataView = LoadData("ALL", "ALL")
                    Session("objDataView") = objDataView
                    BindGrid()



            End Select
        Catch ex As Exception

        End Try


    End Sub

End Class

Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ShippedExchangeView
    Inherits System.Web.UI.Page
    Dim ObjShipExchangeRate As New ShipExchangeRate
    Dim objDataView As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Shipped Exchange Rate View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try

            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgShipRate.Visible = True
                strSortExpression = dgShipRate.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgShipRate.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgShipRate.RecordCount = objDataView.Count
                dgShipRate.DataSource = objDataView
                dgShipRate.DataBind()
            Else
                dgShipRate.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjShipExchangeRate.GetAllRates()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgShipRate.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("ShippedExchange.aspx")
    End Sub

    Protected Sub dgShipRate_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgShipRate.ItemCommand
        Select Case e.CommandName


            Case "Edit"

                Dim RateID As Long = dgShipRate.Items(e.Item.ItemIndex).Cells(0).Text

                Response.Redirect("ShippedExchange.aspx?lRateID=" & RateID & "")

            Case "Remove"
                Dim RateID As Long = dgShipRate.Items(e.Item.ItemIndex).Cells(0).Text
                ObjShipExchangeRate.deletepodtl(RateID)
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()


        End Select
    End Sub
End Class
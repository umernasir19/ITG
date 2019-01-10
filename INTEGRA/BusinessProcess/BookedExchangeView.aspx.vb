Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class BookedExchangeView
    Inherits System.Web.UI.Page
    Dim ObjBookedExchangeRate As New BookedExchangeRate
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
        PageHeader("Booked Exchange Rate View")
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
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgBookedRate.Visible = True
                strSortExpression = dgBookedRate.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgBookedRate.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgBookedRate.RecordCount = objDataView.Count
                dgBookedRate.DataSource = objDataView
                dgBookedRate.DataBind()
            Else
                dgBookedRate.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjBookedExchangeRate.GetAllRates()
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
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgBookedRate.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("BookedExchange.aspx")
    End Sub







    Protected Sub dgBookedRate_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBookedRate.ItemCommand


        Select Case e.CommandName


            Case "Edit"

                Dim BookedExchangeRateID As Long = dgBookedRate.Items(e.Item.ItemIndex).Cells(0).Text

                Response.Redirect("BookedExchange.aspx?BookedExchangeRateID=" & BookedExchangeRateID & "")
        End Select
    End Sub
End Class
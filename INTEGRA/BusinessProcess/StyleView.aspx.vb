Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls.WebParts
Public Class StyleView
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim cmbVendor, cmbBuyer, cmbStyle As DropDownList
    Dim Vendor, Buyer, Style, TotalStyleQuantity As String
    Dim dr As DataRow
    Dim dt As DataTable
    Dim objStyleMaster As New StyleMaster

    Dim RoleID As String
    Dim Pattern As String
    Dim StyleID As Long
    Dim dtArticleDetail As DataTable
    Dim UserID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        UserID = CLng(Session("UserID"))
        RoleID = Session("RoleId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgStyle.Visible = True
                strSortExpression = dgStyle.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgStyle.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgStyle.RecordCount = objDataView.Count
                dgStyle.DataSource = objDataView
                dgStyle.DataBind()
            Else
                dgStyle.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objStyleMaster.GetALLStyleforviewSearchPattern22()
        If RoleID = 32 Then
            objDataTable = objStyleMaster.GetALLStyleforviewManRole
        Else
            objDataTable = objStyleMaster.GetALLStyleforviewUSER(UserID)
        End If

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
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub
   Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("StyleDatabaseEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtsearchStyle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtsearchStyle.TextChanged
        Try
            Dim objDataView As DataView
            If txtsearchStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            ElseIf txtsearchStyle.Text <> "" Then

                objDataView = LoadData(txtsearchStyle.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No. Not Exist")
                End If
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadData(ByVal SttyleNo As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleMaster.GetALLStyleNoForSearch(SttyleNo)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
End Class
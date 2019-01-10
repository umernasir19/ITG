Imports System.Data
Imports Integra.EuroCentra
Imports SmartControls.Controls
Public Class UserView
    Inherits System.Web.UI.Page
    Public nUserId As Integer
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Expires = 0
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("User View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            strSortExpression = dgUser.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgUser.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgUser.RecordCount = objDataView.Count
            dgUser.DataSource = objDataView
            dgUser.DataBind()
            For x = 0 To dgUser.Items.Count - 1
                Dim lnkDisable As LinkButton = CType(dgUser.Items(x).FindControl("lnkDisable"), LinkButton)
                Dim lnkEnable As LinkButton = CType(dgUser.Items(x).FindControl("lnkEnable"), LinkButton)
                If objDataView.Item(x)("IsActive") = True Then
                    lnkEnable.Visible = False
                    lnkDisable.Visible = True
                    lnkDisable.ToolTip = "by click this user will disabled"
                Else
                    lnkDisable.Visible = False
                    lnkEnable.Visible = True
                    lnkEnable.ToolTip = "by click this user will enabled"
                End If
            Next
        Else
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim ObjUser As New User
        objDataTable = ObjUser.getPicture111New()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub StatusChanged(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        Dim objUser As New User
        Dim nUserId As Short
        Dim bIsActive As Boolean
        Dim lnkButton As LinkButton = e.Item.FindControl("lnkStatus")
        If Not lnkButton Is Nothing Then
            bIsActive = Convert.ToBoolean(lnkButton.CommandName)
            nUserId = lnkButton.CommandArgument
            If bIsActive = True Then
                bIsActive = False
            Else
                bIsActive = True
            End If
            objUser.GetUserBy2Id(nUserId)
            objUser.IsActive = bIsActive
            objUser.SaveUser(nUserId)
            Response.Redirect("UserView.aspx")
        End If
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("UserAdd.aspx")
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
    End Sub
    Protected Sub dgUser_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgUser.ItemCommand
        Try
        Catch ex As Exception
        End Try
    End Sub
End Class


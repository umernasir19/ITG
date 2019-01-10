Imports System.Data
Imports Telerik.Web.UI
Imports System.IO
Imports Integra.EuroCentra
Public Class DeversaMaster
    Inherits System.Web.UI.MasterPage
    Dim objtree As New Tree
    Dim objUser As New EuroCentra.User
    Dim UserID As Long
    Protected mintTimeout As Integer
    Protected mstrLoginURL As String
    Dim objVender As New Vender
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim intRedirectTime As Integer = 2
        mintTimeout = (Session.Timeout - intRedirectTime) * 150000
        mstrLoginURL = ResolveUrl("~/login.aspx")
        'mstrLoginURL = ResolveUrl("~/SessionExpire.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("UserId") Is Nothing Then
                BindFormCombo(CLng(Session("RoleId")))
                UserID = CLng(Session("Userid"))
                populateMenuItem()
                GetUserInfo(UserID)
                If UserID = 83 Then
                    'Madni ID no news bultn
                ElseIf UserID = 78 Then
                    'Norbert ID no news bultn
                ElseIf Session("ECPDivistion") = "Supplier" Then
                    'Supplier login
                Else
                    '  HeaderMarquee()
                End If
            Else
                Response.Redirect("~/login.aspx")
            End If
        End If
    End Sub
    Sub GetForm(ByVal value As Long)
        Dim URL As String
        URL = objtree.GetFormThroughURL(value)
        If URL <> "" Then
            Response.Redirect("~/" + URL)
        Else
        End If
    End Sub
    Private Sub populateMenuItem()
        Dim dt As New DataTable()
        dt = objtree.GetMembersTree(CLng(Session("Userid")))
        ' Dim menuData As DataTable = GetMenuData()
        AddTopMenuItems(dt)
    End Sub
    Private Sub AddTopMenuItems(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            'Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), "/GeneralSetup/CustomerProfile.aspx?CustomerID=" & row("FormRoleID").ToString())
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTree(Session("UserId"), row("FormRoleID").ToString())
            'AddChildMenuItems(dt, newMenuItem)
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddChildMenuItem(ByVal menuData As DataTable, ByVal parentMenuItem As RadMenuItem)
        For Each rows In menuData.Rows
            Dim objMenuItems As New RadMenuItem(rows("TextToDisplay").ToString(), rows("link").ToString())
            parentMenuItem.Items.Add(objMenuItems)
        Next
    End Sub
    Private Sub GetChildMenuItems(ByVal value As String)
        Dim URL As String
        URL = objtree.GetFormThroughURL(value)
        If URL <> "" Then
            Response.Redirect("~/" + URL)
        Else
            ' Response.Redirect("~/mainpage.aspx?style=Home")
        End If
    End Sub
    Sub GetUserInfo(ByVal UserID)
        Dim dt As DataTable
        dt = objUser.GetUSerInfoNew(UserID)
        Dim dtCurrentInfo As DataTable = objUser.GetCurrentTime()
        lblMessage.Text = dtCurrentInfo.Rows(0)("Message") + ", "
        lblUser.Text = dt.Rows(0)("UserName")

    End Sub
    Protected Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
        GetChildMenuItems(e.Item.Value)

    End Sub
    Sub BindFormCombo(ByVal ID As Long)
        Dim Dt As DataTable
        Dt = objtree.GetFormByRole(ID)
        With cmbForm
            .DataSource = Dt
            .DataTextField = "texttoDisplay"
            .DataValueField = "FormRoleID"
            .DataBind()
            .Items.Insert(0, "Select Menu Item")
        End With
    End Sub
    Protected Sub cmbForm_SelectedIndexChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles cmbForm.SelectedIndexChanged
        GetForm(cmbForm.SelectedValue)
    End Sub
    Protected Sub Impak_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Impak.Click
        Session.Abandon()
        Response.Redirect("http://www.eurocentrab2b.com")
    End Sub
    Sub HeaderMarquee()
        Try
            Dim ObjPO As New PurchaseOrder
            Dim x As Integer
            lblPageHead.Text = ""
            UserID = CLng(Session("Userid"))
            Dim dtUser As DataTable = objUser.GetUSerInfoNew(UserID)
            Dim dt As New DataTable
            If dtUser.Rows(0)("ECPDivistion") = "Supplier" Then
                dt = ObjPO.POInfor(dtUser.Rows(0)("EmployeeId"), dtUser.Rows(0)("ECPDivistion"))
            ElseIf dtUser.Rows(0)("ECPDivistion") = "Customer" Then
                dt = ObjPO.POInfor(dtUser.Rows(0)("EmployeeId"), dtUser.Rows(0)("ECPDivistion"))
            ElseIf dtUser.Rows(0)("ECPDivistion") = "PD" Then
                dt = Nothing
            Else
                dt = ObjPO.POInfor(UserID, dtUser.Rows(0)("Designation"))
            End If

            Dim Message As String = ""
            For x = 0 To dt.Rows.Count - 1
                Message = Message + " " + dt.Rows(x)("Username").ToString() + " has " + dt.Rows(x)("TotalOrders").ToString() + " order(s) booked in " & Date.Now.Year.ToString() + "."
            Next
            lblPageHead.Text = Message
        Catch ex As Exception

        End Try
    End Sub
End Class
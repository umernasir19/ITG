Imports System.Data
Imports Telerik.Web.UI
Imports System.IO
Imports Integra.EuroCentra
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim objtree As New Tree
    Dim objUser As New EuroCentra.User
    Dim UserID, Roleid As Long
    Protected mintTimeout As Integer
    Protected mstrLoginURL As String
    Dim objVender As New Vender
    Dim ID As Long
    Dim Type As String
    Public Sub ShowMessgae(ByVal message As String)
        lblErrorMsg.Text = message
        lblErrorMsgUpdate.Update()
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim intRedirectTime As Integer = 2
        'mintTimeout = (Session.Timeout - intRedirectTime) * 150000
        mstrLoginURL = ResolveUrl("~/login.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("RoleId") = Nothing And Session("Type") = Nothing Then
            ID = Request.QueryString("ID")
            Type = Request.QueryString("Type")
            Session("RoleId") = ID
            Session("Type") = Type
        End If
        If Not Page.IsPostBack Then
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                BindFormCombo(Session("RoleId"))
                populateMenuItem()
                Roleid = ID
                If Roleid = 46 Then
                End If
                GetUserInfoForDirector()
                HeaderMarquee()
            ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                BindFormCombo(Session("RoleId"))
                populateMenuItem()
                Roleid = ID
                If Roleid = 46 Then
                End If
                HeaderMarquee()
                GetUserInfoForDirector()
            ElseIf Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                BindFormCombo(Session("RoleId"))
                populateMenuItem()
                Roleid = ID
                If Roleid = 46 Then
                End If
                HeaderMarquee()
                GetUserInfoForDirector()
            ElseIf Session("RoleId") = 46 And Session("Type") = "Production" Then
                BindFormCombo(Session("RoleId"))
                populateMenuItem()
                Roleid = ID
                If Roleid = 46 Then
                End If
                HeaderMarquee()
                GetUserInfoForDirector()
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                BindFormCombo(Session("RoleId"))
                populateMenuItem()
                Roleid = ID
                If Roleid = 46 Then
                End If
                HeaderMarquee()
                GetUserInfoForDirector()
            Else
                UserID = CLng(Session("Userid"))
                If UserID > 271 Then
                    BindFormCombo(CLng(Session("RoleId")))
                    UserID = CLng(Session("Userid"))
                    populateMenuItem()
                    GetUserInfo(UserID)
                    BindFormComboNew(Roleid)
                ElseIf Not Session("UserId") Is Nothing Then
                    BindFormCombo(CLng(Session("RoleId")))
                    UserID = CLng(Session("Userid"))
                    populateMenuItem()
                    GetUserInfo(UserID)
                    Roleid = Session("RoleId")
                    BindFormComboNew(Roleid)
                    If Roleid = 41 Then
                        lblseason.Text = "Session: " & Session("Session")
                    End If
                    If UserID = 83 Then
                    ElseIf UserID = 78 Then
                    ElseIf Session("ECPDivistion") = "Supplier" Then
                    Else
                        HeaderMarquee()
                    End If
                Else
                    Roleid = Session("RoleId")
                    If Roleid = 41 Then
                        Response.Redirect("~/Accountslogin.aspx")
                    Else
                        Response.Redirect("~/login.aspx")
                    End If
                End If
            End If
            Dim currentItem As RadMenuItem = RadMenu1.FindItemByUrl(Request.Url.PathAndQuery)
            If currentItem IsNot Nothing Then
                currentItem.HighlightPath()
            End If
        End If
    End Sub
    Sub BindFormComboNew(ByVal ID As Long)
        Dim Dt As DataTable
        Dt = objtree.GetFormByRoleNew(ID)
        With cmbForm
            .DataSource = Dt
            .DataTextField = "texttoDisplay"
            .DataValueField = "FormRoleID"
            .DataBind()
            .Items.Insert(0, "Select Menu Item")
        End With
    End Sub
    Sub GetFormNew(ByVal value As Long)
        Dim URL As String
        URL = objtree.GetFormThroughURLNew(value)
        If URL <> "" Then
            Response.Redirect("~/" + URL)
        Else
        End If
    End Sub
    Sub GetUserInfoForDirector()
        Dim dtCurrentInfo As DataTable = objUser.GetCurrentTime()
        lblMessage.Text = dtCurrentInfo.Rows(0)("Message") + ", "
        lblUser.Text = "Atif Sahab"
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
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt = objtree.GetMembersTreeNewForNewUsers(257)
            AddTopMenuItemsFormerchandising(dt)
        ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
            dt = objtree.GetMembersTreeNewForNewUsers(238)
            AddTopMenuItemsForGGT(dt)
        ElseIf Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
            dt = objtree.GetMembersTreeNewForNewUsers(252)
            AddTopMenuItemsForRND(dt)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Production" Then
            dt = objtree.GetMembersTreeNewForNewUsers(248)
            AddTopMenuItemsForProduction(dt)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = objtree.GetMembersTreeNewForNewUsers(241)
            AddTopMenuItemsForFabricStore(dt)
        ElseIf UserID = 271 Then
            dt = objtree.GetMembersTreeNew(271)
            AddTopMenuItemsForAdminPanel(dt)
        ElseIf UserID > 271 Then
            dt = objtree.GetMembersTreeNewForNewUsers(UserID)
            AddTopMenuItemsForNewUsers(dt)
        Else
            dt = objtree.GetMembersTreeNewForNewUsers(UserID)
            AddTopMenuItemsForNewUsers(dt)
        End If
    End Sub
    Private Sub AddTopMenuItemsForNewUsers(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(UserID, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsForAdminPanel(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNew(271, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsForFabricStore(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(241, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsForProduction(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(248, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsForRND(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(252, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsForGGT(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(238, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItemsFormerchandising(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTreeNewForNewUsers(257, row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddTopMenuItems(ByVal menuData As DataTable)
        Dim view As New DataView(menuData)
        view.RowFilter = "ParentFormRoleId is not null"
        For Each row As DataRowView In view
            Dim newMenuItem As New RadMenuItem(row("TextToDisplay").ToString(), objtree.GetFormThroughURL(row("FormRoleID").ToString()))
            RadMenu1.Items.Add(newMenuItem)
            Dim dt As New DataTable()
            dt = objtree.GetMembersTree(Session("UserId"), row("FormRoleID").ToString())
            AddChildMenuItem(dt, newMenuItem)
        Next
    End Sub
    Private Sub AddChildMenuItem(ByVal menuData As DataTable, ByVal parentMenuItem As RadMenuItem)
        For Each rows In menuData.Rows
            Dim objMenuItems As New RadMenuItem(rows("TextToDisplay").ToString(), rows("link").ToString())
            parentMenuItem.Items.Add(objMenuItems)
        Next
    End Sub
    Protected Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Response.Write("You clicked: " & e.Item.Text)
    End Sub
    Private Sub GetChildMenuItems(ByVal value As String)
        Dim URL As String
        URL = objtree.GetFormThroughURL(value)
        Session("FormRoleId") = value
        If URL <> "" Then
            Response.Redirect("~/" + URL)
        Else
        End If
    End Sub
    Sub GetUserInfo(ByVal UserID)
        Dim dt As DataTable
        dt = objUser.GetUSerInfoNew(UserID)
        Dim dtCurrentInfo As DataTable = objUser.GetCurrentTime()
        lblUser.Text = dt.Rows(0)("UserName")
    End Sub
    Protected Sub RadMenu1_MenuItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
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
        GetFormNew(cmbForm.SelectedValue)
    End Sub
    Protected Sub Impak_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Impak.Click
        Session.Abandon()
        Roleid = Session("RoleId")
        'If Roleid = 41 Then
        'Response.Redirect("~/Accountslogin.aspx")
        'Else
        Response.Redirect("~/login.aspx")
        'End If
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


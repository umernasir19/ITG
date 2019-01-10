Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class StyleAssortmentView
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSizeRange As New SizeRange
    Dim userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Style Assortment View")
    End Sub
    Sub GetRights()
         Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
             If View = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items(x).FindControl("lnkEditFab"), ImageButton)
                    lnkEditt.Enabled = True
                    lnkOk.Enabled = True
                    lnkAccChecklist.Enabled = True
                    lnkCopy.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items(x).FindControl("lnkEditFab"), ImageButton)
                    lnkEditt.Enabled = False
                    lnkOk.Enabled = False
                    lnkAccChecklist.Enabled = False
                    lnkCopy.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
            Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
            Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
            Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
            If StyleAssortmentMasterID = 0 Then
                lnkOk.Visible = False
                lnkEdit.Visible = True
                lnkRemove.Visible = False
            Else
                lnkOk.Visible = True
                lnkEdit.Visible = False
                lnkRemove.Visible = True
            End If
            Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
            If dtChk.Rows.Count > 0 Then
                lnkCreateFab.Visible = False
                lnkEditFab.Visible = True
            Else
                lnkCreateFab.Visible = True
                lnkEditFab.Visible = False
            End If
        Next
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.View
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "StyleAssortmanr"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Styles As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&Styles=" & Styles & "")
                Case "Edit"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "FABRICATION"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("FabricationEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "FABRICATIONEdit"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(JobOrderID, JoborderDetailid)
                    If dtChk.Rows.Count > 0 Then
                        Response.Redirect("FabricationEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&FabricationMasterID=" & dtChk.Rows(0)("FabricationMasterID") & "")
                    End If
                Case Is = "Remove"
                    Dim LStyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForCuttingForAssotmentView(LStyleAssortmentMasterID)
                    Dim dtt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForChecklistForAssotmentView(LStyleAssortmentMasterID)
                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        objStyleAssortmentMaster.DeleteStyleAssortmentMasterForAssortmentView(LStyleAssortmentMasterID)
                        objStyleAssortmentMaster.DeleteStyleAssortmentDetailForAssortmentView(LStyleAssortmentMasterID)
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                    BindGrid()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ViewForBrandStyleAssormentView(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.ViewForBuyerStyleAssormentView(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.ViewForStyleStyleAssormentView(txtSearch.Text)
            Dim dt4 As DataTable = objStyleAssortmentMaster.ViewForSrNoStyleAssormentView(txtSearch.Text)
            Dim dt5 As DataTable = objStyleAssortmentMaster.ViewForSeasonStyleAssormentView(txtSearch.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            ElseIf dt5.Rows.Count > 0 Then
                dgView.DataSource = dt5
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            Else
                Dim dt6 As DataTable = objStyleAssortmentMaster.View
                dgView.DataSource = dt6
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                Next
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class


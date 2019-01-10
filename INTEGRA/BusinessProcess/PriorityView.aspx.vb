Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Telerik.Web.UI.GridDataItem
Public Class PriorityView
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objTblDPRND As New TblDPRND
    Dim dt As DataTable
    Dim objDPPOMst As New DPPOMst
    Dim Userid As Long
    Dim objDataView As DataView
    Dim TotalDone As Decimal = 0
    Dim TotalNotDone As Decimal = 0
    Dim objPatternDepartTaskListMst As New PatternDepartTaskListMstNew
    Dim Total As Decimal = 0
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = Session("UserId")
        If Not Page.IsPostBack Then
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
            If DtCheck.Rows(0)("Department") = "G.G.T" Then
                btnSave.Visible = False
            ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                btnSave.Visible = False
            Else
                btnSave.Visible = True
            End If
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            GetRights()
        End If
    End Sub
    Sub GetRights()
         Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(Userid, Path4)
        'If PathArr.Length > 2 Then
        '    Dim Path2 As String = PathArr(1)
        '    Dim Path3 As String = PathArr(2)
        '    Dim Path4 As String = Path2 + "/" + Path3
        '    dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        'ElseIf PathArr.Length > 3 Then
        '    Dim Path1 As String = PathArr(1)
        '    Dim Path2 As String = PathArr(2)
        '    Dim Path3 As String = PathArr(3)
        '    Dim Path4 As String = Path2 + "/" + Path3
        '    dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        'End If
        ' Dim Path2 As String = Path.Substring(1, Path.Length - 1)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
            If View = 1 Then
                dgRND.MasterTableView.GetColumn("Priority").Display = True
            Else
                dgRND.MasterTableView.GetColumn("Priority").Display = False
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            UpdateData()
        Catch ex As Exception
        End Try
    End Sub
    Sub UpdateData()
        Dim x As Integer
        For x = 0 To dgRND.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
            Dim txtPriority As TextBox = CType(dgRND.Items(x).FindControl("txtPriority"), TextBox)
            Dim Idd As Long = item("PATTERNDEPARTMENTTASKLISTMstid").Text
            objPatternDepartTaskListMst.UpdatePriority(Idd, txtPriority.Text)
        Next
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgRND.DataSource = objDataView
            dgRND.DataBind()
            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim txtPriority As TextBox = CType(dgRND.Items(x).FindControl("txtPriority"), TextBox)
                txtPriority.Text = dt.Rows(x)("Priority")
                Dim Status As String = item("Status").Text
                Dim ConStatus As String = item("ConStatus").Text
                If ConStatus = True Then
                    item("ConStatus").ForeColor = Drawing.Color.Green
                    item("ConStatus").Text = True
                    Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red
                End If
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "G.G.T" Then
                    txtPriority.ReadOnly = True
                ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                    txtPriority.ReadOnly = True
                Else
                    txtPriority.ReadOnly = False
                End If
            Next
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objTblDPRND.GetBindGridForTaskListGGTViewNewPriority()
        dt = objTblDPRND.GetBindGridForTaskListGGTViewNewPriority()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgRND_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgRND.NeedDataSource
        objDataView = LoadData()
        Session("objDataView") = objDataView
        BindGrid()
        GetRights()
    End Sub
    Protected Sub dgRND_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgRND.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgRND_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgRND.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Protected Sub dgRND_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgRND.SortCommand
        BindGrid()
        GetRights()
    End Sub
End Class
Imports System.Data
Imports System.Xml
Imports Integra.EuroCentra
Public Class SeasonView
    Inherits System.Web.UI.Page
    Dim objSeason As New Season
    Dim objDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSizeRange As New SizeRange
    Dim userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
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
        PageHeader("Season")
    End Sub
    Sub GetRights()
          Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
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
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    Dim lnkEditt As HyperLink = CType(dgPurchaseOrder.Items(x).FindControl("lnkEdit"), HyperLink)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    Dim lnkEditt As HyperLink = CType(dgPurchaseOrder.Items(x).FindControl("lnkEdit"), HyperLink)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgPurchaseOrder.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgPurchaseOrder.Items(x).FindControl("lnkRemove"), ImageButton)
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
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.Visible = True
                strSortExpression = dgPurchaseOrder.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgPurchaseOrder.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgPurchaseOrder.RecordCount = objDataView.Count
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()
                GetRights()
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection

        Dim objDataTable As DataTable
        objDataTable = objSeason.GetAllNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '  BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ' BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("SeasonEntry.aspx")
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim SeasonID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                objSeason.deletepodtl(SeasonID)
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
        End Select
    End Sub

End Class
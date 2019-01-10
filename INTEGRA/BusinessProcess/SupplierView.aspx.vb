Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class SupplierView
    Inherits System.Web.UI.Page
    Public bIsShowException As Boolean
    Public strTabId As String
    Public strActionType As String
    Dim ObjSupplier As New SupplierDataBase
    Dim userid As Long
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim userRole As Long
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        userid = Session("UserId")
        userRole = Session("RoleId")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                mainpnl.Visible = False
                objDataView = LoadData()
        Session("objDataView") = objDataView
        BindGrid()
        GetRights()
            Catch objUDException As UDException
            bIsShowException = True
        End Try
            PageHeader("SUPPLIER INDEX")
        End If
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
            If Add = 1 Then
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgSupplierDataBase.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSupplierDataBase.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgSupplierDataBase.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgSupplierDataBase.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgSupplierDataBase.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgSupplierDataBase.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgSupplierDataBase.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgSupplierDataBase.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ViewForSupplierName(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.ViewForSupplierCode(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.ViewForSupplierCategory(txtSearch.Text)
            If dt1.Rows.Count > 0 Then
                dgSupplierDataBase.DataSource = dt1
                dgSupplierDataBase.DataBind()
                Dim gridItem As DataGridItem
                Dim iPos As Long = 1
                For Each gridItem In dgSupplierDataBase.Items
                    With gridItem
                        Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                        lblSrNo.Text = iPos
                        iPos += 1
                    End With
                Next
            ElseIf dt2.Rows.Count > 0 Then
                dgSupplierDataBase.DataSource = dt2
                dgSupplierDataBase.DataBind()
                Dim gridItem As DataGridItem
                Dim iPos As Long = 1
                For Each gridItem In dgSupplierDataBase.Items
                    With gridItem
                        Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                        lblSrNo.Text = iPos
                        iPos += 1
                    End With
                Next
            ElseIf dt3.Rows.Count > 0 Then
                dgSupplierDataBase.DataSource = dt3
                dgSupplierDataBase.DataBind()
                Dim gridItem As DataGridItem
                Dim iPos As Long = 1
                For Each gridItem In dgSupplierDataBase.Items
                    With gridItem
                        Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                        lblSrNo.Text = iPos
                        iPos += 1
                    End With
                Next
          Else
                Dim dt6 As DataTable = ObjSupplier.GetSupplierDatabaseDetailsForRND()
                dgSupplierDataBase.DataSource = dt6
                dgSupplierDataBase.DataBind()
                Dim gridItem As DataGridItem
                Dim iPos As Long = 1
                For Each gridItem In dgSupplierDataBase.Items
                    With gridItem
                        Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                        lblSrNo.Text = iPos
                        iPos += 1
                    End With
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgSupplierDataBase.RecordCount = objDataView.Count
            dgSupplierDataBase.DataSource = objDataView
            dgSupplierDataBase.DataBind()
            Dim gridItem As DataGridItem
            Dim iPos As Long = 1
            For Each gridItem In dgSupplierDataBase.Items
                With gridItem
                    Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                    lblSrNo.Text = iPos
                    iPos += 1
                End With
            Next
        Else
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjSupplier.GetSupplierDatabaseDetailsnewNewNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub StatusChanged(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
    End Sub
    Protected Sub dgSupplierDataBase_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSupplierDataBase.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Edit"
                    Dim SupplierDataBaseId As Long = dgSupplierDataBase.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("SupplierEntry.aspx?lSupplierDataBaseId=" & SupplierDataBaseId & "")
                Case Is = "Remove"
                    Dim SupplierDataBaseId As Long = dgSupplierDataBase.Items(e.Item.ItemIndex).Cells(0).Text
                    ObjSupplier.DeleteSupplierDatBase(SupplierDataBaseId)
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = ObjSupplier.GetSupplierDatabaseDetails()
                    objDataView = New DataView(objDataTable)
                    Session("objDataView") = objDataView
                    BindGrid()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            Response.Redirect("SupplierEntry.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData(ByVal SupplierName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjSupplier.GetSupplierDataBaseAllInfo(SupplierName)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
End Class
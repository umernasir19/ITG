Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class StylepopupNew
    Inherits System.Web.UI.Page
    Dim dr As System.Data.DataRow
    Dim lId As Integer
    Dim PONo As Long
    Dim objStyleMaster As New StyleMaster
    Dim dtSessionStyle As DataTable
    Dim UserID As Long
    Dim RoleID As Long
    Dim dt As New System.Data.DataTable
    Dim LastStyleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cmdSelect.Visible = False
        End If
    End Sub
    Protected Sub btnAddPurchaseorder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim objDataView As DataView
        Try
            'objDataView = LoadDataA("Seach", txtStyleNo.Text, txtArticle.Text)
            objDataView = LoadDataA("Seach", txtStyleNo.Text)
            Session("objDataView") = objDataView
            BindGrid()

        Catch objUDException As UDException
        End Try
    End Sub
    Function LoadDataA(ByVal Type As String, ByVal StyleNo As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Type = "Seach" Then
            objDataTable = objStyleMaster.GetStyleByStyleNosNew(StyleNo, UserID, RoleID)

        Else
            objDataTable = objStyleMaster.GetStyleByPO(UserID, RoleID, StyleNo)
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'Function LoadDataA(ByVal Type As String, ByVal StyleNo As String, ByVal Article As String) As ICollection
    '    Dim objDataView As DataView
    '    Dim objDataTable As DataTable
    '    If Type = "Seach" Then
    '        objDataTable = objStyleMaster.GetStyleByStyleNos(StyleNo, Article, UserID, RoleID)

    '    Else
    '        objDataTable = objStyleMaster.GetStyleByPO(UserID, RoleID, StyleNo)
    '    End If
    '    objDataView = New DataView(objDataTable)
    '    Return objDataView
    'End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgSelecttion.Visible = True
            dgSelecttion.DataSource = objDataView
            dgSelecttion.DataBind()

            cmdSelect.Visible = True
        Else
            dgSelecttion.Visible = False
        End If

        TryCast(dgSelecttion.MasterTableView.GetColumn("PurchaseOrderDetailID"), GridBoundColumn).Display = False
        TryCast(dgSelecttion.MasterTableView.GetColumn("StyleDetailID"), GridBoundColumn).Display = False
     
    End Sub
    Protected Sub UpdateCertificate(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Function ChekIDExist(ByVal ID As Long) As Boolean
        Return False
    End Function
    Protected Sub cmdSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelect.Click
        Try
            Dim x As Integer
            Dim ID As Label
            Dim chkSelect As CheckBox
            Dim dt As System.Data.DataTable
            Dim bShouldAdd As Boolean = True
            Dim isEmployeeExist As Boolean = False
            If (Not CType(Session("dtSelection"), DataTable) Is Nothing) Then
                dt = Session("dtSelection")
            Else
                dt = New DataTable
                With dt
                    .Columns.Add("ID", GetType(Long))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("Name", GetType(String))
                    .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("StyleDescription", GetType(String))
                    .Columns.Add("ColorRefNo", GetType(String))
                    .Columns.Add("Colorway", GetType(String))
                    .Columns.Add("SizeRange", GetType(String))
                    .Columns.Add("Size", GetType(String))
                    .Columns.Add("ItemPrice", GetType(String))
                    .Columns.Add("StyleDetailID", GetType(Long))
                End With
            End If
            For x = 0 To dgSelecttion.Items.Count - 1
                chkSelect = CType(dgSelecttion.Items(x).FindControl("chkSelected"), CheckBox)
                ID = CType(dgSelecttion.Items(x).FindControl("lblID"), Label)
                If chkSelect.Checked = True Then
                    ' If ChekIDExist(ID.Text) = False Then
                    Dim item As GridDataItem = DirectCast(dgSelecttion.MasterTableView.Items(x), GridDataItem)
                    dr = dt.NewRow()
                    dr("ID") = ID.Text
                    dr("Type") = "Style"
                    dr("PurchaseOrderDetailID") = item("PurchaseOrderDetailID").Text
                    dr("Name") = item("StyleNo").Text
                    dr("StyleNo") = item("StyleNo").Text
                    dr("StyleDescription") = item("StyleDescription").Text
                    dr("ColorRefNo") = item("ColorRefNo").Text
                    dr("Colorway") = item("Colorway").Text
                    dr("Size") = item("Sizes").Text
                    dr("SizeRange") = item("SizeRange").Text
                    dr("ItemPrice") = item("Price").Text
                    dr("StyleDetailID") = item("StyleDetailID").Text
                    dt.Rows.Add(dr)
                    ' End If
                Else
                    Try

                    Catch ex As Exception
                    End Try
                End If
            Next
            Session("dtSelection") = dt
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        Try
            Dim chkSelect As CheckBox
            Dim a As Integer = 0
            For a = 0 To dgSelecttion.Items.Count - 1
                chkSelect = CType(dgSelecttion.Items(a).FindControl("chkSelected"), CheckBox)
                chkSelect.Checked = True
            Next

            Dim x As Integer
            Dim ID As Label

            Dim dt As System.Data.DataTable
            Dim bShouldAdd As Boolean = True
            Dim isEmployeeExist As Boolean = False
            If (Not CType(Session("dtSelection"), DataTable) Is Nothing) Then
                dt = Session("dtSelection")
            Else
                dt = New DataTable
                With dt
                    .Columns.Add("ID", GetType(Long))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("Name", GetType(String))
                    .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("StyleDescription", GetType(String))
                    .Columns.Add("ColorRefNo", GetType(String))
                    .Columns.Add("Colorway", GetType(String))
                    .Columns.Add("SizeRange", GetType(String))
                    .Columns.Add("Size", GetType(String))
                    .Columns.Add("ItemPrice", GetType(String))
                    .Columns.Add("StyleDetailID", GetType(Long))
                End With
            End If
            For x = 0 To dgSelecttion.Items.Count - 1
                chkSelect = CType(dgSelecttion.Items(x).FindControl("chkSelected"), CheckBox)
                ID = CType(dgSelecttion.Items(x).FindControl("lblID"), Label)
                If chkSelect.Checked = True Then
                    ' If ChekIDExist(ID.Text) = False Then
                    Dim item As GridDataItem = DirectCast(dgSelecttion.MasterTableView.Items(x), GridDataItem)
                    dr = dt.NewRow()
                    dr("ID") = ID.Text
                    dr("Type") = "Style"
                    dr("PurchaseOrderDetailID") = item("PurchaseOrderDetailID").Text
                    dr("Name") = item("StyleNo").Text
                    dr("StyleNo") = item("StyleNo").Text
                    dr("StyleDescription") = item("StyleDescription").Text
                    dr("ColorRefNo") = item("ColorRefNo").Text
                    dr("Colorway") = item("Colorway").Text
                    dr("Size") = item("Sizes").Text
                    dr("SizeRange") = item("SizeRange").Text
                    dr("ItemPrice") = item("Price").Text
                    dr("StyleDetailID") = item("StyleDetailID").Text
                    dt.Rows.Add(dr)
                    ' End If
                Else
                    Try

                    Catch ex As Exception
                    End Try
                End If
            Next
            Session("dtSelection") = dt
        Catch ex As Exception

        End Try
    End Sub
End Class
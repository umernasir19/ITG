Imports System.Data
Imports Integra.EuroCentra
Public Class AccountsTree
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New AcntChartOfAccount
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateRootLevel()
        Else
        End If
    End Sub
    Private Sub PopulateRootLevel()
        Dim dt As New DataTable()
        dt = objChartOfAccount.GetMembersTree
        PopulateNodes(dt, Tree.Nodes)
        Tree.CollapseAll()
    End Sub
    Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)
        For Each dr As DataRow In dt.Rows
            Dim tn As New TreeNode()
            tn.Text = dr("AccountName").ToString()
            tn.Value = dr("AccountCode").ToString()
            nodes.Add(tn)
            ' tn.PopulateOnDemand = False

            'If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
            'tn.PopulateOnDemand = True
            ' nodes.Add(tn)
            tn.ToolTip = "Click to get Child"
        Next
    End Sub
    Protected Sub Tree_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles Tree.TreeNodePopulate
        PopulateSubLevel(e.Node.Value, e.Node)
    End Sub
    Private Sub PopulateSubLevel(ByVal parentid As String, ByVal parentNode As TreeNode)
        Dim dt As New DataTable()
        dt = objChartOfAccount.GetMembersTree(parentid)
        PopulateNodes(dt, parentNode.ChildNodes)
    End Sub

    Protected Sub btnManage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnManage.Click
        Try
            Tree.CollapseAll()
            'Tree.ExpandAll()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExpand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpand.Click
        Try

            ' PopulateSubLevel(5, 1)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            Response.Redirect("AccountInfo.aspx")

        Catch ex As Exception

        End Try
    End Sub
   
End Class

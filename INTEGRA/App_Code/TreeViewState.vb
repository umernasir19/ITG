Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class TreeViewState
    Public Sub SaveTreeView(ByVal treeView As TreeView, ByVal key As String)
        Dim list As New List(Of Nullable(Of Boolean))
        SaveTreeViewExpandedState(treeView.Nodes, list)
        HttpContext.Current.Session(key + treeView.ID) = list
    End Sub

    Private Sub SaveTreeViewExpandedState(ByVal nodes As TreeNodeCollection, ByVal list As List(Of Nullable(Of Boolean)))
        For Each node As TreeNode In nodes
            list.Add(node.Expanded)
            If node.ChildNodes.Count > 0 Then
                SaveTreeViewExpandedState(node.ChildNodes, list)

            End If

        Next
    End Sub

    Private RestoreTreeViewIndex As Integer

    Public Sub RestoreTreeView(ByVal treeView As TreeView, ByVal key As String)
        Dim list As New List(Of Nullable(Of Boolean))
        If HttpContext.Current.Session(key + treeView.ID) IsNot Nothing Then
            list = CType(HttpContext.Current.Session(key + treeView.ID), List(Of Nullable(Of Boolean)))
        End If

        RestoreTreeViewIndex = 0
        RestoreTreeViewExpandedState(treeView.Nodes, list)
    End Sub

    Private Sub RestoreTreeViewExpandedState(ByVal nodes As TreeNodeCollection, ByVal list As List(Of Nullable(Of Boolean)))
        For Each node As TreeNode In nodes
            If RestoreTreeViewIndex >= list.Count Then Exit Sub

            node.Expanded = list(RestoreTreeViewIndex)
            RestoreTreeViewIndex += 1

            If node.ChildNodes.Count > 0 Then
                RestoreTreeViewExpandedState(node.ChildNodes, list)
            End If
        Next
    End Sub



End Class

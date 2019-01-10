Imports Microsoft.VisualBasic


Public Class Tempcol
    Implements ITemplate
    Dim templateType As ListItemType
    Dim columnName As String
    Sub New(ByVal type As ListItemType, ByVal ColName As String)
        templateType = type
        columnName = ColName
    End Sub
    Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        Dim lc As New Literal
        Select Case templateType
            Case ListItemType.Header
                lc.Text = "<B>" & columnName & "</B>"
                container.Controls.Add(lc)
            Case ListItemType.Item
                lc.Text = columnName
                'AddHandler lc.DataBinding, AddressOf DataGridTemplate_DataBinding()
                container.Controls.Add(lc)
            Case ListItemType.EditItem
                Dim tb As New TextBox
                tb.Text = ""
                tb.ID = columnName
                tb.Width = 50
                container.Controls.Add(tb)
            Case ListItemType.Footer
                lc.Text = "<I>Footer</I>"
                container.Controls.Add(lc)
        End Select
    End Sub
    Sub DataGridTemplate_DataBinding(ByVal sender As Object, ByVal ByVale As System.EventArgs)
        Dim container As DataGridItem
        Dim lc As Literal
        lc = CType(sender, Literal)
        container = CType(lc.NamingContainer, DataGridItem)
        If Not IsDBNull(DataBinder.Eval(container.DataItem, lc.Text)) Then
            lc.Text = DataBinder.Eval(container.DataItem, lc.Text)
        End If
    End Sub

End Class

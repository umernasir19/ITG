Imports System.Data
Imports Integra.EuroCentra
Public Class VAFPanelView
    Inherits System.Web.UI.Page
    Dim objVAF_BasicInformation As New VAF_BasicInformation
    Dim objVender As New Vender
    Dim SupplierID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()


               
            Catch ex As Exception

            End Try
        End If

        PageHeader("Vendor Assessment From")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgView.Visible = True
                strSortExpression = dgView.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgView.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgView.RecordCount = objDataView.Count
                dgView.DataSource = objDataView
                dgView.DataBind()
            Else
                dgView.Visible = False
            End If

            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                If objDataView.Table.Rows(x)("SupplierStatus") = "No Decision" Then
                    dgView.Items(x).Cells(1).BackColor = Drawing.Color.Yellow
                ElseIf objDataView.Table.Rows(x)("SupplierStatus") = "Active" Then
                    dgView.Items(x).Cells(1).BackColor = Drawing.Color.Green
                ElseIf objDataView.Table.Rows(x)("SupplierStatus") = "Deactive" Then
                    dgView.Items(x).Cells(1).BackColor = Drawing.Color.Red
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objVAF_BasicInformation.ViewEntered()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub
   Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "ViewVAF"
                    Dim VAFID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("VAFPanel.aspx?VAFID=" & Vender.EncryptData(VAFID) & "&SupplierID=" & Vender.EncryptData(0) & "&bit=0")
                Case "Approval"
                    Dim VAFID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("VAFapproval.aspx?VAFID=" & Vender.EncryptData(VAFID) & "")
                Case "Print"
                    Dim VAFID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Write("<script> window.open('VAFPenalPrint.aspx?VAFID=" & objVender.EncryptData(VAFID) & "&SupplierID=" & objVender.EncryptData(0) & "&bit=1', 'newwindow', 'left=50, top=30, height=620, width=800, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

            End Select
        Catch ex As Exception
        End Try

    End Sub

End Class
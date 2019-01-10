Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class DebitNoteView
    Inherits System.Web.UI.Page
    Dim objDebitNote As New DebitNote
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()

        End If
        PageHeader("Debit Note View")
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

                Dim x As Integer
                Dim DNMonth As Label
                For x = 0 To dgPurchaseOrder.RecordCount - 1
                    DNMonth = CType(dgPurchaseOrder.Items(x).FindControl("DNMonth"), Label)
                    If objDataView.Table.Rows(x)("CommissionMonth") = 1 Then
                        DNMonth.Text = "Jan " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 2 Then
                        DNMonth.Text = "Feb " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 3 Then
                        DNMonth.Text = "Mar " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 4 Then
                        DNMonth.Text = "Apr " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 5 Then
                        DNMonth.Text = "May " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 6 Then
                        DNMonth.Text = "Jun " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 7 Then
                        DNMonth.Text = "Jul " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 8 Then
                        DNMonth.Text = "Aug " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 9 Then
                        DNMonth.Text = "Sep " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 10 Then
                        DNMonth.Text = "Oct " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 11 Then
                        DNMonth.Text = "Nov " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    ElseIf objDataView.Table.Rows(x)("CommissionMonth") = 12 Then
                        DNMonth.Text = "Dec " + objDataView.Table.Rows(x)("CommissionYear").ToString()
                    End If
                Next
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objDebitNote.GetAllDataForView()
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
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPurchaseOrder.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("DebitNoteModule.aspx")
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"
                    Dim DebitNoteID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim CommissionYear As String = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Currency As String = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(5).Text
                    Dim CustomerName As String = objDebitNote.GetDebitNoteCustomer(DebitNoteID)
                    Dim CommissionMonth As String = ""
                    If dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 1 Then
                        CommissionMonth = "January"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 2 Then
                        CommissionMonth = "February"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 3 Then
                        CommissionMonth = "March"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 4 Then
                        CommissionMonth = "April"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 5 Then
                        CommissionMonth = "May"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 6 Then
                        CommissionMonth = "June"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 7 Then
                        CommissionMonth = "July"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 8 Then
                        CommissionMonth = "August"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 9 Then
                        CommissionMonth = "September"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 10 Then
                        CommissionMonth = "October"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 11 Then
                        CommissionMonth = "November"
                    ElseIf dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text = 12 Then
                        CommissionMonth = "December"
                    End If

                    If (Directory.Exists(Server.MapPath("~/PDFReports/" & CommissionYear & "/" & CommissionMonth & ""))) Then
                        Dim strFileSize As String = ""
                        Dim di As New IO.DirectoryInfo(Server.MapPath("~/PDFReports/" & CommissionYear & "/" & CommissionMonth & ""))
                        Dim ExistFIleName As String = "DN-" + CustomerName + "-" + CommissionMonth + "-" + Currency + ".pdf"
                        Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)
                        If aryFi.Length > 0 Then
                            Dim fi As IO.FileInfo
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            For Each fi In aryFi
                                Response.ClearHeaders()
                                Response.ClearContent()
                                Response.ContentType = "application/octet-stream"
                                Response.Charset = "UTF-8"
                                Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                                Response.WriteFile((Server.MapPath("~/PDFReports/" & CommissionYear & "/" & CommissionMonth & "/" & fi.Name & "")))
                                Response.End()
                            Next
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                        End If
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")

                    End If
            End Select
        Catch ex As Exception
        End Try

    End Sub

End Class
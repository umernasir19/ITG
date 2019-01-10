Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class SizeRangeEntry
    Inherits System.Web.UI.Page
    Dim dtSizeRangeDB As New DataTable
    Dim Dr As DataRow
    Dim objSizeRangeDB As New SizeRangeDB
    Dim SizeRangeDBID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SizeRangeDBID = Request.QueryString("lSizeRangeDBID")
        If Not Page.IsPostBack Then
            If SizeRangeDBID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If txtSizeRange.Text = "" Or txtSize.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Empty text not allow.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If (Not CType(Session("dtSizeRangeDB"), DataTable) Is Nothing) Then
                    dtSizeRangeDB = Session("dtSizeRangeDB")
                Else
                    dtSizeRangeDB = New DataTable
                    With dtSizeRangeDB
                        .Columns.Add("SizeRangeDBID", GetType(Long))
                        .Columns.Add("SizeRange", GetType(String))
                        .Columns.Add("Sizes", GetType(String))
                    End With
                End If

                Dr = dtSizeRangeDB.NewRow()
                Dr("SizeRangeDBID") = 0
                Dr("SizeRange") = txtSizeRange.Text
                Dr("Sizes") = txtSize.Text
                dtSizeRangeDB.Rows.Add(Dr)
                Session("dtSizeRangeDB") = dtSizeRangeDB
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtSizeRangeDB Is Nothing) Then
            If (dtSizeRangeDB.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtSizeRangeDB
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objSizeRangeDB.GetAll(SizeRangeDBID)

            dtSizeRangeDB = Nothing
            Session("dtSizeRangeDB") = Nothing
            dtSizeRangeDB = New DataTable
            With dtSizeRangeDB
                .Columns.Add("SizeRangeDBID", GetType(Long))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Sizes", GetType(String))
            End With
            For x = 0 To dt.Rows.Count - 1
                Dr = dtSizeRangeDB.NewRow()
                Dr("SizeRangeDBID") = dt.Rows(x)("SizeRangeDBID")
                Dr("SizeRange") = dt.Rows(x)("SizeRange")
                Dr("Sizes") = dt.Rows(x)("Sizes")
                dtSizeRangeDB.Rows.Add(Dr)
            Next

            Session("dtSizeRangeDB") = dtSizeRangeDB
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                dtSizeRangeDB = CType(Session("dtSizeRangeDB"), DataTable)
                If (Not dtSizeRangeDB Is Nothing) Then
                    If (dtSizeRangeDB.Rows.Count > 0) Then
                        Dim ISizeRangeDBID As Integer = dtSizeRangeDB.Rows(e.Item.ItemIndex)("SizeRangeDBID")
                        dtSizeRangeDB.Rows.RemoveAt(e.Item.ItemIndex)
                        objSizeRangeDB.DeleteDetail(ISizeRangeDBID)
                        BindGrid()

                        If dtSizeRangeDB.Rows.Count = 0 Then
                            dgPurchaseOrder.Visible = False
                        End If
                    Else
                        dgPurchaseOrder.Visible = False
                    End If
                End If

        End Select
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                With objSizeRangeDB
                    .SizeRangeDBID = 0
                    .SizeRange = dgPurchaseOrder.Items(x).Cells(1).Text
                    .Sizes = dgPurchaseOrder.Items(x).Cells(2).Text
                    .SaveSizeRangeDB()
                End With
            Next

            Session("dtSizeRangeDB") = Nothing
            Response.Redirect("SizeRangeView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Session("dtSizeRangeDB") = Nothing
            Response.Redirect("SizeRangeView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports Integra
Imports System.Data

Public Class RewashIssueEntry
    Inherits System.Web.UI.Page
    Dim RewashIssueID As Long = 0
    Dim ObjRewashIssue As New RewashIssue

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            RewashIssueID = Request.QueryString("RewashIssueID")
            If Not Page.IsPostBack Then
                BindSeason()
                If RewashIssueID > 0 Then
                    Edit()
                    btnSave.Text = "Update"
                Else
                    btnSave.Text = "Save"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjRewashIssue.GetSeasonsFromJobOrderDatabase()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
            ' BindColor()
            ' GetStyle()
            ' GetQuantity()
            ' GetAlreadyIssueQty()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            BindColor()
            ' GetStyle()
            ' GetQuantity()
            ' GetAlreadyIssueQty()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = ObjRewashIssue.GetSrnOForCutting(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = ObjRewashIssue.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Empty Date")
            ElseIf cmbSeason.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Season")
            ElseIf cmbSrNo.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Sr No")
            ElseIf cmbColor.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Color")
            ElseIf txtRewashIssueQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Rewash Issue Qty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjRewashIssue
                    If RewashIssueID > 0 Then
                        .RewashIssueID = RewashIssueID
                    Else
                        .RewashIssueID = 0
                    End If
                    .IssueDate = txtDate.Text
                    .SeasonDatabaseID = cmbSeason.SelectedValue
                    .JobOrderId = cmbSrNo.SelectedValue
                    .JobOrderDetailId = cmbColor.SelectedValue
                    .RewashIssueQty = txtRewashIssueQty.Text
                    .Remarks = txtRemarks.Text
                    .Save()
                End With
                Response.Redirect("RewashIssueView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = ObjRewashIssue .GetRewashIssueByID (RewashIssueID)
            txtDate.Text = dt.Rows(0)("IssueDate")
            cmbSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")
            BindSrNo()
            cmbSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            BindColor()
            cmbColor.SelectedValue = dt.Rows(0)("JobOrderDetailId")
            txtRewashIssueQty.Text = dt.Rows(0)("RewashIssueQty")
            txtRemarks.Text = dt.Rows(0)("Remarks")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("RewashIssueView.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
Imports Integra
Imports System.Data

Public Class RewashRecvEntry
    Inherits System.Web.UI.Page
    Dim RewashRecvID As Long = 0
    Dim ObjRewash As New RewashRecv
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            RewashRecvID = Request.QueryString("RewashRecvID")
            If Not Page.IsPostBack Then
                BindSeason()
                If RewashRecvID > 0 Then
                    txtChallanNo.Enabled = False
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
            dtcmbSeason = ObjRewash.GetSeasonsFromJobOrderDatabase()
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
            dtInvoiceNo = ObjRewash.GetSrnOForCutting(cmbSeason.SelectedValue)
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
            dtInvoiceNo = ObjRewash.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
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
            ElseIf txtChallanNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Empty Challan No")
            ElseIf cmbSeason.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Season")
            ElseIf cmbSrNo.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Sr No")
            ElseIf cmbColor.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Color")
            ElseIf txtRewashQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Rewash Qty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjRewash
                    If RewashRecvID > 0 Then
                        .RewashRecID = RewashRecvID
                    Else
                        .RewashRecID = 0
                    End If
                    .RecDate = txtDate.Text
                    .ChallanNo = txtChallanNo.Text
                    .SeasonDatabaseID = cmbSeason.SelectedValue
                    .JobOrderId = cmbSrNo.SelectedValue
                    .JobOrderDetailId = cmbColor.SelectedValue
                    .RewashQty = txtRewashQty.Text
                    .Remarks = txtRemarks.Text
                    .Save()
                End With
                Response.Redirect("RewashRecvView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = ObjRewash.GetRewashRecvByID(RewashRecvID)
            txtChallanNo.Text = dt.Rows(0)("ChallanNo")
            txtDate.Text = dt.Rows(0)("RecDate")
            cmbSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")
            BindSrNo()
            cmbSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            BindColor()
            cmbColor.SelectedValue = dt.Rows(0)("JobOrderDetailId")
            txtRewashQty.Text = dt.Rows(0)("RewashQty")
            txtRemarks.Text = dt.Rows(0)("Remarks")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("RewashRecvView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDate.TextChanged, txtChallanNo.TextChanged
        Try
            If txtDate.Text <> "" And txtChallanNo.Text <> "" Then
                
                    ' save mode

                Dim dt As DataTable = ObjRewash.CheckDateAndChallan(txtDate.Text, txtChallanNo.Text)
                    If dt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Challan No is Already Exists on " & txtDate.Text)
                        btnSave.Enabled = False
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        btnSave.Enabled = True
                    End If

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
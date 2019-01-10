Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class PanalCheckingEntry
    Inherits System.Web.UI.Page
    Dim DtPanalChecking As DataTable
    Dim Dr As DataRow
    Dim objSizeRange As New SizeRange
    Dim objPanalMst As New PanalMst
    Dim objPanalDtl As New PanalDtl
    Dim lPanalMstID, userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPanalMstID = Request.QueryString("PanalMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("DtPanalChecking") = Nothing
            BindSeason()
            If lPanalMstID > 0 Then
                Edit()
                btnSave.Visible = True
                btnSave.Text = "Update"
                dgPanalEntry.Columns(8).Visible = True
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub dgPanalEntry_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPanalEntry.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"

                    DtPanalChecking = CType(Session("DtPanalChecking"), DataTable)
                    If (Not DtPanalChecking Is Nothing) Then
                        If (DtPanalChecking.Rows.Count > 0) Then
                            Dim PanalDtlID As Integer = DtPanalChecking.Rows(e.Item.ItemIndex)("PanalDtlID")
                            DtPanalChecking.Rows.RemoveAt(e.Item.ItemIndex)
                            objPanalDtl.DeletePanalDetail(PanalDtlID)
                            BindGrid()
                        Else
                        End If
                    End If
                Case "Edit"
                    DtPanalChecking = CType(Session("DtPanalChecking"), DataTable)
                    If (Not DtPanalChecking Is Nothing) Then
                        If (DtPanalChecking.Rows.Count > 0) Then
                            Dim PanalDtlID As Integer = DtPanalChecking.Rows(e.Item.ItemIndex)("PanalDtlID")
                            lblDtlIDwhenEdit.Text = PanalDtlID
                            SetDetailValuesByDataTable(PanalDtlID)
                            DtPanalChecking.Rows.RemoveAt(e.Item.ItemIndex)
                            Session("DtPanalChecking") = DtPanalChecking
                            dgPanalEntry.Visible = False
                            btnAdd.Visible = True
                        Else
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            Dim dt As DataTable
            dt = objPanalDtl.GetPanalDetailByID(dtrowNo)
            If dt.Rows.Count > 0 Then
                BindSRNO()
                CMBsRnO.SelectedValue = dt.Rows(0)("JobOrderID")
                BindColor()
                cmbColor.SelectedValue = dt.Rows(0)("Color")
                txtDate.Text = dt.Rows(0)("PanalDate")
                txtRangNo.Text = dt.Rows(0)("RangNo")
                txtPanalQty.Text = dt.Rows(0)("PanalQty")
                txtRejectionQty.Text = dt.Rows(0)("RejectionQty")
                txtRemarks.Text = dt.Rows(0)("Remarks")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Dim dt As DataTable = objSizeRange.GetEditForPanal(lPanalMstID)
        cmbSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")
        lblUserId.Text = dt.Rows(0)("UserId")
        Dim DTT As DataTable = objSizeRange.GetsrnoForPanal(cmbSeason.SelectedValue)
        CMBsRnO.DataSource = DTT
        CMBsRnO.DataTextField = "SrNo"
        CMBsRnO.DataValueField = "JobOrderId"
        CMBsRnO.DataBind()
        CMBsRnO.Items.Insert(0, New ListItem("Select", "0"))
        ' CMBsRnO.SelectedValue = dt.Rows(0)("JobOrderID")
        If (Not CType(Session("DtPanalChecking"), DataTable) Is Nothing) Then
            DtPanalChecking = Session("DtPanalChecking")
        Else
            DtPanalChecking = New DataTable
            With DtPanalChecking
                .Columns.Add("PanalDtlID", GetType(Long))
                .Columns.Add("JobOrderID", GetType(Long))
                .Columns.Add("SRNO", GetType(String))
                .Columns.Add("Date", GetType(String))
                .Columns.Add("RangNo", GetType(String))
                .Columns.Add("PanalQty", GetType(String))
                .Columns.Add("RejectionQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("Color", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dt.Rows.Count - 1
            Dr = DtPanalChecking.NewRow()
            Dr("PanalDtlID") = dt.Rows(x)("PanalDtlID")
            Dr("JobOrderID") = dt.Rows(x)("JobOrderID")
            Dr("SRNO") = dt.Rows(x)("SRNO")
            Dr("Date") = dt.Rows(x)("PanalDatee")
            Dr("RangNo") = dt.Rows(x)("RangNo")
            Dr("PanalQty") = dt.Rows(x)("PanalQty")
            Dr("RejectionQty") = dt.Rows(x)("RejectionQty")
            Dr("Remarks") = dt.Rows(x)("Remarks")
            Dr("Color") = dt.Rows(x)("Color")
            DtPanalChecking.Rows.Add(Dr)
            Session("DtPanalChecking") = DtPanalChecking
        Next
        BindGrid()
    End Sub
    Sub BindSeason()
        Dim dt As DataTable
        dt = objSizeRange.GetSeasonsForPanal()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindSRNO()
        Dim dt As DataTable
        dt = objSizeRange.GetsrnoForPanal(cmbSeason.SelectedValue)
        CMBsRnO.DataSource = dt
        CMBsRnO.DataTextField = "SrNo"
        CMBsRnO.DataValueField = "JobOrderId"
        CMBsRnO.DataBind()
        CMBsRnO.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Session("SeasonDatabaseID") = cmbSeason.SelectedValue
            BindSRNO()
        Catch ex As Exception

        End Try
    End Sub
    Sub Clear()
        CMBsRnO.SelectedValue = 0
        ' txtDate.Text = ""
        CMBsRnO.SelectedIndex = 0
        txtRangNo.Text = ""
        txtPanalQty.Text = ""
        txtRejectionQty.Text = ""
        txtRemarks.Text = ""
        cmbColor.SelectedIndex = 0
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtPanalChecking"), DataTable) Is Nothing) Then
            DtPanalChecking = Session("DtPanalChecking")
        Else
            DtPanalChecking = New DataTable
            With DtPanalChecking
                .Columns.Add("PanalDtlID", GetType(Long))
                .Columns.Add("JobOrderID", GetType(Long))
                .Columns.Add("SRNO", GetType(String))
                .Columns.Add("Date", GetType(String))
                .Columns.Add("RangNo", GetType(String))
                .Columns.Add("PanalQty", GetType(String))
                .Columns.Add("RejectionQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("Color", GetType(String))
                 End With
        End If
        Dr = DtPanalChecking.NewRow()

        Dr("PanalDtlID") = Convert.ToInt32(lblDtlIDwhenEdit.Text)
        Dr("JobOrderID") = CMBsRnO.SelectedValue
        Dr("SRNO") = CMBsRnO.SelectedItem.Text
        Dr("Date") = txtDate.Text
        If txtRangNo.Text = "" Then
            Dr("RangNo") = ""
        Else
            Dr("RangNo") = txtRangNo.Text
        End If

        Dr("PanalQty") = txtPanalQty.Text
        Dr("RejectionQty") = txtRejectionQty.Text
        If txtRemarks.Text = "" Then
            Dr("Remarks") = ""
        Else
            Dr("Remarks") = txtRemarks.Text.ToUpper
        End If
        Dr("Color") = cmbColor.SelectedItem.Text

        DtPanalChecking.Rows.Add(Dr)
        Session("DtPanalChecking") = DtPanalChecking
        BindGrid()
        Clear()
    End Sub
    Sub BindGrid()
        Try
            If DtPanalChecking.Rows.Count > 0 Then
                dgPanalEntry.DataSource = DtPanalChecking
                dgPanalEntry.DataBind()
                dgPanalEntry.Visible = True
            Else

                dgPanalEntry.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If txtDate.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
        ElseIf cmbSeason.SelectedItem.Text = "Select" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Season")
            'ElseIf CMBsRnO.SelectedItem.Text = "Select" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select SR NO")
            'ElseIf txtRangNo.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Rang No")
        ElseIf CMBsRnO.SelectedIndex = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select SRNO")
        ElseIf cmbColor.SelectedIndex = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Color")
        ElseIf txtPanalQty.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Panal Qty")
        ElseIf txtRejectionQty.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Rejection Qty")
            'ElseIf txtRemarks.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Remarks")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            SaveSession()
            btnSave.Visible = True
        End If

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
           save()
                Response.Redirect("PanalCheckingView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("PanalCheckingView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        Try
            With objPanalMst

                If lPanalMstID > 0 Then
                    .PanalMstid = lPanalMstID
                Else
                    .PanalMstid = 0
                End If

                If Session("RoleId") = 46 And Session("Type") = "Production" Then
                    If lPanalMstID > 0 Then
                        .UserId = lblUserId.Text
                    Else
                        .UserId = 270
                    End If
                Else
                    If lPanalMstID > 0 Then
                        .UserId = lblUserId.Text
                    Else
                        .UserId = userid
                    End If
                End If

                .SeasonDatabaseID = cmbSeason.SelectedValue
                .CreationDate = Date.Now
                .Save()
            End With

            Dim x As Integer
            For x = 0 To dgPanalEntry.Items.Count - 1
                Dim Remarks As String = dgPanalEntry.Items(x).Cells(8).Text()
                Dim Rang As String = dgPanalEntry.Items(x).Cells(5).Text()
                With objPanalDtl
                    .PanalDtlid = dgPanalEntry.Items(x).Cells(0).Text()
                    If lPanalMstID > 0 Then
                        .PanalMstid = lPanalMstID
                    Else
                        .PanalMstid = objPanalMst.GetID
                    End If
                    .JobOrderID = dgPanalEntry.Items(x).Cells(1).Text()
                    .SRNO = dgPanalEntry.Items(x).Cells(2).Text()
                    .PanalDate = dgPanalEntry.Items(x).Cells(4).Text()
                    If Rang = "&nbsp;" Then
                        .RangNo = ""
                    Else
                        .RangNo = Rang 'dgPanalEntry.Items(x).Cells(5).Text()
                    End If

                    .PanalQty = dgPanalEntry.Items(x).Cells(6).Text()
                    .RejectionQty = dgPanalEntry.Items(x).Cells(7).Text()

                    If Remarks = "&nbsp;" Then
                        .Remarks = ""
                    Else
                        .Remarks = Remarks 'dgPanalEntry.Items(x).Cells(8).Text()
                    End If
                    .Color = dgPanalEntry.Items(x).Cells(3).Text()
                    .Save()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub txtSRNO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSRNO.TextChanged
    '    Try
    '        Dim dt As DataTable = objPanalMst.GetJobId(txtSRNO.Text)
    '        lblSrID.Text = dt.Rows(0)("Joborderid")
    '        Session("Joborderid") = lblSrID.Text
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub CMBsRnO_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CMBsRnO.SelectedIndexChanged
        Try
            BindColor()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, CMBsRnO.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "BuyerColor"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
    End Sub
End Class
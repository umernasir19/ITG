Imports Telerik.Web.UI
Imports Integra.EuroCentra
Public Class LeaveRequestApproval
    Inherits System.Web.UI.Page
    Dim objLeaveRequestApproval As New HRLeaveRequestApproval
    Dim objLeaveRequest As New HRLeaveRequest
    Dim objHRLeaveTable As New HRLeaveTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindLeaveRequestApproval()
            Validation()
        End If
    End Sub
    Function LoadData() As ICollection
        Dim i As Integer
        Dim txtRemarks As RadTextBox
        Dim chkChecked As CheckBox
        Dim lblReason As Label

        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim objDataTable1 As DataTable
        Dim objDataTable2 As DataTable
        If RadioButtonList1.SelectedItem.Text = "Pending" Then
            objDataTable = objLeaveRequestApproval.GetValuesForPendingRequests()
            dgLeaveRequestApproval.Columns(10).Visible = True
            objDataView = New DataView(objDataTable)
            dgLeaveRequestApproval.DataSource = objDataView
            dgLeaveRequestApproval.DataBind()
            For i = 0 To objDataTable.Rows.Count - 1
                Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(i), GridDataItem)
                lblReason = CType(dgLeaveRequestApproval.Items(i).FindControl("lblReason"), Label)

                Dim StrReason() As String
                StrReason = objDataView.Item(i)("Reason").ToString().Split(" ")
                If StrReason.Length > 3 Then
                    lblReason.Text = StrReason(0) + " " + StrReason(1) + " " + StrReason(2) + "..."
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                Else
                    lblReason.Text = objDataView.Item(i)("Reason").ToString()
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                End If
            Next
        ElseIf RadioButtonList1.SelectedItem.Text = "Approved" Then
            objDataTable1 = objLeaveRequestApproval.GetValuesForApprovedrequest()
            objDataView = New DataView(objDataTable1)
            dgLeaveRequestApproval.DataSource = objDataView
            dgLeaveRequestApproval.DataBind()
            For i = 0 To objDataTable1.Rows.Count - 1
                Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(i), GridDataItem)
                txtRemarks = CType(dgLeaveRequestApproval.Items(i).FindControl("txtRemarks"), RadTextBox)
                chkChecked = CType(dgLeaveRequestApproval.Items(i).FindControl("chkApproved"), CheckBox)
                lblReason = CType(dgLeaveRequestApproval.Items(i).FindControl("lblReason"), Label)
                dgLeaveRequestApproval.Columns(10).Visible = False
                chkChecked.Visible = False
                txtRemarks.ReadOnly = True
                txtRemarks.Text = objDataTable1.Rows(i)("Remarks")
                Dim StrReason() As String
                StrReason = objDataView.Item(i)("Reason").ToString().Split(" ")
                If StrReason.Length > 3 Then
                    lblReason.Text = StrReason(0) + " " + StrReason(1) + " " + StrReason(2) + "..."
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                Else
                    lblReason.Text = objDataView.Item(i)("Reason").ToString()
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                End If
            Next
        ElseIf RadioButtonList1.SelectedItem.Text = "Rejected" Then
            objDataTable2 = objLeaveRequestApproval.GetValuesForRejectedrequest()
            objDataView = New DataView(objDataTable2)
            dgLeaveRequestApproval.DataSource = objDataView
            dgLeaveRequestApproval.DataBind()
            For i = 0 To objDataTable2.Rows.Count - 1
                Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(i), GridDataItem)
                txtRemarks = CType(dgLeaveRequestApproval.Items(i).FindControl("txtRemarks"), RadTextBox)
                chkChecked = CType(dgLeaveRequestApproval.Items(i).FindControl("chkApproved"), CheckBox)
                lblReason = CType(dgLeaveRequestApproval.Items(i).FindControl("lblReason"), Label)
                dgLeaveRequestApproval.Columns(10).Visible = False
                chkChecked.Visible = False
                txtRemarks.ReadOnly = True
                txtRemarks.Text = objDataTable2.Rows(i)("Remarks")
                Dim StrReason() As String
                StrReason = objDataView.Item(i)("Reason").ToString().Split(" ")
                If StrReason.Length > 3 Then
                    lblReason.Text = StrReason(0) + " " + StrReason(1) + " " + StrReason(2) + "..."
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                Else
                    lblReason.Text = objDataView.Item(i)("Reason").ToString()
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                End If
            Next
        End If
        Return objDataView
    End Function
    Private Sub BindLeaveRequestApproval()
        Try
            Dim lblReason As Label
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgLeaveRequestApproval.DataSource = objDataView
            dgLeaveRequestApproval.DataBind()
            For i = 0 To dgLeaveRequestApproval.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(i), GridDataItem)
                lblReason = CType(dgLeaveRequestApproval.Items(i).FindControl("lblReason"), Label)
                Dim StrReason() As String
                StrReason = objDataView.Item(i)("Reason").ToString().Split(" ")
                If StrReason.Length > 3 Then
                    lblReason.Text = StrReason(0) + " " + StrReason(1) + "..."
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                Else
                    lblReason.Text = objDataView.Item(i)("Reason").ToString()
                    lblReason.ToolTip = objDataView.Item(i)("Reason").ToString()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadData()
    End Sub
    Sub SaveLeaveRequestApproval()
        Dim x As Integer
        Dim LeaveRequestApprovalID As Integer = 0
        Dim txtRemarks As RadTextBox
        Dim chkApproved As CheckBox

        For x = 0 To dgLeaveRequestApproval.Items.Count - 1

            Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(x), GridDataItem)
            txtRemarks = CType(dgLeaveRequestApproval.Items(x).FindControl("txtRemarks"), RadTextBox)
            chkApproved = CType(dgLeaveRequestApproval.Items(x).FindControl("chkApproved"), CheckBox)
            If chkApproved.Checked = True Then
                Dim HRID As String = item("HRID").Text
                With objLeaveRequestApproval
                    .LeaveRequestApprovalID = 0
                    .HRID = HRID
                    .LeaveRequestID = item("LeaveRequestID").Text
                    .Remarks = txtRemarks.Text
                    .ActionDate = Today.Date
                    .Status = "Approved"
                    .SaveLeaveRequestApproval()
                End With

                '---Leave Request---------'''''''''''''''''''
                ' objLeaveRequest.UpdateRequestStatus(item("LeaveRequestID").Text)
                Dim dtLeaveRequest As New DataTable
                dtLeaveRequest = objLeaveRequest.GetRequestStatus(item("LeaveRequestID").Text)
                With objLeaveRequest
                    .LeaveRequestID = dtLeaveRequest.Rows(0)("LeaveRequestID")
                    .HRID = dtLeaveRequest.Rows(0)("HRID")
                    .LeaveFrom = dtLeaveRequest.Rows(0)("LeaveFrom")
                    .LeaveTo = dtLeaveRequest.Rows(0)("LeaveTo")
                    .Reason = dtLeaveRequest.Rows(0)("Reason")
                    .CreationDate = dtLeaveRequest.Rows(0)("CreationDate")
                    .LeaveDays = dtLeaveRequest.Rows(0)("LeaveDays")
                    .DateOfNotice = dtLeaveRequest.Rows(0)("DateOfNotice")
                    .Approved = 1
                    .Rejected = 0
                    .SaveLeaveRequest()
                End With

                Dim dtHRLeaveTable As New DataTable
                dtHRLeaveTable = objHRLeaveTable.GetHRLeaveTable(HRID)
                Dim LeaveAvailed As Integer
                LeaveAvailed = dtHRLeaveTable.Rows(0)("TotalLeaveAvailed")
                Dim LeaveDays As Integer
                LeaveDays = dtLeaveRequest.Rows(0)("LeaveDays")
                Dim TotalLeaveAvailed As Integer
                TotalLeaveAvailed = LeaveAvailed + LeaveDays
                objHRLeaveTable.UpdateTotalLeaveAvailed(HRID, TotalLeaveAvailed)
            End If
        Next
    End Sub
    Sub SaveLeaveRequestRejected()
        Dim x As Integer
        Dim LeaveRequestApprovalID As Integer = 0
        Dim txtRemarks As RadTextBox
        Dim chkApproved As CheckBox

        For x = 0 To dgLeaveRequestApproval.Items.Count - 1

            Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(x), GridDataItem)
            txtRemarks = CType(dgLeaveRequestApproval.Items(x).FindControl("txtRemarks"), RadTextBox)
            chkApproved = CType(dgLeaveRequestApproval.Items(x).FindControl("chkApproved"), CheckBox)
            If chkApproved.Checked = True Then
                Dim HRID As String = item("HRID").Text
                With objLeaveRequestApproval
                    .LeaveRequestApprovalID = 0
                    .HRID = HRID
                    .LeaveRequestID = item("LeaveRequestID").Text
                    .Remarks = txtRemarks.Text
                    .ActionDate = Today.Date
                    .Status = "Rejected"
                    .SaveLeaveRequestApproval()
                End With
                '---Leave Request---------'''''''''''''''''''
                ' objLeaveRequest.UpdateRequestStatus(item("LeaveRequestID").Text)
                Dim dtLeaveRequest As New DataTable
                dtLeaveRequest = objLeaveRequest.GetRequestStatus(item("LeaveRequestID").Text)
                With objLeaveRequest
                    .LeaveRequestID = dtLeaveRequest.Rows(0)("LeaveRequestID")
                    .HRID = dtLeaveRequest.Rows(0)("HRID")
                    .LeaveFrom = dtLeaveRequest.Rows(0)("LeaveFrom")
                    .LeaveTo = dtLeaveRequest.Rows(0)("LeaveTo")
                    .Reason = dtLeaveRequest.Rows(0)("Reason")
                    .CreationDate = dtLeaveRequest.Rows(0)("CreationDate")
                    .LeaveDays = dtLeaveRequest.Rows(0)("LeaveDays")
                    .DateOfNotice = dtLeaveRequest.Rows(0)("DateOfNotice")
                    .Approved = 0
                    .Rejected = 1
                    .SaveLeaveRequest()
                End With
            End If
        Next
    End Sub
    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApproved.Click
        SaveLeaveRequestApproval()
        LoadData()
    End Sub
    Protected Sub btnRejected_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRejected.Click
        SaveLeaveRequestRejected()
        LoadData()
    End Sub
    Sub Validation()
        Dim x As Integer
        Dim chkApproved As CheckBox
        If dgLeaveRequestApproval.Items.Count > 0 Then
            btnApproved.Visible = True
            btnRejected.Visible = True
            Dim item As GridDataItem = DirectCast(dgLeaveRequestApproval.MasterTableView.Items(x), GridDataItem)
            chkApproved = CType(dgLeaveRequestApproval.Items(x).FindControl("chkApproved"), CheckBox)
            If chkApproved.Checked = True Then
                btnApproved.Enabled = True
                btnRejected.Enabled = True
            Else
                btnApproved.Enabled = True
                btnRejected.Enabled = True
            End If
        Else
            btnApproved.Visible = False
            btnRejected.Visible = False
        End If
    End Sub

End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class LeaveRequest
    Inherits System.Web.UI.Page
    Dim objLeaveRequest As New HRLeaveRequest
    Dim objUser As New User
    Dim HRID As Long
    Dim UserID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HRID = Request.QueryString("lHRID")
        UserID = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            GetPendingRequest(HRID)
            txtDateofNotice.SelectedDate = Today.Date
            GetUserDetail(HRID)
            txtLeaveFrom.SelectedDate = Today.Date
            txtLeaveTo.SelectedDate = Today.Date
            btnApproval.Enabled = False
            btnClose.Visible = False
        End If
    End Sub
    Sub GetUserDetail(ByVal HRID)
        Dim dt As DataTable
        dt = objLeaveRequest.GetUserDetail(HRID)
        If dt.Rows.Count > 0 Then
            lblUser.Text = "Welcome,   " + dt.Rows(0)("EmployeeName")
            txtTotalLeave.Text = dt.Rows(0)("TotalLeaveGranted")
            txtAvailed.Text = dt.Rows(0)("TotalLeaveAvailed")
            txtRemaining.Text = dt.Rows(0)("TotalLeaveGranted") - dt.Rows(0)("TotalLeaveAvailed")
        End If
    End Sub
    Protected Sub txtLeaveFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtLeaveFrom.SelectedDateChanged
        If txtLeaveFrom.SelectedDate < Today.Date Then
            lblErrorMsg.Text = "Selected Date is not Valid Please Select valid Date"
            btnApproval.Enabled = False
        Else
            lblErrorMsg.Text = ""
            btnApproval.Enabled = True
            Dim TimeSpan As TimeSpan = txtLeaveTo.SelectedDate.Value.Subtract(txtLeaveFrom.SelectedDate.Value)
            Dim LeaveDays As Long = TimeSpan.Days
            txtLeaveDays.Text = LeaveDays
        End If
    End Sub
    Protected Sub txtLeaveTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtLeaveTo.SelectedDateChanged
        If txtLeaveTo.SelectedDate <= txtLeaveFrom.SelectedDate Then
            lblErrorMsg.Text = "Selected Date is not Valid Please Select valid Date"
            btnApproval.Enabled = False
        Else
            lblErrorMsg.Text = ""
            btnApproval.Enabled = True
            Dim TimeSpan As TimeSpan = txtLeaveTo.SelectedDate.Value.Subtract(txtLeaveFrom.SelectedDate.Value)
            Dim LeaveDays As Long = TimeSpan.Days
            txtLeaveDays.Text = LeaveDays
        End If
        Dim RemainigLeave As Long = txtRemaining.Text
        Dim LeaveDayss As Long = txtLeaveDays.Text
        If LeaveDayss > RemainigLeave Then
            lblErrorMsg.Text = "Your Leave Days are Greater then Your Remaining Days."
            btnApproval.Enabled = False
        Else
            btnApproval.Enabled = True
            lblErrorMsg.Text = ""
        End If
    End Sub
    Protected Sub btnApproval_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApproval.Click
        SaveLeaveRequest()
        lblErrorMsg.Text = "Your Request Sent Successfully"
        btnApproval.Visible = False
        txtDateofNotice.Enabled = False
        txtLeaveFrom.Enabled = False
        txtLeaveTo.Enabled = False
        txtReason.Enabled = False
        btnClose.Visible = True
    End Sub
    Sub SaveLeaveRequest()
        Try
            With objLeaveRequest
                .LeaveRequestID = 0
                .UserID = CLng(Session("Userid"))
                .HRID = HRID
                .CreationDate = Date.Now
                .LeaveFrom = txtLeaveFrom.SelectedDate
                .LeaveTo = txtLeaveTo.SelectedDate
                .LeaveDays = txtLeaveDays.Text
                .DateOfNotice = txtDateofNotice.SelectedDate
                .Reason = txtReason.Text
                .Approved = 0
                .Rejected = 0
                .SaveLeaveRequest()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub GetPendingRequest(ByVal HRID)
        Dim dtPending As New DataTable
        dtPending = objLeaveRequest.GetPendingRequests(HRID)
        If dtPending.Rows.Count = 0 Then
            lblmessage.Visible = False
        Else
            lblmessage.Text = "Your leave request is under process please wait...."
            txtDateofNotice.Enabled = False
            txtLeaveFrom.Enabled = False
            txtLeaveTo.Enabled = False
            txtReason.Enabled = False
        End If

    End Sub

End Class
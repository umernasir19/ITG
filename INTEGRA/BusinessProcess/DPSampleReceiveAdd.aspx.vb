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
Public Class DPSampleReceiveAdd
    Inherits System.Web.UI.Page
    Dim objDPPOMst As New DPPOMst
    Dim objDPPODtl As New DPPODtl
    Dim lDPPOMSTId, userid As Long
    Dim dtPORecvDetail As DataTable
    Dim Dr As DataRow
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim objDPSampleReceive As New DPSampleReceive
    Dim lDPSampleReceiveID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        lDPSampleReceiveID = Request.QueryString("DPSampleReceiveID")
        If Not Page.IsPostBack Then
            If lDPSampleReceiveID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                PakistanTimezone()
                GRNNoGenerateOnLoad()
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub PakistanTimezone()
        Dim timeZoneInfo As TimeZoneInfo
        Dim dateTime As DateTime
        timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
        dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
        Dim time As String = dateTime.ToLongTimeString()
        txtReceiveTime.Text = time
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = objDPSampleReceive.GetEditData(lDPSampleReceiveID)
        txtReceiveDate.SelectedDate = dt.Rows(0)("ReceiveDate")
        PakistanTimezone()
        lblFabricMstId.Text = dt.Rows(0)("FabricdbMstId")
        txtDalNoO.Text = dt.Rows(0)("DalNo")
        LBLfABRICiSSUEid.Text = dt.Rows(0)("FabricIssueID")
        lblUserId.Text = dt.Rows(0)("UserId")
        Dim dtFBData As DataTable = objDPSampleReceive.StyleForSampleIssue(txtDalNoO.Text, LBLfABRICiSSUEid.Text)
        If dtFBData.Rows.Count > 0 Then
            cmbStyleNo.DataSource = dtFBData
            cmbStyleNo.DataTextField = "Style"
            cmbStyleNo.DataValueField = "DPRNDID"
            cmbStyleNo.DataBind()
            cmbStyleNo.Items.Insert(0, New RadComboBoxItem("Select", 0))

        End If
        cmbStyleNo.SelectedValue = dt.Rows(0)("DPRNDID")
        txtIssueQty.Text = dt.Rows(0)("IssueQty")
        txtFabricReceivedQty.Text = dt.Rows(0)("FabricRecvQty")
        txtReceiveQty.Text = dt.Rows(0)("ReceiveQty")
        txtHourConsumed.Text = dt.Rows(0)("HourConsumed")
        txtDifference.Text = dt.Rows(0)("Difference")
        txtRemarks.Text = dt.Rows(0)("Remarks")
        txtDSRNO.Text = dt.Rows(0)("DSRNO")
        txtDSINo.Text = dt.Rows(0)("DSINo")
    End Sub
    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDSINo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDSINo.TextChanged
        Try


            Dim DTGetDSINO As DataTable = objDPSampleReceive.GetDalNoForFabricIssue(txtDSINo.Text)
            txtDalNoO.Text = DTGetDSINO.Rows(0)("DalNo")
            LBLfABRICiSSUEid.Text = DTGetDSINO.Rows(0)("FabricIssueID")



            Dim dtFBData As DataTable = objDPSampleReceive.StyleForSampleIssue(DTGetDSINO.Rows(0)("DalNo"), LBLfABRICiSSUEid.Text)
            If dtFBData.Rows.Count > 0 Then
                cmbStyleNo.DataSource = dtFBData
                cmbStyleNo.DataTextField = "Style"
                cmbStyleNo.DataValueField = "DPRNDID"
                cmbStyleNo.DataBind()
                cmbStyleNo.Items.Insert(0, New RadComboBoxItem("Select", 0))

            End If




            Dim dt As DataTable = objDPSampleReceive.GetFBData(DTGetDSINO.Rows(0)("DalNo"))
            If dt.Rows.Count > 0 Then
                lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
            End If






            Dim IssueQty As DataTable
            IssueQty = objDPSampleReceive.GetIssueQtyNew(txtDSINo.Text)
            If IssueQty.Rows.Count > 0 Then
                txtIssueQty.Text = IssueQty.Rows(0)("IssueQty")
                UptxtIssueQty.Update()
            End If


            Dim FabricReceiveQty As DataTable
            FabricReceiveQty = objDPSampleReceive.GetFabricReceiveQtyNew(txtDSINo.Text)
            If FabricReceiveQty.Rows.Count > 0 Then
                txtFabricReceivedQty.Text = FabricReceiveQty.Rows(0)("FabricReceiveQty")
                UptxtFabricReceivedQty.Update()
            End If



        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyleNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyleNo.SelectedIndexChanged
        Try
        Catch ex As Exception

        End Try
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objDPSampleReceive.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(4, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If


                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If


                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "DSR" & "-" & LastCode
            txtDSRNO.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try


            
            If txtReceiveQty.Text = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Zero Quantity Available From Sample Receive")
            Else


                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                With objDPSampleReceive
                    If lDPSampleReceiveID > 0 Then
                        .DPSampleReceiveID = lDPSampleReceiveID

                    Else
                        .DPSampleReceiveID = 0
                    End If

                    .CreationDate = Date.Now
                    If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then

                        If lDPSampleReceiveID > 0 Then
                            .UserId = lblUserId.Text
                        Else
                            .UserId = 270
                        End If
                    Else
                        If lDPSampleReceiveID > 0 Then
                            .UserId = lblUserId.Text
                        Else
                            .UserId = userid
                        End If

                    End If



                    .ReceiveDate = txtReceiveDate.SelectedDate

                    .ReceiveTime = txtReceiveTime.Text
                    .FabricDbMstID = lblFabricMstId.Text
                    .DPRNDID = cmbStyleNo.SelectedValue

                    .IssueQty = txtIssueQty.Text
                    .FabricRecvQty = txtFabricReceivedQty.Text
                    .ReceiveQty = txtReceiveQty.Text

                    .HourConsumed = txtHourConsumed.Text
                    .Difference = txtDifference.Text
                    .Remarks = txtRemarks.Text
                    .DSRNo = txtDSRNO.Text
                    .DSINo = txtDSINo.Text
                    .FabricIssueID = LBLfABRICiSSUEid.Text
                    .Saved()
                End With
                Response.Redirect("DPSampleReceiveView.aspx")

            End If
        Catch ex As Exception

        End Try
    End Sub
  
    Protected Sub txtReceiveQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtReceiveQty.TextChanged
        If Val(txtFabricReceivedQty.Text) + Val(txtReceiveQty.Text) > Val(txtIssueQty.Text) Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub
    Protected Sub txtHourConsumed_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtHourConsumed.TextChanged
        If cmbStyleNo.SelectedItem.Text = "Select" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style No")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Dim DTDifference As DataTable
            DTDifference = objDPSampleReceive.GetDifference(lblFabricMstId.Text, cmbStyleNo.SelectedValue, txtDSINo.Text)
            If DTDifference.Rows.Count > 0 Then
                Dim TotalTimeReq As Decimal
                TotalTimeReq = DTDifference.Rows(0)("TotalTimeReq")
                txtDifference.Text = Val(TotalTimeReq) - Val(txtHourConsumed.Text)
                UptxtDifference.Update()
        End If
        End If
    End Sub
End Class
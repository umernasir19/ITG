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
Public Class DPFabricIssueAdd
    Inherits System.Web.UI.Page
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim objFabricIssueWorkerDtl As New FabricIssueWorkerDtl
    Dim objDPWorker As New DPWorker
    Dim lFabricIssueID, userid As Long
    Dim dtWorkerDetail As DataTable
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lFabricIssueID = Request.QueryString("lFabricIssueID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtWorkerDetail") = Nothing
            BindWorker()
            BindTime()
            GRNNoGenerateOnLoad()
            PakistanTimezone()
            'txtTimeCurrent.Text = DateTime.Now.ToLongTimeString()
            If userid = "238" Then
                '  pnldd.Enabled = True
            Else
            End If
            txtCreationDatee.SelectedDate = Date.Now
            If lFabricIssueID > 0 Then
                btnSave.Text = "Update"
                Edit()
            Else
                btnSave.Text = "Issue"
            End If
        End If
        PageHeader("Fabric Issue Entry Form")
    End Sub

    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub PakistanTimezone()
        Dim timeZoneInfo As TimeZoneInfo
        Dim dateTime As DateTime
        'Set the time zone information to US Mountain Standard Time 
        timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
        'Get date and time in US Mountain Standard Time 
        dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
        Dim time As String = dateTime.ToLongTimeString()
        txtTimeCurrent.Text = time   ' DateTime.Now.ToLongTimeString()
    End Sub
    Sub Edit()
        Dim dtedit As DataTable = ObjDPFabricIssue.GetEditDatanEW(lFabricIssueID)
        Dim dtworker As DataTable = ObjDPFabricIssue.GetEditWorkerData(lFabricIssueID)
        If dtedit.Rows.Count > 0 Then
            lblFabricMstId.Text = dtedit.Rows(0)("FabricDBMstId")
            txtDalNoO.Text = dtedit.Rows(0)("dALNO")
            txtDalNoO.ReadOnly = True
            txtTotalFabric.Text = dtedit.Rows(0)("TotalFabricReq")
            Changedalno()
            cmbStyleNo.SelectedValue = dtedit.Rows(0)("DPRNDIDD")
            cmbStyleNo.Enabled = False
            txtCreationDatee.SelectedDate = dtedit.Rows(0)("FabricIssueDate")
            PakistanTimezone()
            '  txtTimeCurrent.Text = DateTime.Now.ToLongTimeString() ' DPTime
            txtNoofSample.Text = dtedit.Rows(0)("NoofSample")
            txtNoofSample.ReadOnly = False
            txtFabReq.Text = dtedit.Rows(0)("FabricReqforonePcs")
            txtFabReq.ReadOnly = False
            txttimeReq1Pcs.Text = dtedit.Rows(0)("TimeReqforonePcs")
            txttimeReq1Pcs.ReadOnly = False
            txtnoofworker.Text = dtedit.Rows(0)("Nofworker")
            txtnoofworker.ReadOnly = False
            txtTotaltimereq.Text = dtedit.Rows(0)("TotalTimeReq")
            txtTotaltimereq.ReadOnly = False
            txtRemarks.Text = dtedit.Rows(0)("Remarks")
            ' txtAvailFab.Text = dtedit.Rows(0)("AvailableFabric")
            ' btnSave.Text = dtedit.Rows(0)("Type")
            txtIsssueNo.Text = dtedit.Rows(0)("IssueNo")
            TxtRemFabric.Text = dtedit.Rows(0)("BalanceQty")
        End If
        If (Not CType(Session("dtWorkerDetail"), DataTable) Is Nothing) Then
            dtWorkerDetail = Session("dtWorkerDetail")
        Else
            dtWorkerDetail = New DataTable
            With dtWorkerDetail
                .Columns.Add("FabricIssueWorkerDtlId", GetType(Long))
                .Columns.Add("WorkerID", GetType(String))
                .Columns.Add("WorkerName", GetType(String))

            End With
        End If
        If dtworker.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To dtworker.Rows.Count - 1
                Dr = dtWorkerDetail.NewRow()
                Dr("FabricIssueWorkerDtlId") = dtworker.Rows(x)("FabricIssueWorkerDtlId")
                Dr("WorkerID") = dtworker.Rows(x)("WorkerID")
                Dr("WorkerName") = dtworker.Rows(x)("WorkerName")
                dtWorkerDetail.Rows.Add(Dr)
                Session("dtWorkerDetail") = dtWorkerDetail
            Next
        End If
        BindGrid()

    End Sub
    Protected Sub txtDalNoO_TextChanged(sender As Object, e As EventArgs) Handles txtDalNoO.TextChanged
        Try
            Changedalno()
        Catch ex As Exception

        End Try
    End Sub
    Sub Changedalno()
        Dim dtFBData As DataTable = ObjDPFabricIssue.GetFBData(txtDalNoO.Text)
        Dim dtFBRecv As DataTable = ObjDPFabricIssue.GetFBRcvQty(txtDalNoO.Text)
        Dim dtFBIssue As DataTable = ObjDPFabricIssue.GetFBIssueQty(txtDalNoO.Text)
        Dim dtDPFBIssue As DataTable = ObjDPFabricIssue.GetDPFBIssueQty(txtDalNoO.Text)
        Dim FBRecv As Decimal = 0
        Dim FBIssue As Decimal = 0
        Dim DPFBIssue As Decimal = 0
        If dtFBRecv.Rows.Count > 0 Then
            FBRecv = dtFBRecv.Rows(0)("ReceiveQty")
        End If
        If dtFBIssue.Rows.Count > 0 Then
            FBIssue = dtFBIssue.Rows(0)("IssueQty")
        End If
        If dtDPFBIssue.Rows.Count > 0 Then
            DPFBIssue = dtDPFBIssue.Rows(0)("IssueQty")
        End If
        If dtFBData.Rows.Count > 0 Then
            txtSupplierRef.Text = dtFBData.Rows(0)("SupplierArtNo")
            txtSupplierName.Text = dtFBData.Rows(0)("SupplierName")
            txtQuality.Text = dtFBData.Rows(0)("SupplierName")
            txtComposition.Text = dtFBData.Rows(0)("CompositionName")
            txtQuality.Text = dtFBData.Rows(0)("FabricQuality")
            txtColour.Text = dtFBData.Rows(0)("Color")
            txtWidth.Text = dtFBData.Rows(0)("FabricWidth")
            txtDye.Text = dtFBData.Rows(0)("DyeWash")
            txtFinish.Text = dtFBData.Rows(0)("FinishGSM")
            lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")

            txtAvailFab.Text = Val(dtFBData.Rows(0)("OPQty")) + Val(dtFBData.Rows(0)("PurchaseQty")) + FBRecv - FBIssue - DPFBIssue

            If txtTotalFabric.Text = "" Then
                txtTotalFabric.Text = 0
            End If
            'If Val(txtTotalFabric.Text) < Val(txtAvailFab.Text) Then
            '    TxtRemFabric.Text = Val(txtTotalFabric.Text) - Val(txtAvailFab.Text)
            '    upTxtRemFabric.Update()
            'ElseIf Val(txtTotalFabric.Text) > Val(txtAvailFab.Text) Then
            '    TxtRemFabric.Text = 0
            'End If
            BindSupplier()

            Dim dtTotalReqTime As DataTable = ObjDPFabricIssue.GetTotalReqTime(cmbStyleNo.SelectedItem.Text)
            If dtTotalReqTime.Rows.Count > 0 Then
                txtTotaltimereq.Text = dtTotalReqTime.Rows(0)("EstimatedTimeReq")
                UptxtTotaltimereq.Update()
            Else
            End If

        End If

    End Sub
    Sub BindSupplier()
        Dim dtStyle As DataTable = ObjDPFabricIssue.GetStyleForRND(lblFabricMstId.Text)
        cmbStyleNo.DataSource = dtStyle
        cmbStyleNo.DataTextField = "Style"
        cmbStyleNo.DataValueField = "DPRNDID"
        cmbStyleNo.DataBind()

    End Sub
    Sub BindTime()
        Dim dtStyle As DataTable = ObjDPFabricIssue.GetTime
        CmbTime.DataSource = dtStyle
        CmbTime.DataTextField = "DPTime"
        CmbTime.DataValueField = "DPTimeID"
        CmbTime.DataBind()

    End Sub

    Protected Sub txtNoofSample_TextChanged(sender As Object, e As EventArgs) Handles txtNoofSample.TextChanged
        Try
            If txtNoofSample.Text = "" Then
                txtNoofSample.Text = 0
            End If
            If txtFabReq.Text = "" Then
                txtFabReq.Text = 0
            End If
            'update yasir 30 sep

            '  Dim DTCons As DataTable = ObjDPFabricIssue.GetConsNew(cmbStyleNo.SelectedValue)
            'txtFabReq.Text = DTCons.Rows(0)("ConsumptionPerPCS")

            txtTotalFabric.Text = Val(txtNoofSample.Text) * Val(txtFabReq.Text)


            If Val(txtTotalFabric.Text) < Val(txtAvailFab.Text) Then
                TxtRemFabric.Text = Val(txtAvailFab.Text) - Val(txtTotalFabric.Text)
                upTxtRemFabric.Update()

            ElseIf Val(txtTotalFabric.Text) > Val(txtAvailFab.Text) Then
                TxtRemFabric.Text = Val(txtAvailFab.Text) - Val(txtTotalFabric.Text)
                upTxtRemFabric.Update()


            End If
            'If Val(txtTotalFabric.Text) < Val(txtAvailFab.Text) Then
            '    TxtRemFabric.Text = Val(txtTotalFabric.Text) - Val(txtAvailFab.Text)
            '    upTxtRemFabric.Update()
            'ElseIf Val(txtTotalFabric.Text) > Val(txtAvailFab.Text) Then
            '    TxtRemFabric.Text = 0
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtFabReq_TextChanged(sender As Object, e As EventArgs) Handles txtFabReq.TextChanged
        Try
            If txtNoofSample.Text = "" Then
                txtNoofSample.Text = 0
            End If
            If txtFabReq.Text = "" Then
                txtFabReq.Text = 0
            End If
            txtTotalFabric.Text = Val(txtNoofSample.Text) * Val(txtFabReq.Text)


            If Val(txtTotalFabric.Text) < Val(txtAvailFab.Text) Then
                TxtRemFabric.Text = Val(txtAvailFab.Text) - Val(txtTotalFabric.Text)
                upTxtRemFabric.Update()

            ElseIf Val(txtTotalFabric.Text) > Val(txtAvailFab.Text) Then
                TxtRemFabric.Text = Val(txtAvailFab.Text) - Val(txtTotalFabric.Text)
                upTxtRemFabric.Update()

      
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txttimeReq1Pcs_TextChanged(sender As Object, e As EventArgs) Handles txttimeReq1Pcs.TextChanged
        Try
            If txtNoofSample.Text = "" Then
                txtNoofSample.Text = 0
            End If
            If txtFabReq.Text = "" Then
                txtFabReq.Text = 0
            End If
            txtTotalFabric.Text = Val(txtNoofSample.Text) * Val(txtFabReq.Text)
            If txtnoofworker.Text = "" Then
            Else
                If Val(txtnoofworker.Text) = 0 Then
                Else
                    If txtTotalFabric.Text <> "" And txtNoofSample.Text <> "" Then
                        txtTotaltimereq.Text = (Val(txtNoofSample.Text) * Val(txttimeReq1Pcs.Text)) / Val(txtnoofworker.Text)


                        'If Val(txtTotalFabric.Text) < Val(txtAvailFab.Text) Then
                        '    TxtRemFabric.Text = Val(txtTotalFabric.Text) - Val(txtAvailFab.Text)
                        '    upTxtRemFabric.Update()
                        'ElseIf Val(txtTotalFabric.Text) > Val(txtAvailFab.Text) Then
                        '    TxtRemFabric.Text = 0
                        'End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtnoofworker_TextChanged(sender As Object, e As EventArgs) Handles txtnoofworker.TextChanged
        Try
            If txtnoofworker.Text = "" Then
            Else
                If Val(txtnoofworker.Text) = 0 Then
                Else
                    If txtTotalFabric.Text <> "" And txtNoofSample.Text <> "" Then
                        txtTotaltimereq.Text = (Val(txtNoofSample.Text) * Val(txttimeReq1Pcs.Text)) / Val(txtnoofworker.Text)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
   

    Protected Sub btnAddComp_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnAddWorker.Click
        Try
            cmbWorker.Visible = False
            txtWorker.Visible = True
            btnAddWorker.Visible = False
            btnSaveWorker.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSaveComp_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnSaveWorker.Click
        Try
            If txtWorker.Text = "" Then

            Else
                With objDPWorker
                    .WorkerID = 0
                    .WorkerName = txtWorker.Text.ToUpper
                    .SaveWorker()
                End With

            End If
            BindWorker()
            cmbWorker.Visible = True
            txtWorker.Text = ""
            txtWorker.Visible = False
            btnAddWorker.Visible = True
            btnSaveWorker.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Sub BindWorker()
        Dim dtworker As DataTable
        dtworker = ObjDPFabricIssue.GetWorker
        cmbWorker.DataSource = dtworker
        cmbWorker.DataTextField = "WorkerName"
        cmbWorker.DataValueField = "WorkerID"
        cmbWorker.DataBind()
        UpcmbWorker.Update()
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            SaveSession()
            BindGrid()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtWorkerDetail"), DataTable) Is Nothing) Then
            dtWorkerDetail = Session("dtWorkerDetail")
        Else
            dtWorkerDetail = New DataTable
            With dtWorkerDetail
                .Columns.Add("FabricIssueWorkerDtlId", GetType(Long))
                .Columns.Add("WorkerID", GetType(String))
                .Columns.Add("WorkerName", GetType(String))

            End With
        End If
        Dr = dtWorkerDetail.NewRow()
        Dr("FabricIssueWorkerDtlId") = 0
        Dr("WorkerID") = cmbWorker.SelectedValue
        Dr("WorkerName") = cmbWorker.SelectedItem.Text
        dtWorkerDetail.Rows.Add(Dr)
        Session("dtWorkerDetail") = dtWorkerDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtWorkerDetail")
            If objDatatble.Rows.Count > 0 Then
                dgWorker.Visible = True
                dgWorker.VirtualItemCount = objDatatble.Rows.Count
                dgWorker.DataSource = objDatatble
                dgWorker.DataBind()
            Else
                dgWorker.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgWorker_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgWorker.DeleteCommand
        dtWorkerDetail = CType(Session("dtWorkerDetail"), DataTable)
        If (Not dtWorkerDetail Is Nothing) Then
            If (dtWorkerDetail.Rows.Count > 0) Then
                Dim FabricDBDtlId As Integer = dtWorkerDetail.Rows(e.Item.ItemIndex)("FabricIssueWorkerDtlId")
                dtWorkerDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objFabricIssueWorkerDtl.Deletedetail(FabricDBDtlId)
                BindGrid()
            Else
            End If

        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If dgWorker.Visible = False Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Add Worker")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveData()
                ' If btnSave.Text = "Purchase" Then
                'Response.Redirect("DPPurchaseOrder.aspx")
                'Else
                Response.Redirect("DPFabricIssueView.aspx")
                'End If
            End If

         

        Catch ex As Exception

        End Try
    End Sub

    Sub SaveData()
        With ObjDPFabricIssue
            If lFabricIssueID > 0 Then
                .FabricIssueID = lFabricIssueID
            Else
                .FabricIssueID = 0
            End If
            .FabricDBMstId = lblFabricMstId.Text
            .CreationDate = Date.Now
            .DPRNDID = cmbStyleNo.SelectedValue
            .FabricIssueDate = txtCreationDatee.SelectedDate
            .DPTime = txtTimeCurrent.Text  ' CmbTime.SelectedItem.Text
            If txtNoofSample.Text = "" Then
                .NoofSample = 0
            Else
                .NoofSample = txtNoofSample.Text
            End If
            If txtFabReq.Text = "" Then
                .FabricReqforonePcs = 0
            Else
                .FabricReqforonePcs = txtFabReq.Text
            End If
            If txtTotalFabric.Text = "" Then
                .TotalFabricReq = 0
            Else
                .TotalFabricReq = txtTotalFabric.Text
            End If
            If txttimeReq1Pcs.Text = "" Then
                .TimeReqforonePcs = 0
            Else
                .TimeReqforonePcs = txttimeReq1Pcs.Text
            End If
            If txtnoofworker.Text = "" Then
                .Nofworker = 0
            Else
                .Nofworker = txtnoofworker.Text
            End If
            If txtTotaltimereq.Text = "" Then
                .TotalTimeReq = 0
            Else
                .TotalTimeReq = txtTotaltimereq.Text
            End If
            .Remarks = txtRemarks.Text
            If txtAvailFab.Text = "" Then
                .AvailableFabric = ""
            Else
                .AvailableFabric = txtAvailFab.Text
            End If
            .Type = "Issue"
            .IssueNo = txtIsssueNo.Text
            .BalanceQty = TxtRemFabric.Text
            .SaveFabricIssue()
        End With
        Dim x As Integer
        For x = 0 To dgWorker.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgWorker.MasterTableView.Items(x), GridDataItem)

            With objFabricIssueWorkerDtl
                .FabricIssueWorkerDtlId = item("FabricIssueWorkerDtlId").Text
                If lFabricIssueID > 0 Then
                    .FabricIssueID = lFabricIssueID
                Else
                    .FabricIssueID = ObjDPFabricIssue.GetID
                End If
                .WorkerID = item("WorkerID").Text
                .WorkerName = item("WorkerName").Text
                .SaveFabricIssueWorkerDtl()
            End With
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("DPFabricIssueView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = ObjDPFabricIssue.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(7, 2)
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
            VoucherNo = "DSI" & "-" & LastCode
            txtIsssueNo.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyleNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyleNo.SelectedIndexChanged
        Try
            Dim dtTotalReqTime As DataTable = ObjDPFabricIssue.GetTotalReqTime(cmbStyleNo.SelectedItem.Text)
            txtTotaltimereq.Text = dtTotalReqTime.Rows(0)("EstimatedTimeReq")
            UptxtTotaltimereq.update()
        Catch ex As Exception

        End Try
    End Sub
End Class
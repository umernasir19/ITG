Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CashTransactionSheet
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New ChartOfAccount
    Dim objCashTransaction As New CashTransaction
    Dim CashTransactionID As Long
    Dim DtCashDetail As DataTable
    Dim dr As DataRow
    Dim objCashTransactionDetail As New CashTransactionDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CashTransactionID = Request.QueryString("CashTransactionID")
        If Not Page.IsPostBack Then
            BindAccountHead()
            BindHKCode()
            BindECPCode()
            txtTransactionDate.SelectedDate = Date.Now
            Session("DtCashDetail") = Nothing
            If CashTransactionID > 0 Then
                EditModes()
                btnPostAddmore.Visible = False
                rblTranscationType.Enabled = False
            Else
                AutoVocharNo()
                btnPostAddmore.Visible = True
                rblTranscationType.Enabled = True
            End If
        End If
    End Sub
    Sub AutoVocharNo()
        Try
            Dim tCashTransactionID As Long = objCashTransaction.GetId + 1
            If tCashTransactionID > 0 And tCashTransactionID < 9 Then
                txtVocharNo.Text = "100000" + tCashTransactionID
            ElseIf tCashTransactionID > 10 And tCashTransactionID < 99 Then
                txtVocharNo.Text = "10000" + tCashTransactionID
            ElseIf tCashTransactionID > 100 And tCashTransactionID < 999 Then
                txtVocharNo.Text = "1000" + tCashTransactionID
            ElseIf tCashTransactionID > 1000 And tCashTransactionID < 9999 Then
                txtVocharNo.Text = "100" + tCashTransactionID
            ElseIf tCashTransactionID > 10000 And tCashTransactionID < 99999 Then
                txtVocharNo.Text = "10" + tCashTransactionID
            Else
                txtVocharNo.Text = tCashTransactionID
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindAccountHead()
        Try
            Dim dtAccountHead As DataTable
            dtAccountHead = objChartOfAccount.GetAccountHead(rblTranscationType.SelectedValue)
            cmbAccountHead.DataSource = dtAccountHead
            cmbAccountHead.DataTextField = "AccountHead"
            cmbAccountHead.DataValueField = "ChartofAccountID"
            cmbAccountHead.DataBind()
            upcmbAccountHead.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindHKCode()
        Try
            Dim dtHKCode As DataTable
            dtHKCode = objChartOfAccount.GetHKCode()
            cmbHKCode.DataSource = dtHKCode
            cmbHKCode.DataTextField = "HKCode"
            cmbHKCode.DataValueField = "HKCodeID"
            cmbHKCode.DataBind()
            upcmbHKCode.Update()

        Catch ex As Exception
        End Try
    End Sub
    Sub BindECPCode()
        Try
            Dim dtECPCode As DataTable
            dtECPCode = objChartOfAccount.GetECPCode()
            cmbECPCode.DataSource = dtECPCode
            cmbECPCode.DataTextField = "ECPCode"
            cmbECPCode.DataValueField = "ECPCodeID"
            cmbECPCode.DataBind()
            upcmbECPCode.Update()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPostthisvoucher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPostthisvoucher.Click
        Try
            If dgCashDetail.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Detail Required.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objCashTransaction
                    .CashTransactionID = CashTransactionID
                    .TransactionDate = txtTransactionDate.SelectedDate
                    .TranscationType = rblTranscationType.SelectedValue
                    .CreationDate = Date.Now
                    .SaveCashTransaction()
                End With

                Dim x As Integer
                For x = 0 To dgCashDetail.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgCashDetail.MasterTableView.Items(x), GridDataItem)
                    With objCashTransactionDetail
                        If CashTransactionID > 0 Then
                            .CashTransactionID = CashTransactionID
                        Else
                            .CashTransactionID = objCashTransaction.GetId
                        End If
                        .CashTransactionDetailID = item("CashTransactionDetailID").Text
                        .ChartofAccountID = item("ChartofAccountID").Text
                        .NameOfPayee = item("NameOfPayee").Text
                        .HKCode = item("HKCode").Text
                        .ECPCode = item("ECPCode").Text
                        .Narration = item("Narration").Text

                        ' .Amount = item("Amount").Text
                        If rblTranscationType.SelectedValue = "CPV" Then
                            If item("Amount").Text < 0 Then
                                .Amount = item("Amount").Text
                            Else
                                .Amount = "-" + item("Amount").Text
                            End If
                        ElseIf rblTranscationType.SelectedValue = "CRV" Then
                            .Amount = item("Amount").Text
                        End If
                        .Notes = item("Notes").Text
                        .SaveCashTransactionDetail()
                    End With
                Next

                Response.Redirect("CashTransactionSheetView.aspx?BitStatus=1&BitMonth=" & txtTransactionDate.SelectedDate.Value.Month & "&BitYear=" & txtTransactionDate.SelectedDate.Value.Year & "")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub rblTranscationType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblTranscationType.SelectedIndexChanged
        Try
            BindAccountHead()
            upcmbAccountHead.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnPostPrintthisvoucher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPostPrintthisvoucher.Click
        If dgCashDetail.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Detail Required.")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            With objCashTransaction
                .CashTransactionID = CashTransactionID
                .TransactionDate = txtTransactionDate.SelectedDate
                .TranscationType = rblTranscationType.SelectedValue
                .CreationDate = Date.Now
                .SaveCashTransaction()
            End With

            Dim x As Integer
            For x = 0 To dgCashDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgCashDetail.MasterTableView.Items(x), GridDataItem)
                With objCashTransactionDetail
                    If CashTransactionID > 0 Then
                        .CashTransactionID = CashTransactionID
                    Else
                        .CashTransactionID = objCashTransaction.GetId
                    End If
                    .CashTransactionDetailID = item("CashTransactionDetailID").Text
                    .ChartofAccountID = item("ChartofAccountID").Text
                    .NameOfPayee = item("NameOfPayee").Text
                    .HKCode = item("HKCode").Text
                    .ECPCode = item("ECPCode").Text
                    .Narration = item("Narration").Text
                    If rblTranscationType.SelectedValue = "CPV" Then
                        If item("Amount").Text < 0 Then
                            .Amount = item("Amount").Text
                        Else
                            .Amount = "-" + item("Amount").Text
                        End If
                    ElseIf rblTranscationType.SelectedValue = "CRV" Then
                        .Amount = item("Amount").Text
                    End If
                    .Notes = item("Notes").Text
                    .SaveCashTransactionDetail()
                End With
            Next

            Response.Redirect("CashTransactionSheetView.aspx?BitStatus=1&BitMonth=" & txtTransactionDate.SelectedDate.Value.Month & "&BitYear=" & txtTransactionDate.SelectedDate.Value.Year & "")

        End If
    End Sub
    Protected Sub btnPostAddmore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPostAddmore.Click
        Try
          If dgCashDetail.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Detail Required.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objCashTransaction
                    .CashTransactionID = CashTransactionID
                    .TransactionDate = txtTransactionDate.SelectedDate
                    .TranscationType = rblTranscationType.SelectedValue
                    .CreationDate = Date.Now
                    .SaveCashTransaction()
                End With
                Dim x As Integer
                For x = 0 To dgCashDetail.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgCashDetail.MasterTableView.Items(x), GridDataItem)
                    With objCashTransactionDetail
                        If CashTransactionID > 0 Then
                            .CashTransactionID = CashTransactionID
                        Else
                            .CashTransactionID = objCashTransaction.GetId
                        End If
                        .CashTransactionDetailID = item("CashTransactionDetailID").Text
                        .ChartofAccountID = item("ChartofAccountID").Text
                        .NameOfPayee = item("NameOfPayee").Text
                        .HKCode = item("HKCode").Text
                        .ECPCode = item("ECPCode").Text
                        .Narration = item("Narration").Text
                        If rblTranscationType.SelectedValue = "CPV" Then
                            If item("Amount").Text < 0 Then
                                .Amount = item("Amount").Text
                            Else
                                .Amount = "-" + item("Amount").Text
                            End If
                        ElseIf rblTranscationType.SelectedValue = "CRV" Then
                            .Amount = item("Amount").Text
                        End If
                        .Notes = item("Notes").Text
                        .SaveCashTransactionDetail()
                    End With
                Next

                'Reset
                ClearControls()
                BindAccountHead()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try

            Response.Redirect("CashTransactionSheetView.aspx?BitStatus=0")
        Catch ex As Exception

        End Try
    End Sub
    Sub ClearControlss()
        txtTotalAmount.Text = 0
        txtNameOfPayee.Text = ""
        txtNotes.Text = ""
        txtNarration.Text = ""
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objCashTransaction.GetEditData(CashTransactionID)
            txtTransactionDate.SelectedDate = dt.Rows(0)("TransactionDate")
            txtVocharNo.Text = dt.Rows(0)("VoucherNo")
            If dt.Rows(0)("TranscationType") = "CPV" Then
                rblTranscationType.SelectedValue = "CPV"
            Else
                rblTranscationType.SelectedValue = "CRV"
            End If
            cmbHKCode.SelectedValue = objCashTransaction.GetHKCodeIndex(dt.Rows(0)("HKCode"))
            cmbECPCode.SelectedValue = objCashTransaction.GetECPCodeIndex(dt.Rows(0)("ECPCode"))
            '--------------------Cash Detail Values
            DtCashDetail = Nothing
            Session("DtCashDetail") = Nothing
            DtCashDetail = New DataTable

            With DtCashDetail
                .Columns.Add("CashTransactionDetailID", GetType(Long))
                .Columns.Add("ChartofAccountID", GetType(Long))
                .Columns.Add("AccountHead", GetType(String))
                .Columns.Add("NameOfPayee", GetType(String))
                .Columns.Add("HKCode", GetType(String))
                .Columns.Add("ECPCode", GetType(String))
                .Columns.Add("Narration", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("Notes", GetType(String))
            End With
            For x = 0 To dt.Rows.Count - 1
                dr = DtCashDetail.NewRow()
                dr("CashTransactionDetailID") = dt.Rows(x)("CashTransactionDetailID")
                dr("ChartofAccountID") = dt.Rows(x)("ChartofAccountID")
                dr("AccountHead") = dt.Rows(x)("AccountHead")
                dr("NameOfPayee") = dt.Rows(x)("NameOfPayee")
                dr("HKCode") = dt.Rows(x)("HKCode")
                dr("ECPCode") = dt.Rows(x)("ECPCode")
                dr("Narration") = dt.Rows(x)("Narration")
                dr("Amount") = dt.Rows(x)("Amount")
                dr("Notes") = dt.Rows(x)("Notes")
                DtCashDetail.Rows.Add(dr)
            Next
            Session("DtCashDetail") = DtCashDetail
            BindGrid()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If txtNameOfPayee.Text <> "" And txtTotalAmount.Text <> "" Then
                rblTranscationType.Enabled = False
                SaveSession()
                BindGrid()
                ClearControlss()
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill All Boxes.")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtCashDetail"), DataTable) Is Nothing) Then
            DtCashDetail = Session("DtCashDetail")
        Else
            DtCashDetail = New DataTable
            With DtCashDetail
                .Columns.Add("CashTransactionDetailID", GetType(Long))
                .Columns.Add("ChartofAccountID", GetType(Long))
                .Columns.Add("AccountHead", GetType(String))
                .Columns.Add("NameOfPayee", GetType(String))
                .Columns.Add("HKCode", GetType(String))
                .Columns.Add("ECPCode", GetType(String))
                .Columns.Add("Narration", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("Notes", GetType(String))
            End With
        End If
        dr = DtCashDetail.NewRow()
        dr("CashTransactionDetailID") = 0
        dr("ChartofAccountID") = cmbAccountHead.SelectedValue
        dr("AccountHead") = cmbAccountHead.SelectedItem.Text
        dr("NameOfPayee") = txtNameOfPayee.Text
        dr("HKCode") = cmbHKCode.SelectedItem.Text
        dr("ECPCode") = cmbECPCode.SelectedItem.Text
        dr("Narration") = txtNarration.Text
        'If rblTranscationType.SelectedValue = "CPV" Then
        '    If txtTotalAmount.Text < 0 Then
        '        dr("Amount") = txtTotalAmount.Text
        '    Else
        '        dr("Amount") = "-" + txtTotalAmount.Text
        '    End If
        'ElseIf rblTranscationType.SelectedValue = "CRV" Then
        '    dr("Amount") = txtTotalAmount.Text
        'End If
        dr("Amount") = txtTotalAmount.Text
        dr("Notes") = txtNotes.Text
        DtCashDetail.Rows.Add(dr)
        Session("DtCashDetail") = DtCashDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtCashDetail")
            If objDatatble.Rows.Count > 0 Then
                dgCashDetail.Visible = True
                dgCashDetail.VirtualItemCount = objDatatble.Rows.Count
                dgCashDetail.DataSource = objDatatble
                dgCashDetail.DataBind()
            Else
                dgCashDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtNarration.Text = ""
        txtTotalAmount.Text = ""
        txtNotes.Text = ""
        txtNameOfPayee.Text = ""
    End Sub


End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml

Public Class ECPSamplingEntry
    Inherits System.Web.UI.Page
    Dim objECPSampling As New ECPSampling
    Dim objECPSamplingDetail As New ECPSamplingDetail
    Dim lECPSamplingID As Long
    Dim Dt As DataTable
    Dim Dr As DataRow
    Dim dtDetail As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lECPSamplingID = Request.QueryString("lECPSamplingID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindCustomer()
            BindSupplier()
            BindUser()
            BindTypeofSampling()
            If lECPSamplingID > 0 Then
                btnSave.Text = "Update"
                EditECPSampling()
                btnAddMore.Visible = False

                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                txtDate.SelectedDate = Date.Now

                txtEntryDate.Enabled = False
                cmbCustomer.Enabled = False
                txtBuyingDept.ReadOnly = True
                cmbSupplier.Enabled = False
                txtStyleNo.ReadOnly = True
                cmbUser.Enabled = False

            Else
                txtEntryDate.SelectedDate = Date.Now
                txtDate.SelectedDate = Date.Now
                btnAddMore.Visible = True
                btnSave.Text = "Save"
            End If
            PageHeader("ECP Sampling Module")

        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgView.Visible = True
                strSortExpression = dgView.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgView.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgView.RecordCount = objDataView.Count
                dgView.DataSource = objDataView
                dgView.DataBind()
            Else
                dgView.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridNew()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgView.Visible = True
                dgView.RecordCount = objDatatble.Rows.Count
                dgView.DataSource = objDatatble
                dgView.DataBind()
            Else
                dgView.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objECPSampling.GetECPSamplingDataForEditData(lECPSamplingID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub EditECPSampling()
        Try
            Dt = objECPSampling.GetECPSamplingDataForEditData(lECPSamplingID)
            txtEntryDate.SelectedDate = Dt.Rows(0)("EntryDate")
            cmbCustomer.SelectedValue = Dt.Rows(0)("CustomerID")
            cmbSupplier.SelectedValue = Dt.Rows(0)("SupplierID")
            cmbUser.SelectedValue = Dt.Rows(0)("UserID")
            txtStyleNo.Text = Dt.Rows(0)("StyleNo")
            ' txtNoOfPeices.Text = Dt.Rows(0)("NoOfPieces")
            txtBuyingDept.Text = Dt.Rows(0)("BuyingDept")
            'cmbTypeofSampling.SelectedValue = Dt.Rows(0)("TypeOfSamplingID")
            'If Dt.Rows(0)("Status").ToString() = "Pass" Then
            '    cmbStatus.SelectedIndex = 0
            'ElseIf Dt.Rows(0)("Status").ToString() = "Fail" Then
            '    cmbStatus.SelectedIndex = 1
            'End If
            'If Dt.Rows(0)("Progress").ToString() = "--" Then
            '    cmbProgress.SelectedIndex = 0
            'ElseIf Dt.Rows(0)("Progress").ToString() = "Recieved from Supplier" Then
            '    cmbProgress.SelectedIndex = 1
            'ElseIf Dt.Rows(0)("Progress").ToString() = "Sent to Buyer" Then
            '    cmbProgress.SelectedIndex = 2
            'ElseIf Dt.Rows(0)("Progress").ToString() = "Buyer Accept" Then
            '    cmbProgress.SelectedIndex = 3
            'ElseIf Dt.Rows(0)("Progress").ToString() = "Buyer Reject" Then
            '    cmbProgress.SelectedIndex = 4
            'End If

            'txtRemarks.Text = Dt.Rows(0)("Remarks")
            'If Dt.Rows(0)("Submission").ToString() = "1st Submission" Then
            '    cmbSumbission.SelectedIndex = 0
            'ElseIf Dt.Rows(0)("Submission").ToString() = "2nd Submission" Then
            '    cmbSumbission.SelectedIndex = 1
            'ElseIf Dt.Rows(0)("Submission").ToString() = "3rd Submission" Then
            '    cmbSumbission.SelectedIndex = 2
            'ElseIf Dt.Rows(0)("Submission").ToString() = "4th Submission" Then
            '    cmbSumbission.SelectedIndex = 3
            'ElseIf Dt.Rows(0)("Submission").ToString() = "5th Submission" Then
            '    cmbSumbission.SelectedIndex = 4
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveECPSamplingEntry()
                SaveECPSamplingDetail()
                If cmbStatus.SelectedItem.Text = "Fail" Then
                    If lECPSamplingID > 0 Then
                        SendFailAlertMsg(lECPSamplingID)
                    Else
                        SendFailAlertMsg(objECPSampling.GetId())
                    End If
                End If
                Response.Redirect("ECPSamplingView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveECPSamplingEntry()
        With objECPSampling
            If lECPSamplingID > 0 Then
                .ECPSamplingID = lECPSamplingID
            Else
                .ECPSamplingID = 0
            End If
            .CreationDate = Date.Now
            .EntryDate = txtEntryDate.SelectedDate
            .CustomerID = cmbCustomer.SelectedValue
            .SupplierID = cmbSupplier.SelectedValue
            .StyleNo = txtStyleNo.Text
            .PDUserid = CLng(Session("Userid"))
            .BuyingDept = txtBuyingDept.Text
            .UserID = cmbUser.SelectedValue
            .SaveECPSamplingEntry()
        End With
    End Sub
    Sub SaveECPSamplingDetail()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1

            With objECPSamplingDetail
                .ECPSamplingDetailID = dgView.Items(x).Cells(0).Text
                If lECPSamplingID > 0 Then
                    .ECPSamplingID = lECPSamplingID
                Else
                    .ECPSamplingID = objECPSampling.GetId()
                End If
                .Datee = dgView.Items(x).Cells(2).Text 'txtDate.SelectedDate
                .NoOfPieces = dgView.Items(x).Cells(3).Text
                .TypeOfSamplingID = dgView.Items(x).Cells(1).Text
                .SampleLocation = dgView.Items(x).Cells(5).Text
                .Status = dgView.Items(x).Cells(6).Text
                .Progress = dgView.Items(x).Cells(7).Text
                .Remarks = dgView.Items(x).Cells(9).Text
                .Submission = dgView.Items(x).Cells(8).Text
                .SaveECPSamplingDetail()
            End With
        Next
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcustomer As DataTable
            dtcustomer = objECPSampling.GetCustomerComboN
            cmbCustomer.DataSource = dtcustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            UpdatePanel3.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objECPSampling.GetSupplierComboN
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "VenderName"
            cmbSupplier.DataValueField = "VenderLibraryID"
            cmbSupplier.DataBind()
            UpdatePanel2.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindUser()
        Try
            Dim dtuser As DataTable
            dtuser = objECPSampling.GetUserCombo
            cmbUser.DataSource = dtuser
            cmbUser.DataTextField = "UserName"
            cmbUser.DataValueField = "UserId"
            cmbUser.DataBind()
            UpdatePanel4.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindTypeofSampling()
        Try
            Dim dtTypeOfSampling As DataTable
            dtTypeOfSampling = objECPSampling.GetTypeOfSamplingCombo
            cmbTypeofSampling.DataSource = dtTypeOfSampling
            cmbTypeofSampling.DataTextField = "TypeName"
            cmbTypeofSampling.DataValueField = "TypeOfSamplingID"
            cmbTypeofSampling.DataBind()
            UpdatePanel1.Update()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ECPSamplingView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try
            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                ' SaveECPSamplingEntry()
                SaveSession()
                If cmbStatus.SelectedItem.Text = "Fail" Then
                    If lECPSamplingID > 0 Then
                        SendFailAlertMsg(lECPSamplingID)
                    Else
                        SendFailAlertMsg(objECPSampling.GetId())
                    End If
                End If
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("ECP Sampling Saved.")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("ECPSamplingDetailID", GetType(Long))
                .Columns.Add("DateeN", GetType(Date))
                .Columns.Add("NoOfPieces", GetType(String))
                .Columns.Add("TypeOfSamplingID", GetType(Long))
                .Columns.Add("TypeName", GetType(String))
                .Columns.Add("SampleLocation", GetType(String))
                .Columns.Add("Status", GetType(String))
                .Columns.Add("Progress", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("Submission", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("ECPSamplingDetailID") = 0
        Dr("DateeN") = txtDate.SelectedDate
        Dr("NoOfPieces") = txtNoOfPeices.Text
        Dr("TypeOfSamplingID") = cmbTypeofSampling.SelectedValue
        Dr("TypeName") = cmbTypeofSampling.SelectedItem.Text
        Dr("SampleLocation") = txtSampleLocation2.Text
        Dr("Status") = cmbStatus.SelectedItem.Text
        Dr("Progress") = cmbProgress.SelectedItem.Text
        Dr("Remarks") = txtRemarks.Text
        Dr("Submission") = cmbSumbission.SelectedItem.Text

        'Dr("InHandQty") = txtInhandQty.Text

        dtDetail.Rows.Add(Dr)

        Session("dtDetail") = dtDetail
        BindGridNew()
        clear()

    End Sub
    Sub clear()
        txtRemarks.Text = ""
        txtDate.SelectedDate = ""


    End Sub
    Sub SendFailAlertMsg(ByVal IIECPSamplingID As Long)
        Try
            Dim objECPSampling As New ECPSampling
            Dim dtObjTable As DataTable = objECPSampling.SendFailAlert(IIECPSamplingID)
            If dtObjTable.Rows.Count > 0 Then
                'Email
                Dim objUser As New User
                Dim mail As MailMessage = New MailMessage()

                Dim dtTo As DataTable
                dtTo = objUser.GetEmailAddress(28)
                mail.To.Add(dtTo.Rows(0)("EmailAddress"))

                Dim dtCC As DataTable
                dtCC = objUser.GetSupplierEmail(dtObjTable.Rows(0)("SupplierID"))
                If dtCC.Rows.Count > 0 Then
                    mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
                End If
                ' mail.Bcc.Add("zahidsajjad@hotmail.com")
                '  mail.From = New MailAddress("noreply@eurocentrab2b.com")
                mail.Subject = "Alert -Sampling Status Fail"
                Dim Body As String = " " & _
                             "<br/>" & _
                             "<b> Dear Supply Chain, </b>" & _
                               "<br/>" & _
                               "<br/>" & _
                             "Following Samples have Fail in system." & _
                            "<br/>" & _
                         "<b> PD:   " & dtObjTable.Rows(0)("PD") & "" & _
                            "<br/>" & _
                         "Date:   " & dtObjTable.Rows(0)("EntryDatee") & "" & _
                            "<br/>" & _
                         "Customer:   " & dtObjTable.Rows(0)("CustomerName") & "" & _
                            "<br/>" & _
                         "Supplier:   " & dtObjTable.Rows(0)("SupplierName") & "" & _
                            "<br/>" & _
                         "B/M:   " & dtObjTable.Rows(0)("UserName") & "" & _
                            "<br/>" & _
                         "Style No:   " & dtObjTable.Rows(0)("StyleNo") & "" & _
                            "<br/>" & _
                         "Pcs:   " & dtObjTable.Rows(0)("NoOfPieces") & "" & _
                            "<br/>" & _
                         "Type Of Sampling:   " & dtObjTable.Rows(0)("TypeName") & "" & _
                            "<br/>" & _
                         "Progress:   " & dtObjTable.Rows(0)("Progress") & "" & _
                            "<br/>" & _
                         "Submission:   " & dtObjTable.Rows(0)("Submission") & " </b>" & _
                         "<br/>" & _
                            "<br/>" & _
                             "Thanks," & _
                               "<br/>" & _
                                "<br/>" & _
                             "Euro Centra B2B." & _
                               "<br/>" & _
                            "Powered By: Integra ERP" & _
                               "<br/>" & _
                                 "<br/>"
                mail.Body = Body
                mail.IsBodyHtml = True
                Dim smtp As SmtpClient = New SmtpClient()
                smtp.Port = 25
                smtp.Host = "mail.eurocentrab2b.com"
                smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
                smtp.EnableSsl = False
                smtp.Send(mail)
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
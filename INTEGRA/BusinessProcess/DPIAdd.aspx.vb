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
Public Class DPIAdd
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim ObjDPIDtl As New DPIDtl
    Dim dtPIDetail As DataTable
    Dim Dr As DataRow
    Dim lDPIMstID As Long
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim objFabricIssueWorkerDtl As New FabricIssueWorkerDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPIMstID = Request.QueryString("lDPIMstID")
        If Not Page.IsPostBack Then
            Session("dtPIDetail") = Nothing
            txtPIDate.SelectedDate = Date.Now
            SeasonNOGenerateOnLoad()
            BindSeason()
            BindCustomer()
            BindSrno()
            SalesContract()
            BindReportType()
            GetConsignee()
            If lDPIMstID > 0 Then
                btnSave.Text = "Update"
                Edit()
                If cmbReportType.SelectedItem.Text = "Proforma Invoice Inditex" Then
                    pnlnew.Visible = True
                Else
                    pnlnew.Visible = False
                End If
            Else
                btnSave.Text = "Save"
                txtRevisedDate.SelectedDate = Date.Now
            End If
            BindSrno()
        End If
        PageHeader("PI ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub Edit()
        Dim dtedit As DataTable = ObjDPFabricIssue.GetEditForDPI(lDPIMstID)

        If dtedit.Rows.Count > 0 Then
            txtPIDate.SelectedDate = dtedit.Rows(0)("PIDate")
            txtSalesContract.Text = dtedit.Rows(0)("SalesContract")
            BindSeason()
            cmbSeason.SelectedValue = dtedit.Rows(0)("SeasonID")
            BindCustomer()
            cmbCustomer.SelectedValue = dtedit.Rows(0)("CustomerID")
            txtSeason.Text = dtedit.Rows(0)("SeasonNo")
            cmbReportType.SelectedValue = dtedit.Rows(0)("ReportTypeID")
            txtForaccountAndRisk.Text = dtedit.Rows(0)("ForaccountAndRisk")
            txtNotifyparty.Text = dtedit.Rows(0)("Notifyparty")
            txtPaymentTo.Text = dtedit.Rows(0)("PaymentTo")
            txtBrandandsection.Text = dtedit.Rows(0)("Brandandsection")
            txtConsignee.Text = dtedit.Rows(0)("Consignee")
            txtRevisedDate.SelectedDate = dtedit.Rows(0)("RevisedDate")
            txtPaymentTerm.Text = dtedit.Rows(0)("PaymentTerm")
            txtPortOfLoading.Text = dtedit.Rows(0)("PortOfLoading")
            txtFinalDestination.Text = dtedit.Rows(0)("FinalDestination")

            If (Not CType(Session("dtPIDetail"), DataTable) Is Nothing) Then
                dtPIDetail = Session("dtPIDetail")
            Else
                dtPIDetail = New DataTable
                With dtPIDetail
                    .Columns.Add("DPIDtlID", GetType(Long))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("Joborderid", GetType(Long))
                End With
            End If
            Dim x As Integer
            For x = 0 To dtedit.Rows.Count - 1
                Dr = dtPIDetail.NewRow()
                Dr("DPIDtlID") = dtedit.Rows(x)("DPIDtlID")
                Dr("SRNO") = dtedit.Rows(x)("SRNO")
                Dr("Joborderid") = dtedit.Rows(x)("Joborderid")
                dtPIDetail.Rows.Add(Dr)
                Session("dtPIDetail") = dtPIDetail
            Next
            BindGrid()

        End If

    End Sub
    Sub BindReportType()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjDPIMst.GetReportType
            cmbReportType.DataSource = dtcmbSeason
            cmbReportType.DataTextField = "ReportType"
            cmbReportType.DataValueField = "ReportTypeID"
            cmbReportType.DataBind()
            cmbReportType.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjDPIMst.GetSeasons
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbCustomer As DataTable
            dtcmbCustomer = ObjDPIMst.GetCustomer(cmbSeason.SelectedValue)
            cmbCustomer.DataSource = dtcmbCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrno()
        Try
            Dim dtcmbSrno As DataTable
            dtcmbSrno = ObjDPIMst.GetSRNo(cmbSeason.SelectedValue, cmbCustomer.SelectedValue)
            cmbSrno.DataSource = dtcmbSrno
            cmbSrno.DataTextField = "SRNO"
            cmbSrno.DataValueField = "Joborderid"
            cmbSrno.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub GetConsignee()
        Dim dt As DataTable = ObjDPFabricIssue.GetBuyerAddress(cmbCustomer.SelectedValue)
        If dt.Rows.Count > 0 Then
            txtConsignee.Text = dt.Rows(0)("Consignee")
            txtForaccountAndRisk.Text = dt.Rows(0)("ForaccountAndRisk")
            txtNotifyparty.Text = dt.Rows(0)("Notifyparty")
            txtPaymentTo.Text = dt.Rows(0)("PaymentTo")
            txtBrandandsection.Text = dt.Rows(0)("Brandandsection")
            txtPaymentTerm.Text = dt.Rows(0)("PaymentTerm")
            txtPortOfLoading.Text = dt.Rows(0)("PortOfLoading")
            txtFinalDestination.Text = dt.Rows(0)("FinalDestination")
        End If

    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSeason.SelectedIndexChanged
        Try

            SalesContract()
            BindCustomer()
            BindSrno()
            GetConsignee()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbReportType_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbReportType.SelectedIndexChanged
        Try
            If cmbReportType.SelectedItem.Text = "Proforma Invoice Inditex" Then
                pnlnew.Visible = True
            Else
                pnlnew.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            SalesContract()
            BindSrno()
            GetConsignee()
        Catch ex As Exception

        End Try
    End Sub
    Sub SalesContract()
        Try
            Dim yEAR As String = Date.Now.Year
            txtSalesContract.Text = txtSeason.Text + "/" + cmbSeason.SelectedItem.Text + "/" + yEAR
            Dim S As String = cmbSeason.SelectedItem.Text
            Dim ss As String = S.Substring(0, 1)
            Dim SName As String = cmbSeason.SelectedItem.Text
            Dim Season As String = SName.Substring(SName.Length - 2)
            txtSalesContract.Text = ss + "-" + txtSeason.Text + "/" + Season
        Catch ex As Exception

        End Try
    End Sub
    Sub SeasonNOGenerateOnLoad()
        Try
             Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month

            Dim LastVoucherNo As Integer = ObjDPIMst.SeasonnoNew()
            Dim LastCode As String
            If LastVoucherNo = 0 Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo
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
            VoucherNo = LastCode
            txtSeason.Text = VoucherNo
           
        Catch ex As Exception

        End Try
    End Sub
      Sub SaveSession()

        If (Not CType(Session("dtPIDetail"), DataTable) Is Nothing) Then
            dtPIDetail = Session("dtPIDetail")
        Else
            dtPIDetail = New DataTable
            With dtPIDetail
                .Columns.Add("DPIDtlID", GetType(Long))
                .Columns.Add("SRNO", GetType(String))
                .Columns.Add("Joborderid", GetType(Long))
            End With
        End If
        Dr = dtPIDetail.NewRow()
        Dr("DPIDtlID") = 0
        Dr("SRNO") = cmbSrno.SelectedItem.Text
        Dr("Joborderid") = cmbSrno.SelectedValue
        dtPIDetail.Rows.Add(Dr)
        Session("dtPIDetail") = dtPIDetail
        BindGrid()

    End Sub
    Sub BindGrid()
        Try
            If dtPIDetail.Rows.Count > 0 Then
                dgPI.DataSource = dtPIDetail
                dgPI.DataBind()
                dgPI.Visible = True
            Else

                dgPI.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
           Dim dt As DataTable = ObjDPIMst.CheckExistingSRNOforPI(cmbSrno.SelectedValue)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This SR No Already Use")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("DPIView.aspx")
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If cmbReportType.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Report Type")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                save()
                Response.Redirect("DPIView.aspx")
            End If
            
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        Try
            With ObjDPIMst

                If lDPIMstID > 0 Then
                    .DPIMstID = lDPIMstID
                Else
                    .DPIMstID = 0
                End If
                .PIDate = txtPIDate.SelectedDate
                .SalesContract = txtSalesContract.Text
                .SeasonID = cmbSeason.SelectedValue
                .CustomerID = cmbCustomer.SelectedValue
                .SeasonNo = txtSeason.Text
                .ReportTypeID = cmbReportType.SelectedValue
                .ForaccountAndRisk = txtForaccountAndRisk.Text
                .Notifyparty = txtNotifyparty.Text
                .PaymentTo = txtPaymentTo.Text
                .Brandandsection = txtBrandandsection.Text
                .Consignee = txtConsignee.Text
                .RevisedDate = txtRevisedDate.SelectedDate
                .PaymentTerm = txtPaymentTerm.Text
                .PortOfLoading = txtPortOfLoading.Text
                .FinalDestination = txtFinalDestination.Text
                .Save()
            End With

            Dim x As Integer
            For x = 0 To dgPI.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPI.MasterTableView.Items(x), GridDataItem)
                With ObjDPIDtl
                    .DPIDtlID = item("DPIDtlID").Text

                    If lDPIMstID > 0 Then
                        .DPIMstID = lDPIMstID
                    Else
                        .DPIMstID = ObjDPIMst.GetID()
                    End If


                    .SRNO = item("SRNO").Text
                    .Joborderid = item("Joborderid").Text
                    .Save()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPI_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPI.DeleteCommand
        dtPIDetail = CType(Session("dtPIDetail"), DataTable)
        If (Not dtPIDetail Is Nothing) Then
            If (dtPIDetail.Rows.Count > 0) Then
                Dim lDPIDtlID As Integer = dtPIDetail.Rows(e.Item.ItemIndex)("DPIDtlID")
                dtPIDetail.Rows.RemoveAt(e.Item.ItemIndex)
                ObjDPIMst.DeletedPIDetail(lDPIDtlID)
                BindGrid()
            Else
            End If

        End If
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.DataTable
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class TNAChartViewPDM
    Inherits System.Web.UI.Page
    Dim ObjTNAChart As New TNAChart
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjTNAChartHistory As New TNAChartHistory
    Dim POID As String
    Dim GeneralCode As New GeneralCode
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim dtEmail As New DataTable
    Dim dtEmail2 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        POID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            Try
                If POID <> "" Then
                    Dim objDataView As DataView
                    Try
                        SetData(CLng(POID))
                        objDataView = LoadData(CLng(POID))
                        Session("objDataView") = objDataView
                        BindGrid()
                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
            '   PageHeader("Milestone View")
        End If
    End Sub
    Sub SetData(ByVal IPOID)
        Dim Dt As DataTable
        Dt = ObjPurchaseOrder.GetPOData(IPOID)
        If Dt.Rows.Count > 0 Then
            lblBuyer.Text = Dt.Rows(0)("CustomerName")
            lblVendor.Text = Dt.Rows(0)("VenderName")
            lblPONo.Text = Dt.Rows(0)("PONO")
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                SetGrid()
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SetGrid()
        Dim x As Integer
        Dim ChkSelect As CheckBox
        Dim ddlstatus As RadComboBox
        Dim dtStatusCheck As New DataTable
        Dim chkbox As New CheckBox
        Dim txtActualDate, txtEstimatedDate As RadDatePicker
        Dim txtQuantityCmpltd As RadTextBox

        dtStatusCheck = ObjTNAChart.GetProcessByForPDM(POID)
        For x = 0 To dgTNAChart.Items.Count - 1
            ChkSelect = DirectCast(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
            ddlstatus = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
            ''---
            txtActualDate = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
            txtEstimatedDate = DirectCast(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
            txtQuantityCmpltd = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)

            Dim ActualDate As String = Convert.ToString(dtStatusCheck.Rows(x)("ActualDate"))
            If ActualDate = "" Then
                txtActualDate.SelectedDate = Date.Today
                txtActualDate.Clear()
            Else
                txtActualDate.SelectedDate = Convert.ToDateTime(dtStatusCheck.Rows(x)("ActualDate"))
            End If

            Dim EstimatedDate As String = Convert.ToString(dtStatusCheck.Rows(x)("EstimatedDate"))
            If EstimatedDate = "" Then
                txtEstimatedDate.SelectedDate = Date.Today
                txtEstimatedDate.Clear()
            Else
                txtEstimatedDate.SelectedDate = Convert.ToDateTime(dtStatusCheck.Rows(x)("EstimatedDate"))
            End If
            txtQuantityCmpltd.Text = dtStatusCheck.Rows(x)("QtyCompleted")

            Dim status As Boolean = dtStatusCheck.Rows(x)("Selected")
            If status = True Then
                ChkSelect.Checked = True
                dgTNAChart.Items(x).Enabled = True
            Else
                ChkSelect.Checked = False
                dgTNAChart.Items(x).Enabled = False
            End If
            'Status Check Condition
            If dtStatusCheck.Rows(x)("Status").ToString() = "Completed" Then
                ddlstatus.SelectedIndex = 2
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Pending" Then
                ddlstatus.SelectedIndex = 1
            Else
                ddlstatus.SelectedIndex = 0
            End If
            'end
        Next
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetProcessByTNAChartIddForPDM(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            Dim i As Integer
            Dim chkUpdate As CheckBox
            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim ChkSelect As CheckBox = DirectCast(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
                    Dim txtEstimatedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                    Dim txtRemarks As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtRemarks"), RadTextBox)
                    Dim cmbStatus As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
                    Dim QtyCompleted As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
                    Dim txtActualDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)

                    Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                    Dim lChartID As Integer = item("TNAChartID").Text
                    Dim ProcessID As Integer = item("ProcessID").Text
                    Dim EstimatedDate As Date = txtEstimatedDate.SelectedDate
                    Dim ActualDate As Date = txtActualDate.SelectedDate

                    If Not EstimatedDate.ToString() = "" Then
                        lblMSG.Visible = False
                        With ObjTNAChart
                            .GetTNAChartById(lChartID)
                            .DateEstemated = txtEstimatedDate.SelectedDate
                            .Status = cmbStatus.SelectedItem.Text
                            .ActualDate = txtActualDate.SelectedDate
                            .Remarks = txtRemarks.Text
                            .QtyCompleted = QtyCompleted.Text
                            .Selected = ChkSelect.Checked
                            .SelectedStatus = "SELECTED"
                            .TNAProcessID = ProcessID
                            .Parameter = 0
                            .ParameterUnit = 0
                            .TotalCapacity = 0
                            .CapacityUnit = 0
                            .Required = 0
                            .RequiredUnit = 0
                            .SaveTNAChart()
                        End With
                        '-------------- History Manage
                        With ObjTNAChartHistory
                            .CreationDate = Date.Now
                            .TNAChartID = lChartID
                            .IdealDate = ObjTNAChart.IdealDate
                            .DateEstemated = txtEstimatedDate.SelectedDate
                            .ActualDate = txtActualDate.SelectedDate
                            .QtyCompleted = ObjTNAChart.QtyCompleted
                            .Remarks = txtRemarks.Text
                            .Status = cmbStatus.SelectedItem.Text
                            .TNAProcessID = ProcessID
                            .Parameter = 0
                            .ParameterUnit = 0
                            .TotalCapacity = 0
                            .CapacityUnit = 0
                            .Required = 0
                            .RequiredUnit = 0
                            .SaveTNAChartHistory()
                        End With
                        lblMSG.Visible = False
                    Else
                        lblMSG.Text = "Record Has Sucessfully Saved"
                        lblMSG.Visible = True
                    End If
                Else
                    lblMSG.Text = "Record Has Sucessfully Saved"
                    lblMSG.Visible = True
                End If
            Next
            '---Check Send email or not
            Dim dtcompleted As New DataTable
            Dim dtcustomize As New DataTable
            dtcompleted = ObjTNAChart.GetAllCompletedTNAPDM(POID)
            dtcustomize = ObjTNAChart.GetAllCUstomizeTNAPDM(POID)
            Dim totalCustomize As Integer = dtcustomize.Rows.Count
            Dim totalcompleted As Integer = dtcompleted.Rows.Count
            If totalcompleted = totalCustomize Then
                SendEmailPDM()
                lblMSG.Visible = True
                lblMSG.Text = "Record has sucessfully saved and email send."
            Else
                lblMSG.Visible = False
                lblMSG.Text = " "
            End If
        Catch ex As Exception

        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadDataPDM(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetProcessByTNAChartIddForPDMEmail(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGridEfile()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataViewEfile")
            If objDataView.Count > 0 Then
                dgEFile.Visible = True
                strSortExpression = dgEFile.SortExpression
                dgEFile.DataSource = objDataView
                dgEFile.DataBind()
            Else
                dgEFile.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEmailPDM()
        Try
            'Bind Grid
            Dim objDataViewPDM1 As DataView
            Dim dtEfile As DataTable = ObjTNAChart.GetProcessByTNAChartIddForPDMEmail(POID)
            Dim objDataView As DataView
            objDataView = New DataView(dtEfile)
            Session("objDataViewEfile") = objDataView
            BindGridEfile()
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            dgEFile.RenderControl(hw)

            'Email
            Dim Objuser As New User
            Dim mail As MailMessage = New MailMessage()
            Dim dtTo As DataTable
            dtTo = Objuser.GetEmailAddress(28)
            mail.To.Add(dtTo.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            dtCC = Objuser.MarchantMailAddress(dtEfile.Rows(0)("MarchandID"))
            mail.CC.Add(dtCC.Rows(0)("EmailAddress"))
            Dim dtCC1 As DataTable
            dtCC1 = Objuser.GetSupplierEmail(dtEfile.Rows(0)("SupplierID"))
            mail.CC.Add(dtCC1.Rows(0)("EmailAddress"))

            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = " e-file for Order no -" + dtEfile.Rows(0)("PONO").ToString()
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<b> Dear  Supply Chain, </b> " & _
                           "<br/>" & _
                           "<br/>" & _
                               "System generates this email to notify all stakeholders that you successfully accomplished critical path of following orders." & _
                         "<br/>" & _
                         "Hence it consider as e-file (CP) and suggest SCM to attach a print copy attach in order file. " & _
                         "<br/>" & _
                         "<br/>" & _
                        "PO No.:   " & dtEfile.Rows(0)("PONO") & "" & _
                         "<br/>" & _
                         "Customer:   " & dtEfile.Rows(0)("Customername") & "" & _
                         "<br/>" & _
                          "Supplier:   " & dtEfile.Rows(0)("Vendername") & "" & _
                         "<br/>" & _
                          "Merchant:   " & dtEfile.Rows(0)("Username") & "" & _
                         "<br/>" & _
                         "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                        "<br/>" & _
                         "<u> Notified parties: </u>" & _
                          "<br/>" & _
                      "Product Development Manager" & _
                       "<br/>" & _
                      "Quality Development Manager" & _
                       "<br/>" & _
                                  "Brand Managers" & _
                                   "<br/>" & _
                                  "Suppliers" & _
                                   "<br/>" & _
                                 " SCM" & _
                                  "<br/>" & _
                                   "<br/>" & _
 "Why we consider this email is necessary?" & _
  "<br/>" & _
 "Sampling stages are always being critical but most necessary part of order execution. Each customer order is vital for all" & _
  "<br/>" & _
 " of us. Once you receive this email, it is equally informed to all notified parties so that communication time can be minimized." & _
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

            dgEFile.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '  base.VerifyRenderingInServerForm(control);
    End Sub
    Protected Sub btnCustomise_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCustomise.Click
        Try
            Dim chkSelect As CheckBox
            Dim Str As String = "("
            Dim ID As String
            Dim x As Integer
            For x = 0 To dgTNAChart.Items.Count - 1
                chkSelect = CType(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
                Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                ID = item("TNAChartID").Text
                If chkSelect.Checked = False Then
                    dgTNAChart.Items(x).Enabled = False
                    Str = Str + ID + ","
                Else
                    dgTNAChart.Items(x).Enabled = True
                End If
            Next
            Str = Str + ")"
            Str = Replace(Str, ",)", ")")
            ObjTNAChart.UpdateSelecte(Str)
            lblMSG.Visible = True
            lblMSG.Text = "Sucessfully Customized."
        Catch ex As Exception

        End Try
    End Sub

End Class
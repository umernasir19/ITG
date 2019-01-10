Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class SamplingChart
    Inherits System.Web.UI.Page
    Dim StyleID As String
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjSampleTNAChart As New SampleTNAChart
    Dim ObjSampleTNAChartHistory As New SampleTNAChartHistory
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("StyleID")
        If Not Page.IsPostBack Then
            Try
                If StyleID <> "" Then
                    Dim objDataView As DataView
                    Try
                        SetData(CLng(StyleID))
                        objDataView = LoadData(CLng(StyleID))
                        Session("objDataView") = objDataView
                        BindGrid()
                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
            PageHeader("Sampling Chart View")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SetData(ByVal IStyleID)
        'For Style
        Dim dt As DataTable
        dt = ObjPurchaseOrder.GetStyleNoE(IStyleID)
        lblStyle.Text = dt.Rows(0)("StyleNo").ToString()
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNASampling.DataSource = objDataView
                dgTNASampling.DataBind()
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
        Dim chkbox As New CheckBox
        For x = 0 To dgTNASampling.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgTNASampling.MasterTableView.Items(x), GridDataItem)
            ChkSelect = DirectCast(dgTNASampling.Items(x).FindControl("chkSelect"), CheckBox)
            ddlstatus = DirectCast(dgTNASampling.Items(x).FindControl("cmbStatus"), RadComboBox)

            If item("SelectedStatus").Text = "SELECTED" Then
                dgTNASampling.Columns(4).Visible = False
                If ChkSelect.Checked = True Then
                    dgTNASampling.Items(x).Enabled = True
                Else
                    dgTNASampling.Items(x).Enabled = False
                    dgTNASampling.Items(x).BackColor = Drawing.Color.WhiteSmoke
                End If
            Else
                dgTNASampling.Columns(4).Visible = True
            End If

            'Actiity Data from Sampling
            Dim lChartID As Integer = item("SampleTNAChartID").Text
            Dim txtRemarks As RadTextBox = DirectCast(dgTNASampling.Items(x).FindControl("txtRemarks"), RadTextBox)
            Dim cmbStatus As RadComboBox = DirectCast(dgTNASampling.Items(x).FindControl("cmbStatus"), RadComboBox)
            Dim cmbSubmission As RadComboBox = DirectCast(dgTNASampling.Items(x).FindControl("cmbSubmission"), RadComboBox)
            Dim txtActualDate As RadDatePicker = DirectCast(dgTNASampling.Items(x).FindControl("txtActualDate"), RadDatePicker)

            Dim dt As DataTable = ObjSampleTNAChart.GetSamplingActivityData(lChartID)
            If dt.Rows.Count > 0 Then
                txtRemarks.Text = dt.Rows(0)("Remarks")
                If dt.Rows(0)("Submission") = "Ist Submission" Then
                    cmbSubmission.SelectedValue = 1
                ElseIf dt.Rows(0)("Submission") = "2nd Submission" Then
                    cmbSubmission.SelectedValue = 2
                ElseIf dt.Rows(0)("Submission") = "3rd Submission" Then
                    cmbSubmission.SelectedValue = 3
                ElseIf dt.Rows(0)("Submission") = "4th Submission" Then
                    cmbSubmission.SelectedValue = 4
                Else
                    cmbSubmission.SelectedValue = 0
                End If

                If dt.Rows(0)("Status") = "Recieved from Supplier" Then
                    cmbStatus.SelectedValue = 1
                ElseIf dt.Rows(0)("Status") = "Approved(ECP)" Then
                    cmbStatus.SelectedValue = 2
                ElseIf dt.Rows(0)("Status") = "Rejected(ECP)" Then
                    cmbStatus.SelectedValue = 3
                ElseIf dt.Rows(0)("Status") = "Sent to Buyer" Then
                    cmbStatus.SelectedValue = 4
                ElseIf dt.Rows(0)("Status") = "Buyer Accept" Then
                    cmbStatus.SelectedValue = 5
                ElseIf dt.Rows(0)("Status") = "Buyer Reject" Then
                    cmbStatus.SelectedValue = 6
                Else
                    cmbStatus.SelectedValue = 0
                End If
                txtActualDate.SelectedDate = dt.Rows(0)("ActualDate")
            End If
        Next
    End Sub
    Function LoadData(ByVal lStyleID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjSampleTNAChart.GetProcessByTNAChartIdd(lStyleID)
        If objDataTable.Rows(0)("SelectedStatus") = "UNSELECT" Then
            btnCustomized.Visible = True
        Else
            btnCustomized.Visible = False
        End If

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnCustomized_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCustomized.Click
        Try
            ''''''''''''' Update Selected Status
            ObjSampleTNAChart.UpdateSelecteStatus(StyleID)
            '---------------
            Dim chkSelect As CheckBox
            Dim Str As String = "("
            Dim ID As String
            Dim x As Integer
            For x = 0 To dgTNASampling.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgTNASampling.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(dgTNASampling.Items(x).FindControl("chkSelect"), CheckBox)
                ID = item("SampleTNAChartID").Text
                If chkSelect.Checked = False Then
                    Str = Str + ID + ","
                End If
            Next
            Str = Str + ")"
            Str = Replace(Str, ",)", ")")
            ObjSampleTNAChart.UpdateSelecte(Str)
            Dim objDataView As DataView
            objDataView = LoadData(CLng(StyleID))
            Session("objDataView") = objDataView
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            Dim i As Integer
            Dim chkUpdate As CheckBox
            For x = 0 To dgTNASampling.Items.Count - 1
                chkUpdate = CType(dgTNASampling.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim txtEstimatedDate As RadDatePicker = DirectCast(dgTNASampling.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                    Dim txtRemarks As RadTextBox = DirectCast(dgTNASampling.Items(x).FindControl("txtRemarks"), RadTextBox)
                    Dim cmbStatus As RadComboBox = DirectCast(dgTNASampling.Items(x).FindControl("cmbStatus"), RadComboBox)
                    Dim cmbSubmission As RadComboBox = DirectCast(dgTNASampling.Items(x).FindControl("cmbSubmission"), RadComboBox)
                    Dim txtActualDate As RadDatePicker = DirectCast(dgTNASampling.Items(x).FindControl("txtActualDate"), RadDatePicker)

                    Dim item As GridDataItem = DirectCast(dgTNASampling.MasterTableView.Items(x), GridDataItem)
                    Dim lChartID As Integer = item("SampleTNAChartID").Text
                    Dim ProcessID As Integer = item("ProcessID").Text
                    Dim EstimatedDate As Date = txtEstimatedDate.SelectedDate
                    Dim ActualDate As Date = txtActualDate.SelectedDate
                    ' Dim ISampleTNAChartID As Long = ObjSampleTNAChart.GetSampleTNAChartID(lChartID)
                    If Not EstimatedDate.ToString() = "" Then
                        lblMSG.Visible = False
                        With ObjSampleTNAChart
                            .GetSampleTNAChartById(lChartID)
                            .DateEstemated = EstimatedDate
                            .Status = cmbStatus.SelectedItem.Text
                            .ActualDate = ActualDate
                            .Remarks = txtRemarks.Text
                            .TNAProcessID = ProcessID
                            .CreationDate = Date.Now
                            .Submission = cmbSubmission.SelectedItem.Text
                            .SaveSampleTNAChart()
                        End With
                        '-------------- History Manage
                        With ObjSampleTNAChartHistory
                            .CreationDate = Date.Now
                            .SampleTNAChartHistoryID = 0
                            .SampleTNAChartID = lChartID
                            .IdealDate = ObjSampleTNAChart.IdealDate
                            .ActualDate = txtActualDate.SelectedDate
                            .DateEstemated = EstimatedDate
                            .Remarks = txtRemarks.Text
                            .Status = cmbStatus.SelectedItem.Text
                            .TNAProcessID = ProcessID
                            .Submission = cmbSubmission.SelectedItem.Text
                            .SaveSampleTNAChartHistory()
                        End With
                        lblMSG.Visible = False
                    Else
                        lblMSG.Visible = True
                    End If
                Else
                    lblMSG.Text = "Record Has Sucessfully Saved"
                    lblMSG.Visible = True
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
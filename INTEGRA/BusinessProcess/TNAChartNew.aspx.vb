Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class TNAChartNew
    Inherits System.Web.UI.Page
    Dim ObjTNAChart As New TNAChart
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjTNAChartHistory As New TNAChartHistory
    Dim POID As String
    Dim GeneralCode As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("POID")
        If Not Page.IsPostBack Then
            Try
                If POID <> "" Then
                    Dim objDataView As DataView
                    Dim objDataView1 As DataView
                    Try
                        SetData(CLng(POID))
                        objDataView = LoadDataTNACritical(CLng(POID))
                        objDataView1 = LoadTNAProductionStatusData(CLng(POID))
                        Session("objDataView1") = objDataView1
                        Session("objDataView") = objDataView
                        BindTNACriticalGrid()
                        BindTNAProductionGrid()
                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
            PageHeader("Milestone View")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
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
    Sub BindCuttingApprovelStatusForTNACriticalPath()
        Try
            Dim x As Integer
            Dim ddlstatus As RadComboBox
            For x = 0 To dgTNACriticalPath.Items.Count - 1
                ddlstatus = DirectCast(dgTNACriticalPath.Items(x).FindControl("cmbStatus"), RadComboBox)
                Dim item As GridDataItem = DirectCast(dgTNACriticalPath.MasterTableView.Items(x), GridDataItem)
                Dim ProcessID As Integer = item("ProcessID").Text
                If ProcessID = 33 Then
                    ddlstatus.Items.Add(New RadComboBoxItem("Send Request"))
                    ddlstatus.Items.Add(New RadComboBoxItem("Approved"))
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindTNACriticalGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNACriticalPath.DataSource = objDataView
                dgTNACriticalPath.DataBind()
                BindCuttingApprovelStatusForTNACriticalPath()

                Dim x As Integer
                Dim ChkSelect As CheckBox
                Dim ddlstatus As RadComboBox
                Dim chkbox As New CheckBox
                For x = 0 To dgTNACriticalPath.Items.Count - 1
                    ChkSelect = DirectCast(dgTNACriticalPath.Items(x).FindControl("chkSelect"), CheckBox)
                    ddlstatus = DirectCast(dgTNACriticalPath.Items(x).FindControl("cmbStatus"), RadComboBox)
                    'Status Check Condition
                    If objDataView.Item(x)("Status").ToString() = "Completed" Then
                        ddlstatus.SelectedIndex = 2
                    ElseIf objDataView.Item(x)("Status").ToString() = "Pending" Then
                        ddlstatus.SelectedIndex = 1
                    ElseIf objDataView.Item(x)("Status").ToString() = "Send Request" Then
                        ddlstatus.SelectedIndex = 0
                    ElseIf objDataView.Item(x)("Status").ToString() = "Approved" Then
                        ddlstatus.SelectedIndex = 0
                    ElseIf objDataView.Item(x)("Status").ToString() = "Created" Then
                        ddlstatus.SelectedIndex = 0
                    Else
                        ddlstatus.SelectedIndex = 0
                    End If
                Next

                ' SetGridForTNACritiCal()
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindTNAProductionGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView1")
            If objDataView.Count > 0 Then
                dgTNAProductionStatus.DataSource = objDataView
                dgTNAProductionStatus.DataBind()
                ' SetGridForTNAProductionStatus()
                Dim x As Integer
                Dim ChkSelect As CheckBox
                Dim ddlstatus As RadComboBox
                Dim chkbox As New CheckBox
                For x = 0 To dgTNAProductionStatus.Items.Count - 1
                    ChkSelect = DirectCast(dgTNAProductionStatus.Items(x).FindControl("chkSelect"), CheckBox)
                    ddlstatus = DirectCast(dgTNAProductionStatus.Items(x).FindControl("cmbStatus"), RadComboBox)
                    'Status Check Condition
                    If objDataView.Item(x)("Status").ToString() = "Completed" Then
                        ddlstatus.SelectedIndex = 2
                    ElseIf objDataView.Item(x)("Status").ToString() = "Pending" Then
                        ddlstatus.SelectedIndex = 1
                    ElseIf objDataView.Item(x)("Status").ToString() = "Send Request" Then
                        ddlstatus.SelectedIndex = 0
                    ElseIf objDataView.Item(x)("Status").ToString() = "Approved" Then
                        ddlstatus.SelectedIndex = 0
                    ElseIf objDataView.Item(x)("Status").ToString() = "Created" Then
                        ddlstatus.SelectedIndex = 0
                    Else
                        ddlstatus.SelectedIndex = 0
                    End If
                    'end
                Next
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadDataTNACritical(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetTNACriticalPath(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Function that Loads the data and return dataview
    Function LoadTNAProductionStatusData(ByVal lPOID As Long) As ICollection
        Dim objDataView1 As DataView
        Dim objDataTable1 As DataTable
        objDataTable1 = ObjTNAChart.GetTNAProductionStatus(lPOID)
        objDataView1 = New DataView(objDataTable1)
        Return objDataView1
    End Function
    Sub SetGridForTNACritiCal()
        Dim x As Integer
        Dim ChkSelect As CheckBox
        Dim ddlstatus As RadComboBox
        Dim dtStatusCheck As New DataTable
        Dim chkbox As New CheckBox
        dtStatusCheck = ObjTNAChart.GetTNACriticalPath(POID)
        For x = 0 To dgTNACriticalPath.Items.Count - 1
            ChkSelect = DirectCast(dgTNACriticalPath.Items(x).FindControl("chkSelect"), CheckBox)
            ddlstatus = DirectCast(dgTNACriticalPath.Items(x).FindControl("cmbStatus"), RadComboBox)
            'Status Check Condition
            If dtStatusCheck.Rows(x)("Status").ToString() = "Completed" Then
                ddlstatus.SelectedIndex = 2
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Pending" Then
                ddlstatus.SelectedIndex = 1
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Send Request" Then
                ddlstatus.SelectedIndex = 0
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Buyer Approved" Then
                ddlstatus.SelectedIndex = 0
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Created" Then
                ddlstatus.SelectedIndex = 0
            Else
                ddlstatus.SelectedIndex = 0
            End If
            'end
        Next
    End Sub
    Sub SetGridForTNAProductionStatus()
        Dim x As Integer
        Dim ChkSelect As CheckBox
        Dim ddlstatus As RadComboBox
        Dim dtStatusCheck As New DataTable
        Dim chkbox As New CheckBox
        dtStatusCheck = ObjTNAChart.GetTNAProductionStatus(POID)
        For x = 0 To dgTNAProductionStatus.Items.Count - 1
            ChkSelect = DirectCast(dgTNAProductionStatus.Items(x).FindControl("chkSelect"), CheckBox)
            ddlstatus = DirectCast(dgTNAProductionStatus.Items(x).FindControl("cmbStatus"), RadComboBox)
            'Status Check Condition
            If dtStatusCheck.Rows(x)("Status").ToString() = "Completed" Then
                ddlstatus.SelectedIndex = 2
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Pending" Then
                ddlstatus.SelectedIndex = 1
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Send Request" Then
                ddlstatus.SelectedIndex = 0
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Approved" Then
                ddlstatus.SelectedIndex = 0
            ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Created" Then
                ddlstatus.SelectedIndex = 0
            Else
                ddlstatus.SelectedIndex = 0
            End If
            'end
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            Dim chkUpdate As CheckBox
            For x = 0 To dgTNACriticalPath.Items.Count - 1
                chkUpdate = CType(dgTNACriticalPath.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim txtEstimatedDate As RadDatePicker = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                    Dim txtRemarks As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtRemarks"), RadTextBox)
                    Dim cmbStatus As RadComboBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("cmbStatus"), RadComboBox)
                    Dim QtyCompleted As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
                    Dim txtActualDate As RadDatePicker = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtActualDate"), RadDatePicker)
                    Dim txtParameter As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtParameter"), RadTextBox)
                    Dim txtParameterUnit As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtParameterUnit"), RadTextBox)
                    Dim txtTotalCapacity As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtTotalCapacity"), RadTextBox)
                    Dim txtCapacityUnit As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtCapacityUnit"), RadTextBox)
                    Dim txtRequired As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtRequired"), RadTextBox)
                    Dim txtRequiredUnit As RadTextBox = DirectCast(dgTNACriticalPath.Items(x).FindControl("txtRequiredUnit"), RadTextBox)

                    Dim item As GridDataItem = DirectCast(dgTNACriticalPath.MasterTableView.Items(x), GridDataItem)
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
                            .Selected = True
                            .SelectedStatus = "SELECTED"
                            .TNAProcessID = ProcessID
                            .Parameter = txtParameter.Text
                            .ParameterUnit = txtParameterUnit.Text
                            .TotalCapacity = txtTotalCapacity.Text
                            .CapacityUnit = txtCapacityUnit.Text
                            .Required = txtRequired.Text
                            .RequiredUnit = txtRequiredUnit.Text
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
                            .Parameter = txtParameter.Text
                            .ParameterUnit = txtParameterUnit.Text
                            .TotalCapacity = txtTotalCapacity.Text
                            .CapacityUnit = txtCapacityUnit.Text
                            .Required = txtRequired.Text
                            .RequiredUnit = txtRequiredUnit.Text
                            .SaveTNAChartHistory()
                        End With
                        lblMSG.Visible = False
                    Else
                        lblMSG.Visible = True
                    End If
                Else
                    lblMSG.Text = "Record Has Sucessfully Saved"
                    lblMSG.Visible = True
                End If
                chkUpdate.Checked = False
            Next 'end x loop

            '------- Code For dgTNAProductionStatus
            Dim xx As Integer
            For xx = 0 To dgTNAProductionStatus.Items.Count - 1
                chkUpdate = CType(dgTNAProductionStatus.Items(xx).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim txtEstimatedDate As RadDatePicker = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtEstimatedDate"), RadDatePicker)
                    Dim txtRemarks As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtRemarks"), RadTextBox)
                    Dim cmbStatus As RadComboBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("cmbStatus"), RadComboBox)
                    Dim QtyCompleted As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtQuantityCmpltd"), RadTextBox)
                    Dim txtActualDate As RadDatePicker = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtActualDate"), RadDatePicker)
                    Dim txtParameter As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtParameter"), RadTextBox)
                    Dim txtParameterUnit As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtParameterUnit"), RadTextBox)
                    Dim txtTotalCapacity As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtTotalCapacity"), RadTextBox)
                    Dim txtCapacityUnit As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtCapacityUnit"), RadTextBox)
                    Dim txtRequired As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtRequired"), RadTextBox)
                    Dim txtRequiredUnit As RadTextBox = DirectCast(dgTNAProductionStatus.Items(xx).FindControl("txtRequiredUnit"), RadTextBox)

                    Dim item As GridDataItem = DirectCast(dgTNAProductionStatus.MasterTableView.Items(xx), GridDataItem)
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
                            .Selected = True
                            .SelectedStatus = "SELECTED"
                            .TNAProcessID = ProcessID
                            .Parameter = txtParameter.Text
                            .ParameterUnit = txtParameterUnit.Text
                            .TotalCapacity = txtTotalCapacity.Text
                            .CapacityUnit = txtCapacityUnit.Text
                            .Required = txtRequired.Text
                            .RequiredUnit = txtRequiredUnit.Text
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
                            .Parameter = txtParameter.Text
                            .ParameterUnit = txtParameterUnit.Text
                            .TotalCapacity = txtTotalCapacity.Text
                            .CapacityUnit = txtCapacityUnit.Text
                            .Required = txtRequired.Text
                            .RequiredUnit = txtRequiredUnit.Text
                            .SaveTNAChartHistory()
                        End With
                        lblMSG.Visible = False
                    Else
                        lblMSG.Visible = True
                    End If
                Else
                    lblMSG.Text = "Record Has Sucessfully Saved"
                    lblMSG.Visible = True
                End If
                chkUpdate.Checked = False
            Next 'end xx loop
        Catch ex As Exception
        End Try
    End Sub

End Class
Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class TNAChartView
    Inherits System.Web.UI.Page
    Dim ObjTNAChart As New TNAChart
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjTNAChartHistory As New TNAChartHistory
    Dim POID As String
    Dim GeneralCode As New GeneralCode
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        POID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then
            Try
                If POID <> "" Then
                    Dim objDataView As DataView
                    Try
                        SetData(CLng(POID))
                        objDataView = LoadData(CLng(POID))
                        Session("objDataView") = objDataView
                        BindGrid()
                        GetStatusforTNA()

                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
            PageHeader("Milestone View")
        End If
    End Sub
    Sub GetStatusforTNA()
        Dim dt As DataTable
        dt = ObjTNAChart.GetProductionStatusForTNA(POID)
        If dt.Rows.Count > 0 Then
            txtProductionstatus.Text = dt.Rows(0)("ProductionStatus")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SetData(ByVal IPOID)
        Dim Dt As DataTable
        Dt = ObjPurchaseOrder.GetPODataNew(IPOID)
        If Dt.Rows.Count > 0 Then
            lblBuyer.Text = Dt.Rows(0)("CustomerName")
            lblVendor.Text = Dt.Rows(0)("Supplier")
            lblPONo.Text = Dt.Rows(0)("SrNO")
            '---New nizam
            txtShipmentDate.Text = Dt.Rows(0)("ShipmentDate")
            txtShipmentDatee.SelectedDate = Dt.Rows(0)("ShipmentDate")
            lblPlacementDate.Text = Dt.Rows(0)("OrderRecvDate")
            txtPlacementDate.SelectedDate = Dt.Rows(0)("OrderRecvDate")
        End If
    End Sub
    ''''' Update Function of Production Status
    Private Sub UpdateProductionStatus()
        ObjTNAChart.updateProductionStatusForTNA(POID, txtProductionstatus.Text)
       
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                BindCuttingApprovelStatus()
                SetGrid()
            Else
            End If
            Dim txtEstimatedDate As RadDatePicker
            Dim txtActualDate As RadDatePicker
            Dim dt As DataTable
            Dim EstimatedDate As Date
            Dim ActualDate As Date
            dt = objDataView.ToTable
            For x = 0 To dt.Rows.Count - 1
                txtEstimatedDate = DirectCast(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                txtActualDate = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
                ' EstimatedDate = dt.Rows(x)("EstimatedDate")

                txtEstimatedDate.SelectedDate = dt.Rows(x)("EstimatedDate") 'EstimatedDate 
                If dt.Rows(x)("ActualDate") = "01/01/1900" Then

                Else
                    ActualDate = dt.Rows(x)("ActualDate")
                    txtActualDate.SelectedDate = dt.Rows(x)("ActualDate") ' ActualDate 'dt.Rows(x)("ActualDate")
                End If
            Next
            BindColor()
        Catch ex As Exception
            lblMSG.Text = ex.ToString
        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtcolor As DataTable = ObjTNAChart.GetPOColor(POID)
            Dim x As Integer
            Dim cmbColor As RadComboBox
            For x = 0 To dgTNAChart.Items.Count - 1
                cmbColor = DirectCast(dgTNAChart.Items(x).FindControl("cmbColor"), RadComboBox)
                cmbColor.DataSource = dtcolor
                cmbColor.DataTextField = "BuyerColor"
                cmbColor.DataValueField = "BuyerColor"
                cmbColor.DataBind()
            Next
        Catch ex As Exception
            lblMSG.Text = ex.ToString
        End Try
    End Sub
    Sub BindCuttingApprovelStatus()
        Try
            Dim x As Integer
            Dim ddlstatus As RadComboBox
            For x = 0 To dgTNAChart.Items.Count - 1
                ddlstatus = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
                Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                Dim ProcessID As Integer = item("ProcessID").Text
                If ProcessID = 33 Then
                    ddlstatus.Items.Add(New RadComboBoxItem("Send Request"))
                    ddlstatus.Items.Add(New RadComboBoxItem("Buyer Approved"))
                End If
            Next
        Catch ex As Exception
            lblMSG.Text = ex.ToString
        End Try
    End Sub
    Sub SetGrid()
        Dim x As Integer
        Dim ChkSelect As CheckBox
        Dim ddlstatus As RadComboBox
        Dim dtStatusCheck As New DataTable
        Dim chkbox As New CheckBox
        dtStatusCheck = ObjTNAChart.GetProcessByTNAChartIddNew(POID)
        For x = 0 To dgTNAChart.Items.Count - 1
            ChkSelect = DirectCast(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
            ddlstatus = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
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
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetProcessByTNAChartIddNew(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            lblMSG.Text = ""
            UpdateProductionStatus()
            Dim x As Integer
            Dim i As Integer
            Dim chkUpdate As CheckBox
            Dim ChkCheckBox As Boolean = False

            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    ChkCheckBox = True
                    Exit For
                End If
            Next

            If ChkCheckBox = True Then
                For x = 0 To dgTNAChart.Items.Count - 1
                    chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                    If chkUpdate.Checked = True Then
                        Dim txtEstimatedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                        Dim txtRemarks As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtRemarks"), RadTextBox)
                        Dim cmbStatus As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
                        Dim QtyCompleted As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
                        Dim txtActualDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
                        Dim cmbColor As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbColor"), RadComboBox)
                        Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                        Dim lChartID As Integer = item("TNAChartID").Text
                        Dim ProcessID As Integer = item("ProcessID").Text
                        Dim EstimatedDate As Date = txtEstimatedDate.SelectedDate
                        Dim ActualDateE As String
                        If txtActualDate.ValidationDate = "" Then
                            ActualDateE = ""
                        Else
                            ActualDateE = txtActualDate.SelectedDate.Value().ToString()
                        End If
                        If Not ActualDateE.ToString = "" Then
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
                                    .Parameter = 0
                                    .ParameterUnit = 0
                                    .TotalCapacity = 0
                                    .CapacityUnit = 0
                                    .Required = 0
                                    .RequiredUnit = 0
                                    .ProductionStatus = txtProductionstatus.Text
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
                                    .Color = cmbColor.SelectedValue
                                    .ProductionStatus = txtProductionstatus.Text
                                    .SaveTNAChartHistory()
                                End With
                                ObjTNAChart.UpdateProcessAlerts(POID, ProcessID, 0)
                                lblMSG.Visible = False
                            Else
                                lblMSG.Visible = True
                            End If
                        Else
                            ''Update Estimated date
                            ObjTNAChart.UpdateDateEstemated(lChartID, txtEstimatedDate.SelectedDate.Value.ToString("yyyy-MM-dd"))
                            ''-------------- History For Color Update
                            With ObjTNAChartHistory
                                .CreationDate = Date.Now
                                .TNAChartID = lChartID
                                .IdealDate = txtEstimatedDate.SelectedDate
                                .DateEstemated = txtEstimatedDate.SelectedDate
                                If txtActualDate.ValidationDate = "" Then
                                    .ActualDate = txtEstimatedDate.SelectedDate
                                Else
                                    .ActualDate = txtActualDate.SelectedDate
                                End If
                                .QtyCompleted = QtyCompleted.Text
                                .Remarks = txtRemarks.Text
                                .Status = cmbStatus.SelectedItem.Text
                                .TNAProcessID = ProcessID
                                .Parameter = 0
                                .ParameterUnit = 0
                                .TotalCapacity = 0
                                .CapacityUnit = 0
                                .Required = 0
                                .RequiredUnit = 0
                                .Color = cmbColor.SelectedValue
                                .ProductionStatus = txtProductionstatus.Text
                                .SaveTNAChartHistory()
                            End With
                            ObjTNAChart.UpdateProcessAlerts(POID, ProcessID, 0)
                            lblMSG.Text = "Record Updated. Estimated date updated."
                            lblMSG.Visible = True
                        End If
                    Else

                        lblMSG.Text = "Record has been Saved."
                        lblMSG.Visible = True
                    End If
                Next
                GetStatusforTNA()
            Else
                lblMSG.Text = "Please check atleast one from below."
                lblMSG.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
     Protected Sub lnkReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkReport.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Report.Load(Server.MapPath("..\Reports/TNAChart.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Milestone Chart"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, POID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkHistory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkHistory.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete

            Report.Load(Server.MapPath("..\Reports/TNAChartHistory.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Milestone History"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, POID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()
            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub lnkReportCustomer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkReportCustomer.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Report.Load(Server.MapPath("..\Reports/CustomerTNAChart.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Customer Chart"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, POID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception




        End Try
    End Sub
    Protected Sub lnkHistoryCustomer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkHistoryCustomer.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete

            Report.Load(Server.MapPath("..\Reports/TNAChartHistoryCustomer.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Customer History"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, POID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()
            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnNotApplicable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotApplicable.Click
        Try
            Dim bit As Decimal = 0
            Dim x As Integer
            Dim chkUpdate As CheckBox ' get the update check box status
            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    ' Dim txtEstimatedDate As TextBox = CType(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), TextBox)
                    'Dim txtRemarks As TextBox = CType(dgTNAChart.Items(x).FindControl("txtRemarks"), TextBox)
                    'Dim cmbStatus As DropDownList = CType(dgTNAChart.Items(x).FindControl("cmbStatus"), DropDownList)
                    'Dim QtyCompleted As TextBox = CType(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), TextBox)
                    Dim txtRemarks As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtRemarks"), RadTextBox)
                    Dim cmbStatus As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
                    Dim QtyCompleted As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
                    Dim txtEstimatedDatee As RadDatePicker = CType(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)

                    Dim ProcessID As Integer = dgTNAChart.Items(x).Cells(2).Text
                    Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                    Dim lChartID As Integer = item("TNAChartID").Text
                    'Dim lChartID As Integer = dgTNAChart.Items(x).Cells(0).Text
                    bit = 1
                    ObjTNAChart.UpdateSelected(lChartID)

                    With ObjTNAChart
                        .GetTNAChartById(lChartID)
                    End With
                    '-------------- History Manage
                    With ObjTNAChartHistory
                        .CreationDate = Date.Now
                        .TNAChartID = lChartID
                        .IdealDate = ObjTNAChart.IdealDate
                        .DateEstemated = txtEstimatedDatee.SelectedDate
                        .ActualDate = txtEstimatedDatee.SelectedDate
                        .QtyCompleted = 0 '0ObjTNAChart.QtyCompleted
                        .Remarks = "Not Applicable"
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
                    'With ObjTNAChartHistory
                    '    .TNAChartHistoryID = 0
                    '    .CreationDate = Date.Now
                    '    .TNAChartID = lChartID
                    '    .IdealDate = ObjTNAChart.IdealDate
                    '    .DateEstemated = GeneralCode.GetDate(txtEstimatedDatee.SelectedDate.Value.ToString("dd-MM-yyyy"))
                    '    .ActualDate = GeneralCode.GetDate(txtEstimatedDatee.SelectedDate.Value.ToString("dd-MM-yyyy"))
                    '    .QtyCompleted = ObjTNAChart.QtyCompleted
                    '    .Remarks = "Not Applicable"
                    '    .Status = cmbStatus.SelectedItem.Text
                    '    .TNAProcessID = ProcessID
                    '    .SaveTNAChartHistory()
                    'End With

                End If

            Next

            If bit = 1 Then
                lblMSG.Text = "Selected Process update with 'Not Applicable' Successfully."
                Dim objDataView As DataView
                SetData(CLng(POID))
                objDataView = LoadData(CLng(POID))
                Session("objDataView") = objDataView
                BindGrid()
            Else
                lblMSG.Text = "Not saved, Select process."
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCheckAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheckAll.Click
        Try
            Dim bit As Decimal = 0
            Dim x As Integer
            Dim chkUpdate As CheckBox ' get the update check box status
            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                chkUpdate.Checked = True
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub RadBtnUpdateTNA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadBtnUpdateTNA.Click
        Try
            UpdateTNAReviseShipdate()
            SaveRevisedShipmentdateAuto()
           
            '----Again Load Grid
            Dim objDataView As DataView
            SetData(CLng(POID))
            objDataView = LoadData(CLng(POID))
            Session("objDataView") = objDataView

            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                BindCuttingApprovelStatus()
                SetGrid()
            Else
            End If

            Dim txtEstimatedDate As RadDatePicker
            Dim txtActualDate As RadDatePicker
            Dim dt As DataTable
            Dim EstimatedDate As Date
            Dim ActualDate As Date
            dt = objDataView.ToTable
            For x = 0 To dt.Rows.Count - 1
                txtEstimatedDate = DirectCast(dgTNAChart.Items(x).FindControl("txtEstimatedDate"), RadDatePicker)
                txtActualDate = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
                ' EstimatedDate = dt.Rows(x)("EstimatedDate")
                txtEstimatedDate.BackColor = Drawing.Color.Yellow
                txtEstimatedDate.SelectedDate = dt.Rows(x)("EstimatedDate") 'EstimatedDate 
                If dt.Rows(x)("ActualDate") = "01/01/1900" Then

                Else
                    ActualDate = dt.Rows(x)("ActualDate")
                    txtActualDate.SelectedDate = dt.Rows(x)("ActualDate") ' ActualDate 'dt.Rows(x)("ActualDate")
                End If
            Next
            BindColor()

        Catch ex As Exception

        End Try
    End Sub
    Function GetTimeSpame(ByVal DateFrom As Date, ByVal DateTo As Date)
        Try
            Dim tsTimeSpan As TimeSpan
            Dim iNumberOfDays As Integer
            tsTimeSpan = DateFrom.Subtract(DateTo)
            iNumberOfDays = tsTimeSpan.Days
            Return iNumberOfDays
        Catch ex As Exception
            Lblerror.Text = ex.Message.ToString
        End Try
      
    End Function
    Sub SaveRevisedShipmentdateAuto()
        Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
        Try
            Try
                With objPurchaseReviseShip
                    .POReviseShipmentID = 0
                    .POID = POID
                    .CreationDate = Date.Now()
                    .ShipmentDate = txtReviseShipmentDate.SelectedDate 'GeneralCode.GetDate(txtShipmentDate.Text)
                    .SavePurchaseOrderReviseShipment()
                End With
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Function AddDate(ByVal TotalDays As Double, ByVal Days As Double, ByVal DateAddin As Date) As Date
        Try
            Dim dt As Date
            Days = (TotalDays / 100) * Days
            dt = DateAddin.AddDays(Days)
            Return dt
        Catch ex As Exception
            Lblerror.Text = ex.Message.ToString
        End Try
      
    End Function
    Sub UpdateTNAReviseShipdate()
        Try
            Dim x As Integer
            Dim i As Integer
            Dim DateEstemated As Date
            Dim TimeSpame As Long
            '    TimeSpame = GetTimeSpame(txtReviseShipmentDate.SelectedDate, lblPlacementDate.Text)
            'TimeSpame = GetTimeSpame(txtReviseShipmentDate.SelectedDate, txtPlacementDate.SelectedDate)
            TimeSpame = GetTimeSpame(GeneralCode.GetDate(txtReviseShipmentDate.SelectedDate.Value.ToString("dd-MM-yyyy")), GeneralCode.GetDate(txtPlacementDate.SelectedDate.Value.ToString("dd-MM-yyyy")))
            For x = 0 To dgTNAChart.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                Dim lChartID As Integer = item("TNAChartID").Text
                Dim ProcessID As Integer = item("ProcessID").Text

                Dim Dtprocess As DataTable
                Dtprocess = ObjTNAChart.GetSchedularTimeByProcessID(ProcessID)

                ' DateEstemated = GeneralCode.GetDate(AddDate(TimeSpame, Dtprocess.Rows(0)("SchedularTime"), lblPlacementDate.Text))
                '  DateEstemated = GeneralCode.GetDate(AddDate(TimeSpame, Dtprocess.Rows(0)("SchedularTime"), GeneralCode.GetDate(txtPlacementDate.SelectedDate.ToString("dd-MM-yyyy"))))
                DateEstemated = GeneralCode.GetDate(AddDate(TimeSpame, Dtprocess.Rows(0)("SchedularTime"), GeneralCode.GetDate(txtPlacementDate.SelectedDate.Value.ToString("dd-MM-yyyy"))))
                Dim startdatee As String = DateEstemated.ToString("yyyy-MM-dd")

                ObjTNAChart.UpdateDateEstematedNew(lChartID, startdatee)
                '-------------- History Manage
                ObjTNAChart.UpdateDateEstematedNewHistory(lChartID, startdatee)
            Next
            ObjTNAChart.UpdateDateTimeSpam(POID, TimeSpame)
        Catch ex As Exception
            Lblerror.Text = ex.Message.ToString
        End Try
    End Sub
End Class
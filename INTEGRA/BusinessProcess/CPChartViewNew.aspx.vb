Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class CPChartViewNew
    Inherits System.Web.UI.Page
    Dim ObjTNAChart As New TNAChart
    Dim ObjCPChart As New CustomerCPChart
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjTNAChartHistory As New TNAChartHistory
    Dim ObjCPChartHistory As New CustomerCPChartHistory
    Dim POID As String
    Dim objGeneralCode As New GeneralCode
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        POID = Request.QueryString("POID")
        Dim dtcheck As DataTable
        If Not Page.IsPostBack Then
            Try
                If POID <> "" Then
                    Dim objDataView As DataView
                    Try
                        SetData(CLng(POID))
                        dtcheck = ObjCPChart.Check(CLng(POID))
                        If dtcheck.Rows.Count > 0 Then
                            objDataView = LoadDataEdit(CLng(POID))
                            Session("objDataView") = objDataView
                            BindGrid()
                            Dim dt As DataTable = objDataView.ToTable
                            Dim x As Integer
                            Dim chkUpdate As CheckBox
                            For x = 0 To dgTNAChart.Items.Count - 1
                                Dim txtExpectedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtExpectedDate"), RadDatePicker)
                                Dim txtActualDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
                                Dim ExpectedDate As Date
                                Dim ActualDate As Date
                                If dt.Rows(x)("ExpectedDate") = "" Then
                                    ' txtExpectedDate.SelectedDate = dt.Rows(x)("ExpectedDate")
                                Else
                                    ' ExpectedDate = dt.Rows(x)("ExpectedDate")
                                    txtExpectedDate.SelectedDate = Convert.ToDateTime(dt.Rows(x)("ExpectedDatee"))
                                End If
                                If dt.Rows(x)("ActualDate") = "" Then

                                Else
                                    txtActualDate.SelectedDate = Convert.ToDateTime(dt.Rows(x)("ActualDatee"))
                                End If
                            Next
                        Else
                            objDataView = LoadData(CLng(POID))
                            Session("objDataView") = objDataView
                            BindGrid()
                            Dim Dt As DataTable
                            Dt = ObjPurchaseOrder.GetPOData(CLng(POID))
                            Dim x As Integer
                            Dim chkUpdate As CheckBox
                            For x = 0 To dgTNAChart.Items.Count - 1
                                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                                Dim txtExpectedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtExpectedDate"), RadDatePicker)
                                Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                                Dim CPProcessID As Integer = item("CPProcessID").Text
                                If CPProcessID = 4 Or CPProcessID = 5 Or CPProcessID = 6 Or CPProcessID = 24 Then
                                    chkUpdate.Checked = True
                                End If
                                If CPProcessID = 4 Or CPProcessID = 5 Or CPProcessID = 6 Then
                                    txtExpectedDate.SelectedDate = Dt.Rows(0)("PlacementDate")
                                ElseIf CPProcessID = 24 Then
                                    txtExpectedDate.SelectedDate = Dt.Rows(0)("ShipmentDate")
                                End If
                            Next
                            savefirst()
                        End If
                       
                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
            PageHeader("Customer CP View")
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
            lblPONO.Text = Dt.Rows(0)("PONO")
        End If
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = ObjTNAChart.GetProcessByTNAChartIdd(lPOID)
        objDataTable = ObjCPChart.GetProcessFirstTime(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Function LoadDataEdit(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = ObjTNAChart.GetProcessByTNAChartIdd(lPOID)
        objDataTable = ObjCPChart.GetProcessInEDIT(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                ' BindCuttingApprovelStatus()

            Else
            End If
        Catch ex As Exception

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

        End Try
    End Sub
    
    
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim x As Integer
            Dim i As Integer
            Dim chkUpdate As CheckBox
            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim txtExpectedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtExpectedDate"), RadDatePicker)
                    ' Dim txtRemarks As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtRemarks"), RadTextBox)
                    ' Dim cmbStatus As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
                    ' Dim QtyCompleted As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
                    Dim txtActualDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)

                    Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
                    Dim lCPChartID As Integer = item("CPChartID").Text
                    Dim CPProcessID As Integer = item("CPProcessID").Text
                    Dim ExpectedDate As Date
                    Dim ExpectedDates As String
                    Dim em As Long
                    Dim eD As Long
                    Dim ey As Long
                    If txtExpectedDate.SelectedDate IsNot Nothing Then
                        ExpectedDate = txtExpectedDate.SelectedDate
                        em = ExpectedDate.Month
                        eD = ExpectedDate.Day
                        ey = ExpectedDate.Year
                        If em <= 9 Then
                            If eD <= 9 Then
                                ExpectedDates = "0" & eD & "/0" & em & "/" & ey
                            Else
                                ExpectedDates = eD & "/0" & em & "/" & ey
                            End If
                        Else

                            If eD <= 9 Then
                                ExpectedDates = "0" & eD & "/" & em & "/" & ey
                            Else
                                ExpectedDates = eD & "/" & em & "/" & ey
                            End If

                        End If
                        ' ExpectedDates = objGeneralCode.GetDateN(txtExpectedDate.SelectedDate)
                    Else
                        ExpectedDates = ""

                    End If

                    Dim ActualDate As Date
                    Dim ActualDates As String
                    Dim Am As Long
                    Dim AD As Long
                    Dim Ay As Long
                    If txtActualDate.SelectedDate IsNot Nothing Then
                        ActualDate = txtActualDate.SelectedDate
                        Am = ActualDate.Month
                        AD = ActualDate.Day
                        Ay = ActualDate.Year
                        If Am <= 9 Then
                            If AD <= 9 Then
                                ActualDates = "0" & AD & "/0" & Am & "/" & Ay
                            Else
                                ActualDates = AD & "/0" & Am & "/" & Ay
                            End If
                        Else
                            If AD <= 9 Then
                                ActualDates = "0" & AD & "/" & Am & "/" & Ay
                            Else
                                ActualDates = AD & "/" & Am & "/" & Ay
                            End If


                        End If
                        'ActualDates = objGeneralCode.GetDateN(txtActualDate.SelectedDate)
                    Else
                        ActualDates = ""
                    End If

                    ' If Not ExpectedDate.ToString() = "" Then
                    lblMSG.Visible = False
                    With ObjCPChart
                        ' .GetTNAChartById(lChartID)
                        .CPChartID = lCPChartID
                        .POID = POID
                        .ExpectedDate = ExpectedDates
                        .IdealDate = ExpectedDates
                        .Status = "--" 'cmbStatus.SelectedItem.Text
                        .ActualDate = ActualDates
                        .Remarks = " " 'txtRemarks.Text
                        .QtyCompleted = 0 'QtyCompleted.Text
                        .Selected = True
                        .SelectedStatus = "SELECTED"
                        .CPProcessID = CPProcessID
                        .Parameter = 0
                        .ParameterUnit = 0
                        .TotalCapacity = 0
                        .CapacityUnit = 0
                        .Required = 0
                        .RequiredUnit = 0
                        .SaveTNAChart()
                    End With
                    '-------------- History Manage
                    With ObjCPChartHistory
                        .CreationDate = Date.Now
                        .CPChartID = lCPChartID
                        .IdealDate = ExpectedDates
                        .ExpectedDate = ExpectedDates
                        .ActualDate = ActualDates
                        .QtyCompleted = 0 'ObjTNAChart.QtyCompleted
                        .Remarks = " " 'txtRemarks.Text
                        .Status = "--" 'cmbStatus.SelectedItem.Text
                        .CPProcessID = CPProcessID
                        .Parameter = 0
                        .ParameterUnit = 0
                        .TotalCapacity = 0
                        .CapacityUnit = 0
                        .Required = 0
                        .RequiredUnit = 0
                        .SaveTNAChartHistory()
                    End With

                    chkUpdate.Checked = False
                    lblMSG.Visible = False
                    'Else
                    '    lblMSG.Visible = True
                    'End If
                    chkUpdate.Checked = False
                Else
                    lblMSG.Text = "Record Has Sucessfully Saved"
                    lblMSG.Visible = True
                    chkUpdate.Checked = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub savefirst()
        Dim x As Integer
        Dim i As Integer
        Dim chkUpdate As CheckBox
        For x = 0 To dgTNAChart.Items.Count - 1
            chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)

            Dim txtExpectedDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtExpectedDate"), RadDatePicker)
            ' Dim txtRemarks As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtRemarks"), RadTextBox)
            ' Dim cmbStatus As RadComboBox = DirectCast(dgTNAChart.Items(x).FindControl("cmbStatus"), RadComboBox)
            ' Dim QtyCompleted As RadTextBox = DirectCast(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), RadTextBox)
            Dim txtActualDate As RadDatePicker = DirectCast(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)

            Dim item As GridDataItem = DirectCast(dgTNAChart.MasterTableView.Items(x), GridDataItem)
            Dim lCPChartID As Integer = item("CPChartID").Text
            Dim CPProcessID As Integer = item("CPProcessID").Text
            Dim POID As Integer = item("POID").Text
            Dim ExpectedDate As Date
            Dim ExpectedDates As String
            Dim em As Long
            Dim eD As Long
            Dim ey As Long
            If txtExpectedDate.SelectedDate IsNot Nothing Then
                ExpectedDate = txtExpectedDate.SelectedDate
                em = ExpectedDate.Month
                eD = ExpectedDate.Day
                ey = ExpectedDate.Year
                If em <= 9 Then
                    If eD <= 9 Then
                        ExpectedDates = "0" & eD & "/0" & em & "/" & ey
                    Else
                        ExpectedDates = eD & "/0" & em & "/" & ey
                    End If
                Else

                    If eD <= 9 Then
                        ExpectedDates = "0" & eD & "/" & em & "/" & ey
                    Else
                        ExpectedDates = eD & "/" & em & "/" & ey
                    End If

                End If
                ' ExpectedDates = objGeneralCode.GetDateN(txtExpectedDate.SelectedDate)
            Else
                ExpectedDates = ""

            End If

            Dim ActualDate As Date
            Dim ActualDates As String
            Dim Am As Long
            Dim AD As Long
            Dim Ay As Long
            If txtActualDate.SelectedDate IsNot Nothing Then
                ActualDate = txtActualDate.SelectedDate
                Am = ActualDate.Month
                AD = ActualDate.Day
                Ay = ActualDate.Year
                If Am <= 9 Then
                    If AD <= 9 Then
                        ActualDates = "0" & AD & "/0" & Am & "/" & Ay
                    Else
                        ActualDates = AD & "/0" & Am & "/" & Ay
                    End If
                Else
                    If AD <= 9 Then
                        ActualDates = "0" & AD & "/" & Am & "/" & Ay
                    Else
                        ActualDates = AD & "/" & Am & "/" & Ay
                    End If


                End If
                'ActualDates = objGeneralCode.GetDateN(txtActualDate.SelectedDate)
            Else
                ActualDates = ""
            End If


            lblMSG.Visible = False
            With ObjCPChart
                ' .GetTNAChartById(lChartID)
                .CPChartID = lCPChartID
                .POID = POID
                .ExpectedDate = ExpectedDates
                .IdealDate = ExpectedDates
                .Status = "Created" 'cmbStatus.SelectedItem.Text
                .ActualDate = ActualDates
                .Remarks = " " 'txtRemarks.Text
                .QtyCompleted = 0 'QtyCompleted.Text
                .Selected = True
                .SelectedStatus = "SELECTED"
                .CPProcessID = CPProcessID
                .Parameter = 0
                .ParameterUnit = 0
                .TotalCapacity = 0
                .CapacityUnit = 0
                .Required = 0
                .RequiredUnit = 0
                .SaveTNAChart()
            End With
            '-------------- History Manage
            With ObjCPChartHistory
                .CreationDate = Date.Now
                .CPChartID = lCPChartID
                .IdealDate = ExpectedDates
                .ExpectedDate = ExpectedDates
                .ActualDate = ActualDates
                .QtyCompleted = 0 'ObjTNAChart.QtyCompleted
                .Remarks = " " 'txtRemarks.Text
                .Status = "Created" 'cmbStatus.SelectedItem.Text
                .CPProcessID = CPProcessID
                .Parameter = 0
                .ParameterUnit = 0
                .TotalCapacity = 0
                .CapacityUnit = 0
                .Required = 0
                .RequiredUnit = 0
                .SaveTNAChartHistory()
            End With

            chkUpdate.Checked = False

        Next
    End Sub
    Protected Sub lnkReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkReport.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Report.Load(Server.MapPath("..\Reports/CustomerCPChart.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Customer CPChart"
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

            Report.Load(Server.MapPath("..\Reports/CPChartHistory.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Customer CPChart History"
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

End Class
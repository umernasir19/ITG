Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class TNAChartPopup
    Inherits System.Web.UI.Page
    Dim ObjTNAChart As New TNAChart
    Dim ObjPurchaseOrder As New PurchaseOrder
    Dim ObjTNAChartHistory As New TNAChartHistory
    Dim POID As String
    Dim GeneralCode As New GeneralCode
    Dim obTempCritical As New TempCriticalReport
    Dim Type As String
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
                        BindStatus()
                        SetGrid()
                        Session.Remove("Type")
                    Catch objUDException As UDException
                    End Try
                End If
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Private Sub BindGrid()
        Try
            '----New Code for reporttable
            obTempCritical.TruncateTable()
            GetSampleDevelpomentReportData()
            '----End new code
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                strSortExpression = dgTNAChart.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgTNAChart.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgTNAChart.RecordCount = objDataView.Count
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                dgTNAChart.Visible = True
                btnssave.Visible = True
                btnRequired.Visible = True
                lblmsg.Visible = False
                SetGrid()
            Else
                dgTNAChart.Visible = False
                btnssave.Visible = False
                btnRequired.Visible = False
                lblmsg.Visible = True
                lblmsg.Text = "Not Record Founf"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub GetSampleDevelpomentReportData()
        Dim dtsampledevlpoment As New DataTable
        dtsampledevlpoment = ObjTNAChart.GetSampleDevelpmentbyPOID(POID)
        Dim x As Integer
        Try
            For x = 0 To dtsampledevlpoment.Rows.Count - 1
                With obTempCritical
                    .ID = 0
                    .POID = dtsampledevlpoment.Rows(x)("POID")
                    .TNAChartID = dtsampledevlpoment.Rows(x)("TNAChartID")
                    .TNAProcessID = dtsampledevlpoment.Rows(x)("ProcessID")
                    .Status = dtsampledevlpoment.Rows(x)("Status")
                    .IdealDate = dtsampledevlpoment.Rows(x)("IdealDate")
                    .DateEstemated = dtsampledevlpoment.Rows(x)("EstimatedDate")
                    .QtyCompleted = dtsampledevlpoment.Rows(x)("QtyCompleted")
                    .Remarks = dtsampledevlpoment.Rows(x)("Remarks")
                    .SaveTempTNAChartHistoryReportData()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetRequiredtesttReportData()
        Dim dtsampledevlpoment As New DataTable
        dtsampledevlpoment = ObjTNAChart.GetRequuiretestDataByPOID(POID)
        Dim x As Integer
        Try
            For x = 0 To dtsampledevlpoment.Rows.Count - 1
                With obTempCritical
                    .ID = 0
                    .POID = dtsampledevlpoment.Rows(x)("POID")
                    .TNAChartID = dtsampledevlpoment.Rows(x)("TNAChartID")
                    .TNAProcessID = dtsampledevlpoment.Rows(x)("ProcessID")
                    .Status = dtsampledevlpoment.Rows(x)("Status")
                    .IdealDate = dtsampledevlpoment.Rows(x)("IdealDate")
                    .DateEstemated = dtsampledevlpoment.Rows(x)("EstimatedDate")
                    .QtyCompleted = dtsampledevlpoment.Rows(x)("QtyCompleted")
                    .Remarks = dtsampledevlpoment.Rows(x)("Remarks")
                    .SaveTempTNAChartHistoryReportData()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetAccessoriesReportData()
        Dim dtsampledevlpoment As New DataTable
        dtsampledevlpoment = ObjTNAChart.GetAccessoriesDataByPOID(POID)
        Dim x As Integer
        Try
            For x = 0 To dtsampledevlpoment.Rows.Count - 1
                With obTempCritical
                    .ID = 0
                    .POID = dtsampledevlpoment.Rows(x)("POID")
                    .TNAChartID = dtsampledevlpoment.Rows(x)("TNAChartID")
                    .TNAProcessID = dtsampledevlpoment.Rows(x)("ProcessID")
                    .Status = dtsampledevlpoment.Rows(x)("Status")
                    .IdealDate = dtsampledevlpoment.Rows(x)("IdealDate")
                    .DateEstemated = dtsampledevlpoment.Rows(x)("EstimatedDate")
                    .QtyCompleted = dtsampledevlpoment.Rows(x)("QtyCompleted")
                    .Remarks = dtsampledevlpoment.Rows(x)("Remarks")
                    .SaveTempTNAChartHistoryReportData()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridSampleDevelpoment()
        Try
            '----New Code for reporttable
            '  obTempCritical.TruncateTable()
            ' GetSampleDevelpomentReportData()
            '----End new code

            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            dgTNAChart.Columns(5).HeaderText = "Sample Type"
            If objDataView.Count > 0 Then
                strSortExpression = dgTNAChart.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgTNAChart.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgTNAChart.RecordCount = objDataView.Count
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                dgTNAChart.Visible = True
                btnssave.Visible = True
                btnRequired.Visible = True
                lblmsg.Visible = False
                SetGrid()
            Else
                dgTNAChart.Visible = False
                btnssave.Visible = False
                btnRequired.Visible = False
                lblmsg.Visible = True
                lblmsg.Text = "Not Record Founf"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridRequuiretest()
        Try
            '----New Code for reporttable
            ' obTempCritical.TruncateTable()
            '  GetRequiredtesttReportData()
            '----End new code

            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            dgTNAChart.Columns(5).HeaderText = "Lab Test"
            If objDataView.Count > 0 Then
                strSortExpression = dgTNAChart.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgTNAChart.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgTNAChart.RecordCount = objDataView.Count
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                dgTNAChart.Visible = True
                btnssave.Visible = True
                btnRequired.Visible = True
                lblmsg.Visible = False
                SetGrid()
            Else
                dgTNAChart.Visible = False
                btnssave.Visible = False
                btnRequired.Visible = False
                lblmsg.Visible = True
                lblmsg.Text = "Not Record Founf"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridAccessories()
        Try
            '----New Code for reporttable
            ' obTempCritical.TruncateTable()
            '  GetAccessoriesReportData()
            '----End new code

            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            dgTNAChart.Columns(5).HeaderText = "Accessories"
            If objDataView.Count > 0 Then
                strSortExpression = dgTNAChart.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgTNAChart.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgTNAChart.RecordCount = objDataView.Count
                dgTNAChart.DataSource = objDataView
                dgTNAChart.DataBind()
                dgTNAChart.Visible = True
                btnssave.Visible = True
                btnRequired.Visible = True
                lblmsg.Visible = False
                SetGrid()
            Else
                dgTNAChart.Visible = False
                btnssave.Visible = False
                btnRequired.Visible = False
                lblmsg.Visible = True
                lblmsg.Text = "Not Record Founf"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindStatus()
        Try
            Dim objDataGridItem As DataGridItem
            For Each objDataGridItem In dgTNAChart.Items
                With objDataGridItem
                    If (Not .FindControl("cmbStatus") Is Nothing) Then
                        Dim tempDropDown As DropDownList = CType(.FindControl("cmbStatus"), DropDownList)
                        With tempDropDown
                            .Items.Clear()
                            .Items.Insert(0, " ")
                            .Items.Insert(1, "Send to buyer")
                            .Items.Insert(2, "Rework advised")
                            .Items.Insert(3, "Approved")
                        End With
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindStatusRequuiretes()
        Try
            Dim objDataGridItem As DataGridItem
            For Each objDataGridItem In dgTNAChart.Items
                With objDataGridItem
                    If (Not .FindControl("cmbStatus") Is Nothing) Then
                        Dim tempDropDown As DropDownList = CType(.FindControl("cmbStatus"), DropDownList)
                        With tempDropDown
                            .Items.Clear()
                            .Items.Insert(0, " ")
                            .Items.Insert(1, "Send to Lab")
                            .Items.Insert(2, "Rejected")
                            .Items.Insert(3, "Approved")
                        End With
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindStatusAccessories()
        Try
            Dim objDataGridItem As DataGridItem
            For Each objDataGridItem In dgTNAChart.Items
                With objDataGridItem
                    If (Not .FindControl("cmbStatus") Is Nothing) Then
                        Dim tempDropDown As DropDownList = CType(.FindControl("cmbStatus"), DropDownList)
                        With tempDropDown
                            .Items.Clear()
                            .Items.Insert(0, " ")
                            .Items.Insert(1, "Pending")
                            .Items.Insert(2, "Complete")
                            .Items.Insert(3, "Approved")
                        End With
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SetData(ByVal IPOID)
        Dim Dt As DataTable
        Dt = ObjPurchaseOrder.GetPOData(IPOID)
        If Dt.Rows.Count > 0 Then
            lblBuyer.Text = Dt.Rows(0)("CustomerName")
            lblvender.Text = Dt.Rows(0)("VenderName")
            lblPONO.Text = Dt.Rows(0)("PONO")
            lblShipment.Text = Dt.Rows(0)("ShipmentDate")
        End If
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetProcessByPOID(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
        Dim ImgBtn As ImageButton = Master.FindControl("Impak")
        ImgBtn.Enabled = False
    End Sub
    Sub SetGrid()
        ''Dim x As Integer
        ''Dim ChkSelect As CheckBox
        ''Dim ddlstatus As DropDownList
        ''Dim dtStatusCheck As New DataTable
        ''Dim chkbox As New CheckBox
        ''dtStatusCheck = ObjTNAChart.GetProcessByPOID(POID)

        ''For x = 0 To dgTNAChart.Items.Count - 1
        ''    ChkSelect = CType(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
        ''    ddlstatus = CType(dgTNAChart.Items(x).FindControl("cmbStatus"), DropDownList)
        ''    '  If dgTNAChart.Items(x).Cells(3).Text = "SELECTED" Then
        ''    'dgTNAChart.Columns(4).Visible = False
        ''    ' If ChkSelect.Checked = True Then
        ''    'dgTNAChart.Items(x).Enabled = True
        ''    '  Else
        ''    '  dgTNAChart.Items(x).Enabled = False
        ''    '  End If
        ''    'Status Check Condition
        ''    If dtStatusCheck.Rows(x)("Status").ToString() = "Completed" Then
        ''        ddlstatus.SelectedIndex = 2
        ''    ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Pending" Then
        ''        ddlstatus.SelectedIndex = 1
        ''    ElseIf dtStatusCheck.Rows(x)("Status").ToString() = "Bottlenecks" Then
        ''        ddlstatus.SelectedIndex = 3
        ''    Else
        ''        ddlstatus.SelectedIndex = 0
        ''    End If
        ''    'end

        ''    ' Else
        ''    ' dgTNAChart.Columns(4).Visible = True
        ''    ' End If

        ''Next


        Dim x As Integer
        Dim ChkSelect As CheckBox
        For x = 0 To dgTNAChart.Items.Count - 1
            ChkSelect = CType(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
            If dgTNAChart.Items(x).Cells(3).Text = "SELECTED" Then
                'dgTNAChart.Columns(4).Visible = False
                If ChkSelect.Checked = True Then
                    dgTNAChart.Items(x).Enabled = True
                Else
                    dgTNAChart.Items(x).Enabled = False
                End If
            Else
                ' dgTNAChart.Columns(4).Visible = True
            End If
        Next

    End Sub
    Protected Sub btnRequired_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRequired.Click
        Dim i As Integer
        Dim ChkSelect As CheckBox
        Dim dtStatusCheck As New DataTable
        Dim chkbox As New CheckBox
        For i = 0 To dgTNAChart.Items.Count - 1
            ChkSelect = CType(dgTNAChart.Items(i).FindControl("chkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                dgTNAChart.Items(i).Enabled = True
            Else
                dgTNAChart.Items(i).Enabled = False
            End If
        Next
        '==============New
        ''''''''''''' Update Selected Status
        ObjTNAChart.UpdateSelecteStatus(POID)
        '---------------
        Dim Str As String = "("
        Dim ID As String
        Dim x As Integer
        For x = 0 To dgTNAChart.Items.Count - 1
            ChkSelect = CType(dgTNAChart.Items(x).FindControl("chkSelect"), CheckBox)
            ID = dgTNAChart.Items(x).Cells(0).Text
            If ChkSelect.Checked = False Then
                Str = Str + ID + ","
            End If
        Next
        Str = Str + ")"
        Str = Replace(Str, ",)", ")")
        ObjTNAChart.UpdateSelecte(Str)
        'Implement the Selection  and view Selected Process Now
        Try
            Dim objDataView As DataView
            objDataView = LoadData(CLng(POID))
            Session("objDataView") = objDataView
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadDataSampleDevelpoment(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetProcessByPOID(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Function that Loads the data and return dataview
    Function LoadDataRequuiretest(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetRequuiretestProcessByPOID(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Function that Loads the data and return dataview
    Function LoadDataAccessories(ByVal lPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTNAChart.GetAccessoriesProcessByPOID(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub imgSampleDevelpoment_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSampleDevelpoment.Click
        Dim objDataView As DataView
        Type = "SampleDevelopment"
        Session("Type") = Type
        Try
            objDataView = LoadDataSampleDevelpoment(CLng(POID))
            Session("objDataView") = objDataView
            BindGridSampleDevelpoment()
            BindStatus()
            SetGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ImageRequuiretest_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageRequuiretest.Click
        Dim objDataView As DataView
        Type = "LabTest"
        Session("Type") = Type
        Try
            objDataView = LoadDataRequuiretest(CLng(POID))
            Session("objDataView") = objDataView
            BindGridRequuiretest()
            BindStatusRequuiretes()
            SetGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ImageAccessories_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageAccessories.Click
        Dim objDataView As DataView
        Type = "Accessories"
        Session("Type") = Type
        Try
            objDataView = LoadDataAccessories(CLng(POID))
            Session("objDataView") = objDataView
            BindGridAccessories()
            BindStatusAccessories()
            SetGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnssave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnssave.Click
        Try
            Dim x As Integer
            Dim i As Integer
            Dim chkUpdate As CheckBox
            For x = 0 To dgTNAChart.Items.Count - 1
                chkUpdate = CType(dgTNAChart.Items(x).FindControl("chkUpdate"), CheckBox)
                If chkUpdate.Checked = True Then
                    Dim cmbStatus As DropDownList = CType(dgTNAChart.Items(x).FindControl("cmbStatus"), DropDownList)
                    Dim QtyCompleted As TextBox = CType(dgTNAChart.Items(x).FindControl("txtQuantityCmpltd"), TextBox)
                    Dim txtActualDate As RadDatePicker = CType(dgTNAChart.Items(x).FindControl("txtActualDate"), RadDatePicker)
                    Dim txtRemarks As TextBox = CType(dgTNAChart.Items(x).FindControl("txtRemarks"), TextBox)

                    Dim lChartID As Integer = dgTNAChart.Items(x).Cells(0).Text
                    Dim ProcessID As Integer = dgTNAChart.Items(x).Cells(2).Text
                    Dim ActualDate As String = txtActualDate.SelectedDate

                    If Not ActualDate = "" Then
                        With ObjTNAChart
                            .GetTNAChartById(lChartID)
                            .DateEstemated = dgTNAChart.Items(x).Cells(10).Text
                            .Status = cmbStatus.SelectedItem.Text
                            .ActualDate = txtActualDate.SelectedDate
                            .Remarks = txtRemarks.Text
                            .QtyCompleted = QtyCompleted.Text
                            .Selected = True
                            .SelectedStatus = "SELECTED"
                            .TNAProcessID = ProcessID
                            .SaveTNAChart()
                        End With
                        '-------------- History Manage
                        With ObjTNAChartHistory
                            .CreationDate = Date.Now
                            .TNAChartID = lChartID
                            .IdealDate = ObjTNAChart.IdealDate
                            .DateEstemated = dgTNAChart.Items(x).Cells(10).Text
                            .ActualDate = txtActualDate.SelectedDate
                            .QtyCompleted = ObjTNAChart.QtyCompleted
                            .Remarks = txtRemarks.Text
                            .Status = cmbStatus.SelectedItem.Text
                            .TNAProcessID = ProcessID
                            .SaveTNAChartHistory()
                        End With
                    Else
                        lblmsg.Visible = True
                        lblmsg.Text = "Please Enter Date"
                    End If
                    lblmsg.Visible = True
                    lblmsg.Text = "Saved Successfully."
                Else
                End If
            Next 'end x loop
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        Try
            Dim ProcessID As String
            Dim Chktype = Session("Type")
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            'Report.Load(Server.MapPath("..\Reports/TNAChartHistory2.rpt"))
            If Chktype = "SampleDevelopment" Then
                Report.Load(Server.MapPath("..\Reports/TNAChartHistory2.rpt"))
            ElseIf Chktype = "LabTest" Then
                Report.Load(Server.MapPath("..\Reports/TNAChartHistoryLabTest.rpt"))
            ElseIf Chktype = "Accessories" Then
                Report.Load(Server.MapPath("..\Reports/TNAChartHistoryAccessories.rpt"))
            Else
                Report.Load(Server.MapPath("..\Reports/TNAChartHistory2.rpt"))
            End If
            Session.Remove("Type")
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Critical Path"
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
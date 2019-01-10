Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports Telerik.Web.UI

Public Class LoginedUserView
    Inherits System.Web.UI.Page
    Dim ObjUserLogined As New UserLogined
    Dim objUser As New User
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindUserName()
            BindDepartment()

            lblTo.Visible = False
            lblFrom.Visible = False
            lblDepartment.Visible = False
            cmbDepartment.Visible = False
            txtDateFrom.Visible = False
            txtDateTo.Visible = False
            lblUserName.Visible = True
            cmbUserName.Visible = True

        End If
        PageHeader("Euro Centra Pakistan Logined User TIME STAMP")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindUserName()
        Dim dtCustomer As DataTable
        dtCustomer = objUser.getALlUMUserNew
        cmbUserName.DataSource = dtCustomer
        cmbUserName.DataTextField = "UserName"
        cmbUserName.DataValueField = "UserID"
        cmbUserName.DataBind()
        ' cmbUserName.Items.Insert(0, New ListItem("All User...", "0"))
    End Sub
    Sub BindDepartment()
        Dim dtCustomer As DataTable
        dtCustomer = objUser.getAllECPDivisionNew
        cmbDepartment.DataSource = dtCustomer
        cmbDepartment.DataTextField = "ECPDivistion"
        cmbDepartment.DataValueField = "ECPDivistion"
        cmbDepartment.DataBind()
        'cmbDepartment.Items.Insert(0, New ListItem("All Department...", "0"))
    End Sub
    Protected Sub btnSreach_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSreach.Click
        Try
            Dim objDataView As DataView
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try


        Catch ex As Exception

        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If cmbSearchType.SelectedItem.Text = "By User Name" Then
            objDataTable = ObjUserLogined.GetAllLogindUser(cmbUserName.SelectedValue, 0, "", "")
          
        ElseIf cmbSearchType.SelectedItem.Text = "By Department" Then
            objDataTable = ObjUserLogined.GetAllLogindUser(0, cmbDepartment.SelectedValue, "", "")
           
        ElseIf cmbSearchType.SelectedItem.Text = "By Date" Then
            objDataTable = ObjUserLogined.GetAllLogindUser(0, 0, txtDateFrom.SelectedDate, txtDateTo.SelectedDate)
        End If
        'If objDataTable.Rows.Count > 0 Then
        '    lnkPrint.Visible = True
        '    uplnkPrint.Update()
        'End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgLoginedUser.DataSource = objDataView
            dgLoginedUser.DataBind()
 
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkPrint.Click
        Try
            ' Response.Write("<script> window.open('LoginedUserReport.aspx?ReportName=TIMESTAMP&DateTo=" & txtDateTo.SelectedDate & "&DateFrom=" & txtDateFrom.SelectedDate & "&UserID=" & cmbUserName.SelectedValue & "&Department=" & cmbDepartment.SelectedValue & "', 'newwindow', 'left=200, top=40, height=650, width=670, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            If cmbSearchType.SelectedItem.Text = "By User Name" Then
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                Report.Load(Server.MapPath("..\Reports/UserWiseReport.rpt"))
                Dim FileName As String = "Logined Report-" + cmbUserName.SelectedItem.Text
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, cmbUserName.SelectedValue)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "Logined Report-" + cmbUserName.SelectedItem.Text + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next
            ElseIf cmbSearchType.SelectedItem.Text = "By Department" Then
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                Report.Load(Server.MapPath("..\Reports/LoginedUserDepartmentWise.rpt"))
                Dim FileName As String = "Logined Report-" + cmbDepartment.SelectedItem.Text
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, cmbDepartment.SelectedItem.Text)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "Logined Report-" + cmbDepartment.SelectedItem.Text + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next

            ElseIf cmbSearchType.SelectedItem.Text = "By Date" Then
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                Report.Load(Server.MapPath("..\Reports/LoginedUserDateWise.rpt"))
                Dim FileName As String = "Logined Report_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Dim fromDate As String = txtDateFrom.SelectedDate.Value.ToString("MM/dd/yyyy")
                Dim ToDate As String = txtDateTo.SelectedDate.Value.ToString("MM/dd/yyyy")
                Report.SetParameterValue(0, fromDate)
                Report.SetParameterValue(1, ToDate)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "Logined Report_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy") + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LnkCurrentMonth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkCurrentMonth.Click
        Try
            '  Response.Write("<script> window.open('LoginedUserViewCurrentMonth.aspx?', 'newwindow', 'left=400, top=220, height=450, width=470, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upLnkCurrentMonthy, Me.upLnkCurrentMonthy.GetType(), "New ClientScript", "window.open('LoginedUserViewCurrentMonth.aspx?', 'newwindow', 'left=400, top=200, height=450, width=470, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSearchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSearchType.SelectedIndexChanged
        Try
            If cmbSearchType.SelectedItem.Text = "By User Name" Then
                lblTo.Visible = False
                lblFrom.Visible = False
                lblDepartment.Visible = False
                cmbDepartment.Visible = False
                txtDateFrom.Visible = False
                txtDateTo.Visible = False
                lblUserName.Visible = True
                cmbUserName.Visible = True

                uplblUserName.Update()
                upcmbUserName.Update()
                uplblUserName.Update()
                upcmbDepartment.Update()
                uptxtDateTo.Update()
                uplblTo.Update()
                uptxtDateFrom.Update()
                uplblFrom.Update()
                uplblDepartment.Update()
            ElseIf cmbSearchType.SelectedItem.Text = "By Department" Then
                lblUserName.Visible = False
                cmbUserName.Visible = False
                lblTo.Visible = False
                lblFrom.Visible = False
                lblDepartment.Visible = True
                cmbDepartment.Visible = True
                txtDateFrom.Visible = False
                txtDateTo.Visible = False

                uplblUserName.Update()
                upcmbUserName.Update()
                upcmbDepartment.Update()

                uptxtDateTo.Update()
                uplblTo.Update()
                uptxtDateFrom.Update()
                uplblFrom.Update()
                uplblDepartment.Update()
            ElseIf cmbSearchType.SelectedItem.Text = "By Date" Then
                lblUserName.Visible = False
                cmbUserName.Visible = False
                lblTo.Visible = True
                lblFrom.Visible = True
                lblDepartment.Visible = False
                cmbDepartment.Visible = False
                txtDateFrom.Visible = True
                txtDateTo.Visible = True
             
                upcmbUserName.Update()
                upcmbDepartment.Update()
                uplblUserName.Update()
                uptxtDateTo.Update()
                uplblTo.Update()
                uptxtDateFrom.Update()
                uplblFrom.Update()
                uplblDepartment.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
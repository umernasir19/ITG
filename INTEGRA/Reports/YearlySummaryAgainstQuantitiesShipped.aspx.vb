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
Public Class YearlySummaryAgainstQuantitiesShipped
    Inherits System.Web.UI.Page
    Dim objSummaryStyleQtybyDept As New SummaryStyleQtybyDept
    Dim objYeraltSummaryofwithheld As New YeraltSummaryofwithheld
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = objYeraltSummaryofwithheld.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = objYeraltSummaryofwithheld.GetDept(cmbCustomer.SelectedValue)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "Department"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("All", "0"))

    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindDept(cmbCustomer.SelectedValue)

    End Sub
    Sub BindDept(ByVal CustomerID As Long)
        Dim dt As DataTable
        dt = objYeraltSummaryofwithheld.GetDept(CustomerID)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "Department"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("All", "0"))
    End Sub

    Sub GetDataForReport()
        objYeraltSummaryofwithheld.TruncateTable()
        Dim dtDept As DataTable = objYeraltSummaryofwithheld.GetDept(cmbCustomer.SelectedValue) 'objYeraltSummaryofwithheld.GetDept()
        Dim dtYear1 As DataTable
        Dim dtYear1WH As DataTable
        Dim dtYear2 As DataTable
        Dim dtYear2WH As DataTable
        Dim dtYear3 As DataTable
        Dim dtYear3WH As DataTable

        Dim i As Integer
        Dim Department As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Department", GetType(String))
            .Columns.Add("Y1QTY", GetType(String))
            .Columns.Add("Y1WITHHELD", GetType(String))
            .Columns.Add("Y2QTY", GetType(String))
            .Columns.Add("Y2WITHHELD", GetType(String))
            .Columns.Add("Y3QTY", GetType(String))
            .Columns.Add("Y3WITHHELD", GetType(String))
        End With
        If cmbDept.SelectedItem.Text = "All" Then
            For i = 0 To dtDept.Rows.Count - 1
                Department = dtDept.Rows(i)("Department")
                dtYear1 = objYeraltSummaryofwithheld.getdataforReport12New(Department, "2014", cmbCustomer.SelectedValue)
                dtYear1WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNew(Department, "2014", cmbCustomer.SelectedValue)
                dtYear2 = objYeraltSummaryofwithheld.getdataforReport12New(Department, "2015", cmbCustomer.SelectedValue)
                dtYear2WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNew(Department, "2015", cmbCustomer.SelectedValue)
                dtYear3 = objYeraltSummaryofwithheld.getdataforReport12NewMonthWise(Department, "2016", cmbCustomer.SelectedValue, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)
                dtYear3WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNewMonthWise(Department, "2016", cmbCustomer.SelectedValue, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)
                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("Department") = Department
                If dtYear1.Rows.Count > 0 Then
                    Dr("Y1QTY") = dtYear1.Rows(0)("Qty")
                    Dr("Y1WITHHELD") = dtYear1WH.Rows(0)("WITHHELD")
                Else
                    Dr("Y1QTY") = 0
                    Dr("Y1WITHHELD") = 0
                End If
                If dtYear2.Rows.Count > 0 Then
                    Dr("Y2QTY") = dtYear2.Rows(0)("Qty")
                    Dr("Y2WITHHELD") = dtYear2WH.Rows(0)("WITHHELD")
                Else
                    Dr("Y2QTY") = 0
                    Dr("Y2WITHHELD") = 0
                End If
                If dtYear3.Rows.Count > 0 Then
                    Dr("Y3QTY") = dtYear3.Rows(0)("Qty")
                    Dr("Y3WITHHELD") = dtYear3WH.Rows(0)("WITHHELD")
                Else
                    Dr("Y3QTY") = 0
                    Dr("Y3WITHHELD") = 0
                End If

                dtFinal.Rows.Add(Dr)
            Next
        Else
            Department = cmbDept.SelectedItem.Text
            dtYear1 = objYeraltSummaryofwithheld.getdataforReport12New(Department, "2014", cmbCustomer.SelectedValue)
            dtYear1WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNew(Department, "2014", cmbCustomer.SelectedValue)
            dtYear2 = objYeraltSummaryofwithheld.getdataforReport12New(Department, "2015", cmbCustomer.SelectedValue)
            dtYear2WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNew(Department, "2015", cmbCustomer.SelectedValue)
            dtYear3 = objYeraltSummaryofwithheld.getdataforReport12NewMonthWise(Department, "2016", cmbCustomer.SelectedValue, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)
            dtYear3WH = objYeraltSummaryofwithheld.getdataforReport12withHeldNewMonthWise(Department, "2016", cmbCustomer.SelectedValue, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Department") = Department
            If dtYear1.Rows.Count > 0 Then
                Dr("Y1QTY") = dtYear1.Rows(0)("Qty")
                Dr("Y1WITHHELD") = dtYear1WH.Rows(0)("WITHHELD")
            Else
                Dr("Y1QTY") = 0
                Dr("Y1WITHHELD") = 0
            End If
            If dtYear2.Rows.Count > 0 Then
                Dr("Y2QTY") = dtYear2.Rows(0)("Qty")
                Dr("Y2WITHHELD") = dtYear2WH.Rows(0)("WITHHELD")
            Else
                Dr("Y2QTY") = 0
                Dr("Y2WITHHELD") = 0
            End If
            If dtYear3.Rows.Count > 0 Then
                Dr("Y3QTY") = dtYear3.Rows(0)("Qty")
                Dr("Y3WITHHELD") = dtYear3WH.Rows(0)("WITHHELD")
            Else
                Dr("Y3QTY") = 0
                Dr("Y3WITHHELD") = 0
            End If

            dtFinal.Rows.Add(Dr)
        End If
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objYeraltSummaryofwithheld
                .TempId = 0
                .Department = dtFinal.Rows(A)("Department")
                .Y1QTY = dtFinal.Rows(A)("Y1QTY")
                .Y1WITHHELD = dtFinal.Rows(A)("Y1WITHHELD")
                .Y2QTY = dtFinal.Rows(A)("Y2QTY")
                .Y2WITHHELD = dtFinal.Rows(A)("Y2WITHHELD")
                .Y3QTY = dtFinal.Rows(A)("Y3QTY")
                .Y3WITHHELD = dtFinal.Rows(A)("Y3WITHHELD")
                .SaveTempYeraltSummaryofwithheld()
            End With
        Next
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            GetDataForReport()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            ' Report.Load(Server.MapPath("..\Reports/EnquirySystemALL.rpt"))
            'If cmbType.SelectedValue = 0 Then
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemNew2.rpt"))
            'Else
            '    Report.Load(Server.MapPath("..\Reports/EnquirySystemByTime.rpt"))
            'End If

            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport12New.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "YearlySummaryAgainstQuantitiesShipped"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, cmbCustomer.SelectedItem.Text)
            Report.SetParameterValue(1, cmbDept.SelectedItem.Text)
            Report.SetParameterValue(2, cmbFromMonth.SelectedItem.Text)
            Report.SetParameterValue(3, cmbToMonth.SelectedItem.Text)


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
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
Public Class WithHeldAgainstShippedQty
    Inherits System.Web.UI.Page
    Dim objYeraltSummaryofwithheld As New YeraltSummaryofwithheld
    Dim objWithheldAgainstQty As New WithheldAgainstQty
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()

        Else

        End If
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = objWithheldAgainstQty.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = objWithheldAgainstQty.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("ALL", "0"))

    End Sub
    Sub GetDataForReport()
        objWithheldAgainstQty.TruncateTable()
        Dim dtDept As DataTable = objWithheldAgainstQty.GetVender()
        Dim dtYear1 As DataTable
        Dim dtYear1WH As DataTable
        'Dim dtYear2 As DataTable
        'Dim dtYear2WH As DataTable
        'Dim dtYear3 As DataTable
        'Dim dtYear3WH As DataTable

        Dim i As Integer
        Dim Supplier As String
        Dim Supplierid As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Supplier", GetType(String))
            .Columns.Add("Y1QTY", GetType(String))
            .Columns.Add("Y1WITHHELD", GetType(String))
            '.Columns.Add("Y2QTY", GetType(String))
            '.Columns.Add("Y2WITHHELD", GetType(String))
            '.Columns.Add("Y3QTY", GetType(String))
            '.Columns.Add("Y3WITHHELD", GetType(String))
        End With
        For i = 0 To dtDept.Rows.Count - 1
            Supplier = dtDept.Rows(i)("VenderName")
            Supplierid = dtDept.Rows(i)("Supplierid")
            ' dtYear1 = objWithheldAgainstQty.getdataforReport4(Supplierid, cmbyear.SelectedItem.Text)
            'dtYear1WH = objWithheldAgainstQty.getdataforReport4withHeld(Supplierid, cmbyear.SelectedItem.Text)

            dtYear1 = objWithheldAgainstQty.getdataforReport4New(Supplierid, cmbyear.SelectedItem.Text, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
            dtYear1WH = objWithheldAgainstQty.getdataforReport4withHeldNew(Supplierid, cmbyear.SelectedItem.Text, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
            'dtYear2 = objYeraltSummaryofwithheld.getdataforReport12(Department, "2015")
            'dtYear2WH = objYeraltSummaryofwithheld.getdataforReport12withHeld(Department, "2015")
            'dtYear3 = objYeraltSummaryofwithheld.getdataforReport12(Department, "2016")
            'dtYear3WH = objYeraltSummaryofwithheld.getdataforReport12withHeld(Department, "2016")
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Supplier") = Supplier
            If dtYear1.Rows.Count > 0 Then
                Dr("Y1QTY") = dtYear1.Rows(0)("Qty")
                If dtYear1WH.Rows.Count > 0 Then
                    Dr("Y1WITHHELD") = dtYear1WH.Rows(0)("WITHHELD")
                Else
                    Dr("Y1WITHHELD") = 0
                End If
            Else
                Dr("Y1QTY") = 0
                Dr("Y1WITHHELD") = 0
            End If
            'If dtYear2.Rows.Count > 0 Then
            '    Dr("Y2QTY") = dtYear2.Rows(0)("Qty")
            '    Dr("Y2WITHHELD") = dtYear2WH.Rows(0)("WITHHELD")
            'Else
            '    Dr("Y2QTY") = 0
            '    Dr("Y2WITHHELD") = 0
            'End If
            'If dtYear3.Rows.Count > 0 Then
            '    Dr("Y3QTY") = dtYear3.Rows(0)("Qty")
            '    Dr("Y3WITHHELD") = dtYear3WH.Rows(0)("WITHHELD")
            'Else
            '    Dr("Y3QTY") = 0
            '    Dr("Y3WITHHELD") = 0
            'End If

            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objWithheldAgainstQty
                .TempId = 0
                .Supplier = dtFinal.Rows(A)("Supplier")
                .Y1QTY = dtFinal.Rows(A)("Y1QTY")
                .Y1WITHHELD = dtFinal.Rows(A)("Y1WITHHELD")
                '.Y2QTY = dtFinal.Rows(A)("Y2QTY")
                '.Y2WITHHELD = dtFinal.Rows(A)("Y2WITHHELD")
                '.Y3QTY = dtFinal.Rows(A)("Y3QTY")
                '.Y3WITHHELD = dtFinal.Rows(A)("Y3WITHHELD")
                .SaveTempWithheldAgainstQty()
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

            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport4.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "WithHeldAgainsShippedtQuantiy"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, cmbyear.SelectedItem.Text)
            Report.SetParameterValue(1, cmbCustomer.SelectedItem.Text)
            Report.SetParameterValue(2, cmbDept.SelectedItem.Text)


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
    Protected Sub cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindDept(cmbCustomer.SelectedValue)

    End Sub
    Sub BindDept(ByVal CustomerID As Long)
        Dim dt As DataTable
        dt = objWithheldAgainstQty.GetDeptCustomerWise(CustomerID)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
End Class
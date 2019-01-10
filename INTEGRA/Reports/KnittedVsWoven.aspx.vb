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
Public Class KnittedVsWoven
    Inherits System.Web.UI.Page
    Dim objKnittedVsWoven As New tempKnittedVsWoven
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub GetDataForReport()
        objKnittedVsWoven.TruncateTable()
        '  Dim dtDept As DataTable = objKnittedVsWoven.GetDept()
        Dim Dept1 As String = "Knitwear"
        Dim Dept2 As String = "Woven"

        Dim dtYear1 As DataTable
        Dim dtYear2 As DataTable
        Dim dtYear3 As DataTable

        Dim i As Integer
        Dim Department As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Department", GetType(String))
            .Columns.Add("Y1QTY", GetType(String))
            .Columns.Add("Y1NoOfOrder", GetType(String))
            .Columns.Add("Y1NoOfSupplier", GetType(String))
            .Columns.Add("Y2QTY", GetType(String))
            .Columns.Add("Y2NoOfOrder", GetType(String))
            .Columns.Add("Y2NoOfSupplier", GetType(String))
            .Columns.Add("Y3QTY", GetType(String))
            .Columns.Add("Y3NoOfOrder", GetType(String))
            .Columns.Add("Y3NoOfSupplier", GetType(String))
        End With
        For i = 0 To 1
            If i = 0 Then
                Department = Dept1
            Else
                Department = Dept2
            End If

            dtYear1 = objKnittedVsWoven.getdataforReport13(Department, "2014")
            dtYear2 = objKnittedVsWoven.getdataforReport13(Department, "2015")
            dtYear3 = objKnittedVsWoven.getdataforReport13Monthwise(Department, "2016", cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)

            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            If i = 0 Then
                Dr("Department") = Dept1
            Else
                Dr("Department") = Dept2
            End If
            If dtYear1.Rows.Count > 0 Then
                Dr("Y1QTY") = dtYear1.Rows(0)("QTY")
                Dr("Y1NoOfOrder") = dtYear1.Rows(0)("NoOfOrder")
                Dr("Y1NoOfSupplier") = dtYear1.Rows(0)("NoOfSupplier")
            Else
                Dr("Y1QTY") = 0
                Dr("Y1NoOfOrder") = 0
                Dr("Y1NoOfSupplier") = 0
            End If
            If dtYear2.Rows.Count > 0 Then
                Dr("Y2QTY") = dtYear2.Rows(0)("Qty")
                Dr("Y2NoOfOrder") = dtYear2.Rows(0)("NoOfOrder")
                Dr("Y2NoOfSupplier") = dtYear2.Rows(0)("NoOfSupplier")
            Else
                Dr("Y2QTY") = 0
                Dr("Y2NoOfOrder") = 0
                Dr("Y2NoOfSupplier") = 0
            End If
            If dtYear3.Rows.Count > 0 Then
                Dr("Y3QTY") = dtYear3.Rows(0)("Qty")
                Dr("Y3NoOfOrder") = dtYear3.Rows(0)("NoOfOrder")
                Dr("Y3NoOfSupplier") = dtYear3.Rows(0)("NoOfSupplier")
            Else
                Dr("Y3QTY") = 0
                Dr("Y3NoOfOrder") = 0
                Dr("Y3NoOfSupplier") = 0
            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objKnittedVsWoven
                .TempId = 0
                .Department = dtFinal.Rows(A)("Department")
                .Y1QTY = dtFinal.Rows(A)("Y1QTY")
                .Y1NoOfOrder = dtFinal.Rows(A)("Y1NoOfOrder")
                .Y1NoOfSupplier = dtFinal.Rows(A)("Y1NoOfSupplier")
                .Y2QTY = dtFinal.Rows(A)("Y2QTY")
                .Y2NoOfOrder = dtFinal.Rows(A)("Y2NoOfOrder")
                .Y2NoOfSupplier = dtFinal.Rows(A)("Y2NoOfSupplier")
                .Y3QTY = dtFinal.Rows(A)("Y3QTY")
                .Y3NoOfOrder = dtFinal.Rows(A)("Y3NoOfOrder")
                .Y3NoOfSupplier = dtFinal.Rows(A)("Y3NoOfSupplier")
                .SavetempKnittedVsWoven()
            End With
        Next
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            GetDataForReport()
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

            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport13New.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "WovenVsKnitted"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, cmbFromMonth.SelectedItem.Text)
            Report.SetParameterValue(1, cmbToMonth.SelectedItem.Text)


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
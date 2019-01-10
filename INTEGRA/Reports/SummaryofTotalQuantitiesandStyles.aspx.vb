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
Public Class SummaryofTotalQuantitiesandStyles
    Inherits System.Web.UI.Page

    '  Dim objSummaryStyleQtybyDept As New SummaryStyleQtybyDept
    Dim objTempSummaryofTotalQuantitiesandStyles As New TempSummaryofTotalQuantitiesandStyles
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'binddept()
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = objTempSummaryofTotalQuantitiesandStyles.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = objTempSummaryofTotalQuantitiesandStyles.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbBuyingDept.DataSource = dt
        cmbBuyingDept.DataTextField = "BuyingDept"
        cmbBuyingDept.DataBind()
        cmbBuyingDept.Items.Insert(0, New ListItem("ALL", "0"))

    End Sub
    Sub binddept()
        Dim dtDept As DataTable = objTempSummaryofTotalQuantitiesandStyles.GetDept()
        cmbBuyingDept.DataSource = dtDept
        cmbBuyingDept.DataTextField = "Department"
        cmbBuyingDept.DataValueField = "Department"
        cmbBuyingDept.DataBind()
    End Sub


    Sub GetDataForReport()
        objTempSummaryofTotalQuantitiesandStyles.TruncateTable()
        Dim dtItem As DataTable = objTempSummaryofTotalQuantitiesandStyles.GetItem()
        Dim dtSeason1 As DataTable
        Dim dtSeason2 As DataTable
        Dim dtSeason3 As DataTable
        Dim dtSeason4 As DataTable
        Dim i, Y As Integer
        Dim Item As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Item", GetType(String))
            .Columns.Add("S1QTY", GetType(String))
            .Columns.Add("S1LINE", GetType(String))
            .Columns.Add("S2QTY", GetType(String))
            .Columns.Add("S2LINE", GetType(String))
            .Columns.Add("S3QTY", GetType(String))
            .Columns.Add("S3LINE", GetType(String))
            .Columns.Add("S4QTY", GetType(String))
            .Columns.Add("S4LINE", GetType(String))
        End With
        For i = 0 To dtItem.Rows.Count - 1
            Item = dtItem.Rows(i)("Item")
            dtSeason1 = objTempSummaryofTotalQuantitiesandStyles.getdataforReport6New(Item, "SS/2015", cmbBuyingDept.SelectedItem.Text, cmbCustomer.SelectedItem.Text)
            dtSeason2 = objTempSummaryofTotalQuantitiesandStyles.getdataforReport6New(Item, "AW/2015", cmbBuyingDept.SelectedItem.Text, cmbCustomer.SelectedItem.Text)
            dtSeason3 = objTempSummaryofTotalQuantitiesandStyles.getdataforReport6New(Item, "SS/2016", cmbBuyingDept.SelectedItem.Text, cmbCustomer.SelectedItem.Text)
            dtSeason4 = objTempSummaryofTotalQuantitiesandStyles.getdataforReport6New(Item, "AW/2016", cmbBuyingDept.SelectedItem.Text, cmbCustomer.SelectedItem.Text)
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Item") = Item
            If dtSeason1.Rows.Count > 0 Then
                Dim Qty As Decimal = 0
                Dim line As Decimal = 0
                For Y = 0 To dtSeason1.Rows.Count - 1
                    Qty = Qty + Val(dtSeason1.Rows(Y)("Qty"))
                    line = line + Val(dtSeason1.Rows(Y)("line"))
                    Dr("S1QTY") = Qty
                    Dr("S1LINE") = line
                Next
                ' Dr("S1QTY") = dtSeason1.Rows(0)("Qty")
                ' Dr("S1LINE") = dtSeason1.Rows(0)("line")
            Else
                Dr("S1QTY") = 0
                Dr("S1LINE") = 0
            End If
            If dtSeason2.Rows.Count > 0 Then
                Dim Qty As Decimal = 0
                Dim line As Decimal = 0
                For Y = 0 To dtSeason2.Rows.Count - 1
                    Qty = Qty + Val(dtSeason2.Rows(Y)("Qty"))
                    line = line + Val(dtSeason2.Rows(Y)("line"))
                    Dr("S2QTY") = Qty
                    Dr("S2LINE") = line
                Next
                'Dr("S2QTY") = dtSeason2.Rows(0)("Qty")
                'Dr("S2LINE") = dtSeason2.Rows(0)("line")
            Else
                Dr("S2QTY") = 0
                Dr("S2LINE") = 0
            End If
            If dtSeason3.Rows.Count > 0 Then
                Dim Qty As Decimal = 0
                Dim line As Decimal = 0
                For Y = 0 To dtSeason3.Rows.Count - 1
                    Qty = Qty + Val(dtSeason3.Rows(Y)("Qty"))
                    line = line + Val(dtSeason3.Rows(Y)("line"))
                    Dr("S3QTY") = Qty
                    Dr("S3LINE") = line
                Next
                'Dr("S3QTY") = dtSeason3.Rows(0)("Qty")
                'Dr("S3LINE") = dtSeason3.Rows(0)("line")
            Else
                Dr("S3QTY") = 0
                Dr("S3LINE") = 0
            End If
            If dtSeason4.Rows.Count > 0 Then
                Dim Qty As Decimal = 0
                Dim line As Decimal = 0
                For Y = 0 To dtSeason4.Rows.Count - 1
                    Qty = Qty + Val(dtSeason4.Rows(Y)("Qty"))
                    line = line + Val(dtSeason4.Rows(Y)("line"))
                    Dr("S4QTY") = Qty
                    Dr("S4LINE") = line
                Next
                ' Dr("S4QTY") = dtSeason4.Rows(0)("Qty")
                'Dr("S4LINE") = dtSeason4.Rows(0)("line")
            Else
                Dr("S4QTY") = 0
                Dr("S4LINE") = 0
            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objTempSummaryofTotalQuantitiesandStyles
                .TempId = 0
                .Item = dtFinal.Rows(A)("Item")
                .S1QTY = dtFinal.Rows(A)("S1QTY")
                .S1LINE = dtFinal.Rows(A)("S1LINE")
                .S2QTY = dtFinal.Rows(A)("S2QTY")
                .S2LINE = dtFinal.Rows(A)("S2LINE")
                .S3QTY = dtFinal.Rows(A)("S3QTY")
                .S3LINE = dtFinal.Rows(A)("S3LINE")
                .S4QTY = dtFinal.Rows(A)("S4QTY")
                .S4LINE = dtFinal.Rows(A)("S4LINE")
                .SaveTempSummaryStyleQtybyDept()
            End With
        Next
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            GetDataForReport()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions


            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport6.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "SummaryofTotalQuantitiesandStyles"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, cmbBuyingDept.SelectedItem.Text)
            Report.SetParameterValue(1, cmbCustomer.SelectedItem.Text)

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
        dt = objTempSummaryofTotalQuantitiesandStyles.GetDeptCustomerWise(CustomerID)
        cmbBuyingDept.DataSource = dt
        cmbBuyingDept.DataTextField = "BuyingDept"
        cmbBuyingDept.DataBind()
        cmbBuyingDept.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
End Class
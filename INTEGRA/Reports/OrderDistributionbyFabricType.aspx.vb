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
Public Class OrderDistributionbyFabricType
    Inherits System.Web.UI.Page
    Dim objReportClass As New EuroCentra.ReportClass
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            BindCustomer()
        End If
       
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = objReportClass.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = objReportClass.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbBuyingDept.DataSource = dt
        cmbBuyingDept.DataTextField = "BuyingDept"
        cmbBuyingDept.DataBind()
        cmbBuyingDept.Items.Insert(0, New ListItem("ALL", "0"))

    End Sub
    Sub GetDataForReport()
        objReportClass.TruncateTable()
        Dim dtfabrictype As DataTable = objReportClass.GetFabric()
        Dim dtyear1 As DataTable
        Dim dtyear2 As DataTable
        Dim dtyear3 As DataTable
        Dim i As Integer
        Dim FabricType As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("FabricType", GetType(String))
            .Columns.Add("Y1NoOforder", GetType(String))
            .Columns.Add("Y1OrderQty", GetType(String))
            .Columns.Add("Y1PerTotal", GetType(String))
            .Columns.Add("Y2NoOforder", GetType(String))
            .Columns.Add("Y2OrderQty", GetType(String))
            .Columns.Add("Y2PerTotal", GetType(String))
            .Columns.Add("Y3NoOforder", GetType(String))
            .Columns.Add("Y3OrderQty", GetType(String))
            .Columns.Add("Y3PerTotal", GetType(String))
        End With
        For i = 0 To dtfabrictype.Rows.Count - 1
            FabricType = dtfabrictype.Rows(i)("FabricType")
            dtyear1 = objReportClass.getdataforReport8New("2014", FabricType, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue, cmbCustomer.SelectedItem.Text, cmbBuyingDept.SelectedItem.Text)
            dtyear2 = objReportClass.getdataforReport8New("2015", FabricType, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue, cmbCustomer.SelectedItem.Text, cmbBuyingDept.SelectedItem.Text)
            dtyear3 = objReportClass.getdataforReport8New("2016", FabricType, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue, cmbCustomer.SelectedItem.Text, cmbBuyingDept.SelectedItem.Text)
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("FabricType") = FabricType
            If dtyear1.Rows.Count > 0 Then
                If dtyear1.Rows.Count > 1 Then
                    Dim ORDERQTY As Decimal = 0
                    Dim NoOfOrder As Decimal = 0
                    For Y = 0 To dtyear1.Rows.Count - 1
                        ORDERQTY = ORDERQTY + Val(dtyear1.Rows(Y)("OrderQty"))
                        NoOfOrder = NoOfOrder + Val(dtyear1.Rows(Y)("NoOfOrder"))
                        Dr("Y1NoOforder") = NoOfOrder 'dtyear1.Rows(Y)("NoOfOrder")
                        Dr("Y1OrderQty") = ORDERQTY 'dtyear1.Rows(Y)("OrderQty")
                    Next

                Else
                    Dr("Y1NoOforder") = dtyear1.Rows(0)("NoOfOrder")
                    Dr("Y1OrderQty") = dtyear1.Rows(0)("OrderQty")
                End If

                Dr("Y1PerTotal") = 0 'dtyear1.Rows(0)("Colorway")
            Else
                Dr("Y1NoOforder") = 0
                Dr("Y1OrderQty") = 0
                Dr("Y1PerTotal") = 0
            End If
            If dtyear2.Rows.Count > 0 Then
                If dtyear2.Rows.Count > 1 Then
                    Dim ORDERQTY As Decimal = 0
                    Dim NoOfOrder As Decimal = 0
                    For Y = 0 To dtyear2.Rows.Count - 1
                        ORDERQTY = ORDERQTY + Val(dtyear2.Rows(Y)("OrderQty"))
                        NoOfOrder = NoOfOrder + Val(dtyear2.Rows(Y)("NoOfOrder"))
                        Dr("Y2NoOforder") = NoOfOrder 'dtyear1.Rows(Y)("NoOfOrder")
                        Dr("Y2OrderQty") = ORDERQTY 'dtyear1.Rows(Y)("OrderQty")
                    Next
                Else
                    Dr("Y2NoOforder") = dtyear2.Rows(0)("NoOfOrder")
                    Dr("Y2OrderQty") = dtyear2.Rows(0)("OrderQty")
                End If

                Dr("Y2PerTotal") = 0 'dtyear1.Rows(0)("Colorway")
            Else
                Dr("Y2NoOforder") = 0
                Dr("Y2OrderQty") = 0
                Dr("Y2PerTotal") = 0
            End If
            If dtyear3.Rows.Count > 0 Then
                If dtyear3.Rows.Count > 1 Then
                    Dim ORDERQTY As Decimal = 0
                    Dim NoOfOrder As Decimal = 0
                    For Y = 0 To dtyear3.Rows.Count - 1
                        ORDERQTY = ORDERQTY + Val(dtyear3.Rows(Y)("OrderQty"))
                        NoOfOrder = NoOfOrder + dtyear3.Rows(Y)("NoOfOrder")
                        Dr("Y3NoOforder") = NoOfOrder 'dtyear1.Rows(Y)("NoOfOrder")
                        Dr("Y3OrderQty") = ORDERQTY 'dtyear1.Rows(Y)("OrderQty")
                    Next
                Else
                    Dr("Y3NoOforder") = dtyear3.Rows(0)("NoOfOrder")
                    Dr("Y3OrderQty") = dtyear3.Rows(0)("OrderQty")
                End If

                Dr("Y3PerTotal") = 0 'dtyear1.Rows(0)("Colorway")
            Else
                Dr("Y3NoOforder") = 0
                Dr("Y3OrderQty") = 0
                Dr("Y3PerTotal") = 0
            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objReportClass
                .TempId = 0
                .FabricType = dtFinal.Rows(A)("FabricType")
                .Y1NoOforder = dtFinal.Rows(A)("Y1NoOforder")
                .Y1OrderQty = dtFinal.Rows(A)("Y1OrderQty")
                .Y1PerTotal = dtFinal.Rows(A)("Y1PerTotal")
                .Y2NoOforder = dtFinal.Rows(A)("Y2NoOforder")
                .Y2OrderQty = dtFinal.Rows(A)("Y2OrderQty")
                .Y2PerTotal = dtFinal.Rows(A)("Y2PerTotal")
                .Y3NoOforder = dtFinal.Rows(A)("Y3NoOforder")
                .Y3OrderQty = dtFinal.Rows(A)("Y3OrderQty")
                .Y3PerTotal = dtFinal.Rows(A)("Y3PerTotal")
                .SaveTempOrderDisByFabric()
            End With

        Next
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            'If txtStartDate.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
            'ElseIf txtEndDate.Text = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
            'Else
            GetDataForReport()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport8New.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "OrderDistributionbyFabricType"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, cmbFromMonth.SelectedItem.Text)
            Report.SetParameterValue(1, cmbToMonth.SelectedItem.Text)
            Report.SetParameterValue(2, cmbCustomer.SelectedItem.Text)
            Report.SetParameterValue(3, cmbBuyingDept.SelectedItem.Text)

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
            ' End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindDept(cmbCustomer.SelectedValue)

    End Sub
    Sub BindDept(ByVal CustomerID As Long)
        Dim dt As DataTable
        dt = objReportClass.GetDeptCustomerWise(CustomerID)
        cmbBuyingDept.DataSource = dt
        cmbBuyingDept.DataTextField = "BuyingDept"
        cmbBuyingDept.DataBind()
        cmbBuyingDept.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
End Class
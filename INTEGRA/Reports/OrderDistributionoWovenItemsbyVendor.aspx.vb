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
Public Class OrderDistributionoWovenItemsbyVendor
    Inherits System.Web.UI.Page
    Dim ObjTempOrderDisWovenItemsbyVendor As New TempOrderDisWovenItemsbyVendor
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = ObjTempOrderDisWovenItemsbyVendor.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = ObjTempOrderDisWovenItemsbyVendor.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("All", "0"))

    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindDept(cmbCustomer.SelectedValue)

    End Sub
    Sub BindDept(ByVal CustomerID As Long)
        Dim dt As DataTable
        dt = ObjTempOrderDisWovenItemsbyVendor.GetDeptCustomerWise(CustomerID)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub GetDataForReport()
        ObjTempOrderDisWovenItemsbyVendor.TruncateTable()
        Dim dtSupplier As DataTable = ObjTempOrderDisWovenItemsbyVendor.GetVenderNew(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
        Dim dtyear1 As DataTable
        Dim dtyear2 As DataTable
        Dim dtyear3 As DataTable
        Dim i As Integer
        Dim Supplier As String
        Dim SupplierId As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Supplier", GetType(String))
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
        For i = 0 To dtSupplier.Rows.Count - 1
            Supplier = dtSupplier.Rows(i)("VenderName")
            SupplierId = dtSupplier.Rows(i)("Supplierid")
            dtyear1 = ObjTempOrderDisWovenItemsbyVendor.getdataforReport1New("2014", SupplierId, cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
            dtyear2 = ObjTempOrderDisWovenItemsbyVendor.getdataforReport1New("2015", SupplierId, cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
            dtyear3 = ObjTempOrderDisWovenItemsbyVendor.getdataforReport1NewMonthWise("2016", SupplierId, cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbFromMonth.SelectedValue, cmbToMonth.SelectedValue)
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Supplier") = Supplier
            If dtyear1.Rows.Count > 0 Then
                Dr("Y1NoOforder") = dtyear1.Rows(0)("NoOfOrder")
                Dr("Y1OrderQty") = dtyear1.Rows(0)("OrderQty")

            Else
                Dr("Y1NoOforder") = 0
                Dr("Y1OrderQty") = 0

            End If
            If dtyear2.Rows.Count > 0 Then
                Dr("Y2NoOforder") = dtyear2.Rows(0)("NoOfOrder")
                Dr("Y2OrderQty") = dtyear2.Rows(0)("OrderQty")

            Else
                Dr("Y2NoOforder") = 0
                Dr("Y2OrderQty") = 0

            End If
            If dtyear3.Rows.Count > 0 Then
                Dr("Y3NoOforder") = dtyear3.Rows(0)("NoOfOrder")
                Dr("Y3OrderQty") = dtyear3.Rows(0)("OrderQty")

            Else
                Dr("Y3NoOforder") = 0
                Dr("Y3OrderQty") = 0

            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With ObjTempOrderDisWovenItemsbyVendor
                .TempId = 0
                .Supplier = dtFinal.Rows(A)("Supplier")
                .Y1NoOforder = dtFinal.Rows(A)("Y1NoOforder")
                .Y1OrderQty = dtFinal.Rows(A)("Y1OrderQty")
                .Y2NoOforder = dtFinal.Rows(A)("Y2NoOforder")
                .Y2OrderQty = dtFinal.Rows(A)("Y2OrderQty")
                .Y3NoOforder = dtFinal.Rows(A)("Y3NoOforder")
                .Y3OrderQty = dtFinal.Rows(A)("Y3OrderQty")
                .SaveTempOrderDisWovenItemsbyVendor()
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
            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport2Woven.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "OrderDisofWovenItemsbyVendor"
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
            ' End If
        Catch ex As Exception

        End Try
    End Sub
End Class
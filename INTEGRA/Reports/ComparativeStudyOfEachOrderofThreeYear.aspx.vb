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
Public Class ComparativeStudyOfEachOrderofThreeYear
    Inherits System.Web.UI.Page
    Dim ObjComparativeStudyofEachOrder As New ComparativeStudyofEachOrder
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        Else

        End If

    End Sub
    Sub BindCustomer()
        Dim dtt As DataTable
        dtt = ObjComparativeStudyofEachOrder.GetCustomerForRpt
        cmbCustomer.DataSource = dtt
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataBind()

        Dim dt As DataTable
        dt = ObjComparativeStudyofEachOrder.GetDeptCustomerWise(cmbCustomer.SelectedValue)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("ALL", "0"))

    End Sub
    Sub GetDataForReport()
        ObjComparativeStudyofEachOrder.TruncateTable()
        Dim dtSupplier As DataTable '= ObjComparativeStudyofEachOrder.GetVender()
        dtSupplier = ObjComparativeStudyofEachOrder.GetVender3(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        Dim dt7 As DataTable
        Dim dt8 As DataTable
        Dim dt9 As DataTable
        Dim dt10 As DataTable
        Dim dt11 As DataTable
        Dim dt12 As DataTable
        Dim dt13 As DataTable
        Dim dt14 As DataTable
        Dim i As Integer
        Dim Supplier As String
        Dim SupplierId As String
        Dim RYear As String
        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Supplier", GetType(String))
            .Columns.Add("RYear", GetType(String))
            .Columns.Add("C1", GetType(String))
            .Columns.Add("C2", GetType(String))
            .Columns.Add("C3", GetType(String))
            .Columns.Add("C4", GetType(String))
            .Columns.Add("C5", GetType(String))
            .Columns.Add("C6", GetType(String))
            .Columns.Add("C7", GetType(String))
            .Columns.Add("C8", GetType(String))
            .Columns.Add("C9", GetType(String))
            .Columns.Add("C10", GetType(String))
            .Columns.Add("C11", GetType(String))
            .Columns.Add("C12", GetType(String))
            .Columns.Add("C13", GetType(String))
            .Columns.Add("C14", GetType(String))
        End With
        For x = 0 To 2
            If x = 0 Then
                RYear = "2014"
            ElseIf x = 1 Then
                RYear = "2015"
            ElseIf x = 2 Then
                RYear = "2016"
            End If

            For i = 0 To dtSupplier.Rows.Count - 1
                Supplier = dtSupplier.Rows(i)("VenderName")
                SupplierId = dtSupplier.Rows(i)("Supplierid")
                If RYear = "2016" Then
                    dt1 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "0", "250", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt2 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "250", "500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt3 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "501", "1000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt4 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "1001", "1500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt5 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "1501", "2000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt6 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "2001", "2500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt7 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "2501", "3000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt8 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "3001", "3500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt9 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "3501", "4000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt10 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "4001", "4500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt11 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "4501", "5000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt12 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "5000", "5500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt13 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "5501", "7000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                    dt14 = ObjComparativeStudyofEachOrder.getdataforReport1NewMonthWise(SupplierId, "7000", "19160", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text, cmbMonthFrom.SelectedValue, cmbMonthTo.SelectedValue)
                Else
                    dt1 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "0", "250", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt2 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "250", "500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt3 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "501", "1000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt4 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "1001", "1500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt5 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "1501", "2000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt6 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "2001", "2500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt7 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "2501", "3000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt8 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "3001", "3500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt9 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "3501", "4000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt10 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "4001", "4500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt11 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "4501", "5000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt12 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "5000", "5500", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt13 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "5501", "7000", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                    dt14 = ObjComparativeStudyofEachOrder.getdataforReport1NewThreeYear(SupplierId, "7000", "19160", RYear, cmbCustomer.SelectedItem.Text, cmbDept.SelectedItem.Text)
                End If
                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("Supplier") = Supplier
                Dr("RYear") = RYear
                If dt1.Rows.Count > 0 Then
                    Dr("C1") = dt1.Rows.Count
                Else
                    Dr("C1") = 0
                End If
                If dt2.Rows.Count > 0 Then
                    Dr("C2") = dt2.Rows.Count
                Else
                    Dr("C2") = 0
                End If
                If dt2.Rows.Count > 0 Then
                    Dr("C2") = dt2.Rows.Count
                Else
                    Dr("C2") = 0
                End If
                If dt3.Rows.Count > 0 Then
                    Dr("C3") = dt3.Rows.Count
                Else
                    Dr("C3") = 0
                End If
                If dt4.Rows.Count > 0 Then
                    Dr("C4") = dt4.Rows.Count
                Else
                    Dr("C4") = 0
                End If
                If dt5.Rows.Count > 0 Then
                    Dr("C5") = dt5.Rows.Count
                Else
                    Dr("C5") = 0
                End If
                If dt6.Rows.Count > 0 Then
                    Dr("C6") = dt6.Rows.Count
                Else
                    Dr("C6") = 0
                End If
                If dt7.Rows.Count > 0 Then
                    Dr("C7") = dt7.Rows.Count
                Else
                    Dr("C7") = 0
                End If
                If dt8.Rows.Count > 0 Then
                    Dr("C8") = dt8.Rows.Count
                Else
                    Dr("C8") = 0
                End If
                If dt9.Rows.Count > 0 Then
                    Dr("C9") = dt9.Rows.Count
                Else
                    Dr("C9") = 0
                End If
                If dt10.Rows.Count > 0 Then
                    Dr("C10") = dt10.Rows.Count
                Else
                    Dr("C10") = 0
                End If
                If dt11.Rows.Count > 0 Then
                    Dr("C11") = dt11.Rows.Count
                Else
                    Dr("C11") = 0
                End If
                If dt12.Rows.Count > 0 Then
                    Dr("C12") = dt12.Rows.Count
                Else
                    Dr("C12") = 0
                End If
                If dt13.Rows.Count > 0 Then
                    Dr("C13") = dt13.Rows.Count
                Else
                    Dr("C13") = 0
                End If
                If dt14.Rows.Count > 0 Then
                    Dr("C14") = dt14.Rows.Count
                Else
                    Dr("C14") = 0
                End If
                dtFinal.Rows.Add(Dr)
            Next
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With ObjComparativeStudyofEachOrder
                .TempId = 0
                .Supplier = dtFinal.Rows(A)("Supplier")
                .RYear = dtFinal.Rows(A)("RYear")
                .C1 = dtFinal.Rows(A)("C1")
                .C2 = dtFinal.Rows(A)("C2")
                .C3 = dtFinal.Rows(A)("C3")
                .C4 = dtFinal.Rows(A)("C4")
                .C5 = dtFinal.Rows(A)("C5")
                .C6 = dtFinal.Rows(A)("C6")
                .C7 = dtFinal.Rows(A)("C7")
                .C8 = dtFinal.Rows(A)("C8")
                .C9 = dtFinal.Rows(A)("C9")
                .C10 = dtFinal.Rows(A)("C10")
                .C11 = dtFinal.Rows(A)("C11")
                .C12 = dtFinal.Rows(A)("C12")
                .C13 = dtFinal.Rows(A)("C13")
                .C14 = dtFinal.Rows(A)("C14")
                .SaveTempComparativeStudyofEachOrder()
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
            Report.Load(Server.MapPath("..\Reports/OracleEndofYearReport5.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "ComparativeStudyofQuantities"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            'Report.SetParameterValue(0, cmbyear.SelectedItem.Text)
            'Report.SetParameterValue(1, txtEndDate.Text)
            Report.SetParameterValue(0, cmbCustomer.SelectedItem.Text)
            Report.SetParameterValue(1, cmbDept.SelectedItem.Text)
            Report.SetParameterValue(2, cmbMonthFrom.SelectedItem.Text)
            Report.SetParameterValue(3, cmbMonthTo.SelectedItem.Text)

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
        dt = ObjComparativeStudyofEachOrder.GetDeptCustomerWise(CustomerID)
        cmbDept.DataSource = dt
        cmbDept.DataTextField = "BuyingDept"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
End Class
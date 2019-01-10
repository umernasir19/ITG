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
Public Class ShipmentReport
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim dr As DataRow
    Dim objTempSrNoFromShipmentPalningReport As New TempSrNoFromShipmentPalningReport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSeason()
            BindCustomer()
        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objTempSrNoFromShipmentPalningReport.GetCustomerDatabase()
            cmbCustomer.DataSource = dtcmbSeason
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            cmbCustomer.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objTempSrNoFromShipmentPalningReport.GetSeasonsFromJobOrderDatabase()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objTempSrNoFromShipmentPalningReport.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSrNoo.DataSource = dtInvoiceNo
            cmbSrNoo.DataTextField = "SrNO"
            cmbSrNoo.DataValueField = "JobOrderID"
            cmbSrNoo.DataBind()
            cmbSrNoo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNoo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSrNoo.SelectedIndexChanged
        Try
        Catch ex As Exception
        End Try
    End Sub
    Sub POPDFNew()
        Dim dtFinal = New DataTable
        Dim objTempPurchaseOrder As New TempPurchaseOrder
        objTempPurchaseOrder.TruncateTable()
        objTempPurchaseOrder.TruncateTableTempSrNoFromShipmentPalningReport()
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("RowType", GetType(String))
            .Columns.Add("RowNo", GetType(String))
            .Columns.Add("Color", GetType(String))
            .Columns.Add("SrNo", GetType(String))
            .Columns.Add("Rate", GetType(String))
            .Columns.Add("SeasonDatabaseId", GetType(String))
            .Columns.Add("JobOrderId", GetType(String))
            .Columns.Add("CustomerId", GetType(String))
            .Columns.Add("ReceivingDate", GetType(String))
            .Columns.Add("S1", GetType(String))
            .Columns.Add("S2", GetType(String))
            .Columns.Add("S3", GetType(String))
            .Columns.Add("S4", GetType(String))
            .Columns.Add("S5", GetType(String))
            .Columns.Add("S6", GetType(String))
            .Columns.Add("S7", GetType(String))
            .Columns.Add("S8", GetType(String))
            .Columns.Add("S9", GetType(String))
            .Columns.Add("S10", GetType(String))
            .Columns.Add("S11", GetType(String))
            .Columns.Add("S12", GetType(String))
            .Columns.Add("S13", GetType(String))
            .Columns.Add("S14", GetType(String))
            .Columns.Add("S15", GetType(String))
            .Columns.Add("S16", GetType(String))
            .Columns.Add("S17", GetType(String))
            .Columns.Add("S18", GetType(String))
            .Columns.Add("S19", GetType(String))
            .Columns.Add("S20", GetType(String))
            .Columns.Add("S21", GetType(String))
            .Columns.Add("S22", GetType(String))
            .Columns.Add("TotalQTYPCS", GetType(String))
            .Columns.Add("TotalQTYCTN", GetType(String))
        End With
        Dim dtColor As DataTable = objTempPurchaseOrder.GetSRNO()
        Dim c As Integer
        For c = 0 To dtColor.Rows.Count - 1
            Dim dtDtl As DataTable = objTempPurchaseOrder.GetColorData(dtColor.Rows(c)("JobOrderId"))
            Dim TotalQTYPCS As Decimal = 0
            Dim TotalQTYCTN As Decimal = 0
            Dim CC As Integer = 0
            For CC = 0 To dtDtl.Rows.Count - 1
                Dim dtsize As DataTable = objTempPurchaseOrder.GetALLPOData(dtDtl.Rows(CC)("JobOrderid"), dtDtl.Rows(CC)("JobOrderDetailid"))
                Dim dtData As DataTable = objTempPurchaseOrder.GetALLPODatanew(dtDtl.Rows(CC)("JobOrderid"), dtDtl.Rows(CC)("JobOrderDetailid"))
                Dim Count As Integer = 0
                Count = dtsize.Rows.Count
                If dtsize.Rows.Count > 0 Then
                    TotalQTYPCS = Convert.ToInt32(dtsize.Compute("SUM(Quantity)", String.Empty))
                    TotalQTYCTN = Convert.ToInt32(dtsize.Compute("SUM(CartonNo)", String.Empty))
                    dr = dtFinal.NewRow()
                    dr("TempId") = 0
                    dr("RowType") = "Size"
                    dr("RowNo") = "1"
                    dr("Color") = dtData.Rows(0)("BuyerColor")
                    dr("SrNo") = dtData.Rows(0)("SrNo")
                    dr("SeasonDatabaseId") = dtData.Rows(0)("SeasonDatabaseId")
                    dr("JobOrderId") = dtData.Rows(0)("JobOrderId")
                    dr("CustomerId") = dtData.Rows(0)("CustomerDatabaseId")
                    dr("ReceivingDate") = dtData.Rows(0)("ReceiveDate")
                    If Count > 1 Or Count = 1 Then
                        dr("S1") = dtsize.Rows(0)("Size")
                    Else
                        dr("S1") = ""
                    End If
                        dr("S2") = ""
                    If Count > 2 Or Count = 2 Then
                        dr("S3") = dtsize.Rows(1)("Size")
                    Else
                        dr("S3") = ""
                    End If
                        dr("S4") = ""
                    If Count > 3 Or Count = 3 Then
                        dr("S5") = dtsize.Rows(2)("Size")
                    Else
                        dr("S5") = ""
                    End If
                        dr("S6") = ""
                    If Count > 4 Or Count = 4 Then
                        dr("S7") = dtsize.Rows(3)("Size")
                    Else
                        dr("S7") = ""
                    End If
                        dr("S8") = ""
                    If Count > 5 Or Count = 5 Then
                        dr("S9") = dtsize.Rows(4)("Size")
                    Else
                        dr("S9") = ""
                    End If
                        dr("S10") = ""
                    If Count > 6 Or Count = 6 Then
                        dr("S11") = dtsize.Rows(5)("Size")
                    Else
                        dr("S11") = ""
                    End If
                    dr("S12") = ""
                    If Count > 7 Or Count = 7 Then
                        dr("S13") = dtsize.Rows(6)("Size")
                    Else
                        dr("S13") = ""
                    End If
                    dr("S14") = ""
                    If Count > 8 Or Count = 8 Then
                        dr("S15") = dtsize.Rows(7)("Size")
                    Else
                        dr("S15") = ""
                    End If
                    dr("S16") = ""
                    If Count > 9 Or Count = 9 Then
                        dr("S17") = dtsize.Rows(8)("Size")
                    Else
                        dr("S17") = ""
                    End If
                    dr("S18") = ""
                    If Count > 10 Or Count = 10 Then
                        dr("S19") = dtsize.Rows(9)("Size")
                    Else
                        dr("S19") = ""
                    End If
                    dr("S20") = ""
                    If Count > 11 Or Count = 11 Then
                        dr("S21") = dtsize.Rows(10)("Size")
                    Else
                        dr("S21") = ""
                    End If
                    dr("S22") = ""
                    dr("TotalQTYPCS") = 0
                    dr("TotalQTYCTN") = 0
                    dtFinal.Rows.Add(dr)

                    '----Row 2
                    dr = dtFinal.NewRow()
                    dr("TempId") = 0
                    dr("RowType") = "Quantity"
                    dr("RowNo") = "2"
                    dr("Color") = dtData.Rows(0)("BuyerColor")
                    dr("SrNo") = dtData.Rows(0)("SrNo")
                    dr("SeasonDatabaseId") = dtData.Rows(0)("SeasonDatabaseId")
                    dr("JobOrderId") = dtData.Rows(0)("JobOrderId")
                    dr("CustomerId") = dtData.Rows(0)("CustomerDatabaseId")
                    dr("ReceivingDate") = dtData.Rows(0)("ReceiveDate")
                    If Count > 1 Or Count = 1 Then
                        dr("S1") = dtsize.Rows(0)("Quantity")
                    Else
                        dr("S1") = ""
                    End If
                    If Count > 1 Or Count = 1 Then
                        dr("S2") = dtsize.Rows(0)("CartonNo")
                    Else
                        dr("S2") = ""
                    End If
                    If Count > 2 Or Count = 2 Then
                        dr("S3") = dtsize.Rows(1)("Quantity")
                    Else
                        dr("S3") = ""
                    End If
                    If Count > 2 Or Count = 2 Then
                        dr("S4") = dtsize.Rows(1)("CartonNo")
                    Else
                        dr("S4") = ""
                    End If
                    If Count > 3 Or Count = 3 Then
                        dr("S5") = dtsize.Rows(2)("Quantity")
                    Else
                        dr("S5") = ""
                    End If
                    If Count > 3 Or Count = 3 Then
                        dr("S6") = dtsize.Rows(2)("CartonNo")
                    Else
                        dr("S6") = ""
                    End If
                    If Count > 4 Or Count = 4 Then
                        dr("S7") = dtsize.Rows(3)("Quantity")
                    Else
                        dr("S7") = ""
                    End If
                    If Count > 4 Or Count = 4 Then
                        dr("S8") = dtsize.Rows(3)("CartonNo")
                    Else
                        dr("S8") = ""
                    End If
                    If Count > 5 Or Count = 5 Then
                        dr("S9") = dtsize.Rows(4)("Quantity")
                    Else
                        dr("S9") = ""
                    End If
                    If Count > 5 Or Count = 5 Then
                        dr("S10") = dtsize.Rows(4)("CartonNo")
                    Else
                        dr("S10") = ""
                    End If
                    If Count > 6 Or Count = 6 Then
                        dr("S11") = dtsize.Rows(5)("Quantity")
                    Else
                        dr("S11") = ""
                    End If
                    If Count > 6 Or Count = 6 Then
                        dr("S12") = dtsize.Rows(5)("CartonNo")
                    Else
                        dr("S12") = ""
                    End If
                    If Count > 7 Or Count = 7 Then
                        dr("S13") = dtsize.Rows(6)("Quantity")
                    Else
                        dr("S13") = ""
                    End If
                    If Count > 7 Or Count = 7 Then
                        dr("S14") = dtsize.Rows(6)("CartonNo")
                    Else
                        dr("S14") = ""
                    End If
                    If Count > 8 Or Count = 8 Then
                        dr("S15") = dtsize.Rows(7)("Quantity")
                    Else
                        dr("S15") = ""
                    End If
                    If Count > 8 Or Count = 8 Then
                        dr("S16") = dtsize.Rows(7)("CartonNo")
                    Else
                        dr("S16") = ""
                    End If
                    If Count > 9 Or Count = 9 Then
                        dr("S17") = dtsize.Rows(8)("Quantity")
                    Else
                        dr("S17") = ""
                    End If
                    If Count > 9 Or Count = 9 Then
                        dr("S18") = dtsize.Rows(8)("CartonNo")
                    Else
                        dr("S18") = ""
                    End If
                    If Count > 10 Or Count = 10 Then
                        dr("S19") = dtsize.Rows(9)("Quantity")
                    Else
                        dr("S19") = ""
                    End If
                    If Count > 10 Or Count = 10 Then
                        dr("S20") = dtsize.Rows(9)("CartonNo")
                    Else
                        dr("S20") = ""
                    End If
                    If Count > 11 Or Count = 11 Then
                        dr("S21") = dtsize.Rows(10)("Quantity")
                    Else
                        dr("S21") = ""
                    End If
                    If Count > 11 Or Count = 11 Then
                        dr("S22") = dtsize.Rows(10)("CartonNo")
                    Else
                        dr("S22") = ""
                    End If
                    dr("TotalQTYPCS") = TotalQTYPCS
                    dr("TotalQTYCTN") = TotalQTYCTN
                    dtFinal.Rows.Add(dr)
                End If
            Next
        Next
        Session("dtFinal") = dtFinal
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objTempPurchaseOrder
                .TempId = 0
                .RowType = dtFinal.Rows(A)("RowType")
                .RowNo = dtFinal.Rows(A)("RowNo")
                .Color = dtFinal.Rows(A)("Color")
                .SrNo = dtFinal.Rows(A)("SrNo")
                .JobOrderId = dtFinal.Rows(A)("JobOrderId")
                .CustomerId = dtFinal.Rows(A)("CustomerId")
                .SeasonDatabaseId = dtFinal.Rows(A)("SeasonDatabaseId")
                .ReceivingDate = dtFinal.Rows(A)("ReceivingDate")
                .S1 = dtFinal.Rows(A)("S1")
                .S2 = dtFinal.Rows(A)("S2")
                .S3 = dtFinal.Rows(A)("S3")
                .S4 = dtFinal.Rows(A)("S4")
                .S5 = dtFinal.Rows(A)("S5")
                .S6 = dtFinal.Rows(A)("S6")
                .S7 = dtFinal.Rows(A)("S7")
                .S8 = dtFinal.Rows(A)("S8")
                .S9 = dtFinal.Rows(A)("S9")
                .S10 = dtFinal.Rows(A)("S10")
                .S11 = dtFinal.Rows(A)("S11")
                .S12 = dtFinal.Rows(A)("S12")
                .S13 = dtFinal.Rows(A)("S13")
                .S14 = dtFinal.Rows(A)("S14")
                .S15 = dtFinal.Rows(A)("S15")
                .S16 = dtFinal.Rows(A)("S16")
                .S17 = dtFinal.Rows(A)("S17")
                .S18 = dtFinal.Rows(A)("S18")
                .S19 = dtFinal.Rows(A)("S19")
                .S20 = dtFinal.Rows(A)("S20")
                .S21 = dtFinal.Rows(A)("S21")
                .S22 = dtFinal.Rows(A)("S22")
                .TotalQTYPCS = dtFinal.Rows(A)("TotalQTYPCS")
                .TotalQTYCTN = dtFinal.Rows(A)("TotalQTYCTN")
                .Savetemp()
            End With
        Next
        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/ShipmentView.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Finishing_Godown_Carton_Stock"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        If cmbSeason.SelectedItem.Text = "Select" Then
            If txtDate.SelectedDate.ToString <> "" Then
                Dim Date2 As Date = "01/03/2015"
                Dim date3 As Date = txtDate.SelectedDate
                Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                CheckDate = 1
                Dim CustomerId As Long
                If cmbCustomer.SelectedItem.Text = "Select" Then
                    CustomerId = 0
                Else
                    CustomerId = cmbCustomer.SelectedValue
                End If
                Report.SetParameterValue(0, 0)
                Report.SetParameterValue(1, 0)
                Report.SetParameterValue(2, CustomerId)
                Report.SetParameterValue(3, Estdatee)
                Report.SetParameterValue(4, Enddatee)
                Report.SetParameterValue(5, CheckDate)
            Else
                CheckDate = 0
                Dim CustomerId As Long
                If cmbCustomer.SelectedItem.Text = "Select" Then
                    CustomerId = 0
                Else
                    CustomerId = cmbCustomer.SelectedValue
                End If
                Report.SetParameterValue(0, 0)
                Report.SetParameterValue(1, 0)
                Report.SetParameterValue(2, CustomerId)
                Report.SetParameterValue(3, Date.Now)
                Report.SetParameterValue(4, Date.Now)
                Report.SetParameterValue(5, CheckDate)
            End If
        Else
            If cmbSrNoo.Text = "All" Then
                If txtDate.SelectedDate.ToString <> "" Then
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDate.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    CheckDate = 1
                    Dim CustomerId As Long
                    If cmbCustomer.SelectedItem.Text = "Select" Then
                        CustomerId = 0
                    Else
                        CustomerId = cmbCustomer.SelectedValue
                    End If
                    Report.SetParameterValue(0, 0)
                    Report.SetParameterValue(1, 0)
                    Report.SetParameterValue(2, CustomerId)
                    Report.SetParameterValue(3, Estdatee)
                    Report.SetParameterValue(4, Enddatee)
                    Report.SetParameterValue(5, CheckDate)
                Else
                    CheckDate = 0
                    Dim CustomerId As Long
                    If cmbCustomer.SelectedItem.Text = "Select" Then
                        CustomerId = 0
                    Else
                        CustomerId = cmbCustomer.SelectedValue
                    End If
                    Report.SetParameterValue(0, cmbSeason.SelectedValue)
                    Report.SetParameterValue(1, 0)
                    Report.SetParameterValue(2, CustomerId)
                    Report.SetParameterValue(3, Date.Now)
                    Report.SetParameterValue(4, Date.Now)
                    Report.SetParameterValue(5, CheckDate)
                End If
            Else
                If txtDate.SelectedDate.ToString <> "" Then
                    Dim xx As Integer
                    For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                        With objTempSrNoFromShipmentPalningReport
                            .ID = 0
                            .No = cmbSrNoo.CheckedItems(xx).Text
                            .JobOrderId = cmbSrNoo.CheckedItems(xx).Value
                            .Save()
                        End With
                    Next
                    Dim Date2 As Date = "01/03/2015"
                    Dim date3 As Date = txtDate.SelectedDate
                    Dim Estdatee As String = Date2.ToString("dd/MM/yyyy")
                    Dim Enddatee As String = date3.ToString("dd/MM/yyyy")
                    CheckDate = 1
                    Dim CustomerId As Long
                    If cmbCustomer.SelectedItem.Text = "Select" Then
                        CustomerId = 0
                    Else
                        CustomerId = cmbCustomer.SelectedValue
                    End If
                    Report.SetParameterValue(0, cmbSeason.SelectedValue)
                    Report.SetParameterValue(1, 1)
                    Report.SetParameterValue(2, CustomerId)
                    Report.SetParameterValue(3, Estdatee)
                    Report.SetParameterValue(4, Enddatee)
                    Report.SetParameterValue(5, CheckDate)
                Else
                    Dim xx As Integer
                    For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                        With objTempSrNoFromShipmentPalningReport
                            .ID = 0
                            .No = cmbSrNoo.CheckedItems(xx).Text
                            .JobOrderId = cmbSrNoo.CheckedItems(xx).Value
                            .Save()
                        End With
                    Next
                    CheckDate = 0
                    Dim CustomerId As Long
                    If cmbCustomer.SelectedItem.Text = "Select" Then
                        CustomerId = 0
                    Else
                        CustomerId = cmbCustomer.SelectedValue
                    End If
                    Report.SetParameterValue(0, cmbSeason.SelectedValue)
                    Report.SetParameterValue(1, 1)
                    Report.SetParameterValue(2, CustomerId)
                    Report.SetParameterValue(3, Date.Now)
                    Report.SetParameterValue(4, Date.Now)
                    Report.SetParameterValue(5, CheckDate)
                End If
            End If
        End If
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
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        POPDFNew()
    End Sub
End Class
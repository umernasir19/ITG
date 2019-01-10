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
Public Class FabricInventoryFifoIssue
    Inherits System.Web.UI.Page
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim Dr As DataRow
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindItem()
        End If
    End Sub
    Sub BindItem()
        Try
            Dim dtItem As DataTable
            dtItem = objTempStockInventory.GetIMSItemAllBYtype(Session("UserId"))
            cmbItem.DataSource = dtItem
            cmbItem.DataTextField = "Itemname"
            cmbItem.DataValueField = "IMSIteMID"
            cmbItem.DataBind()
            cmbItem.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            GetFabricinventoryFifoIssue()
        Catch ex As Exception


        End Try
    End Sub
    Sub GetFabricinventoryFifoIssue()
        Try

            '--Will truncate first 
            objTempStockInventory.TruncateTempInventoryNew()
            '--Insert data on belaf of Issue
            objTempStockInventory.InsertTempStockInventoryOpen(cmbItem.SelectedValue)
            '--Insert data on belaf of Issue
            objTempStockInventory.InsertTempStockInventoryIssue(cmbItem.SelectedValue)

            '--Insert data on belaf of Receive
            objTempStockInventory.InsertTempStockInventoryReceive(cmbItem.SelectedValue)
            '--Insert data on belaf of Recipe Issue


            '--Will truncate Temp Final New
            ' objCustomerLedgerInv.TruncateTempStockLedgerNewFinal()
            '--Insert data on behalf on Temp Stock Ledger New 
            ' objCustomerLedgerInv.InsertTempStockLedgerNewFinal()
            Dim OBJDATE As New GeneralCode
            Dim sdatee, edate As String
            sdatee = txtDateFrom.SelectedDate.Value.ToString("MM-dd-yyyy")
            edate = txtDateTo.SelectedDate.Value.ToString("MM-dd-yyyy")
            Dim dtrecve As DataTable = objTempStockInventory.GETRecvData() 'objTempStockInventory.GETRecvDataWithDate(edate) '
            Dim dtsales As DataTable = objTempStockInventory.GETIssueDataWithDate(edate) 'objTempStockInventory.GETIssueData() '
            Dim dtDetail = New DataTable
            With dtDetail
                .Columns.Add("TempID", GetType(Long))
                .Columns.Add("EntryDate", GetType(String))
                .Columns.Add("Inward", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("SupplierID", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("UnitRate", GetType(String))
                .Columns.Add("UnitSold", GetType(String))
            End With
            Dim TotalSales As Decimal
            Dim DistributeSales As Decimal
            If dtsales.Rows.Count > 0 Then
                TotalSales = dtsales.Rows(0)("SalesQty")
                DistributeSales = dtsales.Rows(0)("SalesQty")
            Else
                TotalSales = 0
                DistributeSales = 0
            End If
            Dim Quantity As Decimal
            Dim x As Integer
            For x = 0 To dtrecve.Rows.Count - 1
                Quantity = dtrecve.Rows(x)("ReceiveQty")
                Dr = dtDetail.NewRow()
                Dr("TempID") = 0
                Dr("EntryDate") = dtrecve.Rows(x)("EntryDate")
                Dr("Inward") = dtrecve.Rows(x)("DCNo")
                Dr("ItemName") = dtrecve.Rows(x)("ItemName")
                Dr("SupplierID") = dtrecve.Rows(x)("IMSSupplierId")
                Dr("Quantity") = Quantity
                Dr("UnitRate") = dtrecve.Rows(x)("UnitRate")
                If Quantity < DistributeSales Then
                    Dr("UnitSold") = Quantity
                    DistributeSales = DistributeSales - Quantity
                Else
                    Dr("UnitSold") = DistributeSales
                    DistributeSales = DistributeSales - DistributeSales
                End If
                dtDetail.Rows.Add(Dr)
            Next
            objTempStockInventory.TruncateTempInventoryFinal()
            Dim y As Integer
            For y = 0 To dtDetail.Rows.Count - 1
                With objTempStockInventory
                    .TempTableStockId = 0
                    .EntryDate = dtDetail.Rows(y)("EntryDate")
                    .Inward = dtDetail.Rows(y)("Inward")
                    .ItemName = dtDetail.Rows(y)("ItemName")
                    .SupplierID = dtDetail.Rows(y)("SupplierID")
                    .Quantity = dtDetail.Rows(y)("Quantity")
                    .UnitRate = dtDetail.Rows(y)("UnitRate")
                    .UnitSold = dtDetail.Rows(y)("UnitSold")
                    .SaveStockInventory()
                End With
            Next


            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FileName As String = "Stock Inventory"
            Report.Load(Server.MapPath("~/Reports/ItemInventoryIssueFifo.rpt"))
            Report.Refresh()

            Report.SetParameterValue(0, cmbItem.SelectedValue)
            Report.SetParameterValue(1, txtDateFrom.SelectedDate)
            Report.SetParameterValue(2, txtDateTo.SelectedDate)

            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

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
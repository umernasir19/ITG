Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports Telerik.Web.UI
Public Class MGTEcpWiseReport
    Inherits System.Web.UI.Page
    Dim objProductCategory As New MGTProductCategory
    Dim objMGTCustomer As New MGTCustomer
    Dim objMGTMarchand As New MGTMarchand
    Dim objSQLManager As SQLManager
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("MGT ECP Product Group & Product Categories Report")
            BindECPDivision()
            Dim FirstDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateFrom.SelectedDate = FirstDay
            Dim lastDay As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, 1)
            txtDateTo.SelectedDate = lastDay.AddMonths(1).AddDays(-1)
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            objMGTCustomer.TruncateTable()
            GetCustomerWiseReport()
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim ProductGroup As String = "("
            If cmbProductGroup.SelectedItem.Text = "All Product Group" Then
                Dim dtProductGroup As DataTable
                dtProductGroup = objMGTMarchand.GetProductGroup(cmbECP.SelectedItem.Text)
                Dim x As Integer
                For x = 0 To dtProductGroup.Rows.Count - 1
                    ProductGroup = ProductGroup + dtProductGroup.Rows(x)("ProductPortfolio").ToString() + ","
                Next
                ProductGroup = ProductGroup + ")"
                ProductGroup = Replace(ProductGroup, ",)", ")")
            Else
                ProductGroup = cmbProductGroup.SelectedItem.Text
            End If
            Report.Load(Server.MapPath("..\Reports/MGTCustomerECProductGroupVise.rpt"))

            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "MGT_ProductAnalysis_" + txtDateFrom.SelectedDate.Value.ToString("dd-MM-yyyy") + "_" + txtDateTo.SelectedDate.Value.ToString("dd-MM-yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, cmbECP.SelectedItem.Text)
            Report.SetParameterValue(1, ProductGroup)
            Report.SetParameterValue(2, cmbProductCategories.SelectedItem.Text)
            Report.SetParameterValue(3, txtDateFrom.SelectedDate)
            Report.SetParameterValue(4, txtDateTo.SelectedDate)
          
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
    Sub GetCustomerWiseReport()
        Try
            'Dim ProductGroup As String
            'Dim ProductCategory As String
            'ProductGroup = cmbProductGroup.SelectedItem.Text
            'ProductCategory = cmbProductCategories.SelectedItem.Text
          
            Dim dtMgtECP As New DataTable
            Dim dtBookQty As New DataTable
            Dim dtbookedturnover As New DataTable
            Dim dtShippedturnover As New DataTable
            Dim dtTimelyShipped As New DataTable
            Dim dtTotalPos As New DataTable
            Dim Fromdate As Date = txtDateFrom.SelectedDate
            Dim ToDate As Date = txtDateTo.SelectedDate
            Dim x As Integer
            dtMgtECP = objProductCategory.GetMgtECPReportData(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, cmbProductCategories.SelectedItem.Text)
            For x = 0 To dtMgtECP.Rows.Count - 1
                Dim BookedQty As Decimal = 0
                Dim ShippedQty As Decimal = 0
                Dim ShippedQtyOnTime As Decimal = 0
                Dim BookedForPos As Decimal = 0
                Dim TotalShippedPos As Decimal = 0
                Dim ShippedPosOnTime As Decimal = 0
                Dim BookedTurnOver As Decimal = 0
                Dim SumOfBookedTurnOver As Decimal = 0
                Dim ShippedTurnOver As Decimal = 0
                Dim SumOfShippedTurnOver As Decimal = 0
                Dim ProductCategories As String = dtMgtECP.Rows(x)("ProductCategories")
                '---BookedQty
                BookedQty = objProductCategory.GetMGTBookedQTY(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)

                '---ShippeddQty
                ShippedQty = objProductCategory.GetMGTShippedQTY(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                '----Shipped Qty On Time
                ShippedQtyOnTime = objProductCategory.GetMGTShippedQTYOnTime(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                '----Booked For Pos
                BookedForPos = objProductCategory.GetMGTBookedForPOs(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                '----Total Shipped Pos
                TotalShippedPos = objProductCategory.GetMGTTotalShippedPos(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                '----Shipped Pos OnTime
                ShippedPosOnTime = objProductCategory.GetMGTShippedPOsOnTime(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                '----Booked TurOver
                dtbookedturnover = objProductCategory.GetMGTBookedTurOver(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                Dim xBookedTurnOver As Integer = 0
                If dtbookedturnover.Rows.Count = 0 Then
                    SumOfBookedTurnOver = 0
                Else
                    SumOfBookedTurnOver = dtbookedturnover.Compute("Sum(BookedTurnOver)", "")
                End If
                '----Shipped TurOver
                dtShippedturnover = objProductCategory.GetMGTShippedTurOver(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                If dtShippedturnover.Rows.Count = 0 Then
                    SumOfShippedTurnOver = 0
                Else
                    SumOfShippedTurnOver = dtShippedturnover.Compute("Sum(ShippedTurOver)", "")
                End If

                '---BookedCommission
                Dim TotalBookedComm As Decimal = 0
                Dim dtcommission As New DataTable
                dtcommission = objProductCategory.GetMGTBookedCommNew(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                If dtcommission.Rows.Count = 0 Then
                    TotalBookedComm = 0
                Else
                    TotalBookedComm = dtcommission.Compute("Sum(BookedTurnOver)", "")
                End If
                '---ShippedCommission
                Dim TotalShippedComm As Decimal
                Dim dtShippedComm As DataTable = objProductCategory.GetMGTShippedCommNew(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                If dtShippedComm.Rows.Count = 0 Then
                    TotalShippedComm = 0
                Else
                    TotalShippedComm = dtShippedComm.Compute("Sum(ShippedTurOver)", "")
                End If
                '-----ClaimPcs
                Dim ClaimedPcs As Decimal
                '---check cover direct val or not then get in datatable
                ClaimedPcs = objProductCategory.GetMGTClaiPcs(Fromdate, ToDate, cmbECP.SelectedItem.Text, cmbProductGroup.SelectedItem.Text, ProductCategories)
                ''----Timely Shipped
                Dim DeliverPerformance As Decimal
                If BookedForPos = 0 Then
                    DeliverPerformance = 0
                Else
                    DeliverPerformance = (ShippedPosOnTime * 100) / BookedForPos
                End If

                'PP
                Dim ProductionPerformance As Decimal = 0
                If BookedQty = 0 Then
                    ProductionPerformance = 0
                Else
                    ProductionPerformance = (ShippedQtyOnTime * 100) / BookedQty
                End If
                '----BackLogCleared
                Dim BackLogCleared As Decimal = 0
                BackLogCleared = ShippedQty - ShippedQtyOnTime
                '----For Save
                With objMGTCustomer
                    .MGTId = 0
                    .CreationDate = Date.Now
                    .CustomerId = 0
                    .CustomerName = ProductCategories
                    .BookedQuantity = BookedQty
                    .ShippedQuantity = ShippedQty
                    .BookedTurnOver = SumOfBookedTurnOver
                    .ShippedTurnOver = SumOfShippedTurnOver
                    .BookedCommission = TotalBookedComm
                    .ShippedCommission = TotalShippedComm
                    .NoOfClaimed = ClaimedPcs
                    .DeliveryPerformance = Math.Round(DeliverPerformance, 2)
                    .ProductionPerformance = Math.Round(ProductionPerformance, 2)
                    .ShippedPOsOnTime = ShippedPosOnTime
                    .BookedForPOs = BookedForPos
                    .ShippedQuantityOnTime = ShippedQtyOnTime
                    .TotalShippedPOs = TotalShippedPos
                    .BackLogCleared = BackLogCleared
                    .SaveMGT()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub BindECPDivision()
        Try
            Dim dtECP As DataTable = objMGTMarchand.GEtECP()
            With cmbECP
                .DataSource = dtECP
                .DataTextField = "ECPDivistion"
                .DataBind()
                '  .Items.Insert(0, "Select ECP...")
            End With
        Catch ex As Exception
        End Try

    End Sub
    Protected Sub cmbECP_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbECP.SelectedIndexChanged
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objMGTMarchand.GetProductGroup(cmbECP.SelectedItem.Text)
            cmbProductGroup.DataSource = dtProductGroup
            cmbProductGroup.DataTextField = "ProductPortfolio"
            cmbProductGroup.DataValueField = "ProductPortfolioID"
            cmbProductGroup.DataBind()
            cmbProductGroup.Items.Insert(0, New RadComboBoxItem("All Product Group", 0))
            updProductGroup.Update()

            '====
            Dim ProductGroup As String
            Dim dtProductCategories As DataTable
            ProductGroup = cmbProductGroup.SelectedItem.Text
            If ProductGroup = "All Product Group" Then
                dtProductCategories = objMGTMarchand.GetProductCategoriesForAll(cmbECP.SelectedItem.Text)
            Else
                dtProductCategories = objMGTMarchand.GetProductCategories(cmbProductGroup.SelectedValue, cmbECP.SelectedItem.Text)
            End If
            cmbProductCategories.DataSource = dtProductCategories
            cmbProductCategories.DataTextField = "ProductCategories"
            cmbProductCategories.DataBind()
            cmbProductCategories.Items.Insert(0, New RadComboBoxItem("All Product Categories", 0))
            updProductCategories.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbProductGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbProductGroup.SelectedIndexChanged
        Try

            Dim ProductGroup As String
            Dim dtProductCategories As DataTable
            ProductGroup = cmbProductGroup.SelectedItem.Text
            If ProductGroup = "All Product Group" Then
                dtProductCategories = objMGTMarchand.GetProductCategoriesForAll(cmbECP.SelectedItem.Text)
            Else
                dtProductCategories = objMGTMarchand.GetProductCategories(cmbProductGroup.SelectedValue, cmbECP.SelectedItem.Text)
            End If
            cmbProductCategories.DataSource = dtProductCategories
            cmbProductCategories.DataTextField = "ProductCategories"
            cmbProductCategories.DataBind()
            cmbProductCategories.Items.Insert(0, New RadComboBoxItem("All Product Categories", 0))
            updProductCategories.Update()
        Catch ex As Exception

        End Try
    End Sub
End Class
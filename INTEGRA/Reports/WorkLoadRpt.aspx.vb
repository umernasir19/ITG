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
Public Class WorkLoadRpt
    Inherits System.Web.UI.Page
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Dim objCustomer As New Customer
    Dim ObjTempOrderDisKnittedItemsbyVendor As New TempOrderDisKnittedItemsbyVendor
    Dim ObjTempSummaryOfWorkLoad As New TempSummaryOfWorkLoad
    Dim ObjTempSummaryOfWorkLoadCustomerWise As New TempSummaryOfWorkLoadCustomerWise
    Dim ObjTempSummaryOfWorkLoadDeptWise As New TempSummaryOfWorkLoadDeptWise
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSeason()
            BindCustomer()
            BindSupplier()
        End If
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystemAddclass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Dim dt As New DataTable
        dt = objEnquiriesSystemAddclass.GetWorkLDSupplier
        cmbSupplier.DataSource = dt
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataBind()
        cmbSupplier.Items.Insert(0, New ListItem("ALL", "0"))
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerFullNAME"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()


            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))

            'txtStartDate.Text = ""
            'txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If txtStartDatee.ValidationDate <> "" And txtEndDatee.ValidationDate <> "" Then
                'Dim startdate As Date = txtStartDate.Text
                ' Dim EndDate As Date = txtEndDate.Text
                Dim season As String = cmbSeason.SelectedItem.Text
                Dim supplier As String
                Dim Bytindept As String
                Dim customer As String
                Dim Heading As String
                Dim monthdate As Date = txtStartDatee.SelectedDate
                If cmbReportType.SelectedItem.Text = "Monthly" Then
                    If monthdate.Month = 1 Then
                        Heading = "Jan"
                    ElseIf monthdate.Month = 2 Then
                        Heading = "Feb"
                    ElseIf monthdate.Month = 3 Then
                        Heading = "Mar"
                    ElseIf monthdate.Month = 4 Then
                        Heading = "April"
                    ElseIf monthdate.Month = 5 Then
                        Heading = "May"
                    ElseIf monthdate.Month = 6 Then
                        Heading = "June"
                    ElseIf monthdate.Month = 7 Then
                        Heading = "July"
                    ElseIf monthdate.Month = 8 Then
                        Heading = "Aug"
                    ElseIf monthdate.Month = 9 Then
                        Heading = "Sep"
                    ElseIf monthdate.Month = 10 Then
                        Heading = "Oct"
                    ElseIf monthdate.Month = 11 Then
                        Heading = "Nov"
                    ElseIf monthdate.Month = 12 Then
                        Heading = "Dec"
                    End If
                ElseIf cmbReportType.SelectedItem.Text = "Yearly" Then
                    Heading = monthdate.Year
                Else
                    Heading = cmbSeason.SelectedItem.Text
                End If

                If cmbSupplier.SelectedValue = 0 Then
                    supplier = 0
                Else
                    supplier = cmbSupplier.SelectedValue
                End If


                customer = cmbCustomer.SelectedValue


                If cmbBuyingDept.SelectedItem.Text = "All" Then
                    Bytindept = "All"
                Else
                    Bytindept = cmbBuyingDept.SelectedItem.Text
                End If
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

                Report.Load(Server.MapPath("..\Reports/WORKLOADAllseasonNew.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "WorkLoad"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, supplier)
                Report.SetParameterValue(1, customer)
                Report.SetParameterValue(2, season)
                Report.SetParameterValue(3, Bytindept)
                Report.SetParameterValue(4, txtStartDatee.SelectedDate)

                Report.SetParameterValue(5, txtEndDatee.SelectedDate)
                Report.SetParameterValue(6, cmbReportType.SelectedItem.Text)
                Report.SetParameterValue(7, Heading)
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
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub GetDataForReport()
        Dim OBJDATE As New GeneralCode
        ObjTempSummaryOfWorkLoad.TruncateTable()
        Dim startdatee As String = txtStartDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
        Dim Enddatee As String = txtEndDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
        ' Dim STARTDATE As String = OBJDATE.GetDateFormat(startdatee)
        '  Dim ENDDATE As String = OBJDATE.GetDateFormat(Enddatee)
        Dim CUSTOMERID As Long = cmbCustomer.SelectedValue
        Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
        Dim supplieridd As Long = cmbSupplier.SelectedValue
        Dim supplierid As Long
        Dim saeson As String = cmbSeason.SelectedItem.Text
        Dim dtSupplier As DataTable = ObjTempSummaryOfWorkLoad.GetVender(startdatee, Enddatee, saeson, CUSTOMERID, BuyingDept, supplieridd)
        Dim dtoderdata As DataTable
        Dim dtShIPPED As DataTable
        Dim dtyear3 As DataTable
        Dim i As Integer
        Dim Supplier As String
        Dim dtoderdataM1 As DataTable
        Dim dtShIPPEDM1 As DataTable
        Dim dtoderdataM2 As DataTable
        Dim dtShIPPEDM2 As DataTable
        Dim Month1 As String
        Dim Month2 As String
        Month1 = cmbMonth1.SelectedValue
        Month2 = cmbMonth2.SelectedValue
        Dim M1M2Year As String
        M1M2Year = Year(txtStartDatee.SelectedDate)

        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Supplier", GetType(String))
            .Columns.Add("NoOfLines", GetType(String))
            .Columns.Add("NoOforder", GetType(String))
            .Columns.Add("OrderQty", GetType(String))
            .Columns.Add("OrderQtyInPcs", GetType(String))
            .Columns.Add("ShippedOrderQty", GetType(String))
            .Columns.Add("ShippedOrderQtyInPcs", GetType(String))
            .Columns.Add("OrderQtyM1", GetType(Decimal))
            .Columns.Add("OrderQtyInPcsM1", GetType(Decimal))
            .Columns.Add("ShippedOrderQtyM1", GetType(Decimal))
            .Columns.Add("ShippedOrderQtyInPcsM1", GetType(Decimal))
            .Columns.Add("OrderQtyM2", GetType(Decimal))
            .Columns.Add("OrderQtyInPcsM2", GetType(Decimal))
            .Columns.Add("ShippedOrderQtyM2", GetType(Decimal))
            .Columns.Add("ShippedOrderQtyInPcsM2", GetType(Decimal))
        End With

        For i = 0 To dtSupplier.Rows.Count - 1
            Supplier = dtSupplier.Rows(i)("VenderName")
            supplierid = dtSupplier.Rows(i)("Supplierid")
            dtoderdata = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummary(startdatee, Enddatee, saeson, CUSTOMERID, BuyingDept, supplierid)
            dtShIPPED = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummarySHIPPED(startdatee, Enddatee, saeson, CUSTOMERID, BuyingDept, supplierid)

            dtoderdataM1 = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummaryForMonth1(Month1, M1M2Year, saeson, CUSTOMERID, BuyingDept, supplierid)
            dtShIPPEDM1 = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummarySHIPPEDMonth1(Month1, M1M2Year, saeson, CUSTOMERID, BuyingDept, supplierid)
            dtoderdataM2 = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummaryForMonth2(Month2, M1M2Year, saeson, CUSTOMERID, BuyingDept, supplierid)
            dtShIPPEDM2 = ObjTempSummaryOfWorkLoad.getdataforWorkLoadSummarySHIPPEDMonth2(Month2, M1M2Year, saeson, CUSTOMERID, BuyingDept, supplierid)

            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Supplier") = Supplier
            If dtoderdata.Rows.Count > 0 Then
                Dim OrderQty As Decimal = 0
                Dim OrderQtyInPcs As Decimal = 0
                Dim NoOfLines As Decimal = 0
                Dim NoOforder As Decimal = 0

                For Y = 0 To dtoderdata.Rows.Count - 1
                    OrderQty = OrderQty + Val(dtoderdata.Rows(Y)("OrderQty"))
                    OrderQtyInPcs = OrderQtyInPcs + Val(dtoderdata.Rows(Y)("OrderQtyInPcs"))
                    NoOfLines = NoOfLines + Val(dtoderdata.Rows(Y)("NoOfLines"))
                    NoOforder = NoOforder + Val(dtoderdata.Rows(Y)("NoOforder"))
                    Dr("OrderQty") = OrderQty
                    Dr("OrderQtyInPcs") = OrderQtyInPcs
                    Dr("NoOfLines") = NoOfLines
                    Dr("NoOforder") = NoOforder

                Next
            Else
                Dr("OrderQty") = 0
                Dr("OrderQtyInPcs") = 0
                Dr("NoOfLines") = 0
                Dr("NoOforder") = 0
            End If


            If dtoderdataM1.Rows.Count > 0 Then
                Dim OrderQtyM1 As Decimal = 0
                Dim OrderQtyInPcsM1 As Decimal = 0


                For a = 0 To dtoderdataM1.Rows.Count - 1
                    OrderQtyM1 = OrderQtyM1 + Val(dtoderdataM1.Rows(a)("OrderQtyM1"))
                    OrderQtyInPcsM1 = OrderQtyInPcsM1 + Val(dtoderdataM1.Rows(a)("OrderQtyInPcsM1"))

                    Dr("OrderQtyM1") = OrderQtyM1
                    Dr("OrderQtyInPcsM1") = OrderQtyInPcsM1

                Next
            Else
                Dr("OrderQtyM1") = 0
                Dr("OrderQtyInPcsM1") = 0

            End If
            If dtShIPPEDM1.Rows.Count > 0 Then
                Dr("ShippedOrderQtyInPcsM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyInPcsM1")
                Dr("ShippedOrderQtyM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyM1")
            Else
                Dr("ShippedOrderQtyInPcsM1") = 0
                Dr("ShippedOrderQtyM1") = 0
            End If

            If dtoderdataM2.Rows.Count > 0 Then
                Dim OrderQtyM2 As Decimal = 0
                Dim OrderQtyInPcsM2 As Decimal = 0


                For b = 0 To dtoderdataM2.Rows.Count - 1
                    OrderQtyM2 = OrderQtyM2 + Val(dtoderdataM2.Rows(b)("OrderQtyM2"))
                    OrderQtyInPcsM2 = OrderQtyInPcsM2 + Val(dtoderdataM2.Rows(b)("OrderQtyInPcsM2"))

                    Dr("OrderQtyM2") = OrderQtyM2
                    Dr("OrderQtyInPcsM2") = OrderQtyInPcsM2

                Next
            Else
                Dr("OrderQtyM2") = 0
                Dr("OrderQtyInPcsM2") = 0

            End If
            If dtShIPPEDM2.Rows.Count > 0 Then
                Dr("ShippedOrderQtyInPcsM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyInPcsM2")
                Dr("ShippedOrderQtyM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyM2")
            Else
                Dr("ShippedOrderQtyInPcsM2") = 0
                Dr("ShippedOrderQtyM2") = 0
            End If



            If dtShIPPED.Rows.Count > 0 Then
                Dr("ShippedOrderQtyInPcs") = dtShIPPED.Rows(0)("ShippedOrderQtyInPcs")
                Dr("ShippedOrderQty") = dtShIPPED.Rows(0)("ShippedOrderQty")
            Else
                Dr("ShippedOrderQtyInPcs") = 0
                Dr("ShippedOrderQty") = 0
            End If

            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With ObjTempSummaryOfWorkLoad
                .TempId = 0
                .Supplier = dtFinal.Rows(A)("Supplier")
                .NoOfLines = dtFinal.Rows(A)("NoOfLines")
                .NoOforder = dtFinal.Rows(A)("NoOforder")
                .OrderQty = dtFinal.Rows(A)("OrderQty")
                .OrderQtyInPcs = dtFinal.Rows(A)("OrderQtyInPcs")
                .ShippedOrderQty = dtFinal.Rows(A)("ShippedOrderQty")
                .ShippedOrderQtyInPcs = dtFinal.Rows(A)("ShippedOrderQtyInPcs")

                .OrderQtyM1 = dtFinal.Rows(A)("OrderQtyM1")
                .OrderQtyInPcsM1 = dtFinal.Rows(A)("OrderQtyInPcsM1")
                .OrderQtyM2 = dtFinal.Rows(A)("OrderQtyM2")
                .OrderQtyInPcsM2 = dtFinal.Rows(A)("OrderQtyInPcsM2")

                .ShippedOrderQtyM1 = dtFinal.Rows(A)("ShippedOrderQtyM1")
                .ShippedOrderQtyInPcsM1 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM1")
                .ShippedOrderQtyM2 = dtFinal.Rows(A)("ShippedOrderQtyM2")
                .ShippedOrderQtyInPcsM2 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM2")
                .saveTempSummaryOfWorkLoad()
            End With

        Next
    End Sub
    Sub GetDataForReportCustomerWise()
        Try


            Dim OBJDATE As New GeneralCode
            ObjTempSummaryOfWorkLoadCustomerWise.TruncateTable()
            Dim startdatee As String = txtStartDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim Enddatee As String = txtEndDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            ' Dim STARTDATE As String = OBJDATE.GetDateFormat(startdatee)
            '  Dim ENDDATE As String = OBJDATE.GetDateFormat(Enddatee)
            'Dim CUSTOMERID As Long = cmbCustomer.SelectedValue
            Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
            ' Dim supplieridd As Long = cmbSupplier.SelectedValue
            'Dim supplierid As Long
            Dim saeson As String = cmbSeason.SelectedItem.Text
            Dim dtCustomer As DataTable = ObjTempSummaryOfWorkLoadCustomerWise.GetVender(startdatee, Enddatee, saeson, BuyingDept)
            Dim dtoderdata As DataTable
            Dim dtShIPPED As DataTable
            Dim dtyear3 As DataTable
            Dim i As Integer
            Dim Supplier As String
            Dim dtoderdataM1 As DataTable
            Dim dtShIPPEDM1 As DataTable
            Dim dtoderdataM2 As DataTable
            Dim dtShIPPEDM2 As DataTable
            Dim Month1 As String
            Dim Month2 As String
            Month1 = cmbMonth1.SelectedValue
            Month2 = cmbMonth2.SelectedValue
            Dim M1M2Year As String
            M1M2Year = Year(txtStartDatee.SelectedDate)
            Dim CustomerName As String
            Dim CustomerID As Long
            Dim dtFinal = New DataTable
            With dtFinal
                .Columns.Add("TempId", GetType(Long))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("NoOfLines", GetType(String))
                .Columns.Add("NoOforder", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("OrderQtyInPcs", GetType(String))
                .Columns.Add("ShippedOrderQty", GetType(String))
                .Columns.Add("ShippedOrderQtyInPcs", GetType(String))
                .Columns.Add("OrderQtyM1", GetType(Decimal))
                .Columns.Add("OrderQtyInPcsM1", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyM1", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyInPcsM1", GetType(Decimal))
                .Columns.Add("OrderQtyM2", GetType(Decimal))
                .Columns.Add("OrderQtyInPcsM2", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyM2", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyInPcsM2", GetType(Decimal))
            End With

            For i = 0 To dtCustomer.Rows.Count - 1
                'Supplier = dtSupplier.Rows(i)("VenderName")
                'supplierid = dtSupplier.Rows(i)("Supplierid")
                CustomerName = dtCustomer.Rows(i)("CustomerFullNAME")
                CustomerID = dtCustomer.Rows(i)("CustomerID")
                dtoderdata = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummary(startdatee, Enddatee, saeson, BuyingDept, CustomerID)
                dtShIPPED = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummarySHIPPED(startdatee, Enddatee, saeson, BuyingDept, CustomerID)

                dtoderdataM1 = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummaryForMonth1(Month1, M1M2Year, saeson, BuyingDept, CustomerID)
                dtShIPPEDM1 = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummarySHIPPEDMonth1(Month1, M1M2Year, saeson, BuyingDept, CustomerID)
                dtoderdataM2 = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummaryForMonth2(Month2, M1M2Year, saeson, BuyingDept, CustomerID)
                dtShIPPEDM2 = ObjTempSummaryOfWorkLoadCustomerWise.getdataforWorkLoadSummarySHIPPEDMonth2(Month2, M1M2Year, saeson, BuyingDept, CustomerID)

                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("CustomerName") = CustomerName
                If dtoderdata.Rows.Count > 0 Then
                    Dim OrderQty As Decimal = 0
                    Dim OrderQtyInPcs As Decimal = 0
                    Dim NoOfLines As Decimal = 0
                    Dim NoOforder As Decimal = 0

                    For Y = 0 To dtoderdata.Rows.Count - 1
                        OrderQty = OrderQty + Val(dtoderdata.Rows(Y)("OrderQty"))
                        OrderQtyInPcs = OrderQtyInPcs + Val(dtoderdata.Rows(Y)("OrderQtyInPcs"))
                        NoOfLines = NoOfLines + Val(dtoderdata.Rows(Y)("NoOfLines"))
                        NoOforder = NoOforder + Val(dtoderdata.Rows(Y)("NoOforder"))
                        Dr("OrderQty") = OrderQty
                        Dr("OrderQtyInPcs") = OrderQtyInPcs
                        Dr("NoOfLines") = NoOfLines
                        Dr("NoOforder") = NoOforder

                    Next
                Else
                    Dr("OrderQty") = 0
                    Dr("OrderQtyInPcs") = 0
                    Dr("NoOfLines") = 0
                    Dr("NoOforder") = 0
                End If


                If dtoderdataM1.Rows.Count > 0 Then
                    Dim OrderQtyM1 As Decimal = 0
                    Dim OrderQtyInPcsM1 As Decimal = 0


                    For a = 0 To dtoderdataM1.Rows.Count - 1
                        OrderQtyM1 = OrderQtyM1 + Val(dtoderdataM1.Rows(a)("OrderQtyM1"))
                        OrderQtyInPcsM1 = OrderQtyInPcsM1 + Val(dtoderdataM1.Rows(a)("OrderQtyInPcsM1"))

                        Dr("OrderQtyM1") = OrderQtyM1
                        Dr("OrderQtyInPcsM1") = OrderQtyInPcsM1

                    Next
                Else
                    Dr("OrderQtyM1") = 0
                    Dr("OrderQtyInPcsM1") = 0

                End If
                If dtShIPPEDM1.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcsM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyInPcsM1")
                    Dr("ShippedOrderQtyM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyM1")
                Else
                    Dr("ShippedOrderQtyInPcsM1") = 0
                    Dr("ShippedOrderQtyM1") = 0
                End If

                If dtoderdataM2.Rows.Count > 0 Then
                    Dim OrderQtyM2 As Decimal = 0
                    Dim OrderQtyInPcsM2 As Decimal = 0


                    For b = 0 To dtoderdataM2.Rows.Count - 1
                        OrderQtyM2 = OrderQtyM2 + Val(dtoderdataM2.Rows(b)("OrderQtyM2"))
                        OrderQtyInPcsM2 = OrderQtyInPcsM2 + Val(dtoderdataM2.Rows(b)("OrderQtyInPcsM2"))

                        Dr("OrderQtyM2") = OrderQtyM2
                        Dr("OrderQtyInPcsM2") = OrderQtyInPcsM2

                    Next
                Else
                    Dr("OrderQtyM2") = 0
                    Dr("OrderQtyInPcsM2") = 0

                End If
                If dtShIPPEDM2.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcsM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyInPcsM2")
                    Dr("ShippedOrderQtyM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyM2")
                Else
                    Dr("ShippedOrderQtyInPcsM2") = 0
                    Dr("ShippedOrderQtyM2") = 0
                End If



                If dtShIPPED.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcs") = dtShIPPED.Rows(0)("ShippedOrderQtyInPcs")
                    Dr("ShippedOrderQty") = dtShIPPED.Rows(0)("ShippedOrderQty")
                Else
                    Dr("ShippedOrderQtyInPcs") = 0
                    Dr("ShippedOrderQty") = 0
                End If

                dtFinal.Rows.Add(Dr)
            Next
            For A As Integer = 0 To dtFinal.Rows.Count - 1
                With ObjTempSummaryOfWorkLoadCustomerWise
                    .TempId = 0
                    .CustomerName = dtFinal.Rows(A)("CustomerName")
                    .NoOfLines = dtFinal.Rows(A)("NoOfLines")
                    .NoOforder = dtFinal.Rows(A)("NoOforder")
                    .OrderQty = dtFinal.Rows(A)("OrderQty")
                    .OrderQtyInPcs = dtFinal.Rows(A)("OrderQtyInPcs")
                    .ShippedOrderQty = dtFinal.Rows(A)("ShippedOrderQty")
                    .ShippedOrderQtyInPcs = dtFinal.Rows(A)("ShippedOrderQtyInPcs")

                    .OrderQtyM1 = dtFinal.Rows(A)("OrderQtyM1")
                    .OrderQtyInPcsM1 = dtFinal.Rows(A)("OrderQtyInPcsM1")
                    .OrderQtyM2 = dtFinal.Rows(A)("OrderQtyM2")
                    .OrderQtyInPcsM2 = dtFinal.Rows(A)("OrderQtyInPcsM2")

                    .ShippedOrderQtyM1 = dtFinal.Rows(A)("ShippedOrderQtyM1")
                    .ShippedOrderQtyInPcsM1 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM1")
                    .ShippedOrderQtyM2 = dtFinal.Rows(A)("ShippedOrderQtyM2")
                    .ShippedOrderQtyInPcsM2 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM2")
                    .saveTempSummaryOfWorkLoadCustomerWise()
                End With

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetDataForReportDeptWise()
        Try


            Dim OBJDATE As New GeneralCode
            ObjTempSummaryOfWorkLoadDeptWise.TruncateTable()
            Dim startdatee As String = txtStartDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            Dim Enddatee As String = txtEndDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            ' Dim STARTDATE As String = OBJDATE.GetDateFormat(startdatee)
            '  Dim ENDDATE As String = OBJDATE.GetDateFormat(Enddatee)
            'Dim CUSTOMERID As Long = cmbCustomer.SelectedValue
            Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
            ' Dim supplieridd As Long = cmbSupplier.SelectedValue
            'Dim supplierid As Long
            Dim saeson As String = cmbSeason.SelectedItem.Text
            Dim CustomerID As Long = cmbCustomer.SelectedValue
            Dim dtBuyingDept As DataTable = ObjTempSummaryOfWorkLoadDeptWise.GetVender(startdatee, Enddatee, saeson, CustomerID)
            Dim dtoderdata As DataTable
            Dim dtShIPPED As DataTable
            Dim dtyear3 As DataTable
            Dim i As Integer
            Dim Supplier As String
            Dim dtoderdataM1 As DataTable
            Dim dtShIPPEDM1 As DataTable
            Dim dtoderdataM2 As DataTable
            Dim dtShIPPEDM2 As DataTable
            Dim Month1 As String
            Dim Month2 As String
            Month1 = cmbMonth1.SelectedValue
            Month2 = cmbMonth2.SelectedValue
            Dim M1M2Year As String
            M1M2Year = Year(txtStartDatee.SelectedDate)
            Dim DeptName As String
            Dim CustomerName As String = cmbCustomer.SelectedItem.Text

            Dim dtFinal = New DataTable
            With dtFinal
                .Columns.Add("TempId", GetType(Long))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("DeptName", GetType(String))
                .Columns.Add("NoOfLines", GetType(String))
                .Columns.Add("NoOforder", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("OrderQtyInPcs", GetType(String))
                .Columns.Add("ShippedOrderQty", GetType(String))
                .Columns.Add("ShippedOrderQtyInPcs", GetType(String))
                .Columns.Add("OrderQtyM1", GetType(Decimal))
                .Columns.Add("OrderQtyInPcsM1", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyM1", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyInPcsM1", GetType(Decimal))
                .Columns.Add("OrderQtyM2", GetType(Decimal))
                .Columns.Add("OrderQtyInPcsM2", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyM2", GetType(Decimal))
                .Columns.Add("ShippedOrderQtyInPcsM2", GetType(Decimal))
            End With

            For i = 0 To dtBuyingDept.Rows.Count - 1
                'Supplier = dtSupplier.Rows(i)("VenderName")
                'supplierid = dtSupplier.Rows(i)("Supplierid")
                DeptName = dtBuyingDept.Rows(i)("EkNumber")
                'CustomerID = dtCustomer.Rows(i)("CustomerID")
                dtoderdata = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummary(startdatee, Enddatee, saeson, DeptName, CustomerID)
                dtShIPPED = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummarySHIPPED(startdatee, Enddatee, saeson, DeptName, CustomerID)

                dtoderdataM1 = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummaryForMonth1(Month1, M1M2Year, saeson, DeptName, CustomerID)
                dtShIPPEDM1 = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummarySHIPPEDMonth1(Month1, M1M2Year, saeson, DeptName, CustomerID)
                dtoderdataM2 = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummaryForMonth2(Month2, M1M2Year, saeson, DeptName, CustomerID)
                dtShIPPEDM2 = ObjTempSummaryOfWorkLoadDeptWise.getdataforWorkLoadSummarySHIPPEDMonth2(Month2, M1M2Year, saeson, DeptName, CustomerID)

                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("CustomerName") = CustomerName
                Dr("DeptName") = DeptName
                If dtoderdata.Rows.Count > 0 Then
                    Dim OrderQty As Decimal = 0
                    Dim OrderQtyInPcs As Decimal = 0
                    Dim NoOfLines As Decimal = 0
                    Dim NoOforder As Decimal = 0

                    For Y = 0 To dtoderdata.Rows.Count - 1
                        OrderQty = OrderQty + Val(dtoderdata.Rows(Y)("OrderQty"))
                        OrderQtyInPcs = OrderQtyInPcs + Val(dtoderdata.Rows(Y)("OrderQtyInPcs"))
                        NoOfLines = NoOfLines + Val(dtoderdata.Rows(Y)("NoOfLines"))
                        NoOforder = NoOforder + Val(dtoderdata.Rows(Y)("NoOforder"))
                        Dr("OrderQty") = OrderQty
                        Dr("OrderQtyInPcs") = OrderQtyInPcs
                        Dr("NoOfLines") = NoOfLines
                        Dr("NoOforder") = NoOforder

                    Next
                Else
                    Dr("OrderQty") = 0
                    Dr("OrderQtyInPcs") = 0
                    Dr("NoOfLines") = 0
                    Dr("NoOforder") = 0
                End If


                If dtoderdataM1.Rows.Count > 0 Then
                    Dim OrderQtyM1 As Decimal = 0
                    Dim OrderQtyInPcsM1 As Decimal = 0


                    For a = 0 To dtoderdataM1.Rows.Count - 1
                        OrderQtyM1 = OrderQtyM1 + Val(dtoderdataM1.Rows(a)("OrderQtyM1"))
                        OrderQtyInPcsM1 = OrderQtyInPcsM1 + Val(dtoderdataM1.Rows(a)("OrderQtyInPcsM1"))

                        Dr("OrderQtyM1") = OrderQtyM1
                        Dr("OrderQtyInPcsM1") = OrderQtyInPcsM1

                    Next
                Else
                    Dr("OrderQtyM1") = 0
                    Dr("OrderQtyInPcsM1") = 0

                End If
                If dtShIPPEDM1.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcsM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyInPcsM1")
                    Dr("ShippedOrderQtyM1") = dtShIPPEDM1.Rows(0)("ShippedOrderQtyM1")
                Else
                    Dr("ShippedOrderQtyInPcsM1") = 0
                    Dr("ShippedOrderQtyM1") = 0
                End If

                If dtoderdataM2.Rows.Count > 0 Then
                    Dim OrderQtyM2 As Decimal = 0
                    Dim OrderQtyInPcsM2 As Decimal = 0


                    For b = 0 To dtoderdataM2.Rows.Count - 1
                        OrderQtyM2 = OrderQtyM2 + Val(dtoderdataM2.Rows(b)("OrderQtyM2"))
                        OrderQtyInPcsM2 = OrderQtyInPcsM2 + Val(dtoderdataM2.Rows(b)("OrderQtyInPcsM2"))

                        Dr("OrderQtyM2") = OrderQtyM2
                        Dr("OrderQtyInPcsM2") = OrderQtyInPcsM2

                    Next
                Else
                    Dr("OrderQtyM2") = 0
                    Dr("OrderQtyInPcsM2") = 0

                End If
                If dtShIPPEDM2.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcsM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyInPcsM2")
                    Dr("ShippedOrderQtyM2") = dtShIPPEDM2.Rows(0)("ShippedOrderQtyM2")
                Else
                    Dr("ShippedOrderQtyInPcsM2") = 0
                    Dr("ShippedOrderQtyM2") = 0
                End If



                If dtShIPPED.Rows.Count > 0 Then
                    Dr("ShippedOrderQtyInPcs") = dtShIPPED.Rows(0)("ShippedOrderQtyInPcs")
                    Dr("ShippedOrderQty") = dtShIPPED.Rows(0)("ShippedOrderQty")
                Else
                    Dr("ShippedOrderQtyInPcs") = 0
                    Dr("ShippedOrderQty") = 0
                End If

                dtFinal.Rows.Add(Dr)
            Next
            For A As Integer = 0 To dtFinal.Rows.Count - 1
                With ObjTempSummaryOfWorkLoadDeptWise
                    .TempId = 0
                    .CustomerName = dtFinal.Rows(A)("CustomerName")
                    .DeptName = dtFinal.Rows(A)("DeptName")
                    .NoOfLines = dtFinal.Rows(A)("NoOfLines")
                    .NoOforder = dtFinal.Rows(A)("NoOforder")
                    .OrderQty = dtFinal.Rows(A)("OrderQty")
                    .OrderQtyInPcs = dtFinal.Rows(A)("OrderQtyInPcs")
                    .ShippedOrderQty = dtFinal.Rows(A)("ShippedOrderQty")
                    .ShippedOrderQtyInPcs = dtFinal.Rows(A)("ShippedOrderQtyInPcs")

                    .OrderQtyM1 = dtFinal.Rows(A)("OrderQtyM1")
                    .OrderQtyInPcsM1 = dtFinal.Rows(A)("OrderQtyInPcsM1")
                    .OrderQtyM2 = dtFinal.Rows(A)("OrderQtyM2")
                    .OrderQtyInPcsM2 = dtFinal.Rows(A)("OrderQtyInPcsM2")

                    .ShippedOrderQtyM1 = dtFinal.Rows(A)("ShippedOrderQtyM1")
                    .ShippedOrderQtyInPcsM1 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM1")
                    .ShippedOrderQtyM2 = dtFinal.Rows(A)("ShippedOrderQtyM2")
                    .ShippedOrderQtyInPcsM2 = dtFinal.Rows(A)("ShippedOrderQtyInPcsM2")
                    .saveTempSummaryOfWorkLoadDeptWise()
                End With

            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSummaryReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSummaryReport.Click
        Try
            If txtStartDatee.ValidationDate <> "" And txtEndDatee.ValidationDate <> "" Then

                GetDataForReport()
                Dim season As String = cmbSeason.SelectedItem.Text
                Dim supplier As String
                Dim Bytindept As String
                Dim customer As String
                Dim M1 As String = cmbMonth1.SelectedItem.Text
                Dim M2 As String = cmbMonth2.SelectedItem.Text
                If cmbSupplier.SelectedValue = 0 Then
                    supplier = "All"
                Else
                    supplier = cmbSupplier.SelectedItem.Text
                End If


                customer = cmbCustomer.SelectedItem.Text


                If cmbBuyingDept.SelectedItem.Text = "All" Then
                    Bytindept = "All"
                Else
                    Bytindept = cmbBuyingDept.SelectedItem.Text
                End If
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If txtStartDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""
                ElseIf txtEndDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""

                Else
                    Dim Heading As String
                    Dim monthdate As Date = txtStartDatee.SelectedDate
                    Dim Year As String = monthdate.Year
                    If cmbReportType.SelectedItem.Text = "Monthly" Then
                        If monthdate.Month = 1 Then
                            Heading = "Jan"
                        ElseIf monthdate.Month = 2 Then
                            Heading = "Feb"
                        ElseIf monthdate.Month = 3 Then
                            Heading = "Mar"
                        ElseIf monthdate.Month = 4 Then
                            Heading = "April"
                        ElseIf monthdate.Month = 5 Then
                            Heading = "May"
                        ElseIf monthdate.Month = 6 Then
                            Heading = "June"
                        ElseIf monthdate.Month = 7 Then
                            Heading = "July"
                        ElseIf monthdate.Month = 8 Then
                            Heading = "Aug"
                        ElseIf monthdate.Month = 9 Then
                            Heading = "Sep"
                        ElseIf monthdate.Month = 10 Then
                            Heading = "Oct"
                        ElseIf monthdate.Month = 11 Then
                            Heading = "Nov"
                        ElseIf monthdate.Month = 12 Then
                            Heading = "Dec"
                        End If
                    ElseIf cmbReportType.SelectedItem.Text = "Yearly" Then
                        Heading = monthdate.Year
                    Else
                        Heading = cmbSeason.SelectedItem.Text
                    End If

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    'Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinal.rpt"))
                    Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinalNew.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "WorkLoadSummary"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, supplier)
                    Report.SetParameterValue(1, season)
                    Report.SetParameterValue(2, cmbReportType.SelectedItem.Text)
                    Report.SetParameterValue(3, Heading)
                    Report.SetParameterValue(4, customer)
                    Report.SetParameterValue(5, M1)
                    Report.SetParameterValue(6, M2)
                    Report.SetParameterValue(7, cmbBuyingDept.SelectedItem.Text)
                    Report.SetParameterValue(8, Year)
                    'Report.SetParameterValue(5, txtEndDate.Text)

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
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnReportCustomerWise_Click(sender As Object, e As EventArgs) Handles btnReportCustomerWise.Click
        Try
            If txtStartDatee.ValidationDate <> "" And txtEndDatee.ValidationDate <> "" Then

                GetDataForReportCustomerWise()
                Dim season As String = cmbSeason.SelectedItem.Text
                'Dim supplier As String
                Dim Bytindept As String
                Dim customer As String
                Dim M1 As String = cmbMonth1.SelectedItem.Text
                Dim M2 As String = cmbMonth2.SelectedItem.Text
                ' If cmbSupplier.SelectedValue = 0 Then
                'supplier = "All"
                ' Else
                '   supplier = cmbSupplier.SelectedItem.Text
                ' End If


                ' customer = cmbCustomer.SelectedItem.Text


                If cmbBuyingDept.SelectedItem.Text = "All" Then
                    Bytindept = "All"
                Else
                    Bytindept = cmbBuyingDept.SelectedItem.Text
                End If
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If txtStartDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""
                ElseIf txtEndDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""

                Else
                    Dim Heading As String
                    Dim monthdate As Date = txtStartDatee.SelectedDate
                    Dim Year As String = monthdate.Year
                    If cmbReportType.SelectedItem.Text = "Monthly" Then
                        If monthdate.Month = 1 Then
                            Heading = "Jan"
                        ElseIf monthdate.Month = 2 Then
                            Heading = "Feb"
                        ElseIf monthdate.Month = 3 Then
                            Heading = "Mar"
                        ElseIf monthdate.Month = 4 Then
                            Heading = "April"
                        ElseIf monthdate.Month = 5 Then
                            Heading = "May"
                        ElseIf monthdate.Month = 6 Then
                            Heading = "June"
                        ElseIf monthdate.Month = 7 Then
                            Heading = "July"
                        ElseIf monthdate.Month = 8 Then
                            Heading = "Aug"
                        ElseIf monthdate.Month = 9 Then
                            Heading = "Sep"
                        ElseIf monthdate.Month = 10 Then
                            Heading = "Oct"
                        ElseIf monthdate.Month = 11 Then
                            Heading = "Nov"
                        ElseIf monthdate.Month = 12 Then
                            Heading = "Dec"
                        End If
                    ElseIf cmbReportType.SelectedItem.Text = "Yearly" Then
                        Heading = monthdate.Year
                    Else
                        Heading = cmbSeason.SelectedItem.Text
                    End If

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    'Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinal.rpt"))
                    Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinalNewCustomerWise.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "WorkLoadSummary"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    ' Report.SetParameterValue(0, supplier)
                    Report.SetParameterValue(0, season)
                    Report.SetParameterValue(1, cmbReportType.SelectedItem.Text)
                    Report.SetParameterValue(2, Heading)
                    ' Report.SetParameterValue(3, customer)
                    Report.SetParameterValue(3, M1)
                    Report.SetParameterValue(4, M2)
                    ' Report.SetParameterValue(5, cmbBuyingDept.SelectedItem.Text)
                    Report.SetParameterValue(5, Year)
                    'Report.SetParameterValue(5, txtEndDate.Text)

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
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnReportDeptWise_Click(sender As Object, e As EventArgs) Handles btnReportDeptWise.Click
        Try
            If txtStartDatee.ValidationDate <> "" And txtEndDatee.ValidationDate <> "" Then

                GetDataForReportDeptWise()
                Dim season As String = cmbSeason.SelectedItem.Text
                'Dim supplier As String
                Dim Bytindept As String
                Dim customer As String
                Dim M1 As String = cmbMonth1.SelectedItem.Text
                Dim M2 As String = cmbMonth2.SelectedItem.Text
                ' If cmbSupplier.SelectedValue = 0 Then
                'supplier = "All"
                ' Else
                '   supplier = cmbSupplier.SelectedItem.Text
                ' End If


                ' customer = cmbCustomer.SelectedItem.Text


                If cmbBuyingDept.SelectedItem.Text = "All" Then
                    Bytindept = "All"
                Else
                    Bytindept = cmbBuyingDept.SelectedItem.Text
                End If
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If txtStartDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""
                ElseIf txtEndDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
                    'txtStartDate.Text = ""
                    'txtEndDate.Text = ""

                Else
                    Dim Heading As String
                    Dim monthdate As Date = txtStartDatee.SelectedDate
                    Dim Year As String = monthdate.Year
                    If cmbReportType.SelectedItem.Text = "Monthly" Then
                        If monthdate.Month = 1 Then
                            Heading = "Jan"
                        ElseIf monthdate.Month = 2 Then
                            Heading = "Feb"
                        ElseIf monthdate.Month = 3 Then
                            Heading = "Mar"
                        ElseIf monthdate.Month = 4 Then
                            Heading = "April"
                        ElseIf monthdate.Month = 5 Then
                            Heading = "May"
                        ElseIf monthdate.Month = 6 Then
                            Heading = "June"
                        ElseIf monthdate.Month = 7 Then
                            Heading = "July"
                        ElseIf monthdate.Month = 8 Then
                            Heading = "Aug"
                        ElseIf monthdate.Month = 9 Then
                            Heading = "Sep"
                        ElseIf monthdate.Month = 10 Then
                            Heading = "Oct"
                        ElseIf monthdate.Month = 11 Then
                            Heading = "Nov"
                        ElseIf monthdate.Month = 12 Then
                            Heading = "Dec"
                        End If
                    ElseIf cmbReportType.SelectedItem.Text = "Yearly" Then
                        Heading = monthdate.Year
                    Else
                        Heading = cmbSeason.SelectedItem.Text
                    End If

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    'Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinal.rpt"))
                    Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinalNewDeptWise.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "WorkLoadSummary"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    ' Report.SetParameterValue(0, supplier)
                    Report.SetParameterValue(0, season)
                    Report.SetParameterValue(1, cmbReportType.SelectedItem.Text)
                    Report.SetParameterValue(2, Heading)
                    ' Report.SetParameterValue(3, customer)
                    Report.SetParameterValue(3, M1)
                    Report.SetParameterValue(4, M2)
                    ' Report.SetParameterValue(5, cmbBuyingDept.SelectedItem.Text)
                    Report.SetParameterValue(5, Year)
                    'Report.SetParameterValue(5, txtEndDate.Text)

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
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
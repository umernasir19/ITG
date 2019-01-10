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
Public Class QCWORKLOAD
    Inherits System.Web.UI.Page
    Dim ObjTempQcWiseload As New TempQcWiseload
    Dim Dr As DataRow
    Dim objPurchaseMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
            'BindBuyingDept()
        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objPurchaseMaster.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()


            ''---Bind BuyingDept
            cmbbuyingDept.DataSource = objPurchaseMaster.GetBuyingDeptForComparsionReportNew(cmbCustomer.SelectedValue)
            cmbbuyingDept.DataTextField = "EKNumber"
            cmbbuyingDept.DataValueField = "EKNumber"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbbuyingDept.DataSource = objPurchaseMaster.GetBuyingDeptForComparsionReportNew(cmbCustomer.SelectedValue)
            cmbbuyingDept.DataTextField = "EKNumber"
            cmbbuyingDept.DataValueField = "EKNumber"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("All", "0"))

            txtStartDate.Text = ""
            txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub
    Sub BindBuyingDept()

        Dim dt As DataTable
        dt = objPurchaseMaster.GetBuyingDeptForComparsionReport
        cmbbuyingDept.DataSource = dt
        cmbbuyingDept.DataTextField = "EKNumber"
        cmbbuyingDept.DataValueField = "EKNumber"
        cmbbuyingDept.DataBind()
    End Sub
    Sub GetDataForReport()
        Dim OBJDATE As New GeneralCode
        ObjTempQcWiseload.TruncateTable()
        Dim STARTDATE As String = OBJDATE.GetDateFormat(txtStartDate.Text)
        Dim ENDDATE As String = OBJDATE.GetDateFormat(txtEndDate.Text)
        Dim supplierid As String
        'Dim dtSupplier As DataTable = ObjTempQcWiseload.GetVender(STARTDATE, ENDDATE, cmbbuyingDept.SelectedItem.Text)
        Dim dtSupplier As DataTable = ObjTempQcWiseload.GetVenderNew(STARTDATE, ENDDATE, cmbbuyingDept.SelectedItem.Text, cmbCustomer.SelectedValue)
        Dim dtoderdata As DataTable
        Dim dtShIPPED As DataTable
        Dim dtQA As DataTable
        Dim i As Integer
        Dim Supplier As String
        Dim BuyingDept As String = cmbbuyingDept.SelectedItem.Text
        Dim CustomerID As Long = cmbCustomer.SelectedValue

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
            .Columns.Add("QANAME", GetType(String))
        End With

        For i = 0 To dtSupplier.Rows.Count - 1
            Supplier = dtSupplier.Rows(i)("VenderName")
            supplierid = dtSupplier.Rows(i)("Supplierid")
            'dtoderdata = ObjTempQcWiseload.getdataforWorkLoadSummary(STARTDATE, ENDDATE, supplierid)
            'dtShIPPED = ObjTempQcWiseload.getdataforWorkLoadSummarySHIPPED(STARTDATE, ENDDATE, supplierid)

            dtoderdata = ObjTempQcWiseload.getdataforWorkLoadSummaryNew(STARTDATE, ENDDATE, supplierid, BuyingDept, CustomerID)
            dtShIPPED = ObjTempQcWiseload.getdataforWorkLoadSummarySHIPPEDNew(STARTDATE, ENDDATE, supplierid, BuyingDept, CustomerID)
            dtQA = ObjTempQcWiseload.getdataqa(STARTDATE, ENDDATE, supplierid)
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
            If dtShIPPED.Rows.Count > 0 Then

                Dr("ShippedOrderQtyInPcs") = dtShIPPED.Rows(0)("ShippedOrderQtyInPcs")
                Dr("ShippedOrderQty") = dtShIPPED.Rows(0)("ShippedOrderQty")
            Else
                Dr("ShippedOrderQtyInPcs") = 0
                Dr("ShippedOrderQty") = 0
            End If
            If dtQA.Rows.Count > 0 Then
                Dim QAName As String = ""
                For X = 0 To dtQA.Rows.Count - 1
                    If X = dtQA.Rows.Count - 1 Then
                        QAName = QAName + dtQA.Rows(X)("QANAME")
                    Else
                        QAName = QAName + dtQA.Rows(X)("QANAME") + ","
                    End If
                    Dr("QANAME") = QAName
                Next

            Else
                Dr("QANAME") = "NA"

            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With ObjTempQcWiseload
                .TempId = 0
                .Supplier = dtFinal.Rows(A)("Supplier")
                .NoOfLines = dtFinal.Rows(A)("NoOfLines")
                .NoOforder = dtFinal.Rows(A)("NoOforder")
                .OrderQty = dtFinal.Rows(A)("OrderQty")
                .OrderQtyInPcs = dtFinal.Rows(A)("OrderQtyInPcs")
                .ShippedOrderQty = dtFinal.Rows(A)("ShippedOrderQty")
                .ShippedOrderQtyInPcs = dtFinal.Rows(A)("ShippedOrderQtyInPcs")
                .QANAME = dtFinal.Rows(A)("QANAME")
                .saveTempSummaryOfWorkLoad()
            End With

        Next
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If txtStartDate.Text <> "" And txtEndDate.Text <> "" Then



                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If txtStartDate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date Empty.")
                    txtStartDate.Text = ""
                    txtEndDate.Text = ""
                ElseIf txtEndDate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date Empty.")
                    txtStartDate.Text = ""
                    txtEndDate.Text = ""

                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    GetDataForReport()
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Report.Load(Server.MapPath("..\Reports/QCworkloadFinal.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "QCWorkLoad"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, txtStartDate.Text)
                    Report.SetParameterValue(1, txtEndDate.Text)
                    Report.SetParameterValue(2, cmbbuyingDept.SelectedItem.Text)
                    Report.SetParameterValue(3, cmbCustomer.SelectedItem.Text)

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
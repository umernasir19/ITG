Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CargoView
    Inherits System.Web.UI.Page
    Dim objCommercial As New Commercial
    Dim objcargo As New Cargo
    Dim objcargodetail As New CargoDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            PageHeader("Invoice View")
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
     
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgPurchaseOrder.DataSource = objDataView
            dgPurchaseOrder.DataBind()
            '--To check Already Commercial Invoice Created or not Plus Shipped Exchange Rate
            Dim dtcheck As New DataTable
            Dim objShipExchangeRate As New ShipExchangeRate
            Dim dtExchangerate As DataTable
            Dim txtEXRate As RadTextBox
            Dim linkBtn As LinkButton
            Dim x As Integer
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
                Dim lETD As Date = item("ETDD").Text
                Dim MontStart As Date = DateSerial(Year(lETD), Month(lETD), 1)
                Dim MonthEnd As Date = DateSerial(Year(lETD), Month(lETD) + 1, 0)
                dtExchangerate = objShipExchangeRate.ExistingOfShipRate(MontStart, MonthEnd)
                txtEXRate = DirectCast(item.FindControl("txtExchangeRate"), RadTextBox)
                linkBtn = DirectCast(item.FindControl("lnConfirm"), LinkButton)
                If dtExchangerate.Rows.Count > 0 Then
                    txtEXRate.Text = dtExchangerate.Rows(0)("ShipExchangeRate")
                Else
                    txtEXRate.Text = 0
                End If
                Dim lInvoiceNo As String = item("InvoiceNo").Text
                dtcheck = objcargo.checkInvoice(lInvoiceNo)
                If dtcheck.Rows.Count > 0 Then
                    linkBtn.Text = "Confirmed"
                    linkBtn.Enabled = False
                Else
                    linkBtn.Text = "UnConfirm"
                    linkBtn.Enabled = True
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCommercial.GetCommercialInvoiceForView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "PDF"
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lCommercialInvoiceID As String = item("CommercialInvoiceID").Text
                Dim ETD As Date = item("ETDD").Text

                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Report.Load(Server.MapPath("..\Reports/CommercialInvoice.rpt"))

                Dim FileName As String = "Commercial Invoice-" + ETD.ToString("dd-MM-yyyy")
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, lCommercialInvoiceID)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()
                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "Commercial Invoice-" + ETD.ToString("dd-MM-yyyy") + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next
            Case Is = "Confirm"
                Dim txtEXRate As RadTextBox
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lCommercialInvoiceID As String = item("CommercialInvoiceID").Text
                txtEXRate = DirectCast(item.FindControl("txtExchangeRate"), RadTextBox)
                Dim EXRate As String = txtEXRate.Text
                If EXRate = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please enter exchange rate of shipped date.")
                    Exit Select
                Else
                    Dim dtcargo As DataTable = objCommercial.GetCommercialMasterdata(lCommercialInvoiceID)
                    Dim dtcargodetail As DataTable = objCommercial.GetCommercialDetaildata(lCommercialInvoiceID)
                    '----Save Cargo Master

                    With objcargo
                        .CargoID = 0
                        .CreationDate = Date.Now
                        .InvoiceNo = dtcargo.Rows(0)("InvoiceNo")
                        .InvoiceDate = dtcargo.Rows(0)("InvoiceDate")
                        .InvoiceValue = dtcargo.Rows(0)("InvoiceValue")
                        .Terms = dtcargo.Rows(0)("Terms")
                        .ItemDescription = dtcargo.Rows(0)("ItemDescription")
                        .Mode = dtcargo.Rows(0)("Mode")
                        .CarrierName = dtcargo.Rows(0)("CarrierName")
                        .VoyageFlight = dtcargo.Rows(0)("VoyageFlight")
                        .BillNo = dtcargo.Rows(0)("BillNo")
                        .ShipmentDate = dtcargo.Rows(0)("ShipmentDate")
                        .ContainerNo = dtcargo.Rows(0)("ContainerNo")
                        .Remarks = dtcargo.Rows(0)("Remarks")
                        .IsActive = True
                        .ETD = dtcargo.Rows(0)("ETA")
                        .ETA = dtcargo.Rows(0)("ETD")
                        .Forwarder = dtcargo.Rows(0)("Forwarder")
                        ' .Currency = dtcargo.Rows(0)("Currency")
                        .CBM = 0
                        .Consolidation = dtcargo.Rows(0)("Consolidation")
                        .ContainerSize = dtcargo.Rows(0)("ContainerSize")
                        .ShippingLine = ""
                        If EXRate = 0 Then
                            .ShippedExchangeRate = 0
                        Else
                            .ShippedExchangeRate = EXRate
                        End If
                        .SaveCargo()
                    End With
                    '----END Save Cargo Master
                    '----Save Cargo Detail
                    For x = 0 To dtcargodetail.Rows.Count - 1
                        With objcargodetail
                            .CargoDetailID = 0
                            .CargoID = objcargo.GetId
                            .POID = dtcargodetail.Rows(x)("PODetailID")
                            .Quantity = dtcargodetail.Rows(x)("Quantity")
                           
                            .CustomerID = 0

                            .POPOID = dtcargodetail.Rows(x)("POID")
                            .ShippedRate = dtcargodetail.Rows(x)("Rate")
                            .SaveCargoDetail()
                        End With
                    Next
                    '----END Save Cargo Detail
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Save Successfully.")
                    BindGrid()
                End If
        End Select
    End Sub

End Class
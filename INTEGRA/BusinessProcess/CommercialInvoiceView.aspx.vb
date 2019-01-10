Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CommercialInvoiceView
    Inherits System.Web.UI.Page
    Dim objCommercial As New Commercial
    Dim objcargo As New Cargo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            PageHeader("Commercial Invoice View")
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        Else
            ' BindGrid()
            'Response.Redirect("MasterOrderForSupplier.aspx")
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

            '--To check Already Commercial Invoice Created or not
            Dim dtcheck As New DataTable
            Dim x As Integer
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
                Dim InvoiceNo As String = item("InvoiceNo").Text

                dtcheck = objcargo.checkInvoice(InvoiceNo)
                If dtcheck.Rows.Count > 0 Then
                    Dim linkBtn As LinkButton
                    linkBtn = DirectCast(item.FindControl("lnEdit"), LinkButton)
                    linkBtn.Enabled = False
                Else
                    Dim linkBtn As LinkButton
                    linkBtn = DirectCast(item.FindControl("lnEdit"), LinkButton)
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
            Case Is = "Edit"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim CommercialInvoiceID As String = item("CommercialInvoiceID").Text
                Response.Redirect("CommercialInvoices.aspx?lCommercialInvoiceID=" & CommercialInvoiceID & "")
        End Select
    End Sub
    'Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
    '    Select Case e.CommandName
    '        Case Is = "Edit"
    '            Dim Id As String = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
    '            Response.Redirect("CommercialInvoices.aspx?lCommercialInvoiceID=" & Id & "")

    '            ' Dim st As StringBuilder = New StringBuilder()
    '            'st.Append("<script language='javascript'>")
    '            'st.Append("var w = window.open('CommercialInvoices.aspx?lCommercialInvoiceID=" & Id & "','PopUpWindowName','left=50, top=30, height=700, width=750, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
    '            'st.Append("w.focus()")
    '            'st.Append("</script>")
    '            'Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
    '    End Select

    'End Sub
End Class
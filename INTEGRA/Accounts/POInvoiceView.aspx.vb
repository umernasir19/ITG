Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POInvoiceView
    Inherits System.Web.UI.Page
    Dim objPOInvoiceMaster As New POInvoiceMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PURCHASE VOUCHER")
    End Sub

    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()

    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOInvoiceMaster.GetPOInvoiceforView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("POInvoice.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim POInvoiceMAsterID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim AccountPayablePartyID As Long = dgView.Items(e.Item.ItemIndex).Cells(12).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("POInvoice.aspx?lPOInvoiceMAsterID=" & POInvoiceMAsterID & " &AccountPayablePartyID=" & AccountPayablePartyID & "")
                Case "Remove"
                    Dim POInvoiceMAsterID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    '  objPOInvoiceMaster.DeleteFromPOInvoiceMAster(POInvoiceMAsterID)
                    ' objPOInvoiceMaster.DeleteFromPOInvoiceDetail(POInvoiceMAsterID)
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Case "PDF"
                    Dim POInvoiceMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim Type As String = dgView.Items(e.Item.ItemIndex).Cells(6).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String
                    Report.Load(Server.MapPath("..\Accounts/PurchaseVoucher.rpt"))

                    'If Type = "With GST" Then
                    '    If dgView.Items(e.Item.ItemIndex).Cells(12).Text = "PORECEIVE" Then
                    '        Report.Load(Server.MapPath("..\Accounts/POInvoiceWithGST.rpt"))
                    '    Else
                    '        Report.Load(Server.MapPath("..\Accounts/POInvoiceYarnWithGST.rpt"))
                    '    End If

                    'Else
                    '    If dgView.Items(e.Item.ItemIndex).Cells(12).Text = "PORECEIVE" Then
                    '        Report.Load(Server.MapPath("..\Accounts/POInvoice.rpt"))
                    '    Else
                    '        Report.Load(Server.MapPath("..\Accounts/POInvoiceYarnWithOutGST.rpt"))
                    '    End If

                    ' End If

                    FileName = "PurchaseVoucher"

                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, POInvoiceMstID)


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
                        Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                        Response.End()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub



End Class



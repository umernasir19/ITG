Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class StoreReceiptVoucherViewNew
    Inherits System.Web.UI.Page
    Dim objStoreReceiptVoucherMst As New StoreReceiptVoucherMst
    Dim objStoreReceiptVoucherDtl As New StoreReceiptVoucherDtl
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim Userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then

            Try
                Bindgrid()
            Catch objUDException As UDException

            End Try
            PageHeader("Store Receipt Voucher View")

        End If

    End Sub



    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub Bindgrid()
        Dim dt As DataTable

        dt = objStoreReceiptVoucherMst.View1(Userid)
        If dt.Rows.Count > 0 Then
            dgVoucherView.DataSource = dt
            dgVoucherView.DataBind()
        Else
        End If

    End Sub
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("StoreReceiptVoucherEntry.aspx")
    End Sub
    Protected Sub dgVoucherView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVoucherView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    ' Dim lJoborderid As Long = dgVoucherView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim StoreReceiptVoucherMstID As Long = dgVoucherView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?StoreReceiptVoucherMstID=" & StoreReceiptVoucherMstID & "")

                Case "PDF"
                    Dim StoreReceiptVoucherMstID As Long = dgVoucherView.Items(e.Item.ItemIndex).Cells(0).Text

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim FileName As String

                    If Userid = 17 Then

                        Report.Load(Server.MapPath("~/Reports/StoreReceipReportForStore.rpt"))
                        FileName = "STORE RECEIVED SHEET"
                    Else
                        Report.Load(Server.MapPath("~/Reports/StoreReceipReport.rpt"))
                        FileName = "FABRIC RECEIVED SHEET"

                    End If



                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()


                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, StoreReceiptVoucherMstID)
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

            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class


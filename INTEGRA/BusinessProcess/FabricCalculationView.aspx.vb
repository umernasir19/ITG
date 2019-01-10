Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class FabricCalculationView
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim dtSummary As DataTable
    Dim objDataTable As DataTable
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                dtSummary = loadSummary()
                Session("dtSummary") = dtSummary
                BindSummaryGrid()

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PURCHASE ORDER")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindSummaryGrid()
        Try
            Dim dt As DataTable
            dt = Session("dtSummary")
            dgSummaryView.RecordCount = dt.Rows.Count
            dgSummaryView.DataSource = dt
            dgSummaryView.DataBind()
            dgSummaryView.Visible = True
        Catch ex As Exception

        End Try
    End Sub 
    Function loadSummary() As DataTable
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPOMaster.GetFabricCalculationData()
        Return objDataTable
    End Function
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChangedSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSummaryView.PageIndexChanged
        BindSummaryGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumnSummary(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgSummaryView.SortCommand
        BindSummaryGrid()
    End Sub 
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If userid = 241 Then
            Response.Redirect("FabricPurchaseOrderEntry.aspx")
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            Response.Redirect("FabricPurchaseOrderEntry.aspx")
        Else
            Response.Redirect("PurchaseOrderEntry.aspx")
        End If

    End Sub
    Protected Sub dgSummaryView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSummaryView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim POID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim FabriocOrder As Boolean = dgSummaryView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    If FabriocOrder = True Then
                        Response.Redirect("FabricPurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    Else
                        Response.Redirect("PurchaseOrderEntry.aspx?lPOID=" & POID & "")
                    End If

                Case "Remove"

                    Dim POID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objPOMaster.GetCheckExistingDataForPORecv(POID)
                    Dim dtt As DataTable = objPOMaster.GetCheckExistingDataForPOIssue(POID)

                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objPOMaster.DeletePOMAster(POID)
                        objPOMaster.DeletePODetail(POID)
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                        dtSummary = loadSummary()
                        Session("dtSummary") = dtSummary
                        BindSummaryGrid()
                    End If


                Case "PDF"
                    Dim FabCalMstID As String = dgSummaryView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IMSItemID As Long = dgSummaryView.Items(e.Item.ItemIndex).Cells(1).Text
 
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Report.Load(Server.MapPath("..\Reports/FabricCalculation.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Fabric Calculation"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, FabCalMstID)
                    Report.SetParameterValue(1, IMSItemID)
                    Report.SetParameterValue(2, FabCalMstID)
                    Report.SetParameterValue(3, IMSItemID)
                    Report.SetParameterValue(4, FabCalMstID)
                    Report.SetParameterValue(5, IMSItemID)

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




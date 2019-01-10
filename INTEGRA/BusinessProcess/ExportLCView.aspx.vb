Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ExportLCView
    Inherits System.Web.UI.Page
    Dim ObjLCExportMst As New LCExportMst
    Dim ObjDPIMst As New DPIMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Session("objMasterDataView") = Nothing
            Session("DtSummarytable") = Nothing
            ' objDataView = LoadData()
            objDataView = LoadMasterData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Function LoadMasterData() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        dtSummaryViewData = ObjDPIMst.GetViewForLCView()
        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("LCExportMstID", GetType(Long))
        DtSummarytable.Columns.Add("PIID", GetType(Long))
        DtSummarytable.Columns.Add("LCNo", GetType(String))
        DtSummarytable.Columns.Add("SeasonName", GetType(String))
        DtSummarytable.Columns.Add("SRNO", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("salescontract", GetType(String))
   If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim LCExportMstID As Long = dtSummaryViewData.Rows(i)("LCExportMstID")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("SRNO")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("LCExportMstID='" & LCExportMstID & "'")
                    If results.Length <> 1 Then
                        dtSum = ObjDPIMst.ViewMasterLCViewPage(LCExportMstID)
                        dtSumstyle = ObjDPIMst.ViewMasterStyleLCViewPage(LCExportMstID)
                        Dim Str As String = ""
                        Dim StrStyle As String = ""
                        Dim Style As String = ""
                        For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                            Style = dtSumstyle.Rows(F)("SRNO") + ","
                            StrStyle = StrStyle + Style
                        Next
                        dr("LCExportMstID") = dtSum.Rows(0)("LCExportMstID")
                        dr("PIID") = dtSum.Rows(0)("PIID")
                        dr("LCNo") = dtSum.Rows(0)("LCNo")
                        dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                        dr("SRNO") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("SalesContract") = dtSum.Rows(0)("SalesContractNO")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                       DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = ObjDPIMst.ViewMasterLCViewPage(LCExportMstID)
                    dtSumstyle = ObjDPIMst.ViewMasterStyleLCViewPage(LCExportMstID)
                    Dim Str As String = ""
                    Dim StrStyle As String = ""
                    Dim ReturnQty As Decimal = 0
                    Dim StyleID As String = ""
                    Dim Style As String = ""

                    For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                        Style = dtSumstyle.Rows(F)("SRNO") + ","
                        StrStyle = StrStyle + Style
                    Next
                    dr("LCExportMstID") = dtSum.Rows(0)("LCExportMstID")
                    dr("PIID") = dtSum.Rows(0)("PIID")
                    dr("LCNo") = dtSum.Rows(0)("LCNo")
                    dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                    dr("SRNO") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("SalesContract") = dtSum.Rows(0)("SalesContractNO")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        'End If
        '------End
        objMasterDataView = New DataView(Session("DtSummarytable"))
        '-------
        Return objMasterDataView
    End Function

    Private Sub BindGrid()
        Try

            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgView.DataSource = objDataView
            dgView.DataBind()

            'Dim x As Integer
            'For x = 0 To dgView.Items.Count - 1

            '    Dim item As GridDataItem = DirectCast(dgView.MasterTableView.Items(x), GridDataItem)


            '    Dim PISendDate As String = item("PISendDatee").Text
            '    Dim LCRecvDate As String = item("LCRecvDatee").Text
            '    Dim LCShipDate As String = item("LCShipDatee").Text
            '    Dim LCAMDDate As String = item("LCAMDDatee").Text
            '    Dim LCAmount As String = item("LCAmount").Text


            '    If PISendDate = "01/01/1900" Then
            '        item("PISendDatee").Text = ""
            '    End If
            '    If LCRecvDate = "01/01/1900" Then
            '        item("LCRecvDatee").Text = ""
            '    End If
            '    If LCShipDate = "01/01/1900" Then
            '        item("LCShipDatee").Text = ""
            '    End If
            '    If LCAMDDate = "01/01/1900" Then
            '        item("LCAMDDatee").Text = ""
            '    End If
            '    If LCAmount = "0" Then
            '        item("LCAmount").Text = ""

            '    End If

            'Next
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = ObjLCExportMst.GetViewNew()
        objDataTable = ObjLCExportMst.GetViewNewNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgView_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgView_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("ExportLCEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                'Case Is = "EDIT"
                '    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                '    Dim WashMstID As String = item("WashMstID").Text
                '    Response.Redirect("WashIssueAdd.aspx?WashMstID=" & WashMstID & "")
                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    ' Dim DPCourierMstId As Integer = dgCourier.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lLCExportMstID As String = item("LCExportMstID").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    ' Report.Load(Server.MapPath("..\Reports/POReport.rpt"))
                    Report.Load(Server.MapPath("..\Reports/WashReceive.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Wash Receive Report"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lLCExportMstID)

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
    Protected Sub dgView_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgView.NeedDataSource
        dgView.DataSource = ObjLCExportMst.GetViewNew()
    End Sub
    Protected Sub dgView_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgView.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
 

End Class
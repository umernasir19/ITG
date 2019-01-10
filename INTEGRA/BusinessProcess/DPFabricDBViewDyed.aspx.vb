Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPFabricDBViewDyed
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim lFabricIssueID, userid As Long
    Dim objDataView As DataView
    Dim DalNo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        userid = Session("UserId")
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()

            If userid = 245 Then
                btnAddSampling.Visible = False
                dgFabricDB.MasterTableView.GetColumn("View").Display = False
                dgFabricDB.MasterTableView.GetColumn("PDF").Display = False
                dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
            ElseIf userid = 241 Then
                btnAddSampling.Visible = False
                dgFabricDB.MasterTableView.GetColumn("View").Display = False
                dgFabricDB.MasterTableView.GetColumn("PDF").Display = False
                dgFabricDB.MasterTableView.GetColumn("DeleteColumn").Display = False
            Else
                btnAddSampling.Visible = True
            End If

          

        End If
    End Sub
  Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgFabricDB.DataSource = objDataView
            dgFabricDB.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objDPFabricDbMst.GetAllDataNewForDyed()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Response.Redirect("DAFabricDBEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgFabricDB_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgFabricDB.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "EDIT"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricDBMstId As String = item("FabricDBMstId").Text
                    Response.Redirect("DAFabricDBEntry.aspx?lECPSamplingID=" & lFabricDBMstId & "")


                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    ' Dim DPCourierMstId As Integer = dgCourier.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim llFabricDBMstId As String = item("FabricDBMstId").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/FabricReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Fabric Report"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, llFabricDBMstId)
                    'Report.SetParameterValue(1, EnquiriesSystemID)
                    'Report.SetParameterValue(2, EnquiriesSystemID)
                    'Report.SetParameterValue(3, EnquiriesSystemID)
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


                Case Is = "Delete"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricDBMstId As String = item("FabricDBMstId").Text
                    Dim Checkdt As DataTable = objDPFabricDbMst.GetDalNoFromFDB(lFabricDBMstId)
                    If Checkdt.Rows.Count > 0 Then
                        DalNo = Checkdt.Rows(0)("DalNo")
                    End If
                    Dim dt1 As DataTable = objDPFabricDbMst.CheckExistingDataForSampleIssueFromFDB(lFabricDBMstId)
                    Dim dt2 As DataTable = objDPFabricDbMst.CheckExistingDataForSampleReceiveFromFDB(lFabricDBMstId)
                    Dim dt3 As DataTable = objDPFabricDbMst.CheckExistingDataForPOMstFromFDB(lFabricDBMstId)
                    Dim dt4 As DataTable = objDPFabricDbMst.CheckExistingDataForPOReceiveMstFromFDB(lFabricDBMstId)
                    Dim dt5 As DataTable = objDPFabricDbMst.CheckExistingDataForPOReceiveDtlFromFDB(lFabricDBMstId)
                    Dim dt6 As DataTable = objDPFabricDbMst.CheckExistingDataForPOIssueDtlFromFDB(lFabricDBMstId)
                    Dim dt7 As DataTable = objDPFabricDbMst.CheckExistingDataForWashDtlFromFDB(lFabricDBMstId)
                    Dim dt8 As DataTable = objDPFabricDbMst.CheckExistingDataForWashRecvDtlFromFDB(lFabricDBMstId)
                    Dim dt9 As DataTable = objDPFabricDbMst.CheckExistingDataForDPRNDFromFDB(lFabricDBMstId)
                    Dim dt10 As DataTable = objDPFabricDbMst.CheckExistingDataForimsitemFromFDB(lFabricDBMstId)
                    Dim dt11 As DataTable = objDPFabricDbMst.CheckExistingDataForConsumptionFromFDB(DalNo)

                    If dt1.Rows.Count > 0 Or dt2.Rows.Count > 0 Or dt3.Rows.Count > 0 Or dt4.Rows.Count > 0 Or dt5.Rows.Count > 0 Or dt6.Rows.Count > 0 Or dt7.Rows.Count > 0 Or dt8.Rows.Count > 0 Or dt9.Rows.Count > 0 Or dt10.Rows.Count > 0 Or dt11.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objDPFabricDbMst.DeletedDPFabricDbMst(lFabricDBMstId)
                        objDPFabricDbMst.DeletedDPFabricDbDtl(lFabricDBMstId)
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgFabricDB_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgFabricDB.NeedDataSource

        dgFabricDB.DataSource = objDPFabricDbMst.GetAllDataNewForDyed()
    End Sub
    Protected Sub dgFabricDB_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgFabricDB.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgFabricDB_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgFabricDB.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgFabricDB_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgFabricDB.SortCommand
        BindGrid()
    End Sub

End Class
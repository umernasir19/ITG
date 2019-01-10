Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPFabricIssueView
    Inherits System.Web.UI.Page
    Dim objDPPOMst As New DPPOMst
    Dim objDataView As DataView
    Dim objDPFabricIssue As New DPFabricIssue
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
           
            BindGrid()
        End If
    End Sub
    Sub BindGrid()

        Dim dt As New DataTable
        dt = objDPFabricIssue.GetBindFabricGrid
        dgFabricIssue.DataSource = dt
        dgFabricIssue.DataBind()
    End Sub
   
    Protected Sub btnAddFabricIssue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddFabricIssue.Click
        Try

            Response.Redirect("DPFabricIssueAdd.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgFabricIssue_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgFabricIssue.ItemCommand
        Try
            Select Case e.CommandName
            


                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    ' Dim DPCourierMstId As Integer = dgCourier.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lFabricIssueID As String = item("FabricIssueID").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/SampleIssueReport.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "SampleIssueReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lFabricIssueID)
                 
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
                    Dim lFabricIssueID As String = item("FabricIssueID").Text

                    Dim dt As DataTable = objDPPOMst.CheckExistingDataForSampleReceiveForFabricReceive(lFabricIssueID)
                    If dt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Use For Sample Receive")
                        BindGrid()
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        objDPPOMst.DeletedFabricIssue(lFabricIssueID)
                        objDPPOMst.DeletedFabricIssueWorkerDetail(lFabricIssueID)
                        BindGrid()

                    End If

                   







            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Data.DataTable
Public Class MandEentryView
    Inherits System.Web.UI.Page
    Dim objMAEMst As New MAEMst
    Dim ObjTblRND As New TblDPRND
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                BindPackingListView()
            Catch ex As Exception
            End Try
            PageHeader("Fixed Assets / Machine & Equipments / Declaration View")
        End If
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btnCreatePackingList.Enabled = True
            Else
                btnCreatePackingList.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgMandEentry.Items.Count - 1
                    Dim lnkEditt As HyperLink = CType(dgMandEentry.Items(x).FindControl("lnkEdit"), HyperLink)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgMandEentry.Items.Count - 1
                    Dim lnkEditt As HyperLink = CType(dgMandEentry.Items(x).FindControl("lnkEdit"), HyperLink)
                    lnkEditt.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindPackingListView()
        Try
            Dim DT As DataTable = objMAEMst.BindMAEPageView()
            dgMandEentry.DataSource = DT
            dgMandEentry.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCreatePackingList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreatePackingList.Click
        Response.Redirect("MandEentry.aspx")
    End Sub
    Protected Sub dgMandEentry_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgMandEentry.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim MAEID As String = dgMandEentry.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("MandEentry.aspx?MAEID=" & MAEID & "")

                Case "PDF"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim TodayCuttingMstid As Long = dgMandEentry.Items(e.Item.ItemIndex).Cells(0).Text

                    Report.Load(Server.MapPath("..\Reports/CuttingReport.rpt"))

                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Cutting_Report"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, TodayCuttingMstid)
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
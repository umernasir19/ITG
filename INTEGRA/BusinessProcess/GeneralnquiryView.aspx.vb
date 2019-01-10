Imports System.Data
Imports System.Xml
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class GeneralnquiryView
    Inherits System.Web.UI.Page
    Dim ObjGeneralInquiry As New GeneralInquiryMst

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataENView") = objDataView
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataENView")
            If objDataView.Count > 0 Then
                dgView.Visible = True
                strSortExpression = dgView.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgView.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgView.RecordCount = objDataView.Count
                dgView.DataSource = objDataView
                dgView.DataBind()
            Else
                dgView.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objEnquiriesSystemAddclass.GetAll()
        objDataTable = ObjGeneralInquiry.GetAllForUser()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        ' BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    Dim GeneralInquiryMstID As Integer = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    'End Delete
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/EnquiresSystemRpt.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Enquiry System_"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, GeneralInquiryMstID)
                    Report.SetParameterValue(1, GeneralInquiryMstID)
                    Report.SetParameterValue(2, GeneralInquiryMstID)
                    Report.SetParameterValue(3, GeneralInquiryMstID)
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

    Protected Sub btnBlankReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBlankReport.Click
        Response.Redirect("GeneralEnquiryEntry.aspx")
    End Sub
End Class
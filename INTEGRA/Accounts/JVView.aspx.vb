Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports Integra.EuroCentra
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class JVView
    Inherits System.Web.UI.Page
    Dim objtblJVMst As New tblJVMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim YearFirst, YearSecond As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        YearFirst = Session("YearFirst")
        YearSecond = Session("YearSecond")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("JOURNAL VOUCHER")
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
        ' objDataTable = objtblJVMst.GetJournalVoucherforView
        If YearFirst <> "" And YearSecond <> "" Then
            objDataTable = objtblJVMst.GetJournalVoucherforViewNew(YearFirst, YearSecond)
        End If

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
        'Response.Redirect("JVEntry.aspx")
        Response.Redirect("JVEntry.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    Dim tblJVMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Successfully Deleted.")
                    objtblJVMst.DeletetblJVMst(tblJVMstID)
                    objtblJVMst.DeletetblJVDtl(tblJVMstID)
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Case "Edit"
                    Dim tblJVMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JVEntry.aspx?ltblJVMstID=" & tblJVMstID & "")
                Case "PDF"
                    Dim tblJVMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Report.Load(Server.MapPath("~/Reports/JournalVoucherNM.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, tblJVMstID)

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "VoucherReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

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

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtShowMe.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
            ElseIf txtShowMe.Text <> "" Then
                Dim objDataView As DataView
                objDataView = LoadData(txtShowMe.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher No. Not Exist")
                End If
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadData(ByVal VoucherNo As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objtblJVMst.GetVoucherNoAllInfo(VoucherNo)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            Dim objDataView As DataView
            If txtShowMe.Text = "" Then
                'DirectCast(Me.Page.Master, MasterPageNew).ShowMessgae("Please Enter Valid Voucher No.")
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            ElseIf txtShowMe.Text <> "" Then
                objDataView = LoadData(txtShowMe.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher No. Not Exist")
                End If
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class



Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class ContraVoucherView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjContraVoucherMst As New ContraVoucherMst
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
    End Sub
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
        If YearFirst <> "" And YearSecond <> "" Then
            objDataTable = ObjContraVoucherMst.GetViewNew(YearFirst, YearSecond)
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
        Response.Redirect("ContraVoucherAdd.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim ContraVoucherMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ContraVoucherAdd.aspx?lContraVoucherMstID=" & ContraVoucherMstID & "")
                Case "PDF"
                    'Dim VoucherType As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim ContraVoucherMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String


                    Report.Load(Server.MapPath("..\Reports/ContraVoucher.rpt"))

                    FileName = "ContraVoucher"

                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, ContraVoucherMstID)


                    Dim FileOption As New DiskFileDestinationOptions
                    FileOption.DiskFileName = sTempFileName
                    Options = Report.ExportOptions
                    Options.ExportDestinationType = ExportDestinationType.DiskFile
                    Options.ExportFormatType = ExportFormatType.PortableDocFormat
                    Options.DestinationOptions = FileOption
                    Options.ExportDestinationOptions = FileOption
                    Report.SetDatabaseLogon("sa", "pwd")
                    Report.Export()


                    Dim path As String = (Server.MapPath("~/TempPDF") + "/" + FileName + ".pdf")
                    Dim fs As FileStream = New FileStream(path, FileMode.Open)
                    Dim fileSize As Long
                    fileSize = fs.Length
                    Dim Buffer() As Byte = New Byte((CType(fileSize, Integer)) - 1) {}
                    fs.Read(Buffer, 0, CType(fs.Length, Integer))
                    fs.Close()
                    Response.ContentType = "application/pdf"
                    Response.AddHeader("content-disposition", ("inline; filename=" + FileName))
                    Response.BinaryWrite(Buffer)
                    Response.Flush()
                    Response.End()

                   
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class

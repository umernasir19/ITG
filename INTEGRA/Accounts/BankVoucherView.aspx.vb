Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class BankVoucherView
    Inherits System.Web.UI.Page
    Dim objtblBankMst As New tblBankMst
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
        PageHeader("BANK VOUCHER")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim a As Integer = 0
        Dim dt As New DataTable
        dt = objDataView.ToTable
        For a = 0 To dgView.Items.Count - 1
            Dim VoucherType As String = ""
            VoucherType = dgView.Items(a).Cells(9).Text
            If VoucherType = "P" Then
                dgView.Items(a).Cells(4).Text = dt.Rows(a)("TotalAmount").ToString
            ElseIf VoucherType = "R" Then
                dgView.Items(a).Cells(5).Text = dt.Rows(a)("TotalAmount").ToString
            Else
                dgView.Items(a).Cells(9).Text = 0
            End If
        Next
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If YearFirst <> "" And YearSecond <> "" Then
            objDataTable = objtblBankMst.GetBankVoucherforViewNew(YearFirst, YearSecond)
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("BankVoucherEntry.aspx?ltblBankMstID=" & tblBankMstID & "")
                Case "Remove"
                    Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    objtblBankMst.DeleteBrandDatabase(tblBankMstID)
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Case "PDF"
                    Dim VoucherType As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    If VoucherType = "R" Then
                        Report.Load(Server.MapPath("..\Reports/VoucherReceipt.rpt"))
                        FileName = "Voucher"
                    Else
                        Report.Load(Server.MapPath("..\Reports/VoucherPayment.rpt"))
                        FileName = "Voucher"
                    End If
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, tblBankMstID)
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
        objDataTable = objtblBankMst.GetVoucherNoAllInfo(VoucherNo)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            Dim objDataView As DataView
            If txtShowMe.Text = "" Then
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
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            Dim A As String = "BankVoucher"
            Response.Redirect("BankVoucherEntry.aspx?Voucher=" & A & "")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAddCash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddCash.Click
        Try
            Dim B As String = "CashVoucher"
            Response.Redirect("CashVoucherView.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class


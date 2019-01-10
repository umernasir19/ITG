Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Public Class CashVoucherView
    Inherits System.Web.UI.Page
    Dim objtblCashMst As New tblCashMst
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
        PageHeader("CASH VOUCHER")
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
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If YearFirst <> "" And YearSecond <> "" Then
            objDataTable = objtblCashMst.GetBankVoucherforViewNew(YearFirst, YearSecond)
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
        Response.Redirect("CashVoucherEntry.aspx")
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    ' Dim lblCreatedByID As Label = CType(dgView.Items(e.Item.ItemIndex).FindControl("lblCreatedByID"), Label)
                    'If CLng(Session("Userid")) = Convert.ToInt32(lblCreatedByID.Text) Then
                    Dim tblCashMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("CashVoucherEntry.aspx?ltblCashMstID=" & tblCashMstID & "")
                    ' Else
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Edit Permitted By Only Created Person")
                    ' End If
                Case "Remove"
                    Dim tblCashMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    'objtblCashMst.DeleteBrandDatabase(tblCashMstID)
                    objtblCashMst.DeletetblBankMst(tblCashMstID)
                    objtblCashMst.DeletetblBankDtl(tblCashMstID)
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Successfully Deleted")
                    Dim objDataView As DataView
                    objDataView = LoadData()
                    Session("objDataView") = objDataView
                    BindGrid()
                Case "PDF"
                    Dim VoucherType As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim tblCashMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String
                    If VoucherType = "R" Then
                        Report.Load(Server.MapPath("..\Reports/CashReceiptVoucherNew.rpt"))
                        FileName = "CashReceipt"

                    Else
                        'Report.Load(Server.MapPath("..\Reports/CashPayment.rpt"))
                        Report.Load(Server.MapPath("..\Reports/CashVoucherPaymentNew.rpt"))

                        FileName = "CashPayment"
                    End If

                    'Report.Load(Server.MapPath("..\Reports/Voucher.rpt"))
                    'FileName = "Bank Voucher"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, tblCashMstID)


                    Dim FileOption As New DiskFileDestinationOptions
                    FileOption.DiskFileName = sTempFileName
                    Options = Report.ExportOptions
                    Options.ExportDestinationType = ExportDestinationType.DiskFile
                    Options.ExportFormatType = ExportFormatType.PortableDocFormat
                    Options.DestinationOptions = FileOption
                    Options.ExportDestinationOptions = FileOption
                    Report.SetDatabaseLogon("sa", "pwd")
                    Report.Export()

                    'If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                    '    Dim strFileSize As String = ""
                    '    Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                    '    Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                    '    Dim fi As IO.FileInfo
                    '    For Each fi In aryFi
                    '        Response.ClearHeaders()
                    '        Response.ClearContent()
                    '        Response.ContentType = "application/octet-stream"
                    '        Response.Charset = "UTF-8"
                    '        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    '        Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    '        Response.End()
                    '    Next
                    '    Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                    '    Response.End()
                    'End If

                    ''' '-------Code for PDf open same Tab not download--------Start 
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
        objDataTable = objtblCashMst.GetVoucherNoAllInfo(VoucherNo)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            Dim objDataView As DataView
            If txtShowMe.Text = "" Then
                'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
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


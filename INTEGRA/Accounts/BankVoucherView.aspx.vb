Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.classes

Public Class BankVoucherView
    Inherits System.Web.UI.Page



    Dim objtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim DeletedUID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DeletedUID = CLng(Session("Userid"))
        Dim objDataView As DataView
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
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try

            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgView.RecordCount = objDataView.Count
            dgView.DataSource = objDataView
            dgView.DataBind()

            Dim dthd As DataTable
            dthd = objtblBankMst.GetBankVoucherforViewForHd()
            dgHeader.DataSource = dthd
            dgHeader.DataBind()

            Dim a As Integer = 0
            Dim BackDate As Boolean
            Dim dt As New DataTable
            dt = objDataView.ToTable
            For a = 0 To dgView.Items.Count - 1
                Dim VoucherType As String = ""
                BackDate = dgView.Items(a).Cells(11).Text
                VoucherType = dgView.Items(a).Cells(9).Text
                If VoucherType = "P" Then
                    dgView.Items(a).Cells(4).Text = dt.Rows(a)("TotalAmount").ToString
                ElseIf VoucherType = "R" Then
                    dgView.Items(a).Cells(5).Text = dt.Rows(a)("TotalAmount").ToString
                Else
                    dgView.Items(a).Cells(9).Text = 0
                End If

                Dim LockBit As Boolean
                Dim lnkEdit As ImageButton = DirectCast(dgView.Items(a).FindControl("lnkEdit"), ImageButton)
                Dim lnkRemove As ImageButton = DirectCast(dgView.Items(a).FindControl("lnkRemove"), ImageButton)
                LockBit = dgView.Items(a).Cells(10).Text
                If LockBit = True Then
                    dgView.Items(a).Cells(0).BackColor = Drawing.Color.Red
                    dgView.Items(a).Cells(1).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(2).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(3).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(4).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(5).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(6).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(7).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(8).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(9).BackColor = Drawing.Color.Red
                    'dgView.Items(a).Cells(10).BackColor = Drawing.Color.Red

                    lnkEdit.Visible = False
                    lnkRemove.Visible = False
                Else
                    'dgView.Items(a).Cells(0).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(1).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(2).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(3).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(4).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(5).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(6).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(7).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(8).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(9).BackColor = Drawing.Color.White
                    'dgView.Items(a).Cells(10).BackColor = Drawing.Color.White
                    If BackDate = True Then
                        lnkEdit.Visible = False
                        lnkRemove.Visible = False
                    Else
                        lnkEdit.Visible = True
                        lnkRemove.Visible = True
                    End If

                End If


            Next

        Catch ex As Exception

        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objtblBankMst.GetBankVoucherforView
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

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim A As String = "BankVoucher"
                    ' Dim lblCreatedByID As Label = CType(dgView.Items(e.Item.ItemIndex).FindControl("lblCreatedByID"), Label)
                    'If CLng(Session("Userid")) = Convert.ToInt32(lblCreatedByID.Text) Then
                    Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("BankVoucherentry.aspx?ltblBankMstID=" & tblBankMstID & " &Voucher=" & A & "")
                    ' Else
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Edit Permitted By Only Created Person")
                    ' End If
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
                    Dim VoucherNo As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String
                    If VoucherType = "R" Then

                        Report.Load(Server.MapPath("..\Reports/VoucherReceipt.rpt"))
                        FileName = VoucherNo '"Voucher"

                    Else

                        Report.Load(Server.MapPath("..\Reports/VoucherPayment.rpt"))

                        FileName = VoucherNo
                    End If

                    'Report.Load(Server.MapPath("..\Reports/Voucher.rpt"))
                    'FileName = "Bank Voucher"
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
                    '''' '-------Code for PDf open same Tab not download--------Start 
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
                    ''If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                    ''    Dim strFileSize As String = ""
                    ''    Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                    ''    Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                    ''    Dim fi As IO.FileInfo
                    ''    For Each fi In aryFi
                    ''        Response.ClearHeaders()
                    ''        Response.ClearContent()
                    ''        Response.ContentType = "application/octet-stream"
                    ''        Response.Charset = "UTF-8"
                    ''        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    ''        Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    ''        Response.End()
                    ''    Next
                    ''    Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                    ''    Response.End()
                    ''End If
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
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            Dim A As String = "BankVoucher"
            Response.Redirect("BankVoucherentry.aspx?Voucher=" & A & "")
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub cmdAddCash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddCash.Click
        Try
            Dim B As String = "CashVoucher"
            '  Response.Redirect("BankVoucherentryForNaeem.aspx?Voucher=" & B & "")
            Response.Redirect("CashVoucherView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtdrcr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdrcr.TextChanged
        Try
            Dim objDataView2 As DataView
            If txtdrcr.Text = "" Then
                'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Voucher No.")
                objDataView2 = LoadData()
                Session("objDataView") = objDataView2
                BindGrid()

            ElseIf txtdrcr.Text <> "" Then
                objDataView2 = LoadDataDrCr(txtdrcr.Text)
                If objDataView2.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher No. Not Exist")
                End If
                Session("objDataView") = objDataView2
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadDataDrCr(ByVal VoucherNo As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objtblBankMst.GetVoucherNoAllInfoForDrCr(VoucherNo)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
End Class
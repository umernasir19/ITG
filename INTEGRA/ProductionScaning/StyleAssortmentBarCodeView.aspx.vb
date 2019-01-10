Imports System.Data
Imports Integra.classes
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Drawing.Color
Imports Integra.EuroCentra
Public Class StyleAssortmentBarCodeView
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim RoleID As Long
    Dim UserId As Long
    Dim objDataView As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        RoleID = Session("RoleId")
        If Not Page.IsPostBack Then
            Try
                BinSeason()
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Style Assortment View")
    End Sub
    Sub BinSeason()
        Dim dt As DataTable
        dt = objFabricationMaster.GetSeasonsForJobOrderVieeSearchingBarCodeView()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, "All")
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        If cmbSeason.SelectedItem.Text = "All" Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        Else
            objDataView = LoadDataForSearching()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ViewForBrandStyleAssormentViewForBarCodeView(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.ViewForBuyerStyleAssormentViewForBarCode(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.ViewForStyleStyleAssormentViewForBarCode(txtSearch.Text)
            Dim dt4 As DataTable = objStyleAssortmentMaster.ViewForSrNoStyleAssormentViewForBarCode(txtSearch.Text)
            Dim dt5 As DataTable = objStyleAssortmentMaster.ViewForSeasonStyleAssormentViewForBarCode(txtSearch.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            ElseIf dt5.Rows.Count > 0 Then
                dgView.DataSource = dt5
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            Else
                Dim dt6 As DataTable = objStyleAssortmentMaster.View2NewNew
                dgView.DataSource = dt6
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
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
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
            Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
            Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
            Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
            Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
            Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
            If StyleAssortmentMasterID = 0 Then
                lnkOk.Visible = False
                lnkEdit.Visible = True
                lnkOk.Enabled = False
                lnkEdit.Enabled = True
            Else
                lnkOk.Visible = True
                lnkEdit.Visible = False
                lnkOk.Enabled = True
                lnkEdit.Enabled = True
            End If
            Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
            If dtChk.Rows.Count > 0 Then
                lnkCreateFab.Visible = False
                lnkEditFab.Visible = True
                lnkOk.Enabled = False
                lnkEdit.Enabled = True
            Else
                lnkCreateFab.Visible = True
                lnkEditFab.Visible = False
                lnkOk.Enabled = True
                lnkEdit.Enabled = True
            End If
            If DownloadBit = "True" Then
                lnkBarcode.BackColor = Red
                lnkBarcode.BorderColor = Green
                lnkBarcode.BorderStyle = BorderStyle.Dashed
                lnkBarcode.BorderWidth = 2
            Else
            End If
            Dim From As Long = dgView.Items.Item(x).Cells(13).Text
            Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
            If From = 0 Then
                dgView.Items.Item(x).Cells(13).Text = ""
            End If
            If Too = 0 Then
                dgView.Items.Item(x).Cells(14).Text = ""
            End If
        Next
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.View2NewNewNew
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Function LoadDataForSearching() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.View2NewNewNewForSearching(cmbSeason.SelectedValue)
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
                Case "StyleAssortmanr"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Styles As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("..\BusinessProcess/StyleAssortmentEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "Edit"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Styles As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("..\BusinessProcess/StyleAssortmentEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "Barcode"
                    objStyleAssortmentMaster.UpdateDwnloadbit(dgView.Items(e.Item.ItemIndex).Cells(19).Text)
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\Reports/BarcodereportNew.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StyleAssortmentMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim StyleAssortmentdetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(19).Text
                    Dim JobOrderId As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim Size As String = dgView.Items(e.Item.ItemIndex).Cells(12).Text
                    Dim FileName As String = "BarCode"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, StyleAssortmentMasterID)
                    Report.SetParameterValue(1, StyleAssortmentdetailID)
                    Report.SetParameterValue(2, JobOrderId)
                    Report.SetParameterValue(3, Size)
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
                Case "ExtraBarcode"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\Reports/BarcodereportExtra.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim StyleAssortmentMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim StyleAssortmentdetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(19).Text
                    Dim JobOrderId As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim Size As String = dgView.Items(e.Item.ItemIndex).Cells(12).Text
                    Dim FileName As String = "BarCode"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, StyleAssortmentMasterID)
                    Report.SetParameterValue(1, StyleAssortmentdetailID)
                    Report.SetParameterValue(2, JobOrderId)
                    Report.SetParameterValue(3, Size)
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
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(ex.ToString())
        End Try
    End Sub
    Protected Sub txtColor_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtColor.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ColorViseBarCodeView(txtColor.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim DownloadBit As String = dgView.Items.Item(x).Cells(20).Text
                    Dim lnkBarcode As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkBarcode"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    Dim dtChk As DataTable = objStyleAssortmentMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                        lnkOk.Enabled = False
                        lnkEdit.Enabled = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                        lnkOk.Enabled = True
                        lnkEdit.Enabled = True
                    End If
                    If DownloadBit = "True" Then
                        lnkBarcode.BackColor = Red
                        lnkBarcode.BorderColor = Green
                        lnkBarcode.BorderStyle = BorderStyle.Dashed
                        lnkBarcode.BorderWidth = 2
                    Else
                    End If
                    Dim From As Long = dgView.Items.Item(x).Cells(13).Text
                    Dim Too As Long = dgView.Items.Item(x).Cells(14).Text
                    If From = 0 Then
                        dgView.Items.Item(x).Cells(13).Text = ""
                    End If
                    If Too = 0 Then
                        dgView.Items.Item(x).Cells(14).Text = ""
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

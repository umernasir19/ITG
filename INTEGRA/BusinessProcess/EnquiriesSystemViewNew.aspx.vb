Imports System.Data
Imports System.Xml
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class EnquiriesSystemViewNew
    Inherits System.Web.UI.Page
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Dim objVendor As New Vender
    Dim UserID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        UserID = CLng(Session("UserID"))
        If Not Page.IsPostBack Then
            Try
                BindSupplier()
                BindSeason()
                objDataView = LoadData()
                Session("objDataENView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Enquiries System")
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.getSupplierFoRENQ
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                .Items.Insert(0, New ListItem("All", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystemAddclass.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataENView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.Visible = True
                strSortExpression = dgPurchaseOrder.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgPurchaseOrder.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgPurchaseOrder.RecordCount = objDataView.Count
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objEnquiriesSystemAddclass.GetAll()
      

            objDataTable = objEnquiriesSystemAddclass.GetAllForUser(UserID, cmbSeason.SelectedValue, cmbSupplier.SelectedValue)


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
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("EnquiresSystemAdd.aspx")
    End Sub
    Protected Sub txtsearchStyle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtsearchStyle.TextChanged
        Try
            Dim objDataView As DataView
            If txtsearchStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                objDataView = LoadData()
                Session("objDataENView") = objDataView
                BindGrid()
            ElseIf txtsearchStyle.Text <> "" Then

                objDataView = LoadData(txtsearchStyle.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No. Not Exist")
                End If
                Session("objDataENView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function LoadData(ByVal SttyleNo As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objEnquiriesSystemAddclass.GetOnlyStyleSearch(SttyleNo, cmbSeason.SelectedValue, cmbSupplier.SelectedValue)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "PDF"
                    ''Delete All PDF files from Folder
                    Dim EnquiriesSystemID As Integer = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
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
                    Report.SetParameterValue(0, EnquiriesSystemID)
                    Report.SetParameterValue(1, EnquiriesSystemID)
                    Report.SetParameterValue(2, EnquiriesSystemID)
                    Report.SetParameterValue(3, EnquiriesSystemID)
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

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim objDataView As DataView
            If txtsearchStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                objDataView = LoadData()
                Session("objDataENView") = objDataView
                BindGrid()
            ElseIf txtsearchStyle.Text <> "" Then

                objDataView = LoadData(txtsearchStyle.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No. Not Exist")
                End If
                Session("objDataENView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            Dim objDataView As DataView
            If txtsearchStyle.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                objDataView = LoadData()
                Session("objDataENView") = objDataView
                BindGrid()
            ElseIf txtsearchStyle.Text <> "" Then

                objDataView = LoadData(txtsearchStyle.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style No. Not Exist")
                End If
                Session("objDataENView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBlankReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBlankReport.Click
        Try

            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/EnquiryReportBlank.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Enquiry System_Blank Report"
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



        Catch ex As Exception

        End Try
    End Sub
End Class
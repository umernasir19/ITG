Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ClaimView
    Inherits System.Web.UI.Page
    Dim objClaim As New POClaim
    Dim objClaimDetail As New POClaimDetail
    Dim lPOClaimID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            PageHeader("PO Claim View")
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
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
            dgPOClaimView.DataSource = objDataView
            dgPOClaimView.DataBind()

            Dim x As Integer
            Dim lblClaimReason As Label
            For x = 0 To dgPOClaimView.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPOClaimView.MasterTableView.Items(x), GridDataItem)
                lblClaimReason = CType(dgPOClaimView.Items(x).FindControl("lblClaimReason"), Label)
                Dim StrClaimReason() As String
                StrClaimReason = objDataView.Item(x)("ClaimReason").ToString().Split(" ")
                If StrClaimReason.Length > 3 Then
                    lblClaimReason.Text = StrClaimReason(0) + " " + StrClaimReason(1) + " " + StrClaimReason(2) + "..."
                    lblClaimReason.ToolTip = objDataView.Item(x)("ClaimReason").ToString()
                Else
                    lblClaimReason.Text = objDataView.Item(x)("ClaimReason").ToString()
                    lblClaimReason.ToolTip = objDataView.Item(x)("ClaimReason").ToString()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objClaim.GetClaimForView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Protected Sub dgPOClaimView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPOClaimView.ItemCommand
        Select Case e.CommandName
            Case Is = "PDF"
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim POClaimID As String = item("POClaimID").Text
                Dim ClaimNo As String = item("ClaimNo").Text

                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Report.Load(Server.MapPath("..\Reports/POClaim.rpt"))

                Dim FileName As String = "PO Claim-" + ClaimNo
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, POClaimID)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                Dim strFileSize As String = ""
                Dim ExistFIleName As String = "PO Claim-" + ClaimNo + ".pdf"
                Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                Dim fi As IO.FileInfo
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                    Response.End()
                Next
            Case Is = "EDIT"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOClaimID As String = item("POClaimID").Text
                Response.Redirect("Claim.aspx?lPOClaimID=" & lPOClaimID & "")
        End Select
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("Claim.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
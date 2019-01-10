Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LoanView
    Inherits System.Web.UI.Page
    Dim objLoanmaster As New LoanMaster
    Dim objLoanDetail As New LoanDetail
    Dim lHRID As Long
    Dim objUser As New EuroCentra.User
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Dim dtUser As DataTable = objUser.GetUSerInfoNew(CLng(Session("Userid")))
            lHRID = dtUser.Rows(0)("EmployeeId")
            PageHeader("Process For Loan")
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
            dgLoanView.DataSource = objDataView
            dgLoanView.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objLoanmaster.GetLoanForViewNew(lHRID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Protected Sub dgLoanView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgLoanView.ItemCommand
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            Select Case e.CommandName
                Case Is = "PDF"
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lLoanMasterID As String = item("LoanMasterID").Text
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Report.Load(Server.MapPath("..\Reports/LoanReport.rpt"))
                    Dim FileName As String = "Loan"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                    Report.SetParameterValue(0, lLoanMasterID)

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
                    Dim ExistFIleName As String = "Loan" + ".pdf"
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
                    Dim lLoanMasterID As String = item("LoanMasterID").Text
                    Response.Redirect("LoanRequest.aspx?lLoanMasterID=" & lLoanMasterID & "")
            End Select
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("LoanRequest.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
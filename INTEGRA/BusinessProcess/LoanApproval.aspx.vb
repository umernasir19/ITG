Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LoanApproval
    Inherits System.Web.UI.Page
    Dim objLoanmaster As New LoanMaster
    Dim objLoanDetail As New LoanDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            PageHeader("Process For Loan")
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        Else

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim x As Integer
        Dim lnApproved As LinkButton
        Dim dt As DataTable
        Try
            If RadioButtonList1.SelectedItem.Text = "Not Approved" Then
                dt = objLoanmaster.GetNotApprovedLoanforView()
             
                If dt.Rows.Count > 0 Then
                   
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    objDataView = Session("objDataView")
                    dgLoanView.DataSource = objDataView
                    dgLoanView.Columns(8).Visible = True
                    dgLoanView.Columns(7).Visible = False
                    dgLoanView.DataBind()
                    dgLoanView.Visible = True
                    For x = 0 To dt.Rows.Count - 1
                        lnApproved = CType(dgLoanView.Items(x).FindControl("lnApproved"), LinkButton)
                        lnApproved.Text = dt.Rows(x)("Statuss")
                    Next

                Else
                    dgLoanView.Visible = False
                End If
            Else
                dt = objLoanmaster.GetApprovedLoanforView()
               
                If dt.Rows.Count > 0 Then
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    objDataView = Session("objDataView")
                    dgLoanView.DataSource = objDataView
                    dgLoanView.Columns(8).Visible = False
                    dgLoanView.Columns(7).Visible = True
                    dgLoanView.DataBind()
                    dgLoanView.Visible = True
                   
                Else
                    dgLoanView.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objLoanmaster.GetNotApprovedLoanforView()
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

                Case Is = "Approved"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim lLoanMasterID As String = item("LoanMasterID").Text
                    objLoanmaster.UpdateLoan(lLoanMasterID)
                    ' BindGrid()

                    Dim i As Integer
                    Dim lnApproved As LinkButton
                    Dim dtapproval As DataTable
                    dtapproval = objLoanmaster.GetNotApprovedLoanforView()
                    If dtapproval.Rows.Count > 0 Then
                        Dim objDataView As DataView
                        objDataView = New DataView(dtapproval)
                        dgLoanView.DataSource = objDataView
                        dgLoanView.Columns(8).Visible = True
                        dgLoanView.Columns(7).Visible = False
                        dgLoanView.DataBind()
                        dgLoanView.Visible = True
                        For i = 0 To dtapproval.Rows.Count - 1
                            lnApproved = CType(dgLoanView.Items(i).FindControl("lnApproved"), LinkButton)
                            lnApproved.Text = dtapproval.Rows(i)("Statuss")
                        Next
                    Else
                        dgLoanView.Visible = False
                    End If
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Loan Approved Successfully.")
            End Select
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        Dim xx As Integer
        Dim lnApproved As LinkButton
        Dim dt As DataTable

        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            If RadioButtonList1.SelectedItem.Text = "Not Approved" Then
                dt = objLoanmaster.GetNotApprovedLoanforView()

                If dt.Rows.Count > 0 Then
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    'objDataView = Session("objDataView")
                    dgLoanView.DataSource = objDataView
                    dgLoanView.Columns(8).Visible = True
                    dgLoanView.Columns(7).Visible = False
                    dgLoanView.DataBind()
                    dgLoanView.Visible = True
                    For xx = 0 To dt.Rows.Count - 1
                        lnApproved = CType(dgLoanView.Items(xx).FindControl("lnApproved"), LinkButton)
                        lnApproved.Text = dt.Rows(xx)("Statuss")
                    Next

                Else
                    dgLoanView.Visible = False
                End If
            Else
                dt = objLoanmaster.GetApprovedLoanforView()

                If dt.Rows.Count > 0 Then
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    'objDataView = Session("objDataView")
                    dgLoanView.DataSource = objDataView
                    dgLoanView.Columns(8).Visible = False
                    dgLoanView.Columns(7).Visible = True
                    dgLoanView.DataBind()
                    dgLoanView.Visible = True
                Else
                    dgLoanView.Visible = False
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

End Class
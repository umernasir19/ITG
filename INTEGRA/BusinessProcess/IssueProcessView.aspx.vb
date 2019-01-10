Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class IssueProcessView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjIssue As New IssueProcessMst
    Dim ObjIssueDtl As New IssueProcessDetail
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try

                If userid = 241 Then
                    dgView.Columns(4).HeaderText = "Fabric Code"
                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    dgView.Columns(4).HeaderText = "Fabric Code"
                ElseIf userid = 242 Then
                    dgView.Columns(4).HeaderText = "Item Code"
                End If


                'BindStyle()
                'BindItem()
                'BindDept()
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                'If userid = 19 Then
                '    lblItemFab.Text = "Fabric "
                'Else
                '    lblItemFab.Text = "Item "
                'End If
            Catch ex As Exception

            End Try
        End If
        PageHeader("Process Issue View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = ObjIssue.ViewFabricNewNew()
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = ObjIssue.ViewFabricNewNew()
        Else
            objDataTable = ObjIssue.ViewNewForAcc()
        End If

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.DataSource = objDataView
        dgView.DataBind()

    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"
                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim FileName As String
                    If userid = 241 Then
                        Report.Load(Server.MapPath("..\Reports/POIssueForFabric.rpt"))
                    ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                        Report.Load(Server.MapPath("..\Reports/POIssueForFabric.rpt"))
                    Else
                        Report.Load(Server.MapPath("..\Reports/POIssue.rpt"))
                    End If

                    FileName = "PO ISSUE REPORT"

                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, IssueID)
                    Report.SetParameterValue(1, IssueDtlID)



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
                        Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
                        Response.End()
                    End If
                Case "Return"



                    Dim IssueID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim IssueDtlID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    'Dim PORecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    '   Dim PORecvDetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(3).Text

                    '  Dim PONO As String = dgView.Items(e.Item.ItemIndex).Cells(5).Text
                    '  Dim Style As String = dgView.Items(e.Item.ItemIndex).Cells(6).Text
                    ' Dim SupplierName As String = dgView.Items(e.Item.ItemIndex).Cells(7).Text
                    ' Dim ItemName As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    ' Dim POQTY As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    ' Dim RecvQuantity As String = dgView.Items(e.Item.ItemIndex).Cells(12).Text


                    'Session("PONO") = PONO
                    ' Session("Style") = Style
                    'Session("SupplierName") = SupplierName
                    'Session("ItemName") = ItemName
                    ' Session("POQTY") = POQTY
                    'Session("RecvQuantity") = RecvQuantity
                    Response.Redirect("POIssueReturn.aspx?IssueID=" & IssueID & " &IssueDtlID=" & IssueDtlID & "", False)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("IssueProcessOr.aspx")
    End Sub

    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = ObjIssue.GetItemAllInfoISSUE(ItemName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = ObjIssue.GetItemAllInfoISSUE(ItemName)
        Else
            objDataTable = ObjIssue.ViewForSearch(ItemName)
        End If

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        Try
            Dim objDataView As DataView
            objDataView = LoadData()

            Session("objDataView") = objDataView
            BindGrid()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If txtShowMe.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid ItemName")
            ElseIf txtShowMe.Text <> "" Then
                Dim objDataView As DataView
                objDataView = LoadData(txtShowMe.Text)
                If objDataView.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("ItemName Not Exist")
                End If
                Session("objDataView") = objDataView
                BindGrid()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


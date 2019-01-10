Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class Fabric
    Inherits System.Web.UI.Page
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim UserID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView, objMasterDataView As DataView
        UserID = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            Try
                Session("DtSummarytable") = Nothing
                '---Master
                objMasterDataView = LoadMasterData()
                Session("objMasterDataView") = objMasterDataView
                BindMasterGrid()
                If UserID = 241 Then
                    dgViewMaster.Columns(9).Visible = False
                    lblHeading.Text = "FABRIC PLANNING"
                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    dgViewMaster.Columns(9).Visible = False
                    lblHeading.Text = "FABRIC PLANNING"
                End If
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Fabric/Accessoriese")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadMasterData() As ICollection

        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        '------------Nizam New work for Summary joborder in   Grid

        Dim dtSummaryViewData As DataTable = objJobOrderdatabase.ForfabricView()
        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("Joborderid", GetType(String))
        DtSummarytable.Columns.Add("SRNo", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("Style", GetType(String))
        DtSummarytable.Columns.Add("OrderRecvDatee", GetType(String))
        DtSummarytable.Columns.Add("StyleShipmentDatee", GetType(String))
        DtSummarytable.Columns.Add("Quantity", GetType(String))


        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")

                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMasterForFabric(Joborderid)
                        dtSumstyle = objJobOrderdatabase.ViewMasterStyleForFabric(Joborderid)
                        Dim Str As String = ""
                        Dim StrStyle As String = ""
                        Dim ReturnQty As Decimal = 0
                        Dim StyleID As String = 0
                        Dim Style As String = ""
                        For k As Integer = 0 To dtSum.Rows.Count - 1
                            ReturnQty = ReturnQty + Val(dtSum.Rows(k)("Quantity"))
                        Next
                        For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                            Style = dtSumstyle.Rows(F)("Style") + ","
                            StrStyle = StrStyle + Style
                        Next
                        dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                        dr("SRNo") = dtSum.Rows(0)("SRNo")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                        dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                        dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                        dr("Quantity") = ReturnQty
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMasterForFabric(Joborderid)
                    dtSumstyle = objJobOrderdatabase.ViewMasterStyleForFabric(Joborderid)
                    Dim Str As String = ""
                    Dim StrStyle As String = ""
                    Dim ReturnQty As Decimal = 0
                    Dim StyleID As String = ""
                    Dim Style As String = ""
                    For k As Integer = 0 To dtSum.Rows.Count - 1
                        ReturnQty = ReturnQty + Val(dtSum.Rows(k)("Quantity"))
                    Next
                    For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                        Style = dtSumstyle.Rows(F)("Style") + ","
                        StrStyle = StrStyle + Style
                    Next
                    dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                    dr("SRNo") = dtSum.Rows(0)("SRNo")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                    dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                    dr("Quantity") = ReturnQty
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        '------End
        objMasterDataView = New DataView(Session("DtSummarytable"))
        '-------
        Return objMasterDataView
    End Function
    Private Sub BindMasterGrid()
        Dim objMasterDataView As DataView
        objMasterDataView = Session("objMasterDataView")
        dgViewMaster.RecordCount = objMasterDataView.Count
        dgViewMaster.DataSource = objMasterDataView
        dgViewMaster.DataBind()
        Dim checkdt As DataTable
        Dim x As Long
        For x = 0 To dgViewMaster.Items.Count - 1
            Dim lnkFabric As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkFabric"), ImageButton)
            Dim lnkFabricPDF As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkFabricPDF"), ImageButton)
            Dim lnkAccessoriese As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkAccessoriese"), ImageButton)
            Dim lnkAccessoriesePDF As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkAccessoriesePDF"), ImageButton)
        
            Dim lJobOrderId = dgViewMaster.Items(x).Cells(0).Text
            checkdt = objJobOrderdatabase.CheckStyle(lJobOrderId)
            If checkdt.Rows.Count > 0 Then
                lnkFabric.Enabled = True
                lnkFabric.ToolTip = "Click Here To Fabric Planning"
                lnkFabric.ImageUrl = "~/Images/green.png"

                lnkAccessoriese.ImageUrl = "~/Images/green.png"
                lnkAccessoriese.Enabled = True
                lnkAccessoriese.ToolTip = "Click Here To Accessoriese Planning"

              
            Else
                lnkFabric.Enabled = False
                'lnkFabricPDF.Enabled = False
                lnkFabric.ToolTip = "Firstly Make Style Then Fabric Planning"
                lnkFabric.ImageUrl = "~/Images/red.png"

                lnkAccessoriese.ImageUrl = "~/Images/red.png"
                lnkAccessoriese.Enabled = False
                lnkAccessoriese.ToolTip = "Firstly Make Style Then Accessoriese Planning"

                 

            End If

            Dim dtfabric As DataTable = objJobOrderdatabase.CheckFabricPlane(lJobOrderId)
            If dtfabric.Rows.Count > 0 Then
                lnkFabricPDF.Enabled = True
                lnkFabricPDF.ToolTip = "Click to Download Fabric Planning PDF"
                lnkFabricPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
            Else
                lnkFabricPDF.Enabled = False
                lnkFabricPDF.ToolTip = "Not Available"
                lnkFabricPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
            End If
            Dim dtcheckAccess As New DataTable
            dtcheckAccess = objJobOrderdatabase.CheckAccessoriesePlane(lJobOrderId)
            If dtcheckAccess.Rows.Count > 0 Then
                lnkAccessoriesePDF.Enabled = True
                lnkAccessoriesePDF.ToolTip = "Click to Download Accessoriese Planning PDF"
                lnkAccessoriesePDF.ImageUrl = "~/Images/pdf_icon_small.gif"

            Else
                lnkAccessoriesePDF.Enabled = False
                lnkAccessoriesePDF.ToolTip = "Not Available"
                lnkAccessoriesePDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
            End If

        Next
    End Sub
    Protected Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgViewMaster.PageIndexChanged
        BindMasterGrid()
    End Sub
    Protected Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgViewMaster.SortCommand
        BindMasterGrid()
    End Sub
    Protected Sub dgViewMaster_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgViewMaster.ItemCommand
        Try
            Select Case e.CommandName

                Case "Fabric"

                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("FPlanEntryNew2.aspx?JobOrderID=" & JobOrderID & "")
                    ' Response.Redirect("CostControlFb.aspx?JobOrderID=" & JobOrderID & "")
                Case "Accessoriese"

                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    ' Response.Redirect("AccPlanEntryNew.aspx?JobOrderID=" & JobOrderID & "")
                    Response.Redirect("AccPlanEntryNewSF.aspx?JobOrderID=" & JobOrderID & "")

                Case "FabricPDF"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\Reports/FabricPlanningg.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim JobOrderNO As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    Dim FileName As String = "Fabric Planning-" + JobOrderNO
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, JobOrderID)
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
End Class

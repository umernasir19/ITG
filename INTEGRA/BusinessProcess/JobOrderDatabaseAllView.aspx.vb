Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.DataView
Public Class JobOrderDatabaseAllView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim UserID, Roleid As Long
    Dim objDataView, objMasterDataView As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UserID = CLng(Session("Userid"))
        Roleid = CLng(Session("RoleId"))
        If Not Page.IsPostBack Then
            Try
                BinSeason()
                Session("DtSummarytable") = Nothing

                '---Master
                objMasterDataView = LoadMasterData()
                Session("objMasterDataView") = objMasterDataView
                BindMasterGrid()
                '---Detail
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                ''for production
              

            Catch objUDException As UDException
            End Try
        End If
        PageHeader("JOB ORDER INDEX")
    End Sub
    Sub BinSeason()
        Dim dt As DataTable
        dt = objSizeRange.GetSeasonsForJobOrderVieeSearchingNew()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, "All")
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        If cmbSeason.SelectedItem.Text = "All" Then

            Session("DtSummarytable") = Nothing
            objMasterDataView = LoadMasterData()
            Session("objMasterDataView") = objMasterDataView
            BindMasterGrid()

        Else

            Session("DtSummarytable") = Nothing
            objMasterDataView = LoadMasterDataForSearching()
            Session("objMasterDataView") = objMasterDataView
            BindMasterGrid()

        End If
    End Sub
    Sub ProductionHide()
        Try
            'btndAdd.Visible = False
            'dgViewMaster.Columns(12).Visible = False
            'dgViewMaster.Columns(13).Visible = False
            'dgViewMaster.Columns(14).Visible = False
            'dgViewMaster.Columns(15).Visible = False
            'dgViewMaster.Columns(16).Visible = False
            'dgViewMaster.Columns(17).Visible = False
            'dgViewMaster.Columns(19).Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
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
                lnkFabric.Enabled = True
                lnkFabric.ToolTip = "Click Here To Fabric Planning"
                lnkFabric.ImageUrl = "~/Images/green.png"

                lnkAccessoriese.ImageUrl = "~/Images/green.png"
                lnkAccessoriese.Enabled = True
                lnkAccessoriese.ToolTip = "Click Here To Accessoriese Planning"
                ''lnkFabric.Enabled = False
                ' ''lnkFabricPDF.Enabled = False
                ''lnkFabric.ToolTip = "Firstly Make Style Then Fabric Planning"
                ''lnkFabric.ImageUrl = "~/Images/red.png"
                ''lnkAccessoriese.ImageUrl = "~/Images/red.png"
                ''lnkAccessoriese.Enabled = False
                ''lnkAccessoriese.ToolTip = "Firstly Make Style Then Accessoriese Planning"
            End If

            Dim dtfabric As DataTable = objJobOrderdatabase.CheckFabricPlaneNew(lJobOrderId) ' objJobOrderdatabase.CheckFabricPlane
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
            dtcheckAccess = objJobOrderdatabase.CheckAccessorieseCostNew(lJobOrderId)
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
        'If UserID = "249" Or UserID = "264" Or UserID = "265" Or UserID = "266" Or UserID = "267" Then
        '    btnDetailSection.Visible = False
        '    btndAdd.Visible = False
        '    dgViewMaster.Columns(12).Visible = False
        '    dgViewMaster.Columns(13).Visible = False
        '    dgViewMaster.Columns(14).Visible = False
        '    dgViewMaster.Columns(15).Visible = False
        '    dgViewMaster.Columns(16).Visible = False
        '    dgViewMaster.Columns(17).Visible = False
        '    dgViewMaster.Columns(18).Visible = False
        '    dgViewMaster.Columns(19).Visible = False
        '    dgViewMaster.Columns(20).Visible = False
        '    dgViewMaster.Columns(21).Visible = False
        '    dgViewMaster.Columns(22).Visible = False
        '    dgViewMaster.Columns(23).Visible = False

        'End If
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadMasterData() As ICollection

        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
      
        dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2(0)
   
        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("Joborderid", GetType(String))
        DtSummarytable.Columns.Add("JoborderNo", GetType(String))
        DtSummarytable.Columns.Add("SRNO", GetType(String))
        DtSummarytable.Columns.Add("Model", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("Style", GetType(String))
        DtSummarytable.Columns.Add("OrderRecvDatee", GetType(String))
        DtSummarytable.Columns.Add("StyleShipmentDatee", GetType(String))
        DtSummarytable.Columns.Add("Quantity", GetType(String))
        DtSummarytable.Columns.Add("UserID", GetType(String))
        DtSummarytable.Columns.Add("UserName", GetType(String))
        DtSummarytable.Columns.Add("CustomerDatabaseID", GetType(Long))
        DtSummarytable.Columns.Add("SeasonName", GetType(String))
        DtSummarytable.Columns.Add("CustomerOrder", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")

                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMaster(Joborderid)
                        dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                        dr("UserName") = dtSum.Rows(0)("UserName")
                        dr("UserID") = dtSum.Rows(0)("UserID")
                        dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                        dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                        dr("SRNO") = dtSum.Rows(0)("SRNO")
                        dr("Model") = dtSum.Rows(0)("Model")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                        dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                        dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                        dr("Quantity") = ReturnQty
                        dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                        dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                        dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMaster(Joborderid)
                    dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                    dr("UserName") = dtSum.Rows(0)("UserName")
                    dr("UserID") = dtSum.Rows(0)("UserID")
                    dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                    dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                    dr("SRNO") = dtSum.Rows(0)("SRNO")
                    dr("Model") = dtSum.Rows(0)("Model")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                    dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                    dr("Quantity") = ReturnQty
                    dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                    dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                    dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        'End If
        '------End
        objMasterDataView = New DataView(Session("DtSummarytable"))
        '-------
        Return objMasterDataView
    End Function
    Function LoadMasterDataForSearching() As ICollection

        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable

        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingNew(0, cmbSeason.SelectedValue)


        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("Joborderid", GetType(String))
        DtSummarytable.Columns.Add("JoborderNo", GetType(String))
        DtSummarytable.Columns.Add("SRNO", GetType(String))
        DtSummarytable.Columns.Add("Model", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("Style", GetType(String))
        DtSummarytable.Columns.Add("OrderRecvDatee", GetType(String))
        DtSummarytable.Columns.Add("StyleShipmentDatee", GetType(String))
        DtSummarytable.Columns.Add("Quantity", GetType(String))
        DtSummarytable.Columns.Add("UserID", GetType(String))
        DtSummarytable.Columns.Add("UserName", GetType(String))
        DtSummarytable.Columns.Add("CustomerDatabaseID", GetType(Long))
        DtSummarytable.Columns.Add("SeasonName", GetType(String))
        DtSummarytable.Columns.Add("CustomerOrder", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")

                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMasterForSearchingNewFor(Joborderid, cmbSeason.SelectedValue)
                        dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                        dr("UserName") = dtSum.Rows(0)("UserName")
                        dr("UserID") = dtSum.Rows(0)("UserID")
                        dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                        dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                        dr("SRNO") = dtSum.Rows(0)("SRNO")
                        dr("Model") = dtSum.Rows(0)("Model")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                        dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                        dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                        dr("Quantity") = ReturnQty
                        dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                        dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                        dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMasterForSearchingNewFor(Joborderid, cmbSeason.SelectedValue)
                    dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                    dr("UserName") = dtSum.Rows(0)("UserName")
                    dr("UserID") = dtSum.Rows(0)("UserID")
                    dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                    dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                    dr("SRNO") = dtSum.Rows(0)("SRNO")
                    dr("Model") = dtSum.Rows(0)("Model")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                    dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                    dr("Quantity") = ReturnQty
                    dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                    dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                    dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        'End If
        '------End
        objMasterDataView = New DataView(Session("DtSummarytable"))
        '-------
        Return objMasterDataView
    End Function
    Protected Sub dgViewMaster_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgViewMaster.ItemCommand
        Try
            Select Case e.CommandName

                Case "Copy"
                    ' Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim Type As String = "Copy"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?Joborderid=" & lJoborderid & " &Type=" & Type & "")

                Case "MILESTONE"
                    Dim StyleID As String = 0 'dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim Joborderid As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("TNAChartView.aspx?JobOrderID=" & Joborderid & "")
                Case "ASSORT"
                    'Dim StyleID As String = 0 'dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    'Dim Joborderid As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentView.aspx")
                Case "Edit"
                    ' Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?Joborderid=" & lJoborderid & "")
                Case "Fabric"

                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    'Response.Redirect("FPlanEntryNew.aspx?JobOrderID=" & JobOrderID & "")

                    Response.Redirect("CostControlFb.aspx?JobOrderID=" & JobOrderID & "")
                Case "Accessoriese"

                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    'Response.Redirect("AccPlanEntryNew.aspx?JobOrderID=" & JobOrderID & "")
                    Response.Redirect("CostControlAc2.aspx?JobOrderID=" & JobOrderID & "")

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

                    Dim FileName As String = "FabricPlanning-" + JobOrderNO
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
                Case "AccessoriesePDF"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\Reports/Accessories.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim JobOrderNO As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    Dim FileName As String = "BuyingAccessoriesProgram-" + JobOrderNO
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

                Case "PRODUCTION"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    Response.Redirect("CostingCutToPack.aspx?JobOrderID=" & JobOrderID & "")
                Case "OtherHead"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    Response.Redirect("CostHead.aspx?JobOrderID=" & JobOrderID & "")

                Case "CostPDF"
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Report.Load(Server.MapPath("..\Reports/CostSheetANew.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()

                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text

                    Dim FileName As String = "CostSheet"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, JobOrderID)
                    Report.SetParameterValue(1, JobOrderID)
                    Report.SetParameterValue(2, JobOrderID)
                    Report.SetParameterValue(3, JobOrderID)

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




                Case "PIPDF"

                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim JobOrderNO As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim CustomerDatabaseID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(20).Text

                    If CustomerDatabaseID = 14 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoicePortrait.rpt"))
                    ElseIf CustomerDatabaseID = 13 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceArmandThierySASPortrait.rpt"))
                    ElseIf CustomerDatabaseID = 12 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceMayoralModaSAUPortrait.rpt"))
                    End If


                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()


                    Dim FileName As String = "PROFORMAINVOICE-" + JobOrderNO
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


                Case "PRODUCTIONN"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("Production.aspx?JobOrderID=" & JobOrderID & "")

            End Select
        Catch ex As Exception
        End Try
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()

        'If UserID = "249" Or UserID = "264" Or UserID = "265" Or UserID = "266" Or UserID = "267" Then
        '    btnDetailSection.Visible = False
        '    btndAdd.Visible = False
        '    dgViewMaster.Columns(12).Visible = False
        '    dgViewMaster.Columns(13).Visible = False
        '    dgViewMaster.Columns(14).Visible = False
        '    dgViewMaster.Columns(15).Visible = False
        '    dgViewMaster.Columns(16).Visible = False
        '    dgViewMaster.Columns(17).Visible = False
        '    dgViewMaster.Columns(18).Visible = False
        '    dgViewMaster.Columns(19).Visible = False
        '    dgViewMaster.Columns(20).Visible = False
        '    dgViewMaster.Columns(21).Visible = False
        '    dgViewMaster.Columns(22).Visible = False
        '    dgViewMaster.Columns(23).Visible = False

        'End If


    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable

        objDataTable = objJobOrderdatabase.ViewNewForTFA(0)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btndAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndAdd.Click
        Response.Redirect("JobOrderDatabaseEntry.aspx")
    End Sub
    Protected Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "MILESTONE"
                    Dim StyleID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim Joborderid As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("TNAChartView.aspx?JobOrderID=" & Joborderid & "&StyleID=" & StyleID & "")
                Case "Edit"
                    '  Dim lJoborderid As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim lJoborderid As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?Joborderid=" & lJoborderid & "")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnDetailSection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetailSection.Click
        Try
            pnlDetail.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            objMasterDataView = LoadMasterDataForSearch()
            Session("objMasterDataView") = objMasterDataView
            BindMasterGrid()
        Catch ex As Exception

        End Try

    End Sub
    Function LoadMasterDataForSearch() As ICollection

        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        Dim dtSummaryViewDataSR As DataTable
        Dim dtSummaryViewDataCS As DataTable
        Dim dtSummaryViewDataST As DataTable


        dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrno(0, txtSearch.Text)
        dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomer(0, txtSearch.Text)
        dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyle(0, txtSearch.Text)
   
        If dtSummaryViewDataSR.Rows.Count > 0 Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNO(0, txtSearch.Text)
        ElseIf dtSummaryViewDataCS.Rows.Count > 0 Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomer(0, txtSearch.Text)
        ElseIf dtSummaryViewDataST.Rows.Count > 0 Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyle(0, txtSearch.Text)
        Else
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFA(0)
        End If

        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("Joborderid", GetType(String))
        DtSummarytable.Columns.Add("JoborderNo", GetType(String))
        DtSummarytable.Columns.Add("SRNO", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("Style", GetType(String))
        DtSummarytable.Columns.Add("OrderRecvDatee", GetType(String))
        DtSummarytable.Columns.Add("StyleShipmentDatee", GetType(String))
        DtSummarytable.Columns.Add("Quantity", GetType(String))
        DtSummarytable.Columns.Add("UserID", GetType(String))
        DtSummarytable.Columns.Add("UserName", GetType(String))
        DtSummarytable.Columns.Add("CustomerDatabaseID", GetType(Long))
        DtSummarytable.Columns.Add("SeasonName", GetType(String))
        DtSummarytable.Columns.Add("CustomerOrder", GetType(String))
        DtSummarytable.Columns.Add("Model", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")

                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMaster(Joborderid)
                        dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                        dr("UserName") = dtSum.Rows(0)("UserName")
                        dr("UserID") = dtSum.Rows(0)("UserID")
                        dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                        dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                        dr("SRNO") = dtSum.Rows(0)("SRNO")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                        dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                        dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                        dr("Quantity") = ReturnQty
                        dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                        dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                        dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                        dr("Model") = dtSum.Rows(0)("Model")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMaster(Joborderid)
                    dtSumstyle = objJobOrderdatabase.ViewMasterStyle(Joborderid)
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
                    dr("UserName") = dtSum.Rows(0)("UserName")
                    dr("UserID") = dtSum.Rows(0)("UserID")
                    dr("Joborderid") = dtSum.Rows(0)("Joborderid")
                    dr("JoborderNo") = dtSum.Rows(0)("JoborderNo")
                    dr("SRNO") = dtSum.Rows(0)("SRNO")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    dr("Style") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("OrderRecvDatee") = dtSum.Rows(0)("OrderRecvDatee")
                    dr("StyleShipmentDatee") = dtSum.Rows(0)("StyleShipmentDatee")
                    dr("Quantity") = ReturnQty
                    dr("CustomerDatabaseID") = dtSum.Rows(0)("CustomerDatabaseID")
                    dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                    dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                    dr("Model") = dtSum.Rows(0)("Model")
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
End Class


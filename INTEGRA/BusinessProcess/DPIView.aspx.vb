Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DPIView
    Inherits System.Web.UI.Page
    Dim ObjDPIMst As New DPIMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim Userid As Long
    Dim Dr As DataRow
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objCuttingProMst As New CuttingProMst
    Dim objTempAccCheckListSize As New TempAccCheckListSize
    Dim objTempCuttingPro As New TempCuttingPro
    Dim objTempZipperCheckListSize As New TempZipperCheckListSize
    Dim objAccCheckListMst As New AccCheckListMst
    Dim dtAccDetail, dtFinal As DataTable
    Dim objTempPIOne As New TempPIOne
    Dim objTempPISecond As New TempPISecond
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView, objMasterDataView As DataView
        Userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("objMasterDataView") = Nothing
            Session("DtSummarytable") = Nothing
            objMasterDataView = LoadMasterData()
            Session("objMasterDataView") = objMasterDataView
            BindGrid()
            GetRights()
        End If
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(Userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If
            If View = 1 Then
                dgPI.MasterTableView.GetColumn("View").Display = True
            Else
                dgPI.MasterTableView.GetColumn("View").Display = False
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objMasterDataView")
            dgPI.DataSource = objDataView
            dgPI.DataBind()
            GetRights()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Response.Redirect("DPIAdd.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgPi_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPI.ItemCommand
        Try
            Select Case e.CommandName
                Case "PDF"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim DPIMstID As String = item("DPIMstID").Text
                    Dim CustomID As String = item("CustomID").Text
                    Dim ReportTypeID As String = item("ReportTypeID").Text
                    Dim SalesContract As String = item("SalesContract").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    If ReportTypeID = 1 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoicePortrait.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "PROFORMAINVOICE" '+ SalesContract
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, DPIMstID)
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
                    ElseIf ReportTypeID = 2 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceMayoralModaSAUPortrait.rpt"))
                        Report.Refresh()
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                        di.Create()
                        Dim FileName As String = "PROFORMAINVOICE" '+ SalesContract
                        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                        Report.SetParameterValue(0, DPIMstID)
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
                    ElseIf ReportTypeID = 3 Then
                        LoloaLizaPDF(DPIMstID)
                    Else
                    End If
                Case "PDFF"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim DPIMstID As String = item("DPIMstID").Text
                    Dim CustomID As String = item("CustomID").Text
                    Dim ReportTypeID As String = item("ReportTypeID").Text
                    Dim SalesContract As String = item("SalesContract").Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    If ReportTypeID = 1 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoicePortraitWH.rpt"))
                    ElseIf ReportTypeID = 2 Then
                        Report.Load(Server.MapPath("..\Reports/ProformaInvoiceMayoralModaSAUPortraitWH.rpt"))
                    Else
                    End If
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "PROFORMAINVOICE" '+ SalesContract
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, DPIMstID)
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
    Protected Sub dgPi_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgPI.NeedDataSource
    End Sub
    Protected Sub dgPi_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgPI.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgPi_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgPI.SortCommand
        BindGrid()
    End Sub
    Function LoadMasterData() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        dtSummaryViewData = ObjDPIMst.GetView()
        Dim DtSummarytable As New DataTable()
        DtSummarytable.Columns.Add("DPIMstID", GetType(Long))
        DtSummarytable.Columns.Add("SeasonID", GetType(Long))
        DtSummarytable.Columns.Add("CustomID", GetType(Long))
        DtSummarytable.Columns.Add("PIDatee", GetType(String))
        DtSummarytable.Columns.Add("SRNO", GetType(String))
        DtSummarytable.Columns.Add("SalesContract", GetType(String))
        DtSummarytable.Columns.Add("CustomerName", GetType(String))
        DtSummarytable.Columns.Add("SeasonName", GetType(String))
        DtSummarytable.Columns.Add("ReportTypeID", GetType(Long))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim DPIMstID As Long = dtSummaryViewData.Rows(i)("DPIMstID")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("SRNO")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("DPIMstID='" & DPIMstID & "'")
                    If results.Length <> 1 Then
                        dtSum = ObjDPIMst.ViewMasterPIViewPage(DPIMstID)
                        dtSumstyle = ObjDPIMst.ViewMasterStylePIViewPage(DPIMstID)
                        Dim Str As String = ""
                        Dim StrStyle As String = ""
                        Dim Style As String = ""
                        For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                            Style = dtSumstyle.Rows(F)("SRNO") + ","
                            StrStyle = StrStyle + Style
                        Next
                        dr("DPIMstID") = dtSum.Rows(0)("DPIMstID")
                        dr("SeasonID") = dtSum.Rows(0)("SeasonID")
                        dr("CustomID") = dtSum.Rows(0)("CustomID")
                        dr("PIDatee") = dtSum.Rows(0)("PIDatee")
                        dr("SRNO") = StrStyle.Substring(0, StrStyle.Length - 1)
                        dr("SalesContract") = dtSum.Rows(0)("SalesContract")
                        dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                        dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                        dr("ReportTypeID") = dtSum.Rows(0)("ReportTypeID")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = ObjDPIMst.ViewMasterPIViewPage(DPIMstID)
                    dtSumstyle = ObjDPIMst.ViewMasterStylePIViewPage(DPIMstID)
                    Dim Str As String = ""
                    Dim StrStyle As String = ""
                    Dim ReturnQty As Decimal = 0
                    Dim StyleID As String = ""
                    Dim Style As String = ""
                    For F As Integer = 0 To dtSumstyle.Rows.Count - 1
                        Style = dtSumstyle.Rows(F)("SRNO") + ","
                        StrStyle = StrStyle + Style
                    Next
                    dr("DPIMstID") = dtSum.Rows(0)("DPIMstID")
                    dr("SeasonID") = dtSum.Rows(0)("SeasonID")
                    dr("CustomID") = dtSum.Rows(0)("CustomID")
                    dr("PIDatee") = dtSum.Rows(0)("PIDatee")
                    dr("SRNO") = StrStyle.Substring(0, StrStyle.Length - 1)
                    dr("SalesContract") = dtSum.Rows(0)("SalesContract")
                    dr("CustomerName") = dtSum.Rows(0)("CustomerName")
                    dr("SeasonName") = dtSum.Rows(0)("SeasonName")
                    dr("ReportTypeID") = dtSum.Rows(0)("ReportTypeID")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
    Sub LoloaLizaPDF(ByVal DPIMstID As Long)
        Dim dtMain As DataTable = objAccCheckListMst.GetJobOrderDetailId(DPIMstID)
        Dim x As Integer
        For x = 0 To dtMain.Rows.Count - 1
            If dtMain.Rows.Count = 1 Then
                Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
                Dim Style, Description, SRNO, ArtNo, ShipmentDate As String
                Dim Color, Type, ColorCode As String
                Dim Quantity As Decimal = 0
                Dim Price As Decimal = 0
                Dim Amount As Decimal = 0
                Dim dtS1 As Decimal = 0
                Dim dtS2 As Decimal = 0
                Dim dtS3 As Decimal = 0
                Dim dtS4 As Decimal = 0
                Dim dtS5 As Decimal = 0
                Dim dtS6 As Decimal = 0
                Dim dtS7 As Decimal = 0
                Dim dtS8 As Decimal = 0
                Dim dtS9 As Decimal = 0
                Dim dtS10 As Decimal = 0
                Dim dtS11 As Decimal = 0
                Dim dtFinal = New DataTable
                objTempAccCheckListSize.TruncateTablePIONe()
                With dtFinal
                    .Columns.Add("TempId", GetType(Long))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("Description", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("ArtNo", GetType(String))
                    .Columns.Add("ShipmentDate", GetType(String))
                    .Columns.Add("S1", GetType(String))
                    .Columns.Add("S2", GetType(String))
                    .Columns.Add("S3", GetType(String))
                    .Columns.Add("S4", GetType(String))
                    .Columns.Add("S5", GetType(String))
                    .Columns.Add("S6", GetType(String))
                    .Columns.Add("S7", GetType(String))
                    .Columns.Add("S8", GetType(String))
                    .Columns.Add("S9", GetType(String))
                    .Columns.Add("S10", GetType(String))
                    .Columns.Add("S11", GetType(String))
                    .Columns.Add("Qty", GetType(String))
                    .Columns.Add("Price", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("DPIMstID", GetType(Long))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("ColorCode", GetType(String))
                End With
                dtAccDetail = objAccCheckListMst.GetSizeForPI(dtMain.Rows(0)("JobOrderDetailid"))
                Dim DtExtraQTY As DataTable = objAccCheckListMst.GetExtraQtyForPI(dtMain.Rows(0)("JobOrderDetailid"))
                Style = dtAccDetail.Rows(0)("Style")
                Description = dtAccDetail.Rows(0)("ItemDesc")
                Color = dtAccDetail.Rows(0)("BuyerColor")
                Quantity = dtAccDetail.Rows(0)("Quantity") + Val(DtExtraQTY.Rows(0)("ExtraQty"))
                Price = dtAccDetail.Rows(0)("UnitPrice")
                SRNO = dtAccDetail.Rows(0)("CustomerOrder")
                ArtNo = dtAccDetail.Rows(0)("Model")
                ShipmentDate = dtAccDetail.Rows(0)("StyleShipmentDate")
                Type = dtAccDetail.Rows(0)("Breakup")
                ColorCode = dtAccDetail.Rows(0)("ColorCode")
                Amount = Val(dtAccDetail.Rows(0)("Quantity")) * Val(dtAccDetail.Rows(0)("UnitPrice"))
                If dtAccDetail.Rows.Count > 0 Then
                    Size1 = dtAccDetail.Rows(0)("Size")
                    dtS1 = dtAccDetail.Rows(0)("Total")
                End If
                If dtAccDetail.Rows.Count > 1 Then
                    Size2 = dtAccDetail.Rows(1)("Size")
                    dtS2 = dtAccDetail.Rows(1)("Total")
                End If
                If dtAccDetail.Rows.Count > 2 Then
                    Size3 = dtAccDetail.Rows(2)("Size")
                    dtS3 = dtAccDetail.Rows(2)("Total")
                End If
                If dtAccDetail.Rows.Count > 3 Then
                    Size4 = dtAccDetail.Rows(3)("Size")
                    dtS4 = dtAccDetail.Rows(3)("Total")
                End If
                If dtAccDetail.Rows.Count > 4 Then
                    Size5 = dtAccDetail.Rows(4)("Size")
                    dtS5 = dtAccDetail.Rows(4)("Total")
                End If
                If dtAccDetail.Rows.Count > 5 Then
                    Size6 = dtAccDetail.Rows(5)("Size")
                    dtS6 = dtAccDetail.Rows(5)("Total")
                End If
                If dtAccDetail.Rows.Count > 6 Then
                    Size7 = dtAccDetail.Rows(6)("Size")
                    dtS7 = dtAccDetail.Rows(6)("Total")
                End If
                If dtAccDetail.Rows.Count > 7 Then
                    Size8 = dtAccDetail.Rows(7)("Size")
                    dtS8 = dtAccDetail.Rows(7)("Total")
                End If
                If dtAccDetail.Rows.Count > 8 Then
                    Size9 = dtAccDetail.Rows(8)("Size")
                    dtS9 = dtAccDetail.Rows(8)("Total")
                End If
                If dtAccDetail.Rows.Count > 9 Then
                    Size10 = dtAccDetail.Rows(9)("Size")
                    dtS10 = dtAccDetail.Rows(9)("Total")
                End If
                If dtAccDetail.Rows.Count > 10 Then
                    Size11 = dtAccDetail.Rows(10)("Size")
                    dtS11 = dtAccDetail.Rows(10)("Total")
                End If
                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("Style") = Style
                Dr("Description") = Description
                Dr("Color") = Color
                Dr("Qty") = Quantity
                Dr("Price") = Price
                Dr("Amount") = Amount
                Dr("SRNO") = SRNO
                Dr("ArtNo") = ArtNo
                Dr("ShipmentDate") = ShipmentDate
                Dr("DPIMstID") = DPIMstID
                Dr("Type") = Type
                Dr("ColorCode") = ColorCode
                If dtS1 = 0 Then
                    Dr("S1") = "0"
                Else
                    Dr("S1") = dtS1
                End If
                If dtS2 = 0 Then
                    Dr("S2") = "0"
                Else
                    Dr("S2") = dtS2
                End If
                If dtS3 = 0 Then
                    Dr("S3") = "0"
                Else
                    Dr("S3") = dtS3
                End If
                If dtS4 = 0 Then
                    Dr("S4") = "0"
                Else
                    Dr("S4") = dtS4
                End If
                If dtS5 = 0 Then
                    Dr("S5") = "0"
                Else
                    Dr("S5") = dtS5
                End If
                If dtS6 = 0 Then
                    Dr("S6") = "0"
                Else
                    Dr("S6") = dtS6
                End If
                If dtS7 = 0 Then
                    Dr("S7") = "0"
                Else
                    Dr("S7") = dtS7
                End If
                If dtS8 = 0 Then
                    Dr("S8") = "0"
                Else
                    Dr("S8") = dtS8
                End If
                If dtS9 = 0 Then
                    Dr("S9") = "0"
                Else
                    Dr("S9") = dtS9
                End If
                If dtS10 = 0 Then
                    Dr("S10") = "0"
                Else
                    Dr("S10") = dtS10
                End If
                If dtS11 = 0 Then
                    Dr("S11") = "0"
                Else
                    Dr("S11") = dtS11
                End If
                dtFinal.Rows.Add(Dr)
                For A As Integer = 0 To dtFinal.Rows.Count - 1
                    With objTempPIOne
                        .TempId = 0
                        .Style = dtFinal.Rows(A)("Style")
                        .Description = dtFinal.Rows(A)("Description")
                        .Color = dtFinal.Rows(A)("Color")
                        .Qty = dtFinal.Rows(A)("Qty")
                        .Price = dtFinal.Rows(A)("Price")
                        .Amount = dtFinal.Rows(A)("Amount")
                        .S1 = dtFinal.Rows(A)("S1")
                        .S2 = dtFinal.Rows(A)("S2")
                        .S3 = dtFinal.Rows(A)("S3")
                        .S4 = dtFinal.Rows(A)("S4")
                        .S5 = dtFinal.Rows(A)("S5")
                        .S6 = dtFinal.Rows(A)("S6")
                        .S7 = dtFinal.Rows(A)("S7")
                        .S8 = dtFinal.Rows(A)("S8")
                        .S9 = dtFinal.Rows(A)("S9")
                        .S10 = dtFinal.Rows(A)("S10")
                        .S11 = dtFinal.Rows(A)("S11")
                        .SRNO = dtFinal.Rows(A)("SRNO")
                        .Model = dtFinal.Rows(A)("ArtNo")
                        .StyleShipmentDate = dtFinal.Rows(A)("ShipmentDate")
                        .DPIMstID = dtFinal.Rows(A)("DPIMstID")
                        .Type = dtFinal.Rows(A)("Type")
                        .ColorCode = dtFinal.Rows(A)("ColorCode")
                        .Savetemp()
                    End With
                Next
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/PILolaLizaOne.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PROFORMAINVOICE"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, Size1)
                Report.SetParameterValue(1, Size2)
                Report.SetParameterValue(2, Size3)
                Report.SetParameterValue(3, Size4)
                Report.SetParameterValue(4, Size5)
                Report.SetParameterValue(5, Size6)
                Report.SetParameterValue(6, Size7)
                Report.SetParameterValue(7, Size8)
                Report.SetParameterValue(8, Size9)
                Report.SetParameterValue(9, Size10)
                Report.SetParameterValue(10, Size11)
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
            ElseIf dtMain.Rows.Count > 0 And dtMain.Rows.Count < 3 Then
                Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
                Dim Style, Description, SRNO, ArtNo, ShipmentDate As String
                Dim Color, Type, ColorCode As String
                Dim Quantity As Decimal = 0
                Dim Price As Decimal = 0
                Dim Amount As Decimal = 0
                Dim dtS1 As Decimal = 0
                Dim dtS2 As Decimal = 0
                Dim dtS3 As Decimal = 0
                Dim dtS4 As Decimal = 0
                Dim dtS5 As Decimal = 0
                Dim dtS6 As Decimal = 0
                Dim dtS7 As Decimal = 0
                Dim dtS8 As Decimal = 0
                Dim dtS9 As Decimal = 0
                Dim dtS10 As Decimal = 0
                Dim dtS11 As Decimal = 0

                Dim dtFinal = New DataTable
                objTempAccCheckListSize.TruncateTablePIONe()
                With dtFinal
                    .Columns.Add("TempId", GetType(Long))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("Description", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("ArtNo", GetType(String))
                    .Columns.Add("ShipmentDate", GetType(String))
                    .Columns.Add("S1", GetType(String))
                    .Columns.Add("S2", GetType(String))
                    .Columns.Add("S3", GetType(String))
                    .Columns.Add("S4", GetType(String))
                    .Columns.Add("S5", GetType(String))
                    .Columns.Add("S6", GetType(String))
                    .Columns.Add("S7", GetType(String))
                    .Columns.Add("S8", GetType(String))
                    .Columns.Add("S9", GetType(String))
                    .Columns.Add("S10", GetType(String))
                    .Columns.Add("S11", GetType(String))
                    .Columns.Add("Qty", GetType(String))
                    .Columns.Add("Price", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("DPIMstID", GetType(Long))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("ColorCode", GetType(String))
                End With
                dtAccDetail = objAccCheckListMst.GetSizeForPI(dtMain.Rows(0)("JobOrderDetailid"))
                Dim DtExtraQTY As DataTable = objAccCheckListMst.GetExtraQtyForPI(dtMain.Rows(0)("JobOrderDetailid"))
                Style = dtAccDetail.Rows(0)("Style")
                Description = dtAccDetail.Rows(0)("ItemDesc")
                Color = dtAccDetail.Rows(0)("BuyerColor")
                Quantity = dtAccDetail.Rows(0)("Quantity") + Val(DtExtraQTY.Rows(0)("ExtraQty"))
                Price = dtAccDetail.Rows(0)("UnitPrice")
                SRNO = dtAccDetail.Rows(0)("CustomerOrder")
                ArtNo = dtAccDetail.Rows(0)("Model")
                ShipmentDate = dtAccDetail.Rows(0)("StyleShipmentDate")
                Type = dtAccDetail.Rows(0)("Breakup")
                ColorCode = dtAccDetail.Rows(0)("ColorCode")
                Amount = Val(dtAccDetail.Rows(0)("Quantity")) * Val(dtAccDetail.Rows(0)("UnitPrice"))
                If dtAccDetail.Rows.Count > 0 Then
                    Size1 = dtAccDetail.Rows(0)("Size")
                    dtS1 = dtAccDetail.Rows(0)("Total")
                End If
                If dtAccDetail.Rows.Count > 1 Then
                    Size2 = dtAccDetail.Rows(1)("Size")
                    dtS2 = dtAccDetail.Rows(1)("Total")
                End If
                If dtAccDetail.Rows.Count > 2 Then
                    Size3 = dtAccDetail.Rows(2)("Size")
                    dtS3 = dtAccDetail.Rows(2)("Total")
                End If
                If dtAccDetail.Rows.Count > 3 Then
                    Size4 = dtAccDetail.Rows(3)("Size")
                    dtS4 = dtAccDetail.Rows(3)("Total")
                End If
                If dtAccDetail.Rows.Count > 4 Then
                    Size5 = dtAccDetail.Rows(4)("Size")
                    dtS5 = dtAccDetail.Rows(4)("Total")
                End If
                If dtAccDetail.Rows.Count > 5 Then
                    Size6 = dtAccDetail.Rows(5)("Size")
                    dtS6 = dtAccDetail.Rows(5)("Total")
                End If
                If dtAccDetail.Rows.Count > 6 Then
                    Size7 = dtAccDetail.Rows(6)("Size")
                    dtS7 = dtAccDetail.Rows(6)("Total")
                End If
                If dtAccDetail.Rows.Count > 7 Then
                    Size8 = dtAccDetail.Rows(7)("Size")
                    dtS8 = dtAccDetail.Rows(7)("Total")
                End If
                If dtAccDetail.Rows.Count > 8 Then
                    Size9 = dtAccDetail.Rows(8)("Size")
                    dtS9 = dtAccDetail.Rows(8)("Total")
                End If
                If dtAccDetail.Rows.Count > 9 Then
                    Size10 = dtAccDetail.Rows(9)("Size")
                    dtS10 = dtAccDetail.Rows(9)("Total")
                End If
                If dtAccDetail.Rows.Count > 10 Then
                    Size11 = dtAccDetail.Rows(10)("Size")
                    dtS11 = dtAccDetail.Rows(10)("Total")
                End If
                Dr = dtFinal.NewRow()
                Dr("TempId") = 0
                Dr("Style") = Style
                Dr("Description") = Description
                Dr("Color") = Color
                Dr("Qty") = Quantity
                Dr("Price") = Price
                Dr("Amount") = Amount
                Dr("SRNO") = SRNO
                Dr("ArtNo") = ArtNo
                Dr("ShipmentDate") = ShipmentDate
                Dr("DPIMstID") = DPIMstID
                Dr("Type") = Type
                Dr("ColorCode") = ColorCode
                If dtS1 = 0 Then
                    Dr("S1") = "0"
                Else
                    Dr("S1") = dtS1
                End If
                If dtS2 = 0 Then
                    Dr("S2") = "0"
                Else
                    Dr("S2") = dtS2
                End If
                If dtS3 = 0 Then
                    Dr("S3") = "0"
                Else
                    Dr("S3") = dtS3
                End If
                If dtS4 = 0 Then
                    Dr("S4") = "0"
                Else
                    Dr("S4") = dtS4
                End If
                If dtS5 = 0 Then
                    Dr("S5") = "0"
                Else
                    Dr("S5") = dtS5
                End If
                If dtS6 = 0 Then
                    Dr("S6") = "0"
                Else
                    Dr("S6") = dtS6
                End If
                If dtS7 = 0 Then
                    Dr("S7") = "0"
                Else
                    Dr("S7") = dtS7
                End If
                If dtS8 = 0 Then
                    Dr("S8") = "0"
                Else
                    Dr("S8") = dtS8
                End If
                If dtS9 = 0 Then
                    Dr("S9") = "0"
                Else
                    Dr("S9") = dtS9
                End If
                If dtS10 = 0 Then
                    Dr("S10") = "0"
                Else
                    Dr("S10") = dtS10
                End If
                If dtS11 = 0 Then
                    Dr("S11") = "0"
                Else
                    Dr("S11") = dtS11
                End If
                dtFinal.Rows.Add(Dr)
                For A As Integer = 0 To dtFinal.Rows.Count - 1
                    With objTempPIOne
                        .TempId = 0
                        .Style = dtFinal.Rows(A)("Style")
                        .Description = dtFinal.Rows(A)("Description")
                        .Color = dtFinal.Rows(A)("Color")
                        .Qty = dtFinal.Rows(A)("Qty")
                        .Price = dtFinal.Rows(A)("Price")
                        .Amount = dtFinal.Rows(A)("Amount")
                        .S1 = dtFinal.Rows(A)("S1")
                        .S2 = dtFinal.Rows(A)("S2")
                        .S3 = dtFinal.Rows(A)("S3")
                        .S4 = dtFinal.Rows(A)("S4")
                        .S5 = dtFinal.Rows(A)("S5")
                        .S6 = dtFinal.Rows(A)("S6")
                        .S7 = dtFinal.Rows(A)("S7")
                        .S8 = dtFinal.Rows(A)("S8")
                        .S9 = dtFinal.Rows(A)("S9")
                        .S10 = dtFinal.Rows(A)("S10")
                        .S11 = dtFinal.Rows(A)("S11")
                        .SRNO = dtFinal.Rows(A)("SRNO")
                        .Model = dtFinal.Rows(A)("ArtNo")
                        .StyleShipmentDate = dtFinal.Rows(A)("ShipmentDate")
                        .DPIMstID = dtFinal.Rows(A)("DPIMstID")
                        .Type = dtFinal.Rows(A)("Type")
                        .ColorCode = dtFinal.Rows(A)("ColorCode")
                        .Savetemp()
                    End With
                Next
                Dim Size12, Size22, Size32, Size42, Size52, Size62, Size72, Size82, Size92, Size102, Size112 As String
                Dim Style2, Description2, SRNO2, ArtNo2, ShipmentDate2 As String
                Dim Color2, Type2, ColorCode2 As String
                Dim Quantity2 As Decimal = 0
                Dim Price2 As Decimal = 0
                Dim Amount2 As Decimal = 0
                Dim dtS12 As Decimal = 0
                Dim dtS22 As Decimal = 0
                Dim dtS32 As Decimal = 0
                Dim dtS42 As Decimal = 0
                Dim dtS52 As Decimal = 0
                Dim dtS62 As Decimal = 0
                Dim dtS72 As Decimal = 0
                Dim dtS82 As Decimal = 0
                Dim dtS92 As Decimal = 0
                Dim dtS102 As Decimal = 0
                Dim dtS112 As Decimal = 0
                Dim dtFinal2 = New DataTable
                objTempAccCheckListSize.TruncateTablePISecond()
                With dtFinal2
                    .Columns.Add("TempId", GetType(Long))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("Description", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("ArtNo", GetType(String))
                    .Columns.Add("ShipmentDate", GetType(String))
                    .Columns.Add("S1", GetType(String))
                    .Columns.Add("S2", GetType(String))
                    .Columns.Add("S3", GetType(String))
                    .Columns.Add("S4", GetType(String))
                    .Columns.Add("S5", GetType(String))
                    .Columns.Add("S6", GetType(String))
                    .Columns.Add("S7", GetType(String))
                    .Columns.Add("S8", GetType(String))
                    .Columns.Add("S9", GetType(String))
                    .Columns.Add("S10", GetType(String))
                    .Columns.Add("S11", GetType(String))
                    .Columns.Add("Qty", GetType(String))
                    .Columns.Add("Price", GetType(String))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("DPIMstID", GetType(Long))
                    .Columns.Add("Type", GetType(String))
                    .Columns.Add("ColorCode", GetType(String))
                End With
                dtAccDetail = objAccCheckListMst.GetSizeForPI(dtMain.Rows(1)("JobOrderDetailid"))
                Dim DtExtraQTYy As DataTable = objAccCheckListMst.GetExtraQtyForPI(dtMain.Rows(1)("JobOrderDetailid"))
                Style2 = dtAccDetail.Rows(1)("Style")
                Description2 = dtAccDetail.Rows(1)("ItemDesc")
                Color2 = dtAccDetail.Rows(1)("BuyerColor")
                Quantity2 = dtAccDetail.Rows(1)("Quantity") + Val(DtExtraQTYy.Rows(0)("ExtraQty"))
                Price2 = dtAccDetail.Rows(1)("UnitPrice")
                SRNO2 = dtAccDetail.Rows(1)("CustomerOrder")
                ArtNo2 = dtAccDetail.Rows(1)("Model")
                ShipmentDate2 = dtAccDetail.Rows(1)("StyleShipmentDate")
                Type2 = dtAccDetail.Rows(1)("Breakup")
                ColorCode2 = dtAccDetail.Rows(1)("ColorCode")
                Amount2 = Val(dtAccDetail.Rows(1)("Quantity")) * Val(dtAccDetail.Rows(0)("UnitPrice"))
                If dtAccDetail.Rows.Count > 0 Then
                    Size12 = dtAccDetail.Rows(0)("Size")
                    dtS12 = dtAccDetail.Rows(0)("Total")
                End If
                If dtAccDetail.Rows.Count > 1 Then
                    Size22 = dtAccDetail.Rows(1)("Size")
                    dtS22 = dtAccDetail.Rows(1)("Total")
                End If
                If dtAccDetail.Rows.Count > 2 Then
                    Size32 = dtAccDetail.Rows(2)("Size")
                    dtS32 = dtAccDetail.Rows(2)("Total")
                End If
                If dtAccDetail.Rows.Count > 3 Then
                    Size42 = dtAccDetail.Rows(3)("Size")
                    dtS42 = dtAccDetail.Rows(3)("Total")
                End If
                If dtAccDetail.Rows.Count > 4 Then
                    Size52 = dtAccDetail.Rows(4)("Size")
                    dtS52 = dtAccDetail.Rows(4)("Total")
                End If
                If dtAccDetail.Rows.Count > 5 Then
                    Size62 = dtAccDetail.Rows(5)("Size")
                    dtS62 = dtAccDetail.Rows(5)("Total")
                End If
                If dtAccDetail.Rows.Count > 6 Then
                    Size72 = dtAccDetail.Rows(6)("Size")
                    dtS72 = dtAccDetail.Rows(6)("Total")
                End If
                If dtAccDetail.Rows.Count > 7 Then
                    Size82 = dtAccDetail.Rows(7)("Size")
                    dtS82 = dtAccDetail.Rows(7)("Total")
                End If
                If dtAccDetail.Rows.Count > 8 Then
                    Size92 = dtAccDetail.Rows(8)("Size")
                    dtS92 = dtAccDetail.Rows(8)("Total")
                End If
                If dtAccDetail.Rows.Count > 9 Then
                    Size102 = dtAccDetail.Rows(9)("Size")
                    dtS102 = dtAccDetail.Rows(9)("Total")
                End If
                If dtAccDetail.Rows.Count > 10 Then
                    Size112 = dtAccDetail.Rows(10)("Size")
                    dtS112 = dtAccDetail.Rows(10)("Total")
                End If
                Dr = dtFinal2.NewRow()
                Dr("TempId") = 0
                Dr("Style") = Style2
                Dr("Description") = Description2
                Dr("Color") = Color2
                Dr("Qty") = Quantity2
                Dr("Price") = Price2
                Dr("Amount") = Amount2
                Dr("SRNO") = SRNO2
                Dr("ArtNo") = ArtNo2
                Dr("ShipmentDate") = ShipmentDate2
                Dr("Type") = Type2
                Dr("DPIMstID") = DPIMstID
                Dr("ColorCode") = ColorCode2
                If dtS12 = 0 Then
                    Dr("S1") = "0"
                Else
                    Dr("S1") = dtS12
                End If
                If dtS22 = 0 Then
                    Dr("S2") = "0"
                Else
                    Dr("S2") = dtS22
                End If
                If dtS32 = 0 Then
                    Dr("S3") = "0"
                Else
                    Dr("S3") = dtS32
                End If
                If dtS42 = 0 Then
                    Dr("S4") = "0"
                Else
                    Dr("S4") = dtS42
                End If
                If dtS52 = 0 Then
                    Dr("S5") = "0"
                Else
                    Dr("S5") = dtS52
                End If
                If dtS62 = 0 Then
                    Dr("S6") = "0"
                Else
                    Dr("S6") = dtS62
                End If
                If dtS72 = 0 Then
                    Dr("S7") = "0"
                Else
                    Dr("S7") = dtS72
                End If
                If dtS82 = 0 Then
                    Dr("S8") = "0"
                Else
                    Dr("S8") = dtS82
                End If
                If dtS92 = 0 Then
                    Dr("S9") = "0"
                Else
                    Dr("S9") = dtS92
                End If
                If dtS102 = 0 Then
                    Dr("S10") = "0"
                Else
                    Dr("S10") = dtS102
                End If
                If dtS112 = 0 Then
                    Dr("S11") = "0"
                Else
                    Dr("S11") = dtS112
                End If
                dtFinal2.Rows.Add(Dr)
                For A As Integer = 0 To dtFinal2.Rows.Count - 1
                    With objTempPISecond
                        .TempId = 0
                        .Style = dtFinal2.Rows(A)("Style")
                        .Description = dtFinal2.Rows(A)("Description")
                        .Color = dtFinal2.Rows(A)("Color")
                        .Qty = dtFinal2.Rows(A)("Qty")
                        .Price = dtFinal2.Rows(A)("Price")
                        .Amount = dtFinal2.Rows(A)("Amount")
                        .S1 = dtFinal2.Rows(A)("S1")
                        .S2 = dtFinal2.Rows(A)("S2")
                        .S3 = dtFinal2.Rows(A)("S3")
                        .S4 = dtFinal2.Rows(A)("S4")
                        .S5 = dtFinal2.Rows(A)("S5")
                        .S6 = dtFinal2.Rows(A)("S6")
                        .S7 = dtFinal2.Rows(A)("S7")
                        .S8 = dtFinal2.Rows(A)("S8")
                        .S9 = dtFinal2.Rows(A)("S9")
                        .S10 = dtFinal2.Rows(A)("S10")
                        .S11 = dtFinal2.Rows(A)("S11")
                        .SRNO = dtFinal2.Rows(A)("SRNO")
                        .Model = dtFinal2.Rows(A)("ArtNo")
                        .StyleShipmentDate = dtFinal2.Rows(A)("ShipmentDate")
                        .DPIMstID = dtFinal2.Rows(A)("DPIMstID")
                        .Type = dtFinal2.Rows(A)("Type")
                        .ColorCode = dtFinal2.Rows(A)("ColorCode")
                        .Savetemp()
                    End With
                Next
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/PILolaLizaSecond.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PROFORMAINVOICE"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue(0, Size1)
                Report.SetParameterValue(1, Size2)
                Report.SetParameterValue(2, Size3)
                Report.SetParameterValue(3, Size4)
                Report.SetParameterValue(4, Size5)
                Report.SetParameterValue(5, Size6)
                Report.SetParameterValue(6, Size7)
                Report.SetParameterValue(7, Size8)
                Report.SetParameterValue(8, Size9)
                Report.SetParameterValue(9, Size10)
                Report.SetParameterValue(10, Size11)
                Report.SetParameterValue(11, Size12)
                Report.SetParameterValue(12, Size22)
                Report.SetParameterValue(13, Size32)
                Report.SetParameterValue(14, Size42)
                Report.SetParameterValue(15, Size52)
                Report.SetParameterValue(16, Size62)
                Report.SetParameterValue(17, Size72)
                Report.SetParameterValue(18, Size82)
                Report.SetParameterValue(19, Size92)
                Report.SetParameterValue(20, Size102)
                Report.SetParameterValue(21, Size112)


                Dim GrandTotal1 As Decimal = 0
                Dim GrandTotal2 As Decimal = 0
                Dim GrandTotal3 As Decimal = 0
                Dim GrandTotal4 As Decimal = 0
                Dim GrandTotal5 As Decimal = 0
                Dim GrandTotal6 As Decimal = 0
                Dim GrandTotal7 As Decimal = 0
                Dim GrandTotal8 As Decimal = 0
                Dim GrandTotal9 As Decimal = 0
                Dim GrandTotal10 As Decimal = 0
                Dim GrandTotal11 As Decimal = 0
                Dim GrandTotalQty As Decimal = 0
                Dim GrandTotalAmount As Decimal = 0
                GrandTotal1 = Val(dtS1) + Val(dtS12)
                GrandTotal2 = Val(dtS2) + Val(dtS22)
                GrandTotal3 = Val(dtS3) + Val(dtS32)
                GrandTotal4 = Val(dtS4) + Val(dtS42)
                GrandTotal5 = Val(dtS5) + Val(dtS52)
                GrandTotal6 = Val(dtS6) + Val(dtS62)
                GrandTotal7 = Val(dtS7) + Val(dtS72)
                GrandTotal8 = Val(dtS8) + Val(dtS82)
                GrandTotal9 = Val(dtS9) + Val(dtS92)
                GrandTotal10 = Val(dtS10) + Val(dtS102)
                GrandTotal11 = Val(dtS11) + Val(dtS112)
                GrandTotalQty = Val(dtFinal.Rows(0)("Qty")) + Val(dtFinal2.Rows(0)("Qty"))
                GrandTotalAmount = Val(dtFinal.Rows(0)("Amount")) + Val(dtFinal2.Rows(0)("Amount"))
                Report.SetParameterValue(22, GrandTotal1)
                Report.SetParameterValue(23, GrandTotal2)
                Report.SetParameterValue(24, GrandTotal3)
                Report.SetParameterValue(25, GrandTotal4)
                Report.SetParameterValue(26, GrandTotal5)
                Report.SetParameterValue(27, GrandTotal6)
                Report.SetParameterValue(28, GrandTotal7)
                Report.SetParameterValue(29, GrandTotal8)
                Report.SetParameterValue(30, GrandTotal9)
                Report.SetParameterValue(31, GrandTotal10)
                Report.SetParameterValue(32, GrandTotal11)
                Report.SetParameterValue(33, GrandTotalQty)
                Report.SetParameterValue(34, GrandTotalAmount)
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
            End If
        Next
    End Sub
End Class
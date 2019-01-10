Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Xml
Public Class CargoReleaseView
    Inherits System.Web.UI.Page
    Dim objCargo As New Cargo
    Dim UserID, RoleID As Long
    Dim Dr As DataRow
    Dim objTempSizeWeightList As New TempSizeWeightList
    Dim objAccCheckListMst As New AccCheckListMst
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Response.Expires = 0
        Dim objDataView As DataView
        UserID = CLng(Session("UserID"))
        RoleID = Session("RoleId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
            If CLng(Session("Userid")) = 26 Then
                Button1.Visible = True
            Else
                Button1.Visible = False
            End If
        End If
        PageHeader("Shipment Release")
    End Sub
  Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgCagro.Visible = True
                strSortExpression = dgCagro.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgCagro.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgCagro.RecordCount = objDataView.Count
                dgCagro.DataSource = objDataView
                dgCagro.DataBind()
            Else
                dgCagro.Visible = False
            End If
            Dim x As Long
            For x = 0 To dgCagro.Items.Count - 1
                Dim lnkPDFSales As ImageButton = CType(dgCagro.Items(x).FindControl("lnkPDFSales"), ImageButton)
                Dim tblJVMstId = dgCagro.Items(x).Cells(12).Text
                If tblJVMstId > 0 Then
                    lnkPDFSales.Visible = True
                Else
                    lnkPDFSales.Visible = False
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub POPDFNew(ByVal lCargoID As Long)
        Dim POID As Long
        Dim dtFinal = New DataTable
        objAccCheckListMst.TruncateTableSizeList()
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("RowType", GetType(String))
            .Columns.Add("RowNo", GetType(String))
            .Columns.Add("Color", GetType(String))
            .Columns.Add("Style", GetType(String))
            .Columns.Add("SizeRangeID", GetType(String))
            .Columns.Add("JobOrderId", GetType(String))
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
            .Columns.Add("TotalQTY", GetType(String))
        End With
        Dim dtMain As DataTable = objTempSizeWeightList.GetJobOrderId(lCargoID)
        Dim Z As Integer
        For Z = 0 To dtMain.Rows.Count - 1
            Dim lPOID As Long = dtMain.Rows(Z)("POPOID")
            Dim dtColor As DataTable = objTempSizeWeightList.GetALLPODetailDataDistinctColor(lPOID)
            If dtColor.Rows.Count > 0 Then
                Dim TotalQTY As Decimal = 0
                Dim CC As Integer = 0
                For CC = 0 To dtColor.Rows.Count - 1
                    Dim dtsize As DataTable = objTempSizeWeightList.GetALLPOData(lPOID, dtColor.Rows(CC)("Color"), dtColor.Rows(CC)("SizeRangeID"))
                    POID = dtsize.Rows(0)("JobOrderID")
                    Dim Count As Integer = 0
                    Count = dtsize.Rows.Count
                    If dtsize.Rows.Count > 0 Then
                        TotalQTY = Convert.ToInt32(dtsize.Compute("SUM(WeightNew)", String.Empty))
                        Dr = dtFinal.NewRow()
                        Dr("TempId") = 0
                        Dr("RowType") = "Size"
                        Dr("RowNo") = "1"
                        Dr("Color") = dtsize.Rows(0)("BuyerColor")
                        Dr("Style") = dtsize.Rows(0)("Style")
                        Dr("SizeRangeID") = dtsize.Rows(0)("SizeRangeID")
                        Dr("JobOrderID") = dtsize.Rows(0)("JobOrderID")
                        If Count > 1 Or Count = 1 Then
                            Dr("S1") = dtsize.Rows(0)("Size")
                        Else
                            Dr("S1") = ""
                        End If
                        If Count > 2 Or Count = 2 Then
                            Dr("S2") = dtsize.Rows(1)("Size")
                        Else
                            Dr("S2") = ""
                        End If
                        If Count > 3 Or Count = 3 Then
                            Dr("S3") = dtsize.Rows(2)("Size")
                        Else
                            Dr("S3") = ""
                        End If
                        If Count > 4 Or Count = 4 Then
                            Dr("S4") = dtsize.Rows(3)("Size")
                        Else
                            Dr("S4") = ""
                        End If
                        If Count > 5 Or Count = 5 Then
                            Dr("S5") = dtsize.Rows(4)("Size")
                        Else
                            Dr("S5") = ""
                        End If
                        If Count > 6 Or Count = 6 Then
                            Dr("S6") = dtsize.Rows(5)("Size")
                        Else
                            Dr("S6") = ""
                        End If
                        If Count > 7 Or Count = 7 Then
                            Dr("S7") = dtsize.Rows(6)("Size")
                        Else
                            Dr("S7") = ""
                        End If
                        If Count > 8 Or Count = 8 Then
                            Dr("S8") = dtsize.Rows(7)("Size")
                        Else
                            Dr("S8") = ""
                        End If
                        If Count > 9 Or Count = 9 Then
                            Dr("S9") = dtsize.Rows(8)("Size")
                        Else
                            Dr("S9") = ""
                        End If
                        If Count > 10 Or Count = 10 Then
                            Dr("S10") = dtsize.Rows(9)("Size")
                        Else
                            Dr("S10") = ""
                        End If
                        If Count > 11 Or Count = 11 Then
                            Dr("S11") = dtsize.Rows(10)("Size")
                        Else
                            Dr("S11") = ""
                        End If
                        Dr("TotalQTY") = 0
                        dtFinal.Rows.Add(Dr)
                        Dr = dtFinal.NewRow()
                        Dr("TempId") = 0
                        Dr("RowType") = "Weight"
                        Dr("RowNo") = "2"
                        Dr("Color") = dtsize.Rows(0)("BuyerColor")
                        Dr("Style") = dtsize.Rows(0)("Style")
                        Dr("SizeRangeID") = dtsize.Rows(0)("SizeRangeID")
                        Dr("JobOrderID") = dtsize.Rows(0)("JobOrderID")
                        If Count > 1 Or Count = 1 Then
                            Dr("S1") = dtsize.Rows(0)("WeightNew")
                        Else
                            Dr("S1") = ""
                        End If
                        If Count > 2 Or Count = 2 Then
                            Dr("S2") = dtsize.Rows(1)("WeightNew")
                        Else
                            Dr("S2") = ""
                        End If
                        If Count > 3 Or Count = 3 Then
                            Dr("S3") = dtsize.Rows(2)("WeightNew")
                        Else
                            Dr("S3") = ""
                        End If
                        If Count > 4 Or Count = 4 Then
                            Dr("S4") = dtsize.Rows(3)("WeightNew")
                        Else
                            Dr("S4") = ""
                        End If
                        If Count > 5 Or Count = 5 Then
                            Dr("S5") = dtsize.Rows(4)("WeightNew")
                        Else
                            Dr("S5") = ""
                        End If
                        If Count > 6 Or Count = 6 Then
                            Dr("S6") = dtsize.Rows(5)("WeightNew")
                        Else
                            Dr("S6") = ""
                        End If
                        If Count > 7 Or Count = 7 Then
                            Dr("S7") = dtsize.Rows(6)("WeightNew")
                        Else
                            Dr("S7") = ""
                        End If
                        If Count > 8 Or Count = 8 Then
                            Dr("S8") = dtsize.Rows(7)("WeightNew")
                        Else
                            Dr("S8") = ""
                        End If
                        If Count > 9 Or Count = 9 Then
                            Dr("S9") = dtsize.Rows(8)("WeightNew")
                        Else
                            Dr("S9") = ""
                        End If
                        If Count > 10 Or Count = 10 Then
                            Dr("S10") = dtsize.Rows(9)("WeightNew")
                        Else
                            Dr("S10") = ""
                        End If
                        If Count > 11 Or Count = 11 Then
                            Dr("S11") = dtsize.Rows(10)("WeightNew")
                        Else
                            Dr("S11") = ""
                        End If
                        Dr("TotalQTY") = TotalQTY
                        dtFinal.Rows.Add(Dr)
                    End If
                Next
            End If
        Next
        Session("dtFinal") = dtFinal
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objTempSizeWeightList
                .TempId = 0
                .RowType = dtFinal.Rows(A)("RowType")
                .RowNo = dtFinal.Rows(A)("RowNo")
                .Color = dtFinal.Rows(A)("Color")
                .Style = dtFinal.Rows(A)("Style")
                .SizeRangeID = dtFinal.Rows(A)("SizeRangeID")
                .JobOrderID = dtFinal.Rows(A)("JobOrderId")
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
                .TotalQTY = dtFinal.Rows(A)("TotalQTY")
                .Savetemp()
            End With
        Next
    End Sub
    Protected Sub dgCagro_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCagro.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "PDF"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/InpectionCertificateRpt.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "InspectionCertificate"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, CargoID)
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
                Case Is = "PDFF"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/CustomInvoiceNewww.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "CustomInvoice"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, CargoID)
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
                Case Is = "PDFFF"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/CommercialInvoice.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "CommercialInvoice"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, CargoID)
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
                Case Is = "PDFFFF"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    POPDFNew(CargoID)
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/CustomPackingList.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "CustomPackingList"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, CargoID)
                    Report.SetParameterValue(1, CargoID)
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
                Case Is = "SVPDF"
                    Dim tblJVMstId As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(12).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/SalesVoucher.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "SalesVoucher"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, tblJVMstId)
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
                Case Is = "SVOUCHER"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("~/Accounts/SVEntry.aspx?lcargorId=" & CargoID & "")
                Case "Con"
                    Dim JobOrderID As Long = dgCagro.Items(e.Item.ItemIndex).Cells(16).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ConsumptionEntry.aspx?JobOrderID=" & JobOrderID & "")
                Case Is = "ConPDF"
                    Dim JobOrderID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(16).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/ShipmentSchedule.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "ConsumptionEntry"
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
                Case "ExportDocument"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("CargoStyleDescription.aspx?CargoID=" & CargoID & "")
                Case "Certificate"
                    Dim CargoID As Integer = dgCagro.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ExportDashBoard.aspx?CargoID=" & CargoID & "")
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCargo.GetCargoinfoNewMaxFieldsLatestMangemnetNewForDigital
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Session("dtArticle") = Nothing
        Session("dtSelection") = Nothing
        Response.Redirect("CargoReleaseNew.aspx")
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim objDataView As DataView
        Try
            objDataView = LoadDataSearch()
            Session("objDataView") = objDataView
            BindGrid()
        Catch objUDException As UDException
        End Try
    End Sub
    Function LoadDataSearch() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCargo.GetCargoinfoSearch(txtInvoiceNo.Text)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt, dtcargodetail As New DataTable
            Dim x, y As Integer
            Dim ObjCragodetail As New CargoDetail
            dt = objCargo.GetCargoinfoNewMaxFieldsLatest
            For x = 0 To dt.Rows.Count - 1
                dtcargodetail = ObjCragodetail.Getalldata(dt.Rows(x)("Cargoid"))
                If dtcargodetail.Rows.Count = 1 Then
                    objCargo.UpdateCurrency(dt.Rows(x)("Cargoid"), dtcargodetail.Rows(0)("currency"))
                Else
                    objCargo.UpdateCurrency(dt.Rows(x)("Cargoid"), "NoCurrency")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnMoreSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoreSearch.Click
        Try
            Response.Redirect("CargoReleaseSearch.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtInvoiceNo.TextChanged
        Try
            Dim objDataView As DataView
            If txtInvoiceNo.Text <> "" Then
                objDataView = LoadDataSearch()
                Session("objDataView") = objDataView
                BindGrid()
            Else
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
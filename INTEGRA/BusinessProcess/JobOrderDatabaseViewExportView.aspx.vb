Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.DataView
Public Class JobOrderDatabaseViewExportView
    Inherits System.Web.UI.Page
    Dim objTempZipperCheckListSize As New TempZipperCheckListSize
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim UserID, Roleid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objAccCheckListMst As New AccCheckListMst
    Dim Dr As DataRow
    Dim objTempSizeWeightList As New TempSizeWeightList
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserID = CLng(Session("Userid"))
        Roleid = CLng(Session("RoleId"))
        If Not Page.IsPostBack Then
            Try
                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    dgViewMaster.Columns(13).Visible = False
                    dgViewMaster.Columns(14).Visible = False
                    dgViewMaster.Columns(15).Visible = False
                    dgViewMaster.Columns(16).Visible = False
                    dgViewMaster.Columns(17).Visible = False
                    dgViewMaster.Columns(18).Visible = False
                    dgViewMaster.Columns(19).Visible = False
                    dgViewMaster.Columns(20).Visible = False
                    dgViewMaster.Columns(21).Visible = False
                    dgViewMaster.Columns(22).Visible = False
                    dgViewMaster.Columns(23).Visible = False
                    dgViewMaster.Columns(24).Visible = False
                    dgViewMaster.Columns(27).Visible = False
                    dgViewMaster.Columns(28).Visible = False
                    dgViewMaster.Columns(29).Visible = False
                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                     btnDetailSection.Visible = False
                    btndAdd.Visible = False
                    dgViewMaster.Columns(13).Visible = False
                    dgViewMaster.Columns(14).Visible = False
                    dgViewMaster.Columns(15).Visible = False
                    dgViewMaster.Columns(16).Visible = False
                    dgViewMaster.Columns(17).Visible = False
                    dgViewMaster.Columns(18).Visible = False
                    dgViewMaster.Columns(19).Visible = False
                    dgViewMaster.Columns(20).Visible = False
                    dgViewMaster.Columns(21).Visible = False
                    dgViewMaster.Columns(22).Visible = False
                    dgViewMaster.Columns(23).Visible = False
                    dgViewMaster.Columns(24).Visible = False
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        btnDetailSection.Visible = False
                        btndAdd.Visible = False
                        dgViewMaster.Columns(13).Visible = False
                        dgViewMaster.Columns(14).Visible = False
                        dgViewMaster.Columns(15).Visible = False
                        dgViewMaster.Columns(16).Visible = False
                        dgViewMaster.Columns(17).Visible = False
                        dgViewMaster.Columns(18).Visible = False
                        dgViewMaster.Columns(19).Visible = False
                        dgViewMaster.Columns(20).Visible = False
                        dgViewMaster.Columns(21).Visible = False
                        dgViewMaster.Columns(22).Visible = False
                        dgViewMaster.Columns(23).Visible = False
                        dgViewMaster.Columns(24).Visible = False
                    ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                        dgViewMaster.Columns(13).Visible = False
                        dgViewMaster.Columns(14).Visible = False
                        dgViewMaster.Columns(15).Visible = False
                        dgViewMaster.Columns(16).Visible = False
                        dgViewMaster.Columns(17).Visible = False
                        dgViewMaster.Columns(18).Visible = False
                        dgViewMaster.Columns(19).Visible = False
                        dgViewMaster.Columns(20).Visible = False
                        dgViewMaster.Columns(21).Visible = False
                        dgViewMaster.Columns(22).Visible = False
                        dgViewMaster.Columns(23).Visible = False
                        dgViewMaster.Columns(24).Visible = False
                        dgViewMaster.Columns(27).Visible = False
                        dgViewMaster.Columns(28).Visible = False
                        dgViewMaster.Columns(29).Visible = False
                    ElseIf DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        dgViewMaster.Columns(13).Visible = False
                        dgViewMaster.Columns(14).Visible = False
                        dgViewMaster.Columns(15).Visible = False
                        dgViewMaster.Columns(16).Visible = False
                        dgViewMaster.Columns(17).Visible = False
                        dgViewMaster.Columns(18).Visible = False
                        dgViewMaster.Columns(19).Visible = False
                        dgViewMaster.Columns(20).Visible = False
                        dgViewMaster.Columns(21).Visible = False
                        dgViewMaster.Columns(22).Visible = False
                        dgViewMaster.Columns(23).Visible = False
                        dgViewMaster.Columns(24).Visible = False
                        dgViewMaster.Columns(27).Visible = False
                        dgViewMaster.Columns(28).Visible = False
                        dgViewMaster.Columns(29).Visible = False
                        dgViewMaster.Columns(25).Visible = False
                    End If
                End If
                BinSeason()
                Session("DtSummarytable") = Nothing
                objMasterDataView = LoadMasterData()
                Session("objMasterDataView") = objMasterDataView
                BindMasterGrid()
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                If Roleid = 40 Then
                    ProductionHide()
                End If
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
            btndAdd.Visible = False
            dgViewMaster.Columns(12).Visible = False
            dgViewMaster.Columns(13).Visible = False
            dgViewMaster.Columns(14).Visible = False
            dgViewMaster.Columns(15).Visible = False
            dgViewMaster.Columns(16).Visible = False
            dgViewMaster.Columns(17).Visible = False
            dgViewMaster.Columns(19).Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
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
            Dim ChkMove As CheckBox = CType(dgViewMaster.Items(x).FindControl("ChkShipmentStatus"), CheckBox)
            Dim lnkSizeWeightPDF As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkSizeWeightPDF"), ImageButton)
            Dim lnkSizeWeight As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkSizeWeight"), ImageButton)
            Dim lJobOrderId = dgViewMaster.Items(x).Cells(0).Text
            Dim Status As String = dgViewMaster.Items(x).Cells(28).Text
            If Status = 1 Then
                ChkMove.Checked = True
            Else
                ChkMove.Checked = False
            End If
            Dim dtNum As DataTable = objJobOrderdatabase.CheckNumbering(lJobOrderId)
            If dtNum.Rows.Count > 0 Then
                lnkSizeWeightPDF.Visible = True
            Else
                lnkSizeWeightPDF.Visible = False
            End If
            Dim dtAssortment As DataTable = objJobOrderdatabase.CheckAssortmentData(lJobOrderId)
            If dtAssortment.Rows.Count > 0 Then
                lnkSizeWeight.Visible = True
            Else
                lnkSizeWeight.Visible = False
            End If
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
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dgViewMaster.Columns(13).Visible = False
            dgViewMaster.Columns(14).Visible = False
            dgViewMaster.Columns(15).Visible = False
            dgViewMaster.Columns(16).Visible = False
            dgViewMaster.Columns(17).Visible = False
            dgViewMaster.Columns(18).Visible = False
            dgViewMaster.Columns(19).Visible = False
            dgViewMaster.Columns(20).Visible = False
            dgViewMaster.Columns(21).Visible = False
            dgViewMaster.Columns(22).Visible = False
            dgViewMaster.Columns(23).Visible = False
            dgViewMaster.Columns(24).Visible = False
            dgViewMaster.Columns(27).Visible = False
            dgViewMaster.Columns(28).Visible = False
            dgViewMaster.Columns(29).Visible = False
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
             btnDetailSection.Visible = False
            btndAdd.Visible = False
            dgViewMaster.Columns(24).Visible = False
            dgViewMaster.Columns(13).Visible = False
            dgViewMaster.Columns(14).Visible = False
            dgViewMaster.Columns(15).Visible = False
            dgViewMaster.Columns(16).Visible = False
            dgViewMaster.Columns(17).Visible = False
            dgViewMaster.Columns(18).Visible = False
            dgViewMaster.Columns(19).Visible = False
            dgViewMaster.Columns(20).Visible = False
            dgViewMaster.Columns(21).Visible = False
            dgViewMaster.Columns(22).Visible = False
            dgViewMaster.Columns(23).Visible = False
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Then
                btnDetailSection.Visible = False
                btndAdd.Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(27).Visible = False
                dgViewMaster.Columns(28).Visible = False
                dgViewMaster.Columns(29).Visible = False
            ElseIf DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(27).Visible = False
                dgViewMaster.Columns(28).Visible = False
                dgViewMaster.Columns(29).Visible = False
                dgViewMaster.Columns(25).Visible = False
            End If
        End If
    End Sub
    Function LoadMasterData() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2ForExportnEWWW()
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2ForExportnEWWW()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2ForExportnEWWW()
            Else
                dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNewnEWW(UserID)
            End If
        End If
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
        DtSummarytable.Columns.Add("ExtraQuantity", GetType(String))
        DtSummarytable.Columns.Add("ShipmentStatus", GetType(Byte))
        DtSummarytable.Columns.Add("InspectionDate", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")
                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMasterForExport(Joborderid)
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
                        Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                        dr("ExtraQuantity") = ExtraQty
                        dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                        dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMasterForExport(Joborderid)
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
                    Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                    dr("ExtraQuantity") = ExtraQty
                    dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                    dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
    Function LoadMasterDataForSearching() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingForExportfORnEWW(cmbSeason.SelectedItem.Text)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingForExportfORnEWW(cmbSeason.SelectedItem.Text)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingForExportfORnEWW(cmbSeason.SelectedItem.Text)
            Else
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingForExportYasir(UserID, cmbSeason.SelectedItem.Text)
            End If
        End If
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
        DtSummarytable.Columns.Add("ExtraQuantity", GetType(String))
        DtSummarytable.Columns.Add("ShipmentStatus", GetType(Byte))
        DtSummarytable.Columns.Add("InspectionDate", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")
                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMasterForSearchingForExport(Joborderid, cmbSeason.SelectedItem.Text)
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
                        Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                        dr("ExtraQuantity") = ExtraQty
                        dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                        dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMasterForSearchingForExport(Joborderid, cmbSeason.SelectedItem.Text)
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
                    Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                    dr("ExtraQuantity") = ExtraQty
                    dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                    dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
    Protected Sub dgViewMaster_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgViewMaster.ItemCommand
        Try
            Select Case e.CommandName
                Case "Copy"
                    Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim Type As String = "Copy"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?Joborderid=" & lJoborderid & " &Type=" & Type & "")
                Case "MILESTONE"
                    Dim StyleID As String = 0
                    Dim Joborderid As String = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("TNAChartView.aspx?JobOrderID=" & Joborderid & "&StyleID=" & StyleID & "")
                Case "ASSORT"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentView.aspx")
                Case "Edit"
                    Dim lJoborderid As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("JobOrderDatabaseEntry.aspx?Joborderid=" & lJoborderid & "")
                Case "Fabric"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("CostControlFb.aspx?JobOrderID=" & JobOrderID & "")
                Case "Accessoriese"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
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
                Case "Con"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        Response.Redirect("ConsumptionEntryExport.aspx?JobOrderID=" & JobOrderID & "")
                    ElseIf DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        Response.Redirect("ConsumptionEntry.aspx?JobOrderID=" & JobOrderID & "")
                    End If
                Case Is = "ConPDF"
                    Dim JobOrderID As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
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
                Case "SizeWeight"
                    Dim JobOrderID As Long = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("SizeWiseWeightList.aspx?JobOrderID=" & JobOrderID & "")
                Case Is = "SizeWeightPDF"
                    Dim JobOrderID As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Report.Load(Server.MapPath("..\Reports/NumberingBarcode.rpt"))
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "Bar_Code"
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
    Sub POPDFNew(ByVal lPOID As Long)
        Dim Style As String
        Dim CustomerName As String
        Dim CustomerOrder As String
        Dim Desc As String
        Dim FabricContent As String
        Dim Quantity As String
        Dim Color As String
        Dim POID As Long
        Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
        Dim dtS1, dtS2, dtS3, dtS4, dtS5, dtS6, dtS7, dtS8, dtS9, dtS10, dtS11 As DataTable
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
                    TotalQTY = Convert.ToInt32(dtsize.Compute("SUM(SizeWeight)", String.Empty))
                    Dr = dtFinal.NewRow()
                    Dr("TempId") = 0
                    Dr("RowType") = "Size"
                    Dr("RowNo") = "1"
                    Dr("Color") = dtsize.Rows(0)("Color")
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
                    '----Row 2
                    Dr = dtFinal.NewRow()
                    Dr("TempId") = 0
                    Dr("RowType") = "Weight"
                    Dr("RowNo") = "2"
                    Dr("Color") = dtsize.Rows(0)("Color")
                    Dr("Style") = dtsize.Rows(0)("Style")
                    Dr("SizeRangeID") = dtsize.Rows(0)("SizeRangeID")
                    Dr("JobOrderID") = dtsize.Rows(0)("JobOrderID")
                    If Count > 1 Or Count = 1 Then
                        Dr("S1") = dtsize.Rows(0)("SizeWeight")
                    Else
                        Dr("S1") = ""
                    End If
                    If Count > 2 Or Count = 2 Then
                        Dr("S2") = dtsize.Rows(1)("SizeWeight")
                    Else
                        Dr("S2") = ""
                    End If
                    If Count > 3 Or Count = 3 Then
                        Dr("S3") = dtsize.Rows(2)("SizeWeight")
                    Else
                        Dr("S3") = ""
                    End If
                    If Count > 4 Or Count = 4 Then
                        Dr("S4") = dtsize.Rows(3)("SizeWeight")
                    Else
                        Dr("S4") = ""
                    End If
                    If Count > 5 Or Count = 5 Then
                        Dr("S5") = dtsize.Rows(4)("SizeWeight")
                    Else
                        Dr("S5") = ""
                    End If
                    If Count > 6 Or Count = 6 Then
                        Dr("S6") = dtsize.Rows(5)("SizeWeight")
                    Else
                        Dr("S6") = ""
                    End If
                    If Count > 7 Or Count = 7 Then
                        Dr("S7") = dtsize.Rows(6)("SizeWeight")
                    Else
                        Dr("S7") = ""
                    End If
                    If Count > 8 Or Count = 8 Then
                        Dr("S8") = dtsize.Rows(7)("SizeWeight")
                    Else
                        Dr("S8") = ""
                    End If
                    If Count > 9 Or Count = 9 Then
                        Dr("S9") = dtsize.Rows(8)("SizeWeight")
                    Else
                        Dr("S9") = ""
                    End If
                    If Count > 10 Or Count = 10 Then
                        Dr("S10") = dtsize.Rows(9)("SizeWeight")
                    Else
                        Dr("S10") = ""
                    End If
                    If Count > 11 Or Count = 11 Then
                        Dr("S11") = dtsize.Rows(10)("SizeWeight")
                    Else
                        Dr("S11") = ""
                    End If
                    Dr("TotalQTY") = TotalQTY
                    dtFinal.Rows.Add(Dr)
                End If
            Next
        End If
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
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions
        Report.Load(Server.MapPath("..\Reports/SizeWeightReport.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "SizeWeightList"
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
        Dim path As String = (Server.MapPath("~/TempPDF") + "/" + FileName + ".pdf")
        Dim fs As FileStream = New FileStream(path, FileMode.Open)
        Dim fileSize As Long
        fileSize = fs.Length
        Dim Buffer() As Byte = New Byte((CType(fileSize, Integer)) - 1) {}
        fs.Read(Buffer, 0, CType(fs.Length, Integer))
        fs.Close()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", ("inline; filename=" + FileName))
        Response.BinaryWrite(Buffer)
        Response.Flush()
        Response.End()
    End Sub
    Protected Sub ShipmentStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Joborderid As Integer
        Dim x As Integer
        For x = 0 To dgViewMaster.Items.Count - 1
            Dim ChkShipmentStatus As CheckBox = CType(dgViewMaster.Items(x).FindControl("ChkShipmentStatus"), CheckBox)
            If ChkShipmentStatus.Checked = True Then
                Joborderid = dgViewMaster.Items(x).Cells(0).Text
                objJobOrderdatabase.UpdateShipmentStatus(Joborderid)
            Else
                Joborderid = dgViewMaster.Items(x).Cells(0).Text
                objJobOrderdatabase.UpdateShipmentStatusFalse(Joborderid)
            End If
        Next
        objMasterDataView = LoadMasterData()
        Session("objMasterDataView") = objMasterDataView
        BindMasterGrid()
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dgViewMaster.Columns(13).Visible = False
            dgViewMaster.Columns(14).Visible = False
            dgViewMaster.Columns(15).Visible = False
            dgViewMaster.Columns(16).Visible = False
            dgViewMaster.Columns(17).Visible = False
            dgViewMaster.Columns(18).Visible = False
            dgViewMaster.Columns(19).Visible = False
            dgViewMaster.Columns(20).Visible = False
            dgViewMaster.Columns(21).Visible = False
            dgViewMaster.Columns(22).Visible = False
            dgViewMaster.Columns(23).Visible = False
            dgViewMaster.Columns(24).Visible = False
            dgViewMaster.Columns(27).Visible = False
            dgViewMaster.Columns(28).Visible = False
            dgViewMaster.Columns(29).Visible = False
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            btnDetailSection.Visible = False
            btndAdd.Visible = False
            dgViewMaster.Columns(24).Visible = False
            dgViewMaster.Columns(13).Visible = False
            dgViewMaster.Columns(14).Visible = False
            dgViewMaster.Columns(15).Visible = False
            dgViewMaster.Columns(16).Visible = False
            dgViewMaster.Columns(17).Visible = False
            dgViewMaster.Columns(18).Visible = False
            dgViewMaster.Columns(19).Visible = False
            dgViewMaster.Columns(20).Visible = False
            dgViewMaster.Columns(21).Visible = False
            dgViewMaster.Columns(22).Visible = False
            dgViewMaster.Columns(23).Visible = False
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Then
                btnDetailSection.Visible = False
                btndAdd.Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(27).Visible = False
                dgViewMaster.Columns(28).Visible = False
                dgViewMaster.Columns(29).Visible = False
            ElseIf DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dgViewMaster.Columns(13).Visible = False
                dgViewMaster.Columns(14).Visible = False
                dgViewMaster.Columns(15).Visible = False
                dgViewMaster.Columns(16).Visible = False
                dgViewMaster.Columns(17).Visible = False
                dgViewMaster.Columns(18).Visible = False
                dgViewMaster.Columns(19).Visible = False
                dgViewMaster.Columns(20).Visible = False
                dgViewMaster.Columns(21).Visible = False
                dgViewMaster.Columns(22).Visible = False
                dgViewMaster.Columns(23).Visible = False
                dgViewMaster.Columns(24).Visible = False
                dgViewMaster.Columns(27).Visible = False
                dgViewMaster.Columns(28).Visible = False
                dgViewMaster.Columns(29).Visible = False
                dgViewMaster.Columns(25).Visible = False
            End If
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            objDataTable = objJobOrderdatabase.ViewNewForTFANewwwwwww()
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objJobOrderdatabase.ViewNewForTFANewwwwwww()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                objDataTable = objJobOrderdatabase.ViewNewForTFANewwwwwww()
            Else
                objDataTable = objJobOrderdatabase.ViewNewForTFAForLatest(UserID)
            End If
        End If
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
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoForlateast(245, txtSearch.Text)
            dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNewwwww(245, txtSearch.Text)
            dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleForNew(245, txtSearch.Text)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoForlateast(245, txtSearch.Text)
            dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNewwwww(245, txtSearch.Text)
            dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleForNew(245, txtSearch.Text)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
            If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoForlateast(245, txtSearch.Text)
                dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNewwwww(245, txtSearch.Text)
                dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleForNew(245, txtSearch.Text)
            Else
                dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoForlateast(UserID, txtSearch.Text)
                dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNewwwww(UserID, txtSearch.Text)
                dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleForNew(UserID, txtSearch.Text)
            End If
        End If
        If dtSummaryViewDataSR.Rows.Count > 0 Then
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONewww(txtSearch.Text)
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONewww(txtSearch.Text)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONewww(txtSearch.Text)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNO222(UserID, txtSearch.Text)
                End If
            End If
        ElseIf dtSummaryViewDataCS.Rows.Count > 0 Then
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerForNMewww(txtSearch.Text)
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerForNMewww(txtSearch.Text)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerForNMewww(txtSearch.Text)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomer2222(UserID, txtSearch.Text)
                End If
            End If
        ElseIf dtSummaryViewDataST.Rows.Count > 0 Then
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleForNew(245, txtSearch.Text)
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleForNew(245, txtSearch.Text)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleForNew(245, txtSearch.Text)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyle222(UserID, txtSearch.Text)
                End If
            End If
        Else
            If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForLatest(245)
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForLatest(245)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Or DtCheck.Rows(0)("Department") = "Fabric Store" Or DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForLatest(245)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFA222(UserID)
                End If
            End If
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
        DtSummarytable.Columns.Add("ExtraQuantity", GetType(String))
        DtSummarytable.Columns.Add("ShipmentStatus", GetType(Byte))
        DtSummarytable.Columns.Add("InspectionDate", GetType(String))
        If dtSummaryViewData.Rows.Count > 0 Then
            For i As Integer = 0 To dtSummaryViewData.Rows.Count - 1
                dr = DtSummarytable.NewRow()
                Dim Joborderid As Long = dtSummaryViewData.Rows(i)("Joborderid")
                Dim StyleV As String = dtSummaryViewData.Rows(i)("Style")
                If DtSummarytable.Rows.Count > 0 Then
                    Dim results As DataRow() = DtSummarytable.Select("Joborderid='" & Joborderid & "'")
                    If results.Length <> 1 Then
                        dtSum = objJobOrderdatabase.ViewMasterForExport(Joborderid)
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
                        dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                        Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                        dr("ExtraQuantity") = ExtraQty
                        dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                        DtSummarytable.Rows.Add(dr)
                    End If
                Else
                    dtSum = objJobOrderdatabase.ViewMasterForExport(Joborderid)
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
                    dr("ShipmentStatus") = dtSum.Rows(0)("ShipmentStatuss")
                    Dim ExtraQty As Decimal = Math.Round(((ReturnQty * dtSum.Rows(0)("ExtraQuantity")) / 100) + ReturnQty, 0)
                    dr("ExtraQuantity") = ExtraQty
                    dr("InspectionDate") = dtSum.Rows(0)("InspectionDate")
                    DtSummarytable.Rows.Add(dr)
                End If
            Next
            Session("DtSummarytable") = DtSummarytable
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
End Class


Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.DataView
Public Class JobOrderDatabaseView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim UserID, Roleid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserID = CLng(Session("Userid"))
        Roleid = CLng(Session("RoleId"))
        If Not Page.IsPostBack Then
            Try
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Then
                    btnDetailSection.Visible = False
                    btndAdd.Visible = False
                    dgViewMaster.Columns(12).Visible = False
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
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("JOB ORDER INDEX")
    End Sub
    Sub GetRights()
       Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(UserID, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btndAdd.Enabled = True
            Else
                btndAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgViewMaster.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkCopy"), ImageButton)
                    Dim lnkFabric As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkFabric"), ImageButton)
                    Dim lnkAccessoriese As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                    Dim lnkPRODUCTION As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkPRODUCTION"), ImageButton)
                    Dim lnkOtherHeadPDF As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkOtherHeadPDF"), ImageButton)
                    Dim lnkPRODUCTIONN As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkPRODUCTIONN"), ImageButton)
                    Dim lnkTNA As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkTNA"), ImageButton)
                    lnkEditt.Enabled = True
                    lnkCopy.Enabled = True
                    lnkFabric.Enabled = True
                    lnkAccessoriese.Enabled = True
                    lnkPRODUCTION.Enabled = True
                    lnkOtherHeadPDF.Enabled = True
                    lnkPRODUCTIONN.Enabled = True
                    lnkTNA.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgViewMaster.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkCopy"), ImageButton)
                    Dim lnkFabric As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkFabric"), ImageButton)
                    Dim lnkAccessoriese As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                    Dim lnkPRODUCTION As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkPRODUCTION"), ImageButton)
                    Dim lnkOtherHeadPDF As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkOtherHeadPDF"), ImageButton)
                    Dim lnkPRODUCTIONN As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkPRODUCTIONN"), ImageButton)
                    Dim lnkTNA As ImageButton = CType(dgViewMaster.Items(x).FindControl("lnkTNA"), ImageButton)
                    lnkEditt.Enabled = False
                    lnkCopy.Enabled = False
                    lnkFabric.Enabled = False
                    lnkAccessoriese.Enabled = False
                    lnkPRODUCTION.Enabled = False
                    lnkOtherHeadPDF.Enabled = False
                    lnkPRODUCTIONN.Enabled = False
                    lnkTNA.Enabled = False
                Next
            End If
        End If
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
        GetRights()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
        If DtCheck.Rows(0)("Department") = "Export" Then
                btnDetailSection.Visible = False
                btndAdd.Visible = False
                dgViewMaster.Columns(12).Visible = False
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
            End If
    End Sub
    Function LoadMasterData() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2ForDirectorView()
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
                'Kashi
                DtSummarytable.Columns.Add("PONo", GetType(String))
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
                                'Kashi
                                dr("PONo") = dtSum.Rows(0)("PONo")
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
                            'Kashi
                            dr("PONo") = dtSum.Rows(0)("PONo")
                            dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                            DtSummarytable.Rows.Add(dr)
                        End If
                    Next
                    Session("DtSummarytable") = DtSummarytable
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2(UserID)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForDALNew2(UserID)
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
                'Kashi
                DtSummarytable.Columns.Add("PONo", GetType(String))
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
                                'Kashi
                                dr("PONo") = dtSum.Rows(0)("PONo")
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
                            'Kashi
                            dr("PONo") = dtSum.Rows(0)("PONo")
                            dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                            DtSummarytable.Rows.Add(dr)
                        End If
                    Next
                    Session("DtSummarytable") = DtSummarytable
                End If
            End If
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
    Function LoadMasterDataForSearching() As ICollection
        Dim objMasterDataView As DataView
        Dim dtSum, dtSumstyle As DataTable
        Dim dr As DataRow = Nothing
        Dim dtSummaryViewData As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingNew2ForDirectorView(cmbSeason.SelectedValue)
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
                'Kashi
                DtSummarytable.Columns.Add("PONo", GetType(String))
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
                                'Kashi
                                dr("PONo") = dtSum.Rows(0)("PONo")
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
                            'Kashi
                            dr("PONo") = dtSum.Rows(0)("PONo")
                            dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                            DtSummarytable.Rows.Add(dr)
                        End If
                    Next
                    Session("DtSummarytable") = DtSummarytable
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingNew(245, cmbSeason.SelectedValue)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSearchingNew2(UserID, cmbSeason.SelectedValue)
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
            End If
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
                    Response.Redirect("TNAChartView.aspx?JobOrderID=" & Joborderid & "")
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
                    Report.Load(Server.MapPath("..\Reports/CostSheetANew2.rpt"))
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
                    Report.SetParameterValue(4, JobOrderID)
                    Report.SetParameterValue(5, JobOrderID)
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
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
        If DtCheck.Rows(0)("Department") = "Export" Then
            btnDetailSection.Visible = False
            btndAdd.Visible = False
            dgViewMaster.Columns(12).Visible = False
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
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                objDataTable = objJobOrderdatabase.ViewNewForTFANew3ForDirectorView()
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Then
                    objDataTable = objJobOrderdatabase.ViewNewForTFANew2New(245)
                Else
                    objDataTable = objJobOrderdatabase.ViewNewForTFANew3(UserID)
                End If
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
        Dim dtSummaryViewDataPO As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserID)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoNewForDirectorView(txtSearch.Text)
                dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNew2ForDirectorView(txtSearch.Text)
                dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleNew2ForDirectorView(txtSearch.Text)
                If dtSummaryViewDataSR.Rows.Count > 0 Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONew3ForDirectorVise(txtSearch.Text)
                ElseIf dtSummaryViewDataCS.Rows.Count > 0 Then
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerNewForDirectorView(txtSearch.Text)
                ElseIf dtSummaryViewDataST.Rows.Count > 0 Then

                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleNewForDirectorVise(txtSearch.Text)
                Else
                    dtSummaryViewData = objJobOrderdatabase.ViewNewForTFANew4DirectorVise()
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
                'Kashi
                DtSummarytable.Columns.Add("PONo", GetType(String))
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
                                'Kashi
                                dr("PONo") = dtSum.Rows(0)("PONo")
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
                            'Kashi
                            dr("PONo") = dtSum.Rows(0)("PONo")
                            dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                            dr("Model") = dtSum.Rows(0)("Model")
                            DtSummarytable.Rows.Add(dr)
                        End If
                    Next
                    Session("DtSummarytable") = DtSummarytable
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                If DtCheck.Rows(0)("Department") = "Export" Then
                    dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoNewForNew(txtSearch.Text)
                    dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNewwww(txtSearch.Text)
                    dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleNewwww(txtSearch.Text)
                    dtSummaryViewDataPO = objJobOrderdatabase.ViewNewForTFAPONoNewwww(txtSearch.Text)
                Else
                    dtSummaryViewDataSR = objJobOrderdatabase.ViewNewForTFASrnoNew(UserID, txtSearch.Text)
                    dtSummaryViewDataCS = objJobOrderdatabase.ViewNewForTFACustomerNew2(UserID, txtSearch.Text)
                    dtSummaryViewDataST = objJobOrderdatabase.ViewNewForTFAStyleNew2(UserID, txtSearch.Text)
                    dtSummaryViewDataPO = objJobOrderdatabase.ViewNewForTFAPONo(UserID, txtSearch.Text)
                End If
                If dtSummaryViewDataSR.Rows.Count > 0 Then
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONewww(txtSearch.Text)
                    Else
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForSRNONew3(UserID, txtSearch.Text)
                    End If
                ElseIf dtSummaryViewDataCS.Rows.Count > 0 Then
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerForNMewww(txtSearch.Text)
                    Else
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForCustomerNew(UserID, txtSearch.Text)
                    End If
                ElseIf dtSummaryViewDataST.Rows.Count > 0 Then
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleForNew(245, txtSearch.Text)
                    Else
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForStyleNew(UserID, txtSearch.Text)
                    End If
                ElseIf dtSummaryViewDataPO.Rows.Count > 0 Then
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForPONo(245, txtSearch.Text)
                    Else
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFAForPONoNew(UserID, txtSearch.Text)
                    End If
                Else
                    If DtCheck.Rows(0)("Department") = "Export" Then
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFANewwwwwww()
                    Else
                        dtSummaryViewData = objJobOrderdatabase.ViewNewForTFANew4(UserID)
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
                'Kashi
                DtSummarytable.Columns.Add("PONo", GetType(String))
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
                                'Kashi
                                dr("PONo") = dtSum.Rows(0)("PONo")
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
                            'Kashi
                            dr("PONo") = dtSum.Rows(0)("PONo")
                            dr("CustomerOrder") = dtSum.Rows(0)("CustomerOrder")
                            dr("Model") = dtSum.Rows(0)("Model")
                            DtSummarytable.Rows.Add(dr)
                        End If
                    Next
                    Session("DtSummarytable") = DtSummarytable
                End If
            End If
        End If
        objMasterDataView = New DataView(Session("DtSummarytable"))
        Return objMasterDataView
    End Function
End Class

